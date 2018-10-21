Imports MySql.Data.MySqlClient
Imports LawyerCommonControls.CommonSetting
Imports System.Globalization


Namespace CommonVB



    Public Class DateManager


#Region "LReview"

#Region "Methods"

        Public Shared Function GetCurrentShamsiDate() As String

            Dim curDate As Date = GetCurrentDate()

            If curDate <> Nothing Then

                Dim Per As String

                Dim ps As New PersianCalendar

                Per = ps.GetYear(curDate) & "/" & CStr(ps.GetMonth(curDate)).PadLeft(2, "0"c) & "/" & CStr(ps.GetDayOfMonth(curDate)).PadLeft(2, "0"c)

                Return Per

            End If

            Return Nothing

        End Function

        Public Shared Function GetCurrentTime() As String

            Dim curDate As Date = GetCurrentDate()

            If curDate <> Nothing Then

                Dim Per As String

                Dim time As DateTime = DateTime.Now()

                Per = CStr(time.Hour).PadLeft(2, "0"c) & ":" & CStr(time.Minute).PadLeft(2, "0"c) & ":" & CStr(time.Second).PadLeft(2, "0"c)

                Return Per

            End If

            Return Nothing


        End Function

        'Public Shared Function GetCurrentTime(ByVal m As Double) As String

        '    Dim curDate As Date = GetCurrentDate()

        '    If curDate <> Nothing Then

        '        Dim Per As String

        '        Dim time As DateTime = DateTime.Now()

        '        time.AddMinutes(m)

        '        Per = CStr(time.Hour).PadLeft(2, "0"c) & ":" & CStr(time.Minute).PadLeft(2, "0"c) & ":" & CStr(time.Second).PadLeft(2, "0"c)

        '        Return Per

        '    End If

        '    Return Nothing


        'End Function

        Public Shared Function GetCurrentShamsiDateInNumericFormat() As String

            Dim curDate As Date = GetCurrentDate()

            If curDate <> Nothing Then

                Dim Per As String

                Dim ps As New PersianCalendar

                Per = ps.GetYear(curDate) & CStr(ps.GetMonth(curDate)).PadLeft(2, "0"c) & CStr(ps.GetDayOfMonth(curDate)).PadLeft(2, "0"c)

                Return Per

            End If

            Return Nothing

        End Function

#End Region

#Region "Utility"

        Private Shared Function GetCurrentDate() As Date

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromCommandText("  SELECT NOW() as curDate;")

            If db.HasError Then Return Nothing

            Dim curDate As Date

            If reader.Read Then

                curDate = DbAccessLayer.MySqlDataHelper.GetDateTime(reader, "curDate").ToString()

            End If

            reader.Close()

            Return curDate

        End Function

#End Region
#End Region




        Public Shared Function GetCurrentYear() As String

            Dim curDate As Date = GetCurrentDate()

            If curDate <> Nothing Then

                Dim Per As String

                Dim ps As New PersianCalendar

                Per = ps.GetYear(curDate)

                Return Per

            End If

            Return Nothing

        End Function

        Public Shared Function GetFileUpdateDate() As String

            Dim curDate As Date = GetCurrentDate()

            If curDate <> Nothing Then

                Dim Per As String

                Dim ps As New PersianCalendar

                Per = CStr(ps.GetYear(curDate)).Substring(2, 2) & CStr(ps.GetMonth(curDate)).PadLeft(2, "0"c) & CStr(ps.GetDayOfMonth(curDate)).PadLeft(2, "0")

                Per &= CStr(curDate.Hour).PadLeft(2, "0"c) & CStr(curDate.Minute).PadLeft(2, "0"c) & CStr(curDate.Second).PadLeft(2, "0"c)

                Return Per

            End If

            Return Nothing

        End Function
    End Class

End Namespace

