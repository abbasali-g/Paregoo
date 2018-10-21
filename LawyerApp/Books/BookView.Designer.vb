<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookView
    Inherits GlobalForm3

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BookView))
        Me.TooltipBookCase1 = New WFControls.CS.TooltipBookCase()
        Me.lvCase = New System.Windows.Forms.ListView()
        Me.MyBookCase1 = New WFControls.VB.ucBookCase()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.pbAdd = New System.Windows.Forms.Button()
        Me.pbDel = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.pnlTitle.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'TooltipBookCase1
        '
        Me.TooltipBookCase1.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.TooltipBookCase1.Location = New System.Drawing.Point(81, 392)
        Me.TooltipBookCase1.Name = "TooltipBookCase1"
        Me.TooltipBookCase1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TooltipBookCase1.Size = New System.Drawing.Size(188, 68)
        Me.TooltipBookCase1.Subject = Nothing
        Me.TooltipBookCase1.TabIndex = 31
        Me.TooltipBookCase1.Title = Nothing
        '
        'lvCase
        '
        Me.lvCase.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.lvCase.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.lvCase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvCase.HideSelection = False
        Me.lvCase.Location = New System.Drawing.Point(51, 6)
        Me.lvCase.Margin = New System.Windows.Forms.Padding(0)
        Me.lvCase.MultiSelect = False
        Me.lvCase.Name = "lvCase"
        Me.lvCase.Size = New System.Drawing.Size(245, 61)
        Me.lvCase.TabIndex = 33
        Me.lvCase.UseCompatibleStateImageBehavior = False
        '
        'MyBookCase1
        '
        Me.MyBookCase1.BackgroundImage = CType(resources.GetObject("MyBookCase1.BackgroundImage"), System.Drawing.Image)
        Me.MyBookCase1.Location = New System.Drawing.Point(56, 72)
        Me.MyBookCase1.Name = "MyBookCase1"
        Me.MyBookCase1.Size = New System.Drawing.Size(234, 388)
        Me.MyBookCase1.TabIndex = 30
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Label2)
        Me.pnlTitle.Location = New System.Drawing.Point(1, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(306, 23)
        Me.pnlTitle.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(230, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "کتابخانه من"
        '
        'pnlContent
        '
        Me.pnlContent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.pnlMenu)
        Me.pnlContent.Controls.Add(Me.TooltipBookCase1)
        Me.pnlContent.Controls.Add(Me.lvCase)
        Me.pnlContent.Controls.Add(Me.MyBookCase1)
        Me.pnlContent.Location = New System.Drawing.Point(2, 23)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(305, 464)
        Me.pnlContent.TabIndex = 35
        '
        'pnlMenu
        '
        Me.pnlMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.pnlMenu.Controls.Add(Me.pbAdd)
        Me.pnlMenu.Controls.Add(Me.pbDel)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(43, 464)
        Me.pnlMenu.TabIndex = 37
        '
        'pbAdd
        '
        Me.pbAdd.BackgroundImage = Global.LawyerApp.My.Resources.Resources.shelfAdd
        Me.pbAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAdd.FlatAppearance.BorderSize = 0
        Me.pbAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.pbAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.pbAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pbAdd.Location = New System.Drawing.Point(7, 156)
        Me.pbAdd.Name = "pbAdd"
        Me.pbAdd.Size = New System.Drawing.Size(31, 32)
        Me.pbAdd.TabIndex = 23
        Me.pbAdd.UseVisualStyleBackColor = True
        '
        'pbDel
        '
        Me.pbDel.BackgroundImage = Global.LawyerApp.My.Resources.Resources.Recycle_Full
        Me.pbDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbDel.FlatAppearance.BorderSize = 0
        Me.pbDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.pbDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.pbDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pbDel.Location = New System.Drawing.Point(7, 227)
        Me.pbDel.Name = "pbDel"
        Me.pbDel.Size = New System.Drawing.Size(31, 32)
        Me.pbDel.TabIndex = 22
        Me.pbDel.UseVisualStyleBackColor = True
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
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(1, 487)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(306, 26)
        Me.pnlMsg.TabIndex = 78
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(3, 2)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(300, 13)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'BookView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 535)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.pnlMsg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BookView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "کتابخانه من"
        Me.Controls.SetChildIndex(Me.pnlMsg, 0)
        Me.Controls.SetChildIndex(Me.pnlTitle, 0)
        Me.Controls.SetChildIndex(Me.pnlContent, 0)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyBookCase1 As WFControls.VB.ucBookCase
    Friend WithEvents TooltipBookCase1 As WFControls.CS.TooltipBookCase
    Friend WithEvents lvCase As System.Windows.Forms.ListView
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents pbDel As System.Windows.Forms.Button
    Friend WithEvents pbAdd As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox

End Class
