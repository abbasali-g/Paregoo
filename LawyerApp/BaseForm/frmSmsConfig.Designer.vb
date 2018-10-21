<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmsConfig
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
        Me.UcSmsConfig1 = New WFControls.CS.Sms.ucSmsConfig()
        Me.SuspendLayout()
        '
        'UcSmsConfig1
        '
        Me.UcSmsConfig1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.UcSmsConfig1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.UcSmsConfig1.Location = New System.Drawing.Point(0, 1)
        Me.UcSmsConfig1.Name = "UcSmsConfig1"
        Me.UcSmsConfig1.Size = New System.Drawing.Size(201, 68)
        Me.UcSmsConfig1.TabIndex = 0
        '
        'frmSmsConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(190, 65)
        Me.Controls.Add(Me.UcSmsConfig1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSmsConfig"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcSmsConfig1 As WFControls.CS.Sms.ucSmsConfig
End Class
