<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class kartablView
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.rcDescription = New System.Windows.Forms.RichTextBox
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFrom = New System.Windows.Forms.TextBox
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.txtTime = New System.Windows.Forms.TextBox
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.lstFiles = New System.Windows.Forms.DataGridView
        Me.gvClmImage = New System.Windows.Forms.DataGridViewImageColumn
        Me.gvClmTitle = New System.Windows.Forms.DataGridViewLinkColumn
        Me.gvClmID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmnSaveAs = New System.Windows.Forms.DataGridViewLinkColumn
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Label9 = New System.Windows.Forms.Label
        CType(Me.lstFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(418, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "فرستنده :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(426, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 14)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "تاریخ :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(147, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 14)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "ساعت :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(429, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "عنوان :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(430, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "متن "
        '
        'rcDescription
        '
        Me.rcDescription.Location = New System.Drawing.Point(22, 160)
        Me.rcDescription.Name = "rcDescription"
        Me.rcDescription.Size = New System.Drawing.Size(445, 158)
        Me.rcDescription.TabIndex = 11
        Me.rcDescription.Text = ""
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1, Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(492, 469)
        Me.ShapeContainer1.TabIndex = 12
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape1.CornerRadius = 5
        Me.RectangleShape1.Location = New System.Drawing.Point(9, 101)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(472, 359)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(8, 10)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(472, 72)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(377, 344)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "فایلهای پیوست"
        '
        'txtFrom
        '
        Me.txtFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFrom.Location = New System.Drawing.Point(24, 22)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(392, 15)
        Me.txtFrom.TabIndex = 15
        Me.txtFrom.Text = "from"
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtDate.Location = New System.Drawing.Point(301, 53)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(122, 15)
        Me.txtDate.TabIndex = 16
        Me.txtDate.Text = "date"
        '
        'txtTime
        '
        Me.txtTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTime.Location = New System.Drawing.Point(31, 55)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(114, 15)
        Me.txtTime.TabIndex = 17
        Me.txtTime.Text = "time"
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTitle.Location = New System.Drawing.Point(31, 118)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(393, 15)
        Me.txtTitle.TabIndex = 18
        Me.txtTitle.Text = "title"
        '
        'lstFiles
        '
        Me.lstFiles.AllowDrop = True
        Me.lstFiles.AllowUserToAddRows = False
        Me.lstFiles.AllowUserToResizeColumns = False
        Me.lstFiles.AllowUserToResizeRows = False
        Me.lstFiles.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.lstFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.lstFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.lstFiles.ColumnHeadersVisible = False
        Me.lstFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvClmImage, Me.gvClmTitle, Me.gvClmID, Me.clmnSaveAs})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstFiles.DefaultCellStyle = DataGridViewCellStyle1
        Me.lstFiles.Location = New System.Drawing.Point(22, 364)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.ReadOnly = True
        Me.lstFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.lstFiles.RowHeadersVisible = False
        Me.lstFiles.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.lstFiles.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.lstFiles.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.lstFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lstFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.lstFiles.Size = New System.Drawing.Size(445, 85)
        Me.lstFiles.TabIndex = 58
        '
        'gvClmImage
        '
        Me.gvClmImage.HeaderText = "Column1"
        Me.gvClmImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.gvClmImage.Name = "gvClmImage"
        Me.gvClmImage.ReadOnly = True
        Me.gvClmImage.Width = 16
        '
        'gvClmTitle
        '
        Me.gvClmTitle.ActiveLinkColor = System.Drawing.Color.Black
        Me.gvClmTitle.HeaderText = ""
        Me.gvClmTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.gvClmTitle.LinkColor = System.Drawing.Color.Black
        Me.gvClmTitle.Name = "gvClmTitle"
        Me.gvClmTitle.ReadOnly = True
        Me.gvClmTitle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvClmTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.gvClmTitle.VisitedLinkColor = System.Drawing.Color.Black
        Me.gvClmTitle.Width = 320
        '
        'gvClmID
        '
        Me.gvClmID.HeaderText = ""
        Me.gvClmID.Name = "gvClmID"
        Me.gvClmID.ReadOnly = True
        Me.gvClmID.Visible = False
        Me.gvClmID.Width = 5
        '
        'clmnSaveAs
        '
        Me.clmnSaveAs.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.clmnSaveAs.HeaderText = ""
        Me.clmnSaveAs.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
        Me.clmnSaveAs.LinkColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.clmnSaveAs.Name = "clmnSaveAs"
        Me.clmnSaveAs.ReadOnly = True
        Me.clmnSaveAs.Text = "ذخیره"
        Me.clmnSaveAs.UseColumnTextForLinkValue = True
        Me.clmnSaveAs.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.clmnSaveAs.Width = 120
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(399, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 14)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "محتویات پیام"
        '
        'kartablView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lstFiles)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rcDescription)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "kartablView"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(492, 469)
        CType(Me.lstFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rcDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents lstFiles As System.Windows.Forms.DataGridView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gvClmImage As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents gvClmTitle As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents gvClmID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmnSaveAs As System.Windows.Forms.DataGridViewLinkColumn

End Class
