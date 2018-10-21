Imports Lawyer.Common.VB.FileCaseArea
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB
Imports NwdSolutions.Web.GeneralUtilities
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Common
Imports Microsoft.Reporting.WinForms

Public Class UcFileCase

#Region "Reminder"

    ' openDate , Close Date , کنترل کردن مقادیر که عدد باشد , گرفتن تاریخ امروز
    ' و گرفتن اطلاعات از فرم دیگر  
    'بعد از ثبت موفق چه عملی انجام شود

#End Region

    Enum textBoxClick

        khahan = 4
        khande = 5
        vakil = 0
        expert = 1

    End Enum

    Private curFileCase As New FileCase
    Private parties As New FileParties.FilePartiesReviewCollection
    Private IsEditMode As Boolean = False
    Private PartiesBaseInfo As FileParties.FilePartiesAccessCollection
    Private IsClosed As Boolean = False
    Private DicMovakel As New Dictionary(Of String, String())
    Private DicKhande As New Dictionary(Of String, String())
    Private DicVakil As New Dictionary(Of String, String())
    Private DicExpert As New Dictionary(Of String, String())
    Private txtClick As textBoxClick
    Dim mouseLocation As Integer = -1
    Dim preMouseLocation As Integer = -1
    '' ''Dim lastActivity As String
    Dim IsEditAction As Boolean = False

    Delegate Sub _showSmsFormHandler(ByVal fileCaseID As String, ByVal timeID As String, ByVal dt As DataTable, ByVal smsText As String)
    Event _showSmsForm As _showSmsFormHandler

    Delegate Sub ShowContact(ByVal type As textBoxClick)
    Event ShowContactSearch As ShowContact

    Delegate Sub _showContactInformationHandler(ByVal custID As String)
    Event _showContactInformation As _showContactInformationHandler

    Delegate Sub _showReportHandler(ByVal _Dt As DataTable, ByVal _ReportDataSources As String, ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)
    Event _showReport As _showReportHandler

    Delegate Sub ContactDetailHandler(ByVal custId As String)
    Event ContactDetail As ContactDetailHandler

    Delegate Sub ShowConfirm(ByVal text As String, ByVal title As String)
    Event ShowMessageBox As ShowConfirm

    Private FileCaseKey As String = String.Empty
    Private DefaultMovakel As FileParties.FilePartiesAccess

    Public YesClicked As Boolean = False

#Region "Events"

