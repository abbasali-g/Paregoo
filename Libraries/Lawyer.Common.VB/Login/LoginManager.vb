Imports Lawyer.Common.CS
Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting


Namespace Login

    Public Class LoginManager

#Region "Lreview"

#Region "Methods"


        Public Shared Function ValidateSavedConnection(ByVal c As ConfigFile.Config, ByVal islocal As Boolean) As String

            If c IsNot Nothing Then

                Dim result As String = TestPrivillage(c, islocal)

                If result <> String.Empty Then Return result

                Dim con As MySqlConnection = New MySqlConnection(String.Format("server={0};Port={1};uid={2}; pwd={3};database=nwdicdad2;", c.LIP, c.LPort, c.LUserName, c.LPassword))

                Dim com As MySqlCommand = New MySqlCommand("select count(*) from `information_schema`.`TABLES` where  table_schema='nwdicdad2'", con)

                Try

                    con.Open()

                Catch ex As Exception

                    con.Close()

                    Return "ارتباط برقرار نمی باشد."

                End Try

                Try

                    Dim count As Long = CLng(com.ExecuteScalar())

                    If count >= 25 Then ''''>30

                        com.CommandText = "select count(*) from `information_schema`.`ROUTINES` where  routine_schema='nwdicdad2'"

                        count = CLng(com.ExecuteScalar())

                        con.Close()

                        If count < 200 Then

                            Throw New Exception

                        End If

                    Else

                        Throw New Exception

                    End If

                    CommonSetting.CommonSettingManager.SetConnectionString(c.LIP, c.LPort, c.LUserName, c.LPassword)

                Catch ex As Exception

                    If con.State <> ConnectionState.Closed Then

                        con.Close()

                    End If

                    Return "پایگاه داده آماده پاسخگویی نمی باشد."

                End Try

                Return String.Empty

            Else

                Return "ارتباط برقرار نمی باشد."

            End If


        End Function

        Private Shared Function TestPrivillage(ByVal c As ConfigFile.Config, ByVal islocal As Boolean) As String

            Dim con As MySqlConnection = New MySqlConnection(String.Format("server={0};Port={1};uid={2}; pwd={3};database=information_schema;", c.LIP, c.LPort, c.LUserName, c.LPassword))

            Dim com As MySqlCommand = New MySqlCommand("select count(Grantee) from  `information_schema`.`USER_PRIVILEGES` where Grantee = concat('''','root','''', '@','''','%','''')  and is_Grantable='YES'", con)

            Try
                con.Open()

                Dim result As Long = CLng(com.ExecuteScalar())

                con.Close()

                If islocal Then

                    If result < 4 Then

                        Dim p As Process = New Process()

                        Dim f As ProcessStartInfo = New ProcessStartInfo(Lawyer.Common.VB.Common.FileManager.GetAutoConfigExePath, String.Format("{0} {1}  {2} ", "--password=" + c.Password, "--setprivilege", "--serverType"))

                        p.StartInfo.UseShellExecute = False

                        p.StartInfo.CreateNoWindow = True

                        p.StartInfo = f

                        p.Start()

                        p.WaitForExit()

                    End If

                Else

                    If result < 4 Then
                        Return "user مربوط به پایگاه داده تنظیم نشده است."
                    End If


                End If


            Catch ex As Exception

                Return "user مربوط به پایگاه داده تنظیم نشده است."

            End Try

            Return String.Empty

        End Function

        Public Shared Function TestConnection(ByVal Ip As String, ByVal port As String, ByVal Username As String, ByVal Pass As String) As Boolean

            Dim con As MySqlConnection = New MySqlConnection(String.Format("server={0};Port={1};uid={2}; pwd={3};database=nwdicdad2;", Ip, port, Username, Pass))

            Try

                con.Open()

                con.Close()

                Return True

            Catch ex As Exception

                con.Close()

                Return False

            End Try

        End Function

        Public Shared Sub SetCurrentLogin(ByVal CustId As String)

            Dim params(0) As MySqlParameter

            Dim validate As Boolean = False

            params(0) = New MySqlParameter("_custID", CustId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelCurrentLogin", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                CurrentLogin.CurrentUser = GetLoginFromReader(reader)

            End If

            reader.Close()


        End Sub

        Public Shared Sub SetCurrentLoginDebug(ByVal CustId As String)

            Dim params(0) As MySqlParameter

            Dim validate As Boolean = False

            params(0) = New MySqlParameter("_custID", CustId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelCurrentLogin", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                CurrentLogin.CurrentUser = GetLoginFromReader(reader)

            End If

            reader.Close()


        End Sub


#End Region

#End Region

        Public Shared Sub changeUserInfo(ByVal fullname As String, ByVal IsAdmin As Boolean, ByVal mail1 As String, ByVal role As ContactInfo.Enums.RoleType)

            CurrentLogin.CurrentUser.IsAdmin = IsAdmin


            CurrentLogin.CurrentUser.Mail = mail1

            CurrentLogin.CurrentUser.Name = fullname

            CurrentLogin.CurrentUser.Role = role

        End Sub

        Private Shared Function GetLoginFromReader(ByVal reader As IDataReader) As Login

            Dim parameter As New Login

            parameter.UserID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID").ToString

            parameter.IsAdmin = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "custIsAdminUser")

            parameter.Mail = DbAccessLayer.MySqlDataHelper.GetString(reader, "custEmailOne").ToString

            parameter.Name = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName").ToString

            parameter.Role = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "custType")

            Return parameter

        End Function


    End Class

End Namespace

