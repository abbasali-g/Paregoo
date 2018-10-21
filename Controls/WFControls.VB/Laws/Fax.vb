Imports Lawyer.Common.VB.Laws
Imports System.IO

Public Class Fax


    Private _Clear As Boolean
    Public Property Clear() As Boolean
        Get
            Return _Clear
        End Get
        Set(ByVal value As Boolean)
            _Clear = value
            Me.txtToNumber.Text = String.Empty
            Me.txtDisplayName.Text = String.Empty
            Me.rtbContent.Text = String.Empty
        End Set
    End Property



    Private _DisplayName As String
    Public Property DisplayName() As String
        Get
            Return _DisplayName
        End Get
        Set(ByVal value As String)
            _DisplayName = value
            Me.txtDisplayName.Text = value
        End Set
    End Property



    Private _Content As String
    Public Property Content() As String
        Get
            Return _Content
        End Get
        Set(ByVal value As String)
            _Content = value
            Me.rtbContent.Text = value
        End Set
    End Property


    Dim ToStr As String = String.Empty


    Private Sub Email_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lvUsers.CheckBoxes = True
        Me.lvUsers.View = View.List
        Me.lvUsers.FullRowSelect = True
        Me.lvUsers.GridLines = True
        Me.lvUsers.Sorting = SortOrder.Ascending
        'Me.lvUsers.Columns.Add("دستگاههای اجرایی", -2, HorizontalAlignment.Left)

        FillListView(String.Empty)


    End Sub

    Sub FillListView(ByVal FullName As String)


        Dim cec As New CustEmail_FaxCollection

        If FullName = String.Empty Then
            cec = CustEmail_FaxManager.GetCustFaxs()
        Else
            cec = CustEmail_FaxManager.GetCustFaxs(Me.txtSearchUser.Text)
        End If

        For i = 0 To cec.Count - 1
            Dim Item As New ListViewItem(cec.Item(i).custFullName)
            Item.SubItems.Add(cec.Item(i).custFax)
            Me.lvUsers.Items.Add(Item)
        Next

    End Sub


    Private Sub lvUsers_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvUsers.ItemCheck

        If (e.NewValue = CheckState.Checked) Then  'CBool(e.NewValue)

            For i As Integer = 0 To Me.lvUsers.Items.Count - 1
                If Me.lvUsers.Items(i).Index <> e.Index Then
                    Me.lvUsers.Items(i).Checked = False
                End If
            Next

            Me.txtToNumber.Text = Me.lvUsers.Items(e.Index).SubItems(1).Text

        End If


    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click

        Dim Fax As New Lawyer.Common.VB.Laws.Fax

        Fax.FaxNumber = Me.txtToNumber.Text
        Fax.RecipientName = String.Empty
        Fax.DisplayName = txtDisplayName.Text
        Fax.Text = Me.rtbContent.Text

        Fax.SendFax(Fax)

        If Fax.HasError Then
            Throw New Exception(Fax.Exception.Message, Fax.Exception)
        End If

        Me.lvUsers.Clear()
        FillListView(String.Empty)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Visible = False

        Me.txtToNumber.Text = String.Empty
        Me.txtDisplayName.Text = String.Empty
        Me.rtbContent.Text = String.Empty

        Me.lvUsers.Clear()
        FillListView(String.Empty)

    End Sub

    Private Sub txtSearchUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchUser.TextChanged

        Me.lvUsers.Clear()
        FillListView(Me.txtSearchUser.Text)

    End Sub
End Class
