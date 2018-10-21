Imports Lawyer.Common.VB.CommonSetting
Imports Microsoft.Reporting.WinForms

Public Class AddFileCase

    Dim filecaseId As String = String.Empty
    Dim fileCasekey As String = "1211361532123454"

    Private Sub AddFileCase_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If CommonSettingManager.SetContactSearch IsNot Nothing Then
            CommonSettingManager.SetContactSearch.Close()
        End If
    End Sub

    Private Sub AddFileCase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UcFileCase1.SetFileCase(filecaseId, fileCasekey)

    End Sub

    Public Sub New(ByVal fileCaseID As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.filecaseId = fileCaseID
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub UcFileCase1_ContactDetail(ByVal custId As String) Handles UcFileCase1.ContactDetail, UcFileCase1._showContactInformation
        Dim f As New ContactAdd(custId)

        f.ShowDialog()
    End Sub

    Private Sub _ucSms_OpenForm(ByVal fileCaseID As String, ByVal timeID As String, ByVal dt As DataTable, ByVal smsText As String) Handles UcFileCase1._showSmsForm
        Dim frmSmsDialog As New frmSms(fileCaseID, timeID, dt, smsText)
        frmSmsDialog.ShowDialog()

    End Sub


    ' ''Private Sub BrowseFiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    ' ''    If e.KeyCode = Keys.F2 Then

    ' ''        If CommonSettingManager.SetContactSearch Is Nothing Then

    ' ''            Dim f As New ContactSearch()

    ' ''            CommonSettingManager.SetContactSearch = f

    ' ''            f.Show()

    ' ''            f.Location = New Point(Me.Location.X + Me.Width - f.Size.Width - 20, Me.Location.Y + 100)

    ' ''        Else

    ' ''            Dim f As ContactSearch = CommonSettingManager.SetContactSearch

    ' ''            f.Show()

    ' ''            f.WindowState = FormWindowState.Normal

    ' ''            f.BringToFront()

    ' ''            f.Location = New Point(Me.Location.X + Me.Width - f.Size.Width - 20, Me.Location.Y + 100)

    ' ''        End If

    ' ''    End If


    ' ''End Sub


    Private Sub UcFileCase1_ShowComptency() Handles UcFileCase1.ShowComptency

        Dim c As New CompetencySearch()

        c.ShowDialog()

        Try

            UcFileCase1.SetSalahiyat(c.Pro_CompetencyOnGrid)

        Catch ex As Exception

            UcFileCase1.SetSalahiyat(Nothing)

        End Try

    End Sub

    Private Sub btnContactSearh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContactSearh.Click
        If CommonSettingManager.SetContactSearch IsNot Nothing Then

            CommonSettingManager.SetContactSearch.Close()

        End If

        Dim f As New ContactSearch()

        CommonSettingManager.SetContactSearch = f

        f.Show()


    End Sub

    '' ''Private Sub UcFileCase1_ShowContactSearch() Handles UcFileCase1.ShowContactSearch
    '' ''    ShowContact()
    '' ''End Sub

    ' '' ''Private Sub ShowContact()

    ' '' ''    If CommonSettingManager.SetContactSearch IsNot Nothing Then

    ' '' ''        CommonSettingManager.SetContactSearch.Close()

    ' '' ''    End If

    ' '' ''    Dim f As New ContactSearch()

    ' '' ''    CommonSettingManager.SetContactSearch = f

    ' '' ''    f.Show()

    ' '' ''    'f.Location = New Point(Me.Location.X + Me.Width - f.Size.Width - 20, Me.Location.Y + 100)

    ' '' ''End Sub

    Private Sub UcFileCase1_ShowContactSearch(ByVal type As WFControls.VB.UcFileCase.textBoxClick) Handles UcFileCase1.ShowContactSearch

        If CommonSettingManager.SetContactSearch IsNot Nothing Then

            CommonSettingManager.SetContactSearch.Close()

        End If

        Dim f As New ContactSearch(type)

        CommonSettingManager.SetContactSearch = f

        f.Show()

    End Sub

    Private Sub UcFileCase1_ShowMessageBox(ByVal text As String, ByVal title As String) Handles UcFileCase1.ShowMessageBox
        Dim f As New dadMessageBox(text, title)

        If f.ShowMessage = Windows.Forms.DialogResult.Yes Then

            UcFileCase1.YesClicked = True

        Else
            UcFileCase1.YesClicked = False

        End If
    End Sub

    
End Class