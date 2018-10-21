

Public Class RichTextBoxEx


#Region "- Event -"

    Event HS_Rtb_MouseDown_Out(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    Event HS_Rtb_KeyDown_Out(ByVal sender As System.Object, ByVal e As Hs_EventArgs)

    Public Class Hs_EventArgs : Inherits EventArgs

        Public _SelectedText As String

        Public Sub New(ByVal str As String)
            _SelectedText = str
        End Sub

    End Class


#End Region

#Region "- Property -"

    Private _TextRich As String
    Public Property TextRich() As String
        Get
            Return Me.HS_Rtb.Text '_TextRich
        End Get
        Set(ByVal value As String)
            _TextRich = value
            Me.HS_Rtb.Text = value

            Me.HS_Rtb.SelectAll()
            Me.HS_Rtb.SelectionFont = New Font("Tahoma", 12, FontStyle.Regular)
            Me.HS_Rtb.SelectionAlignment = HorizontalAlignment.Right
            Me.HS_Rtb.SelectionLength = 0

        End Set
    End Property

    Private _SelectedText As String
    Public ReadOnly Property SelectedText() As String
        Get
            Return Me.HS_Rtb.SelectedText
        End Get

    End Property


    Private _HighlightText As String
    Public WriteOnly Property HighlightText() As String

        Set(ByVal value As String)
            _HighlightText = value

            Me.HS_Rtb.ClearBackColor(True)
            Me.HS_Rtb.Highlight(_HighlightText, System.Drawing.Color.LightPink, False, False)

            If Me.HS_Rtb.CaretPos > -1 Then
                Me.HS_Rtb.Select(Me.HS_Rtb.CaretPos, 1)
                Me.HS_Rtb.ScrollToCaret()
                Me.HS_Rtb.SelectionLength = 0
            End If

        End Set
    End Property

    Private _RReadOnly As Boolean
    Public Property RReadOnly() As Boolean
        Get
            Return _RReadOnly
        End Get
        Set(ByVal value As Boolean)
            _RReadOnly = value
            Me.HS_Rtb.ReadOnly = value
            If value Then
                Me.HS_Rtb.BackColor = System.Drawing.SystemColors.InactiveBorder
            Else
                Me.HS_Rtb.BackColor = System.Drawing.SystemColors.Window
            End If
        End Set
    End Property


#End Region

#Region "- Load -"

    Dim start As Integer = 0
    Dim indexOfSearchText As Integer = 0

    Private isDragging As Boolean = False
    Private ClickAreaX As Integer
    Private ClickAreaY As Integer

    Private Sub RichTextBoxEx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        HS_Rtb.Focus()

    End Sub


#End Region

#Region "- Print -"


    Private Sub PageSetupToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetupToolStripButton1.Click

        PageSetupDialog1.ShowDialog()

    End Sub

    Private Sub PreviewToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewToolStripButton1.Click

        PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click

        If PrintDialog1.ShowDialog() = DialogResult.OK Then

            PrintDocument1.Print()

        End If

    End Sub

    Private checkPrint As Integer

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        ' Print the content of the RichTextBox. Store the last character printed.
        checkPrint = HS_Rtb.Print(checkPrint, HS_Rtb.TextLength, e)

        ' Look for more pages
        If checkPrint < HS_Rtb.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub


#End Region

#Region "- Find -"


    Private Sub FindToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripButton1.Click

        plnSearch.Visible = True
        Me.txtFind.Focus()

    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click

        Me.lblMsg.Visible = False
        Me.HS_Rtb.ClearBackColor(True)
        FindText(Me.txtFind.Text)

    End Sub

    Public Sub FindText(ByVal _Text As String)


        Dim startindex As Integer = 0

        If _Text.Length > 0 Then
            startindex = FindMyText(_Text.Trim(), start, HS_Rtb.Text.Length)
        End If


        If startindex >= 0 Then ' if find

            HS_Rtb.SelectionBackColor = Color.LightSkyBlue
            ' HS_Rtb.Select(startindex, FindText.Length)
            start = startindex + _Text.Length

            Me.HS_Rtb.ScrollToCaret() ' for scroll

        Else

            indexOfSearchText = 0
            start = 0
            Me.lblMsg.Visible = True

        End If


    End Sub

    Public Function FindMyText(ByVal txtToSearch As String, ByVal searchStart As Integer, ByVal searchEnd As Integer) As Integer

        ' Unselect the previously searched string
        If searchStart > 0 AndAlso searchEnd > 0 AndAlso indexOfSearchText >= 0 Then
            HS_Rtb.Undo()
        End If


        Dim retVal As Integer = -1


        If searchStart >= 0 AndAlso indexOfSearchText >= 0 Then ' if indexOfSearchText = -1, the end of search
            If searchEnd > searchStart OrElse searchEnd = -1 Then
                indexOfSearchText = HS_Rtb.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None)
                If indexOfSearchText <> -1 Then
                    retVal = indexOfSearchText
                End If
            End If
        End If


        Return retVal

    End Function

    Public Sub FindAndReplace(ByVal FindText As String, ByVal ReplaceText As String)

        HS_Rtb.Find(FindText)
        If Not HS_Rtb.SelectionLength = 0 Then
            HS_Rtb.SelectedText = ReplaceText
        Else
            MsgBox("The following specified text was not found: " & FindText)
        End If

    End Sub

    Public Sub FindAndReplace(ByVal FindText As String, ByVal ReplaceText As String, ByVal ReplaceAll As Boolean, ByVal MatchCase As Boolean, ByVal WholeWord As Boolean)

        Select Case ReplaceAll

            Case False

                If MatchCase = True Then
                    If WholeWord = True Then
                        HS_Rtb.Find(FindText, RichTextBoxFinds.MatchCase Or RichTextBoxFinds.WholeWord)
                    Else
                        HS_Rtb.Find(FindText, RichTextBoxFinds.MatchCase)
                    End If
                Else
                    If WholeWord = True Then
                        HS_Rtb.Find(FindText, RichTextBoxFinds.WholeWord)
                    Else
                        HS_Rtb.Find(FindText)
                    End If
                End If

                If Not HS_Rtb.SelectionLength = 0 Then
                    HS_Rtb.SelectedText = ReplaceText
                Else
                    MsgBox("The following specified text was not found: " & FindText)
                End If


            Case True


                Dim i As Integer
                For i = 0 To HS_Rtb.TextLength

                    If MatchCase = True Then
                        If WholeWord = True Then
                            HS_Rtb.Find(FindText, RichTextBoxFinds.MatchCase Or RichTextBoxFinds.WholeWord)
                        Else
                            HS_Rtb.Find(FindText, RichTextBoxFinds.MatchCase)
                        End If
                    Else
                        If WholeWord = True Then
                            HS_Rtb.Find(FindText, RichTextBoxFinds.WholeWord)
                        Else
                            HS_Rtb.Find(FindText)
                        End If
                    End If

                    If Not HS_Rtb.SelectionLength = 0 Then
                        HS_Rtb.SelectedText = ReplaceText
                    Else
                        MsgBox(i & " occurrence(s) replaced")
                        Exit For
                    End If
                Next i

        End Select

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        plnSearch.Visible = False

    End Sub

    Private Sub txtFind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFind.TextChanged

        start = 0
        indexOfSearchText = 0

    End Sub

    Private Sub chbHighlight_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbHighlight.CheckedChanged

        If Me.chbHighlight.Checked Then

            Me.HS_Rtb.Highlight(Me.txtFind.Text, System.Drawing.Color.Yellow, False, False)
            'Me.HS_Rtb.ScrollToBottom()

        Else
            Me.HS_Rtb.ClearBackColor(True)
        End If


    End Sub

