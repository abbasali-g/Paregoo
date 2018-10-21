<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimingView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimingView))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.picForward = New System.Windows.Forms.Button()
        Me.picReply = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.NewTimingAdd1 = New WFControls.VB.NewTimingAdd()
        Me.pnlTitle.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.SuspendLayout()
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
        Me.pnlTitle.Location = New System.Drawing.Point(7, 3)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(562, 23)
        Me.pnlTitle.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(427, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "مشاهده اقدام ثبت شده"
        '
        'pnlMenu
        '
        Me.pnlMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.pnlMenu.Controls.Add(Me.picForward)
        Me.pnlMenu.Controls.Add(Me.picReply)
        Me.pnlMenu.Location = New System.Drawing.Point(7, 25)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(57, 568)
        Me.pnlMenu.TabIndex = 9
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
        Me.picForward.Location = New System.Drawing.Point(14, 288)
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
        Me.picReply.Location = New System.Drawing.Point(14, 217)
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
        'NewTimingAdd1
        '
        Me.NewTimingAdd1.AutoSize = True
        Me.NewTimingAdd1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.NewTimingAdd1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.NewTimingAdd1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.NewTimingAdd1.Location = New System.Drawing.Point(66, 25)
        Me.NewTimingAdd1.Margin = New System.Windows.Forms.Padding(0)
        Me.NewTimingAdd1.Name = "NewTimingAdd1"
        Me.NewTimingAdd1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NewTimingAdd1.Size = New System.Drawing.Size(502, 508)
        Me.NewTimingAdd1.TabIndex = 76
        '
        'TimingView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 622)
        Me.Controls.Add(Me.NewTimingAdd1)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TimingView"
        Me.Text = "مشاهده اقدام"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnlMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents picReply As System.Windows.Forms.Button
    Friend WithEvents picForward As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents NewTimingAdd1 As WFControls.VB.NewTimingAdd
End Class
