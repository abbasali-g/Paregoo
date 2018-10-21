Imports System.Globalization

Namespace HS.Date.PersiaCal

    Public Class PersiaDate



        Public Shared Function GetShamsiString_6Digit() As String

            Dim pc As New PersianCalendar

            Return pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString().PadLeft(2, "0") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, "0")

        End Function

        Public Shared Function GetShamsiString_6Digit(ByVal _Date As Date) As String

            Dim pc As New PersianCalendar

            Return pc.GetYear(_Date).ToString() + "/" + pc.GetMonth(_Date).ToString().PadLeft(2, "0") + "/" + pc.GetDayOfMonth(_Date).ToString().PadLeft(2, "0")

        End Function

        Public Shared Function Shamsi2MiladiDate(ByVal Sal As Integer, ByVal Mah As Integer, ByVal Ruz As Integer) As Date

            Try

                Dim pc As New PersianCalendar()
                Dim dt As DateTime = pc.ToDateTime(Sal, Mah, Ruz, 0, 0, 0, 0)

                Return dt
            Catch ex As Exception
                Return Nothing
            End Try


        End Function


    End Class




End Namespace
