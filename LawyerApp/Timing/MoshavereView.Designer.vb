<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MoshavereView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MoshavereView))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Moshavere1 = New WFControls.VB.Moshavere()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.btnMyComputer = New System.Windows.Forms.Button()
        Me.btnContacts = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlTitle.SuspendLayout()
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
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'Moshavere1
        '
        Me.Moshavere1.AutoSize = True
        Me.Moshavere1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Moshavere1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Moshavere1.Location = New System.Drawing.Point(6, 26)
        Me.Moshavere1.Margin = New System.Windows.Forms.Padding(0)
        Me.Moshavere1.Name = "Moshavere1"
        Me.Moshavere1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Moshavere1.Size = New System.Drawing.Size(516, 496)
        Me.Moshavere1.TabIndex = 9
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.btnMyComputer)
        Me.pnlTitle.Controls.Add(Me.btnContacts)
        Me.pnlTitle.Controls.Add(Me.Label3)
        Me.pnlTitle.Location = New System.Drawing.Point(7, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(516, 36)
        Me.pnlTitle.TabIndex = 8
        '
        'btnMyComputer
        '
        Me.btnMyComputer.BackgroundImage = Global.LawyerApp.My.Resources.Resources.myComputer20
        Me.btnMyComputer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMyComputer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMyComputer.FlatAppearance.BorderSize = 0
        Me.btnMyComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMyComputer.Location = New System.Drawing.Point(33, 2)
        Me.btnMyComputer.Name = "btnMyComputer"
        Me.btnMyComputer.Size = New System.Drawing.Size(20, 20)
        Me.btnMyComputer.TabIndex = 15
        Me.btnMyComputer.UseVisualStyleBackColor = True
        '
        'btnContacts
        '
        Me.btnContacts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnContacts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContacts.FlatAppearance.BorderSize = 0
        Me.btnContacts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContacts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContacts.Image = Global.LawyerApp.My.Resources.Resources.contact20
        Me.btnContacts.Location = New System.Drawing.Point(7, 0)
        Me.btnContacts.Name = "btnContacts"
        Me.btnContacts.Size = New System.Drawing.Size(20, 20)
        Me.btnContacts.TabIndex = 14
        Me.btnContacts.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(310, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "مشاهده مشاوره"
        '
        'MoshavereView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 531)
        Me.Controls.Add(Me.Moshavere1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MoshavereView"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Moshavere1 As WFControls.VB.Moshavere
    Friend WithEvents btnMyComputer As System.Windows.Forms.Button
    Friend WithEvents btnContacts As System.Windows.Forms.Button
End Class
