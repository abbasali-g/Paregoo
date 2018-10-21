Namespace FileParties
    Public Class FileParties

        Private _filePartyID As String
        Private _fileID As String
        Private _fileCaseID As String
        Private _fileCaseRole As Int16
        Private _contactInfoID As String
        Private _financeAccess As Boolean


        Public Property filePartyID() As String
            Get
                Return _filePartyID
            End Get
            Set(ByVal value As String)
                _filePartyID = value
            End Set
        End Property


        Public Property financeAccess() As Boolean
            Get
                Return _financeAccess
            End Get
            Set(ByVal value As Boolean)
                _financeAccess = value
            End Set
        End Property


        Public Property fileID() As String
            Get
                Return _fileID
            End Get
            Set(ByVal value As String)
                _fileID = value
            End Set
        End Property


        Public Property fileCaseID() As String
            Get
                Return _fileCaseID
            End Get
            Set(ByVal value As String)
                _fileCaseID = value
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


        Public Property contactInfoID() As String
            Get
                Return _contactInfoID
            End Get
            Set(ByVal value As String)
                _contactInfoID = value
            End Set
        End Property


    End Class
End Namespace

