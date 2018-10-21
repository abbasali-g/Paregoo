Namespace ContactInfo

    Public Class ContactInfoForTransfer

        Private _custUserName As String
        Private _custFullName As String


        Public Property custUserName() As String
            Get
                Return _custUserName
            End Get
            Set(ByVal value As String)
                _custUserName = value
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

    End Class

End Namespace

