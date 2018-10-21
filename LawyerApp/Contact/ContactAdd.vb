Public Class ContactAdd
    Private ContactId As String

    Private Sub ContactAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ToolTip1.SetToolTip(btnMyComputer, "My Computer")

        If Me.ContactId <> String.Empty Then

            ContactAdd1.Bind(ContactId)

        End If



    End Sub

    Public Sub New(ByVal ContactId As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.ContactId = ContactId

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnMyComputer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyComputer.Click

        Try

            Dim f As New frmWinExplorer()
            f.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ContactAdd1_ShowMessageBox(ByVal text As String, ByVal title As String) Handles ContactAdd1.ShowMessageBox

        Dim f As New dadMessageBox(text, title)

        If f.ShowMessage = Windows.Forms.DialogResult.Yes Then

            ContactAdd1.YesClicked = True

        Else
            ContactAdd1.YesClicked = False

        End If

    End Sub

    Private Sub ContactAdd1_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactAdd1.SizeChanged
        Me.Height = ContactAdd1.Height + pnlTitle.Height + 30
    End Sub

   

End Class