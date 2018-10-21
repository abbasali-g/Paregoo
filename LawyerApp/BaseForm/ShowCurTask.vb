Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Timing
Imports Lawyer.Common.VB.CommonSetting

Public Class ShowCurTask



    'Private Sub ShowCurTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    '    Try
    '        Dim str As String = String.Empty

    '        Dim a As ArrayList = TimingManager.TimingSearch()

    '        If a IsNot Nothing Then


    '            For index As Integer = 0 To a.Count - 1

    '                str &= vbCrLf & index + 1 & "- " & a.Item(0)
    '            Next

    '        End If


    '        txtContent.Text = str




    '    Catch ex As Exception

    '        ErrorManager.WriteMessage("ShowCurTask_Load", ex.ToString(), Me.Text)

    '    End Try

    'End Sub

    Public Function IsHasContent()

        '    Try
        '        Dim str As String = String.Empty

        '        Dim a As ArrayList = TimingManager.TimingSearch()

        '        If a IsNot Nothing Then


        '            For index As Integer = 0 To a.Count - 1

        '                str &= vbCrLf & index + 1 & "- " & a.Item(0)
        '            Next

        '        End If


        '        txtContent.Text = str


        '        If a Is Nothing OrElse a.Count = 0 Then

        '            Return False

        '        End If


        '        Return True

        '    Catch ex As Exception

        '        ErrorManager.WriteMessage("IsHasContent", ex.ToString(), Me.Text)

        '        Return False

        '    End Try


    End Function

 
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Me.Hide()

    End Sub
End Class