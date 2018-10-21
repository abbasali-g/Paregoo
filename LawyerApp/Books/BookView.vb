Imports Lawyer.Common.VB.Books
Imports System.ComponentModel
Imports WFControls.VB.ucBook
Imports WFControls.VB
Imports Lawyer.Common.VB.BaseUserControl.ListView
Imports Lawyer.Common.VB.LawyerError

Public Class BookView


#Region "Property"


    Private _LibId As Guid
    Public WriteOnly Property LibId() As Guid
        Set(ByVal value As Guid)
            _LibId = value

            FillBookCase(_LibId)

        End Set
    End Property



    Private _FillLv As Boolean
    Public WriteOnly Property FillLv() As Boolean

        Set(ByVal value As Boolean)
            _FillLv = value
            If _FillLv Then
                FillListViewOfCase()
            End If

        End Set
    End Property

    Sub FillBookCase(ByVal LibId As Guid)

        Try


            Dim BookOnCaseCollection As New BookOnCaseCollection
            BookOnCaseCollection = BookOnCaseManager.GetCaseBooksByOneBookLibID(LibId)


            If BookOnCaseCollection.Count <> 0 Then

                For i = 0 To Me.lvCase.Items.Count - 1 '---------- select case item for first book

                    If Me.lvCase.Items(i).SubItems(1).Text = BookOnCaseCollection(0).shelfNumber Then

                        If Me.lvCase.SelectedItems.Count > 0 Then
                            Me.lvCase.SelectedItems(0).Selected = False
                        End If
                        Me.lvCase.Items(i).Selected = True
                        Me.lvCase.Select()

                    End If

                Next

            End If

            Me.MyBookCase1.DataSource(LibId) = BookOnCaseCollection


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری کتابخانه"
        End Try


    End Sub


#End Region

#Region "Load"


    Private Sub BookView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblMessage.Text = String.Empty

        Me.AllowDrop = True
        For Each c As Control In Me.Controls
            c.AllowDrop = True
        Next

        Me.pbDel.AllowDrop = True

        Me.lvCase.View = View.LargeIcon
        Me.lvCase.Sorting = SortOrder.Ascending
        Me.lvCase.LabelEdit = True
        Me.lvCase.ListViewItemSorter = New ListViewIndexComparer() 'Comparer

        FillListViewOfCase()

        If Me.lvCase.Items.Count > 0 Then
            Me.lvCase.Items(0).Selected = True 'ItemSelectionChanged >>> inside of that must be FillBookCaseByShelfNumber
        End If
        Me.lvCase.Select()

        Me.TooltipBookCase1.Visible = False

        ToolTip1.SetToolTip(pbAdd, "قفسه جدید")
        ToolTip1.SetToolTip(pbDel, "حذف قفسه")


    End Sub

    Sub FillListViewOfCase()

        Try

            Dim ImageList As New ImageList()
            ImageList.ImageSize = New Size(14, 24)
            ImageList.Images.Add(New Bitmap(My.Resources.BookCaseLogo))

            Dim BookCaseCollection As New BookCaseCollection
            BookCaseCollection = BookCaseManager.GetAllCase()

            Me.lvCase.Items.Clear()
            Me.lvCase.LargeImageList = ImageList

            For i = 0 To BookCaseCollection.Count - 1

                Dim lvi As New ListViewItem(BookCaseCollection.Item(i).shelfName) 'Name
                lvi.SubItems.Add(BookCaseCollection.Item(i).shelfNumber) 'Number
                lvi.ImageIndex = 0

                Me.lvCase.Items.Add(lvi)

            Next

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری نام قفسه ها"
            ErrorManager.WriteMessage("FillListViewOfCase()", ex.ToString, Me.Text)
        End Try


    End Sub

    Private Sub lvCase_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvCase.ItemSelectionChanged

        If Me.lvCase.SelectedItems.Count > 0 Then
            FillBookCaseByShelfNumber(Me.lvCase.Items(e.ItemIndex).SubItems(1).Text)
        End If

    End Sub

    Sub FillBookCaseByShelfNumber(ByVal ShelfNumber As Integer)

        Try

            Me.MyBookCase1.DataSource(Guid.Empty) = BookOnCaseManager.GetCaseBooksByShelfNumber(ShelfNumber)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری قفسه کتابخانه"
            ErrorManager.WriteMessage("FillBookCaseByShelfNumber()", ex.ToString, Me.Text)
        End Try

    End Sub


#End Region

#Region "Drag Out ListView"

    Dim moveCursor, nodropCursor, copyCursor As Cursor

    Private Sub lvCase_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles lvCase.GiveFeedback

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

    Private Sub lvCase_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvCase.ItemDrag

        Dim _Bitmap As New Bitmap(My.Resources.BookCase_Color)
        moveCursor = New Cursor(_Bitmap.GetHicon)

        Dim _Bitmap2 As New Bitmap(My.Resources.BookCase_Gray)
        nodropCursor = New Cursor(_Bitmap2.GetHicon)

        Me.lvCase.DoDragDrop(e.Item, DragDropEffects.Copy)


    End Sub


#End Region

