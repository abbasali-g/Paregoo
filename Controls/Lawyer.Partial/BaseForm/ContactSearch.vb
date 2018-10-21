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

            'Dim f As New ContactAdd(ID)

            'f.ShowDialog()

            'UcContactSearch1.RefreshContacts()

        End If

    End Sub

    'Private Sub btnAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUser.Click

    '    lblMessage.Text = String.Empty

    '    Dim f As New ContactAdd()

    '    f.ShowDialog()

    '    UcContactSearch1.RefreshContacts()

    'End Sub

    'Private Sub btnDelUser_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelUser.DragDrop

    '    lblMessage.Text = String.Empty

    '    Try

    '        Dim data As ArrayList = e.Data.GetData("ArrayList")

    '        If data.Item(0) = "Contact" Then

    '            Dim msgbox As New dadMessageBox(Lawyer.Common.VB.DadMessages.Messages.ConfirmDelete, "حذف کاربر")

    '            If msgbox.ShowMessage() = Windows.Forms.DialogResult.Yes Then

    '                Dim contact() As ListViewItem = data.Item(1)

    '                For Each Item As ListViewItem In contact

    '                    ''''یک کاربر درسیستم وجود دارد

    '                    Dim msg As String = ContactInfoManager.DelContactByID(Item.SubItems(1).Text)

    '                    If msg <> String.Empty Then

    '                        UcContactSearch1.RefreshContacts()

    '                        lblMessage.Text = msg + " ( " + Item.Text + " )"

    '                        Exit Sub

    '                    Else

    '                        lblMessage.Text = String.Empty

    '                    End If

    '                Next

    '                UcContactSearch1.RefreshContacts()

    '            End If

    '        End If

    '    Catch ex As Exception

    '        lblMessage.Text = Lawyer.Common.VB.DadMessages.Messages.ConfirmDelete
    '        ErrorManager.WriteMessage("btnDelUser_DragDrop", ex.ToString(), Me.Text)
    '    End Try

    'End Sub

    'Private Sub btnDelUser_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelUser.DragEnter

    '    e.Effect = DragDropEffects.Copy

    'End Sub

    Private Sub ContactSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblMessage.Text = String.Empty

        ToolTip1.SetToolTip(btnAddUser, "جدید")

        ToolTip1.SetToolTip(btnDelUser, "حذف")

        ToolTip1.SetToolTip(btnHelp, "برای جستجو ابتدا نام خانوادگی را وارد نمایید")

    End Sub

#End Region

End Class