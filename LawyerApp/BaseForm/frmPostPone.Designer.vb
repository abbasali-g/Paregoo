<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPostPone
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
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.Title = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbReminderType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReminder = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCancle = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.pnlTitle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Title)
        Me.pnlTitle.Location = New System.Drawing.Point(4, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(285, 23)
        Me.pnlTitle.TabIndex = 6
        '
        'Title
        '
        Me.Title.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Title.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Title.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Title.Location = New System.Drawing.Point(4, 4)
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        Me.Title.Size = New System.Drawing.Size(278, 14)
        Me.Title.TabIndex = 1
        Me.Title.Text = "تعیین زمان یادآوری"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.cmbReminderType)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtReminder)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.btnCancle)
        Me.Panel1.Controls.Add(Me.btnOk)
        Me.Panel1.Location = New System.Drawing.Point(3, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(286, 94)
        Me.Panel1.TabIndex = 7
        '
        'cmbReminderType
        '
        Me.cmbReminderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReminderType.FormattingEnabled = True
        Me.cmbReminderType.Items.AddRange(New Object() {"دقیقه", "ساعت ", "روز"})
        Me.cmbReminderType.Location = New System.Drawing.Point(72, 20)
        Me.cmbReminderType.Name = "cmbReminderType"
        Me.cmbReminderType.Size = New System.Drawing.Size(59, 21)
        Me.cmbReminderType.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(40, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = " مانده"
        '
        'txtReminder
        '
        Me.txtReminder.Location = New System.Drawing.Point(135, 20)
        Me.txtReminder.MaxLength = 3
        Me.txtReminder.Name = "txtReminder"
        Me.txtReminder.Size = New System.Drawing.Size(56, 21)
        Me.txtReminder.TabIndex = 38
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(196, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "زمان یادآوری :"
        '
        'btnCancle
        '
        Me.btnCancle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancle.Image = Global.LawyerApp.My.Resources.Resources.ok16_12
        Me.btnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancle.Location = New System.Drawing.Point(69, 59)
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
        Me.btnOk.Image = Global.LawyerApp.My.Resources.Resources.tick_icon12
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(132, 59)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(59, 23)
        Me.btnOk.TabIndex = 30
        Me.btnOk.Text = "تایـیـد"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'pnlMsg
        '
        Me.pnlMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(4, 121)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(286, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(7, 6)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(273, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "lblMessage"
        Me.lblMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmPostPone
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 156)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTitle)
        Me.MaximizeBox = False
        Me.Name = "frmPostPone"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "فرم تایید"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Title As System.Windows.Forms.TextBox
    Private WithEvents btnCancle As System.Windows.Forms.Button
    Private WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents cmbReminderType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReminder As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox

End Class
