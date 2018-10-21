
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.ContactInfo
Imports Lawyer.Common.VB.FileParties
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.TimeParties
Imports Lawyer.Common.VB.Common
Imports System.IO.Path
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Docs
Imports NwdSolutions.Web.GeneralUtilities
Imports NwdSolutions.Web

Public Class Moshavere

    Delegate Sub ShowFinanceForm(ByVal financeId As String, ByVal IsTimeId As Boolean)
    Event ShowFinanceAdd As ShowFinanceForm

    ' '' ''Private DicReciver As New Dictionary(Of String, String)
    Private CurTiming As New Timing.Timing
    Private IsEditMode As Boolean = False
    Private tpId As String = String.Empty
    Private isNewTask As Boolean = False
    Private images As New ImageList
    Delegate Sub ShowDocForm(ByVal filePath As String, ByVal fileName As String)
    Event ShowDocContent As ShowDocForm

    Delegate Sub _showSmsFormHandler(ByVal fileCaseID As String, ByVal timeID As String, ByVal dt As DataTable, ByVal smsText As String)
    Event _showSmsForm As _showSmsFormHandler

    Delegate Sub ShowConfirmForm(ByVal text As String, ByVal title As String)
    Event ShowConfirm As ShowConfirmForm
    Public YesClicked As Boolean = False
    '' مشاوره گیرنده
    Private MoshavereID As String = String.Empty
    Private RecieverID As String = String.Empty
    Dim rowIndex As Integer = -1
    Private timingType As String = "4"
    Private moshavereType = "44ca4f7d-1044-4fe0-9abd-94abd834c149"

    Delegate Sub ShowContact()
    Event ShowContactSearch As ShowContact

