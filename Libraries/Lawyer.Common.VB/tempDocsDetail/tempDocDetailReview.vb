Namespace tempDocs
    Public Class tempDocDetailReview
        Private _tpDID As String
        Private _tpCatName As String


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
    End Class
End Namespace

