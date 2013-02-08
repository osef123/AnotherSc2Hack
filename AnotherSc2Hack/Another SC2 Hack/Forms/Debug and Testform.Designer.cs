namespace Another_SC2_Hack.Forms
{
    partial class Debug_and_Testform
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstPlayerinfo = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstUnitInfo = new System.Windows.Forms.ListBox();
            this.lblUnitNum = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstPlayerinfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 350);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playerinfo";
            // 
            // lstPlayerinfo
            // 
            this.lstPlayerinfo.FormattingEnabled = true;
            this.lstPlayerinfo.Location = new System.Drawing.Point(17, 19);
            this.lstPlayerinfo.Name = "lstPlayerinfo";
            this.lstPlayerinfo.Size = new System.Drawing.Size(395, 303);
            this.lstPlayerinfo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBack);
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Controls.Add(this.lblUnitNum);
            this.groupBox2.Controls.Add(this.lstUnitInfo);
            this.groupBox2.Location = new System.Drawing.Point(468, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 408);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unitinfo";
            // 
            // lstUnitInfo
            // 
            this.lstUnitInfo.FormattingEnabled = true;
            this.lstUnitInfo.Location = new System.Drawing.Point(17, 19);
            this.lstUnitInfo.Name = "lstUnitInfo";
            this.lstUnitInfo.Size = new System.Drawing.Size(395, 303);
            this.lstUnitInfo.TabIndex = 0;
            // 
            // lblUnitNum
            // 
            this.lblUnitNum.AutoSize = true;
            this.lblUnitNum.Location = new System.Drawing.Point(189, 337);
            this.lblUnitNum.Name = "lblUnitNum";
            this.lblUnitNum.Size = new System.Drawing.Size(49, 13);
            this.lblUnitNum.TabIndex = 1;
            this.lblUnitNum.Text = "Unitnum:";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(244, 325);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(97, 36);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(86, 325);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(97, 36);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Debug_and_Testform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 432);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Debug_and_Testform";
            this.Text = "Debug_and_Testform";
            this.Load += new System.EventHandler(this.Debug_and_Testform_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstPlayerinfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstUnitInfo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblUnitNum;
    }
}