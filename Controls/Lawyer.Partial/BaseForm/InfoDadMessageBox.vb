Public Class InfoDadMessageBox

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub InfoDadMessageBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HideMinimize = True
    End Sub

    Sub New(ByVal IsError As Boolean, ByVal text As String, Optional ByVal title As String = "هشدار")

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Title.Text = title
        Me.txtContent.Text = text
        If IsError Then
            ' pnlError.BackgroundImage = Global.LawyerApp.My.Resources.erro18_1

        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class