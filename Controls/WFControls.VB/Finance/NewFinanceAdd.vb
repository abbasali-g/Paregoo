Imports Lawyer.Common.VB.Shaxes
Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.FileParties
Imports Lawyer.Common.VB.LawyerError

Public Class NewFinanceAdd

    Private curFinance As New Finance
    Private BankSettingID As String
    Private FinanceSettingID As String
    'Delegate Sub ShowContactForm()
    'Event ShowContactSearchForm As ShowContactForm
    Private EventIsRun As Boolean = False
    Private txtClick As textBoxClick
    Delegate Sub ShowConfirm(ByVal text As String, ByVal title As String)
    Event ShowMessageBox As ShowConfirm
    Public YesClicked As Boolean = False

#Region "Methods"

    Public Sub SetBinding(ByVal financeId As String, ByVal mode As FinanceEnums.FinanceAddMode, Optional ByVal isDaryafti As Boolean = False)

        Try


            Select Case mode

                Case FinanceEnums.FinanceAddMode.ویرایش

                    curFinance = FinanceManager.GetFinaceByID(financeId)

                    If curFinance Is Nothing Then

                        lblMessage.Text = "خطا در بارگذاری اطلاعات"

                        btnSave.Enabled = False

                        Exit Sub

                    End If

                    cmbPaymentType.SelectedValue = curFinance.financePaymentType

                    If curFinance.financeAmount > 0 Then
                        'دریافتی
                        rdbDaryafti.Checked = True
                        txtAmountDaryafti.Text = curFinance.financeAmount
                        txtAmountHazine.Reset()

                    Else
                        rdbHazine.Checked = True

                        txtAmountHazine.Text = -curFinance.financeAmount

                        txtAmountDaryafti.Reset()

                    End If

                    cmbFinanceType.SelectedValue = curFinance.finaceTypeID


                    If curFinance.financeBankID <> String.Empty Then

                        cmbBank.SelectedValue = curFinance.financeBankID

                    End If

                    If curFinance.financeBranchID <> String.Empty Then

                        cmbBranch.SelectedValue = curFinance.financeBranchID

                    End If

                    txtDescription.Text = curFinance.financeDesc

                    txtCheckSerial.Text = curFinance.financeChequeSerial

                    txtCheckDate.SetShamsiDateInNumericFormat(curFinance.financeChequeDate)

                    financePaymentDate.SetShamsiDateInNumericFormat(curFinance.financePaymentDate)

                    ' '' ''Case FinanceEnums.FinanceAddMode.اضافه_کردن

                    ' '' ''    Dim finrev As FinanceReview = FinanceManager.GetFinaceReviewByID(financeId)

                    ' '' ''    curFinance.fileCaseID = finrev.fileCaseID

                    ' '' ''    curFinance.fileID = finrev.fileID

                    ' '' ''    curFinance.finaceTypeID = finrev.finaceTypeID

                    ' '' ''    curFinance.financeCustID = finrev.financeCustID

                    ' '' ''    curFinance.timeID = finrev.timeID

                    ' '' ''    txtPersonName.Text = ContactInfo.ContactInfoManager.GetContactFullNameByID(curFinance.financeCustID)

                    ' '' ''    PersonName(0) = curFinance.financeCustID

                    ' '' ''    PersonName(1) = txtPersonName.Text

                    ' '' ''    If curFinance.timeID <> String.Empty Then

                    ' '' ''        cmbFinanceType.SelectedValue = curFinance.finaceTypeID

                    ' '' ''        cmbFinanceType.Enabled = False

                    ' '' ''    End If

                    ' '' ''    If isDaryafti Then

                    ' '' ''        rdbDaryafti.Checked = True

                    ' '' ''    End If

                    ' '' ''Case Else

            End Select


        Catch ex As Exception

            lblMessage.Text = "خطا در بارگذاری اطلاعات"

            ErrorManager.WriteMessage("SetBinding", ex.ToString(), Me.ParentForm.Text)

            btnSave.Enabled = False

            Exit Sub

        End Try

    End Sub

    Public ReadOnly Property GetFileCaseID() As String
        Get
            Return curFinance.fileCaseID
        End Get

    End Property
 
    

