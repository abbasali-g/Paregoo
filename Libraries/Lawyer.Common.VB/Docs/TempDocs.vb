Namespace Docs
    Public Class TempDocs
        Private _docID As String
        Private _docName As String
        Private _docIsCat As Boolean
        Private _docChild As String
        Private _docFile As Byte()
        Private _docOwner As String
        Private _docContent As String
        Private _docType As String
        Private _docImageID As String
        Private _docExtension As String
        Private _docFullPath As String


        Public Property docID() As String
            Get
                Return _docID
            End Get
            Set(ByVal value As String)
                _docID = value
            End Set
        End Property

        Public Property docFullPath() As String
            Get
                Return _docFullPath
            End Get
            Set(ByVal value As String)
                _docFullPath = value
            End Set
        End Property


        Public Property docName() As String
            Get
                Return _docName
            End Get
            Set(ByVal value As String)
                If value.Length > 45 Then value = value.Substring(0, 45)
                _docName = value
            End Set
        End Property



        Public Property docType() As String
            Get
                Return _docType
            End Get
            Set(ByVal value As String)

                If String.IsNullOrEmpty(value) AndAlso value.Length > 45 Then value = value.Substring(0, 45)

                _docType = value
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


        Public Property docChild() As String
            Get
                Return _docChild
            End Get
            Set(ByVal value As String)
                _docChild = value
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


        Public Property docOwner() As String
            Get
                Return _docOwner
            End Get
            Set(ByVal value As String)
                _docOwner = value
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




        Public Property docImageID() As String
            Get
                Return _docImageID
            End Get
            Set(ByVal value As String)
                _docImageID = value
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
