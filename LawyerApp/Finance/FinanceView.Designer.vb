<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinanceView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FinanceView))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblfrmTitle = New System.Windows.Forms.Label()
        Me.btnContacts = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.NewFinanceAdd1 = New WFControls.VB.NewFinanceAdd()
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
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.lblfrmTitle)
        Me.pnlTitle.Controls.Add(Me.btnContacts)
        Me.pnlTitle.Controls.Add(Me.Label3)
        Me.pnlTitle.Location = New System.Drawing.Point(7, 1)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(422, 23)
        Me.pnlTitle.TabIndex = 8
        '
        'lblfrmTitle
        '
        Me.lblfrmTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblfrmTitle.AutoSize = True
        Me.lblfrmTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrmTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblfrmTitle.Location = New System.Drawing.Point(331, 7)
        Me.lblfrmTitle.Name = "lblfrmTitle"
        Me.lblfrmTitle.Size = New System.Drawing.Size(80, 13)
        Me.lblfrmTitle.TabIndex = 15
        Me.lblfrmTitle.Text = "ویرایش هزینه"
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
        Me.Label3.Location = New System.Drawing.Point(311, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 1
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'NewFinanceAdd1
        '
        Me.NewFinanceAdd1.AutoSize = True
        Me.NewFinanceAdd1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.NewFinanceAdd1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.NewFinanceAdd1.Location = New System.Drawing.Point(7, 24)
        Me.NewFinanceAdd1.Name = "NewFinanceAdd1"
        Me.NewFinanceAdd1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NewFinanceAdd1.Size = New System.Drawing.Size(422, 305)
        Me.NewFinanceAdd1.TabIndex = 15
        '
        'FinanceView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 337)
        Me.Controls.Add(Me.NewFinanceAdd1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FinanceView"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnContacts As System.Windows.Forms.Button
    Friend WithEvents NewFinanceAdd1 As WFControls.VB.NewFinanceAdd
    Friend WithEvents lblfrmTitle As System.Windows.Forms.Label
End Class
