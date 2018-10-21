Imports Lawyer.Common.VB.Laws
Imports System.Text
Imports System.Threading
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.Setting

Public Class ucEmail

#Region "Property"

    Private _From_Email As String
    Public Property From_Email() As String
        Get
            Return _From_Email
        End Get
        Set(ByVal value As String)
            _From_Email = value
        End Set
    End Property

    Private _DisplayName As String
    Public Property DisplayName() As String
        Get
            Return _DisplayName
        End Get
        Set(ByVal value As String)
            _DisplayName = value
        End Set
    End Property


    Private _Subject As String
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
            Me.txtSubject.Text = value
        End Set
    End Property

    Private _Content As String
    Public Property Content() As String
        Get
            Return _Content
        End Get
        Set(ByVal value As String)
            _Content = value
            RichTextBoxEx1.TextRich = value
        End Set
    End Property

    Private _AttachmentFilePath As String
    Public Property AttachmentFilePath() As String
        Get
            Return _AttachmentFilePath
        End Get
        Set(ByVal value As String)
            _AttachmentFilePath = value

            If Not String.IsNullOrEmpty(_AttachmentFilePath) Then
                Me.lbFiles.Items.Add(_AttachmentFilePath)
            End If

        End Set
    End Property



    Private _To_Email As String
    Public Property To_Email() As String
        Get
            Return _To_Email
        End Get
        Set(ByVal value As String)
            _To_Email = value
            Me.txtTo.Text = value
            'Me.txtTo.ReadOnly = True
        End Set
    End Property

    '********************* nahani
    Private _To_Nwdic As String
    Public Property To_Nwdic() As String
        Get
            Return _To_Nwdic
        End Get
        Set(ByVal value As String)
            _To_Nwdic = value
            Me.txtTo.Text = "واحد پشتیبانی"
            Me.txtTo.ReadOnly = True
            Me.txtTo.RightToLeft = Windows.Forms.RightToLeft.Yes
        End Set
    End Property

    Private _Clear As Boolean
    Public Property Clear() As Boolean
        Get
            Return _Clear
        End Get
        Set(ByVal value As Boolean)
            _Clear = value
            Me.txtTo.Text = String.Empty
            Me.txtSubject.Text = String.Empty
            '''''Me.rtb.TextRich = String.Empty
            RichTextBoxEx1.TextRich = String.Empty
            Me.lbFiles.Items.Clear()
        End Set
    End Property


    ''******** Nahani
    'Public WriteOnly Property IsReadonlyFrom() As Boolean

    '    Set(ByVal value As Boolean)
    '        txtTo.ReadOnly = value
    '    End Set
    'End Property


#End Region

#Region "Event"

    Public Event UC_EmailSended(ByVal sender As Object, ByVal e As String)

#End Region

#Region " Load "

    Dim ToStr As String = String.Empty

    WithEvents Email As Lawyer.Common.VB.Laws.Email ' in this case email added top left dropdown with event
    ' Email = New Lawyer.Common.VB.Laws.Email

    Private Sub Email_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ToolTip1.SetToolTip(llFile, "فایل ضمیمه")

        Email = New Lawyer.Common.VB.Laws.Email
        'AddHandler Email.EmailSended, AddressOf Email_EmailSended


        Me.txtTo.AllowDrop = True
        RichTextBoxEx1.RReadOnly = False
        Me.lblMessage.Text = String.Empty
        Me.btnShowAttach.Image = Global.WFControls.VB.My.Resources.Resources.Close

        'Me.lvUsers.CheckBoxes = True
        'Me.lvUsers.View = View.List
        'Me.lvUsers.FullRowSelect = True
        'Me.lvUsers.GridLines = True
        'Me.lvUsers.Sorting = SortOrder.Ascending
        ''Me.lvUsers.Columns.Add("دستگاههای اجرایی", -2, HorizontalAlignment.Left)
        'FillListView(String.Empty)

      

    End Sub

#End Region

#Region " Drag in User "

    Private DicKhande As New Dictionary(Of String, String)

    Private Sub txtTo_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTo.DragDrop


        Try

            ' Dim myData As New ArrayList  
            ' row string and  ListViewItem
            ' sender.DoDragDrop(New DataObject("ArrayList", myData), DragDropEffects.Copy)
            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then
                Dim contact() As ListViewItem = data.Item(1)


                Dim _Where As String = String.Empty
                For Each item As ListViewItem In contact

                    'If Not DicKhande.Keys.Contains(item.SubItems(1).Text) Then
                    '    DicKhande.Add(item.SubItems(1).Text, item.Text)
                    '    If txtTo.Text <> String.Empty Then txtTo.Text += ","
                    '    txtTo.Text += item.Text
                    'End If

                    If _Where <> String.Empty Then _Where += " OR "
                    _Where += " custid='" + item.SubItems(1).Text + "' "
                Next

                _Where = " Where " + _Where



                Dim CustEmail_FaxCollection As New CustEmail_FaxCollection
                CustEmail_FaxCollection = CustEmail_FaxManager.GetCustEmailsByCustIDs(_Where)


                Dim ToStr As String = String.Empty
                For i = 0 To CustEmail_FaxCollection.Count - 1
                    If Not String.IsNullOrEmpty(CustEmail_FaxCollection.Item(i).custEmailOne) Then
                        ToStr += CustEmail_FaxCollection.Item(i).custEmailOne + ","
                    End If
                   
                Next
                If Not String.IsNullOrEmpty(ToStr) Then
                    ToStr = Mid(ToStr, 1, ToStr.Length - 1)
                End If

                If Not String.IsNullOrEmpty(Me.txtTo.Text) Then
                    Me.txtTo.Text += "," + ToStr
                Else
                    Me.txtTo.Text = ToStr
                End If


            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در درگ"
        End Try

    End Sub

    Private Sub txtTo_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtTo.DragEnter

        If e.Data.GetDataPresent("ArrayList") Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

#End Region

#Region " Attachment "

    Private Sub llFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles llFile.Click
        If Me.ofdLoad.ShowDialog(Me) = DialogResult.OK AndAlso Not String.IsNullOrEmpty((Me.ofdLoad.FileName)) Then

            Me.lbFiles.Items.Add(Me.ofdLoad.FileName)

        End If

    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

        If Me.lbFiles.SelectedItem IsNot Nothing Then

            Me.lbFiles.Items.Remove(Me.lbFiles.SelectedItem)

        End If

    End Sub

#End Region

#Region " Command Button "

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click

        Dim workerThread As New Thread(AddressOf SendMail)
        workerThread.Start()

        ' SendMail()

    End Sub

    Sub SendMail()

        Try

            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> read from setting File

            'Dim ActiveNo As String = Lawyer.Coding.HsPublic.ReadTextFile(1, FileManager.GetMailSettingFilePath) 'App_Path() + "\MailSetting.txt"

            'If ActiveNo Is String.Empty Then
            '    Me.lblMessage.Text = "تنظیمات ارسال ایمیل یافت نشد"
            '    Exit Sub
            'End If

            '------------------------------- Determine Active Server

            'Dim No As Integer
            'Try
            '    No = CInt(ActiveNo)
            'Catch ex As Exception
            '    Me.lblMessage.Text = "فایل تنظیمات دارای فرمت صحیح نمی باشد"
            '    Exit Sub
            'End Try
          

            'Dim str As String

            'Select Case No
            ' Case Enums.Server.Other, Enums.Server.Gmail ', Enums.Server.Yahoo
            'str = Lawyer.Coding.HsPublic.ReadTextFile(No, FileManager.GetMailSettingFilePath) 'App_Path() + "\MailSetting.txt"
            'If No = Enums.Server.Gmail Then 'Or No = Enums.Server.Yahoo
            'Email.EnableSsl = True
            'End If

            ' Case Else
            ' Me.lblMessage.Text = "فایل تنظیمات دارای فرمت صحیح نمی باشد"
            ' Exit Sub
            ' End Select


            ' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            lblMessage.Text = "در حال ارسال ..."

            Dim str As String = MailSettingManager.GetActiveMail()

            If String.IsNullOrEmpty(str) Then

                Dim SettingCollection As New SettingCollection
                SettingCollection = MailSettingManager.GetEmailSetting()
                ' SettingCollection = SettingManager.GetSettingsByName("Traffic")

                For i As Integer = 0 To SettingCollection.Count - 1
                    If SettingCollection(i).settingValue = 1 Then
                        str = SettingCollection(i).settingName
                        Exit For
                    End If
                Next

            End If

            If String.IsNullOrEmpty(str) Then

                Me.lblMessage.Text = "تنظیمات ارسال ایمیل پیدا نشد"
                Exit Sub

            End If


            If str.Contains("smtp.gmail.com") Then
                Email.EnableSsl = True
            End If

            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            '------------------------------------
            Dim SetMail() As String = str.Split(":")
            If SetMail.Length <> 4 Then
                Me.lblMessage.Text = "فایل تنظیمات دارای فرمت صحیح نمی باشد"
                Exit Sub
            End If

            For i As Integer = 0 To SetMail.Length - 1

                If SetMail(i) = String.Empty Then
                    Me.lblMessage.Text = "یکی از تنظیمات ایمیل خالی است تنظیمات ایمیل را بررسی نمایید"
                    Exit Sub
                End If
            Next



            'Dim str1 As String = Lawyer.Coding.HsPublic.EncryptText("sasapass")
            'Dim str0 As String = Lawyer.Coding.HsPublic.DecryptText("Gc1ElTLeKAZe0c4qq6vp+g==")


            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Set Object Email

            '---------------------- seting from Out side
            Email.From_Email = _From_Email
            Email.DisplayName = _DisplayName
            '----------------------

            Email.SmtpClient = SetMail(0) ' "mail.nwdic.com" ' '89.238.162.71:25
            Email.Port = SetMail(1)

            Email.NetworkCredential_Pass = Lawyer.Coding.HsPublic.DecryptText(SetMail(2)) '"password"
            Email.NetworkCredential_Mail = SetMail(3) '"support@nwdic.com"


            If txtTo.ReadOnly Then
                Email.To_Email = Me.To_Nwdic ' "info@nwdic.com" '"abbasali_g@yahoo.com" '

            Else
                Email.To_Email = Me.txtTo.Text ' "info@nwdic.com" '"abbasali_g@yahoo.com" '

            End If

            Email.Subject = Me.txtSubject.Text '"sarandy با پیوست"
            Email.Body = RichTextBoxEx1.TextRich   '"سلام خوبی" ' Email.Body = Me.rtbContent.Text

            '------------------------------


            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Attachment

            If Me.lbFiles.Items.Count > 0 Then


                Try

                    Dim zip As New Ionic.Zip.ZipFile

                    'If Not String.IsNullOrEmpty(_AttachmentFilePath) Then
                    'zip.AddFile(_AttachmentFilePath, "") 'create in root      zip.AddFile("filePath", "fileRealName")    'zip.AddDirectory("My Pictures", true); // AddDirectory recurses subdirectories
                    ' End If

                    For i As Integer = 0 To Me.lbFiles.Items.Count - 1
                        zip.AddFile(Me.lbFiles.Items(i).ToString, "")
                    Next

                    zip.Save(FileManager.GetAttachmentZipFilePath) '"Attachment.zip"
                    _AttachmentFilePath = FileManager.GetAttachmentZipFilePath ' App_Path() + "\Attachment.zip"

                Catch ex As Exception
                    Me.lblMessage.Text = "خطا در ارسال پیوستها"
                    _AttachmentFilePath = String.Empty
                End Try

                Email.AttachmentFilePath = _AttachmentFilePath ' "D:\share\ddd.zip" 

            End If

            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> End Attachment

            Email.SendEmail(Email)

            If Email.HasError Then
                Dim ex As Exception = Email.Exception
                'While ex.InnerException IsNot Nothing
                '    ex = ex.InnerException
                'End While
                Me.lblMessage.Text = " خطا در ارسال ایمیل " + ex.Message
            Else
                Me.lblMessage.Text = "ایمیل ارسال شد"

                '**********8nahani
                Try
                    If txtTo.ReadOnly Then
                        'پاک کردن فایل log

                        Lawyer.Common.VB.LawyerError.ErrorManager.ClearFile()

                    End If

                Catch ex As Exception

                End Try

            End If

            'Me.lvUsers.Clear()
            'FillListView(String.Empty)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ارسال ایمیل"
        End Try


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Clear = True
        Me.ParentForm.Close()

        'Me.lvUsers.Clear()
        'FillListView(String.Empty)

    End Sub

    Private Sub btnShowAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAttach.Click

        ToggleRow(1, Me.btnShowAttach)

    End Sub

    Sub ToggleRow(ByVal RowNo As Integer, ByRef btn As Button)


        For Each ctl As Control In tlpUsers.Controls
            If tlpUsers.GetRow(ctl) = RowNo Then
                ctl.Visible = Not ctl.Visible

                If ctl.Visible Then
                    btn.Image = Global.WFControls.VB.My.Resources.Resources.Close
                Else
                    btn.Image = Global.WFControls.VB.My.Resources.Resources.Open
                End If

            End If

        Next

    End Sub

#End Region


    Private Sub Email_EmailSended(ByVal sender As Object, ByVal e As String) Handles Email.EmailSended

        RaiseEvent UC_EmailSended(Me, "ok")

    End Sub

#Region " Unused Select User "

    'Sub FillListView(ByVal FullName As String)

    '    Try

    '        Dim CustEmail_FaxCollection As New CustEmail_FaxCollection

    '        If FullName = String.Empty Then
    '            CustEmail_FaxCollection = CustEmail_FaxManager.GetCustEmails()
    '        Else
    '            CustEmail_FaxCollection = CustEmail_FaxManager.GetCustEmails(Me.txtSearchUser.Text)
    '        End If

    '        For i = 0 To CustEmail_FaxCollection.Count - 1
    '            Dim Item As New ListViewItem(CustEmail_FaxCollection.Item(i).custFullName)
    '            Item.SubItems.Add(CustEmail_FaxCollection.Item(i).custEmailOne)
    '            Item.SubItems.Add(CustEmail_FaxCollection.Item(i).custEmailTwo)
    '            Me.lvUsers.Items.Add(Item)
    '        Next

    '    Catch ex As Exception
    '        Me.lblMessage.Text = "خطا در خواندن اسامی کاربران"
    '    End Try


    'End Sub


    'Private Sub lvUsers_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)

    '    If (e.NewValue = CheckState.Checked) Then  'CBool(e.NewValue)

    '        If Me.lvUsers.Items(e.Index).SubItems(1).Text <> String.Empty Then
    '            ToStr = ToStr.Insert(ToStr.Length, Me.lvUsers.Items(e.Index).SubItems(1).Text + ",")
    '        End If

    '        If Me.lvUsers.Items(e.Index).SubItems(2).Text <> String.Empty Then
    '            ToStr = ToStr.Insert(ToStr.Length, Me.lvUsers.Items(e.Index).SubItems(2).Text + ",")
    '        End If

    '    Else

    '        If Me.lvUsers.Items(e.Index).SubItems(1).Text <> String.Empty Then
    '            ToStr = ToStr.Replace(Me.lvUsers.Items(e.Index).SubItems(1).Text + ",", String.Empty)
    '        End If

    '        If Me.lvUsers.Items(e.Index).SubItems(2).Text <> String.Empty Then
    '            ToStr = ToStr.Replace(Me.lvUsers.Items(e.Index).SubItems(2).Text + ",", String.Empty)
    '        End If

    '    End If

    '    Me.txtTo.Text = ToStr


    'End Sub

    'Private Sub txtSearchUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Me.lvUsers.Clear()
    '    FillListView(Me.txtSearchUser.Text)


    'End Sub


    'Private Sub btnShowUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    ToggleRow(1, Me.btnShowUser)

    'End Sub

#End Region


    
  
End Class
