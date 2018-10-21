<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdate
    Inherits GlobalForm

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdate))
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtdbVersion = New System.Windows.Forms.TextBox
        Me.rdbInternet = New System.Windows.Forms.RadioButton
        Me.rdbServer = New System.Windows.Forms.RadioButton
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.txtCVersion = New System.Windows.Forms.TextBox
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlStart = New System.Windows.Forms.Panel
        Me.btnStart = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.pnlRestart = New System.Windows.Forms.Panel
        Me.btnRestartLater = New System.Windows.Forms.Button
        Me.btnRestart = New System.Windows.Forms.Button
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.picUpdate = New System.Windows.Forms.PictureBox
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlTitle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlStart.SuspendLayout()
        Me.pnlRestart.SuspendLayout()
        CType(Me.picUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(5, 22)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(404, 23)
        Me.pnlTitle.TabIndex = 6
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(330, 5)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(68, 13)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "بروز رسانی"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtdbVersion)
        Me.Panel1.Controls.Add(Me.rdbInternet)
        Me.Panel1.Controls.Add(Me.rdbServer)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.txtCVersion)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.txtMessage)
        Me.Panel1.Controls.Add(Me.picUpdate)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(5, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(404, 306)
        Me.Panel1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(44, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(329, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "لطفا جهت بروز رسانی به سایت www.dadco.ir مراجعه فرمایید"
        '
        'txtdbVersion
        '
        Me.txtdbVersion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtdbVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtdbVersion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtdbVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.txtdbVersion.Location = New System.Drawing.Point(4, 6)
        Me.txtdbVersion.Name = "txtdbVersion"
        Me.txtdbVersion.Size = New System.Drawing.Size(185, 13)
        Me.txtdbVersion.TabIndex = 90
        Me.txtdbVersion.Text = "نسخه پایگاه داده : 1.0.0.0"
        Me.txtdbVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rdbInternet
        '
        Me.rdbInternet.AutoSize = True
        Me.rdbInternet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdbInternet.Location = New System.Drawing.Point(106, 217)
        Me.rdbInternet.Name = "rdbInternet"
        Me.rdbInternet.Size = New System.Drawing.Size(94, 17)
        Me.rdbInternet.TabIndex = 88
        Me.rdbInternet.Text = "از طریق اینترنت"
        Me.rdbInternet.UseVisualStyleBackColor = True
        Me.rdbInternet.Visible = False
        '
        'rdbServer
        '
        Me.rdbServer.AutoSize = True
        Me.rdbServer.Checked = True
        Me.rdbServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdbServer.Location = New System.Drawing.Point(225, 217)
        Me.rdbServer.Name = "rdbServer"
        Me.rdbServer.Size = New System.Drawing.Size(87, 17)
        Me.rdbServer.TabIndex = 76
        Me.rdbServer.TabStop = True
        Me.rdbServer.Text = "از طریق سرور"
        Me.rdbServer.UseVisualStyleBackColor = True
        Me.rdbServer.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(54, 191)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(296, 18)
        Me.ProgressBar1.TabIndex = 82
        '
        'txtCVersion
        '
        Me.txtCVersion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtCVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCVersion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.txtCVersion.Location = New System.Drawing.Point(199, 6)
        Me.txtCVersion.Name = "txtCVersion"
        Me.txtCVersion.Size = New System.Drawing.Size(205, 13)
        Me.txtCVersion.TabIndex = 87
        Me.txtCVersion.Text = "نسخه نرم افزار : 1.0.0.0"
        Me.txtCVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlStart)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlRestart)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(92, 252)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(220, 33)
        Me.FlowLayoutPanel1.TabIndex = 84
        '
        'pnlStart
        '
        Me.pnlStart.Controls.Add(Me.btnStart)
        Me.pnlStart.Controls.Add(Me.btnStop)
        Me.pnlStart.Location = New System.Drawing.Point(3, 1)
        Me.pnlStart.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlStart.Name = "pnlStart"
        Me.pnlStart.Size = New System.Drawing.Size(216, 30)
        Me.pnlStart.TabIndex = 0
        Me.pnlStart.Visible = False
        '
        'btnStart
        '
        Me.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStart.FlatAppearance.BorderSize = 0
        Me.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Image = Global.LawyerApp.My.Resources.Resources._stop
        Me.btnStart.Location = New System.Drawing.Point(111, 3)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(24, 24)
        Me.btnStart.TabIndex = 80
        Me.ToolTip1.SetToolTip(Me.btnStart, "بروز رسانی")
        Me.btnStart.UseVisualStyleBackColor = True
        Me.btnStart.Visible = False
        '
        'btnStop
        '
        Me.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStop.FlatAppearance.BorderSize = 0
        Me.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Image = Global.LawyerApp.My.Resources.Resources.play2
        Me.btnStop.Location = New System.Drawing.Point(81, 3)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(24, 24)
        Me.btnStop.TabIndex = 81
        Me.btnStop.UseVisualStyleBackColor = True
        Me.btnStop.Visible = False
        '
        'pnlRestart
        '
        Me.pnlRestart.Controls.Add(Me.btnRestartLater)
        Me.pnlRestart.Controls.Add(Me.btnRestart)
        Me.pnlRestart.Location = New System.Drawing.Point(-215, 1)
        Me.pnlRestart.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlRestart.Name = "pnlRestart"
        Me.pnlRestart.Size = New System.Drawing.Size(216, 34)
        Me.pnlRestart.TabIndex = 83
        '
        'btnRestartLater
        '
        Me.btnRestartLater.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestartLater.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnRestartLater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestartLater.Image = Global.LawyerApp.My.Resources.Resources.restartLater16
        Me.btnRestartLater.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRestartLater.Location = New System.Drawing.Point(6, 8)
        Me.btnRestartLater.Name = "btnRestartLater"
        Me.btnRestartLater.Size = New System.Drawing.Size(100, 23)
        Me.btnRestartLater.TabIndex = 86
        Me.btnRestartLater.Text = "Restart Later"
        Me.btnRestartLater.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRestartLater.UseVisualStyleBackColor = True
        '
        'btnRestart
        '
        Me.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestart.Image = Global.LawyerApp.My.Resources.Resources.restart16
        Me.btnRestart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRestart.Location = New System.Drawing.Point(109, 8)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(100, 23)
        Me.btnRestart.TabIndex = 85
        Me.btnRestart.Text = "Restart"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMessage.Location = New System.Drawing.Point(64, 215)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(329, 30)
        Me.txtMessage.TabIndex = 82
        Me.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'picUpdate
        '
        Me.picUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picUpdate.Image = Global.LawyerApp.My.Resources.Resources.Update300
        Me.picUpdate.Location = New System.Drawing.Point(55, 73)
        Me.picUpdate.Name = "picUpdate"
        Me.picUpdate.Size = New System.Drawing.Size(296, 137)
        Me.picUpdate.TabIndex = 77
        Me.picUpdate.TabStop = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(404, 306)
        Me.ShapeContainer1.TabIndex = 89
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(80, 217)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(244, 26)
        Me.RectangleShape2.Visible = False
        '
        'pnlMsg
        '
        Me.pnlMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(5, 350)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(404, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Multiline = True
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(404, 26)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "lblMessage"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'frmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 382)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUpdate"
        Me.Text = "بروز رسانی"
        Me.Controls.SetChildIndex(Me.pnlTitle, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.pnlMsg, 0)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlStart.ResumeLayout(False)
        Me.pnlRestart.ResumeLayout(False)
        CType(Me.picUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Private WithEvents picUpdate As System.Windows.Forms.PictureBox
    Private WithEvents pnlRestart As System.Windows.Forms.Panel
    Private WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlStart As System.Windows.Forms.Panel
    Private WithEvents btnRestartLater As System.Windows.Forms.Button
    Private WithEvents btnRestart As System.Windows.Forms.Button
    Private WithEvents txtCVersion As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents rdbInternet As System.Windows.Forms.RadioButton
    Friend WithEvents rdbServer As System.Windows.Forms.RadioButton
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Private WithEvents txtdbVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