#Region "Events"

    ' '' ''Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    ' '' ''    lblMessage.Text = String.Empty

    ' '' ''    If CheckBeforeSave() Then

    ' '' ''        If IsEditMode Then

    ' '' ''            Try

    ' '' ''                'TimeParties
    ' '' ''                Dim timeParties As New TimeParties

    ' '' ''                timeParties.timeTime = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

    ' '' ''                Dim d As Date = DateAdd(DateInterval.Minute, -CDbl(txtReminder.Text), TimingTime.Value)

    ' '' ''                timeParties.timeReminderBefore = txtReminder.Text

    ' '' ''                timeParties.timeDuration = txtDuration.Text

    ' '' ''                timeParties.timeActualTime = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

    ' '' ''                timeParties.timeStatus = cmbTimingStatus.SelectedValue

    ' '' ''                timeParties.timeDate = TimingDate.GetShamsiDateInNumericFormat()

    ' '' ''                timeParties.tpID = tpId

    ' '' ''                d = DateAdd(DateInterval.Minute, CDbl(txtDuration.Text), TimingTime.Value)

    ' '' ''                timeParties.timeEnd = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

    ' '' ''                If TimePartiesManager.EditParties(timeParties) Then

    ' '' ''                    ParentForm.Close()

    ' '' ''                End If

    ' '' ''            Catch ex As Exception

    ' '' ''                lblMessage.Text = "خطا در ویرایش"
    ' '' ''                ErrorManager.WriteMessage("btnSave_Click,Edit", ex.ToString(), Me.ParentForm.Text)
    ' '' ''            End Try


    ' '' ''        Else

    ' '' ''            Try

    ' '' ''                ' مقایسه برای وقت آزاد یا مشغول
    ' '' ''                If cmbTimingStatus.SelectedValue = "1" OrElse cmbTimingStatus.SelectedValue = "2" Then

    ' '' ''                    Dim curDate As Integer = TimingDate.GetShamsiDateInNumericFormat
    ' '' ''                    Dim time As String = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

    ' '' ''                    If CurTiming.fileCaseID <> String.Empty Then

    ' '' ''                        Dim str As String = String.Empty

    ' '' ''                        For index As Integer = 0 To lstTargetSource.Items.Count - 1

    ' '' ''                            If TimePartiesManager.IsUserBusy(lstTargetSource.Items(index).SubItems(1).Text, curDate, time) > 0 Then

    ' '' ''                                str &= " ," + lstTargetSource.Items(index).Text

    ' '' ''                            End If

    ' '' ''                        Next

    ' '' ''                        If str <> String.Empty Then

    ' '' ''                            str = "برای " & str.Substring(2) & " در ساعت مورد نظر کار ثبت شده است "

    ' '' ''                            RaiseEvent ShowConfirm(str, "اقدامات")

    ' '' ''                            If Not YesClicked Then

    ' '' ''                                Exit Sub

    ' '' ''                            End If

    ' '' ''                        End If

    ' '' ''                    Else

    ' '' ''                        Dim str As String = String.Empty



    ' '' ''                        For Each Item As String In DicReciver.Keys

    ' '' ''                            If TimePartiesManager.IsUserBusy(Item, curDate, time) > 0 Then

    ' '' ''                                str &= " و" + DicReciver.Item(Item)

    ' '' ''                            End If
    ' '' ''                        Next

    ' '' ''                        If str <> String.Empty Then

    ' '' ''                            str = "برای " & str.Substring(2) & " در ساعت مورد نظر کار ثبت شده ایت ، آیا مایل به ثبت هستید ؟ "

    ' '' ''                            RaiseEvent ShowConfirm(str, "اقدامات")

    ' '' ''                            If Not YesClicked Then

    ' '' ''                                Exit Sub

    ' '' ''                            End If

    ' '' ''                        End If

    ' '' ''                    End If

    ' '' ''                End If


    ' '' ''                CurTiming.timeID = Guid.NewGuid.ToString()

    ' '' ''                CurTiming.timeSourceCustID = CurrentLogin.CurrentUser.UserID

    ' '' ''                CurTiming.timeText = txtDescription.Text.Trim()

    ' '' ''                CurTiming.timeTitle = txtTitle.Text.Trim()

    ' '' ''                CurTiming.timeType = cmbTimingType.SelectedValue


    ' '' ''                If Timing.TimingManager.AddTiming(CurTiming) Then

    ' '' ''                    'TimeParties
    ' '' ''                    Dim timeParties As New TimeParties

    ' '' ''                    timeParties.timeTime = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

    ' '' ''                    If pnlReminder.Visible Then

    ' '' ''                        Dim d As Date = DateAdd(DateInterval.Minute, -CDbl(txtReminder.Text), TimingTime.Value)
    ' '' ''                        timeParties.timeReminderBefore = txtReminder.Text
    ' '' ''                        timeParties.timeDuration = txtDuration.Text
    ' '' ''                        timeParties.timeActualTime = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)
    ' '' ''                        timeParties.timeStatus = cmbTimingStatus.SelectedValue

    ' '' ''                        d = DateAdd(DateInterval.Minute, CDbl(txtDuration.Text), TimingTime.Value)

    ' '' ''                        timeParties.timeEnd = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

    ' '' ''                    Else

    ' '' ''                        timeParties.timeActualTime = timeParties.timeTime
    ' '' ''                        timeParties.timeEnd = timeParties.timeTime

    ' '' ''                    End If

    ' '' ''                    timeParties.timeDate = TimingDate.GetShamsiDateInNumericFormat
    ' '' ''                    timeParties.timeDone = False
    ' '' ''                    timeParties.timeID = CurTiming.timeID

    ' '' ''                    Dim isUserRegBefore As Boolean = False

    ' '' ''                    'پرونده ای مد نظر نمی باشد
    ' '' ''                    If CurTiming.fileCaseID = String.Empty Then

    ' '' ''                        For Each Item As String In DicReciver.Keys

    ' '' ''                            If CurrentLogin.CurrentUser.UserID <> Item Then

    ' '' ''                                timeParties.tpID = Guid.NewGuid().ToString()

    ' '' ''                                timeParties.tpTargetCustID = Item

    ' '' ''                                Try
    ' '' ''                                    TimePartiesManager.AddParties(timeParties)

    ' '' ''                                Catch ex As Exception
    ' '' ''                                    ErrorManager.WriteMessage("btnSave_Click,AddParties,1", ex.ToString(), Me.ParentForm.Text)
    ' '' ''                                End Try

    ' '' ''                            End If

    ' '' ''                        Next

    ' '' ''                    Else


    ' '' ''                        For Each Item As ListViewItem In lstTargetSource.CheckedItems

    ' '' ''                            If CurrentLogin.CurrentUser.UserID <> Item.SubItems(1).Text Then

    ' '' ''                                timeParties.tpID = Guid.NewGuid().ToString()

    ' '' ''                                timeParties.tpTargetCustID = Item.SubItems(1).Text

    ' '' ''                                Try
    ' '' ''                                    TimePartiesManager.AddParties(timeParties)

    ' '' ''                                Catch ex As Exception
    ' '' ''                                    ErrorManager.WriteMessage("btnSave_Click,AddParties,2", ex.ToString(), Me.ParentForm.Text)
    ' '' ''                                End Try

    ' '' ''                            End If

    ' '' ''                        Next

    ' '' ''                    End If


    ' '' ''                    'برای ارسال کننده هم ارسال می شود
    ' '' ''                    timeParties.tpID = Guid.NewGuid().ToString()

    ' '' ''                    timeParties.tpTargetCustID = CurrentLogin.CurrentUser.UserID

    ' '' ''                    Try
    ' '' ''                        TimePartiesManager.AddParties(timeParties)

    ' '' ''                    Catch ex As Exception
    ' '' ''                        ErrorManager.WriteMessage("btnSave_Click,AddParties,sender", ex.ToString(), Me.ParentForm.Text)
    ' '' ''                    End Try


    ' '' ''                End If


    ' '' ''                'TimeDocs
    ' '' ''                Dim tDoc As New Timing.deskDocs

    ' '' ''                For Each Item As DataGridViewRow In lstFiles.Rows

    ' '' ''                    tDoc.deskDocExtension = GetExtension(Item.Cells(2).Value)
    ' '' ''                    tDoc.deskDocID = Guid.NewGuid().ToString()
    ' '' ''                    tDoc.deskDocName = Item.Cells(1).Value
    ' '' ''                    tDoc.deskImageID = Item.Cells(3).Value
    ' '' ''                    tDoc.deskTimeID = CurTiming.timeID
    ' '' ''                    tDoc.FileFullPath = Item.Cells(2).Value

    ' '' ''                    Try
    ' '' ''                        Timing.TimingManager.AddTimeDocs(tDoc)

    ' '' ''                    Catch ex As Exception
    ' '' ''                        ErrorManager.WriteMessage("btnSave_Click,AddTimeDocs", ex.ToString(), Me.ParentForm.Text)
    ' '' ''                    End Try


    ' '' ''                Next


    ' '' ''                If isNewTask Then

    ' '' ''                    Try
    ' '' ''                        TimePartiesManager.EditTimingDoneField(Me.tpId, True)

    ' '' ''                    Catch ex As Exception

    ' '' ''                        lblMessage.Text = "خطا در واگذاری"

    ' '' ''                    End Try


    ' '' ''                End If

    ' '' ''                'مشاوره 

    ' '' ''                If cmbTimingType.SelectedValue = "4" Then

    ' '' ''                    ' ثبت هزینه
    ' '' ''                    Dim curfinance As New Finance.Finance

    ' '' ''                    curfinance.finaceTypeID = "44ca4f7d-1044-4fe0-9abd-94abd834c149"
    ' '' ''                    curfinance.financeAmount = -1 * AmountControl1.Amount
    ' '' ''                    curfinance.financeCustID = MoshavereID
    ' '' ''                    curfinance.financeID = Guid.NewGuid().ToString()
    ' '' ''                    curfinance.financePaymentDate = DateManager.GetCurrentShamsiDateInNumericFormat()
    ' '' ''                    '
    ' '' ''                    curfinance.financePaymentTime = DateManager.GetCurrentTime()

    ' '' ''                    curfinance.timeID = CurTiming.timeID

    ' '' ''                    Try
    ' '' ''                        If Finance.FinanceManager.AddFinance(curfinance) Then

    ' '' ''                            lblMessage.Text = "هزینه ی مشاوره ثبت شد ، دریافتی را در فرم ثبت هزینه انجام دهید."

    ' '' ''                            RaiseEvent ShowFinanceAdd(curfinance.financeID, False)

    ' '' ''                        Else

    ' '' ''                            Throw New Exception

    ' '' ''                        End If

    ' '' ''                    Catch ex As Exception

    ' '' ''                        lblMessage.Text = "هزینه ی مشاوره ثبت نشد ، لطفا هزینه و دریافتی را  به صورت دستی در فرم ثبت هزینه وارد نمایید."

    ' '' ''                        RaiseEvent ShowFinanceAdd(curfinance.financeID, True)

    ' '' ''                    End Try


    ' '' ''                End If

    ' '' ''                ResetElements()

    ' '' ''                lblMessage.Text = "ثبت انجام شد."

    ' '' ''            Catch ex As Exception

    ' '' ''                lblMessage.Text = "خطا در ثبت"
    ' '' ''                ErrorManager.WriteMessage("btnSave_Click,Save", ex.ToString(), Me.ParentForm.Text)
    ' '' ''            End Try

    ' '' ''        End If

    ' '' ''    End If

    ' '' ''End Sub



    ' '' ''Private Sub TimingAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    ' '' ''    ToolTip1.SetToolTip(picAttachment, "افزودن فایل")

    ' '' ''    ToolTip1.SetToolTip(btnHelp, "لیست افراد موجود در پرونده")

    ' '' ''    ToolTip1.SetToolTip(picHelp2, "در صورت خالی بودن ، برای کاربر جاری ارسال می گردد")

    ' '' ''    lblMessage.Text = String.Empty

    ' '' ''    If IsEditMode AndAlso btnDelete.Visible Then
    ' '' ''        btnSave.Location = New Point(250, 157)
    ' '' ''    Else
    ' '' ''        btnSave.Location = New Point(200, 157)
    ' '' ''    End If


    ' '' ''End Sub

    ' '' ''Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

    ' '' ''    YesClicked = False

    ' '' ''    Try

    ' '' ''        RaiseEvent ShowConfirm("آیا برای حذف مطمئن هستید ؟", "حذف اقدام")

    ' '' ''        If YesClicked Then

    ' '' ''            If Finance.FinanceManager.IsExistMoshaveredaryafti(tpId) Then

    ' '' ''                lblMessage.Text = "برای مشاوره مبلغی دریافت شده و امکان حذف وجود ندارد"

    ' '' ''            Else

    ' '' ''                If Timing.TimingManager.DeleteTiming(CurTiming.timeID) Then

    ' '' ''                    Me.ParentForm.Close()

    ' '' ''                End If

    ' '' ''            End If

    ' '' ''        End If

    ' '' ''    Catch ex As Exception

    ' '' ''        lblMessage.Text = "خطا در حذف"
    ' '' ''        ErrorManager.WriteMessage("btnDelete_Click", ex.ToString(), Me.ParentForm.Text)
    ' '' ''    End Try

    ' '' ''End Sub

    ' '' ''Private Sub flow1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ' '' ''    If IsEditMode Then
    ' '' ''        Me.Size = New Size(Me.Size.Width, CType(sender, FlowLayoutPanel).Size.Height + 30)

    ' '' ''    End If
    ' '' ''End Sub

    ' '' ''Private Sub txtReceivers_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMoshavere.MouseDoubleClick
    ' '' ''    RaiseEvent ShowContactSearch()
    ' '' ''End Sub


