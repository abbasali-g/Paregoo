<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Moshavere
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
        Dim flow1 As System.Windows.Forms.FlowLayoutPanel
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.TimingTime = New System.Windows.Forms.DateTimePicker()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlType = New System.Windows.Forms.Panel()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlReminder = New System.Windows.Forms.Panel()
        Me.txtReminder = New System.Windows.Forms.TextBox()
        Me.cmbReminderType = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbTimingStatus = New System.Windows.Forms.ComboBox()
        Me.lblSatus = New System.Windows.Forms.Label()
        Me.txtDuration = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lstFiles = New System.Windows.Forms.DataGridView()
        Me.gvClmImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.gvClmTitle = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.gvClmName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvclmnImageID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvclmFileID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.picAttachment = New System.Windows.Forms.Button()
        Me.txtVakil = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMoshavere = New System.Windows.Forms.TextBox()
        Me.pnlText = New System.Windows.Forms.Panel()
        Me.rdbTypeNS = New System.Windows.Forms.RadioButton()
        Me.rdbTypeS = New System.Windows.Forms.RadioButton()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tooltipDelFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.TimingDate = New WFControls.VB.RmanShamsiDate()
        Me.UcContacts1 = New WFControls.VB.ucContacts()
        Me.AmountControl1 = New WFControls.VB.AmountControl()
        flow1 = New System.Windows.Forms.FlowLayoutPanel()
        flow1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlType.SuspendLayout()
        Me.pnlReminder.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.lstFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlText.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'flow1
        '
        flow1.AutoSize = True
        flow1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        flow1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        flow1.Controls.Add(Me.pnlHeader)
        flow1.Controls.Add(Me.pnlType)
        flow1.Controls.Add(Me.pnlReminder)
        flow1.Controls.Add(Me.Panel1)
        flow1.Controls.Add(Me.pnlText)
        flow1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        flow1.Location = New System.Drawing.Point(0, 1)
        flow1.Margin = New System.Windows.Forms.Padding(0)
        flow1.Name = "flow1"
        flow1.Size = New System.Drawing.Size(508, 467)
        flow1.TabIndex = 54
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.TimingDate)
        Me.pnlHeader.Controls.Add(Me.TimingTime)
        Me.pnlHeader.Controls.Add(Me.txtTitle)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Location = New System.Drawing.Point(1, 1)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(506, 54)
        Me.pnlHeader.TabIndex = 0
        '
        'TimingTime
        '
        Me.TimingTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimingTime.Location = New System.Drawing.Point(6, 27)
        Me.TimingTime.Name = "TimingTime"
        Me.TimingTime.ShowUpDown = True
        Me.TimingTime.Size = New System.Drawing.Size(116, 22)
        Me.TimingTime.TabIndex = 2
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(6, 2)
        Me.txtTitle.MaxLength = 100
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(401, 22)
        Me.txtTitle.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(410, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "عنوان :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(126, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 14)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "زمان :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(411, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 14)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "تاریخ :"
        '
        'pnlType
        '
        Me.pnlType.Controls.Add(Me.txtNumber)
        Me.pnlType.Controls.Add(Me.Label6)
        Me.pnlType.Location = New System.Drawing.Point(1, 57)
        Me.pnlType.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlType.Name = "pnlType"
        Me.pnlType.Size = New System.Drawing.Size(506, 26)
        Me.pnlType.TabIndex = 60
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(283, 2)
        Me.txtNumber.MaxLength = 30
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(121, 22)
        Me.txtNumber.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(408, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 14)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "شماره :"
        '
        'pnlReminder
        '
        Me.pnlReminder.Controls.Add(Me.txtReminder)
        Me.pnlReminder.Controls.Add(Me.cmbReminderType)
        Me.pnlReminder.Controls.Add(Me.Label14)
        Me.pnlReminder.Controls.Add(Me.cmbTimingStatus)
        Me.pnlReminder.Controls.Add(Me.lblSatus)
        Me.pnlReminder.Controls.Add(Me.txtDuration)
        Me.pnlReminder.Controls.Add(Me.Label16)
        Me.pnlReminder.Controls.Add(Me.Label17)
        Me.pnlReminder.Controls.Add(Me.Label18)
        Me.pnlReminder.Location = New System.Drawing.Point(1, 85)
        Me.pnlReminder.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlReminder.Name = "pnlReminder"
        Me.pnlReminder.Size = New System.Drawing.Size(506, 51)
        Me.pnlReminder.TabIndex = 64
        '
        'txtReminder
        '
        Me.txtReminder.Location = New System.Drawing.Point(378, 1)
        Me.txtReminder.MaxLength = 3
        Me.txtReminder.Name = "txtReminder"
        Me.txtReminder.Size = New System.Drawing.Size(37, 22)
        Me.txtReminder.TabIndex = 4
        Me.txtReminder.Text = "0"
        '
        'cmbReminderType
        '
        Me.cmbReminderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReminderType.FormattingEnabled = True
        Me.cmbReminderType.Items.AddRange(New Object() {"دقیقه", "ساعت ", "روز"})
        Me.cmbReminderType.Location = New System.Drawing.Point(319, 1)
        Me.cmbReminderType.Name = "cmbReminderType"
        Me.cmbReminderType.Size = New System.Drawing.Size(56, 22)
        Me.cmbReminderType.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(25, 4)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 14)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "دقیقه"
        '
        'cmbTimingStatus
        '
        Me.cmbTimingStatus.DisplayMember = "settingName"
        Me.cmbTimingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTimingStatus.FormattingEnabled = True
        Me.cmbTimingStatus.Location = New System.Drawing.Point(319, 27)
        Me.cmbTimingStatus.Name = "cmbTimingStatus"
        Me.cmbTimingStatus.Size = New System.Drawing.Size(96, 22)
        Me.cmbTimingStatus.TabIndex = 7
        Me.cmbTimingStatus.ValueMember = "settingValue"
        '
        'lblSatus
        '
        Me.lblSatus.AutoSize = True
        Me.lblSatus.Location = New System.Drawing.Point(418, 30)
        Me.lblSatus.Name = "lblSatus"
        Me.lblSatus.Size = New System.Drawing.Size(50, 14)
        Me.lblSatus.TabIndex = 19
        Me.lblSatus.Text = "وضعیت :"
        '
        'txtDuration
        '
        Me.txtDuration.Location = New System.Drawing.Point(63, 0)
        Me.txtDuration.MaxLength = 3
        Me.txtDuration.Name = "txtDuration"
        Me.txtDuration.Size = New System.Drawing.Size(67, 22)
        Me.txtDuration.TabIndex = 6
        Me.txtDuration.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(132, 4)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 14)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "مدت زمان انجام :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(282, 4)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 14)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = " مانده"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(417, 4)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 14)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "زمان یادآوری :"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lstFiles)
        Me.Panel1.Controls.Add(Me.UcContacts1)
        Me.Panel1.Controls.Add(Me.picAttachment)
        Me.Panel1.Controls.Add(Me.AmountControl1)
        Me.Panel1.Controls.Add(Me.txtVakil)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtMoshavere)
        Me.Panel1.Location = New System.Drawing.Point(0, 137)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(508, 130)
        Me.Panel1.TabIndex = 55
        '
        'lstFiles
        '
        Me.lstFiles.AllowDrop = True
        Me.lstFiles.AllowUserToAddRows = False
        Me.lstFiles.AllowUserToResizeColumns = False
        Me.lstFiles.AllowUserToResizeRows = False
        Me.lstFiles.BackgroundColor = System.Drawing.Color.White
        Me.lstFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lstFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(61, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lstFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.lstFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lstFiles.ColumnHeadersVisible = False
        Me.lstFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvClmImage, Me.gvClmTitle, Me.gvClmName, Me.gvclmnImageID, Me.gvclmFileID})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstFiles.DefaultCellStyle = DataGridViewCellStyle2
        Me.lstFiles.Location = New System.Drawing.Point(7, 73)
        Me.lstFiles.MultiSelect = False
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.ReadOnly = True
        Me.lstFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.lstFiles.RowHeadersVisible = False
        Me.lstFiles.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White
        Me.lstFiles.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lstFiles.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lstFiles.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.lstFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lstFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.lstFiles.Size = New System.Drawing.Size(401, 54)
        Me.lstFiles.TabIndex = 66
        '
        'gvClmImage
        '
        Me.gvClmImage.DataPropertyName = "AttachmentImage"
        Me.gvClmImage.HeaderText = "Column1"
        Me.gvClmImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.gvClmImage.Name = "gvClmImage"
        Me.gvClmImage.ReadOnly = True
        Me.gvClmImage.Width = 16
        '
        'gvClmTitle
        '
        Me.gvClmTitle.ActiveLinkColor = System.Drawing.Color.Black
        Me.gvClmTitle.DataPropertyName = "timeTitle"
        Me.gvClmTitle.HeaderText = ""
        Me.gvClmTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.gvClmTitle.LinkColor = System.Drawing.Color.Black
        Me.gvClmTitle.Name = "gvClmTitle"
        Me.gvClmTitle.ReadOnly = True
        Me.gvClmTitle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvClmTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.gvClmTitle.VisitedLinkColor = System.Drawing.Color.Black
        Me.gvClmTitle.Width = 440
        '
        'gvClmName
        '
        Me.gvClmName.DataPropertyName = "custFullName"
        Me.gvClmName.HeaderText = ""
        Me.gvClmName.Name = "gvClmName"
        Me.gvClmName.ReadOnly = True
        Me.gvClmName.Width = 5
        '
        'gvclmnImageID
        '
        Me.gvclmnImageID.HeaderText = ""
        Me.gvclmnImageID.Name = "gvclmnImageID"
        Me.gvclmnImageID.ReadOnly = True
        Me.gvclmnImageID.Visible = False
        '
        'gvclmFileID
        '
        Me.gvclmFileID.HeaderText = ""
        Me.gvclmFileID.Name = "gvclmFileID"
        Me.gvclmFileID.ReadOnly = True
        Me.gvclmFileID.Visible = False
        Me.gvclmFileID.Width = 5
        '
        'picAttachment
        '
        Me.picAttachment.AllowDrop = True
        Me.picAttachment.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.browse2
        Me.picAttachment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picAttachment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picAttachment.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.picAttachment.FlatAppearance.BorderSize = 0
        Me.picAttachment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.picAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.picAttachment.Location = New System.Drawing.Point(436, 100)
        Me.picAttachment.Name = "picAttachment"
        Me.picAttachment.Size = New System.Drawing.Size(24, 24)
        Me.picAttachment.TabIndex = 12
        Me.picAttachment.UseVisualStyleBackColor = True
        '
        'txtVakil
        '
        Me.txtVakil.AllowDrop = True
        Me.txtVakil.BackColor = System.Drawing.Color.White
        Me.txtVakil.Location = New System.Drawing.Point(233, 3)
        Me.txtVakil.Name = "txtVakil"
        Me.txtVakil.ReadOnly = True
        Me.txtVakil.Size = New System.Drawing.Size(146, 22)
        Me.txtVakil.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(134, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 14)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "مبلغ مشاوره :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(412, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 14)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "فایلهای پیوست :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(387, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 14)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "مشاوره دهنده(وکیل):"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(383, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 14)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "مشاوره گیرنده(موکل) :"
        '
        'txtMoshavere
        '
        Me.txtMoshavere.AllowDrop = True
        Me.txtMoshavere.BackColor = System.Drawing.Color.White
        Me.txtMoshavere.Location = New System.Drawing.Point(234, 28)
        Me.txtMoshavere.Name = "txtMoshavere"
        Me.txtMoshavere.ReadOnly = True
        Me.txtMoshavere.Size = New System.Drawing.Size(146, 22)
        Me.txtMoshavere.TabIndex = 10
        '
        'pnlText
        '
        Me.pnlText.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlText.Controls.Add(Me.rdbTypeNS)
        Me.pnlText.Controls.Add(Me.rdbTypeS)
        Me.pnlText.Controls.Add(Me.btnPrint)
        Me.pnlText.Controls.Add(Me.btnDelete)
        Me.pnlText.Controls.Add(Me.btnSave)
        Me.pnlText.Controls.Add(Me.txtDescription)
        Me.pnlText.Controls.Add(Me.Label10)
        Me.pnlText.Location = New System.Drawing.Point(4, 268)
        Me.pnlText.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlText.Name = "pnlText"
        Me.pnlText.Size = New System.Drawing.Size(500, 198)
        Me.pnlText.TabIndex = 56
        '
        'rdbTypeNS
        '
        Me.rdbTypeNS.AutoSize = True
        Me.rdbTypeNS.Location = New System.Drawing.Point(140, 3)
        Me.rdbTypeNS.Name = "rdbTypeNS"
        Me.rdbTypeNS.Size = New System.Drawing.Size(79, 18)
        Me.rdbTypeNS.TabIndex = 0
        Me.rdbTypeNS.Text = "انجام شده"
        Me.rdbTypeNS.UseVisualStyleBackColor = True
        Me.rdbTypeNS.Visible = False
        '
        'rdbTypeS
        '
        Me.rdbTypeS.AutoSize = True
        Me.rdbTypeS.Checked = True
        Me.rdbTypeS.Location = New System.Drawing.Point(16, 3)
        Me.rdbTypeS.Name = "rdbTypeS"
        Me.rdbTypeS.Size = New System.Drawing.Size(108, 18)
        Me.rdbTypeS.TabIndex = 1
        Me.rdbTypeS.TabStop = True
        Me.rdbTypeS.Text = "برنامه ریزی شده"
        Me.rdbTypeS.UseVisualStyleBackColor = True
        Me.rdbTypeS.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(213, 157)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 32)
        Me.btnPrint.TabIndex = 15
        Me.btnPrint.TabStop = False
        Me.btnPrint.Text = "ذخیره و چاپ"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(60, 157)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 32)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "حذف"
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(362, 157)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 32)
        Me.btnSave.TabIndex = 14
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "ذخیره"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(7, 21)
        Me.txtDescription.MaxLength = 500
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(478, 130)
        Me.txtDescription.TabIndex = 13
        Me.txtDescription.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(412, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "توضیحات  :"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tooltipDelFile})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(100, 26)
        '
        'tooltipDelFile
        '
        Me.tooltipDelFile.Image = Global.WFControls.VB.My.Resources.Resources.DeleteCat
        Me.tooltipDelFile.Name = "tooltipDelFile"
        Me.tooltipDelFile.Size = New System.Drawing.Size(99, 22)
        Me.tooltipDelFile.Text = "حذف"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Black
        Me.lblMessage.Location = New System.Drawing.Point(6, 504)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(487, 13)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'TimingDate
        '
        Me.TimingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TimingDate.Location = New System.Drawing.Point(286, 25)
        Me.TimingDate.Name = "TimingDate"
        Me.TimingDate.Size = New System.Drawing.Size(121, 27)
        Me.TimingDate.TabIndex = 1
        '
        'UcContacts1
        '
        Me.UcContacts1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.UcContacts1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcContacts1.Location = New System.Drawing.Point(7, 3)
        Me.UcContacts1.Name = "UcContacts1"
        Me.UcContacts1.Size = New System.Drawing.Size(234, 23)
        Me.UcContacts1.TabIndex = 65
        '
        'AmountControl1
        '
        Me.AmountControl1.Amount = 0.0R
        Me.AmountControl1.Location = New System.Drawing.Point(7, 4)
        Me.AmountControl1.Name = "AmountControl1"
        Me.AmountControl1.Size = New System.Drawing.Size(121, 22)
        Me.AmountControl1.TabIndex = 9
        '
        'Moshavere
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(flow1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "Moshavere"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(508, 529)
        flow1.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlType.ResumeLayout(False)
        Me.pnlType.PerformLayout()
        Me.pnlReminder.ResumeLayout(False)
        Me.pnlReminder.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.lstFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlText.ResumeLayout(False)
        Me.pnlText.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents TimingTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMoshavere As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pnlType As System.Windows.Forms.Panel
    Friend WithEvents cmbTimingStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TimingDate As WFControls.VB.RmanShamsiDate
    Friend WithEvents AmountControl1 As WFControls.VB.AmountControl
    Friend WithEvents picAttachment As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tooltipDelFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlText As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlReminder As System.Windows.Forms.Panel
    Friend WithEvents cmbReminderType As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDuration As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents rdbTypeS As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTypeNS As System.Windows.Forms.RadioButton
    Friend WithEvents txtVakil As System.Windows.Forms.TextBox
    Friend WithEvents lblSatus As System.Windows.Forms.Label
    Friend WithEvents txtReminder As System.Windows.Forms.TextBox
    Friend WithEvents UcContacts1 As WFControls.VB.ucContacts
    Friend WithEvents lstFiles As System.Windows.Forms.DataGridView
    Friend WithEvents gvClmImage As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents gvClmTitle As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents gvClmName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvclmnImageID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvclmFileID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox


End Class
