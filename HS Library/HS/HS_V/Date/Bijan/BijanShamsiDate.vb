Imports System.Globalization

'Imports Microsoft.VisualBasic
'Imports System.Data.SqlClient
'Imports System.Data
'Imports BijanComponents


Namespace HS.Date.Bijan

    Public Class BijanShamsiDate

        'Inherits DatabaseAccessLayer.DbaLayer

        Public Year_Shamsi_Today As Integer
        Public Month_Shamsi_Today As Integer
        Public Day_Shamsi_Today As Integer
        Public Year_Miladi_Today As Integer
        Public Month_Miladi_Today As Integer
        Public Day_Miladi_Today As Integer


        Enum DateType

            Day = 1
            Month = 2
            Year = 3

        End Enum
        '=======تارِيخ شمسی(+=/ امروز /=+)را بصورت رشته برمی گرداند=======================================

        Public Overloads Function GetShamsiDate() As String
            Try
                Dim pc As New PersianCalendar

                Return pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString().PadLeft(2, "0") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, "0")

            Catch ex As Exception

                Return Nothing
            End Try
        End Function

        Public Overloads Function GetShamsiDate(ByVal ReturnDateType As DateType) As String
            Try

                Dim pc As New PersianCalendar

                '  pc.GetYear(DateTime.Now).ToString(+"/" + pc.GetMonth(DateTime.Now).ToString().PadLeft(2, "0") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, "0"))


                '=================
                Select Case ReturnDateType
                    Case DateType.Day
                        Return pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, "0")

                    Case DateType.Month
                        Return pc.GetMonth(DateTime.Now).ToString().PadLeft(2, "0")

                    Case DateType.Year
                        Return pc.GetYear(DateTime.Now).ToString()

                End Select


            Catch ex As Exception
            Finally

            End Try
        End Function

        '=======تارِيخ شمسی داده شده را بصورت رشته برمی گرداند=======================================

        Public Overloads Function GetShamsiDate(ByVal MiladiDate As Date) As String
            Try
                Dim pc As New PersianCalendar

                Return pc.GetYear(MiladiDate).ToString(+"/" + pc.GetMonth(MiladiDate).ToString().PadLeft(2, "0") + "/" + pc.GetDayOfMonth(MiladiDate).ToString().PadLeft(2, "0"))


            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '===========تاريخ ميلادی را بصورت رشته برمی گرداند ================================sarandy

        Public Overloads Function GetMiladiDate() As Date 'String
            Try

                ' Dim DT As New DataTable
                ' DT = Me.GetDataTableFromProcedure("stpDateMiladi_Sel")

                'Fill Public Vars============

                '--------------                         sarandy

                Dim myDTFI As DateTimeFormatInfo = New CultureInfo("en-US", False).DateTimeFormat

                Year_Miladi_Today = CInt(Year(Date.Now.ToString("u", myDTFI)))
                Month_Miladi_Today = CInt(Month(Date.Now.ToString("u", myDTFI)))
                Day_Miladi_Today = CInt(Day(Date.Now.ToString("u", myDTFI)))

                '-----------------


                'Year_Miladi_Today = CInt(Year(Convert.ToDateTime(DT.Rows(0).Item("MiladiDate"))))
                'Month_Miladi_Today = CInt(Month(Convert.ToDateTime(DT.Rows(0).Item("MiladiDate"))))
                'Day_Miladi_Today = CInt(Day(Convert.ToDateTime(DT.Rows(0).Item("MiladiDate"))))

                '=================

                '  Return CStr(DT.Rows(0).Item("MiladiDate"))

                Return Date.Now

            Catch ex As Exception
                Return Nothing
            Finally

            End Try
        End Function

        Public Overloads Function GetMiladiDate(ByVal Sal As Integer, ByVal Mah As Integer, ByVal Ruz As Integer) As Date

            Try
                Dim pc As New PersianCalendar()
                Dim dt As DateTime = pc.ToDateTime(Sal, Mah, Ruz, 0, 0, 0, 0)

                Return dt

            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Overloads Function GetMiladiDate(ByVal ShamsiDate As String) As Object

            Try

             
                If ShamsiDate.Substring(0, 4).Length <> 4 Then

                    ShamsiDate = ReverseShamsiDate(ShamsiDate)

                End If

                Dim Year As Integer

                Dim Month As Integer

                Dim Day As Integer

                Year = Mid$(ShamsiDate, 1, 4)

                Month = Mid$(ShamsiDate, 6, 2)

                Day = Mid$(ShamsiDate, 9, 2)

                Dim pc As New PersianCalendar()
                Dim dt As DateTime = pc.ToDateTime(Year, Month, Day, 0, 0, 0, 0)

            Catch ex As Exception

                Return Nothing
            Finally

            End Try
        End Function

        Public Function GetTodayDate(ByVal Language As String) As Object

            Try

                Return GetShamsiDate()

            Catch ex As Exception

                Return Nothing

            End Try

        End Function

        Function GetFasriWeekDay(ByVal InputDate As DateTime) As Integer

            Dim FarsiDayOfWeek As Integer

            Select Case InputDate.DayOfWeek

                Case DayOfWeek.Saturday
                    FarsiDayOfWeek = 0
                Case DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
                    FarsiDayOfWeek = InputDate.DayOfWeek + 1

            End Select

            Return FarsiDayOfWeek

        End Function

        Function GetWeekDayName(ByVal InputDate As DateTime, ByVal Lang As String) As String

            Dim WeekdayName As String

            WeekdayName = GetFasriWeekDayName(InputDate)

            Return WeekdayName

        End Function

        Function GetFasriWeekDayName(ByVal InputDate As DateTime) As String

            Select Case InputDate.DayOfWeek

                Case DayOfWeek.Saturday
                    Return "شنبه"
                Case DayOfWeek.Sunday
                    Return "یکشنبه"
                Case DayOfWeek.Monday
                    Return "دوشنبه"
                Case DayOfWeek.Tuesday
                    Return "سه شنبه"
                Case DayOfWeek.Wednesday
                    Return "چهار شنبه"
                Case DayOfWeek.Thursday
                    Return "پنجشنبه"
                Case DayOfWeek.Friday
                    Return "جمعه"
            End Select

            Return ""

        End Function

        Public Shared Function IsShamsiDate(ByVal str As String) As Boolean

            If String.IsNullOrEmpty(str) Then Return False

            If str.Length <> 10 Then Return False

            If str.Split("/").Length <> 3 Then Return False

            If IsNumeric(str.Replace("/", "")) = False Then Return False

            Dim Year As String() = str.Split("/")

            If Year(0).Length = 4 Then '1387/11/19

                If Val(Year(1)) > 12 Or Val(Year(1)) < 0 Then Return False

                If Val(Year(2)) > 31 Or Val(Year(2)) < 0 Then Return False

            ElseIf Year(0).Length = 2 Then '31/12/1387

                If Val(Year(1)) > 12 Or Val(Year(1)) < 0 Then Return False

                If Val(Year(0)) > 31 Or Val(Year(0)) < 0 Then Return False

            End If

            Return True

        End Function

        Public Shared Function _ReverseShamsiDate(ByVal ShamsiDate As String) As String

            Dim RshamsiDate() As String = ShamsiDate.Split("/")

            '' ''If RshamsiDate(0).Length = 4 Then  'input shamsidate in the format of 1387/01/19

            '' ''    Return ShamsiDate

            '' ''Else

            Return RshamsiDate(2) & "/" & RshamsiDate(1) & "/" & RshamsiDate(0)

            '' ''End If

        End Function

        Public Function ReverseShamsiDate(ByVal ShamsiDate As String) As String

            _ReverseShamsiDate(ShamsiDate)

        End Function

        Public Function AdjustShamsiDate(ByVal ShamsiDate As String)

            Dim year As Integer = CInt(Me.GetShamsiDate().Substring(0, 2)) * 100

            Return AdjustShamsiDate(ShamsiDate, year)

        End Function

        Public Function AdjustShamsiDate(ByVal ShamsiDate As String, ByVal minYear As Integer)

            Dim StrShamsiDate() As String = ShamsiDate.Split("/")

            Dim mYear As UShort

            Dim Year As UShort

            Dim Month As UShort

            Dim Day As UShort

            Try

                mYear = minYear

            Catch ex As Exception

                Return String.Empty

            End Try

            If StrShamsiDate.Length <> 3 Then

                Return String.Empty

            End If

            Try

                Year = StrShamsiDate(0)

                Month = StrShamsiDate(1)

                Day = StrShamsiDate(2)

            Catch ex As Exception

                Return String.Empty

            End Try

            If Year < mYear Then

                Year += mYear

            End If

            If Month < 1 Or Month > 12 Then

                Return String.Empty

            End If

            If Day < 1 Or Day > 31 Then

                Return String.Empty

            End If

            StrShamsiDate(0) = Year.ToString()

            StrShamsiDate(1) = IIf(Month < 10, "0" & Month.ToString(), Month.ToString())

            StrShamsiDate(2) = IIf(Day < 10, "0" & Day.ToString(), Day.ToString())

            Return String.Join("/", StrShamsiDate)

        End Function

    End Class

End Namespace