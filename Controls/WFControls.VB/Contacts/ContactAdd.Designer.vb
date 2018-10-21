<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContactAdd
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
        Me.lable1 = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCellphone = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCompanyName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFatherName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtFullName = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtHomeTel = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtJob = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtOfficeTel = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtRegNumber = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.richTxtDescription = New System.Windows.Forms.RichTextBox
        Me.ContextMenuImage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.toolStripChangeImage = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripDelImage = New System.Windows.Forms.ToolStripMenuItem
        Me.Label13 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.pnlImage = New System.Windows.Forms.Panel
        Me.picImage = New System.Windows.Forms.PictureBox
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.txtEmail1 = New System.Windows.Forms.TextBox
        Me.txtNetUser = New System.Windows.Forms.TextBox
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.cmbContactType = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.chkIsAdmin = New System.Windows.Forms.CheckBox
        Me.chkIsSysUser = New System.Windows.Forms.CheckBox
        Me.pnlSysUserDetail = New System.Windows.Forms.Panel
        Me.chkChangePass = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtConfirmPass = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtNumberID = New System.Windows.Forms.TextBox
        Me.btnHelp = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.pnlCollapse = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.txtBirthday = New WFControls.VB.RmanShamsiDate
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtNetPassword = New System.Windows.Forms.TextBox
        Me.ContextMenuImage.SuspendLayout()
        Me.pnlImage.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMsg.SuspendLayout()
        Me.pnlSysUserDetail.SuspendLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lable1
        '
        Me.lable1.AutoSize = True
        Me.lable1.Location = New System.Drawing.Point(464, 407)
        Me.lable1.Name = "lable1"
        Me.lable1.Size = New System.Drawing.Size(43, 14)
        Me.lable1.TabIndex = 1
        Me.lable1.Text = "آدرس :"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(13, 401)
        Me.txtAddress.MaxLength = 200
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(446, 24)
        Me.txtAddress.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(463, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "تاریخ تولد :"
        '
        'txtCellphone
        '
        Me.txtCellphone.Location = New System.Drawing.Point(323, 292)
        Me.txtCellphone.MaxLength = 15
        Me.txtCellphone.Name = "txtCellphone"
        Me.txtCellphone.Size = New System.Drawing.Size(137, 22)
        Me.txtCellphone.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(465, 295)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "شماره همراه :"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(271, 227)
        Me.txtCompanyName.MaxLength = 45
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(188, 22)
        Me.txtCompanyName.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(463, 230)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "نام شرکت :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(139, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "سایر توضیحات"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(463, 375)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "ایمیل  :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(461, 432)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 14)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "رزرو:"
        Me.Label7.Visible = False
        '
        'txtFatherName
        '
        Me.txtFatherName.Location = New System.Drawing.Point(340, 48)
        Me.txtFatherName.MaxLength = 45
        Me.txtFatherName.Name = "txtFatherName"
        Me.txtFatherName.Size = New System.Drawing.Size(119, 22)
        Me.txtFatherName.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(462, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 14)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "نام پدر :"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(323, 318)
        Me.txtFax.MaxLength = 15
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(137, 22)
        Me.txtFax.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(464, 322)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 14)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "فاکس :"
        '
        'txtFullName
        '
        Me.txtFullName.BackColor = System.Drawing.SystemColors.Window
        Me.txtFullName.Location = New System.Drawing.Point(267, 22)
        Me.txtFullName.MaxLength = 100
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(192, 22)
        Me.txtFullName.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(462, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 14)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "نام خانوادگی/نام :"
        '
        'txtHomeTel
        '
        Me.txtHomeTel.Location = New System.Drawing.Point(323, 266)
        Me.txtHomeTel.MaxLength = 15
        Me.txtHomeTel.Name = "txtHomeTel"
        Me.txtHomeTel.Size = New System.Drawing.Size(137, 22)
        Me.txtHomeTel.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(465, 269)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 14)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "تلفن منزل :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(463, 104)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 14)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "کد ملی :"
        '
        'txtJob
        '
        Me.txtJob.Location = New System.Drawing.Point(272, 200)
        Me.txtJob.MaxLength = 45
        Me.txtJob.Name = "txtJob"
        Me.txtJob.Size = New System.Drawing.Size(187, 22)
        Me.txtJob.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(463, 203)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 14)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "شغل :"
        '
        'txtOfficeTel
        '
        Me.txtOfficeTel.Location = New System.Drawing.Point(323, 345)
        Me.txtOfficeTel.MaxLength = 15
        Me.txtOfficeTel.Name = "txtOfficeTel"
        Me.txtOfficeTel.Size = New System.Drawing.Size(137, 22)
        Me.txtOfficeTel.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(464, 348)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 14)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "تلفن شرکت :"
        '
        'txtRegNumber
        '
        Me.txtRegNumber.Location = New System.Drawing.Point(340, 127)
        Me.txtRegNumber.MaxLength = 20
        Me.txtRegNumber.Name = "txtRegNumber"
        Me.txtRegNumber.Size = New System.Drawing.Size(119, 22)
        Me.txtRegNumber.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(463, 130)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 14)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "ش ش :"
        '
        'richTxtDescription
        '
        Me.richTxtDescription.Location = New System.Drawing.Point(15, 203)
        Me.richTxtDescription.MaxLength = 500
        Me.richTxtDescription.Name = "richTxtDescription"
        Me.richTxtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.richTxtDescription.Size = New System.Drawing.Size(203, 191)
        Me.richTxtDescription.TabIndex = 14
        Me.richTxtDescription.Text = ""
        '
        'ContextMenuImage
        '
        Me.ContextMenuImage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripChangeImage, Me.toolStripDelImage})
        Me.ContextMenuImage.Name = "ContextMenuImage"
        Me.ContextMenuImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuImage.Size = New System.Drawing.Size(146, 48)
        '
        'toolStripChangeImage
        '
        Me.toolStripChangeImage.Image = Global.WFControls.VB.My.Resources.Resources.EditCat
        Me.toolStripChangeImage.Name = "toolStripChangeImage"
        Me.toolStripChangeImage.Size = New System.Drawing.Size(145, 22)
        Me.toolStripChangeImage.Text = "ویرایش تصویر"
        '
        'toolStripDelImage
        '
        Me.toolStripDelImage.Image = Global.WFControls.VB.My.Resources.Resources.DeleteCat
        Me.toolStripDelImage.Name = "toolStripDelImage"
        Me.toolStripDelImage.Size = New System.Drawing.Size(145, 22)
        Me.toolStripDelImage.Text = "حذف تصویر"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(448, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 13)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "اطلاعات شغلی"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pnlImage
        '
        Me.pnlImage.AllowDrop = True
        Me.pnlImage.Controls.Add(Me.picImage)
        Me.pnlImage.Controls.Add(Me.ShapeContainer1)
        Me.pnlImage.Location = New System.Drawing.Point(49, 9)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(122, 146)
        Me.pnlImage.TabIndex = 55
        Me.pnlImage.TabStop = True
        '
        'picImage
        '
        Me.picImage.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.NOPIC
        Me.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picImage.Location = New System.Drawing.Point(7, 5)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(108, 134)
        Me.picImage.TabIndex = 44
        Me.picImage.TabStop = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(122, 146)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.RectangleShape1.BorderWidth = 2
        Me.RectangleShape1.Location = New System.Drawing.Point(5, 4)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(112, 136)
        '
        'txtEmail1
        '
        Me.txtEmail1.Location = New System.Drawing.Point(273, 372)
        Me.txtEmail1.MaxLength = 45
        Me.txtEmail1.Name = "txtEmail1"
        Me.txtEmail1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEmail1.Size = New System.Drawing.Size(187, 22)
        Me.txtEmail1.TabIndex = 11
        '
        'txtNetUser
        '
        Me.txtNetUser.Location = New System.Drawing.Point(273, 432)
        Me.txtNetUser.MaxLength = 45
        Me.txtNetUser.Name = "txtNetUser"
        Me.txtNetUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(37)
        Me.txtNetUser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNetUser.Size = New System.Drawing.Size(187, 22)
        Me.txtNetUser.TabIndex = 12
        Me.txtNetUser.Visible = False
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 511)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(563, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(15, 7)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(537, 13)
        Me.lblMessage.TabIndex = 116
        Me.lblMessage.Text = "lblMessage"
        Me.lblMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(457, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "نحوه تماس"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(326, 458)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(145, 13)
        Me.Label21.TabIndex = 77
        Me.Label21.Text = "ثبت به عنوان کاربر سیستم"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(448, 6)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(92, 13)
        Me.Label22.TabIndex = 78
        Me.Label22.Text = "مشخصات فردی"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(563, 537)
        Me.ShapeContainer2.TabIndex = 79
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape4
        '
        Me.LineShape4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 86
        Me.LineShape4.X2 = 320
        Me.LineShape4.Y1 = 466
        Me.LineShape4.Y2 = 466
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 261
        Me.LineShape3.X2 = 440
        Me.LineShape3.Y1 = 257
        Me.LineShape3.Y2 = 257
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 261
        Me.LineShape2.X2 = 440
        Me.LineShape2.Y1 = 189
        Me.LineShape2.Y2 = 189
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 254
        Me.LineShape1.X2 = 440
        Me.LineShape1.Y1 = 13
        Me.LineShape1.Y2 = 13
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape3.CornerRadius = 5
        Me.RectangleShape3.Location = New System.Drawing.Point(286, 7)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(110, 101)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(38, 6)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(232, 103)
        '
        'cmbContactType
        '
        Me.cmbContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbContactType.FormattingEnabled = True
        Me.cmbContactType.Location = New System.Drawing.Point(338, 155)
        Me.cmbContactType.Name = "cmbContactType"
        Me.cmbContactType.Size = New System.Drawing.Size(121, 22)
        Me.cmbContactType.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(464, 154)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 14)
        Me.Label20.TabIndex = 82
        Me.Label20.Text = "عنوان :"
        '
        'chkIsAdmin
        '
        Me.chkIsAdmin.AutoSize = True
        Me.chkIsAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIsAdmin.Location = New System.Drawing.Point(310, 32)
        Me.chkIsAdmin.Name = "chkIsAdmin"
        Me.chkIsAdmin.Size = New System.Drawing.Size(70, 18)
        Me.chkIsAdmin.TabIndex = 16
        Me.chkIsAdmin.Text = "کاربر مدیر"
        Me.chkIsAdmin.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkIsAdmin.UseVisualStyleBackColor = True
        '
        'chkIsSysUser
        '
        Me.chkIsSysUser.AutoSize = True
        Me.chkIsSysUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIsSysUser.Location = New System.Drawing.Point(290, 62)
        Me.chkIsSysUser.Name = "chkIsSysUser"
        Me.chkIsSysUser.Size = New System.Drawing.Size(90, 18)
        Me.chkIsSysUser.TabIndex = 17
        Me.chkIsSysUser.Text = "کاربر سیستم"
        Me.chkIsSysUser.UseVisualStyleBackColor = True
        '
        'pnlSysUserDetail
        '
        Me.pnlSysUserDetail.Controls.Add(Me.chkChangePass)
        Me.pnlSysUserDetail.Controls.Add(Me.Label17)
        Me.pnlSysUserDetail.Controls.Add(Me.txtPassword)
        Me.pnlSysUserDetail.Controls.Add(Me.Label14)
        Me.pnlSysUserDetail.Controls.Add(Me.Label18)
        Me.pnlSysUserDetail.Controls.Add(Me.txtConfirmPass)
        Me.pnlSysUserDetail.Controls.Add(Me.txtUserName)
        Me.pnlSysUserDetail.Location = New System.Drawing.Point(46, 10)
        Me.pnlSysUserDetail.Name = "pnlSysUserDetail"
        Me.pnlSysUserDetail.Size = New System.Drawing.Size(215, 97)
        Me.pnlSysUserDetail.TabIndex = 86
        '
        'chkChangePass
        '
        Me.chkChangePass.AutoSize = True
        Me.chkChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkChangePass.Location = New System.Drawing.Point(35, 78)
        Me.chkChangePass.Name = "chkChangePass"
        Me.chkChangePass.Size = New System.Drawing.Size(88, 18)
        Me.chkChangePass.TabIndex = 21
        Me.chkChangePass.Text = "تغییر رمز عبور"
        Me.chkChangePass.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkChangePass.UseVisualStyleBackColor = True
        Me.chkChangePass.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(128, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 14)
        Me.Label17.TabIndex = 81
        Me.Label17.Text = "نام کاربری :"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(7, 31)
        Me.txtPassword.MaxLength = 20
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(116, 22)
        Me.txtPassword.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(127, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 14)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "تایید رمز عبور :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(128, 33)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 14)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "رمز عبور :"
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.Location = New System.Drawing.Point(7, 56)
        Me.txtConfirmPass.MaxLength = 20
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPass.Size = New System.Drawing.Size(116, 22)
        Me.txtConfirmPass.TabIndex = 20
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(7, 6)
        Me.txtUserName.MaxLength = 20
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(116, 22)
        Me.txtUserName.TabIndex = 18
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'txtNumberID
        '
        Me.txtNumberID.Location = New System.Drawing.Point(340, 101)
        Me.txtNumberID.MaxLength = 10
        Me.txtNumberID.Name = "txtNumberID"
        Me.txtNumberID.Size = New System.Drawing.Size(119, 22)
        Me.txtNumberID.TabIndex = 3
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
        Me.btnHelp.Location = New System.Drawing.Point(241, 22)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(20, 20)
        Me.btnHelp.TabIndex = 87
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(231, 473)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 32)
        Me.btnSave.TabIndex = 50
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "ذخیره"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.AddPic
        Me.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBrowse.ContextMenuStrip = Me.ContextMenuImage
        Me.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBrowse.FlatAppearance.BorderSize = 0
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Location = New System.Drawing.Point(267, 53)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(65, 97)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.TabStop = False
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'pnlCollapse
        '
        Me.pnlCollapse.Image = Global.WFControls.VB.My.Resources.Resources.expand
        Me.pnlCollapse.Location = New System.Drawing.Point(474, 458)
        Me.pnlCollapse.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCollapse.Name = "pnlCollapse"
        Me.pnlCollapse.Size = New System.Drawing.Size(13, 13)
        Me.pnlCollapse.TabIndex = 88
        Me.pnlCollapse.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlSysUserDetail)
        Me.Panel1.Controls.Add(Me.chkIsSysUser)
        Me.Panel1.Controls.Add(Me.chkIsAdmin)
        Me.Panel1.Controls.Add(Me.ShapeContainer3)
        Me.Panel1.Location = New System.Drawing.Point(49, 474)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(438, 0)
        Me.Panel1.TabIndex = 89
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2, Me.RectangleShape3})
        Me.ShapeContainer3.Size = New System.Drawing.Size(438, 0)
        Me.ShapeContainer3.TabIndex = 87
        Me.ShapeContainer3.TabStop = False
        '
        'txtBirthday
        '
        Me.txtBirthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtBirthday.Location = New System.Drawing.Point(339, 72)
        Me.txtBirthday.Name = "txtBirthday"
        Me.txtBirthday.Size = New System.Drawing.Size(121, 27)
        Me.txtBirthday.TabIndex = 2
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(204, 436)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(24, 14)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "رزرو"
        Me.Label23.Visible = False
        '
        'txtNetPassword
        '
        Me.txtNetPassword.Location = New System.Drawing.Point(14, 431)
        Me.txtNetPassword.MaxLength = 45
        Me.txtNetPassword.Name = "txtNetPassword"
        Me.txtNetPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(37)
        Me.txtNetPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNetPassword.Size = New System.Drawing.Size(187, 22)
        Me.txtNetPassword.TabIndex = 12
        Me.txtNetPassword.Visible = False
        '
        'ContactAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.txtNetPassword)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlCollapse)
        Me.Controls.Add(Me.txtBirthday)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.cmbContactType)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.txtNetUser)
        Me.Controls.Add(Me.txtEmail1)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.richTxtDescription)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtRegNumber)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtOfficeTel)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtJob)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtNumberID)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtHomeTel)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtFatherName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCompanyName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCellphone)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.lable1)
        Me.Controls.Add(Me.ShapeContainer2)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "ContactAdd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(563, 537)
        Me.ContextMenuImage.ResumeLayout(False)
        Me.pnlImage.ResumeLayout(False)
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.pnlSysUserDetail.ResumeLayout(False)
        Me.pnlSysUserDetail.PerformLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lable1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCellphone As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFatherName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtHomeTel As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtJob As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtOfficeTel As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRegNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents richTxtDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pnlImage As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuImage As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents toolStripChangeImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripDelImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtEmail1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNetUser As System.Windows.Forms.TextBox
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents cmbContactType As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chkIsAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsSysUser As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSysUserDetail As System.Windows.Forms.Panel
    Friend WithEvents chkChangePass As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents txtBirthday As WFControls.VB.RmanShamsiDate
    Friend WithEvents txtNumberID As System.Windows.Forms.TextBox
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents pnlCollapse As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer3 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtNetPassword As System.Windows.Forms.TextBox

End Class
