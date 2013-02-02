using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Another_SC2_Hack.Classes;
using System.IO;

namespace Another_SC2_Hack.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /*** Set the basic Buffered Forms ***/
        private BufferForm _bfRes;
        private BufferForm _bfInc;
        private BufferForm _bfArm;
        private BufferForm _bfApm;
        private BufferForm _bfMap;
        private BufferForm _bfWor;
        private BufferForm _bfNot;

        /* Variables for the Position for the settings- group- boxes */
        private const int Max = 6;
        private int _iCurrent = 0;

        private PlayerInfo _pInfo;
        private Update _upCheckforUpdates;

        #region Variables used to safe/ load settings

        /* Ressources */
        public int _iResInterval;
        public bool _bResRemoveAi;
        public bool _bResRemoveLocalplayer;
        public bool _bResRemoveAllie;
        public bool _bResRemoveDeadPlayer;
        public bool _bResRemoveObserver;
        public bool _bResRemoveReferee;
        public Font _fResPanelFont;
        public Keys _kResHotkey1,
                     _kResHotkey2,
                     _kResHotkey3;

        public string _sResShortcut,
                       _sResPos,
                       _sResSize;

        public int _iResWidth,
                   _iResHeigth,
                   _iResX,
                   _iResY,
                   _iResOpacity;

        /* Income */
        public int _iIncInterval;
        public bool _bIncRemoveAi;
        public bool _bIncRemoveLocalplayer;
        public bool _bIncRemoveAllie;
        public bool _bIncRemoveDeadPlayer;
        public bool _bIncRemoveObserver;
        public bool _bIncRemoveReferee;
        public Font _fIncPanelFont;
        public Keys _kIncHotkey1,
                     _kIncHotkey2,
                     _kIncHotkey3;
        public string _sIncShortcut,
                       _sIncPos,
                       _sIncSize;
        public int _iIncWidth,
                    _iIncHeigth,
                    _iIncX,
                    _iIncY,
                    _iIncOpacity;

        /* Army */
        public int _iArmInterval;
        public bool _bArmRemoveAi;
        public bool _bArmRemoveLocalplayer;
        public bool _bArmRemoveAllie;
        public bool _bArmRemoveDeadPlayer;
        public bool _bArmRemoveObserver;
        public bool _bArmRemoveReferee;
        public Font _fArmPanelFont;
        public Keys _kArmHotkey1,
                     _kArmHotkey2,
                     _kArmHotkey3;
        public string _sArmShortcut,
                       _sArmPos,
                       _sArmSize;
        public int _iArmWidth,
                    _iArmHeigth,
                    _iArmX,
                    _iArmY,
                    _iArmOpacity;

        /* Apm */
        public int _iApmInterval;
        public bool _bApmRemoveAi;
        public bool _bApmRemoveLocalplayer;
        public bool _bApmRemoveAllie;
        public bool _bApmRemoveDeadPlayer;
        public bool _bApmRemoveObserver;
        public bool _bApmRemoveReferee;
        public Font _fApmPanelFont;
        public Keys _kApmHotkey1,
                     _kApmHotkey2,
                     _kApmHotkey3;
        public string _sApmShortcut,
                       _sApmPos,
                       _sApmSize;
        public int _iApmWidth,
                    _iApmHeigth,
                    _iApmX,
                    _iApmY,
                    _iApmOpacity;

        /* Worker */
        public int _iWorInterval;
        public Font _fWorPanelFont;
        public Keys _kWorHotkey1,
                     _kWorHotkey2,
                     _kWorHotkey3;
        public string _sWorShortcut,
                       _sWorPos,
                       _sWorSize;
        public int _iWorWidth,
                    _iWorHeigth,
                    _iWorX,
                    _iWorY,
                    _iWorOpacity;

        /* Maphack */
        public int _iMapInterval;
        public bool _bMapRemoveAi;
        public bool _bMapRemoveLocalplayer;
        public bool _bMapRemoveAllie;
        public Keys _kMapHotkey1,
                     _kMapHotkey2,
                     _kMapHotkey3;
        public string _sMapShortcut,
                       _sMapPos,
                       _sMapSize;
        public Color _cMapColorofDestinationLine;
        public bool _bShowDestinationLine;
        public int _iMapWidth,
                    _iMapHeigth,
                    _iMapX,
                    _iMapY,
                    _iMapOpacity;

        /* Notification */
        public int _iNotInterval;

        public Keys _kNotHotkey1,
                    _kNotHotkey2,
                    _kNotHotkey3;

        public string _sNotShortcut,
                      _sNotSize,
                      _sNotPos;

        public int _iNotWidth,
                   _iNotHeigth,
                   _iNotX,
                   _iNotY,
                   _iNotOpacity;

        public Font _fNotPanelFont;



        #endregion
     

        private void MainForm_Load(object sender, EventArgs e)
        {
            /* Change window Title */
            var rnd = new Random();
            Text = rnd.Next(0, 999999999).ToString(CultureInfo.InvariantCulture);


            while (_fResPanelFont == null)
            {
                if (File.Exists("Settings.cfg"))
                    ReadSaveFile();

                else
                {
                    /* Set standard values */
                    SetStandardValues();
                    Various.InitResolution(this);
                }
            }


            InsertDataIntoControl();

            pnlShow.MaxItem = Max;
            pnlShow.CurrentItem = 1;

            /* Here a check is performed which needs SC2 */
            if (Various.StarcraftAvailable())
                _pInfo = new PlayerInfo(new BufferForm(Typo.BufferformType.Dummy, this));

            /* Change Windowstyle */
            ChangeWindowStyle();

            /* Update at startup */
            fsSecondCheckforUpdate_Click(sender, e);

            /* Set text for Resolution Label */
            if (Various.CheckResolution())
            {
                lblResolution.ForeColor = Color.Green;
                lblResolution.Text = "Your resolution is supported!";
            }

            else
            {
                lblResolution.ForeColor = Color.Red;
                lblResolution.Text = "Your resolution is NOT supported!";
            }

            /* Activate timer */
            tmrTick.Enabled = true;
        }

        /*** Our Maintimer, will handle the toggle for the Panels ***/
        private void tmrTick_Tick(object sender, EventArgs e)
        {
            /* Leave if SC2 is not found */
            if (Various.StarcraftAvailable() && _pInfo == null)
                _pInfo = new PlayerInfo(new BufferForm(Typo.BufferformType.Dummy, this));

            if (!Various.StarcraftAvailable())
            {
                _pInfo = null;
                lblGametype.Text = "STARCRAFT 2 NOT FOUND";
                lblShowFps.Text = "STARCRAFT 2 NOT FOUND";
                slblTimer.Text = "STARCRAFT 2 NOT FOUND";
                slblTimer.ForeColor = Color.Black;

                return;
            }
             

            /* We have to refresh this */
            HandleInput(ref _bfRes, Typo.BufferformType.Ressource, _sResShortcut, _kResHotkey1, _kResHotkey2, _kResHotkey3);
            HandleInput(ref _bfInc, Typo.BufferformType.Income, _sIncShortcut, _kIncHotkey1, _kIncHotkey2, _kIncHotkey3);
            HandleInput(ref _bfApm, Typo.BufferformType.Apm, _sApmShortcut, _kApmHotkey1, _kApmHotkey2, _kApmHotkey3);
            HandleInput(ref _bfArm, Typo.BufferformType.Army, _sArmShortcut, _kArmHotkey1, _kArmHotkey2, _kArmHotkey3);
            HandleInput(ref _bfWor, Typo.BufferformType.Worker, _sWorShortcut, _kWorHotkey1, _kWorHotkey2, _kWorHotkey3);
            HandleInput(ref _bfMap, Typo.BufferformType.Maphack, _sMapShortcut, _kMapHotkey1, _kMapHotkey2, _kMapHotkey3);
            HandleInput(ref _bfNot, Typo.BufferformType.Notification, _sNotShortcut, _kNotHotkey1, _kNotHotkey2, _kNotHotkey3);

            /* Fill Statuslabel */
            FillStatuslabel();

            /* Show Fps in Label */
            ShowFps(); 
        }

        /*** Change font for a Panel ***/
        private void btnResFont_Click(object sender, EventArgs e)
        {
            var fd = new FontDialog();
            
            
            DialogResult dr = fd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                switch (_iCurrent)
                {
                    case 0:
                        _fResPanelFont = fd.Font;
                        break;

                    case 1:
                        _fIncPanelFont = fd.Font;
                        break;

                    case 2:
                        _fWorPanelFont = fd.Font;
                        break;

                    case 3:
                        _fApmPanelFont = fd.Font;
                        break;

                    case 4:
                        _fArmPanelFont = fd.Font;
                        break;

                    case 6:
                        _fNotPanelFont = fd.Font;
                        break;
                }
            }

            InsertDataIntoControl();
        }

        /*** Set some standard values ***/
        private void SetStandardValues()
        {
            _iResInterval = 100;
            _iIncInterval = 100;
            _iArmInterval = 100;
            _iApmInterval = 100;
            _iWorInterval = 100;
            _iMapInterval = 100;
            _iNotInterval = 100;

            _bResRemoveAi = true;
            _bIncRemoveAi = true;
            _bArmRemoveAi = true;
            _bApmRemoveAi = true;
            _bMapRemoveAi = true;

            _bResRemoveLocalplayer = true;
            _bIncRemoveLocalplayer = true;
            _bArmRemoveLocalplayer = true;
            _bApmRemoveLocalplayer = true;
            _bMapRemoveLocalplayer = true;

            _bResRemoveAllie = true;
            _bIncRemoveAllie = true;
            _bApmRemoveAllie = true;
            _bArmRemoveAllie = true;
            _bMapRemoveAllie = true;

            _bResRemoveDeadPlayer = true;
            _bIncRemoveDeadPlayer = true;
            _bArmRemoveDeadPlayer = true;
            _bApmRemoveDeadPlayer = true;

            _bResRemoveObserver = true;
            _bIncRemoveObserver = true;
            _bApmRemoveObserver = true;
            _bArmRemoveObserver = true;

            _bResRemoveReferee = true;
            _bIncRemoveReferee = true;
            _bArmRemoveReferee = true;
            _bApmRemoveReferee = true;

            _fResPanelFont = new Font("Century Gothic", 12, FontStyle.Bold);
            _fIncPanelFont = new Font("Century Gothic", 12, FontStyle.Bold);
            _fArmPanelFont = new Font("Century Gothic", 12, FontStyle.Bold);
            _fApmPanelFont = new Font("Century Gothic", 12, FontStyle.Bold);
            _fWorPanelFont = new Font("Century Gothic", 12, FontStyle.Bold);
            _fNotPanelFont = new Font("Century Gothic", 12, FontStyle.Bold);

            _kResHotkey1 = Keys.ControlKey;
            _kIncHotkey1 = Keys.ControlKey;
            _kArmHotkey1 = Keys.ControlKey;
            _kApmHotkey1 = Keys.ControlKey;
            _kWorHotkey1 = Keys.ControlKey;
            _kMapHotkey1 = Keys.ControlKey;
            _kNotHotkey1 = Keys.ControlKey;

            _kResHotkey2 = Keys.Menu;
            _kIncHotkey2 = Keys.Menu;
            _kArmHotkey2 = Keys.Menu;
            _kApmHotkey2 = Keys.Menu;
            _kWorHotkey2 = Keys.Menu;
            _kMapHotkey2 = Keys.Menu;
            _kNotHotkey2 = Keys.Menu;

            _kResHotkey3 = Keys.NumPad1;
            _kIncHotkey3 = Keys.NumPad2;
            _kArmHotkey3 = Keys.NumPad8;
            _kApmHotkey3 = Keys.NumPad7;
            _kWorHotkey3 = Keys.NumPad3;
            _kMapHotkey3 = Keys.NumPad5;
            _kNotHotkey3 = Keys.NumPad9;

            _sResShortcut = "/tg";
            _sIncShortcut = "/ic";
            _sArmShortcut = "/am";
            _sApmShortcut = "/ap";
            _sWorShortcut = "/wc";
            _sMapShortcut = "/mh";
            _sNotShortcut = "/nf";

            _sResPos = "/atg";
            _sIncPos = "/aic";
            _sArmPos = "/aam";
            _sApmPos = "/aap";
            _sWorPos = "/awc";
            _sMapPos = "/amh";
            _sNotPos = "/anf";

            _sResSize = "/stg";
            _sIncSize = "/sic";
            _sArmSize = "/sam";
            _sApmSize = "/sap";
            _sWorSize = "/swc";
            _sMapSize = "/smh";
            _sNotSize = "/snf";

            _iResWidth = 550;
            _iIncWidth = 550;
            _iArmWidth = 550;
            _iApmWidth = 550;
            _iWorWidth = 150;
            _iMapWidth = 262;
            _iNotWidth = 378;

            _iResHeigth = 40;
            _iIncHeigth = 40;
            _iArmHeigth = 40;
            _iApmHeigth = 40;
            _iWorHeigth = 40;
            _iMapHeigth = 258;
            _iNotHeigth = 110;

            _iResX = 1312;
            _iIncX = 1316;
            _iArmX = 1317;
            _iApmX = 5;
            _iWorX = 1319;
            _iMapX = 28;
            _iNotX = 50;

            _iResY = 44;
            _iIncY = 328;
            _iArmY = 629;
            _iApmY = 64;
            _iWorY = 826;
            _iMapY = 808;
            _iNotY = 50;

            _iResOpacity = 80;
            _iIncOpacity = 80;
            _iApmOpacity = 80;
            _iArmOpacity = 80;
            _iWorOpacity = 80;
            _iMapOpacity = 100;
            _iNotOpacity = 80;



            

            _bShowDestinationLine = true;
            _cMapColorofDestinationLine = Color.Yellow;
        }

        /*** Put the data into the controls ***/
        private void InsertDataIntoControl()
        {
            /* Change the content of the controls
             * based on the selected Index 
             * 0 = Res
             * 1 = Inc
             * 2 = Wor
             * 3 = Apm
             * 4 = Arm
             * 5 = Map 
             * 6 = Not */

            switch (_iCurrent)
            {
                //Ressources
                case 0:
                    //Data
                    txtResRef.Text = _iResInterval.ToString(CultureInfo.InvariantCulture);
                    cbResRemAI.SelectedItem = _bResRemoveAi.ToString();
                    cbResRemLocal.SelectedItem = _bResRemoveLocalplayer.ToString();
                    cbResRemAllie.SelectedItem = _bResRemoveAllie.ToString();
                    cbResRemDead.SelectedItem = _bResRemoveDeadPlayer.ToString();
                    cbResRemObs.SelectedItem = _bResRemoveObserver.ToString();
                    cbResRemReferee.SelectedItem = _bResRemoveReferee.ToString();
                    btnResFont.Text = _fResPanelFont.Name;
                    btnResFont.Font = _fResPanelFont;
                    btnColorDestinationLine.Text = "";
                    txtRes1.Text = _kResHotkey1.ToString();
                    txtRes2.Text = _kResHotkey2.ToString();
                    txtRes3.Text = _kResHotkey3.ToString();
                    txtResShortcut.Text = _sResShortcut;
                    txtResPos.Text = _sResPos;
                    txtResSize.Text = _sResSize;
                    btnResFont.Text = _fResPanelFont.Name;
                    gbRes.Text = "Ressources";
                    txtResOpacity.Text = _iResOpacity.ToString(CultureInfo.InvariantCulture);

                    //Controls
                    cbResRemAI.Enabled = true;
                    cbResRemLocal.Enabled = true;
                    cbResRemAllie.Enabled = true;
                    cbResRemDead.Enabled = true;
                    cbResRemObs.Enabled = true;
                    cbResRemReferee.Enabled = true;
                    btnResFont.Enabled = true;
                    btnColorDestinationLine.Enabled = false;
                    cbDestinationLine.Enabled = false;

                    break;

                //Income
                case 1:
                    //Data
                    txtResRef.Text = _iIncInterval.ToString(CultureInfo.InvariantCulture);
                    cbResRemAI.SelectedItem = _bIncRemoveAi.ToString();
                    cbResRemLocal.SelectedItem = _bIncRemoveLocalplayer.ToString();
                    cbResRemAllie.SelectedItem = _bIncRemoveAllie.ToString();
                    cbResRemDead.SelectedItem = _bIncRemoveDeadPlayer.ToString();
                    cbResRemObs.SelectedItem = _bIncRemoveObserver.ToString();
                    cbResRemReferee.SelectedItem = _bIncRemoveReferee.ToString();
                    btnResFont.Text = _fIncPanelFont.Name;
                    btnResFont.Font = _fIncPanelFont;
                    btnColorDestinationLine.Text = "";
                    txtRes1.Text = _kIncHotkey1.ToString();
                    txtRes2.Text = _kIncHotkey2.ToString();
                    txtRes3.Text = _kIncHotkey3.ToString();
                    txtResShortcut.Text = _sIncShortcut;
                    txtResPos.Text = _sIncPos;
                    txtResSize.Text = _sIncSize;
                    btnResFont.Text = _fIncPanelFont.Name;
                    gbRes.Text = "Income";
                    txtResOpacity.Text = _iIncOpacity.ToString(CultureInfo.InvariantCulture);

                    //Controls
                    cbResRemAI.Enabled = true;
                    cbResRemLocal.Enabled = true;
                    cbResRemAllie.Enabled = true;
                    cbResRemDead.Enabled = true;
                    cbResRemObs.Enabled = true;
                    cbResRemReferee.Enabled = true;
                    btnResFont.Enabled = true;
                    btnColorDestinationLine.Enabled = false;
                    cbDestinationLine.Enabled = false;
                    break;

                //Worker
                case 2:
                    //Data
                    txtResRef.Text = _iWorInterval.ToString(CultureInfo.InvariantCulture);
                    cbResRemAI.SelectedItem = "";
                    cbResRemLocal.SelectedItem = "";
                    cbResRemAllie.SelectedItem = "";
                    cbResRemDead.SelectedItem = "";
                    cbResRemObs.SelectedItem = "";
                    cbResRemReferee.SelectedItem = "";
                    btnResFont.Text = _fWorPanelFont.Name;
                    btnResFont.Font = _fWorPanelFont;
                    btnColorDestinationLine.Text = "";
                    txtRes1.Text = _kWorHotkey1.ToString();
                    txtRes2.Text = _kWorHotkey2.ToString();
                    txtRes3.Text = _kWorHotkey3.ToString();
                    txtResShortcut.Text = _sWorShortcut;
                    txtResPos.Text = _sWorPos;
                    txtResSize.Text = _sWorSize;
                    btnResFont.Text = _fWorPanelFont.Name;
                    gbRes.Text = "Worker";
                    txtResOpacity.Text = _iWorOpacity.ToString(CultureInfo.InvariantCulture);

                    //Controls
                    cbResRemAI.Enabled = false;
                    cbResRemLocal.Enabled = false;
                    cbResRemAllie.Enabled = false;
                    cbResRemDead.Enabled = false;
                    cbResRemObs.Enabled = false;
                    cbResRemReferee.Enabled = false;
                    btnResFont.Enabled = true;
                    btnColorDestinationLine.Enabled = false;
                    cbDestinationLine.Enabled = false;
                    break;

                //Apm
                case 3:
                    //Data
                    txtResRef.Text = _iApmInterval.ToString(CultureInfo.InvariantCulture);
                    cbResRemAI.SelectedItem = _bApmRemoveAi.ToString();
                    cbResRemLocal.SelectedItem = _bApmRemoveLocalplayer.ToString();
                    cbResRemAllie.SelectedItem = _bApmRemoveAllie.ToString();
                    cbResRemDead.SelectedItem = _bApmRemoveDeadPlayer.ToString();
                    cbResRemObs.SelectedItem = _bApmRemoveObserver.ToString();
                    cbResRemReferee.SelectedItem = _bApmRemoveReferee.ToString();
                    btnColorDestinationLine.Text = "";
                    btnResFont.Text = _fApmPanelFont.Name;
                    btnResFont.Font = _fApmPanelFont;
                    txtResPos.Text = _sApmPos;
                    txtResSize.Text = _sApmSize;
                    txtRes1.Text = _kApmHotkey1.ToString();
                    txtRes2.Text = _kApmHotkey2.ToString();
                    txtRes3.Text = _kApmHotkey3.ToString();
                    txtResShortcut.Text = _sApmShortcut;
                    btnResFont.Text = _fApmPanelFont.Name;
                    gbRes.Text = "Apm";
                    txtResOpacity.Text = _iApmOpacity.ToString(CultureInfo.InvariantCulture);

                    //Controls
                    cbResRemAI.Enabled = true;
                    cbResRemLocal.Enabled = true;
                    cbResRemAllie.Enabled = true;
                    cbResRemDead.Enabled = true;
                    cbResRemObs.Enabled = true;
                    cbResRemReferee.Enabled = true;
                    btnResFont.Enabled = true;
                    btnColorDestinationLine.Enabled = false;
                    cbDestinationLine.Enabled = false;
                    break;

                //Army
                case 4:
                    //Data
                    txtResRef.Text = _iArmInterval.ToString(CultureInfo.InvariantCulture);
                    cbResRemAI.SelectedItem = _bArmRemoveAi.ToString();
                    cbResRemLocal.SelectedItem = _bArmRemoveLocalplayer.ToString();
                    cbResRemAllie.SelectedItem = _bArmRemoveAllie.ToString();
                    cbResRemDead.SelectedItem = _bArmRemoveDeadPlayer.ToString();
                    cbResRemObs.SelectedItem = _bArmRemoveObserver.ToString();
                    cbResRemReferee.SelectedItem = _bArmRemoveReferee.ToString();
                    btnResFont.Text = _fArmPanelFont.Name;
                    btnResFont.Font = _fArmPanelFont;
                    btnColorDestinationLine.Text = "";
                    txtRes1.Text = _kArmHotkey1.ToString();
                    txtRes2.Text = _kArmHotkey2.ToString();
                    txtRes3.Text = _kArmHotkey3.ToString();
                    txtResShortcut.Text = _sArmShortcut;
                    txtResPos.Text = _sArmPos;
                    txtResSize.Text = _sArmSize;
                    btnResFont.Text = _fArmPanelFont.Name;
                    gbRes.Text = "Army";
                    txtResOpacity.Text = _iArmOpacity.ToString(CultureInfo.InvariantCulture);

                    //Controls
                    cbResRemAI.Enabled = true;
                    cbResRemLocal.Enabled = true;
                    cbResRemAllie.Enabled = true;
                    cbResRemDead.Enabled = true;
                    cbResRemObs.Enabled = true;
                    cbResRemReferee.Enabled = true;
                    btnResFont.Enabled = true;
                    btnColorDestinationLine.Enabled = false;
                    cbDestinationLine.Enabled = false;
                    break;

                //Maphack
                case 5:
                    //Data
                    txtResRef.Text = _iMapInterval.ToString(CultureInfo.InvariantCulture);
                    cbResRemAI.SelectedItem = _bMapRemoveAi.ToString();
                    cbResRemLocal.SelectedItem = _bMapRemoveLocalplayer.ToString();
                    cbResRemAllie.SelectedItem = _bMapRemoveAllie.ToString();
                    btnResFont.Text = "";
                    btnColorDestinationLine.Text = _cMapColorofDestinationLine.Name;
                    btnColorDestinationLine.ForeColor = _cMapColorofDestinationLine;
                    txtRes1.Text = _kMapHotkey1.ToString();
                    txtRes2.Text = _kMapHotkey2.ToString();
                    txtRes3.Text = _kMapHotkey3.ToString();
                    txtResShortcut.Text = _sMapShortcut;
                    txtResPos.Text = _sMapPos;
                    txtResSize.Text = _sMapSize;
                    cbDestinationLine.SelectedItem = _bShowDestinationLine.ToString();
                    gbRes.Text = "Maphack";
                    txtResOpacity.Text = _iMapOpacity.ToString(CultureInfo.InvariantCulture);

                    //Controls
                    cbResRemAI.Enabled = true;
                    cbResRemLocal.Enabled = true;
                    cbResRemAllie.Enabled = true;
                    cbResRemDead.Enabled = false;
                    cbResRemObs.Enabled = false;
                    cbResRemReferee.Enabled = false;
                    btnResFont.Enabled = false;
                    btnColorDestinationLine.Enabled = true;
                    cbDestinationLine.Enabled = true;
                    break;

                //Notification
                case 6:
                    //Data
                    txtResRef.Text = _iNotInterval.ToString(CultureInfo.InvariantCulture);
                    cbResRemAI.SelectedItem = _bArmRemoveAi.ToString();
                    cbResRemLocal.SelectedItem = _bArmRemoveLocalplayer.ToString();
                    cbResRemAllie.SelectedItem = _bArmRemoveAllie.ToString();
                    cbResRemDead.SelectedItem = _bArmRemoveDeadPlayer.ToString();
                    cbResRemObs.SelectedItem = _bArmRemoveObserver.ToString();
                    cbResRemReferee.SelectedItem = _bArmRemoveReferee.ToString();
                    btnResFont.Text = _fNotPanelFont.Name;
                    btnResFont.Font = _fNotPanelFont;
                    btnColorDestinationLine.Text = "";
                    txtRes1.Text = _kNotHotkey1.ToString();
                    txtRes2.Text = _kNotHotkey2.ToString();
                    txtRes3.Text = _kNotHotkey3.ToString();
                    txtResShortcut.Text = _sNotShortcut;
                    txtResPos.Text = _sNotPos;
                    txtResSize.Text = _sNotSize;
                    btnResFont.Text = _fNotPanelFont.Name;
                    gbRes.Text = "Notification";
                    txtResOpacity.Text = _iNotOpacity.ToString(CultureInfo.InvariantCulture);

                    //Controls
                    cbResRemAI.Enabled = false;
                    cbResRemLocal.Enabled = false;
                    cbResRemAllie.Enabled = false;
                    cbResRemDead.Enabled = false;
                    cbResRemObs.Enabled = false;
                    cbResRemReferee.Enabled = false;
                    btnResFont.Enabled = true;
                    btnColorDestinationLine.Enabled = false;
                    cbDestinationLine.Enabled = false;
                    break;


                    
            }
        }

        /*** Read the actual data out of the file ***/
        private void ReadSaveFile()
        {
            var fc = new FontConverter();
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));

            var sr = new StreamReader("Settings.cfg");

            var strSource = sr.ReadToEnd();

            var strAllItems = strSource.Split('\n');

            /* Seperate by keywords!
             * [Ressource]
             * [Income]
             * [Apm]
             * [Army]
             * [Worker]
             * [Maphack] 
             * [Notification]*/
            string[] strKeywords =
                {
                    "[Ressource]",
                    "[Income]",
                    "[Apm]",
                    "[Army]",
                    "[Worker]",
                    "[Maphack]",
                    "[Notification]"
                };

            bool bFlagContinue = false;
            string strCurrentPanelItem = string.Empty;

            /* Remove stupid '\r' from StreamWriter */
            for (var i = 0; i < strAllItems.Length; i++)
            {
                if (strAllItems[i].Contains("\r"))
                {
                    strAllItems[i] = strAllItems[i].Remove(strAllItems[i].IndexOf('\r'), 1);
                }
            }

            /* The important Part */
            for (var i = 0; i < strAllItems.Length; i++)
            {
                /* Check if there is a new Main- Element to associate the Items with another Panel */
                for (var j = 0; j < strKeywords.Length; j++)
                {
                    if (strKeywords[j].Equals(strAllItems[i]))
                    {
                        strCurrentPanelItem = strKeywords[j];
                        bFlagContinue = true;
                        break;
                    }
                }

                /* We don't need to waste time to check if the Element is here */
                if (bFlagContinue)
                {
                    bFlagContinue = false;
                    continue;
                }

                var strCurrentItem = strAllItems[i].Split('=');

                /* Do the Actual Reading- Part*/

                #region Ressources

                if (strCurrentPanelItem.Equals("[Ressource]"))
                {
                    /* Interval */
                    if (strCurrentItem[0] == "Interval")
                        _iResInterval = int.Parse(strCurrentItem[1]);


                    /* Remove AI */
                    if (strCurrentItem[0] == "RemoveAi")
                        _bResRemoveAi = Convert.ToBoolean(strCurrentItem[1]);


                    /* Remove Local Player */
                    if (strCurrentItem[0] == "RemoveLocalPlayer")
                        _bResRemoveLocalplayer = Convert.ToBoolean(strCurrentItem[1]);


                    /* Remove Allie */
                    if (strCurrentItem[0] == "RemoveAllie")
                        _bResRemoveAllie = Convert.ToBoolean(strCurrentItem[1]);


                    /* Remove Dead Player */
                    if (strCurrentItem[0] == "RemoveDeadPlayer")
                        _bResRemoveDeadPlayer = Convert.ToBoolean(strCurrentItem[1]);


                    /* Remove Observer */
                    if (strCurrentItem[0] == "RemoveObserver")
                        _bResRemoveObserver = Convert.ToBoolean(strCurrentItem[1]);


                    /* Remove Referee */
                    if (strCurrentItem[0] == "RemoveReferee")
                        _bResRemoveReferee = Convert.ToBoolean(strCurrentItem[1]);


                    /* Font */
                    if (strCurrentItem[0] == "Font")
                    {
                        var MiniItems =strCurrentItem[1].Split(';');

                        _fResPanelFont = new Font(MiniItems[0], float.Parse(MiniItems[1]));
                    }


                    /* Hotkey 1 */
                    if (strCurrentItem[0] == "Hotkey1")
                        _kResHotkey1 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                    /* Hotkey 2 */
                    if (strCurrentItem[0] == "Hotkey2")
                        _kResHotkey2 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                    /* Hotkey 3 */
                    if (strCurrentItem[0] == "Hotkey3")
                        _kResHotkey3 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                    /* Shortcut Toggle */
                    if (strCurrentItem[0] == "ShortcutToggle")
                        _sResShortcut = strCurrentItem[1];


                    /* Shortcut Pos */
                    if (strCurrentItem[0] == "ShortcutPos")
                        _sResPos = strCurrentItem[1];


                    /* Shortcut Size */
                    if (strCurrentItem[0] == "ShortcutSize")
                        _sResSize = strCurrentItem[1];


                    /* Width */
                    if (strCurrentItem[0] == "Width")
                        _iResWidth = int.Parse(strCurrentItem[1]);


                    /* Heigth */
                    if (strCurrentItem[0] == "Heigth")
                        _iResHeigth = int.Parse(strCurrentItem[1]);


                    /* Pos X */
                    if (strCurrentItem[0] == "PosX")
                        _iResX = int.Parse(strCurrentItem[1]);


                    /* Pos Y */
                    if (strCurrentItem[0] == "PosY")
                        _iResY = int.Parse(strCurrentItem[1]);

                    /* Opacity */
                    if (strCurrentItem[0] == "Opacity")
                        _iResOpacity = int.Parse(strCurrentItem[1]);
                }

                    #endregion

                #region Income

            else if (strCurrentPanelItem.Equals("[Income]"))
            {
                /* Interval */
                if (strCurrentItem[0] == "Interval")
                    _iIncInterval = int.Parse(strCurrentItem[1]);


                /* Remove AI */
                if (strCurrentItem[0] == "RemoveAi")
                    _bIncRemoveAi = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Local Player */
                if (strCurrentItem[0] == "RemoveLocalPlayer")
                    _bIncRemoveLocalplayer = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Allie */
                if (strCurrentItem[0] == "RemoveAllie")
                    _bIncRemoveAllie = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Dead Player */
                if (strCurrentItem[0] == "RemoveDeadPlayer")
                    _bIncRemoveDeadPlayer = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Observer */
                if (strCurrentItem[0] == "RemoveObserver")
                    _bIncRemoveObserver = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Referee */
                if (strCurrentItem[0] == "RemoveReferee")
                    _bIncRemoveReferee = Convert.ToBoolean(strCurrentItem[1]);


                /* Font */
                if (strCurrentItem[0] == "Font")
                {
                    var MiniItems = strCurrentItem[1].Split(';');

                    _fIncPanelFont = new Font(MiniItems[0], float.Parse(MiniItems[1]));
                }


                /* Hotkey 1 */
                if (strCurrentItem[0] == "Hotkey1")
                    _kIncHotkey1 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 2 */
                if (strCurrentItem[0] == "Hotkey2")
                    _kIncHotkey2 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 3 */
                if (strCurrentItem[0] == "Hotkey3")
                    _kIncHotkey3 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Shortcut Toggle */
                if (strCurrentItem[0] == "ShortcutToggle")
                    _sIncShortcut = strCurrentItem[1];


                /* Shortcut Pos */
                if (strCurrentItem[0] == "ShortcutPos")
                    _sIncPos = strCurrentItem[1];


                /* Shortcut Size */
                if (strCurrentItem[0] == "ShortcutSize")
                    _sIncSize = strCurrentItem[1];


                /* Width */
                if (strCurrentItem[0] == "Width")
                    _iIncWidth = int.Parse(strCurrentItem[1]);


                /* Heigth */
                if (strCurrentItem[0] == "Heigth")
                    _iIncHeigth = int.Parse(strCurrentItem[1]);


                /* Pos X */
                if (strCurrentItem[0] == "PosX")
                    _iIncX = int.Parse(strCurrentItem[1]);


                /* Pos Y */
                if (strCurrentItem[0] == "PosY")
                    _iIncY = int.Parse(strCurrentItem[1]);

                /* Opacity */
                if (strCurrentItem[0] == "Opacity")
                    _iIncOpacity = int.Parse(strCurrentItem[1]);
            }

                #endregion

                #region Apm

            else if (strCurrentPanelItem.Equals("[Apm]"))
            {
                /* Interval */
                if (strCurrentItem[0] == "Interval")
                    _iApmInterval = int.Parse(strCurrentItem[1]);


                /* Remove AI */
                if (strCurrentItem[0] == "RemoveAi")
                    _bApmRemoveAi = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Local Player */
                if (strCurrentItem[0] == "RemoveLocalPlayer")
                    _bApmRemoveLocalplayer = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Allie */
                if (strCurrentItem[0] == "RemoveAllie")
                    _bApmRemoveAllie = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Dead Player */
                if (strCurrentItem[0] == "RemoveDeadPlayer")
                    _bApmRemoveDeadPlayer = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Observer */
                if (strCurrentItem[0] == "RemoveObserver")
                    _bApmRemoveObserver = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Referee */
                if (strCurrentItem[0] == "RemoveReferee")
                    _bApmRemoveReferee = Convert.ToBoolean(strCurrentItem[1]);


                /* Font */
                if (strCurrentItem[0] == "Font")
                {
                    var MiniItems = strCurrentItem[1].Split(';');

                    _fApmPanelFont = new Font(MiniItems[0], float.Parse(MiniItems[1]));
                }


                /* Hotkey 1 */
                if (strCurrentItem[0] == "Hotkey1")
                    _kApmHotkey1 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 2 */
                if (strCurrentItem[0] == "Hotkey2")
                    _kApmHotkey2 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 3 */
                if (strCurrentItem[0] == "Hotkey3")
                    _kApmHotkey3 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Shortcut Toggle */
                if (strCurrentItem[0] == "ShortcutToggle")
                    _sApmShortcut = strCurrentItem[1];


                /* Shortcut Pos */
                if (strCurrentItem[0] == "ShortcutPos")
                    _sApmPos = strCurrentItem[1];


                /* Shortcut Size */
                if (strCurrentItem[0] == "ShortcutSize")
                    _sApmSize = strCurrentItem[1];


                /* Width */
                if (strCurrentItem[0] == "Width")
                    _iApmWidth = int.Parse(strCurrentItem[1]);


                /* Heigth */
                if (strCurrentItem[0] == "Heigth")
                    _iApmHeigth = int.Parse(strCurrentItem[1]);


                /* Pos X */
                if (strCurrentItem[0] == "PosX")
                    _iApmX = int.Parse(strCurrentItem[1]);


                /* Pos Y */
                if (strCurrentItem[0] == "PosY")
                    _iApmY = int.Parse(strCurrentItem[1]);

                /* Opacity */
                if (strCurrentItem[0] == "Opacity")
                    _iApmOpacity = int.Parse(strCurrentItem[1]);
            }

                #endregion

                #region Army

            else if (strCurrentPanelItem.Equals("[Army]"))
            {
                /* Interval */
                if (strCurrentItem[0] == "Interval")
                    _iArmInterval = int.Parse(strCurrentItem[1]);


                /* Remove AI */
                if (strCurrentItem[0] == "RemoveAi")
                    _bArmRemoveAi = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Local Player */
                if (strCurrentItem[0] == "RemoveLocalPlayer")
                    _bArmRemoveLocalplayer = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Allie */
                if (strCurrentItem[0] == "RemoveAllie")
                    _bArmRemoveAllie = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Dead Player */
                if (strCurrentItem[0] == "RemoveDeadPlayer")
                    _bArmRemoveDeadPlayer = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Observer */
                if (strCurrentItem[0] == "RemoveObserver")
                    _bArmRemoveObserver = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Referee */
                if (strCurrentItem[0] == "RemoveReferee")
                    _bArmRemoveReferee = Convert.ToBoolean(strCurrentItem[1]);


                /* Font */
                if (strCurrentItem[0] == "Font")
                {
                    var MiniItems = strCurrentItem[1].Split(';');

                    _fArmPanelFont = new Font(MiniItems[0], float.Parse(MiniItems[1]));
                }


                /* Hotkey 1 */
                if (strCurrentItem[0] == "Hotkey1")
                    _kArmHotkey1 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 2 */
                if (strCurrentItem[0] == "Hotkey2")
                    _kArmHotkey2 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 3 */
                if (strCurrentItem[0] == "Hotkey3")
                    _kArmHotkey3 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Shortcut Toggle */
                if (strCurrentItem[0] == "ShortcutToggle")
                    _sArmShortcut = strCurrentItem[1];


                /* Shortcut Pos */
                if (strCurrentItem[0] == "ShortcutPos")
                    _sArmPos = strCurrentItem[1];


                /* Shortcut Size */
                if (strCurrentItem[0] == "ShortcutSize")
                    _sArmSize = strCurrentItem[1];


                /* Width */
                if (strCurrentItem[0] == "Width")
                    _iArmWidth = int.Parse(strCurrentItem[1]);


                /* Heigth */
                if (strCurrentItem[0] == "Heigth")
                    _iArmHeigth = int.Parse(strCurrentItem[1]);


                /* Pos X */
                if (strCurrentItem[0] == "PosX")
                    _iArmX = int.Parse(strCurrentItem[1]);


                /* Pos Y */
                if (strCurrentItem[0] == "PosY")
                    _iArmY = int.Parse(strCurrentItem[1]);

                /* Opacity */
                if (strCurrentItem[0] == "Opacity")
                    _iArmOpacity = int.Parse(strCurrentItem[1]);
            }

                #endregion

                #region Worker

            else if (strCurrentPanelItem.Equals("[Worker]"))
            {
                /* Interval */
                if (strCurrentItem[0] == "Interval")
                    _iWorInterval = int.Parse(strCurrentItem[1]);

                /* Font */
                if (strCurrentItem[0] == "Font")
                {
                    var MiniItems = strCurrentItem[1].Split(';');

                    _fWorPanelFont = new Font(MiniItems[0], float.Parse(MiniItems[1]));
                }


                /* Hotkey 1 */
                if (strCurrentItem[0] == "Hotkey1")
                    _kWorHotkey1 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 2 */
                if (strCurrentItem[0] == "Hotkey2")
                    _kWorHotkey2 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 3 */
                if (strCurrentItem[0] == "Hotkey3")
                    _kWorHotkey3 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Shortcut Toggle */
                if (strCurrentItem[0] == "ShortcutToggle")
                    _sWorShortcut = strCurrentItem[1];


                /* Shortcut Pos */
                if (strCurrentItem[0] == "ShortcutPos")
                    _sWorPos = strCurrentItem[1];


                /* Shortcut Size */
                if (strCurrentItem[0] == "ShortcutSize")
                    _sWorSize = strCurrentItem[1];


                /* Width */
                if (strCurrentItem[0] == "Width")
                    _iWorWidth = int.Parse(strCurrentItem[1]);


                /* Heigth */
                if (strCurrentItem[0] == "Heigth")
                    _iWorHeigth = int.Parse(strCurrentItem[1]);


                /* Pos X */
                if (strCurrentItem[0] == "PosX")
                    _iWorX = int.Parse(strCurrentItem[1]);


                /* Pos Y */
                if (strCurrentItem[0] == "PosY")
                    _iWorY = int.Parse(strCurrentItem[1]);

                /* Opacity */
                if (strCurrentItem[0] == "Opacity")
                    _iWorOpacity = int.Parse(strCurrentItem[1]);
            }

                #endregion

                #region Maphack

            else if (strCurrentPanelItem.Equals("[Maphack]"))
            {
                /* Interval */
                if (strCurrentItem[0] == "Interval")
                    _iMapInterval = int.Parse(strCurrentItem[1]);


                /* Remove AI */
                if (strCurrentItem[0] == "RemoveAi")
                    _bMapRemoveAi = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Local Player */
                if (strCurrentItem[0] == "RemoveLocalPlayer")
                    _bMapRemoveLocalplayer = Convert.ToBoolean(strCurrentItem[1]);


                /* Remove Allie */
                if (strCurrentItem[0] == "RemoveAllie")
                    _bMapRemoveAllie = Convert.ToBoolean(strCurrentItem[1]);


                /* Hotkey 1 */
                if (strCurrentItem[0] == "Hotkey1")
                    _kMapHotkey1 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 2 */
                if (strCurrentItem[0] == "Hotkey2")
                    _kMapHotkey2 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Hotkey 3 */
                if (strCurrentItem[0] == "Hotkey3")
                    _kMapHotkey3 = (Keys) Enum.Parse(typeof (Keys), strCurrentItem[1]);


                /* Shortcut Toggle */
                if (strCurrentItem[0] == "ShortcutToggle")
                    _sMapShortcut = strCurrentItem[1];


                /* Shortcut Pos */
                if (strCurrentItem[0] == "ShortcutPos")
                    _sMapPos = strCurrentItem[1];


                /* Shortcut Size */
                if (strCurrentItem[0] == "ShortcutSize")
                    _sMapSize = strCurrentItem[1];


                /* Width */
                if (strCurrentItem[0] == "Width")
                    _iMapWidth = int.Parse(strCurrentItem[1]);


                /* Heigth */
                if (strCurrentItem[0] == "Heigth")
                    _iMapHeigth = int.Parse(strCurrentItem[1]);


                /* Pos X */
                if (strCurrentItem[0] == "PosX")
                    _iMapX = int.Parse(strCurrentItem[1]);


                /* Pos Y */
                if (strCurrentItem[0] == "PosY")
                    _iMapY = int.Parse(strCurrentItem[1]);

                /* Destination Color */
                if (strCurrentItem[0] == "DestinationColor")
                    _cMapColorofDestinationLine = ColorTranslator.FromHtml(strCurrentItem[1]);

                /* Remove DestinationLine */
                if (strCurrentItem[0] == "RemoveDestinationLine")
                    _bShowDestinationLine = Convert.ToBoolean(strCurrentItem[1]);

                /* Opacity */
                if (strCurrentItem[0] == "Opacity")
                    _iMapOpacity = int.Parse(strCurrentItem[1]);

            }

            #endregion

                #region Notification

                else if (strCurrentPanelItem.Equals("[Notification]"))
                {
                    /* Interval */
                    if (strCurrentItem[0] == "Interval")
                        _iNotInterval = int.Parse(strCurrentItem[1]);

                    /* Font */
                    if (strCurrentItem[0] == "Font")
                    {
                        var MiniItems = strCurrentItem[1].Split(';');

                        _fNotPanelFont = new Font(MiniItems[0], float.Parse(MiniItems[1]));
                    }

                    /* Hotkey 1 */
                    if (strCurrentItem[0] == "Hotkey1")
                        _kNotHotkey1 = (Keys)Enum.Parse(typeof(Keys), strCurrentItem[1]);


                    /* Hotkey 2 */
                    if (strCurrentItem[0] == "Hotkey2")
                        _kNotHotkey2 = (Keys)Enum.Parse(typeof(Keys), strCurrentItem[1]);


                    /* Hotkey 3 */
                    if (strCurrentItem[0] == "Hotkey3")
                        _kNotHotkey3 = (Keys)Enum.Parse(typeof(Keys), strCurrentItem[1]);


                    /* Shortcut Toggle */
                    if (strCurrentItem[0] == "ShortcutToggle")
                        _sNotShortcut = strCurrentItem[1];


                    /* Shortcut Pos */
                    if (strCurrentItem[0] == "ShortcutPos")
                        _sNotPos = strCurrentItem[1];


                    /* Shortcut Size */
                    if (strCurrentItem[0] == "ShortcutSize")
                        _sNotSize = strCurrentItem[1];


                    /* Width */
                    if (strCurrentItem[0] == "Width")
                        _iNotWidth = int.Parse(strCurrentItem[1]);


                    /* Heigth */
                    if (strCurrentItem[0] == "Heigth")
                        _iNotHeigth = int.Parse(strCurrentItem[1]);


                    /* Pos X */
                    if (strCurrentItem[0] == "PosX")
                        _iNotX = int.Parse(strCurrentItem[1]);


                    /* Pos Y */
                    if (strCurrentItem[0] == "PosY")
                        _iNotY = int.Parse(strCurrentItem[1]);

                    /* Opacity */
                    if (strCurrentItem[0] == "Opacity")
                        _iNotOpacity = int.Parse(strCurrentItem[1]);

                }

                #endregion
            }

            sr.Close();
        }

        /*** Write the actual data into the file ***/
        private void CreatSaveFile()
        {
            if (File.Exists("Settings.cfg"))
                File.Delete("Settings.cfg");

            var sw = new StreamWriter("Settings.cfg");

            #region Ressources

            /* Ressources */
            sw.WriteLine("[Ressource]");
            sw.WriteLine("Interval=" + _iResInterval.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine("RemoveAi=" + _bResRemoveAi.ToString());
            sw.WriteLine("RemoveLocalPlayer=" + _bResRemoveLocalplayer.ToString());
            sw.WriteLine("RemoveAllie=" + _bResRemoveAllie.ToString());
            sw.WriteLine("RemoveDeadPlayer=" + _bResRemoveDeadPlayer.ToString());
            sw.WriteLine("RemoveObserver=" + _bResRemoveObserver.ToString());
            sw.WriteLine("RemoveReferee=" + _bResRemoveReferee.ToString());
            sw.WriteLine("Font=" + _fResPanelFont.Name + ";" + _fResPanelFont.Size);
            sw.WriteLine("Hotkey1=" + _kResHotkey1.ToString());
            sw.WriteLine("Hotkey2=" + _kResHotkey2.ToString());
            sw.WriteLine("Hotkey3=" + _kResHotkey3.ToString());
            sw.WriteLine("ShortcutToggle=" + _sResShortcut);
            sw.WriteLine("ShortcutPos=" + _sResPos);
            sw.WriteLine("ShortcutSize=" + _sResSize);
            sw.WriteLine("Width=" + _iResWidth.ToString());
            sw.WriteLine("Heigth=" + _iResHeigth.ToString());
            sw.WriteLine("PosX=" + _iResX.ToString());
            sw.WriteLine("PosY=" + _iResY.ToString());
            sw.WriteLine("Opacity=" + _iResOpacity.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine("");

            #endregion

            #region Income

            /* Income */
            sw.WriteLine("[Income]");
            sw.WriteLine("Interval=" + _iIncInterval.ToString());
            sw.WriteLine("RemoveAi=" + _bIncRemoveAi.ToString());
            sw.WriteLine("RemoveLocalPlayer=" + _bIncRemoveLocalplayer.ToString());
            sw.WriteLine("RemoveAllie=" + _bIncRemoveAllie.ToString());
            sw.WriteLine("RemoveDeadPlayer=" + _bIncRemoveDeadPlayer.ToString());
            sw.WriteLine("RemoveObserver=" + _bIncRemoveObserver.ToString());
            sw.WriteLine("RemoveReferee=" + _bIncRemoveReferee.ToString());
            sw.WriteLine("Font=" + _fIncPanelFont.Name + ";" + _fIncPanelFont.Size);
            sw.WriteLine("Hotkey1=" + _kIncHotkey1.ToString());
            sw.WriteLine("Hotkey2=" + _kIncHotkey2.ToString());
            sw.WriteLine("Hotkey3=" + _kIncHotkey3.ToString());
            sw.WriteLine("ShortcutToggle=" + _sIncShortcut);
            sw.WriteLine("ShortcutPos=" + _sIncPos);
            sw.WriteLine("ShortcutSize=" + _sIncSize);
            sw.WriteLine("Width=" + _iIncWidth.ToString());
            sw.WriteLine("Heigth=" + _iIncHeigth.ToString());
            sw.WriteLine("PosX=" + _iIncX.ToString());
            sw.WriteLine("PosY=" + _iIncY.ToString());
            sw.WriteLine("Opacity=" + _iIncOpacity.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine("");

            #endregion

            #region Apm

            /* Apm */
            sw.WriteLine("[Apm]");
            sw.WriteLine("Interval=" + _iApmInterval.ToString());
            sw.WriteLine("RemoveAi=" + _bApmRemoveAi.ToString());
            sw.WriteLine("RemoveLocalPlayer=" + _bApmRemoveLocalplayer.ToString());
            sw.WriteLine("RemoveAllie=" + _bApmRemoveAllie.ToString());
            sw.WriteLine("RemoveDeadPlayer=" + _bApmRemoveDeadPlayer.ToString());
            sw.WriteLine("RemoveObserver=" + _bApmRemoveObserver.ToString());
            sw.WriteLine("RemoveReferee=" + _bApmRemoveReferee.ToString());
            sw.WriteLine("Font=" + _fApmPanelFont.Name + ";" + _fApmPanelFont.Size);
            sw.WriteLine("Hotkey1=" + _kApmHotkey1.ToString());
            sw.WriteLine("Hotkey2=" + _kApmHotkey2.ToString());
            sw.WriteLine("Hotkey3=" + _kApmHotkey3.ToString());
            sw.WriteLine("ShortcutToggle=" + _sApmShortcut);
            sw.WriteLine("ShortcutPos=" + _sApmPos);
            sw.WriteLine("ShortcutSize=" + _sApmSize);
            sw.WriteLine("Width=" + _iApmWidth.ToString());
            sw.WriteLine("Heigth=" + _iApmHeigth.ToString());
            sw.WriteLine("PosX=" + _iApmX.ToString());
            sw.WriteLine("PosY=" + _iApmY.ToString());
            sw.WriteLine("Opacity=" + _iApmOpacity.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine("");

            #endregion

            #region Army

            /* Army */
            sw.WriteLine("[Army]");
            sw.WriteLine("Interval=" + _iArmInterval.ToString());
            sw.WriteLine("RemoveAi=" + _bArmRemoveAi.ToString());
            sw.WriteLine("RemoveLocalPlayer=" + _bArmRemoveLocalplayer.ToString());
            sw.WriteLine("RemoveAllie=" + _bArmRemoveAllie.ToString());
            sw.WriteLine("RemoveDeadPlayer=" + _bArmRemoveDeadPlayer.ToString());
            sw.WriteLine("RemoveObserver=" + _bArmRemoveObserver.ToString());
            sw.WriteLine("RemoveReferee=" + _bArmRemoveReferee.ToString());
            sw.WriteLine("Font=" + _fArmPanelFont.Name + ";" + _fArmPanelFont.Size);
            sw.WriteLine("Hotkey1=" + _kArmHotkey1.ToString());
            sw.WriteLine("Hotkey2=" + _kArmHotkey2.ToString());
            sw.WriteLine("Hotkey3=" + _kArmHotkey3.ToString());
            sw.WriteLine("ShortcutToggle=" + _sArmShortcut);
            sw.WriteLine("ShortcutPos=" + _sArmPos);
            sw.WriteLine("ShortcutSize=" + _sArmSize);
            sw.WriteLine("Width=" + _iArmWidth.ToString());
            sw.WriteLine("Heigth=" + _iArmHeigth.ToString());
            sw.WriteLine("PosX=" + _iArmX.ToString());
            sw.WriteLine("PosY=" + _iArmY.ToString());
            sw.WriteLine("Opacity=" + _iArmOpacity.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine("");

            #endregion

            #region Worker

            /* Worker */
            sw.WriteLine("[Worker]");
            sw.WriteLine("Interval=" + _iWorInterval.ToString());
            sw.WriteLine("Font=" + _fWorPanelFont.Name + ";" + _fWorPanelFont.Size);
            sw.WriteLine("Hotkey1=" + _kWorHotkey1.ToString());
            sw.WriteLine("Hotkey2=" + _kWorHotkey2.ToString());
            sw.WriteLine("Hotkey3=" + _kWorHotkey3.ToString());
            sw.WriteLine("ShortcutToggle=" + _sWorShortcut);
            sw.WriteLine("ShortcutPos=" + _sWorPos);
            sw.WriteLine("ShortcutSize=" + _sWorSize);
            sw.WriteLine("Width=" + _iWorWidth.ToString());
            sw.WriteLine("Heigth=" + _iWorHeigth.ToString());
            sw.WriteLine("PosX=" + _iWorX.ToString());
            sw.WriteLine("PosY=" + _iWorY.ToString());
            sw.WriteLine("Opacity=" + _iWorOpacity.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine("");

            #endregion

            #region Maphack

            /* Maphack */
            sw.WriteLine("[Maphack]");
            sw.WriteLine("Interval=" + _iMapInterval.ToString());
            sw.WriteLine("RemoveAi=" + _bMapRemoveAi.ToString());
            sw.WriteLine("RemoveLocalPlayer=" + _bMapRemoveLocalplayer.ToString());
            sw.WriteLine("RemoveAllie=" + _bMapRemoveAllie.ToString());
            sw.WriteLine("Hotkey1=" + _kMapHotkey1.ToString());
            sw.WriteLine("Hotkey2=" + _kMapHotkey2.ToString());
            sw.WriteLine("Hotkey3=" + _kMapHotkey3.ToString());
            sw.WriteLine("ShortcutToggle=" + _sMapShortcut);
            sw.WriteLine("ShortcutPos=" + _sMapPos);
            sw.WriteLine("ShortcutSize=" + _sMapSize);
            sw.WriteLine("Width=" + _iMapWidth.ToString());
            sw.WriteLine("Heigth=" + _iMapHeigth.ToString());
            sw.WriteLine("PosX=" + _iMapX.ToString());
            sw.WriteLine("PosY=" + _iMapY.ToString());
            sw.WriteLine("DestinationColor=" + ColorTranslator.ToHtml(_cMapColorofDestinationLine));
            sw.WriteLine("RemoveDestinationLine=" + _bShowDestinationLine);
            sw.WriteLine("Opacity=" + _iMapOpacity.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine("");

            #endregion

            #region Notification

            /* Notification */
            sw.WriteLine("[Notification]");
            sw.WriteLine("Interval=" + _iNotInterval.ToString());
            sw.WriteLine("Font=" + _fNotPanelFont.Name + ";" + _fNotPanelFont.Size);
            sw.WriteLine("Hotkey1=" + _kNotHotkey1.ToString());
            sw.WriteLine("Hotkey2=" + _kNotHotkey2.ToString());
            sw.WriteLine("Hotkey3=" + _kNotHotkey3.ToString());
            sw.WriteLine("ShortcutToggle=" + _sNotShortcut);
            sw.WriteLine("ShortcutPos=" + _sNotPos);
            sw.WriteLine("ShortcutSize=" + _sNotSize);
            sw.WriteLine("Width=" + _iNotWidth.ToString());
            sw.WriteLine("Heigth=" + _iNotHeigth.ToString());
            sw.WriteLine("PosX=" + _iNotX.ToString());
            sw.WriteLine("PosY=" + _iNotY.ToString());
            sw.WriteLine("Opacity=" + _iNotOpacity.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine("");

            #endregion

            sw.Close();
        }

        /*** Check if the Input is okay and take over variables' content ***/
        private void txtResRef_TextChanged(object sender, EventArgs e)
        {
            if (txtResRef.Text.Length < 1) 
                return;

            int dummy = 0;

            if (int.TryParse(txtResRef.Text, NumberStyles.Integer, null, out dummy))
            {
            }

            else
                txtResRef.Text = txtResRef.Text.Remove(txtResRef.Text.Length - 1, 1);

            txtResRef.Select(txtResRef.Text.Length, 0);

            if (dummy <= 0)
                dummy = 1;

            /* Check which Panelsetting was active */
            switch (_iCurrent)
            {
                case 0:
                    _iResInterval = dummy;
                    break;

                case 1:
                    _iIncInterval = dummy;
                    break;

                case 2:
                    _iWorInterval = dummy;
                    break;

                case 3:
                    _iApmInterval = dummy;
                    break;

                case 4:
                    _iArmInterval = dummy;
                    break;

                case 5:
                    _iMapInterval = dummy;
                    break;

                case 6:
                    _iNotInterval = dummy;
                    break;
            }
        }

        /*** First Hotkey ***/
        private void txtRes1_KeyDown(object sender, KeyEventArgs e)
        {
            txtRes1.Text = e.KeyCode.ToString();
            e.SuppressKeyPress = true;

            switch (_iCurrent)
            {
                case 0:
                    _kResHotkey1 = e.KeyCode;
                    break;

                case 1:
                    _kIncHotkey1 = e.KeyCode;
                    break;

                case 2:
                    _kWorHotkey1 = e.KeyCode;
                    break;

                case 3:
                    _kApmHotkey1 = e.KeyCode;
                    break;

                case 4:
                    _kArmHotkey1 = e.KeyCode;
                    break;

                case 5:
                    _kMapHotkey1 = e.KeyCode;
                    break;

                case 6:
                    _kNotHotkey1 = e.KeyCode;
                    break;
            }
        }

        /*** Second Hotkey ***/
        private void txtRes2_KeyDown(object sender, KeyEventArgs e)
        {
            txtRes2.Text = e.KeyCode.ToString();
            e.SuppressKeyPress = true;

            switch (_iCurrent)
            {
                case 0:
                    _kResHotkey2 = e.KeyCode;
                    break;

                case 1:
                    _kIncHotkey2 = e.KeyCode;
                    break;

                case 2:
                    _kWorHotkey2 = e.KeyCode;
                    break;

                case 3:
                    _kApmHotkey2 = e.KeyCode;
                    break;

                case 4:
                    _kArmHotkey2 = e.KeyCode;
                    break;

                case 5:
                    _kMapHotkey2 = e.KeyCode;
                    break;

                case 6:
                    _kNotHotkey2 = e.KeyCode;
                    break;
            }
        }

        /*** Third Hotkey ***/
        private void txtRes3_KeyDown(object sender, KeyEventArgs e)
        {
            txtRes3.Text = e.KeyCode.ToString();
            e.SuppressKeyPress = true;

            switch (_iCurrent)
            {
                case 0:
                    _kResHotkey3 = e.KeyCode;
                    break;

                case 1:
                    _kIncHotkey3 = e.KeyCode;
                    break;

                case 2:
                    _kWorHotkey3 = e.KeyCode;
                    break;

                case 3:
                    _kApmHotkey3 = e.KeyCode;
                    break;

                case 4:
                    _kArmHotkey3 = e.KeyCode;
                    break;

                case 5:
                    _kMapHotkey3 = e.KeyCode;
                    break;

                case 6:
                    _kNotHotkey3 = e.KeyCode;
                    break;
            }
        }

        /*** Goes to the next Panelrectangle ***/
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_iCurrent + 1 < Max)
                _iCurrent++;

            pnlShow.CurrentItem = _iCurrent + 1;

            //Refresh Controls
            InsertDataIntoControl();
        }

        /*** Goes to the previous Panelrectangle ***/
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_iCurrent < 1)
            {

            }
            else
                _iCurrent--;

            pnlShow.CurrentItem = _iCurrent + 1;

            //Refresh Controls
            InsertDataIntoControl();
        }

        /*** Set color for the destination- Line ***/
        private void btnColorDestinationLine_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            var res = cd.ShowDialog();

            if (res.Equals(DialogResult.OK))
                _cMapColorofDestinationLine = cd.Color;

            btnColorDestinationLine.Text = _cMapColorofDestinationLine.Name;
            btnColorDestinationLine.ForeColor = _cMapColorofDestinationLine;
        }

        /*** Remove AI Setting ***/
        private void cbResRemAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_iCurrent)
            {
                case 0:
                    _bResRemoveAi = Convert.ToBoolean(cbResRemAI.SelectedItem);
                    break;

                case 1:
                    _bIncRemoveAi = Convert.ToBoolean(cbResRemAI.SelectedItem);
                    break;


                case 3:
                    _bApmRemoveAi = Convert.ToBoolean(cbResRemAI.SelectedItem);
                    break;


                case 4:
                    _bArmRemoveAi = Convert.ToBoolean(cbResRemAI.SelectedItem);
                    break;


                case 5:
                    _bMapRemoveAi = Convert.ToBoolean(cbResRemAI.SelectedItem);
                    break;    
            }
        }

        /*** Remove LocalPlayer Setting ***/
        private void cbResRemLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_iCurrent)
            {
                case 0:
                   _bResRemoveLocalplayer = Convert.ToBoolean(cbResRemLocal.SelectedItem);
                    break;

                case 1:
                    _bIncRemoveLocalplayer = Convert.ToBoolean(cbResRemLocal.SelectedItem);
                    break;


                case 3:
                    _bApmRemoveLocalplayer = Convert.ToBoolean(cbResRemLocal.SelectedItem);
                    break;


                case 4:
                    _bArmRemoveLocalplayer = Convert.ToBoolean(cbResRemLocal.SelectedItem);
                    break;


                case 5:
                    _bMapRemoveLocalplayer = Convert.ToBoolean(cbResRemLocal.SelectedItem);
                    break;
            }
        }

        /*** Remove Allie Setting ***/
        private void cbResRemAllie_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_iCurrent)
            {
                case 0:
                    _bResRemoveAllie = Convert.ToBoolean(cbResRemAllie.SelectedItem);
                    break;

                case 1:
                    _bIncRemoveAllie = Convert.ToBoolean(cbResRemAllie.SelectedItem);
                    break;

                case 3:
                    _bApmRemoveAllie = Convert.ToBoolean(cbResRemAllie.SelectedItem);
                    break;

                case 4:
                    _bArmRemoveAllie = Convert.ToBoolean(cbResRemAllie.SelectedItem);
                    break;

                case 5:
                    _bMapRemoveAllie = Convert.ToBoolean(cbResRemAllie.SelectedItem);
                    break;
            }
        }

        /*** Remove Dead Player Setting ***/
        private void cbResRemDead_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_iCurrent)
            {
                case 0:
                    _bResRemoveDeadPlayer = Convert.ToBoolean(cbResRemDead.SelectedItem);
                    break;

                case 1:
                    _bIncRemoveDeadPlayer = Convert.ToBoolean(cbResRemDead.SelectedItem);
                    break;

                case 3:
                    _bApmRemoveDeadPlayer = Convert.ToBoolean(cbResRemDead.SelectedItem);
                    break;

                case 4:
                    _bArmRemoveDeadPlayer = Convert.ToBoolean(cbResRemDead.SelectedItem);
                    break;

            }
        }

        /*** Remove Observer Setting ***/
        private void cbResRemObs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_iCurrent)
            {
                case 0:
                    _bResRemoveObserver = Convert.ToBoolean(cbResRemObs.SelectedItem);
                    break;

                case 1:
                    _bIncRemoveObserver = Convert.ToBoolean(cbResRemObs.SelectedItem);
                    break;

                case 3:
                    _bApmRemoveObserver = Convert.ToBoolean(cbResRemObs.SelectedItem);
                    break;

                case 4:
                    _bArmRemoveObserver = Convert.ToBoolean(cbResRemObs.SelectedItem);
                    break;
            }
        }

        /*** Remove Referee Setting ***/
        private void cbResRemReferee_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_iCurrent)
            {
                case 0:
                    _bResRemoveReferee = Convert.ToBoolean(cbResRemReferee.SelectedItem);
                    break;

                case 1:
                    _bIncRemoveReferee = Convert.ToBoolean(cbResRemReferee.SelectedItem);
                    break;

                case 3:
                    _bApmRemoveReferee = Convert.ToBoolean(cbResRemReferee.SelectedItem);
                    break;

                case 4:
                    _bArmRemoveReferee = Convert.ToBoolean(cbResRemReferee.SelectedItem);
                    break;
            }
        }

        /*** Set Shortcut (Toggle) Setting ***/
        private void txtResShortcut_TextChanged(object sender, EventArgs e)
        {
            switch (_iCurrent)
            {
                case 0:
                    _sResShortcut = txtResShortcut.Text;
                    break;

                case 1:
                    _sIncShortcut = txtResShortcut.Text;
                    break;

                case 2:
                    _sWorShortcut = txtResShortcut.Text;
                    break;

                case 3:
                    _sApmShortcut = txtResShortcut.Text;
                    break;

                case 4:
                    _sArmShortcut = txtResShortcut.Text;
                    break;

                case 5:
                    _sMapShortcut = txtResShortcut.Text;
                    break;

                case 6:
                    _sNotShortcut = txtResShortcut.Text;
                    break;
            }
        }

        /*** Set Shortcut (Position) Setting ***/
        private void txtResPos_TextChanged(object sender, EventArgs e)
        {
            switch (_iCurrent)
            {
                case 0:
                    _sResPos = txtResPos.Text;
                    break;

                case 1:
                    _sIncPos = txtResPos.Text;
                    break;

                case 2:
                    _sWorPos = txtResPos.Text;
                    break;

                case 3:
                    _sApmPos = txtResPos.Text;
                    break;

                case 4:
                    _sArmPos = txtResPos.Text;
                    break;

                case 5:
                    _sMapPos = txtResPos.Text;
                    break;

                case 6:
                    _sNotPos = txtResPos.Text;
                    break;
            }
        }

        /*** Set Shortcut (Size) Setting ***/
        private void txtResSize_TextChanged(object sender, EventArgs e)
        {
            switch (_iCurrent)
            {
                case 0:
                    _sResSize = txtResSize.Text;
                    break;

                case 1:
                    _sIncSize = txtResSize.Text;
                    break;

                case 2:
                    _sWorSize = txtResSize.Text;
                    break;

                case 3:
                    _sApmSize = txtResSize.Text;
                    break;

                case 4:
                    _sArmSize = txtResSize.Text;
                    break;

                case 5:
                    _sMapSize = txtResSize.Text;
                    break;

                case 6:
                    _sNotSize = txtResSize.Text;
                    break;
            }
        }

        /*** Set the Opacity ***/
        private void txtResOpacity_TextChanged(object sender, EventArgs e)
        {
            if (txtResOpacity.Text.Length < 1)
                return;

            int dummy = 0;

            if (!int.TryParse(txtResOpacity.Text, NumberStyles.Integer, null, out dummy))
            {
                MessageBox.Show("Try numbers...");
                return;
            }


            switch (_iCurrent)
            {
                case 0:
                    _iResOpacity = dummy;
                    break;

                case 1:
                    _iIncOpacity = dummy;
                    break;

                case 2:
                    _iWorOpacity = dummy;
                    break;

                case 3:
                    _iApmOpacity = dummy;
                    break;

                case 4:
                    _iArmOpacity = dummy;
                    break;

                case 5:
                    _iMapOpacity = dummy;
                    break;

                case 6:
                    _iNotOpacity = dummy;
                    break;
            }
        }

        /*** Enable DestinationLine Setting***/
        private void cbDestinationLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_iCurrent.Equals(5))
                _bShowDestinationLine = Convert.ToBoolean(cbDestinationLine.SelectedItem);
        }

        /*** Button to save the actual stuff ***/
        private void btnSave_Click(object sender, EventArgs e)
        {
            CreatSaveFile();
        }

        /*** When closing, save everything ***/
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CreatSaveFile();
        }

        /*** Check if the Hotkey(s) are pressed ***/
        public bool HotkeysPressed(Keys ikeya, Keys ikeyb, Keys ikeyc)
        {
            return (Pinvokes.GetAsyncKeyState(ikeya) <= (-32767) &&
                    Pinvokes.GetAsyncKeyState(ikeyb) <= (-32767) &&
                    Pinvokes.GetAsyncKeyState(ikeyc) <= (-32767));
        }

        /* This part handles all Input and toggles */
        private void HandleInput(ref BufferForm bfForm, Typo.BufferformType bfType, string strShortcut, Keys keya, Keys keyb, Keys keyc)
        {
            /* Open/ Close process, using the Keys- combination */
            if (HotkeysPressed(keya, keyb, keyc))
            {
                if  (bfForm == null)
                    bfForm = new BufferForm(bfType, this);

                if (bfForm.Created)
                    bfForm.Close();

                else
                {
                    bfForm = new BufferForm(bfType, this);
                    bfForm.Show();
                }
                    
                GC.Collect();
            }

            /* Open/ Close Form using the Textinput */
            var sInput = _pInfo.GetChatInput();

            if (sInput.Contains(strShortcut))
            {

                if (bfForm == null)
                    bfForm = new BufferForm(bfType, this);

                if (bfForm.Created)
                    bfForm.Close();

                else
                {
                    bfForm = new BufferForm(bfType, this);
                    bfForm.Show();
                }

                Pinvokes.SimulateCompleteKeypress(Process.GetProcessesByName("SC2")[0].MainWindowHandle, Keys.Enter, 3);


                GC.Collect();
            }
        }

        /*** Here we'll fill the Statuslabel ***/
        private void FillStatuslabel()
        {
            string strOutput = string.Empty;

            if (_pInfo.MapIngame())
            {
                slblTimer.ForeColor = Color.Green;

                if (_pInfo.Pause())
                    strOutput = "Ingame - { PAUSED } - [Ingame Time: ";

                else
                    strOutput = "Ingame - { PLAYING } - [Ingame Time: ";
            }

            else
            {
                slblTimer.ForeColor = Color.Red;
                strOutput = "Not Ingame!";
                slblTimer.Text = strOutput;
                return;
            }

            /* Transform the numbers into actual time */

            /* This is the Ingame Time */
            var iMins = _pInfo.Timer()/60;
            var iSec = _pInfo.Timer()%60;
            var iHours = iMins/60;
            iMins = iMins%60;

            /* This is the Realtime (based on constant gamespeed */
            double dummy = 0;
            if (_pInfo.Gamespeed().Equals(Typo.Gamespeed.Slower))
                dummy = _pInfo.Timer() / 0.599;

            else if (_pInfo.Gamespeed().Equals(Typo.Gamespeed.Slow))
                dummy = _pInfo.Timer() / 0.83;

            else if (_pInfo.Gamespeed().Equals(Typo.Gamespeed.Normal))
                dummy = _pInfo.Timer();

            else if (_pInfo.Gamespeed().Equals(Typo.Gamespeed.Fast))
                dummy = _pInfo.Timer() / 1.21;

            else if (_pInfo.Gamespeed().Equals(Typo.Gamespeed.Faster))
                dummy = _pInfo.Timer() / 1.38;

            else if (_pInfo.Gamespeed().Equals(Typo.Gamespeed.Fasterx2))
                dummy = _pInfo.Timer() / 2.77;

            else if (_pInfo.Gamespeed().Equals(Typo.Gamespeed.Fasterx4))
                dummy = _pInfo.Timer() / 5.624;

            else
                dummy = _pInfo.Timer() / 11.249;

            var ibuffer = (Int32) dummy;

            var iMinsReal = ibuffer/60;
            var iSecsReal = ibuffer%60;
            var iHoursReal = iMinsReal/60;
            iMinsReal = iMinsReal%60;

            strOutput += iHours.ToString(CultureInfo.InvariantCulture) + ":" +
                         iMins.ToString(CultureInfo.InvariantCulture) + ":" +
                         iSec.ToString(CultureInfo.InvariantCulture) + "] - [Real Time: " +
                         iHoursReal.ToString(CultureInfo.InvariantCulture) + ":" +
                         iMinsReal.ToString(CultureInfo.InvariantCulture) + ":" +
                         iSecsReal.ToString(CultureInfo.InvariantCulture) + "]";

            /* Press out the content*/
            slblTimer.Text = strOutput;
        }

        /*** Change SC2's Window- style ***/
        private void ChangeWindowStyle()
        {
            /* Will exit if sc2 is not loaded */
            if (!Various.StarcraftAvailable())
                return;

            var sc2 = Process.GetProcessesByName("SC2")[0].MainWindowHandle;


            var iStyle = (int) Pinvokes.GetWindowLongPtr(sc2,
                                                         Pinvokes.GWL_EXSTYLE);

            if (iStyle.Equals((int) Typo.WindowStyle.Fullscreen))
            {
                var msgResult =
                    MessageBox.Show(
                        "Fullscreen detected!\n\nThe hack won't work.\nDo you need to change the style!",
                        "SC2 Style");


            }


        }

        /*** Show Fps on Label ***/
        private void ShowFps()
        {
            lblShowFps.Text = "Game's Fps: " + _pInfo.FramesPerSecond().ToString();

            string strGametype = string.Empty;

            if (!_pInfo.MapIngame())
                strGametype = "None";

            else if (_pInfo.Gametype().Equals(Typo.Gametype.Replay))
                strGametype = "Replay";

            else if (_pInfo.Gametype().Equals(Typo.Gametype.Challange))
                strGametype = "Challange";

            else if (_pInfo.Gametype().Equals(Typo.Gametype.VersusAi))
                strGametype = "Versus A.I.";

            else if (_pInfo.Gametype().Equals(Typo.Gametype.Ladder))
                strGametype = "Ladder";


            lblGametype.Text = "Gametype: " + strGametype;
        }

        /* Check for updates */
        private void fsSecondCheckforUpdate_Click(object sender, EventArgs e)
        {
            CreatSaveFile();

            if (_upCheckforUpdates == null)
                _upCheckforUpdates = new Update();

            if (_upCheckforUpdates.Created)
                _upCheckforUpdates.Close();

            else
            {
                _upCheckforUpdates = new Update();
                _upCheckforUpdates.Show();
            }

        }

        /* Close this */
        private void fsSecondExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
