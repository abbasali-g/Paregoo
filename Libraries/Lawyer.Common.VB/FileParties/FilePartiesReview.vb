Namespace FileParties
    Public Class FilePartiesReview

        Private _filePartyID As String
        Private _fileCaseRole As Int16
        Private _contactInfoID As String


        Public Property filePartyID() As String
            Get
                Return _filePartyID
            End Get
            Set(ByVal value As String)
                _filePartyID = value
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