#End Region

#Region "Public Methods"

    'مربوط به یک پرونده
    Public Sub SetFinance(ByVal fileCaseId As String, ByVal fileId As String)

        Try

            curFinance.fileCaseID = fileCaseId

            curFinance.fileID = fileId

            curFinance.financeCustID = Docs.FileDocManager.GetFileCustId(fileId)

        Catch ex As Exception

            ErrorManager.WriteMessage("SetFinance", ex.ToString(), Me.ParentForm.Text)

        End Try

        If curFinance.financeCustID = String.Empty Then

            btnSave.Enabled = False

        End If

    End Sub


#End Region

#Region "Save"

    Private Function CheckElementsBeforeSave()

        If rdbHazine.Checked Then

            If cmbFinanceType.SelectedIndex = -1 Then

                lblMessage.Text = "نوع هزینه را وارد نمایید."

                Return False

            End If


            If txtAmountHazine.Amount = 0 Then

                lblMessage.Text = "مبلغ را وارد نمایید."

                Return False

            End If

        Else

            If txtAmountDaryafti.Amount = 0 Then

                lblMessage.Text = "مبلغ را وارد نمایید."

                Return False

            End If

        End If

        Return True

    End Function

#End Region

#Region "در حال بررسی"

    Public Sub SetDesign()

        lblMessage.Text = String.Empty

        If EventIsRun Then

            Try
                If rdbDaryafti.Checked Then

                    pnlHazine.Visible = False

                    pnlPaymentType.Visible = True

                    If cmbPaymentType.SelectedValue = "1" Then

                        pnlCheq.Visible = True

                    Else

                        pnlCheq.Visible = False

                    End If

                Else

                    pnlHazine.Visible = True

                    pnlPaymentType.Visible = False

                    pnlCheq.Visible = False

                End If



            Catch ex As Exception

                ErrorManager.WriteMessage("SetDesign", ex.ToString(), Me.ParentForm.Text)

            End Try

        End If

    End Sub

    Private Sub ResetElements()

        txtAmountHazine.Reset()

        txtAmountDaryafti.Reset()

        txtCheckDate.SetShamsiDate(String.Empty)

        txtCheckSerial.Text = String.Empty

        curFinance.financeID = String.Empty

        txtDescription.Text = String.Empty

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            lblMessage.Text = String.Empty

            SaveBankList()

            SaveFinanceType()

            If CheckElementsBeforeSave() Then

                If rdbHazine.Checked Then
                    'هزینه

                    curFinance.finaceTypeID = cmbFinanceType.SelectedValue

                    curFinance.financeAmount = -txtAmountHazine.Amount

                    curFinance.financePaymentType = String.Empty

                    curFinance.financeBankID = String.Empty

                    curFinance.financeBranchID = String.Empty

                    curFinance.financeChequeDate = String.Empty

                    curFinance.financeChequeSerial = String.Empty

                Else

                    'دریافتی

                    curFinance.finaceTypeID = String.Empty

                    curFinance.financeAmount = txtAmountDaryafti.Amount

                    curFinance.financePaymentType = cmbPaymentType.SelectedValue()

                    curFinance.financeBankID = cmbBank.SelectedValue

                    curFinance.financeBranchID = cmbBranch.SelectedValue

                    If cmbPaymentType.SelectedValue = "0" Then

                        curFinance.financeChequeDate = String.Empty

                        curFinance.financeChequeSerial = String.Empty

                        curFinance.financeBankID = String.Empty

                        curFinance.financeBranchID = String.Empty

                    Else

                        If txtCheckDate.GetShamsiDateInNumericFormat.HasValue Then

                            curFinance.financeChequeDate = txtCheckDate.GetShamsiDateInNumericFormat

                        Else

                            curFinance.financeChequeDate = String.Empty

                        End If

                        curFinance.financeChequeSerial = txtCheckSerial.Text

                    End If

                End If

                curFinance.financeDesc = txtDescription.Text.Trim()

                Dim d = financePaymentDate.GetShamsiDateInNumericFormat()

                curFinance.financePaymentDate = IIf(d = 0, Lawyer.Common.VB.Common.DateManager.GetCurrentShamsiDateInNumericFormat(), d)

                curFinance.financePaymentTime = Lawyer.Common.VB.Common.DateManager.GetCurrentTime()

                If curFinance.financeID = String.Empty Then

                    curFinance.financeID = Guid.NewGuid().ToString()

                    If FinanceManager.AddFinance(curFinance) Then

                        ResetElements()

                        lblMessage.Text = "ثبت انجام شد."

                    Else
                        curFinance.financeID = String.Empty

                    End If

                Else

                    If FinanceManager.EditFinance(curFinance) Then

                        ParentForm.Close()

                    End If

                End If

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("btnSave_Click", ex.ToString(), Me.ParentForm.Text)

            lblMessage.Text = "خطا در ثبت"

        End Try

    End Sub

