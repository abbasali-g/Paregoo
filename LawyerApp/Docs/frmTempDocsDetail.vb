Public Class frmTempDocsDetail

    Private Sub UcAddTempDocsDetail1_ShowMessageBox(ByVal text As String, ByVal title As String) Handles UcAddTempDocsDetail1.ShowMessageBox

        Dim f As New dadMessageBox(text, title)

        If f.ShowMessage() = Windows.Forms.DialogResult.Yes Then

            UcAddTempDocsDetail1.YesClicked = True

        Else

            UcAddTempDocsDetail1.YesClicked = False

        End If
    End Sub

  
End Class