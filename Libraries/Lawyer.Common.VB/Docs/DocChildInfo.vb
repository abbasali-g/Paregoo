Namespace Docs

    Public Class DocChildInfo
        Private _docID As String
        Private _docName As String
        Private _docIsCat As Boolean
        Private _docExtension As String
        Private _imageId As String
        Private _imageExtension As String
        Private _imageUpdateDate As String



        Public Property docID() As String
            Get
                Return _docID
            End Get
            Set(ByVal value As String)
                _docID = value
            End Set
        End Property

        Public Property imageExtension() As String
            Get
                Return _imageExtension
            End Get
            Set(ByVal value As String)
                _imageExtension = value
            End Set
        End Property

        Public Property imageUpdateDate() As String
            Get
                Return _imageUpdateDate
            End Get
            Set(ByVal value As String)
                _imageUpdateDate = value
            End Set
        End Property


        Public Property docImageID() As String
            Get
                Return _imageId
            End Get
            Set(ByVal value As String)
                _imageId = value
            End Set
        End Property


        Public Property docName() As String
            Get
                Return _docName
            End Get
            Set(ByVal value As String)
                _docName = value
            End Set
        End Property


        Public Property docIsCat() As Boolean
            Get
                Return _docIsCat
            End Get
            Set(ByVal value As Boolean)
                _docIsCat = value
            End Set
        End Property


        Public Property docExtension() As String
            Get
                Return _docExtension
            End Get
            Set(ByVal value As String)
                _docExtension = value
            End Set
        End Property

    End Class

End Namespace

