namespace WFControls.CS.Sms
{
    partial class ucSmsConfig
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
            this.chkSmsConfig = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkSmsConfig
            // 
            this.chkSmsConfig.AutoSize = true;
            this.chkSmsConfig.Checked = true;
            this.chkSmsConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSmsConfig.Location = new System.Drawing.Point(21, 37);
            this.chkSmsConfig.Name = "chkSmsConfig";
            this.chkSmsConfig.Size = new System.Drawing.Size(151, 17);
            this.chkSmsConfig.TabIndex = 0;
            this.chkSmsConfig.Text = "ارسال پیامک غیر فعال شود";
            this.chkSmsConfig.UseVisualStyleBackColor = true;
            this.chkSmsConfig.CheckedChanged += new System.EventHandler(this.chkSmsConfig_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "تنظیمات ارسال پیامک";
            // 
            // ucSmsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(222)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSmsConfig);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "ucSmsConfig";
            this.Size = new System.Drawing.Size(201, 68);
            this.Load += new System.EventHandler(this.ucSmsConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSmsConfig;
        private System.Windows.Forms.Label label1;
    }
}
