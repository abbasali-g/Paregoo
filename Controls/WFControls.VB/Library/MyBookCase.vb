Imports Lawyer.Common.VB.Books
Imports WFControls.VB.MyBook

Public Class MyBookCase

#Region "Event"

    Public Event BookCase_MouseHover(ByVal sender As Object, ByVal e As MyBook_EventArgs)
    Public Event BookCase_MouseLeave(ByVal sender As Object, ByVal e As MyBook_EventArgs)

    Public Event BookCase_DragDrop(ByVal sender As Object, ByVal e As xy_EventArgs)

    Public Event BookCase_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    Public Class xy_EventArgs : Inherits EventArgs

        Public Sub New(ByVal LibId As Guid, ByVal Row As Integer, ByVal Col As Integer)
            _LibId = LibId
            _Row = Row
            _Col = Col
        End Sub

        Private _LibId As Guid
        Public ReadOnly Property LibId() As Guid
            Get
                Return _LibId
            End Get

        End Property


        Private _Row As Integer
        Public ReadOnly Property Row() As Integer
            Get
                Return _Row
            End Get

        End Property

        Private _Col As Integer
        Public ReadOnly Property Col() As Integer
            Get
                Return _Col
            End Get

        End Property

    End Class


#End Region

#Region "Property"


    'Private _DoubleClick As Boolean
    'Public Property MyBookDoubleClick(ByVal Name As String) As Boolean
    '    Get
    '        Return _DoubleClick
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _DoubleClick = value
    '        Dim c = CType(Me.Controls(Name), MyBook)
    '        c.MyBookDoubleClick = True
    '    End Set
    'End Property


    Private _DataSource As BookOnCaseCollection
    Public Property DataSource(ByVal ActivelibID As Guid) As BookOnCaseCollection
        Get
            Return _DataSource
        End Get
        Set(ByVal value As BookOnCaseCollection)
            _DataSource = value
            If _DataSource IsNot Nothing Then
                FillBookCase(_DataSource, ActivelibID)
            End If
        End Set
    End Property

    Private _DragEnterAll As Boolean
    Public Property DragEnterAll(ByVal x As Integer, ByVal y As Integer) As Boolean
        Get
            Return _DragEnterAll
        End Get
        Set(ByVal value As Boolean)
            _DragEnterAll = value
            If _DragEnterAll Then

                If x > 100 Then

                Else

                End If


                ' pbBook.Image = My.Resources.Resources.MyBook
            Else
                'pbBook.Image = Nothing
            End If
        End Set
    End Property


    Sub FillBookCase(ByVal BookOnCaseCollection As BookOnCaseCollection, ByVal ActivelibID As Guid)

        Dim ListOfMyBooks As New List(Of MyBook) ' Create List for name of mybooks  '0 to 39

        For Each MyBook As MyBook In Me.Controls

            ' MyBook.Visible = True
            MyBook.BookOnCase = Nothing
            MyBook.ShowImage(False) = False

            '----------------------

            'Me.MyBook40.BackColor = System.Drawing.Color.Transparent

            ListOfMyBooks.Add(MyBook)

        Next

        ListOfMyBooks.Sort(Function(p1, p2) p1.Name.CompareTo(p2.Name)) '0 to 39

        '---------------------------------------------------------------------------------------

        If BookOnCaseCollection IsNot Nothing Then

            For i As Integer = 0 To BookOnCaseCollection.Count - 1

                Dim Location As Integer = RowColumn2ListLocation(BookOnCaseCollection(i).shelfRow, BookOnCaseCollection(i).shelfColumn)

                Dim MyBook As MyBook = CType(ListOfMyBooks(Location), MyBook) 'set ehch book 0 to 39

                MyBook.BookOnCase = BookOnCaseCollection(i)

                If ActivelibID = Guid.Empty OrElse ActivelibID <> MyBook.BookOnCase.libID Then
                    MyBook.ShowImage(False) = True
                Else
                    MyBook.ShowImage(True) = True
                End If


                AddHandler MyBook.MyBook_MouseHover, AddressOf AllMyBook_MouseHover 'New EventHandler(AddressOf Inside_MouseHover)
                AddHandler MyBook.MyBook_MouseLeave, AddressOf AllMyBook_MouseLeave
                AddHandler MyBook.MyBook_DoubleClick, AddressOf AllMyBook_DoubleClick

                ' ListOfMyBooks.Remove(MyBook)
            Next
        End If



        'For i As Integer = 0 To ListOfMyBooks.Count - 1
        '    Dim MyBook As MyBook = CType(ListOfMyBooks(i), MyBook)
        '    MyBook.BackColor = System.Drawing.Color.Transparent
        'Next




    End Sub


    Function RowColumn2ListLocation(ByVal row As Integer, ByVal Column As Integer) As Integer

        Dim Location As Integer 'create location between 0 to 39

        If row = 1 Then '0 to 9
            Location = Column - 1
        ElseIf Column = 10 Then
            Location = (row * 10) - 1
        Else
            Location = ((row - 1) * 10 + (Column - 1))
        End If

        Return Location

    End Function


