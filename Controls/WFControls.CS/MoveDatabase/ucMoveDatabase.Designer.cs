namespace WFControls.CS.MoveDatabase
{
    partial class ucMoveDatabase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.fldBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectNewPath = new System.Windows.Forms.Button();
            this.btnTransferToNewPlace = new System.Windows.Forms.Button();
            this.txtActionLog = new System.Windows.Forms.TextBox();
            this.lblCurrentPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNewPath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "انتقال پایگاه داده به مسیر دیگر در هارد دیسک";
            // 
            // btnSelectNewPath
            // 
            this.btnSelectNewPath.Location = new System.Drawing.Point(290, 33);
            this.btnSelectNewPath.Name = "btnSelectNewPath";
            this.btnSelectNewPath.Size = new System.Drawing.Size(118, 23);
            this.btnSelectNewPath.TabIndex = 2;
            this.btnSelectNewPath.Text = "انتخاب مسیر جدید";
            this.btnSelectNewPath.UseVisualStyleBackColor = true;
            this.btnSelectNewPath.Click += new System.EventHandler(this.btnSelectNewPath_Click);
            // 
            // btnTransferToNewPlace
            // 
            this.btnTransferToNewPlace.Location = new System.Drawing.Point(290, 68);
            this.btnTransferToNewPlace.Name = "btnTransferToNewPlace";
            this.btnTransferToNewPlace.Size = new System.Drawing.Size(118, 23);
            this.btnTransferToNewPlace.TabIndex = 3;
            this.btnTransferToNewPlace.Text = "انتقال به مسیر جدید";
            this.btnTransferToNewPlace.UseVisualStyleBackColor = true;
            this.btnTransferToNewPlace.Visible = false;
            this.btnTransferToNewPlace.Click += new System.EventHandler(this.btnTransferToNewPlace_Click);
            // 
            // txtActionLog
            // 
            this.txtActionLog.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtActionLog.ForeColor = System.Drawing.Color.White;
            this.txtActionLog.Location = new System.Drawing.Point(7, 107);
            this.txtActionLog.Multiline = true;
            this.txtActionLog.Name = "txtActionLog";
            this.txtActionLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtActionLog.Size = new System.Drawing.Size(403, 100);
            this.txtActionLog.TabIndex = 4;
            // 
            // lblCurrentPath
            // 
            this.lblCurrentPath.AutoSize = true;
            this.lblCurrentPath.Location = new System.Drawing.Point(77, 43);
            this.lblCurrentPath.Name = "lblCurrentPath";
            this.lblCurrentPath.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "مسیر فعلی:";
            // 
            // lblNewPath
            // 
            this.lblNewPath.AutoSize = true;
            this.lblNewPath.Location = new System.Drawing.Point(66, 77);
            this.lblNewPath.Name = "lblNewPath";
            this.lblNewPath.Size = new System.Drawing.Size(0, 13);
            this.lblNewPath.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "مسیر جدید:";
            // 
            // ucMoveDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(222)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNewPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrentPath);
            this.Controls.Add(this.txtActionLog);
            this.Controls.Add(this.btnTransferToNewPlace);
            this.Controls.Add(this.btnSelectNewPath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "ucMoveDatabase";
            this.Size = new System.Drawing.Size(418, 222);
            this.Load += new System.EventHandler(this.ucMoveDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fldBrowser;
        private System.Windows.Forms.Button btnSelectNewPath;
        private System.Windows.Forms.Button btnTransferToNewPlace;
        private System.Windows.Forms.TextBox txtActionLog;
        private System.Windows.Forms.Label lblCurrentPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNewPath;
        private System.Windows.Forms.Label label3;
    }
}
