<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabaseMove
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
        Me.UcMoveDatabase1 = New WFControls.CS.MoveDatabase.ucMoveDatabase()
        Me.SuspendLayout()
        '
        'UcMoveDatabase1
        '
        Me.UcMoveDatabase1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.UcMoveDatabase1.Location = New System.Drawing.Point(-2, 1)
        Me.UcMoveDatabase1.Name = "UcMoveDatabase1"
        Me.UcMoveDatabase1.Size = New System.Drawing.Size(418, 222)
        Me.UcMoveDatabase1.TabIndex = 0
        '
        'frmDatabaseMove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(408, 210)
        Me.Controls.Add(Me.UcMoveDatabase1)
        Me.MaximizeBox = False
        Me.Name = "frmDatabaseMove"
        Me.Text = "انتقال فایلهای پایگاه داده"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcMoveDatabase1 As WFControls.CS.MoveDatabase.ucMoveDatabase
End Class
