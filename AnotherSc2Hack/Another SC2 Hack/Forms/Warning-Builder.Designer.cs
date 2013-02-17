namespace Another_SC2_Hack.Forms
{
    partial class Warning_Builder
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.pGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 364);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(343, 364);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 1;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // pGrid
            // 
            this.pGrid.Location = new System.Drawing.Point(12, 12);
            this.pGrid.Name = "pGrid";
            this.pGrid.Size = new System.Drawing.Size(406, 334);
            this.pGrid.TabIndex = 2;
            // 
            // Warning_Builder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 399);
            this.Controls.Add(this.pGrid);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnSave);
            this.Name = "Warning_Builder";
            this.Text = "Warning_Builder";
            this.Load += new System.EventHandler(this.Warning_Builder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.PropertyGrid pGrid;
    }
}