#Region "Drag In pbDel"

    Sub _DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(GetType(ListViewItem)) Or e.Data.GetDataPresent(DataFormats.StringFormat) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub pbDel_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDel.DragEnter

        _DragEnter(sender, e)

    End Sub

    Private Sub pbDel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDel.DragDrop

        Try

            If e.Data.GetDataPresent(GetType(ListViewItem)) Then


                Dim dmb As New dadMessageBox("آیا از حذف این قفسه مطمئن هستید؟", "هشدار")
                If dmb.ShowMessage() = DialogResult.Yes Then

                    Dim lvi As New ListViewItem
                    lvi = CType(e.Data.GetData(GetType(ListViewItem)), ListViewItem)

                    BookCaseManager.DeleteCase(lvi.SubItems(1).Text)

                    FillListViewOfCase()

                End If


                ' Dim response As MsgBoxResult = (MsgBox("آیا از حذف این قفسه مطمئن هستید؟", MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNo))
                ' If response = MsgBoxResult.Yes Then
                'End If

            Else 'del book from case


                Dim str As String = CType(e.Data.GetData(DataFormats.StringFormat), String)

                Dim BookOnCase As New BookOnCase

                BookOnCase.shelfNumber = CInt(Part(str)(1))
                BookOnCase.shelfRow = CInt(Part(str)(2))
                BookOnCase.shelfColumn = CInt(Part(str)(3))

                BookOnCaseManager.DeleteBookFromCase(BookOnCase)

                FillBookCaseByShelfNumber(BookOnCase.shelfNumber)

            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در حذف"
            ErrorManager.WriteMessage("pbDel_DragDrop()", ex.ToString, Me.Text)
        End Try


    End Sub

    Function Part(ByVal str As String) As String()

        Dim strArray() As String
        Dim Separators() As String = {"<|>"}

        strArray = str.Split(Separators, StringSplitOptions.None)

        Return strArray
    End Function

#End Region

#Region " Command "

    Private Sub pbAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAdd.Click

        Dim CaseAdd As New CaseAdd
        CaseAdd.ShowDialog(Me)

    End Sub

    Private Sub lvCase_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles lvCase.AfterLabelEdit

        Try

            If Not String.IsNullOrEmpty(Trim(e.Label)) Then

                Dim BookCase As New BookCase
                BookCase.shelfName = e.Label
                BookCase.shelfNumber = Me.lvCase.Items(e.Item).SubItems(1).Text

                BookCaseManager.UpdateCaseName(BookCase)

                FillListViewOfCase()

            Else
                e.CancelEdit = True
            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در تغییر نام قفسه"
            ErrorManager.WriteMessage("lvCase_AfterLabelEdit()", ex.ToString, Me.Text)
        End Try

    End Sub

#End Region

#Region "MyBookCase Event"

#Region "ToolTip"

    Private Sub pbBook_MouseHover_Out_All_Out(ByVal sender As System.Object, ByVal e As WFControls.VB.ucBook.ucBook_EventArgs) Handles MyBookCase1.pbBook_MouseHover_Out_All_Out

        Try

            Dim MyBook = CType(sender, ucBook)

            If MyBook.BookOnCase IsNot Nothing Then

                Dim Book As New Book
                Book = BookManager.GetBookForToolTip(MyBook.BookOnCase.libID)

                Me.TooltipBookCase1.Title = Book.libName
                Me.TooltipBookCase1.Subject = Book.libSubject
                Me.TooltipBookCase1.Visible = True

                'Me.TooltipBookCase1.Visible = False
                'Me.TooltipBookCase1.Location = Me.MyBookCase1.Location + MyBook.Location
                'Me.TooltipBookCase1.Location = New Point(Me.TooltipBookCase1.Location.X + 5, Me.TooltipBookCase1.Location.Y + 50)

            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در گرفتن اطلاعات تول تیپ"
            ErrorManager.WriteMessage("pbBook_MouseHover_Out_All_Out()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub pbBook_MouseLeave_Out_All_Out(ByVal sender As System.Object, ByVal e As WFControls.VB.ucBook.ucBook_EventArgs) Handles MyBookCase1.pbBook_MouseLeave_Out_All_Out

        Me.TooltipBookCase1.Visible = False

    End Sub

#End Region

#Region "Drag In Case"

    Private Sub ucBook_DragDrop_Out_All_Out(ByVal sender As System.Object, ByVal e As WFControls.VB.ucBookCase.xy_EventArgs) Handles MyBookCase1.ucBook_DragDrop_Out_All_Out

        Try

            Dim BookOnCase As New BookOnCase

            BookOnCase.shelfID = Guid.NewGuid
            BookOnCase.shelfNumber = Me.lvCase.SelectedItems(0).SubItems(1).Text

            BookOnCase.shelfRow = e.Row
            BookOnCase.shelfColumn = e.Col
            BookOnCase.libID = e.LibId

            BookOnCaseManager.InsertBookInCase(BookOnCase)


            Dim ucBookOld As New ucBook
            ucBookOld = CType(sender, ucBook)

            If ucBookOld.BookOnCase IsNot Nothing Then '-------------- move book inside bookCase
                BookOnCaseManager.DeleteBookFromCase(ucBookOld.BookOnCase)
            End If

            FillBookCaseByShelfNumber(Me.lvCase.SelectedItems(0).SubItems(1).Text)


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در انتقال کتاب در قفسه"
            ErrorManager.WriteMessage("ucBook_DragDrop_Out_All_Out()", ex.ToString, Me.Text)
        End Try

    End Sub

#End Region

#Region "DoubleClick on pbBook "

    Private Sub pbBook_DoubleClick_Out_All_Out(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBookCase1.pbBook_DoubleClick_Out_All_Out

        Try

            Dim BookSearch As New BookSearch ' show book info on bookSearch Form
            BookSearch = Me.Owner
            BookSearch.LibId = CType(sender, ucBook).BookOnCase.libID

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در انتقال اطلاعات به فرم جستجو"
            ErrorManager.WriteMessage("pbBook_DoubleClick_Out_All_Out()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#End Region


    Private Sub pnlTitle_Paint(sender As Object, e As PaintEventArgs) Handles pnlTitle.Paint

    End Sub
End Class