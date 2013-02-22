using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Another_SC2_Hack.Forms;

namespace Another_SC2_Hack.Classes
{
    sealed class BufferForm : Form
    {
        
        /*** Variables loaded on StartUp ***/
        public IntPtr HStarCraft = IntPtr.Zero;
        public Process PStarcraft = null;
        public Offsets OOffset;
        private readonly PlayerInfo _pInfo;
        private readonly MainForm _myForm = null;
        private readonly Typo.BufferformType _myType;
        private const float fFontSize = 0.0217607334817899f;
        readonly Stopwatch _swPrimeBenching = new Stopwatch();
        Stopwatch _swBench = new Stopwatch();
        private bool _bStopFlickering = false;  //Toggles when changing pos/Size with mouse - Stops issues with the ActiveWindowsing within the timer

        /* Settings */
        #region Settings

        public bool BremobeAi = true,
                    BremoveDeadPlayer = true,
                    BremoveLocalPlayer = true,
                    BremoveAllie = true,
                    BremoveObserver = true,
                    BremoveReferee = true,
                    BuseTeamColor = false,
                    BremoveDestinationLine = false;

        public int Iinterval = 0,
                   Iwidth = 0,
                   Iheigth = 0,
                   Ix = 0,
                   Iy = 0;

        public string Strtoggle = string.Empty,
                      StrPos = string.Empty,
                      StrSize = string.Empty;

        public Keys KHotkey1,
                    KHotkey2,
                    KHotkey3;

        public Font Ffont;
        private Timer _tmrMainTick;
        private IContainer components;

        public Color CDestinationLineColor;

        #endregion

        public BufferForm(Typo.BufferformType bftype, MainForm fr)
        {
            InitializeComponent();

            /* Check if SC2 is found */
            var allProcs = Process.GetProcesses();
            var bFlag = false;
            foreach (var process in allProcs)
            {
                if (!process.ProcessName.Equals("SC2")) 
                    continue;

                PStarcraft = process;
                bFlag = true;
                break;
            }

            if (!bFlag)
            {
                MessageBox.Show("Starcraft 2 is not found!", "STARCRAFT MISSING");
                return;
            }
                


            /*** Disable Flickering ***/
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint, true);

            /* Set Borderstyle */
            FormBorderStyle = FormBorderStyle.None; 

            /*** Assign the needed Variables ***/
            HStarCraft = Pinvokes.OpenProcess(Pinvokes.PROCESS_VM_READ, 1, (uint)PStarcraft.Id);    //Handle
            OOffset = new Offsets(PStarcraft);                                                      //Offsets                                                  
            _pInfo = new PlayerInfo(this);                                                          //Playerclass (Infos for everything)
            _myType = bftype;
            TopMost = true;
            Opacity = 99;
            TransparencyKey = SystemColors.Control;
            BackColor = SystemColors.Control;
            _myForm = fr;

            /*** Check which Panel was called ***/
            if (_myType.Equals(Typo.BufferformType.Ressource))
            {
                Width = 500;
                Height = 40 * _pInfo.Playercount();
            }

            else if (_myType.Equals(Typo.BufferformType.Income))
            {
                Width = 500;
                Height = 40 * _pInfo.Playercount();
            }

            else if (_myType.Equals(Typo.BufferformType.Apm))
            {
                Width = 500;
                Height = 40 * _pInfo.Playercount();
            }

            else if (_myType.Equals(Typo.BufferformType.Army))
            {
                Width = 500;
                Height = 40 * _pInfo.Playercount();
            }

            else if (_myType.Equals(Typo.BufferformType.Worker))
            {
                Width = 150;
                Height = 40;
            }

            else if (_myType.Equals(Typo.BufferformType.Maphack))
            {
                /* Set size for the Panel */
                Height = 258;
                Width = 262;

                Location = new Point(28, 808);
            }

            else if (_myType.Equals(Typo.BufferformType.Notification))
            {
                Height = 110;
                Width = 378;

                Location = new Point(50, 50);
            }


            /* Activate timer */
            _tmrMainTick.Enabled = true;

        } 

        //Draw the actual stuff
        protected override void OnPaint(PaintEventArgs e)
        {
            var strUsedPanel = string.Empty;
            var iItemNum = 0;
            _swPrimeBenching.Start();

            #region Excape Sequences - OKAY

            if (!_pInfo.MapIngame())
                return;

            #endregion


            #region Check foreground - NOT WORKING

            //if (Pinvokes.GetForegroundWindow().Equals(PStarcraft.MainWindowHandle))
            //{
            //    if (_myForm.TopMost)
            //        TopMost = false;

            //    else
            //    TopMost = true;
            //}

            //else
            //    TopMost = false;



            #endregion


            base.OnPaint(e);


            var context = new BufferedGraphicsContext();
            context.MaximumBuffer = ClientSize;

            using (BufferedGraphics buffer = context.Allocate(e.Graphics, ClientRectangle))
            {
                /*** Initial quality ***/
                buffer.Graphics.Clear(BackColor);
                buffer.Graphics.CompositingMode = CompositingMode.SourceOver;
                buffer.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                buffer.Graphics.PixelOffsetMode = PixelOffsetMode.None;
                buffer.Graphics.SmoothingMode = SmoothingMode.None;

                /* Check which Panel is opened */
                if (_myType.Equals(Typo.BufferformType.Ressource))
                    RessourceDrawing(buffer);
                

                else if (_myType.Equals(Typo.BufferformType.Income))
                    IncomeDrawing(buffer);
                

                else if (_myType.Equals(Typo.BufferformType.Army))
                    ArmyDrawing(buffer);
                

                else if (_myType.Equals(Typo.BufferformType.Apm))
                    ApmDrawing(buffer);
                

                else if (_myType.Equals(Typo.BufferformType.Worker))
                    WorkerDrawing(buffer);


                else if (_myType.Equals(Typo.BufferformType.Maphack))
                    MaphackDrawing(buffer);
                

                else if (_myType.Equals(Typo.BufferformType.Units))
                    UnitDrawing(buffer);
                

                else if (_myType.Equals(Typo.BufferformType.Notification))
                    NotificationDrawing(buffer);
                

                buffer.Render();
                
            }
            context.Dispose();

            /* Stopping the stopwatch */
            _swPrimeBenching.Stop();

            #region Send information to the labels 

            /* Calculate stuff in ms */
            var dTime = Math.Round(
                1000.0*(double) _swPrimeBenching.ElapsedTicks/Stopwatch.Frequency, 2);
            var dFps = Math.Round(1000 / dTime, 0);
            

            switch (_myType)
            {
                case Typo.BufferformType.Ressource:
                    _myForm.lblResource.Text = "Ressource: " +
                                               (dTime.ToString() +
                                                "ms" + " [" + dFps  + " FPS]");
                    break;

                case Typo.BufferformType.Income:
                    _myForm.lblIncome.Text = "Income: " +
                                             (dTime.ToString() +
                                                "ms" + " [" + dFps + " FPS]");
                    break;

                case Typo.BufferformType.Worker:
                    _myForm.lblWorker.Text = "Worker: " +
                                             (dTime.ToString() +
                                                "ms" + " [" + dFps + " FPS]");
                    break;

                case Typo.BufferformType.Maphack:
                    _myForm.lblMaphack.Text = "Maphack: " +
                                              (dTime.ToString() +
                                                "ms" + " [" + dFps + " FPS]");
                    break;

                case Typo.BufferformType.Apm:
                    _myForm.lblApm.Text = "Apm: " +
                                          (dTime.ToString() +
                                                "ms" + " [" + dFps + " FPS]");
                    break;

                case Typo.BufferformType.Army:
                    _myForm.lblArmy.Text = "Army: " +
                                           (dTime.ToString() +
                                                "ms" + " [" + dFps + " FPS]");
                    break;

                case Typo.BufferformType.Notification:
                    _myForm.lblNotification.Text = "Notification: " +
                                           (dTime.ToString() +
                                                "ms" + " [" + dFps + " FPS]");
                    break;

            }

            #endregion

            /* Just reset the stopwatch*/
            _swPrimeBenching.Reset();
        }

