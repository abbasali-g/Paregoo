Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.Docs
Imports WFControls.VB
Imports Lawyer.Common.VB.TimeParties

Public Class frmMoshavere

#Region "Design"

    Dim IsSearchMode As Boolean = True
    Dim _fileId As String = String.Empty

    Private Sub setLinkedSearch()
        ''abbas
        ''Lawyer.Common.VB.Login.LoginManager.SetCurrentLoginDebug("e6a96e46-b0e2-49df-a141-1de32258bdbd")

        lblMessage.Text = String.Empty

        Try
            pnlAdd.Visible = IsSearchMode

            If IsSearchMode Then

                lnkChangeDesign.Text = "مشاوره های ثبت شده"

                lnkChangeDesign.Location = New Point(14, 1)

                pnlSearch.Height = 0

                pnlSearchDetail.Height = 0

                pnlSearchDetail.Width = Moshavere1.Width

                pnlAdd.Height = Moshavere1.Height + 10

                FlowLayoutPanel2.Width = pnlAdd.Width

            Else

                lnkChangeDesign.Text = "ثبت مشاوره"

                lnkChangeDesign.Location = New Point(36, 1)

                pnlAdd.Height = 0

                If custId = String.Empty Then

                    pnlSearchDetail.Height = 98

                    btnRefresh.Visible = False

                    pnlSearch.Height = 520


                Else
                    btnRefresh.Visible = True

                    pnlSearchDetail.Height = 0

                    pnlSearch.Height = 550

                End If

                pnlSearchDetail.Width = 630

                FlowLayoutPanel2.Width = pnlSearch.Width + 5

                If custId = String.Empty Then

                    SearchByParameter()

                Else

                    Search()

                End If


            End If

            pnlSearch.Visible = Not IsSearchMode

            IsSearchMode = Not IsSearchMode

            Me.Height = FlowLayoutPanel2.Height + 60

            Me.Width = FlowLayoutPanel2.Width + 20

            pnlTitle.Width = FlowLayoutPanel2.Width

            lblfrmTitle.Location = New Point(pnlTitle.Width - 60, 6)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub lnkChangeDesign_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkChangeDesign.LinkClicked

        setLinkedSearch()

    End Sub

    Private Sub frmNewTimingSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ToolTip1.SetToolTip(btnContacts, "لیست افراد")

        ToolTip1.SetToolTip(btnMyComputer, "MyComputer")

        ToolTip1.SetToolTip(btnBrowsDocs, "اسناد تیپ")

        ToolTip1.SetToolTip(btnRefresh, "جستجو")

        ToolTip1.SetToolTip(btnPrint, "چاپ")

        ToolTip1.SetToolTip(btnSearch, "جستجو")

        txtFrom.SetToday = True

        txtTo.SetToday = True

        cmbStatus.SelectedIndex = 0

        If Lawyer.Common.VB.Login.CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.وکیل OrElse Lawyer.Common.VB.Login.CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.کارشناس Then

            txtVakil.Text = Lawyer.Common.VB.Login.CurrentLogin.CurrentUser.Name

            RecieverID = Lawyer.Common.VB.Login.CurrentLogin.CurrentUser.UserID

        End If

        setLinkedSearch()

    End Sub


#End Region

