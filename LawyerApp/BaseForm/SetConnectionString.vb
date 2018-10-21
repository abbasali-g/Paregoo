Imports Lawyer.Common.CS.ConfigFile
Imports Lawyer.Common.CS
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.LawyerError


Public Class SetConnectionString

    Private IsLogin As Boolean
    Private c As Config
    Private IsTransfer As Boolean

    '' ''Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '' ''    Try

    '' ''        Lawyer.Common.VB.LockDocs.Common.DestComputerName = txtIp.Text

    '' ''        Me.Close()

    '' ''    Catch ex As Exception

    '' ''    End Try

    '' ''End Sub

    Private Sub SetConnectionString_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '' ''    txtIp.Text = Lawyer.Common.VB.LockDocs.Common.DestComputerName

        lblMessage.Text = String.Empty

    End Sub


#Region "LReview"

    Public Sub SetInitial(ByVal IsLogin As Boolean, ByVal currentConfig As Config, ByVal title As String)

        Me.Title.Text = title

        Me.IsLogin = IsLogin

        txtIp.ReadOnly = Not IsLogin

        Try

            c = currentConfig

            If c IsNot Nothing Then

                BindElements()

            End If

            Me.IsTransfer = IsTransfer

        Catch ex As Exception

        End Try

    End Sub

    Public Sub SetIforTransfer(ByVal isLocal As Boolean)

        txtIp.Text = Lawyer.Common.VB.LockDocs.Common.DestIP
        If isLocal AndAlso txtIp.Text = String.Empty Then
            txtIp.Text = Common.DefaultValues.DefaultIP
        End If

        txtPass.Text = Lawyer.Common.VB.LockDocs.Common.DestPass
        If txtPass.Text = String.Empty Then
            txtPass.Text = Common.DefaultValues.DefaultPass
        End If

        txtPort.Text = Lawyer.Common.VB.LockDocs.Common.DestPort
        If txtPort.Text = String.Empty Then
            txtPort.Text = Common.DefaultValues.DefaultPort
        End If
        txtUsername.Text = Lawyer.Common.VB.LockDocs.Common.DestUser
        If txtUsername.Text = String.Empty Then
            txtUsername.Text = Common.DefaultValues.DefaultUser
        End If

        IsTransfer = True

    End Sub

    Private Sub BindElements()

        Try

            If IsLogin Then

                txtIp.Text = c.LIP

                txtPass.Text = c.LPassword

                txtPort.Text = c.LPort

                txtUsername.Text = c.LUserName


            Else

                txtIp.Text = c.IP

                txtPass.Text = c.Password

                txtPort.Text = c.Port

                txtUsername.Text = c.UserName

            End If

        Catch ex As Exception

            txtIp.Text = String.Empty

            txtPass.Text = String.Empty

            txtPort.Text = String.Empty

            txtUsername.Text = String.Empty

            ErrorManager.WriteMessage("BindElements", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            If IsTransfer Then

                Lawyer.Common.VB.LockDocs.Common.DestIP = txtIp.Text.Trim()
                Lawyer.Common.VB.LockDocs.Common.DestUser = txtUsername.Text.Trim()
                Lawyer.Common.VB.LockDocs.Common.DestPort = txtPort.Text.Trim()
                Lawyer.Common.VB.LockDocs.Common.DestPass = txtPass.Text.Trim()

                Me.Close()

                Exit Sub

            End If

            If TestConnection() Then

                If c IsNot Nothing Then

                    c.Decrypt = False

                    If IsLogin Then

                        c.LIP = txtIp.Text.Trim()

                        c.LPassword = txtPass.Text.Trim()

                        c.LPort = txtPort.Text.Trim()

                        c.LUserName = txtUsername.Text.Trim()

                        c.Udpate()

                    Else

                        c.IP = txtIp.Text.Trim()

                        c.Password = txtPass.Text.Trim()

                        c.Port = txtPort.Text.Trim()

                        c.UserName = txtUsername.Text.Trim()

                        c.Udpate()

                    End If

                    Me.Close()

                End If

            Else

                lblMessage.Text = "تنظیمات ذخیره نشد."

            End If


        Catch ex As Exception

            lblMessage.Text = "تنظیمات ذخیره نشد."

            ErrorManager.WriteMessage("btnSave_Click", ex.ToString(), Me.Text)

        End Try


    End Sub

    Private Sub btnConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click

        TestConnection()

    End Sub

    Private Function TestConnection() As Boolean

        Try


            lblMessage.Text = "لطفا چند لحظه صبر نمایید..."

            Me.Refresh()

            If CheckBeforeSave() Then

                If LoginManager.TestConnection(txtIp.Text.Trim(), txtPort.Text.Trim(), txtUsername.Text.Trim(), txtPass.Text.Trim()) Then

                    lblMessage.Text = "ارتباط برقرار شد."

                    Return True

                Else

                    lblMessage.Text = "ارتباط برقرار نشد."

                    Return False

                End If

            End If


        Catch ex As Exception

            lblMessage.Text = "ارتباط برقرار نشد."

            ErrorManager.WriteMessage("TestConnection", ex.ToString(), Me.Text)

            Return False

        End Try

    End Function

    Private Function CheckBeforeSave()

        If txtIp.Text.Trim() = String.Empty Then

            lblMessage.Text = "IP را تنظیم نمایید."

            Return False

        End If

        If txtPass.Text = String.Empty Then
            txtPass.Text = Common.DefaultValues.DefaultPass
        End If

        If txtPort.Text = String.Empty Then
            txtPort.Text = Common.DefaultValues.DefaultPort
        End If

        If txtUsername.Text = String.Empty Then
            txtUsername.Text = Common.DefaultValues.DefaultUser

        End If

        Return True

    End Function

#End Region


End Class