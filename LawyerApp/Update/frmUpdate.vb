Imports Lawyer.Common.CS.Update
Imports System.Reflection
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.LawyerError
Imports Shetab.LicenseControl.Helper
Imports Lawyer.Common.VB.Common
Imports System.Net

Public Class frmUpdate

    Private Const C_LicenceID As UInteger = LawyerSetting.LicenceId

    Public Function ShowMessage() As System.Windows.Forms.DialogResult

        Return Me.ShowDialog()

    End Function

#Region "Review"

    Private cVersion As String

    Dim thread As Threading.Thread
    Dim thrPrs As Threading.Thread
    Dim dbVersion As String = String.Empty
    WithEvents initD As InitialDownload

    Private Sub frmUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
         
            lblMessage.Text = String.Empty

            ToolTip1.SetToolTip(btnStart, "Start")

            ToolTip1.SetToolTip(btnStop, "Cancel")

            ' check exe file --
            Dim softlock As New SoftLock(C_LicenceID)
            Dim random As New Random()
            Dim day As Integer = random.Next(0, 6)
            If Date.Now.DayOfWeek = day Then
                softlock.CheckLock(False, True)
            End If

            initD = New InitialDownload()

            initD.SetBeforeUpdate(txtMessage, lblMessage, CommonSetting.CommonSettingManager.ConnectionString, dbVersion, Lawyer.Common.Default.DefaultValue.DefaultSoftV)

            SetLastVersions()

            SetBeforeStart()

            SetForRestart()

            LoadConfigFile()



        Catch ex As Exception

        End Try


    End Sub

    Private Sub SetForRestart()

        Try
            If UpdateStatus.IsExistNewVersion AndAlso UpdateStatus.LastVersion <> String.Empty Then

                pnlRestart.Visible = True

                pnlStart.Visible = False

                txtMessage.Text = "برای دریافت نسخه جدید نرم افزار  Restart را کلیک کنید...."

                ProgressBar1.Value = ProgressBar1.Maximum

                lblMessage.Text = String.Empty

            Else
                pnlRestart.Visible = False

                pnlStart.Visible = True

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("SetForRestart", ex.ToString(), Me.Text)

        End Try


    End Sub

    Private Sub SetLastVersions()

        Try

            Dim lastVersion As String = String.Empty

            Try
                
                txtCVersion.Text = "نسخه نرم افزار : " & Lawyer.Common.Default.DefaultValue.DefaultSoftV

                cVersion = Lawyer.Common.Default.DefaultValue.DefaultSoftV

            Catch ex As Exception

                txtCVersion.Text = "نسخه نرم افزار  : " + "------"

                cVersion = String.Empty

            End Try

            SetDBLastVersions()
        Catch ex As Exception
            ErrorManager.WriteMessage("SetLastVersions", ex.ToString(), Me.Text)

        End Try


    End Sub

    Private Sub SetDBLastVersions()

        Try
            dbVersion = InitialDownload.GetDBLastVersion()

            If dbVersion = String.Empty Then

                txtdbVersion.Text = "نسخه پایگاه داده : " + Lawyer.Common.Default.DefaultValue.DefaultDatabaseV

                dbVersion = Lawyer.Common.Default.DefaultValue.DefaultDatabaseV

            Else
                txtdbVersion.Text = "نسخه پایگاه داده : " + dbVersion

            End If

        Catch ex As Exception

            txtdbVersion.Text = "نسخه جاری  : " + "------"

            dbVersion = String.Empty

            ErrorManager.WriteMessage("SetDBLastVersions", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub SetBeforeStart()

        Try
            UpdateStatus.InUpdating = True

            UpdateStatus.CanClose = True

            UpdateStatus.CloseClick = False

            lblMessage.Text = String.Empty

            txtMessage.Text = String.Empty

            ProgressBar1.Value = ProgressBar1.Minimum

        Catch ex As Exception

            ErrorManager.WriteMessage("SetBeforeStart", ex.ToString(), Me.Text)
        End Try


    End Sub

    Private Sub btnStartUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        Try

            ' check exe file --
            Dim softLock As New SoftLock(C_LicenceID)
            softLock.CheckLock(False, True)

            SetBeforeStart()

            If rdbServer.Checked Then

                thread = New Threading.Thread(New Threading.ThreadStart(AddressOf StartUpdate))

                thread.Start()

            Else

                thread = New Threading.Thread(New Threading.ThreadStart(AddressOf StartUpdateByInternet))

                thread.Start()

                '''' StartUpdateByInternet()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Sub StartProgress()

        Try
            ProgressBar1.Minimum = 0

            ProgressBar1.Maximum = 100

            For index As Integer = 1 To 100

                Threading.Thread.Sleep(20)

                ProgressBar1.Increment(1)

                If index = 99 Then

                    index = 5

                    ProgressBar1.Value = 5

                End If

            Next
        Catch ex As Exception
            ErrorManager.WriteMessage("StartProgress", ex.ToString(), Me.Text)
        End Try


    End Sub

    Sub CompleteProgress()

        Try

            While ProgressBar1.Value < 100

                ProgressBar1.Value += 5

                System.Threading.Thread.Sleep(5)

            End While

        Catch ex As Exception
            ErrorManager.WriteMessage("CompleteProgress", ex.ToString(), Me.Text)
        End Try


    End Sub

    Sub StartUpdate()

        Try

            thrPrs = New Threading.Thread(New Threading.ThreadStart(AddressOf StartProgress))

            thrPrs.Start()

            setForm(False)
           
            Dim result As ResultUpdate = Downloader.Download(Lawyer.Common.Default.DefaultValue.DefaultSoftV, System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Environment.GetCommandLineArgs()(3), CommonSetting.CommonSettingManager.ConnectionString, txtMessage, lblMessage)

            Select Case result

                Case ResultUpdate.exit

                    lblMessage.Text = "لغو عملیات بروزرسانی توسط کاربر...."

                    txtMessage.Text = String.Empty

            End Select

            Throw New Exception

        Catch ex As Exception

            setForm(True)

            SetForRestart()

            btnStart.Enabled = True

            UpdateStatus.CanClose = True

            StopProcess()


        End Try

    End Sub

    Private Sub setForm(ByVal IsShow As Boolean)

        Try

            If IsShow Then

                Me.WindowState = FormWindowState.Normal

                Me.Activate()

                Me.BringToFront()


            Else

                Me.WindowState = FormWindowState.Minimized

            End If

        Catch ex As Exception

        End Try
       

    End Sub

    Sub StartUpdateByInternet()

        Dim r As ResultUpdate = ResultUpdate.exit

        Try
            'start progress bar
            thrPrs = New Threading.Thread(New Threading.ThreadStart(AddressOf StartProgress))

            thrPrs.Start()

            'set the lables and connetion
            initD.SetBeforeUpdate(txtMessage, lblMessage, CommonSetting.CommonSettingManager.ConnectionString, dbVersion, cVersion)
            'bring to front or minimize the form
            setForm(False)

            r = initD.DoUpdate()

            Select Case r

                Case ResultUpdate.exit

                    lblMessage.Text = "لغو عملیات بروزرسانی توسط کاربر...."
                    txtMessage.Text = String.Empty

            End Select

            Throw New Exception

        Catch ex As Exception

            setForm(True)

            SetForRestart()

            btnStart.Enabled = True

            UpdateStatus.CanClose = True

            SetDBLastVersions()

            StopProcess(r)

        End Try


    End Sub

    Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click

        UpdateStatus.RestartApp = True

        UpdateStatus.InUpdating = False

        Me.Close()

    End Sub

    Private Sub btnRestartLater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestartLater.Click

        UpdateStatus.InUpdating = False

        Me.Close()

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function closeForm() As Boolean

        UpdateStatus.CloseClick = True

        Try

            If UpdateStatus.CanClose Then

                If thread IsNot Nothing Then

                    thread.Abort()

                    lblMessage.Text = "لغو عملیات بروزرسانی توسط کاربر"

                    SetForRestart()

                    btnStart.Enabled = True

                    StopProcess()


                End If

                Return True

            Else

                lblMessage.Text = "لطفا چند لحظه صبر نمایید...."

            End If

        Catch ex As Exception

        End Try

        Return False

    End Function

    'Public Overrides Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    If closeForm() Then

    '        UpdateStatus.InUpdating = False

    '        Me.Close()

    '    End If

    'End Sub

    Private Sub StopProcess(Optional ByVal r As ResultUpdate = ResultUpdate.exit)

        Try
            If thrPrs IsNot Nothing Then
                thrPrs.Abort()
            End If
            If thread IsNot Nothing Then
                thread.Abort()
            End If

            If pnlRestart.Visible OrElse (r = ResultUpdate.update OrElse ResultUpdate.uptodate) Then
                CompleteProgress()
            End If
        Catch ex As Exception
            If pnlRestart.Visible OrElse (r = ResultUpdate.update OrElse ResultUpdate.uptodate) Then
                CompleteProgress()
            End If
        End Try

    End Sub

    Private Sub btnCancleUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click

        Try

            closeForm()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub LoadConfigFile()

        Dim currentConfig As Lawyer.Common.CS.ConfigFile.Config

        Try

            currentConfig = Lawyer.Common.CS.ConfigFile.Config.Load(FileManager.GetLoginConfigPath())

            If currentConfig Is Nothing Then

                currentConfig = Lawyer.Common.CS.ConfigFile.Config.CreateDefultXml(FileManager.GetLoginConfigPath())

            End If

        Catch ex As Exception

            currentConfig = Nothing

        End Try


        If Not ISLocalVersion(currentConfig) Then rdbInternet.Enabled = False

    End Sub

    Private Function ISLocalVersion(ByVal currentConfig As Lawyer.Common.CS.ConfigFile.Config) As Boolean

        Try

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

        Catch ex As Exception

        End Try
        

    End Function

#End Region


End Class