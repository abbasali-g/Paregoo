Namespace tempDocs
    Public Class TempDocsDetail

        Private _tpDID As String
        Private _tpCatName As String
        Private _tpParentID As String
        Private _tpControlKey As String
        Private _tpkeyContent As String
        Private _tpPParentId As String


        Public Property tpDID() As String
            Get
                Return _tpDID
            End Get
            Set(ByVal value As String)
                _tpDID = value
            End Set
        End Property


        Public Property tpCatName() As String
            Get
                Return _tpCatName
            End Get
            Set(ByVal value As String)
                _tpCatName = value
            End Set
        End Property


        Public Property tpParentID() As String
            Get
                Return _tpParentID
            End Get
            Set(ByVal value As String)
                _tpParentID = value
            End Set
        End Property


        Public Property tpControlKey() As String
            Get
                Return _tpControlKey
            End Get
            Set(ByVal value As String)
                _tpControlKey = value
            End Set
        End Property


        Public Property tpkeyContent() As String
            Get
                Return _tpkeyContent
            End Get
            Set(ByVal value As String)
                _tpkeyContent = value
            End Set
        End Property


        Public Property tpPParentId() As String
            Get
                Return _tpPParentId
            End Get
            Set(ByVal value As String)
                _tpPParentId = value
            End Set
        End Property

        Public Sub New(ByVal catName As String, ByVal catKey As String)

            _tpCatName = catName

            _tpControlKey = catKey

        End Sub

        Public Sub New()

        End Sub
    End Class
End Namespace

