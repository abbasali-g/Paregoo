Namespace Docs

    Public Class Files

        Private _fileIsCat As Boolean
        Private _fileChilds As String
        Private _fileID As String
        Private _fileName As String
        Private _imageID As String
        Private _fileType As Enums.FileType
        Private _fileCustID As String
        Private _fileCaseID As String
        Private _FileLocker As String



        Public Property fileIsCat() As Boolean
            Get
                Return _fileIsCat
            End Get
            Set(ByVal value As Boolean)
                _fileIsCat = value
            End Set
        End Property

        Public Property FileLocker() As String
            Get
                Return _FileLocker
            End Get
            Set(ByVal value As String)
                _FileLocker = value
            End Set
        End Property

        Public Property fileChilds() As String
            Get
                Return _fileChilds
            End Get
            Set(ByVal value As String)
                _fileChilds = value
            End Set
        End Property

        Public Property fileCustID() As String
            Get
                Return _fileCustID
            End Get
            Set(ByVal value As String)
                _fileCustID = value
            End Set
        End Property

        Public Property fileID() As String
            Get
                Return _fileID
            End Get
            Set(ByVal value As String)
                _fileID = value
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


        Public Property fileImageID() As String
            Get
                Return _imageID
            End Get
            Set(ByVal value As String)
                _imageID = value
            End Set
        End Property


        Public Property fileCaseID() As String
            Get
                Return _fileCaseID
            End Get
            Set(ByVal value As String)
                _fileCaseID = value
            End Set
        End Property

        Public Property FileType() As Enums.FileType
            Get
                Return _fileType
            End Get
            Set(ByVal value As Enums.FileType)
                _fileType = value
            End Set
        End Property

    End Class

End Namespace

