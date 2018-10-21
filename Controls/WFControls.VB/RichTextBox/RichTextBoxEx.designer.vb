<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RichTextBoxEx
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RichTextBoxEx))
        '  Me.SpellChecker = New NetSpell.SpellChecker.Spelling(Me.components)
        Me.FontDlg = New System.Windows.Forms.FontDialog
        Me.ColorDlg = New System.Windows.Forms.ColorDialog
        Me.OpenFileDlg = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDlg = New System.Windows.Forms.SaveFileDialog
        Me.ctmRich = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tstCut = New System.Windows.Forms.ToolStripTextBox
        Me.tstCopy = New System.Windows.Forms.ToolStripTextBox
        Me.tstPaste = New System.Windows.Forms.ToolStripTextBox
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.FontToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.FontColorToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.BoldToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.UnderlineToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.LeftToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CenterToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.RightToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.BulletsToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SpellcheckToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.PageSetupToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.PreviewToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.FindToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.UndoToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.RedoToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.plnSearch = New System.Windows.Forms.Panel
        Me.chbHighlight = New System.Windows.Forms.CheckBox
        Me.lblMsg = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnFind = New System.Windows.Forms.Button
        Me.txtFind = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.tmsiFind = New System.Windows.Forms.ToolStripMenuItem
        Me.tmsiPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.tmsiFindCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.tmsiNextSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.HS_Rtb = New WFControls.VB.HS.HS_RichTextBox
        Me.ctmRich.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.plnSearch.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SpellChecker
        '
        '''''''''        Me.SpellChecker.Dictionary = Nothing
        '
        'OpenFileDlg
        '
        Me.OpenFileDlg.FileName = "OpenFileDialog1"
        '
        'ctmRich
        '
        Me.ctmRich.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstCut, Me.tstCopy, Me.tstPaste})
        Me.ctmRich.Name = "ctmRich"
        Me.ctmRich.ShowImageMargin = False
        Me.ctmRich.ShowItemToolTips = False
        Me.ctmRich.Size = New System.Drawing.Size(136, 73)
        '
        'tstCut
        '
        Me.tstCut.Name = "tstCut"
        Me.tstCut.ReadOnly = True
        Me.tstCut.Size = New System.Drawing.Size(100, 21)
        Me.tstCut.Text = "Cut"
        '
        'tstCopy
        '
        Me.tstCopy.Name = "tstCopy"
        Me.tstCopy.Size = New System.Drawing.Size(100, 21)
        Me.tstCopy.Text = "Copy"
        '
        'tstPaste
        '
        Me.tstPaste.Name = "tstPaste"
        Me.tstPaste.Size = New System.Drawing.Size(100, 21)
        Me.tstPaste.Text = "Paste"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "&New"
        Me.NewToolStripButton.Visible = False
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        Me.OpenToolStripButton.Visible = False
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        Me.SaveToolStripButton.Visible = False
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'FontToolStripButton
        '
        Me.FontToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FontToolStripButton.Image = CType(resources.GetObject("FontToolStripButton.Image"), System.Drawing.Image)
        Me.FontToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FontToolStripButton.Name = "FontToolStripButton"
        Me.FontToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FontToolStripButton.Text = "Font"
        '
        'FontColorToolStripButton
        '
        Me.FontColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FontColorToolStripButton.Image = CType(resources.GetObject("FontColorToolStripButton.Image"), System.Drawing.Image)
        Me.FontColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FontColorToolStripButton.Name = "FontColorToolStripButton"
        Me.FontColorToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.FontColorToolStripButton.Text = "Font Color"
        '
        'BoldToolStripButton
        '
        Me.BoldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BoldToolStripButton.Image = CType(resources.GetObject("BoldToolStripButton.Image"), System.Drawing.Image)
        Me.BoldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BoldToolStripButton.Name = "BoldToolStripButton"
        Me.BoldToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.BoldToolStripButton.Text = "Bold"
        '
        'UnderlineToolStripButton
        '
        Me.UnderlineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UnderlineToolStripButton.Image = CType(resources.GetObject("UnderlineToolStripButton.Image"), System.Drawing.Image)
        Me.UnderlineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UnderlineToolStripButton.Name = "UnderlineToolStripButton"
        Me.UnderlineToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.UnderlineToolStripButton.Text = "Underline"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'LeftToolStripButton
        '
        Me.LeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LeftToolStripButton.Image = CType(resources.GetObject("LeftToolStripButton.Image"), System.Drawing.Image)
        Me.LeftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LeftToolStripButton.Name = "LeftToolStripButton"
        Me.LeftToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.LeftToolStripButton.Text = "Left"
        '
        'CenterToolStripButton
        '
        Me.CenterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CenterToolStripButton.Image = CType(resources.GetObject("CenterToolStripButton.Image"), System.Drawing.Image)
        Me.CenterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CenterToolStripButton.Name = "CenterToolStripButton"
        Me.CenterToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CenterToolStripButton.Text = "Center"
        '
        'RightToolStripButton
        '
        Me.RightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RightToolStripButton.Image = CType(resources.GetObject("RightToolStripButton.Image"), System.Drawing.Image)
        Me.RightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RightToolStripButton.Name = "RightToolStripButton"
        Me.RightToolStripButton.Size = New System.Drawing.Size(23, 20)
        Me.RightToolStripButton.Text = "Right"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BulletsToolStripButton
        '
        Me.BulletsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BulletsToolStripButton.Image = CType(resources.GetObject("BulletsToolStripButton.Image"), System.Drawing.Image)
        Me.BulletsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BulletsToolStripButton.Name = "BulletsToolStripButton"
        Me.BulletsToolStripButton.Size = New System.Drawing.Size(23, 20)
        Me.BulletsToolStripButton.Text = "Bullets"
        '
        'SpellcheckToolStripButton
        '
        Me.SpellcheckToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SpellcheckToolStripButton.Image = CType(resources.GetObject("SpellcheckToolStripButton.Image"), System.Drawing.Image)
        Me.SpellcheckToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SpellcheckToolStripButton.Name = "SpellcheckToolStripButton"
        Me.SpellcheckToolStripButton.Size = New System.Drawing.Size(23, 20)
        Me.SpellcheckToolStripButton.Text = "Spell Check"
        Me.SpellcheckToolStripButton.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PageSetupToolStripButton1, Me.PreviewToolStripButton1, Me.PrintToolStripButton, Me.FindToolStripButton1, Me.UndoToolStripButton, Me.RedoToolStripButton, Me.toolStripSeparator, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton, Me.ToolStripSeparator2, Me.FontToolStripButton, Me.FontColorToolStripButton, Me.BoldToolStripButton, Me.UnderlineToolStripButton, Me.ToolStripSeparator4, Me.LeftToolStripButton, Me.CenterToolStripButton, Me.RightToolStripButton, Me.ToolStripSeparator3, Me.BulletsToolStripButton, Me.SpellcheckToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(400, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'PageSetupToolStripButton1
        '
        Me.PageSetupToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PageSetupToolStripButton1.Image = CType(resources.GetObject("PageSetupToolStripButton1.Image"), System.Drawing.Image)
        Me.PageSetupToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PageSetupToolStripButton1.Name = "PageSetupToolStripButton1"
        Me.PageSetupToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.PageSetupToolStripButton1.Text = "PageSetup"
        '
        'PreviewToolStripButton1
        '
        Me.PreviewToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PreviewToolStripButton1.Image = CType(resources.GetObject("PreviewToolStripButton1.Image"), System.Drawing.Image)
        Me.PreviewToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PreviewToolStripButton1.Name = "PreviewToolStripButton1"
        Me.PreviewToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.PreviewToolStripButton1.Text = "PrintPrview"
        '
        'FindToolStripButton1
        '
        Me.FindToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FindToolStripButton1.Image = CType(resources.GetObject("FindToolStripButton1.Image"), System.Drawing.Image)
        Me.FindToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FindToolStripButton1.Name = "FindToolStripButton1"
        Me.FindToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.FindToolStripButton1.Text = "Find"
        '
        'UndoToolStripButton
        '
        Me.UndoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UndoToolStripButton.Image = CType(resources.GetObject("UndoToolStripButton.Image"), System.Drawing.Image)
        Me.UndoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoToolStripButton.Name = "UndoToolStripButton"
        Me.UndoToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.UndoToolStripButton.Text = "Undo"
        '
        'RedoToolStripButton
        '
        Me.RedoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RedoToolStripButton.Image = CType(resources.GetObject("RedoToolStripButton.Image"), System.Drawing.Image)
        Me.RedoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RedoToolStripButton.Name = "RedoToolStripButton"
        Me.RedoToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.RedoToolStripButton.Text = "Redo"
        '
        'plnSearch
        '
        Me.plnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.plnSearch.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.plnSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plnSearch.Controls.Add(Me.chbHighlight)
        Me.plnSearch.Controls.Add(Me.lblMsg)
        Me.plnSearch.Controls.Add(Me.btnCancel)
        Me.plnSearch.Controls.Add(Me.btnFind)
        Me.plnSearch.Controls.Add(Me.txtFind)
        Me.plnSearch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.plnSearch.Location = New System.Drawing.Point(100, 59)
        Me.plnSearch.Name = "plnSearch"
        Me.plnSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.plnSearch.Size = New System.Drawing.Size(200, 107)
        Me.plnSearch.TabIndex = 2
        Me.plnSearch.Visible = False
        '
        'chbHighlight
        '
        Me.chbHighlight.AutoSize = True
        Me.chbHighlight.Location = New System.Drawing.Point(93, 35)
        Me.chbHighlight.Name = "chbHighlight"
        Me.chbHighlight.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbHighlight.Size = New System.Drawing.Size(88, 17)
        Me.chbHighlight.TabIndex = 4
        Me.chbHighlight.Text = "علامت گذاری"
        Me.chbHighlight.UseVisualStyleBackColor = True
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(65, 83)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(64, 13)
        Me.lblMsg.TabIndex = 3
        Me.lblMsg.Text = "پایان جستجو"
        Me.lblMsg.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(16, 57)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "لغو"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(106, 57)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 1
        Me.btnFind.Text = "جستجو"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtFind
        '
        Me.txtFind.Location = New System.Drawing.Point(16, 14)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(165, 21)
        Me.txtFind.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmsiFind, Me.tmsiPrint, Me.tmsiFindCancel, Me.tmsiNextSearch})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(400, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'tmsiFind
        '
        Me.tmsiFind.Name = "tmsiFind"
        Me.tmsiFind.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.tmsiFind.Size = New System.Drawing.Size(39, 20)
        Me.tmsiFind.Text = "Find"
        '
        'tmsiPrint
        '
        Me.tmsiPrint.Name = "tmsiPrint"
        Me.tmsiPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.tmsiPrint.Size = New System.Drawing.Size(41, 20)
        Me.tmsiPrint.Text = "Print"
        '
        'tmsiFindCancel
        '
        Me.tmsiFindCancel.Name = "tmsiFindCancel"
        Me.tmsiFindCancel.Size = New System.Drawing.Size(71, 20)
        Me.tmsiFindCancel.Text = "FindCancel"
        '
        'tmsiNextSearch
        '
        Me.tmsiNextSearch.Name = "tmsiNextSearch"
        Me.tmsiNextSearch.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.tmsiNextSearch.Size = New System.Drawing.Size(75, 20)
        Me.tmsiNextSearch.Text = "NextSearch"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'HS_Rtb
        '
        Me.HS_Rtb.BackColor = System.Drawing.SystemColors.Window
        Me.HS_Rtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HS_Rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HS_Rtb.EnableAutoDragDrop = True
        Me.HS_Rtb.Location = New System.Drawing.Point(0, 25)
        Me.HS_Rtb.Name = "HS_Rtb"
        Me.HS_Rtb.ReadOnly = True
        Me.HS_Rtb.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.HS_Rtb.Size = New System.Drawing.Size(400, 354)
        Me.HS_Rtb.TabIndex = 5
        Me.HS_Rtb.Text = ""
        '
        'RichTextBoxEx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.plnSearch)
        Me.Controls.Add(Me.HS_Rtb)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "RichTextBoxEx"
        Me.Size = New System.Drawing.Size(400, 379)
        Me.ctmRich.ResumeLayout(False)
        Me.ctmRich.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.plnSearch.ResumeLayout(False)
        Me.plnSearch.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SpellChecker As NetSpell.SpellChecker.Spelling
    Friend WithEvents FontDlg As System.Windows.Forms.FontDialog
    Friend WithEvents ColorDlg As System.Windows.Forms.ColorDialog
    Friend WithEvents OpenFileDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FontToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FontColorToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents BoldToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents UnderlineToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LeftToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CenterToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RightToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BulletsToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SpellcheckToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ctmRich As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tstCut As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tstCopy As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tstPaste As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents FindToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents plnSearch As System.Windows.Forms.Panel
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tmsiFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsiPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RedoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PreviewToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PageSetupToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tmsiFindCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsiNextSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HS_Rtb As WFControls.VB.HS.HS_RichTextBox
    Friend WithEvents chbHighlight As System.Windows.Forms.CheckBox

End Class
