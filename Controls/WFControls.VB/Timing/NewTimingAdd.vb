
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.ContactInfo
Imports Lawyer.Common.VB.FileParties
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.TimeParties
Imports Lawyer.Common.VB.Common
Imports System.IO.Path
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Setting
Imports NwdSolutions.Web


Public Class NewTimingAdd

    ' '' ''Delegate Sub ShowFinanceForm(ByVal financeId As String, ByVal IsTimeId As Boolean)
    ' '' ''Event ShowFinanceAdd As ShowFinanceForm

    ' '' '' '' ''Private DicReciver As New Dictionary(Of String, String)

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
    ' '' '' '' مشاوره گیرنده
    ' '' '' '' ''Private MoshavereID As String = String.Empty

    Dim rowIndex As Integer = -1

    ' '' ''Delegate Sub ShowContact()
    ' '' ''Event ShowContactSearch As ShowContact

    Private timingSettingID As String = String.Empty

#Region "Events"

    '' ''Private Sub TimingAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '' ''    ToolTip1.SetToolTip(picAttachment, "افزودن فایل")

    '' ''    ToolTip1.SetToolTip(btnHelp, "لیست افراد موجود در پرونده")

    '' ''    ' '' ''ToolTip1.SetToolTip(picHelp2, "در صورت خالی بودن ، برای کاربر جاری ارسال می گردد")

    '' ''    lblMessage.Text = String.Empty

    '' ''    If IsEditMode AndAlso btnDelete.Visible Then
    '' ''        btnSave.Location = New Point(250, 157)
    '' ''    Else
    '' ''        btnSave.Location = New Point(200, 157)
    '' ''    End If


    '' ''End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        YesClicked = False

        Try

            RaiseEvent ShowConfirm("در صورت تایید ، این اقدام از لیست تمامی دریافت کننده ها حذف خواهد شد. آیا مایل به حذف هستید؟", "حذف اقدام")

            If YesClicked Then

                '' ''If Finance.FinanceManager.IsExistMoshaveredaryafti(tpId) Then

                '' ''    lblMessage.Text = "برای مشاوره مبلغی دریافت شده و امکان حذف وجود ندارد"

                '' ''Else

                If Timing.TimingManager.DeleteTiming(CurTiming.timeID) Then

                    Me.ParentForm.Close()

                End If

                '' ''End If

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در حذف"

            ErrorManager.WriteMessage("btnDelete_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region


#Region "Comment"


    Public Sub NewTask()

        Try


            txtTitle.Focus()

            cmbTimingType.Enabled = True

            picAttachment.Visible = True

            '' ''lstFiles.AllowDrop = True

            ' '' ''SetDesign()

            ''If CurTiming.fileCaseID = String.Empty Then

            ''    ' '' ''pnlReciverG.Visible = True

            ''    ' '' ''Me.Size = New Size(Me.Size.Width, Me.Size.Height + pnlReciverG.Height)

            ''Else
            ''    '' ''pnlReciever.Visible = True

            ''    Me.Size = New Size(Me.Size.Width, Me.Size.Height + pnlReciever.Height)

            ''End If


            isNewTask = True

            IsEditMode = False


        Catch ex As Exception

        End Try

    End Sub

    Public Sub NewTask(ByVal tpId As String)

        Try

            Me.tpId = tpId

            Dim tp As TimeParties = TimePartiesManager.GetTimePartiesInfoByID(tpId)

            If tp IsNot Nothing Then

                TimingDate.SetShamsiDate(tp.timeDate)

                txtDuration.Text = tp.timeDuration

                txtReminder.Text = tp.timeReminderBefore()

                TimingTime.Text = tp.timeTime

                CurTiming = Timing.TimingManager.GetTimingInfoByID(tp.timeID)

                CurTiming.fileCaseID = Guid.Empty.ToString() 'abbas : to show all users in list even in filecase

                If CurTiming.fileCaseID = Guid.Empty.ToString() Then


                    SetTiming()

                    CurTiming.fileCaseID = String.Empty

                    CurTiming.fileID = String.Empty

                Else

                    SetTiming(CurTiming.fileCaseID, CurTiming.fileID)

                End If

                cmbTimingStatus.SelectedValue = tp.timeStatus

                txtDescription.Text = CurTiming.timeText

                txtTitle.Text = CurTiming.timeTitle

                'لود کردن Docs

                Dim docs As Timing.DeskDocsReviewCollection = Timing.TimingManager.GetAllTimingDeskDocs(CurTiming.timeID)

                If docs IsNot Nothing Then

                    Dim lvItem As New ListViewItem

                    lvItem.Text = ""

                    lvItem.SubItems.Add("")

                    lvItem.Font = New System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Underline, GraphicsUnit.Point)

                    lvItem.ForeColor = Color.Blue

                    For Each Item As Timing.DeskDocsReview In docs

                        lvItem.Text = Item.deskDocName

                        lvItem.SubItems(1).Text = Item.deskDocID

                        lvItem.ImageKey = Item.deskImageID

                        '' ''lstFiles.Items.Add(lvItem.Clone())

                    Next

                End If

                isNewTask = True
            End If

        Catch ex As Exception

        End Try

    End Sub



