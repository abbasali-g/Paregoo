<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fax
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
        Me.pnlEmail = New System.Windows.Forms.Panel
        Me.rtbContent = New System.Windows.Forms.RichTextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSend = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDisplayName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtToNumber = New System.Windows.Forms.TextBox
        Me.pnlInfo = New System.Windows.Forms.Panel
        Me.txtSearchUser = New System.Windows.Forms.TextBox
        Me.lvUsers = New System.Windows.Forms.ListView
        Me.pnlEmail.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEmail
        '
        Me.pnlEmail.BackColor = System.Drawing.Color.Transparent
        Me.pnlEmail.Controls.Add(Me.rtbContent)
        Me.pnlEmail.Controls.Add(Me.btnCancel)
        Me.pnlEmail.Controls.Add(Me.btnSend)
        Me.pnlEmail.Controls.Add(Me.Label2)
        Me.pnlEmail.Controls.Add(Me.txtDisplayName)
        Me.pnlEmail.Controls.Add(Me.Label1)
        Me.pnlEmail.Controls.Add(Me.txtToNumber)
        Me.pnlEmail.Location = New System.Drawing.Point(112, 3)
        Me.pnlEmail.Name = "pnlEmail"
        Me.pnlEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlEmail.Size = New System.Drawing.Size(273, 163)
        Me.pnlEmail.TabIndex = 10
        '
        'rtbContent
        '
        Me.rtbContent.Location = New System.Drawing.Point(14, 56)
        Me.rtbContent.Name = "rtbContent"
        Me.rtbContent.Size = New System.Drawing.Size(250, 71)
        Me.rtbContent.TabIndex = 7
        Me.rtbContent.Text = ""
        Me.rtbContent.WordWrap = False
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(59, 134)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "انصراف"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.Location = New System.Drawing.Point(141, 134)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 5
        Me.btnSend.Text = "ارسال"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "از"
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Location = New System.Drawing.Point(9, 30)
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(208, 20)
        Me.txtDisplayName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(220, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "به شماره"
        '
        'txtToNumber
        '
        Me.txtToNumber.Location = New System.Drawing.Point(9, 3)
        Me.txtToNumber.Multiline = True
        Me.txtToNumber.Name = "txtToNumber"
        Me.txtToNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtToNumber.Size = New System.Drawing.Size(208, 21)
        Me.txtToNumber.TabIndex = 0
        '
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.SystemColors.Info
        Me.pnlInfo.Controls.Add(Me.txtSearchUser)
        Me.pnlInfo.Controls.Add(Me.lvUsers)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Size = New System.Drawing.Size(118, 167)
        Me.pnlInfo.TabIndex = 13
        '
        'txtSearchUser
        '
        Me.txtSearchUser.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtSearchUser.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSearchUser.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.txtSearchUser.Location = New System.Drawing.Point(4, 5)
        Me.txtSearchUser.Name = "txtSearchUser"
        Me.txtSearchUser.Size = New System.Drawing.Size(109, 21)
        Me.txtSearchUser.TabIndex = 11
        '
        'lvUsers
        '
        Me.lvUsers.BackColor = System.Drawing.SystemColors.Info
        Me.lvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvUsers.Location = New System.Drawing.Point(4, 29)
        Me.lvUsers.MultiSelect = False
        Me.lvUsers.Name = "lvUsers"
        Me.lvUsers.RightToLeftLayout = True
        Me.lvUsers.Size = New System.Drawing.Size(109, 134)
        Me.lvUsers.TabIndex = 9
        Me.lvUsers.UseCompatibleStateImageBehavior = False
        '
        'Fax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlEmail)
        Me.Name = "Fax"
        Me.Size = New System.Drawing.Size(386, 167)
        Me.pnlEmail.ResumeLayout(False)
        Me.pnlEmail.PerformLayout()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEmail As System.Windows.Forms.Panel
    Friend WithEvents rtbContent As System.Windows.Forms.RichTextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtToNumber As System.Windows.Forms.TextBox
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents txtSearchUser As System.Windows.Forms.TextBox
    Friend WithEvents lvUsers As System.Windows.Forms.ListView

End Class
