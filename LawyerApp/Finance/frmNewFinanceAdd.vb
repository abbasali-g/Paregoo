Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Shaxes
Imports Lawyer.Common.VB.LawyerError
Imports Shetab.LicenseControl.Helper
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.Common

Public Class frmNewFinanceAdd



#Region "Design"

    Dim IsSearchMode As Boolean = True

    Private Sub setLinkedSearch()

        lblMessage.Text = String.Empty

        Try
            pnlAdd.Visible = IsSearchMode

            If IsSearchMode Then

                lnkChangeDesign.Text = "هزینه های ثبت شده"

                lnkChangeDesign.Location = New Point(10, 1)

                pnlSearch.Height = 0

                pnlAdd.Height = NewFinanceAdd1.Height

                FlowLayoutPanel1.Width = pnlAdd.Width

            Else

                lnkChangeDesign.Text = "ثبت هزینه"

                lnkChangeDesign.Location = New Point(36, 1)

                pnlAdd.Height = 0

                pnlSearch.Height = 550

                Search()

            End If

            pnlSearch.Visible = Not IsSearchMode

            IsSearchMode = Not IsSearchMode

            Me.Height = FlowLayoutPanel1.Height + 50

            Me.Width = FlowLayoutPanel1.Width + 12

            pnlTitle.Width = FlowLayoutPanel1.Width

            lblfrmTitle.Location = New Point(pnlTitle.Width - 100, 6)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub lnkChangeDesign_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkChangeDesign.LinkClicked

        setLinkedSearch()

    End Sub

    Private Sub frmNewTimingSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ToolTip1.SetToolTip(btnExcel, "ارسال به اکسل")

        ToolTip1.SetToolTip(btnRefresh, "جستجو")

        ToolTip1.SetToolTip(btnPrint, "چاپ")

        setLinkedSearch()

    End Sub


#End Region

#Region "NewFinanceAdd"

    Private Sub NewFinanceAdd1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewFinanceAdd1.SizeChanged

        pnlAdd.Height = NewFinanceAdd1.Height

        FlowLayoutPanel1.Width = pnlAdd.Width

        Me.Height = FlowLayoutPanel1.Height + 50

        Me.Width = FlowLayoutPanel1.Width + 12

        pnlTitle.Width = FlowLayoutPanel1.Width

    End Sub

    Private Sub FinanceAdd1_ShowMessageBox(ByVal text As String, ByVal title As String) Handles NewFinanceAdd1.ShowMessageBox

        Dim f As New dadMessageBox(text, title)

        If f.ShowMessage() = Windows.Forms.DialogResult.Yes Then

            NewFinanceAdd1.YesClicked = True

        Else

            NewFinanceAdd1.YesClicked = False

        End If

    End Sub


#End Region

