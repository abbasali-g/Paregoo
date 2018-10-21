Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Shaxes
Imports Lawyer.Common.VB.LawyerError
Imports Shetab.LicenseControl.Helper

Public Class frmOfficeFinanceAdd

    Private Const C_LicenceID As UInteger = LawyerSetting.LicenceId

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub OfficeFinanceAdd1_ShowMessageBox(ByVal text As String, ByVal title As String) Handles OfficeFinanceAdd1.ShowMessageBox

        Dim f As New dadMessageBox(text, title)

        If f.ShowMessage() = Windows.Forms.DialogResult.Yes Then

            OfficeFinanceAdd1.YesClicked = True

        Else

            OfficeFinanceAdd1.YesClicked = False

        End If

    End Sub

    Private Sub OfficeFinanceAdd1_ShowReport(ByVal dt As System.Data.DataTable, ByVal title As String) Handles OfficeFinanceAdd1.ShowReport

        Try

            Dim r As New ReportsFix()

            r.ReportDataTable(ReportsFix.ReportType.ClericalSpending, title) = dt

            r.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub OfficeFinanceAdd1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OfficeFinanceAdd1.SizeChanged

        Me.Size = New Size(Me.Width, Me.OfficeFinanceAdd1.Size.Height + 50)

    End Sub

End Class