Public Class BraowsDocs

    Private Sub DocList1_ConfirmDelete(ByVal myItems As System.Windows.Forms.ListView.SelectedListViewItemCollection) Handles DocList1.ConfirmDelete

        Dim f As New dadMessageBox("آیا برای حذف مطمئن هستید ؟", "حذف فایل")

        If f.ShowMessage() = Windows.Forms.DialogResult.Yes Then

            DocList1.Delete(myItems)

            
        End If

    End Sub
    Private Sub DocList1_ConfirmDeleteDrag(ByVal myItems() As System.Windows.Forms.ListViewItem) Handles DocList1.ConfirmDeleteDrag

        Dim f As New dadMessageBox("آیا برای حذف مطمئن هستید ؟", "حذف فایل")

        If f.ShowMessage() = Windows.Forms.DialogResult.Yes Then

            DocList1.Delete(myItems)

        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'UcShamsiDate1.showShamsiDate()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public WriteOnly Property SearchString() As String

        Set(ByVal value As String)
            DocList1.Search(value)
        End Set
    End Property

    Private Sub BraowsDocs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ToolTip1.SetToolTip(btnMyComputer, "My Computer")

    End Sub

    Private Sub btnMyComputer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyComputer.Click

        Try

            '' ''Dim startInfo As New ProcessStartInfo("explorer.exe")

            '' ''startInfo.WindowStyle = ProcessWindowStyle.Normal

            ' '' ''startInfo.Arguments = "My Computer"

            '' ''Process.Start(startInfo)

            Dim f As New frmWinExplorer()
            f.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DocList1_ShowDocContent(ByVal ID As String, ByVal filePath As String, ByVal TableName As String, ByVal fileName As String) Handles DocList1.ShowDocContent
        Try

            ''Dim f As New OpenDoc(filePath, ID, TableName, fileName)
            ''f.ShowDialog()

            Lawyer.Common.VB.Common.FileManager.executeWordFile(ID, filePath, fileName, TableName)


        Catch ex As Exception

        End Try
    End Sub
End Class