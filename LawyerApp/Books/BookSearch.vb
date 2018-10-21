Imports Lawyer.Common.VB.Books
Imports Lawyer.Common.VB.Common
Imports System.ComponentModel
Imports Lawyer.Common.VB.LawyerError



Public Class BookSearch


#Region " Property "

    Private _LibId As Guid
    Public WriteOnly Property LibId() As Guid
        Set(ByVal value As Guid)
            _LibId = value
            FillSummaryAndHasFile(_LibId)
            ShowFile_LibID = _LibId
        End Set
    End Property


    Private _RefreshGrid As Boolean
    Public WriteOnly Property RefreshGrid() As Boolean
        Set(ByVal value As Boolean)
            _RefreshGrid = value
            If _RefreshGrid Then
                FillGrid()
            End If

        End Set
    End Property




#End Region


    Dim ShowFile_LibID As Guid
    Dim IsOpen As Boolean = False
    Dim RowOrder As Boolean = False
    Dim RowEnterEnable As Boolean = False

    Dim frmBookView As New BookView


#Region " Load "

    Private Sub BookSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ActiveControl = txtSearch
    End Sub


    Private Sub BookSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblMessage.Text = String.Empty

        Me.AllowDrop = True
        For Each c As Control In Me.pnlContent.Controls
            c.AllowDrop = True
        Next


        Gridpreparation()

        Me.pbBook.Enabled = False
        Me.pbBook.Image = My.Resources.WhiteBook

        ToolTip1.SetToolTip(pbAdd, "کتاب جدید")
        ToolTip1.SetToolTip(pbDel, "حذف کتاب")
        ToolTip1.SetToolTip(pbEdit, "ویرایش کتاب")
        ToolTip1.SetToolTip(pbBook, "فایل ضمیمه")


    End Sub

    Sub Gridpreparation()


        dgvBooks.AllowUserToAddRows = False
        dgvBooks.AllowUserToDeleteRows = False
        dgvBooks.AutoGenerateColumns = False
        dgvBooks.Columns.Clear()

        '---------------------------------------------
        dgvBooks.Columns.Add("libID", "")
        dgvBooks.Columns.Item("libID").DataPropertyName = "libID"
        dgvBooks.Columns("libID").ReadOnly = True
        dgvBooks.Columns("libID").Visible = False
        'dgvLaws.Columns("libID").SortMode = DataGridViewColumnSortMode.Automatic
        'dgvLaws.Columns("libID").DisplayIndex = 1
        dgvBooks.Columns("libID").Width = 5
        '---------------------------------------------
        dgvBooks.Columns.Add("libName", "عنوان / پدیدآورنده")
        dgvBooks.Columns.Item("libName").DataPropertyName = "libName"
        dgvBooks.Columns("libName").ReadOnly = True
        dgvBooks.Columns("libName").Visible = True
        'dgvBooks.Columns("libName").SortMode = DataGridViewColumnSortMode.Automatic
        'dgvLaws.Columns("libName").DisplayIndex = 1
        dgvBooks.Columns("libName").Width = 260
        '---------------------------------------------
        dgvBooks.Columns.Add("libSubject", "موضوع")
        dgvBooks.Columns.Item("libSubject").DataPropertyName = "libSubject"
        dgvBooks.Columns("libSubject").ReadOnly = True
        dgvBooks.Columns("libSubject").Visible = True
        ' dgvBooks.Columns("libSubject").SortMode = DataGridViewColumnSortMode.Automatic
        'dgvLaws.Columns("libSubject").DisplayIndex = 1
        dgvBooks.Columns("libSubject").Width = 130
        '---------------------------------------------

        For Each dgvCol As DataGridViewColumn In dgvBooks.Columns
            dgvCol.SortMode = DataGridViewColumnSortMode.Programmatic
        Next

        ' dgvBooks.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect

    End Sub

#End Region

