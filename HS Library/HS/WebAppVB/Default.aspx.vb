Imports HS.Dal
Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Management.Smo
Imports System.Globalization


Partial Public Class _Default
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim curDate As Date = Date.Today

        Dim jc As New System.Globalization.PersianCalendar()
        Dim sal As String = jc.GetYear(Date.Today).ToString()
        Dim Per As String = jc.GetYear(curDate) & CStr(jc.GetMonth(curDate)).PadLeft(2, "0") & CStr(jc.GetDayOfMonth(curDate)).PadLeft(2, "0"c)

        Dim d As New Date(1390, 9, 7, New PersianCalendar())


        Dim DTFI As DateTimeFormatInfo = New CultureInfo("en-US", False).DateTimeFormat
        curDate = Date.Now.ToString("s", DTFI)

        Dim evilString As String = "   "

        'Me.Label1.Text = Server.HtmlEncode(evilString)

        Dim srv As New Server(".\sqlexpress")

        Dim db As Database
        db = srv.Databases("bookmax")




        Dim _Error As Integer = 0

        For Each sp As StoredProcedure In db.StoredProcedures
            If sp.IsSystemObject = False AndAlso sp.IsEncrypted = True And sp.Name = "Get_BookDetails" Then

                sp.TextMode = True
                sp.IsEncrypted = False

                Try
                    sp.Alter()
                Catch ex As Exception
                    _Error += 1
                End Try

            End If
        Next


        'For Each vi As View In db.Views
        '    If vi.IsSystemObject = False AndAlso vi.IsEncrypted = False Then


        '        vi.TextMode = False
        '        vi.IsEncrypted = True

        '        Try
        '            vi.Alter()
        '        Catch ex As Exception
        '            _Error += 1
        '        End Try
        '    End If
        'Next


        'For Each udf As UserDefinedFunction In db.UserDefinedFunctions
        '    If udf.IsSystemObject = False AndAlso udf.IsEncrypted = False Then


        '        udf.TextMode = False
        '        udf.IsEncrypted = True

        '        Try
        '            udf.Alter()
        '        Catch ex As Exception
        '            _Error += 1
        '        End Try


        '    End If
        'Next






        ' srv.Databases.Item("bookmax").SetOffline()
        'srv.KillDatabase("bookmax")




    End Sub

End Class