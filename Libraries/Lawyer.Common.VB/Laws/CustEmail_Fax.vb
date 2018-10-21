Namespace Laws


    Public Class CustEmail_Fax


        Private _custID As Guid
        Private _custFullName As String
        Private _custEmailOne As String
        Private _custFax As String


        Public Property custID() As Guid
            Get
                Return _custID
            End Get
            Set(ByVal value As Guid)
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


        Public Property custEmailOne() As String
            Get
                Return _custEmailOne
            End Get
            Set(ByVal value As String)
                _custEmailOne = value
            End Set
        End Property

        Public Property custFax() As String
            Get
                Return _custFax
            End Get
            Set(ByVal value As String)
                _custFax = value
            End Set
        End Property


    End Class

End Namespace