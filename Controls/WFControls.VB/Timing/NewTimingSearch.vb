Imports Lawyer.Common.VB.Timing
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.TimeParties
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.CommonSetting
Imports NwdSolutions.Web

Public Class NewTimingSearch

    Delegate Sub ShowForm(ByVal IsKartabl As Boolean, ByVal timePartiesID As String)

    Event ShowKartablDetail As ShowForm

#Region "Initial"

    Private Sub TimingSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            '''abbas
            ''LoginManager.SetCurrentLoginDebug("df8718ac-77b0-4ca2-a7e2-d4bdaaa521e7")


            ToolTip1.SetToolTip(btnPrint, "چاپ")

            lblMessage.Text = String.Empty

            DataGridView1.AllowUserToResizeColumns = True

            DataGridView1.ColumnHeadersVisible = False

            'set Type
            Dim c As Setting.SettingCollection = TimingManager.GetFileCaseTimingType()

            If c Is Nothing Then

                c = New Setting.SettingCollection()

            End If

            c.Insert(0, (New Setting.Setting("همه موارد", "-1")))

            cmbType.DataSource = c

            cmbType.SelectedValue = "-1"

            BindSubject()

            'Set Status
            cmbStatus.SelectedIndex = 0


            'SetDate
            cmbDay.SelectedIndex = 7

            cmbDateType.SelectedIndex = 0

            cmbRange.SelectedIndex = 0

            'Set Sender & reciever

            cmbUserId.DisplayMember = "custFullName"

            cmbUserId.ValueMember = "custID"

            cmbSender.DisplayMember = "custFullName"

            cmbSender.ValueMember = "custID"

            Dim uList As ContactInfo.ContactInfoReviewCollection = ContactInfo.ContactInfoManager.GetAllSysUser()

            If uList Is Nothing Then uList = New ContactInfo.ContactInfoReviewCollection()

            uList.Add(New ContactInfo.ContactInfoReview("-1", "همه موارد"))

            cmbSender.DataSource = uList

            cmbUserId.DataSource = ContactInfo.ContactInfoManager.GetAllSysUser()

            If CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.منشی OrElse CurrentLogin.CurrentUser.IsAdmin Then

                cmbUserId.Enabled = True
                chkSeeAll.Visible = True

            Else
                chkSeeAll.Visible = False
                cmbUserId.Enabled = False

            End If

            cmbSender.SelectedValue = "-1"

            cmbUserId.SelectedValue = CurrentLogin.CurrentUser.UserID

            cmbFileCaseStatus.SelectedIndex = 1

            CreateTable()

            ' '' ''dtResult.Columns.Add(New DataColumn("",System.Type.GetType("System.String"),
            Search()

        Catch ex As Exception

            btnSearch.Enabled = False

            Exit Sub

        End Try

    End Sub

    Private Sub BindSubject()

        Try

            txtFilecaseSubject.AutoCompleteCustomSource = FileCaseManager.GetAllFileCaseSubjects()

        Catch ex As Exception

        End Try


    End Sub

#End Region

#Region "Search"

    Dim tpWhere As String = String.Empty

    Dim tWhere As String = String.Empty

    Dim fcWhere As String = String.Empty

    Dim dtResult As New DataTable

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Search()

    End Sub

    Public Sub Search()

        Try

            If cmbUserId.SelectedIndex = -1 Then

                lblMessage.Text = "موردی یافت نشد."

                Exit Sub

            End If

            DataGridView1.ColumnHeadersVisible = True

            lblMessage.Text = String.Empty

            tpWhere = String.Empty
            tWhere = String.Empty
            fcWhere = String.Empty

            If CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.منشی OrElse CurrentLogin.CurrentUser.IsAdmin Then
                If chkSeeAll.Checked Then
                    tpWhere = " where 1=1"
                Else
                    tpWhere = " where tpTargetCustID='" & cmbUserId.SelectedValue & "'"
                End If
       
            End If


                Select Case cmbStatus.SelectedIndex

                    Case 1

                        tpWhere &= " and timeDone=1"

                    Case 2

                        tpWhere &= " and  timeDone=0"

                End Select

                Dim fromDate As Date = Date.Now()

                Dim plusOrNeg As Int16 = -1

                If cmbRange.SelectedIndex = 0 Then plusOrNeg = 1

                Dim toDate As Date

                Select Case cmbDateType.SelectedIndex


                    Case 0
                        'روز
                        toDate = DateAdd(DateInterval.DayOfYear, plusOrNeg * CDbl(cmbDay.SelectedIndex), fromDate)

                    Case 1
                        'ماه
                        toDate = DateAdd(DateInterval.Month, plusOrNeg * CDbl(cmbDay.SelectedIndex), fromDate)

                    Case 2
                        'سال
                        toDate = DateAdd(DateInterval.Year, plusOrNeg * CDbl(cmbDay.SelectedIndex), fromDate)

                End Select

                Dim g As New GeneralUtilities.DateConvertor(CommonSettingManager.ConnectionString())

                If plusOrNeg = -1 Then

                    tpWhere &= " and timeDate >=" & g.GetShamsiDateInNumericFormat(toDate)

                    tpWhere &= " and timeDate <=" & g.GetShamsiDateInNumericFormat(fromDate)

                Else

                    tpWhere &= " and timeDate >=" & g.GetShamsiDateInNumericFormat(fromDate)

                    tpWhere &= " and timeDate <=" & g.GetShamsiDateInNumericFormat(toDate)

                End If


                tWhere = " where  timeType<>4 "

                If cmbType.SelectedValue <> "-1" Then

                    tWhere &= " and  timeType=" & cmbType.SelectedValue

                End If

                Dim filecaseMode As Boolean = True

                If cmbSender.SelectedValue <> "-1" Then

                    tWhere &= "  and  timeSourceCustID='" & cmbSender.SelectedValue & "'"

                End If

                If txtSubject.Text.Trim() <> String.Empty Then

                    tWhere &= "  and timeTitle like'%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text) & "%'"

                End If


                If txtFilecaseNo.Text.Trim() <> String.Empty Then

                    fcWhere = "(fileCaseNumberInSystem='" & txtFilecaseNo.Text & "'" & " or fileCaseNumberInCourt='" & txtFilecaseNo.Text & "'" & " or fileCaseNumberInBranch='" & txtFilecaseNo.Text & "')"

                End If

                If txtFilecaseSubject.Text.Trim() <> String.Empty Then

                    If fcWhere <> String.Empty Then fcWhere &= " and "

                    fcWhere &= "fileCaseSubject like '%" & txtFilecaseSubject.Text & "%'"

                End If

                'مختومه
                If cmbFileCaseStatus.SelectedIndex = 2 Then

                    If fcWhere <> String.Empty Then fcWhere &= " and "

                    fcWhere &= "fileCaseCloseDate is not null"

                    'جاری
                ElseIf cmbFileCaseStatus.SelectedIndex = 1 Then

                    If fcWhere <> String.Empty Then fcWhere &= " and "

                    fcWhere &= "fileCaseCloseDate is  null"


                End If

                Dim f As String = String.Empty

                If txtMovakel.Text <> String.Empty Then

                    f &= " select * from     ("

                    f &= " select filecaseId ,fileCaseNumberInCourt, fileCaseNumberInBranch,  fileCaseNumberInSystem "

                    f &= "  from  filecases "

                    f &= "  Join( "

                    f &= " Select fileCaseID  FROM         fileparties "

                    f &= " where contactInfoID='" & movakelId & "'"

                    f &= " )fp using  (filecaseID) "

                    If fcWhere <> String.Empty Then fcWhere = " where " & fcWhere

                    fcWhere = f & fcWhere & " ) fc1 "

                    fcWhere &= " ) fc using  (filecaseID)"


                Else

                    f &= " select filecaseId ,fileCaseNumberInCourt, fileCaseNumberInBranch,  fileCaseNumberInSystem "

                    f &= "  from  filecases "

                    If fcWhere <> String.Empty Then fcWhere = " where " & fcWhere

                    fcWhere = f & fcWhere & " ) fc using  (filecaseID) "

                End If

                BindTiming(filecaseMode)

                If DataGridView1.Rows.Count = 0 Then

                    lblMessage.Text = "موردی یافت نشد."

                End If

        Catch ex As Exception

            lblMessage.Text = "خطا در انجام عملیات."

            ErrorManager.WriteMessage("Search", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub CreateTable()

        If dtResult.Columns.Count <= 0 Then

            dtResult.Columns.Add("timeTitle")
            dtResult.Columns.Add("fileCaseNumber")
            dtResult.Columns.Add("custFullName")
            dtResult.Columns.Add("targetcustName")
            dtResult.Columns.Add("timeTypeName")
            dtResult.Columns.Add("timeFullDate")
            dtResult.Columns.Add("tpID")
            dtResult.Columns.Add("timeDone")
            dtResult.Columns.Add("filecaseid", System.Type.GetType("System.String"))
            dtResult.Columns.Add("timeTime")
            dtResult.Columns.Add("timeDate")
            dtResult.Columns.Add("timeText")

        End If


    End Sub

    Private Sub BindTiming(ByVal fileCaseMode As Boolean)

        DataGridView1.Columns.Clear()

        Dim gvClmTitle As New System.Windows.Forms.DataGridViewLinkColumn
        Dim gvClmDate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvClmID As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvclmDone As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim gvClmName As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvtargetCustName As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvfcNum As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvClmTypeName As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvtimeText As New System.Windows.Forms.DataGridViewTextBoxColumn
        'gvClmTitle
        gvClmTitle.DataPropertyName = "timeTitle"
        gvClmTitle.HeaderText = ""
        gvClmTitle.Name = "timeTitle"
        gvClmTitle.ReadOnly = True
        gvClmTitle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        gvClmTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        gvClmTitle.HeaderText = "عنوان"
        gvClmTitle.Width = 120
        gvClmTitle.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(102, Byte), Integer))
        gvClmTitle.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(102, Byte), Integer))
        gvClmTitle.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(102, Byte), Integer))
        gvClmTitle.LinkBehavior = LinkBehavior.NeverUnderline

        'gvClmName

        '

        gvfcNum.DataPropertyName = "fileCaseNumber"
        gvfcNum.HeaderText = ""
        gvfcNum.Name = "gvfcNum"
        gvfcNum.ReadOnly = True
        gvfcNum.HeaderText = "شماره پرونده"
        gvfcNum.Width = 100


        gvtimeText.DataPropertyName = "timeText"
        gvtimeText.HeaderText = ""
        gvtimeText.Name = "gvtimeText"
        gvtimeText.ReadOnly = True
        gvtimeText.HeaderText = "شرح"
        gvtimeText.Width = 100

        gvClmName.DataPropertyName = "custFullName"
        gvClmName.HeaderText = ""
        gvClmName.Name = "gvClmName"
        gvClmName.ReadOnly = True
        gvClmName.HeaderText = "فرستنده"
        gvClmName.Width = 70

        gvtargetCustName.DataPropertyName = "targetcustName"
        gvtargetCustName.HeaderText = ""
        gvtargetCustName.Name = "gvtargetCustName"
        gvtargetCustName.ReadOnly = True
        gvtargetCustName.HeaderText = "گیرنده"
        gvtargetCustName.Width = 70
      
        ''gvClmType
        ''
        gvClmTypeName.DataPropertyName = "timeTypeName"
        gvClmTypeName.HeaderText = ""
        gvClmTypeName.Name = "timeTypeName"
        gvClmTypeName.ReadOnly = True
        gvClmTypeName.HeaderText = "نوع"
        gvClmTypeName.Width = 70
        '
        'gvClmDate
        '
        gvClmDate.DataPropertyName = "timeFullDate"
        gvClmDate.HeaderText = ""
        gvClmDate.Name = "timeFullDate"
        gvClmDate.ReadOnly = True
        gvClmDate.Width = 120
        gvClmDate.HeaderText = "تاریخ"


        '
        'gvClmID
        '
        gvClmID.DataPropertyName = "tpID"
        gvClmID.HeaderText = ""
        gvClmID.Name = "gvClmID"
        gvClmID.ReadOnly = True
        gvClmID.Visible = False


        'gvClmcheck
        '
        gvclmDone.DataPropertyName = "timeDone"
        gvclmDone.HeaderText = ""
        gvclmDone.Name = "timeDone"
        gvclmDone.ReadOnly = True
        gvclmDone.Width = 25
        gvclmDone.SortMode = DataGridViewColumnSortMode.Automatic

        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {gvClmID, gvclmDone, gvClmTitle, gvClmTypeName, gvClmDate, gvClmName, gvtargetCustName, gvfcNum, gvtimeText})

        Dim b As New BindingSource

        DataGridView1.AutoGenerateColumns = False

        Dim list As TimingFullSearchCollection = TimingManager.TimingSearch(tpWhere, tWhere, fcWhere, fileCaseMode)

        dtResult.Rows.Clear()

        If list IsNot Nothing Then

            For Each Item As TimingFullSearch In list

                Dim dtNewRow As DataRow
                dtNewRow = dtResult.NewRow()
                dtNewRow.Item("timeTitle") = Item.timeTitle
                dtNewRow.Item("fileCaseNumber") = Item.fileCaseNumber
                dtNewRow.Item("custFullName") = Item.custFullName
                dtNewRow.Item("targetcustName") = Item.targetcustName
                dtNewRow.Item("timeTypeName") = Item.timeTypeName
                dtNewRow.Item("timeFullDate") = Item.timeFullDate
                dtNewRow.Item("tpID") = Item.tpID
                dtNewRow.Item("timeDone") = Item.timeDone
                dtNewRow.Item("filecaseid") = Item.filecaseid
                dtNewRow.Item("timeTime") = Item.timeTime
                dtNewRow.Item("timeDate") = Item.StrtimeDate
                dtNewRow.Item("timeText") = Item.timeText

                dtResult.Rows.Add(dtNewRow)

            Next

            b.DataSource = dtResult

            'AddHandler b.ListChanged, AddressOf listchanged
            DataGridView1.DataSource = b

        Else

            DataGridView1.DataSource = Nothing

        End If

        SetDatagridview()

    End Sub

    'Private Sub listchanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs)

    '    Dim dv = DirectCast(DataGridView1.DataSource, DataView)

    '    MessageBox.Show(String.Format("Sort on column {0}", dv.Sort))

    'End Sub


    Private Sub rdbFilecase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbFilecase.CheckedChanged, rdbNoFilecase.CheckedChanged

        SetDatagridview()

    End Sub

    Private Sub SetDatagridview()

        pnlFileCase.Visible = Not rdbNoFilecase.Checked

        If rdbNoFilecase.Checked Then

            UcContacts1.Hide()

        End If

        If dtResult IsNot Nothing AndAlso dtResult.Rows.Count > 0 Then

            Dim dt As DataTable = dtResult.Copy()

            If rdbNoFilecase.Checked Then

                dt.DefaultView.RowFilter = " filecaseid='" & Guid.Empty.ToString & "'"

                dt = dt.DefaultView.ToTable()

            ElseIf rdbFilecase.Checked Then

                dt.DefaultView.RowFilter = " filecaseid <>'" & Guid.Empty.ToString & "'"

                dt = dt.DefaultView.ToTable()


            End If

            setDesign(Not rdbNoFilecase.Checked)

            Dim b As New BindingSource

            b.DataSource = dt

            DataGridView1.DataSource = b

        Else

            DataGridView1.DataSource = Nothing

        End If

    End Sub

    Private Sub setDesign(ByVal isFilecaseMode As Boolean)

        If isFilecaseMode Then

            pnlFileCase.Visible = True

            pnlFileCase.Height = 67

            pnlGrid.Height = 370

        Else

            pnlFileCase.Visible = False

            pnlFileCase.Height = 0

            pnlGrid.Height = 370 + 67


        End If

    End Sub

#End Region

#Region "DataGridview"

    ' '' ''Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

    ' '' ''    Try

    ' '' ''        If DataGridView1.Columns(e.ColumnIndex).Name = "timeDone" Then

    ' '' ''            If CBool(e.Value) Then

    ' '' ''                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.Font = New Font("Tahoma", 8, System.Drawing.FontStyle.Strikeout)

    ' '' ''            Else
    ' '' ''                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.Font = New Font("Tahoma", 8, System.Drawing.FontStyle.Regular)

    ' '' ''            End If

    ' '' ''        End If

    ' '' ''    Catch ex As Exception

    ' '' ''    End Try

    ' '' ''End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try

            If e.RowIndex <> -1 Then


                Dim tpId As String = DataGridView1.Rows(e.RowIndex).Cells("gvClmID").Value

                If e.ColumnIndex = 1 Then

                    Dim IsCheck As Boolean = DataGridView1.Rows(e.RowIndex).Cells("timeDone").Value

                    Dim result As Boolean = TimePartiesManager.EditTimingDoneField(tpId, Not IsCheck)

                    If result Then

                        DataGridView1.Rows(e.RowIndex).Cells("timeDone").Value = Not IsCheck

                    End If

                ElseIf e.ColumnIndex = 2 Then

                    RaiseEvent ShowKartablDetail(True, tpId)

                    Search()

                End If

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("DataGridView1_CellClick", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#Region "movakel"

    Private movakelId As String = String.Empty

    Delegate Sub ContactDetailHandler(ByVal custId As String)

    Event ContactDetail As ContactDetailHandler

    Private Sub txtMovakel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMovakel.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode <> Keys.Delete Then

            UcContacts1.Focus()

            UcContacts1.BindContacts(ucContacts.SearchType.role, Lawyer.Common.VB.ContactInfo.Enums.RoleType.موکل, New Point(270, 3), "", "")

        Else

            txtMovakel.Text = String.Empty

            movakelId = String.Empty

        End If

    End Sub

    Private Sub txtMovakel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMovakel.KeyPress

        lblMessage.Text = String.Empty

        e.Handled = True

    End Sub

    Private Sub UcContacts1_ContactAdd(ByVal c As Lawyer.Common.VB.ContactInfo.ContactInfoReview) Handles UcContacts1.ContactAdd

        Try

            txtMovakel.Text = c.custFullName

            movakelId = c.custID

            UcContacts1.Hide()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub UcContacts1_ContactDetail(ByVal custId As String) Handles UcContacts1.ContactDetail

        lblMessage.Text = String.Empty

        txtMovakel.Text = String.Empty

        RaiseEvent ContactDetail(custId)

        UcContacts1.RefreshContacts()

    End Sub

    Private Sub txtMovakel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMovakel.DragDrop

        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim contact() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In contact

                    If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.موکل Then

                        txtMovakel.Text = contact(0).Text

                        movakelId = item.SubItems(1).Text

                        Exit Sub

                    End If

                Next

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("txtMovakelr_DragDrop", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub txtMovakel_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMovakel.DragEnter

        e.Effect = DragDropEffects.Copy

    End Sub

#End Region

#Region "print"

    Delegate Sub ReportForm(ByVal c As DataTable, ByVal title As String)

    Event ShowReport As ReportForm



    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try
            lblMessage.Text = String.Empty

            Dim b As BindingSource = DataGridView1.DataSource

            Dim c As DataTable = b.DataSource

            RaiseEvent ShowReport(c, "")


        Catch ex As Exception


        End Try

    End Sub

#End Region


    'Private Sub DataGridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
    '    'Dim sort As String = DataGridView1.SortedColumn.Name
    '    'sort += " Asc"
    '    'If DataGridView1.SortOrder = SortOrder.Descending Then sort += " DESC"

    '    'b.Sort = sort

    '    b = DataGridView1.DataSource

    '    'Dim b As BindingSource = DataGridView1.DataSource
    '    'b.Sort = DataGridView1.SortedColumn.Name
    'End Sub
End Class
