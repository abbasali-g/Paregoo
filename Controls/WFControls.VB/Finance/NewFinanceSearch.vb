Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB.Shaxes
Imports Microsoft.Office.Interop
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.Docs


Public Class NewFinanceSearch

    ' '' ''#Region "Variablr"

    Dim gridSize As Size = Nothing

    ' '' ''    Dim rowIndex As Integer = -1

    Delegate Sub ShowForm(ByVal financeId As String, ByVal mode As FinanceEnums.FinanceAddMode)

    Event ShowFinanceAdd As ShowForm

    Private IsFileCaseMode As Boolean = False

    Delegate Sub ReportForm(ByVal dt As DataTable, ByVal title As String, ByVal type As Int16)
    Event ShowReport As ReportForm

    Delegate Sub ShowContact()
    Event ShowContactSearch As ShowContact

    Dim dtDaryafti As DataTable
    Dim dtHazine As DataTable


    Private Sub SetAmounts()

        txtBedehkar.Amount = 0

        txtDaryafti.Amount = 0

        txtMande.Amount = 0

        Dim d As Double = 0

        Dim b As Double = 0

        Try

            If dtDaryafti IsNot Nothing Then

                For index As Integer = 0 To dtDaryafti.Rows.Count - 1

                    d += CDbl(dtDaryafti.Rows(index).Item("AmountDaryafti"))

                Next

                txtDaryafti.Amount = d

                If d <> txtDaryafti.Amount Then txtDaryafti.Amount = d

            End If


            If dtHazine IsNot Nothing Then

                For index As Integer = 0 To dtHazine.Rows.Count - 1

                    b += CDbl(dtHazine.Rows(index).Item("AmountHazine"))
                Next

                txtBedehkar.Amount = b

                If b <> txtBedehkar.Amount Then txtBedehkar.Amount = b

            End If

            txtMande.Amount = b - d

            If (b - d) <> txtMande.Amount Then txtMande.Amount = b - d

        Catch ex As Exception

        End Try

    End Sub

