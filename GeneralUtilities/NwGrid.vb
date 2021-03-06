Imports Microsoft.VisualBasic
Imports system.Web.UI.WebControls
Imports system.Web.UI
Imports System.Web
Imports System.Data
Imports System.Web.SessionState

Public Class NwGrid

    Private conStr As String = String.Empty

    Private Const c_MouseOverBackColor As String = "#549C00"
    Private Const c_MouseOverForeColor As String = "#ffffff"
    Private Const c_MouseOutForeColor As String = "#000000"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <param name="DataGrid"></param>
    ''' <param name="AddOnclickAttribute"></param>
    ''' <param name="DeActiveCellNumbers">the cells which we do not add onclick attribute</param>
    ''' <param name="MouseOverbackColor"></param>
    ''' <param name="MouseOverForeColor"></param>
    ''' <remarks></remarks>
    Private Sub BaseSelectGridRow( _
        ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, _
        ByVal DataGrid As DataGrid, ByVal AddOnclickAttribute As Boolean, ByVal DeActiveCellNumbers As Integer(), ByVal MouseOverbackColor As String, _
        ByVal MouseOverForeColor As String, ByVal MouseOutForeColor As String)

        If MouseOverbackColor = Nothing Then MouseOverbackColor = c_MouseOverBackColor
        If MouseOverForeColor = Nothing Then MouseOverForeColor = c_MouseOverForeColor
        If MouseOutForeColor = Nothing Then MouseOutForeColor = c_MouseOutForeColor

        If e.Item.ItemType = ListItemType.Item Or _
                    e.Item.ItemType = ListItemType.AlternatingItem Or _
                    e.Item.ItemType = ListItemType.SelectedItem Then

            e.Item.Attributes.Add("onmouseover", String.Format("Gridcolor=this.style.backgroundColor;this.style.backgroundColor='{0}';this.style.color='{1}';this.style.cursor='hand'", MouseOverbackColor, MouseOverForeColor))

            e.Item.Attributes.Add("onmouseout", String.Format("this.style.backgroundColor=Gridcolor;this.style.color='{0}';this.style.cursor='default'", MouseOutForeColor))

            If AddOnclickAttribute Then

                Dim Click As String

                Click = String.Format("__doPostBack('{0}$ctl", DataGrid.UniqueID) '$ctl

                If DataGrid.AllowPaging = True Then

                    Click += IIf((e.Item.ItemIndex + 3) < 10, "0" + (e.Item.ItemIndex + 3).ToString, (e.Item.ItemIndex + 3).ToString)

                Else

                    Click += IIf((e.Item.ItemIndex + 3) < 10, "0" + (e.Item.ItemIndex + 2).ToString, (e.Item.ItemIndex + 2).ToString)

                End If

                Click += "$ctl00','')"

                If DeActiveCellNumbers Is Nothing Then

                    e.Item.Attributes.Add("onclick", Click)

                Else

                    For j As Integer = 0 To e.Item.Cells.Count - 1

                        If Array.BinarySearch(DeActiveCellNumbers, j) < 0 Then

                            e.Item.Cells(j).Attributes.Add("onclick", Click)
                        Else
                            e.Item.Cells(j).Attributes.Remove("onclick")

                        End If

                    Next

                End If

            End If

        End If

    End Sub


    Public Overloads Sub SelectGridRow( _
      ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, _
      ByVal DataGrid As DataGrid)

        BaseSelectGridRow(e, DataGrid, True, Nothing, Nothing, Nothing, Nothing)

    End Sub

    Public Overloads Sub SelectGridRow( _
           ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, _
           ByVal DataGrid As DataGrid, ByVal MouseOverbackColor As String, _
           ByVal MouseOverForeColor As String, ByVal MouseOutForeColor As String)

        BaseSelectGridRow(e, DataGrid, True, Nothing, MouseOverbackColor, MouseOverForeColor, MouseOutForeColor)

    End Sub

    Public Overloads Sub SelectGridRow( _
      ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, _
      ByVal DataGrid As DataGrid, ByVal DeActiveCellNumbers As Integer())

        BaseSelectGridRow(e, DataGrid, True, DeActiveCellNumbers, Nothing, Nothing, Nothing)

    End Sub

    Public Overloads Sub SelectGridRow( _
         ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, _
         ByVal DataGrid As DataGrid, ByVal DeActiveCellNumbers As Integer(), ByVal MouseOverbackColor As String, _
         ByVal MouseOverForeColor As String, ByVal MouseOutForeColor As String)

        BaseSelectGridRow(e, DataGrid, True, DeActiveCellNumbers, MouseOverbackColor, MouseOverForeColor, MouseOutForeColor)

    End Sub

    Public Overloads Sub SelectGridRow( _
       ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, _
       ByVal DataGrid As DataGrid, ByVal AddOnclickAttribute As Boolean)

        BaseSelectGridRow(e, DataGrid, AddOnclickAttribute, Nothing, Nothing, Nothing, Nothing)

    End Sub

    Public Overloads Sub SelectGridRow( _
       ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, _
       ByVal DataGrid As DataGrid, ByVal AddOnclickAttribute As Boolean, ByVal MouseOverbackColor As String, _
       ByVal MouseOverForeColor As String, ByVal MouseOutForeColor As String)

        BaseSelectGridRow(e, DataGrid, AddOnclickAttribute, Nothing, MouseOverbackColor, MouseOverForeColor, MouseOutForeColor)

    End Sub

#Region "Shared Properties"

    Public Shared ReadOnly Property Current() As NwGrid

        Get

            Return New NwGrid()

        End Get

    End Property

#End Region
#Region "Shared Methods"

    Public Shared Sub ReverseDataGridShamsiDates(ByVal DataGrid As System.Web.UI.WebControls.DataGrid)

        Try

            For i As Integer = 0 To DataGrid.Items.Count - 1

                Dim e As New System.Web.UI.WebControls.DataGridItemEventArgs(DataGrid.Items(i))

                ReverseDataGridShamsiDates(DataGrid, e)

            Next

        Catch ex As Exception

            Throw New Exception(ex.Message, ex.InnerException)

        End Try


    End Sub

    Public Shared Sub ReverseGridViewShamsiDates(ByVal GridView As System.Web.UI.WebControls.GridView)

        Try

            For i As Integer = 0 To GridView.Rows.Count - 1

                Dim e As New System.Web.UI.WebControls.GridViewRowEventArgs(GridView.Rows(i))

                ReverseGridViewShamsiDates(GridView, e)

            Next

        Catch ex As Exception

            Throw New Exception(ex.Message, ex.InnerException)

        End Try


    End Sub

    Public Shared Sub ReverseDataGridShamsiDates(ByVal DataGrid As System.Web.UI.WebControls.DataGrid, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

        Dim CellContent As String = String.Empty

        With e.Item

            If .ItemType = ListItemType.Item Or .ItemType = ListItemType.SelectedItem Or .ItemType = ListItemType.AlternatingItem Or .ItemType = ListItemType.EditItem Then

                For c As Integer = 0 To .Cells.Count - 1

                    Try

                        If .Cells(c).Controls.Count = 0 Then

                            CellContent = .Cells(c).Text.Trim.ToString

                            If DateConvertor.IsShamsiDate(CellContent) Then

                                .Cells(c).Text = DateConvertor.ReverseShamsiDate(CellContent)

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                Next

            End If

        End With

    End Sub

    Public Shared Sub ReverseGridViewShamsiDates(ByVal GridView As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        Dim CellContent As String = String.Empty

        With e.Row

            If .RowType = DataControlRowType.DataRow Then

                If .RowState = DataControlRowState.Normal Or .RowState = DataControlRowState.Alternate Or .RowState = DataControlRowState.Selected Then

                    For c As Integer = 0 To .Cells.Count - 1

                        Try

                            If .Cells(c).Controls.Count = 0 Then

                                CellContent = .Cells(c).Text.Trim.ToString

                                If DateConvertor.IsShamsiDate(CellContent) Then

                                    .Cells(c).Text = DateConvertor.ReverseShamsiDate(CellContent)

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                End If

            End If

        End With

    End Sub

#End Region

   
End Class
