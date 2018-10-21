Namespace Docs
    'Public Enum Level

    '    createFile = 1
    '    CreateCase = 2
    '    CaseDetail = 3

    'End Enum

    Public Class FileParentInfo

        Private _FileType As Enums.FileType
        Private _fID As String
        Private _FileCaseId As String
        Private _fileName As String
       
        Public Property fileId() As String
            Get
                Return _fID
            End Get
            Set(ByVal value As String)
                _fID = value
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


        Public Property FileCaseId() As String
            Get
                Return _FileCaseId
            End Get
            Set(ByVal value As String)
                _FileCaseId = value
            End Set
        End Property

        Public Property FileType() As Enums.FileType
            Get
                Return _FileType
            End Get
            Set(ByVal value As Enums.FileType)
                _FileType = value
            End Set
        End Property


    End Class
End Namespace

