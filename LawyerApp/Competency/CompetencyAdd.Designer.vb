<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompetencyAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompetencyAdd))
        Me.txtMapStreet = New System.Windows.Forms.TextBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.panel4 = New System.Windows.Forms.Panel()
        Me.rbBranchKalantari = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAddKey = New System.Windows.Forms.Button()
        Me.pnlDadsaraDetail = New System.Windows.Forms.Panel()
        Me.rbBranchShobe = New System.Windows.Forms.RadioButton()
        Me.rdBazporsi = New System.Windows.Forms.RadioButton()
        Me.rdbDadyari = New System.Windows.Forms.RadioButton()
        Me.txtBranchName = New System.Windows.Forms.TextBox()
        Me.lvBranch = New System.Windows.Forms.ListView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtTsName = New System.Windows.Forms.TextBox()
        Me.txtTsProvince = New System.Windows.Forms.TextBox()
        Me.txtTsState = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbKeyfari = New System.Windows.Forms.RadioButton()
        Me.rbHugugi = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdEdalat = New System.Windows.Forms.RadioButton()
        Me.rbDivan = New System.Windows.Forms.RadioButton()
        Me.rbShura = New System.Windows.Forms.RadioButton()
        Me.rbMojtame = New System.Windows.Forms.RadioButton()
        Me.rbDadsara = New System.Windows.Forms.RadioButton()
        Me.rbShebhe = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMapCity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlTitle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panel4.SuspendLayout()
        Me.pnlDadsaraDetail.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMapStreet
        '
        Me.txtMapStreet.AcceptsReturn = True
        Me.txtMapStreet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtMapStreet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtMapStreet.BackColor = System.Drawing.Color.White
        Me.txtMapStreet.Location = New System.Drawing.Point(18, 103)
        Me.txtMapStreet.Name = "txtMapStreet"
        Me.txtMapStreet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMapStreet.Size = New System.Drawing.Size(112, 21)
        Me.txtMapStreet.TabIndex = 4
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.White
        Me.txtNote.Location = New System.Drawing.Point(7, 135)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(632, 59)
        Me.txtNote.TabIndex = 5
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(8, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(642, 23)
        Me.pnlTitle.TabIndex = 30
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(585, 5)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(51, 13)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = " صلاحیت"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.panel4)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btnDel)
        Me.Panel1.Controls.Add(Me.btnAddKey)
        Me.Panel1.Controls.Add(Me.pnlDadsaraDetail)
        Me.Panel1.Controls.Add(Me.txtBranchName)
        Me.Panel1.Controls.Add(Me.lvBranch)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.txtTsName)
        Me.Panel1.Controls.Add(Me.txtTsProvince)
        Me.Panel1.Controls.Add(Me.txtTsState)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtMapCity)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtNote)
        Me.Panel1.Controls.Add(Me.txtMapStreet)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(8, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(642, 339)
        Me.Panel1.TabIndex = 31
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(428, 194)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "مشخصات شعبه"
        '
        'panel4
        '
        Me.panel4.Controls.Add(Me.rbBranchKalantari)
        Me.panel4.Location = New System.Drawing.Point(27, 295)
        Me.panel4.Name = "panel4"
        Me.panel4.Size = New System.Drawing.Size(78, 34)
        Me.panel4.TabIndex = 107
        Me.panel4.Visible = False
        '
        'rbBranchKalantari
        '
        Me.rbBranchKalantari.AutoSize = True
        Me.rbBranchKalantari.Enabled = False
        Me.rbBranchKalantari.Location = New System.Drawing.Point(8, 14)
        Me.rbBranchKalantari.Name = "rbBranchKalantari"
        Me.rbBranchKalantari.Size = New System.Drawing.Size(60, 17)
        Me.rbBranchKalantari.TabIndex = 1
        Me.rbBranchKalantari.Text = "کلانتری"
        Me.rbBranchKalantari.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(588, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "توضیحات"
        '
        'btnDel
        '
        Me.btnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDel.FlatAppearance.BorderSize = 0
        Me.btnDel.Image = Global.LawyerApp.My.Resources.Resources.DeleteCat
        Me.btnDel.Location = New System.Drawing.Point(8, 247)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(62, 32)
        Me.btnDel.TabIndex = 8
        Me.btnDel.Text = "حذف"
        Me.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnDel, "حذف آیتم انتخاب شده")
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAddKey
        '
        Me.btnAddKey.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddKey.FlatAppearance.BorderSize = 0
        Me.btnAddKey.Image = Global.LawyerApp.My.Resources.Resources.Tick_circle_frame
        Me.btnAddKey.Location = New System.Drawing.Point(326, 232)
        Me.btnAddKey.Name = "btnAddKey"
        Me.btnAddKey.Size = New System.Drawing.Size(61, 24)
        Me.btnAddKey.TabIndex = 7
        Me.btnAddKey.Text = "اضافه"
        Me.btnAddKey.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnAddKey, "اضافه کردن به لیست")
        Me.btnAddKey.UseVisualStyleBackColor = True
        '
        'pnlDadsaraDetail
        '
        Me.pnlDadsaraDetail.Controls.Add(Me.rbBranchShobe)
        Me.pnlDadsaraDetail.Controls.Add(Me.rdBazporsi)
        Me.pnlDadsaraDetail.Controls.Add(Me.rdbDadyari)
        Me.pnlDadsaraDetail.Location = New System.Drawing.Point(543, 211)
        Me.pnlDadsaraDetail.Name = "pnlDadsaraDetail"
        Me.pnlDadsaraDetail.Size = New System.Drawing.Size(87, 70)
        Me.pnlDadsaraDetail.TabIndex = 106
        '
        'rbBranchShobe
        '
        Me.rbBranchShobe.AutoSize = True
        Me.rbBranchShobe.Checked = True
        Me.rbBranchShobe.Location = New System.Drawing.Point(15, 2)
        Me.rbBranchShobe.Name = "rbBranchShobe"
        Me.rbBranchShobe.Size = New System.Drawing.Size(52, 17)
        Me.rbBranchShobe.TabIndex = 0
        Me.rbBranchShobe.TabStop = True
        Me.rbBranchShobe.Text = "شعبه"
        Me.rbBranchShobe.UseVisualStyleBackColor = True
        '
        'rdBazporsi
        '
        Me.rdBazporsi.AutoSize = True
        Me.rdBazporsi.Location = New System.Drawing.Point(2, 44)
        Me.rdBazporsi.Name = "rdBazporsi"
        Me.rdBazporsi.Size = New System.Drawing.Size(65, 17)
        Me.rdBazporsi.TabIndex = 1
        Me.rdBazporsi.Text = "بازپرسی"
        Me.rdBazporsi.UseVisualStyleBackColor = True
        '
        'rdbDadyari
        '
        Me.rdbDadyari.AutoSize = True
        Me.rdbDadyari.Location = New System.Drawing.Point(9, 23)
        Me.rdbDadyari.Name = "rdbDadyari"
        Me.rdbDadyari.Size = New System.Drawing.Size(58, 17)
        Me.rdbDadyari.TabIndex = 0
        Me.rdbDadyari.Text = "دادیاری"
        Me.rdbDadyari.UseVisualStyleBackColor = True
        '
        'txtBranchName
        '
        Me.txtBranchName.AcceptsReturn = True
        Me.txtBranchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtBranchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBranchName.BackColor = System.Drawing.Color.White
        Me.txtBranchName.Location = New System.Drawing.Point(393, 234)
        Me.txtBranchName.Name = "txtBranchName"
        Me.txtBranchName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtBranchName.Size = New System.Drawing.Size(144, 21)
        Me.txtBranchName.TabIndex = 6
        '
        'lvBranch
        '
        Me.lvBranch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.lvBranch.CheckBoxes = True
        Me.lvBranch.Location = New System.Drawing.Point(76, 204)
        Me.lvBranch.Name = "lvBranch"
        Me.lvBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lvBranch.RightToLeftLayout = True
        Me.lvBranch.Size = New System.Drawing.Size(246, 77)
        Me.lvBranch.TabIndex = 9
        Me.lvBranch.UseCompatibleStateImageBehavior = False
        Me.lvBranch.View = System.Windows.Forms.View.List
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.LawyerApp.My.Resources.Resources.pill_shaped_002
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(162, 295)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 32)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "انصراف"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.LawyerApp.My.Resources.Resources.pill_shaped_002
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(267, 295)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 32)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "ذخیره"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtTsName
        '
        Me.txtTsName.AcceptsReturn = True
        Me.txtTsName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTsName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtTsName.BackColor = System.Drawing.Color.White
        Me.txtTsName.Location = New System.Drawing.Point(8, 9)
        Me.txtTsName.Name = "txtTsName"
        Me.txtTsName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTsName.Size = New System.Drawing.Size(310, 21)
        Me.txtTsName.TabIndex = 2
        '
        'txtTsProvince
        '
        Me.txtTsProvince.AcceptsReturn = True
        Me.txtTsProvince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTsProvince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtTsProvince.BackColor = System.Drawing.Color.White
        Me.txtTsProvince.Location = New System.Drawing.Point(357, 9)
        Me.txtTsProvince.Name = "txtTsProvince"
        Me.txtTsProvince.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTsProvince.Size = New System.Drawing.Size(90, 21)
        Me.txtTsProvince.TabIndex = 1
        '
        'txtTsState
        '
        Me.txtTsState.AcceptsReturn = True
        Me.txtTsState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTsState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtTsState.BackColor = System.Drawing.Color.White
        Me.txtTsState.Location = New System.Drawing.Point(508, 9)
        Me.txtTsState.Name = "txtTsState"
        Me.txtTsState.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTsState.Size = New System.Drawing.Size(90, 21)
        Me.txtTsState.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rbKeyfari)
        Me.Panel3.Controls.Add(Me.rbHugugi)
        Me.Panel3.Location = New System.Drawing.Point(443, 64)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(196, 24)
        Me.Panel3.TabIndex = 4
        '
        'rbKeyfari
        '
        Me.rbKeyfari.AutoSize = True
        Me.rbKeyfari.Checked = True
        Me.rbKeyfari.Location = New System.Drawing.Point(47, 3)
        Me.rbKeyfari.Name = "rbKeyfari"
        Me.rbKeyfari.Size = New System.Drawing.Size(55, 17)
        Me.rbKeyfari.TabIndex = 1
        Me.rbKeyfari.TabStop = True
        Me.rbKeyfari.Text = "کیفری"
        Me.rbKeyfari.UseVisualStyleBackColor = True
        '
        'rbHugugi
        '
        Me.rbHugugi.AutoSize = True
        Me.rbHugugi.Checked = True
        Me.rbHugugi.Location = New System.Drawing.Point(132, 3)
        Me.rbHugugi.Name = "rbHugugi"
        Me.rbHugugi.Size = New System.Drawing.Size(59, 17)
        Me.rbHugugi.TabIndex = 0
        Me.rbHugugi.TabStop = True
        Me.rbHugugi.Text = "حقوقی"
        Me.rbHugugi.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdEdalat)
        Me.Panel2.Controls.Add(Me.rbDivan)
        Me.Panel2.Controls.Add(Me.rbShura)
        Me.Panel2.Controls.Add(Me.rbMojtame)
        Me.Panel2.Controls.Add(Me.rbDadsara)
        Me.Panel2.Controls.Add(Me.rbShebhe)
        Me.Panel2.Location = New System.Drawing.Point(8, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(631, 26)
        Me.Panel2.TabIndex = 3
        '
        'rdEdalat
        '
        Me.rdEdalat.AutoSize = True
        Me.rdEdalat.Location = New System.Drawing.Point(27, 5)
        Me.rdEdalat.Name = "rdEdalat"
        Me.rdEdalat.Size = New System.Drawing.Size(108, 17)
        Me.rdEdalat.TabIndex = 89
        Me.rdEdalat.TabStop = True
        Me.rdEdalat.Text = "دیوان عدالت اداری"
        Me.rdEdalat.UseVisualStyleBackColor = True
        '
        'rbDivan
        '
        Me.rbDivan.AutoSize = True
        Me.rbDivan.Location = New System.Drawing.Point(137, 5)
        Me.rbDivan.Name = "rbDivan"
        Me.rbDivan.Size = New System.Drawing.Size(104, 17)
        Me.rbDivan.TabIndex = 89
        Me.rbDivan.TabStop = True
        Me.rbDivan.Text = "دیوان عالی کشور"
        Me.rbDivan.UseVisualStyleBackColor = True
        '
        'rbShura
        '
        Me.rbShura.AutoSize = True
        Me.rbShura.Location = New System.Drawing.Point(245, 5)
        Me.rbShura.Name = "rbShura"
        Me.rbShura.Size = New System.Drawing.Size(111, 17)
        Me.rbShura.TabIndex = 88
        Me.rbShura.TabStop = True
        Me.rbShura.Text = "شورای حل اختلاف"
        Me.rbShura.UseVisualStyleBackColor = True
        '
        'rbMojtame
        '
        Me.rbMojtame.AutoSize = True
        Me.rbMojtame.Checked = True
        Me.rbMojtame.Location = New System.Drawing.Point(535, 5)
        Me.rbMojtame.Name = "rbMojtame"
        Me.rbMojtame.Size = New System.Drawing.Size(89, 17)
        Me.rbMojtame.TabIndex = 0
        Me.rbMojtame.TabStop = True
        Me.rbMojtame.Text = "مجتمع قضائی"
        Me.rbMojtame.UseVisualStyleBackColor = True
        '
        'rbDadsara
        '
        Me.rbDadsara.AutoSize = True
        Me.rbDadsara.Location = New System.Drawing.Point(477, 5)
        Me.rbDadsara.Name = "rbDadsara"
        Me.rbDadsara.Size = New System.Drawing.Size(57, 17)
        Me.rbDadsara.TabIndex = 1
        Me.rbDadsara.TabStop = True
        Me.rbDadsara.Text = "دادسرا"
        Me.rbDadsara.UseVisualStyleBackColor = True
        '
        'rbShebhe
        '
        Me.rbShebhe.AutoSize = True
        Me.rbShebhe.Location = New System.Drawing.Point(358, 5)
        Me.rbShebhe.Name = "rbShebhe"
        Me.rbShebhe.Size = New System.Drawing.Size(107, 17)
        Me.rbShebhe.TabIndex = 2
        Me.rbShebhe.TabStop = True
        Me.rbShebhe.Text = "مرجع شبه قضایی"
        Me.rbShebhe.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(136, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "خیابان به فارسی"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "شهر به انگلیسی"
        '
        'txtMapCity
        '
        Me.txtMapCity.AcceptsReturn = True
        Me.txtMapCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtMapCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtMapCity.BackColor = System.Drawing.Color.White
        Me.txtMapCity.Location = New System.Drawing.Point(18, 76)
        Me.txtMapCity.Name = "txtMapCity"
        Me.txtMapCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMapCity.Size = New System.Drawing.Size(112, 21)
        Me.txtMapCity.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(324, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "حوزه"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(450, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "شهرستان"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(600, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "استان"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1, Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(642, 339)
        Me.ShapeContainer1.TabIndex = 109
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape1.CornerRadius = 5
        Me.RectangleShape1.Location = New System.Drawing.Point(6, 200)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(631, 90)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(7, 68)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(221, 61)
        '
        'pnlMsg
        '
        Me.pnlMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(8, 369)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlMsg.Size = New System.Drawing.Size(642, 25)
        Me.pnlMsg.TabIndex = 80
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(75, 3)
        Me.lblMessage.Multiline = True
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(567, 24)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'CompetencyAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(659, 396)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.pnlMsg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "CompetencyAdd"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panel4.ResumeLayout(False)
        Me.panel4.PerformLayout()
        Me.pnlDadsaraDetail.ResumeLayout(False)
        Me.pnlDadsaraDetail.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtMapStreet As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbShebhe As System.Windows.Forms.RadioButton
    Friend WithEvents rbDadsara As System.Windows.Forms.RadioButton
    Friend WithEvents rbMojtame As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbHugugi As System.Windows.Forms.RadioButton
    Friend WithEvents rbKeyfari As System.Windows.Forms.RadioButton
    Friend WithEvents txtMapCity As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtTsName As System.Windows.Forms.TextBox
    Friend WithEvents txtTsProvince As System.Windows.Forms.TextBox
    Friend WithEvents txtTsState As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lvBranch As System.Windows.Forms.ListView
    Friend WithEvents pnlDadsaraDetail As System.Windows.Forms.Panel
    Friend WithEvents rbBranchKalantari As System.Windows.Forms.RadioButton
    Friend WithEvents rbBranchShobe As System.Windows.Forms.RadioButton
    Friend WithEvents txtBranchName As System.Windows.Forms.TextBox
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnAddKey As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents rbShura As System.Windows.Forms.RadioButton
    Friend WithEvents rbDivan As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents panel4 As System.Windows.Forms.Panel
    Friend WithEvents rdBazporsi As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDadyari As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents rdEdalat As System.Windows.Forms.RadioButton
End Class
