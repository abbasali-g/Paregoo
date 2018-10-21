<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMap
    Inherits GlobalForm2

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMap))
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnTraffic = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rdbCity = New System.Windows.Forms.RadioButton()
        Me.rdbMokhtasat = New System.Windows.Forms.RadioButton()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.Map1 = New WFControls.VB.Map()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlTitle.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.btnHelp)
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(8, 4)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(668, 23)
        Me.pnlTitle.TabIndex = 6
        '
        'btnHelp
        '
        Me.btnHelp.BackgroundImage = Global.LawyerApp.My.Resources.Resources.HelpIcon3
        Me.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Location = New System.Drawing.Point(5, 2)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(18, 18)
        Me.btnHelp.TabIndex = 8
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(569, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(85, 13)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "مشاهده نقشه"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.SplitContainer1.Location = New System.Drawing.Point(8, 27)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnTraffic)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdbCity)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdbMokhtasat)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLat)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblStreet)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCity)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCity)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlMsg)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Map1)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(668, 622)
        Me.SplitContainer1.SplitterDistance = 86
        Me.SplitContainer1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 13)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = " از طریق سایت شهرداری تهران"
        '
        'btnTraffic
        '
        Me.btnTraffic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTraffic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTraffic.FlatAppearance.BorderSize = 0
        Me.btnTraffic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTraffic.ForeColor = System.Drawing.SystemColors.Control
        Me.btnTraffic.Image = Global.LawyerApp.My.Resources.Resources.Traffic
        Me.btnTraffic.Location = New System.Drawing.Point(83, 8)
        Me.btnTraffic.Name = "btnTraffic"
        Me.btnTraffic.Size = New System.Drawing.Size(36, 32)
        Me.btnTraffic.TabIndex = 88
        Me.btnTraffic.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 13)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "مشاهده ترافیک آن لاین شهری "
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Image = Global.LawyerApp.My.Resources.Resources.Search1
        Me.btnSearch.Location = New System.Drawing.Point(215, 47)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(20, 20)
        Me.btnSearch.TabIndex = 85
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(550, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "جستجوی محل"
        '
        'rdbCity
        '
        Me.rdbCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdbCity.AutoSize = True
        Me.rdbCity.Checked = True
        Me.rdbCity.Location = New System.Drawing.Point(567, 19)
        Me.rdbCity.Name = "rdbCity"
        Me.rdbCity.Size = New System.Drawing.Size(63, 17)
        Me.rdbCity.TabIndex = 20
        Me.rdbCity.TabStop = True
        Me.rdbCity.Text = "نام شهر"
        Me.rdbCity.UseVisualStyleBackColor = True
        '
        'rdbMokhtasat
        '
        Me.rdbMokhtasat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdbMokhtasat.AutoSize = True
        Me.rdbMokhtasat.Location = New System.Drawing.Point(517, 43)
        Me.rdbMokhtasat.Name = "rdbMokhtasat"
        Me.rdbMokhtasat.Size = New System.Drawing.Size(113, 17)
        Me.rdbMokhtasat.TabIndex = 19
        Me.rdbMokhtasat.Text = "مختصات جغرافیایی"
        Me.rdbMokhtasat.UseVisualStyleBackColor = True
        '
        'txtLat
        '
        Me.txtLat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLat.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtLat.Location = New System.Drawing.Point(241, 46)
        Me.txtLat.MaxLength = 100
        Me.txtLat.Name = "txtLat"
        Me.txtLat.Size = New System.Drawing.Size(158, 21)
        Me.txtLat.TabIndex = 15
        '
        'lblStreet
        '
        Me.lblStreet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Location = New System.Drawing.Point(403, 50)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(41, 13)
        Me.lblStreet.TabIndex = 18
        Me.lblStreet.Text = "خیابان :"
        '
        'lblCity
        '
        Me.lblCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(403, 24)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(36, 13)
        Me.lblCity.TabIndex = 17
        Me.lblCity.Text = "شهر :"
        '
        'txtCity
        '
        Me.txtCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCity.Location = New System.Drawing.Point(240, 19)
        Me.txtCity.MaxLength = 50
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(159, 21)
        Me.txtCity.TabIndex = 11
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(668, 86)
        Me.ShapeContainer1.TabIndex = 21
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(208, 12)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(435, 59)
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 506)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(668, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(7, 6)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(656, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "lblMessage"
        '
        'Map1
        '
        Me.Map1.AutoScroll = True
        Me.Map1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Map1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Map1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Map1.Location = New System.Drawing.Point(0, 0)
        Me.Map1.Name = "Map1"
        Me.Map1.Size = New System.Drawing.Size(668, 532)
        Me.Map1.TabIndex = 0
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'frmMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 670)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMap"
        Me.Text = "مشاهده نقشه"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Map1 As WFControls.VB.Map
    Private WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents rdbCity As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMokhtasat As System.Windows.Forms.RadioButton
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents txtLat As System.Windows.Forms.TextBox
    Private WithEvents lblStreet As System.Windows.Forms.Label
    Private WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnTraffic As System.Windows.Forms.Button
    Private WithEvents Label3 As System.Windows.Forms.Label
End Class
