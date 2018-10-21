Imports Lawyer.Common.VB.CommonSetting



Public Class BrowseFiles

    Private fileId As String = String.Empty


    Private Sub FileList1_AsnadTip() Handles FileList1.AsnadTip

        Dim f As New BraowsDocs

        f.Show()
        f.Location = New Drawing.Point(Me.Location.X + 300, Me.Location.Y - 50)
    End Sub

    Private Sub _dlgShowTemDoc() Handles FileList1._dlgOpenTempDoc
        Dim f As New BraowsDocs
        f.Show()
        f.Location = New Drawing.Point(Me.Location.X + 300, Me.Location.Y - 50)

    End Sub


    Private Sub FileList1_ContactDetail(ByVal custId As String) Handles FileList1.ContactDetail

        Dim f As New ContactAdd(custId)

        f.ShowDialog()

    End Sub

    Private Sub FileList1_SetConnectionString(ByVal islocal As Boolean) Handles FileList1.SetConnectionString

        Dim f As New SetConnectionString()

        f.SetIforTransfer(islocal)

        f.ShowDialog()

    End Sub

    Private Sub FileList1_ShowDocContent(ByVal ID As String, ByVal filePath As String, ByVal TableName As String, ByVal fileName As String, ByVal filecaseId As String) Handles FileList1.ShowDocContent

        ''Dim f As New OpenDoc(filePath, filecaseId, ID, TableName, fileName)

        ''f.ShowDialog()

        Lawyer.Common.VB.Common.FileManager.executeWordFile(ID, filePath, fileName, TableName, filecaseId)

    End Sub



    Private Sub FileList1_ShowMessageBox(ByVal text As String, ByVal title As String) Handles FileList1.ShowMessageBox

        Dim f As New dadMessageBox(text, title)

        If f.ShowMessage = Windows.Forms.DialogResult.Yes Then

            FileList1.YesClicked = True

        Else
            FileList1.YesClicked = False

        End If

    End Sub

    

    Private Sub FileList1_ShowSpecificForm(ByVal ID As String, ByVal formName As Lawyer.Common.VB.Docs.Enums.FileType, ByVal FileID As String) Handles FileList1.ShowSpecificForm

        If formName = Lawyer.Common.VB.Docs.Enums.FileType.مشخصات_پرونده Then

            Dim f As New AddFileCase(ID)

            f.ShowDialog()

        ElseIf formName = Lawyer.Common.VB.Docs.Enums.FileType.آلارم Then

            Dim f As New frmNewTimingAdd(ID, FileID)

            f.ShowDialog()

        ElseIf formName = Lawyer.Common.VB.Docs.Enums.FileType.مالی Then

            Dim f As New frmNewFinanceAdd(ID, FileID)

            f.ShowDialog()

        ElseIf formName = Lawyer.Common.VB.Docs.Enums.FileType.مشاوره Then

            Dim f As New frmMoshavere(FileID)

            f.ShowDialog()

        End If

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal fileId As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.fileId = fileId

    End Sub

    Private Sub BrowseFiles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ToolTip1.SetToolTip(btnBrowsDocs, "اسناد تیپ")

        Me.ToolTip1.SetToolTip(btnContactSearh, "لیست افراد")

        Me.ToolTip1.SetToolTip(btnMyComputer, "My Computer")

        If fileId <> String.Empty Then

            FileList1.ShowSpecificFileCase(Me.fileId)

        End If


    End Sub

    Private Sub btnMyComputer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyComputer.Click


        ' check exe file --
        ''abbas lock
        'Dim softLock As New SoftLock(C_LicenceID)
        'softLock.CheckLock(False, True)

        Dim f As New frmWinExplorer()
        f.Show()


    End Sub

    Private Sub btnBrowsDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsDocs.Click

        Dim f As New BraowsDocs

        f.Show()

    End Sub

    Private Sub btnContactSearh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContactSearh.Click

        Dim f As New ContactSearch(Lawyer.Common.VB.ContactInfo.Enums.RoleType.موکل)

        f.Show()

    End Sub

    Public WriteOnly Property SearchString() As String

        Set(ByVal value As String)
            FileList1.Search(value)
        End Set
    End Property


    '#End Region




    '#End Region


    '' ''Private Sub BrowseFiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    '' ''    If e.KeyCode = Keys.F2 Then

    '' ''        If CommonSettingManager.SetContactSearch Is Nothing Then

    '' ''            Dim f As New ContactSearch()

    '' ''            CommonSettingManager.SetContactSearch = f

    '' ''            f.Show()

    '' ''            f.Location = New Point(Me.Location.X + Me.Width - f.Size.Width - 20, Me.Location.Y + 100)

    '' ''        Else

    '' ''            Dim f As ContactSearch = CommonSettingManager.SetContactSearch

    '' ''            f.Show()

    '' ''            f.WindowState = FormWindowState.Normal

    '' ''            f.BringToFront()

    '' ''            f.Location = New Point(Me.Location.X + Me.Width - f.Size.Width - 20, Me.Location.Y + 100)

    '' ''        End If

    '' ''    End If


    '' ''End Sub

   

   
    Private Sub FileList1_ShowReport(dt As System.Data.DataTable, title As String) Handles FileList1.ShowReport
        Try
            Dim r As New ReportsFix()

            r.ReportDataTable(ReportsFix.ReportType.CaseDocuments, title) = dt

            r.Show()

        Catch ex As Exception

        End Try
    End Sub
End Class
