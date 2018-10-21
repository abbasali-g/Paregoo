Namespace BaseUserControl.ListView
    Public Class DragAndDropList
        Private _Title As String
        Private _ImageUrl1 As String
        Private _ImageUrl2 As String
        Private _Form As String

        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal value As String)
                _Title = value
            End Set
        End Property

        Public Property ImageUrl1() As String
            Get
                Return _ImageUrl1
            End Get
            Set(ByVal value As String)
                _ImageUrl1 = value
            End Set
        End Property

        Public Property ImageUrl2() As String
            Get
                Return _ImageUrl2
            End Get
            Set(ByVal value As String)
                _ImageUrl2 = value
            End Set
        End Property



        Public Property Form() As String
            Get
                Return _Form
            End Get
            Set(ByVal value As String)
                _Form = value
            End Set
        End Property
    End Class

End Namespace

