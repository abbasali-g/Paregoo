Namespace Docs
    Public Class FileDocsChildInfo
        Private _fileDocID As String
        Private _fileDocName As String
        Private _fileDocImageID As String
        Private _fileDocExtension As String

        Public Property fileDocID() As String
            Get
                Return _fileDocID
            End Get
            Set(ByVal value As String)
                _fileDocID = value
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

    End Class
End Namespace

