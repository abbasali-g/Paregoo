<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompetencySearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompetencySearch))
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.dgvLaws = New System.Windows.Forms.DataGridView()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbEdalat = New System.Windows.Forms.RadioButton()
        Me.rbDivan = New System.Windows.Forms.RadioButton()
        Me.rbShura = New System.Windows.Forms.RadioButton()
        Me.Map1 = New WFControls.VB.Map()
        Me.rbShebhe = New System.Windows.Forms.RadioButton()
        Me.rbDadsara = New System.Windows.Forms.RadioButton()
        Me.rbMojtame = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.pbDel = New System.Windows.Forms.Button()
        Me.pbEdit = New System.Windows.Forms.Button()
        CType(Me.dgvLaws, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTitle
        '
        Me.txtTitle.AcceptsReturn = True
        Me.txtTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtTitle.BackColor = System.Drawing.Color.White
        Me.txtTitle.Location = New System.Drawing.Point(210, 9)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTitle.Size = New System.Drawing.Size(316, 21)
        Me.txtTitle.TabIndex = 0
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.White
        Me.txtNote.Location = New System.Drawing.Point(14, 233)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ReadOnly = True
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(568, 44)
        Me.txtNote.TabIndex = 5
        '
        'dgvLaws
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LavenderBlush
        Me.dgvLaws.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLaws.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLaws.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLaws.EnableHeadersVisualStyles = False
        Me.dgvLaws.Location = New System.Drawing.Point(7, 84)
        Me.dgvLaws.MultiSelect = False
        Me.dgvLaws.Name = "dgvLaws"
        Me.dgvLaws.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgvLaws.RowHeadersVisible = False
        Me.dgvLaws.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgvLaws.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvLaws.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.dgvLaws.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvLaws.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvLaws.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLaws.Size = New System.Drawing.Size(583, 101)
        Me.dgvLaws.TabIndex = 4
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(8, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(594, 23)
        Me.pnlTitle.TabIndex = 30
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(468, 6)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(117, 13)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "جستجوی صلاحیت ها"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.pbDel)
        Me.Panel1.Controls.Add(Me.pbEdit)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.rbEdalat)
        Me.Panel1.Controls.Add(Me.rbDivan)
        Me.Panel1.Controls.Add(Me.rbShura)
        Me.Panel1.Controls.Add(Me.Map1)
        Me.Panel1.Controls.Add(Me.rbShebhe)
        Me.Panel1.Controls.Add(Me.rbDadsara)
        Me.Panel1.Controls.Add(Me.rbMojtame)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtNote)
        Me.Panel1.Controls.Add(Me.txtTitle)
        Me.Panel1.Controls.Add(Me.dgvLaws)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(8, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 587)
        Me.Panel1.TabIndex = 31
        '
        'rbEdalat
        '
        Me.rbEdalat.AutoSize = True
        Me.rbEdalat.Location = New System.Drawing.Point(14, 55)
        Me.rbEdalat.Name = "rbEdalat"
        Me.rbEdalat.Size = New System.Drawing.Size(108, 17)
        Me.rbEdalat.TabIndex = 5
        Me.rbEdalat.TabStop = True
        Me.rbEdalat.Text = "دیوان عدالت اداری"
        Me.rbEdalat.UseVisualStyleBackColor = True
        '
        'rbDivan
        '
        Me.rbDivan.AutoSize = True
        Me.rbDivan.Location = New System.Drawing.Point(118, 55)
        Me.rbDivan.Name = "rbDivan"
        Me.rbDivan.Size = New System.Drawing.Size(104, 17)
        Me.rbDivan.TabIndex = 5
        Me.rbDivan.TabStop = True
        Me.rbDivan.Text = "دیوان عالی کشور"
        Me.rbDivan.UseVisualStyleBackColor = True
        '
        'rbShura
        '
        Me.rbShura.AutoSize = True
        Me.rbShura.Location = New System.Drawing.Point(223, 55)
        Me.rbShura.Name = "rbShura"
        Me.rbShura.Size = New System.Drawing.Size(111, 17)
        Me.rbShura.TabIndex = 4
        Me.rbShura.TabStop = True
        Me.rbShura.Text = "شورای حل اختلاف"
        Me.rbShura.UseVisualStyleBackColor = True
        '
        'Map1
        '
        Me.Map1.AutoScroll = True
        Me.Map1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Map1.Location = New System.Drawing.Point(14, 287)
        Me.Map1.Name = "Map1"
        Me.Map1.Size = New System.Drawing.Size(568, 290)
        Me.Map1.TabIndex = 86
        '
        'rbShebhe
        '
        Me.rbShebhe.AutoSize = True
        Me.rbShebhe.Location = New System.Drawing.Point(334, 55)
        Me.rbShebhe.Name = "rbShebhe"
        Me.rbShebhe.Size = New System.Drawing.Size(107, 17)
        Me.rbShebhe.TabIndex = 3
        Me.rbShebhe.TabStop = True
        Me.rbShebhe.Text = "مرجع شبه قضایی"
        Me.rbShebhe.UseVisualStyleBackColor = True
        '
        'rbDadsara
        '
        Me.rbDadsara.AutoSize = True
        Me.rbDadsara.Location = New System.Drawing.Point(442, 55)
        Me.rbDadsara.Name = "rbDadsara"
        Me.rbDadsara.Size = New System.Drawing.Size(57, 17)
        Me.rbDadsara.TabIndex = 2
        Me.rbDadsara.TabStop = True
        Me.rbDadsara.Text = "دادسرا"
        Me.rbDadsara.UseVisualStyleBackColor = True
        '
        'rbMojtame
        '
        Me.rbMojtame.AutoSize = True
        Me.rbMojtame.Checked = True
        Me.rbMojtame.Location = New System.Drawing.Point(499, 55)
        Me.rbMojtame.Name = "rbMojtame"
        Me.rbMojtame.Size = New System.Drawing.Size(89, 17)
        Me.rbMojtame.TabIndex = 1
        Me.rbMojtame.TabStop = True
        Me.rbMojtame.Text = "مجتمع قضائی"
        Me.rbMojtame.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(533, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "نام استان"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(538, 208)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "توضیحات"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1, Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(594, 587)
        Me.ShapeContainer1.TabIndex = 30
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape1.CornerRadius = 5
        Me.RectangleShape1.Location = New System.Drawing.Point(8, 282)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(578, 300)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(7, 228)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(582, 51)
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(8, 615)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlMsg.Size = New System.Drawing.Size(594, 25)
        Me.pnlMsg.TabIndex = 80
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(0, 9)
        Me.lblMessage.Multiline = True
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(594, 16)
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
        'btnSearch
        '
        Me.btnSearch.Image = Global.LawyerApp.My.Resources.Resources.Search12
        Me.btnSearch.Location = New System.Drawing.Point(136, 7)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(68, 23)
        Me.btnSearch.TabIndex = 87
        Me.btnSearch.Text = "جستجو"
        Me.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Image = Global.LawyerApp.My.Resources.Resources.AddTiming
        Me.btnAdd.Location = New System.Drawing.Point(68, 7)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(68, 23)
        Me.btnAdd.TabIndex = 88
        Me.btnAdd.Text = "جدید"
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'pbDel
        '
        Me.pbDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbDel.FlatAppearance.BorderSize = 0
        Me.pbDel.Image = Global.LawyerApp.My.Resources.Resources.DeleteCat
        Me.pbDel.Location = New System.Drawing.Point(14, 191)
        Me.pbDel.Name = "pbDel"
        Me.pbDel.Size = New System.Drawing.Size(65, 24)
        Me.pbDel.TabIndex = 90
        Me.pbDel.Text = "حذف"
        Me.pbDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.pbDel, "حذف رکورد انتخاب شده")
        Me.pbDel.UseVisualStyleBackColor = True
        '
        'pbEdit
        '
        Me.pbEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEdit.FlatAppearance.BorderSize = 0
        Me.pbEdit.Image = Global.LawyerApp.My.Resources.Resources.EditCat
        Me.pbEdit.Location = New System.Drawing.Point(84, 191)
        Me.pbEdit.Name = "pbEdit"
        Me.pbEdit.Size = New System.Drawing.Size(69, 23)
        Me.pbEdit.TabIndex = 89
        Me.pbEdit.Text = "ویرایش"
        Me.pbEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.pbEdit, "ویرایش رکورد انتخاب شده")
        Me.pbEdit.UseVisualStyleBackColor = True
        '
        'CompetencySearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(610, 646)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlMsg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CompetencySearch"
        Me.Text = "جستجوی صلاحیت ها"
        CType(Me.dgvLaws, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents dgvLaws As System.Windows.Forms.DataGridView
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbShebhe As System.Windows.Forms.RadioButton
    Friend WithEvents rbDadsara As System.Windows.Forms.RadioButton
    Friend WithEvents rbMojtame As System.Windows.Forms.RadioButton
    Friend WithEvents Map1 As WFControls.VB.Map
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents rbDivan As System.Windows.Forms.RadioButton
    Friend WithEvents rbShura As System.Windows.Forms.RadioButton
    Friend WithEvents rbEdalat As System.Windows.Forms.RadioButton
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents pbDel As System.Windows.Forms.Button
    Friend WithEvents pbEdit As System.Windows.Forms.Button
End Class
