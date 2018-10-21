<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OfficeFinanceAdd
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnlAdd = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPaymentDate = New WFControls.VB.RmanShamsiDate
        Me.txtAmount = New WFControls.VB.AmountControl
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbFinanceType = New System.Windows.Forms.ComboBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemDel = New System.Windows.Forms.ToolStripMenuItem
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlSearch = New System.Windows.Forms.Panel
        Me.txtDaryafti = New WFControls.VB.AmountControl
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblType = New System.Windows.Forms.Label
        Me.txtBmNameHeader = New System.Windows.Forms.TextBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.clmfinanceID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmfinanceType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmfinancePaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmnAmountDar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmdes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtTo = New WFControls.VB.RmanShamsiDate
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFrom = New WFControls.VB.RmanShamsiDate
        Me.cmbFinanceSearch = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lnkChangeDesign = New System.Windows.Forms.LinkLabel
        Me.pnlCollapse = New System.Windows.Forms.PictureBox
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemEditFinance = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemDelFinance = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlAdd.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAdd
        '
        Me.pnlAdd.Controls.Add(Me.btnCancel)
        Me.pnlAdd.Controls.Add(Me.btnSave)
        Me.pnlAdd.Controls.Add(Me.txtDescription)
        Me.pnlAdd.Controls.Add(Me.Label1)
        Me.pnlAdd.Controls.Add(Me.txtPaymentDate)
        Me.pnlAdd.Controls.Add(Me.txtAmount)
        Me.pnlAdd.Controls.Add(Me.Label10)
        Me.pnlAdd.Controls.Add(Me.cmbFinanceType)
        Me.pnlAdd.Controls.Add(Me.Label9)
        Me.pnlAdd.Controls.Add(Me.Label8)
        Me.pnlAdd.Location = New System.Drawing.Point(6, 283)
        Me.pnlAdd.Name = "pnlAdd"
        Me.pnlAdd.Size = New System.Drawing.Size(520, 232)
        Me.pnlAdd.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(156, 189)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 29)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "انصراف"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(262, 189)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 29)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "ذخیره"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(34, 91)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(445, 73)
        Me.txtDescription.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(398, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "سایر توضیحات"
        '
        'txtPaymentDate
        '
        Me.txtPaymentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtPaymentDate.Location = New System.Drawing.Point(299, 35)
        Me.txtPaymentDate.Name = "txtPaymentDate"
        Me.txtPaymentDate.Size = New System.Drawing.Size(121, 27)
        Me.txtPaymentDate.TabIndex = 12
        '
        'txtAmount
        '
        Me.txtAmount.Amount = 0
        Me.txtAmount.Location = New System.Drawing.Point(36, 11)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(121, 22)
        Me.txtAmount.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(163, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 14)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "مبلغ :"
        '
        'cmbFinanceType
        '
        Me.cmbFinanceType.ContextMenuStrip = Me.ContextMenuStrip1
        Me.cmbFinanceType.DisplayMember = "settingName"
        Me.cmbFinanceType.FormattingEnabled = True
        Me.cmbFinanceType.Location = New System.Drawing.Point(299, 11)
        Me.cmbFinanceType.MaxLength = 150
        Me.cmbFinanceType.Name = "cmbFinanceType"
        Me.cmbFinanceType.Size = New System.Drawing.Size(121, 22)
        Me.cmbFinanceType.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.cmbFinanceType, "آیتم های این لیست قابل حذف/اضافه است")
        Me.cmbFinanceType.ValueMember = "settingValue"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemDel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(96, 26)
        '
        'ToolStripMenuItemDel
        '
        Me.ToolStripMenuItemDel.Image = Global.WFControls.VB.My.Resources.Resources.DeleteCat
        Me.ToolStripMenuItemDel.Name = "ToolStripMenuItemDel"
        Me.ToolStripMenuItemDel.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripMenuItemDel.Text = "حذف"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(424, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 14)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "نوع هزینه :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(424, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "تاریخ :"
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 536)
        Me.pnlMsg.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(529, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(8, 5)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(509, 13)
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
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSearch)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlAdd)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMsg)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 1)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(529, 562)
        Me.FlowLayoutPanel1.TabIndex = 76
        '
        'pnlSearch
        '
        Me.pnlSearch.Controls.Add(Me.txtDaryafti)
        Me.pnlSearch.Controls.Add(Me.Label11)
        Me.pnlSearch.Controls.Add(Me.lblType)
        Me.pnlSearch.Controls.Add(Me.txtBmNameHeader)
        Me.pnlSearch.Controls.Add(Me.btnPrint)
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Controls.Add(Me.DataGridView1)
        Me.pnlSearch.Controls.Add(Me.txtTo)
        Me.pnlSearch.Controls.Add(Me.Label4)
        Me.pnlSearch.Controls.Add(Me.txtFrom)
        Me.pnlSearch.Controls.Add(Me.cmbFinanceSearch)
        Me.pnlSearch.Controls.Add(Me.Label2)
        Me.pnlSearch.Controls.Add(Me.Label3)
        Me.pnlSearch.Location = New System.Drawing.Point(6, 3)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(520, 274)
        Me.pnlSearch.TabIndex = 0
        '
        'txtDaryafti
        '
        Me.txtDaryafti.Amount = 0
        Me.txtDaryafti.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDaryafti.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDaryafti.ForeColor = System.Drawing.Color.Red
        Me.txtDaryafti.Location = New System.Drawing.Point(48, 198)
        Me.txtDaryafti.Name = "txtDaryafti"
        Me.txtDaryafti.ReadOnly = True
        Me.txtDaryafti.Size = New System.Drawing.Size(119, 22)
        Me.txtDaryafti.TabIndex = 81
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.AliceBlue
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label11.Location = New System.Drawing.Point(173, 202)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "جمع :"
        '
        'lblType
        '
        Me.lblType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblType.AutoSize = True
        Me.lblType.BackColor = System.Drawing.Color.AliceBlue
        Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblType.Location = New System.Drawing.Point(21, 203)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(24, 13)
        Me.lblType.TabIndex = 79
        Me.lblType.Text = "ریال"
        '
        'txtBmNameHeader
        '
        Me.txtBmNameHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBmNameHeader.BackColor = System.Drawing.Color.AliceBlue
        Me.txtBmNameHeader.Location = New System.Drawing.Point(11, 197)
        Me.txtBmNameHeader.Multiline = True
        Me.txtBmNameHeader.Name = "txtBmNameHeader"
        Me.txtBmNameHeader.ReadOnly = True
        Me.txtBmNameHeader.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtBmNameHeader.Size = New System.Drawing.Size(499, 24)
        Me.txtBmNameHeader.TabIndex = 78
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Image = Global.WFControls.VB.My.Resources.Resources.printerWeb
        Me.btnPrint.Location = New System.Drawing.Point(9, 55)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(24, 22)
        Me.btnPrint.TabIndex = 77
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(210, 235)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(101, 30)
        Me.btnSearch.TabIndex = 28
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmfinanceID, Me.clmfinanceType, Me.clmfinancePaymentDate, Me.clmnAmountDar, Me.clmdes})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(11, 83)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
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
        Me.DataGridView1.Size = New System.Drawing.Size(499, 114)
        Me.DataGridView1.TabIndex = 27
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
        Me.clmfinanceType.DataPropertyName = "financeTypeName"
        Me.clmfinanceType.HeaderText = "نوع هزینه"
        Me.clmfinanceType.Name = "clmfinanceType"
        Me.clmfinanceType.ReadOnly = True
        Me.clmfinanceType.Width = 120
        '
        'clmfinancePaymentDate
        '
        Me.clmfinancePaymentDate.DataPropertyName = "financePaymentDate"
        Me.clmfinancePaymentDate.HeaderText = "تاریخ "
        Me.clmfinancePaymentDate.Name = "clmfinancePaymentDate"
        Me.clmfinancePaymentDate.ReadOnly = True
        '
        'clmnAmountDar
        '
        Me.clmnAmountDar.DataPropertyName = "financeAmount"
        Me.clmnAmountDar.HeaderText = "مبلغ"
        Me.clmnAmountDar.Name = "clmnAmountDar"
        Me.clmnAmountDar.ReadOnly = True
        '
        'clmdes
        '
        Me.clmdes.DataPropertyName = "financeDesc"
        Me.clmdes.HeaderText = "شرح"
        Me.clmdes.Name = "clmdes"
        Me.clmdes.ReadOnly = True
        Me.clmdes.Width = 130
        '
        'txtTo
        '
        Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTo.Location = New System.Drawing.Point(42, 31)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(121, 27)
        Me.txtTo.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(166, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 14)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "تا تاریخ :"
        '
        'txtFrom
        '
        Me.txtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtFrom.Location = New System.Drawing.Point(305, 31)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(121, 27)
        Me.txtFrom.TabIndex = 22
        '
        'cmbFinanceSearch
        '
        Me.cmbFinanceSearch.DisplayMember = "settingName"
        Me.cmbFinanceSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFinanceSearch.FormattingEnabled = True
        Me.cmbFinanceSearch.Location = New System.Drawing.Point(306, 6)
        Me.cmbFinanceSearch.MaxLength = 150
        Me.cmbFinanceSearch.Name = "cmbFinanceSearch"
        Me.cmbFinanceSearch.Size = New System.Drawing.Size(119, 22)
        Me.cmbFinanceSearch.TabIndex = 21
        Me.cmbFinanceSearch.ValueMember = "settingValue"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(429, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 14)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "نوع هزینه :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(429, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 14)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "از تاریخ :"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lnkChangeDesign)
        Me.Panel3.Controls.Add(Me.pnlCollapse)
        Me.Panel3.Location = New System.Drawing.Point(404, 518)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(125, 18)
        Me.Panel3.TabIndex = 24
        '
        'lnkChangeDesign
        '
        Me.lnkChangeDesign.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChangeDesign.AutoSize = True
        Me.lnkChangeDesign.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkChangeDesign.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChangeDesign.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lnkChangeDesign.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChangeDesign.Location = New System.Drawing.Point(26, 2)
        Me.lnkChangeDesign.Name = "lnkChangeDesign"
        Me.lnkChangeDesign.Size = New System.Drawing.Size(90, 13)
        Me.lnkChangeDesign.TabIndex = 4
        Me.lnkChangeDesign.TabStop = True
        Me.lnkChangeDesign.Text = "جستجوی هزینه"
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
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemEditFinance, Me.ToolStripMenuItemDelFinance})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(106, 48)
        '
        'ToolStripMenuItemEditFinance
        '
        Me.ToolStripMenuItemEditFinance.Image = Global.WFControls.VB.My.Resources.Resources.EditCat
        Me.ToolStripMenuItemEditFinance.Name = "ToolStripMenuItemEditFinance"
        Me.ToolStripMenuItemEditFinance.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripMenuItemEditFinance.Text = "ویرایش"
        '
        'ToolStripMenuItemDelFinance
        '
        Me.ToolStripMenuItemDelFinance.Image = Global.WFControls.VB.My.Resources.Resources.DeleteCat
        Me.ToolStripMenuItemDelFinance.Name = "ToolStripMenuItemDelFinance"
        Me.ToolStripMenuItemDelFinance.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripMenuItemDelFinance.Text = "حذف"
        '
        'OfficeFinanceAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Name = "OfficeFinanceAdd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(529, 565)
        Me.pnlAdd.ResumeLayout(False)
        Me.pnlAdd.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbFinanceType As System.Windows.Forms.ComboBox
    Friend WithEvents pnlAdd As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtAmount As WFControls.VB.AmountControl
    Friend WithEvents txtPaymentDate As WFControls.VB.RmanShamsiDate
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents txtTo As WFControls.VB.RmanShamsiDate
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As WFControls.VB.RmanShamsiDate
    Friend WithEvents cmbFinanceSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemEditFinance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDelFinance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlCollapse As System.Windows.Forms.PictureBox
    Friend WithEvents lnkChangeDesign As System.Windows.Forms.LinkLabel
    Friend WithEvents txtBmNameHeader As System.Windows.Forms.TextBox
    Friend WithEvents txtDaryafti As WFControls.VB.AmountControl
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents clmfinanceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinanceType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinancePaymentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnAmountDar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmdes As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
