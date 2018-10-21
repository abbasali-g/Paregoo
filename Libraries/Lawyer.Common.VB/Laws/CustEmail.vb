Namespace Laws


    Public Class CustEmail


        Private _custID As Int32
        Private _custFullName As String
        Private _custEmailOne As String
        Private _custEmailTwo As String


        Public Property custID() As Int32
            Get
                Return _custID
            End Get
            Set(ByVal value As Int32)
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


        Public Property custEmailTwo() As String
            Get
                Return _custEmailTwo
            End Get
            Set(ByVal value As String)
                _custEmailTwo = value
            End Set
        End Property






    End Class

End Namespace