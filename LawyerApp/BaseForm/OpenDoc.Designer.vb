<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OpenDoc))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnSaveAndClose = New System.Windows.Forms.Button
        Me.btnFax = New System.Windows.Forms.Button
        Me.btnEmail = New System.Windows.Forms.Button
        Me.btn_top = New System.Windows.Forms.Button
        Me.btn_Down = New System.Windows.Forms.Button
        Me.btn_Right = New System.Windows.Forms.Button
        Me.btn_Left = New System.Windows.Forms.Button
        Me.pbCenter = New System.Windows.Forms.PictureBox
        Me.btnPdf = New System.Windows.Forms.Button
        Me.btnSaveAs = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnPrintDataOnly = New System.Windows.Forms.Button
        ' Me.objWinWordControl = New WinWordControl.WinWordControl
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblTitle = New System.Windows.Forms.TextBox
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.pbCenter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMsg.SuspendLayout()
        Me.pnlTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'splitContainer1
        '
        Me.splitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitContainer1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.splitContainer1.Location = New System.Drawing.Point(9, 46)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.splitContainer1.Panel1.Controls.Add(Me.btnSaveAndClose)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnFax)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnEmail)
        Me.splitContainer1.Panel1.Controls.Add(Me.btn_top)
        Me.splitContainer1.Panel1.Controls.Add(Me.btn_Down)
        Me.splitContainer1.Panel1.Controls.Add(Me.btn_Right)
        Me.splitContainer1.Panel1.Controls.Add(Me.btn_Left)
        Me.splitContainer1.Panel1.Controls.Add(Me.pbCenter)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnPdf)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnSaveAs)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnSave)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnOpen)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnPrint)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnPrintDataOnly)
        Me.splitContainer1.Panel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.splitContainer1.Panel1MinSize = 20
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.objWinWordControl)
        Me.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.splitContainer1.Size = New System.Drawing.Size(884, 551)
        Me.splitContainer1.SplitterDistance = 60
        Me.splitContainer1.SplitterWidth = 1
        Me.splitContainer1.TabIndex = 24
        '
        'btnSaveAndClose
        '
        Me.btnSaveAndClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnSaveAndClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveAndClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveAndClose.FlatAppearance.BorderSize = 0
        Me.btnSaveAndClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAndClose.ForeColor = System.Drawing.SystemColors.Control
        Me.btnSaveAndClose.Image = Global.LawyerApp.My.Resources.Resources.SaveAndClose
        Me.btnSaveAndClose.Location = New System.Drawing.Point(13, 60)
        Me.btnSaveAndClose.Name = "btnSaveAndClose"
        Me.btnSaveAndClose.Size = New System.Drawing.Size(32, 32)
        Me.btnSaveAndClose.TabIndex = 36
        Me.btnSaveAndClose.UseVisualStyleBackColor = False
        '
        'btnFax
        '
        Me.btnFax.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnFax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFax.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFax.FlatAppearance.BorderSize = 0
        Me.btnFax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnFax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFax.ForeColor = System.Drawing.SystemColors.Control
        Me.btnFax.Image = Global.LawyerApp.My.Resources.Resources.Fax
        Me.btnFax.Location = New System.Drawing.Point(13, 452)
        Me.btnFax.Name = "btnFax"
        Me.btnFax.Size = New System.Drawing.Size(32, 32)
        Me.btnFax.TabIndex = 35
        Me.btnFax.UseVisualStyleBackColor = False
        '
        'btnEmail
        '
        Me.btnEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEmail.FlatAppearance.BorderSize = 0
        Me.btnEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmail.ForeColor = System.Drawing.SystemColors.Control
        Me.btnEmail.Image = Global.LawyerApp.My.Resources.Resources.Email
        Me.btnEmail.Location = New System.Drawing.Point(13, 396)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(32, 32)
        Me.btnEmail.TabIndex = 34
        Me.btnEmail.UseVisualStyleBackColor = False
        '
        'btn_top
        '
        Me.btn_top.BackColor = System.Drawing.Color.Transparent
        Me.btn_top.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_top.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_top.FlatAppearance.BorderSize = 0
        Me.btn_top.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_top.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_top.Image = Global.LawyerApp.My.Resources.Resources.arrow_T
        Me.btn_top.Location = New System.Drawing.Point(22, 504)
        Me.btn_top.Name = "btn_top"
        Me.btn_top.Size = New System.Drawing.Size(16, 10)
        Me.btn_top.TabIndex = 32
        Me.btn_top.UseVisualStyleBackColor = False
        '
        'btn_Down
        '
        Me.btn_Down.BackColor = System.Drawing.Color.Transparent
        Me.btn_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Down.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Down.FlatAppearance.BorderSize = 0
        Me.btn_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Down.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_Down.Image = Global.LawyerApp.My.Resources.Resources.arrow_D
        Me.btn_Down.Location = New System.Drawing.Point(22, 530)
        Me.btn_Down.Name = "btn_Down"
        Me.btn_Down.Size = New System.Drawing.Size(16, 10)
        Me.btn_Down.TabIndex = 31
        Me.btn_Down.UseVisualStyleBackColor = False
        '
        'btn_Right
        '
        Me.btn_Right.BackColor = System.Drawing.Color.Transparent
        Me.btn_Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Right.FlatAppearance.BorderSize = 0
        Me.btn_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Right.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_Right.Image = Global.LawyerApp.My.Resources.Resources.arrow_R
        Me.btn_Right.Location = New System.Drawing.Point(37, 514)
        Me.btn_Right.Name = "btn_Right"
        Me.btn_Right.Size = New System.Drawing.Size(10, 16)
        Me.btn_Right.TabIndex = 30
        Me.btn_Right.UseVisualStyleBackColor = False
        '
        'btn_Left
        '
        Me.btn_Left.BackColor = System.Drawing.Color.Transparent
        Me.btn_Left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_Left.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Left.FlatAppearance.BorderSize = 0
        Me.btn_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Left.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_Left.Image = Global.LawyerApp.My.Resources.Resources.arrow_L
        Me.btn_Left.Location = New System.Drawing.Point(12, 514)
        Me.btn_Left.Name = "btn_Left"
        Me.btn_Left.Size = New System.Drawing.Size(10, 16)
        Me.btn_Left.TabIndex = 29
        Me.btn_Left.UseVisualStyleBackColor = False
        '
        'pbCenter
        '
        Me.pbCenter.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.pbCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbCenter.Image = Global.LawyerApp.My.Resources.Resources.rounded_square16
        Me.pbCenter.Location = New System.Drawing.Point(23, 515)
        Me.pbCenter.Name = "pbCenter"
        Me.pbCenter.Size = New System.Drawing.Size(16, 16)
        Me.pbCenter.TabIndex = 33
        Me.pbCenter.TabStop = False
        '
        'btnPdf
        '
        Me.btnPdf.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPdf.FlatAppearance.BorderSize = 0
        Me.btnPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPdf.ForeColor = System.Drawing.SystemColors.Control
        Me.btnPdf.Image = Global.LawyerApp.My.Resources.Resources.pdf
        Me.btnPdf.Location = New System.Drawing.Point(13, 228)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(32, 32)
        Me.btnPdf.TabIndex = 27
        Me.btnPdf.UseVisualStyleBackColor = False
        '
        'btnSaveAs
        '
        Me.btnSaveAs.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnSaveAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveAs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveAs.FlatAppearance.BorderSize = 0
        Me.btnSaveAs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAs.ForeColor = System.Drawing.SystemColors.Control
        Me.btnSaveAs.Image = Global.LawyerApp.My.Resources.Resources.Save_all
        Me.btnSaveAs.Location = New System.Drawing.Point(13, 172)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(32, 32)
        Me.btnSaveAs.TabIndex = 26
        Me.btnSaveAs.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.SystemColors.Control
        Me.btnSave.Image = Global.LawyerApp.My.Resources.Resources.Save
        Me.btnSave.Location = New System.Drawing.Point(13, 116)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(32, 32)
        Me.btnSave.TabIndex = 25
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnOpen
        '
        Me.btnOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpen.FlatAppearance.BorderSize = 0
        Me.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpen.ForeColor = System.Drawing.SystemColors.Control
        Me.btnOpen.Image = Global.LawyerApp.My.Resources.Resources.folderopen
        Me.btnOpen.Location = New System.Drawing.Point(13, 4)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(32, 32)
        Me.btnOpen.TabIndex = 24
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.Control
        Me.btnPrint.Image = Global.LawyerApp.My.Resources.Resources.print_Green
        Me.btnPrint.Location = New System.Drawing.Point(13, 284)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(32, 32)
        Me.btnPrint.TabIndex = 21
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnPrintDataOnly
        '
        Me.btnPrintDataOnly.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnPrintDataOnly.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrintDataOnly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrintDataOnly.FlatAppearance.BorderSize = 0
        Me.btnPrintDataOnly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnPrintDataOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintDataOnly.ForeColor = System.Drawing.SystemColors.Control
        Me.btnPrintDataOnly.Image = Global.LawyerApp.My.Resources.Resources.print
        Me.btnPrintDataOnly.Location = New System.Drawing.Point(13, 340)
        Me.btnPrintDataOnly.Name = "btnPrintDataOnly"
        Me.btnPrintDataOnly.Size = New System.Drawing.Size(32, 32)
        Me.btnPrintDataOnly.TabIndex = 20
        Me.btnPrintDataOnly.UseVisualStyleBackColor = False
        '
        'objWinWordControl
        '
        Me.objWinWordControl.AllowDrop = True
        Me.objWinWordControl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.objWinWordControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.objWinWordControl.Location = New System.Drawing.Point(0, 0)
        Me.objWinWordControl.Name = "objWinWordControl"
        Me.objWinWordControl.Size = New System.Drawing.Size(821, 549)
        Me.objWinWordControl.TabIndex = 3
        Me.objWinWordControl.wDoc = Nothing
        '
        'pnlMsg
        '
        Me.pnlMsg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(8, 596)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(884, 26)
        Me.pnlMsg.TabIndex = 76
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(16, 7)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(860, 13)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "lblMessage"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(15, 5)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(862, 13)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "محتویات فایل"
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(9, 23)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(883, 23)
        Me.pnlTitle.TabIndex = 25
        '
        'OpenDoc
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 628)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.splitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OpenDoc"
        Me.Text = "محتویات فایل"
        Me.Controls.SetChildIndex(Me.splitContainer1, 0)
        Me.Controls.SetChildIndex(Me.pnlTitle, 0)
        Me.Controls.SetChildIndex(Me.pnlMsg, 0)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        CType(Me.pbCenter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    'Private WithEvents objWinWordControl As WinWordControl.WinWordControl
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnPrintDataOnly As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSaveAs As System.Windows.Forms.Button
    Friend WithEvents btnPdf As System.Windows.Forms.Button
    Friend WithEvents btn_Left As System.Windows.Forms.Button
    Friend WithEvents btn_Down As System.Windows.Forms.Button
    Friend WithEvents btn_Right As System.Windows.Forms.Button
    Friend WithEvents btn_top As System.Windows.Forms.Button
    Friend WithEvents pbCenter As System.Windows.Forms.PictureBox
    Friend WithEvents btnEmail As System.Windows.Forms.Button
    Friend WithEvents btnFax As System.Windows.Forms.Button
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSaveAndClose As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.TextBox
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel

End Class
