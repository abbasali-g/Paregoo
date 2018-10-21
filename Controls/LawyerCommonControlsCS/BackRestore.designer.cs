namespace LawyerCommonControlsCS.ResoreBackup
{
    partial class BackRestore
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblFileLocation = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstBackups = new System.Windows.Forms.ListBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.prgBottom = new System.Windows.Forms.ProgressBar();
            this.prgBackupRestore = new System.Windows.Forms.ProgressBar();
            this.rdRestore = new System.Windows.Forms.RadioButton();
            this.fldrBrws = new System.Windows.Forms.FolderBrowserDialog();
            this.rdBackup = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkLaws = new System.Windows.Forms.CheckBox();
            this.btnBrows = new System.Windows.Forms.Button();
            this.grpBackRestore = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlMsg = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpBackRestore.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "User Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Port ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Database Name ";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(151, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '$';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(232, 21);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "1";
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Location = new System.Drawing.Point(6, 10);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(143, 13);
            this.lblComputerName.TabIndex = 18;
            this.lblComputerName.Text = "Computer Name/IP Address ";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(151, 55);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '$';
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserName.Size = new System.Drawing.Size(232, 21);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.Text = "root";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(151, 3);
            this.txtPort.Name = "txtPort";
            this.txtPort.PasswordChar = '$';
            this.txtPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPort.Size = new System.Drawing.Size(232, 21);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "3306";
            // 
            // lblFileLocation
            // 
            this.lblFileLocation.AutoSize = true;
            this.lblFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFileLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(118)))));
            this.lblFileLocation.Location = new System.Drawing.Point(24, 11);
            this.lblFileLocation.Name = "lblFileLocation";
            this.lblFileLocation.Size = new System.Drawing.Size(74, 13);
            this.lblFileLocation.TabIndex = 18;
            this.lblFileLocation.Text = "Backup File";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(151, 30);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDatabaseName.Size = new System.Drawing.Size(232, 21);
            this.txtDatabaseName.TabIndex = 4;
            this.txtDatabaseName.Text = "nwdicdad2";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(151, 7);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIPAddress.Size = new System.Drawing.Size(232, 21);
            this.txtIPAddress.TabIndex = 3;
            this.txtIPAddress.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(118)))));
            this.label1.Location = new System.Drawing.Point(20, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Backup Files";
            // 
            // lstBackups
            // 
            this.lstBackups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(222)))));
            this.lstBackups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBackups.FormattingEnabled = true;
            this.lstBackups.Location = new System.Drawing.Point(23, 75);
            this.lstBackups.Name = "lstBackups";
            this.lstBackups.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstBackups.Size = new System.Drawing.Size(374, 119);
            this.lstBackups.TabIndex = 9;
            this.lstBackups.DoubleClick += new System.EventHandler(this.lstBackups_DoubleClick_1);
            this.lstBackups.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstBackups_KeyPress_1);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(163)))), ((int)(((byte)(61)))));
            this.txtPath.ForeColor = System.Drawing.Color.Black;
            this.txtPath.Location = new System.Drawing.Point(23, 27);
            this.txtPath.Name = "txtPath";
            this.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPath.Size = new System.Drawing.Size(344, 21);
            this.txtPath.TabIndex = 7;
            // 
            // prgBottom
            // 
            this.prgBottom.ForeColor = System.Drawing.Color.LightCoral;
            this.prgBottom.Location = new System.Drawing.Point(9, 28);
            this.prgBottom.Name = "prgBottom";
            this.prgBottom.Size = new System.Drawing.Size(408, 13);
            this.prgBottom.TabIndex = 24;
            // 
            // prgBackupRestore
            // 
            this.prgBackupRestore.BackColor = System.Drawing.SystemColors.Control;
            this.prgBackupRestore.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.prgBackupRestore.Location = new System.Drawing.Point(9, 3);
            this.prgBackupRestore.Name = "prgBackupRestore";
            this.prgBackupRestore.Size = new System.Drawing.Size(408, 19);
            this.prgBackupRestore.TabIndex = 25;
            this.prgBackupRestore.Visible = false;
            // 
            // rdRestore
            // 
            this.rdRestore.AutoSize = true;
            this.rdRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdRestore.Location = new System.Drawing.Point(271, 8);
            this.rdRestore.Name = "rdRestore";
            this.rdRestore.Size = new System.Drawing.Size(62, 17);
            this.rdRestore.TabIndex = 21;
            this.rdRestore.TabStop = true;
            this.rdRestore.Text = "Restore";
            this.rdRestore.UseVisualStyleBackColor = true;
            this.rdRestore.CheckedChanged += new System.EventHandler(this.rdRestore_CheckedChanged_1);
            // 
            // rdBackup
            // 
            this.rdBackup.AutoSize = true;
            this.rdBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdBackup.Location = new System.Drawing.Point(349, 9);
            this.rdBackup.Name = "rdBackup";
            this.rdBackup.Size = new System.Drawing.Size(58, 17);
            this.rdBackup.TabIndex = 20;
            this.rdBackup.TabStop = true;
            this.rdBackup.Text = "Backup";
            this.rdBackup.UseVisualStyleBackColor = true;
            this.rdBackup.CheckedChanged += new System.EventHandler(this.rdBackup_CheckedChanged_1);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.rdBackup);
            this.panel1.Controls.Add(this.rdRestore);
            this.panel1.Location = new System.Drawing.Point(9, 12);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(436, 34);
            this.panel1.TabIndex = 27;
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::LawyerCommonControlsCS .Properties.Resources.stop;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(195)))), ((int)(((byte)(157)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(56, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(24, 24);
            this.btnStart.TabIndex = 27;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::LawyerCommonControlsCS .Properties.Resources.play2;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(195)))), ((int)(((byte)(157)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(26, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(24, 24);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutomaticDelay = 300;
            this.ToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(92)))));
            this.ToolTip1.IsBalloon = true;
            this.ToolTip1.ShowAlways = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkLaws);
            this.panel2.Controls.Add(this.btnBrows);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lstBackups);
            this.panel2.Controls.Add(this.lblFileLocation);
            this.panel2.Controls.Add(this.txtPath);
            this.panel2.Location = new System.Drawing.Point(3, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 207);
            this.panel2.TabIndex = 28;
            // 
            // chkLaws
            // 
            this.chkLaws.AutoSize = true;
            this.chkLaws.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(222)))));
            this.chkLaws.Location = new System.Drawing.Point(149, 3);
            this.chkLaws.Name = "chkLaws";
            this.chkLaws.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkLaws.Size = new System.Drawing.Size(154, 17);
            this.chkLaws.TabIndex = 77;
            this.chkLaws.Text = "پشتیبان گیری از بانک قوانین";
            this.chkLaws.UseVisualStyleBackColor = false;
            this.chkLaws.CheckedChanged += new System.EventHandler(this.chkLaws_CheckedChanged);
            // 
            // btnBrows
            // 
            this.btnBrows.BackgroundImage = global::LawyerCommonControlsCS .Properties.Resources.browse2;
            this.btnBrows.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrows.FlatAppearance.BorderSize = 0;
            this.btnBrows.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(195)))), ((int)(((byte)(157)))));
            this.btnBrows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrows.Location = new System.Drawing.Point(373, 24);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(24, 24);
            this.btnBrows.TabIndex = 26;
            this.btnBrows.UseVisualStyleBackColor = true;
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            // 
            // grpBackRestore
            // 
            this.grpBackRestore.AutoSize = true;
            this.grpBackRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpBackRestore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpBackRestore.Controls.Add(this.panel5);
            this.grpBackRestore.Controls.Add(this.pnlDetail);
            this.grpBackRestore.Controls.Add(this.panel2);
            this.grpBackRestore.Controls.Add(this.panel3);
            this.grpBackRestore.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.grpBackRestore.Location = new System.Drawing.Point(9, 52);
            this.grpBackRestore.Name = "grpBackRestore";
            this.grpBackRestore.Size = new System.Drawing.Size(435, 416);
            this.grpBackRestore.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblComputerName);
            this.panel5.Controls.Add(this.txtIPAddress);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(427, 32);
            this.panel5.TabIndex = 28;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.label2);
            this.pnlDetail.Controls.Add(this.txtDatabaseName);
            this.pnlDetail.Controls.Add(this.label4);
            this.pnlDetail.Controls.Add(this.txtUserName);
            this.pnlDetail.Controls.Add(this.label5);
            this.pnlDetail.Controls.Add(this.txtPassword);
            this.pnlDetail.Controls.Add(this.txtPort);
            this.pnlDetail.Controls.Add(this.label3);
            this.pnlDetail.Location = new System.Drawing.Point(1, 39);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(429, 109);
            this.pnlDetail.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.prgBottom);
            this.panel3.Controls.Add(this.prgBackupRestore);
            this.panel3.Location = new System.Drawing.Point(3, 365);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(427, 46);
            this.panel3.TabIndex = 29;
            // 
            // pnlMsg
            // 
            this.pnlMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.pnlMsg.Controls.Add(this.lblMessage);
            this.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMsg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pnlMsg.Location = new System.Drawing.Point(0, 480);
            this.pnlMsg.Name = "pnlMsg";
            this.pnlMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlMsg.Size = new System.Drawing.Size(453, 26);
            this.pnlMsg.TabIndex = 75;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Multiline = true;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.ReadOnly = true;
            this.lblMessage.Size = new System.Drawing.Size(453, 26);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "lblMessage";
            // 
            // BackRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(222)))));
            this.Controls.Add(this.pnlMsg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpBackRestore);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "BackRestore";
            this.Size = new System.Drawing.Size(453, 506);
            this.Load += new System.EventHandler(this.BackRestore_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpBackRestore.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlMsg.ResumeLayout(false);
            this.pnlMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblFileLocation;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBackups;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ProgressBar prgBottom;
        private System.Windows.Forms.ProgressBar prgBackupRestore;
        private System.Windows.Forms.RadioButton rdRestore;
        private System.Windows.Forms.FolderBrowserDialog fldrBrws;
        private System.Windows.Forms.RadioButton rdBackup;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel grpBackRestore;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Button btnBrows;
        internal System.Windows.Forms.Panel pnlMsg;
        internal System.Windows.Forms.TextBox lblMessage;
        private System.Windows.Forms.CheckBox chkLaws;
    }
}