#End Region

#Region "new"

#Region "Bind"

    Public Sub SetTiming()

        Try
            '' ''pnlReminder.Visible = False
            ''abbas 
            '''' LoginManager.SetCurrentLoginDebug("e6a96e46-b0e2-49df-a141-1de32258bdbd")


            isNewTask = False

            IsEditMode = False

            Dim largeImage As New ImageList

            largeImage.ImageSize = New Size(16, 16)

            LoadDefaultImageFromTempDoc()

            BindTimingType()

            cmbTimingType.SelectedIndex = 0

            cmbTimingStatus.DataSource = Timing.TimingManager.GetTimingStatus()

            cmbTimingStatus.SelectedIndex = 0

            cmbReminderType.SelectedIndex = 0

            TimingDate.SetToday = True

            'دریافت کننده
            Dim TargetCusts As ContactInfoReviewCollection = ContactInfoManager.GetAllSysUserExcept(CurrentLogin.CurrentUser.UserID)

            'کاربر جاری

            AddCurrentUserToList()

            For Each Item As ContactInfoReview In TargetCusts

                Dim lstItem As New ListViewItem

                lstItem.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

                lstItem.Text = Item.custFullName

                lstItem.Checked = False

                lstItem.SubItems.Add(Item.custID.ToString())

                lstItem.SubItems.Add(0) 'قبلا انتخاب شده است

                lstTargetSource.Items.Add(lstItem.Clone())

            Next

        Catch ex As Exception

            btnSave.Enabled = False

            btnDelete.Enabled = False

            lblMessage.Text = "خطا در بارگذاری"

            ErrorManager.WriteMessage("SetTiming", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Public Sub SetTiming(ByVal fileCaseId As String, ByVal fileID As String, Optional ByVal CheckedAll As Boolean = True)

        Try



            isNewTask = False

            IsEditMode = False

            Dim largeImage As New ImageList

            largeImage.ImageSize = New Size(16, 16)

            LoadDefaultImageFromTempDoc()

            CurTiming.fileCaseID = fileCaseId

            CurTiming.fileID = fileID

            BindTimingType()

            cmbTimingType.SelectedIndex = 0

            cmbTimingStatus.DataSource = Timing.TimingManager.GetTimingStatus()

            cmbTimingStatus.SelectedIndex = 0

            cmbReminderType.SelectedIndex = 0

            TimingDate.SetToday = True

            'دریافت کننده
            Dim TargetCusts As ContactInfoReviewCollection = ContactInfoManager.GetAllSysUserExcept(CurrentLogin.CurrentUser.UserID)
            ''abbas 
            ''Dim TargetCusts As FilePartiesBaseInfoCollection = FilePartiesManager.GetPartiesByFileCaseOwnerUsersExcept(CurTiming.fileCaseID, CurrentLogin.CurrentUser.UserID)

            AddCurrentUserToList()

            ''''abbas  For Each Item As FilePartiesBaseInfo In TargetCusts
            For Each Item As ContactInfoReview In TargetCusts

                Dim lstItem As New ListViewItem

                lstItem.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

                lstItem.Text = Item.custFullName

                ''abbas
                ' lstItem.Checked = CheckedAll
                lstItem.Checked = False
                '''abbas lstItem.SubItems.Add(Item.contactInfoID.ToString())
                lstItem.SubItems.Add(Item.custID.ToString())
                lstItem.SubItems.Add(0) 'قبلا انتخاب شده است

                lstTargetSource.Items.Add(lstItem.Clone())

            Next

        Catch ex As Exception

            btnSave.Enabled = False

            btnDelete.Enabled = False

            lblMessage.Text = "خطا در بارگذاری"

            ErrorManager.WriteMessage("SetTiming,FilecaseID", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub LoadDefaultImageFromTempDoc()

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

    Public Sub EditReminder(ByVal tpId As String)

        Try

            Me.tpId = tpId

            Dim tp As TimeParties = TimePartiesManager.GetTimePartiesInfoByID(tpId)

            Dim recivers As ContactInfoReviewCollection = TimePartiesManager.GetAllPartiesByTiming(tp.timeID)

            If tp IsNot Nothing Then

                txtDuration.Text = tp.timeDuration

                txtReminder.Text = tp.timeReminderBefore()

                Dim d As New Date(Now.Year, Now.Month, Now.Day, CInt(tp.timeTime.Substring(0, 2)), CInt(tp.timeTime.Substring(3, 2)), CInt(tp.timeTime.Substring(6, 2)))

                TimingTime.Value = d

                CurTiming = Timing.TimingManager.GetTimingInfoByID(tp.timeID)

                If CurTiming.fileCaseID = Guid.Empty.ToString() Then

                    SetTiming()

                    CurTiming.timeID = tp.timeID

                    TimingDate.SetShamsiDate(tp.timeDate)

                    CurTiming.fileCaseID = String.Empty

                    CurTiming.fileID = String.Empty

                Else

                    SetTiming(CurTiming.fileCaseID, CurTiming.fileID, False)

                    CurTiming.timeID = tp.timeID

                    TimingDate.SetShamsiDate(tp.timeDate)

                End If

                IsEditMode = True

                If tp.timeReminderBefore = "0" AndAlso tp.timeDuration = "0" Then

                    rdbTypeNS.Checked = True

                Else

                    rdbTypeS.Checked = True

                    pnlReminder.Visible = True

                End If

                cmbTimingType.SelectedValue = CurTiming.timeType.ToString

                If tp.timeReminderType.HasValue Then

                    cmbReminderType.SelectedIndex = tp.timeReminderType

                Else

                    cmbReminderType.SelectedIndex = 0

                End If

                Try

                    cmbTimingStatus.SelectedValue = tp.timeStatus

                Catch ex As Exception

                    cmbTimingStatus.SelectedIndex = 0

                End Try


                txtDescription.Text = CurTiming.timeText

                txtTitle.Text = CurTiming.timeTitle

                txtNumber.Text = CurTiming.timingNo


                'chkSMS.Checked = False
                ' If CurTiming.timeSms = 1 Then chkSMS.Checked = True

                Dim index As Integer = 0

                For Each Item As ContactInfoReview In recivers

                    While index < lstTargetSource.Items.Count

                        If lstTargetSource.Items(index).SubItems(1).Text = Item.custID Then

                            lstTargetSource.Items(index).Checked = True

                            Exit While

                        End If

                        index += 1

                    End While

                Next


                '    'لود کردن Docs

                Dim docs As Timing.DeskDocsCollection = Timing.TimingManager.GetAllForwardTimingDeskDocs(tp.timeID)

                If docs IsNot Nothing Then

                    For Each Item As Timing.deskDocs In docs

                        Dim dr As Integer = lstFiles.Rows.Add()

                        lstFiles.Rows(dr).Cells("gvClmTitle").Value = Item.deskDocName

                        lstFiles.Rows(dr).Cells("gvclmnImageID").Value = Item.deskImageID

                        lstFiles.Rows(dr).Cells("gvClmName").Value = Item.FileFullPath

                        lstFiles.Rows(dr).Cells("gvClmImage").Value = images.Images(Item.deskImageID)

                    Next

                End If

                If tp.tpTargetCustID = CurTiming.timeSourceCustID Then

                    btnDelete.Visible = True

                End If


            Else

                Throw New Exception("tp is Null")

            End If

            SetForEdit()

        Catch ex As Exception

            btnDelete.Enabled = False

            btnSave.Enabled = False

            lblMessage.Text = "خطا در بارگذاری"

            ErrorManager.WriteMessage("EditReminder", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub SetForEdit()

        txtTitle.ReadOnly = False

        cmbTimingType.Enabled = True

        Me.txtTitle.BackColor = System.Drawing.Color.WhiteSmoke

        Me.lstFiles.BackColor = System.Drawing.Color.WhiteSmoke

        Me.lstTargetSource.BackColor = System.Drawing.Color.WhiteSmoke

        lstTargetSource.Enabled = True

        txtDescription.ReadOnly = False

        Me.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke

        RemoveHandler lstFiles.MouseUp, AddressOf lstFiles_MouseUp

        RemoveHandler lstFiles.DragDrop, AddressOf lstFiles_DragDrop

        picAttachment.Enabled = True

    End Sub

    Public Sub ForwardMessage(ByVal tpId As String)

        Try

            Me.tpId = tpId

            Dim tp As TimeParties = TimePartiesManager.GetTimePartiesInfoByID(tpId)

            Dim recivers As ContactInfoReviewCollection = TimePartiesManager.GetAllPartiesByTiming(tp.timeID)

            If tp IsNot Nothing Then

                txtDuration.Text = tp.timeDuration

                txtReminder.Text = tp.timeReminderBefore()

                Dim d As New Date(Now.Year, Now.Month, Now.Day, CInt(tp.timeTime.Substring(0, 2)), CInt(tp.timeTime.Substring(3, 2)), CInt(tp.timeTime.Substring(6, 2)))

                TimingTime.Value = d

                CurTiming = Timing.TimingManager.GetTimingInfoByID(tp.timeID)

                If CurTiming.fileCaseID = Guid.Empty.ToString() Then

                    SetTiming()

                    CurTiming.timeID = tp.timeID

                    TimingDate.SetShamsiDate(tp.timeDate)

                    CurTiming.fileCaseID = String.Empty

                    CurTiming.fileID = String.Empty

                Else

                    SetTiming(CurTiming.fileCaseID, CurTiming.fileID, False)

                    CurTiming.timeID = tp.timeID

                    TimingDate.SetShamsiDate(tp.timeDate)

                End If

                IsEditMode = False

                If tp.timeReminderBefore = "0" AndAlso tp.timeDuration = "0" Then

                    rdbTypeNS.Checked = True

                Else

                    rdbTypeS.Checked = True

                    pnlReminder.Visible = True

                End If

                cmbTimingType.SelectedValue = CurTiming.timeType.ToString

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

                '    'لود کردن Docs

                Dim docs As Timing.DeskDocsCollection = Timing.TimingManager.GetAllForwardTimingDeskDocs(tp.timeID)

                If docs IsNot Nothing Then

                    For Each Item As Timing.deskDocs In docs

                        Dim dr As Integer = lstFiles.Rows.Add()

                        lstFiles.Rows(dr).Cells("gvClmTitle").Value = Item.deskDocName

                        lstFiles.Rows(dr).Cells("gvclmnImageID").Value = Item.deskImageID

                        lstFiles.Rows(dr).Cells("gvClmName").Value = Item.FileFullPath

                        lstFiles.Rows(dr).Cells("gvClmImage").Value = images.Images(Item.deskImageID)

                    Next

                End If

            End If

        Catch ex As Exception

            btnDelete.Enabled = False

            lblMessage.Text = "خطا در بارگذاری"

            ErrorManager.WriteMessage("EditReminder", ex.ToString(), Me.ParentForm.Text)

        End Try
    End Sub

    Public Sub ReplyMessage(ByVal tpId As String)

        Try

            Dim tp As TimeParties = TimePartiesManager.GetTimePartiesInfoByID(tpId)

            CurTiming = Timing.TimingManager.GetTimingInfoByID(tp.timeID)

            If CurTiming.fileCaseID = Guid.Empty.ToString() Then

                SetTiming()

                CurTiming.fileCaseID = String.Empty

                CurTiming.fileID = String.Empty

            Else

                SetTiming(CurTiming.fileCaseID, CurTiming.fileID, False)

            End If

            If Not String.IsNullOrEmpty(CurTiming.timeSourceCustID) Then

                For index1 As Integer = 0 To lstTargetSource.Items.Count - 1

                    If lstTargetSource.Items(index1).SubItems(1).Text = CurTiming.timeSourceCustID Then

                        lstTargetSource.Items(index1).Checked = True

                        Exit For

                    End If

                Next

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("ReplyMessage", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub


#End Region

#Region "Save"

    Private Function CheckBeforeSave() As Boolean

        Try

            If cmbTimingType.SelectedIndex = -1 Then

                lblMessage.Text = "نوع را تعیین کنید."

                Return False

            End If

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

            Return True

        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت"

            ErrorManager.WriteMessage("CheckBeforeSave", ex.ToString(), Me.ParentForm.Text)

            Return False

        End Try


    End Function

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    '    lblMessage.Text = String.Empty

    '    If CheckBeforeSave() Then

    '        If IsEditMode Then

    '            Try

    '                ' مقایسه برای وقت آزاد یا مشغول
    '                'فقط برای حالت برنامه ریزی شده معنی دارد

    '                Timing.TimingManager.DeleteTiming(CurTiming.timeID)



    '                If rdbTypeS.Checked AndAlso cmbTimingStatus.SelectedValue = "1" Then

    '                    Dim curDate As Integer = TimingDate.GetShamsiDateInNumericFormat

    '                    Dim time As String = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

    '                    Dim str As String = String.Empty

    '                    If TimePartiesManager.IsUserBusyForEdit(CurrentLogin.CurrentUser.UserID, curDate, time, CurTiming.timeID) > 0 Then

    '                        str &= " ," + CurrentLogin.CurrentUser.Name

    '                    End If

    '                    If str <> String.Empty Then

    '                        str = "برای شما " & "در ساعت مورد نظر کار ثبت شده است.آیا مایل به ثبت کار جدید هستید؟"

    '                        RaiseEvent ShowConfirm(str, "اقدامات")

    '                        If Not YesClicked Then

    '                            Exit Sub

    '                        End If

    '                    End If

    '                End If

    '                Dim d As Date

    '                Dim g As New GeneralUtilities.DateConvertor(CommonSettingManager.ConnectionString())

    '                Dim miladiD As Date = g.GetMiladiDate(TimingDate.GetShamsiDate)

    '                Dim AlarmDate As New Date(miladiD.Year, miladiD.Month, miladiD.Day, TimingTime.Value.Hour, TimingTime.Value.Minute, TimingTime.Value.Second)

    '                Select Case cmbReminderType.SelectedIndex


    '                    Case 0
    '                        'دقیقه
    '                        d = DateAdd(DateInterval.Minute, -CDbl(txtReminder.Text), AlarmDate)

    '                    Case 1
    '                        'ساعت
    '                        d = DateAdd(DateInterval.Hour, -CDbl(txtReminder.Text), AlarmDate)

    '                    Case 2
    '                        'روز
    '                        d = DateAdd(DateInterval.DayOfYear, -CDbl(txtReminder.Text), AlarmDate)

    '                End Select


    '                'TimeParties
    '                Dim timeParties As New TimeParties

    '                timeParties.timeTime = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

    '                timeParties.timeReminderBefore = txtReminder.Text

    '                timeParties.timeDuration = txtDuration.Text

    '                timeParties.timeActualTime = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

    '                timeParties.timeActualDate = g.GetShamsiDateInNumericFormat(d)

    '                'If timeParties.timeActualDate < DateManager.GetCurrentShamsiDateInNumericFormat() Then

    '                '    lblMessage.Text = "زمان یادآوری را درست تنظیم نمایید."

    '                '    Exit Sub

    '                'End If

    '                timeParties.timeStatus = cmbTimingStatus.SelectedValue

    '                d = DateAdd(DateInterval.Minute, CDbl(txtDuration.Text), TimingTime.Value)

    '                timeParties.timeEnd = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

    '                timeParties.timeDate = TimingDate.GetShamsiDateInNumericFormat

    '                timeParties.timeDone = rdbTypeNS.Checked

    '                timeParties.timeReminderType = cmbReminderType.SelectedIndex

    '                timeParties.tpID = tpId

    '                If TimePartiesManager.EditParties(timeParties) Then

    '                    ParentForm.Close()

    '                End If

    '            Catch ex As Exception

    '                lblMessage.Text = "خطا در ویرایش"

    '                ErrorManager.WriteMessage("btnSave_Click,Edit", ex.ToString(), Me.ParentForm.Text)

    '            End Try

    '        Else

    '            Try

    '                ' مقایسه برای وقت آزاد یا مشغول
    '                'فقط برای حالت برنامه ریزی شده معنی دارد

    '                If rdbTypeS.Checked AndAlso cmbTimingStatus.SelectedValue = "1" Then

    '                    Dim curDate As Integer = TimingDate.GetShamsiDateInNumericFormat

    '                    Dim time As String = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

    '                    Dim str As String = String.Empty

    '                    For index As Integer = 0 To lstTargetSource.Items.Count - 1

    '                        If lstTargetSource.Items(index).Checked AndAlso TimePartiesManager.IsUserBusy(lstTargetSource.Items(index).SubItems(1).Text, curDate, time) > 0 Then

    '                            str &= " ," + lstTargetSource.Items(index).Text

    '                        End If

    '                    Next


    '                    If str <> String.Empty Then

    '                        str = " برای " & str.Substring(2) & " در ساعت مورد نظر کار ثبت شده است.آیا مایل به ثبت کار جدید هستید؟ "

    '                        RaiseEvent ShowConfirm(str, "اقدامات")

    '                        If Not YesClicked Then

    '                            Exit Sub

    '                        End If

    '                    End If

    '                End If

    '                CurTiming.timeID = Guid.NewGuid.ToString()

    '                CurTiming.timeSourceCustID = CurrentLogin.CurrentUser.UserID

    '                CurTiming.timeText = txtDescription.Text.Trim()

    '                CurTiming.timeTitle = txtTitle.Text.Trim()

    '                CurTiming.timeType = cmbTimingType.SelectedValue

    '                CurTiming.timingNo = txtNumber.Text.Trim()

    '                Dim g As New GeneralUtilities.DateConvertor(CommonSettingManager.ConnectionString())

    '                Dim miladiD As Date = g.GetMiladiDate(TimingDate.GetShamsiDate)

    '                Dim AlarmDate As New Date(miladiD.Year, miladiD.Month, miladiD.Day, TimingTime.Value.Hour, TimingTime.Value.Minute, TimingTime.Value.Second)

    '                If Timing.TimingManager.AddTiming(CurTiming) Then

    '                    'TimeParties
    '                    Dim timeParties As New TimeParties

    '                    timeParties.timeTime = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

    '                    Dim d As Date

    '                    Select Case cmbReminderType.SelectedIndex


    '                        Case 0
    '                            'دقیقه
    '                            d = DateAdd(DateInterval.Minute, -CDbl(txtReminder.Text), AlarmDate)

    '                        Case 1
    '                            'ساعت
    '                            d = DateAdd(DateInterval.Hour, -CDbl(txtReminder.Text), AlarmDate)

    '                        Case 2
    '                            'روز
    '                            d = DateAdd(DateInterval.DayOfYear, -CDbl(txtReminder.Text), AlarmDate)

    '                    End Select

    '                    timeParties.timeReminderBefore = txtReminder.Text

    '                    timeParties.timeDuration = txtDuration.Text

    '                    timeParties.timeActualTime = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

    '                    timeParties.timeActualDate = g.GetShamsiDateInNumericFormat(d)

    '                    timeParties.timeStatus = cmbTimingStatus.SelectedValue

    '                    d = DateAdd(DateInterval.Minute, CDbl(txtDuration.Text), TimingTime.Value)

    '                    timeParties.timeEnd = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

    '                    timeParties.timeDate = TimingDate.GetShamsiDateInNumericFormat

    '                    timeParties.timeDone = rdbTypeNS.Checked

    '                    timeParties.timeID = CurTiming.timeID

    '                    timeParties.timeReminderType = cmbReminderType.SelectedIndex

    '                    Dim isUserRegBefore As Boolean = False

    '                    For Each Item As ListViewItem In lstTargetSource.CheckedItems

    '                        If CurrentLogin.CurrentUser.UserID <> Item.SubItems(1).Text Then

    '                            timeParties.tpID = Guid.NewGuid().ToString()

    '                            timeParties.tpTargetCustID = Item.SubItems(1).Text

    '                            Try
    '                                TimePartiesManager.AddParties(timeParties)

    '                            Catch ex As Exception
    '                                ErrorManager.WriteMessage("btnSave_Click,AddParties,2", ex.ToString(), Me.ParentForm.Text)
    '                            End Try

    '                        End If

    '                    Next

    '                    'برای ارسال کننده هم ارسال می شود
    '                    timeParties.tpID = Guid.NewGuid().ToString()

    '                    timeParties.tpTargetCustID = CurrentLogin.CurrentUser.UserID

    '                    Try
    '                        TimePartiesManager.AddParties(timeParties)

    '                    Catch ex As Exception

    '                        ErrorManager.WriteMessage("btnSave_Click,AddParties,sender", ex.ToString(), Me.ParentForm.Text)

    '                    End Try

    '                End If


    '                'TimeDocs

    '                Dim tDoc As New Timing.deskDocs

    '                For Each Item As DataGridViewRow In lstFiles.Rows

    '                    tDoc.deskDocExtension = GetExtension(Item.Cells(2).Value)

    '                    tDoc.deskDocID = Guid.NewGuid().ToString()

    '                    tDoc.deskDocName = Item.Cells(1).Value

    '                    tDoc.deskImageID = Item.Cells(3).Value

    '                    tDoc.deskTimeID = CurTiming.timeID

    '                    tDoc.FileFullPath = Item.Cells(2).Value


    '                    Try

    '                        Timing.TimingManager.AddTimeDocs(tDoc)

    '                    Catch ex As Exception

    '                        ErrorManager.WriteMessage("btnSave_Click,AddTimeDocs", ex.ToString(), Me.ParentForm.Text)

    '                    End Try



    '                Next

    '                ResetElements()

    '                lblMessage.Text = "ثبت انجام شد."

    '            Catch ex As Exception

    '                lblMessage.Text = "خطا در ثبت"

    '                ErrorManager.WriteMessage("btnSave_Click,Save", ex.ToString(), Me.ParentForm.Text)

    '            End Try

    '        End If

    '    End If

    'End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        ''abbas
        '' LoginManager.SetCurrentLoginDebug("e6a96e46-b0e2-49df-a141-1de32258bdbd")

        lblMessage.Text = String.Empty
        Dim lst As New List(Of String)

        If CheckBeforeSave() Then

            If IsEditMode Then

                Try
                    Timing.TimingManager.DeleteTiming(CurTiming.timeID)
                Catch ex As Exception

                    lblMessage.Text = "خطا در ویرایش"

                    ErrorManager.WriteMessage("btnSave_Click,Edit", ex.ToString(), Me.ParentForm.Text)
                    Exit Sub
                End Try
            End If



            ' مقایسه برای وقت آزاد یا مشغول
            'فقط برای حالت برنامه ریزی شده معنی دارد

            If rdbTypeS.Checked AndAlso cmbTimingStatus.SelectedValue = "1" Then

                Dim curDate As Integer = TimingDate.GetShamsiDateInNumericFormat

                Dim time As String = TimingTime.Value.Hour.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Minute.ToString().PadLeft(2, "0"c) & ":" & TimingTime.Value.Second.ToString().PadLeft(2, "0"c)

                Dim str As String = String.Empty

                For index As Integer = 0 To lstTargetSource.Items.Count - 1

                    If lstTargetSource.Items(index).Checked AndAlso TimePartiesManager.IsUserBusy(lstTargetSource.Items(index).SubItems(1).Text, curDate, time) > 0 Then

                        str &= " ," + lstTargetSource.Items(index).Text

                    End If

                Next


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

            CurTiming.timeType = cmbTimingType.SelectedValue

            CurTiming.timingNo = txtNumber.Text.Trim()

            '' to get the fileid, if timming is for a filecase
            Dim fileCustID As String = String.Empty
            Dim fileID As String = CurTiming.fileID
            Try
                If fileID IsNot Nothing Then
                    fileCustID = Lawyer.Common.VB.Docs.FileDocManager.GetFileCustId(fileID)
                End If

            Catch ex As Exception

            End Try



            CurTiming.timeSms = 0
            ' If chkSMS.Checked Then CurTiming.timeSms = 1

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



                For Each Item As ListViewItem In lstTargetSource.CheckedItems

                    If CurrentLogin.CurrentUser.UserID <> Item.SubItems(1).Text Then

                        timeParties.tpID = Guid.NewGuid().ToString()

                        timeParties.tpTargetCustID = Item.SubItems(1).Text

                        lst.Add(timeParties.tpTargetCustID)

                        Try
                            TimePartiesManager.AddParties(timeParties)

                        Catch ex As Exception
                            ErrorManager.WriteMessage("btnSave_Click,AddParties,2", ex.ToString(), Me.ParentForm.Text)
                        End Try

                    End If

                Next

                'برای ارسال کننده هم ارسال می شود
                timeParties.tpID = Guid.NewGuid().ToString()

                timeParties.tpTargetCustID = CurrentLogin.CurrentUser.UserID

                lst.Add(timeParties.tpTargetCustID)

                Try
                    TimePartiesManager.AddParties(timeParties)

                Catch ex As Exception

                    ErrorManager.WriteMessage("btnSave_Click,AddParties,sender", ex.ToString(), Me.ParentForm.Text)

                End Try

            End If


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

            If IsEditMode Then ParentForm.Close()

            lblMessage.Text = "ثبت انجام شد."

            ''abbas sms

            ''abbas send sms

        If Lawyer.Common.VB.SmsManager.getSmsConfig() = True Then
            Dim orgName As String = ""
            If Lawyer.Common.VB.Setting.SettingManager.GetSettingsByName("smsorgname").Count > 0 Then orgName = Lawyer.Common.VB.Setting.SettingManager.GetSettingsByName("smsorgname")(0).settingValue

            RaiseEvent _showSmsForm(Nothing, CurTiming.timeID, Nothing, Nothing)

        End If

        Try

            ResetElements()
        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت"

            ErrorManager.WriteMessage("btnSave_Click,Save", ex.ToString(), Me.ParentForm.Text)

        End Try







        End If



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



        'chkSMS.Checked = False


    End Sub

#End Region

#Region "Initial & Design"

    Private Sub TimingAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'timingSettingID = SettingManager.GetIDBySettingName("TimingType")

        ToolTip1.SetToolTip(picAttachment, "افزودن فایل")

        ToolTip1.SetToolTip(btnHelp, "لیست کاربران")

        If CurTiming.fileCaseID = String.Empty Then

            ToolTip1.SetToolTip(btnHelp, "لیست کاربران")

        End If

        lblMessage.Text = String.Empty

        If IsEditMode AndAlso btnDelete.Visible Then

            btnSave.Location = New Point(250, btnSave.Location.Y)

        Else

            btnSave.Location = New Point(200, btnSave.Location.Y)

        End If


    End Sub

    Private Sub rdbTypeS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTypeS.CheckedChanged, rdbTypeNS.CheckedChanged

        Try

            pnlReminder.Visible = rdbTypeS.Checked

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtReminder_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReminder.KeyPress, txtDuration.KeyPress

        Try

            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

                e.Handled = True

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub AddCurrentUserToList()

        Try

            Dim lstItem As New ListViewItem

            lstItem.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

            lstItem.Text = CurrentLogin.CurrentUser.Name

            lstItem.Checked = True

            lstItem.SubItems.Add(CurrentLogin.CurrentUser.UserID.ToString())

            lstItem.SubItems.Add(0) 'قبلا انتخاب شده است

            lstTargetSource.Items.Add(lstItem.Clone())


        Catch ex As Exception

            ErrorManager.WriteMessage("AddCurrentUserToList", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#Region "TimingType"

    Private Sub BindTimingType()

        Try

            Dim TimingTypeSource As New BindingSource

            cmbTimingType.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            cmbTimingType.AutoCompleteSource = AutoCompleteSource.ListItems

            TimingTypeSource.DataSource = Timing.TimingManager.GetFileCaseTimingType()

            If TimingTypeSource IsNot Nothing Then

                cmbTimingType.DataSource = TimingTypeSource

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadTimingType()

        Dim TimingTypeSource As New BindingSource

        TimingTypeSource.DataSource = Timing.TimingManager.GetFileCaseTimingType()

        If TimingTypeSource Is Nothing OrElse TimingTypeSource.Count = 0 Then

            clearComboboxItems(cmbTimingType)

        Else

            cmbTimingType.DataSource = TimingTypeSource

        End If

    End Sub

    Private Sub clearComboboxItems(ByRef cmb As ComboBox)

        Try

            If cmb.DataSource IsNot Nothing Then


                CType(cmb.DataSource, BindingSource).Clear()

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("clearComboboxItems", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub cmbTimingType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTimingType.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode = Keys.Enter Then

            SaveTimingType()

        End If

    End Sub

    Private Sub SaveTimingType()

        lblMessage.Text = String.Empty

        Try

            Dim newItem As New Setting

            If cmbTimingType.Text.Trim() = String.Empty Then

                cmbTimingType.Text = String.Empty

                Exit Sub

            End If

            Dim a As New SettingComplete

            If cmbTimingType.SelectedIndex = -1 Then
                If timingSettingID = String.Empty Then timingSettingID = SettingManager.GetIDBySettingName("TimingType")
                a.settingGroupID = timingSettingID

                a.settingID = Guid.NewGuid.ToString

                a.settingName = cmbTimingType.Text.Trim()

                newItem.settingName = a.settingName

                Dim mId As Decimal? = SettingManager.GetMaxValueByType(timingSettingID)

                If (Not mId.HasValue) OrElse mId.Value < 15 Then

                    mId = 15

                End If

                newItem.settingValue = mId

                a.settingValue = mId

                If SettingManager.AddSetting(a) Then

                    CType(cmbTimingType.DataSource, BindingSource).Add(newItem)

                    cmbTimingType.SelectedValue = mId.ToString()

                    cmbTimingType.DisplayMember = "settingName"

                    cmbTimingType.ValueMember = "settingValue"

                    lblMessage.Text = "نوع جدید اضافه شد."
                Else

                    cmbTimingType.Text = String.Empty

                    lblMessage.Text = "خطا در ثبت نوع"

                    Exit Sub

                End If


            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("SaveTimingType", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub ToolStrip_Del_ALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Del_ALL.Click

        lblMessage.Text = String.Empty

        YesClicked = False

        Try
            If timingSettingID = String.Empty Then timingSettingID = SettingManager.GetIDBySettingName("TimingType")

            If cmbTimingType.SelectedIndex <> -1 Then


                If Timing.TimingManager.IsExistTiminglistByTimingType(cmbTimingType.SelectedValue) Then

                    RaiseEvent ShowConfirm("آیا برای حذف مطمئن هستید؟", "حذف نوع اقدام")

                    If YesClicked Then

                        If SettingManager.DelSettingByGroupIDAndValue(timingSettingID, cmbTimingType.SelectedValue) Then

                            LoadTimingType()

                        End If

                    End If

                Else

                    lblMessage.Text = "امکان حذف به دلیل ثبت رکورد وجود ندارد."

                End If

            End If


        Catch ex As Exception

            ErrorManager.WriteMessage("ToolStrip_Del_ALL_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#Region "AttachFile"

    Private Sub lstFiles_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles lstFiles.UserDeletingRow

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

        Try

            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lstFiles_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstFiles.DragDrop

        lblMessage.Text = String.Empty

        Try

            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

            For Each Item As String In files

                AttachFile(Item)

            Next

        Catch ex As Exception

            ErrorManager.WriteMessage("lstFiles_DragDrop", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub AttachFile(ByVal item As String)

        Dim extension As String = GetExtension(item)

        Dim name As String = GetFileName(item)

        If extension <> String.Empty Then

            Dim dr As Integer = lstFiles.Rows.Add()

            lstFiles.Rows(dr).Cells("gvClmTitle").Value = name

            lstFiles.Rows(dr).Cells("gvClmName").Value = item

            lstFiles.Rows(dr).Cells("gvClmImage").Value = images.Images(BaseForm.ImageManager.GetDefaultIcon_TempDocsTable16(extension))

            lstFiles.Rows(dr).Cells("gvclmnImageID").Value = BaseForm.ImageManager.GetDefaultIcon_TempDocsTable16(extension)

        End If

    End Sub

    Private Sub tooltipDelFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooltipDelFile.Click

        lblMessage.Text = String.Empty

        Try

            If rowIndex <> -1 Then

                lstFiles.Rows.RemoveAt(rowIndex)

                rowIndex = -1

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

                    RaiseEvent ShowDocContent(lstFiles.Rows(e.RowIndex).Cells(2).Value, lstFiles.Rows(e.RowIndex).Cells(1).Value)

                Else

                    System.Diagnostics.Process.Start(lstFiles.Rows(e.RowIndex).Cells(2).Value)
                End If

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("lstFiles_CellClick", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#End Region

End Class
