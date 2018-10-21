<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseFiles
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BrowseFiles))
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.btnContactSearh = New System.Windows.Forms.Button()
        Me.btnMyComputer = New System.Windows.Forms.Button()
        Me.btnBrowsDocs = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FileList1 = New WFControls.VB.FileList()
        Me.pnlTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.btnContactSearh)
        Me.pnlTitle.Controls.Add(Me.btnMyComputer)
        Me.pnlTitle.Controls.Add(Me.btnBrowsDocs)
        Me.pnlTitle.Controls.Add(Me.Label2)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(789, 23)
        Me.pnlTitle.TabIndex = 7
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
        Me.btnContactSearh.Location = New System.Drawing.Point(32, 0)
        Me.btnContactSearh.Name = "btnContactSearh"
        Me.btnContactSearh.Size = New System.Drawing.Size(20, 20)
        Me.btnContactSearh.TabIndex = 11
        Me.btnContactSearh.UseVisualStyleBackColor = True
        '
        'btnMyComputer
        '
        Me.btnMyComputer.BackgroundImage = Global.LawyerApp.My.Resources.Resources.myComputer20
        Me.btnMyComputer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMyComputer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMyComputer.FlatAppearance.BorderSize = 0
        Me.btnMyComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMyComputer.Location = New System.Drawing.Point(10, 2)
        Me.btnMyComputer.Name = "btnMyComputer"
        Me.btnMyComputer.Size = New System.Drawing.Size(20, 20)
        Me.btnMyComputer.TabIndex = 5
        Me.btnMyComputer.UseVisualStyleBackColor = True
        '
        'btnBrowsDocs
        '
        Me.btnBrowsDocs.BackgroundImage = Global.LawyerApp.My.Resources.Resources.BrawsDocs
        Me.btnBrowsDocs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBrowsDocs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBrowsDocs.FlatAppearance.BorderSize = 0
        Me.btnBrowsDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowsDocs.Location = New System.Drawing.Point(58, 4)
        Me.btnBrowsDocs.Name = "btnBrowsDocs"
        Me.btnBrowsDocs.Size = New System.Drawing.Size(16, 16)
        Me.btnBrowsDocs.TabIndex = 4
        Me.btnBrowsDocs.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(689, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "تشکیل پرونده"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'FileList1
        '
        Me.FileList1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.FileList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileList1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FileList1.Location = New System.Drawing.Point(0, 23)
        Me.FileList1.Name = "FileList1"
        Me.FileList1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FileList1.Size = New System.Drawing.Size(789, 643)
        Me.FileList1.TabIndex = 8
        '
        'BrowseFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(789, 666)
        Me.Controls.Add(Me.FileList1)
        Me.Controls.Add(Me.pnlTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BrowseFiles"
        Me.Text = "تشکیل پرونده"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBrowsDocs As System.Windows.Forms.Button
    Friend WithEvents btnMyComputer As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnContactSearh As System.Windows.Forms.Button
    Friend WithEvents FileList1 As WFControls.VB.FileList


End Class
