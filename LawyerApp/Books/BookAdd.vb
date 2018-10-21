Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.Books
Imports System.IO
Imports Lawyer.Common.VB.Books.Enums
Imports Lawyer.Common.VB.LawyerError


Public Class BookAdd


#Region "Property"


    Private _LibID As Guid
    Public WriteOnly Property LibID() As Guid

        Set(ByVal value As Guid)
            _LibID = value

            _PageMode = Enums.PageMode.Edit

        End Set
    End Property


#End Region


    Dim IsDropedFile As Boolean
    Dim _PageMode As PageMode = Enums.PageMode.Add


#Region " Load "

    Private Sub BookAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblMessage.Text = String.Empty

        If _PageMode = Enums.PageMode.Edit Then

            FillForm()

        End If

        ToolTip1.SetToolTip(btnLoad, "فایل کتاب")

        ToolTip1.SetToolTip(btnIE, "کتابخانه مرکزی")


    End Sub

    Sub FillForm()


        Try

            Dim Book As New Book
            Book = BookManager.GetBookByLibID(_LibID)

            If Book.libName.Contains("/") Then
                Dim s() As String : s = Book.libName.Split("/")
                Me.txtTitle.Text = s.GetValue(0)
                Me.txtName.Text = s.GetValue(1)
            Else
                Me.txtTitle.Text = Book.libName
                Me.txtName.Text = String.Empty

            End If

            Me.txtSubject.Text = Book.libSubject
            Me.txtSummary.Text = Book.libSummary '.Replace(Book.libName, String.Empty).Replace(Book.libSubject, String.Empty)


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری اطلاعات کتاب"
            ErrorManager.WriteMessage("FillForm()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#Region " Command "

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        If Me.ofdLoad.ShowDialog(Me) = DialogResult.OK Then

            Me.txtPath.Text = Me.ofdLoad.FileName

        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click


        Try


            Dim Book As New Book
            Book = Form2Book()

            If Book IsNot Nothing AndAlso Not String.IsNullOrEmpty(Trim(Book.libName)) Then


                If _PageMode = Enums.PageMode.Add Then

                    Book.libID = Guid.NewGuid
                    BookManager.InsertBook(Book)

                Else '-------------- Edit Mode- Update

                    Book.libID = _LibID

                    If String.IsNullOrEmpty(Book.libFileName) Then
                        BookManager.UpdateBookWithoutFile(Book)
                    Else
                        BookManager.UpdateBookWithFile(Book) ' if  file name empty ==> null in db
                    End If

                End If


                Dim BookSearch As New BookSearch
                BookSearch = Me.Owner
                BookSearch.RefreshGrid = True '------ refesh


            End If


            ' Me.Close()
            '--------------------------------for torabi-Ready For another book
            Me.txtTitle.Text = String.Empty
            Me.txtName.Text = String.Empty
            Me.txtSubject.Text = String.Empty
            Me.txtSummary.Text = String.Empty
            Me.txtPath.Text = String.Empty
            '-----------------------------------

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ذخیره کتاب"
            ErrorManager.WriteMessage("btnSave_Click()", ex.ToString, Me.Text)
        End Try

    End Sub

    Function Form2Book() As Book

        Try

            Dim Book As New Book

            Book.libName = Me.txtTitle.Text + "/" + Me.txtName.Text
            Book.libSubject = Me.txtSubject.Text

            If IsDropedFile Then
                Book.libSummary = txtSummary.Text
            Else
                Try
                    If Book.libSummary.Substring(0, 10) = Book.libName.Substring(0, 10) Then ' Dont Add To summery
                        Book.libSummary = txtSummary.Text
                    Else
                        Book.libSummary = Book.libName + vbNewLine + Book.libSubject + vbNewLine + Me.txtSummary.Text
                    End If
                Catch ex As Exception
                    Book.libSummary = txtSummary.Text
                End Try
               



            End If

            Book.libFileName = Me.txtPath.Text ' if empty ==> null in db

            Return Book

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در تبدیل فرم به کتاب"
            ErrorManager.WriteMessage("Form2Book()", ex.ToString, Me.Text)
            Return Nothing
        End Try


    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

#End Region

#Region "Drag In Summary"

    Sub _DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
        '------------------------------------------

        'Dim str As String = TryCast(e.Data.GetData(GetType(String)), String)

        'Dim size As SizeF
        'Dim f As New Font(FontFamily.GenericSerif, 10, FontStyle.Bold)
        'Using tmpBmp As New Bitmap(1, 1)
        '    Using g As Graphics = Graphics.FromImage(tmpBmp)
        '        size = g.MeasureString(str, f)
        '    End Using
        'End Using

        'Dim bitmap As New Bitmap(CInt(Math.Ceiling(size.Width)), CInt(Math.Ceiling(size.Height)))
        'Using g As Graphics = Graphics.FromImage(Bitmap)
        '    g.DrawString(str, f, Brushes.Black, 0, 0)
        'End Using

        'Cursor.Current = CreateCursor(Bitmap, 0, 0)

        'Bitmap.Dispose()
        'f.Dispose()
    End Sub

    Private Sub txtSummary_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSummary.DragEnter

        _DragEnter(sender, e)

    End Sub

    Private Sub txtSummary_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtSummary.DragDrop


        Try

            Dim str As String = CType(e.Data.GetData(DataFormats.StringFormat), String)


            '-------------------------------------write RawText to TextFile
            Dim RawText As String = str
            Dim TextFile As String = FileManager.GetBookConvertFilePath ' Application.StartupPath + "\Lib.txt"

            ' Create a Text File
            Dim fs As FileStream = Nothing
            If (Not File.Exists(TextFile)) Then
                fs = File.Create(TextFile)
                Using fs
                End Using
            End If

            ' Write to a Text File
            If File.Exists(TextFile) Then
                Using sw As StreamWriter = New StreamWriter(TextFile)
                    sw.Write(RawText)
                End Using
            End If

            '-------------------------------------read info from file
            Dim book As New Book

            Dim BookConvertor As New BookConvertor
            book = BookConvertor.ReadBookInfoFromFile(TextFile)

            If book.libName.Contains("/") Then
                Dim s() As String : s = book.libName.Split("/")
                Me.txtTitle.Text = s.GetValue(0)
                Me.txtName.Text = s.GetValue(1)
            Else
                Me.txtTitle.Text = book.libName
                Me.txtName.Text = String.Empty

            End If

            Me.txtSubject.Text = book.libSubject
            Me.txtSummary.Text = book.libSummary

            Me.IsDropedFile = True


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در گرفتن اطلاعات درگ شده" + " " + ex.Message
            ErrorManager.WriteMessage("txtSummary_DragDrop()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

    Private Sub btnIE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIE.Click

        'Dim f As New FormalNewspaper("www.nlai.ir")
        'f.Show()

    End Sub

End Class


