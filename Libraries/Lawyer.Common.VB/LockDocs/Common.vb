Namespace LockDocs
    Public Class Common

        Private Shared _DestComputerName As String
        Private Shared _DestConnString As String

        Private Shared _IP As String
        Private Shared _Pass As String
        Private Shared _User As String
        Private Shared _port As String

        Public Shared Property DestIP() As String
            Get
                Return _IP
            End Get
            Set(ByVal value As String)
                _IP = value
            End Set
        End Property

        Public Shared Property DestPass() As String
            Get
                Return _Pass
            End Get
            Set(ByVal value As String)
                _Pass = value
            End Set
        End Property

        Public Shared Property DestUser() As String
            Get
                Return _User
            End Get
            Set(ByVal value As String)
                _User = value
            End Set
        End Property

        Public Shared Property DestPort() As String
            Get
                Return _port
            End Get
            Set(ByVal value As String)
                _port = value
            End Set
        End Property

        Public Shared Property DestComputerName() As String
            Get
                Return _DestComputerName
            End Get
            Set(ByVal value As String)
                _DestComputerName = value.Trim()
            End Set
        End Property


        Public Shared Function DestConnectionString() As String
            Try
                'If String.IsNullOrEmpty(_DestConnString) Then

                _DestConnString = String.Format("server={0};port={1};uid={2}; pwd={3};database=nwdicdad2;", DestIP, DestPort, DestUser, DestPass)

                'End If

                Return _DestConnString

            Catch ex As Exception

                Return Nothing

            End Try

        End Function

        Public Shared Function IsCorrectDestComputer() As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Try

                db.Connection.Open()
                db.Connection.Close()
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

    End Class
End Namespace

