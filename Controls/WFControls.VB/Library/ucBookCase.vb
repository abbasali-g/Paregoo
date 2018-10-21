Imports Lawyer.Common.VB.Books
Imports WFControls.VB.ucBook

Public Class ucBookCase

#Region "Event"

    Public Event pbBook_MouseHover_Out_All_Out(ByVal sender As Object, ByVal e As ucBook_EventArgs)
    Public Event pbBook_MouseLeave_Out_All_Out(ByVal sender As Object, ByVal e As ucBook_EventArgs)

    Public Event ucBook_DragDrop_Out_All_Out(ByVal sender As Object, ByVal e As xy_EventArgs)

    Public Event pbBook_DoubleClick_Out_All_Out(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

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

    Sub FillBookCase(ByVal BookOnCaseCollection As BookOnCaseCollection, ByVal ActivelibID As Guid)

        Dim ListOfMyBooks As New List(Of ucBook) ' Create List for name of mybooks  '0 to 39

        For Each _ucBook As ucBook In Me.Controls

            ' MyBook.Visible = True
            _ucBook.BookOnCase = Nothing
            _ucBook.ShowImage(False) = False
            _ucBook.BackColor = System.Drawing.Color.Transparent



            'Select Case _ucBook.Name
            '    Case "MyBook01"
            '        _ucBook.pbBook.Image = Global.WFControls.VB.My.Resources.Resources.B01
            '    Case "MyBook02"
            '        _ucBook.pbBook.Image = Global.WFControls.VB.My.Resources.Resources.B02
            '    Case "MyBook03"
            '        _ucBook.pbBook.Image = Global.WFControls.VB.My.Resources.Resources.B03
            '    Case "MyBook04"
            '        _ucBook.pbBook.Image = Global.WFControls.VB.My.Resources.Resources.B04
            '    Case "MyBook05"
            '        _ucBook.pbBook.Image = Global.WFControls.VB.My.Resources.Resources.B05
            '    Case "MyBook06"
            '        _ucBook.pbBook.Image = Global.WFControls.VB.My.Resources.Resources.B06
            '    Case "MyBook07"
            '        _ucBook.pbBook.Image = Global.WFControls.VB.My.Resources.Resources.B07
            '    Case "MyBook08"
            '        _ucBook.pbBook.Image = Global.WFControls.VB.My.Resources.Resources.B08
            '    Case "MyBook09"


            '    Case Else

            'End Select


            '----------------------
            ListOfMyBooks.Add(_ucBook)

        Next

        ListOfMyBooks.Sort(Function(p1, p2) p1.Name.CompareTo(p2.Name)) '0 to 39

        '---------------------------------------------------------------------------------------

        If BookOnCaseCollection IsNot Nothing Then

            For i As Integer = 0 To BookOnCaseCollection.Count - 1

                Dim Location As Integer = RowColumn2ListLocation(BookOnCaseCollection(i).shelfRow, BookOnCaseCollection(i).shelfColumn)

                Dim _ucBook As ucBook = CType(ListOfMyBooks(Location), ucBook) 'set ehch book 0 to 39

                _ucBook.BookOnCase = BookOnCaseCollection(i)

                If ActivelibID = Guid.Empty OrElse ActivelibID <> _ucBook.BookOnCase.libID Then
                    _ucBook.ShowImage(False) = True
                Else
                    _ucBook.ShowImage(True) = True
                End If


                AddHandler _ucBook.pbBook_MouseHover_Out, AddressOf pbBook_MouseHover_Out_All 'New EventHandler(AddressOf Inside_MouseHover)
                AddHandler _ucBook.pbBook_MouseLeave_Out, AddressOf pbBook_MouseLeave_Out_All
                AddHandler _ucBook.pbBook_DoubleClick_Out, AddressOf pbBook_DoubleClick_Out_All

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

#Region " Load "

    Private Sub ucBookCase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each _Control As Control In Me.Controls

            If TypeOf _Control Is WFControls.VB.ucBook Then
                Dim _ucBook As ucBook = CType(_Control, ucBook)
                _ucBook.AllowDrop = True

                AddHandler _ucBook.ucBook_DragDrop_Out, AddressOf ucBook_DragDrop_Out_All
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

#End Region

#Region " Raise OutGoing Event"

    Sub pbBook_MouseHover_Out_All(ByVal sender As System.Object, ByVal e As ucBook_EventArgs)

        RaiseEvent pbBook_MouseHover_Out_All_Out(sender, e)

    End Sub

    Sub pbBook_MouseLeave_Out_All(ByVal sender As System.Object, ByVal e As ucBook_EventArgs)

        RaiseEvent pbBook_MouseLeave_Out_All_Out(sender, e)

    End Sub

    Private Sub ucBook_DragDrop_Out_All(ByVal sender As System.Object, ByVal e As Guid)

        Dim _ucBook As New ucBook
        _ucBook = CType(sender, ucBook)
        Dim Row, Col As Integer
        MyBookName2RowCol(_ucBook.Name, Row, Col)

        RaiseEvent ucBook_DragDrop_Out_All_Out(sender, New xy_EventArgs(e, Row, Col))

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

    Private Sub pbBook_DoubleClick_Out_All(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For Each _ucBook As ucBook In Me.Controls

            If _ucBook.BookOnCase IsNot Nothing AndAlso _ucBook.BookOnCase.libID = CType(sender, ucBook).BookOnCase.libID Then
                _ucBook.ShowImage(True) = True
            ElseIf _ucBook.BookOnCase IsNot Nothing Then
                _ucBook.ShowImage(False) = True
            End If

        Next


        RaiseEvent pbBook_DoubleClick_Out_All_Out(sender, e)

    End Sub

#End Region


End Class
