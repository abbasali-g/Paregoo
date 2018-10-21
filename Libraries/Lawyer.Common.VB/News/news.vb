Namespace News
    Public Class news

        Private _newsId As String
        Private _newsTitle As String
        Private _newsDescription As String
        Private _newsDate As String
        Private _Link As String


        Public Property newsId() As String
            Get
                Return _newsId
            End Get
            Set(ByVal value As String)
                _newsId = value
            End Set
        End Property


        Public Property newsTitle() As String
            Get
                Return _newsTitle
            End Get
            Set(ByVal value As String)
                _newsTitle = value
            End Set
        End Property


        Public Property Link() As String
            Get
                Return _Link
            End Get
            Set(ByVal value As String)
                _Link = value
            End Set
        End Property


        Public Property newsDescription() As String
            Get
                Return _newsDescription
            End Get
            Set(ByVal value As String)
                _newsDescription = value
            End Set
        End Property


        Public Property newsDate() As String
            Get
                Return _newsDate
            End Get
            Set(ByVal value As String)
                _newsDate = value
            End Set
        End Property

        Public Sub New(ByVal title As String, ByVal desc As String, ByVal curdate As String, ByVal link As String)

            _newsTitle = title
            _newsDescription = desc
            _newsDate = curdate
            _Link = link

        End Sub

        Public Sub New()

        End Sub

    End Class

End Namespace

