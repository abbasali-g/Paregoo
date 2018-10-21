<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageViewer
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
        Me.pnlNavigate = New System.Windows.Forms.Panel
        Me.pbNext = New System.Windows.Forms.PictureBox
        Me.lblNo = New System.Windows.Forms.Label
        Me.pbImage = New System.Windows.Forms.PictureBox
        Me.pbBack = New System.Windows.Forms.PictureBox
        Me.pnlNavigate.SuspendLayout()
        CType(Me.pbNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlNavigate
        '
        Me.pnlNavigate.BackColor = System.Drawing.SystemColors.Control
        Me.pnlNavigate.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.menubar_Blue
        Me.pnlNavigate.Controls.Add(Me.pbBack)
        Me.pnlNavigate.Controls.Add(Me.pbNext)
        Me.pnlNavigate.Controls.Add(Me.lblNo)
        Me.pnlNavigate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlNavigate.Location = New System.Drawing.Point(0, 234)
        Me.pnlNavigate.Name = "pnlNavigate"
        Me.pnlNavigate.Size = New System.Drawing.Size(254, 20)
        Me.pnlNavigate.TabIndex = 1
        '
        'pbNext
        '
        Me.pbNext.BackColor = System.Drawing.Color.Transparent
        Me.pbNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbNext.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbNext.Image = Global.WFControls.VB.My.Resources.Resources.Naxt_Gray
        Me.pbNext.Location = New System.Drawing.Point(238, 0)
        Me.pbNext.Name = "pbNext"
        Me.pbNext.Size = New System.Drawing.Size(16, 20)
        Me.pbNext.TabIndex = 14
        Me.pbNext.TabStop = False
        '
        'lblNo
        '
        Me.lblNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNo.AutoSize = True
        Me.lblNo.BackColor = System.Drawing.Color.Transparent
        Me.lblNo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblNo.Location = New System.Drawing.Point(107, 4)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(36, 13)
        Me.lblNo.TabIndex = 2
        Me.lblNo.Text = "20/99"
        '
        'pbImage
        '
        Me.pbImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbImage.Location = New System.Drawing.Point(0, 0)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(254, 254)
        Me.pbImage.TabIndex = 0
        Me.pbImage.TabStop = False
        '
        'pbBack
        '
        Me.pbBack.BackColor = System.Drawing.Color.Transparent
        Me.pbBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbBack.Dock = System.Windows.Forms.DockStyle.Left
        Me.pbBack.Image = Global.WFControls.VB.My.Resources.Resources.Back_Gray
        Me.pbBack.Location = New System.Drawing.Point(0, 0)
        Me.pbBack.Name = "pbBack"
        Me.pbBack.Size = New System.Drawing.Size(16, 20)
        Me.pbBack.TabIndex = 15
        Me.pbBack.TabStop = False
        '
        'ImageViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pnlNavigate)
        Me.Controls.Add(Me.pbImage)
        Me.Name = "ImageViewer"
        Me.Size = New System.Drawing.Size(254, 254)
        Me.pnlNavigate.ResumeLayout(False)
        Me.pnlNavigate.PerformLayout()
        CType(Me.pbNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents pnlNavigate As System.Windows.Forms.Panel
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Friend WithEvents pbNext As System.Windows.Forms.PictureBox
    Friend WithEvents pbBack As System.Windows.Forms.PictureBox

End Class
