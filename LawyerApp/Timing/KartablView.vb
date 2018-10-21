Imports Lawyer.Common.VB.Timing
Imports Lawyer.Common.VB.LawyerError

Public Class KartablView

#Region "Variable"

    Dim timeParties As String

    Dim timeId As String

#End Region

#Region "Events"

    Private Sub KartablView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ToolTip1.SetToolTip(picForward, "ارسال به دیگری")

        ToolTip1.SetToolTip(picReply, "ارسال پاسخ")

        ToolTip1.SetToolTip(btnDel, "حذف پیام")

        lblMessage.Text = String.Empty

    End Sub

    Private Sub picReply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picReply.Click

        Try

            ''Dim f As New TimingAdd()

            'f.Show()

            'f.Reply(timeParties)

        Catch ex As Exception

            lblMessage.Text = "خطا در ارسال پاسخ"
            ErrorManager.WriteMessage("picReply_Click", ex.ToString(), Me.Text)
        End Try

    End Sub

    Private Sub pnlForward_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picForward.Click

        Try

            'Dim f As New TimingAdd()

            'f.Show()

            'f.Forward(timeParties)

        Catch ex As Exception

            lblMessage.Text = "خطا در ارسال"
            ErrorManager.WriteMessage("pnlForward_DoubleClick", ex.ToString(), Me.Text)
        End Try

    End Sub

    Public Sub New(ByVal timePartieId As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Try
            Me.timeParties = timePartieId

            If Not KartablView1.Bind(timePartieId) Then

                Throw New Exception

            End If

            timeId = KartablView1.IsDeletable()

            If timeId = String.Empty Then btnDel.Visible = False

        Catch ex As Exception

            lblMessage.Text = "محتوای پیام قابل نمایش نیست"

            btnDel.Visible = False
            ErrorManager.WriteMessage("New,timePartieId", ex.ToString(), Me.Text)
        End Try

    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

        Dim f As New dadMessageBox("در صورت تایید ، این پیام از لیست تمامی دریافت کننده ها حذف خواهد شد. آیا مایل به حذف هستید؟", "حذف پیام")

        If f.ShowMessage() = Windows.Forms.DialogResult.Yes Then

            If TimingManager.DeleteTiming(timeId) Then

                Me.Close()

            Else

                lblMessage.Text = "خطا در حذف پیام"

            End If

        End If
      

    End Sub

#End Region

    'Private Sub KartablView1_ShowDocContent(ByVal filePath As String) Handles KartablView1.ShowDocContent
    '    Try

    '        Dim f As New OpenDoc()

    '        f.Show()

    '        f.OpenDoc(filePath)

    '    Catch ex As Exception
    '        ErrorManager.WriteMessage("KartablView1_ShowDocContent", ex.ToString(), Me.Text)
    '    End Try
    'End Sub
End Class