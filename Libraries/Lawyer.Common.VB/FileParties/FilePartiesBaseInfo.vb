Namespace FileParties
    Public Class FilePartiesBaseInfo

        Private _contactInfoID As String
        Private _custFullName As String
        Private _fileCaseRole As Int16


        Public Property contactInfoID() As String
            Get
                Return _contactInfoID
            End Get
            Set(ByVal value As String)
                _contactInfoID = value
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


        Public Property fileCaseRole() As Int16
            Get
                Return _fileCaseRole
            End Get
            Set(ByVal value As Int16)
                _fileCaseRole = value
            End Set
        End Property


    End Class
End Namespace

