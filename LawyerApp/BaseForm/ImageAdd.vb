Imports Lawyer.Common.VB

Public Class ImageAdd

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ''LawyerError.ErrorManager.WriteMessage(Me.Text, LawyerError.ActionType.ثبت, "jjhjadgfjasdggfa jhjsgfgdhgfhdsghf")
        'Dim l As LawyerError.ErrorMsg = LawyerError.ErrorManager.ReadMessage()
        Dim pic As New BaseForm.Image

        pic.imagePath = txtPath.Text

        pic.imageID = Guid.NewGuid().ToString()

        pic.imageExtension = System.IO.Path.GetExtension(pic.imagePath)

        pic.imageUpdateDate = txtDate.Text

        pic.imageName = System.IO.Path.GetFileNameWithoutExtension(pic.imagePath)

        If Not BaseForm.ImageManager.AddImage(pic) Then

            MessageBox.Show("خطا در ثبت")

        End If

    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Try

                txtPath.Text = OpenFileDialog1.FileName

            Catch Ex As Exception
            
            End Try

        End If


    End Sub
End Class