#End Region

#Region "Design"

    Private Sub rdbHazine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbHazine.CheckedChanged

        SetDesign()

    End Sub

    Private Sub FinanceAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblMessage.Text = String.Empty

        Try
            ' بانک

            Dim banksource As New BindingSource

            banksource.DataSource = FinanceManager.GetBankList()

            cmbBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            cmbBank.AutoCompleteSource = AutoCompleteSource.ListItems

            If banksource IsNot Nothing Then

                cmbBank.DataSource = banksource

            End If

            BankSettingID = SettingManager.GetIDBySettingName("BankList")

            'شعبه
            cmbBranch.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            cmbBranch.AutoCompleteSource = AutoCompleteSource.ListItems

            'نوع هزینه

            Dim FinaceTypeSource As New BindingSource

            cmbFinanceType.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            cmbFinanceType.AutoCompleteSource = AutoCompleteSource.ListItems

            FinaceTypeSource.DataSource = FinanceManager.GetFinanceTypeList()

            FinanceSettingID = SettingManager.GetIDBySettingName("FinanceType")

            If FinaceTypeSource IsNot Nothing Then

                cmbFinanceType.DataSource = FinaceTypeSource

            End If

            ' نوع پرداخت

            Dim payment As SettingCollection = FinanceManager.GetPaymentTypeList()

            If payment IsNot Nothing Then

                cmbPaymentType.DataSource = payment

                cmbPaymentType.SelectedValue = "0"

            End If

            financePaymentDate.SetToday = True

            EventIsRun = True

            SetDesign()

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "FinanceType"

    Enum textBoxClick

        hazine = 1
        bank = 2
        shobe = 3

    End Enum

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

    Private Sub cmbFinanceType_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFinanceType.MouseEnter

        txtClick = textBoxClick.hazine

    End Sub

    Private Sub LoadFinace()

        ' هزینه

        Dim FinaceTypeSource As New BindingSource

        FinaceTypeSource.DataSource = FinanceManager.GetFinanceTypeList()

        If FinaceTypeSource Is Nothing OrElse FinaceTypeSource.Count = 0 Then

            clearComboboxItems(cmbFinanceType)

        Else

            cmbFinanceType.DataSource = FinaceTypeSource

        End If

    End Sub

#End Region

