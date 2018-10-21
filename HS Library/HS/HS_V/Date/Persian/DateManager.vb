Imports System.Globalization

Namespace HS.Date.Persian

    Public Class DateManager


#Region "-- Shamsi --"


        Public Shared Function GetShamsiString_8Digit() As String

            Dim _Date As Date = BaseCurrentDate()

            If _Date <> Nothing Then

                Dim pc As New PersianCalendar
                Dim Per As String = pc.GetYear(_Date) & CStr(pc.GetMonth(_Date)).PadLeft(2, "0"c) & CStr(pc.GetDayOfMonth(_Date)).PadLeft(2, "0"c)
                Return Per

            End If

            Return Nothing

        End Function

        Public Shared Function GetShamsiString_8Digit(ByVal MiladiData As Date) As String

            Dim _Date As Date = MiladiData

            If _Date <> Nothing Then

                Dim Pc As New PersianCalendar
                Dim Per As String = Pc.GetYear(_Date) & CStr(Pc.GetMonth(_Date)).PadLeft(2, "0"c) & CStr(Pc.GetDayOfMonth(_Date)).PadLeft(2, "0"c)
                Return Per

            End If

            Return Nothing

        End Function

        Public Shared Function GetShamsiString_8Digit(ByVal Year As String, ByVal Month As String, ByVal Day As String) As String

            ' Dim _DtFi As DateTimeFormatInfo = New CultureInfo("en-US", False).DateTimeFormat
            ' Dim _Date As Date = Convert.ToDateTime(Year + "/" + Month + "/" + Day, _DtFi)

            Dim _Date As Date = CDate(Year + "/" + Month + "/" + Day)

            If _Date <> Nothing Then

                Dim pc As New Globalization.PersianCalendar
                Dim Per As String = pc.GetYear(_Date) & CStr(pc.GetMonth(_Date)).PadLeft(2, "0"c) & CStr(pc.GetDayOfMonth(_Date)).PadLeft(2, "0"c)
                Return Per

            End If

            Return Nothing

        End Function


#End Region

#Region "-- Miladi --"


        Shared Function Shamsi2MiladiDate(ByVal Shamsi_10DigitString As String) As Date

            Dim _Date As Date

            If IsNumeric(Shamsi_10DigitString.Replace("/", "")) = False Then Return Nothing
            If Shamsi_10DigitString.Length <> 10 Then Return Nothing

            Try

                Dim pc As New Globalization.PersianCalendar
                _Date = pc.ToDateTime(Shamsi_10DigitString.Substring(0, 4), Shamsi_10DigitString.Substring(5, 2), Shamsi_10DigitString.Substring(8, 2), 0, 0, 0, 0, Globalization.PersianCalendar.PersianEra)
                Return _Date



            Catch ex As Exception
                Return Nothing
            End Try


        End Function

        Shared Function Shamsi2MiladiDate(ByVal Sal As Integer, ByVal Mah As Integer, ByVal Ruz As Integer) As Date


            If IsNumeric(Sal) = False Or IsNumeric(Mah) = False Or IsNumeric(Ruz) = False Then Return Nothing
            If Sal > 9999 Or Mah > 12 Or Ruz > 31 Then Return Nothing

            Try

                Dim _Date As New Date(Sal, Mah, Ruz, New PersianCalendar())
                Return _Date


            Catch ex As Exception
                Return Nothing
            End Try


        End Function


#End Region

#Region "-- Time --"

        Public Shared Function GetTime(ByVal MiladiData As DateTime) As String

            Dim _Date As Date = MiladiData

            If _Date <> Nothing Then

                Dim Time As String
                Time = CStr(_Date.Hour).PadLeft(2, "0"c) & ":" & CStr(_Date.Minute).PadLeft(2, "0"c) & ":" & CStr(_Date.Second).PadLeft(2, "0"c)
                Return Time

            End If

            Return Nothing


        End Function

#End Region


#Region "Utility"

        Private Shared Function BaseCurrentDate() As Date
            'base is client or server



            'Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim reader As IDataReader = db.GetDataReaderFromCommandText("  SELECT NOW() as curDate;")

            'If db.HasError Then Return Nothing

            'Dim curDate As Date

            'If reader.Read Then

            '    curDate = DbAccessLayer.MySqlDataHelper.GetDateTime(reader, "curDate").ToString()

            'End If

            'reader.Close()

            'Return curDate

        End Function

#End Region


#Region "-- unused "

        Shared Function GetMiladiDate_DTFI() As String
            Try

                Dim DTFI As DateTimeFormatInfo = New CultureInfo("en-US", False).DateTimeFormat

                ' Year_Miladi_Today = CInt(Year(Date.Now.ToString("s", DTFI)))
                ' Month_Miladi_Today = CInt(Month(Date.Now.ToString("s", DTFI)))
                ' Day_Miladi_Today = CInt(Day(Date.Now.ToString("s", DTFI)))


                'Custom Date and Time Format Strings
                'Date.Now.ToString("yyyy/MM/dd")

                'SELECT CONVERT(CHAR(10),GETDATE(),111)


                Return Date.Now.ToString("s", DTFI)

            Catch ex As Exception
                Return Nothing
            Finally

            End Try
        End Function

#End Region



    End Class


End Namespace
