Namespace Login
    Public Class Login

        Private _UserId As String
        Private _Name As String
        Private _RoleId As New ContactInfo.Enums.RoleType
        Private _IsAdmin As Boolean
        Private _Mail As String

        Public Property UserID() As String
            Get
                Return _UserId
            End Get
            Set(ByVal value As String)
                _UserId = value
            End Set
        End Property

        Public Property Mail() As String
            Get
                Return _Mail
            End Get
            Set(ByVal value As String)
                _Mail = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Public Property Role() As ContactInfo.Enums.RoleType
            Get
                Return _RoleId
            End Get
            Set(ByVal value As ContactInfo.Enums.RoleType)
                _RoleId = value
            End Set
        End Property

        Public Property IsAdmin() As Boolean
            Get
                Return _IsAdmin
            End Get
            Set(ByVal value As Boolean)
                _IsAdmin = value
            End Set
        End Property

    End Class
End Namespace

