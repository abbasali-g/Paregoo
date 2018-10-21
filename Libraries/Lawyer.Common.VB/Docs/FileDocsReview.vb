Namespace Docs

    Public Class FileDocsReview

        Private _fileDocName As String
        Private _fileDocBinary As Byte()
        Private _fileDocExtension As String
        Private _docFullPath As String

        Public Property fileDocName() As String
            Get
                Return _fileDocName
            End Get
            Set(ByVal value As String)
                _fileDocName = value
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


