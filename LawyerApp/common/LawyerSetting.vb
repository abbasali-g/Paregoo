Imports System.IO
Imports Lawyer.Common.VB.tempDocs
Imports MySql.Data.MySqlClient

Public Class LawyerSetting

    Public Shared ReadOnly Property FileKey() As String
        Get
            Return "1213214532129567"
        End Get

    End Property

    Private Shared splitString As String = "@;;@"

    Public Shared lastLog As DateTime

    Public Shared ExpireDate As DateTime

    Private Shared Id As String = "672549f0-73e9-4d31-bbe7-89bb39097a67"

    Private Shared MaxUse As Integer = 29

    Private Shared Increment As Integer = 8

    Public Const LicenceId As UInteger = 473

    Public Shared Function CheckExpire() As String
        ''************************************write File
        'Dim start As String = Lawyer.Common.CS.Common.SecurityHelper.Encrypt(DateTime.Now(), FileKey)

        'Dim EndDate As String = Lawyer.Common.CS.Common.SecurityHelper.Encrypt(DateTime.Now().AddMonths(6), FileKey)

        ''خواندن فایل

        'tempDocsDetailManager.EditContent(Id, String.Empty)
        ''**********************************************************

        Dim dates As String() = ReadTextFile()

        Dim curTime As DateTime = DateTime.Now()

        lastLog = curTime

        ExpireDate = curTime

        If dates Is Nothing Then
            'فایل دستکاری شده است

            Endprogram()

            Return "E3000"

        Else

            Dim d As DateTime = CType(dates(0), DateTime)

            If curTime <= d Then
                'زمان سیستم نادرست می باشد حتی در اول نصب هم باشد اجازه نخواهد داد
                Endprogram()

                Return "E3001"

            End If

            If curTime >= CType(dates(1), DateTime) Then

                'زمان انقضای برنامه

                Endprogram()

                Return "E3002"

            End If

            Dim str As String = String.Empty

            Try
                'str = tempDocsDetailManager.GetContentByID(Id, GetConnectionString)
                str = tempDocsDetailManager.GetContentByID(Id)

            Catch ex As Exception
                'خطا در خواندن مقدار Log
                Endprogram()

                Return "E4000"

            End Try

            'ورود برای اولین بار
            If str = String.Empty Then

                'tempDocsDetailManager.EditContent(Id, Lawyer.Common.CS.Common.SecurityHelper.Encrypt(curTime.ToString(), FileKey) & splitString & Lawyer.Common.CS.Common.SecurityHelper.Encrypt(curTime.AddDays(MaxUse).ToString, FileKey), GetConnectionString())

                tempDocsDetailManager.EditContent(Id, Lawyer.Common.CS.Common.SecurityHelper.Encrypt(curTime.ToString(), FileKey) & splitString & Lawyer.Common.CS.Common.SecurityHelper.Encrypt(curTime.AddDays(MaxUse).ToString, FileKey))

                lastLog = curTime

                ExpireDate = curTime.AddDays(MaxUse)

                Return String.Empty

            Else

                If IsValidTime(str) Then

                    If (Not lastLog > curTime) AndAlso (Not curTime >= ExpireDate) Then

                        'If tempDocsDetailManager.EditContent(Id, Lawyer.Common.CS.Common.SecurityHelper.Encrypt(curTime.ToString(), FileKey) & splitString & Lawyer.Common.CS.Common.SecurityHelper.Encrypt(ExpireDate.ToString(), FileKey), GetConnectionString()) Then
                        If tempDocsDetailManager.EditContent(Id, Lawyer.Common.CS.Common.SecurityHelper.Encrypt(curTime.ToString(), FileKey) & splitString & Lawyer.Common.CS.Common.SecurityHelper.Encrypt(ExpireDate.ToString(), FileKey)) Then

                            lastLog = curTime

                            Return String.Empty

                        Else
                            'مقدار ثبت نشد

                            Endprogram()

                            Return "E4001"

                        End If


                    Else
                        'دستکاری شده
                        Endprogram()

                        Return "E5000"


                    End If

                Else

                    'دستکاری شده
                    Endprogram()

                    Return "E5001"

                End If

            End If

        End If

        Return String.Empty

    End Function

    Shared Function ReadTextFile() As String()

        Dim sr As StreamReader

        Dim dates() As String = New String() {"", ""}

        Dim _File As String = Lawyer.Common.VB.Common.FileManager.App_RootPath() + "\Temp.txt"

        If File.Exists(_File) Then

            sr = New StreamReader(_File)

            Try

                If sr.Peek() >= 0 Then

                    dates(0) = Lawyer.Common.CS.Common.SecurityHelper.Decrypt(sr.ReadLine(), FileKey)

                End If

                If sr.Peek() >= 0 Then

                    dates(1) = Lawyer.Common.CS.Common.SecurityHelper.Decrypt(sr.ReadLine(), FileKey)

                End If

                sr.Close()

                Return dates

            Catch ex As Exception

                Return Nothing

            End Try

        Else

            Return Nothing

        End If

    End Function

    Private Shared Function IsValidTime(ByVal str As String) As Boolean

        Dim str1 As String() = str.Split(New String() {splitString}, System.StringSplitOptions.RemoveEmptyEntries)

        If str1.Length = 2 Then

            Try
                lastLog = CType(Lawyer.Common.CS.Common.SecurityHelper.Decrypt(str1(0), FileKey), DateTime)

                ExpireDate = CType(Lawyer.Common.CS.Common.SecurityHelper.Decrypt(str1(1), FileKey), DateTime)

                If lastLog >= ExpireDate Then
                    'زمان برنامه تمام شده

                    Return False

                Else

                    Return True

                End If

            Catch ex As Exception

                Return False

            End Try

        Else
            'جدول دستکاری شده
            Return False

        End If


    End Function

    Private Shared Function GetFilesDate() As DateTime

        Dim d As DateTime = Nothing
        Dim c As DateTime = Nothing

        Dim con As New MySqlConnection

        con.ConnectionString = GetConnectionStringInformation()

        Dim com As New MySqlCommand()

        com.Connection = con

        com.CommandText = "SELECT create_time,update_time FROM `information_schema`.`TABLES` where table_schema='nwdicdad2' and table_name='files'"

        Dim r As IDataReader = Nothing

        Try

            con.Open()

            r = com.ExecuteReader()

            If r.Read() Then

                c = CType(r.Item("create_time"), DateTime)

                If c = Nothing Then

                    '
                    Throw New Exception

                End If

                d = CType(r.Item("update_time"), DateTime)

            End If

            r.Close()

            con.Clone()

            If d = Nothing Then d = c

        Catch ex As Exception

            If r IsNot Nothing Then

                r.Close()

            End If

            con.Clone()

            Return Nothing

        End Try

        Return d

    End Function

    Private Shared Sub Endprogram()


        '2) change log
        Try

            tempDocsDetailManager.EditContent(Id, Lawyer.Common.CS.Common.SecurityHelper.Encrypt(ExpireDate.ToString, FileKey) & splitString & Lawyer.Common.CS.Common.SecurityHelper.Encrypt(ExpireDate.ToString, FileKey))

        Catch ex As Exception

        End Try




    End Sub

    Public Shared Sub UpdateLog()

        Try

            Dim c As DateTime = DateTime.Now()

            If c < lastLog Then

                tempDocsDetailManager.EditContent(Id, Lawyer.Common.CS.Common.SecurityHelper.Encrypt(ExpireDate.ToString, FileKey) & splitString & Lawyer.Common.CS.Common.SecurityHelper.Encrypt(ExpireDate.ToString, FileKey))

            Else
                lastLog = c

                tempDocsDetailManager.EditContent(Id, Lawyer.Common.CS.Common.SecurityHelper.Encrypt(lastLog.ToString, FileKey) & splitString & Lawyer.Common.CS.Common.SecurityHelper.Encrypt(ExpireDate.ToString, FileKey))

            End If
            
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub EndLog()

        Try
            lastLog = ExpireDate

            tempDocsDetailManager.EditContent(Id, Lawyer.Common.CS.Common.SecurityHelper.Encrypt(ExpireDate.ToString, FileKey) & splitString & Lawyer.Common.CS.Common.SecurityHelper.Encrypt(ExpireDate.ToString, FileKey))

        Catch ex As Exception

        End Try

    End Sub

    Private Shared Function GetConnectionStringInformation() As String
        Return String.Format("server={0};Port={1};uid={2}; pwd={3};database=information_schema;", "127.0.0.1", "9918", "root", "@@%!mysqlnahani")
    End Function

    Public Shared Sub createInfoFile(ByVal txtContent As String)


        Dim filePath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\HgSetup_ErrorInfo.txt"

        Dim stream As IO.StreamWriter = IO.File.CreateText(filePath)

        stream.Write(txtContent)

        stream.Close()

        Process.Start(filePath)

    End Sub

End Class
