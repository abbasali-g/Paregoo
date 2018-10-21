Imports Lawyer.Common.VB.Shaxes
Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.FileParties
Imports Lawyer.Common.VB.LawyerError

Public Class OfficeFinanceAdd

    Private curFinance As New OfficeFinance
    Private FinanceSettingID As String
    Delegate Sub ShowConfirm(ByVal text As String, ByVal title As String)
    Event ShowMessageBox As ShowConfirm
    Public YesClicked As Boolean = False


#Region "Design"

    Dim IsSearchMode As Boolean = True

    Private Sub FinanceAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblMessage.Text = String.Empty

        Try

            ToolTip1.SetToolTip(btnPrint, "چاپ")
            'نوع هزینه

            Dim FinaceTypeSource As New BindingSource

            cmbFinanceType.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            cmbFinanceType.AutoCompleteSource = AutoCompleteSource.ListItems

            Dim l As SettingCollection = FinanceManager.GetOtherFinanceTypeList()

            If l IsNot Nothing Then

                FinaceTypeSource.DataSource = l

            End If


            FinanceSettingID = SettingManager.GetIDBySettingName("OtherFinanceType")

            cmbFinanceType.DataSource = FinaceTypeSource

            txtPaymentDate.SetToday = True

            txtFrom.SetToday = True

            txtTo.SetToday = True

            Dim l2 As SettingCollection = FinanceManager.GetOtherFinanceTypeList()

            Try

                If l2 IsNot Nothing Then

                    l2.Add(New Setting("همه موارد", Guid.Empty.ToString()))

                Else

                    l2 = New SettingCollection

                    l2.Add(New Setting("همه موارد", Guid.Empty.ToString()))

                End If

                cmbFinanceSearch.DataSource = l2

                cmbFinanceSearch.SelectedValue = Guid.Empty.ToString()

            Catch ex As Exception

                btnSearch.Enabled = False

            End Try

            setLinkedSearch()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lnkChangeDesign_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkChangeDesign.LinkClicked

        setLinkedSearch()

    End Sub

    Private Sub setLinkedSearch()

        Try
            pnlAdd.Visible = IsSearchMode

            If IsSearchMode Then

                lnkChangeDesign.Text = "جستجوی هزینه"

                lnkChangeDesign.Location = New Point(26, 1)

                btnSave.Location = New Point(209, 189)

                btnCancel.Visible = False

                pnlSearch.Height = 0

                pnlAdd.Height = 232

                ResetElements()

                txtPaymentDate.SetToday = True

            Else

                lnkChangeDesign.Text = "ثبت هزینه"

                lnkChangeDesign.Location = New Point(55, 1)

                pnlSearch.Height = 480

                pnlAdd.Height = 0

                Search()

            End If

            pnlSearch.Visible = Not IsSearchMode

            IsSearchMode = Not IsSearchMode


        Catch ex As Exception

        End Try

    End Sub

    Private Sub FlowLayoutPanel1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel1.SizeChanged

        Me.Size = New Size(FlowLayoutPanel1.Width, FlowLayoutPanel1.Height)

    End Sub


#End Region

