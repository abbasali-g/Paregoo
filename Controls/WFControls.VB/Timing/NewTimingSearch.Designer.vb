<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewTimingSearch
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkSeeAll = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.cmbRange = New System.Windows.Forms.ComboBox()
        Me.cmbDateType = New System.Windows.Forms.ComboBox()
        Me.cmbDay = New System.Windows.Forms.ComboBox()
        Me.cmbSender = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUserId = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.pnlFileCase = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbFileCaseStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMovakel = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFilecaseSubject = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFilecaseNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.UcContacts1 = New WFControls.VB.ucContacts()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdbALL = New System.Windows.Forms.RadioButton()
        Me.rdbNoFilecase = New System.Windows.Forms.RadioButton()
        Me.rdbFilecase = New System.Windows.Forms.RadioButton()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Panel3.SuspendLayout()
        Me.pnlFileCase.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrid.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chkSeeAll)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cmbStatus)
        Me.Panel3.Controls.Add(Me.cmbRange)
        Me.Panel3.Controls.Add(Me.cmbDateType)
        Me.Panel3.Controls.Add(Me.cmbDay)
        Me.Panel3.Controls.Add(Me.cmbSender)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.cmbUserId)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.cmbType)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtSubject)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.ShapeContainer1)
        Me.Panel3.Location = New System.Drawing.Point(0, 1)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(557, 89)
        Me.Panel3.TabIndex = 3
        '
        'chkSeeAll
        '
        Me.chkSeeAll.AutoSize = True
        Me.chkSeeAll.Location = New System.Drawing.Point(210, 37)
        Me.chkSeeAll.Name = "chkSeeAll"
        Me.chkSeeAll.Size = New System.Drawing.Size(90, 17)
        Me.chkSeeAll.TabIndex = 80
        Me.chkSeeAll.Text = "مشاهده همه"
        Me.chkSeeAll.UseVisualStyleBackColor = True
        Me.chkSeeAll.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(159, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "وضعیت :"
        '
        'cmbStatus
        '
        Me.cmbStatus.DisplayMember = "settingName"
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"همه موارد", "خوانده / انجام شده", "خوانده / انجام نشده"})
        Me.cmbStatus.Location = New System.Drawing.Point(35, 58)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(121, 21)
        Me.cmbStatus.TabIndex = 79
        Me.cmbStatus.ValueMember = "settingValue"
        '
        'cmbRange
        '
        Me.cmbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRange.FormattingEnabled = True
        Me.cmbRange.Items.AddRange(New Object() {"آینده", "گذشته"})
        Me.cmbRange.Location = New System.Drawing.Point(305, 58)
        Me.cmbRange.Name = "cmbRange"
        Me.cmbRange.Size = New System.Drawing.Size(60, 21)
        Me.cmbRange.TabIndex = 78
        '
        'cmbDateType
        '
        Me.cmbDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDateType.FormattingEnabled = True
        Me.cmbDateType.Items.AddRange(New Object() {"روز", "ماه", "سال"})
        Me.cmbDateType.Location = New System.Drawing.Point(367, 58)
        Me.cmbDateType.Name = "cmbDateType"
        Me.cmbDateType.Size = New System.Drawing.Size(47, 21)
        Me.cmbDateType.TabIndex = 78
        '
        'cmbDay
        '
        Me.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDay.FormattingEnabled = True
        Me.cmbDay.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.cmbDay.Location = New System.Drawing.Point(416, 58)
        Me.cmbDay.Name = "cmbDay"
        Me.cmbDay.Size = New System.Drawing.Size(40, 21)
        Me.cmbDay.TabIndex = 77
        '
        'cmbSender
        '
        Me.cmbSender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSender.FormattingEnabled = True
        Me.cmbSender.Location = New System.Drawing.Point(305, 10)
        Me.cmbSender.Name = "cmbSender"
        Me.cmbSender.Size = New System.Drawing.Size(150, 21)
        Me.cmbSender.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(460, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "ارسال کننده :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(460, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "ارجاع به :"
        '
        'cmbUserId
        '
        Me.cmbUserId.DisplayMember = "settingName"
        Me.cmbUserId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserId.FormattingEnabled = True
        Me.cmbUserId.Location = New System.Drawing.Point(305, 34)
        Me.cmbUserId.Name = "cmbUserId"
        Me.cmbUserId.Size = New System.Drawing.Size(150, 21)
        Me.cmbUserId.TabIndex = 0
        Me.cmbUserId.ValueMember = "settingValue"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(159, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "نوع :"
        '
        'cmbType
        '
        Me.cmbType.DisplayMember = "settingName"
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(35, 10)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(121, 21)
        Me.cmbType.TabIndex = 11
        Me.cmbType.ValueMember = "settingValue"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(460, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "محدوده زمانی :"
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(35, 34)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(121, 21)
        Me.txtSubject.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "عنوان :"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(557, 89)
        Me.ShapeContainer1.TabIndex = 15
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(6, 5)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(544, 80)
        '
        'pnlFileCase
        '
        Me.pnlFileCase.Controls.Add(Me.Label11)
        Me.pnlFileCase.Controls.Add(Me.cmbFileCaseStatus)
        Me.pnlFileCase.Controls.Add(Me.Label10)
        Me.pnlFileCase.Controls.Add(Me.txtMovakel)
        Me.pnlFileCase.Controls.Add(Me.Label9)
        Me.pnlFileCase.Controls.Add(Me.txtFilecaseSubject)
        Me.pnlFileCase.Controls.Add(Me.Label5)
        Me.pnlFileCase.Controls.Add(Me.txtFilecaseNo)
        Me.pnlFileCase.Controls.Add(Me.Label7)
        Me.pnlFileCase.Controls.Add(Me.ShapeContainer2)
        Me.pnlFileCase.Location = New System.Drawing.Point(0, 130)
        Me.pnlFileCase.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlFileCase.Name = "pnlFileCase"
        Me.pnlFileCase.Size = New System.Drawing.Size(557, 71)
        Me.pnlFileCase.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(162, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "وضعیت پرونده :"
        '
        'cmbFileCaseStatus
        '
        Me.cmbFileCaseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFileCaseStatus.FormattingEnabled = True
        Me.cmbFileCaseStatus.Items.AddRange(New Object() {"همه موارد", "جاری", "مختومه"})
        Me.cmbFileCaseStatus.Location = New System.Drawing.Point(35, 38)
        Me.cmbFileCaseStatus.Name = "cmbFileCaseStatus"
        Me.cmbFileCaseStatus.Size = New System.Drawing.Size(121, 21)
        Me.cmbFileCaseStatus.TabIndex = 81
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(460, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 77
        Me.Label10.Text = "موکل :"
        '
        'txtMovakel
        '
        Me.txtMovakel.AllowDrop = True
        Me.txtMovakel.Location = New System.Drawing.Point(305, 38)
        Me.txtMovakel.Name = "txtMovakel"
        Me.txtMovakel.Size = New System.Drawing.Size(150, 21)
        Me.txtMovakel.TabIndex = 78
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(451, -3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "مشخصات پرونده"
        '
        'txtFilecaseSubject
        '
        Me.txtFilecaseSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtFilecaseSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtFilecaseSubject.Location = New System.Drawing.Point(35, 12)
        Me.txtFilecaseSubject.Name = "txtFilecaseSubject"
        Me.txtFilecaseSubject.Size = New System.Drawing.Size(121, 21)
        Me.txtFilecaseSubject.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(159, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "موضوع دعوی :"
        '
        'txtFilecaseNo
        '
        Me.txtFilecaseNo.Location = New System.Drawing.Point(305, 14)
        Me.txtFilecaseNo.Name = "txtFilecaseNo"
        Me.txtFilecaseNo.Size = New System.Drawing.Size(150, 21)
        Me.txtFilecaseNo.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(460, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "شماره پرونده :"
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape1.CornerRadius = 5
        Me.RectangleShape1.Location = New System.Drawing.Point(8, 6)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(542, 55)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(5, 62)
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
        Me.DataGridView1.Size = New System.Drawing.Size(544, 287)
        Me.DataGridView1.TabIndex = 9
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'pnlGrid
        '
        Me.pnlGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlGrid.Controls.Add(Me.Label12)
        Me.pnlGrid.Controls.Add(Me.btnPrint)
        Me.pnlGrid.Controls.Add(Me.btnSearch)
        Me.pnlGrid.Controls.Add(Me.UcContacts1)
        Me.pnlGrid.Controls.Add(Me.DataGridView1)
        Me.pnlGrid.Location = New System.Drawing.Point(0, 202)
        Me.pnlGrid.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(555, 362)
        Me.pnlGrid.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(311, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(227, 13)
        Me.Label12.TabIndex = 86
        Me.Label12.Text = "جهت ویرایش یا حذف روی عنوان رکورد کلیک کنید"
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Image = Global.WFControls.VB.My.Resources.Resources.printerWeb
        Me.btnPrint.Location = New System.Drawing.Point(8, 37)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(25, 22)
        Me.btnPrint.TabIndex = 17
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(200, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 32)
        Me.btnSearch.TabIndex = 16
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'UcContacts1
        '
        Me.UcContacts1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.UcContacts1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcContacts1.Location = New System.Drawing.Point(270, 3)
        Me.UcContacts1.Name = "UcContacts1"
        Me.UcContacts1.Size = New System.Drawing.Size(202, 20)
        Me.UcContacts1.TabIndex = 85
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 595)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(564, 26)
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
        Me.lblMessage.Size = New System.Drawing.Size(549, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "lblMessage"
        Me.lblMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlFileCase)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlGrid)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(558, 586)
        Me.FlowLayoutPanel1.TabIndex = 76
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdbALL)
        Me.Panel2.Controls.Add(Me.rdbNoFilecase)
        Me.Panel2.Controls.Add(Me.rdbFilecase)
        Me.Panel2.Controls.Add(Me.ShapeContainer3)
        Me.Panel2.Location = New System.Drawing.Point(4, 94)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(551, 32)
        Me.Panel2.TabIndex = 80
        '
        'rdbALL
        '
        Me.rdbALL.AutoSize = True
        Me.rdbALL.Checked = True
        Me.rdbALL.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdbALL.ForeColor = System.Drawing.Color.Navy
        Me.rdbALL.Location = New System.Drawing.Point(55, 8)
        Me.rdbALL.Name = "rdbALL"
        Me.rdbALL.Size = New System.Drawing.Size(79, 17)
        Me.rdbALL.TabIndex = 78
        Me.rdbALL.TabStop = True
        Me.rdbALL.Text = "همه موارد"
        Me.rdbALL.UseVisualStyleBackColor = True
        '
        'rdbNoFilecase
        '
        Me.rdbNoFilecase.AutoSize = True
        Me.rdbNoFilecase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdbNoFilecase.ForeColor = System.Drawing.Color.Navy
        Me.rdbNoFilecase.Location = New System.Drawing.Point(206, 8)
        Me.rdbNoFilecase.Name = "rdbNoFilecase"
        Me.rdbNoFilecase.Size = New System.Drawing.Size(139, 17)
        Me.rdbNoFilecase.TabIndex = 77
        Me.rdbNoFilecase.Text = "اقدامات غیر پرونده ای"
        Me.rdbNoFilecase.UseVisualStyleBackColor = True
        '
        'rdbFilecase
        '
        Me.rdbFilecase.AutoSize = True
        Me.rdbFilecase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rdbFilecase.ForeColor = System.Drawing.Color.Navy
        Me.rdbFilecase.Location = New System.Drawing.Point(410, 8)
        Me.rdbFilecase.Name = "rdbFilecase"
        Me.rdbFilecase.Size = New System.Drawing.Size(119, 17)
        Me.rdbFilecase.TabIndex = 18
        Me.rdbFilecase.Text = "اقدامات پرونده ای"
        Me.rdbFilecase.UseVisualStyleBackColor = True
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape3})
        Me.ShapeContainer3.Size = New System.Drawing.Size(551, 32)
        Me.ShapeContainer3.TabIndex = 0
        Me.ShapeContainer3.TabStop = False
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape3.CornerRadius = 5
        Me.RectangleShape3.Location = New System.Drawing.Point(3, 5)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(544, 23)
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(557, 71)
        Me.ShapeContainer2.TabIndex = 9
        Me.ShapeContainer2.TabStop = False
        '
        'NewTimingSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.pnlMsg)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Margin = New System.Windows.Forms.Padding(1)
        Me.Name = "NewTimingSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(564, 621)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlFileCase.ResumeLayout(False)
        Me.pnlFileCase.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrid.ResumeLayout(False)
        Me.pnlGrid.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlFileCase As System.Windows.Forms.Panel
    Friend WithEvents txtFilecaseNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFilecaseSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUserId As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbSender As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbRange As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDateType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDay As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMovakel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UcContacts1 As WFControls.VB.ucContacts
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbFileCaseStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdbALL As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNoFilecase As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFilecase As System.Windows.Forms.RadioButton
    Friend WithEvents ShapeContainer3 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkSeeAll As System.Windows.Forms.CheckBox
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer

End Class
