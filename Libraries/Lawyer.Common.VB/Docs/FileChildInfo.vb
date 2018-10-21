Namespace Docs
    Public Class FileChildInfo

        Private _fID As String
        Private _fileIsCat As Boolean
        Private _fileName As String
        Private _fileType As Enums.FileType
        Private _fileImageID As String
        Private _ImageUpdateDate As String
        Private _imageExtension As String
        Private _fileRelationId As String

        Public Property fileID() As String
            Get
                Return _fID
            End Get
            Set(ByVal value As String)
                _fID = value
            End Set
        End Property


        Public Property fileRelationId() As String

            Get
                Return _fileRelationId
            End Get
            Set(ByVal value As String)
                _fileRelationId = value
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


        Public Property fileImageID() As String
            Get
                Return _fileImageID
            End Get
            Set(ByVal value As String)
                _fileImageID = value
            End Set
        End Property

        Public Property ImageUpdateDate() As String
            Get
                Return _ImageUpdateDate
            End Get
            Set(ByVal value As String)
                _ImageUpdateDate = value
            End Set
        End Property

        Public Property fileIsCat() As Boolean
            Get
                Return _fileIsCat
            End Get
            Set(ByVal value As Boolean)
                _fileIsCat = value
            End Set
        End Property

        Public Property fileName() As String
            Get
                Return _fileName
            End Get
            Set(ByVal value As String)
                _fileName = value
            End Set
        End Property

        Public Property fileType() As Enums.FileType
            Get
                Return _fileType
            End Get
            Set(ByVal value As Enums.FileType)
                _fileType = value
            End Set
        End Property
    End Class
End Namespace

