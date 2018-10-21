Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.Timing
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.TimeParties

Public Class frmNewTimingAdd

#Region "Initial"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



    End Sub

    Dim isFileCaseMode As Boolean = False

    Dim _filecaseId As String

    Public Sub New(ByVal FileCaseId As String, ByVal fileId As String)

        Try

            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.

            NewTimingAdd1.SetTiming(FileCaseId, fileId)

            _filecaseId = FileCaseId

            isFileCaseMode = True

            CreateTable()

        Catch ex As Exception

            ErrorManager.WriteMessage("New,2param, 2String", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub btnContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContacts.Click

        Try
            lblMessage.Text = String.Empty

            If CommonSettingManager.SetContactSearch IsNot Nothing Then

                CommonSettingManager.SetContactSearch.Close()

            End If

            Dim f As New ContactSearch()

            CommonSettingManager.SetContactSearch = f

            f.Show()

            f.Location = New Point(Me.Location.X + Me.Width - f.Size.Width - 20, Me.Location.Y + 100)

        Catch ex As Exception

            ErrorManager.WriteMessage("btnContacts_Click", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub btnMyComputer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyComputer.Click

        Try
            lblMessage.Text = String.Empty

            Dim f As New frmWinExplorer()

            f.Show()

        Catch ex As Exception

            ErrorManager.WriteMessage("btnMyComputer_Click", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub TimingAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        lblMessage.Text = String.Empty

        ToolTip1.SetToolTip(btnContacts, "لیست افراد")

        ToolTip1.SetToolTip(btnMyComputer, "MyComputer")

        ToolTip1.SetToolTip(btnPrint, "چاپ")

        ToolTip1.SetToolTip(btnRefresh, "جستجو")

    End Sub

    Public Sub Forward(ByVal tpId)

        NewTimingAdd1.ForwardMessage(tpId)

    End Sub

    Public Sub Reply(ByVal tpId)

        NewTimingAdd1.ReplyMessage(tpId)

    End Sub


#End Region

#Region "Design"

    Dim IsSearchMode As Boolean = True

    Private Sub setLinkedSearch()

        lblMessage.Text = String.Empty

        Try
            pnlAdd.Visible = IsSearchMode

            If IsSearchMode Then

                lnkChangeDesign.Text = "اقدامات ثبت شده"

                lnkChangeDesign.Location = New Point(14, 1)

                pnlSearch.Height = 0

                pnlAdd.Height = NewTimingAdd1.Height + 10

                FlowLayoutPanel2.Width = pnlAdd.Width + 5

            Else

                lnkChangeDesign.Text = "ثبت اقدام"

                lnkChangeDesign.Location = New Point(36, 1)

                pnlAdd.Height = 0

                pnlSearch.Height = 620

                Search()

            End If

            pnlSearch.Visible = Not IsSearchMode

            IsSearchMode = Not IsSearchMode

            Me.Height = FlowLayoutPanel2.Height + 60

            Me.Width = FlowLayoutPanel2.Width + 15

            pnlTitle.Width = FlowLayoutPanel2.Width

            'lblfrmTitle.Location = New Point(pnlTitle.Width - 50, 6)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub lnkChangeDesign_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkChangeDesign.LinkClicked

        setLinkedSearch()

    End Sub

    Private Sub frmNewTimingSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        setLinkedSearch()

    End Sub


#End Region

#Region "NewTimingAdd"

    Private Sub NewTimingAdd1_ShowDocContent(ByVal filePath As String, ByVal fileName As String) Handles NewTimingAdd1.ShowDocContent

        ''Dim f As New OpenDoc(filePath, fileName)

        ''f.ShowDialog()
        Lawyer.Common.VB.Common.FileManager.executeWordFile(System.IO.Path.GetFileNameWithoutExtension(filePath), filePath, fileName, "deskdocs")
    End Sub

    Private Sub NewTimingAdd1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewTimingAdd1.SizeChanged

        pnlAdd.Height = NewTimingAdd1.Height

        FlowLayoutPanel2.Width = pnlAdd.Width

        Me.Height = FlowLayoutPanel2.Height + 50

        Me.Width = FlowLayoutPanel2.Width + 12

        pnlTitle.Width = FlowLayoutPanel2.Width

    End Sub

    Private Sub ShowContact()

        If CommonSettingManager.SetContactSearch IsNot Nothing Then

            CommonSettingManager.SetContactSearch.Close()

        End If

        Dim f As New ContactSearch()

        CommonSettingManager.SetContactSearch = f

        f.Show()

        f.Location = New Point(Me.Location.X + Me.Width - f.Size.Width - 20, Me.Location.Y + 100)

    End Sub

    Private Sub TimingAdd1_ShowConfirm(ByVal text As String, ByVal title As String) Handles NewTimingAdd1.ShowConfirm

        Dim f As New dadMessageBox(text, title)

        If f.ShowMessage = Windows.Forms.DialogResult.Yes Then

            NewTimingAdd1.YesClicked = True

        Else

            NewTimingAdd1.YesClicked = False

        End If


    End Sub


#End Region

#Region "DataGridview"

    Dim dtResult As New DataTable

    Private Sub CreateTable()

        If dtResult.Columns.Count <= 0 Then

            dtResult.Columns.Add("timeTitle")
            dtResult.Columns.Add("timeText")
            dtResult.Columns.Add("custFullName")
            dtResult.Columns.Add("timeTypeName")
            dtResult.Columns.Add("timeFullDate")
            dtResult.Columns.Add("tpID")
            dtResult.Columns.Add("timeDone")
            dtResult.Columns.Add("timeTime")
            dtResult.Columns.Add("timeDate")
            dtResult.Columns.Add("timeText")

        End If

    End Sub

    Public Sub Search()

        Try


            DataGridView1.ColumnHeadersVisible = True

            lblMessage.Text = String.Empty

            BindTiming()

            If DataGridView1.Rows.Count = 0 Then

                lblMessage.Text = "موردی یافت نشد."

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در انجام عملیات."

            ErrorManager.WriteMessage("Search", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub BindTiming()

        DataGridView1.Columns.Clear()

        Dim gvClmTitle As New System.Windows.Forms.DataGridViewLinkColumn
        Dim gvClmDate As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvClmID As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvclmDone As New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim gvClmName As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvtimeText As New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim gvClmTypeName As New System.Windows.Forms.DataGridViewTextBoxColumn

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
        gvClmName.Width = 100

        ''gvClmType
        ''
        gvClmTypeName.DataPropertyName = "timeTypeName"
        gvClmTypeName.HeaderText = ""
        gvClmTypeName.Name = "timeTypeName"
        gvClmTypeName.ReadOnly = True
        gvClmTypeName.HeaderText = "نوع"
        gvClmTypeName.Width = 90
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
        gvclmDone.Width = 30
        gvclmDone.SortMode = DataGridViewColumnSortMode.Automatic

        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {gvClmID, gvclmDone, gvClmTitle, gvClmTypeName, gvClmDate, gvClmName, gvtimeText})

        Dim b As New BindingSource

        DataGridView1.AutoGenerateColumns = False

        Dim list As TimingFullSearchCollection = TimingManager.TimingSearchByFilecaseId(_filecaseId, Lawyer.Common.VB.Login.CurrentLogin.CurrentUser.UserID)

        b.DataSource = list

        dtResult.Rows.Clear()

        If list IsNot Nothing Then

            For Each Item As TimingFullSearch In list

                Dim dtNewRow As DataRow
                dtNewRow = dtResult.NewRow()
                dtNewRow.Item("timeTitle") = Item.timeTitle
                dtNewRow.Item("timeText") = Item.timeText
                dtNewRow.Item("custFullName") = Item.custFullName
                dtNewRow.Item("timeTypeName") = Item.timeTypeName
                dtNewRow.Item("timeFullDate") = Item.timeFullDate
                dtNewRow.Item("tpID") = Item.tpID
                dtNewRow.Item("timeDone") = Item.timeDone
                dtNewRow.Item("timeDate") = Item.timeDate
                dtNewRow.Item("timeText") = Item.timeText

                dtResult.Rows.Add(dtNewRow)

            Next

            b.DataSource = dtResult

            DataGridView1.DataSource = b

        Else

            DataGridView1.DataSource = Nothing

        End If

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

            r.ReportDataTable(ReportsFix.ReportType.Actions, title) = c

            r.Show()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        Search()

    End Sub

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

                    Dim f As New TimingView(tpId)

                    f.ShowDialog()

                    Search()

                End If

            End If


        Catch ex As Exception

            ErrorManager.WriteMessage("DataGridView1_CellClick", ex.ToString(), Me.Text)

        End Try

    End Sub

#End Region


    ' '' ''    Enum messageStatus

    ' '' ''        forward = 1
    ' '' ''        reply = 2
    ' '' ''        Edit = 3

    ' '' ''    End Enum

    ' '' ''    


    ' '' ''    Public Sub New(ByVal tpId As String)

    ' '' ''        Try

    ' '' ''            ' This call is required by the Windows Form Designer.
    ' '' ''            InitializeComponent()
    ' '' ''            ' Add any initialization after the InitializeComponent() call.
    ' '' ''            NewTimingAdd1.EditReminder(tpId)

    ' '' ''        Catch ex As Exception
    ' '' ''            ErrorManager.WriteMessage("New,1param", ex.ToString(), Me.Text)
    ' '' ''        End Try
    ' '' ''    End Sub

    ' '' ''    Public Sub New(ByVal status As messageStatus, ByVal tpId As String)
    ' '' ''        Try
    ' '' ''            ' This call is required by the Windows Form Designer.
    ' '' ''            InitializeComponent()
    ' '' ''            ' Add any initialization after the InitializeComponent() call.
    ' '' ''            '' ''TimingAdd1.SetTiming()

    ' '' ''            Select Case status

    ' '' ''                Case messageStatus.forward

    ' '' ''                    NewTimingAdd1.ForwardMessage(tpId)

    ' '' ''                Case messageStatus.reply

    ' '' ''                    NewTimingAdd1.ReplyMessage(tpId)
    ' '' ''            End Select

    ' '' ''            NewTimingAdd1.EditReminder(tpId)

    ' '' ''        Catch ex As Exception
    ' '' ''            ErrorManager.WriteMessage("New,2param,messageStatus", ex.ToString(), Me.Text)
    ' '' ''        End Try

    ' '' ''    End Sub

    ' '' ''    Public Sub New()
    ' '' ''        Try
    ' '' ''            ' This call is required by the Windows Form Designer.
    ' '' ''            InitializeComponent()
    ' '' ''            ' Add any initialization after the InitializeComponent() call.
    ' '' ''            NewTimingAdd1.SetTiming()

    ' '' ''        Catch ex As Exception
    ' '' ''            ErrorManager.WriteMessage("New", ex.ToString(), Me.Text)
    ' '' ''        End Try

    ' '' ''    End Sub







    ' '' ''    Public Sub Forward(ByVal tpId)

    ' '' ''        NewTimingAdd1.ForwardMessage(tpId)

    ' '' ''    End Sub



    ' '' ''    Private Sub btnTimingSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimingSearch.Click
    ' '' ''        Try

    ' '' ''            If CommonSettingManager.SetTimingSearchFun IsNot Nothing AndAlso isFileCaseMode Then

    ' '' ''                CommonSettingManager.SetTimingSearchFun.Close()
    ' '' ''                CommonSettingManager.SetTimingSearchFun = Nothing
    ' '' ''            End If


    ' '' ''            If CommonSettingManager.SetTimingSearchFun Is Nothing Then

    ' '' ''                Dim f As New TimingSearch()

    ' '' ''                CommonSettingManager.SetTimingSearchFun = f


    ' '' ''            Else

    ' '' ''            End If

    ' '' ''            CommonSettingManager.SetTimingSearchFun.Show()

    ' '' ''            CommonSettingManager.SetTimingSearchFun.Activate()

    ' '' ''            CommonSettingManager.SetTimingSearchFun.WindowState = FormWindowState.Normal

    ' '' ''            CommonSettingManager.SetTimingSearchFun.BringToFront()



    ' '' ''        Catch ex As Exception
    ' '' ''            ErrorManager.WriteMessage("btnTimingSearch_Click", ex.ToString(), Me.Text)
    ' '' ''        End Try

    ' '' ''    End Sub


    ' '' ''    ' '' ''Private Sub picTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTask.Click

    ' '' ''    ' '' ''    TimingAdd1.NewTask()

    ' '' ''    ' '' ''End Sub




    ' '' ''#Region "Expand"

    ' '' ''    Private IsSearch As Boolean = False

    ' '' ''    Private Sub pnlCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlCollapse.Click

    ' '' ''        If IsSearch Then

    ' '' ''            Panel2.Height = 580

    ' '' ''            Panel1.Height = 0

    ' '' ''            pnlCollapse.Image = My.Resources.Resources.collpase

    ' '' ''            ToolTip1.SetToolTip(pnlCollapse, "")

    ' '' ''        Else

    ' '' ''            Panel2.Height = 0
    ' '' ''            Panel1.Height = 580


    ' '' ''            pnlCollapse.Image = My.Resources.Resources.expand

    ' '' ''            ToolTip1.SetToolTip(pnlCollapse, "جستجوی پرونده")

    ' '' ''        End If

    ' '' ''        IsSearch = Not IsSearch

    ' '' ''    End Sub


    ' '' ''    '' ''Private Sub TimingAdd1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimingAdd1.SizeChanged

    ' '' ''    '' ''    Me.Size = New Size(Me.Size.Width, Me.TimingAdd1.Size.Height + pnlTitle.Height + 30)

    ' '' ''    '' ''End Sub

    ' '' ''#End Region

    Private Sub _ucSms_OpenForm(ByVal fileCaseID As String, ByVal timeID As String, ByVal dt As DataTable, ByVal smsText As String) Handles NewTimingAdd1._showSmsForm
        Dim frmSmsDialog As New frmSms(fileCaseID, timeID, dt, smsText)
        frmSmsDialog.ShowDialog()

    End Sub

End Class