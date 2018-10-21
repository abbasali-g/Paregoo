<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BloodMoney
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BloodMoney))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageViewer1 = New WFControls.VB.ImageViewer()
        Me.pnlPercent = New System.Windows.Forms.Panel()
        Me.acValue = New WFControls.VB.AmountControl()
        Me.pbOk = New System.Windows.Forms.PictureBox()
        Me.pbCancel = New System.Windows.Forms.PictureBox()
        Me.txtBmNameHeader = New System.Windows.Forms.TextBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.ssGrid = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.space = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslSum = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvBm = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbbBmiYear = New System.Windows.Forms.ComboBox()
        Me.rdbMan = New System.Windows.Forms.RadioButton()
        Me.rdbWoman = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdbCamel = New System.Windows.Forms.RadioButton()
        Me.rdbSheep = New System.Windows.Forms.RadioButton()
        Me.rdbCow = New System.Windows.Forms.RadioButton()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlSide = New System.Windows.Forms.Panel()
        Me.pbDel = New System.Windows.Forms.Button()
        Me.pbEmail = New System.Windows.Forms.Button()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.pnlPercent.SuspendLayout()
        CType(Me.pbOk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssGrid.SuspendLayout()
        CType(Me.dgvBm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlSide.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(59, 41)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlPercent)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtDescription)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ssGrid)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvBm)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(702, 490)
        Me.SplitContainer1.SplitterDistance = 232
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TreeView1)
        Me.SplitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.SplitContainer2.Panel2.Controls.Add(Me.ImageViewer1)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer2.Size = New System.Drawing.Size(232, 490)
        Me.SplitContainer2.SplitterDistance = 310
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 1
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.BackColor = System.Drawing.SystemColors.Window
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.Size = New System.Drawing.Size(232, 310)
        Me.TreeView1.TabIndex = 0
        '
        'ImageViewer1
        '
        Me.ImageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageViewer1.ImageList = CType(resources.GetObject("ImageViewer1.ImageList"), System.Collections.Generic.List(Of String))
        Me.ImageViewer1.ImagePath = "\\\\\\\\\\\\\\\\\"
        Me.ImageViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ImageViewer1.Name = "ImageViewer1"
        Me.ImageViewer1.Size = New System.Drawing.Size(232, 179)
        Me.ImageViewer1.TabIndex = 1
        '
        'pnlPercent
        '
        Me.pnlPercent.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPercent.Controls.Add(Me.acValue)
        Me.pnlPercent.Controls.Add(Me.pbOk)
        Me.pnlPercent.Controls.Add(Me.pbCancel)
        Me.pnlPercent.Controls.Add(Me.txtBmNameHeader)
        Me.pnlPercent.Controls.Add(Me.lblType)
        Me.pnlPercent.Location = New System.Drawing.Point(8, 242)
        Me.pnlPercent.Name = "pnlPercent"
        Me.pnlPercent.Size = New System.Drawing.Size(450, 50)
        Me.pnlPercent.TabIndex = 12
        Me.pnlPercent.Visible = False
        '
        'acValue
        '
        Me.acValue.Amount = 0.0R
        Me.acValue.Location = New System.Drawing.Point(58, 24)
        Me.acValue.Name = "acValue"
        Me.acValue.Size = New System.Drawing.Size(100, 21)
        Me.acValue.TabIndex = 15
        '
        'pbOk
        '
        Me.pbOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbOk.Image = Global.LawyerApp.My.Resources.Resources.Tick_circle_frame
        Me.pbOk.Location = New System.Drawing.Point(26, 28)
        Me.pbOk.Name = "pbOk"
        Me.pbOk.Size = New System.Drawing.Size(16, 16)
        Me.pbOk.TabIndex = 14
        Me.pbOk.TabStop = False
        '
        'pbCancel
        '
        Me.pbCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbCancel.Image = Global.LawyerApp.My.Resources.Resources.Cancel_round
        Me.pbCancel.Location = New System.Drawing.Point(5, 28)
        Me.pbCancel.Name = "pbCancel"
        Me.pbCancel.Size = New System.Drawing.Size(16, 16)
        Me.pbCancel.TabIndex = 13
        Me.pbCancel.TabStop = False
        '
        'txtBmNameHeader
        '
        Me.txtBmNameHeader.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtBmNameHeader.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBmNameHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtBmNameHeader.Location = New System.Drawing.Point(0, 0)
        Me.txtBmNameHeader.Multiline = True
        Me.txtBmNameHeader.Name = "txtBmNameHeader"
        Me.txtBmNameHeader.ReadOnly = True
        Me.txtBmNameHeader.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtBmNameHeader.Size = New System.Drawing.Size(448, 20)
        Me.txtBmNameHeader.TabIndex = 5
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(164, 28)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(59, 13)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "مبلغ به ریال"
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescription.Location = New System.Drawing.Point(0, 322)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(466, 168)
        Me.txtDescription.TabIndex = 13
        '
        'ssGrid
        '
        Me.ssGrid.Dock = System.Windows.Forms.DockStyle.Top
        Me.ssGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.tsslCount, Me.space, Me.ToolStripStatusLabel1, Me.tsslSum, Me.ToolStripStatusLabel2})
        Me.ssGrid.Location = New System.Drawing.Point(0, 300)
        Me.ssGrid.Name = "ssGrid"
        Me.ssGrid.Size = New System.Drawing.Size(466, 22)
        Me.ssGrid.TabIndex = 11
        Me.ssGrid.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(33, 17)
        Me.ToolStripStatusLabel3.Text = "تعداد"
        '
        'tsslCount
        '
        Me.tsslCount.BackColor = System.Drawing.SystemColors.Control
        Me.tsslCount.ForeColor = System.Drawing.Color.DarkGreen
        Me.tsslCount.Name = "tsslCount"
        Me.tsslCount.Size = New System.Drawing.Size(13, 17)
        Me.tsslCount.Text = "0"
        '
        'space
        '
        Me.space.AutoSize = False
        Me.space.BackColor = System.Drawing.SystemColors.Control
        Me.space.Name = "space"
        Me.space.Size = New System.Drawing.Size(250, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(45, 17)
        Me.ToolStripStatusLabel1.Text = "جمع کل"
        '
        'tsslSum
        '
        Me.tsslSum.BackColor = System.Drawing.SystemColors.Control
        Me.tsslSum.ForeColor = System.Drawing.Color.DarkGreen
        Me.tsslSum.Name = "tsslSum"
        Me.tsslSum.Size = New System.Drawing.Size(13, 17)
        Me.tsslSum.Text = "0"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(28, 17)
        Me.ToolStripStatusLabel2.Text = "ریال"
        '
        'dgvBm
        '
        Me.dgvBm.AllowDrop = True
        Me.dgvBm.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(125, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBm.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBm.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvBm.EnableHeadersVisualStyles = False
        Me.dgvBm.Location = New System.Drawing.Point(0, 0)
        Me.dgvBm.MultiSelect = False
        Me.dgvBm.Name = "dgvBm"
        Me.dgvBm.ReadOnly = True
        Me.dgvBm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBm.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBm.RowHeadersVisible = False
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvBm.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBm.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dgvBm.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.dgvBm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBm.Size = New System.Drawing.Size(466, 300)
        Me.dgvBm.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.cbbBmiYear)
        Me.Panel1.Controls.Add(Me.rdbMan)
        Me.Panel1.Controls.Add(Me.rdbWoman)
        Me.Panel1.Location = New System.Drawing.Point(59, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(673, 28)
        Me.Panel1.TabIndex = 8
        '
        'cbbBmiYear
        '
        Me.cbbBmiYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbBmiYear.FormattingEnabled = True
        Me.cbbBmiYear.Location = New System.Drawing.Point(111, 2)
        Me.cbbBmiYear.Name = "cbbBmiYear"
        Me.cbbBmiYear.Size = New System.Drawing.Size(50, 21)
        Me.cbbBmiYear.TabIndex = 1
        '
        'rdbMan
        '
        Me.rdbMan.Checked = True
        Me.rdbMan.Image = Global.LawyerApp.My.Resources.Resources.man24_
        Me.rdbMan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbMan.Location = New System.Drawing.Point(587, -2)
        Me.rdbMan.Name = "rdbMan"
        Me.rdbMan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbMan.Size = New System.Drawing.Size(45, 30)
        Me.rdbMan.TabIndex = 18
        Me.rdbMan.TabStop = True
        Me.rdbMan.UseVisualStyleBackColor = True
        '
        'rdbWoman
        '
        Me.rdbWoman.Image = Global.LawyerApp.My.Resources.Resources.woman24_
        Me.rdbWoman.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbWoman.Location = New System.Drawing.Point(536, -2)
        Me.rdbWoman.Name = "rdbWoman"
        Me.rdbWoman.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbWoman.Size = New System.Drawing.Size(45, 30)
        Me.rdbWoman.TabIndex = 17
        Me.rdbWoman.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdbCamel)
        Me.Panel2.Controls.Add(Me.rdbSheep)
        Me.Panel2.Controls.Add(Me.rdbCow)
        Me.Panel2.Location = New System.Drawing.Point(232, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 35)
        Me.Panel2.TabIndex = 19
        '
        'rdbCamel
        '
        Me.rdbCamel.Checked = True
        Me.rdbCamel.Image = Global.LawyerApp.My.Resources.Resources.Camel24h
        Me.rdbCamel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbCamel.Location = New System.Drawing.Point(123, -2)
        Me.rdbCamel.Name = "rdbCamel"
        Me.rdbCamel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbCamel.Size = New System.Drawing.Size(55, 30)
        Me.rdbCamel.TabIndex = 18
        Me.rdbCamel.TabStop = True
        Me.rdbCamel.Tag = "0"
        Me.rdbCamel.UseVisualStyleBackColor = True
        '
        'rdbSheep
        '
        Me.rdbSheep.Image = Global.LawyerApp.My.Resources.Resources.sheep24h
        Me.rdbSheep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbSheep.Location = New System.Drawing.Point(1, -2)
        Me.rdbSheep.Name = "rdbSheep"
        Me.rdbSheep.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbSheep.Size = New System.Drawing.Size(55, 30)
        Me.rdbSheep.TabIndex = 20
        Me.rdbSheep.Tag = "2"
        Me.rdbSheep.UseVisualStyleBackColor = True
        Me.rdbSheep.Visible = False
        '
        'rdbCow
        '
        Me.rdbCow.Image = Global.LawyerApp.My.Resources.Resources.cattle24h
        Me.rdbCow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbCow.Location = New System.Drawing.Point(62, -2)
        Me.rdbCow.Name = "rdbCow"
        Me.rdbCow.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbCow.Size = New System.Drawing.Size(55, 30)
        Me.rdbCow.TabIndex = 19
        Me.rdbCow.Tag = "1"
        Me.rdbCow.UseVisualStyleBackColor = True
        Me.rdbCow.Visible = False
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Label2)
        Me.pnlTitle.Location = New System.Drawing.Point(12, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(772, 30)
        Me.pnlTitle.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(684, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "محاسبه دیه"
        '
        'pnlContent
        '
        Me.pnlContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.pnlSide)
        Me.pnlContent.Controls.Add(Me.Panel2)
        Me.pnlContent.Controls.Add(Me.Panel1)
        Me.pnlContent.Controls.Add(Me.SplitContainer1)
        Me.pnlContent.Controls.Add(Me.pnlMsg)
        Me.pnlContent.Location = New System.Drawing.Point(12, 31)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(772, 557)
        Me.pnlContent.TabIndex = 11
        '
        'pnlSide
        '
        Me.pnlSide.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.pnlSide.Controls.Add(Me.pbDel)
        Me.pnlSide.Controls.Add(Me.pbEmail)
        Me.pnlSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSide.Location = New System.Drawing.Point(0, 0)
        Me.pnlSide.Name = "pnlSide"
        Me.pnlSide.Size = New System.Drawing.Size(49, 532)
        Me.pnlSide.TabIndex = 7
        '
        'pbDel
        '
        Me.pbDel.BackgroundImage = Global.LawyerApp.My.Resources.Resources.Recycle_Full
        Me.pbDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbDel.FlatAppearance.BorderSize = 0
        Me.pbDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.pbDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pbDel.Location = New System.Drawing.Point(3, 201)
        Me.pbDel.Name = "pbDel"
        Me.pbDel.Size = New System.Drawing.Size(36, 35)
        Me.pbDel.TabIndex = 23
        Me.pbDel.UseVisualStyleBackColor = True
        '
        'pbEmail
        '
        Me.pbEmail.BackgroundImage = Global.LawyerApp.My.Resources.Resources.Email
        Me.pbEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEmail.FlatAppearance.BorderSize = 0
        Me.pbEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.pbEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pbEmail.Location = New System.Drawing.Point(6, 147)
        Me.pbEmail.Name = "pbEmail"
        Me.pbEmail.Size = New System.Drawing.Size(36, 35)
        Me.pbEmail.TabIndex = 21
        Me.pbEmail.UseVisualStyleBackColor = True
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 532)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlMsg.Size = New System.Drawing.Size(772, 25)
        Me.pnlMsg.TabIndex = 81
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(0, 3)
        Me.lblMessage.Multiline = True
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(772, 22)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 250
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(133, Byte), Integer))
        '
        'BloodMoney
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 624)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlTitle)
        Me.Name = "BloodMoney"
        Me.Text = "BloodMoney"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.pnlPercent.ResumeLayout(False)
        Me.pnlPercent.PerformLayout()
        CType(Me.pbOk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssGrid.ResumeLayout(False)
        Me.ssGrid.PerformLayout()
        CType(Me.dgvBm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlSide.ResumeLayout(False)
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents dgvBm As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbWoman As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMan As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSheep As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCow As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCamel As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtBmNameHeader As System.Windows.Forms.TextBox
    Friend WithEvents cbbBmiYear As System.Windows.Forms.ComboBox
    Friend WithEvents ssGrid As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslSum As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents space As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlPercent As System.Windows.Forms.Panel
    Friend WithEvents pbOk As System.Windows.Forms.PictureBox
    Friend WithEvents pbCancel As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlSide As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pbEmail As System.Windows.Forms.Button
    Friend WithEvents pbDel As System.Windows.Forms.Button
    Friend WithEvents ImageViewer1 As WFControls.VB.ImageViewer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents acValue As WFControls.VB.AmountControl
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
End Class
