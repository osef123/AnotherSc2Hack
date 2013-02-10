using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace Another_SC2_Hack.Forms
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        #region Variables

        private bool _bToggle;      //Toggles "begin search"
        private int _iRound;
        private const string StrOnlinePath = @"https://dl.dropbox.com/u/62845853/AnotherSc2Hack/UpdateFiles/version";
        private string _strDownloadString = string.Empty;
        private int _iCountTimeOuts = 0;
        private const int IMaxTimeOuts = 10;

        #endregion 

        /* Makes a rotating star in the Title */
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            if (!_bToggle)
                return;

            Text = BounceLabel(_iRound) + "   -   Searching";

            _iRound++;
            if (_iRound > 7)
                _iRound = 0;

        }

        /* Loads the Update- deamon */
        private void Update_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            btnAbort.Enabled = false;
            btnDownload.Enabled = false;

            /* Begin Search */
            _bToggle = true;

            new Thread(InitSearch).Start();
        }

        /* Actual search- routine */
        public void InitSearch()
        {
            TryAnotherRound:

            /* We ping the Server first to exclude exceptions! */
            var myPing = new Ping();

            var myResult = myPing.Send("Dropbox.com", 10);

            if (myResult != null && myResult.Status != IPStatus.Success)
            {
                if (_iCountTimeOuts >= IMaxTimeOuts)
                {
                    MessageBox.Show("Can not reach Server!\n\nTry later!", "FAILED");
                    Close();
                    return;
                }

                _iCountTimeOuts++;
                goto TryAnotherRound;
                
            }


            /* Connect to server */
            var privateWebClient = new WebClient();

            string strSource = string.Empty;

            try
            {
                strSource = privateWebClient.DownloadString(StrOnlinePath);
            }

            catch
            {
                MessageBox.Show("Can not reach Server!\n\nTry later!", "FAILED");
                Close();
                return;
            }

            /* Build version from this file */
            var curVer = new Version(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

            /* Build version from online- file (string) */
            var newVer = new Version(GetStringItems(1, strSource));

            /* Version- check */
            if (newVer > curVer)
            {
                _strDownloadString = GetStringItems(2, strSource);
                ReadChangesFile(GetStringItems(3, strSource));

                btnAbort.Enabled = true;
                btnDownload.Enabled = true;
                return;
            }

            _bToggle = false;
            Text = "Done! - No new Version found!";
            Close();
        }


        /* Parses out a string of Line x */
        private string GetStringItems(int line, string source)
        {
            /* Is Like
             *1 [AnotherSc2Hack]
              2  Version=1.0.0.1
              3  Path=https://dl.dropbox.com/u/62845853/AnotherSc2Hack/Binaries/Another%20SC2%20Hack.exe
              4  Changes=https://dl.dropbox.com/u/62845853/AnotherSc2Hack/UpdateFiles/Changes */

            var strmoreSource = source.Split('\n');
            if (strmoreSource[line].Contains("\r"))
                strmoreSource[line] = strmoreSource[line].Substring(0, strmoreSource[line].IndexOf('\r'));

            return strmoreSource[line];
        }

        /* Make "animation" */
        private string BounceLabel(int iPhase)
        {
            if (iPhase.Equals(0))
                return "|";

            if (iPhase.Equals(1))
                return "/";

            if (iPhase.Equals(2))
                return "-";

            if (iPhase.Equals(3))
                return "\\";

            if (iPhase.Equals(4))
                return "|";

            if (iPhase.Equals(5))
                return "/";

            if (iPhase.Equals(6))
                return "-";

            if (iPhase.Equals(7))
                return "\\";

            return "*";
        }

        /* Read changes */
        private void ReadChangesFile(string path)
        {
            _bToggle = true;

            var privWebClient = new WebClient();
            var strSource = privWebClient.DownloadString(path);

            rtbOutput.Text = strSource;

            _bToggle = false;
            Text = "Done!";
        }

        /* Close this form */
        private void btnAbort_Click(object sender, EventArgs e)
        {
            Close();
        }

        /* Start the downloader- deamon */
        private void btnDownload_Click(object sender, EventArgs e)
        {
            var fi = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var inf = new ProcessStartInfo("NewDownloaderDeamon.exe", 
                _strDownloadString + " " 
                + "\"" 
                + Application.StartupPath +  "\\" + fi.Name + "\"");

            Process.Start(inf);
        }
    }
}
