Imports WFControls.VB

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlReports
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.گزارشاتتحلیلیToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolstripReportBySubject = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolstripReportByMovakel = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemMali = New System.Windows.Forms.ToolStripMenuItem
        Me.txtReportTitle = New System.Windows.Forms.TextBox
        Me.grpFilecase = New System.Windows.Forms.GroupBox
        Me.rdbOpen = New System.Windows.Forms.RadioButton
        Me.rdbClose = New System.Windows.Forms.RadioButton
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtContent = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UcContacts1 = New WFControls.VB.ucContacts
        Me.toDate = New RmanShamsiDate
        Me.fromDate = New RmanShamsiDate
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.lblTitle = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.grpFilecase.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.گزارشاتتحلیلیToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(773, 24)
        Me.MenuStrip1.TabIndex = 79
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'گزارشاتتحلیلیToolStripMenuItem
        '
        Me.گزارشاتتحلیلیToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolstripReportBySubject, Me.ToolstripReportByMovakel, Me.ToolStripMenuItemMali})
        Me.گزارشاتتحلیلیToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.گزارشاتتحلیلیToolStripMenuItem.Name = "گزارشاتتحلیلیToolStripMenuItem"
        Me.گزارشاتتحلیلیToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.گزارشاتتحلیلیToolStripMenuItem.Text = "گزارشات تحلیلی"
        '
        'ToolstripReportBySubject
        '
        Me.ToolstripReportBySubject.Name = "ToolstripReportBySubject"
        Me.ToolstripReportBySubject.Size = New System.Drawing.Size(221, 22)
        Me.ToolstripReportBySubject.Text = "گزارش براساس موضوع دعوی"
        '
        'ToolstripReportByMovakel
        '
        Me.ToolstripReportByMovakel.Name = "ToolstripReportByMovakel"
        Me.ToolstripReportByMovakel.Size = New System.Drawing.Size(221, 22)
        Me.ToolstripReportByMovakel.Text = "گزارش کلی پرونده ها"
        '
        'ToolStripMenuItemMali
        '
        Me.ToolStripMenuItemMali.Name = "ToolStripMenuItemMali"
        Me.ToolStripMenuItemMali.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItemMali.Text = "گزارش مالی پرونده ها"
        '
        'txtReportTitle
        '
        Me.txtReportTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReportTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtReportTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReportTitle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtReportTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.txtReportTitle.Location = New System.Drawing.Point(351, 3)
        Me.txtReportTitle.Multiline = True
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.ReadOnly = True
        Me.txtReportTitle.Size = New System.Drawing.Size(273, 20)
        Me.txtReportTitle.TabIndex = 85
        Me.txtReportTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpFilecase
        '
        Me.grpFilecase.Controls.Add(Me.rdbOpen)
        Me.grpFilecase.Controls.Add(Me.rdbClose)
        Me.grpFilecase.Location = New System.Drawing.Point(630, 3)
        Me.grpFilecase.Name = "grpFilecase"
        Me.grpFilecase.Size = New System.Drawing.Size(134, 36)
        Me.grpFilecase.TabIndex = 92
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
        'btnSearch
        '
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(380, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(20, 20)
        Me.btnSearch.TabIndex = 91
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTitle.Location = New System.Drawing.Point(578, 20)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(46, 14)
        Me.txtTitle.TabIndex = 90
        Me.txtTitle.Text = "موضوع :"
        Me.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(133, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "تا تاریخ :"
        '
        'txtContent
        '
        Me.txtContent.Location = New System.Drawing.Point(372, 16)
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(200, 21)
        Me.txtContent.TabIndex = 87
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(321, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "از تاریخ :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.UcContacts1)
        Me.Panel1.Controls.Add(Me.toDate)
        Me.Panel1.Controls.Add(Me.fromDate)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtContent)
        Me.Panel1.Controls.Add(Me.grpFilecase)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(773, 47)
        Me.Panel1.TabIndex = 93
        '
        'UcContacts1
        '
        Me.UcContacts1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.UcContacts1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UcContacts1.Location = New System.Drawing.Point(373, 40)
        Me.UcContacts1.Name = "UcContacts1"
        Me.UcContacts1.Size = New System.Drawing.Size(200, 20)
        Me.UcContacts1.TabIndex = 95
        '
        'toDate
        '
        Me.toDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.toDate.Location = New System.Drawing.Point(6, 12)
        Me.toDate.Name = "toDate"
        Me.toDate.Size = New System.Drawing.Size(121, 27)
        Me.toDate.TabIndex = 94
        '
        'fromDate
        '
        Me.fromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.fromDate.Location = New System.Drawing.Point(194, 12)
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Size = New System.Drawing.Size(121, 27)
        Me.fromDate.TabIndex = 93
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 71)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(773, 450)
        Me.ReportViewer1.TabIndex = 94
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(3, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(93, 13)
        Me.lblTitle.TabIndex = 96
        Me.lblTitle.Text = "گزارشات تحلیلی"
        '
        'UserControlReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtReportTitle)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "UserControlReports"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(773, 521)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpFilecase.ResumeLayout(False)
        Me.grpFilecase.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents گزارشاتتحلیلیToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolstripReportBySubject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolstripReportByMovakel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMali As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtReportTitle As System.Windows.Forms.TextBox
    Friend WithEvents grpFilecase As System.Windows.Forms.GroupBox
    Friend WithEvents rdbOpen As System.Windows.Forms.RadioButton
    Friend WithEvents rdbClose As System.Windows.Forms.RadioButton
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents toDate As RmanShamsiDate
    Friend WithEvents fromDate As RmanShamsiDate
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents UcContacts1 As WFControls.VB.ucContacts
    Friend WithEvents lblTitle As System.Windows.Forms.Label

End Class
