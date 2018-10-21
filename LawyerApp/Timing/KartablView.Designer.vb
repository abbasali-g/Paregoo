<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KartablView
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KartablView))
        Me.KartablView1 = New WFControls.VB.kartablView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.picForward = New System.Windows.Forms.Button()
        Me.picReply = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.pnlTitle.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'KartablView1
        '
        Me.KartablView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.KartablView1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KartablView1.Location = New System.Drawing.Point(63, 25)
        Me.KartablView1.Name = "KartablView1"
        Me.KartablView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.KartablView1.Size = New System.Drawing.Size(491, 473)
        Me.KartablView1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "reply"
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Label3)
        Me.pnlTitle.Location = New System.Drawing.Point(7, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(547, 23)
        Me.pnlTitle.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(454, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "مشاهده پیغام"
        '
        'pnlMenu
        '
        Me.pnlMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.pnlMenu.Controls.Add(Me.btnDel)
        Me.pnlMenu.Controls.Add(Me.picForward)
        Me.pnlMenu.Controls.Add(Me.picReply)
        Me.pnlMenu.Location = New System.Drawing.Point(7, 24)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(57, 474)
        Me.pnlMenu.TabIndex = 9
        '
        'btnDel
        '
        Me.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDel.FlatAppearance.BorderSize = 0
        Me.btnDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDel.Image = Global.LawyerApp.My.Resources.Resources.Recycle_Full
        Me.btnDel.Location = New System.Drawing.Point(14, 262)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(32, 32)
        Me.btnDel.TabIndex = 10
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'picForward
        '
        Me.picForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picForward.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picForward.FlatAppearance.BorderSize = 0
        Me.picForward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.picForward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.picForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.picForward.Image = Global.LawyerApp.My.Resources.Resources.forward32
        Me.picForward.Location = New System.Drawing.Point(14, 195)
        Me.picForward.Name = "picForward"
        Me.picForward.Size = New System.Drawing.Size(32, 32)
        Me.picForward.TabIndex = 9
        Me.picForward.UseVisualStyleBackColor = True
        '
        'picReply
        '
        Me.picReply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picReply.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picReply.FlatAppearance.BorderSize = 0
        Me.picReply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.picReply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.picReply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.picReply.Image = Global.LawyerApp.My.Resources.Resources.reply321
        Me.picReply.Location = New System.Drawing.Point(14, 124)
        Me.picReply.Name = "picReply"
        Me.picReply.Size = New System.Drawing.Size(32, 32)
        Me.picReply.TabIndex = 8
        Me.picReply.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'pnlMsg
        '
        Me.pnlMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(6, 499)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(548, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(7, 8)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(529, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "lblMessage"
        '
        'KartablView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 526)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.KartablView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "KartablView"
        Me.Text = "مشاهده پیام"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KartablView1 As WFControls.VB.kartablView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents picReply As System.Windows.Forms.Button
    Friend WithEvents picForward As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnDel As System.Windows.Forms.Button
End Class
