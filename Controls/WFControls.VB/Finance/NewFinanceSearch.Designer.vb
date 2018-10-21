<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewFinanceSearch
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
        Me.cmbFinanceType = New System.Windows.Forms.ComboBox
        Me.lblhazine = New System.Windows.Forms.Label
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.pnlFileCase = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbShowType = New System.Windows.Forms.ComboBox
        Me.UcContacts2 = New WFControls.VB.ucContacts
        Me.txtFrom = New WFControls.VB.RmanShamsiDate
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTo = New WFControls.VB.RmanShamsiDate
        Me.btnHelp = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtFCaseID = New System.Windows.Forms.TextBox
        Me.txtFcMovakel = New System.Windows.Forms.TextBox
        Me.txtFCaseSubject = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.pnlGrid = New System.Windows.Forms.Panel
        Me.btnPrint = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.clmcustFullName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmfinanceAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmnAmountDar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmfinancePaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmfinanceID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmfinanceType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmdescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmFileCaseNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmfinaceTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmfinanceChequeSerial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmBranchName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmfinancePaymentTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlPercent = New System.Windows.Forms.Panel
        Me.txtBedehkar = New WFControls.VB.AmountControl
        Me.txtMande = New WFControls.VB.AmountControl
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtDaryafti = New WFControls.VB.AmountControl
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBmNameHeader = New System.Windows.Forms.TextBox
        Me.lblType = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnSearch = New System.Windows.Forms.Button
        Me.picCreateExcel = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.toolStripEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlFileCase.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPercent.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbFinanceType
        '
        Me.cmbFinanceType.DisplayMember = "settingName"
        Me.cmbFinanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFinanceType.FormattingEnabled = True
        Me.cmbFinanceType.Location = New System.Drawing.Point(76, 3)
        Me.cmbFinanceType.Name = "cmbFinanceType"
        Me.cmbFinanceType.Size = New System.Drawing.Size(121, 22)
        Me.cmbFinanceType.TabIndex = 0
        Me.cmbFinanceType.ValueMember = "settingValue"
        '
        'lblhazine
        '
        Me.lblhazine.AutoSize = True
        Me.lblhazine.Location = New System.Drawing.Point(200, 6)
        Me.lblhazine.Name = "lblhazine"
        Me.lblhazine.Size = New System.Drawing.Size(61, 14)
        Me.lblhazine.TabIndex = 4
        Me.lblhazine.Text = "نوع هزینه :"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlFileCase)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlGrid)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(547, 654)
        Me.FlowLayoutPanel1.TabIndex = 8
        '
        'pnlFileCase
        '
        Me.pnlFileCase.Controls.Add(Me.Label3)
        Me.pnlFileCase.Controls.Add(Me.cmbShowType)
        Me.pnlFileCase.Controls.Add(Me.UcContacts2)
        Me.pnlFileCase.Controls.Add(Me.txtFrom)
        Me.pnlFileCase.Controls.Add(Me.Label7)
        Me.pnlFileCase.Controls.Add(Me.Label8)
        Me.pnlFileCase.Controls.Add(Me.txtTo)
        Me.pnlFileCase.Controls.Add(Me.lblhazine)
        Me.pnlFileCase.Controls.Add(Me.cmbFinanceType)
        Me.pnlFileCase.Controls.Add(Me.btnHelp)
        Me.pnlFileCase.Controls.Add(Me.Label9)
        Me.pnlFileCase.Controls.Add(Me.txtFCaseID)
        Me.pnlFileCase.Controls.Add(Me.txtFcMovakel)
        Me.pnlFileCase.Controls.Add(Me.txtFCaseSubject)
        Me.pnlFileCase.Controls.Add(Me.Label5)
        Me.pnlFileCase.Controls.Add(Me.Label6)
        Me.pnlFileCase.Controls.Add(Me.Label4)
        Me.pnlFileCase.Controls.Add(Me.ShapeContainer1)
        Me.pnlFileCase.Location = New System.Drawing.Point(5, 0)
        Me.pnlFileCase.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFileCase.Name = "pnlFileCase"
        Me.pnlFileCase.Size = New System.Drawing.Size(542, 133)
        Me.pnlFileCase.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(420, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 14)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "جستجو از :"
        '
        'cmbShowType
        '
        Me.cmbShowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShowType.FormattingEnabled = True
        Me.cmbShowType.Items.AddRange(New Object() {"هزینه ها", "دریافتی ها"})
        Me.cmbShowType.Location = New System.Drawing.Point(294, 3)
        Me.cmbShowType.Name = "cmbShowType"
        Me.cmbShowType.Size = New System.Drawing.Size(123, 22)
        Me.cmbShowType.TabIndex = 89
        '
        'UcContacts2
        '
        Me.UcContacts2.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.UcContacts2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcContacts2.Location = New System.Drawing.Point(35, 97)
        Me.UcContacts2.Name = "UcContacts2"
        Me.UcContacts2.Size = New System.Drawing.Size(233, 22)
        Me.UcContacts2.TabIndex = 78
        '
        'txtFrom
        '
        Me.txtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtFrom.Location = New System.Drawing.Point(296, 27)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(121, 27)
        Me.txtFrom.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(418, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 14)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "از تاریخ :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(200, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 14)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "تا تاریخ :"
        '
        'txtTo
        '
        Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTo.Location = New System.Drawing.Point(76, 27)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(121, 27)
        Me.txtTo.TabIndex = 3
        '
        'btnHelp
        '
        Me.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.WFControls.VB.My.Resources.Resources.HelpIcon3
        Me.btnHelp.Location = New System.Drawing.Point(37, 69)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(20, 20)
        Me.btnHelp.TabIndex = 88
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(410, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 14)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "مشخصات پرونده"
        '
        'txtFCaseID
        '
        Me.txtFCaseID.Location = New System.Drawing.Point(76, 70)
        Me.txtFCaseID.Name = "txtFCaseID"
        Me.txtFCaseID.Size = New System.Drawing.Size(121, 22)
        Me.txtFCaseID.TabIndex = 5
        '
        'txtFcMovakel
        '
        Me.txtFcMovakel.AllowDrop = True
        Me.txtFcMovakel.Location = New System.Drawing.Point(294, 97)
        Me.txtFcMovakel.Name = "txtFcMovakel"
        Me.txtFcMovakel.Size = New System.Drawing.Size(123, 22)
        Me.txtFcMovakel.TabIndex = 6
        '
        'txtFCaseSubject
        '
        Me.txtFCaseSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtFCaseSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtFCaseSubject.Location = New System.Drawing.Point(294, 70)
        Me.txtFCaseSubject.Name = "txtFCaseSubject"
        Me.txtFCaseSubject.Size = New System.Drawing.Size(123, 22)
        Me.txtFCaseSubject.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(200, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 14)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "شماره  :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(420, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 14)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "موکل :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(420, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "موضوع پرونده :"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(542, 133)
        Me.ShapeContainer1.TabIndex = 3
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(28, 61)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(486, 63)
        '
        'pnlGrid
        '
        Me.pnlGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlGrid.Controls.Add(Me.btnPrint)
        Me.pnlGrid.Controls.Add(Me.DataGridView1)
        Me.pnlGrid.Controls.Add(Me.pnlPercent)
        Me.pnlGrid.Location = New System.Drawing.Point(1, 134)
        Me.pnlGrid.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(545, 440)
        Me.pnlGrid.TabIndex = 3
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Image = Global.WFControls.VB.My.Resources.Resources.printerWeb
        Me.btnPrint.Location = New System.Drawing.Point(5, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(25, 22)
        Me.btnPrint.TabIndex = 76
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmcustFullName, Me.clmfinanceAmount, Me.clmnAmountDar, Me.clmfinancePaymentDate, Me.clmfinanceID, Me.clmfinanceType, Me.clmdescription, Me.clmFileCaseNumber, Me.clmfinaceTypeID, Me.clmfinanceChequeSerial, Me.clmBranchName, Me.clmfinancePaymentTime})
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(4, 31)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
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
        Me.DataGridView1.Size = New System.Drawing.Size(537, 350)
        Me.DataGridView1.TabIndex = 21
        '
        'clmcustFullName
        '
        Me.clmcustFullName.DataPropertyName = "custFullName"
        Me.clmcustFullName.HeaderText = "واریزکننده"
        Me.clmcustFullName.Name = "clmcustFullName"
        Me.clmcustFullName.ReadOnly = True
        '
        'clmfinanceAmount
        '
        Me.clmfinanceAmount.DataPropertyName = "AmountHazine"
        Me.clmfinanceAmount.HeaderText = "مبلغ "
        Me.clmfinanceAmount.Name = "clmfinanceAmount"
        Me.clmfinanceAmount.ReadOnly = True
        '
        'clmnAmountDar
        '
        Me.clmnAmountDar.DataPropertyName = "AmountDaryafti"
        Me.clmnAmountDar.HeaderText = "مبلغ"
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
        'clmFileCaseNumber
        '
        Me.clmFileCaseNumber.DataPropertyName = "FileCaseNumber"
        Me.clmFileCaseNumber.HeaderText = "شماره پرونده"
        Me.clmFileCaseNumber.Name = "clmFileCaseNumber"
        Me.clmFileCaseNumber.ReadOnly = True
        '
        'clmfinaceTypeID
        '
        Me.clmfinaceTypeID.DataPropertyName = "finaceTypeID"
        Me.clmfinaceTypeID.HeaderText = ""
        Me.clmfinaceTypeID.Name = "clmfinaceTypeID"
        Me.clmfinaceTypeID.ReadOnly = True
        Me.clmfinaceTypeID.Visible = False
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
        Me.clmBranchName.DataPropertyName = "shobe"
        Me.clmBranchName.HeaderText = "نام شعبه"
        Me.clmBranchName.Name = "clmBranchName"
        Me.clmBranchName.ReadOnly = True
        '
        'clmfinancePaymentTime
        '
        Me.clmfinancePaymentTime.DataPropertyName = "financePaymentTime"
        Me.clmfinancePaymentTime.HeaderText = "زمان "
        Me.clmfinancePaymentTime.Name = "clmfinancePaymentTime"
        Me.clmfinancePaymentTime.ReadOnly = True
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
        Me.pnlPercent.Controls.Add(Me.Label1)
        Me.pnlPercent.Controls.Add(Me.txtBmNameHeader)
        Me.pnlPercent.Controls.Add(Me.lblType)
        Me.pnlPercent.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.pnlPercent.Location = New System.Drawing.Point(4, 387)
        Me.pnlPercent.Name = "pnlPercent"
        Me.pnlPercent.Size = New System.Drawing.Size(538, 50)
        Me.pnlPercent.TabIndex = 22
        '
        'txtBedehkar
        '
        Me.txtBedehkar.Amount = 0
        Me.txtBedehkar.BackColor = System.Drawing.Color.LightSkyBlue
        Me.txtBedehkar.Location = New System.Drawing.Point(309, 2)
        Me.txtBedehkar.Name = "txtBedehkar"
        Me.txtBedehkar.ReadOnly = True
        Me.txtBedehkar.Size = New System.Drawing.Size(120, 20)
        Me.txtBedehkar.TabIndex = 23
        '
        'txtMande
        '
        Me.txtMande.Amount = 0
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
        Me.txtDaryafti.Amount = 0
        Me.txtDaryafti.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDaryafti.Location = New System.Drawing.Point(309, 26)
        Me.txtDaryafti.Name = "txtDaryafti"
        Me.txtDaryafti.ReadOnly = True
        Me.txtDaryafti.Size = New System.Drawing.Size(120, 20)
        Me.txtDaryafti.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label12.Location = New System.Drawing.Point(279, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "ریال"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.AliceBlue
        Me.Label11.Location = New System.Drawing.Point(435, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "جمع مبلغ دریافتی :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.Location = New System.Drawing.Point(437, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "جمع مبلغ هزینه :"
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
        Me.txtBmNameHeader.Size = New System.Drawing.Size(536, 23)
        Me.txtBmNameHeader.TabIndex = 5
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(279, 29)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(24, 13)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "ریال"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnSearch)
        Me.Panel2.Controls.Add(Me.picCreateExcel)
        Me.Panel2.Location = New System.Drawing.Point(5, 576)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(541, 52)
        Me.Panel2.TabIndex = 21
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(274, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(101, 30)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'picCreateExcel
        '
        Me.picCreateExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picCreateExcel.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.picCreateExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCreateExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.picCreateExcel.FlatAppearance.BorderSize = 0
        Me.picCreateExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.picCreateExcel.Location = New System.Drawing.Point(165, 11)
        Me.picCreateExcel.Name = "picCreateExcel"
        Me.picCreateExcel.Size = New System.Drawing.Size(101, 30)
        Me.picCreateExcel.TabIndex = 9
        Me.picCreateExcel.Text = "ارسال به اکسل"
        Me.picCreateExcel.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripEdit, Me.ToolStripDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(111, 48)
        '
        'toolStripEdit
        '
        Me.toolStripEdit.Image = Global.WFControls.VB.My.Resources.Resources.EditCat
        Me.toolStripEdit.Name = "toolStripEdit"
        Me.toolStripEdit.Size = New System.Drawing.Size(110, 22)
        Me.toolStripEdit.Text = "ویرایش "
        '
        'ToolStripDelete
        '
        Me.ToolStripDelete.Image = Global.WFControls.VB.My.Resources.Resources.DeleteCat
        Me.ToolStripDelete.Name = "ToolStripDelete"
        Me.ToolStripDelete.Size = New System.Drawing.Size(110, 22)
        Me.ToolStripDelete.Text = "حذف"
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 628)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(547, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(13, 6)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(515, 13)
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
        'NewFinanceSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "NewFinanceSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(547, 654)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlFileCase.ResumeLayout(False)
        Me.pnlFileCase.PerformLayout()
        Me.pnlGrid.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPercent.ResumeLayout(False)
        Me.pnlPercent.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbFinanceType As System.Windows.Forms.ComboBox
    Friend WithEvents lblhazine As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents pnlFileCase As System.Windows.Forms.Panel
    Friend WithEvents txtFcMovakel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFCaseID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFCaseSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents picCreateExcel As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents toolStripEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtFrom As WFControls.VB.RmanShamsiDate
    Friend WithEvents txtTo As WFControls.VB.RmanShamsiDate
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlPercent As System.Windows.Forms.Panel
    Friend WithEvents txtBmNameHeader As System.Windows.Forms.TextBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtDaryafti As WFControls.VB.AmountControl
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMande As WFControls.VB.AmountControl
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBedehkar As WFControls.VB.AmountControl
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents UcContacts2 As WFControls.VB.ucContacts
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbShowType As System.Windows.Forms.ComboBox
    Friend WithEvents clmcustFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinanceAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnAmountDar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinancePaymentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinanceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinanceType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmdescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFileCaseNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinaceTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinanceChequeSerial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmBranchName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmfinancePaymentTime As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
