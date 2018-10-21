Public Class dadMessageBox

#Region "Events"

    Sub New(ByVal text As String, Optional ByVal title As String = "هشدار")

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Title.Text = title
        Me.text.Text = text
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dadMessageBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        HideMinimize = True

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Me.DialogResult = Windows.Forms.DialogResult.Yes

    End Sub

    Private Sub btnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancle.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub


#End Region

#Region "Methods"

    Public Function ShowMessage() As System.Windows.Forms.DialogResult

        Return Me.ShowDialog()

    End Function

#End Region

End Class