<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSms
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
        Me.UcSms1 = New WFControls.CS.Sms.ucSms()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'UcSms1
        '
        Me.UcSms1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.UcSms1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcSms1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.UcSms1.Location = New System.Drawing.Point(0, 0)
        Me.UcSms1.Name = "UcSms1"
        Me.UcSms1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.UcSms1.Size = New System.Drawing.Size(397, 247)
        Me.UcSms1.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(4, 215)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(51, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "انصراف"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmSms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 247)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.UcSms1)
        Me.MaximizeBox = False
        Me.Name = "frmSms"
        Me.Text = "ارسال پیامک"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcSms1 As WFControls.CS.Sms.ucSms
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
