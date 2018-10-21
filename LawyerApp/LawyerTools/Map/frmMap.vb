Imports Lawyer.Common.VB.LawyerError
Imports Shetab.LicenseControl.Helper

Public Class frmMap

    Private Const C_LicenceID As UInteger = LawyerSetting.LicenceId

    Private Sub frmMap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblMessage.Text = String.Empty

        ToolTip1.SetToolTip(Me.btnTraffic, "پس از مشاهده نقشه تهران ، برای مشاهده ترافیک شهری لازم است نقشه را کمی حرکت «Pan» نمایید")
        ToolTip1.SetToolTip(Me.txtCity, "نام شهر را به انگلسی وارد نمایید")
        ToolTip1.SetToolTip(btnSearch, "جستجو")
        ToolTip1.SetToolTip(btnHelp, "برای مشاهده نقشه بایستی از اینترنت استفاده نمایید")



    End Sub

    Private Sub rdbCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCity.CheckedChanged

        lblMessage.Text = String.Empty

        ' check exe file --


        If rdbCity.Checked Then

            ToolTip1.SetToolTip(Me.txtCity, "نام شهر را به انگلیسی وارد نمایید.")

            lblCity.Text = "شهر :"
            lblStreet.Text = "خیابان :"

        Else

            ToolTip1.SetToolTip(Me.txtCity, "")
            lblCity.Text = "عرض جغرافیایی :"
            lblStreet.Text = "طول جغرافیایی :"

        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try

            lblMessage.Text = String.Empty

            If rdbCity.Checked Then
                Map1.BindMap(txtLat.Text, txtCity.Text)
            Else
                Map1.BindMapLatLong(txtCity.Text, txtLat.Text)
            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در جستجوی محل"
            ErrorManager.WriteMessage("btnSearch_Click()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub Map1_ShowMessage(ByVal msg As String) Handles Map1.ShowMessage

        Me.lblMessage.Text = msg

    End Sub

    Private Sub btnTraffic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraffic.Click
        ' check exe file --
        Dim random As New Random()

        Dim day As Integer = random.Next(0, 6)


        Map1.doNavigate()

    End Sub

End Class