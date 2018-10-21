Imports Lawyer.Common.VB.ContactInfo
Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.CS.Update
Imports Lawyer.Common.VB.Common
Imports System.Net
Imports Shetab.LicenseControl.Helper
Imports System.Security.Cryptography
Imports System.Text
Imports System.Security
Imports System.Diagnostics

Public Class Login

    Dim IsCorectConection As Boolean = False
    Dim currentConfig As Lawyer.Common.CS.ConfigFile.Config
    Private Const C_LicenceID As UInteger = LawyerSetting.LicenceId
    Private Const C_Key As String = "@@%!unregister"

#Region "Review"

    Private Sub picClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picClose.Click

        CloseForm()

    End Sub

    Private Sub CloseForm()

        Try

            Me.Close()

            Application.Exit()

            For Each Item As Process In Process.GetProcessesByName("LawyerApp")

                Item.Kill()
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            ' '' '''''*********** نسخه آزمایشیLawyerSetting.CheckExpire()
            ' ''If Environment.GetCommandLineArgs().Length < 3 Then
            ' ''    ''abbas important
            ' ''    '' Application.Exit()

            ' ''End If



            lblMessage.Text = String.Empty

            pnlSetting.Visible = False

            Me.Size = New Size(Me.Size.Width, Me.Size.Height - pnlSetting.Size.Height - 2)

            ToolTip1.SetToolTip(btnRefresh, "Refresh")

            ToolTip1.SetToolTip(btnLogin, "ورود به سیستم")

            LoadConfigFile()

            SetIp()

            setCurrentLoginStatus()

            ServerStatus1.ShowStatus(currentConfig)

            lblVersion.Text = "نسخه " + Lawyer.Common.Default.DefaultValue.DefaultSoftV

            FileManager.EmptyDirectory()

            'UcShamsiDate1.showShamsiDate()

            If OpenformForFirstTime() Then

                InstallDataBase(False, True)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub LoadConfigFile()

        Try


            currentConfig = Lawyer.Common.CS.ConfigFile.Config.Load(FileManager.GetLoginConfigPath())

            If currentConfig Is Nothing Then

                currentConfig = Lawyer.Common.CS.ConfigFile.Config.CreateDefultXml(FileManager.GetLoginConfigPath())

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            currentConfig = Nothing

        End Try

    End Sub

    Private Sub SetIp()

        If currentConfig IsNot Nothing Then

            lblIP.Text = currentConfig.LIP

        End If

    End Sub

    Private Sub LoginApp()

        Try

            If CheckBeforeLogin() Then


                Dim str As String = LoginManager.ValidateSavedConnection(currentConfig, ISLocalVersion())

                If str <> String.Empty Then

                    lblMessage.Text = str

                Else

                    If ContactInfoManager.ValidateUser(txtUserName.Text, txtPassword.Text) Then

                        Dim deskForm As New frmDesktop()

                        If currentConfig IsNot Nothing Then currentConfig = Nothing

                        'تنظیم currentLogin

                        If CurrentLogin.CurrentUser.Name = String.Empty Then

                            LoginManager.SetCurrentLogin(CurrentLogin.CurrentUser.UserID)

                        End If

                        ContactInfoManager.UpdateContactToLoginState(CurrentLogin.CurrentUser.UserID, 1)

                        Me.Hide()

                        deskForm.ShowDialog()

                        ContactInfoManager.UpdateContactToLoginState(CurrentLogin.CurrentUser.UserID, 0)

                        ''Try

                        ''    If UpdateStatus.IsExistNewVersion AndAlso UpdateStatus.LastVersion <> String.Empty Then

                        ''        Process.Start(Environment.GetCommandLineArgs()(2), String.Format("{0}  {1}  {2}", UpdateStatus.LastVersion, UpdateStatus.RestartApp, UpdateStatus.LastVersionName))

                        ''    End If

                        ''Catch ex As Exception

                        ''    Dim f As New InfoDadMessageBox(True, "عمل بروز رسانی انجام نشد.", "خطا در بروز رسانی")

                        ''    f.ShowDialog()

                        ''End Try

                        CloseForm()

                    Else

                        lblMessage.Text = "ورود نامعتبر می باشد."

                    End If

                End If

            End If

        Catch ex As Exception
            lblMessage.Text = "خطا در برقراری ارتباط." + " (" + ex.Message + ")"

        End Try

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        LoginApp()

    End Sub

    Private Function CheckBeforeLogin()

        If txtUserName.Text.Trim() = String.Empty Then

            lblMessage.Text = "نام کاربری را وارد نمایید."

            txtUserName.Focus()
            Return False

        End If

        If txtPassword.Text = String.Empty Then

            lblMessage.Text = "رمز عبور را وارد نمایید."
            txtPassword.Focus()
            Return False

        End If

        Return True

    End Function

    Private Function ISLocalVersion() As Boolean

        If currentConfig IsNot Nothing Then

            Dim h As System.Net.IPHostEntry = Dns.GetHostByName(System.Net.Dns.GetHostName)

            For index As Integer = 0 To h.AddressList.Length - 1

                If currentConfig.LIP.ToLower() = h.AddressList.GetValue(index).ToString Then

                    Return True

                End If

            Next

            If currentConfig.LIP.ToLower() <> "localhost" AndAlso currentConfig.LIP.ToLower() <> "127.0.0.1" Then

                Return False

            End If

        End If

        Return True

    End Function

    Private Sub picMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picMinimize.Click

        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub picColEx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picColEx.Click
        panelSetting()
    End Sub
    Private Sub lblSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSetting.Click
        panelSetting()
    End Sub

    Private Sub panelSetting()
        Try

            If pnlLogin.Visible Then

                picColEx.Image = Global.LawyerApp.My.Resources.collapse7_12

                pnlLogin.Visible = False

                pnlSetting.Visible = True

                Me.Size = New Size(Me.Size.Width, pnlSetting.Size.Height + 22)


            Else

                picColEx.Image = Global.LawyerApp.My.Resources.colapse16_12

                pnlLogin.Visible = True

                pnlSetting.Visible = False

                Me.Size = New Size(Me.Size.Width, pnlLogin.Size.Height + 23)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public mouse_offset As Point
    Public mouse_OffForm As Point

    Private Sub pnlHeader_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlHeader.MouseDown

        mouse_offset = New Point(-e.X, -e.Y)

    End Sub

    Private Sub pnlHeader_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlHeader.MouseMove

        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim mousePos As Point = Control.MousePosition

            mousePos.Offset(mouse_offset.X, mouse_offset.Y)

            Location = mousePos

        End If

    End Sub

    Private Sub btnConnectToDBg_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnectToDB.MouseHover

        btnConnectToDB.Image = Global.LawyerApp.My.Resources.connect_h

    End Sub

    Private Sub btnConnectToDB_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnectToDB.MouseLeave

        btnConnectToDB.Image = Global.LawyerApp.My.Resources.Connect

    End Sub

    Private Sub btnConnectToDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnectToDB.Click

        Try

            Dim f As New SetConnectionString()

            f.SetInitial(True, currentConfig, "اتصال به پایگاه داده")

            f.ShowDialog()

            SetIp()

            setCurrentLoginStatus()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnConfig_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.MouseHover

        btnConfig.Image = Global.LawyerApp.My.Resources.Setting_h

    End Sub

    Private Sub btnConfig_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.MouseLeave

        btnConfig.Image = Global.LawyerApp.My.Resources.Setting

    End Sub

    'Private Sub picUnregister_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    picUnregister.Image = Global.LawyerApp.My.Resources.DisableSoft_h

    'End Sub

    'Private Sub picUnregister_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    picUnregister.Image = Global.LawyerApp.My.Resources.DisableSoft

    'End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        Try
            ServerStatus1.ShowStatus(currentConfig)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ToolStripRunService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRunService.Click

        Try

            Process.Start(FileManager.GetAutoConfigExePath, String.Format("{0}  {1}  {2} ", "--password=1", "--startserivec", "--clientType"))

            ServerStatus1.ShowStatus(currentConfig)

        Catch ex As Exception

            ServerStatus1.ShowStatus(currentConfig)

        End Try


    End Sub

    Private Sub ToolStripAutoConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripAutoConfig.Click

        Try

            Dim msg As dadMessageBox = New dadMessageBox("آیا برای انجام پیکربندی مطمئن هستید ؟", "پیکربندی اتوماتیک")

            If msg.ShowMessage() = System.Windows.Forms.DialogResult.Yes Then

                Process.Start(FileManager.GetAutoConfigExePath, String.Format("{0} {1}  {2} ", "--password=1", "--mysqlconfig", "--clientType"))
                ServerStatus1.ShowStatus(currentConfig)

            End If

        Catch ex As Exception
            ServerStatus1.ShowStatus(currentConfig)
        End Try


    End Sub

    Private Sub setCurrentLoginStatus()

        Try

            If currentConfig IsNot Nothing Then

                Dim con As New MySqlConnection(String.Format("server={0};Port={1};uid={2}; pwd={3};database=mysql;", currentConfig.LIP, currentConfig.LPort, currentConfig.LUserName, currentConfig.LPassword))

                con.Open()
                con.Close()

                btncurStatus.Image = Global.LawyerApp.My.Resources.InstallData24

            End If

        Catch ex As Exception

            btncurStatus.Image = Global.LawyerApp.My.Resources.noInstalData24

        End Try

    End Sub

    Private Function OpenformForFirstTime() As Boolean

        Dim con As New MySqlConnection(String.Format("server={0};Port={1};uid={2}; pwd={3};database=mysql;", Lawyer.Common.CS.Common.DefaultValues.DefaultIP, Lawyer.Common.CS.Common.DefaultValues.DefaultPort, Lawyer.Common.CS.Common.DefaultValues.DefaultUser, Lawyer.Common.CS.Common.DefaultValues.DefaultPass))

        Dim com As New MySqlCommand("select count(*) from `information_schema`.`TABLES` where  table_schema='nwdicdad2';", con)

        Try

            If currentConfig IsNot Nothing AndAlso ISLocalVersion() Then

                con.Open()

                Dim count As Long = CLng(com.ExecuteScalar())

                If (count >= 25) Then

                    Return False

                Else

                    Return True

                End If

                con.Close()

            End If

        Catch ex As Exception

            Try

                con.Close()

            Catch ex1 As Exception

                Return False

            End Try

            Return False

        End Try

    End Function

    Private Sub ToolStripManualConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripManualConfig.Click


        Try

            Dim f As New SetConnectionString()

            f.SetInitial(False, currentConfig, "پیکربندی دستی")

            f.ShowDialog()

            ServerStatus1.ShowStatus(currentConfig)

        Catch ex As Exception

            ServerStatus1.ShowStatus(currentConfig)

        End Try

    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown, txtUserName.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then

                'Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                LoginApp()

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click

        Dim x As Integer
        Dim y As Integer
        x = Control.MousePosition().X - Me.Location.X - 35   'Adjust Here If Needed
        y = Control.MousePosition().Y - Me.Location.Y - 40 'Adjust Here If Needed
        Dim xy As New Point(x, y)

        ContextMenuStrip1.Show(sender, xy)

    End Sub

    Private Sub picUnregister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Public Function ComputeHash(ByVal input As String, ByVal algorithm As HashAlgorithm, ByVal salt As String) As String

        Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)
        Dim saltedInput As Byte() = New System.Byte(salt.Length + inputBytes.Length) {}
        Dim _salt As Byte() = Encoding.UTF8.GetBytes(salt)
        _salt.CopyTo(saltedInput, 0)
        inputBytes.CopyTo(saltedInput, salt.Length)
        Dim hashedBytes As Byte() = algorithm.ComputeHash(saltedInput)
        Return BitConverter.ToString(hashedBytes)

    End Function

    Private Sub InstallDataBase(ByVal restoreRLaws As Boolean, ByVal automaticStart As Boolean)

        Try
            If ISLocalVersion() Then

                Dim f As frmRestoreBackup = New frmRestoreBackup(currentConfig, True, restoreRLaws, automaticStart)

                f.ShowDialog()
                ServerStatus1.ShowDataBaseStatus(currentConfig)

            Else

                Dim i As New InfoDadMessageBox(True, "نصب پایگاه داده فقط برای کامپیوتر جاری امکان پذیر می باشد.", "نصب پایگاه داده")
                i.ShowDialog()

            End If


        Catch ex As Exception
            ServerStatus1.ShowDataBaseStatus(currentConfig)

        End Try


    End Sub

    Private Sub ToolStripInstallData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripInstallData.Click
        InstallDataBase(False, False)
       
    End Sub

    Private Sub ToolStripMenuItemLaws_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemLaws.Click
        InstallDataBase(True, False)
    End Sub

    Private Sub picTalk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picTalk.Click
        Dim frm As New SupportForm
        frm.ShowDialog()
    End Sub

    Private Sub toolstripDatabaseMove_Click(sender As Object, e As EventArgs) Handles toolstripDatabaseMove.Click
        Dim frm As New frmDatabaseMove
        frm.ShowDialog()
    End Sub
End Class