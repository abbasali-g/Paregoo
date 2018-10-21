Namespace ContactInfo
    Public Class ContactInfoReview

        Private _custID As String
        Private _custFullName As String


        Public Property custID() As String
            Get
                Return _custID
            End Get
            Set(ByVal value As String)
                _custID = value
            End Set
        End Property


        Public Property custFullName() As String
            Get
                Return _custFullName
            End Get
            Set(ByVal value As String)
                _custFullName = value
            End Set
        End Property

        Public Sub New(ByVal Id As String, ByVal name As String)
            _custID = Id
            _custFullName = name
        End Sub
        Public Sub New()
           
        End Sub
    End Class
End Namespace

