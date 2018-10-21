Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Timing
Imports myReport = HS.Report_Rdlc
Imports Microsoft.Reporting.WinForms

Public Class NewReport

    Public Sub ShowReport(ByVal _Dt As DataTable, ByVal _ReportDataSources As String, ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)

        Try

            If _Dt IsNot Nothing Then

                Me.ReportViewer1.Reset()

                Me.ReportViewer1.LocalReport.DataSources.Add(myReport.ReportDataSource.GetRds(_Dt.Copy(), _ReportDataSources))

                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = _ReportRdlc

                If Params IsNot Nothing Then

                    ReportViewer1.LocalReport.SetParameters(Params)

                End If

                Me.ReportViewer1.RefreshReport()

            Else
                lblMessage.Text = "خطا در دریافت اطلاعات"
            End If

        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("ShowReport()", ex.ToString, Me.Text)
        End Try
        Me.Show()

    End Sub

    Private Sub ShowReport(ByVal _Collection As ICollection, ByVal _ReportDataSources As String, ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)

        Try

            If _Collection IsNot Nothing Then

                Me.ReportViewer1.Reset()
                Me.ReportViewer1.LocalReport.DataSources.Add(myReport.ReportDataSource.GetRds(_Collection, _ReportDataSources))
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = _ReportRdlc
                If Params IsNot Nothing Then
                    ReportViewer1.LocalReport.SetParameters(Params)
                End If
                Me.ReportViewer1.RefreshReport()

            Else
                lblMessage.Text = "خطا در دریافت اطلاعات"
            End If

        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("ShowReport()", ex.ToString, Me.Text)
        End Try


    End Sub


End Class