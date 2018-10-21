<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewTimingSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewTimingSearch))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.btnMyComputer = New System.Windows.Forms.Button()
        Me.btnContactSearh = New System.Windows.Forms.Button()
        Me.lblfrmTitle = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lnkChangeDesign = New System.Windows.Forms.LinkLabel()
        Me.pnlCollapse = New System.Windows.Forms.PictureBox()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.NewTimingSearch1 = New WFControls.VB.NewTimingSearch()
        Me.pnlAdd = New System.Windows.Forms.Panel()
        Me.NewTimingAdd1 = New WFControls.VB.NewTimingAdd()
        Me.pnlTitle.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearch.SuspendLayout()
        Me.pnlAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.btnMyComputer)
        Me.pnlTitle.Controls.Add(Me.btnContactSearh)
        Me.pnlTitle.Controls.Add(Me.lblfrmTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(9, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(562, 23)
        Me.pnlTitle.TabIndex = 6
        '
        'btnMyComputer
        '
        Me.btnMyComputer.BackgroundImage = Global.LawyerApp.My.Resources.Resources.myComputer20
        Me.btnMyComputer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMyComputer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMyComputer.FlatAppearance.BorderSize = 0
        Me.btnMyComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMyComputer.Location = New System.Drawing.Point(31, 1)
        Me.btnMyComputer.Name = "btnMyComputer"
        Me.btnMyComputer.Size = New System.Drawing.Size(20, 20)
        Me.btnMyComputer.TabIndex = 13
        Me.btnMyComputer.UseVisualStyleBackColor = True
        '
        'btnContactSearh
        '
        Me.btnContactSearh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnContactSearh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContactSearh.FlatAppearance.BorderSize = 0
        Me.btnContactSearh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContactSearh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContactSearh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContactSearh.Image = Global.LawyerApp.My.Resources.Resources.contact20
        Me.btnContactSearh.Location = New System.Drawing.Point(5, 0)
        Me.btnContactSearh.Name = "btnContactSearh"
        Me.btnContactSearh.Size = New System.Drawing.Size(20, 20)
        Me.btnContactSearh.TabIndex = 12
        Me.btnContactSearh.UseVisualStyleBackColor = True
        '
        'lblfrmTitle
        '
        Me.lblfrmTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblfrmTitle.AutoSize = True
        Me.lblfrmTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrmTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblfrmTitle.Location = New System.Drawing.Point(388, 7)
        Me.lblfrmTitle.Name = "lblfrmTitle"
        Me.lblfrmTitle.Size = New System.Drawing.Size(48, 13)
        Me.lblfrmTitle.TabIndex = 1
        Me.lblfrmTitle.Text = "اقدامات"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlSearch)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlAdd)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(8, 25)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(564, 382)
        Me.FlowLayoutPanel1.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lnkChangeDesign)
        Me.Panel3.Controls.Add(Me.pnlCollapse)
        Me.Panel3.Location = New System.Drawing.Point(439, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(125, 18)
        Me.Panel3.TabIndex = 25
        '
        'lnkChangeDesign
        '
        Me.lnkChangeDesign.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChangeDesign.AutoSize = True
        Me.lnkChangeDesign.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lnkChangeDesign.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChangeDesign.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lnkChangeDesign.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnkChangeDesign.Location = New System.Drawing.Point(36, 2)
        Me.lnkChangeDesign.Name = "lnkChangeDesign"
        Me.lnkChangeDesign.Size = New System.Drawing.Size(56, 13)
        Me.lnkChangeDesign.TabIndex = 4
        Me.lnkChangeDesign.TabStop = True
        Me.lnkChangeDesign.Text = "ثبت اقدام"
        Me.lnkChangeDesign.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'pnlCollapse
        '
        Me.pnlCollapse.Location = New System.Drawing.Point(562, 5)
        Me.pnlCollapse.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlCollapse.Name = "pnlCollapse"
        Me.pnlCollapse.Size = New System.Drawing.Size(13, 13)
        Me.pnlCollapse.TabIndex = 3
        Me.pnlCollapse.TabStop = False
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlSearch.Controls.Add(Me.NewTimingSearch1)
        Me.pnlSearch.Location = New System.Drawing.Point(0, 18)
        Me.pnlSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(564, 109)
        Me.pnlSearch.TabIndex = 8
        '
        'NewTimingSearch1
        '
        Me.NewTimingSearch1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.NewTimingSearch1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.NewTimingSearch1.Location = New System.Drawing.Point(0, 2)
        Me.NewTimingSearch1.Margin = New System.Windows.Forms.Padding(1)
        Me.NewTimingSearch1.Name = "NewTimingSearch1"
        Me.NewTimingSearch1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NewTimingSearch1.Size = New System.Drawing.Size(564, 621)
        Me.NewTimingSearch1.TabIndex = 0
        '
        'pnlAdd
        '
        Me.pnlAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlAdd.Controls.Add(Me.NewTimingAdd1)
        Me.pnlAdd.Location = New System.Drawing.Point(62, 127)
        Me.pnlAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAdd.Name = "pnlAdd"
        Me.pnlAdd.Size = New System.Drawing.Size(502, 255)
        Me.pnlAdd.TabIndex = 26
        '
        'NewTimingAdd1
        '
        Me.NewTimingAdd1.AutoSize = True
        Me.NewTimingAdd1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.NewTimingAdd1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.NewTimingAdd1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.NewTimingAdd1.Location = New System.Drawing.Point(-3, 22)
        Me.NewTimingAdd1.Margin = New System.Windows.Forms.Padding(0)
        Me.NewTimingAdd1.Name = "NewTimingAdd1"
        Me.NewTimingAdd1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NewTimingAdd1.Size = New System.Drawing.Size(502, 508)
        Me.NewTimingAdd1.TabIndex = 0
        '
        'frmNewTimingSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 538)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmNewTimingSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlAdd.ResumeLayout(False)
        Me.pnlAdd.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblfrmTitle As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnContactSearh As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lnkChangeDesign As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlCollapse As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAdd As System.Windows.Forms.Panel
    Friend WithEvents NewTimingAdd1 As WFControls.VB.NewTimingAdd
    Friend WithEvents NewTimingSearch1 As WFControls.VB.NewTimingSearch
    Friend WithEvents btnMyComputer As System.Windows.Forms.Button
End Class
