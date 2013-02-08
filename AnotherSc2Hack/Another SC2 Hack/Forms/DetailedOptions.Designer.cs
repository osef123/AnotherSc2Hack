namespace Another_SC2_Hack.Forms
{
    partial class DetailedOptions
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDecline = new System.Windows.Forms.Button();
            this.gbMaphack = new System.Windows.Forms.GroupBox();
            this.btnColorDT = new System.Windows.Forms.Button();
            this.btnColorMedivac = new System.Windows.Forms.Button();
            this.btnColorDefensive = new System.Windows.Forms.Button();
            this.cbDT = new System.Windows.Forms.ComboBox();
            this.cbMedivacs = new System.Windows.Forms.ComboBox();
            this.cbDefensive = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColorNexi = new System.Windows.Forms.Button();
            this.cbQueenOcNexus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbMaphack.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(12, 290);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(94, 31);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.Location = new System.Drawing.Point(281, 290);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(94, 31);
            this.btnDecline.TabIndex = 1;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // gbMaphack
            // 
            this.gbMaphack.Controls.Add(this.btnColorNexi);
            this.gbMaphack.Controls.Add(this.cbQueenOcNexus);
            this.gbMaphack.Controls.Add(this.label4);
            this.gbMaphack.Controls.Add(this.btnColorDT);
            this.gbMaphack.Controls.Add(this.btnColorMedivac);
            this.gbMaphack.Controls.Add(this.btnColorDefensive);
            this.gbMaphack.Controls.Add(this.cbDT);
            this.gbMaphack.Controls.Add(this.cbMedivacs);
            this.gbMaphack.Controls.Add(this.cbDefensive);
            this.gbMaphack.Controls.Add(this.label3);
            this.gbMaphack.Controls.Add(this.label2);
            this.gbMaphack.Controls.Add(this.label1);
            this.gbMaphack.Location = new System.Drawing.Point(12, 12);
            this.gbMaphack.Name = "gbMaphack";
            this.gbMaphack.Size = new System.Drawing.Size(363, 261);
            this.gbMaphack.TabIndex = 2;
            this.gbMaphack.TabStop = false;
            this.gbMaphack.Text = "Maphack";
            // 
            // btnColorDT
            // 
            this.btnColorDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorDT.Location = new System.Drawing.Point(277, 70);
            this.btnColorDT.Name = "btnColorDT";
            this.btnColorDT.Size = new System.Drawing.Size(80, 23);
            this.btnColorDT.TabIndex = 8;
            this.btnColorDT.Text = "button1";
            this.btnColorDT.UseVisualStyleBackColor = true;
            this.btnColorDT.Click += new System.EventHandler(this.btnColorDT_Click);
            // 
            // btnColorMedivac
            // 
            this.btnColorMedivac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorMedivac.Location = new System.Drawing.Point(277, 47);
            this.btnColorMedivac.Name = "btnColorMedivac";
            this.btnColorMedivac.Size = new System.Drawing.Size(80, 23);
            this.btnColorMedivac.TabIndex = 7;
            this.btnColorMedivac.Text = "button1";
            this.btnColorMedivac.UseVisualStyleBackColor = true;
            this.btnColorMedivac.Click += new System.EventHandler(this.btnColorMedivac_Click);
            // 
            // btnColorDefensive
            // 
            this.btnColorDefensive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorDefensive.Location = new System.Drawing.Point(277, 24);
            this.btnColorDefensive.Name = "btnColorDefensive";
            this.btnColorDefensive.Size = new System.Drawing.Size(80, 23);
            this.btnColorDefensive.TabIndex = 6;
            this.btnColorDefensive.Text = "button1";
            this.btnColorDefensive.UseVisualStyleBackColor = true;
            this.btnColorDefensive.Click += new System.EventHandler(this.btnColorDefensive_Click);
            // 
            // cbDT
            // 
            this.cbDT.FormattingEnabled = true;
            this.cbDT.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbDT.Location = new System.Drawing.Point(190, 72);
            this.cbDT.Name = "cbDT";
            this.cbDT.Size = new System.Drawing.Size(81, 21);
            this.cbDT.TabIndex = 5;
            this.cbDT.SelectedIndexChanged += new System.EventHandler(this.cbDT_SelectedIndexChanged);
            // 
            // cbMedivacs
            // 
            this.cbMedivacs.FormattingEnabled = true;
            this.cbMedivacs.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbMedivacs.Location = new System.Drawing.Point(190, 49);
            this.cbMedivacs.Name = "cbMedivacs";
            this.cbMedivacs.Size = new System.Drawing.Size(81, 21);
            this.cbMedivacs.TabIndex = 4;
            this.cbMedivacs.SelectedIndexChanged += new System.EventHandler(this.cbMedivacs_SelectedIndexChanged);
            // 
            // cbDefensive
            // 
            this.cbDefensive.FormattingEnabled = true;
            this.cbDefensive.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbDefensive.Location = new System.Drawing.Point(190, 26);
            this.cbDefensive.Name = "cbDefensive";
            this.cbDefensive.Size = new System.Drawing.Size(81, 21);
            this.cbDefensive.TabIndex = 3;
            this.cbDefensive.SelectedIndexChanged += new System.EventHandler(this.cbDefensive_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Color Dark Templars:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Color Medivacs/ Warp Prisms:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color Defensive- Structures:";
            // 
            // btnColorNexi
            // 
            this.btnColorNexi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorNexi.Location = new System.Drawing.Point(277, 94);
            this.btnColorNexi.Name = "btnColorNexi";
            this.btnColorNexi.Size = new System.Drawing.Size(80, 23);
            this.btnColorNexi.TabIndex = 11;
            this.btnColorNexi.Text = "button1";
            this.btnColorNexi.UseVisualStyleBackColor = true;
            this.btnColorNexi.Click += new System.EventHandler(this.btnColorNexi_Click);
            // 
            // cbQueenOcNexus
            // 
            this.cbQueenOcNexus.FormattingEnabled = true;
            this.cbQueenOcNexus.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbQueenOcNexus.Location = new System.Drawing.Point(190, 96);
            this.cbQueenOcNexus.Name = "cbQueenOcNexus";
            this.cbQueenOcNexus.Size = new System.Drawing.Size(81, 21);
            this.cbQueenOcNexus.TabIndex = 10;
            this.cbQueenOcNexus.SelectedIndexChanged += new System.EventHandler(this.cbQueenOcNexus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Color Nexi, OC and Queen:";
            // 
            // DetailedOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 333);
            this.Controls.Add(this.gbMaphack);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DetailedOptions";
            this.Text = "DetailedOptions";
            this.Load += new System.EventHandler(this.DetailedOptions_Load);
            this.gbMaphack.ResumeLayout(false);
            this.gbMaphack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.GroupBox gbMaphack;
        private System.Windows.Forms.Button btnColorDT;
        private System.Windows.Forms.Button btnColorMedivac;
        private System.Windows.Forms.Button btnColorDefensive;
        private System.Windows.Forms.ComboBox cbDT;
        private System.Windows.Forms.ComboBox cbMedivacs;
        private System.Windows.Forms.ComboBox cbDefensive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColorNexi;
        private System.Windows.Forms.ComboBox cbQueenOcNexus;
        private System.Windows.Forms.Label label4;
    }
}