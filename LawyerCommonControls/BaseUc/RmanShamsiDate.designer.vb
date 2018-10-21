<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RmanShamsiDate
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
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.txtDay = New System.Windows.Forms.TextBox
        Me.txtSlash2 = New System.Windows.Forms.TextBox
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.txtSlash1 = New System.Windows.Forms.TextBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.White
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.RectangleShape1.CornerRadius = 3
        Me.RectangleShape1.Location = New System.Drawing.Point(0, 1)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(119, 24)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(121, 27)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'txtDay
        '
        Me.txtDay.BackColor = System.Drawing.Color.White
        Me.txtDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDay.Location = New System.Drawing.Point(91, 6)
        Me.txtDay.MaxLength = 2
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(23, 14)
        Me.txtDay.TabIndex = 2
        Me.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSlash2
        '
        Me.txtSlash2.BackColor = System.Drawing.Color.White
        Me.txtSlash2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSlash2.Location = New System.Drawing.Point(79, 6)
        Me.txtSlash2.Name = "txtSlash2"
        Me.txtSlash2.ReadOnly = True
        Me.txtSlash2.Size = New System.Drawing.Size(12, 14)
        Me.txtSlash2.TabIndex = 13
        Me.txtSlash2.TabStop = False
        Me.txtSlash2.Text = "/"
        Me.txtSlash2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMonth
        '
        Me.txtMonth.BackColor = System.Drawing.Color.White
        Me.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMonth.Location = New System.Drawing.Point(57, 6)
        Me.txtMonth.MaxLength = 2
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(23, 14)
        Me.txtMonth.TabIndex = 1
        Me.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSlash1
        '
        Me.txtSlash1.BackColor = System.Drawing.Color.White
        Me.txtSlash1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSlash1.Location = New System.Drawing.Point(45, 6)
        Me.txtSlash1.Name = "txtSlash1"
        Me.txtSlash1.ReadOnly = True
        Me.txtSlash1.Size = New System.Drawing.Size(12, 14)
        Me.txtSlash1.TabIndex = 11
        Me.txtSlash1.TabStop = False
        Me.txtSlash1.Text = "/"
        Me.txtSlash1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtYear
        '
        Me.txtYear.BackColor = System.Drawing.Color.White
        Me.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtYear.Location = New System.Drawing.Point(1, 6)
        Me.txtYear.MaxLength = 4
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(45, 14)
        Me.txtYear.TabIndex = 0
        Me.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RmanShamsiDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtDay)
        Me.Controls.Add(Me.txtSlash2)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.txtSlash1)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "RmanShamsiDate"
        Me.Size = New System.Drawing.Size(121, 27)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents txtSlash2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtSlash1 As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox

End Class
