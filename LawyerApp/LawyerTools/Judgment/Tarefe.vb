Public Class Tarefe

    Private Sub Tarefe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String = System.IO.Directory.GetCurrentDirectory() + "\tarefe.pdf"

        WebBrowser1.Navigate(New Uri(path).AbsolutePath)

    End Sub
End Class