#Region "DataGridview"

    Dim dtResult As New DataTable

    Private Sub CreateTable()


        If dtResult.Columns.Count <= 0 Then

            dtResult.Columns.Add("AmountDaryafti", System.Type.GetType("System.Double"))
            dtResult.Columns.Add("AmountHazine", System.Type.GetType("System.Double"))
            dtResult.Columns.Add("financeChequeSerial")
            dtResult.Columns.Add("financeDesc")
            dtResult.Columns.Add("financeID")
            dtResult.Columns.Add("financePaymentDate")
            dtResult.Columns.Add("financePaymentTime")
            dtResult.Columns.Add("financeType")
            dtResult.Columns.Add("Shobe")

        End If


    End Sub

    Public Sub Search()

        Try


            DataGridView1.ColumnHeadersVisible = True


            lblMessage.Text = String.Empty

            BindFinance()

            If DataGridView1.Rows.Count = 0 Then

                lblMessage.Text = "موردی یافت نشد."

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در انجام عملیات."

            ErrorManager.WriteMessage("Search", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub BindFinance()

        DataGridView1.AutoGenerateColumns = False

        Dim b As New BindingSource

        Dim list As FinanceSearchCollection = FinanceManager.SearchFinanceByfileCaseId(_filecaseId)

        dtResult.Rows.Clear()

        If list IsNot Nothing Then

            For Each Item As Lawyer.Common.VB.Shaxes.FinanceSearch In list

                Dim dtNewRow As DataRow
                dtNewRow = dtResult.NewRow()
                dtNewRow.Item("AmountDaryafti") = Item.AmountDaryafti
                dtNewRow.Item("AmountHazine") = Item.AmountHazine
                dtNewRow.Item("financeChequeSerial") = Item.financeChequeSerial
                dtNewRow.Item("financeDesc") = Item.financeDesc
                dtNewRow.Item("financeID") = Item.financeID
                dtNewRow.Item("financePaymentDate") = Item.financePaymentDate
                dtNewRow.Item("financePaymentTime") = Item.financePaymentTime
                dtNewRow.Item("financeType") = Item.financeType
                dtNewRow.Item("Shobe") = Item.Shobe

                dtResult.Rows.Add(dtNewRow)

            Next

            b.DataSource = dtResult

            DataGridView1.DataSource = b

        Else

            DataGridView1.DataSource = Nothing

        End If

        SetAmounts()
    End Sub

    Private Sub SetAmounts()

        txtBedehkar.Amount = 0

        txtDaryafti.Amount = 0

        txtMande.Amount = 0

        Try

            If DataGridView1.Rows.Count > 0 Then


                Dim d As Double = 0

                Dim b As Double = 0

                For index As Integer = 0 To DataGridView1.Rows.Count - 1

                    d += CDbl(DataGridView1.Rows(index).Cells("clmnAmountDar").Value)

                    b += CDbl(DataGridView1.Rows(index).Cells("clmfinanceAmount").Value)

                Next

                txtBedehkar.Amount = b

                txtDaryafti.Amount = d

                txtMande.Amount = b - d

                If b <> txtBedehkar.Amount Then txtBedehkar.Amount = b

                If d <> txtDaryafti.Amount Then txtDaryafti.Amount = d

                If (b - d) <> txtMande.Amount Then txtMande.Amount = b - d

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            lblMessage.Text = String.Empty

            Dim number As FileCaseNumber = FileCaseManager.GetFileCaseNumbers(_filecaseId)

            Dim title As String = String.Empty

            If number IsNot Nothing Then

                title = "شماره سیستمی پرونده : " & number.fileCaseNumberInSystem & vbCrLf

                title &= "شماره پرونده در مرجع قضایی : " & number.fileCaseNumberInCourt & "/" & number.fileCaseNumberInBranch

            Else
                title = String.Empty

            End If


            Dim b As BindingSource = DataGridView1.DataSource

            Dim c As DataTable = b.DataSource

            Dim r As New ReportsFix()

            r.ReportDataTable(ReportsFix.ReportType.HazineOfOneCase, title) = c

            r.Show()


        Catch ex As Exception

            lblMessage.Text = "خطا در چاپ"

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        Search()

    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

        Try
            lblMessage.Text = String.Empty

            If DataGridView1.Rows.Count = 0 Then

                lblMessage.Text = "رکوردی برای تولید فایل اکسل وجود ندارد"

                Exit Sub

            End If

            SaveFileDialog1.Filter = "Excel workbook|*.xlsx | Excel 97-2003 workbook|*.xls"

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

                ExcelManager.CreateExcel(SaveFileDialog1.FileName, DataGridView1, True)

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در ایجاد فایل اکسل"

            ErrorManager.WriteMessage("picCreateExcel_Click", ex.ToString(), Me.Text)

        End Try

    End Sub

    Dim rowIndex As Integer = -1

    Private Sub ToolStripMenuItemEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemEdit.Click

        Dim f As New FinanceView(DataGridView1.Rows(rowIndex).Cells("clmfinanceID").Value.ToString(), FinanceEnums.FinanceAddMode.ویرایش)

        f.ShowDialog()

    End Sub

    Private Sub ToolStripMenuItemDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDel.Click

        Try

            If rowIndex <> -1 Then

                Dim msgbox As New dadMessageBox(Lawyer.Common.VB.DadMessages.Messages.ConfirmDelete, "حذف مالی")

                If msgbox.ShowMessage() = Windows.Forms.DialogResult.Yes Then

                    If FinanceManager.DeleteFinanceByID(DataGridView1.Rows(rowIndex).Cells("clmfinanceID").Value.ToString()) Then

                        DataGridView1.Rows.RemoveAt(rowIndex)

                        SetAmounts()

                    Else
                        lblMessage.Text = "خطا در حذف"

                    End If

                End If


            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در حذف"

            ErrorManager.WriteMessage("ToolStripMenuItemDel_Click", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub DataGridView1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseUp

        lblMessage.Text = String.Empty

        If e.Button = Windows.Forms.MouseButtons.Right AndAlso DataGridView1.SelectedRows.Count > 0 Then

            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)

            If hti.Type = DataGridViewHitTestType.Cell Then

                For index As Integer = 0 To DataGridView1.Rows.Count - 1

                    DataGridView1.Rows(index).Selected = False
                Next

                ContextMenuStrip1.Visible = True

                rowIndex = hti.RowIndex

                DataGridView1.Rows(rowIndex).Selected = True

                DataGridView1.ContextMenuStrip = ContextMenuStrip1

                DataGridView1.ContextMenuStrip.Show(DataGridView1, New Point(e.X, e.Y))

            Else

                ContextMenuStrip1.Visible = False

                DataGridView1.ContextMenuStrip = Nothing

            End If

        Else

            ContextMenuStrip1.Visible = False

            DataGridView1.ContextMenuStrip = Nothing

        End If

    End Sub

#End Region

#Region "Initial"

    Private _filecaseId As String = String.Empty

    Public Sub New(ByVal fileCaseId As String, ByVal fileId As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _filecaseId = fileCaseId

        CreateTable()

        NewFinanceAdd1.SetFinance(fileCaseId, fileId)

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region
    ' '' ''Private Const C_LicenceID As UInteger = LawyerSetting.LicenceId

    ' '' ''Public Sub New()

    ' '' ''    ' This call is required by the Windows Form Designer.
    ' '' ''    InitializeComponent()

    ' '' ''    ' Add any initialization after the InitializeComponent() call.

    ' '' ''End Sub



    ' '' ''Public Sub New(ByVal financeId As String, ByVal mode As FinanceEnums.FinanceAddMode, Optional ByVal IsDaryafti As Boolean = False)

    ' '' ''    ' This call is required by the Windows Form Designer.
    ' '' ''    InitializeComponent()

    ' '' ''    NewFinanceAdd1.SetBinding(financeId, mode, IsDaryafti)
    ' '' ''    ' Add any initialization after the InitializeComponent() call.

    ' '' ''End Sub

    ' '' ''Public Sub New(ByVal timeId As String)

    ' '' ''    ' This call is required by the Windows Form Designer.
    ' '' ''    InitializeComponent()

    ' '' ''    NewFinanceAdd1.SetFinance(timeId)
    ' '' ''    ' Add any initialization after the InitializeComponent() call.

    ' '' ''End Sub


    Private Sub pnlSearch_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlSearch.Paint

    End Sub
End Class