#End Region


    Private Sub MyBookCase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each _Control As Control In Me.Controls

            If TypeOf _Control Is WFControls.VB.MyBook Then

                Dim _MyBook As MyBook = CType(_Control, MyBook)

                _MyBook.AllowDrop = True

                AddHandler _MyBook.MyBook_DragDropMe, AddressOf AllMyBook_DragDropMe
                'Other Handler Set Only if filled

            End If
        Next


        'Dim MyBook As New Label

        'Dim x As Integer = 27
        'Dim y As Integer = 43

        'For i As Integer = 1 To 10

        '    MyBook = New Label


        '    MyBook.Location = New System.Drawing.Point(x, y)
        '    MyBook.Name = "MyBook" + x.ToString
        '    MyBook.Visible = False
        '    MyBook.BackColor = System.Drawing.Color.Transparent
        '    'MyBook.Visible = True
        '    Me.Controls.Add(MyBook)

        '    x += 18


        'Next

        'For Each c As Control In Me.Controls

        '    If TypeOf c Is Label Then
        '        c.Visible = True

        '    End If
        'Next


    End Sub


#Region "OutGoing Event"

    Sub AllMyBook_MouseHover(ByVal sender As System.Object, ByVal e As MyBook_EventArgs)

        RaiseEvent BookCase_MouseHover(sender, e)

    End Sub

    Sub AllMyBook_MouseLeave(ByVal sender As System.Object, ByVal e As MyBook_EventArgs)

        RaiseEvent BookCase_MouseLeave(sender, e)

    End Sub

    Private Sub AllMyBook_DragDropMe(ByVal sender As System.Object, ByVal e As Guid)

        Dim MyBook As New MyBook
        MyBook = CType(sender, MyBook)
        Dim Row, Col As Integer
        MyBookName2RowCol(MyBook.Name, Row, Col)

        RaiseEvent BookCase_DragDrop(sender, New xy_EventArgs(e, Row, Col))

    End Sub

    Sub MyBookName2RowCol(ByVal Name As String, ByRef row As Integer, ByRef Col As Integer)

        Dim num As Integer = CInt(Name.Substring(6))


        Select Case True
            Case num < 11
                row = 1
            Case num < 21
                row = 2
            Case num < 31
                row = 3
            Case num < 41
                row = 4
            Case Else

        End Select
        If num < 10 Then
            Col = num
        Else

            num = num - (row - 1) * 10
            If num = 0 Then
                Col = 10
            Else
                Col = num
            End If

        End If


    End Sub

    Private Sub AllMyBook_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For Each MyBook As MyBook In Me.Controls

            If MyBook.BookOnCase IsNot Nothing AndAlso MyBook.BookOnCase.libID = CType(sender, MyBook).BookOnCase.libID Then
                MyBook.ShowImage(True) = True
            ElseIf MyBook.BookOnCase IsNot Nothing Then
                MyBook.ShowImage(False) = True
            End If

        Next


        RaiseEvent BookCase_MouseDoubleClick(sender, e)

    End Sub

#End Region



End Class
