Public Class frmSms

    Public Sub New(ByVal fileCaseID As String, ByVal timeID As String, ByVal dt As DataTable, ByVal smsText As String)

        ' This call is required by the designer.
        InitializeComponent()

        UcSms1.ucSmsInit(fileCaseID, timeID, dt, smsText)
        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class