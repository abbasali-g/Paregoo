<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GuiltSearch
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GuiltSearch))
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgvGuilts = New System.Windows.Forms.DataGridView()
        Me.txttgDescription = New System.Windows.Forms.TextBox()
        Me.txttgRelatedRules = New System.Windows.Forms.TextBox()
        Me.txttgRulePassedDate = New System.Windows.Forms.TextBox()
        Me.txttgRuleDef = New System.Windows.Forms.TextBox()
        Me.txttgRuleTile = New System.Windows.Forms.TextBox()
        Me.txttgPenalty = New System.Windows.Forms.TextBox()
        Me.txttgTitle = New System.Windows.Forms.TextBox()
        Me.ll = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btnSearch = New System.Windows.Forms.Button()
        CType(Me.dgvGuilts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitle.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.AcceptsReturn = True
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSearch.Location = New System.Drawing.Point(317, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSearch.Size = New System.Drawing.Size(331, 21)
        Me.txtSearch.TabIndex = 2
        '
        'dgvGuilts
        '
        Me.dgvGuilts.AllowDrop = True
        Me.dgvGuilts.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(61, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGuilts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGuilts.EnableHeadersVisualStyles = False
        Me.dgvGuilts.Location = New System.Drawing.Point(12, 39)
        Me.dgvGuilts.MultiSelect = False
        Me.dgvGuilts.Name = "dgvGuilts"
        Me.dgvGuilts.ReadOnly = True
        Me.dgvGuilts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGuilts.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGuilts.RowHeadersVisible = False
        Me.dgvGuilts.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgvGuilts.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvGuilts.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.dgvGuilts.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvGuilts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvGuilts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGuilts.Size = New System.Drawing.Size(634, 203)
        Me.dgvGuilts.TabIndex = 6
        '
        'txttgDescription
        '
        Me.txttgDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txttgDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.txttgDescription.Location = New System.Drawing.Point(21, 376)
        Me.txttgDescription.Multiline = True
        Me.txttgDescription.Name = "txttgDescription"
        Me.txttgDescription.ReadOnly = True
        Me.txttgDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txttgDescription.Size = New System.Drawing.Size(516, 34)
        Me.txttgDescription.TabIndex = 15
        '
        'txttgRelatedRules
        '
        Me.txttgRelatedRules.BackColor = System.Drawing.SystemColors.Window
        Me.txttgRelatedRules.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.txttgRelatedRules.Location = New System.Drawing.Point(21, 347)
        Me.txttgRelatedRules.Multiline = True
        Me.txttgRelatedRules.Name = "txttgRelatedRules"
        Me.txttgRelatedRules.ReadOnly = True
        Me.txttgRelatedRules.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txttgRelatedRules.Size = New System.Drawing.Size(220, 20)
        Me.txttgRelatedRules.TabIndex = 14
        '
        'txttgRulePassedDate
        '
        Me.txttgRulePassedDate.BackColor = System.Drawing.SystemColors.Window
        Me.txttgRulePassedDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.txttgRulePassedDate.Location = New System.Drawing.Point(317, 417)
        Me.txttgRulePassedDate.Multiline = True
        Me.txttgRulePassedDate.Name = "txttgRulePassedDate"
        Me.txttgRulePassedDate.ReadOnly = True
        Me.txttgRulePassedDate.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txttgRulePassedDate.Size = New System.Drawing.Size(220, 20)
        Me.txttgRulePassedDate.TabIndex = 13
        '
        'txttgRuleDef
        '
        Me.txttgRuleDef.BackColor = System.Drawing.SystemColors.Window
        Me.txttgRuleDef.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.txttgRuleDef.Location = New System.Drawing.Point(21, 416)
        Me.txttgRuleDef.Multiline = True
        Me.txttgRuleDef.Name = "txttgRuleDef"
        Me.txttgRuleDef.ReadOnly = True
        Me.txttgRuleDef.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txttgRuleDef.Size = New System.Drawing.Size(220, 20)
        Me.txttgRuleDef.TabIndex = 11
        '
        'txttgRuleTile
        '
        Me.txttgRuleTile.BackColor = System.Drawing.SystemColors.Window
        Me.txttgRuleTile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.txttgRuleTile.Location = New System.Drawing.Point(317, 347)
        Me.txttgRuleTile.Multiline = True
        Me.txttgRuleTile.Name = "txttgRuleTile"
        Me.txttgRuleTile.ReadOnly = True
        Me.txttgRuleTile.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txttgRuleTile.Size = New System.Drawing.Size(220, 20)
        Me.txttgRuleTile.TabIndex = 9
        '
        'txttgPenalty
        '
        Me.txttgPenalty.BackColor = System.Drawing.SystemColors.Window
        Me.txttgPenalty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.txttgPenalty.Location = New System.Drawing.Point(22, 305)
        Me.txttgPenalty.Multiline = True
        Me.txttgPenalty.Name = "txttgPenalty"
        Me.txttgPenalty.ReadOnly = True
        Me.txttgPenalty.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txttgPenalty.Size = New System.Drawing.Size(516, 34)
        Me.txttgPenalty.TabIndex = 8
        '
        'txttgTitle
        '
        Me.txttgTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txttgTitle.Location = New System.Drawing.Point(22, 265)
        Me.txttgTitle.Multiline = True
        Me.txttgTitle.Name = "txttgTitle"
        Me.txttgTitle.ReadOnly = True
        Me.txttgTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txttgTitle.Size = New System.Drawing.Size(516, 34)
        Me.txttgTitle.TabIndex = 7
        '
        'll
        '
        Me.ll.AutoSize = True
        Me.ll.Location = New System.Drawing.Point(539, 420)
        Me.ll.Name = "ll"
        Me.ll.Size = New System.Drawing.Size(99, 13)
        Me.ll.TabIndex = 6
        Me.ll.Text = "تاریخ و مرجع تصویب "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(540, 386)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "توضیحات "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(241, 420)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "تعریف قانونی "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(244, 351)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "شماره ماده "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(540, 351)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "عنوان قانونی "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(539, 315)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "نرخ و میزان مجازات "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(532, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "عنوان مجرمانه"
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Label7)
        Me.pnlTitle.Location = New System.Drawing.Point(8, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(659, 23)
        Me.pnlTitle.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(576, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "جرم شناسی"
        '
        'pnlContent
        '
        Me.pnlContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.btnSearch)
        Me.pnlContent.Controls.Add(Me.pnlMsg)
        Me.pnlContent.Controls.Add(Me.Label8)
        Me.pnlContent.Controls.Add(Me.Label9)
        Me.pnlContent.Controls.Add(Me.txttgDescription)
        Me.pnlContent.Controls.Add(Me.txttgTitle)
        Me.pnlContent.Controls.Add(Me.txttgRelatedRules)
        Me.pnlContent.Controls.Add(Me.Label2)
        Me.pnlContent.Controls.Add(Me.txttgRulePassedDate)
        Me.pnlContent.Controls.Add(Me.Label3)
        Me.pnlContent.Controls.Add(Me.txttgRuleDef)
        Me.pnlContent.Controls.Add(Me.Label4)
        Me.pnlContent.Controls.Add(Me.txttgRuleTile)
        Me.pnlContent.Controls.Add(Me.Label5)
        Me.pnlContent.Controls.Add(Me.txttgPenalty)
        Me.pnlContent.Controls.Add(Me.Label6)
        Me.pnlContent.Controls.Add(Me.ll)
        Me.pnlContent.Controls.Add(Me.txtSearch)
        Me.pnlContent.Controls.Add(Me.dgvGuilts)
        Me.pnlContent.Controls.Add(Me.ShapeContainer1)
        Me.pnlContent.Location = New System.Drawing.Point(8, 24)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(659, 508)
        Me.pnlContent.TabIndex = 9
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 483)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(659, 25)
        Me.pnlMsg.TabIndex = 77
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(659, 13)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(543, 276)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "عنوان جرم"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(560, 245)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "مشخصات جرم"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(659, 508)
        Me.ShapeContainer1.TabIndex = 8
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(13, 251)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(633, 203)
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.LawyerApp.My.Resources.Resources.Search1
        Me.btnSearch.Location = New System.Drawing.Point(241, 10)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(70, 23)
        Me.btnSearch.TabIndex = 85
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'GuiltSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 533)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlTitle)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "GuiltSearch"
        CType(Me.dgvGuilts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgvGuilts As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ll As System.Windows.Forms.Label
    Friend WithEvents txttgRuleTile As System.Windows.Forms.TextBox
    Friend WithEvents txttgPenalty As System.Windows.Forms.TextBox
    Friend WithEvents txttgTitle As System.Windows.Forms.TextBox
    Friend WithEvents txttgDescription As System.Windows.Forms.TextBox
    Friend WithEvents txttgRelatedRules As System.Windows.Forms.TextBox
    Friend WithEvents txttgRulePassedDate As System.Windows.Forms.TextBox
    Friend WithEvents txttgRuleDef As System.Windows.Forms.TextBox
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
End Class
