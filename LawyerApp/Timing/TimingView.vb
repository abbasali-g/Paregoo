Imports Lawyer.Common.VB.Timing
Imports Lawyer.Common.VB.LawyerError

Public Class TimingView


    Dim timeParties As String

    Dim timeId As String

#Region "Initial"

    Public Sub New(ByVal tpId As String)

        Try

            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            NewTimingAdd1.EditReminder(tpId)

            timeParties = tpId

        Catch ex As Exception

            ErrorManager.WriteMessage("New,1param", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub KartablView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ToolTip1.SetToolTip(picForward, "ارسال به دیگری")

        ToolTip1.SetToolTip(picReply, "ارسال پاسخ")

    End Sub

    Private Sub pnlForward_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picForward.Click

        Try

            Dim f As New frmNewTimingAdd()

            f.Show()

            f.Forward(timeParties)

        Catch ex As Exception

            ErrorManager.WriteMessage("pnlForward_DoubleClick", ex.ToString(), Me.Text)

        End Try

    End Sub

    Private Sub picReply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picReply.Click

        Try

            Dim f As New frmNewTimingAdd()

            f.Show()

            f.Reply(timeParties)

        Catch ex As Exception

            ErrorManager.WriteMessage("picReply_Click", ex.ToString(), Me.Text)

        End Try

    End Sub

#End Region

#Region "NewTimingAdd"

    Private Sub TimingAdd1_ShowConfirm(ByVal text As String, ByVal title As String) Handles NewTimingAdd1.ShowConfirm

        Dim f As New dadMessageBox(text, title)

        If f.ShowMessage = Windows.Forms.DialogResult.Yes Then

            NewTimingAdd1.YesClicked = True

        Else

            NewTimingAdd1.YesClicked = False

        End If


    End Sub

    Private Sub NewTimingAdd1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewTimingAdd1.SizeChanged

        Me.Size = New Size(Me.Width, NewTimingAdd1.Height + 50)

        pnlMenu.Height = NewTimingAdd1.Height

    End Sub

    Private Sub NewTimingAdd1_ShowDocContent(ByVal filePath As String, ByVal fileName As String) Handles NewTimingAdd1.ShowDocContent

        ''Dim f As New OpenDoc(filePath, fileName)

        ''f.ShowDialog()
        Lawyer.Common.VB.Common.FileManager.executeWordFile(System.IO.Path.GetFileNameWithoutExtension(filePath), filePath, fileName, "deskdocs")

    End Sub

#End Region



End Class