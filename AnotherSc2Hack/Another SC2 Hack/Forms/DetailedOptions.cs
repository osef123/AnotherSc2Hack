using System;
using System.Drawing;
using System.Windows.Forms;

namespace Another_SC2_Hack.Forms
{
    public partial class DetailedOptions : Form
    {
        private string _strForm = null;
        private MainForm _mymain = null;
        private Warning_Builder _wbWarning = null;
        public DetailedOptions(string s, MainForm fr)
        {
            _strForm = s;
            _mymain = fr;
            InitializeComponent();
        }

        #region Variables

        /* Maphack */
        private Color _cDefensive,
                      _cMedic,
                      _cDT,
                      _cNexi;

        private bool _bDefensive,
                     _bMedic,
                     _bDT,
                     _bNexi;


        /* Notification */

        private bool _bSupply,
                     _bMule,
                     _bUnit,
                     _bStructure;

        #endregion

        private void DetailedOptions_Load(object sender, EventArgs e)
        {
            InitialDetails(_strForm);

            /* Handl ethe tooltips */
            ToolTipHandling();
        }

        private void InitialDetails(string s)
        {
            Width = 400;

            switch (s)
            {
                case "map":
                    Text = "Detailed information about: Maphack";
                    _bDefensive = _mymain._bMapColorDefensive;
                    _bMedic = _mymain._bMapColorMedics;
                    _bDT = _mymain._bMapColorDT;
                    _bNexi = _mymain._bMapColorNexiOcQueen;
                    _cDefensive = _mymain._cMapColorDefensive;
                    _cMedic = _mymain._cMapColorMedics;
                    _cDT = _mymain._cMapColorDT;
                    _cNexi = _mymain._cMapColorNexiOcQueen;

                    cbDefensive.SelectedItem = _bDefensive.ToString();
                    cbMedivacs.SelectedItem = _bMedic.ToString();
                    cbDT.SelectedItem = _bDT.ToString();
                    cbQueenOcNexus.SelectedItem = _bNexi.ToString();
                    btnColorDefensive.Text = _cDefensive.Name;
                    btnColorDefensive.ForeColor = _cDefensive;
                    btnColorMedivac.Text = _cMedic.Name;
                    btnColorMedivac.ForeColor = _cMedic;
                    btnColorDT.Text = _cDT.Name;
                    btnColorDT.ForeColor = _cDT;
                    btnColorNexi.Text = _cNexi.Name;
                    btnColorNexi.ForeColor = _cNexi;

                    gbMaphack.Visible = true;
                    break;

                case "not":
                    Text = "Detaailed information about: Notification";
                    cbSupplyWarning.Checked = _mymain._bSupply;
                    cbMule.Checked = _mymain._bMule;
                    cbUnitWarning.Checked = _mymain._bUnit;
                    cbBuildingWarning.Checked = _mymain._bStructures;

                    gbNotification.Visible = true;
                    gbNotification.Location = new Point(12, 12);
                    break;

            }

            
        }

        /*** Just close ***/
        private void btnDecline_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*** Save the settings ***/
        private void btnAccept_Click(object sender, EventArgs e)
        {
            SaveSettings();

            Close();
        }

        /*** This will save the settings ***/
        private void SaveSettings()
        {
            switch (_strForm)
            {
                case "map":
                    _mymain._cMapColorDefensive = _cDefensive;
                    _mymain._cMapColorMedics = _cMedic;
                    _mymain._cMapColorDT = _cDT;
                    _mymain._cMapColorNexiOcQueen = _cNexi;

                    _mymain._bMapColorDefensive = _bDefensive;
                    _mymain._bMapColorMedics = _bMedic;
                    _mymain._bMapColorDT = _bDT;
                    _mymain._bMapColorNexiOcQueen = _bNexi;
                    break;

                case "not":
                    _mymain._bSupply = _bSupply;
                    _mymain._bMule = _bMule;
                    _mymain._bUnit = _bUnit;
                    _mymain._bStructures = _bStructure;
                    break;
            }

            _mymain.CreatSaveFile();
            
        }

        /*** Color for Defensive structure ***/
        private void btnColorDefensive_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            var res = cd.ShowDialog();

            if (res.Equals(DialogResult.OK))
                _cDefensive = cd.Color;

