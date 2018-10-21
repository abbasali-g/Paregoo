Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.CommonSetting

Public Class frmNewTimingSearch

#Region "NewTimingSearch1"

    Private Sub NewTimingSearch1_ContactDetail(ByVal custId As String) Handles NewTimingSearch1.ContactDetail

        Dim f As New ContactAdd(custId)

        f.ShowDialog()

    End Sub

    Private Sub btnContactSearh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContactSearh.Click


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

    Private Sub NewTimingSearch1_ShowKartablDetail(ByVal IsKartabl As Boolean, ByVal timePartiesID As String) Handles NewTimingSearch1.ShowKartablDetail

        If IsKartabl Then

            Dim f As New TimingView(timePartiesID)

            f.ShowDialog()

        End If

    End Sub

    Private Sub NewTimingSearch1_ShowReport(ByVal c As System.Data.DataTable, ByVal title As String) Handles NewTimingSearch1.ShowReport

        Try

            Dim r As New ReportsFix()

            If String.IsNullOrEmpty(title) Then
                title = "گزارش اقدامات"
            End If
            r.ReportDataTable(ReportsFix.ReportType.Actions, title) = c

            r.Show()

        Catch ex As Exception

        End Try


    End Sub


#End Region
  
#Region "Design"

    Dim IsSearchMode As Boolean = True

    Private Sub setLinkedSearch()

        Try

            pnlAdd.Visible = IsSearchMode

            If IsSearchMode Then

                lnkChangeDesign.Text = "جستجوی اقدامات"

                lnkChangeDesign.Location = New Point(14, 1)

                pnlSearch.Height = 0

                pnlAdd.Height = NewTimingAdd1.Height + 10

                FlowLayoutPanel1.Width = pnlAdd.Width

            Else

                lnkChangeDesign.Text = "ثبت اقدام"

                lnkChangeDesign.Location = New Point(36, 1)

                pnlAdd.Height = 0

                pnlSearch.Height = NewTimingSearch1.Height + 10

            End If

            pnlSearch.Visible = Not IsSearchMode

            IsSearchMode = Not IsSearchMode

            Me.Height = FlowLayoutPanel1.Height + 60
            Me.Width = FlowLayoutPanel1.Width + 35
            pnlTitle.Width = FlowLayoutPanel1.Width
            lblfrmTitle.Location = New Point(pnlTitle.Width - 60, 6)


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
    
#Region "Initial"

    Public Sub New()

        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            'Me.Location = New Point(Me.Location.X, 100)

            ' Add any initialization after the InitializeComponent() call.
            NewTimingAdd1.SetTiming()

        Catch ex As Exception

            ErrorManager.WriteMessage("New", ex.ToString(), Me.Text)

        End Try

    End Sub
    'Dim isFileCaseMode As Boolean = False

    'Dim _filecaseId As String

    'Public Sub New(ByVal FileCaseId As String, ByVal fileId As String)

    '    Try

    '        ' This call is required by the Windows Form Designer.
    '        InitializeComponent()
    '        ' Add any initialization after the InitializeComponent() call.

    '        NewTimingAdd1.SetTiming(FileCaseId, fileId)

    '        _filecaseId = FileCaseId

    '        isFileCaseMode = True

    '        CreateTable()

    '    Catch ex As Exception

    '        ErrorManager.WriteMessage("New,2param, 2String", ex.ToString(), Me.Text)

    '    End Try

    'End Sub

    Private Sub btnMyComputer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyComputer.Click

        Try

            Dim f As New frmWinExplorer()

            f.Show()

        Catch ex As Exception

            ErrorManager.WriteMessage("btnMyComputer_Click", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub TimingAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ToolTip1.SetToolTip(btnContactSearh, "لیست افراد")

        ToolTip1.SetToolTip(btnMyComputer, "MyComputer")

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

        FlowLayoutPanel1.Width = pnlAdd.Width

        Me.Height = FlowLayoutPanel1.Height + 50

        Me.Width = FlowLayoutPanel1.Width + 12

        pnlTitle.Width = FlowLayoutPanel1.Width

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

    Private Sub _ucSms_OpenForm(ByVal fileCaseID As String, ByVal timeID As String, ByVal dt As DataTable, ByVal smsText As String) Handles NewTimingAdd1._showSmsForm
        Dim frmSmsDialog As New frmSms(fileCaseID, timeID, dt, smsText)
        frmSmsDialog.ShowDialog()

    End Sub

End Class