#End Region

#Region "- ToolStripButton -"


    Private Sub UndoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripButton.Click
        HS_Rtb.Undo()
    End Sub

    Private Sub RedoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripButton.Click
        HS_Rtb.Redo()
    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        HS_Rtb.Cut()
    End Sub

    Private Sub CopyToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripButton.Click
        HS_Rtb.Copy()
    End Sub

    Private Sub PasteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripButton.Click
        HS_Rtb.Paste()
    End Sub

    Private Sub FontToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripButton.Click

        If FontDlg.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            HS_Rtb.SelectionFont = FontDlg.Font
        End If

    End Sub

    Private Sub FontColorToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontColorToolStripButton.Click

        If ColorDlg.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            HS_Rtb.SelectionColor = ColorDlg.Color
        End If

    End Sub

    Private Sub BoldToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldToolStripButton.Click

        ' Switch Bold
        Dim currentFont As System.Drawing.Font = HS_Rtb.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle

        If HS_Rtb.SelectionFont.Bold = True Then
            newFontStyle = currentFont.Style - Drawing.FontStyle.Bold
        Else
            newFontStyle = currentFont.Style + Drawing.FontStyle.Bold
        End If

        HS_Rtb.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        ' Check/Uncheck Bold button
        BoldToolStripButton.Checked = IIf(HS_Rtb.SelectionFont.Bold, True, False)

    End Sub

    Private Sub UnderlineToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineToolStripButton.Click
        ' Switch Underline
        Dim currentFont As System.Drawing.Font = HS_Rtb.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        If HS_Rtb.SelectionFont.Underline = True Then
            newFontStyle = currentFont.Style - Drawing.FontStyle.Underline
        Else
            newFontStyle = currentFont.Style + Drawing.FontStyle.Underline
        End If
        HS_Rtb.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        ' Check/Uncheck Underline button
        UnderlineToolStripButton.Checked = IIf(HS_Rtb.SelectionFont.Underline, True, False)
    End Sub

    Private Sub LeftToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftToolStripButton.Click
        HS_Rtb.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub CenterToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterToolStripButton.Click
        HS_Rtb.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub RightToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightToolStripButton.Click
        HS_Rtb.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub BulletsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BulletsToolStripButton.Click
        HS_Rtb.SelectionBullet = Not HS_Rtb.SelectionBullet
        BulletsToolStripButton.Checked = HS_Rtb.SelectionBullet
    End Sub

    Private Sub SpellcheckToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpellcheckToolStripButton.Click
        SpellChecker.Text = HS_Rtb.Text
        SpellChecker.SpellCheck()
    End Sub


