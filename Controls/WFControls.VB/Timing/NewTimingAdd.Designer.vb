<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewTimingAdd
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlType = New System.Windows.Forms.Panel()
        Me.TimingTime = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TimingDate = New WFControls.VB.RmanShamsiDate()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTimingType = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStrip_Del_ALL = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlReminder = New System.Windows.Forms.Panel()
        Me.cmbReminderType = New System.Windows.Forms.ComboBox()
        Me.cmbTimingStatus = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDuration = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReminder = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlReciever = New System.Windows.Forms.Panel()
        Me.rdbTypeNS = New System.Windows.Forms.RadioButton()
        Me.rdbTypeS = New System.Windows.Forms.RadioButton()
        Me.picAttachment = New System.Windows.Forms.Button()
        Me.lblSatus = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.lstFiles = New System.Windows.Forms.DataGridView()
        Me.gvClmImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.gvClmTitle = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.gvClmName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvclmnImageID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lstTargetSource = New System.Windows.Forms.ListView()
        Me.pnlText = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tooltipDelFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        flow1 = New System.Windows.Forms.FlowLayoutPanel()
        flow1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlType.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlReminder.SuspendLayout()
        Me.pnlReciever.SuspendLayout()
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
        flow1.Controls.Add(Me.pnlReciever)
        flow1.Controls.Add(Me.pnlText)
        flow1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        flow1.Location = New System.Drawing.Point(0, 0)
        flow1.Margin = New System.Windows.Forms.Padding(0)
        flow1.Name = "flow1"
        flow1.Size = New System.Drawing.Size(502, 508)
        flow1.TabIndex = 54
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.txtTitle)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Location = New System.Drawing.Point(4, 1)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(497, 24)
        Me.pnlHeader.TabIndex = 0
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(12, 1)
        Me.txtTitle.MaxLength = 100
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(400, 22)
        Me.txtTitle.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(416, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "عنوان :"
        '
        'pnlType
        '
        Me.pnlType.Controls.Add(Me.TimingTime)
        Me.pnlType.Controls.Add(Me.Label2)
        Me.pnlType.Controls.Add(Me.TimingDate)
        Me.pnlType.Controls.Add(Me.txtNumber)
        Me.pnlType.Controls.Add(Me.Label1)
        Me.pnlType.Controls.Add(Me.Label5)
        Me.pnlType.Controls.Add(Me.Label6)
        Me.pnlType.Controls.Add(Me.cmbTimingType)
        Me.pnlType.Location = New System.Drawing.Point(4, 27)
        Me.pnlType.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlType.Name = "pnlType"
        Me.pnlType.Size = New System.Drawing.Size(497, 54)
        Me.pnlType.TabIndex = 60
        '
        'TimingTime
        '
        Me.TimingTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TimingTime.Location = New System.Drawing.Point(49, 26)
        Me.TimingTime.Name = "TimingTime"
        Me.TimingTime.ShowUpDown = True
        Me.TimingTime.Size = New System.Drawing.Size(116, 22)
        Me.TimingTime.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 14)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "زمان :"
        '
        'TimingDate
        '
        Me.TimingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TimingDate.Location = New System.Drawing.Point(291, 25)
        Me.TimingDate.Name = "TimingDate"
        Me.TimingDate.Size = New System.Drawing.Size(121, 27)
        Me.TimingDate.TabIndex = 3
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(12, 1)
        Me.txtNumber.MaxLength = 30
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(153, 22)
        Me.txtNumber.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(414, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "تاریخ یادآوری :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(168, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 14)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "تاریخ و شماره نامه :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(415, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 14)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "نوع  :"
        '
        'cmbTimingType
        '
        Me.cmbTimingType.ContextMenuStrip = Me.ContextMenuStrip1
        Me.cmbTimingType.DisplayMember = "settingName"
        Me.cmbTimingType.FormattingEnabled = True
        Me.cmbTimingType.Location = New System.Drawing.Point(284, 0)
        Me.cmbTimingType.Name = "cmbTimingType"
        Me.cmbTimingType.Size = New System.Drawing.Size(128, 22)
        Me.cmbTimingType.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.cmbTimingType, "آیتم های این لیست قابل حذف/اضافه است")
        Me.cmbTimingType.ValueMember = "settingValue"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrip_Del_ALL})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(103, 26)
        '
        'ToolStrip_Del_ALL
        '
        Me.ToolStrip_Del_ALL.Image = Global.WFControls.VB.My.Resources.Resources.DeleteCat
        Me.ToolStrip_Del_ALL.Name = "ToolStrip_Del_ALL"
        Me.ToolStrip_Del_ALL.Size = New System.Drawing.Size(102, 22)
        Me.ToolStrip_Del_ALL.Text = "حذف "
        '
        'pnlReminder
        '
        Me.pnlReminder.Controls.Add(Me.cmbReminderType)
        Me.pnlReminder.Controls.Add(Me.cmbTimingStatus)
        Me.pnlReminder.Controls.Add(Me.Label11)
        Me.pnlReminder.Controls.Add(Me.txtDuration)
        Me.pnlReminder.Controls.Add(Me.Label12)
        Me.pnlReminder.Controls.Add(Me.Label4)
        Me.pnlReminder.Controls.Add(Me.txtReminder)
        Me.pnlReminder.Controls.Add(Me.Label7)
        Me.pnlReminder.Controls.Add(Me.Label9)
        Me.pnlReminder.Location = New System.Drawing.Point(1, 83)
        Me.pnlReminder.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlReminder.Name = "pnlReminder"
        Me.pnlReminder.Size = New System.Drawing.Size(500, 62)
        Me.pnlReminder.TabIndex = 1
        '
        'cmbReminderType
        '
        Me.cmbReminderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReminderType.FormattingEnabled = True
        Me.cmbReminderType.Items.AddRange(New Object() {"دقیقه", "ساعت ", "روز"})
        Me.cmbReminderType.Location = New System.Drawing.Point(308, 3)
        Me.cmbReminderType.Name = "cmbReminderType"
        Me.cmbReminderType.Size = New System.Drawing.Size(63, 22)
        Me.cmbReminderType.TabIndex = 6
        '
        'cmbTimingStatus
        '
        Me.cmbTimingStatus.DisplayMember = "settingName"
        Me.cmbTimingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTimingStatus.FormattingEnabled = True
        Me.cmbTimingStatus.Location = New System.Drawing.Point(308, 27)
        Me.cmbTimingStatus.Name = "cmbTimingStatus"
        Me.cmbTimingStatus.Size = New System.Drawing.Size(107, 22)
        Me.cmbTimingStatus.TabIndex = 8
        Me.cmbTimingStatus.ValueMember = "settingValue"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(55, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 14)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "دقیقه"
        '
        'txtDuration
        '
        Me.txtDuration.Location = New System.Drawing.Point(99, 3)
        Me.txtDuration.MaxLength = 3
        Me.txtDuration.Name = "txtDuration"
        Me.txtDuration.Size = New System.Drawing.Size(67, 22)
        Me.txtDuration.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(171, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 14)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "مدت زمان انجام :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(273, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 14)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = " مانده"
        '
        'txtReminder
        '
        Me.txtReminder.Location = New System.Drawing.Point(378, 3)
        Me.txtReminder.MaxLength = 3
        Me.txtReminder.Name = "txtReminder"
        Me.txtReminder.Size = New System.Drawing.Size(37, 22)
        Me.txtReminder.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(416, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 14)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "وضعیت:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(416, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 14)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "زمان یادآوری :"
        '
        'pnlReciever
        '
        Me.pnlReciever.Controls.Add(Me.rdbTypeNS)
        Me.pnlReciever.Controls.Add(Me.rdbTypeS)
        Me.pnlReciever.Controls.Add(Me.picAttachment)
        Me.pnlReciever.Controls.Add(Me.lblSatus)
        Me.pnlReciever.Controls.Add(Me.btnHelp)
        Me.pnlReciever.Controls.Add(Me.lstFiles)
        Me.pnlReciever.Controls.Add(Me.Label13)
        Me.pnlReciever.Controls.Add(Me.lstTargetSource)
        Me.pnlReciever.Location = New System.Drawing.Point(1, 147)
        Me.pnlReciever.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlReciever.Name = "pnlReciever"
        Me.pnlReciever.Size = New System.Drawing.Size(500, 220)
        Me.pnlReciever.TabIndex = 63
        '
        'rdbTypeNS
        '
        Me.rdbTypeNS.AutoSize = True
        Me.rdbTypeNS.Location = New System.Drawing.Point(171, 0)
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
        Me.rdbTypeS.Location = New System.Drawing.Point(21, 0)
        Me.rdbTypeS.Name = "rdbTypeS"
        Me.rdbTypeS.Size = New System.Drawing.Size(108, 18)
        Me.rdbTypeS.TabIndex = 1
        Me.rdbTypeS.TabStop = True
        Me.rdbTypeS.Text = "برنامه ریزی شده"
        Me.rdbTypeS.UseVisualStyleBackColor = True
        Me.rdbTypeS.Visible = False
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
        Me.picAttachment.Location = New System.Drawing.Point(361, 140)
        Me.picAttachment.Name = "picAttachment"
        Me.picAttachment.Size = New System.Drawing.Size(24, 17)
        Me.picAttachment.TabIndex = 11
        Me.picAttachment.UseVisualStyleBackColor = True
        '
        'lblSatus
        '
        Me.lblSatus.AutoSize = True
        Me.lblSatus.Location = New System.Drawing.Point(427, 8)
        Me.lblSatus.Name = "lblSatus"
        Me.lblSatus.Size = New System.Drawing.Size(55, 14)
        Me.lblSatus.TabIndex = 19
        Me.lblSatus.Text = "ارجاع به :"
        '
        'btnHelp
        '
        Me.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHelp.FlatAppearance.BorderSize = 0
        Me.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = Global.WFControls.VB.My.Resources.Resources.HelpIcon3
        Me.btnHelp.Location = New System.Drawing.Point(362, 4)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(17, 18)
        Me.btnHelp.TabIndex = 64
        Me.btnHelp.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(61, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lstFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.lstFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lstFiles.ColumnHeadersVisible = False
        Me.lstFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvClmImage, Me.gvClmTitle, Me.gvClmName, Me.gvclmnImageID})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstFiles.DefaultCellStyle = DataGridViewCellStyle4
        Me.lstFiles.Location = New System.Drawing.Point(21, 167)
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
        Me.lstFiles.Size = New System.Drawing.Size(461, 45)
        Me.lstFiles.TabIndex = 6
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(391, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 14)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "فایلهای پیوست :"
        '
        'lstTargetSource
        '
        Me.lstTargetSource.CheckBoxes = True
        Me.lstTargetSource.Location = New System.Drawing.Point(21, 25)
        Me.lstTargetSource.Name = "lstTargetSource"
        Me.lstTargetSource.RightToLeftLayout = True
        Me.lstTargetSource.Size = New System.Drawing.Size(461, 120)
        Me.lstTargetSource.TabIndex = 10
        Me.lstTargetSource.UseCompatibleStateImageBehavior = False
        Me.lstTargetSource.View = System.Windows.Forms.View.List
        '
        'pnlText
        '
        Me.pnlText.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlText.Controls.Add(Me.lblMessage)
        Me.pnlText.Controls.Add(Me.btnDelete)
        Me.pnlText.Controls.Add(Me.btnSave)
        Me.pnlText.Controls.Add(Me.txtDescription)
        Me.pnlText.Controls.Add(Me.Label10)
        Me.pnlText.Location = New System.Drawing.Point(1, 369)
        Me.pnlText.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlText.Name = "pnlText"
        Me.pnlText.Size = New System.Drawing.Size(500, 138)
        Me.pnlText.TabIndex = 56
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Black
        Me.lblMessage.Location = New System.Drawing.Point(239, 105)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(200, 13)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(134, 72)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 32)
        Me.btnDelete.TabIndex = 14
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
        Me.btnSave.Location = New System.Drawing.Point(339, 72)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 32)
        Me.btnSave.TabIndex = 13
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "ذخیره"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(21, 20)
        Me.txtDescription.MaxLength = 500
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(460, 50)
        Me.txtDescription.TabIndex = 12
        Me.txtDescription.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(422, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "توضیحات  :"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tooltipDelFile})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
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
        'NewTimingAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Controls.Add(flow1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "NewTimingAdd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(502, 508)
        flow1.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlType.ResumeLayout(False)
        Me.pnlType.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlReminder.ResumeLayout(False)
        Me.pnlReminder.PerformLayout()
        Me.pnlReciever.ResumeLayout(False)
        Me.pnlReciever.PerformLayout()
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
    Friend WithEvents pnlType As System.Windows.Forms.Panel
    Friend WithEvents cmbTimingStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblSatus As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTimingType As System.Windows.Forms.ComboBox
    Friend WithEvents pnlReciever As System.Windows.Forms.Panel
    Friend WithEvents lstTargetSource As System.Windows.Forms.ListView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlReminder As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDuration As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReminder As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStrip_Del_ALL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimingDate As WFControls.VB.RmanShamsiDate
    Friend WithEvents lstFiles As System.Windows.Forms.DataGridView
    Friend WithEvents picAttachment As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tooltipDelFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlText As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rdbTypeNS As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTypeS As System.Windows.Forms.RadioButton
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbReminderType As System.Windows.Forms.ComboBox
    Friend WithEvents gvClmImage As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents gvClmTitle As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents gvClmName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvclmnImageID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label


End Class
