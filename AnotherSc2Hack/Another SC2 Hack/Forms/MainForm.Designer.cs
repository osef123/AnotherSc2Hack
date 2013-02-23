namespace Another_SC2_Hack.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tmrTick = new System.Windows.Forms.Timer(this.components);
            this.msSimpleStrip = new System.Windows.Forms.MenuStrip();
            this.fsMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.fsSecondExit = new System.Windows.Forms.ToolStripMenuItem();
            this.fsMainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.fsSecondCheckforUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.gbRes = new System.Windows.Forms.GroupBox();
            this.btnDetailedOptions = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtResOpacity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbResRemAI = new System.Windows.Forms.ComboBox();
            this.cbDestinationLine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbResRemLocal = new System.Windows.Forms.ComboBox();
            this.btnColorDestinationLine = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbResRemAllie = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbResRemDead = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnResFont = new System.Windows.Forms.Button();
            this.cbResRemObs = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResRef = new System.Windows.Forms.TextBox();
            this.cbResRemReferee = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRes3 = new System.Windows.Forms.TextBox();
            this.txtRes1 = new System.Windows.Forms.TextBox();
            this.txtRes2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResSize = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtResShortcut = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtResPos = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGame = new System.Windows.Forms.TabPage();
            this.btnWorker = new System.Windows.Forms.Button();
            this.btnIncome = new System.Windows.Forms.Button();
            this.btnResource = new System.Windows.Forms.Button();
            this.gbBenchmark = new System.Windows.Forms.GroupBox();
            this.lblNotification = new System.Windows.Forms.Label();
            this.lblArmy = new System.Windows.Forms.Label();
            this.lblApm = new System.Windows.Forms.Label();
            this.lblMaphack = new System.Windows.Forms.Label();
            this.lblWorker = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.btnDebug = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblRamUsage = new System.Windows.Forms.Label();
            this.lblCpuUsage = new System.Windows.Forms.Label();
            this.lblWhatResolutions = new System.Windows.Forms.Label();
            this.btnAdjustResolution = new System.Windows.Forms.Button();
            this.lblResolution = new System.Windows.Forms.Label();
            this.lblGametype = new System.Windows.Forms.Label();
            this.lblShowFps = new System.Windows.Forms.Label();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttMaininfo = new System.Windows.Forms.ToolTip(this.components);
            this.btnMaphack = new System.Windows.Forms.Button();
            this.btnApm = new System.Windows.Forms.Button();
            this.btnArmy = new System.Windows.Forms.Button();
            this.btnNotification = new System.Windows.Forms.Button();
            this.pnlShow = new Another_SC2_Hack.Classes.BufferPanel();
            this.msSimpleStrip.SuspendLayout();
            this.gbRes.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpGame.SuspendLayout();
            this.gbBenchmark.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrTick
            // 
            this.tmrTick.Tick += new System.EventHandler(this.tmrTick_Tick);
            // 
            // msSimpleStrip
            // 
            this.msSimpleStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fsMainFile,
            this.fsMainHelp});
            this.msSimpleStrip.Location = new System.Drawing.Point(0, 0);
            this.msSimpleStrip.Name = "msSimpleStrip";
            this.msSimpleStrip.Size = new System.Drawing.Size(753, 24);
            this.msSimpleStrip.TabIndex = 0;
            this.msSimpleStrip.Text = "menuStrip1";
            // 
            // fsMainFile
            // 
            this.fsMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fsSecondExit});
            this.fsMainFile.Name = "fsMainFile";
            this.fsMainFile.Size = new System.Drawing.Size(37, 20);
            this.fsMainFile.Text = "File";
            // 
            // fsSecondExit
            // 
            this.fsSecondExit.Image = global::Another_SC2_Hack.Properties.Resources.close;
            this.fsSecondExit.Name = "fsSecondExit";
            this.fsSecondExit.Size = new System.Drawing.Size(95, 22);
            this.fsSecondExit.Text = "Exit ";
            this.fsSecondExit.Click += new System.EventHandler(this.fsSecondExit_Click);
            // 
            // fsMainHelp
            // 
            this.fsMainHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fsSecondCheckforUpdate});
            this.fsMainHelp.Name = "fsMainHelp";
            this.fsMainHelp.Size = new System.Drawing.Size(44, 20);
            this.fsMainHelp.Text = "Help";
            // 
            // fsSecondCheckforUpdate
            // 
            this.fsSecondCheckforUpdate.Image = global::Another_SC2_Hack.Properties.Resources.downldf;
            this.fsSecondCheckforUpdate.Name = "fsSecondCheckforUpdate";
            this.fsSecondCheckforUpdate.Size = new System.Drawing.Size(166, 22);
            this.fsSecondCheckforUpdate.Text = "Check for Update";
            this.fsSecondCheckforUpdate.Click += new System.EventHandler(this.fsSecondCheckforUpdate_Click);
            // 
            // gbRes
            // 
            this.gbRes.Controls.Add(this.btnDetailedOptions);
            this.gbRes.Controls.Add(this.groupBox3);
            this.gbRes.Controls.Add(this.groupBox2);
            this.gbRes.Controls.Add(this.groupBox1);
            this.gbRes.Controls.Add(this.btnSave);
            this.gbRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRes.Location = new System.Drawing.Point(20, 109);
            this.gbRes.Name = "gbRes";
            this.gbRes.Size = new System.Drawing.Size(674, 393);
            this.gbRes.TabIndex = 4;
            this.gbRes.TabStop = false;
            this.gbRes.Text = "Ressource Settings";
            // 
            // btnDetailedOptions
            // 
            this.btnDetailedOptions.Enabled = false;
            this.btnDetailedOptions.Location = new System.Drawing.Point(446, 261);
            this.btnDetailedOptions.Name = "btnDetailedOptions";
            this.btnDetailedOptions.Size = new System.Drawing.Size(208, 23);
            this.btnDetailedOptions.TabIndex = 38;
            this.btnDetailedOptions.Text = "Detailed Options";
            this.btnDetailedOptions.UseVisualStyleBackColor = true;
            this.btnDetailedOptions.Click += new System.EventHandler(this.btnDetailedOptions_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtResOpacity);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbResRemAI);
            this.groupBox3.Controls.Add(this.cbDestinationLine);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.cbResRemLocal);
            this.groupBox3.Controls.Add(this.btnColorDestinationLine);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cbResRemAllie);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbResRemDead);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnResFont);
            this.groupBox3.Controls.Add(this.cbResRemObs);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtResRef);
            this.groupBox3.Controls.Add(this.cbResRemReferee);
            this.groupBox3.Location = new System.Drawing.Point(17, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 351);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Various Panel- Options";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 325);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Set Opacity (0 to 100):";
            // 
            // txtResOpacity
            // 
            this.txtResOpacity.Location = new System.Drawing.Point(169, 321);
            this.txtResOpacity.Name = "txtResOpacity";
            this.txtResOpacity.Size = new System.Drawing.Size(156, 20);
            this.txtResOpacity.TabIndex = 31;
            this.txtResOpacity.TextChanged += new System.EventHandler(this.txtResOpacity_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Set RefreshInterval:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remove AI:";
            // 
            // cbResRemAI
            // 
            this.cbResRemAI.FormattingEnabled = true;
            this.cbResRemAI.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbResRemAI.Location = new System.Drawing.Point(169, 81);
            this.cbResRemAI.Name = "cbResRemAI";
            this.cbResRemAI.Size = new System.Drawing.Size(155, 21);
            this.cbResRemAI.TabIndex = 1;
            this.cbResRemAI.SelectedIndexChanged += new System.EventHandler(this.cbResRemAI_SelectedIndexChanged);
            // 
            // cbDestinationLine
            // 
            this.cbDestinationLine.FormattingEnabled = true;
            this.cbDestinationLine.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbDestinationLine.Location = new System.Drawing.Point(169, 292);
            this.cbDestinationLine.Name = "cbDestinationLine";
            this.cbDestinationLine.Size = new System.Drawing.Size(155, 21);
            this.cbDestinationLine.TabIndex = 29;
            this.cbDestinationLine.SelectedIndexChanged += new System.EventHandler(this.cbDestinationLine_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Remove Yourself:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 295);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Remove Dest.- Line:";
            // 
            // cbResRemLocal
            // 
            this.cbResRemLocal.FormattingEnabled = true;
            this.cbResRemLocal.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbResRemLocal.Location = new System.Drawing.Point(169, 109);
            this.cbResRemLocal.Name = "cbResRemLocal";
            this.cbResRemLocal.Size = new System.Drawing.Size(155, 21);
            this.cbResRemLocal.TabIndex = 3;
            this.cbResRemLocal.SelectedIndexChanged += new System.EventHandler(this.cbResRemLocal_SelectedIndexChanged);
            // 
            // btnColorDestinationLine
            // 
            this.btnColorDestinationLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorDestinationLine.Location = new System.Drawing.Point(169, 262);
            this.btnColorDestinationLine.Name = "btnColorDestinationLine";
            this.btnColorDestinationLine.Size = new System.Drawing.Size(156, 24);
            this.btnColorDestinationLine.TabIndex = 27;
            this.btnColorDestinationLine.Text = "button1";
            this.btnColorDestinationLine.UseVisualStyleBackColor = true;
            this.btnColorDestinationLine.Click += new System.EventHandler(this.btnColorDestinationLine_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Remove Allie:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 268);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Set Destination- Color:";
            // 
            // cbResRemAllie
            // 
            this.cbResRemAllie.FormattingEnabled = true;
            this.cbResRemAllie.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbResRemAllie.Location = new System.Drawing.Point(169, 137);
            this.cbResRemAllie.Name = "cbResRemAllie";
            this.cbResRemAllie.Size = new System.Drawing.Size(155, 21);
            this.cbResRemAllie.TabIndex = 5;
            this.cbResRemAllie.SelectedIndexChanged += new System.EventHandler(this.cbResRemAllie_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Remove Dead Player:";
            // 
            // cbResRemDead
            // 
            this.cbResRemDead.FormattingEnabled = true;
            this.cbResRemDead.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbResRemDead.Location = new System.Drawing.Point(169, 165);
            this.cbResRemDead.Name = "cbResRemDead";
            this.cbResRemDead.Size = new System.Drawing.Size(155, 21);
            this.cbResRemDead.TabIndex = 7;
            this.cbResRemDead.SelectedIndexChanged += new System.EventHandler(this.cbResRemDead_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Remove Observer:";
            // 
            // btnResFont
            // 
            this.btnResFont.Location = new System.Drawing.Point(169, 49);
            this.btnResFont.Name = "btnResFont";
            this.btnResFont.Size = new System.Drawing.Size(155, 24);
            this.btnResFont.TabIndex = 15;
            this.btnResFont.Text = "button1";
            this.btnResFont.UseVisualStyleBackColor = true;
            this.btnResFont.Click += new System.EventHandler(this.btnResFont_Click);
            // 
            // cbResRemObs
            // 
            this.cbResRemObs.FormattingEnabled = true;
            this.cbResRemObs.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbResRemObs.Location = new System.Drawing.Point(169, 194);
            this.cbResRemObs.Name = "cbResRemObs";
            this.cbResRemObs.Size = new System.Drawing.Size(155, 21);
            this.cbResRemObs.TabIndex = 9;
            this.cbResRemObs.SelectedIndexChanged += new System.EventHandler(this.cbResRemObs_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Set Font:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Remove Referee:";
            // 
            // txtResRef
            // 
            this.txtResRef.Location = new System.Drawing.Point(169, 22);
            this.txtResRef.Name = "txtResRef";
            this.txtResRef.Size = new System.Drawing.Size(156, 20);
            this.txtResRef.TabIndex = 13;
            this.txtResRef.TextChanged += new System.EventHandler(this.txtResRef_TextChanged);
            // 
            // cbResRemReferee
            // 
            this.cbResRemReferee.FormattingEnabled = true;
            this.cbResRemReferee.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbResRemReferee.Location = new System.Drawing.Point(169, 222);
            this.cbResRemReferee.Name = "cbResRemReferee";
            this.cbResRemReferee.Size = new System.Drawing.Size(155, 21);
            this.cbResRemReferee.TabIndex = 11;
            this.cbResRemReferee.SelectedIndexChanged += new System.EventHandler(this.cbResRemReferee_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtRes3);
            this.groupBox2.Controls.Add(this.txtRes1);
            this.groupBox2.Controls.Add(this.txtRes2);
            this.groupBox2.Location = new System.Drawing.Point(446, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 105);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hotkeys";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 26;
            this.label20.Text = "Hotkey 3:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Hotkey 2:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Hotkey 1:";
            // 
            // txtRes3
            // 
            this.txtRes3.Location = new System.Drawing.Point(95, 71);
            this.txtRes3.Name = "txtRes3";
            this.txtRes3.Size = new System.Drawing.Size(94, 20);
            this.txtRes3.TabIndex = 23;
            this.txtRes3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRes3_KeyDown);
            // 
            // txtRes1
            // 
            this.txtRes1.Location = new System.Drawing.Point(95, 19);
            this.txtRes1.Name = "txtRes1";
            this.txtRes1.Size = new System.Drawing.Size(94, 20);
            this.txtRes1.TabIndex = 21;
            this.txtRes1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRes1_KeyDown);
            // 
            // txtRes2
            // 
            this.txtRes2.Location = new System.Drawing.Point(95, 45);
            this.txtRes2.Name = "txtRes2";
            this.txtRes2.Size = new System.Drawing.Size(94, 20);
            this.txtRes2.TabIndex = 22;
            this.txtRes2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRes2_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResSize);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtResShortcut);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtResPos);
            this.groupBox1.Location = new System.Drawing.Point(446, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 105);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chat Input";
            // 
            // txtResSize
            // 
            this.txtResSize.Location = new System.Drawing.Point(95, 71);
            this.txtResSize.Name = "txtResSize";
            this.txtResSize.Size = new System.Drawing.Size(94, 20);
            this.txtResSize.TabIndex = 33;
            this.txtResSize.TextChanged += new System.EventHandler(this.txtResSize_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 74);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "Toggle Size:";
            // 
            // txtResShortcut
            // 
            this.txtResShortcut.Location = new System.Drawing.Point(95, 19);
            this.txtResShortcut.Name = "txtResShortcut";
            this.txtResShortcut.Size = new System.Drawing.Size(94, 20);
            this.txtResShortcut.TabIndex = 19;
            this.txtResShortcut.TextChanged += new System.EventHandler(this.txtResShortcut_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Toggle Panel:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 13);
            this.label18.TabIndex = 32;
            this.label18.Text = "Toggle Position:";
            // 
            // txtResPos
            // 
            this.txtResPos.Location = new System.Drawing.Point(95, 45);
            this.txtResPos.Name = "txtResPos";
            this.txtResPos.Size = new System.Drawing.Size(94, 20);
            this.txtResPos.TabIndex = 31;
            this.txtResPos.TextChanged += new System.EventHandler(this.txtResPos_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(446, 347);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(208, 22);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(675, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "____________________________________________________ Settings ___________________" +
    "_________________________________";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(665, 41);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 39);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(20, 41);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 39);
            this.btnPrev.TabIndex = 8;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpGame);
            this.tabControl1.Controls.Add(this.tpSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(728, 558);
            this.tabControl1.TabIndex = 9;
            // 
            // tpGame
            // 
            this.tpGame.Controls.Add(this.btnNotification);
            this.tpGame.Controls.Add(this.btnMaphack);
            this.tpGame.Controls.Add(this.gbBenchmark);
            this.tpGame.Controls.Add(this.btnApm);
            this.tpGame.Controls.Add(this.btnDebug);
            this.tpGame.Controls.Add(this.btnArmy);
            this.tpGame.Controls.Add(this.groupBox4);
            this.tpGame.Controls.Add(this.btnWorker);
            this.tpGame.Controls.Add(this.btnResource);
            this.tpGame.Controls.Add(this.btnIncome);
            this.tpGame.Location = new System.Drawing.Point(4, 22);
            this.tpGame.Name = "tpGame";
            this.tpGame.Padding = new System.Windows.Forms.Padding(3);
            this.tpGame.Size = new System.Drawing.Size(720, 532);
            this.tpGame.TabIndex = 0;
            this.tpGame.Text = "Game";
            this.tpGame.UseVisualStyleBackColor = true;
            // 
            // btnWorker
            // 
            this.btnWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWorker.ForeColor = System.Drawing.Color.Red;
            this.btnWorker.Location = new System.Drawing.Point(208, 502);
            this.btnWorker.Name = "btnWorker";
            this.btnWorker.Size = new System.Drawing.Size(95, 24);
            this.btnWorker.TabIndex = 2;
            this.btnWorker.Text = "Worker";
            this.btnWorker.UseVisualStyleBackColor = true;
            this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
            // 
            // btnIncome
            // 
            this.btnIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncome.ForeColor = System.Drawing.Color.Red;
            this.btnIncome.Location = new System.Drawing.Point(107, 502);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(95, 24);
            this.btnIncome.TabIndex = 1;
            this.btnIncome.Text = "Income";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // btnResource
            // 
            this.btnResource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResource.ForeColor = System.Drawing.Color.Red;
            this.btnResource.Location = new System.Drawing.Point(6, 502);
            this.btnResource.Name = "btnResource";
            this.btnResource.Size = new System.Drawing.Size(95, 24);
            this.btnResource.TabIndex = 0;
            this.btnResource.Text = "Resource";
            this.btnResource.UseVisualStyleBackColor = true;
            this.btnResource.Click += new System.EventHandler(this.btnResource_Click);
            // 
            // gbBenchmark
            // 
            this.gbBenchmark.Controls.Add(this.lblNotification);
            this.gbBenchmark.Controls.Add(this.lblArmy);
            this.gbBenchmark.Controls.Add(this.lblApm);
            this.gbBenchmark.Controls.Add(this.lblMaphack);
            this.gbBenchmark.Controls.Add(this.lblWorker);
            this.gbBenchmark.Controls.Add(this.lblIncome);
            this.gbBenchmark.Controls.Add(this.lblResource);
            this.gbBenchmark.Location = new System.Drawing.Point(400, 17);
            this.gbBenchmark.Name = "gbBenchmark";
            this.gbBenchmark.Size = new System.Drawing.Size(314, 209);
            this.gbBenchmark.TabIndex = 2;
            this.gbBenchmark.TabStop = false;
            this.gbBenchmark.Text = "Benchmark";
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Location = new System.Drawing.Point(6, 177);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(41, 13);
            this.lblNotification.TabIndex = 6;
            this.lblNotification.Text = "label22";
            // 
            // lblArmy
            // 
            this.lblArmy.AutoSize = true;
            this.lblArmy.Location = new System.Drawing.Point(6, 152);
            this.lblArmy.Name = "lblArmy";
            this.lblArmy.Size = new System.Drawing.Size(41, 13);
            this.lblArmy.TabIndex = 5;
            this.lblArmy.Text = "label22";
            // 
            // lblApm
            // 
            this.lblApm.AutoSize = true;
            this.lblApm.Location = new System.Drawing.Point(6, 127);
            this.lblApm.Name = "lblApm";
            this.lblApm.Size = new System.Drawing.Size(41, 13);
            this.lblApm.TabIndex = 4;
            this.lblApm.Text = "label10";
            // 
            // lblMaphack
            // 
            this.lblMaphack.AutoSize = true;
            this.lblMaphack.Location = new System.Drawing.Point(6, 102);
            this.lblMaphack.Name = "lblMaphack";
            this.lblMaphack.Size = new System.Drawing.Size(41, 13);
            this.lblMaphack.TabIndex = 3;
            this.lblMaphack.Text = "label14";
            // 
            // lblWorker
            // 
            this.lblWorker.AutoSize = true;
            this.lblWorker.Location = new System.Drawing.Point(6, 77);
            this.lblWorker.Name = "lblWorker";
            this.lblWorker.Size = new System.Drawing.Size(41, 13);
            this.lblWorker.TabIndex = 2;
            this.lblWorker.Text = "label10";
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Location = new System.Drawing.Point(6, 50);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(41, 13);
            this.lblIncome.TabIndex = 1;
            this.lblIncome.Text = "label10";
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Location = new System.Drawing.Point(6, 25);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(41, 13);
            this.lblResource.TabIndex = 0;
            this.lblResource.Text = "label10";
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(21, 232);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(114, 22);
            this.btnDebug.TabIndex = 1;
            this.btnDebug.Text = "Show Debug- Panel";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblRamUsage);
            this.groupBox4.Controls.Add(this.lblCpuUsage);
            this.groupBox4.Controls.Add(this.lblWhatResolutions);
            this.groupBox4.Controls.Add(this.btnAdjustResolution);
            this.groupBox4.Controls.Add(this.lblResolution);
            this.groupBox4.Controls.Add(this.lblGametype);
            this.groupBox4.Controls.Add(this.lblShowFps);
            this.groupBox4.Location = new System.Drawing.Point(21, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(373, 209);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gameinformation";
            // 
            // lblRamUsage
            // 
            this.lblRamUsage.AutoSize = true;
            this.lblRamUsage.Location = new System.Drawing.Point(17, 152);
            this.lblRamUsage.Name = "lblRamUsage";
            this.lblRamUsage.Size = new System.Drawing.Size(41, 13);
            this.lblRamUsage.TabIndex = 6;
            this.lblRamUsage.Text = "label10";
            // 
            // lblCpuUsage
            // 
            this.lblCpuUsage.AutoSize = true;
            this.lblCpuUsage.Location = new System.Drawing.Point(17, 114);
            this.lblCpuUsage.Name = "lblCpuUsage";
            this.lblCpuUsage.Size = new System.Drawing.Size(41, 13);
            this.lblCpuUsage.TabIndex = 5;
            this.lblCpuUsage.Text = "label10";
            // 
            // lblWhatResolutions
            // 
            this.lblWhatResolutions.AutoSize = true;
            this.lblWhatResolutions.Location = new System.Drawing.Point(348, 78);
            this.lblWhatResolutions.Name = "lblWhatResolutions";
            this.lblWhatResolutions.Size = new System.Drawing.Size(13, 13);
            this.lblWhatResolutions.TabIndex = 4;
            this.lblWhatResolutions.Text = "?";
            this.lblWhatResolutions.Click += new System.EventHandler(this.lblWhatResolutions_Click);
            // 
            // btnAdjustResolution
            // 
            this.btnAdjustResolution.Location = new System.Drawing.Point(239, 73);
            this.btnAdjustResolution.Name = "btnAdjustResolution";
            this.btnAdjustResolution.Size = new System.Drawing.Size(103, 23);
            this.btnAdjustResolution.TabIndex = 3;
            this.btnAdjustResolution.Text = "Adjust Resolution";
            this.btnAdjustResolution.UseVisualStyleBackColor = true;
            this.btnAdjustResolution.Click += new System.EventHandler(this.btnAdjustResolution_Click);
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(17, 78);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(41, 13);
            this.lblResolution.TabIndex = 2;
            this.lblResolution.Text = "label10";
            // 
            // lblGametype
            // 
            this.lblGametype.AutoSize = true;
            this.lblGametype.Location = new System.Drawing.Point(17, 50);
            this.lblGametype.Name = "lblGametype";
            this.lblGametype.Size = new System.Drawing.Size(147, 13);
            this.lblGametype.TabIndex = 1;
            this.lblGametype.Text = "STARCRAFT 2 NOT FOUND";
            // 
            // lblShowFps
            // 
            this.lblShowFps.AutoSize = true;
            this.lblShowFps.Location = new System.Drawing.Point(17, 25);
            this.lblShowFps.Name = "lblShowFps";
            this.lblShowFps.Size = new System.Drawing.Size(147, 13);
            this.lblShowFps.TabIndex = 0;
            this.lblShowFps.Text = "STARCRAFT 2 NOT FOUND";
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.label9);
            this.tpSettings.Controls.Add(this.btnPrev);
            this.tpSettings.Controls.Add(this.gbRes);
            this.tpSettings.Controls.Add(this.btnNext);
            this.tpSettings.Controls.Add(this.pnlShow);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(720, 532);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblTimer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 596);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(753, 28);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblTimer
            // 
            this.slblTimer.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slblTimer.Name = "slblTimer";
            this.slblTimer.Size = new System.Drawing.Size(235, 23);
            this.slblTimer.Text = "STARCRAFT 2 NOT FOUND";
            // 
            // ttMaininfo
            // 
            this.ttMaininfo.BackColor = System.Drawing.Color.Black;
            this.ttMaininfo.ForeColor = System.Drawing.Color.White;
            // 
            // btnMaphack
            // 
            this.btnMaphack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaphack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphack.ForeColor = System.Drawing.Color.Red;
            this.btnMaphack.Location = new System.Drawing.Point(510, 502);
            this.btnMaphack.Name = "btnMaphack";
            this.btnMaphack.Size = new System.Drawing.Size(95, 24);
            this.btnMaphack.TabIndex = 5;
            this.btnMaphack.Text = "Maphack";
            this.btnMaphack.UseVisualStyleBackColor = true;
            this.btnMaphack.Click += new System.EventHandler(this.btnMaphack_Click);
            // 
            // btnApm
            // 
            this.btnApm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApm.ForeColor = System.Drawing.Color.Red;
            this.btnApm.Location = new System.Drawing.Point(409, 502);
            this.btnApm.Name = "btnApm";
            this.btnApm.Size = new System.Drawing.Size(95, 24);
            this.btnApm.TabIndex = 4;
            this.btnApm.Text = "Apm";
            this.btnApm.UseVisualStyleBackColor = true;
            this.btnApm.Click += new System.EventHandler(this.btnApm_Click);
            // 
            // btnArmy
            // 
            this.btnArmy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArmy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArmy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArmy.ForeColor = System.Drawing.Color.Red;
            this.btnArmy.Location = new System.Drawing.Point(309, 502);
            this.btnArmy.Name = "btnArmy";
            this.btnArmy.Size = new System.Drawing.Size(95, 24);
            this.btnArmy.TabIndex = 3;
            this.btnArmy.Text = "Army";
            this.btnArmy.UseVisualStyleBackColor = true;
            this.btnArmy.Click += new System.EventHandler(this.btnArmy_Click);
            // 
            // btnNotification
            // 
            this.btnNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotification.ForeColor = System.Drawing.Color.Red;
            this.btnNotification.Location = new System.Drawing.Point(611, 502);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(100, 24);
            this.btnNotification.TabIndex = 6;
            this.btnNotification.Text = "Notification";
            this.btnNotification.UseVisualStyleBackColor = true;
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // pnlShow
            // 
            this.pnlShow.CurrentItem = 0;
            this.pnlShow.Location = new System.Drawing.Point(20, 86);
            this.pnlShow.MaxItem = 2;
            this.pnlShow.Name = "pnlShow";
            this.pnlShow.Size = new System.Drawing.Size(674, 17);
            this.pnlShow.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 624);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.msSimpleStrip);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msSimpleStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.TransparencyKey = System.Drawing.Color.DarkRed;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.msSimpleStrip.ResumeLayout(false);
            this.msSimpleStrip.PerformLayout();
            this.gbRes.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpGame.ResumeLayout(false);
            this.gbBenchmark.ResumeLayout(false);
            this.gbBenchmark.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrTick;
        private System.Windows.Forms.MenuStrip msSimpleStrip;
        private System.Windows.Forms.ToolStripMenuItem fsMainFile;
        private System.Windows.Forms.ToolStripMenuItem fsSecondExit;
        private System.Windows.Forms.ToolStripMenuItem fsMainHelp;
        private System.Windows.Forms.ToolStripMenuItem fsSecondCheckforUpdate;
        private System.Windows.Forms.GroupBox gbRes;
        private System.Windows.Forms.Button btnResFont;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtResRef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbResRemReferee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbResRemObs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbResRemDead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbResRemAllie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbResRemLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbResRemAI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRes3;
        private System.Windows.Forms.TextBox txtRes2;
        private System.Windows.Forms.TextBox txtRes1;
        private System.Windows.Forms.TextBox txtResShortcut;
        private System.Windows.Forms.Button btnSave;
        private Classes.BufferPanel pnlShow;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnColorDestinationLine;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbDestinationLine;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtResSize;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtResPos;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpGame;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtResOpacity;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slblTimer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblShowFps;
        private System.Windows.Forms.Label lblGametype;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Button btnAdjustResolution;
        private System.Windows.Forms.Label lblWhatResolutions;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Button btnDetailedOptions;
        private System.Windows.Forms.GroupBox gbBenchmark;
        public System.Windows.Forms.Label lblResource;
        public System.Windows.Forms.Label lblArmy;
        public System.Windows.Forms.Label lblApm;
        public System.Windows.Forms.Label lblMaphack;
        public System.Windows.Forms.Label lblWorker;
        public System.Windows.Forms.Label lblIncome;
        public System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.ToolTip ttMaininfo;
        private System.Windows.Forms.Label lblCpuUsage;
        private System.Windows.Forms.Label lblRamUsage;
        private System.Windows.Forms.Button btnResource;
        private System.Windows.Forms.Button btnWorker;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Button btnMaphack;
        private System.Windows.Forms.Button btnApm;
        private System.Windows.Forms.Button btnArmy;
        private System.Windows.Forms.Button btnNotification;

    }
}