        /*** Drawing Instance for the Ressource- Part ***/
        private void RessourceDrawing(BufferedGraphics buffer)
        {
            if (_pInfo.Playercount() <= 0)
                return;

            _tmrMainTick.Interval = _myForm._iResInterval;
            Opacity = (float) _myForm._iResOpacity/100;
            Width = _myForm._iResWidth;
            Height = _myForm._iResHeigth*_pInfo.Playercount();
            Location = new Point(_myForm._iResX, _myForm._iResY);
            var fDiagonalSize = (float) Math.Sqrt((Math.Pow(Width, 2) + Math.Pow(Height/_pInfo.Playercount(), 2)));
            //fFontSize = 12/fDiagonalSize;


            var i2 = 0;
            for (var i = 0; i < _pInfo.Playercount(); i++)
            {
                /* With Patch 2.0.4 Blizzard 
                 * Changes the way how they store 
                 * Playerinformation.
                 * They leave spots open for no reason.
                 * However, we have to avoid those 
                 * holes. We check for a name and when it's 
                 * not available and the counter hasn't reached 
                 * the max, there is another player! */
            Spot_CalculateAgain:

                #region Escape Sequences

                /* Dead Player */
                if (_myForm._bResRemoveDeadPlayer)
                {
                    if (_pInfo.Status(i).Equals(2))
                        continue;
                }

                /* Ai */
                if (_myForm._bResRemoveAi)
                {
                    if (_pInfo.Type(i).Equals(2))
                        continue;
                }

                /* Observer */
                if (_myForm._bResRemoveObserver)
                {
                    if (_pInfo.Type(i).Equals(6))
                        continue;
                }

                /* Referee */
                if (_myForm._bResRemoveReferee)
                {
                    if (_pInfo.Type(i).Equals(5))
                        continue;
                }

                /* Localplayer */
                if (_myForm._bResRemoveLocalplayer)
                {
                    if (i.Equals(_pInfo.LocalPlayer()))
                        continue;
                }

                /* Allie */
                if (_myForm._bResRemoveAllie)
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        continue;
                }

                /* Teamcolor */
                Color clUsercolor;
                if (_pInfo.TeamColor().Equals(2))
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        clUsercolor = Color.Yellow;

                    else if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())))
                        clUsercolor = Color.Green;

                    else
                        clUsercolor = Color.Red;
                }

                else
                    clUsercolor = _pInfo.Color(i);


                /* Check for the playername */
                if (_pInfo.Name(i).Length <= 0)
                {
                    i++;

                    goto Spot_CalculateAgain;
                }



                #endregion


                /* Draw Background per box */
                var clBackground = i2%2 == 0
                                       ? Color.FromArgb(255, Color.Gray)
                                       : Color.FromArgb(255, Color.LightSlateGray);




                buffer.Graphics.FillRectangle(new SolidBrush(clBackground), 0,
                                              0 + (Height/_pInfo.Playercount())*i2,
                                              Width,
                                              Height/_pInfo.Playercount());

                /* Draw a frame per Box */
                buffer.Graphics.DrawRectangle(new Pen(new SolidBrush(clUsercolor), 2), 1,
                                              1 + (Height/_pInfo.Playercount())*i2,
                                              Width - 2,
                                              Height/_pInfo.Playercount() - 2);

                /* Draw the PlayerName */
                buffer.Graphics.DrawString(_pInfo.Name(i),
                                           new Font(_myForm._fResPanelFont.Name, fFontSize*fDiagonalSize,
                                                    FontStyle.Bold),
                                           new SolidBrush(Color.FromArgb(255, clUsercolor)),
                                           new PointF(10, 10 + (Height/_pInfo.Playercount())*i2));

                /* Draw the PlayerTeam */
                /* CALCS
                 * 526.213 = SQRT(POW(550) + POW(160))
                 * 0.2470482485229365f comes from the standart formular (130/526,213)
                 * 0,3800742284968254f comes from the standart formular (200/526,213)
                 * 0,6138198790223731f comes from the standart formular (323/526,213)
                 * 0,8475655295479207f comes from the standart formular (446/526,213)
                 * 0,3230630942223016f comes from the standart formular (170/526,213)
                 * 0,5568087447478493f comes from the standart formular (293/526,213)
                 * 0,7905543952733969f comes from the standart formular (416/526,213)
                 */
                buffer.Graphics.DrawString("#" + _pInfo.Team(i).ToString(CultureInfo.InvariantCulture),
                                           new Font(_myForm._fResPanelFont.Name, fFontSize*fDiagonalSize,
                                                    FontStyle.Regular),
                                           new SolidBrush(Color.FromArgb(255, Color.White)),
                                           new PointF(0.2357412793860572f*fDiagonalSize,
                                                      10 + (Height/_pInfo.Playercount())*i2));

                /* Draw Minerals of Player */
                buffer.Graphics.DrawString(_pInfo.Minerals(i).ToString(CultureInfo.InvariantCulture),
                                           new Font(_myForm._fResPanelFont.Name, fFontSize*fDiagonalSize,
                                                    FontStyle.Regular),
                                           new SolidBrush(Color.FromArgb(255, Color.White)),
                                           new PointF(0.3626788913631649f*fDiagonalSize,
                                                      10 + (Height/_pInfo.Playercount())*i2));

                /* Draw Gas of Player */
                buffer.Graphics.DrawString(_pInfo.Gas(i).ToString(CultureInfo.InvariantCulture),
                                           new Font(_myForm._fResPanelFont.Name, fFontSize*fDiagonalSize,
                                                    FontStyle.Regular),
                                           new SolidBrush(Color.FromArgb(255, Color.White)),
                                           new PointF(0.5857264095515113f*fDiagonalSize,
                                                      10 + (Height/_pInfo.Playercount())*i2));

                /* Draw Supply of Player */
                buffer.Graphics.DrawString(_pInfo.SupplyMin(i).ToString(CultureInfo.InvariantCulture) + "/" +
                                           _pInfo.SupplyMax(i).ToString(CultureInfo.InvariantCulture),
                                           new Font(_myForm._fResPanelFont.Name, fFontSize*fDiagonalSize,
                                                    FontStyle.Regular),
                                           new SolidBrush(Color.FromArgb(255, Color.White)),
                                           new PointF(0.8087739277398577f*fDiagonalSize,
                                                      10 + (Height/_pInfo.Playercount())*i2));

                Image imgMin = null,
                      imgGas = null,
                      imgSup = null;

                if (_pInfo.Race(i).Contains("Terr"))
                {
                    imgMin = Properties.Resources.Mineral_Terran;
                    imgGas = Properties.Resources.Gas_Terran;
                    imgSup = Properties.Resources.Supply_Terran;
                }

                else if (_pInfo.Race(i).Contains("Prot"))
                {
                    imgMin = Properties.Resources.Mineral_Protoss;
                    imgGas = Properties.Resources.Gas_Protoss;
                    imgSup = Properties.Resources.Supply_Protoss;
                }

                else
                {
                    imgMin = Properties.Resources.Mineral_Zerg;
                    imgGas = Properties.Resources.Gas_Zerg;
                    imgSup = Properties.Resources.Supply_Zerg;
                }

                /* Draw Mineral- Icon */
                buffer.Graphics.DrawImage(imgMin,
                                          0.3082770576586901f*fDiagonalSize,
                                          7 + (Height/_pInfo.Playercount())*i2, 0.0532194943007624f*fDiagonalSize,
                                          0.0532194943007624f*fDiagonalSize);

                /* Draw Gas- Icon */
                buffer.Graphics.DrawImage(imgGas,
                                          0.5313245758470366f*fDiagonalSize,
                                          7 + (Height/_pInfo.Playercount())*i2, 0.0532194943007624f*fDiagonalSize,
                                          0.0532194943007624f*fDiagonalSize);

                /* Draw Supply- Icon */
                buffer.Graphics.DrawImage(imgSup,
                                          0.754372094035383f*fDiagonalSize,
                                          7 + (Height/_pInfo.Playercount())*i2, 0.0532194943007624f*fDiagonalSize,
                                          0.0532194943007624f*fDiagonalSize);

                i2++;
            }
        }

        /*** Drawing Instance for the Income- Part ***/
        private void IncomeDrawing(BufferedGraphics buffer)
        {
            if (_pInfo.Playercount() <= 0)
                return;

            _tmrMainTick.Interval = _myForm._iIncInterval;
            Opacity = (float)_myForm._iIncOpacity / 100;
            Width = _myForm._iIncWidth;
            Height = _myForm._iIncHeigth * _pInfo.Playercount();
            Location = new Point(_myForm._iIncX, _myForm._iIncY);
            var fDiagonalSize = (float)Math.Sqrt((Math.Pow(Width, 2) + Math.Pow(Height / _pInfo.Playercount(), 2)));

            var i2 = 0;
            for (var i = 0; i < _pInfo.Playercount(); i++)
            {

            Spot_CalculateAgain:

                #region Escape Sequences

                /* Dead Player */
                if (_myForm._bIncRemoveDeadPlayer)
                {
                    if (_pInfo.Status(i).Equals(2))
                        continue;
                }

                /* Ai */
                if (_myForm._bIncRemoveAi)
                {
                    if (_pInfo.Type(i).Equals(2))
                        continue;
                }

                /* Observer */
                if (_myForm._bIncRemoveObserver)
                {
                    if (_pInfo.Type(i).Equals(6))
                        continue;
                }

                /* Referee */
                if (_myForm._bIncRemoveReferee)
                {
                    if (_pInfo.Type(i).Equals(5))
                        continue;
                }

                /* Localplayer */
                if (_myForm._bIncRemoveLocalplayer)
                {
                    if (i.Equals(_pInfo.LocalPlayer()))
                        continue;
                }

                /* Allie */
                if (_myForm._bIncRemoveAllie)
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        continue;
                }

                /* Teamcolor */
                Color clUsercolor;
                if (_pInfo.TeamColor().Equals(2))
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        clUsercolor = Color.Yellow;

                    else if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())))
                        clUsercolor = Color.Green;

                    else
                        clUsercolor = Color.Red;
                }

                else
                    clUsercolor = _pInfo.Color(i);


                /* Check for the playername */
                if (_pInfo.Name(i).Length <= 4)
                {
                    i++;

                    goto Spot_CalculateAgain;

                }

                #endregion


                /* Draw Background per box */
                var clBackground = i2 % 2 == 0
                                       ? Color.FromArgb(255, Color.Gray)
                                       : Color.FromArgb(255, Color.LightSlateGray);

                buffer.Graphics.FillRectangle(new SolidBrush(clBackground), 0,
                    0 + (Height / _pInfo.Playercount()) * i2,
                    Width,
                    Height / _pInfo.Playercount());

                /* Draw a frame per Box */
                buffer.Graphics.DrawRectangle(new Pen(new SolidBrush(clUsercolor), 2), 1,
                    1 + (Height / _pInfo.Playercount()) * i2,
                    Width - 2,
                    Height / _pInfo.Playercount() - 2);

                /* Draw the PlayerName */
                buffer.Graphics.DrawString(_pInfo.Name(i),
                    new Font(_myForm._fIncPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Bold),
                    new SolidBrush(Color.FromArgb(255, clUsercolor)),
                    new PointF(10, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw the PlayerTeam */
                buffer.Graphics.DrawString("#" + _pInfo.Team(i).ToString(CultureInfo.InvariantCulture),
                    new Font(_myForm._fIncPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.2357412793860572f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw Minerals of Player */
                buffer.Graphics.DrawString(_pInfo.MineralsIncome(i).ToString(CultureInfo.InvariantCulture),
                    new Font(_myForm._fIncPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.3626788913631649f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw Gas of Player */
                buffer.Graphics.DrawString(_pInfo.GasIncome(i).ToString(CultureInfo.InvariantCulture),
                    new Font(_myForm._fIncPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.5857264095515113f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw Supply of Player */
                buffer.Graphics.DrawString(_pInfo.Workers(i).ToString(CultureInfo.InvariantCulture),
                    new Font(_myForm._fIncPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.8087739277398577f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                Image imgMin = null,
                      imgGas = null,
                      imgWor = null;

                if (_pInfo.Race(i).Contains("Terr"))
                {
                    imgMin = Properties.Resources.Mineral_Terran;
                    imgGas = Properties.Resources.Gas_Terran;
                    imgWor = Properties.Resources.T_SCV;
                }

                else if (_pInfo.Race(i).Contains("Prot"))
                {
                    imgMin = Properties.Resources.Mineral_Protoss;
                    imgGas = Properties.Resources.Gas_Protoss;
                    imgWor = Properties.Resources.P_Probe;
                }

                else
                {
                    imgMin = Properties.Resources.Mineral_Zerg;
                    imgGas = Properties.Resources.Gas_Zerg;
                    imgWor = Properties.Resources.Z_Drone;
                }

                /* Draw Mineral- Icon */
                buffer.Graphics.DrawImage(imgMin,
                                          0.3082770576586901f * fDiagonalSize,
                                          7 + (Height / _pInfo.Playercount()) * i2, 0.0532194943007624f * fDiagonalSize,
                                          0.0532194943007624f * fDiagonalSize);

                /* Draw Gas- Icon */
                buffer.Graphics.DrawImage(imgGas,
                                          0.5313245758470366f * fDiagonalSize,
                                          7 + (Height / _pInfo.Playercount()) * i2, 0.0532194943007624f * fDiagonalSize,
                                          0.0532194943007624f * fDiagonalSize);

                /* Draw Supply- Icon */
                buffer.Graphics.DrawImage(imgWor,
                                          0.754372094035383f * fDiagonalSize,
                                          7 + (Height / _pInfo.Playercount()) * i2, 0.0532194943007624f * fDiagonalSize,
                                          0.0532194943007624f * fDiagonalSize);

                i2++;
            }
        }

        /*** Drawing Instance for the Apm- Part ***/
        private void ApmDrawing(BufferedGraphics buffer)
        {
            if (_pInfo.Playercount() <= 0)
                return;

            _tmrMainTick.Interval = _myForm._iApmInterval;
            Opacity = (float)_myForm._iApmOpacity / 100;
            Width = _myForm._iApmWidth;
            Height = _myForm._iApmHeigth * _pInfo.Playercount();
            Location = new Point(_myForm._iApmX, _myForm._iApmY);
            var fDiagonalSize = (float)Math.Sqrt((Math.Pow(Width, 2) + Math.Pow(Height / _pInfo.Playercount(), 2)));

            var i2 = 0;
            for (var i = 0; i < _pInfo.Playercount(); i++)
            {

            Spot_CalculateAgain:

                #region Escape Sequences

                /* Dead Player */
                if (_myForm._bApmRemoveDeadPlayer)
                {
                    if (_pInfo.Status(i).Equals(2))
                        continue;
                }

                /* Ai */
                if (_myForm._bApmRemoveAi)
                {
                    if (_pInfo.Type(i).Equals(2))
                        continue;
                }

                /* Observer */
                if (_myForm._bApmRemoveObserver)
                {
                    if (_pInfo.Type(i).Equals(6))
                        continue;
                }

                /* Referee */
                if (_myForm._bApmRemoveReferee)
                {
                    if (_pInfo.Type(i).Equals(5))
                        continue;
                }

                /* Localplayer */
                if (_myForm._bApmRemoveLocalplayer)
                {
                    if (i.Equals(_pInfo.LocalPlayer()))
                        continue;
                }

                /* Allie */
                if (_myForm._bApmRemoveAllie)
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        continue;
                }

                /* Teamcolor */
                Color clUsercolor;
                if (_pInfo.TeamColor().Equals(2))
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        clUsercolor = Color.Yellow;

                    else if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())))
                        clUsercolor = Color.Green;

                    else
                        clUsercolor = Color.Red;
                }

                else
                    clUsercolor = _pInfo.Color(i);


                /* Check for the playername */
                if (_pInfo.Name(i).Length <= 4)
                {
                    i++;

                    goto Spot_CalculateAgain;

                }

                #endregion


                /* Draw Background per box */
                var clBackground = i2 % 2 == 0
                                       ? Color.FromArgb(255, Color.Gray)
                                       : Color.FromArgb(255, Color.LightSlateGray);

                buffer.Graphics.FillRectangle(new SolidBrush(clBackground), 0,
                    0 + (Height / _pInfo.Playercount()) * i2,
                    Width,
                    Height / _pInfo.Playercount());

                /* Draw a frame per Box */
                buffer.Graphics.DrawRectangle(new Pen(new SolidBrush(clUsercolor), 2), 1,
                    1 + (Height / _pInfo.Playercount()) * i2,
                    Width - 2,
                    Height / _pInfo.Playercount() - 2);

                /* Draw the PlayerName */
                buffer.Graphics.DrawString(_pInfo.Name(i),
                    new Font(_myForm._fApmPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Bold),
                    new SolidBrush(Color.FromArgb(255, clUsercolor)),
                    new PointF(10, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw the PlayerTeam */
                buffer.Graphics.DrawString("#" + _pInfo.Team(i).ToString(CultureInfo.InvariantCulture),
                    new Font(_myForm._fApmPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.2357412793860572f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw APM of Player */
                buffer.Graphics.DrawString("APM: [" + _pInfo.Apm(i).ToString(CultureInfo.InvariantCulture) + "]",
                    new Font(_myForm._fApmPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.3626788913631649f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw EPM of Player */
                buffer.Graphics.DrawString("EPM: [" + _pInfo.Epm(i).ToString(CultureInfo.InvariantCulture) + "]",
                    new Font(_myForm._fApmPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.5440183370447473f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                i2++;
            }
        }

        /*** Drawing Instance for the Army- Part ***/
        private void ArmyDrawing(BufferedGraphics buffer)
        {
            if (_pInfo.Playercount() <= 0)
                return;

            _tmrMainTick.Interval = _myForm._iArmInterval;
            Opacity = (float)_myForm._iArmOpacity / 100;
            Width = _myForm._iArmWidth;
            Height = _myForm._iArmHeigth * _pInfo.Playercount();
            Location = new Point(_myForm._iArmX, _myForm._iArmY);
            var fDiagonalSize = (float)Math.Sqrt((Math.Pow(Width, 2) + Math.Pow(Height / _pInfo.Playercount(), 2)));

            var i2 = 0;
            for (var i = 0; i < _pInfo.Playercount(); i++)
            {
            Spot_CalculateAgain:

                #region Escape Sequences

                /* Dead Player */
                if (_myForm._bArmRemoveDeadPlayer)
                {
                    if (_pInfo.Status(i).Equals(2))
                        continue;
                }

                /* Ai */
                if (_myForm._bArmRemoveAi)
                {
                    if (_pInfo.Type(i).Equals(2))
                        continue;
                }

                /* Observer */
                if (_myForm._bArmRemoveObserver)
                {
                    if (_pInfo.Type(i).Equals(6))
                        continue;
                }

                /* Referee */
                if (_myForm._bArmRemoveReferee)
                {
                    if (_pInfo.Type(i).Equals(5))
                        continue;
                }

                /* Localplayer */
                if (_myForm._bArmRemoveLocalplayer)
                {
                    if (i.Equals(_pInfo.LocalPlayer()))
                        continue;
                }

                /* Allie */
                if (_myForm._bArmRemoveAllie)
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        continue;
                }

                /* Teamcolor */
                Color clUsercolor;
                if (_pInfo.TeamColor().Equals(2))
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        clUsercolor = Color.Yellow;

                    else if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())))
                        clUsercolor = Color.Green;

                    else
                        clUsercolor = Color.Red;
                }

                else
                    clUsercolor = _pInfo.Color(i);


                /* Check for the playername */
                if (_pInfo.Name(i).Length <= 4)
                {
                    i++;

                    goto Spot_CalculateAgain;

                }

                #endregion


                /* Draw Background per box */
                var clBackground = i2 % 2 == 0
                                       ? Color.FromArgb(255, Color.Gray)
                                       : Color.FromArgb(255, Color.LightSlateGray);

                buffer.Graphics.FillRectangle(new SolidBrush(clBackground), 0,
                    0 + (Height / _pInfo.Playercount()) * i2,
                    Width,
                    Height / _pInfo.Playercount());

                /* Draw a frame per Box */
                buffer.Graphics.DrawRectangle(new Pen(new SolidBrush(clUsercolor), 2), 1,
                    1 + (Height / _pInfo.Playercount()) * i2,
                    Width - 2,
                    Height / _pInfo.Playercount() - 2);

                /* Draw the PlayerName */
                buffer.Graphics.DrawString(_pInfo.Name(i),
                    new Font(_myForm._fArmPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Bold),
                    new SolidBrush(Color.FromArgb(255, clUsercolor)),
                    new PointF(10, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw the PlayerTeam */
                buffer.Graphics.DrawString("#" + _pInfo.Team(i).ToString(CultureInfo.InvariantCulture),
                    new Font(_myForm._fArmPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.2357412793860572f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw Minerals of Player */
                buffer.Graphics.DrawString(_pInfo.MineralsArmy(i).ToString(CultureInfo.InvariantCulture),
                    new Font(_myForm._fArmPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.3626788913631649f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw Gas of Player */
                buffer.Graphics.DrawString(_pInfo.GasArmy(i).ToString(CultureInfo.InvariantCulture),
                    new Font(_myForm._fArmPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.5857264095515113f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                /* Draw Supply of Player */
                buffer.Graphics.DrawString(_pInfo.SupplyMin(i).ToString(CultureInfo.InvariantCulture) + "/" +
                _pInfo.SupplyMax(i).ToString(CultureInfo.InvariantCulture),
                    new Font(_myForm._fArmPanelFont.Name, fFontSize * fDiagonalSize, FontStyle.Regular),
                    new SolidBrush(Color.FromArgb(255, Color.White)),
                    new PointF(0.8087739277398577f * fDiagonalSize, 10 + (Height / _pInfo.Playercount()) * i2));

                Image imgMin = null,
                      imgGas = null,
                      imgSup = null;

                if (_pInfo.Race(i).Contains("Terr"))
                {
                    imgMin = Properties.Resources.Mineral_Terran;
                    imgGas = Properties.Resources.Gas_Terran;
                    imgSup = Properties.Resources.Supply_Terran;
                }

                else if (_pInfo.Race(i).Contains("Prot"))
                {
                    imgMin = Properties.Resources.Mineral_Protoss;
                    imgGas = Properties.Resources.Gas_Protoss;
                    imgSup = Properties.Resources.Supply_Protoss;
                }

                else
                {
                    imgMin = Properties.Resources.Mineral_Zerg;
                    imgGas = Properties.Resources.Gas_Zerg;
                    imgSup = Properties.Resources.Supply_Zerg;
                }

                /* Draw Mineral- Icon */
                buffer.Graphics.DrawImage(imgMin,
                                          0.3082770576586901f * fDiagonalSize,
                                          7 + (Height / _pInfo.Playercount()) * i2, 0.0532194943007624f * fDiagonalSize,
                                          0.0532194943007624f * fDiagonalSize);

                /* Draw Gas- Icon */
                buffer.Graphics.DrawImage(imgGas,
                                          0.5313245758470366f * fDiagonalSize,
                                          7 + (Height / _pInfo.Playercount()) * i2, 0.0532194943007624f * fDiagonalSize,
                                          0.0532194943007624f * fDiagonalSize);

                /* Draw Supply- Icon */
                buffer.Graphics.DrawImage(imgSup,
                                          0.754372094035383f * fDiagonalSize,
                                          7 + (Height / _pInfo.Playercount()) * i2, 0.0532194943007624f * fDiagonalSize,
                                          0.0532194943007624f * fDiagonalSize);

                i2++;
            }
        }

        /*** Drawing Instance for the Worker- Part ***/
        private void WorkerDrawing(BufferedGraphics buffer)
        {

            if (_pInfo.Playercount() <= 0)
                return;

            _tmrMainTick.Interval = _myForm._iWorInterval;
            Opacity = (float)_myForm._iWorOpacity / 100;
            Width = _myForm._iWorWidth;
            Height = _myForm._iWorHeigth;
            Location = new Point(_myForm._iWorX, _myForm._iWorY);
            var fDiagonalSize = (float)Math.Sqrt((Math.Pow(Width, 2) + Math.Pow(Height, 2)));

            #region Teamcolor
            /* Teamcolor */
            var clUsercolor = _pInfo.TeamColor().Equals(2) ? Color.Green : _pInfo.Color(_pInfo.LocalPlayer());

            #endregion

            

            buffer.Graphics.FillRectangle(new SolidBrush(Color.Gray), 0,
                    0,
                    Width,
                    Height);

            /* Draw a frame per Box */
            buffer.Graphics.DrawRectangle(new Pen(new SolidBrush(clUsercolor), 2), 1,
                1,
                Width - 2,
                Height - 2);

            /* Draw the PlayerName */
            buffer.Graphics.DrawString(_pInfo.Workers(_pInfo.LocalPlayer()).ToString(CultureInfo.InvariantCulture) + " Workers",
                new Font(_myForm._fWorPanelFont.Name, 0.077298669174579f * fDiagonalSize, FontStyle.Bold),
                new SolidBrush(clUsercolor),
                new PointF(10, 10));
        }

        /*** Drawing Instance for the Maphack- Part ***/
        private void MaphackDrawing(BufferedGraphics buffer)
        {
            _tmrMainTick.Interval = _myForm._iMapInterval;
            Opacity = (float)_myForm._iMapOpacity / 100;
            Width = _myForm._iMapWidth;
            Height = _myForm._iMapHeigth;
            Location = new Point(_myForm._iMapX, _myForm._iMapY);
            var fDiagonalSize = (float)Math.Sqrt((Math.Pow(Width, 2) + Math.Pow(Height, 2)));


            #region Variables


            var iPlayableWidht = _pInfo.MapRight() - _pInfo.MapLeft();
            var iPlayableHeight = _pInfo.MapTop() - _pInfo.MapBottom();

            float iScale = 0,
                  iX = 0,
                  iY = 0;

            #endregion
            
            #region Get minimap Bounds

            double fa = (float)Height / (float)Width;
            double fb = ((float)iPlayableHeight / (float)iPlayableWidht);

            if (fa >= fb)
            {
                iScale = (float)Width / (float)iPlayableWidht;
                iX = 0;
                iY = (Height - iScale * iPlayableHeight) / 2;
            }
            else
            {
                iScale = (float)Height / (float)iPlayableHeight;
                iY = 0;
                iX = (Width - iScale * iPlayableWidht) / 2;
            }

            #endregion    

            #region Draw Bounds

            /* Draw the background */
            buffer.Graphics.FillRectangle(new SolidBrush(Color.Transparent), 0,
                0,
                Width,
                Height);

            /* Draw a frame per Box */
            buffer.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Magenta)), 0,
                0,
                Width - 1,
                Height - 1);

            /* Draw a bow about the the playable area */
            buffer.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.GreenYellow)), iX, iY,
                                 (Width - iX * 2 - 1),
                                 (Height - iY * 2 - 1));

            #endregion

            #region Draw Unit Destination- Line - LEAST PRIORITY

            for (var i = 0; i < _pInfo.UnitTotal(); i++)
            {

                var clDesti = _myForm._cMapColorofDestinationLine;


                #region Scalling

                //Position of units
                var iUnitX = (_pInfo.UnitPosX(i) - _pInfo.MapLeft()) * iScale + iX;
                var iUnitY = (_pInfo.MapTop() - _pInfo.UnitPosY(i)) * iScale + iY;

            

                #endregion

                #region Color Definition

                var clUnitColor = Color.Green;
                var clUnitBorder = Color.Black;


                #region Teamcolor

                /* Teamcolor is Red (Enemy), Green (yourself) and Yellow (Allie) */
                if (_pInfo.TeamColor().Equals(2))
                {
                    //Myself
                    if (_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        clUnitColor = Color.Green;

                    //Enemy
                    else
                        clUnitColor = Color.Red;

                    //Allie
                    if (_pInfo.Team(_pInfo.UnitOwner(i)).Equals(_pInfo.Team(_pInfo.LocalPlayer() + 1)) &&
                        !_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        clUnitColor = Color.Yellow;
                }

                else
                    clUnitColor = _pInfo.Color(_pInfo.UnitOwner(i) - 1);



                #endregion

                #endregion





                #region Escape Sequences

                #region Remove Neutral Units - OKAY

                /* Neutral Units */
                if (_pInfo.UnitOwner(i).Equals(0))
                {
                    clUnitColor = Color.Transparent;
                    clUnitBorder = Color.Transparent;
                    clDesti = Color.Transparent;
                }

                #endregion

                #region Remove Larva

                if (_pInfo.UnitId(i).Equals((int)Typo.UnitId.ZuLarva))
                {
                    clUnitColor = Color.Transparent;
                    clUnitBorder = Color.Transparent;
                    clDesti = Color.Transparent;
                }

                #endregion

                #region Remove Allie

                if (_myForm._bMapRemoveAllie)
                {
                    if (_pInfo.Team(_pInfo.UnitOwner(i)).Equals(_pInfo.Team(_pInfo.LocalPlayer() + 1)) &&
                        !_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        continue;
                }

                #endregion

                #region Remove Ai

                if (_myForm._bMapRemoveAi)
                {
                    if (_pInfo.Type(_pInfo.UnitOwner(i) - 1).Equals(2))
                        continue;
                }

                #endregion

                #region Remove Local Player - OKAY

                /* Remove Yourself */
                if (_myForm._bMapRemoveLocalplayer)
                {
                    if (_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                    {
                        continue;
                    }
                }

                #endregion

                #region Remove Dead Units - OKAY

                /* Dead Units */
                if ((_pInfo.UnitTargetFilter(i) & 0x0000000200000000) > 0)
                {
                    clUnitColor = Color.Transparent;
                    clUnitBorder = Color.Transparent;
                    clDesti = Color.Transparent;
                }

                #endregion

                #region Remove Destination Line - OKAY

                if (_myForm._bShowDestinationLine)
                    clDesti = Color.Transparent;

                #endregion

                #region The Unit is not moving - OKAY

                if (_pInfo.UnitMoveState(i).Equals(0))
                    clDesti = Color.Transparent;

                #endregion

                #region Unit Cloaked - DISABLED

                //if ((_pInfo.UnitTargetFilter(i) & 0x0000000020000000) > 0)
                //{

                //    buffer.Graphics.DrawEllipse(new Pen(Brushes.BlueViolet, 2),
                //                                iUnitX - 7,
                //                                iUnitY - 7,
                //                                14,
                //                                14);
                //}

                #endregion

                #endregion


                

                #region Draw destination line

                var iUnitDestX = (_pInfo.UnitDestPosX(i) - _pInfo.MapLeft()) * iScale + iX;
                var iUnitDestY = (_pInfo.MapTop() - _pInfo.UnitDestPosY(i)) * iScale + iY;

                //Don't draw when it's negative
                if (_pInfo.UnitDestPosX(i) > 10 && _pInfo.UnitDestPosY(i) > 10)
                {
                    buffer.Graphics.DrawLine(new Pen(new SolidBrush(clDesti)), iUnitX,
                                             iUnitY, iUnitDestX,
                                             iUnitDestY);
                }

                #endregion
            }

            #endregion

            #region Draw Player Cameras - SECOND PRIORITY


            for (var i = 0; i < _pInfo.Playercount(); i++)
            {
                #region Escape Sequences

                /* Dead Player */
                if (_pInfo.Status(i).Equals(2))
                    continue;


                /* Ai */
                if (_myForm._bMapRemoveAi)
                {
                    if (_pInfo.Type(i).Equals(2))
                        continue;
                }

                /* Observer */
                if (_pInfo.Type(i).Equals(6))
                    continue;


                /* Referee */
                if (_pInfo.Type(i).Equals(5))
                    continue;


                /* Localplayer */
                if (_myForm._bMapRemoveLocalplayer)
                {
                    if (i.Equals(_pInfo.LocalPlayer()))
                        continue;
                }

                /* Allie */
                if (_myForm._bMapRemoveAllie)
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        continue;
                }

                /* Teamcolor */
                Color clUsercolor;
                if (_pInfo.TeamColor().Equals(2))
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i != _pInfo.LocalPlayer())
                        clUsercolor = Color.Yellow;

                    else if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())))
                        clUsercolor = Color.Green;

                    else
                        clUsercolor = Color.Red;
                }

                else
                {
                    if (_pInfo.Team(i).Equals(_pInfo.Team(_pInfo.LocalPlayer())) &&
                        i == _pInfo.LocalPlayer())
                        clUsercolor = Color.Green;

                    else
                        clUsercolor = _pInfo.Color(i);
                }



                #endregion

                #region Draw The Players Camera

                //Distance (will change the trapez)
                var distance = _pInfo.CameraDistance(i);

                //The actrual position of the Cameras
                var iPlayerX = (_pInfo.CameraX(i) - _pInfo.MapLeft()) * iScale + iX;
                var iPlayerY = (_pInfo.MapTop() - _pInfo.CameraY(i)) * iScale + iY;

                if (iPlayerX <= 0 ||
                    iPlayerY <= 0)
                    continue;
                

                //Base distance: 139216
                //1.0273020422787531350770333213902 * 34,06982421875 = 35
                var ptPoints = new PointF[4];
                ptPoints[0] = new PointF((int)iPlayerX - 35, (int)iPlayerY - 24);
                ptPoints[1] = new PointF((int)iPlayerX + 35, (int)iPlayerY - 24);
                ptPoints[2] = new PointF((int)iPlayerX + 24, (int)iPlayerY + 10);
                ptPoints[3] = new PointF((int)iPlayerX - 24, (int)iPlayerY + 10);

                //If you want, take this with the angle of attack (0x014), doesnt need to be divided by 4096!
                //ptPoints[0] = new PointF((int)iPlayerX - (int)(0.0068789308176101 * distance), (int)iPlayerY - (int)(0.0049135220125786 * distance));
                //ptPoints[1] = new PointF((int)iPlayerX + (int)(0.0068789308176101 * distance), (int)iPlayerY - (int)(0.0049135220125786 * distance));
                //ptPoints[2] = new PointF((int)iPlayerX + (int)(0.0049135220125786 * distance), (int)iPlayerY + (int)(0.0019654088050314 * distance));
                //ptPoints[3] = new PointF((int)iPlayerX - (int)(0.0049135220125786 * distance), (int)iPlayerY + (int)(0.0019654088050314 * distance));


                buffer.Graphics.DrawPolygon(new Pen(new SolidBrush(clUsercolor), 2), ptPoints);

                #endregion
            }


            #endregion

            #region Draw Units - FIRST PRIORITY


            for (var i = 0; i < _pInfo.UnitTotal(); i++)
            {


                #region Scalling

                //Position of units
                var iUnitX = (_pInfo.UnitPosX(i) - _pInfo.MapLeft()) * iScale + iX;
                var iUnitY = (_pInfo.MapTop() - _pInfo.UnitPosY(i)) * iScale + iY;

                var dsize = _pInfo.UnitSize(i);

                #endregion

                #region Color Definition

                var clUnitColor = Color.Green;
                var clUnitBorder = Color.Black;


                #region Teamcolor

                /* Teamcolor is Red (Enemy), Green (yourself) and Yellow (Allie) */
                if (_pInfo.TeamColor().Equals(2))
                {
                    //Myself
                    if (_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        clUnitColor = Color.Green;

                        //Enemy
                    else
                        clUnitColor = Color.Red;

                    //Allie
                    if (_pInfo.Team(_pInfo.UnitOwner(i)).Equals(_pInfo.Team(_pInfo.LocalPlayer() + 1)) &&
                        !_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        clUnitColor = Color.Yellow;
                }

                else
                {
                    //Myself
                    if (_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        clUnitColor = Color.Green;

                    else
                        clUnitColor = _pInfo.Color(_pInfo.UnitOwner(i) - 1);
                }



                #endregion

                #endregion

                #region Escape Sequences

                #region Remove Neutral Units - OKAY

                /* Neutral Units */
                if (_pInfo.UnitOwner(i).Equals(0))
                {
                    clUnitColor = Color.Transparent;
                    clUnitBorder = Color.Transparent;
                }

                #endregion

                #region Remove Larva

                if (_pInfo.UnitId(i).Equals((int)Typo.UnitId.ZuLarva))
                {
                    clUnitColor = Color.Transparent;
                    clUnitBorder = Color.Transparent;
                }

                #endregion

                #region Remove Allie

                if (_myForm._bMapRemoveAllie)
                {
                    if (_pInfo.Team(_pInfo.UnitOwner(i)).Equals(_pInfo.Team(_pInfo.LocalPlayer() + 1)) &&
                        !_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        continue;
                }

                #endregion

                #region Remove Ai

                if (_myForm._bMapRemoveAi)
                {
                    if (_pInfo.Type(_pInfo.UnitOwner(i) - 1).Equals(2))
                        continue;
                }

                #endregion

                #region Remove Local Player - OKAY

                /* Remove Yourself */
                if (_myForm._bMapRemoveLocalplayer)
                {
                    if (_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                    {
                        clUnitColor = Color.Transparent;
                        clUnitBorder = Color.Transparent;
                    }
                }

                #endregion

                #region Remove Dead Units - OKAY

                /* Dead Units */
                if ((_pInfo.UnitTargetFilter(i) & 0x0000000200000000) > 0)
                {
                    clUnitColor = Color.Transparent;
                    clUnitBorder = Color.Transparent;
                }

                #endregion


                #region Unit Cloaked - DISABLED

                //if ((_pInfo.UnitTargetFilter(i) & 0x0000000020000000) > 0)
                //{

                //    buffer.Graphics.DrawEllipse(new Pen(Brushes.BlueViolet, 2),
                //                                iUnitX - 7,
                //                                iUnitY - 7,
                //                                14,
                //                                14);
                //}

                #endregion

                #endregion

                #region Draw Unit and black sqaure around + Unitcoloring


                //5.3333333333333333333333333333333 = 2 / 0,375 (0,375 beeing the smallest value ingame and 2 px the same fopr visuality
                var dModifiedSize = (2.1781171647339959438013099741158 * iScale) * dsize;
                //dModifiedSize += (1f / iScale);

                //black bounds around
                buffer.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBorder)),
                                         iUnitX - ((int)(dModifiedSize / 2) + 0.5f),
                                         iUnitY - ((int)(dModifiedSize / 2) + 0.5f),
                                         (int)dModifiedSize + 1,
                                         (int)dModifiedSize + 1);

                //Actual point
                buffer.Graphics.FillRectangle(new SolidBrush(clUnitColor),
                                         iUnitX - (int)(dModifiedSize / 2),
                                         iUnitY - (int)(dModifiedSize / 2),
                                         (int)(dModifiedSize),
                                         (int)(dModifiedSize));


                #region Color Defensive- Buldings ONLY ENEMIES

                if (_myForm._bMapColorDefensive)
                {
                    if (!_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                    {
                        //Draw yellow square around unit
                        if (_pInfo.UnitId(i).Equals((int) Typo.UnitId.TbBunker) |
                            _pInfo.UnitId(i).Equals((int) Typo.UnitId.TbTurret) |
                            _pInfo.UnitId(i).Equals((int) Typo.UnitId.TbPlanetary) |
                            _pInfo.UnitId(i).Equals((int) Typo.UnitId.PbCannon) |
                            _pInfo.UnitId(i).Equals((int) Typo.UnitId.ZbSpineCrawler) |
                            _pInfo.UnitId(i).Equals((int) Typo.UnitId.ZbSporeCrawler))
                        {
                            var clBound = (_pInfo.UnitTargetFilter(i) & 0x0000000200000000) > 0
                                              ? Color.Transparent
                                              : _myForm._cMapColorDefensive;

                            buffer.Graphics.DrawRectangle(new Pen(clBound, 2),
                                                          iUnitX - ((int) (dModifiedSize/2) + 0.5f),
                                                          iUnitY - ((int) (dModifiedSize/2) + 0.5f),
                                                          (int) dModifiedSize + 1,
                                                          (int) dModifiedSize + 1);
                        }
                    }
                }

                #endregion
             
                #region Color Dropships and Warpprisms ONLY ENEMIES

                if (_myForm._bMapColorMedics)
                {
                    if (!_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                    {
                        if (_pInfo.UnitId(i).Equals((int) Typo.UnitId.TuMedivac) ||
                            _pInfo.UnitId(i).Equals((int) Typo.UnitId.PuWarpprismTransport) ||
                            _pInfo.UnitId(i).Equals((int)Typo.UnitId.PuWarpprismPhase))
                        {

                            var clBound = (_pInfo.UnitTargetFilter(i) & 0x0000000200000000) > 0
                                              ? Color.Transparent
                                              : _myForm._cMapColorMedics;

                            buffer.Graphics.DrawRectangle(new Pen(clBound, 2),
                                                          iUnitX - ((int) (dModifiedSize/2) + 0.5f),
                                                          iUnitY - ((int) (dModifiedSize/2) + 0.5f),
                                                          (int) dModifiedSize + 1,
                                                          (int) dModifiedSize + 1);
                        }
                    }
                }

                #endregion

                #region Color DTs Purple ONLY ENEMIES

                if (_myForm._bMapColorDT)
                {
                    if (!_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                    {
                        if (_pInfo.UnitId(i).Equals((int) Typo.UnitId.PuDarktemplar))
                        {

                            var clBound = (_pInfo.UnitTargetFilter(i) & 0x0000000200000000) > 0
                                              ? Color.Transparent
                                              : _myForm._cMapColorDT;

                            buffer.Graphics.DrawRectangle(new Pen(clBound, 2),
                                                          iUnitX - ((int) (dModifiedSize/2) + 0.5f),
                                                          iUnitY - ((int) (dModifiedSize/2) + 0.5f),
                                                          (int) dModifiedSize + 1,
                                                          (int) dModifiedSize + 1);
                        }
                    }
                }

                #endregion

                #region Color Queens, Orbitals and Nexi 

                if (_myForm._bMapColorNexiOcQueen)
                {

                    //Draw yellow square around unit
                    if (_pInfo.UnitId(i).Equals((int) Typo.UnitId.ZuQueen))
                    {
                        if (_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        {
                            if (_pInfo.UnitEnergy(i) >= 25)
                            {
                                var clBound = (_pInfo.UnitTargetFilter(i) & 0x0000000200000000) > 0
                                                  ? Color.Transparent
                                                  : _myForm._cMapColorNexiOcQueen;

                                buffer.Graphics.DrawRectangle(new Pen(clBound, 2),
                                                              iUnitX - ((int) (dModifiedSize/2) + 0.5f),
                                                              iUnitY - ((int) (dModifiedSize/2) + 0.5f),
                                                              (int) dModifiedSize + 1,
                                                              (int) dModifiedSize + 1);
                            }
                        }
                    }

                    if (_pInfo.UnitId(i).Equals((int) Typo.UnitId.PbNexus))
                    {
                        if (_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        {
                            if (_pInfo.UnitEnergy(i) >= 25)
                            {
                                var clBound = (_pInfo.UnitTargetFilter(i) & 0x0000000200000000) > 0
                                                  ? Color.Transparent
                                                  : _myForm._cMapColorNexiOcQueen;

                                buffer.Graphics.DrawRectangle(new Pen(clBound, 2),
                                                              iUnitX - ((int) (dModifiedSize/2) + 0.5f),
                                                              iUnitY - ((int) (dModifiedSize/2) + 0.5f),
                                                              (int) dModifiedSize + 1,
                                                              (int) dModifiedSize + 1);
                            }
                        }
                    }

                    if (_pInfo.UnitId(i).Equals((int) Typo.UnitId.TbOrbitalAir) ||
                        _pInfo.UnitId(i).Equals((int) Typo.UnitId.TbOrbitalGround))
                    {
                        if (_pInfo.UnitOwner(i).Equals(_pInfo.LocalPlayer() + 1))
                        {
                            if (_pInfo.UnitEnergy(i) >= 50)
                            {
                                var clBound = (_pInfo.UnitTargetFilter(i) & 0x0000000200000000) > 0
                                                  ? Color.Transparent
                                                  : _myForm._cMapColorNexiOcQueen;

                                buffer.Graphics.DrawRectangle(new Pen(clBound, 2),
                                                              iUnitX - ((int) (dModifiedSize/2) + 0.5f),
                                                              iUnitY - ((int) (dModifiedSize/2) + 0.5f),
                                                              (int) dModifiedSize + 1,
                                                              (int) dModifiedSize + 1);
                            }
                        }
                    }

                }

                #endregion


                #endregion


            }
            #endregion
        }

        /*** Drawing instance for the Unit- Panel ***/
        private void UnitDrawing(BufferedGraphics buffer)
        {
            Font fArial = new Font("Arial", 8);

            for (var i = 1; i <= _pInfo.Playercount(); i++)
            {
                var ibufferScv = CountUnit(i, (int) Typo.UnitId.TuScv);
                if (ibufferScv > 0)
                {
                    buffer.Graphics.DrawImage(Properties.Resources.T_SCV, i * 30 ,i * 30, 30, 30);
                    buffer.Graphics.DrawString(ibufferScv.ToString(), fArial, Brushes.White, i * 30, i * 30);
                }

                var ibufferMarine = CountUnit(i, (int) Typo.UnitId.TuMarine);
                if (ibufferMarine > 0)
                {
                    buffer.Graphics.DrawImage(Properties.Resources.t_marine, i * 45, i * 30, 30, 30);
                    buffer.Graphics.DrawString(ibufferMarine.ToString(), fArial, Brushes.White, i * 45, i * 30);
                }
            }


        }

        /*** Helping method to count the Unitamount ***/
        private int CountUnit(int playerNum, int unitId)
        {
            var idummy = 0;

            for (var i = 0; i < _pInfo.UnitTotal(); i++)
            {
                if (_pInfo.UnitOwner(i).Equals(playerNum))
                {
                    if (_pInfo.UnitId(i).Equals(unitId))
                        idummy++;
                }
            }

            return idummy;
        }

        /*** Draw Notifications for specific Units ***/
        private void NotificationDrawing(BufferedGraphics buffer)
        {
            if (!_myForm._bSupply &&
                !_myForm._bMule)
                return;

            _tmrMainTick.Interval = _myForm._iNotInterval;
            Opacity = (float)_myForm._iNotOpacity / 100;
            Width = _myForm._iNotWidth;
            Height = _myForm._iNotHeigth;
            Location = new Point(_myForm._iNotX, _myForm._iNotY);
            var fDiagonalSize = (float)Math.Sqrt((Math.Pow(Width, 2) + Math.Pow(Height, 2)));

            int iIndex = 0;

            var strMessage = new string[2];
            var iDummyDistance = 0;
            var clWarningColor = new Color[2];

            var iDummyMuleCount = 0;         


            #region We'll handle the messages about the supply here

            if (_myForm._bSupply)
            {
                var iMaxSupply = _pInfo.SupplyMax(_pInfo.LocalPlayer());
                var iCurrentSupply = _pInfo.SupplyMin(_pInfo.LocalPlayer());

                if (ProofSupply(iMaxSupply, iCurrentSupply, out iDummyDistance))
                {
                    if (iCurrentSupply >= iMaxSupply)
                    {
                        clWarningColor[iIndex] = Color.Red;
                        strMessage[iIndex] = "Supply- Warning: You are stuck!";
                        iIndex++;
                    }

                    else
                    {
                        clWarningColor[iIndex] = Color.Orange;
                        strMessage[iIndex] = "Supply- Warning: You are about to get stuck!";
                        iIndex++;
                    }
                }

                
            }

            #endregion

            
            #region Here we'll handle the messages about the Mule/ Queens/ Chronoboosts

            if (_myForm._bMule)
            {
                for (int i = 0; i < _pInfo.UnitTotal(); i++)
                {
                    if (_pInfo.UnitOwner(i) != _pInfo.LocalPlayer() + 1)
                        continue;

                    if (_pInfo.UnitId(i).Equals((int) Typo.UnitId.TbOrbitalGround) ||
                        _pInfo.UnitId(i).Equals((int) Typo.UnitId.TbOrbitalAir))
                    {
                        if (_pInfo.UnitEnergy(i) >= 50)
                        {
                            iDummyMuleCount += _pInfo.UnitEnergy(i)/50;
                            strMessage[iIndex] = "Mule- Warning: You have call-able Mule(s)!";
                            clWarningColor[iIndex] = Color.Orange;
                        }
                    }

                    if (_pInfo.UnitId(i).Equals((int) Typo.UnitId.ZuQueen))
                    {
                        if (_pInfo.UnitEnergy(i) >= 25)
                        {
                            iDummyMuleCount += _pInfo.UnitEnergy(i)/25;
                            strMessage[iIndex] = "Queen- Warning: You have available Injects!";
                            clWarningColor[iIndex] = Color.Orange;
                        }
                    }

                    if (_pInfo.UnitId(i).Equals((int) Typo.UnitId.PbNexus))
                    {
                        if (_pInfo.UnitEnergy(i) >= 50)
                        {
                            iDummyMuleCount += _pInfo.UnitEnergy(i)/50;
                            strMessage[iIndex] = "Nexus- Warning: You have Chronoboost(s)!";
                            clWarningColor[iIndex] = Color.Orange;
                        }
                    }
                }

                strMessage[iIndex] += " (" + iDummyMuleCount.ToString(CultureInfo.InvariantCulture) + ")";


                if (iDummyMuleCount > 0)
                    iIndex++;
            }

            #endregion


            #region Draw bounds

            if (iIndex > 0)
            {
                buffer.Graphics.FillRectangle(new SolidBrush(Color.Gray), 0,
                                              0,
                                              Width - 2,
                                              Height - 2);

                /* Draw a frame per Box */
                buffer.Graphics.DrawRectangle(new Pen(new SolidBrush(_pInfo.Color(_pInfo.LocalPlayer())), 2), 1,
                                              1,
                                              Width - 2,
                                              Height - 2);
            }

            #endregion

            #region Draw the actual warning

            for (var i = 0; i < iIndex; i++)
            {
                /* Supply- warning */
                buffer.Graphics.DrawString(strMessage[i],
                                           new Font(_myForm._fNotPanelFont.Name, 0.028108669174579f*fDiagonalSize,
                                                    FontStyle.Bold),
                                           new SolidBrush(clWarningColor[i]),
                                           new PointF(10, 10 +  i*25));

            }

            #endregion
        }

        /*** Handle Form- position ***/
        private bool _bSetPosition = false;
        private void AdjustFormPosition()
        {
            /* Ressource */
            if (_myType.Equals(Typo.BufferformType.Ressource))
            {
                if (_bSetPosition)
                {
                    Location = Cursor.Position;
                    _myForm._iResX = Cursor.Position.X;
                    _myForm._iResY = Cursor.Position.Y;
                }

                if (_strBackup.Contains(_myForm._sResPos))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = "";
                }
            }

            /* Income */
            else if (_myType.Equals(Typo.BufferformType.Income))
            {
                if (_bSetPosition)
                {
                    Location = Cursor.Position;
                    _myForm._iIncX = Cursor.Position.X;
                    _myForm._iIncY = Cursor.Position.Y;
                }

                if (_strBackup.Contains(_myForm._sIncPos))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = "";
                }
            }

            /* Apm */
            else if (_myType.Equals(Typo.BufferformType.Apm))
            {


                if (_bSetPosition)
                {
                    Location = Cursor.Position;
                    _myForm._iApmX = Cursor.Position.X;
                    _myForm._iApmY = Cursor.Position.Y;
                }

                if (_strBackup.Contains(_myForm._sApmPos))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = "";
                }
            }

            /* Army */
            else if (_myType.Equals(Typo.BufferformType.Army))
            {


                if (_bSetPosition)
                {
                    Location = Cursor.Position;
                    _myForm._iArmX = Cursor.Position.X;
                    _myForm._iArmY = Cursor.Position.Y;
                }

                if (_strBackup.Contains(_myForm._sArmPos))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = "";
                }
            }

            /* Worker */
            else if (_myType.Equals(Typo.BufferformType.Worker))
            {


                if (_bSetPosition)
                {
                    Location = Cursor.Position;
                    _myForm._iWorX = Cursor.Position.X;
                    _myForm._iWorY = Cursor.Position.Y;
                }

                if (_strBackup.Contains(_myForm._sWorPos))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = "";
                }
            }

            /* Maphack */
            else if (_myType.Equals(Typo.BufferformType.Maphack))
            {


                if (_bSetPosition)
                {
                    Location = Cursor.Position;
                    _myForm._iMapX = Cursor.Position.X;
                    _myForm._iMapY = Cursor.Position.Y;
                }

                if (_strBackup.Contains(_myForm._sMapPos))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = "";
                }
            }

            /* Maphack */
            else if (_myType.Equals(Typo.BufferformType.Notification))
            {


                if (_bSetPosition)
                {
                    Location = Cursor.Position;
                    _myForm._iNotX = Cursor.Position.X;
                    _myForm._iNotY = Cursor.Position.Y;
                }

                if (_strBackup.Contains(_myForm._sNotPos))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = "";
                }
            }
        }

        /*** Handle Form- position ***/
        private bool _bSetSize = false;
        private void AdjustFormSize()
        {
            /* Ressource */
            if (_myType.Equals(Typo.BufferformType.Ressource))
            {
                if (_bSetSize)
                {
                    _myForm._iResWidth = Cursor.Position.X - Left;
                    _myForm._iResHeigth = (Cursor.Position.Y - Top) / _pInfo.Playercount();

                }

                if (_strBackup.Contains(_myForm._sResSize))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetSize = false;
                    _strBackup = "";
                }
            }

            /* Income */
            if (_myType.Equals(Typo.BufferformType.Income))
            {
                if (_bSetSize)
                {
                    _myForm._iIncWidth = Cursor.Position.X - Left;
                    _myForm._iIncHeigth = (Cursor.Position.Y - Top) / _pInfo.Playercount();
                }

                if (_strBackup.Contains(_myForm._sIncSize))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetSize = false;
                    _strBackup = "";
                }
            }

            /* Apm */
            if (_myType.Equals(Typo.BufferformType.Apm))
            {
                if (_bSetSize)
                {
                    _myForm._iApmWidth = Cursor.Position.X - Left;
                    _myForm._iApmHeigth = (Cursor.Position.Y - Top) / _pInfo.Playercount();
                }

                if (_strBackup.Contains(_myForm._sApmSize))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetSize = false;
                    _strBackup = "";
                }
            }

            /* Army */
            if (_myType.Equals(Typo.BufferformType.Army))
            {
                if (_bSetSize)
                {
                    _myForm._iArmWidth = Cursor.Position.X - Left;
                    _myForm._iArmHeigth = (Cursor.Position.Y - Top) / _pInfo.Playercount();
                }

                if (_strBackup.Contains(_myForm._sArmSize))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetSize = false;
                    _strBackup = "";
                }
            }

            /* Worker */
            if (_myType.Equals(Typo.BufferformType.Worker))
            {
                if (_bSetSize)
                {
                    _myForm._iWorWidth = Cursor.Position.X - Left;
                    _myForm._iWorHeigth = (Cursor.Position.Y - Top);
                }

                if (_strBackup.Contains(_myForm._sWorSize))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetSize = false;
                    _strBackup = "";
                }
            }

            /* Maphack */
            if (_myType.Equals(Typo.BufferformType.Maphack))
            {
                if (_bSetSize)
                {
                    _myForm._iMapWidth = Cursor.Position.X - Left;
                    _myForm._iMapHeigth = (Cursor.Position.Y - Top);
                }

                if (_strBackup.Contains(_myForm._sMapSize))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetSize = false;
                    _strBackup = "";
                }
            }

            /* Notification */
            if (_myType.Equals(Typo.BufferformType.Notification))
            {
                if (_bSetSize)
                {
                    _myForm._iNotWidth = Cursor.Position.X - Left;
                    _myForm._iNotHeigth = (Cursor.Position.Y - Top);
                }

                if (_strBackup.Contains(_myForm._sNotSize))
                {
                    if (_btoggle)
                    {
                        _btoggle = !_btoggle;


                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (_myForm.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetSize = false;
                    _strBackup = "";
                }
            }

            
        }

        /*** Detect Keyboard- input ***/
        private string _strBackup = string.Empty;
        private bool _btoggle = false;
        public void GetKeyboardInput()
        {
            var sInput = _pInfo.GetChatInput();

            if (sInput != _strBackup)
                _btoggle = true;

            _strBackup = sInput;
        }

        /*** Initialise some things like the timer ***/
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._tmrMainTick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _tmrMainTick
            // 
            this._tmrMainTick.Tick += new System.EventHandler(this.tmrMainTick_Tick);
            // 
            // BufferForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BufferForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BufferForm_MouseAction);
            this.MouseUp += new MouseEventHandler(this.BufferForm_MouseUp);
            this.MouseMove += new MouseEventHandler(this.BufferForm_Move);
            this.MouseWheel += new MouseEventHandler(this.BufferForm_MouseWheel);
            this.ResumeLayout(false);

        }

        /*** Maintimer which ticks... ***/
        private void tmrMainTick_Tick(object sender, EventArgs e)
        {
            /* Check if SC2 is in foreground */
            if (Pinvokes.GetForegroundWindow() != PStarcraft.MainWindowHandle)
            {
                if (!_bStopFlickering)
                {
                    Visible = false;
                    return;
                }
            }

            else
            {
                if (Created)
                {
                    Pinvokes.SetActiveWindow(Handle);
                    Visible = true;
                }
            }




            Invalidate();

            /* Refreshes for key- input */
            GetKeyboardInput();

            /* Catches Position */
            AdjustFormPosition();

            /* Catch Size */
            AdjustFormSize();

            /* Change window style */
            ChangeWindowStyle();

            /* Close this panel if SC2 is not loaded */
            if (!Various.StarcraftAvailable())
                Close();
        }

        /*** Will change the window- style ***/
        private void ChangeWindowStyle()
        {
            try
            {
                if (Pinvokes.GetAsyncKeyState(Keys.NumPad0) <= (-32767))
                {
                    var initial = Pinvokes.GetWindowLong(Handle, Pinvokes.GWL_EXSTYLE);
                    Pinvokes.SetWindowLong(Handle, Pinvokes.GWL_EXSTYLE,
                                           (IntPtr)(initial & ~Pinvokes.WS_EX_TRANSPARENT));
                }

                else
                {
                    var initial = Pinvokes.GetWindowLong(Handle, Pinvokes.GWL_EXSTYLE);
                    Pinvokes.SetWindowLong(Handle, Pinvokes.GWL_EXSTYLE,
                                           (IntPtr)(initial | Pinvokes.WS_EX_TRANSPARENT));
                }
            }

            catch
            { } 
        }

        private Point _pt;
        /* Activates at mousedown */
        private void BufferForm_MouseAction(object sender, MouseEventArgs e)
        {
           _pt = new Point(-e.X, -e.Y);
        }

        /* Change location */
        private void BufferForm_Move(object sender, MouseEventArgs e)
        {
            if (_bSetSize)
                return;

            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(_pt.X, _pt.Y);
                Location = mousePos;
                _bStopFlickering = true;


                /* Save to Form... */
                if (_myType.Equals(Typo.BufferformType.Ressource))
                {
                    _myForm._iResX = Location.X;
                    _myForm._iResY = Location.Y;
                }

                else if (_myType.Equals(Typo.BufferformType.Income))
                {
                    _myForm._iIncX = Location.X;
                    _myForm._iIncY = Location.Y;
                }

                else if (_myType.Equals(Typo.BufferformType.Worker))
                {
                    _myForm._iWorX = Location.X;
                    _myForm._iWorY = Location.Y;
                }

                else if (_myType.Equals(Typo.BufferformType.Apm))
                {
                    _myForm._iApmX = Location.X;
                    _myForm._iApmY = Location.Y;
                }

                else if (_myType.Equals(Typo.BufferformType.Army))
                {
                    _myForm._iArmX = Location.X;
                    _myForm._iArmY = Location.Y;
                }

                else if (_myType.Equals(Typo.BufferformType.Maphack))
                {
                    _myForm._iMapX = Location.X;
                    _myForm._iMapY = Location.Y;
                }

                else if (_myType.Equals(Typo.BufferformType.Notification))
                {
                    _myForm._iNotX = Location.X;
                    _myForm._iNotY = Location.Y;
                }

            
            }
        }

        /* Restore SC2 Window */
        private void BufferForm_MouseUp(object sender, MouseEventArgs e)
        {
            Pinvokes.SetForegroundWindow(PStarcraft.MainWindowHandle);
            _bStopFlickering = false;
        }

        /* Change size of Form using scroll */
        private void BufferForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_bSetSize)
                return;


            /* We break the scalling if we come to the point of no return..
             * There is an issue which changes the forms scale when overscalling */
            if (Width >= Screen.PrimaryScreen.Bounds.Width &&
                e.Delta.Equals(120))
                return;

            if (Height/_pInfo.Playercount() <= 1 && e.Delta.Equals(-120))
                return;
            

            #region Ressource

            if (_myType.Equals(Typo.BufferformType.Ressource))
            {
                if (e.Delta.Equals(120))
                {
                    Height += 5;
                    Width = (int) (Height*(13.75 / _pInfo.Playercount()));
                }

                else if (e.Delta.Equals(-120))
                {
                    Height -= 5;
                    Width = (int)(Height * (13.75 / _pInfo.Playercount()));
                }

                _myForm._iResHeigth = Height/_pInfo.Playercount();
                _myForm._iResWidth = Width;
            }

            #endregion

            #region Income

            else if (_myType.Equals(Typo.BufferformType.Income))
            {
                if (e.Delta.Equals(120))
                {
                    Height += 5;
                    Width = (int)(Height * (13.75 / _pInfo.Playercount()));
                }

                else if (e.Delta.Equals(-120))
                {
                    Height -= 5;
                    Width = (int)(Height * (13.75 / _pInfo.Playercount()));
                }

                _myForm._iIncWidth = Width;
                _myForm._iIncHeigth = Height/_pInfo.Playercount();
            }

            #endregion

            #region Worker

            else if (_myType.Equals(Typo.BufferformType.Worker))
            {
                if (e.Delta.Equals(120))
                {
                    Height += 10;
                    Width = (int)(Height * 3.4375);
                }

                else if (e.Delta.Equals(-120))
                {
                    Height -= 10;
                    Width = (int)(Height * 3.4375);
                }

                _myForm._iWorHeigth = Height;
                _myForm._iWorWidth = Width;
            }

            #endregion

            #region Apm

            else if (_myType.Equals(Typo.BufferformType.Apm))
            {
                if (e.Delta.Equals(120))
                {
                    Height += 5;
                    Width = (int)(Height * (13.75 / _pInfo.Playercount()));
                }

                else if (e.Delta.Equals(-120))
                {
                    Height -= 5;
                    Width = (int)(Height * (13.75 / _pInfo.Playercount()));
                }

                _myForm._iApmWidth = Width;
                _myForm._iApmHeigth = Height/_pInfo.Playercount();
            }

            #endregion

            #region Army

            else if (_myType.Equals(Typo.BufferformType.Army))
            {
                if (e.Delta.Equals(120))
                {
                    Height += 5;
                    Width = (int) (Height*(13.75/_pInfo.Playercount()));
                }

                else if (e.Delta.Equals(-120))
                {
                    Height -= 5;
                    Width = (int) (Height*(13.75/_pInfo.Playercount()));
                }

                _myForm._iArmWidth = Width;
                _myForm._iArmHeigth = Height / _pInfo.Playercount();
            }

                #endregion

            #region Maphack

            else if (_myType.Equals(Typo.BufferformType.Maphack))
            {
                if (e.Delta.Equals(120))
                {
                    Width += 1;
                    Height += 1;
                }

                else if (e.Delta.Equals(-120))
                {
                    Width -= 1;
                    Height -= 1;
                }

                _myForm._iMapHeigth = Height;
                _myForm._iMapWidth = Width;
            }

            #endregion

            #region Notification

            else if (_myType.Equals(Typo.BufferformType.Notification))
            {

                if (e.Delta.Equals(120))
                {
                    Height += 1;
                    Width = (int)(Height * 6.4285714285714285714285714285714);
                }

                else if (e.Delta.Equals(-120))
                {
                    Height -= 1;
                    Width = (int)(Height * 6.4285714285714285714285714285714);
                }


                _myForm._iNotHeigth = Height;
                _myForm._iNotWidth = Width;
            }

            #endregion
        }

        /* Help- Method to gather the supply- count based on the max- supply */
        private bool ProofSupply(int iMax, int iCurrent, out int distance)
        {
            /* There should be a bunch of types
             * 0 - 11   =>  Distance: 1
             * 12 - 19  =>  Distance: 2
             * 20 - 27  =>  Distance: 3
             * 28 - 35  =>  Distance: 4
             * 36 - 43  =>  Distance: 4
             * 44 - 51  =>  Distance: 4
             * 52 - 59  =>  Distance: 5
             * 60 - 67  =>  Distance: 5
             * 68 - 75  =>  Distance: 5
             * 76 - 83  =>  Distance: 5
             * 84 - 91  =>  Distance: 5
             * 92 - 99  =>  Distance: 5 
             * 100+     =>  Distance: 6 */
            distance = iMax - iCurrent;
            
            if (iCurrent > 0 && iCurrent < 11)
            {
                if (distance <= 1)
                    return true;
            }

            else if (iCurrent > 12 && iCurrent < 19)
            {
                if (distance <= 2)
                    return true;
            }

            else if (iCurrent > 20 && iCurrent < 27)
            {
                if (distance <= 3)
                    return true;
            }

            else if (iCurrent > 28 && iCurrent < 35)
            {
                if (distance <= 4)
                    return true;
            }

            else if (iCurrent > 36 && iCurrent < 43)
            {
                if (distance <= 4)
                    return true;
            }

            else if (iCurrent > 44 && iCurrent < 51)
            {
                if (distance <= 4)
                    return true;
            }

            else if (iCurrent > 52 && iCurrent < 59)
            {
                if (distance <= 5)
                    return true;
            }

            else if (iCurrent > 60 && iCurrent < 67)
            {
                if (distance <= 5)
                    return true;
            }

            else if (iCurrent > 68 && iCurrent < 75)
            {
                if (distance <= 5)
                    return true;
            }

            else if (iCurrent > 76 && iCurrent < 83)
            {
                if (distance <= 5)
                    return true;
            }

            else if (iCurrent > 84 && iCurrent < 91)
            {
                if (distance <= 5)
                    return true;
            }

            else if (iCurrent > 92 && iCurrent < 99)
            {
                if (distance <= 5)
                    return true;
            }

            else
            {
                if (iMax == 200)
                    return false;

                if (distance <= 6)
                    return true;
            }

            return false;



        }
    }
}
