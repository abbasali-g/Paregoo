<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWinExplorer
    Inherits GlobalForm2

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWinExplorer))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cb1 = New System.Windows.Forms.ComboBox
        Me.lv1 = New System.Windows.Forms.ListView
        Me.ExpTree1 = New WFControls.VB.ExpTree
        Me.lblTitle = New System.Windows.Forms.Label
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.sbr1 = New System.Windows.Forms.StatusBar
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(6, 43)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cb1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lv1)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ExpTree1)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(456, 356)
        Me.SplitContainer1.SplitterDistance = 300
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 4
        '
        'cb1
        '
        Me.cb1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cb1.BackColor = System.Drawing.Color.White
        Me.cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cb1.ForeColor = System.Drawing.Color.Black
        Me.cb1.FormattingEnabled = True
        Me.cb1.Location = New System.Drawing.Point(4, 5)
        Me.cb1.Name = "cb1"
        Me.cb1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cb1.Size = New System.Drawing.Size(288, 21)
        Me.cb1.TabIndex = 1
        '
        'lv1
        '
        Me.lv1.AllowDrop = True
        Me.lv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv1.BackColor = System.Drawing.Color.White
        Me.lv1.Location = New System.Drawing.Point(4, 30)
        Me.lv1.Name = "lv1"
        Me.lv1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lv1.Size = New System.Drawing.Size(289, 319)
        Me.lv1.TabIndex = 0
        Me.lv1.UseCompatibleStateImageBehavior = False
        '
        'ExpTree1
        '
        Me.ExpTree1.AllowDrop = True
        Me.ExpTree1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExpTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpTree1.Location = New System.Drawing.Point(0, 0)
        Me.ExpTree1.Name = "ExpTree1"
        Me.ExpTree1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExpTree1.ShowRootLines = False
        Me.ExpTree1.Size = New System.Drawing.Size(152, 354)
        Me.ExpTree1.StartUpDirectory = WFControls.VB.ExpTree.StartDir.Desktop
        Me.ExpTree1.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(422, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(45, 13)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "lblTitle"
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Label2)
        Me.pnlTitle.Location = New System.Drawing.Point(6, 20)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(456, 23)
        Me.pnlTitle.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(387, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Desktop"
        '
        'sbr1
        '
        Me.sbr1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sbr1.Dock = System.Windows.Forms.DockStyle.None
        Me.sbr1.Location = New System.Drawing.Point(6, 399)
        Me.sbr1.Name = "sbr1"
        Me.sbr1.Size = New System.Drawing.Size(456, 17)
        Me.sbr1.TabIndex = 7
        Me.sbr1.Text = "Ready"
        '
        'frmWinExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 422)
        Me.Controls.Add(Me.sbr1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWinExplorer"
        Me.Text = "DeskTop"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.pnlTitle, 0)
        Me.Controls.SetChildIndex(Me.sbr1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExpTree1 As WFControls.VB.ExpTree
    Friend WithEvents lv1 As System.Windows.Forms.ListView
    Friend WithEvents sbr1 As System.Windows.Forms.StatusBar
    Friend WithEvents cb1 As System.Windows.Forms.ComboBox
End Class
