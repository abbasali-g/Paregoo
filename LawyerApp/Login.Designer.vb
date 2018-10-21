<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripAutoConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripInstallData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemLaws = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripRunService = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripManualConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolstripDatabaseMove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.picTalk = New System.Windows.Forms.PictureBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSetting = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picColEx = New System.Windows.Forms.PictureBox()
        Me.picMinimize = New System.Windows.Forms.PictureBox()
        Me.picClose = New System.Windows.Forms.PictureBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlSetting = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.ServerStatus1 = New WFControls.CS.Config.ServerStatus()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnConfig = New System.Windows.Forms.PictureBox()
        Me.btnConnectToDB = New System.Windows.Forms.PictureBox()
        Me.pnlLogin = New System.Windows.Forms.Panel()
        Me.btncurStatus = New System.Windows.Forms.PictureBox()
        Me.lblIP = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        'Me.UcShamsiDate1 = New Dtec.ucShamsiDate()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.picTalk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        CType(Me.picColEx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlSetting.SuspendLayout()
        CType(Me.btnConfig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnConnectToDB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLogin.SuspendLayout()
        CType(Me.btncurStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAutoConfig, Me.ToolStripInstallData, Me.ToolStripMenuItemLaws, Me.ToolStripRunService, Me.ToolStripManualConfig, Me.toolstripDatabaseMove})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(222, 136)
        '
        'ToolStripAutoConfig
        '
        Me.ToolStripAutoConfig.Image = Global.LawyerApp.My.Resources.Resources.AutoConfig3
        Me.ToolStripAutoConfig.Name = "ToolStripAutoConfig"
        Me.ToolStripAutoConfig.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripAutoConfig.Text = "پیکربندی اتوماتیک"
        '
        'ToolStripInstallData
        '
        Me.ToolStripInstallData.Image = Global.LawyerApp.My.Resources.Resources.installData
        Me.ToolStripInstallData.Name = "ToolStripInstallData"
        Me.ToolStripInstallData.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripInstallData.Text = "نصب اولیه پایگاه داده "
        '
        'ToolStripMenuItemLaws
        '
        Me.ToolStripMenuItemLaws.Image = Global.LawyerApp.My.Resources.Resources.LawSet
        Me.ToolStripMenuItemLaws.Name = "ToolStripMenuItemLaws"
        Me.ToolStripMenuItemLaws.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItemLaws.Text = "نصب قوانین"
        '
        'ToolStripRunService
        '
        Me.ToolStripRunService.Image = Global.LawyerApp.My.Resources.Resources.Run2
        Me.ToolStripRunService.Name = "ToolStripRunService"
        Me.ToolStripRunService.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripRunService.Text = "راه اندازی سرویس"
        '
        'ToolStripManualConfig
        '
        Me.ToolStripManualConfig.Image = Global.LawyerApp.My.Resources.Resources.ManualConfig2
        Me.ToolStripManualConfig.Name = "ToolStripManualConfig"
        Me.ToolStripManualConfig.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripManualConfig.Text = "پیکربندی دستی"
        Me.ToolStripManualConfig.Visible = False
        '
        'toolstripDatabaseMove
        '
        Me.toolstripDatabaseMove.Image = Global.LawyerApp.My.Resources.Resources.BrawsDocs
        Me.toolstripDatabaseMove.Name = "toolstripDatabaseMove"
        Me.toolstripDatabaseMove.Size = New System.Drawing.Size(221, 22)
        Me.toolstripDatabaseMove.Text = "انتقال پایگاه داده به مسیر دیگر"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'picTalk
        '
        Me.picTalk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picTalk.BackColor = System.Drawing.Color.Transparent
        Me.picTalk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picTalk.Image = Global.LawyerApp.My.Resources.Resources.talk
        Me.picTalk.Location = New System.Drawing.Point(3, 48)
        Me.picTalk.Name = "picTalk"
        Me.picTalk.Size = New System.Drawing.Size(34, 28)
        Me.picTalk.TabIndex = 52
        Me.picTalk.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picTalk, "پشتیبانی")
        '
        'pnlHeader
        '
        Me.pnlHeader.BackgroundImage = Global.LawyerApp.My.Resources.Resources.gbanner3
        Me.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHeader.Controls.Add(Me.lblSetting)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.picColEx)
        Me.pnlHeader.Controls.Add(Me.picMinimize)
        Me.pnlHeader.Controls.Add(Me.picClose)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(401, 24)
        Me.pnlHeader.TabIndex = 10
        '
        'lblSetting
        '
        Me.lblSetting.AutoSize = True
        Me.lblSetting.BackColor = System.Drawing.Color.Transparent
        Me.lblSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSetting.ForeColor = System.Drawing.Color.White
        Me.lblSetting.Location = New System.Drawing.Point(22, 7)
        Me.lblSetting.Name = "lblSetting"
        Me.lblSetting.Size = New System.Drawing.Size(45, 13)
        Me.lblSetting.TabIndex = 48
        Me.lblSetting.Text = "تنظیمات"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(184, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "نرم افزار حقوقی پر قـــو  (نسخه کاربر )"
        '
        'picColEx
        '
        Me.picColEx.BackColor = System.Drawing.Color.Transparent
        Me.picColEx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picColEx.Image = Global.LawyerApp.My.Resources.Resources.colapse16_12
        Me.picColEx.Location = New System.Drawing.Point(4, 8)
        Me.picColEx.Name = "picColEx"
        Me.picColEx.Size = New System.Drawing.Size(12, 12)
        Me.picColEx.TabIndex = 46
        Me.picColEx.TabStop = False
        '
        'picMinimize
        '
        Me.picMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picMinimize.BackColor = System.Drawing.Color.Transparent
        Me.picMinimize.BackgroundImage = Global.LawyerApp.My.Resources.Resources.minus2
        Me.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picMinimize.Location = New System.Drawing.Point(351, 4)
        Me.picMinimize.Name = "picMinimize"
        Me.picMinimize.Size = New System.Drawing.Size(16, 16)
        Me.picMinimize.TabIndex = 45
        Me.picMinimize.TabStop = False
        '
        'picClose
        '
        Me.picClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picClose.BackColor = System.Drawing.Color.Transparent
        Me.picClose.BackgroundImage = Global.LawyerApp.My.Resources.Resources.exit16
        Me.picClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picClose.Location = New System.Drawing.Point(373, 4)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(16, 16)
        Me.picClose.TabIndex = 44
        Me.picClose.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Black
        Me.FlowLayoutPanel1.BackgroundImage = Global.LawyerApp.My.Resources.Resources.background2
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSetting)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlLogin)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(1, 23)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(400, 285)
        Me.FlowLayoutPanel1.TabIndex = 11
        '
        'pnlSetting
        '
        Me.pnlSetting.BackColor = System.Drawing.Color.Transparent
        Me.pnlSetting.Controls.Add(Me.Label4)
        Me.pnlSetting.Controls.Add(Me.lblVersion)
        Me.pnlSetting.Controls.Add(Me.ServerStatus1)
        Me.pnlSetting.Controls.Add(Me.btnRefresh)
        Me.pnlSetting.Controls.Add(Me.btnConfig)
        Me.pnlSetting.Controls.Add(Me.btnConnectToDB)
        Me.pnlSetting.Location = New System.Drawing.Point(0, 0)
        Me.pnlSetting.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSetting.Name = "pnlSetting"
        Me.pnlSetting.Size = New System.Drawing.Size(398, 144)
        Me.pnlSetting.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(289, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "وضعیت کامپیوتر جاری"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblVersion.Location = New System.Drawing.Point(5, 3)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVersion.Size = New System.Drawing.Size(77, 13)
        Me.lblVersion.TabIndex = 13
        Me.lblVersion.Text = "نسخه 4.0.0.0 "
        '
        'ServerStatus1
        '
        Me.ServerStatus1.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ServerStatus1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ServerStatus1.Location = New System.Drawing.Point(1, 112)
        Me.ServerStatus1.Name = "ServerStatus1"
        Me.ServerStatus1.Size = New System.Drawing.Size(398, 30)
        Me.ServerStatus1.TabIndex = 37
        '
        'btnRefresh
        '
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = Global.LawyerApp.My.Resources.Resources.refresh2
        Me.btnRefresh.Location = New System.Drawing.Point(1, 95)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(16, 16)
        Me.btnRefresh.TabIndex = 36
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnConfig
        '
        Me.btnConfig.BackColor = System.Drawing.Color.Transparent
        Me.btnConfig.ContextMenuStrip = Me.ContextMenuStrip1
        Me.btnConfig.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfig.Image = Global.LawyerApp.My.Resources.Resources.Setting
        Me.btnConfig.Location = New System.Drawing.Point(272, 22)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(68, 72)
        Me.btnConfig.TabIndex = 34
        Me.btnConfig.TabStop = False
        '
        'btnConnectToDB
        '
        Me.btnConnectToDB.BackColor = System.Drawing.Color.Transparent
        Me.btnConnectToDB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConnectToDB.Image = Global.LawyerApp.My.Resources.Resources.Connect
        Me.btnConnectToDB.Location = New System.Drawing.Point(165, 21)
        Me.btnConnectToDB.Name = "btnConnectToDB"
        Me.btnConnectToDB.Size = New System.Drawing.Size(68, 72)
        Me.btnConnectToDB.TabIndex = 33
        Me.btnConnectToDB.TabStop = False
        '
        'pnlLogin
        '
        Me.pnlLogin.BackColor = System.Drawing.Color.Transparent
        Me.pnlLogin.Controls.Add(Me.picTalk)
        Me.pnlLogin.Controls.Add(Me.btncurStatus)
        Me.pnlLogin.Controls.Add(Me.lblIP)
        Me.pnlLogin.Controls.Add(Me.btnLogin)
        Me.pnlLogin.Controls.Add(Me.Panel2)
        Me.pnlLogin.Controls.Add(Me.txtUserName)
        Me.pnlLogin.Controls.Add(Me.Label2)
        Me.pnlLogin.Controls.Add(Me.Label1)
        Me.pnlLogin.Controls.Add(Me.txtPassword)
        Me.pnlLogin.Location = New System.Drawing.Point(0, 144)
        Me.pnlLogin.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(398, 139)
        Me.pnlLogin.TabIndex = 0
        '
        'btncurStatus
        '
        Me.btncurStatus.BackColor = System.Drawing.Color.Transparent
        Me.btncurStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncurStatus.Image = Global.LawyerApp.My.Resources.Resources.noInstalData24
        Me.btncurStatus.Location = New System.Drawing.Point(2, 3)
        Me.btncurStatus.Name = "btncurStatus"
        Me.btncurStatus.Size = New System.Drawing.Size(24, 24)
        Me.btncurStatus.TabIndex = 34
        Me.btncurStatus.TabStop = False
        '
        'lblIP
        '
        Me.lblIP.AutoSize = True
        Me.lblIP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblIP.Location = New System.Drawing.Point(30, 9)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblIP.Size = New System.Drawing.Size(55, 13)
        Me.lblIP.TabIndex = 12
        Me.lblIP.Text = "127.0.0.1"
        '
        'btnLogin
        '
        Me.btnLogin.BackgroundImage = Global.LawyerApp.My.Resources.Resources.LoginButton2
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Location = New System.Drawing.Point(72, 46)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(43, 33)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblMessage)
        ' Me.Panel2.Controls.Add(Me.UcShamsiDate1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 109)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(398, 30)
        Me.Panel2.TabIndex = 5
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(3, 9)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(381, 13)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.TabStop = False
        Me.lblMessage.Text = "lblMessage"
        '
        'UcShamsiDate1
        '
        'Me.UcShamsiDate1.Location = New System.Drawing.Point(72, -129)
        'Me.UcShamsiDate1.Name = "UcShamsiDate1"
        'Me.UcShamsiDate1.showToday = False
        'Me.UcShamsiDate1.Size = New System.Drawing.Size(150, 150)
        'Me.UcShamsiDate1.TabIndex = 2
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.Location = New System.Drawing.Point(137, 26)
        Me.txtUserName.MaxLength = 20
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(136, 20)
        Me.txtUserName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(275, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "رمز عبور :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(275, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "نام کاربری :"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Location = New System.Drawing.Point(137, 56)
        Me.txtPassword.MaxLength = 20
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(136, 20)
        Me.txtPassword.TabIndex = 2
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(133, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(401, 309)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ورود به سیستم"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.picTalk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.picColEx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlSetting.ResumeLayout(False)
        Me.pnlSetting.PerformLayout()
        CType(Me.btnConfig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnConnectToDB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        CType(Me.btncurStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents picMinimize As System.Windows.Forms.PictureBox
    Friend WithEvents picClose As System.Windows.Forms.PictureBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlLogin As System.Windows.Forms.Panel
    Friend WithEvents pnlSetting As System.Windows.Forms.Panel
    Friend WithEvents picColEx As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnConnectToDB As System.Windows.Forms.PictureBox
    Friend WithEvents btnConfig As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripRunService As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripInstallData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripAutoConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripManualConfig As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents ServerStatus1 As WFControls.CS.Config.ServerStatus
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents lblIP As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents btncurStatus As System.Windows.Forms.PictureBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItemLaws As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSetting As System.Windows.Forms.Label
    Friend WithEvents picTalk As System.Windows.Forms.PictureBox
    Friend WithEvents toolstripDatabaseMove As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents UcShamsiDate1 As Dtec.ucShamsiDate
End Class
