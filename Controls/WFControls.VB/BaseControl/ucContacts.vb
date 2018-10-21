Imports Lawyer.Common.VB.ContactInfo
Imports NwdSolutions.Web.GeneralUtilities

Public Class ucContacts

    Public Enum SearchType
        role = 1
    End Enum

    Private _SearchType As SearchType
    Private _WhereCondition As String
    Private _fullWhereCondition As String
    Private _location As Point

    Delegate Sub showContactInfoHandler(ByVal custID As String)
    Event showContactInfo As showContactInfoHandler

    Delegate Sub ContactAddHandler(ByVal c As ContactInfoReview)
    Event ContactAdd As ContactAddHandler

    Delegate Sub ConfirmHandler()
    Event ShowConfirm As ConfirmHandler

    Delegate Sub ContactDetailHandler(ByVal custId As String)
    Event ContactDetail As ContactDetailHandler

    Public YesClicked As Boolean = False

    Private Sub ucContacts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ToolTip1.SetToolTip(btnClose, "بستن")

        ToolTip1.SetToolTip(btnRefresh, "تازه گردانی")

        ToolTip1.SetToolTip(btnShowDetail, "اضافه کردن")

        Me.Hide()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Hide()

    End Sub

    Public Sub BindContacts(ByVal stype As SearchType, ByVal whereCondition As String, ByVal _location As Point, ByVal keyEntered As String, ByRef txtBox As String)

        Try
            _SearchType = stype

            _WhereCondition = whereCondition

            Me.Location = _location

            Me.Show()

            '' ''txtContacts.Text = NwdSolutions.Web.GeneralUtilities.General.DbReplace(keyEntered)

            txtContacts.Text = String.Empty

            LoadContacts()

            txtContacts.Refresh()

            txtContacts.Select(txtContacts.Text.Length, 0)

            _textBoxRef = txtBox

        Catch ex As Exception

        End Try

    End Sub

    Public Sub BindContacts(ByVal stype As SearchType, ByVal whereCondition As String, ByVal _location As Point, ByVal keyEntered As String, ByRef txtBox As String, ByVal nokhod As String)

        Try
            _SearchType = stype

            _WhereCondition = whereCondition

            Me.Location = _location

            Me.Show()

            '' ''txtContacts.Text = NwdSolutions.Web.GeneralUtilities.General.DbReplace(keyEntered)

            txtContacts.Text = String.Empty

            LoadContacts("nokhodSiah")

            txtContacts.Refresh()

            txtContacts.Select(txtContacts.Text.Length, 0)

            _textBoxRef = txtBox

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadContacts()

        _fullWhereCondition = String.Empty


        Try

            Select Case _SearchType

                Case SearchType.role

                    If _WhereCondition <> String.Empty Then _fullWhereCondition = " where (custType=" & _WhereCondition & ") "

                    txtContacts.AutoCompleteCustomSource = ContactInfoManager.GetAllUserFullName(_fullWhereCondition)


            End Select

        Catch ex As Exception

        End Try

        txtContacts.Focus()

    End Sub

    Private Sub LoadContacts(ByVal nokhod As String)

        _fullWhereCondition = _WhereCondition


        Try
            txtContacts.AutoCompleteCustomSource = ContactInfoManager.GetAllUserFullName(_fullWhereCondition)
            ''Select Case _SearchType

            ''    Case SearchType.role

            ''        '  If _WhereCondition <> String.Empty Then _fullWhereCondition = " where (custType=" & _WhereCondition & ") "

            ''        txtContacts.AutoCompleteCustomSource = ContactInfoManager.GetAllUserFullName(_fullWhereCondition)


            ''End Select

        Catch ex As Exception

        End Try

        txtContacts.Focus()

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        LoadContacts()

    End Sub

    Private Sub addContactToDB()
        Try
            Dim name As String = txtContacts.Text

            If txtContacts.AutoCompleteCustomSource.IndexOf(name) <> -1 Then


                Select Case _SearchType

                    Case SearchType.role

                        RaiseEvent ContactAdd(ContactInfoManager.GetUserByNameAndRole(name, _fullWhereCondition))

                        txtContacts.Select(0, txtContacts.Text.Length)

                        Exit Sub

                End Select


            ElseIf name.Trim().Length > 0 Then

                YesClicked = False

                If _WhereCondition <> String.Empty Then

                    RaiseEvent ShowConfirm()

                    If YesClicked Then
                        'ثبت کاربر جدید
                        Dim c As New Contact

                        c.custIsSysUser = False

                        c.custID = Guid.NewGuid.ToString()

                        c.custFullName = NwdSolutions.Web.GeneralUtilities.General.DbReplace(name)

                        'rasman eshahlik ...
                        Try
                            c.custType = _WhereCondition.Substring(0, 1)
                        Catch ex As Exception
                            c.custType = 0
                        End Try

                        c.custIsAdminUser = False

                        If ContactInfoManager.AddContact(c) Then

                            RaiseEvent ContactAdd(New ContactInfoReview(c.custID, c.custFullName))

                            txtContacts.Text = String.Empty

                            LoadContacts()
                            RaiseEvent showContactInfo(c.custID)

                            Exit Sub

                        End If

                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtContacts_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContacts.KeyDown

        Try

            If e.KeyCode = Keys.Enter Then

                addContactToDB()

            ElseIf e.KeyCode = Keys.Escape Then

                Me.Hide()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub txtContacts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContacts.KeyPress

        e.KeyChar = NwdSolutions.Web.GeneralUtilities.General.DbReplace(e.KeyChar)

    End Sub

    Private _textBoxRef As String

    Public ReadOnly Property RefTextBox() As String
        Get
            Return _textBoxRef
        End Get

    End Property

    Private Sub btnShowDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowDetail.Click
        addContactToDB()
    End Sub

    Public Sub RefreshContacts()

        LoadContacts()

    End Sub

End Class
