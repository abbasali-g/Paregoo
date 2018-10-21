Imports System.Text
Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.LawyerError

Public Class Map

    Delegate Sub ErrorMsg(ByVal msg As String)
    Event ShowMessage As ErrorMsg


    Public Sub BindMap(ByVal CityStreet As String)

        Try

            Dim str() As String = CityStreet.Split(New String() {";"c}, StringSplitOptions.RemoveEmptyEntries)

            If str Is Nothing OrElse str.Length = 0 Then

                RaiseEvent ShowMessage("اطلاعات نقشه وارد نشده است")

            Else

                Dim c As String = String.Empty

                If str.Length > 1 Then

                    c = str(1)

                End If

                BindMap(str(0), c)

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("BindMap, City", ex.ToString(), Me.ParentForm.Text)
            RaiseEvent ShowMessage("نقشه دریافت نشد")

        End Try

    End Sub

    Public Sub BindMap(ByVal street As String, ByVal City As String)

        Try

            Dim queryAddress As New StringBuilder()

            queryAddress.Append("http://maps.google.com/maps?q=")

            ' build street part of query string
            If street <> String.Empty Then
                '???????????????????????????????
                '' ''street = System.Web.HttpUtility.UrlEncode(street.Replace(" ", "+"))
                street = Uri.EscapeUriString(street.Replace(" ", "+"))
                queryAddress.Append(street + "," & "+")

            End If


            ' build city part of query string
            If City <> String.Empty Then
                '???????????????????????????????
                '' ''City = System.Web.HttpUtility.UrlEncode(City.Replace(" ", "+"))
                City = Uri.EscapeUriString(City.Replace(" ", "+"))
                queryAddress.Append(City + "," & "+")

            End If

            queryAddress.Append("&output=embed")

            WebBrowser1.Navigate(queryAddress.ToString())

        Catch ex As Exception
            ErrorManager.WriteMessage("BindMap, street", ex.ToString(), Me.ParentForm.Text)
            RaiseEvent ShowMessage("نقشه دریافت نشد")

        End Try

    End Sub

    Public Sub BindMapLatLong(ByVal Maplat As String, ByVal MapLong As String)


        If Maplat = String.Empty Or MapLong = String.Empty Then

            RaiseEvent ShowMessage("طول و عرض جغرافیایی را مشخص کنید.")

            Exit Sub

        End If

        Try

            Dim queryAddress As New StringBuilder()

            queryAddress.Append("http://maps.google.com/maps?q=")

            ' build latitude part of query string
            If Maplat <> String.Empty Then
                queryAddress.Append(Maplat + "%2C")
            End If

            ' build longitude part of query string
            If MapLong <> String.Empty Then

                queryAddress.Append(MapLong)

            End If

            queryAddress.Append("&output=embed")

            WebBrowser1.Navigate(queryAddress.ToString())

        Catch ex As Exception
            ErrorManager.WriteMessage("BindMapLatLong, street", ex.ToString(), Me.ParentForm.Text)
            RaiseEvent ShowMessage("نقشه دریافت نشد")

        End Try

    End Sub


    Public Sub doNavigate()

        Dim SettingCollection As New SettingCollection
        SettingCollection = SettingManager.GetSettingsByName("Traffic")

        Dim _url As String
        For i As Integer = 0 To SettingCollection.Count - 1
            If SettingCollection(i).settingName = "Tehran" Then
                _url = SettingCollection(i).settingValue
                WebBrowser1.Navigate(_url)
                Exit For
            End If
        Next


    End Sub



End Class
