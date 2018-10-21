namespace WFControls.CS.ResoreBackup
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
            this.lblComputerName = new System.Windows.Forms.Label();
            this.lblFileLocation = new System.Windows.Forms.Label();
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlIP = new System.Windows.Forms.Panel();
            this.rdbServer = new System.Windows.Forms.RadioButton();
            this.rdbLocal = new System.Windows.Forms.RadioButton();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlMsg = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpBackRestore.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlIP.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlMsg.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Location = new System.Drawing.Point(259, 9);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblComputerName.Size = new System.Drawing.Size(108, 13);
            this.lblComputerName.TabIndex = 18;
            this.lblComputerName.Text = "سرور ( IP Address) : ";
            // 
            // lblFileLocation
            // 
            this.lblFileLocation.AutoSize = true;
            this.lblFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFileLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(118)))));
            this.lblFileLocation.Location = new System.Drawing.Point(239, 39);
            this.lblFileLocation.Name = "lblFileLocation";
            this.lblFileLocation.Size = new System.Drawing.Size(164, 13);
            this.lblFileLocation.TabIndex = 18;
            this.lblFileLocation.Text = "مسیر پشتیبانگیری / بازیابی";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(9, 6);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIPAddress.Size = new System.Drawing.Size(249, 21);
            this.txtIPAddress.TabIndex = 3;
            this.txtIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(78)))), ((int)(((byte)(118)))));
            this.label1.Location = new System.Drawing.Point(278, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "لیست فایل های پشتیبان";
            // 
            // lstBackups
            // 
            this.lstBackups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(222)))));
            this.lstBackups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBackups.FormattingEnabled = true;
            this.lstBackups.Location = new System.Drawing.Point(23, 110);
            this.lstBackups.Name = "lstBackups";
            this.lstBackups.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstBackups.Size = new System.Drawing.Size(394, 119);
            this.lstBackups.TabIndex = 9;
            this.lstBackups.DoubleClick += new System.EventHandler(this.lstBackups_DoubleClick_1);
            this.lstBackups.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstBackups_KeyPress_1);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(163)))), ((int)(((byte)(61)))));
            this.txtPath.ForeColor = System.Drawing.Color.Black;
            this.txtPath.Location = new System.Drawing.Point(53, 55);
            this.txtPath.Name = "txtPath";
            this.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPath.Size = new System.Drawing.Size(364, 21);
            this.txtPath.TabIndex = 7;
            // 
            // prgBottom
            // 
            this.prgBottom.ForeColor = System.Drawing.Color.LightCoral;
            this.prgBottom.Location = new System.Drawing.Point(9, 40);
            this.prgBottom.Name = "prgBottom";
            this.prgBottom.Size = new System.Drawing.Size(408, 13);
            this.prgBottom.TabIndex = 24;
            // 
            // prgBackupRestore
            // 
            this.prgBackupRestore.BackColor = System.Drawing.SystemColors.Control;
            this.prgBackupRestore.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.prgBackupRestore.Location = new System.Drawing.Point(9, 12);
            this.prgBackupRestore.Name = "prgBackupRestore";
            this.prgBackupRestore.Size = new System.Drawing.Size(408, 19);
            this.prgBackupRestore.TabIndex = 25;
            this.prgBackupRestore.Visible = false;
            // 
            // rdRestore
            // 
            this.rdRestore.AutoSize = true;
            this.rdRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdRestore.Location = new System.Drawing.Point(202, 8);
            this.rdRestore.Name = "rdRestore";
            this.rdRestore.Size = new System.Drawing.Size(92, 17);
            this.rdRestore.TabIndex = 21;
            this.rdRestore.TabStop = true;
            this.rdRestore.Text = "در حالت بازیابی";
            this.rdRestore.UseVisualStyleBackColor = true;
            this.rdRestore.CheckedChanged += new System.EventHandler(this.rdRestore_CheckedChanged_1);
            // 
            // rdBackup
            // 
            this.rdBackup.AutoSize = true;
            this.rdBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdBackup.Location = new System.Drawing.Point(300, 8);
            this.rdBackup.Name = "rdBackup";
            this.rdBackup.Size = new System.Drawing.Size(120, 17);
            this.rdBackup.TabIndex = 20;
            this.rdBackup.TabStop = true;
            this.rdBackup.Text = "در حالت پشتیبانگیری";
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
            this.btnStart.BackgroundImage = global::WFControls.CS.Properties.Resources.stop;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(195)))), ((int)(((byte)(157)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(56, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(27, 24);
            this.btnStart.TabIndex = 27;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ToolTip1.SetToolTip(this.btnStart, "START");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::WFControls.CS.Properties.Resources.play2;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(195)))), ((int)(((byte)(157)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(26, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(24, 24);
            this.btnCancel.TabIndex = 26;
            this.ToolTip1.SetToolTip(this.btnCancel, "STOP");
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
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.chkLaws);
            this.panel2.Controls.Add(this.btnBrows);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lstBackups);
            this.panel2.Controls.Add(this.lblFileLocation);
            this.panel2.Controls.Add(this.txtPath);
            this.panel2.Location = new System.Drawing.Point(3, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 242);
            this.panel2.TabIndex = 28;
            // 
            // chkLaws
            // 
            this.chkLaws.AutoSize = true;
            this.chkLaws.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(222)))));
            this.chkLaws.Location = new System.Drawing.Point(249, 9);
            this.chkLaws.Name = "chkLaws";
            this.chkLaws.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLaws.Size = new System.Drawing.Size(154, 17);
            this.chkLaws.TabIndex = 77;
            this.chkLaws.Text = "پشتیبان گیری از بانک قوانین";
            this.chkLaws.UseVisualStyleBackColor = false;
            this.chkLaws.CheckedChanged += new System.EventHandler(this.chkLaws_CheckedChanged);
            // 
            // btnBrows
            // 
            this.btnBrows.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBrows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrows.FlatAppearance.BorderSize = 0;
            this.btnBrows.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(195)))), ((int)(((byte)(157)))));
            this.btnBrows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrows.Image = global::WFControls.CS.Properties.Resources.browse2;
            this.btnBrows.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnBrows.Location = new System.Drawing.Point(23, 45);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(30, 40);
            this.btnBrows.TabIndex = 26;
            this.btnBrows.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBrows.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBrows.UseVisualStyleBackColor = true;
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            // 
            // grpBackRestore
            // 
            this.grpBackRestore.AutoSize = true;
            this.grpBackRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpBackRestore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpBackRestore.Controls.Add(this.panel4);
            this.grpBackRestore.Controls.Add(this.pnlDetail);
            this.grpBackRestore.Controls.Add(this.panel2);
            this.grpBackRestore.Controls.Add(this.panel3);
            this.grpBackRestore.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.grpBackRestore.Location = new System.Drawing.Point(9, 52);
            this.grpBackRestore.Name = "grpBackRestore";
            this.grpBackRestore.Size = new System.Drawing.Size(435, 417);
            this.grpBackRestore.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pnlIP);
            this.panel4.Controls.Add(this.rdbServer);
            this.panel4.Controls.Add(this.rdbLocal);
            this.panel4.Controls.Add(this.shapeContainer1);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(427, 81);
            this.panel4.TabIndex = 29;
            // 
            // pnlIP
            // 
            this.pnlIP.Controls.Add(this.txtIPAddress);
            this.pnlIP.Controls.Add(this.lblComputerName);
            this.pnlIP.Location = new System.Drawing.Point(24, 45);
            this.pnlIP.Name = "pnlIP";
            this.pnlIP.Size = new System.Drawing.Size(393, 33);
            this.pnlIP.TabIndex = 78;
            this.pnlIP.Visible = false;
            // 
            // rdbServer
            // 
            this.rdbServer.AutoSize = true;
            this.rdbServer.Location = new System.Drawing.Point(108, 17);
            this.rdbServer.Name = "rdbServer";
            this.rdbServer.Size = new System.Drawing.Size(88, 17);
            this.rdbServer.TabIndex = 77;
            this.rdbServer.Text = "کامپیوتر سرور";
            this.rdbServer.UseVisualStyleBackColor = true;
            this.rdbServer.CheckedChanged += new System.EventHandler(this.rdbLocal_CheckedChanged);
            // 
            // rdbLocal
            // 
            this.rdbLocal.AutoSize = true;
            this.rdbLocal.Checked = true;
            this.rdbLocal.Location = new System.Drawing.Point(249, 17);
            this.rdbLocal.Name = "rdbLocal";
            this.rdbLocal.Size = new System.Drawing.Size(77, 17);
            this.rdbLocal.TabIndex = 76;
            this.rdbLocal.TabStop = true;
            this.rdbLocal.Text = "این کامپیوتر";
            this.rdbLocal.UseVisualStyleBackColor = true;
            this.rdbLocal.CheckedChanged += new System.EventHandler(this.rdbLocal_CheckedChanged);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(427, 81);
            this.shapeContainer1.TabIndex = 79;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(69)))), ((int)(((byte)(54)))));
            this.rectangleShape1.CornerRadius = 5;
            this.rectangleShape1.Location = new System.Drawing.Point(26, 10);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(389, 30);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.prgBottom);
            this.panel3.Controls.Add(this.prgBackupRestore);
            this.panel3.Location = new System.Drawing.Point(3, 350);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(427, 62);
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
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(30, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "(جهت بازیابی روی یکی از فایلهای زیر دابل کلیک کنید)";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Port ";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Password";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Database Name ";
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
            this.pnlDetail.Location = new System.Drawing.Point(1, 88);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(1);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(429, 10);
            this.pnlDetail.TabIndex = 20;
            this.pnlDetail.Visible = false;
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
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlIP.ResumeLayout(false);
            this.pnlIP.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.pnlMsg.ResumeLayout(false);
            this.pnlMsg.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.Label lblFileLocation;
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
        internal System.Windows.Forms.Button btnBrows;
        internal System.Windows.Forms.Panel pnlMsg;
        internal System.Windows.Forms.TextBox lblMessage;
        private System.Windows.Forms.CheckBox chkLaws;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.RadioButton rdbServer;
        internal System.Windows.Forms.RadioButton rdbLocal;
        private System.Windows.Forms.Panel pnlIP;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
    }
}
