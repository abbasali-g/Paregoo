Imports Lawyer.Common.VB.Timing
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Shaxes

Public Class FinanceView


    '    Dim timeParties As String

    '    Dim timeId As String

    '#Region "Initial"

    '    Public Sub New(ByVal tpId As String)

    '        Try

    '            ' This call is required by the Windows Form Designer.
    '            InitializeComponent()
    '            ' Add any initialization after the InitializeComponent() call.
    '            NewTimingAdd1.EditReminder(tpId)

    '            timeParties = tpId

    '        Catch ex As Exception

    '            ErrorManager.WriteMessage("New,1param", ex.ToString(), Me.Text)

    '        End Try

    '    End Sub

    '    Private Sub KartablView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '        ToolTip1.SetToolTip(picForward, "ارسال به دیگری")

    '        ToolTip1.SetToolTip(picReply, "ارسال پاسخ")

    '    End Sub

    '    Private Sub pnlForward_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '        Try

    '            Dim f As New frmNewTimingAdd()

    '            f.Show()

    '            f.Forward(timeParties)

    '        Catch ex As Exception

    '            ErrorManager.WriteMessage("pnlForward_DoubleClick", ex.ToString(), Me.Text)

    '        End Try

    '    End Sub

    '    Private Sub picReply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '        Try

    '            Dim f As New frmNewTimingAdd()

    '            f.Show()

    '            f.Reply(timeParties)

    '        Catch ex As Exception

    '            ErrorManager.WriteMessage("picReply_Click", ex.ToString(), Me.Text)

    '        End Try

    '    End Sub

    '#End Region

    '#Region "NewTimingAdd"

    '    Private Sub TimingAdd1_ShowConfirm(ByVal text As String, ByVal title As String)

    '        Dim f As New dadMessageBox(text, title)

    '        If f.ShowMessage = Windows.Forms.DialogResult.Yes Then

    '            NewTimingAdd1.YesClicked = True

    '        Else

    '            NewTimingAdd1.YesClicked = False

    '        End If


    '    End Sub

    '    Private Sub NewTimingAdd1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '        Me.Size = New Size(Me.Width, NewTimingAdd1.Height + 50)

    '        pnlMenu.Height = NewTimingAdd1.Height

    '    End Sub

    '    Private Sub NewTimingAdd1_ShowDocContent(ByVal filePath As String, ByVal fileName As String)

    '        Dim f As New OpenDoc(filePath, fileName)

    '        f.ShowDialog()

    '    End Sub

    '#End Region


#Region "Initial"

    Private Sub btnContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContacts.Click

        ShowContact()

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

    Public Sub New(ByVal financeId As String, ByVal mode As FinanceEnums.FinanceAddMode, Optional ByVal IsDaryafti As Boolean = False)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        NewFinanceAdd1.SetBinding(financeId, mode, IsDaryafti)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "NewFinanceAdd"


    Private Sub NewFinanceAdd1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewFinanceAdd1.SizeChanged

        Me.Size = New Size(Me.Width, NewFinanceAdd1.Height + 50)

    End Sub

#End Region

End Class