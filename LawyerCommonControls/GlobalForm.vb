Imports Lawyer.Common.VB.LawyerError
Imports System.Windows.Forms
Imports System.Drawing

Public Class GlobalForm

#Region "- Property -"

    Public WriteOnly Property HideMinimize() As Boolean

        Set(ByVal value As Boolean)
            btnMinimize.Visible = Not value
        End Set
    End Property


#End Region

#Region "- Window Move -"


    Public mouse_offset As Point

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

#End Region

#Region "- Window State -"


    Private Sub btnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMinimize_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.MouseHover
        btnMinimize.BackgroundImage = My.Resources.Resources.Minimize_
    End Sub

    Private Sub btnMinimize_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.MouseLeave
        btnMinimize.BackgroundImage = My.Resources.Resources.Minimize
    End Sub

    Public Overridable Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClose_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.MouseHover
        btnClose.BackgroundImage = My.Resources.Resources.closeForm2_
    End Sub

    Private Sub btnClose_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.MouseLeave
        btnClose.BackgroundImage = My.Resources.Resources.closeForm2
    End Sub


#End Region

    '' ''#Region "Send Error"

    '' ''    Private _errorMsg As String = String.Empty
    '' ''    Public Sub SetError(ByVal errorStr As String)
    '' ''        _errorMsg = errorStr
    '' ''    End Sub

    '' ''    Private Sub btnSendError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendError.Click
    '' ''        Try
    '' ''            Dim f As New frmEmail(Me.Text, ErrorManager.ReadMessage())
    '' ''            f.ShowDialog()
    '' ''        Catch ex As Exception

    '' ''        End Try

    '' ''    End Sub

    '' ''#End Region


End Class