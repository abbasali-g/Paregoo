<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmail
    Inherits GlobalForm2 'System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmail))
        Me.UcEmail1 = New WFControls.VB.ucEmail
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.btnSetting = New System.Windows.Forms.Button
        Me.btnContacts = New System.Windows.Forms.Button
        Me.lblTitle = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'UcEmail1
        '
        Me.UcEmail1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UcEmail1.AttachmentFilePath = Nothing
        Me.UcEmail1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.UcEmail1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcEmail1.Clear = False
        Me.UcEmail1.Content = Nothing
        Me.UcEmail1.DisplayName = Nothing
        Me.UcEmail1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.UcEmail1.From_Email = Nothing
        Me.UcEmail1.Location = New System.Drawing.Point(8, 44)
        Me.UcEmail1.Name = "UcEmail1"
        Me.UcEmail1.Size = New System.Drawing.Size(504, 388)
        Me.UcEmail1.Subject = Nothing
        Me.UcEmail1.TabIndex = 0
        Me.UcEmail1.To_Email = Nothing
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.btnSetting)
        Me.pnlTitle.Controls.Add(Me.btnContacts)
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(9, 22)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(502, 23)
        Me.pnlTitle.TabIndex = 31
        '
        'btnSetting
        '
        Me.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSetting.FlatAppearance.BorderSize = 0
        Me.btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        'Me.btnSetting.Image = Global.LawyerApp.My.Resources.Resources.ManualConfig2
        Me.btnSetting.Location = New System.Drawing.Point(29, 0)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(20, 20)
        Me.btnSetting.TabIndex = 11
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnContacts
        '
        Me.btnContacts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnContacts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContacts.FlatAppearance.BorderSize = 0
        Me.btnContacts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContacts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        'Me.btnContacts.Image = Global.LawyerApp.My.Resources.Resources.contact20
        Me.btnContacts.Location = New System.Drawing.Point(3, 0)
        Me.btnContacts.Name = "btnContacts"
        Me.btnContacts.Size = New System.Drawing.Size(20, 20)
        Me.btnContacts.TabIndex = 10
        Me.btnContacts.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(418, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(71, 13)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "ارسال ایمیل"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'frmEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 440)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.UcEmail1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmail"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "ارسال پست الکترونیکی"
        Me.Controls.SetChildIndex(Me.UcEmail1, 0)
        Me.Controls.SetChildIndex(Me.pnlTitle, 0)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcEmail1 As WFControls.VB.ucEmail
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnContacts As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSetting As System.Windows.Forms.Button
End Class
