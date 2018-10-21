
Namespace HS.Data.DataTables

    Public Class Filter


        Public Shared Function FilterDataTable(ByVal Dt As DataTable, ByVal Expression As String) As DataTable

            Dim NewDt As New DataTable

            If Dt.Rows.Count > 0 Then

                Dim _DataRows() As DataRow
                _DataRows = Dt.Select(Expression)

                If _DataRows.Length > 0 Then
                    NewDt = _DataRows.CopyToDataTable
                Else
                    NewDt = Nothing
                End If

            Else

                Return Dt

            End If

            Return NewDt

        End Function


    End Class


End Namespace
