Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Setting

Public Class frmEmail

#Region " Property "



    Private _ESubject As String
    Public Property ESubject() As String
        Get
            Return _ESubject
        End Get
        Set(ByVal value As String)
            _ESubject = value
            Me.UcEmail1.Subject = value
        End Set
    End Property



    Private _EBody As String
    Public Property EBody() As String
        Get
            Return _EBody
        End Get
        Set(ByVal value As String)
            _EBody = value
            Me.UcEmail1.Content = value
        End Set
    End Property



    Private _EAttachment As String
    Public Property EAttachment() As String
        Get
            Return _EAttachment
        End Get
        Set(ByVal value As String)
            _EAttachment = value
            Me.UcEmail1.AttachmentFilePath = value
        End Set
    End Property


#End Region

#Region "- New -"

    Public Sub New(ByVal ESubject As String, ByVal EBody As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.UcEmail1.Subject = ESubject
        Me.UcEmail1.Content = EBody

        '-------------------------------------

        Dim SettingCollection As New SettingCollection
        SettingCollection = SettingManager.GetSettingsByName("nwdicEmail")

        Dim str As String = String.Empty
        For i As Integer = 0 To SettingCollection.Count - 1
            If SettingCollection(i).settingName = "Email" Then
                str = SettingCollection(i).settingValue
                Exit For
            End If
        Next

        If String.IsNullOrEmpty(str) Then
            ' Me.UcEmail1.lblMessag.Text = "تنظیمات ارسال ایمیل پیدا نشد"
            Exit Sub
        End If

        'Dim SetMail() As String = Str.Split(":")
        'If SetMail.Length <> 2 Then
        '    '    Me.lblMessage.Text = "فایل تنظیمات دارای فرمت صحیح نمی باشد"
        '    Exit Sub
        'End If

        Me.UcEmail1.To_Nwdic = str

        'Me.UcEmail1.IsReadonlyFrom=True 
        '******************** nahani


    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

#End Region

#Region " Load "



    Private Sub frmEmail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.UcEmail1.From_Email = CurrentLogin.CurrentUser.Mail '"" '
        Me.UcEmail1.DisplayName = CurrentLogin.CurrentUser.Name ' "امين سرند حسن" '

        Me.ToolTip1.SetToolTip(btnContacts, "لیست افراد")
        Me.ToolTip1.SetToolTip(Me.btnSetting, "تنظیمات ایمیل")

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


    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetting.Click

        If CommonSettingManager.frmMaileSetting IsNot Nothing Then
            CommonSettingManager.frmMaileSetting.Close()
        End If

        Dim _MailSetting As New MailSetting
        CommonSettingManager.frmMaileSetting = _MailSetting
        _MailSetting.Show(Me)

    End Sub

#End Region

   
  
  
 
End Class