#Region "FinanceType"

    Private Sub cmbFinanceType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbFinanceType.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode = Keys.Enter Then

            SaveFinanceType()

        End If

    End Sub

    Private Sub SaveFinanceType()

        Try

            Dim newItem As New Setting

            If cmbFinanceType.Text.Trim() = String.Empty Then

                cmbFinanceType.Text = String.Empty

                Exit Sub

            End If

            Dim a As New SettingComplete

            If cmbFinanceType.SelectedIndex = -1 Then

                a.settingGroupID = FinanceSettingID

                a.settingID = Guid.NewGuid.ToString

                a.settingName = cmbFinanceType.Text.Trim()

                newItem.settingName = a.settingName

                newItem.settingValue = a.settingID

                If SettingManager.AddSetting(a) Then

                    CType(cmbFinanceType.DataSource, BindingSource).Add(newItem)

                    cmbFinanceType.SelectedValue = a.settingID

                    cmbFinanceType.DisplayMember = "settingName"

                    cmbFinanceType.ValueMember = "settingValue"

                    lblMessage.Text = "نوع جدید ثبت شد."
                Else

                    lblMessage.Text = "خطا در ثبت نوع هزینه."

                    Exit Sub

                End If


            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("SaveFinanceType", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub cmbFinanceType_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFinanceType.Leave

        Try

            lblMessage.Text = String.Empty

            If cmbFinanceType.SelectedIndex = -1 Then

                cmbFinanceType.Text = String.Empty

            End If


        Catch ex As Exception

            ErrorManager.WriteMessage("cmbFinanceType_Leave", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub LoadFinace()

        ' هزینه

        Dim FinaceTypeSource As New BindingSource

        FinaceTypeSource.DataSource = FinanceManager.GetOtherFinanceTypeList()

        If FinaceTypeSource Is Nothing OrElse FinaceTypeSource.Count = 0 Then

            clearComboboxItems(cmbFinanceType)

        Else

            cmbFinanceType.DataSource = FinaceTypeSource

        End If

    End Sub

    Private Sub ToolStripMenuItemDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDel.Click

        lblMessage.Text = String.Empty

        YesClicked = False

        Try

            If cmbFinanceType.SelectedIndex <> -1 Then

                Try

                    If FinanceManager.IsExistOfficeFinanceByFinaceType(cmbFinanceType.SelectedValue) Then

                        RaiseEvent ShowMessageBox("آیا برای حذف مطمئن هستید؟", "حذف نوع هزینه")

                        If YesClicked Then

                            If SettingManager.DelSettingByID(cmbFinanceType.SelectedValue) Then

                                LoadFinace()

                            End If

                        End If

                    Else

                        lblMessage.Text = "امکان حذف به دلیل ثبت رکورد وجود ندارد."

                    End If

                Catch ex As Exception

                    lblMessage.Text = "خطا در حذف هزینه"

                End Try

            End If



        Catch ex As Exception

            ErrorManager.WriteMessage("ToolstripDelComboItem_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#Region "Utility"

    Private Sub clearComboboxItems(ByRef cmb As ComboBox)

        Try

            If cmb.DataSource IsNot Nothing Then

                CType(cmb.DataSource, BindingSource).Clear()

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("clearComboboxItems", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#Region "Search"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Search()

    End Sub

    Private Sub Search()

        DataGridView1.AutoGenerateColumns = False

        lblMessage.Text = String.Empty

        Try

            Dim Query As String = String.Empty


            If cmbFinanceSearch.SelectedValue <> Guid.Empty.ToString() Then

                Query = " And    officefinance.finaceTypeID ='" & cmbFinanceSearch.SelectedValue & "'"

            End If

            If txtFrom.GetShamsiDateInNumericFormat.HasValue Then

                Query &= " And    officefinance.financePaymentDate >=" & txtFrom.GetShamsiDateInNumericFormat

            End If

            If txtTo.GetShamsiDateInNumericFormat.HasValue Then

                Query &= " And    officefinance.financePaymentDate <=" & txtTo.GetShamsiDateInNumericFormat

            End If

            If Query <> String.Empty Then

                Query = " where " + Query.Substring(7)

            End If

            Dim b As New BindingSource

            b.DataSource = FinanceManager.SearchOfficeFinance(Query)

            DataGridView1.DataSource = b

            SetAmounts()

        Catch ex As Exception

            ErrorManager.WriteMessage("Search", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub SetAmounts()

        txtDaryafti.Amount = 0

        Try

            If DataGridView1.Rows.Count > 0 Then

                Dim d As Double = 0

                For index As Integer = 0 To DataGridView1.Rows.Count - 1

                    d += CDbl(DataGridView1.Rows(index).Cells("clmnAmountDar").Value)

                Next

                txtDaryafti.Amount = d

                If d <> txtDaryafti.Amount Then txtDaryafti.Amount = d

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Save"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            lblMessage.Text = String.Empty

            SaveFinanceType()

            If CheckElementsBeforeSave() Then

                curFinance.finaceTypeID = cmbFinanceType.SelectedValue

                curFinance.financeAmount = txtAmount.Amount

                curFinance.financeDesc = txtDescription.Text.Trim()

                curFinance.custId = Login.CurrentLogin.CurrentUser.UserID

                If txtPaymentDate.GetShamsiDateInNumericFormat.HasValue Then

                    curFinance.financePaymentDate = txtPaymentDate.GetShamsiDateInNumericFormat()

                Else
                    curFinance.financePaymentDate = Lawyer.Common.VB.Common.DateManager.GetCurrentShamsiDateInNumericFormat()

                End If

                If curFinance.financeId = String.Empty Then

                    curFinance.financeId = Guid.NewGuid().ToString()

                    If FinanceManager.AddOfficeFinance(curFinance) Then

                        ResetElements()

                        lblMessage.Text = "ثبت انجام شد."

                    Else
                        curFinance.financeId = String.Empty

                    End If

                Else

                    If FinanceManager.EditOfficeFinance(curFinance) Then

                        setLinkedSearch()

                    Else

                        lblMessage.Text = "خطا در ویرایش"

                    End If

                End If

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("btnSave_Click", ex.ToString(), Me.ParentForm.Text)

            lblMessage.Text = "خطا در ثبت"

        End Try

    End Sub

    Private Function CheckElementsBeforeSave()

        If cmbFinanceType.SelectedIndex = -1 Then

            lblMessage.Text = "نوع هزینه را وارد نمایید."

            Return False

        End If

        If txtAmount.Amount = 0 Then

            lblMessage.Text = "مبلغ را وارد نمایید."

            Return False

        End If

        Return True

    End Function

    Private Sub ResetElements()

        txtAmount.Reset()

        curFinance.financeId = String.Empty

        txtDescription.Text = String.Empty

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        ResetElements()

        txtPaymentDate.SetToday = True

        setLinkedSearch()

    End Sub

#End Region

#Region "Print"

    Delegate Sub ReportForm(ByVal dt As DataTable, ByVal title As String)

    Event ShowReport As ReportForm

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            lblMessage.Text = String.Empty

            Dim dt As DataTable = CType(DataGridView1.DataSource, BindingSource).DataSource

            Dim str As String = String.Empty

            If txtFrom.GetShamsiDateInNumericFormat.HasValue Then

                str = "از تاریخ " & txtFrom.GetShamsiDate()

            End If
            If txtTo.GetShamsiDateInNumericFormat.HasValue Then


                str &= "تا تاریخ " & txtTo.GetShamsiDate()

            End If

            RaiseEvent ShowReport(dt, " هزینه های دفتری " & str)

        Catch ex As Exception

        End Try

    End Sub

#End Region
   
#Region "DataGridview"

    Dim rowIndex As Integer = -1

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        Try

            If DataGridView1.Columns(e.ColumnIndex).Name = "clmfinancePaymentDate" Then

                Dim s As String = e.Value.ToString

                e.Value = s.Substring(0, 4) + "/" + s.Substring(4, 2) + "/" + s.Substring(6, 2)

            End If
        Catch ex As Exception

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

                ContextMenuStrip2.Visible = True

                rowIndex = hti.RowIndex

                DataGridView1.Rows(rowIndex).Selected = True

                DataGridView1.ContextMenuStrip = ContextMenuStrip2

                DataGridView1.ContextMenuStrip.Show(DataGridView1, New Point(e.X, e.Y))

            Else

                ContextMenuStrip2.Visible = False

                DataGridView1.ContextMenuStrip = Nothing

            End If

        Else

            ContextMenuStrip2.Visible = False

            DataGridView1.ContextMenuStrip = Nothing

        End If

    End Sub

    Private Sub ToolStripMenuItemDelFinance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDelFinance.Click

        Try

            lblMessage.Text = String.Empty

            If rowIndex <> -1 Then

                RaiseEvent ShowMessageBox("آیا برای حذف مطمئن هستید؟", "حذف هزینه")

                If YesClicked Then

                    If FinanceManager.DeleteOfficeFinanceByID(DataGridView1.Rows(rowIndex).Cells("clmfinanceID").Value.ToString()) Then

                        Search()

                    Else

                        lblMessage.Text = "خطا در حذف هزینه"

                    End If


                End If


            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در حذف"

            ErrorManager.WriteMessage("ToolStripMenuItemDelFinance_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub ToolStripMenuItemEditFinance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemEditFinance.Click

        Try

            If rowIndex <> -1 Then

                BindFinance(DataGridView1.Rows(rowIndex).Cells("clmfinanceID").Value.ToString())

            Else

                curFinance.financeId = String.Empty

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در ویرایش"

            ErrorManager.WriteMessage("toolStripEdit_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub BindFinance(ByVal financeId As String)

        Try
            curFinance = FinanceManager.GetOfficeFinaceByID(financeId)

            If curFinance Is Nothing Then

                lblMessage.Text = "خطا در بارگذاری اطلاعات"

                curFinance.financeId = String.Empty
            Else

                setLinkedSearch()

                curFinance.financeId = financeId

                Try
                    cmbFinanceType.SelectedValue = curFinance.finaceTypeID

                Catch ex As Exception

                    cmbFinanceType.SelectedIndex = -1

                End Try

                txtAmount.Amount = curFinance.financeAmount

                txtDescription.Text = curFinance.financeDesc

                txtPaymentDate.SetShamsiDateInNumericFormat(curFinance.financePaymentDate)

                SetDesignForEdit()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SetDesignForEdit()

        btnCancel.Visible = True

        btnSave.Location = New Point(262, 189)

    End Sub

#End Region

    
 
   
    

End Class
