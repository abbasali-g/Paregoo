<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewFinanceAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewFinanceAdd))
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblfrmTitle = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lnkChangeDesign = New System.Windows.Forms.LinkLabel()
        Me.pnlCollapse = New System.Windows.Forms.PictureBox()
        Me.pnlAdd = New System.Windows.Forms.Panel()
        Me.NewFinanceAdd1 = New WFControls.VB.NewFinanceAdd()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.pnlPercent = New System.Windows.Forms.Panel()
        Me.txtBedehkar = New WFControls.VB.AmountControl()
        Me.txtMande = New WFControls.VB.AmountControl()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDaryafti = New WFControls.VB.AmountControl()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBmNameHeader = New System.Windows.Forms.TextBox()
        Me.lblType = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clmfinanceAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmnAmountDar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmfinancePaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmfinanceID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmfinanceType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmdescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmfileCaseID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmfinanceChequeSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmBranchName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmfinancePaymentTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlTitle.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAdd.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.pnlPercent.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMsg.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.lblfrmTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(7, 1)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(616, 23)
        Me.pnlTitle.TabIndex = 6
        '
        'lblfrmTitle
        '
        Me.lblfrmTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblfrmTitle.AutoSize = True
        Me.lblfrmTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrmTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblfrmTitle.Location = New System.Drawing.Point(507, 6)
        Me.lblfrmTitle.Name = "lblfrmTitle"
        Me.lblfrmTitle.Size = New System.Drawing.Size(99, 13)
        Me.lblfrmTitle.TabIndex = 1
        Me.lblfrmTitle.Text = "هزینه های پرونده"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlAdd)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSearch)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(7, 24)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(616, 365)
        Me.FlowLayoutPanel1.TabIndex = 7
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
        Me.Panel3.Size = New System.Drawing.Size(125, 18)
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
        Me.lnkChangeDesign.Size = New System.Drawing.Size(97, 13)
        Me.lnkChangeDesign.TabIndex = 4
        Me.lnkChangeDesign.TabStop = True
        Me.lnkChangeDesign.Text = "اقدامات ثبت شده"
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
        Me.pnlAdd.Controls.Add(Me.NewFinanceAdd1)
        Me.pnlAdd.Location = New System.Drawing.Point(194, 18)
        Me.pnlAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAdd.Name = "pnlAdd"
        Me.pnlAdd.Size = New System.Drawing.Size(422, 100)
        Me.pnlAdd.TabIndex = 0
        '
        'NewFinanceAdd1
        '
        Me.NewFinanceAdd1.AutoSize = True
        Me.NewFinanceAdd1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.NewFinanceAdd1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.NewFinanceAdd1.Location = New System.Drawing.Point(0, 1)
        Me.NewFinanceAdd1.Name = "NewFinanceAdd1"
        Me.NewFinanceAdd1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NewFinanceAdd1.Size = New System.Drawing.Size(422, 305)
        Me.NewFinanceAdd1.TabIndex = 0
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlSearch.Controls.Add(Me.pnlPercent)
        Me.pnlSearch.Controls.Add(Me.btnExcel)
        Me.pnlSearch.Controls.Add(Me.btnRefresh)
        Me.pnlSearch.Controls.Add(Me.btnPrint)
        Me.pnlSearch.Controls.Add(Me.DataGridView1)
        Me.pnlSearch.Controls.Add(Me.pnlMsg)
        Me.pnlSearch.Location = New System.Drawing.Point(0, 118)
        Me.pnlSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(616, 247)
        Me.pnlSearch.TabIndex = 27
        '
        'pnlPercent
        '
        Me.pnlPercent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPercent.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPercent.Controls.Add(Me.txtBedehkar)
        Me.pnlPercent.Controls.Add(Me.txtMande)
        Me.pnlPercent.Controls.Add(Me.Label14)
        Me.pnlPercent.Controls.Add(Me.Label13)
        Me.pnlPercent.Controls.Add(Me.txtDaryafti)
        Me.pnlPercent.Controls.Add(Me.Label12)
        Me.pnlPercent.Controls.Add(Me.Label11)
        Me.pnlPercent.Controls.Add(Me.Label2)
        Me.pnlPercent.Controls.Add(Me.txtBmNameHeader)
        Me.pnlPercent.Controls.Add(Me.lblType)
        Me.pnlPercent.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.pnlPercent.Location = New System.Drawing.Point(0, 171)
        Me.pnlPercent.Name = "pnlPercent"
        Me.pnlPercent.Size = New System.Drawing.Size(616, 50)
        Me.pnlPercent.TabIndex = 81
        '
        'txtBedehkar
        '
        Me.txtBedehkar.Amount = 0.0R
        Me.txtBedehkar.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtBedehkar.Location = New System.Drawing.Point(372, 2)
        Me.txtBedehkar.Name = "txtBedehkar"
        Me.txtBedehkar.ReadOnly = True
        Me.txtBedehkar.Size = New System.Drawing.Size(120, 20)
        Me.txtBedehkar.TabIndex = 23
        '
        'txtMande
        '
        Me.txtMande.Amount = 0.0R
        Me.txtMande.BackColor = System.Drawing.Color.AliceBlue
        Me.txtMande.ForeColor = System.Drawing.Color.Red
        Me.txtMande.Location = New System.Drawing.Point(59, 25)
        Me.txtMande.Name = "txtMande"
        Me.txtMande.ReadOnly = True
        Me.txtMande.Size = New System.Drawing.Size(120, 20)
        Me.txtMande.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.AliceBlue
        Me.Label14.Location = New System.Drawing.Point(27, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "ریال"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.AliceBlue
        Me.Label13.Location = New System.Drawing.Point(185, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = " مانده :"
        '
        'txtDaryafti
        '
        Me.txtDaryafti.Amount = 0.0R
        Me.txtDaryafti.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDaryafti.Location = New System.Drawing.Point(372, 26)
        Me.txtDaryafti.Name = "txtDaryafti"
        Me.txtDaryafti.ReadOnly = True
        Me.txtDaryafti.Size = New System.Drawing.Size(120, 20)
        Me.txtDaryafti.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label12.Location = New System.Drawing.Point(338, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "ریال"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.AliceBlue
        Me.Label11.Location = New System.Drawing.Point(497, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "جمع مبلغ دریافتی :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label2.Location = New System.Drawing.Point(499, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "جمع مبلغ هزینه :"
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
        Me.txtBmNameHeader.Size = New System.Drawing.Size(614, 23)
        Me.txtBmNameHeader.TabIndex = 5
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(338, 29)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(24, 13)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "ریال"
        '
        'btnExcel
        '
        Me.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Image = Global.LawyerApp.My.Resources.Resources.Excel201
        Me.btnExcel.Location = New System.Drawing.Point(42, 1)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(25, 22)
        Me.btnExcel.TabIndex = 80
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = Global.LawyerApp.My.Resources.Resources.refresh2
        Me.btnRefresh.Location = New System.Drawing.Point(73, 1)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(25, 22)
        Me.btnRefresh.TabIndex = 79
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Image = Global.LawyerApp.My.Resources.Resources.printerWeb
        Me.btnPrint.Location = New System.Drawing.Point(11, 1)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(25, 22)
        Me.btnPrint.TabIndex = 78
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmfinanceAmount, Me.clmnAmountDar, Me.clmfinancePaymentDate, Me.clmfinanceID, Me.clmfinanceType, Me.clmdescription, Me.clmfileCaseID, Me.clmfinanceChequeSerial, Me.clmBranchName, Me.clmfinancePaymentTime})
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(0, 28)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(613, 137)
        Me.DataGridView1.TabIndex = 22
        '
        'clmfinanceAmount
        '
        Me.clmfinanceAmount.DataPropertyName = "AmountHazine"
        Me.clmfinanceAmount.HeaderText = "مبلغ هزینه"
        Me.clmfinanceAmount.Name = "clmfinanceAmount"
        Me.clmfinanceAmount.ReadOnly = True
        '
        'clmnAmountDar
        '
        Me.clmnAmountDar.DataPropertyName = "AmountDaryafti"
        Me.clmnAmountDar.HeaderText = "مبلغ دریافتی"
        Me.clmnAmountDar.Name = "clmnAmountDar"
        Me.clmnAmountDar.ReadOnly = True
        '
        'clmfinancePaymentDate
        '
        Me.clmfinancePaymentDate.DataPropertyName = "financePaymentDate"
        Me.clmfinancePaymentDate.HeaderText = "تاریخ "
        Me.clmfinancePaymentDate.Name = "clmfinancePaymentDate"
        Me.clmfinancePaymentDate.ReadOnly = True
        '
        'clmfinanceID
        '
        Me.clmfinanceID.DataPropertyName = "financeID"
        Me.clmfinanceID.HeaderText = ""
        Me.clmfinanceID.Name = "clmfinanceID"
        Me.clmfinanceID.ReadOnly = True
        Me.clmfinanceID.Visible = False
        '
        'clmfinanceType
        '
        Me.clmfinanceType.DataPropertyName = "financeType"
        Me.clmfinanceType.HeaderText = "نوع هزینه"
        Me.clmfinanceType.Name = "clmfinanceType"
        Me.clmfinanceType.ReadOnly = True
        '
        'clmdescription
        '
        Me.clmdescription.DataPropertyName = "financeDesc"
        Me.clmdescription.HeaderText = "شرح"
        Me.clmdescription.Name = "clmdescription"
        Me.clmdescription.ReadOnly = True
        '
        'clmfileCaseID
        '
        Me.clmfileCaseID.DataPropertyName = "fileCaseID"
        Me.clmfileCaseID.HeaderText = ""
        Me.clmfileCaseID.Name = "clmfileCaseID"
        Me.clmfileCaseID.ReadOnly = True
        Me.clmfileCaseID.Visible = False
        '
        'clmfinanceChequeSerial
        '
        Me.clmfinanceChequeSerial.DataPropertyName = "financeChequeSerial"
        Me.clmfinanceChequeSerial.HeaderText = "شماره چک"
        Me.clmfinanceChequeSerial.Name = "clmfinanceChequeSerial"
        Me.clmfinanceChequeSerial.ReadOnly = True
        '
        'clmBranchName
        '
        Me.clmBranchName.DataPropertyName = "Shobe"
        Me.clmBranchName.HeaderText = "نام شعبه"
        Me.clmBranchName.Name = "clmBranchName"
        Me.clmBranchName.ReadOnly = True
        '
        'clmfinancePaymentTime
        '
        Me.clmfinancePaymentTime.DataPropertyName = "financePaymentTime"
        Me.clmfinancePaymentTime.HeaderText = "زمان"
        Me.clmfinancePaymentTime.Name = "clmfinancePaymentTime"
        Me.clmfinancePaymentTime.ReadOnly = True
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 221)
        Me.pnlMsg.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(616, 26)
        Me.pnlMsg.TabIndex = 76
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(37, 5)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(513, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "lblMessage"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemEdit, Me.ToolStripMenuItemDel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(111, 48)
        '
        'ToolStripMenuItemEdit
        '
        Me.ToolStripMenuItemEdit.Image = Global.LawyerApp.My.Resources.Resources.EditCat
        Me.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit"
        Me.ToolStripMenuItemEdit.Size = New System.Drawing.Size(110, 22)
        Me.ToolStripMenuItemEdit.Text = "ویرایش"
        '
        'ToolStripMenuItemDel
        '
        Me.ToolStripMenuItemDel.Image = Global.LawyerApp.My.Resources.Resources.DeleteCat
        Me.ToolStripMenuItemDel.Name = "ToolStripMenuItemDel"
        Me.ToolStripMenuItemDel.Size = New System.Drawing.Size(110, 22)
        Me.ToolStripMenuItemDel.Text = "حذف"
        '
        'frmNewFinanceAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 398)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmNewFinanceAdd"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAdd.ResumeLayout(False)
        Me.pnlAdd.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlPercent.ResumeLayout(False)
        Me.pnlPercent.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblfrmTitle As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlAdd As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lnkChangeDesign As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlCollapse As System.Windows.Forms.PictureBox
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents NewFinanceAdd1 As WFControls.VB.NewFinanceAdd
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents clmfinanceAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnAmountDar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinancePaymentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinanceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinanceType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmdescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfileCaseID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinanceChequeSerial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmBranchName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinancePaymentTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pnlPercent As System.Windows.Forms.Panel
    Friend WithEvents txtBedehkar As WFControls.VB.AmountControl
    Friend WithEvents txtMande As WFControls.VB.AmountControl
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDaryafti As WFControls.VB.AmountControl
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBmNameHeader As System.Windows.Forms.TextBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDel As System.Windows.Forms.ToolStripMenuItem

End Class
