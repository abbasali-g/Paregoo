Imports Lawyer.Common.VB.LawyerError
Public Class GlobalForm2


#Region "- Property -"

    Public WriteOnly Property HideMinimize() As Boolean

        Set(ByVal value As Boolean)
            btnMinimize.Visible = Not value
        End Set
    End Property

#End Region

#Region "- Load -"

    Public _OrginalBounds As New Rectangle

    Private Sub GlobalForm2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _OrginalBounds = Me.Bounds
        Me.WindowState = FormWindowState.Normal
    End Sub

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
            Me.Location = mousePos

            If Me.Location.X > 0 AndAlso Me.Location.Y > 0 Then
                _OrginalBounds.Location = Me.Location
            End If


        End If

    End Sub

#End Region

#Region "- Window State -"

    Private Sub btnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMinimize_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.MouseHover
        btnMinimize.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.Minimize_
    End Sub

    Private Sub btnMinimize_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.MouseLeave
        btnMinimize.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.Minimize
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClose_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.MouseHover
        btnClose.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.closeForm2_
    End Sub

    Private Sub btnClose_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.MouseLeave
        btnClose.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.closeForm2
    End Sub



    'Dim IsMaxSize As Boolean = False
    Private Sub btnMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax.Click

        If Me.Bounds = _OrginalBounds Then

            Dim _Size As New Size(0.95 * My.Computer.Screen.Bounds.Width, 0.95 * My.Computer.Screen.Bounds.Height)
            Dim _Point As New Point(0.05 * My.Computer.Screen.Bounds.Width / 2, 0.05 * My.Computer.Screen.Bounds.Height / 2)
            Dim _MaxBounds As New Rectangle(_Point, _Size)

            Me.Bounds = _MaxBounds
        Else
            Me.Bounds = _OrginalBounds
        End If


        'If IsMaxSize Then
        '    Me.WindowState = FormWindowState.Normal
        '    IsMaxSize = False
        'Else
        '    Me.WindowState = FormWindowState.Maximized
        '    IsMaxSize = True
        'End If

    End Sub

    Private Sub btnMax_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax.MouseHover
        btnMax.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.ResizeIcon_
    End Sub

    Private Sub btnMax_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax.MouseLeave
        btnMax.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.ResizeIcon
    End Sub

#End Region

#Region "Send Error"

    Private _errorMsg As String = String.Empty
    Public Sub SetError(ByVal errorStr As String)
        _errorMsg = errorStr
    End Sub

    Private Sub btnSendError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim f As New frmEmail(Me.Text, ErrorManager.ReadMessage())
        'f.ShowDialog()
    End Sub

#End Region

End Class