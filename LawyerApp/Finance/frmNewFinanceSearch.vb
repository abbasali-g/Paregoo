Imports Lawyer.Common.VB.Shaxes
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.LawyerError

Public Class frmNewFinanceSearch


#Region "Initial"

    Private Sub btnContactSearh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContactSearh.Click

        ShowContact()

    End Sub

    Private Sub FinanceSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' ToolTip1.SetToolTip(btnContactSearh, "لیست افراد")


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

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "NewFinanceSearch"

    Private Sub NewFinanceSearch1_ContactDetail(ByVal custId As String) Handles NewFinanceSearch1.ContactDetail

        Dim f As New ContactAdd(custId)

        f.ShowDialog()

    End Sub

    Private Sub FinanceSearch1_ShowContactSearch() Handles NewFinanceSearch1.ShowContactSearch

        ShowContact()

    End Sub

    Private Sub NewFinanceSearch1_ShowReport(ByVal dt As System.Data.DataTable, ByVal title As String, ByVal type As Short) Handles NewFinanceSearch1.ShowReport

        Try

            Dim r As New ReportsFix()

            r.ReportDataTable(CType(type, ReportsFix.ReportType), title) = dt

            r.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FinanceSearch1_ShowFinanceAdd(ByVal financeId As String, ByVal mode As FinanceEnums.FinanceAddMode) Handles NewFinanceSearch1.ShowFinanceAdd


        If mode = FinanceEnums.FinanceAddMode.حذف Then

            Dim msgbox As New dadMessageBox(Lawyer.Common.VB.DadMessages.Messages.ConfirmDelete, "حذف مالی")

            If msgbox.ShowMessage() = Windows.Forms.DialogResult.Yes Then

                NewFinanceSearch1.DeleteRow()

            End If

        Else

            Dim f As New FinanceView(financeId, mode)

            f.ShowDialog()

        End If

    End Sub

#End Region

    

    ' '' ''Public Sub New(ByVal fileCaseId As String)

    ' '' ''    ' This call is required by the Windows Form Designer.
    ' '' ''    InitializeComponent()

    ' '' ''    NewFinanceSearch1.SearchFileCase(fileCaseId)

    ' '' ''    ' Add any initialization after the InitializeComponent() call.

    ' '' ''End Sub

    

    'Public Overrides Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CommonSettingManager.SetFinanceSearchFun = Nothing
    '    ' MyBase.btnClose_Click(sender, e)
    'End Sub

   
End Class