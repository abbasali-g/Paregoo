<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucEmail
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
        Me.components = New System.ComponentModel.Container
        Me.pnlEmail = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.ofdLoad = New System.Windows.Forms.OpenFileDialog
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.TextBox
        Me.pnlRech = New System.Windows.Forms.Panel
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSend = New System.Windows.Forms.Button
        Me.tlpUsers = New System.Windows.Forms.TableLayoutPanel
        Me.lbFiles = New System.Windows.Forms.ListBox
        Me.pnlAttachHead = New System.Windows.Forms.Panel
        Me.llFile = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.btnShowAttach = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RichTextBoxEx1 = New LawyerCommonControls.RichTextBoxEx
        Me.pnlEmail.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.pnlRech.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.tlpUsers.SuspendLayout()
        Me.pnlAttachHead.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEmail
        '
        Me.pnlEmail.BackColor = System.Drawing.Color.Transparent
        Me.pnlEmail.Controls.Add(Me.Label2)
        Me.pnlEmail.Controls.Add(Me.txtSubject)
        Me.pnlEmail.Controls.Add(Me.Label1)
        Me.pnlEmail.Controls.Add(Me.txtTo)
        Me.pnlEmail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEmail.Location = New System.Drawing.Point(0, 0)
        Me.pnlEmail.Name = "pnlEmail"
        Me.pnlEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlEmail.Size = New System.Drawing.Size(500, 58)
        Me.pnlEmail.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(454, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "موضوع :"
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSubject.Location = New System.Drawing.Point(151, 29)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(300, 21)
        Me.txtSubject.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(454, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "به :"
        '
        'txtTo
        '
        Me.txtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTo.Location = New System.Drawing.Point(151, 3)
        Me.txtTo.Multiline = True
        Me.txtTo.Name = "txtTo"
        Me.txtTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTo.Size = New System.Drawing.Size(300, 21)
        Me.txtTo.TabIndex = 0
        '
        'ofdLoad
        '
        Me.ofdLoad.Filter = "General Files|*.pdf;*.doc;*.docx;*.xls;*.xlsx;*.gif;*.png;*.txt|All Files (*.*)|*" & _
            ".*"
        Me.ofdLoad.Title = "Select  File..."
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 374)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlMsg.Size = New System.Drawing.Size(500, 25)
        Me.pnlMsg.TabIndex = 77
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Multiline = True
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(500, 25)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'pnlRech
        '
        Me.pnlRech.Controls.Add(Me.RichTextBoxEx1)
        Me.pnlRech.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRech.Location = New System.Drawing.Point(0, 128)
        Me.pnlRech.Name = "pnlRech"
        Me.pnlRech.Size = New System.Drawing.Size(500, 216)
        Me.pnlRech.TabIndex = 14
        '
        'pnlButton
        '
        Me.pnlButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlButton.Controls.Add(Me.btnCancel)
        Me.pnlButton.Controls.Add(Me.btnSend)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButton.Location = New System.Drawing.Point(0, 344)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(500, 30)
        Me.pnlButton.TabIndex = 78
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Image = Global.WFControls.VB.My.Resources.Resources.ok16_12
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.Location = New System.Drawing.Point(153, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "انصراف"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.Image = Global.WFControls.VB.My.Resources.Resources.tick_icon12
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSend.Location = New System.Drawing.Point(268, 4)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 3
        Me.btnSend.Text = "ارسال"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'tlpUsers
        '
        Me.tlpUsers.ColumnCount = 1
        Me.tlpUsers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.tlpUsers.Controls.Add(Me.lbFiles, 0, 1)
        Me.tlpUsers.Controls.Add(Me.pnlAttachHead, 0, 0)
        Me.tlpUsers.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpUsers.Location = New System.Drawing.Point(0, 58)
        Me.tlpUsers.Name = "tlpUsers"
        Me.tlpUsers.RowCount = 2
        Me.tlpUsers.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.tlpUsers.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.tlpUsers.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpUsers.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpUsers.Size = New System.Drawing.Size(500, 70)
        Me.tlpUsers.TabIndex = 79
        '
        'lbFiles
        '
        Me.lbFiles.BackColor = System.Drawing.Color.White
        Me.lbFiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbFiles.FormattingEnabled = True
        Me.lbFiles.Location = New System.Drawing.Point(3, 27)
        Me.lbFiles.Name = "lbFiles"
        Me.lbFiles.Size = New System.Drawing.Size(494, 39)
        Me.lbFiles.TabIndex = 9
        '
        'pnlAttachHead
        '
        Me.pnlAttachHead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAttachHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.pnlAttachHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAttachHead.Controls.Add(Me.llFile)
        Me.pnlAttachHead.Controls.Add(Me.btnDel)
        Me.pnlAttachHead.Controls.Add(Me.btnShowAttach)
        Me.pnlAttachHead.Location = New System.Drawing.Point(268, 3)
        Me.pnlAttachHead.Name = "pnlAttachHead"
        Me.pnlAttachHead.Size = New System.Drawing.Size(229, 18)
        Me.pnlAttachHead.TabIndex = 13
        '
        'llFile
        '
        Me.llFile.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.AttachF
        Me.llFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.llFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.llFile.FlatAppearance.BorderSize = 0
        Me.llFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.llFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.llFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.llFile.Location = New System.Drawing.Point(184, -3)
        Me.llFile.Name = "llFile"
        Me.llFile.Size = New System.Drawing.Size(23, 18)
        Me.llFile.TabIndex = 4
        Me.llFile.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.Transparent
        Me.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDel.FlatAppearance.BorderSize = 0
        Me.btnDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDel.Location = New System.Drawing.Point(59, -2)
        Me.btnDel.Margin = New System.Windows.Forms.Padding(1)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(90, 22)
        Me.btnDel.TabIndex = 7
        Me.btnDel.Text = "حذف ضمیمه"
        Me.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'btnShowAttach
        '
        Me.btnShowAttach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnShowAttach.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowAttach.FlatAppearance.BorderSize = 0
        Me.btnShowAttach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnShowAttach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnShowAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowAttach.Image = Global.WFControls.VB.My.Resources.Resources.Open
        Me.btnShowAttach.Location = New System.Drawing.Point(2, 0)
        Me.btnShowAttach.Margin = New System.Windows.Forms.Padding(0)
        Me.btnShowAttach.Name = "btnShowAttach"
        Me.btnShowAttach.Size = New System.Drawing.Size(16, 16)
        Me.btnShowAttach.TabIndex = 1
        Me.btnShowAttach.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'RichTextBoxEx1
        '
        Me.RichTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBoxEx1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBoxEx1.Name = "RichTextBoxEx1"
        Me.RichTextBoxEx1.RReadOnly = False
        Me.RichTextBoxEx1.Size = New System.Drawing.Size(500, 216)
        Me.RichTextBoxEx1.TabIndex = 0
        Me.RichTextBoxEx1.TextRich = ""
        '
        'ucEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.pnlRech)
        Me.Controls.Add(Me.tlpUsers)
        Me.Controls.Add(Me.pnlEmail)
        Me.Controls.Add(Me.pnlButton)
        Me.Controls.Add(Me.pnlMsg)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "ucEmail"
        Me.Size = New System.Drawing.Size(500, 399)
        Me.pnlEmail.ResumeLayout(False)
        Me.pnlEmail.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.pnlRech.ResumeLayout(False)
        Me.pnlButton.ResumeLayout(False)
        Me.tlpUsers.ResumeLayout(False)
        Me.pnlAttachHead.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEmail As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents ofdLoad As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents pnlRech As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents rtb As WFControls.VB.RichTextBoxEx
    Friend WithEvents tlpUsers As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbFiles As System.Windows.Forms.ListBox
    Friend WithEvents pnlAttachHead As System.Windows.Forms.Panel
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnShowAttach As System.Windows.Forms.Button
    Friend WithEvents llFile As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RichTextBoxEx1 As LawyerCommonControls.RichTextBoxEx

End Class