#Region " Search "

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown

        If e.KeyCode = Keys.Return And (Not String.IsNullOrEmpty(Me.txtSearch.Text)) Then

            FillGrid()

        End If


    End Sub

    Sub FillGrid()

        Me.lblMessage.Text = String.Empty

        Select Case True
            Case Me.rdbAll.Checked
                FillGrid_All()
            Case Me.rdbMy.Checked
                FillGrid_My()
        End Select

    End Sub

    Sub FillGrid_All()

        Try

            If String.IsNullOrEmpty(Me.txtSearch.Text) Then
                Exit Sub
            End If

            If Trim(Me.txtSearch.Text.Length) > 3 Then
                Me.dgvBooks.DataSource = BookManager.GetBooksForGrid(Me.txtSearch.Text)
            Else
                Me.dgvBooks.DataSource = BookManager.GetBooksForGrid_Like(Me.txtSearch.Text)
            End If

            If CType(Me.dgvBooks.DataSource, BookCollection).Count = 0 Then
                Me.lblMessage.Text = "موردی یافت نشد"
            End If

            '---------------------------
            'Dim _BindingSource As New BindingSource
            ' _BindingSource.DataSource = BookManager.GetBooksForGrid(Me.txtSearch.Text)
            ' Me.dgvBooks.DataSource = _BindingSource


            Me.dgvBooks.Focus()

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در انجام جستجو"
            ErrorManager.WriteMessage("FillGrid_All()", ex.ToString, Me.Text)
        End Try


    End Sub

    Sub FillGrid_My()

        Try

            If String.IsNullOrEmpty(Me.txtSearch.Text) Then
                Exit Sub
            End If

            Dim BookCollection As New BookCollection
            If Trim(Me.txtSearch.Text.Length) > 3 Then
                BookCollection = BookManager.GetBooksForGridMe(Me.txtSearch.Text)
            Else
                BookCollection = BookManager.GetBooksForGridMe_Like(Me.txtSearch.Text)
            End If


            If BookCollection.Count > 0 Then
                frmBookView.LibId = BookCollection(0).libID
            Else
                Me.lblMessage.Text = "موردی یافت نشد"
            End If


            Me.dgvBooks.DataSource = BookCollection
            Me.dgvBooks.Focus()

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در انجام جستجو"
            ErrorManager.WriteMessage("FillGrid_My()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#Region " DataGrid Event"

    Private Sub dgvBooks_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBooks.RowEnter

        FillSummaryAndHasFile(Me.dgvBooks.Rows(e.RowIndex).Cells(0).Value)

        If Me.dgvBooks.SelectedRows.Count <> 0 Then ' for showing file
            ShowFile_LibID = Me.dgvBooks.SelectedRows.Item(0).Cells(0).Value
        End If

    End Sub

    Sub FillSummaryAndHasFile(ByVal LibID As Guid)

        Try

            Dim Book As New Book
            Book = BookManager.GetBookInfo(LibID)

            Me.txtSummary.Text = Book.libSummary

            If Book.HasFile Then
                Me.pbBook.Enabled = True
                Me.pbBook.Image = My.Resources.YellowBook
            Else
                Me.pbBook.Enabled = False
                Me.pbBook.Image = My.Resources.WhiteBook
            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در خواندن فایل یا اطلاعات کتاب"
            ErrorManager.WriteMessage("FillSummaryAndHasFile()", ex.ToString, Me.Text)
        End Try


    End Sub

    Private Sub dgvBooks_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBooks.CellDoubleClick

        If Me.rdbMy.Checked Then 'for selecting mybook in bookcase
            frmBookView.LibId = Me.dgvBooks.Rows(e.RowIndex).Cells(0).Value
        End If

    End Sub

#End Region

#Region "Drag out grid"

    Dim moveCursor, nodropCursor, copyCursor As Cursor

    Private Sub dgvBooks_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles dgvBooks.GiveFeedback

        e.UseDefaultCursors = False

        Select Case e.Effect
            Case DragDropEffects.Move
                Cursor.Current = moveCursor
            Case DragDropEffects.None
                Cursor.Current = nodropCursor
            Case DragDropEffects.Copy
                Cursor.Current = moveCursor '  Cursor.Current = copyCursor
        End Select


    End Sub

    Private Sub dgvBooks_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBooks.CellMouseDown

        Try

            If e.Clicks = 1 AndAlso e.RowIndex <> -1 Then ' e.Clicks = 1 for work CellDoubleClick

                'If e.ColumnIndex = 2 Then

                Dim _Bitmap As New Bitmap(My.Resources.MyBook2)
                moveCursor = New Cursor(_Bitmap.GetHicon)

                Dim _Bitmap2 As New Bitmap(My.Resources.MyBook2_Gray)
                nodropCursor = New Cursor(_Bitmap2.GetHicon)

                'libId-?
                Dim str As String

                str = Me.dgvBooks.Rows(e.RowIndex).Cells(0).Value.ToString + _
                "<|>" + _
                 Me.dgvBooks.Rows(e.RowIndex).Cells(2).Value.ToString


                Me.dgvBooks.DoDragDrop(str, DragDropEffects.Copy)

            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در درگ"
            ErrorManager.WriteMessage("dgvBooks_CellMouseDown()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#Region " Command Button"

    Private Sub rdbMy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMy.CheckedChanged

        If Me.rdbMy.Checked Then

            RowOrder = False
            IsOpen = False
            ToggleForm()

            FillGrid_My()

        End If

    End Sub

    Private Sub rdbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAll.CheckedChanged

        If Me.rdbAll.Checked Then

            RowOrder = False
            IsOpen = True
            ToggleForm()

            FillGrid_All()

        End If

    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click

        RowOrder = False
        ToggleForm()

    End Sub

    Sub ToggleForm()

        Try

            If RowOrder = True OrElse IsOpen = False Then

                frmBookView.StartPosition = FormStartPosition.Manual
                ReLocation()

                If frmBookView.Visible = False Then
                    frmBookView.Show(Me)
                End If

                IsOpen = True
                Me.btnShow.Text = "<"

            Else

                frmBookView.Hide()
                IsOpen = False

                Me.btnShow.Text = ">"
            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در باز کردن فرم"
            ErrorManager.WriteMessage("ToggleForm()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub pbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAdd.Click

        Dim form As New BookAdd
        form.ShowDialog(Me)

    End Sub

#End Region

#Region " Show BooK File"

    Private Sub pbBook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBook.Click

        ShowFile(ShowFile_LibID)

    End Sub

    Sub ShowFile(ByVal LibId As Guid)

        Try

            Dim LibFile As Byte() = BookManager.GetLibFileByLibID(LibId)
            Dim CurrentFileName As String = FileManager.GetFileFromBinaryFormat(LibFile, FileManager.GetDbPdfPath() + "TempPdfBook.pdf", False) 'FileManager.GetTempBookPath()
            System.Diagnostics.Process.Start(CurrentFileName)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در نمایش فایل"
            ErrorManager.WriteMessage("ShowFile()", ex.ToString, Me.Text)
        End Try

    End Sub

#End Region

#Region "Drag In Edit"

    Sub _DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(DataFormats.StringFormat) Then ' Or e.Data.GetDataPresent(GetType(ListViewItem)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub pbEdit_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbEdit.DragEnter

        _DragEnter(sender, e)

    End Sub

    Private Sub pbEdit_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbEdit.DragDrop

        Try

            Dim str As String = CType(e.Data.GetData(DataFormats.StringFormat), String)
            Dim LibID As New Guid(Part(str)(0))

            ' Dim LawOwner As String = LawManager.GetLawOwner(lawID)
            ' If LawOwner <> "USE" Then
            ' MsgBox("فقط قوانین ایجاد شده توسط شما قابل ویرایش می باشد", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)

            Dim BookAdd As New BookAdd

            BookAdd.LibID = LibID '   edit mode
            BookAdd.ShowDialog(Me)


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ویرایش  "
            ErrorManager.WriteMessage("pbEdit_DragDrop()", ex.ToString, Me.Text)
        End Try



    End Sub

    Function Part(ByVal str As String) As String()

        Dim strArray() As String
        Dim Separators() As String = {"<|>"}

        strArray = str.Split(Separators, StringSplitOptions.None)

        Return strArray

    End Function

    Private Sub pbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEdit.Click

        If Me.dgvBooks.SelectedRows.Count > 0 Then

            Dim BookAdd As New BookAdd
            BookAdd.LibID = Me.dgvBooks.SelectedRows.Item(0).Cells(0).Value 'edit mode
            BookAdd.ShowDialog(Me)

        End If


    End Sub

#End Region

#Region "Drag In Delete"


    Private Sub pbDel_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDel.DragEnter

        _DragEnter(sender, e)

    End Sub

    Private Sub pbDel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDel.DragDrop

        Dim str As String = CType(e.Data.GetData(DataFormats.StringFormat), String)
        Dim _LibID As New Guid(Part(str)(0))

        DelBook(_LibID)


    End Sub

    Sub DelBook(ByVal _LibId As Guid)

        Try

            Dim dmb As New dadMessageBox("از حذف این کتاب مطمئن هستید؟", "هشدار")
            If dmb.ShowMessage() = DialogResult.Yes Then

                BookManager.DeleteBook(_LibId) 'and it pos on case
                Me.RefreshGrid = True '----- refesh

            End If

            ' Dim response As MsgBoxResult = (MsgBox("از حذف این کتاب مطمئن هستید؟", MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNo))
            ' If response = MsgBoxResult.Yes Then
            ' End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در حذف کتاب"
            ErrorManager.WriteMessage("DelBook()", ex.ToString, Me.Text)
        End Try


    End Sub

    Private Sub pbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDel.Click

        If Me.dgvBooks.SelectedRows.Count > 0 Then
            DelBook(Me.dgvBooks.SelectedRows.Item(0).Cells(0).Value)
        End If

    End Sub


#End Region

#Region " Control"

    Private Sub BookSearch_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

        ReLocation()

    End Sub

    Sub ReLocation()

        frmBookView.Location = New Point(Me.Left - frmBookView.Width, Me.Top) '+ Form1.Width

    End Sub

#End Region


    '-----------------------------------------
    Private Sub dgvBooks_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBooks.ColumnHeaderMouseClick

        Me.dgvBooks.Columns(e.ColumnIndex).Selected = True
        'dataGridView1.SelectedCells(i).ColumnIndex 
        DataGridViewSort(Me.dgvBooks)

    End Sub

    Sub DataGridViewSort(ByRef dataGridView1 As DataGridView)

        '' Check which column is selected, otherwise set NewColumn to Nothing.
        'Dim newColumn As DataGridViewColumn
        'If dataGridView1.Columns.GetColumnCount(DataGridViewElementStates _
        '    .Selected) = 1 Then
        '    newColumn = dataGridView1.SelectedColumns(0)
        'Else
        '    newColumn = Nothing
        'End If

        'Dim oldColumn As DataGridViewColumn = dataGridView1.SortedColumn
        'Dim direction As ListSortDirection

        '' If oldColumn is null, then the DataGridView is not currently sorted.
        'If Not oldColumn Is Nothing Then

        '    ' Sort the same column again, reversing the SortOrder.
        '    If oldColumn Is newColumn AndAlso dataGridView1.SortOrder = _
        '        SortOrder.Ascending Then
        '        direction = ListSortDirection.Descending
        '    Else

        '        ' Sort a new column and remove the old SortGlyph.
        '        direction = ListSortDirection.Ascending
        '        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None
        '    End If
        'Else
        '    direction = ListSortDirection.Ascending
        'End If


        '' If no column has been selected, display an error dialog  box.
        'If newColumn Is Nothing Then
        '    MessageBox.Show("Select a single column and try again.", _
        '        "Error: Invalid Selection", MessageBoxButtons.OK, _
        '        MessageBoxIcon.Error)
        'Else
        '    dataGridView1.Sort(newColumn, direction)
        '    If direction = ListSortDirection.Ascending Then
        '        newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
        '    Else
        '        newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
        '    End If
        'End If

    End Sub


End Class