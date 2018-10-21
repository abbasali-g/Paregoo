Public Class GlobalForm3


#Region "Variable"

    Public mouse_offset As Point
    Public OriginalSize As Point

#End Region

#Region "Events"

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

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


End Class