#End Region

#Region "- Context Menu Strip -"

    Private Sub tstCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstCut.Click
        HS_Rtb.Cut()
    End Sub

    Private Sub tstCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstCopy.Click
        HS_Rtb.Copy()
    End Sub

    Private Sub tstPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstPaste.Click
        HS_Rtb.Paste()
    End Sub


#End Region

#Region "- Menu Bar  Ctrl F P  F3 -"

    Private Sub tmsiFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsiFind.Click
        FindToolStripButton1_Click(sender, e)
    End Sub

    Private Sub tmsiPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsiPrint.Click
        PrintToolStripButton_Click(sender, e)
    End Sub

    Private Sub tmsiFindCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsiFindCancel.Click
        btnCancel_Click(sender, e)
    End Sub

    Private Sub tmsiNextSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmsiNextSearch.Click
        btnFind_Click(sender, e)
    End Sub


#End Region

#Region "- Move Search Panel -"

    Private Sub plnSearch_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles plnSearch.MouseDown

        If e.Button = MouseButtons.Left Then
            ClickAreaX = e.X
            ClickAreaY = e.Y
            isDragging = True
        End If

    End Sub

    Private Sub plnSearch_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles plnSearch.MouseMove

        If isDragging Then
            plnSearch.Location = New Point(plnSearch.Left + (e.X - ClickAreaX), plnSearch.Top + (e.Y - ClickAreaY))
        End If

    End Sub

    Private Sub plnSearch_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles plnSearch.MouseUp

        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If

    End Sub

#End Region

#Region "- Hs_Rtb -"

    ' Update buttons when text is selected
    Private Sub HS_Rtb_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HS_Rtb.SelectionChanged
        ' see which buttons should be checked or unchecked

        If HS_Rtb.SelectionFont IsNot Nothing Then

            BoldToolStripButton.Checked = HS_Rtb.SelectionFont.Bold
            UnderlineToolStripButton.Checked = HS_Rtb.SelectionFont.Underline

        End If

        LeftToolStripButton.Checked = IIf(HS_Rtb.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left, True, False)
        CenterToolStripButton.Checked = IIf(HS_Rtb.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center, True, False)
        RightToolStripButton.Checked = IIf(HS_Rtb.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right, True, False)
        BulletsToolStripButton.Checked = HS_Rtb.SelectionBullet

        'cmbFontName.Text = HS_Rtb.SelectionFont.Name
        'cmbFontSize.Text = HS_Rtb.SelectionFont.SizeInPoints

    End Sub

#End Region

#Region "- OutGoing Event -"

    Private Sub HS_Rtb_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles HS_Rtb.MouseDown

        If HS_Rtb.SelectionLength > 0 Then
            RaiseEvent HS_Rtb_MouseDown_Out(sender, e)
        End If


    End Sub

    Private Sub HS_Rtb_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles HS_Rtb.KeyDown

        If e.KeyCode = Keys.F5 Then
            RaiseEvent HS_Rtb_KeyDown_Out(sender, New Hs_EventArgs(HS_Rtb.SelectedText))
        End If

    End Sub

#End Region

#Region "- SpellChecker -"

    ' Spell checking thanks to: http://www.codeproject.com/KB/string/netspell.aspx

    ' Handles when user chooses to delete in spell cehck

    Private Sub SpellChecker_DeletedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.SpellingEventArgs) Handles SpellChecker.DeletedWord
        'save existing selecting
        Dim start As Integer = HS_Rtb.SelectionStart
        Dim length As Integer = HS_Rtb.SelectionLength

        'select word for this event
        HS_Rtb.Select(e.TextIndex, e.Word.Length)

        'delete word
        HS_Rtb.SelectedText = ""

        If ((start + length) > HS_Rtb.Text.Length) Then
            length = 0
        End If

        'restore selection
        HS_Rtb.Select(start, length)

    End Sub

    ' Handles replacing a word from spell checking
    Private Sub SpellChecker_ReplacedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.ReplaceWordEventArgs) Handles SpellChecker.ReplacedWord
        'save existing selecting
        Dim start As Integer = HS_Rtb.SelectionStart
        Dim length As Integer = HS_Rtb.SelectionLength

        'select word for this event
        HS_Rtb.Select(e.TextIndex, e.Word.Length)

        'replace word
        HS_Rtb.SelectedText = e.ReplacementWord

        If ((start + length) > HS_Rtb.Text.Length) Then
            length = 0
        End If

        'restore selection
        HS_Rtb.Select(start, length)
    End Sub

#End Region

#Region "- UnUsed -"

    Private Sub checkBullets()
        If HS_Rtb.SelectionBullet = True Then
            BulletsToolStripButton.Checked = True
        Else
            BulletsToolStripButton.Checked = False
        End If
    End Sub

#End Region
   

End Class