#Region "Moshavere"

    Private Sub Moshavere1_ContactDetail(ByVal custId As String) Handles Moshavere1.ContactDetail

        Dim f As New ContactAdd(custId)

        f.ShowDialog()

    End Sub

    Private Sub Moshavere1_ShowDocContent(ByVal filePath As String, ByVal fileName As String) Handles Moshavere1.ShowDocContent

        'Dim f As New OpenDoc(filePath, fileName)

        'f.ShowDialog()

        Lawyer.Common.VB.Common.FileManager.executeWordFile(System.IO.Path.GetFileNameWithoutExtension(filePath), filePath, fileName, "deskdocs")

    End Sub

    Private Sub Moshavere1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Moshavere1.SizeChanged

        pnlAdd.Height = Moshavere1.Height

        FlowLayoutPanel2.Width = pnlAdd.Width

        Me.Height = FlowLayoutPanel2.Height + 50

        Me.Width = FlowLayoutPanel2.Width + 12

        pnlTitle.Width = FlowLayoutPanel2.Width

    End Sub

    Private Sub ShowContact()


        Try

            If CommonSettingManager.SetContactSearch IsNot Nothing Then

                CommonSettingManager.SetContactSearch.Close()

            End If

            Dim f As New ContactSearch(Lawyer.Common.VB.ContactInfo.Enums.RoleType.موکل)

            CommonSettingManager.SetContactSearch = f

            f.Show()

        Catch ex As Exception

            ErrorManager.WriteMessage("btnContacts_Click", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub TimingAdd1_ShowConfirm(ByVal text As String, ByVal title As String) Handles Moshavere1.ShowConfirm

        Dim f As New dadMessageBox(text, title)

        If f.ShowMessage = Windows.Forms.DialogResult.Yes Then

            Moshavere1.YesClicked = True

        Else

            Moshavere1.YesClicked = False

        End If


    End Sub


#End Region

#Region "Initial"

    Private Sub btnBrowsDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsDocs.Click

        Dim f As New BraowsDocs

        f.Show()

    End Sub

    Private Sub btnContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContacts.Click

        ShowContact()

    End Sub

    Private Sub btnMyComputer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyComputer.Click

        Try

            Dim f As New frmWinExplorer()

            f.Show()

        Catch ex As Exception

            ErrorManager.WriteMessage("btnMyComputer_Click", ex.ToString(), Me.Text)

        End Try

    End Sub

    Public Sub New()
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Moshavere1.SetTiming()

            CreateTable()

        Catch ex As Exception
            ErrorManager.WriteMessage("New", ex.ToString(), Me.Text)
        End Try

    End Sub

    Public Sub New(ByVal fileId As String)
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Moshavere1.SetTiming(fileId)
            _fileId = fileId
            custId = FileDocManager.GetFileCustId(fileId)

            CreateTable()

        Catch ex As Exception

            ErrorManager.WriteMessage("New", ex.ToString(), Me.Text)

        End Try

    End Sub


#End Region

#Region "DataGridview"

    Dim custId As String
    Dim dtResult As New DataTable

    Private Sub CreateTable()

        If dtResult.Columns.Count <= 0 Then
            dtResult.Columns.Add("timeTitle")
            dtResult.Columns.Add("timeText")
            dtResult.Columns.Add("sender")
            dtResult.Columns.Add("timeFullDate")
            dtResult.Columns.Add("timeDone")
            dtResult.Columns.Add("timeTime")
            dtResult.Columns.Add("timeDate")
            dtResult.Columns.Add("reciever")
            dtResult.Columns.Add("financeAmount", System.Type.GetType("System.Double"))
            dtResult.Columns.Add("movakel")
            dtResult.Columns.Add("tpid")
            dtResult.Columns.Add("financeCustID")
        End If
       

    End Sub

    Public Sub Search()

        Try
            DataGridView1.Columns("clmmovakel").Visible = False

            DataGridView1.Columns("clmmovakel").Width = 0

            DataGridView1.ColumnHeadersVisible = True

            lblMessage.Text = String.Empty

            BindMOshavere()

            If DataGridView1.Rows.Count = 0 Then

                lblMessage.Text = "موردی یافت نشد."

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در انجام عملیات."

            ErrorManager.WriteMessage("Search", ex.ToString(), Me.Text)

        End Try

    End Sub

    Public Sub SearchByParameter()

        Try
            DataGridView1.Columns("clmmovakel").Visible = True

            DataGridView1.Columns("clmmovakel").Width = 100

            lblMessage.Text = String.Empty

            Dim tpQuery As String = String.Empty

            Dim fQuery As String = String.Empty


            If txtFrom.GetShamsiDateInNumericFormat.HasValue Then

                tpQuery = " and  timeDate>=" & txtFrom.GetShamsiDateInNumericFormat

            End If

            If txtTo.GetShamsiDateInNumericFormat.HasValue Then

                tpQuery &= " and  timeDate<=" & txtTo.GetShamsiDateInNumericFormat

            End If

            If RecieverID <> String.Empty Then

                tpQuery &= " and  tpTargetCustID='" & RecieverID & "'"

            End If

            Select Case cmbStatus.SelectedIndex

                Case 1

                    tpQuery &= " and  timeDone=1"

                Case 2

                    tpQuery &= " and  timeDone=0"

            End Select

            If MoshavereID <> String.Empty Then

                fQuery = " and financeCustID='" & MoshavereID & "'"

            End If

            If tpQuery <> String.Empty Then

                tpQuery = " where " & tpQuery.Substring(4)

            End If

            BindMOshavereByparameter(tpQuery, fQuery)

            If DataGridView1.Rows.Count = 0 Then

                lblMessage.Text = "موردی یافت نشد."

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در انجام عملیات."

            ErrorManager.WriteMessage("Search", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub BindMOshavereByparameter(ByVal tpQ As String, ByVal fQ As String)

        Dim b As New BindingSource

        DataGridView1.AutoGenerateColumns = False

        Dim list As Timing.MoshavereSearchCollection = Timing.TimingManager.MoshavereSearch(fQ, tpQ)

        b.DataSource = list

        dtResult.Rows.Clear()


        If list IsNot Nothing Then

            For Each Item As Timing.MoshavereSearch In list

                Dim dtNewRow As DataRow
                dtNewRow = dtResult.NewRow()
                dtNewRow.Item("timeTitle") = Item.timeTitle
                dtNewRow.Item("timeText") = Item.timeText
                dtNewRow.Item("sender") = Item.sender
                dtNewRow.Item("timeFullDate") = Item.timeFullDate
                dtNewRow.Item("reciever") = Item.reciever
                dtNewRow.Item("timeDone") = Item.timeDone
                dtNewRow.Item("timeDate") = Item.timeDate
                dtNewRow.Item("timeTime") = Item.timeTime
                dtNewRow.Item("financeAmount") = Item.financeAmount
                dtNewRow.Item("movakel") = Item.movakel
                dtNewRow.Item("tpid") = Item.tpid
                dtNewRow.Item("financeCustID") = Item.financeCustID

                dtResult.Rows.Add(dtNewRow)

            Next

            b.DataSource = dtResult

            DataGridView1.DataSource = b

        Else

            DataGridView1.DataSource = Nothing

        End If

        SetAmounts()

    End Sub

    Private Sub BindMOshavere()

        Dim b As New BindingSource

        DataGridView1.AutoGenerateColumns = False

        Dim list As Timing.MoshavereSearchCollection = Timing.TimingManager.MoshavereSearchByFileCase(custId)

        b.DataSource = list

        dtResult.Rows.Clear()


        If list IsNot Nothing Then

            For Each Item As Timing.MoshavereSearch In list

                Dim dtNewRow As DataRow
                dtNewRow = dtResult.NewRow()
                dtNewRow.Item("timeTitle") = Item.timeTitle
                dtNewRow.Item("timeText") = Item.timeText
                dtNewRow.Item("sender") = Item.sender
                dtNewRow.Item("timeFullDate") = Item.timeFullDate
                dtNewRow.Item("reciever") = Item.reciever
                dtNewRow.Item("timeDone") = Item.timeDone
                dtNewRow.Item("timeDate") = Item.timeDate
                dtNewRow.Item("timeTime") = Item.timeTime
                dtNewRow.Item("financeAmount") = Item.financeAmount
                dtNewRow.Item("tpid") = Item.tpid
                dtNewRow.Item("financeCustID") = Item.financeCustID

                dtResult.Rows.Add(dtNewRow)

            Next

            b.DataSource = dtResult

            DataGridView1.DataSource = b

        Else

            DataGridView1.DataSource = Nothing

        End If

        SetAmounts()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        SearchByParameter()

    End Sub

    Private Sub SetAmounts()

        txtBedehkar.Amount = 0

        Try

            If DataGridView1.Rows.Count > 0 Then

                Dim b As Double = 0

                For index As Integer = 0 To DataGridView1.Rows.Count - 1

                    b += CDbl(DataGridView1.Rows(index).Cells("clmfinanceAmount").Value)

                Next

                txtBedehkar.Amount = b

                If b <> txtBedehkar.Amount Then txtBedehkar.Amount = b

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            lblMessage.Text = String.Empty

            Dim title As String = String.Empty


            Dim b As BindingSource = DataGridView1.DataSource

            Dim c As DataTable = b.DataSource

            Dim r As New ReportsFix()

            If custId <> String.Empty Then

                title = ContactInfo.ContactInfoManager.GetContactFullNameByID(custId)

                If title <> String.Empty Then

                    title = "مشاوره های مربوط به " & title

                End If

                r.ReportDataTable(ReportsFix.ReportType.Consulting, title) = c

                r.Show()

            Else
                title = "گزارش مشاوره ها"

                r.ReportDataTable(ReportsFix.ReportType.Consulting_Lawyer, title) = c

                r.Show()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        Search()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try

            If e.RowIndex <> -1 Then

                Dim tpId As String = DataGridView1.Rows(e.RowIndex).Cells("clmtpid").Value

                If e.ColumnIndex = 0 Then

                    Dim IsCheck As Boolean = DataGridView1.Rows(e.RowIndex).Cells("clmtimeDone").Value

                    Dim result As Boolean = TimePartiesManager.EditTimingDoneField(tpId, Not IsCheck)

                    If result Then

                        DataGridView1.Rows(e.RowIndex).Cells("clmtimeDone").Value = Not IsCheck

                    End If


                ElseIf e.ColumnIndex = 3 Then

                    Dim f As New MoshavereView(tpId, _fileId)

                    f.ShowDialog()

                    If custId = String.Empty Then

                        SearchByParameter()

                    Else

                        Search()

                    End If

                End If

            End If


        Catch ex As Exception

            ErrorManager.WriteMessage("DataGridView1_CellClick", ex.ToString(), Me.Text)

        End Try

    End Sub

#End Region

#Region "Erjaaa"

    Dim RecieverID As String
    Dim MoshavereID As String


    Private Sub txtVakil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVakil.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode <> Keys.Delete Then

            UcContacts1.Focus()

            UcContacts1.BindContacts(ucContacts.SearchType.role, Lawyer.Common.VB.ContactInfo.Enums.RoleType.وکیل & " or custType=" & Lawyer.Common.VB.ContactInfo.Enums.RoleType.کارشناس, New Point(120, 66), "", CType(sender, TextBox).Name)

        Else

            txtVakil.Text = String.Empty

            RecieverID = String.Empty

        End If

    End Sub

    Private Sub txtMoshavere_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMoshavere.KeyDown

        lblMessage.Text = String.Empty

        If e.KeyCode <> Keys.Delete Then

            UcContacts1.Focus()

            UcContacts1.BindContacts(ucContacts.SearchType.role, Lawyer.Common.VB.ContactInfo.Enums.RoleType.مشاوره, New Point(335, 66), "", CType(sender, TextBox).Name)

        Else

            txtMoshavere.Text = String.Empty

            MoshavereID = String.Empty

        End If

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

            ErrorManager.WriteMessage("txtMoshavere_DragDrop", ex.ToString(), Me.Text)

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

            ErrorManager.WriteMessage("txtVakil_DragDrop", ex.ToString(), Me.Text)

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

        Dim f As New ContactAdd(custId)

        f.ShowDialog()

        UcContacts1.RefreshContacts()

    End Sub


#End Region

    '' ''Enum messageStatus

    '' ''    forward = 1
    '' ''    reply = 2
    '' ''    Edit = 3

    '' ''End Enum

    '' ''Dim isFileCaseMode As Boolean = False

    '' ''Public Sub New(ByVal FileCaseId As String, ByVal fileId As String)

    '' ''    Try

    '' ''        ' This call is required by the Windows Form Designer.
    '' ''        InitializeComponent()
    '' ''        ' Add any initialization after the InitializeComponent() call.
    '' ''        Moshavere1.SetTiming(FileCaseId, fileId)
    '' ''        isFileCaseMode = True
    '' ''    Catch ex As Exception
    '' ''        ErrorManager.WriteMessage("New,2param, 2String", ex.ToString(), Me.Text)
    '' ''    End Try
    '' ''End Sub

    '' ''Public Sub New(ByVal tpId As String)

    '' ''    Try

    '' ''        ' This call is required by the Windows Form Designer.
    '' ''        InitializeComponent()
    '' ''        ' Add any initialization after the InitializeComponent() call.
    '' ''        Moshavere1.EditReminder(tpId)

    '' ''    Catch ex As Exception
    '' ''        ErrorManager.WriteMessage("New,1param", ex.ToString(), Me.Text)
    '' ''    End Try
    '' ''End Sub

    '' ''Public Sub New(ByVal status As messageStatus, ByVal tpId As String)
    '' ''    Try
    '' ''        ' This call is required by the Windows Form Designer.
    '' ''        InitializeComponent()
    '' ''        ' Add any initialization after the InitializeComponent() call.
    '' ''        '' ''TimingAdd1.SetTiming()

    '' ''        Select Case status

    '' ''            Case messageStatus.forward

    '' ''                Moshavere1.ForwardMessage(tpId)

    '' ''            Case messageStatus.reply

    '' ''                Moshavere1.ReplyMessage(tpId)
    '' ''        End Select

    '' ''        Moshavere1.EditReminder(tpId)

    '' ''    Catch ex As Exception
    '' ''        ErrorManager.WriteMessage("New,2param,messageStatus", ex.ToString(), Me.Text)
    '' ''    End Try

    '' ''End Sub



    '' ''Private Sub TimingAdd1_ShowConfirm(ByVal text As String, ByVal title As String) Handles Moshavere1.ShowConfirm

    '' ''    Dim f As New dadMessageBox(text, title)

    '' ''    If f.ShowMessage = Windows.Forms.DialogResult.Yes Then

    '' ''        Moshavere1.YesClicked = True

    '' ''    Else

    '' ''        Moshavere1.YesClicked = False

    '' ''    End If


    '' ''End Sub

    '' ''Private Sub TimingAdd1_ShowContactSearch() Handles Moshavere1.ShowContactSearch
    '' ''    ShowContact()

    '' ''End Sub


    '' ''Private Sub ShowContact()

    '' ''    If CommonSettingManager.SetContactSearch IsNot Nothing Then

    '' ''        CommonSettingManager.SetContactSearch.Close()

    '' ''    End If

    '' ''    Dim f As New ContactSearch()

    '' ''    CommonSettingManager.SetContactSearch = f

    '' ''    f.Show()

    '' ''    'f.Location = New Point(Me.Location.X + Me.Width - f.Size.Width - 20, Me.Location.Y + 100)

    '' ''End Sub

    '' ''Private Sub TimingAdd1_ShowDocContent(ByVal filePath As String, ByVal fileName As String) Handles Moshavere1.ShowDocContent

    '' ''    Dim f As New OpenDoc(filePath, IO.Path.GetFileNameWithoutExtension(fileName))

    '' ''    f.ShowDialog()
    '' ''End Sub

    ' '' ''Private Sub TimingAdd1_ShowDocContent(ByVal filePath As String) Handles TimingAdd1.ShowDocContent

    ' '' ''    Dim f As New OpenDoc(filePath)

    ' '' ''    f.ShowDialog()

    ' '' ''End Sub

    '' ''Private Sub TimingAdd1_ShowFinanceAdd(ByVal financeId As String, ByVal IsTimeId As Boolean) Handles Moshavere1.ShowFinanceAdd

    '' ''    If IsTimeId Then

    '' ''    Else

    '' ''        Dim f As New FinanceAdd(financeId, Lawyer.Common.VB.Finance.FinanceEnums.FinanceAddMode.اضافه_کردن, True)

    '' ''        f.ShowDialog()

    '' ''    End If
    '' ''End Sub


    '' ''Public Sub Reply(ByVal tpId)

    '' ''    Moshavere1.ReplyMessage(tpId)

    '' ''End Sub

    '' ''Public Sub Forward(ByVal tpId)

    '' ''    Moshavere1.ForwardMessage(tpId)

    '' ''End Sub




    ' '' '' '' ''Private Sub picTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTask.Click

    ' '' '' '' ''    TimingAdd1.NewTask()

    ' '' '' '' ''End Sub


    Private Sub _ucSms_OpenForm(ByVal fileCaseID As String, ByVal timeID As String, ByVal dt As DataTable, ByVal smsText As String) Handles Moshavere1._showSmsForm
        Dim frmSmsDialog As New frmSms(fileCaseID, timeID, dt, smsText)
        frmSmsDialog.ShowDialog()

    End Sub


End Class