<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewTimingAdd
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewTimingAdd))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.btnMyComputer = New System.Windows.Forms.Button()
        Me.btnContacts = New System.Windows.Forms.Button()
        Me.lblfrmTitle = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lnkChangeDesign = New System.Windows.Forms.LinkLabel()
        Me.pnlCollapse = New System.Windows.Forms.PictureBox()
        Me.pnlAdd = New System.Windows.Forms.Panel()
        Me.NewTimingAdd1 = New WFControls.VB.NewTimingAdd()
        Me.pnlTitle.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ارجاع به..."
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.btnMyComputer)
        Me.pnlTitle.Controls.Add(Me.btnContacts)
        Me.pnlTitle.Controls.Add(Me.lblfrmTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(6, 1)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(580, 23)
        Me.pnlTitle.TabIndex = 6
        '
        'btnMyComputer
        '
        Me.btnMyComputer.BackgroundImage = Global.LawyerApp.My.Resources.Resources.myComputer20
        Me.btnMyComputer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMyComputer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMyComputer.FlatAppearance.BorderSize = 0
        Me.btnMyComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMyComputer.Location = New System.Drawing.Point(35, 2)
        Me.btnMyComputer.Name = "btnMyComputer"
        Me.btnMyComputer.Size = New System.Drawing.Size(20, 20)
        Me.btnMyComputer.TabIndex = 12
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
        Me.btnContacts.Location = New System.Drawing.Point(9, 0)
        Me.btnContacts.Name = "btnContacts"
        Me.btnContacts.Size = New System.Drawing.Size(20, 20)
        Me.btnContacts.TabIndex = 11
        Me.btnContacts.UseVisualStyleBackColor = True
        '
        'lblfrmTitle
        '
        Me.lblfrmTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblfrmTitle.AutoSize = True
        Me.lblfrmTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfrmTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblfrmTitle.Location = New System.Drawing.Point(328, 4)
        Me.lblfrmTitle.Name = "lblfrmTitle"
        Me.lblfrmTitle.Size = New System.Drawing.Size(48, 13)
        Me.lblfrmTitle.TabIndex = 1
        Me.lblfrmTitle.Text = "اقدامات"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSearch)
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlAdd)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(6, 24)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(578, 308)
        Me.FlowLayoutPanel2.TabIndex = 9
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlSearch.Controls.Add(Me.btnRefresh)
        Me.pnlSearch.Controls.Add(Me.btnPrint)
        Me.pnlSearch.Controls.Add(Me.pnlMsg)
        Me.pnlSearch.Controls.Add(Me.DataGridView1)
        Me.pnlSearch.Location = New System.Drawing.Point(0, 0)
        Me.pnlSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(578, 190)
        Me.pnlSearch.TabIndex = 26
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Image = Global.LawyerApp.My.Resources.Resources.refresh2
        Me.btnRefresh.Location = New System.Drawing.Point(40, 0)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(25, 22)
        Me.btnRefresh.TabIndex = 77
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Image = Global.LawyerApp.My.Resources.Resources.printerWeb
        Me.btnPrint.Location = New System.Drawing.Point(9, 0)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(25, 22)
        Me.btnPrint.TabIndex = 76
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 164)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(578, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(3, 5)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(558, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "lblMessage"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(40, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(6, 23)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowTemplate.Height = 26
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(567, 135)
        Me.DataGridView1.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lnkChangeDesign)
        Me.Panel3.Controls.Add(Me.pnlCollapse)
        Me.Panel3.Location = New System.Drawing.Point(453, 190)
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
        Me.lnkChangeDesign.Location = New System.Drawing.Point(13, 1)
        Me.lnkChangeDesign.Name = "lnkChangeDesign"
        Me.lnkChangeDesign.Size = New System.Drawing.Size(97, 13)
        Me.lnkChangeDesign.TabIndex = 4
        Me.lnkChangeDesign.TabStop = True
        Me.lnkChangeDesign.Text = "اقدامات ثبت شده"
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
        'pnlAdd
        '
        Me.pnlAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlAdd.Controls.Add(Me.NewTimingAdd1)
        Me.pnlAdd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.pnlAdd.Location = New System.Drawing.Point(76, 208)
        Me.pnlAdd.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAdd.Name = "pnlAdd"
        Me.pnlAdd.Size = New System.Drawing.Size(502, 100)
        Me.pnlAdd.TabIndex = 0
        '
        'NewTimingAdd1
        '
        Me.NewTimingAdd1.AutoSize = True
        Me.NewTimingAdd1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.NewTimingAdd1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.NewTimingAdd1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.NewTimingAdd1.Location = New System.Drawing.Point(2, 0)
        Me.NewTimingAdd1.Margin = New System.Windows.Forms.Padding(0)
        Me.NewTimingAdd1.Name = "NewTimingAdd1"
        Me.NewTimingAdd1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NewTimingAdd1.Size = New System.Drawing.Size(502, 508)
        Me.NewTimingAdd1.TabIndex = 0
        '
        'frmNewTimingAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 507)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmNewTimingAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pnlCollapse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAdd.ResumeLayout(False)
        Me.pnlAdd.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents lblfrmTitle As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnContacts As System.Windows.Forms.Button
    Friend WithEvents btnMyComputer As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lnkChangeDesign As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlCollapse As System.Windows.Forms.PictureBox
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents pnlAdd As System.Windows.Forms.Panel
    Friend WithEvents NewTimingAdd1 As WFControls.VB.NewTimingAdd
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button

End Class
