Imports Microsoft.Reporting.WinForms

Namespace HS.Report_Rdlc

    Public Class ReportDataSource

        Shared Function GetRds(ByVal _Dt As DataTable, ByVal _ReportDataSources As String) As Microsoft.Reporting.WinForms.ReportDataSource


            Try

                Dim Rds As New Microsoft.Reporting.WinForms.ReportDataSource

                If _Dt IsNot Nothing Then


                    _Dt.TableName = "Sarandy"
                    Dim _DataSet As New DataSet()
                    _DataSet.Tables.Add(_Dt)

                    Dim BindingSource As New Windows.Forms.BindingSource
                    BindingSource.DataSource = _DataSet
                    BindingSource.DataMember = _Dt.TableName


                    Rds.Value = BindingSource
                    Rds.Name = _ReportDataSources 'A data source instance has not been supplied for the data source
                    'sarandy: each report have a ReportDataSources in disgn time that rds set to it.


                    'ReportViewer.Reset()
                    'ReportViewer.LocalReport.DataSources.Add(Rds)
                    'ReportViewer.LocalReport.ReportEmbeddedResource = _ReportRdlc
                    'If Params IsNot Nothing Then
                    '    ReportViewer.LocalReport.SetParameters(Params)
                    'End If
                    'ReportViewer.RefreshReport()


                Else
                    Return Nothing
                End If

                Return Rds

            Catch ex As Exception
                Throw ex
            End Try




        End Function

        Shared Function GetRds(ByVal Collection As ICollection, ByVal _ReportDataSources As String) As Microsoft.Reporting.WinForms.ReportDataSource


            Try

                Dim Rds As New Microsoft.Reporting.WinForms.ReportDataSource

                '  If Collection. Then

                Dim BindingSource As New Windows.Forms.BindingSource
                BindingSource.DataSource = Collection
                'BindingSource.DataMember = _Dt.TableName

                Rds.Value = BindingSource
                Rds.Name = _ReportDataSources 'A data source instance has not been supplied for the data source
                'sarandy: each report have a ReportDataSources in disgn time that rds set to it.


                'ReportViewer.Reset()
                'ReportViewer.LocalReport.DataSources.Add(Rds)
                'ReportViewer.LocalReport.ReportEmbeddedResource = _ReportRdlc
                'If Params IsNot Nothing Then
                '    ReportViewer.LocalReport.SetParameters(Params)
                'End If
                'ReportViewer.RefreshReport()


                '  Else
                'Return Nothing
                ' End If

                Return Rds

            Catch ex As Exception
                Throw ex
            End Try




        End Function

    End Class



End Namespace