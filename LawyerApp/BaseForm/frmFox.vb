Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.CommonSetting


Public Class frmFox

#Region " Property "


    Private _frmFileName As String
    Public Property frmFileName() As String
        Get
            Return _frmFileName
        End Get
        Set(ByVal value As String)
            _frmFileName = value
            Me.UcFax1.FileName = value
        End Set
    End Property


    Private _frmTextRich As String
    Public Property frmTextRich() As String
        Get
            Return _frmFileName
        End Get
        Set(ByVal value As String)
            _frmTextRich = value
            Me.UcFax1.TextRich = value
        End Set
    End Property




#End Region

#Region " Load "

    Private Sub frmFox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.UcFax1.DisplayName = CurrentLogin.CurrentUser.Name


        Me.ToolTip1.SetToolTip(Me.btnContacts, "لیست افراد")




    End Sub

#End Region

#Region " Command "

    Private Sub btnContacts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContacts.Click

        If CommonSettingManager.SetContactSearch IsNot Nothing Then
            CommonSettingManager.SetContactSearch.Close()
        End If

        Dim ContactSearch As New ContactSearch
        CommonSettingManager.SetContactSearch = ContactSearch
        ContactSearch.Show()

        ContactSearch.Location = New Point(Me.Location.X + Me.Width - ContactSearch.Size.Width - 20, Me.Location.Y + 100)

    End Sub

#End Region


    
End Class