#Region "در حال بررسی"

    Private Sub FinanceSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If CurrentLogin.CurrentUser.Role = Lawyer.Common.VB.ContactInfo.Enums.RoleType.منشی Then
                lblMessage.Text = "دسترسی غیر مجاز برای کاربری منشی"
                Exit Sub
            End If


            Me.ToolTip1.SetToolTip(btnHelp, "شماره سیستمی و یا قضایی پرونده")

            Me.ToolTip1.SetToolTip(btnPrint, "چاپ")

            lblMessage.Text = String.Empty

            Dim list As SettingCollection = FinanceManager.GetFinanceTypeList()

            Try

                If list IsNot Nothing Then

                    list.Add(New Setting("همه موارد", Guid.Empty.ToString()))

                    list.Add(New Setting("مشاوره", "44ca4f7d-1044-4fe0-9abd-94abd834c149"))


                Else

                    list = New SettingCollection

                    list.Add(New Setting("همه موارد", Guid.Empty.ToString()))

                    list.Add(New Setting("مشاوره", "44ca4f7d-1044-4fe0-9abd-94abd834c149"))

                End If

            Catch ex As Exception

                ErrorManager.WriteMessage("FinanceSearch_Load,part1", ex.ToString(), Me.ParentForm.Text)

            End Try

            cmbFinanceType.DataSource = list

            cmbFinanceType.SelectedValue = Guid.Empty.ToString()

            If cmbFinanceType.Items.Count = 0 Then

                btnSearch.Enabled = False

                picCreateExcel.Enabled = False

                lblMessage.Text = "به دلیل عدم وجود نوع هزینه امکان جستجو وجود ندارد"

            End If

            txtFrom.SetToday = True

            txtTo.SetToday = True

            BindSubject()

            cmbShowType.SelectedIndex = 0

            Search()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CreateTable(ByRef dtResult As DataTable)

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

            dtResult.Columns.Add("custFullName")

            dtResult.Columns.Add("FileCaseNumber")

            dtResult.Columns.Add("finaceTypeID")

        End If

    End Sub

    Private Sub Search()

        If CurrentLogin.CurrentUser.Role = Lawyer.Common.VB.ContactInfo.Enums.RoleType.منشی Then
            lblMessage.Text = "دسترسی غیر مجاز برای کاربری منشی"
            Exit Sub
        End If

        lblMessage.Text = String.Empty

        Try

            Dim Query As String = String.Empty

            Dim QueryMovakel As String = String.Empty

            If cmbFinanceType.Visible AndAlso cmbFinanceType.SelectedValue <> Guid.Empty.ToString() Then

                Query = " And    finance.finaceTypeID ='" & cmbFinanceType.SelectedValue & "'"

            End If

            If txtFrom.GetShamsiDateInNumericFormat.HasValue Then

                Query &= " And    finance.financePaymentDate >=" & txtFrom.GetShamsiDateInNumericFormat

            End If

            If txtTo.GetShamsiDateInNumericFormat.HasValue Then

                Query &= " And    finance.financePaymentDate <=" & txtTo.GetShamsiDateInNumericFormat

            End If

            If txtFCaseSubject.Text <> String.Empty Then

                Query &= " And    filecases1.fileCaseSubject  like '%" & txtFCaseSubject.Text & "%'"

            End If

            If txtFCaseID.Text <> String.Empty Then


                Query &= " And    (filecases1.fileCaseNumberInCourt='" & txtFCaseID.Text & "'  or  filecases1.fileCaseNumberInSystem='" & txtFCaseID.Text & "'  or  filecases1.fileCaseNumberInBranch='" & txtFCaseID.Text & "')"

            End If

            If txtFcMovakel.Text <> String.Empty Then

                QueryMovakel = " where  fileparties.fileCaseRole =0 And fileparties.contactInfoID='" & movakelId & "'"

            End If

            Dim dt As New DataTable

            CreateTable(dt)

            If Query <> String.Empty Then

                Query = " where " + Query.Substring(7)

            End If

            Dim l As FinanceSearchCollection = Nothing

            Dim lm As FinanceSearchCollection = Nothing

            If cmbShowType.SelectedIndex = 0 AndAlso cmbFinanceType.SelectedValue = "44ca4f7d-1044-4fe0-9abd-94abd834c149" Then

                lm = searchMoshavere()

            Else

                If CurrentLogin.CurrentUser.IsAdmin Then

                    l = FinanceManager.SearchFinance_Collection(QueryMovakel, Query, True)

                Else

                    Dim FinanceAccessQ As String = " and contactInfoID='" & CurrentLogin.CurrentUser.UserID & "' "

                    l = FinanceManager.SearchFinanceByPermission_Collection(QueryMovakel, Query, True, FinanceAccessQ)

                End If


                If Not (cmbShowType.SelectedIndex = 0 AndAlso cmbFinanceType.SelectedValue <> Guid.Empty.ToString()) Then

                    lm = searchMoshavere()

                End If

            End If

            If l IsNot Nothing Then

                For Each Item As Lawyer.Common.VB.Shaxes.FinanceSearch In l

                    Dim dtNewRow As DataRow

                    dtNewRow = dt.NewRow()

                    dtNewRow.Item("AmountDaryafti") = Item.AmountDaryafti

                    dtNewRow.Item("AmountHazine") = Item.AmountHazine

                    dtNewRow.Item("financeChequeSerial") = Item.financeChequeSerial

                    dtNewRow.Item("financeDesc") = Item.financeDesc

                    dtNewRow.Item("financeID") = Item.financeID

                    dtNewRow.Item("financePaymentDate") = Item.financePaymentDate

                    dtNewRow.Item("financePaymentTime") = Item.financePaymentTime

                    dtNewRow.Item("financeType") = Item.financeType

                    dtNewRow.Item("Shobe") = Item.Shobe

                    dtNewRow.Item("custFullName") = Item.custFullName

                    dtNewRow.Item("FileCaseNumber") = Item.FileCaseNumber

                    dtNewRow.Item("finaceTypeID") = Item.finaceTypeID


                    dt.Rows.Add(dtNewRow)

                Next

            End If

            If lm IsNot Nothing Then

                For Each Item As Lawyer.Common.VB.Shaxes.FinanceSearch In lm

                    Dim dtNewRow As DataRow

                    dtNewRow = dt.NewRow()

                    dtNewRow.Item("AmountDaryafti") = Item.AmountDaryafti

                    dtNewRow.Item("AmountHazine") = Item.AmountHazine

                    dtNewRow.Item("financeChequeSerial") = Item.financeChequeSerial

                    dtNewRow.Item("financeDesc") = Item.financeDesc

                    dtNewRow.Item("financeID") = Item.financeID

                    dtNewRow.Item("financePaymentDate") = Item.financePaymentDate

                    dtNewRow.Item("financePaymentTime") = Item.financePaymentTime

                    dtNewRow.Item("financeType") = Item.financeType

                    dtNewRow.Item("Shobe") = Item.Shobe

                    dtNewRow.Item("custFullName") = Item.custFullName

                    dtNewRow.Item("FileCaseNumber") = Item.FileCaseNumber

                    dtNewRow.Item("finaceTypeID") = Item.finaceTypeID

                    dt.Rows.Add(dtNewRow)

                Next

            End If

            If cmbFinanceType.Visible AndAlso cmbFinanceType.SelectedValue <> Guid.Empty.ToString() Then

                If dtDaryafti IsNot Nothing Then

                    dtDaryafti.Rows.Clear()

                End If

                dtHazine = dt.Copy()

                dtHazine.DefaultView.RowFilter = " AmountHazine>0"

                dtHazine = dtHazine.DefaultView.ToTable()


            Else

                dtDaryafti = dt.Copy()

                dtDaryafti.DefaultView.RowFilter = " AmountDaryafti>0"

                dtDaryafti = dtDaryafti.DefaultView.ToTable()

                dtHazine = dt.Copy()

                dtHazine.DefaultView.RowFilter = " AmountHazine>0"

                dtHazine = dtHazine.DefaultView.ToTable()


            End If

            setDatagrid()

            'SetAmounts()

        Catch ex As Exception

            ErrorManager.WriteMessage("Search", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#Region "Search"

    Private Function searchMoshavere() As FinanceSearchCollection

        Try

            Dim lm As FinanceSearchCollection = Nothing

            Dim fQuery As String = String.Empty

            'مشاوره
            If txtFrom.GetShamsiDateInNumericFormat.HasValue Then

                fQuery = " and finance.financePaymentDate>=" & txtFrom.GetShamsiDateInNumericFormat

            End If

            If txtTo.GetShamsiDateInNumericFormat.HasValue Then

                fQuery &= " and finance.financePaymentDate<=" & txtTo.GetShamsiDateInNumericFormat

            End If


            If movakelId <> String.Empty Then

                fQuery &= " and financeCustID='" & movakelId & "'"

            End If

            lm = FinanceManager.SearchFinance_Moshavere(fQuery)


            Return lm

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        lblMessage.Text = String.Empty

        Search()

    End Sub


    Private Sub setDatagrid()

        Try

            lblMessage.Text = String.Empty

            Dim b As New BindingSource

            If cmbShowType.SelectedIndex = 1 Then

                DataGridView1.Columns("clmnAmountDar").Visible = True

                DataGridView1.Columns("clmfinanceAmount").Visible = False

                b.DataSource = dtDaryafti

            Else

                DataGridView1.Columns("clmnAmountDar").Visible = False

                DataGridView1.Columns("clmfinanceAmount").Visible = True

                b.DataSource = dtHazine

            End If

            DataGridView1.DataSource = b

            If (cmbFinanceType.Visible AndAlso cmbFinanceType.SelectedValue = Guid.Empty.ToString()) OrElse cmbShowType.SelectedIndex = 1 Then
                'همه موارد
                pnlPercent.Height = 50

            Else

                pnlPercent.Height = 25

            End If

            SetAmounts()

            If DataGridView1.RowCount <= 0 Then

                lblMessage.Text = "موردی یافت نشد."

            End If

        Catch ex As Exception

        End Try

    End Sub


#End Region

#Region "Initial & Design"

    Private Sub BindSubject()

        Try

            txtFCaseSubject.AutoCompleteCustomSource = FileCaseManager.GetAllFileCaseSubjects()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbShowType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShowType.SelectedIndexChanged

        lblMessage.Text = String.Empty

        If cmbShowType.SelectedIndex = 0 Then

            lblhazine.Visible = True

            cmbFinanceType.Visible = True

        Else
            lblhazine.Visible = False

            cmbFinanceType.Visible = False

        End If

    End Sub

#End Region

#Region "Movakel"

    Private movakelId As String = String.Empty

    Delegate Sub ContactDetailHandler(ByVal custId As String)

    Event ContactDetail As ContactDetailHandler

    Private Sub UcContacts2_ContactDetail(ByVal custId As String) Handles UcContacts2.ContactDetail

        lblMessage.Text = String.Empty

        lblMessage.Text = String.Empty

        txtFcMovakel.Text = String.Empty

        RaiseEvent ContactDetail(custId)

        UcContacts2.RefreshContacts()

    End Sub

    Private Sub txtFcMovakel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtFcMovakel.DragDrop

        Try
            lblMessage.Text = String.Empty
            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim contact() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In contact

                    If CInt(item.SubItems(2).Text) = Lawyer.Common.VB.ContactInfo.Enums.RoleType.موکل Then

                        txtFcMovakel.Text = contact(0).Text

                        movakelId = item.SubItems(1).Text

                        Exit Sub

                    End If

                Next

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("txtMovakelr_DragDrop", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub txtFcMovakell_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtFcMovakel.DragEnter
        lblMessage.Text = String.Empty
        e.Effect = DragDropEffects.Copy

    End Sub

    Private Sub txtFcMovakel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFcMovakel.KeyPress

        lblMessage.Text = String.Empty

        e.Handled = True

    End Sub

    Private Sub txtFcMovakel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFcMovakel.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode <> Keys.Delete Then

            UcContacts2.Focus()

            UcContacts2.BindContacts(ucContacts.SearchType.role, Lawyer.Common.VB.ContactInfo.Enums.RoleType.موکل, New Point(35, 97), "", "")

        Else

            txtFcMovakel.Text = String.Empty

            movakelId = String.Empty


        End If

    End Sub

    Private Sub UcContacts2_ContactAdd(ByVal c As Lawyer.Common.VB.ContactInfo.ContactInfoReview) Handles UcContacts2.ContactAdd

        lblMessage.Text = String.Empty
        Try

            txtFcMovakel.Text = c.custFullName

            movakelId = c.custID

            UcContacts2.Hide()

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "DataGridview"


    Dim rowIndex As Integer = -1

    Private Sub ToolStripMenuItemDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDelete.Click
        lblMessage.Text = String.Empty

        Try

            If rowIndex <> -1 Then

                If DataGridView1.Rows(rowIndex).Cells("clmfinaceTypeID").Value.ToString() = "44ca4f7d-1044-4fe0-9abd-94abd834c149" Then

                    lblMessage.Text = "لطفا از طریق فرم مشاوره اقدام به ویرایش و یا حذف مشاوره نمایید."

                    Exit Sub

                Else

                    RaiseEvent ShowFinanceAdd(rowIndex, FinanceEnums.FinanceAddMode.حذف)

                    Search()

                End If



            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در حذف"

            ErrorManager.WriteMessage("ToolStripDelete_Click", ex.ToString(), Me.ParentForm.Text)

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

    Public Sub DeleteRow()

        Try

            If FinanceManager.DeleteFinanceByID(DataGridView1.Rows(rowIndex).Cells("clmfinanceID").Value.ToString()) Then

                Search()

            Else
                lblMessage.Text = "خطا در حذف"

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در حذف"

            ErrorManager.WriteMessage("ToolStripMenuItemDel_Click", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub toolStripEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripEdit.Click
        Try
            lblMessage.Text = String.Empty
            If rowIndex <> -1 Then

                If DataGridView1.Rows(rowIndex).Cells("clmfinaceTypeID").Value.ToString() = "44ca4f7d-1044-4fe0-9abd-94abd834c149" Then

                    lblMessage.Text = "لطفا از طریق فرم مشاوره اقدام به ویرایش و یا حذف مشاوره نمایید."

                    Exit Sub

                Else

                    RaiseEvent ShowFinanceAdd(DataGridView1.Rows(rowIndex).Cells("clmfinanceID").Value.ToString(), FinanceEnums.FinanceAddMode.ویرایش)

                    Search()

                End If


            End If

        Catch ex As Exception


            lblMessage.Text = "خطا در ویرایش"

            ErrorManager.WriteMessage("toolStripEdit_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

    Private Sub picCreateExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCreateExcel.Click

        lblMessage.Text = String.Empty
        Try

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
            ErrorManager.WriteMessage("picCreateExcel_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            lblMessage.Text = String.Empty

            Dim title As String = String.Empty

            Dim b As BindingSource = DataGridView1.DataSource

            Dim c As DataTable = b.DataSource


            If cmbShowType.SelectedIndex = 1 Then

                title = "گزارش دریافتی ها"

                RaiseEvent ShowReport(c, title, 11)

            Else

                If cmbFinanceType.SelectedValue = Guid.Empty.ToString() Then

                    title = "گزارش  همه هزینه ها"

                Else

                    title = "گزارش هزینه ها : " & cmbFinanceType.Text

                End If

                RaiseEvent ShowReport(c, title, 10)

            End If



        Catch ex As Exception

        End Try

    End Sub

End Class
