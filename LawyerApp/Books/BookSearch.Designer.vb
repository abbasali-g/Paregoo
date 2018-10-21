<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookSearch
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BookSearch))
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.rdbMy = New System.Windows.Forms.RadioButton()
        Me.rdbAll = New System.Windows.Forms.RadioButton()
        Me.dgvBooks = New System.Windows.Forms.DataGridView()
        Me.txtSummary = New System.Windows.Forms.TextBox()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pbBook = New System.Windows.Forms.Button()
        Me.pbAdd = New System.Windows.Forms.Button()
        Me.pbDel = New System.Windows.Forms.Button()
        Me.pbEdit = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvBooks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitle.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSearch
        '
        Me.txtSearch.AcceptsReturn = True
        Me.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSearch.Location = New System.Drawing.Point(60, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSearch.Size = New System.Drawing.Size(316, 21)
        Me.txtSearch.TabIndex = 1
        '
        'rdbMy
        '
        Me.rdbMy.AutoSize = True
        Me.rdbMy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rdbMy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(19, Byte), Integer))
        Me.rdbMy.Location = New System.Drawing.Point(126, 35)
        Me.rdbMy.Name = "rdbMy"
        Me.rdbMy.Size = New System.Drawing.Size(75, 17)
        Me.rdbMy.TabIndex = 2
        Me.rdbMy.Text = "کتابهای من"
        Me.rdbMy.UseVisualStyleBackColor = True
        '
        'rdbAll
        '
        Me.rdbAll.AutoSize = True
        Me.rdbAll.Checked = True
        Me.rdbAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdbAll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(19, Byte), Integer))
        Me.rdbAll.Location = New System.Drawing.Point(208, 35)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(95, 17)
        Me.rdbAll.TabIndex = 3
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "کتابهای حقوقی"
        Me.rdbAll.UseVisualStyleBackColor = True
        '
        'dgvBooks
        '
        Me.dgvBooks.AllowDrop = True
        Me.dgvBooks.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBooks.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBooks.EnableHeadersVisualStyles = False
        Me.dgvBooks.Location = New System.Drawing.Point(49, 58)
        Me.dgvBooks.MultiSelect = False
        Me.dgvBooks.Name = "dgvBooks"
        Me.dgvBooks.ReadOnly = True
        Me.dgvBooks.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBooks.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBooks.RowHeadersVisible = False
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.dgvBooks.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBooks.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgvBooks.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dgvBooks.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.dgvBooks.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.dgvBooks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBooks.Size = New System.Drawing.Size(344, 203)
        Me.dgvBooks.TabIndex = 5
        '
        'txtSummary
        '
        Me.txtSummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSummary.Location = New System.Drawing.Point(53, 285)
        Me.txtSummary.Multiline = True
        Me.txtSummary.Name = "txtSummary"
        Me.txtSummary.ReadOnly = True
        Me.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSummary.Size = New System.Drawing.Size(334, 159)
        Me.txtSummary.TabIndex = 0
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(16, 8)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(28, 23)
        Me.btnShow.TabIndex = 25
        Me.btnShow.Text = ">"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Label2)
        Me.pnlTitle.Location = New System.Drawing.Point(2, 1)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(409, 23)
        Me.pnlTitle.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(303, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "جستجوی کتاب"
        '
        'pnlContent
        '
        Me.pnlContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.pbBook)
        Me.pnlContent.Controls.Add(Me.pbAdd)
        Me.pnlContent.Controls.Add(Me.pbDel)
        Me.pnlContent.Controls.Add(Me.pbEdit)
        Me.pnlContent.Controls.Add(Me.Label9)
        Me.pnlContent.Controls.Add(Me.txtSummary)
        Me.pnlContent.Controls.Add(Me.btnShow)
        Me.pnlContent.Controls.Add(Me.txtSearch)
        Me.pnlContent.Controls.Add(Me.rdbMy)
        Me.pnlContent.Controls.Add(Me.rdbAll)
        Me.pnlContent.Controls.Add(Me.dgvBooks)
        Me.pnlContent.Controls.Add(Me.pnlMsg)
        Me.pnlContent.Controls.Add(Me.ShapeContainer1)
        Me.pnlContent.Location = New System.Drawing.Point(2, 25)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(409, 482)
        Me.pnlContent.TabIndex = 27
        '
        'pbBook
        '
        Me.pbBook.BackgroundImage = Global.LawyerApp.My.Resources.Resources.YellowBook
        Me.pbBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbBook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbBook.FlatAppearance.BorderSize = 0
        Me.pbBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pbBook.Location = New System.Drawing.Point(12, 285)
        Me.pbBook.Name = "pbBook"
        Me.pbBook.Size = New System.Drawing.Size(31, 35)
        Me.pbBook.TabIndex = 87
        Me.pbBook.UseVisualStyleBackColor = True
        '
        'pbAdd
        '
        Me.pbAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAdd.FlatAppearance.BorderSize = 0
        Me.pbAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pbAdd.Image = Global.LawyerApp.My.Resources.Resources.book_add32
        Me.pbAdd.Location = New System.Drawing.Point(9, 324)
        Me.pbAdd.Name = "pbAdd"
        Me.pbAdd.Size = New System.Drawing.Size(31, 35)
        Me.pbAdd.TabIndex = 86
        Me.pbAdd.UseVisualStyleBackColor = True
        '
        'pbDel
        '
        Me.pbDel.BackgroundImage = Global.LawyerApp.My.Resources.Resources.Recycle_Full
        Me.pbDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbDel.FlatAppearance.BorderSize = 0
        Me.pbDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pbDel.Location = New System.Drawing.Point(11, 410)
        Me.pbDel.Name = "pbDel"
        Me.pbDel.Size = New System.Drawing.Size(31, 35)
        Me.pbDel.TabIndex = 85
        Me.pbDel.UseVisualStyleBackColor = True
        '
        'pbEdit
        '
        Me.pbEdit.BackgroundImage = Global.LawyerApp.My.Resources.Resources.edit1
        Me.pbEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEdit.FlatAppearance.BorderSize = 0
        Me.pbEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pbEdit.Location = New System.Drawing.Point(12, 368)
        Me.pbEdit.Name = "pbEdit"
        Me.pbEdit.Size = New System.Drawing.Size(31, 35)
        Me.pbEdit.TabIndex = 28
        Me.pbEdit.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(300, 263)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "مشخصات کتاب"
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 472)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(409, 10)
        Me.pnlMsg.TabIndex = 77
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(2, 513)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(400, 13)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(409, 482)
        Me.ShapeContainer1.TabIndex = 26
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(49, 273)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(342, 175)
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'BookSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 533)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(550, 100)
        Me.MaximizeBox = False
        Me.Name = "BookSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.dgvBooks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents rdbMy As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
    Friend WithEvents dgvBooks As System.Windows.Forms.DataGridView
    Friend WithEvents txtSummary As System.Windows.Forms.TextBox
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pbEdit As System.Windows.Forms.Button
    Friend WithEvents pbDel As System.Windows.Forms.Button
    Friend WithEvents pbAdd As System.Windows.Forms.Button
    Friend WithEvents pbBook As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
End Class
