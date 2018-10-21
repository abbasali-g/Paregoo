
Namespace Docs
    Public Class TempDocReview

        Private _docExtension As String
        Private _docFile As Byte()
        Private _docID As String
        Private _docName As String
        Private _docContent As String
        Private _docImageID As String


        Public Property docImageID() As String
            Get
                Return _docImageID
            End Get
            Set(ByVal value As String)
                _docImageID = value
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
        Public Property docContent() As String
            Get
                Return _docContent
            End Get
            Set(ByVal value As String)
                _docContent = value
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


        Public Property docID() As String
            Get
                Return _docID
            End Get
            Set(ByVal value As String)
                _docID = value
            End Set
        End Property



        Public Property docFile() As Byte()
            Get
                Return _docFile
            End Get
            Set(ByVal value As Byte())
                _docFile = value
            End Set
        End Property

    End Class

End Namespace
