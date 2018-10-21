Namespace Docs

    Public Class FileDocs
        Private _fileDocID As String
        Private _fileID As String
        Private _fileCaseID As String
        Private _fileDocName As String
        Private _fileDocContent As String
        Private _fileDocBinary As Byte()
        Private _fileDocDate As Int32
        Private _fileDocTime As String
        Private _fileDocImageID As String
        Private _fileDocExtension As String
        Private _docFullPath As String
        Private _fileType As Int16?

        Public Property fileDocID() As String
            Get
                Return _fileDocID
            End Get
            Set(ByVal value As String)
                _fileDocID = value
            End Set
        End Property

        Public Property fileType() As Int16?
            Get
                Return _fileType
            End Get
            Set(ByVal value As Int16?)
                _fileType = value
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


        Public Property fileCaseID() As String
            Get
                Return _fileCaseID
            End Get
            Set(ByVal value As String)
                _fileCaseID = value
            End Set
        End Property


        Public Property fileDocName() As String
            Get
                Return _fileDocName
            End Get
            Set(ByVal value As String)
                _fileDocName = value
            End Set
        End Property


        Public Property fileDocContent() As String
            Get
                Return _fileDocContent
            End Get
            Set(ByVal value As String)
                _fileDocContent = value
            End Set
        End Property


        Public Property fileDocBinary() As Byte()
            Get
                Return _fileDocBinary
            End Get
            Set(ByVal value As Byte())
                _fileDocBinary = value
            End Set
        End Property


        Public Property fileDocDate() As Int32
            Get
                Return _fileDocDate
            End Get
            Set(ByVal value As Int32)
                _fileDocDate = value
            End Set
        End Property


        Public Property fileDocTime() As String
            Get
                Return _fileDocTime
            End Get
            Set(ByVal value As String)
                _fileDocTime = value
            End Set
        End Property


        Public Property fileDocImageID() As String
            Get
                Return _fileDocImageID
            End Get
            Set(ByVal value As String)
                _fileDocImageID = value
            End Set
        End Property


        Public Property fileDocExtension() As String
            Get
                Return _fileDocExtension
            End Get
            Set(ByVal value As String)
                _fileDocExtension = value
            End Set
        End Property



        Public Property DocFullPath() As String
            Get
                Return _docFullPath
            End Get
            Set(ByVal value As String)
                _docFullPath = value
            End Set
        End Property


    End Class

End Namespace

