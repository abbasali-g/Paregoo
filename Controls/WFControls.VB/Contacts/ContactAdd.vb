Imports Lawyer.Common.VB.ContactInfo
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.LawyerError

Public Class ContactAdd


    Public Sub ContactAdd(ByVal custID As String)
        Bind(custID)
    End Sub
#Region "Variable"

    Dim defaultImage As Image

    Dim curimagePath As String = String.Empty

    Dim curcustID As String = String.Empty

    Public YesClicked As Boolean = False

    Delegate Sub ShowConfirm(ByVal text As String, ByVal title As String)

    Event ShowMessageBox As ShowConfirm

    Private PreName As String = String.Empty

    Private preRole As String = String.Empty

#End Region

#Region "Events"




    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        BrowseImage()

    End Sub

    Private Sub toolStripChangeImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripChangeImage.Click

        BrowseImage()

    End Sub

    Private Sub toolStripDelImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripDelImage.Click

        lblMessage.Text = String.Empty

        If EditImage("") Then

            picImage.BackgroundImage = defaultImage

            curimagePath = String.Empty

        End If

    End Sub

    Private Sub pnlImage_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pnlImage.DragEnter

        e.Effect = DragDropEffects.Copy

    End Sub

    Private Sub pnlImage_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pnlImage.DragDrop

        Try

            lblMessage.Text = String.Empty

            Dim extension As String

            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

            If files IsNot Nothing And files.Length > 0 Then

                Dim item As String = files(0)

                extension = System.IO.Path.GetExtension(item)

                If extension <> String.Empty AndAlso (BaseForm.ImageManager.IsCorrectImage(extension)) Then

                    If EditImage(item) Then

                        curimagePath = item

                        picImage.BackgroundImage = Image.FromFile(curimagePath)

                    End If


                End If

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا درتغییر تصویر ."
            ErrorManager.WriteMessage("pnlImage_DragDrop", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub chkIsSysUser_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsSysUser.CheckStateChanged

        lblMessage.Text = String.Empty

        pnlSysUserDetail.Enabled = chkIsSysUser.Checked

    End Sub

    Private Sub chkChangePass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChangePass.CheckedChanged

        lblMessage.Text = String.Empty

        setPasswordEdit()

    End Sub

    Private Sub ContactAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFullName.Focus()

        defaultImage = Global.WFControls.VB.My.Resources.Resources.NOPIC

        pnlSysUserDetail.Enabled = False

        If Login.CurrentLogin.CurrentUser IsNot Nothing AndAlso Not Login.CurrentLogin.CurrentUser.IsAdmin Then

            chkIsSysUser.Enabled = False

            chkIsAdmin.Enabled = False

        End If

        Dim types As Setting.SettingCollection

        Try

            types = ContactInfo.ContactInfoManager.GetAllContactType()

            If types IsNot Nothing AndAlso types.Count > 0 Then

                cmbContactType.DisplayMember = "settingName"

                cmbContactType.ValueMember = "settingValue"

                cmbContactType.DataSource = types

                cmbContactType.SelectedValue = "0"

                lblMessage.Text = String.Empty


            Else

                Throw New Exception

            End If

        Catch ex As Exception

            lblMessage.Text = "به علت عدم وجود عنوان امکان ثبت وجود ندارد"

            btnSave.Enabled = False

            'ErrorManager.WriteMessage("ContactAdd_Load", ex.ToString(),Me.ParentForm.Text)

        End Try

        ToolTip1.SetToolTip(btnBrowse, "افزودن تصویر")

        ToolTip1.SetToolTip(btnHelp, " ابتدا نام خانوادگی را وارد نمایید")


    End Sub

    Private Sub txtNumberID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberID.KeyPress, txtOfficeTel.KeyPress, txtHomeTel.KeyPress, txtFax.KeyPress, txtCellphone.KeyPress

        lblMessage.Text = String.Empty

        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            YesClicked = False

            If CheckBeforeSave() Then

                Dim c As New Contact

                'sysUser
                c.custIsSysUser = chkIsSysUser.Checked

                If chkIsSysUser.Checked Then

                    c.custSaltkey = DateAndTime.Now()

                    Try
                        c.custPassword = SecurityHelper.Encrypt(txtPassword.Text.Trim(), c.custSaltkey)
                        c.custNetUser = SecurityHelper.Encrypt(txtNetUser.Text.Trim(), c.custSaltkey)
                        c.custNetPassword = SecurityHelper.Encrypt(txtNetPassword.Text.Trim(), c.custSaltkey)

                    Catch ex As Exception

                        lblMessage.Text = "رمز عبور را تغییر دهید"

                        Exit Sub

                    End Try

                    c.custUserName = txtUserName.Text.Trim()

                End If

                'General 
                c.custFullName = txtFullName.Text.Trim()

                c.custFatherName = txtFatherName.Text.Trim()

                Dim bd As Integer? = txtBirthday.GetShamsiDateInNumericFormat()

                If bd.HasValue Then

                    c.custBthDay = bd

                End If

                c.custIDNumber = txtNumberID.Text

                c.custRegisterationNumber = txtRegNumber.Text.Trim()

                'Job

                c.custJobTitle = txtJob.Text.Trim()

                c.custCompanyName = txtCompanyName.Text.Trim()


                'Tamas

                c.custCellPhone = txtCellphone.Text

                c.custFax = txtFax.Text

                c.custHomeTel = txtHomeTel.Text

                c.custOfficeTel = txtOfficeTel.Text

                c.custAddress = txtAddress.Text.Trim()

                c.custDescription = richTxtDescription.Text.Trim()

                'internet
                c.custEmailOne = txtEmail1.Text.Trim()


                'SysAdmin
                c.custIsAdminUser = chkIsAdmin.Checked

                If ((curcustID <> String.Empty AndAlso PreName <> NwdSolutions.Web.GeneralUtilities.General.DbReplace(c.custFullName)) OrElse curcustID = String.Empty) AndAlso ContactInfoManager.ISCantactNameIsRepeteive(c.custFullName, curcustID) Then

                    RaiseEvent ShowMessageBox("فردی با نام خانوادگی وارد شده قبلا ثبت شده است، آیا مایل به ثبت هستید ؟", "هشدار")

                Else

                    YesClicked = True

                End If

                If YesClicked Then

                    If curcustID = String.Empty Then

                        'Add

                        c.custID = Guid.NewGuid.ToString()

                        c.custType = cmbContactType.SelectedValue

                        If ContactInfoManager.AddContact(c) Then

                            Dim pic As New BaseForm.Image

                            pic.imagePath = curimagePath

                            pic.imageID = c.custID

                            pic.imageExtension = System.IO.Path.GetExtension(curimagePath)

                            pic.imageUpdateDate = DateManager.GetFileUpdateDate()

                            pic.imageName = System.IO.Path.GetFileNameWithoutExtension(pic.imagePath)

                            If Not BaseForm.ImageManager.AddImage(pic) Then

                                lblMessage.Text = "تصویر کاربر ذخیره نشد."

                            Else

                                lblMessage.Text = "کاربر مورد نظر ثبت شد."

                                ResetElements()

                            End If


                        Else

                            lblMessage.Text = "خطا در ثبت "

                        End If

                    Else
                        'Edit

                        If preRole <> cmbContactType.SelectedValue AndAlso FileParties.FilePartiesManager.IsExitContactID(curcustID) Then

                            lblMessage.Text = "برای فرد مورد نظر قبلا  پرونده تشکیل شده و امکان تغییر عنوان وجود ندارد."

                            cmbContactType.SelectedValue = preRole

                            Exit Sub

                        End If

                        c.custType = cmbContactType.SelectedValue

                        c.custID = curcustID

                        If ContactInfoManager.UpdateContact(c) Then

                            If Login.CurrentLogin.CurrentUser.UserID = curcustID Then

                                Login.LoginManager.changeUserInfo(c.custFullName, c.custIsAdminUser, c.custEmailOne, c.custType)

                            End If

                            ParentForm.Close()

                        Else

                            lblMessage.Text = "خطا در ویرایش اطلاعات کاربر"

                        End If

                    End If

                End If


            End If



        Catch ex As Exception

            lblMessage.Text = "خطا در انجام عملیات"

            ErrorManager.WriteMessage("btnSave_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#Region "Utility"

    Private Sub BrowseImage()

        lblMessage.Text = String.Empty

        Me.OpenFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"

        Me.OpenFileDialog1.FileName = String.Empty

        If (Me.OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then

            If EditImage(OpenFileDialog1.FileName) Then

                curimagePath = OpenFileDialog1.FileName

                picImage.BackgroundImage = Image.FromFile(curimagePath)

            End If

        End If

    End Sub

    Private Function EditImage(ByVal imagePath As String) As Boolean

        Try

            If curcustID <> String.Empty Then

                'آیا تصویر قبلا ثبت شده است

                Dim pic As New BaseForm.Image

                pic.imagePath = imagePath

                pic.imageID = curcustID

                pic.imageExtension = System.IO.Path.GetExtension(imagePath).ToLower()

                pic.imageUpdateDate = DateManager.GetFileUpdateDate()

                pic.imageName = System.IO.Path.GetFileNameWithoutExtension(pic.imagePath)


                If BaseForm.ImageManager.IsImageExist(curcustID) Then

                    Return BaseForm.ImageManager.EditImage(pic)

                Else

                    Return BaseForm.ImageManager.AddImage(pic)

                End If

            End If

            Return True

        Catch ex As Exception
            ErrorManager.WriteMessage("EditImage", ex.ToString(), Me.ParentForm.Text)
            Return False

        End Try

    End Function

    Private Sub setPasswordEdit()

        Dim status As Boolean = chkChangePass.Checked

        txtPassword.Enabled = status

        txtConfirmPass.Enabled = status

    End Sub

    Private Function CheckBeforeSave() As Boolean

        lblMessage.Text = String.Empty

        If txtNumberID.Text <> String.Empty AndAlso txtNumberID.Text.Length < 10 Then txtNumberID.Text = txtNumberID.Text.PadLeft(10, "0"c)

        If txtFullName.Text.Trim = String.Empty Then

            lblMessage.Text = "نام خانوادگی را وارد نمایید."

            txtFullName.Focus()

            Return False

        End If


        If txtUserName.Text.Trim() = String.Empty Then

            txtPassword.Text = String.Empty

            txtConfirmPass.Text = String.Empty

        End If

        If chkIsSysUser.Checked AndAlso txtUserName.Text.Trim() = String.Empty Then

            lblMessage.Text = "نام کاربری را وارد نمایید."

            txtUserName.Focus()

            Return False

        End If

        If txtUserName.Text.Trim() <> String.Empty AndAlso txtPassword.Text.Trim() = String.Empty Then

            lblMessage.Text = "رمز عبور را وارد نمایید."

            txtPassword.Focus()

            Return False

        End If

        If txtPassword.Text.Trim() <> String.Empty AndAlso txtPassword.Text.Trim() <> txtConfirmPass.Text.Trim() Then

            lblMessage.Text = "رمز عبور و تایید آن بایستی یکسان باشد."

            txtConfirmPass.Text = String.Empty

            txtConfirmPass.Focus()

            Return False

        End If

        Dim result As String = String.Empty

        Try

            result = ContactInfoManager.GetContactIDByUserName(txtUserName.Text.Trim())

            If result <> String.Empty AndAlso result <> curcustID Then

                Throw New Exception

            End If

        Catch ex As Exception

            lblMessage.Text = "نام کاربری تکراری می باشد."

            Return False

        End Try

        'تنها کاربر Admin

        If Not ContactInfoManager.ISExistAdminUser(curcustID) Then

            If (Not chkIsSysUser.Checked) OrElse (Not chkIsAdmin.Checked) Then

                lblMessage.Text = "به دلیل عدم وجود کاربر مدیر در سیستم، گزینه های کاربر سیستم و مدیر را انتخاب نمایید. "
                Return False
            End If

        End If

        Return True

    End Function

    Private Sub ResetElements()

        txtFullName.Text = String.Empty

        txtFatherName.Text = String.Empty

        txtBirthday.SetShamsiDate(String.Empty)

        txtNumberID.Text = String.Empty

        txtRegNumber.Text = String.Empty

        'Job

        txtJob.Text = String.Empty

        txtCompanyName.Text = String.Empty

        'Tamas

        txtCellphone.Text = String.Empty

        txtFax.Text = String.Empty

        txtHomeTel.Text = String.Empty

        txtOfficeTel.Text = String.Empty

        txtAddress.Text = String.Empty

        richTxtDescription.Text = String.Empty

        'internet
        txtEmail1.Text = String.Empty

        txtNetUser.Text = String.Empty

        txtNetPassword.Text = String.Empty

        'sysUser
        chkIsSysUser.Checked = False

        txtPassword.Text = String.Empty

        txtConfirmPass.Text = String.Empty

        txtUserName.Text = String.Empty

        'SysAdmin
        chkIsAdmin.Checked = False

        picImage.Image = defaultImage

        picImage.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

#End Region

#Region "Methods"

    Public Sub Bind(ByVal custId As String)

        Dim c As Contact = Nothing

        Try

            c = ContactInfoManager.GetContactByID(custId)

            If c IsNot Nothing Then
                'General 
                txtFullName.Text = c.custFullName

                PreName = c.custFullName

                txtFatherName.Text = c.custFatherName

                txtBirthday.SetShamsiDateInNumericFormat(c.custBthDay)

                txtNumberID.Text = c.custIDNumber

                txtRegNumber.Text = c.custRegisterationNumber

                'Job

                txtJob.Text = c.custJobTitle

                txtCompanyName.Text = c.custCompanyName

                'Tamas

                txtCellphone.Text = c.custCellPhone

                txtFax.Text = c.custFax

                txtHomeTel.Text = c.custHomeTel

                txtOfficeTel.Text = c.custOfficeTel

                txtAddress.Text = c.custAddress

                richTxtDescription.Text = c.custDescription

                'internet
                txtEmail1.Text = c.custEmailOne

                txtNetUser.Text = SecurityHelper.Decrypt(c.custNetUser, c.custSaltkey)

                txtNetPassword.Text = SecurityHelper.Decrypt(c.custNetPassword, c.custSaltkey)



                'sysUser
                chkIsSysUser.Checked = c.custIsSysUser

                txtPassword.Text = SecurityHelper.Decrypt(c.custPassword, c.custSaltkey)

                txtConfirmPass.Text = txtPassword.Text

                txtUserName.Text = c.custUserName

                'SysAdmin
                chkIsAdmin.Checked = c.custIsAdminUser

                Me.curcustID = c.custID

                cmbContactType.SelectedValue = c.custType.ToString()
                preRole = c.custType.ToString()
                chkChangePass.Visible = True

                If Not (Login.CurrentLogin.CurrentUser.IsAdmin OrElse custId = Login.CurrentLogin.CurrentUser.UserID) AndAlso txtUserName.Text <> String.Empty Then

                    pnlSysUserDetail.Enabled = False

                    chkChangePass.Visible = False

                End If

                If chkChangePass.Visible Then setPasswordEdit()

            Else

                Throw New Exception

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("Bind", ex.ToString(), Me.ParentForm.Text)

            lblMessage.Text = "خطا در بارگذاری مشخصات کاربر"

            btnSave.Enabled = False

            Exit Sub

        End Try

        Try

            Dim pic As BaseForm.Image = BaseForm.ImageManager.GetImageByID(c.custID)

            If pic Is Nothing OrElse pic.imageExtension = String.Empty Then

                Throw New Exception

            Else

                curimagePath = FileManager.GetContactPicturePath() + pic.imageID + pic.imageUpdateDate + pic.imageExtension

                FileManager.GetFileFromBinaryFormat(pic.imageLogo, curimagePath, False, False)

                picImage.BackgroundImage = Bitmap.FromFile(curimagePath)


            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("Bind", ex.ToString(), Me.ParentForm.Text)

            picImage.BackgroundImage = defaultImage

            curimagePath = String.Empty

        End Try

    End Sub

#End Region

    Private isCollapse As Boolean = True

    Private Sub pnlCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlCollapse.Click

        If isCollapse Then
            pnlCollapse.Image = Global.WFControls.VB.My.Resources.Resources.collpase
            Panel1.Height = 116
            Me.Size = New Size(Me.Width, 652)
        Else

            pnlCollapse.Image = Global.WFControls.VB.My.Resources.Resources.expand
            Panel1.Height = 0
            Me.Size = New Size(Me.Width, 560)

        End If

        isCollapse = Not isCollapse

    End Sub
End Class
