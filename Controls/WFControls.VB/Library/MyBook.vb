Imports Lawyer.Common.VB.Books

Public Class MyBook


#Region "Event"


    Public Event MyBook_MouseHover(ByVal sender As Object, ByVal e As MyBook_EventArgs) 'As EventHandler
    Public Event MyBook_MouseLeave(ByVal sender As Object, ByVal e As MyBook_EventArgs) 'As EventHandler

    Public Event MyBook_DragDropMe(ByVal sender As Object, ByVal e As Guid)

    Public Event MyBook_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)


    Public Class MyBook_EventArgs : Inherits EventArgs ' unused

        Public Sub New(ByVal BookOnCase As BookOnCase)
            _BookOnCase = BookOnCase
        End Sub

        Private _BookOnCase As BookOnCase
        Public ReadOnly Property BookOnCase() As BookOnCase
            Get
                Return _BookOnCase
            End Get

        End Property

    End Class

#End Region

#Region "Property"



    Private _BookOnCase As New BookOnCase
    Public Property BookOnCase() As BookOnCase
        Get
            Return _BookOnCase
        End Get
        Set(ByVal value As BookOnCase)
            _BookOnCase = value
        End Set
    End Property



    'Private _DoubleClick As Boolean
    'Public Property MyBookDoubleClick() As Boolean
    '    Get
    '        Return _DoubleClick
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _DoubleClick = value
    '        If _DoubleClick Then
    '            pbBook_DoubleClick(Me, Nothing)
    '        End If
    '    End Set
    'End Property


    Private _DragEnter2 As Boolean
    Public Property DragEnterMe() As Boolean
        Get
            Return _DragEnter2
        End Get
        Set(ByVal value As Boolean)
            _DragEnter2 = value
            If _DragEnter2 Then
                'pbBook_DragEnter(Me, Nothing)
            Else
                'pbBook_DragLeave(Me, Nothing)
            End If
        End Set
    End Property


    Private _ShowImage As Boolean
    Public Property ShowImage(ByVal IsActive As Boolean) As Boolean
        Get
            Return _ShowImage
        End Get
        Set(ByVal value As Boolean)
            _ShowImage = value
            If _ShowImage Then
                If IsActive Then
                    pbBook.Image = My.Resources.Resources.MyBook_Active
                Else
                    pbBook.Image = My.Resources.Resources.MyBook
                End If
                changed = False
            Else
                pbBook.Image = Nothing
            End If
        End Set
    End Property



#End Region


    Private Sub MyBook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Me.Visible = False
        ' Me.BackColor = System.Drawing.Color.Transparent
    End Sub


    Private Sub pbBook_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBook.MouseHover

        RaiseEvent MyBook_MouseHover(Me, Nothing) 'New MyBook_EventArgs(BookOnBookCase)

    End Sub

    Private Sub pbBook_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBook.MouseLeave

        RaiseEvent MyBook_MouseLeave(Me, Nothing) ' New MyBook_EventArgs(BookOnBookCase)

    End Sub


    Private Sub pbBook_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBook.DoubleClick

        RaiseEvent MyBook_DoubleClick(Me, e)

    End Sub

  



#Region "Drag in"

    Function Part(ByVal str As String) As String()

        Dim strArray() As String
        Dim Separators() As String = {"<|>"}

        strArray = str.Split(Separators, StringSplitOptions.None)

        Return strArray
    End Function

    Sub _DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Dim changed As Boolean = False

    Private Sub MyBook_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter

        If e.Data.GetDataPresent(DataFormats.StringFormat) AndAlso pbBook.Image Is Nothing Then
            e.Effect = DragDropEffects.Copy
            pbBook.Image = My.Resources.Resources.MyBook_Glow
            changed = True
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub MyBook_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DragLeave

        If changed Then
            pbBook.Image = Nothing 'My.Resources.Resources.MyBook
        End If

    End Sub

    Private Sub MyBook_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop

        pbBook.Image = Nothing


        Dim str As String = CType(e.Data.GetData(DataFormats.StringFormat), String)

        Dim libID As New Guid
        Try
            libID = New Guid(Part(str)(0))
        Catch ex As Exception
            libID = Guid.Empty
        End Try

        If Part(str).Length = 4 Then ' move inside case

            '------------------------- old book info send by me
            _BookOnCase = New BookOnCase
            _BookOnCase.shelfNumber = CInt(Part(str)(1))
            _BookOnCase.shelfRow = CInt(Part(str)(2))
            _BookOnCase.shelfColumn = CInt(Part(str)(3))
            '----------------------------

        End If

        RaiseEvent MyBook_DragDropMe(Me, libID)

    End Sub

#End Region

#Region "Drag Out"



    Private Sub pbBook_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbBook.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left AndAlso e.Clicks = 1 Then ' allow double click also can raise.

            If Me.BookOnCase IsNot Nothing Then 'active book
                MyBook_MouseDown(Me, e)
            End If

        End If


        

    End Sub

    Dim moveCursor, nodropCursor, copyCursor As Cursor

    Private Sub MyBook_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        Dim _Bitmap As New Bitmap(My.Resources.MyBook2)
        moveCursor = New Cursor(_Bitmap.GetHicon)

        Dim _Bitmap2 As New Bitmap(My.Resources.MyBook2_Gray)
        nodropCursor = New Cursor(_Bitmap2.GetHicon)

        Dim MyBook As MyBook = CType(sender, MyBook)
        Dim str As String



        str = MyBook.BookOnCase.libID.ToString + _
        "<|>" + _
         MyBook.BookOnCase.shelfNumber.ToString + _
         "<|>" + _
         MyBook.BookOnCase.shelfRow.ToString + _
         "<|>" + _
         MyBook.BookOnCase.shelfColumn.ToString


        Me.DoDragDrop(str, DragDropEffects.Copy)

    End Sub

    Private Sub MyBook_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles Me.GiveFeedback

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


#End Region


  
End Class
