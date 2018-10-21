<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dadMessageBox
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
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.Title = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.text = New System.Windows.Forms.TextBox
        Me.btnCancle = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.pnlError = New System.Windows.Forms.Panel
        Me.pnlTitle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Title)
        Me.pnlTitle.Location = New System.Drawing.Point(5, 20)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(286, 23)
        Me.pnlTitle.TabIndex = 6
        '
        'Title
        '
        Me.Title.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Title.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Title.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Title.Location = New System.Drawing.Point(5, 4)
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        Me.Title.Size = New System.Drawing.Size(278, 14)
        Me.Title.TabIndex = 1
        Me.Title.Text = "پیام خطا"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.text)
        Me.Panel1.Controls.Add(Me.btnCancle)
        Me.Panel1.Controls.Add(Me.btnOk)
        Me.Panel1.Controls.Add(Me.pnlError)
        Me.Panel1.Location = New System.Drawing.Point(4, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(286, 113)
        Me.Panel1.TabIndex = 7
        '
        'text
        '
        Me.text.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.text.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.text.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.text.Location = New System.Drawing.Point(9, 14)
        Me.text.Multiline = True
        Me.text.Name = "text"
        Me.text.ReadOnly = True
        Me.text.Size = New System.Drawing.Size(242, 52)
        Me.text.TabIndex = 32
        Me.text.Text = "آیا برای حذف فایل مطمئن هستید ؟"
        '
        'btnCancle
        '
        Me.btnCancle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancle.Image = My.Resources.Resources.ok16_12
        Me.btnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancle.Location = New System.Drawing.Point(86, 83)
        Me.btnCancle.Name = "btnCancle"
        Me.btnCancle.Size = New System.Drawing.Size(59, 23)
        Me.btnCancle.TabIndex = 31
        Me.btnCancle.Text = "انصراف"
        Me.btnCancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancle.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Image = My.Resources.Resources.tick_icon12
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(158, 83)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(59, 23)
        Me.btnOk.TabIndex = 30
        Me.btnOk.Text = "تایـیـد"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'pnlError
        '
        Me.pnlError.BackgroundImage = My.Resources.Resources.erro18_1
        Me.pnlError.Location = New System.Drawing.Point(260, 13)
        Me.pnlError.Name = "pnlError"
        Me.pnlError.Size = New System.Drawing.Size(18, 16)
        Me.pnlError.TabIndex = 29
        '
        'dadMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 160)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Name = "dadMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Controls.SetChildIndex(Me.pnlTitle, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Title As System.Windows.Forms.TextBox
    Private WithEvents btnCancle As System.Windows.Forms.Button
    Private WithEvents btnOk As System.Windows.Forms.Button
    Private WithEvents pnlError As System.Windows.Forms.Panel
    Private WithEvents text As System.Windows.Forms.TextBox

End Class
