<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoDadMessageBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfoDadMessageBox))
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.Title = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtContent = New System.Windows.Forms.TextBox
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
        Me.pnlTitle.Location = New System.Drawing.Point(4, 22)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(283, 22)
        Me.pnlTitle.TabIndex = 6
        '
        'Title
        '
        Me.Title.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Title.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Title.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Title.Location = New System.Drawing.Point(6, 4)
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        Me.Title.Size = New System.Drawing.Size(271, 14)
        Me.Title.TabIndex = 7
        Me.Title.Text = "پیام خطا"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtContent)
        Me.Panel1.Controls.Add(Me.btnOk)
        Me.Panel1.Controls.Add(Me.pnlError)
        Me.Panel1.Location = New System.Drawing.Point(4, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(283, 112)
        Me.Panel1.TabIndex = 10
        '
        'txtContent
        '
        Me.txtContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtContent.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContent.Location = New System.Drawing.Point(9, 14)
        Me.txtContent.Multiline = True
        Me.txtContent.Name = "txtContent"
        Me.txtContent.ReadOnly = True
        Me.txtContent.Size = New System.Drawing.Size(243, 52)
        Me.txtContent.TabIndex = 32
        Me.txtContent.Text = "آیا برای حذف فایل مطمئن هستید ؟"
        '
        'btnOk
        '
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Image = Global.Lawyer.Partial.My.Resources.Resources.ok16_12
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(116, 79)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(59, 23)
        Me.btnOk.TabIndex = 30
        Me.btnOk.Text = "بستن"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'pnlError
        '
        Me.pnlError.BackgroundImage = Global.Lawyer.Partial.My.Resources.Resources.info18
        Me.pnlError.Location = New System.Drawing.Point(258, 13)
        Me.pnlError.Name = "pnlError"
        Me.pnlError.Size = New System.Drawing.Size(16, 16)
        Me.pnlError.TabIndex = 29
        '
        'InfoDadMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 162)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InfoDadMessageBox"
        Me.Text = "نمایش پیام"
        Me.Controls.SetChildIndex(Me.pnlTitle, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Private WithEvents Title As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents txtContent As System.Windows.Forms.TextBox
    Private WithEvents btnOk As System.Windows.Forms.Button
    Private WithEvents pnlError As System.Windows.Forms.Panel
End Class
