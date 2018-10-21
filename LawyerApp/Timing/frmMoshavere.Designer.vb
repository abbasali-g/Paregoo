<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoshavere
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMoshavere))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lnkChangeDesign = New System.Windows.Forms.LinkLabel()
        Me.pnlCollapse = New System.Windows.Forms.PictureBox()
        Me.pnlAdd = New System.Windows.Forms.Panel()
        Me.Moshavere1 = New WFControls.VB.Moshavere()
        Me.pnlSearchDetail = New System.Windows.Forms.Panel()
        Me.UcContacts1 = New WFControls.VB.ucContacts()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtVakil = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMoshavere = New System.Windows.Forms.TextBox()
        Me.txtTo = New WFControls.VB.RmanShamsiDate()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFrom = New WFControls.VB.RmanShamsiDate()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBedehkar = New WFControls.VB.AmountControl()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clmtimeDone = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmtpid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmmovakel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmtimeTitle = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.clmsender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmtimeFullDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmreciever = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmfinanceAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmtimeText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.btnBrowsDocs = New System.Windows.Forms.Button()
        Me.btnMyComputer = New System.Windows.Forms.Button()
        Me.btnContacts = New System.Windows.Forms.Button()
        Me.lblfrmTitle = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAdd.SuspendLayout()
        Me.pnlSearchDetail.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ارجاع به..."
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(13, 2)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(587, 62)
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlAdd)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSearchDetail)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSearch)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(7, 25)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(636, 346)
        Me.FlowLayoutPanel2.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lnkChangeDesign)
        Me.Panel3.Controls.Add(Me.pnlCollapse)
        Me.Panel3.Location = New System.Drawing.Point(491, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(145, 18)
        Me.Panel3.TabIndex = 26
        '
        'lnkChangeDesign
        '
        Me.lnkChangeDesign.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChangeDesign.AutoSize = True
        Me.lnkChangeDesign.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkChangeDesign.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChangeDesign.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lnkChangeDesign.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChangeDesign.Location = New System.Drawing.Point(13, 3)
        Me.lnkChangeDesign.Name = "lnkChangeDesign"
        Me.lnkChangeDesign.Size = New System.Drawing.Size(124, 13)
        Me.lnkChangeDesign.TabIndex = 4
        Me.lnkChangeDesign.TabStop = True
        Me.lnkChangeDesign.Text = "مشاوره های ثبت شده"
        Me.lnkChangeDesign.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'pnlCollapse
        '
        Me.pnlCollapse.Location = New System.Drawing.Point(562, 5)
        Me.pnlCollapse.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCollapse.Name = "pnlCollapse"
        Me.pnlCollapse.Size = New System.Drawing.Size(13, 13)
        Me.pnlCollapse.TabIndex = 3
        Me.pnlCollapse.TabStop = False
        '
        'pnlAdd
        '
        Me.pnlAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlAdd.Controls.Add(Me.Moshavere1)
        Me.pnlAdd.Location = New System.Drawing.Point(120, 18)
        Me.pnlAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAdd.Name = "pnlAdd"
        Me.pnlAdd.Size = New System.Drawing.Size(516, 100)
        Me.pnlAdd.TabIndex = 5
        '
        'Moshavere1
        '
        Me.Moshavere1.AutoSize = True
        Me.Moshavere1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Moshavere1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Moshavere1.Location = New System.Drawing.Point(0, 0)
        Me.Moshavere1.Margin = New System.Windows.Forms.Padding(0)
        Me.Moshavere1.Name = "Moshavere1"
        Me.Moshavere1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Moshavere1.Size = New System.Drawing.Size(516, 479)
        Me.Moshavere1.TabIndex = 0
        '
        'pnlSearchDetail
        '
        Me.pnlSearchDetail.Controls.Add(Me.UcContacts1)
        Me.pnlSearchDetail.Controls.Add(Me.btnSearch)
        Me.pnlSearchDetail.Controls.Add(Me.Label4)
        Me.pnlSearchDetail.Controls.Add(Me.cmbStatus)
        Me.pnlSearchDetail.Controls.Add(Me.txtVakil)
        Me.pnlSearchDetail.Controls.Add(Me.Label7)
        Me.pnlSearchDetail.Controls.Add(Me.Label15)
        Me.pnlSearchDetail.Controls.Add(Me.txtMoshavere)
        Me.pnlSearchDetail.Controls.Add(Me.txtTo)
        Me.pnlSearchDetail.Controls.Add(Me.Label3)
        Me.pnlSearchDetail.Controls.Add(Me.txtFrom)
        Me.pnlSearchDetail.Controls.Add(Me.Label2)
        Me.pnlSearchDetail.Controls.Add(Me.ShapeContainer1)
        Me.pnlSearchDetail.Location = New System.Drawing.Point(12, 118)
        Me.pnlSearchDetail.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSearchDetail.Name = "pnlSearchDetail"
        Me.pnlSearchDetail.Size = New System.Drawing.Size(624, 92)
        Me.pnlSearchDetail.TabIndex = 82
        '
        'UcContacts1
        '
        Me.UcContacts1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.UcContacts1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcContacts1.Location = New System.Drawing.Point(335, 66)
        Me.UcContacts1.Name = "UcContacts1"
        Me.UcContacts1.Size = New System.Drawing.Size(206, 23)
        Me.UcContacts1.TabIndex = 85
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Image = Global.LawyerApp.My.Resources.Resources.Search12
        Me.btnSearch.Location = New System.Drawing.Point(81, 34)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(20, 20)
        Me.btnSearch.TabIndex = 84
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(126, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "وضعیت :"
        '
        'cmbStatus
        '
        Me.cmbStatus.DisplayMember = "settingName"
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"همه موارد", "انجام شده", "انجام نشده"})
        Me.cmbStatus.Location = New System.Drawing.Point(42, 9)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(80, 21)
        Me.cmbStatus.TabIndex = 81
        Me.cmbStatus.ValueMember = "settingValue"
        '
        'txtVakil
        '
        Me.txtVakil.AllowDrop = True
        Me.txtVakil.BackColor = System.Drawing.Color.White
        Me.txtVakil.Location = New System.Drawing.Point(205, 35)
        Me.txtVakil.Name = "txtVakil"
        Me.txtVakil.ReadOnly = True
        Me.txtVakil.Size = New System.Drawing.Size(121, 21)
        Me.txtVakil.TabIndex = 68
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(330, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "مشاوره دهنده :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(544, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "موکل :"
        '
        'txtMoshavere
        '
        Me.txtMoshavere.AllowDrop = True
        Me.txtMoshavere.BackColor = System.Drawing.Color.White
        Me.txtMoshavere.Location = New System.Drawing.Point(421, 35)
        Me.txtMoshavere.Name = "txtMoshavere"
        Me.txtMoshavere.ReadOnly = True
        Me.txtMoshavere.Size = New System.Drawing.Size(120, 21)
        Me.txtMoshavere.TabIndex = 66
        '
        'txtTo
        '
        Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTo.Location = New System.Drawing.Point(205, 6)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(121, 27)
        Me.txtTo.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(328, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "تا تاریخ :"
        '
        'txtFrom
        '
        Me.txtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtFrom.Location = New System.Drawing.Point(420, 6)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(121, 27)
        Me.txtFrom.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(544, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "از تاریخ :"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(624, 92)
        Me.ShapeContainer1.TabIndex = 83
        Me.ShapeContainer1.TabStop = False
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlSearch.Controls.Add(Me.Label6)
        Me.pnlSearch.Controls.Add(Me.txtBedehkar)
        Me.pnlSearch.Controls.Add(Me.Label12)
        Me.pnlSearch.Controls.Add(Me.Label5)
        Me.pnlSearch.Controls.Add(Me.pnlMsg)
        Me.pnlSearch.Controls.Add(Me.btnRefresh)
        Me.pnlSearch.Controls.Add(Me.btnPrint)
        Me.pnlSearch.Controls.Add(Me.DataGridView1)
        Me.pnlSearch.Location = New System.Drawing.Point(0, 210)
        Me.pnlSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(636, 136)
        Me.pnlSearch.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(389, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(227, 13)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "جهت ویرایش یا حذف روی عنوان رکورد کلیک کنید"
        '
        'txtBedehkar
        '
        Me.txtBedehkar.Amount = 0.0R
        Me.txtBedehkar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBedehkar.BackColor = System.Drawing.Color.Azure
        Me.txtBedehkar.Location = New System.Drawing.Point(44, 84)
        Me.txtBedehkar.Name = "txtBedehkar"
        Me.txtBedehkar.ReadOnly = True
        Me.txtBedehkar.Size = New System.Drawing.Size(120, 21)
        Me.txtBedehkar.TabIndex = 84
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(14, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 83
        Me.Label12.Text = "ریال"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(168, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "جمع مبلغ  :"
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 110)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(636, 26)
        Me.pnlMsg.TabIndex = 81
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(3, 5)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(558, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "lblMessage"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = Global.LawyerApp.My.Resources.Resources.refresh2
        Me.btnRefresh.Location = New System.Drawing.Point(59, -2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(25, 22)
        Me.btnRefresh.TabIndex = 80
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Image = Global.LawyerApp.My.Resources.Resources.printerWeb
        Me.btnPrint.Location = New System.Drawing.Point(28, -2)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(25, 22)
        Me.btnPrint.TabIndex = 79
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(40, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmtimeDone, Me.clmtpid, Me.clmmovakel, Me.clmtimeTitle, Me.clmsender, Me.clmtimeFullDate, Me.clmreciever, Me.clmfinanceAmount, Me.clmtimeText})
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(9, 21)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.Height = 26
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(617, 57)
        Me.DataGridView1.TabIndex = 78
        '
        'clmtimeDone
        '
        Me.clmtimeDone.DataPropertyName = "timeDone"
        Me.clmtimeDone.HeaderText = ""
        Me.clmtimeDone.Name = "clmtimeDone"
        Me.clmtimeDone.ReadOnly = True
        Me.clmtimeDone.Width = 20
        '
        'clmtpid
        '
        Me.clmtpid.DataPropertyName = "tpid"
        Me.clmtpid.HeaderText = ""
        Me.clmtpid.Name = "clmtpid"
        Me.clmtpid.ReadOnly = True
        Me.clmtpid.Visible = False
        Me.clmtpid.Width = 5
        '
        'clmmovakel
        '
        Me.clmmovakel.DataPropertyName = "movakel"
        Me.clmmovakel.HeaderText = "موکل"
        Me.clmmovakel.Name = "clmmovakel"
        Me.clmmovakel.ReadOnly = True
        '
        'clmtimeTitle
        '
        Me.clmtimeTitle.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.clmtimeTitle.DataPropertyName = "timeTitle"
        Me.clmtimeTitle.HeaderText = "عنوان"
        Me.clmtimeTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.clmtimeTitle.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.clmtimeTitle.Name = "clmtimeTitle"
        Me.clmtimeTitle.ReadOnly = True
        Me.clmtimeTitle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmtimeTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clmtimeTitle.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(102, Byte), Integer))
        '
        'clmsender
        '
        Me.clmsender.DataPropertyName = "sender"
        Me.clmsender.HeaderText = "فرستنده"
        Me.clmsender.Name = "clmsender"
        Me.clmsender.ReadOnly = True
        '
        'clmtimeFullDate
        '
        Me.clmtimeFullDate.DataPropertyName = "timeFullDate"
        Me.clmtimeFullDate.HeaderText = "تاریخ"
        Me.clmtimeFullDate.Name = "clmtimeFullDate"
        Me.clmtimeFullDate.ReadOnly = True
        Me.clmtimeFullDate.Width = 120
        '
        'clmreciever
        '
        Me.clmreciever.DataPropertyName = "reciever"
        Me.clmreciever.HeaderText = "گیرنده"
        Me.clmreciever.Name = "clmreciever"
        Me.clmreciever.ReadOnly = True
        '
        'clmfinanceAmount
        '
        Me.clmfinanceAmount.DataPropertyName = "financeAmount"
        Me.clmfinanceAmount.HeaderText = "مبلغ"
        Me.clmfinanceAmount.Name = "clmfinanceAmount"
        Me.clmfinanceAmount.ReadOnly = True
        Me.clmfinanceAmount.Width = 70
        '
        'clmtimeText
        '
        Me.clmtimeText.DataPropertyName = "timeText"
        Me.clmtimeText.HeaderText = "شرح"
        Me.clmtimeText.Name = "clmtimeText"
        Me.clmtimeText.ReadOnly = True
        Me.clmtimeText.Width = 120
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(23, 31)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(0, 0)
        Me.FlowLayoutPanel1.TabIndex = 8
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.btnBrowsDocs)
        Me.pnlTitle.Controls.Add(Me.btnMyComputer)
        Me.pnlTitle.Controls.Add(Me.btnContacts)
        Me.pnlTitle.Controls.Add(Me.lblfrmTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(7, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(636, 23)
        Me.pnlTitle.TabIndex = 6
        '
        'btnBrowsDocs
        '
        Me.btnBrowsDocs.BackgroundImage = Global.LawyerApp.My.Resources.Resources.BrawsDocs
        Me.btnBrowsDocs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBrowsDocs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBrowsDocs.FlatAppearance.BorderSize = 0
        Me.btnBrowsDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowsDocs.Location = New System.Drawing.Point(61, 4)
        Me.btnBrowsDocs.Name = "btnBrowsDocs"
        Me.btnBrowsDocs.Size = New System.Drawing.Size(16, 16)
        Me.btnBrowsDocs.TabIndex = 13
        Me.btnBrowsDocs.UseVisualStyleBackColor = True
        '
        'btnMyComputer
        '
        Me.btnMyComputer.BackgroundImage = Global.LawyerApp.My.Resources.Resources.myComputer20
        Me.btnMyComputer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMyComputer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMyComputer.FlatAppearance.BorderSize = 0
        Me.btnMyComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMyComputer.Location = New System.Drawing.Point(35, 2)
        Me.btnMyComputer.Name = "btnMyComputer"
        Me.btnMyComputer.Size = New System.Drawing.Size(20, 20)
        Me.btnMyComputer.TabIndex = 12
        Me.btnMyComputer.UseVisualStyleBackColor = True
        '
        'btnContacts
        '
        Me.btnContacts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnContacts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContacts.FlatAppearance.BorderSize = 0
        Me.btnContacts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContacts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContacts.Image = Global.LawyerApp.My.Resources.Resources.contact20
        Me.btnContacts.Location = New System.Drawing.Point(9, 0)
        Me.btnContacts.Name = "btnContacts"
        Me.btnContacts.Size = New System.Drawing.Size(20, 20)
        Me.btnContacts.TabIndex = 11
        Me.btnContacts.UseVisualStyleBackColor = True
        '
        'lblfrmTitle
        '
        Me.lblfrmTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblfrmTitle.AutoSize = True
        Me.lblfrmTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrmTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblfrmTitle.Location = New System.Drawing.Point(568, 4)
        Me.lblfrmTitle.Name = "lblfrmTitle"
        Me.lblfrmTitle.Size = New System.Drawing.Size(48, 13)
        Me.lblfrmTitle.TabIndex = 1
        Me.lblfrmTitle.Text = "مشاوره"
        '
        'frmMoshavere
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 416)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMoshavere"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAdd.ResumeLayout(False)
        Me.pnlAdd.PerformLayout()
        Me.pnlSearchDetail.ResumeLayout(False)
        Me.pnlSearchDetail.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblfrmTitle As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnContacts As System.Windows.Forms.Button
    Friend WithEvents btnMyComputer As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnBrowsDocs As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lnkChangeDesign As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlCollapse As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAdd As System.Windows.Forms.Panel
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents pnlSearchDetail As System.Windows.Forms.Panel
    Friend WithEvents txtTo As WFControls.VB.RmanShamsiDate
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As WFControls.VB.RmanShamsiDate
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVakil As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMoshavere As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents UcContacts1 As WFControls.VB.ucContacts
    Friend WithEvents Moshavere1 As WFControls.VB.Moshavere
    Friend WithEvents txtBedehkar As WFControls.VB.AmountControl
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents clmtimeDone As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmtpid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmmovakel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmtimeTitle As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents clmsender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmtimeFullDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmreciever As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinanceAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmtimeText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