#Region "LastActivity"

    'Private Function LastActivity_BeforeSave() As Boolean

    '    If txtLastActivity.Text.Trim = String.Empty Then

    '        lblMessage.Text = "توضیحات را وارد نمایید."
    '        Return False

    '    End If

    '    If Not txtDate.GetShamsiDateInNumericFormat.HasValue Then

    '        txtDate.SetToday = True

    '    End If

    '    Return True

    'End Function

    'Private Sub DataGridView1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    '    Try

    '        If e.Button = Windows.Forms.MouseButtons.Right Then

    '            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)

    '            If hti.Type = DataGridViewHitTestType.Cell Then

    '                mouseLocation = hti.RowIndex

    '            End If

    '            If mouseLocation <> -1 Then

    '                DataGridView1.ContextMenuStrip = ContextMenuStrip2

    '                DataGridView1.ContextMenuStrip.Show(DataGridView1, New Point(e.X, e.Y))

    '                mouseLocation = mouseLocation

    '                DataGridView1.Rows(mouseLocation).Selected = True

    '            Else

    '                DataGridView1.ContextMenuStrip = Nothing

    '            End If

    '        End If


    '    Catch ex As Exception

    '    End Try


    'End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    lblMessage.Text = String.Empty

    '    Dim preDate As String = String.Empty
    '    Dim preActivity = String.Empty

    '    Try

    '        If LastActivity_BeforeSave() Then

    '            Dim IsEditMode As Boolean = False


    '            If preMouseLocation <> -1 Then IsEditMode = True

    '            If IsEditMode Then

    '                preDate = DataGridView1.Rows(preMouseLocation).Cells(0).Value

    '                preActivity = DataGridView1.Rows(preMouseLocation).Cells(1).Value

    '                DataGridView1.Rows(preMouseLocation).Cells(0).Value = txtDate.GetShamsiDate()

    '                DataGridView1.Rows(preMouseLocation).Cells(1).Value = txtLastActivity.Text

    '            Else
    '                Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)

    '                Dim r As DataRow = dt.NewRow()

    '                r.Item(0) = txtDate.GetShamsiDate()

    '                r.Item(1) = txtLastActivity.Text

    '                dt.Rows.Add(r)

    '                DataGridView1.DataSource = dt

    '            End If

    '            Dim lastA As String = String.Empty

    '            For index As Integer = 0 To DataGridView1.Rows.Count - 1

    '                lastA &= ";""" & DataGridView1.Rows(index).Cells(0).Value & ";"""

    '                lastA &= DataGridView1.Rows(index).Cells(1).Value

    '            Next


    '            If Not FileCaseManager.EditLastAction(curFileCase.fileCaseID, lastA) Then

    '                If IsEditMode Then

    '                    DataGridView1.Rows(preMouseLocation).Cells(0).Value = preDate

    '                    DataGridView1.Rows(preMouseLocation).Cells(1).Value = preActivity

    '                Else

    '                    DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 1)

    '                End If

    '                Throw New Exception

    '            Else

    '                txtDate.SetToday = True

    '                txtLastActivity.Text = String.Empty

    '                SetDesignForEditLastActivity(False)

    '            End If

    '        End If


    '        '' ''If LastActivity_BeforeSave() Then

    '        '' ''    lastActivity &= ";""" & txtDate.GetShamsiDate() & ";""" & txtLastActivity.Text

    '        '' ''    If FileCaseManager.EditLastAction(curFileCase.fileCaseID, lastActivity) Then

    '        '' ''        Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)

    '        '' ''        Dim r As DataRow = dt.NewRow()

    '        '' ''        r.Item(0) = txtDate.GetShamsiDate()

    '        '' ''        r.Item(1) = txtLastActivity.Text

    '        '' ''        dt.Rows.Add(r)

    '        '' ''        DataGridView1.DataSource = dt

    '        '' ''        txtDate.SetToday = True

    '        '' ''        txtLastActivity.Text = String.Empty

    '        '' ''    Else
    '        '' ''        Throw New Exception

    '        '' ''    End If


    '        '' ''End If

    '    Catch ex As Exception

    '        lblMessage.Text = "خطا در ثبت"

    '        ErrorManager.WriteMessage("btnSave_Click", ex.ToString(), Me.ParentForm.Text)


    '    End Try

    'End Sub

    'Private Sub contextEditActivity_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    lblMessage.Text = String.Empty

    '    Try

    '        If mouseLocation <> -1 Then

    '            txtDate.SetShamsiDate(DataGridView1.Rows(mouseLocation).Cells(0).Value)

    '            txtLastActivity.Text = DataGridView1.Rows(mouseLocation).Cells(1).Value

    '            SetDesignForEditLastActivity(True)

    '            '''' temp

    '            '' ''Dim l As String = lastActivity

    '            '' ''lastActivity = String.Empty

    '            '' ''For index As Integer = 0 To DataGridView1.Rows.Count - 1

    '            '' ''    If index <> mouseLocation Then

    '            '' ''        lastActivity &= ";""" & DataGridView1.Rows(index).Cells(0).Value & ";"""

    '            '' ''        lastActivity &= DataGridView1.Rows(index).Cells(1).Value

    '            '' ''    End If

    '            '' ''Next

    '            '' ''If FileCaseManager.EditLastAction(curFileCase.fileCaseID, lastActivity) Then

    '            '' ''    txtDate.SetShamsiDate(DataGridView1.Rows(mouseLocation).Cells(0).Value)

    '            '' ''    txtLastActivity.Text = DataGridView1.Rows(mouseLocation).Cells(1).Value

    '            '' ''    DataGridView1.Rows.RemoveAt(mouseLocation)


    '            '' ''Else
    '            '' ''    lastActivity = l

    '            '' ''    txtDate.SetToday = True

    '            '' ''    txtLastActivity.Text = String.Empty

    '            '' ''End If


    '            '' ''preMouseLocation = mouseLocation

    '        End If

    '        mouseLocation = -1


    '    Catch ex As Exception

    '        SetDesignForEditLastActivity(False)

    '        ErrorManager.WriteMessage("contextEditActivity_Click_1", ex.ToString(), Me.ParentForm.Text)

    '    End Try


    'End Sub

    'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    SetDesignForEditLastActivity(False)

    'End Sub

    'Private Sub SetDesignForEditLastActivity(ByVal isBefore As Boolean)


    '    If isBefore Then

    '        preMouseLocation = mouseLocation

    '        btnCancel.Visible = True

    '        contextDelActivity.Enabled = False

    '        ToolTip1.SetToolTip(btnCancel, "انصراف")


    '    Else

    '        preMouseLocation = -1

    '        btnCancel.Visible = False

    '        txtDate.SetToday = True

    '        txtLastActivity.Text = String.Empty

    '        contextDelActivity.Enabled = True

    '    End If

    'End Sub

    'Private Sub contextDelActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    lblMessage.Text = String.Empty

    '    Try

    '        If mouseLocation <> -1 Then

    '            '' ''lastActivity = String.Empty

    '            '' ''For index As Integer = 0 To DataGridView1.Rows.Count - 1

    '            '' ''    If index <> mouseLocation Then

    '            '' ''        lastActivity &= ";""" & DataGridView1.Rows(index).Cells(0).Value & ";"""

    '            '' ''        lastActivity &= DataGridView1.Rows(index).Cells(1).Value

    '            '' ''    End If

    '            '' ''Next

    '            '' ''If FileCaseManager.EditLastAction(curFileCase.fileCaseID, lastActivity) Then

    '            '' ''    DataGridView1.Rows.RemoveAt(mouseLocation)

    '            '' ''End If

    '            Dim lastA As String = String.Empty

    '            For index As Integer = 0 To DataGridView1.Rows.Count - 1

    '                lastA &= ";""" & DataGridView1.Rows(index).Cells(0).Value & ";"""

    '                lastA &= txtLastActivity.Text = DataGridView1.Rows(mouseLocation).Cells(1).Value

    '            Next

    '            If FileCaseManager.EditLastAction(curFileCase.fileCaseID, lastA) Then

    '                DataGridView1.Rows.RemoveAt(mouseLocation)

    '            End If


    '        End If

    '        mouseLocation = -1


    '    Catch ex As Exception
    '        ErrorManager.WriteMessage("contextDelActivity_Click", ex.ToString(), Me.ParentForm.Text)
    '    End Try

    'End Sub

    'Private Sub BindLastActivity(ByVal actions As String)

    '    Dim text() As String = actions.Split(New String() {";"""}, StringSplitOptions.RemoveEmptyEntries)

    '    Dim b As New DataTable

    '    b.Columns.Add("ActionDate")

    '    b.Columns.Add("ActionText")

    '    Try
    '        For index As Integer = 0 To CInt(text.Length / 2) - 1

    '            Dim r As DataRow = b.NewRow()

    '            r.Item(0) = text(2 * index)

    '            r.Item(1) = text(2 * index + 1)

    '            b.Rows.Add(r)

    '        Next

    '    Catch ex As Exception

    '    End Try


    '    DataGridView1.DataSource = b

    '    txtDate.SetToday = True

    '    '' ''lastActivity = actions

    'End Sub

#End Region
    'Private Sub DataGridView1_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter



    'End Sub

    'Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
    '    DataGridView1.Rows(mouseLocation).Selected = False

    '    mouseLocation = e.RowIndex

    '    DataGridView1.Rows(e.RowIndex).Selected = True
    'End Sub

    '' ''Private Sub btnSaveDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '' ''    lblMessage.Text = String.Empty

    '' ''    Try

    '' ''        If FileCaseManager.EditOtherDescription(curFileCase.fileCaseID, txtOtherDescription.Text) Then

    '' ''            curFileCase.fileCaseOtherDescription = txtOtherDescription.Text


    '' ''            lblMessage.Text = "توضیحات ثبت شد."

    '' ''        Else

    '' ''            txtOtherDescription.Text = curFileCase.fileCaseOtherDescription

    '' ''            Throw New Exception

    '' ''        End If


    '' ''    Catch ex As Exception

    '' ''        lblMessage.Text = "خطا در ثبت"

    '' ''        ErrorManager.WriteMessage("btnSaveDesc_Click", ex.ToString(), Me.ParentForm.Text)

    '' ''    End Try

    '' ''End Sub

    Private Sub cmbResult_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbResult.SelectedIndexChanged
        Try


            Select Case cmbResult.SelectedIndex
                Case 0
                    'قرار
                    pnlMablagh.Visible = False

                Case 1

                    pnlMablagh.Visible = True

                Case Else

                    pnlMablagh.Visible = False

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveResult.Click

        lblMessage.Text = String.Empty

        Try

            Dim result As New FileCaseResult

            result.fileCaseID = curFileCase.fileCaseID

            If cmbResult.SelectedIndex <> -1 Then

                result.fileCaseResult = cmbResult.SelectedIndex

                If cmbResultDetail.SelectedIndex <> -1 Then

                    result.filecaseResultDetail = cmbResultDetail.SelectedIndex

                End If

            Else

                cmbResultDetail.SelectedIndex = -1

            End If


            result.fileCaseGhararType = txtfileCaseGhararType.Text

            'End If

            If cmbResult.SelectedIndex = 1 AndAlso txtMablagh.Amount <> 0 Then

                result.fileCaseCost = CDbl(txtMablagh.Amount)

            End If


            If FileCaseManager.EditResult(result) Then

                curFileCase.fileCaseResult = result.fileCaseResult

                curFileCase.filecaseResultDetail = result.filecaseResultDetail

                curFileCase.fileCaseGhararType = result.fileCaseGhararType

                lblMessage.Text = "نتیجه پرونده ذخیره شد."

            Else

                BindResult()

            End If


        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت"

            ErrorManager.WriteMessage("btnSaveResult_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub txtMovakel_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMovakel.MouseEnter

        txtClick = textBoxClick.khahan

    End Sub

    Private Sub txtKhande_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKhande.MouseEnter


        txtClick = textBoxClick.khande

    End Sub

    Private Sub txtVakil_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVakil.MouseEnter


        txtClick = textBoxClick.vakil

    End Sub

    Private Sub txtExpert_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExpert.MouseEnter

        txtClick = textBoxClick.expert

    End Sub

    Private Sub txtMovakel_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMovakel.DragEnter, txtVakil.DragEnter, txtExpert.DragEnter, txtKhande.DragEnter
        Try

            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtVakil_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtVakil.DragDrop

        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim contact() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In contact
                    ''abbas
                    ''If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.وکیل AndAlso Not DicVakil.Key.Contains(item.SubItems(1).Text) Then
                    If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.وکیل AndAlso Not DicVakil.Keys.Equals(item.SubItems(1).Text) Then

                        DicVakil.Add(item.SubItems(1).Text, New String() {item.Text, "1"})

                        If txtVakil.Text <> String.Empty Then txtVakil.Text += ";"

                        txtVakil.Text += item.Text

                    End If

                Next

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("txtVakil_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub txtExpert_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtExpert.DragDrop
        Try


            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim contact() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In contact
                    'abbas
                    ''If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.کارشناس AndAlso Not DicExpert.Keys.Contains(item.SubItems(1).Text) Then
                    If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.کارشناس AndAlso Not DicExpert.Keys.Equals(item.SubItems(1).Text) Then

                        DicExpert.Add(item.SubItems(1).Text, New String() {item.Text, "0"})

                        If txtExpert.Text <> String.Empty Then txtExpert.Text += ";"
                        txtExpert.Text += item.Text

                    End If

                Next

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("txtExpert_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub txtMovakel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMovakel.DragDrop
        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim contact() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In contact
                    ''abbas
                    ''If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.موکل AndAlso Not DicMovakel.Keys.Contains(item.SubItems(1).Text) Then
                    If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.موکل AndAlso Not DicMovakel.Keys.Equals(item.SubItems(1).Text) Then

                        DicMovakel.Add(item.SubItems(1).Text, New String() {item.Text, "0"})

                        If txtMovakel.Text <> String.Empty Then txtMovakel.Text += ";"

                        txtMovakel.Text += item.Text

                    End If

                Next

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("txtMovakel_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try
    End Sub

    Private Sub txtKhande_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtKhande.DragDrop
        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim contact() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In contact
                    ''abbas
                    ''If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.دعوی AndAlso Not DicKhande.Keys.Contains(item.SubItems(1).Text) Then
                    If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.دعوی AndAlso Not DicKhande.Keys.Equals(item.SubItems(1).Text) Then

                        DicKhande.Add(item.SubItems(1).Text, New String() {item.Text, "0"})

                        If txtKhande.Text <> String.Empty Then txtKhande.Text += ";"

                        txtKhande.Text += item.Text

                    End If

                Next

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("txtKhande_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        RaiseEvent ShowComptency()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        lblMessage.Text = String.Empty

        If txtNoInSystem.Text.Trim <> String.Empty AndAlso txtNoInSystem.Text.Trim <> curFileCase.fileCaseNumberInSystem AndAlso FileCaseManager.IsExitsFileCaseNoInSystem(txtNoInSystem.Text) Then

            lblMessage.Text = "شماره پرونده تکراری می باشد"

            txtNoInSystem.Focus()

            Exit Sub

        End If

        '' ''If txtYear.Text.Length > 0 AndAlso txtYear.Text.Length < 2 Then

        '' ''    lblMessage.Text = "عدد سال موجود در شماره پرونده را به درستی وارد نمایید. "

        '' ''    txtYear.Focus()

        '' ''    Exit Sub

        '' ''End If
        'SaveFileCaseArea()


        curFileCase.fileCaseCat = Enums.FileCaseCat.معاضدتی

        If rdbCat0.Checked Then
            curFileCase.fileCaseCat = Enums.FileCaseCat.عادی

        ElseIf rdbCat1.Checked Then
            curFileCase.fileCaseCat = Enums.FileCaseCat.تسخیری

        End If


        If Not txtOpenDate.GetShamsiDateInNumericFormat().HasValue Then

            txtOpenDate.SetToday = True

        End If

        curFileCase.fileCaseOpenDate = txtOpenDate.GetShamsiDateInNumericFormat()

        curFileCase.fileCaseComplainant = Enums.FileCaseComplainant.خواهان

        If rdbComplainant1.Checked Then curFileCase.fileCaseComplainant = Enums.FileCaseComplainant.خوانده

        curFileCase.fileCaseDescription = NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtDesciption.Text)

        curFileCase.fileCaseNumberInSystem = NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtNoInSystem.Text)

        curFileCase.fileCaseNumberInCourt = NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtNoInCourt.Text)

        curFileCase.fileCaseSubject = NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim())

        curFileCase.fileCaseNumberInBranch = NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtNoBranchCurt.Text)

        '' ''curFileCase.fileCaseNumberYear = txtYear.Text

        If (Not curFileCase.fileCaseType AndAlso rdbType1.Checked) OrElse (curFileCase.fileCaseType AndAlso rdbType0.Checked) Then
            'تغییر فایلهای پیش فرض
            FileCaseManager.WriteDefaultFiles(IIf(rdbType0.Checked, Enums.FileCaseStep.حقوقی, Enums.FileCaseStep.کیفری), True, curFileCase.fileCaseID)

        End If

        If rdbType1.Checked Then

            curFileCase.fileCaseType = Enums.FileCaseType.کیفری

        Else

            curFileCase.fileCaseType = Enums.FileCaseType.حقوقی

        End If

        If cmbFileCaseStep.SelectedValue <> curFileCase.fileCaseStep.ToString() Then

            curFileCase.fileCaseStep = cmbFileCaseStep.SelectedValue

            'تغییر فایلهای پیش فرض
            FileCaseManager.WriteDefaultFiles(curFileCase.fileCaseStep, True, curFileCase.fileCaseID)

        End If



        curFileCase.fileCasePass = SecurityHelper.Encrypt(txtPass.Text.Trim(), FileCaseKey)

        Try
            If FileCaseManager.EditFileCase(curFileCase) Then

                ''''write default files


                'SetPayaneh()

                If Me.txtSubject.Text.Trim() <> String.Empty AndAlso Me.txtSubject.AutoCompleteCustomSource.IndexOf(Me.txtSubject.Text) <> -1 Then
                    BindSubject()
                End If


                If FileParties.FilePartiesManager.DelPartiesByFileCaseID(curFileCase.fileCaseID) Then
                    SaveFileParties()
                End If

                lblMessage.Text = "مشخصات پرونده ذخیره شد."


                If Lawyer.Common.VB.SmsManager.getSmsConfig() = True Then
                    ''abbas send sms
                    Dim orgName As String = ""
                    If Lawyer.Common.VB.Setting.SettingManager.GetSettingsByName("smsorgname").Count > 0 Then orgName = Lawyer.Common.VB.Setting.SettingManager.GetSettingsByName("smsorgname")(0).settingValue

                    RaiseEvent _showSmsForm(curFileCase.fileCaseID, Nothing, Nothing, String.Format("با سلام پرونده شما به شماره {0} ثبت گردید  با تشکر {1}", curFileCase.fileCaseNumberInSystem, orgName))
                End If
               

                ''show label bottun
                btnPrintLebel.Visible = True

            Else

                lblMessage.Text = "خطا در ذخیره مشخصات"

            End If



        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت"

            ErrorManager.WriteMessage("btnEdit_Click", ex.ToString(), Me.ParentForm.Text)

        End Try


    End Sub

    Private Sub WriteDefaultFiles()

        ''''stepCase


        Select Case curFileCase.fileCaseStep

            Case 0

                'بدوی ====> چک لیست بدوی
                '56b11846-9e86-407f-86e6-d9fb3db82f5d

            Case 1
                'تجدید نظر====> چک لیست تجدید نظر
                'f298a569-3929-404c-ab8f-4c0ce2377f92


        End Select



        ''''FilecaseType
        'کیفری====> خلاصه وضعیت دادسرا و 
        '87c3e0be-6b58-49b2-b546-595e73588321
        'خلاصه وضعیت جزئی
        '7ab9b404-5b8f-45d8-a572-d80ca0d7604f
        'حقوقی ====> خلاصه وضعیت حقوقی
        '4bd40597-b4af-4b91-8b36-6f0ed42a67c0

        'تحقیق از موکل
        '9ca2c1df-ed2c-4c69-99b4-4414004858bd

        'وكالت نامه و قرارداد
        '1f76af57-8ac6-49cb-a6ca-465263e5bbae


    End Sub

    Private Sub ToolStripDelParties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripDelParties.Click

        Try

            Select Case txtClick

                Case textBoxClick.expert

                    txtExpert.Text = ""

                    DicExpert.Clear()

                Case textBoxClick.khahan

                    txtMovakel.Text = ""

                    DicMovakel.Clear()

                    'abbas default movakel
                    'If DefaultMovakel IsNot Nothing Then

                    '    txtMovakel.Text = DefaultMovakel.custFullName

                    '    DicMovakel.Add(DefaultMovakel.contactInfoID, New String() {DefaultMovakel.custFullName, DefaultMovakel.financeAccess.ToString()})

                    'End If

                Case textBoxClick.khande

                    txtKhande.Text = ""

                    DicKhande.Clear()

                Case Else

                    txtVakil.Text = ""

                    DicVakil.Clear()

            End Select

        Catch ex As Exception

        End Try


    End Sub

    Private Sub tsMenuContactEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent ShowContactSearch(txtClick)
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged

        Try

            If CType(sender, CheckBox).Checked Then

                pnlMakhtume.Visible = False

                txtClosedDate.ResetDate()

                txtClosedDate.ReadOnlyDate = True

            Else

                ' cmbResultDetail1.SelectedIndex = 0

                pnlMakhtume.Visible = True

                If curFileCase.fileCaseCloseDate.HasValue Then

                    txtClosedDate.SetShamsiDateInNumericFormat(curFileCase.fileCaseCloseDate)

                Else

                    txtClosedDate.SetToday = True

                End If

                txtClosedDate.ReadOnlyDate = False

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub SetPayaneh()

        Try
            Dim pas As String = SecurityHelper.Decrypt(curFileCase.fileCasePass, FileCaseKey)

            txtPass.Text = pas



        Catch ex As Exception

        End Try

    End Sub

    Private Sub FileCase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        ' set Comboboxes

        '' ''cmbHoze.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '' ''cmbMojtame.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '' ''cmbShobe.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        '' ''cmbHoze.AutoCompleteSource = AutoCompleteSource.ListItems
        '' ''cmbMojtame.AutoCompleteSource = AutoCompleteSource.ListItems
        '' ''cmbShobe.AutoCompleteSource = AutoCompleteSource.ListItems

        'SetCombo()

        '' ''cmbMojtame.DataSource = AreaManger.GetFileChildsByParentID(String.Empty)

        'set subject

        btnPrintLebel.Visible = False


        ToolTip1.SetToolTip(btnSearch, "انتخاب مرجع قضایی")

        'ToolTip1.SetToolTip(btnCancel, "انصراف")

        ToolTip1.SetToolTip(btnFVakil, "دسترسی مالی")

        lblMessage.Text = String.Empty

        BindSubject()

        BindFileCaseSteps()

    End Sub

    Private Sub SetDesignForFinanceAccess()

        If Login.CurrentLogin.CurrentUser.IsAdmin OrElse FileParties.FilePartiesManager.UserHasFinanceAccess(curFileCase.fileCaseID, Login.CurrentLogin.CurrentUser.UserID, FileParties.Enums.FileCaseRole.وکیل) Then

            btnFVakil.Visible = True
            Exit Sub

        End If

        btnFVakil.Visible = False

    End Sub

    Private Sub txtMovakel_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMovakel.MouseDoubleClick, txtVakil.MouseDoubleClick, txtExpert.MouseDoubleClick, txtKhande.MouseDoubleClick
        RaiseEvent ShowContactSearch(txtClick)
    End Sub

    Private Sub txtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)


        lblMessage.Text = String.Empty

        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If

    End Sub

    Private Sub btnSaveStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveStatus.Click

        lblMessage.Text = String.Empty

        Try

            If Not chkStatus.Checked Then

                If Not txtClosedDate.GetShamsiDateInNumericFormat.HasValue Then

                    txtClosedDate.SetToday = True

                End If

                curFileCase.fileCaseCloseDate = txtClosedDate.GetShamsiDateInNumericFormat()

            Else
                curFileCase.fileCaseOtherDescription = String.Empty

                curFileCase.fileCaseCloseDate = Nothing

            End If

            ''If Not cmbResultDetail1.Visible Then

            ''    curFileCase.filecaseResultDetail = Nothing

            ''Else

            curFileCase.filecaseResultDetail = txtParvandeRz.Text

            'End If

            curFileCase.fileCaseOtherDescription = txtOtherDescription.Text

            If FileCaseManager.EditOtherDescription(curFileCase.fileCaseID, curFileCase) Then

                If IsClosed AndAlso chkStatus.Checked Then
                    'تبدیل به جاری
                    FileDocManager.UpdateFileImage(curFileCase.fileID, BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده))

                ElseIf Not IsClosed AndAlso Not chkStatus.Checked Then
                    ' تبدیل به مختومه
                    FileDocManager.UpdateFileImage(curFileCase.fileID, BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده_مختومه))

                End If


                If FileParties.FilePartiesManager.DelPartiesByFileCaseID(curFileCase.fileCaseID) Then

                    SaveFileParties()

                End If

            End If

            lblMessage.Text = "وضعیت پرونده ذخیره شد."

        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت"

            ErrorManager.WriteMessage("btnSaveStatus_Click", ex.ToString(), Me.ParentForm.Text)


        End Try


    End Sub

    Private Sub txtMovakel_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMovakel.Enter
        UcContacts1.Focus()
    End Sub
    Private Sub txtMovakel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMovakel.KeyPress
        txtMovakelAddContact()
    End Sub

    Private Sub txtMovakelAddContact()
        UcContacts1.Focus()

        Dim r As ContactInfo.Enums.RoleType = ContactInfo.Enums.RoleType.موکل

        r = ContactInfo.Enums.RoleType.موکل
        UcContacts1.BindContacts(ucContacts.SearchType.role, r, txtMovakel.Location + New Point(0, 19), Nothing, txtMovakel.Name)
    End Sub

    Private Sub txtKhande_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKhande.KeyPress
        txtKhandeAddContact()
    End Sub
    Private Sub txtKhandeAddContact()
        UcContacts1.Focus()

        Dim r As ContactInfo.Enums.RoleType = ContactInfo.Enums.RoleType.موکل
        r = ContactInfo.Enums.RoleType.دعوی
        UcContacts1.BindContacts(ucContacts.SearchType.role, r, txtKhande.Location + New Point(0, 19), Nothing, txtKhande.Name)
    End Sub
    Private Sub txtVakil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVakil.KeyPress
        txtvakilAddContact()
    End Sub
    Private Sub txtvakilAddContact()
        UcContacts1.Focus()

        Dim r As ContactInfo.Enums.RoleType = ContactInfo.Enums.RoleType.موکل

        Dim mixRole As String
        mixRole = " where (custType =" & ContactInfo.Enums.RoleType.وکیل & " Or custType =" & ContactInfo.Enums.RoleType.کارآموز & ")"
        UcContacts1.BindContacts(ucContacts.SearchType.role, mixRole, txtVakil.Location + New Point(0, 19), Nothing, txtVakil.Name, "nokodSiah")

    End Sub
    Private Sub txtExpert_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExpert.KeyPress
        txtExpertAddContact()
    End Sub
    Private Sub txtExpertAddContact()
        UcContacts1.Focus()

        Dim r As ContactInfo.Enums.RoleType = ContactInfo.Enums.RoleType.موکل

        r = ContactInfo.Enums.RoleType.کارشناس
        UcContacts1.BindContacts(ucContacts.SearchType.role, r, txtExpert.Location + New Point(0, 19), Nothing, txtExpert.Name)

    End Sub

    Private Sub showContactInfo(ByVal custID As String) Handles UcContacts1.showContactInfo
        RaiseEvent _showContactInformation(custID)
    End Sub

    Private Sub txtPass_Enter(sender As Object, e As EventArgs) Handles txtPass.Enter
        txtPass.Text = String.Empty

    End Sub

    Private Sub btnAddMovakkel_Click(sender As Object, e As EventArgs) Handles btnAddMovakkel.Click
        txtMovakelAddContact()
    End Sub
    Private Sub btnTarafDavi_Click(sender As Object, e As EventArgs) Handles btnTarafDavi.Click
        txtKhandeAddContact()
    End Sub
    Private Sub btnVakil_Click(sender As Object, e As EventArgs) Handles btnVakil.Click
        txtvakilAddContact()
    End Sub

    Private Sub btnKarshenas_Click(sender As Object, e As EventArgs) Handles btnKarshenas.Click
        txtExpertAddContact()
    End Sub
    Private Sub UcContacts1_ContactAdd(ByVal c As Lawyer.Common.VB.ContactInfo.ContactInfoReview) Handles UcContacts1.ContactAdd

        Try


            Select Case UcContacts1.RefTextBox

                Case "txtExpert"
                    ''abbas
                    ''If Not DicExpert.Keys.Contains(c.custID) Then
                    If Not DicExpert.Keys.Equals(c.custID) Then

                        DicExpert.Add(c.custID, New String() {c.custFullName, "0"})

                        If txtExpert.Text <> String.Empty Then txtExpert.Text += ";"

                        txtExpert.Text += c.custFullName

                        Me.Refresh()

                        txtExpert.Focus()

                    End If

                Case "txtVakil"
                    ''abbas
                    ''If Not DicVakil.Keys.Contains(c.custID) Then
                    If Not DicVakil.Keys.Equals(c.custID) Then

                        DicVakil.Add(c.custID, New String() {c.custFullName, "1"})

                        If txtVakil.Text <> String.Empty Then txtVakil.Text += ";"

                        txtVakil.Text += c.custFullName

                        Me.Refresh()

                        txtVakil.Focus()

                    End If

                Case "txtKhande"
                    ''abbas
                    ''If Not DicKhande.Keys.Contains(c.custID) Then
                    If Not DicKhande.Keys.Equals(c.custID) Then

                        DicKhande.Add(c.custID, New String() {c.custFullName, "0"})

                        If txtKhande.Text <> String.Empty Then txtKhande.Text += ";"

                        txtKhande.Text += c.custFullName

                        Me.Refresh()

                        txtKhande.Focus()

                    End If

                Case "txtMovakel"
                    ''abbas
                    ''If Not DicMovakel.Keys.Contains(c.custID) Then
                    If Not DicMovakel.Keys.Equals(c.custID) Then

                        DicMovakel.Add(c.custID, New String() {c.custFullName, "0"})

                        If txtMovakel.Text <> String.Empty Then txtMovakel.Text += ";"

                        txtMovakel.Text += c.custFullName

                        Me.Refresh()

                        txtMovakel.Focus()

                    End If

            End Select

            UcContacts1.Hide()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub UcContacts1_ContactDetail(ByVal custId As String) Handles UcContacts1.ContactDetail

        lblMessage.Text = String.Empty

        RaiseEvent ContactDetail(custId)

        UcContacts1.RefreshContacts()

    End Sub

    Private Sub UcContacts1_ShowConfirm() Handles UcContacts1.ShowConfirm

        lblMessage.Text = String.Empty

        Try

            YesClicked = False

            RaiseEvent ShowMessageBox("فردی با نام مورد نظر یافت نشد، آیا می خواهید به عنوان فرد جدید در سیستم ثبت شود؟ ", "فرد جدید")

            UcContacts1.YesClicked = YesClicked

        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت موکل جدید"

            ErrorManager.WriteMessage("UcContacts1_ShowConfirm", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub btnFVakil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFVakil.Click
        SetFinanceAccess()
    End Sub

    Private Sub SetFinanceAccess()

        Try
            lblMessage.Text = String.Empty

            Dim f As WFControls.CS.BaseUc.frmPropertyMsg

            f = New WFControls.CS.BaseUc.frmPropertyMsg(DicVakil, " دسترسی مالی برای وکلا", "دسترسی مالی")

            f.ShowDialog()

            Dim copyItem As Dictionary(Of String, String) = f.GetResult()

            If copyItem Is Nothing Then

                Exit Sub

            Else

                Try

                    For Each Item As String In copyItem.Keys

                        DicVakil.Item(Item)(1) = copyItem.Item(Item)

                    Next

                Catch ex As Exception

                End Try

                If FileParties.FilePartiesManager.DelPartiesByFileCaseID(curFileCase.fileCaseID) Then

                    SaveFileParties()

                Else

                    lblMessage.Text = "خطا در ایجاد دسترسی"

                End If

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("SetFinanceAccess", ex.ToString(), Me.ParentForm.Text)

        End Try


    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        lblMessage.Text = String.Empty
    End Sub

#End Region

#Region "Utility"

    Private Sub BindResult()

        '----سایر توضیحات
        txtOtherDescription.Text = curFileCase.fileCaseOtherDescription

        '' ''If curFileCase.fileCaseResult.HasValue Then

        '' ''    cmbResult.SelectedIndex = curFileCase.fileCaseResult

        '' ''    If curFileCase.fileCaseResult = 0 Then

        '' ''        pnlMablagh.Visible = False

        '' ''    End If

        '' ''Else
        '' ''    pnlMablagh.Visible = False

        '' ''End If

        '' ''If curFileCase.filecaseResultDetail.HasValue Then

        '' ''    cmbResultDetail.SelectedIndex = curFileCase.filecaseResultDetail

        '' ''Else

        '' ''    cmbResult.SelectedIndex = -1

        '' ''End If


        '' ''BindGhararType()


        '' ''txtfileCaseGhararType.Text = curFileCase.fileCaseGhararType


        '' ''If curFileCase.fileCaseCost.HasValue Then

        '' ''    If curFileCase.fileCaseCost.ToString() <> String.Empty Then
        '' ''        txtMablagh.Amount = CDbl(curFileCase.fileCaseCost.ToString())
        '' ''    End If


        '' ''Else

        '' ''    txtMablagh.Reset()

        '' ''End If

    End Sub


    Delegate Sub ShowForm()

    Event ShowComptency As ShowForm

    Public Sub SetSalahiyat(ByVal param As Competencys.CompetencyOnGrid)

        Try

            If param IsNot Nothing Then

                If param.tsid <> Guid.Empty Then

                    curFileCase.fileCaseAreaID = param.tsid.ToString()

                    curFileCase.fileCaseSubAreaID = String.Empty

                    txtSalahiat.Text = param.tsState

                    If param.tsProvince <> String.Empty Then

                        txtSalahiat.Text &= " - " & param.tsProvince

                    End If

                    If param.tsName <> String.Empty Then

                        txtSalahiat.Text &= " - " & " حوزه : " & param.tsName

                    End If

                    If param.tsbID <> Guid.Empty Then

                        If param.tsbName <> String.Empty Then

                            txtSalahiat.Text &= " - " & param.tsbName

                        End If

                        curFileCase.fileCaseSubAreaID = param.tsbID.ToString

                    End If

                End If

            End If

        Catch ex As Exception

            txtSalahiat.Text = String.Empty

            curFileCase.fileCaseAreaID = String.Empty

            curFileCase.fileCaseSubAreaID = String.Empty

            ErrorManager.WriteMessage("SetSalahiyat, Competencys.CompetencyOnGri", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Public Sub SetSalahiyat(ByVal areaID As String, ByVal subArea As String)

        Try

            If areaID <> String.Empty Then

                Dim co As Competencys.Competency = Competencys.CompetencyManager.GetCompetencyByLibID(areaID)

                If co IsNot Nothing Then

                    curFileCase.fileCaseAreaID = areaID.ToString()

                    curFileCase.fileCaseSubAreaID = String.Empty

                    txtSalahiat.Text = co.tsState

                    If co.tsProvince <> String.Empty Then

                        txtSalahiat.Text &= " - " & co.tsProvince

                    End If

                    If co.tsName <> String.Empty Then

                        txtSalahiat.Text &= " - " & " حوزه : " & co.tsName

                    End If

                    If subArea <> String.Empty Then

                        Dim br As Competencys.CompetencyBranchReview = Competencys.CompetencyManager.GetToolsSalahiatBranchById(subArea)

                        If br IsNot Nothing Then

                            'If br.tsbType = 0 AndAlso br.tsbName <> String.Empty Then


                            If br.tsbName <> String.Empty Then

                                txtSalahiat.Text &= " - " & CType(br.tsbType, Competencys.Enums.tsbType).ToString() & " : " & br.tsbName

                            End If

                            curFileCase.fileCaseSubAreaID = subArea.ToString()

                        End If

                    End If

                End If

            End If


        Catch ex As Exception

            txtSalahiat.Text = String.Empty

            curFileCase.fileCaseAreaID = String.Empty

            curFileCase.fileCaseSubAreaID = String.Empty

            ErrorManager.WriteMessage("SetSalahiyat", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Public Sub SetFileCase(ByVal fileCaseId As String, ByVal key As String)

        Try
            FileCaseKey = key

            curFileCase = FileCaseManager.GetFileCaseByID(fileCaseId)

            Try

                SetPayaneh()

            Catch ex As Exception

            End Try

            curFileCase.fileCaseID = fileCaseId

            PartiesBaseInfo = FileParties.FilePartiesManager.GetPartiesAccessByFileCaseID(fileCaseId)

            BindElements()

            'BindLastActivity(curFileCase.fileCaseLastAction)

            '' ''If txtYear.Text = String.Empty Then txtYear.Text = Common.DateManager.GetCurrentYear().Substring(2, 2)

            'آیا مجوز ورود دارد؟
            SetDesignForFinanceAccess()

        Catch ex As Exception

            ErrorManager.WriteMessage("SetFileCase", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub BindSubject()

        Try

            txtSubject.AutoCompleteCustomSource = FileCaseManager.GetAllFileCaseSubjects()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub BindFileCaseSteps()

        Try

            cmbFileCaseStep.DataSource = FileCaseManager.GetFileCaseSteps(True)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub BindGhararType()

        Try

            txtfileCaseGhararType.AutoCompleteCustomSource = FileCaseManager.GetAllFileCaseGhararType()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub SaveFileParties()
        Dim pr As ContactInfo.Enums.custPriority

        'خوانده
        If chkStatus.Checked Then
            pr = ContactInfo.Enums.custPriority.davi
        Else
            pr = ContactInfo.Enums.custPriority.Davi_M
        End If

        FileParties.FilePartiesManager.AddParties(DicKhande, curFileCase.fileCaseID, curFileCase.fileID, FileParties.Enums.FileCaseRole.خوانده, pr)


        If chkStatus.Checked Then
            pr = ContactInfo.Enums.custPriority.movakel
        Else
            pr = ContactInfo.Enums.custPriority.movakel_M
        End If
        'موکل
        FileParties.FilePartiesManager.AddParties(DicMovakel, curFileCase.fileCaseID, curFileCase.fileID, FileParties.Enums.FileCaseRole.خواهان, pr)

        'وکیل

        pr = ContactInfo.Enums.custPriority.vakil


        FileParties.FilePartiesManager.AddParties(DicVakil, curFileCase.fileCaseID, curFileCase.fileID, FileParties.Enums.FileCaseRole.وکیل, pr)
        'کارشناس

        FileParties.FilePartiesManager.AddParties(DicExpert, curFileCase.fileCaseID, curFileCase.fileID, FileParties.Enums.FileCaseRole.کارشناس, pr)

    End Sub

    Private Sub BindFileCaseStep()

        Try

            cmbFileCaseStep.SelectedValue = curFileCase.fileCaseStep.ToString()

        Catch ex As Exception

        End Try

        '' ''Select Case curFileCase.fileCaseStep
        '' ''    Case 0
        '' ''        txtFileCaseType.Text = "بدوی"
        '' ''    Case 1
        '' ''        txtFileCaseType.Text = "تجدید نظر"
        '' ''    Case 2
        '' ''        txtFileCaseType.Text = "دعوی مقابل"
        '' ''    Case 3
        '' ''        txtFileCaseType.Text = "دعوی جلب ثالث"
        '' ''    Case 4
        '' ''        txtFileCaseType.Text = "درخواست اعاده"
        '' ''    Case 5
        '' ''        txtFileCaseType.Text = "دعوی ورود ثالث"
        '' ''    Case 6
        '' ''        txtFileCaseType.Text = "دعوی اعتراض ثالث"
        '' ''    Case 7
        '' ''        txtFileCaseType.Text = "فرجام"
        '' ''    Case 8
        '' ''        txtFileCaseType.Text = "اجرای احکام"
        '' ''    Case 9
        '' ''        txtFileCaseType.Text = "مرحله دادسرا"

        '' ''End Select

    End Sub

    Private Sub BindElements()


        BindFileCaseStep()

        If curFileCase.fileCaseComplainant = CBool(Enums.FileCaseComplainant.خوانده) Then
            rdbComplainant1.Checked = True
        Else
            rdbComplainant0.Checked = True
        End If


        If curFileCase.fileCaseType = CBool(Enums.FileCaseType.کیفری) Then
            rdbType1.Checked = True
        Else
            rdbType0.Checked = True
        End If


        Select Case curFileCase.fileCaseCat
            Case Enums.FileCaseCat.عادی
                rdbCat0.Checked = True
            Case Enums.FileCaseCat.تسخیری
                rdbCat1.Checked = True
            Case Else
                rdbCat2.Checked = True
        End Select

        If curFileCase.fileCaseNumberInSystem = String.Empty Then
            curFileCase.fileCaseNumberInSystem = FileCaseManager.GetMaxFileCaseNoInSystem()
        End If
        txtNoInSystem.Text = curFileCase.fileCaseNumberInSystem

        txtNoInCourt.Text = curFileCase.fileCaseNumberInCourt

        If curFileCase.fileCaseCloseDate.HasValue Then
            chkStatus.Checked = False
            txtClosedDate.SetShamsiDateInNumericFormat(curFileCase.fileCaseCloseDate)
            IsClosed = True
            pnlMakhtume.Visible = True

            txtParvandeRz.Text = curFileCase.filecaseResultDetail
        Else
            chkStatus.Checked = True

            txtClosedDate.ResetDate()

        End If

        Dim m As String = FileDocManager.GetFileCustId(curFileCase.fileID)

        For Each Item As FileParties.FilePartiesAccess In PartiesBaseInfo
            Select Case Item.fileCaseRole

                Case FileParties.Enums.FileCaseRole.خوانده

                    If Not DicKhande.ContainsKey(Item.contactInfoID) Then
                        txtKhande.Text += ";" & Item.custFullName
                        DicKhande.Add(Item.contactInfoID, New String() {Item.custFullName, Item.financeAccess.ToString()})

                    End If
                Case FileParties.Enums.FileCaseRole.خواهان

                    If Not DicMovakel.ContainsKey(Item.contactInfoID) Then

                        If m <> String.Empty AndAlso m = Item.contactInfoID Then
                            DefaultMovakel = Item
                        End If

                        txtMovakel.Text += ";" & Item.custFullName
                        DicMovakel.Add(Item.contactInfoID, New String() {Item.custFullName, Item.financeAccess.ToString()})

                    End If
                Case FileParties.Enums.FileCaseRole.کارشناس

                    If Not DicExpert.ContainsKey(Item.contactInfoID) Then

                        txtExpert.Text += ";" & Item.custFullName
                        DicExpert.Add(Item.contactInfoID, New String() {Item.custFullName, Item.financeAccess.ToString()})

                    End If
                Case FileParties.Enums.FileCaseRole.وکیل
                    If Not DicVakil.ContainsKey(Item.contactInfoID) Then
                        txtVakil.Text += ";" & Item.custFullName
                        DicVakil.Add(Item.contactInfoID, New String() {Item.custFullName, Item.financeAccess.ToString()})

                    End If
            End Select
        Next
        If txtKhande.Text <> String.Empty Then
            txtKhande.Text = txtKhande.Text.Substring(1)
        End If
        If txtMovakel.Text <> String.Empty Then
            txtMovakel.Text = txtMovakel.Text.Substring(1)
        End If
        If txtExpert.Text <> String.Empty Then
            txtExpert.Text = txtExpert.Text.Substring(1)
        End If
        If txtVakil.Text <> String.Empty Then
            txtVakil.Text = txtVakil.Text.Substring(1)
        End If

        '' ''txtYear.Text = curFileCase.fileCaseNumberYear

        txtNoBranchCurt.Text = curFileCase.fileCaseNumberInBranch

        txtOpenDate.SetShamsiDate(curFileCase.fileCaseOpenDate)

        txtSubject.Text = curFileCase.fileCaseSubject

        txtDesciption.Text = curFileCase.fileCaseDescription

        SetSalahiyat(curFileCase.fileCaseAreaID, curFileCase.fileCaseSubAreaID)

        '' ''cmbMojtame.SelectedValue = curFileCase.fileCaseAreaID

        '' ''cmbHoze.SelectedValue = curFileCase.fileCaseSubAreaID

        '' ''cmbShobe.SelectedValue = curFileCase.fileCaseBranchID

        BindResult()

    End Sub


#End Region

#Region "Comment"

    'Private Sub cmbMojtame_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim list As ComboBox
    '    list = sender
    '    If (list.DataSource Is Nothing) Then
    '        list.Items.Clear()
    '    End If

    'End Sub

    'Private Sub cmbHoze_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    cmbHoze.SelectedIndex = cmbHoze.FindStringExact(cmbHoze.Text)

    '    If cmbHoze.SelectedIndex <> -1 Then

    '        Dim a As AreaReviewCollection = AreaManger.GetFileChildsByParentID(cmbHoze.SelectedValue)
    '        If a.Count = 0 Then
    '            cmbShobe.DataSource = Nothing

    '        Else

    '            cmbShobe.DataSource = a
    '        End If


    '    Else
    '        cmbShobe.DataSource = Nothing
    '    End If

    'End Sub

    'Private Sub cmbMojtame_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)


    '    cmbMojtame.SelectedIndex = cmbMojtame.FindStringExact(cmbMojtame.Text)

    '    SetCombo()

    '    If cmbMojtame.SelectedIndex <> -1 Then

    '        Dim a As AreaReviewCollection = AreaManger.GetFileChildsByParentID(cmbMojtame.SelectedValue)

    '        If a.Count = 0 Then

    '            cmbHoze.DataSource = Nothing
    '            cmbShobe.DataSource = Nothing
    '        Else


    '            cmbHoze.DataSource = a
    '        End If

    '    Else
    '        cmbHoze.DataSource = Nothing

    '    End If

    'End Sub

    'Private Sub cmbMojtame_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

    '    If cmbMojtame.SelectedIndex = -1 Then

    '        cmbHoze.DataSource = Nothing

    '        cmbShobe.DataSource = Nothing

    '    End If

    'End Sub

    'Private Sub cmbHoze_Leave(ByVal sender As Object, ByVal e As System.EventArgs)

    '    If cmbHoze.SelectedIndex = -1 Then

    '        cmbShobe.DataSource = Nothing

    '    End If

    'End Sub


    'Private Sub clearCombo(ByVal name As String)


    '    Select Case name

    '        Case "Mojtame"

    '            cmbMojtame.Text = String.Empty
    '            cmbHoze.DataSource = Nothing
    '            cmbShobe.DataSource = Nothing
    '            cmbHoze.Text = String.Empty
    '            cmbShobe.Text = String.Empty

    '        Case "Hoze"
    '            cmbHoze.Text = String.Empty
    '            cmbShobe.DataSource = Nothing
    '            cmbShobe.Text = String.Empty
    '        Case "Shobe"
    '            cmbShobe.Text = String.Empty

    '    End Select

    'End Sub


    'Private Sub SetCombo()

    '    cmbMojtame.DisplayMember = "fileCaseAreaName"
    '    cmbMojtame.ValueMember = "fileCaseAreaID"

    '    cmbHoze.DisplayMember = "fileCaseAreaName"
    '    cmbHoze.ValueMember = "fileCaseAreaID"

    '    cmbShobe.DisplayMember = "fileCaseAreaName"
    '    cmbShobe.ValueMember = "fileCaseAreaID"

    'End Sub


    'Private Sub SaveFileCaseArea()

    '    Dim a As New Area
    '    Dim Mojtame As String = cmbMojtame.Text.Trim()
    '    Dim Hoze As String = cmbHoze.Text.Trim()
    '    Dim shobe As String = cmbShobe.Text.Trim()

    '    Dim result As String = String.Empty

    '    a.fileCaseAreaChilds = String.Empty

    '    'مجتمع قضایی

    '    curFileCase.fileCaseAreaID = result
    '    curFileCase.fileCaseBranchID = result
    '    curFileCase.fileCaseSubAreaID = result

    '    a.fileCaseAreaName = Mojtame

    '    If a.fileCaseAreaName = String.Empty Then

    '        clearCombo("Mojtame")
    '        Exit Sub

    '    End If

    '    'SetCombo()

    '    If cmbMojtame.SelectedIndex = -1 Then

    '        result = AreaManger.AddArea(a)
    '        cmbMojtame.DataSource = AreaManger.GetFileChildsByParentID(a.fileCaseAreaChilds)
    '        cmbMojtame.SelectedValue = result
    '        If cmbMojtame.SelectedIndex = -1 Then

    '            clearCombo("Mojtame")
    '            Exit Sub

    '        End If

    '    End If

    '    curFileCase.fileCaseAreaID = cmbMojtame.SelectedValue

    '    'حوزه

    '    a.fileCaseAreaName = Hoze

    '    If a.fileCaseAreaName = String.Empty Then

    '        clearCombo("Hoze")
    '        Exit Sub

    '    End If


    '    If cmbHoze.SelectedIndex = -1 Then

    '        a.fileCaseAreaChilds = curFileCase.fileCaseAreaID
    '        a.fileCaseAreaName = Hoze
    '        result = AreaManger.AddArea(a)
    '        cmbHoze.DataSource = AreaManger.GetFileChildsByParentID(a.fileCaseAreaChilds)
    '        cmbHoze.SelectedValue = result

    '        If cmbHoze.SelectedIndex = -1 Then

    '            clearCombo("Hoze")
    '            Exit Sub

    '        End If

    '    End If


    '    ''''curFileCase.fileCaseSubAreaID = result
    '    curFileCase.fileCaseSubAreaID = cmbHoze.SelectedValue

    '    'شعبه
    '    a.fileCaseAreaName = shobe

    '    If a.fileCaseAreaName = String.Empty Then Exit Sub

    '    If cmbShobe.SelectedIndex = -1 Then

    '        a.fileCaseAreaChilds = cmbHoze.SelectedValue
    '        a.fileCaseAreaName = shobe

    '        result = AreaManger.AddArea(a)
    '        cmbShobe.DataSource = AreaManger.GetFileChildsByParentID(cmbHoze.SelectedValue)
    '        cmbShobe.SelectedValue = result

    '        If cmbShobe.SelectedIndex = -1 Then

    '            clearCombo("Shobe")
    '            Exit Sub

    '        End If

    '    End If

    '    '' ''curFileCase.fileCaseBranchID = result
    '    curFileCase.fileCaseBranchID = cmbShobe.SelectedValue

    '    SetCombo()

    '    Exit Sub

    'End Sub


#End Region




    Private Sub rdbType0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbType0.CheckedChanged
        If rdbType0.Checked = True Then
            rdbComplainant0.Text = "دفاع از خواهان"
            rdbComplainant1.Text = "دفاع از خوانده"
        End If

    End Sub

    Private Sub rdbType1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbType1.CheckedChanged
        If rdbType1.Checked = True Then
            rdbComplainant0.Text = "دفاع از شاکی"
            rdbComplainant1.Text = "دفاع از متهم"
        End If

    End Sub

    Private Sub btnPrintLebel_Click(sender As Object, e As EventArgs) Handles btnPrintLebel.Click

        Dim param As New Dictionary(Of String, String)

        param.Add("fileSystemNumbr", txtNoInSystem.Text)
        param.Add("fileOpenDate", txtOpenDate.txtYear.Text & txtOpenDate.txtSlash1.Text & txtOpenDate.txtMonth.Text & txtOpenDate.txtSlash2.Text & txtOpenDate.txtDay.Text)
        param.Add("fileSubject", txtSubject.Text)
        param.Add("fileLawyer", txtVakil.Text)
        param.Add("fileClient", txtMovakel.Text)
        param.Add("fileTarafDavi", txtKhande.Text)

        Dim r As New MyReports()

        r.SimpleReport("fileCaseLabel", param, True)

        r.Show()

    End Sub
End Class
