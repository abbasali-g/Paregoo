Imports Lawyer.Common.VB.Login

Public Class frmShexes


    Private Sub frmShexes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not CurrentLogin.CurrentUser.IsAdmin Then
            Dim i As New InfoDadMessageBox(True, "فقط کاربر مدیر مجوز دسترسی دارد", "تنظیمات")
            i.ShowDialog()
            Exit Sub
        End If

        UcShaxes1.FillComboBoxs()
    End Sub
End Class