#Region "ContextMenu"

    Private Sub ToolstripDelComboItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolstripDelComboItem.Click

        lblMessage.Text = String.Empty

        YesClicked = False

        Try
            Select Case txtClick

                Case textBoxClick.hazine

                    If cmbFinanceType.SelectedIndex <> -1 Then

                        Try

                            If FinanceManager.IsExistFinanceByFinaceType(cmbFinanceType.SelectedValue) Then

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

                Case textBoxClick.bank

                    If cmbBank.SelectedIndex <> -1 Then

                        RaiseEvent ShowMessageBox("آیا برای حذف مطمئن هستید؟", "حذف بانک")

                        If YesClicked Then

                            Try
                                If SettingManager.DelSettingByBankID(cmbBank.SelectedValue) Then

                                    LoadBanks()

                                End If

                            Catch ex As Exception

                                lblMessage.Text = "خطا در حذف بانک"

                            End Try

                        End If

                    End If


                Case textBoxClick.shobe


                    If cmbBranch.SelectedIndex <> -1 Then

                        RaiseEvent ShowMessageBox("آیا برای حذف مطمئن هستید؟", "حذف شعبه")

                        If YesClicked Then

                            Try
                                If SettingManager.DelSettingByBranchID(cmbBranch.SelectedValue) Then

                                    LoadBranches()

                                End If

                            Catch ex As Exception

                                lblMessage.Text = "خطا در حذف شعبه"

                            End Try

                        End If

                    End If

            End Select

        Catch ex As Exception

            ErrorManager.WriteMessage("ToolstripDelComboItem_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#Region "PaymentType"

    Private Sub cmbPaymentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaymentType.SelectedIndexChanged

        SetDesign()

    End Sub

#End Region

#Region "Bank"

    Private Sub cmbBank_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbBank.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode = Keys.Enter Then

            Try

                Dim bankName As String = cmbBank.Text.Trim()

                Dim ba As New SettingComplete

                If bankName = String.Empty Then

                    Exit Sub

                End If

                If cmbBank.SelectedIndex = -1 Then

                    ba.settingGroupID = BankSettingID

                    ba.settingID = Guid.NewGuid.ToString

                    ba.settingName = bankName

                    If SettingManager.AddSetting(ba) Then

                        Dim newItem As New Setting

                        newItem.settingValue = ba.settingID

                        newItem.settingName = ba.settingName

                        CType(cmbBank.DataSource, BindingSource).Add(newItem)

                        cmbBank.SelectedValue = ba.settingID

                        cmbBank.DisplayMember = "settingName"

                        cmbBank.ValueMember = "settingValue"

                        lblMessage.Text = "بانک جدید ثبت شد."

                    Else

                        lblMessage.Text = "خطا در ثبت بانک."

                    End If

                End If

            Catch ex As Exception

                ErrorManager.WriteMessage("cmbBank_KeyDown", ex.ToString(), Me.ParentForm.Text)

            End Try

        End If

    End Sub

    Private Sub cmbBank_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBank.MouseEnter

        txtClick = textBoxClick.bank

    End Sub

    Private Sub cmbBank_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBank.Leave

        lblMessage.Text = String.Empty

        Try

            If cmbBank.SelectedIndex = -1 Then

                cmbBank.Text = String.Empty

                clearComboboxItems(cmbBranch)

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("cmbBank_Leave", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub cmbBank_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBank.SelectedValueChanged

        LoadBranches()

    End Sub

    Private Sub LoadBranches()

        Try

            lblMessage.Text = String.Empty

            cmbBank.SelectedIndex = cmbBank.FindStringExact(cmbBank.Text)

            If cmbBank.SelectedIndex <> -1 Then

                Dim FinaceTypeSource As New BindingSource

                FinaceTypeSource.DataSource = FinanceManager.GetBankBranches(cmbBank.SelectedValue)

                If FinaceTypeSource Is Nothing OrElse FinaceTypeSource.Count = 0 Then

                    clearComboboxItems(cmbBranch)

                Else

                    cmbBranch.DataSource = FinaceTypeSource

                End If

            Else

                cmbBank.Text = String.Empty

                clearComboboxItems(cmbBranch)

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("LoadBranches", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub cmbBranch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbBranch.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode = Keys.Enter Then

            Try


                Dim BranchName As String = cmbBranch.Text.Trim()

                Dim Br As New SettingComplete

                curFinance.financeBranchID = String.Empty

                If cmbBank.SelectedIndex = -1 Then

                    lblMessage.Text = "بانک را وارد نمایید"

                    Exit Sub

                End If

                If BranchName = String.Empty Then

                    Exit Sub

                End If

                If cmbBranch.SelectedIndex = -1 Then

                    Br.settingGroupID = cmbBank.SelectedValue

                    Br.settingName = BranchName

                    Br.settingID = Guid.NewGuid.ToString

                    If SettingManager.AddSetting(Br) Then

                        Dim newItem As New Setting

                        newItem.settingValue = Br.settingID

                        newItem.settingName = Br.settingName

                        If cmbBranch.DataSource Is Nothing Then

                            Dim b As New BindingSource

                            cmbBranch.DataSource = b

                        End If

                        CType(cmbBranch.DataSource, BindingSource).Add(newItem)

                        cmbBranch.SelectedValue = Br.settingID

                        cmbBranch.DisplayMember = "settingName"

                        cmbBranch.ValueMember = "settingValue"

                        lblMessage.Text = "شعبه جدید ثبت شد."

                    Else

                        lblMessage.Text = "خطا در ثبت شعبه."

                    End If


                End If

            Catch ex As Exception

                ErrorManager.WriteMessage("cmbBranch_KeyDown", ex.ToString(), Me.ParentForm.Text)

            End Try


        End If

    End Sub

    Private Sub cmbBranch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBranch.Leave

        Try

            lblMessage.Text = String.Empty

            If cmbBranch.SelectedIndex = -1 Then

                cmbBranch.Text = String.Empty

            End If


        Catch ex As Exception

            ErrorManager.WriteMessage("cmbBranch_Leave", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub cmbBranch_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.MouseEnter

        txtClick = textBoxClick.shobe

    End Sub

    Private Sub LoadBanks()

        ' بانک

        Dim banksource As New BindingSource

        banksource.DataSource = FinanceManager.GetBankList()

        If banksource Is Nothing OrElse banksource.Count = 0 Then

            clearComboboxItems(cmbBank)

        Else

            cmbBank.DataSource = banksource

        End If

    End Sub

    Private Sub clearCombo(ByVal name As String)

        Select Case name

            Case "Bank"

                cmbBank.Text = String.Empty

                clearComboboxItems(cmbBank)

                clearComboboxItems(cmbBranch)

                cmbBranch.Text = String.Empty

            Case "Branch"

                cmbBranch.Text = String.Empty

        End Select

    End Sub

    Private Sub SaveBankList()

        Try

            Dim bankName As String = cmbBank.Text.Trim()

            Dim BranchName As String = cmbBranch.Text.Trim()

            Dim ba As New SettingComplete

            Dim Br As New SettingComplete

            curFinance.financeBankID = String.Empty

            curFinance.financeBranchID = String.Empty

            If bankName = String.Empty Then

                clearCombo("Bank")

                Exit Sub

            End If

            If cmbBank.SelectedIndex = -1 Then

                ba.settingGroupID = BankSettingID

                ba.settingID = Guid.NewGuid.ToString

                ba.settingName = bankName

                If SettingManager.AddSetting(ba) Then

                    Dim newItem As New Setting

                    newItem.settingValue = ba.settingID

                    newItem.settingName = ba.settingName

                    CType(cmbBank.DataSource, BindingSource).Add(newItem)

                    cmbBank.SelectedValue = ba.settingID

                    cmbBank.DisplayMember = "settingName"

                    cmbBank.ValueMember = "settingValue"

                End If

                If cmbBank.SelectedIndex = -1 Then

                    clearCombo("Bank")

                    Exit Sub

                End If

            End If

            If BranchName = String.Empty Then

                clearCombo("Branch")

                Exit Sub

            End If

            ba.settingID = cmbBank.SelectedValue

            If cmbBranch.SelectedIndex = -1 Then

                Br.settingGroupID = ba.settingID

                Br.settingName = BranchName

                Br.settingID = Guid.NewGuid.ToString

                If SettingManager.AddSetting(Br) Then

                    Dim newItem As New Setting

                    newItem.settingValue = Br.settingID

                    newItem.settingName = Br.settingName

                    If cmbBranch.DataSource Is Nothing Then

                        Dim b As New BindingSource

                        cmbBranch.DataSource = b

                    End If

                    CType(cmbBranch.DataSource, BindingSource).Add(newItem)

                    cmbBranch.SelectedValue = Br.settingID

                    cmbBranch.DisplayMember = "settingName"

                    cmbBranch.ValueMember = "settingValue"

                End If

                If cmbBranch.SelectedIndex = -1 Then

                    clearCombo("Branch")

                    Exit Sub

                End If

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("SaveBankList", ex.ToString(), Me.ParentForm.Text)

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
  
End Class