#End Region

#Region "Utility"
    Public Sub EditReminder(ByVal tpId As String, ByVal fileid As String)

        Try

            btnDelete.Enabled = False

            Me.tpId = tpId

            Dim tp As TimeParties = TimePartiesManager.GetTimePartiesInfoByID(tpId)

            Dim recivers As ContactInfoReviewCollection = TimePartiesManager.GetAllPartiesByTiming(tp.timeID)

            If tp IsNot Nothing Then

                txtDuration.Text = tp.timeDuration

                txtReminder.Text = tp.timeReminderBefore()

                Dim d As New Date(Now.Year, Now.Month, Now.Day, CInt(tp.timeTime.Substring(0, 2)), CInt(tp.timeTime.Substring(3, 2)), CInt(tp.timeTime.Substring(6, 2)))

                TimingTime.Value = d

                CurTiming = Timing.TimingManager.GetTimingInfoByID(tp.timeID)

                If fileid <> String.Empty Then

                    SetTiming(fileid)

                Else

                    SetTiming()

                    Dim m As ContactInfoReview = Shaxes.FinanceManager.GetFinanaceCustInfo(tp.timeID)

                    txtMoshavere.Text = m.custFullName

                    MoshavereID = m.custID

                End If


                CurTiming.timeID = tp.timeID

                TimingDate.SetShamsiDate(tp.timeDate)

                CurTiming.fileCaseID = String.Empty

                CurTiming.fileID = String.Empty

                IsEditMode = True

                If tp.timeReminderBefore = "0" AndAlso tp.timeDuration = "0" Then

                    rdbTypeNS.Checked = True

                Else

                    rdbTypeS.Checked = True

                    pnlReminder.Visible = True

                End If

                If tp.timeReminderType.HasValue Then

                    cmbReminderType.SelectedIndex = tp.timeReminderType

                End If

                Try

                    cmbTimingStatus.SelectedValue = tp.timeStatus

                Catch ex As Exception

                    cmbTimingStatus.SelectedIndex = 0

                End Try

                txtDescription.Text = CurTiming.timeText

                txtTitle.Text = CurTiming.timeTitle

                txtNumber.Text = CurTiming.timingNo



                Dim net As Integer = CurTiming.timeNet

                Dim sms As Integer = CurTiming.timeSms


                Dim index As Integer = 0

                'ارجاع به

                If recivers.Count > 0 Then

                    txtVakil.Text = recivers.Item(0).custFullName

                    RecieverID = recivers.Item(0).custID

                End If

                'مشاوره گیرنده
                AmountControl1.Amount = Shaxes.FinanceManager.GetMoshavereCost(tp.timeID)

                '    'لود کردن Docs

                Dim docs As Timing.DeskDocsCollection = Timing.TimingManager.GetAllForwardTimingDeskDocs(tp.timeID)

                If docs IsNot Nothing Then

                    For Each Item As Timing.deskDocs In docs

                        Dim dr As Integer = lstFiles.Rows.Add()

                        lstFiles.Rows(dr).Cells("gvClmTitle").Value = Item.deskDocName

                        lstFiles.Rows(dr).Cells("gvclmnImageID").Value = Item.deskImageID

                        lstFiles.Rows(dr).Cells("gvClmName").Value = Item.FileFullPath

                        lstFiles.Rows(dr).Cells("gvClmImage").Value = images.Images(Item.deskImageID)

                        lstFiles.Rows(dr).Cells("gvclmFileID").Value = Item.deskDocID
                    Next

                End If

                If CurrentLogin.CurrentUser.UserID <> tp.tpTargetCustID AndAlso CurrentLogin.CurrentUser.UserID <> CurTiming.timeSourceCustID Then

                    btnSave.Enabled = False

                    btnPrint.Enabled = False

                    btnDelete.Enabled = False

                    SetForEdit()

                End If

                If CurrentLogin.CurrentUser.UserID = CurTiming.timeSourceCustID Then

                    btnDelete.Visible = True

                    btnDelete.Enabled = True

                    btnPrint.Enabled = True

                End If


            Else

                Throw New Exception("tp is Null")

            End If

            '' ''SetForEdit()

        Catch ex As Exception

            btnSave.Enabled = False

            btnPrint.Enabled = False
            lblMessage.Text = "خطا در بارگذاری"

            ErrorManager.WriteMessage("EditReminder", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub SetForEdit()

        txtTitle.ReadOnly = True


        Me.txtTitle.BackColor = System.Drawing.Color.WhiteSmoke

        Me.lstFiles.BackColor = System.Drawing.Color.WhiteSmoke

        txtDescription.ReadOnly = True

        Me.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke

        RemoveHandler lstFiles.MouseUp, AddressOf lstFiles_MouseUp

        RemoveHandler lstFiles.DragDrop, AddressOf lstFiles_DragDrop

        picAttachment.Enabled = False

    End Sub


#End Region

#Region "Methods"

    Public Sub SetTiming()

        Try

            ' '' ''isNewTask = False

            ' '' ''IsEditMode = False

            pnlReminder.Visible = False

            Dim largeImage As New ImageList

            largeImage.ImageSize = New Size(16, 16)

            LoadDefaultImageFromTempDoc()

            lblMessage.Text = String.Empty

            cmbReminderType.SelectedIndex = 0

            cmbTimingStatus.DataSource = Timing.TimingManager.GetTimingStatus()

            cmbTimingStatus.SelectedIndex = 0

            TimingDate.SetToday = True

            'تنظیم ارجاع
            If CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.وکیل OrElse CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.کارشناس Then

                txtVakil.Text = CurrentLogin.CurrentUser.Name

                RecieverID = CurrentLogin.CurrentUser.UserID

            End If

        Catch ex As Exception

            btnSave.Enabled = False

            btnDelete.Enabled = False

            lblMessage.Text = "خطا در بارگذاری"

            ErrorManager.WriteMessage("SetTiming", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Public Sub SetTiming(ByVal fileID As String)

        Try
            pnlReminder.Visible = False

            isNewTask = False

            IsEditMode = False

            Dim largeImage As New ImageList

            largeImage.ImageSize = New Size(16, 16)

            LoadDefaultImageFromTempDoc()

            lblMessage.Text = String.Empty

            cmbReminderType.SelectedIndex = 0

            cmbTimingStatus.DataSource = Timing.TimingManager.GetTimingStatus()

            cmbTimingStatus.SelectedIndex = 0

            TimingDate.SetToday = True

            'تنظیم ارجاع
            If CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.وکیل OrElse CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.کارشناس Then

                txtVakil.Text = CurrentLogin.CurrentUser.Name

                RecieverID = CurrentLogin.CurrentUser.UserID

            End If

            Dim m As String = FileDocManager.GetFileCustId(fileID)

            If String.IsNullOrEmpty(m) Then

                Throw New Exception

            Else

                txtMoshavere.Text = ContactInfo.ContactInfoManager.GetContactFullNameByID(m)

                MoshavereID = m

                txtMoshavere.ReadOnly = True

                txtMoshavere.BackColor = Color.White

                RemoveHandler txtMoshavere.DragDrop, AddressOf txtMoshavere_DragDrop

                RemoveHandler txtMoshavere.KeyPress, AddressOf txtVakil_KeyPress

                RemoveHandler txtMoshavere.KeyDown, AddressOf txtMoshavere_KeyDown

            End If

        Catch ex As Exception

            btnSave.Enabled = False

            btnDelete.Enabled = False

            lblMessage.Text = "خطا در بارگذاری"

            ErrorManager.WriteMessage("SetTiming,FilecaseID", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#Region "Comment"


    ' '' ''Public Sub NewTask()

    ' '' ''    Try

    ' '' ''        cmbTimingType.Enabled = True

    ' '' ''        picAttachment.Visible = True

    ' '' ''        '' ''lstFiles.AllowDrop = True

    ' '' ''        SetDesign()

    ' '' ''        If CurTiming.fileCaseID = String.Empty Then

    ' '' ''            pnlReciverG.Visible = True

    ' '' ''            Me.Size = New Size(Me.Size.Width, Me.Size.Height + pnlReciverG.Height)

    ' '' ''        Else
    ' '' ''            pnlReciever.Visible = True

    ' '' ''            Me.Size = New Size(Me.Size.Width, Me.Size.Height + pnlReciever.Height)

    ' '' ''        End If


    ' '' ''        isNewTask = True

    ' '' ''        IsEditMode = False


    ' '' ''    Catch ex As Exception

    ' '' ''    End Try

    ' '' ''End Sub

    ' '' ''Public Sub NewTask(ByVal tpId As String)

    ' '' ''    Try

    ' '' ''        Me.tpId = tpId

    ' '' ''        Dim tp As TimeParties = TimePartiesManager.GetTimePartiesInfoByID(tpId)

    ' '' ''        If tp IsNot Nothing Then

    ' '' ''            TimingDate.SetShamsiDate(tp.timeDate)

    ' '' ''            txtDuration.Text = tp.timeDuration

    ' '' ''            txtReminder.Text = tp.timeReminderBefore()

    ' '' ''            TimingTime.Text = tp.timeTime

    ' '' ''            CurTiming = Timing.TimingManager.GetTimingInfoByID(tp.timeID)

    ' '' ''            If CurTiming.fileCaseID = Guid.Empty.ToString() Then


    ' '' ''                SetTiming()

    ' '' ''                CurTiming.fileCaseID = String.Empty

    ' '' ''                CurTiming.fileID = String.Empty

    ' '' ''            Else

    ' '' ''                SetTiming(CurTiming.fileCaseID, CurTiming.fileID)

    ' '' ''            End If

    ' '' ''            cmbTimingStatus.SelectedValue = tp.timeStatus

    ' '' ''            txtDescription.Text = CurTiming.timeText

    ' '' ''            txtTitle.Text = CurTiming.timeTitle

    ' '' ''            'لود کردن Docs

    ' '' ''            Dim docs As Timing.DeskDocsReviewCollection = Timing.TimingManager.GetAllTimingDeskDocs(CurTiming.timeID)

    ' '' ''            If docs IsNot Nothing Then

    ' '' ''                Dim lvItem As New ListViewItem

    ' '' ''                lvItem.Text = ""

    ' '' ''                lvItem.SubItems.Add("")

    ' '' ''                lvItem.Font = New System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Underline, GraphicsUnit.Point)

    ' '' ''                lvItem.ForeColor = Color.Blue

    ' '' ''                For Each Item As Timing.DeskDocsReview In docs

    ' '' ''                    lvItem.Text = Item.deskDocName

    ' '' ''                    lvItem.SubItems(1).Text = Item.deskDocID

    ' '' ''                    lvItem.ImageKey = Item.deskImageID

    ' '' ''                    '' ''lstFiles.Items.Add(lvItem.Clone())

    ' '' ''                Next

    ' '' ''            End If

    ' '' ''            isNewTask = True
    ' '' ''        End If

    ' '' ''    Catch ex As Exception

    ' '' ''    End Try

    ' '' ''End Sub



#End Region

#Region "Save"

    Private Function CheckBeforeSave() As Boolean

        Try

            If txtTitle.Text.Trim() = String.Empty Then

                lblMessage.Text = "عنوان را وارد نمایید."

                Return False

            End If

            If Not TimingDate.GetShamsiDateInNumericFormat.HasValue Then

                TimingDate.SetToday = True

            End If

            If rdbTypeNS.Checked Then

                cmbTimingStatus.SelectedValue = "0"

                txtReminder.Text = "0"

                txtDuration.Text = "0"

                cmbReminderType.SelectedIndex = 0

            End If

            If rdbTypeS.Checked AndAlso (txtReminder.Text = String.Empty OrElse CInt(txtReminder.Text) = 0) Then

                Select Case cmbReminderType.SelectedIndex

                    Case 0
                        txtReminder.Text = 0

                    Case 1

                        txtReminder.Text = 1

                    Case 2

                        txtReminder.Text = 1

                End Select

            End If

            If rdbTypeS.Checked AndAlso (txtDuration.Text = String.Empty OrElse CInt(txtDuration.Text) = 0) Then

                txtDuration.Text = 0

            End If



            If AmountControl1.Amount = 0 Then

                AmountControl1.Amount = 0

            End If

            If MoshavereID = String.Empty Then

                lblMessage.Text = "نام مشاوره گیرنده را وارد نمایید."

                Return False

            End If


            If RecieverID = String.Empty Then

                lblMessage.Text = "نام کارشناس یا وکیل مربوطه را وارد نمایید."

                Return False

            End If

            Return True

        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت"

            ErrorManager.WriteMessage("CheckBeforeSave", ex.ToString(), Me.ParentForm.Text)

            Return False

        End Try


    End Function

    Private Sub SaveMoshavere(ByVal print As Boolean)



        lblMessage.Text = String.Empty

        If CheckBeforeSave() Then

            If IsEditMode Then

                Try

                    ' مقایسه برای وقت آزاد یا مشغول
                    'فقط برای حالت برنامه ریزی شده معنی دارد

                    'تشکیل فایل
                    '' CreateMoshavereFile()

                    If rdbTypeS.Checked AndAlso cmbTimingStatus.SelectedValue = "1" Then

                        Dim curDate As Integer = TimingDate.GetShamsiDateInNumericFormat

                        Dim time As String = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

                        Dim str As String = String.Empty

                        If TimePartiesManager.IsUserBusyForEdit(RecieverID, curDate, time, CurTiming.timeID) > 0 Then

                            str &= " ," + CurrentLogin.CurrentUser.Name

                        End If

                        If str <> String.Empty Then

                            str = "برای شما " & "در ساعت مورد نظر کار ثبت شده است.آیا مایل به ثبت کار جدید هستید؟"

                            RaiseEvent ShowConfirm(str, "اقدامات")

                            If Not YesClicked Then

                                Exit Sub

                            End If

                        End If

                    End If

                    CurTiming.timeText = txtDescription.Text.Trim()

                    CurTiming.timeTitle = txtTitle.Text.Trim()

                    CurTiming.timingNo = txtNumber.Text.Trim()

                    'If chkSMS.Checked Then
                    '    CurTiming.timeSms = 1
                    'Else
                    '    CurTiming.timeSms = 0
                    'End If

                    ' send timing to net- i deleted this part
                    CurTiming.timeNet = 0



                    Timing.TimingManager.EditTiming_Moshavere(CurTiming)

                    Dim d As Date

                    Dim g As New NwdSolutions.Web.GeneralUtilities.DateConvertor(CommonSettingManager.ConnectionString())

                    Dim miladiD As Date = g.GetMiladiDate(TimingDate.GetShamsiDate)

                    Dim AlarmDate As New Date(miladiD.Year, miladiD.Month, miladiD.Day, TimingTime.Value.Hour, TimingTime.Value.Minute, TimingTime.Value.Second)


                    Select Case cmbReminderType.SelectedIndex


                        Case 0
                            'دقیقه
                            d = DateAdd(DateInterval.Minute, -CDbl(txtReminder.Text), AlarmDate)

                        Case 1
                            'ساعت
                            d = DateAdd(DateInterval.Hour, -CDbl(txtReminder.Text), AlarmDate)

                        Case 2
                            'روز
                            d = DateAdd(DateInterval.DayOfYear, -CDbl(txtReminder.Text), AlarmDate)

                    End Select


                    'TimeParties
                    Dim timeParties As New TimeParties

                    timeParties.timeTime = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

                    timeParties.timeReminderBefore = txtReminder.Text

                    timeParties.timeDuration = txtDuration.Text

                    timeParties.timeActualTime = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

                    timeParties.timeActualDate = g.GetShamsiDateInNumericFormat(d)

                    timeParties.timeStatus = cmbTimingStatus.SelectedValue

                    d = DateAdd(DateInterval.Minute, CDbl(txtDuration.Text), TimingTime.Value)

                    timeParties.timeEnd = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

                    timeParties.timeDate = TimingDate.GetShamsiDateInNumericFormat

                    timeParties.timeDone = rdbTypeNS.Checked

                    timeParties.timeReminderType = cmbReminderType.SelectedIndex

                    timeParties.tpID = tpId

                    timeParties.tpTargetCustID = RecieverID

                    timeParties.timeReminderType = cmbReminderType.SelectedIndex

                    timeParties.timeID = CurTiming.timeID

                    If TimePartiesManager.EditPartiesByMoshavere(timeParties) Then

                        'edit Finance

                        If Shaxes.FinanceManager.DeleteFinanceBytimeID(timeParties.timeID) Then

                            ' ثبت هزینه
                            Dim curfinance As New Shaxes.Finance

                            curfinance.finaceTypeID = "44ca4f7d-1044-4fe0-9abd-94abd834c149"

                            curfinance.financeAmount = -1 * AmountControl1.Amount

                            curfinance.financeCustID = MoshavereID

                            curfinance.financeID = Guid.NewGuid().ToString()

                            curfinance.financePaymentDate = DateManager.GetCurrentShamsiDateInNumericFormat()
                            '
                            curfinance.financePaymentTime = DateManager.GetCurrentTime()

                            curfinance.timeID = CurTiming.timeID

                            Try

                                Shaxes.FinanceManager.AddFinance_Moshavereh(curfinance, Guid.NewGuid().ToString())

                                If print Then

                                    PrintMoshavere(CurTiming.timeID)

                                End If

                                ParentForm.Close()

                            Catch ex As Exception

                                lblMessage.Text = "خطا در ویرایش اطلاعات"

                            End Try

                        End If


                    End If

                Catch ex As Exception

                    lblMessage.Text = "خطا در ویرایش"

                    ErrorManager.WriteMessage("btnSave_Click,Edit", ex.ToString(), Me.ParentForm.Text)

                End Try


            Else

                Try

                    'تشکیل فایل
                    ''' CreateMoshavereFile()

                    ' مقایسه برای وقت آزاد یا مشغول
                    'فقط برای حالت برنامه ریزی شده معنی دارد

                    If rdbTypeS.Checked AndAlso cmbTimingStatus.SelectedValue = "1" Then

                        Dim curDate As Integer = TimingDate.GetShamsiDateInNumericFormat

                        Dim time As String = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

                        Dim str As String = String.Empty

                        If TimePartiesManager.IsUserBusy(RecieverID, curDate, time) > 0 Then

                            str &= " ," + RecieverID

                        End If

                        If str <> String.Empty Then

                            str = " برای " & str.Substring(2) & " در ساعت مورد نظر کار ثبت شده است.آیا مایل به ثبت کار جدید هستید؟ "

                            RaiseEvent ShowConfirm(str, "اقدامات")

                            If Not YesClicked Then

                                Exit Sub

                            End If

                        End If

                    End If

                    CurTiming.timeID = Guid.NewGuid.ToString()

                    CurTiming.timeSourceCustID = CurrentLogin.CurrentUser.UserID

                    CurTiming.timeText = txtDescription.Text.Trim()

                    CurTiming.timeTitle = txtTitle.Text.Trim()

                    CurTiming.timeType = timingType

                    CurTiming.timingNo = txtNumber.Text.Trim()

                    'If chkSMS.Checked Then
                    '    CurTiming.timeSms = 1
                    'Else
                    '    CurTiming.timeSms = 0
                    'End If

                    'send timing to net -- i deleted this part
                    CurTiming.timeNet = 0


                    Dim g As New GeneralUtilities.DateConvertor(CommonSettingManager.ConnectionString())

                    Dim miladiD As Date = g.GetMiladiDate(TimingDate.GetShamsiDate)

                    Dim AlarmDate As New Date(miladiD.Year, miladiD.Month, miladiD.Day, TimingTime.Value.Hour, TimingTime.Value.Minute, TimingTime.Value.Second)

                    If Timing.TimingManager.AddTiming(CurTiming) Then

                        'TimeParties
                        Dim timeParties As New TimeParties

                        timeParties.timeTime = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

                        Dim d As Date

                        Select Case cmbReminderType.SelectedIndex


                            Case 0
                                'دقیقه
                                d = DateAdd(DateInterval.Minute, -CDbl(txtReminder.Text), AlarmDate)

                            Case 1
                                'ساعت
                                d = DateAdd(DateInterval.Hour, -CDbl(txtReminder.Text), AlarmDate)

                            Case 2
                                'روز
                                d = DateAdd(DateInterval.DayOfYear, -CDbl(txtReminder.Text), AlarmDate)

                        End Select

                        timeParties.timeReminderBefore = txtReminder.Text

                        timeParties.timeDuration = txtDuration.Text

                        timeParties.timeActualTime = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

                        timeParties.timeActualDate = g.GetShamsiDateInNumericFormat(d)

                        timeParties.timeStatus = cmbTimingStatus.SelectedValue

                        d = DateAdd(DateInterval.Minute, CDbl(txtDuration.Text), TimingTime.Value)

                        timeParties.timeEnd = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

                        timeParties.timeDate = TimingDate.GetShamsiDateInNumericFormat

                        timeParties.timeDone = rdbTypeNS.Checked

                        timeParties.timeID = CurTiming.timeID

                        timeParties.timeReminderType = cmbReminderType.SelectedIndex

                        Dim isUserRegBefore As Boolean = False

                        timeParties.tpID = Guid.NewGuid().ToString()

                        timeParties.tpTargetCustID = RecieverID

                        Try

                            TimePartiesManager.AddParties(timeParties)

                        Catch ex As Exception

                            ErrorManager.WriteMessage("btnSave_Click,AddParties,2", ex.ToString(), Me.ParentForm.Text)

                        End Try

                    End If


                    ' ثبت هزینه
                    Dim curfinance As New Shaxes.Finance

                    curfinance.finaceTypeID = "44ca4f7d-1044-4fe0-9abd-94abd834c149"

                    curfinance.financeAmount = -1 * AmountControl1.Amount

                    curfinance.financeCustID = MoshavereID

                    curfinance.financeID = Guid.NewGuid().ToString()

                    curfinance.financePaymentDate = DateManager.GetCurrentShamsiDateInNumericFormat()
                    '
                    curfinance.financePaymentTime = DateManager.GetCurrentTime()

                    curfinance.timeID = CurTiming.timeID

                    Try

                        Shaxes.FinanceManager.AddFinance_Moshavereh(curfinance, Guid.NewGuid().ToString())

                    Catch ex As Exception


                    End Try

                    'TimeDocs

                    Dim tDoc As New Timing.deskDocs

                    For Each Item As DataGridViewRow In lstFiles.Rows

                        tDoc.deskDocExtension = GetExtension(Item.Cells(2).Value)

                        tDoc.deskDocID = Guid.NewGuid().ToString()

                        tDoc.deskDocName = Item.Cells(1).Value

                        tDoc.deskImageID = Item.Cells(3).Value

                        tDoc.deskTimeID = CurTiming.timeID

                        tDoc.FileFullPath = Item.Cells(2).Value


                        Try

                            Timing.TimingManager.AddTimeDocs(tDoc)

                        Catch ex As Exception

                            ErrorManager.WriteMessage("btnSave_Click,AddTimeDocs", ex.ToString(), Me.ParentForm.Text)

                        End Try

                    Next

                    ''''''''''''''''''''''






                    ResetElements()

                    lblMessage.Text = "ثبت انجام شد."

                    'abbas 
                    ''abbas sms

                    Dim orgName As String = ""
                    If Lawyer.Common.VB.Setting.SettingManager.GetSettingsByName("smsorgname").Count > 0 Then orgName = Lawyer.Common.VB.Setting.SettingManager.GetSettingsByName("smsorgname")(0).settingValue

                    If Lawyer.Common.VB.SmsManager.getSmsConfig() = True Then
                        RaiseEvent _showSmsForm(Nothing, CurTiming.timeID, Nothing, Nothing)
                    End If




                    If print Then
                        PrintMoshavere(CurTiming.timeID)

                    End If

                Catch ex As Exception

                    lblMessage.Text += "خطا در ثبت"

                    ErrorManager.WriteMessage("btnSave_Click,Save", ex.ToString(), Me.ParentForm.Text)

                End Try

            End If

        End If

    End Sub

    Private Sub PrintMoshavere(ByVal id As String)

        Try

            Dim r As New MyReports()

            r.ReportDataTable("چاپ مشاوره", "testRpt", Nothing) = Timing.TimingManager.GetMoshavereInfoByID(id)

            r.ShowDialog()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        SaveMoshavere(False)

    End Sub

    Private Function CreateMoshavereFile() As Boolean


        Dim prefileName As String = Docs.FileDocManager.GetFileNameByCustId(MoshavereID)

        If String.IsNullOrEmpty(prefileName) Then

            'قبلا فایل ثبت شده است و یا نه
            If String.IsNullOrEmpty(Docs.FileDocManager.IsExistFileName(txtMoshavere.Text, String.Empty)) Then

                Dim item1 As New ListViewItem(txtMoshavere.Text)

                item1.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

                item1.SubItems.Add(Guid.NewGuid().ToString())

                item1.SubItems.Add(1)

                item1.SubItems.Add(Docs.Enums.FileType.فایل)

                item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Docs.Enums.FileType.فایل)

                'نمایش در لیست

                If CreateFile(item1, txtMoshavere.Text, MoshavereID) Then

                    createFileDefaultDirectories(item1.SubItems(1).Text)

                Else


                    lblMessage.Text = "لطفا از طریق فرم تشکیل فایل اقدام نمایید."

                    Return False

                End If
            Else

                lblMessage.Text = "لطفا از طریق فرم تشکیل فایل اقدام نمایید."

                Return False

            End If



        Else


            Return True

        End If

        Return False

    End Function

    Private Function CreateFile(ByVal item As ListViewItem, ByVal docname As String, ByVal cutsid As String, Optional ByVal parentId As String = "") As Boolean

        Try

            Dim newFile As New Docs.Files

            newFile.fileImageID = item.ImageKey

            newFile.fileChilds = parentId

            newFile.fileIsCat = item.SubItems(2).Text

            newFile.fileName = docname

            newFile.FileType = item.SubItems(3).Text

            newFile.fileID = item.SubItems(1).Text

            newFile.fileCustID = cutsid


            Try

                newFile.fileCaseID = item.SubItems(4).Text

            Catch ex As Exception

                newFile.fileCaseID = String.Empty

            End Try

            If Docs.FileDocManager.CreateFile(newFile) Then

                Return True

            End If

            Return False

        Catch ex As Exception

            ErrorManager.WriteMessage("CreateFile", ex.ToString(), Me.ParentForm.Text)

            Return False

        End Try

    End Function

    Private Sub createFileDefaultDirectories(ByVal parentId As String)

        Try

            '1) دایرکتوری اوراق

            Dim item1 As New ListViewItem()

            item1.Text = "مشاوره ها"

            item1.SubItems.Add(Guid.NewGuid().ToString())

            item1.SubItems.Add(0)

            item1.SubItems.Add(Docs.Enums.FileType.مشاوره)

            item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Docs.Enums.FileType.مشاوره)

            CreateFile(item1, item1.Text, MoshavereID, parentId)

        Catch ex As Exception

            Throw New Exception

        End Try

    End Sub

    Private Sub ResetElements()

        IsEditMode = False

        tpId = String.Empty

        isNewTask = False

        txtReminder.Text = String.Empty

        txtTitle.Text = String.Empty

        TimingDate.SetToday = True

        txtDescription.Text = String.Empty

        txtDuration.Text = String.Empty

        TimingTime.ResetText()

        lstFiles.Rows.Clear()

        txtNumber.Text = String.Empty

        AmountControl1.Reset()

    End Sub

#End Region

#Region "Initial & Design"

    Private Sub rdbTypeS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTypeS.CheckedChanged, rdbTypeNS.CheckedChanged

        lblMessage.Text = String.Empty

        Try

            pnlReminder.Visible = rdbTypeS.Checked

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Moshavere_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtTitle.Focus()

        ToolTip1.SetToolTip(picAttachment, "افزودن فایل")

        If IsEditMode AndAlso btnDelete.Visible Then

            btnSave.Location = New Point(298, 157)

            btnPrint.Location = New Point(199, 157)

        Else

            btnSave.Location = New Point(250, 157)

            btnPrint.Location = New Point(151, 157)

        End If

    End Sub

    Private Sub LoadDefaultImageFromTempDoc()

        lblMessage.Text = String.Empty

        Try
            Dim list As BaseForm.ImageCollection = BaseForm.ImageManager.GetImagesByGroupName("Size16")

            If list IsNot Nothing Then

                For Each Item As BaseForm.Image In list

                    Dim imagefullPath As String = FileManager.GetDocsImagePath() & Item.imageID & Item.imageUpdateDate & Item.imageExtension

                    Dim imageKey As String = Item.imageID

                    If Not System.IO.File.Exists(imagefullPath) Then

                        BaseForm.ImageManager.WriteImage(imageKey, imagefullPath)

                    End If

                    images.Images.Add(Item.imageID, Bitmap.FromFile(imagefullPath))
                Next

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("LoadDefaultImageFromTempDoc", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub txtReminder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReminder.KeyPress, txtDuration.KeyPress

        lblMessage.Text = String.Empty

        Try

            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

                e.Handled = True

            End If

        Catch ex As Exception

        End Try

    End Sub


#End Region

#Region "Erjaaa"

    Delegate Sub ContactDetailHandler(ByVal custId As String)

    Event ContactDetail As ContactDetailHandler


    Private Sub txtVakil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVakil.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode <> Keys.Delete Then

            UcContacts1.Focus()

            UcContacts1.BindContacts(ucContacts.SearchType.role, Lawyer.Common.VB.ContactInfo.Enums.RoleType.وکیل & " or custType=" & Lawyer.Common.VB.ContactInfo.Enums.RoleType.کارشناس, New Point(7, 3), "", CType(sender, TextBox).Name)

        Else

            txtVakil.Text = String.Empty

            RecieverID = String.Empty

        End If

    End Sub

    Private Sub txtMoshavere_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMoshavere.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode <> Keys.Delete Then

            UcContacts1.Focus()

            UcContacts1.BindContacts(ucContacts.SearchType.role, Lawyer.Common.VB.ContactInfo.Enums.RoleType.مشاوره, New Point(7, 3), "", CType(sender, TextBox).Name)

        Else

            txtMoshavere.Text = String.Empty

            MoshavereID = String.Empty

        End If

    End Sub

    Private Sub UcContacts1_ShowConfirm() Handles UcContacts1.ShowConfirm

        lblMessage.Text = String.Empty

        Try

            YesClicked = False

            Dim pName As String = " موکل "

            If UcContacts1.RefTextBox = "txtVakil" Then

                pName = " وکیل "

            End If

            RaiseEvent ShowConfirm("فردی با نام مورد نظر یافت نشد، آیا می خواهید به عنوان " & pName & " جدید در سیستم ثبت شود؟", pName & "جدید")

            UcContacts1.YesClicked = YesClicked

        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت فرد جدید"

            ErrorManager.WriteMessage("UcContacts1_ShowConfirm", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub txtVakil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVakil.KeyPress, txtMoshavere.KeyPress

        lblMessage.Text = String.Empty

        e.Handled = True

    End Sub

    Private Sub UcContacts1_ContactAdd(ByVal c As Lawyer.Common.VB.ContactInfo.ContactInfoReview) Handles UcContacts1.ContactAdd

        lblMessage.Text = String.Empty

        Try


            Select Case UcContacts1.RefTextBox

                Case "txtVakil"

                    txtVakil.Text = c.custFullName

                    RecieverID = c.custID

                Case Else

                    txtMoshavere.Text = c.custFullName

                    MoshavereID = c.custID

            End Select

            UcContacts1.Hide()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtMoshavere_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMoshavere.DragDrop

        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim contact() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In contact

                    If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.موکل Then

                        txtMoshavere.Text = contact(0).Text

                        MoshavereID = item.SubItems(1).Text

                        Exit Sub

                    End If

                Next

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("txtMoshavere_DragDrop", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub txtVakil_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtVakil.DragDrop

        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim contact() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In contact

                    If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.وکیل OrElse CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.کارشناس Then

                        txtVakil.Text = contact(0).Text

                        RecieverID = item.SubItems(1).Text

                        Exit Sub

                    End If

                Next

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("txtVakil_DragDrop", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub txtMoshavere_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMoshavere.DragEnter, txtVakil.DragEnter

        e.Effect = DragDropEffects.Copy

    End Sub

    Private Sub UcContacts1_ContactDetail(ByVal custId As String) Handles UcContacts1.ContactDetail

        lblMessage.Text = String.Empty

        If UcContacts1.RefTextBox = "txtVakil" Then

            txtVakil.Text = String.Empty

            RecieverID = String.Empty

        Else

            txtMoshavere.Text = String.Empty

            MoshavereID = String.Empty

        End If

        RaiseEvent ContactDetail(custId)

        UcContacts1.RefreshContacts()

    End Sub


#End Region

#Region "AttachFile"

    Private Sub lstFiles_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles lstFiles.UserDeletingRow

        lblMessage.Text = String.Empty

        Try
            If Not (lstFiles.SelectedRows IsNot Nothing AndAlso lstFiles.Rows.Count > 0) Then

                e.Cancel = True

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("lstFiles_UserDeletingRow", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub lstFiles_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiles.MouseUp


        lblMessage.Text = String.Empty

        If e.Button = Windows.Forms.MouseButtons.Right AndAlso lstFiles.SelectedRows.Count > 0 Then

            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)

            If hti.Type = DataGridViewHitTestType.Cell Then

                For index As Integer = 0 To lstFiles.Rows.Count - 1

                    lstFiles.Rows(index).Selected = False
                Next

                ContextMenuStrip2.Visible = True

                rowIndex = hti.RowIndex

                lstFiles.Rows(rowIndex).Selected = True

                lstFiles.ContextMenuStrip = ContextMenuStrip2

                lstFiles.ContextMenuStrip.Show(lstFiles, New Point(e.X, e.Y))

            Else

                ContextMenuStrip2.Visible = False

                lstFiles.ContextMenuStrip = Nothing

            End If

        Else

            ContextMenuStrip2.Visible = False

            lstFiles.ContextMenuStrip = Nothing

        End If

    End Sub

    Private Sub lstFiles_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstFiles.DragEnter

        lblMessage.Text = String.Empty

        Try

            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lstFiles_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstFiles.DragDrop

        lblMessage.Text = String.Empty

        Try
            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "DocList" Then

                Dim myItems() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In myItems

                    Try

                        Dim file As String = Docs.TempDocManager.WriteFile(item.SubItems(1).Text, item.SubItems(3).Text)

                        If file <> String.Empty Then

                            AttachFile(file, item.Text)

                        End If

                    Catch ex As Exception

                    End Try

                Next

            End If

        Catch ex As Exception

        End Try

        Try

            If e.Data.GetDataPresent(DataFormats.FileDrop) Then

                Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

                For Each Item As String In files

                    AttachFile(Item)

                Next

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("lstFiles_DragDrop", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub AttachFile(ByVal item As String)

        Dim extension As String = GetExtension(item)

        Dim name As String = GetFileName(item)

        If extension <> String.Empty Then

            If (IsEditMode) Then

                Dim tdoc As New Timing.deskDocs

                tdoc.deskDocExtension = GetExtension(item)

                tdoc.deskDocID = Guid.NewGuid().ToString()

                tdoc.deskDocName = name

                tdoc.deskImageID = BaseForm.ImageManager.GetDefaultIcon_TempDocsTable16(extension)

                tdoc.deskTimeID = CurTiming.timeID

                tdoc.FileFullPath = item

                If Timing.TimingManager.AddTimeDocs(tdoc) Then

                    Dim dr As Integer = lstFiles.Rows.Add()

                    lstFiles.Rows(dr).Cells("gvClmTitle").Value = name

                    lstFiles.Rows(dr).Cells("gvClmName").Value = item

                    lstFiles.Rows(dr).Cells("gvClmImage").Value = images.Images(BaseForm.ImageManager.GetDefaultIcon_TempDocsTable16(extension))

                    lstFiles.Rows(dr).Cells("gvclmnImageID").Value = tdoc.deskImageID

                    lstFiles.Rows(dr).Cells("gvclmFileID").Value = tdoc.deskDocID

                End If

            Else
                Dim dr As Integer = lstFiles.Rows.Add()

                lstFiles.Rows(dr).Cells("gvClmTitle").Value = name

                lstFiles.Rows(dr).Cells("gvClmName").Value = item

                lstFiles.Rows(dr).Cells("gvClmImage").Value = images.Images(BaseForm.ImageManager.GetDefaultIcon_TempDocsTable16(extension))

                lstFiles.Rows(dr).Cells("gvclmnImageID").Value = BaseForm.ImageManager.GetDefaultIcon_TempDocsTable16(extension)


            End If

        End If

    End Sub

    Private Sub AttachFile(ByVal item As String, ByVal title As String)

        Dim extension As String = GetExtension(item)

        If extension <> String.Empty Then

            Dim dr As Integer = lstFiles.Rows.Add()

            lstFiles.Rows(dr).Cells("gvClmTitle").Value = title

            lstFiles.Rows(dr).Cells("gvClmName").Value = item

            lstFiles.Rows(dr).Cells("gvClmImage").Value = images.Images(BaseForm.ImageManager.GetDefaultIcon_TempDocsTable16(extension))

            lstFiles.Rows(dr).Cells("gvclmnImageID").Value = BaseForm.ImageManager.GetDefaultIcon_TempDocsTable16(extension)

        End If

    End Sub

    Private Sub tooltipDelFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooltipDelFile.Click

        lblMessage.Text = String.Empty

        Try

            If rowIndex <> -1 Then

                Dim fileId As String = lstFiles.Rows(rowIndex).Cells("gvclmFileID").Value

                If IsEditMode And Not String.IsNullOrEmpty(fileId) Then

                    YesClicked = False

                    RaiseEvent ShowConfirm(" آیا مایل به حذف هستید؟", "حذف فایل")

                    If YesClicked Then

                        If Timing.TimingManager.DeleteTimingDoc(fileId, CurTiming.timeID) Then

                            lstFiles.Rows.RemoveAt(rowIndex)

                            rowIndex = -1

                        End If

                    End If
                Else

                    lstFiles.Rows.RemoveAt(rowIndex)

                    rowIndex = -1

                End If


            End If



        Catch ex As Exception

            lblMessage.Text = "خطا در حذف"

            ErrorManager.WriteMessage("tooltipDelFile_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub picAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picAttachment.Click

        lblMessage.Text = String.Empty

        Try

            Me.OpenFileDialog1.Filter = "All files (*.*)|*.*"

            If (Me.OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then

                For Each Item As String In OpenFileDialog1.FileNames()

                    AttachFile(Item)

                Next
                '


            End If


        Catch ex As Exception

            ErrorManager.WriteMessage("picAttachment_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub lstFiles_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lstFiles.CellDoubleClick

        lblMessage.Text = String.Empty

        Try

            If e.ColumnIndex = 1 Then

                Dim extension As String = System.IO.Path.GetExtension(lstFiles.Rows(e.RowIndex).Cells(2).Value)

                If extension = ".txt" OrElse extension = ".dot" OrElse extension = ".docx" OrElse extension = ".doc" Then
                    'abbas
                    'openword
                    'RaiseEvent ShowDocContent(lstFiles.Rows(e.RowIndex).Cells(2).Value, lstFiles.Rows(e.RowIndex).Cells(1).Value)
                    Dim fi As New System.IO.FileInfo(lstFiles.Rows(e.RowIndex).Cells(2).Value)
                    Dim ID As String = System.IO.Path.GetFileNameWithoutExtension(lstFiles.Rows(e.RowIndex).Cells(2).Value)

                    '' Timing.TimingManager.EditTimeDocs("E:\Paregoo\lawyer\LawyerApp\bin\Debug\DefaultFolders\Timing\8aecace4-d0e2-42fa-bbba-5dc422dbfd3b.dot", "jan", "server=127.0.0.1;Port=9918;uid=root;pwd=@@%!mysqlnahani;database=nwdicdad2;")
                    Lawyer.Common.VB.Common.FileManager.executeWordFile(ID, lstFiles.Rows(e.RowIndex).Cells(2).Value, System.IO.Path.GetFileNameWithoutExtension(lstFiles.Rows(e.RowIndex).Cells(1).Value), "deskdocs")

                Else

                    System.Diagnostics.Process.Start(lstFiles.Rows(e.RowIndex).Cells(2).Value)
                End If

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("lstFiles_CellClick", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        YesClicked = False

        Try

            RaiseEvent ShowConfirm(" آیا مایل به حذف هستید؟", "حذف مشاوره")

            If YesClicked Then

                If Timing.TimingManager.DeleteTiming(CurTiming.timeID) Then

                    Shaxes.FinanceManager.DeleteFinanceBytimeID(CurTiming.timeID)

                    Me.ParentForm.Close()

                End If

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در حذف"

            ErrorManager.WriteMessage("btnDelete_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        SaveMoshavere(True)

    End Sub


End Class
