<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports
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
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reports))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.TextBox
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.btnContactSearh = New System.Windows.Forms.Button
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.grpFilecase = New System.Windows.Forms.GroupBox
        Me.rdbOpen = New System.Windows.Forms.RadioButton
        Me.rdbClose = New System.Windows.Forms.RadioButton
        Me.UcContacts1 = New WFControls.VB.ucContacts
        Me.txtReportTitle = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.گزارشاتتحلیلیToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolstripReportBySubject = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolstripReportByMovakel = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemMali = New System.Windows.Forms.ToolStripMenuItem
        Me.fromDate = New WFControls.VB.RmanShamsiDate
        Me.toDate = New WFControls.VB.RmanShamsiDate
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtContent = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlMsg.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpFilecase.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None
        ReportDataSource1.Name = "rpt_DataSet_dt_rptIncoming"
        ReportDataSource1.Value = Nothing
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "LawyerApp.Incoming.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(5, 3)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ReportViewer1.Size = New System.Drawing.Size(799, 508)
        Me.ReportViewer1.TabIndex = 0
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 589)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlMsg.Size = New System.Drawing.Size(811, 25)
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
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(811, 13)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.btnContactSearh)
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(7, 21)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(811, 23)
        Me.pnlTitle.TabIndex = 78
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
        Me.btnContactSearh.Location = New System.Drawing.Point(3, 0)
        Me.btnContactSearh.Name = "btnContactSearh"
        Me.btnContactSearh.Size = New System.Drawing.Size(20, 20)
        Me.btnContactSearh.TabIndex = 12
        Me.btnContactSearh.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(702, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(93, 13)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "گزارشات تحلیلی"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Controls.Add(Me.pnlMsg)
        Me.Panel1.Location = New System.Drawing.Point(7, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(811, 614)
        Me.Panel1.TabIndex = 79
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpFilecase)
        Me.SplitContainer1.Panel1.Controls.Add(Me.UcContacts1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtReportTitle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTitle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.fromDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.toDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtContent)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(811, 589)
        Me.SplitContainer1.SplitterDistance = 75
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 83
        '
        'grpFilecase
        '
        Me.grpFilecase.Controls.Add(Me.rdbOpen)
        Me.grpFilecase.Controls.Add(Me.rdbClose)
        Me.grpFilecase.Location = New System.Drawing.Point(670, 28)
        Me.grpFilecase.Name = "grpFilecase"
        Me.grpFilecase.Size = New System.Drawing.Size(134, 36)
        Me.grpFilecase.TabIndex = 86
        Me.grpFilecase.TabStop = False
        Me.grpFilecase.Text = "وضعیت پرونده"
        '
        'rdbOpen
        '
        Me.rdbOpen.AutoSize = True
        Me.rdbOpen.Checked = True
        Me.rdbOpen.Location = New System.Drawing.Point(72, 15)
        Me.rdbOpen.Name = "rdbOpen"
        Me.rdbOpen.Size = New System.Drawing.Size(49, 17)
        Me.rdbOpen.TabIndex = 1
        Me.rdbOpen.TabStop = True
        Me.rdbOpen.Text = "جاری"
        Me.rdbOpen.UseVisualStyleBackColor = True
        '
        'rdbClose
        '
        Me.rdbClose.AutoSize = True
        Me.rdbClose.Location = New System.Drawing.Point(6, 15)
        Me.rdbClose.Name = "rdbClose"
        Me.rdbClose.Size = New System.Drawing.Size(59, 17)
        Me.rdbClose.TabIndex = 0
        Me.rdbClose.Text = "مختومه"
        Me.rdbClose.UseVisualStyleBackColor = True
        '
        'UcContacts1
        '
        Me.UcContacts1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.UcContacts1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcContacts1.Location = New System.Drawing.Point(399, 68)
        Me.UcContacts1.Name = "UcContacts1"
        Me.UcContacts1.Size = New System.Drawing.Size(204, 22)
        Me.UcContacts1.TabIndex = 85
        '
        'txtReportTitle
        '
        Me.txtReportTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReportTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtReportTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReportTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtReportTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.txtReportTitle.Location = New System.Drawing.Point(217, 2)
        Me.txtReportTitle.Multiline = True
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.ReadOnly = True
        Me.txtReportTitle.Size = New System.Drawing.Size(327, 20)
        Me.txtReportTitle.TabIndex = 84
        Me.txtReportTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Image = Global.LawyerApp.My.Resources.Resources.Search11
        Me.btnSearch.Location = New System.Drawing.Point(377, 41)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(20, 20)
        Me.btnSearch.TabIndex = 84
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTitle.Location = New System.Drawing.Point(606, 45)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(46, 14)
        Me.txtTitle.TabIndex = 83
        Me.txtTitle.Text = "موضوع :"
        Me.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.گزارشاتتحلیلیToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(809, 24)
        Me.MenuStrip1.TabIndex = 78
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'گزارشاتتحلیلیToolStripMenuItem
        '
        Me.گزارشاتتحلیلیToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolstripReportBySubject, Me.ToolstripReportByMovakel, Me.ToolStripMenuItemMali})
        Me.گزارشاتتحلیلیToolStripMenuItem.Name = "گزارشاتتحلیلیToolStripMenuItem"
        Me.گزارشاتتحلیلیToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.گزارشاتتحلیلیToolStripMenuItem.Text = "گزارشات تحلیلی"
        '
        'ToolstripReportBySubject
        '
        Me.ToolstripReportBySubject.Image = Global.LawyerApp.My.Resources.Resources.bullet_blue_alt2
        Me.ToolstripReportBySubject.Name = "ToolstripReportBySubject"
        Me.ToolstripReportBySubject.Size = New System.Drawing.Size(210, 22)
        Me.ToolstripReportBySubject.Text = "گزارش براساس موضوع دعوی"
        '
        'ToolstripReportByMovakel
        '
        Me.ToolstripReportByMovakel.Image = Global.LawyerApp.My.Resources.Resources.bullet_blue_alt2
        Me.ToolstripReportByMovakel.Name = "ToolstripReportByMovakel"
        Me.ToolstripReportByMovakel.Size = New System.Drawing.Size(210, 22)
        Me.ToolstripReportByMovakel.Text = "گزارش کلی پرونده ها"
        '
        'ToolStripMenuItemMali
        '
        Me.ToolStripMenuItemMali.Image = Global.LawyerApp.My.Resources.Resources.bullet_blue_alt2
        Me.ToolStripMenuItemMali.Name = "ToolStripMenuItemMali"
        Me.ToolStripMenuItemMali.Size = New System.Drawing.Size(210, 22)
        Me.ToolStripMenuItemMali.Text = "گزارش مالی پرونده ها"
        '
        'fromDate
        '
        Me.fromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.fromDate.Location = New System.Drawing.Point(190, 37)
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Size = New System.Drawing.Size(125, 27)
        Me.fromDate.TabIndex = 79
        '
        'toDate
        '
        Me.toDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.toDate.Location = New System.Drawing.Point(10, 37)
        Me.toDate.Name = "toDate"
        Me.toDate.Size = New System.Drawing.Size(130, 27)
        Me.toDate.TabIndex = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "تا تاریخ :"
        '
        'txtContent
        '
        Me.txtContent.Location = New System.Drawing.Point(403, 41)
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(200, 21)
        Me.txtContent.TabIndex = 81
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(318, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "از تاریخ :"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'Reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 665)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Reports"
        Me.Text = "گزارش چاپی"
        Me.Controls.SetChildIndex(Me.pnlTitle, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpFilecase.ResumeLayout(False)
        Me.grpFilecase.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents گزارشاتتحلیلیToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolstripReportBySubject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toDate As WFControls.VB.RmanShamsiDate
    Friend WithEvents fromDate As WFControls.VB.RmanShamsiDate
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtReportTitle As System.Windows.Forms.TextBox
    Friend WithEvents ToolstripReportByMovakel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnContactSearh As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents UcContacts1 As WFControls.VB.ucContacts
    Friend WithEvents ToolStripMenuItemMali As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpFilecase As System.Windows.Forms.GroupBox
    Friend WithEvents rdbOpen As System.Windows.Forms.RadioButton
    Friend WithEvents rdbClose As System.Windows.Forms.RadioButton
End Class
