Imports System.Windows.Forms

Namespace Common

    Public Class ExcelManager

#Region "Methods"

        Public Shared Function CreateExcel(ByVal filePath As String, ByVal datasource As DataTable, ByVal show As Boolean) As Boolean

            If filePath = String.Empty OrElse datasource Is Nothing OrElse ((datasource.Columns.Count = 0) OrElse (datasource.Rows.Count = 0)) Then

                Exit Function

            End If

            Dim dt As New DataTable

            For i As Integer = 0 To datasource.Columns.Count - 1

                dt.Columns.Add(datasource.Columns(i).Caption, Type.GetType("System.String"))

            Next

            Dim dr1 As DataRow

            For i As Integer = 0 To datasource.Rows.Count - 1

                dr1 = dt.NewRow

                For j As Integer = 0 To datasource.Columns.Count - 1

                    dr1(j) = datasource.Rows(i).Item(j).ToString()

                Next

                dt.Rows.Add(dr1)

            Next

            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass

            Dim wBook As Microsoft.Office.Interop.Excel.Workbook

            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            wBook = excel.Workbooks.Add()

            wSheet = wBook.ActiveSheet()

            Dim dc As System.Data.DataColumn

            Dim dr As System.Data.DataRow

            Dim colIndex As Integer = 0

            Dim rowIndex As Integer = 0

            For Each dc In dt.Columns

                colIndex = colIndex + 1

                excel.Cells(1, colIndex) = dc.ColumnName

            Next

            For Each dr In dt.Rows

                rowIndex = rowIndex + 1

                colIndex = 0

                For Each dc In dt.Columns

                    colIndex = colIndex + 1

                    excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)

                Next

            Next

            wSheet.Columns.AutoFit()

            Try
                If System.IO.File.Exists(filePath) Then

                    System.IO.File.Delete(filePath)

                End If

                Dim missing As Object = System.Reflection.Missing.Value

                'excel 97-2003
                If System.IO.Path.GetExtension(filePath) = ".xls" Then

                    wBook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, missing, missing, False, False, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing)

                Else

                    wBook.SaveAs(filePath)

                End If

                If show Then

                    excel.Workbooks.Open(filePath)

                    excel.Visible = True

                Else

                    excel.Quit()

                End If

            Catch ex As Exception

                Return False

            End Try

            Return True

        End Function

        Public Shared Function CreateExcel(ByVal filePath As String, ByVal datasource As DataGridView, ByVal show As Boolean) As Boolean

            If filePath = String.Empty OrElse datasource Is Nothing OrElse ((datasource.Columns.Count = 0) OrElse (datasource.Rows.Count = 0)) Then

                Exit Function

            End If

            Dim dt As New DataTable

            'add column to that table
            Dim clmIndex As Integer = 0

            Dim sourceColumnCount As Integer = datasource.ColumnCount

            For i As Integer = 0 To datasource.ColumnCount - 1
                If datasource.Columns(i).Visible Then
                    dt.Columns.Add(datasource.Columns(i).HeaderText)
                    clmIndex += 1

                End If

            Next

            Dim dd As Integer = dt.Columns.Count
            'add rows to the table

            Dim dr1 As DataRow
            For i As Integer = 0 To datasource.RowCount - 1
                clmIndex = 0
                dr1 = dt.NewRow
                For j As Integer = 0 To datasource.Columns.Count - 1
                    If datasource.Columns(j).Visible Then
                        dr1(clmIndex) = datasource.Rows(i).Cells(j).Value
                        clmIndex += 1
                    End If

                Next
                dt.Rows.Add(dr1)
            Next
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass

            Dim wBook As Microsoft.Office.Interop.Excel.Workbook

            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            wBook = excel.Workbooks.Add()

            wSheet = wBook.ActiveSheet()

            Dim dc As System.Data.DataColumn

            Dim dr As System.Data.DataRow

            Dim colIndex As Integer = 0

            Dim rowIndex As Integer = 0

            For Each dc In dt.Columns

                colIndex = colIndex + 1

                excel.Cells(1, colIndex) = dc.ColumnName

            Next

            For Each dr In dt.Rows

                rowIndex = rowIndex + 1

                colIndex = 0

                For Each dc In dt.Columns

                    colIndex = colIndex + 1

                    excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)

                Next

            Next

            wSheet.Columns.AutoFit()


            Try
                If System.IO.File.Exists(filePath) Then

                    System.IO.File.Delete(filePath)

                End If

                Dim missing As Object = System.Reflection.Missing.Value

                'excel 97-2003
                If System.IO.Path.GetExtension(filePath) = ".xls" Then

                    wBook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, missing, missing, False, False, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing)

                Else

                    wBook.SaveAs(filePath)

                End If

                If show Then

                    excel.Workbooks.Open(filePath)

                    excel.Visible = True

                Else

                    excel.Quit()

                End If

            Catch ex As Exception

                Return False

            End Try

            Return True


        End Function

#End Region

    End Class

End Namespace

