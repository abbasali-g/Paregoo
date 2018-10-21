Namespace Docs

    Public Class DocParentInfo
        Private _docID As String
        Private _DefaultImage As String
        Private _docType As String


        Public Property docID() As String
            Get
                Return _docID
            End Get
            Set(ByVal value As String)
                _docID = value
            End Set
        End Property


        Public Property DefaultImage() As String
            Get
                Return _DefaultImage
            End Get
            Set(ByVal value As String)
                _DefaultImage = value
            End Set
        End Property


        Public Property docType() As String
            Get
                Return _docType
            End Get
            Set(ByVal value As String)
                _docType = value
            End Set
        End Property

    End Class
End Namespace

