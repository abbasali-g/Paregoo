<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShexes
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
        Me.UcShaxes1 = New WFControls.CS.Shaxes.ucShaxes()
        Me.SuspendLayout()
        '
        'UcShaxes1
        '
        Me.UcShaxes1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.UcShaxes1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.UcShaxes1.Location = New System.Drawing.Point(3, 1)
        Me.UcShaxes1.Name = "UcShaxes1"
        Me.UcShaxes1.Size = New System.Drawing.Size(498, 265)
        Me.UcShaxes1.TabIndex = 4
        '
        'frmShexes
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 272)
        Me.Controls.Add(Me.UcShaxes1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmShexes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcShaxes1 As WFControls.CS.Shaxes.ucShaxes
End Class
