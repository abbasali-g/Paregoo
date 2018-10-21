Imports System.Windows.Forms

Public Class ucDesktop

   
    Delegate Sub ShowForm(ByVal IsUpdate As Boolean)
    Event ShowRelatedForm As ShowForm

    Private Sub picSms_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSms.MouseHover
        picSms.Image = Global.Lawyer.Partial.My.Resources.sms_h
    End Sub

    Private Sub picSms_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSms.MouseLeave
        picSms.Image = Global.Lawyer.Partial.My.Resources.sms
    End Sub

    Private Sub picSms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSms.Click, picTalk.Click, picTabadol.Click, picSearchVakil.Click

        '' ''Try

        '' ''    If partialLawyerPath <> String.Empty AndAlso File.Exists(partialLawyerPath) Then

        '' ''        Dim picName As PictureBox = CType(sender, PictureBox)


        '' ''        Process.Start(partialLawyerPath, String.Format("{0} ", picName.Name))

        '' ''    Else

        '' ''        Dim iMsg As New InfoDadMessageBox(False, "به زودی راه اندازی می شود.", "نسخه جدید")

        '' ''        iMsg.ShowDialog()

        '' ''    End If


        '' ''Catch ex As Exception

        '' ''End Try
    End Sub

    Private Sub picBackUp_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBackUp.MouseHover

        picBackUp.Image = Global.Lawyer.Partial.My.Resources.backup64_h

    End Sub

    Private Sub picBackUp_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBackUp.MouseLeave

        picBackUp.Image = Global.Lawyer.Partial.My.Resources.backup64

    End Sub

    Private Sub picBackUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBackUp.Click

        RaiseEvent ShowRelatedForm(False)

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        RaiseEvent ShowRelatedForm(True)

    End Sub

    Private Sub btnUpdate_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.MouseHover

        btnUpdate.Image = Global.Lawyer.Partial.My.Resources.update4_h

    End Sub

    Private Sub btnUpdate_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.MouseLeave

        btnUpdate.Image = Global.Lawyer.Partial.My.Resources.update4

    End Sub

    Private Sub picTalk_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTalk.MouseHover
        picTalk.Image = Global.Lawyer.Partial.My.Resources.talk_h
    End Sub

    Private Sub picTalk_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTalk.MouseLeave
        picTalk.Image = Global.Lawyer.Partial.My.Resources.talk
    End Sub

    Private Sub picTabadol_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTabadol.MouseHover
        picTabadol.Image = Global.Lawyer.Partial.My.Resources.sendFileCase_h
    End Sub

    Private Sub picTabadol_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTabadol.MouseLeave
        picTabadol.Image = Global.Lawyer.Partial.My.Resources.sendFileCase
    End Sub

    Private Sub picSearchVakil_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSearchVakil.MouseHover
        picSearchVakil.Image = Global.Lawyer.Partial.My.Resources.vakilSearch_h
    End Sub

    Private Sub picSearchVakil_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSearchVakil.MouseLeave
        picSearchVakil.Image = Global.Lawyer.Partial.My.Resources.vakilSearch
    End Sub

    Private Sub ucDesktop_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ToolTip1.SetToolTip(picSms, "سرویس ارسال پیامک")

        Me.ToolTip1.SetToolTip(picTalk, "ارسال/دریافت پرونده از وکلای همکار")

        Me.ToolTip1.SetToolTip(picTabadol, "مکاتبه با وکلای همکار")

        Me.ToolTip1.SetToolTip(picSearchVakil, "جستجوی وکیل با مشاهده موقعیت نقشه")

    End Sub
End Class