            btnColorDefensive.Text = _cDefensive.Name;
            btnColorDefensive.ForeColor = _cDefensive;
        }

        /*** Color for Medic and Warp Prism ***/
        private void btnColorMedivac_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            var res = cd.ShowDialog();

            if (res.Equals(DialogResult.OK))
                _cMedic = cd.Color;

            btnColorMedivac.Text = _cMedic.Name;
            btnColorMedivac.ForeColor = _cMedic;
        }

        /*** Color for DT ***/
        private void btnColorDT_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            var res = cd.ShowDialog();

            if (res.Equals(DialogResult.OK))
                _cDT = cd.Color;

            btnColorDT.Text = _cDT.Name;
            btnColorDT.ForeColor = _cDT;
        }

        /*** Color for Nexi, OC and Queen ***/
        private void btnColorNexi_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            var res = cd.ShowDialog();

            if (res.Equals(DialogResult.OK))
                _cNexi = cd.Color;

            btnColorNexi.Text = _cNexi.Name;
            btnColorNexi.ForeColor = _cNexi;
        }

        /*** Activate the Defensive- coloring ***/
        private void cbDefensive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bDefensive = Convert.ToBoolean(cbDefensive.SelectedItem);
        }

        /*** Activate the Medivac/ Wapr Prism coloring ***/
        private void cbMedivacs_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bMedic = Convert.ToBoolean(cbMedivacs.SelectedItem);
        }

        /*** Activate the DT coloring ***/
        private void cbDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bDT = Convert.ToBoolean(cbDT.SelectedItem);
        }

        /*** Activate the Nexi, OC, Queen coloring ***/
        private void cbQueenOcNexus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bNexi = Convert.ToBoolean(cbQueenOcNexus.SelectedItem);
        }

        /*** Configure Buildings ***/
        private void btnConfigureBuildings_Click(object sender, EventArgs e)
        {
            _wbWarning = new Warning_Builder("bui");
            _wbWarning.ShowDialog();
        }

        /*** Configure Units ***/
        private void btnConfigureUnits_Click(object sender, EventArgs e)
        {
            _wbWarning = new Warning_Builder("uni");
            _wbWarning.ShowDialog();
        }

        /*** Enable Supply- warning ***/
        private void cbSupplyWarning_CheckedChanged(object sender, EventArgs e)
        {
            _bSupply = cbSupplyWarning.Checked;
        }

        /*** Enable Building- warning ***/
        private void cbBuildingWarning_CheckedChanged(object sender, EventArgs e)
        {
            _bStructure = cbBuildingWarning.Checked;
        }

        /*** Enable Unit- warning ***/
        private void cbUnitWarning_CheckedChanged(object sender, EventArgs e)
        {
            _bUnit = cbUnitWarning.Checked;
        }

        /*** Enable Mule- Warning ***/
        private void cbMule_CheckedChanged(object sender, EventArgs e)
        {
            _bMule = cbMule.Checked;
        }

        /*** Setting the tooltips ***/
        private void ToolTipHandling()
        {
            ttMaininfo.SetToolTip(cbMule, "This will print out a warning when:\nyour OC reaches 50 Energy\nyour Queen has 25 Energy\nyour Nexus has 25 Energy");
            ttMaininfo.SetToolTip(cbSupplyWarning, "A supply- warning will be printed when you reach different stanges of the game");

            ttMaininfo.SetToolTip(cbDefensive, "Will color all enemy defensive structures");
            ttMaininfo.SetToolTip(cbDT, "Will color all enemy DT's");
            ttMaininfo.SetToolTip(cbMedivacs, "Will color all enemy Medivacs");
            ttMaininfo.SetToolTip(cbQueenOcNexus, "Will color your Nexus/ Queen/ OC when reaching enough Energy");

            ttMaininfo.SetToolTip(btnColorDefensive, "Change the color of the defensive structures");
            ttMaininfo.SetToolTip(btnColorDT, "Change the color of the DTs");
            ttMaininfo.SetToolTip(btnColorMedivac, "Change the color of the Medivacs");
            ttMaininfo.SetToolTip(btnColorNexi, "Change the color of the Nexi/ Queens/ OCs");

            ttMaininfo.SetToolTip(btnAccept, "Save the settings");
            ttMaininfo.SetToolTip(btnDecline, "Don't save the settings and just leave");
        }
    }
}
