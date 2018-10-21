Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.ContactInfo
Imports Lawyer.Common.VB.LawyerError

Public Class ContactSearch

#Region "Events"

    Private Sub UcContactSearch1_DeleteMessage() Handles UcContactSearch1.DeleteMessage

        lblMessage.Text = String.Empty

    End Sub

    Private Sub UcContactSearch1_ShowEditForm(ByVal ID As String, ByVal IsMessage As Boolean) Handles UcContactSearch1.ShowEditForm

        If IsMessage Then

            lblMessage.Text = ID

        Else

            Dim f As New ContactAdd(ID)

            f.ShowDialog()

            UcContactSearch1.RefreshContacts()

        End If

    End Sub

    Private Sub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click

        _showNewUserForm()

    End Sub

    Private Sub _showNewUserForm() Handles UcContactSearch1.ShowNewForm
        lblMessage.Text = String.Empty

        Dim f As New ContactAdd()

        f.ShowDialog()

        UcContactSearch1.RefreshContacts()

    End Sub

    Private Sub btnDelUser_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelUser.DragDrop

        lblMessage.Text = String.Empty
        Dim data As ArrayList = e.Data.GetData("ArrayList")
        deleteUsers(data)

    End Sub



    Private Sub btnDelUser_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelUser.DragEnter

        e.Effect = DragDropEffects.Copy

    End Sub

    Private Sub deleteUsers(ByVal data As ArrayList)
        lblMessage.Text = String.Empty

        Try

            'Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim msgbox As New dadMessageBox(Lawyer.Common.VB.DadMessages.Messages.ConfirmDelete, "حذف کاربر")

                If msgbox.ShowMessage() = Windows.Forms.DialogResult.Yes Then

                    Dim contact() As ListViewItem = data.Item(1)

                    For Each Item As ListViewItem In contact

                        ''''یک کاربر درسیستم وجود دارد

                        Dim msg As String = ContactInfoManager.DelContactByID(Item.SubItems(1).Text)

                        If msg <> String.Empty Then

                            UcContactSearch1.RefreshContacts()

                            lblMessage.Text = msg + " ( " + Item.Text + " )"

                            Exit Sub

                        Else

                            lblMessage.Text = String.Empty

                        End If

                    Next

                    UcContactSearch1.RefreshContacts()

                End If

            End If

        Catch ex As Exception

            lblMessage.Text = Lawyer.Common.VB.DadMessages.Messages.ConfirmDelete
            ErrorManager.WriteMessage("btnDelUser_DragDrop", ex.ToString(), Me.Text)
        End Try

    End Sub
    Private Sub ContactSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        ''abbas
        '' LoginManager.SetCurrentLoginDebug("e6a96e46-b0e2-49df-a141-1de32258bdbd")

        lblMessage.Text = String.Empty

        ToolTip1.SetToolTip(btnAddUser, "جدید")

        ToolTip1.SetToolTip(btnDelUser, "حذف")

        ToolTip1.SetToolTip(btnHelp, "برای جستجو ابتدا نام خانوادگی را وارد نمایید")

    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal role As Enums.RoleType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        UcContactSearch1.RoleType = role

    End Sub

    Private Sub btnDelUser_Click(sender As Object, e As EventArgs) Handles btnDelUser.Click
        deleteUsers(UcContactSearch1.getSelectedContact())
    End Sub


    Private Sub _ucSms_OpenForm(ByVal fileCaseID As String, ByVal timeID As String, ByVal dt As DataTable, ByVal smsText As String) Handles UcContactSearch1._showSmsForm
        Dim frmSmsDialog As New frmSms(fileCaseID, timeID, dt, smsText)
        frmSmsDialog.ShowDialog()

    End Sub

End Class