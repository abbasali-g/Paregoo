namespace WFControls.CS.Config
{
    partial class ServerStatus
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripManual = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.BtnRun = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "وضعیت پایگاه داده :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(303, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "وضعیت سرویس :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripAuto,
            this.ToolStripManual});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 48);
            // 
            // ToolStripAuto
            // 
            this.ToolStripAuto.Name = "ToolStripAuto";
            this.ToolStripAuto.Size = new System.Drawing.Size(162, 22);
            this.ToolStripAuto.Text = "پیکربندی پایگاه داده";
            // 
            // ToolStripManual
            // 
            this.ToolStripManual.Name = "ToolStripManual";
            this.ToolStripManual.Size = new System.Drawing.Size(162, 22);
            this.ToolStripManual.Text = "پیکربندی دستی";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "وضعیت پیکربندی :";
            // 
            // btnConfig
            // 
            this.btnConfig.ContextMenuStrip = this.contextMenuStrip1;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Location = new System.Drawing.Point(141, 2);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(28, 24);
            this.btnConfig.TabIndex = 7;
            this.btnConfig.Text = "---";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.btnRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(6, 2);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(28, 24);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "---";
            this.btnRestore.UseVisualStyleBackColor = true;
            // 
            // BtnRun
            // 
            this.BtnRun.ContextMenuStrip = this.contextMenuStrip1;
            this.BtnRun.FlatAppearance.BorderSize = 0;
            this.BtnRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.BtnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.BtnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRun.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.BtnRun.ForeColor = System.Drawing.Color.White;
            this.BtnRun.Location = new System.Drawing.Point(273, 2);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(28, 24);
            this.BtnRun.TabIndex = 5;
            this.BtnRun.Text = "---";
            this.BtnRun.UseVisualStyleBackColor = true;
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutomaticDelay = 300;
            this.ToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(92)))));
            this.ToolTip1.IsBalloon = true;
            this.ToolTip1.ShowAlways = true;
            this.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ServerStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "ServerStatus";
            this.Size = new System.Drawing.Size(398, 30);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripAuto;
        private System.Windows.Forms.ToolStripMenuItem ToolStripManual;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ToolTip ToolTip1;

    }
}
