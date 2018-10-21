Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace HS.General


    Public Class WebControl


        Public Shared Sub ResetElements(ByVal Obj As Object, Optional ByVal defaultIndex As Integer = 0)


            For Each ctl As Control In Obj.controls

                If TypeOf (ctl) Is TextBox Then

                    CType(ctl, TextBox).Text = String.Empty

                ElseIf TypeOf (ctl) Is DropDownList Then

                    Try
                        CType(ctl, DropDownList).SelectedIndex = defaultIndex
                    Catch ex As Exception
                    End Try

                ElseIf Not (ctl.Controls Is Nothing) Then

                    If ctl.Controls.Count > 0 Then
                        ResetElements(ctl, defaultIndex)
                    End If

                End If
            Next

        End Sub

        Public Shared Sub FillDropDown(ByVal drp As DropDownList, ByVal Dt As DataTable, ByVal DataTextField As String, ByVal DataValueField As String)


            drp.DataSource = Dt
            drp.DataTextField = DataTextField
            drp.DataValueField = DataValueField
            drp.DataBind()

        End Sub




    End Class


End Namespace