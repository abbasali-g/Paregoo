Public Class SupportForm

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Private Sub CloseForm()

        Try

            Me.Close()

            Application.Exit()

            For Each Item As Process In Process.GetProcessesByName("LawyerMessages")

                Item.Kill()
            Next

        Catch ex As Exception

        End Try

    End Sub


    Private Sub tvDownload_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            System.Diagnostics.Process.Start("http://www.datatamin.com/download/tv.exe")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            System.Diagnostics.Process.Start("http://www.dadco.ir")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            System.Diagnostics.Process.Start("http://www.datatamin.com")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
