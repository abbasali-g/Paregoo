namespace WFControls.CS
{
    partial class PropertyMsg
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.picClose = new System.Windows.Forms.Panel();
            this.lstTargetSource = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(214)))), ((int)(((byte)(58)))));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 20);
            this.textBox1.TabIndex = 1;
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(214)))), ((int)(((byte)(58)))));
            this.picClose.BackgroundImage = global::WFControls.CS.Properties.Resources.ok16_12;
            this.picClose.Location = new System.Drawing.Point(5, 4);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(12, 12);
            this.picClose.TabIndex = 30;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // lstTargetSource
            // 
            this.lstTargetSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(183)))));
            this.lstTargetSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTargetSource.CheckBoxes = true;
            this.lstTargetSource.Location = new System.Drawing.Point(5, 26);
            this.lstTargetSource.Name = "lstTargetSource";
            this.lstTargetSource.RightToLeftLayout = true;
            this.lstTargetSource.Size = new System.Drawing.Size(217, 97);
            this.lstTargetSource.TabIndex = 10;
            this.lstTargetSource.UseCompatibleStateImageBehavior = false;
            this.lstTargetSource.View = System.Windows.Forms.View.List;
            // 
            // PropertyMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(183)))));
            this.Controls.Add(this.lstTargetSource);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.textBox1);
            this.Name = "PropertyMsg";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(225, 150);
            this.Load += new System.EventHandler(this.PropertyMsg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel picClose;
        internal System.Windows.Forms.ListView lstTargetSource;



    }
}
