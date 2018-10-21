Imports Lawyer.Common.VB.ContactInfo
Imports Lawyer.Common.VB.BaseUserControl.ListView
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.CommonSetting

Public Class UCContactSearch

#Region "Variable"

    Dim defaulImageKey As String = "0"

    Delegate Sub ShowNewFormHandler()
    Event ShowNewForm As ShowNewFormHandler

    Delegate Sub ShowForm(ByVal ID As String, ByVal IsMessage As Boolean)
    Event ShowEditForm As ShowForm

    Delegate Sub _showSmsFormHandler(ByVal fileCaseID As String, ByVal timeID As String, ByVal dt As DataTable, ByVal smsText As String)
    Event _showSmsForm As _showSmsFormHandler

    Delegate Sub BindNewCollection()
    Event DeleteMessage As BindNewCollection

    Private _roleType As String = "4" ' موکل
    Dim noDropCursor, copyCursor As Cursor

    Dim eventRun As Boolean = False

#End Region

#Region "Event"

    Private Sub txtFullName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFullName.KeyDown

        If e.KeyCode = Keys.Enter Then

            SearchContacts(DadMessages.Messages.FailSearch)

        End If

    End Sub

    Private Sub lvContacts_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvContacts.DoubleClick

        RaiseEvent ShowEditForm(lvContacts.SelectedItems(0).SubItems(3).Text, False)

    End Sub

    Private Sub lvContacts_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvContacts.ItemDrag

        Dim myData As New ArrayList
        myData = getSelectedContact()
        lvContacts.DoDragDrop(New DataObject("ArrayList", myData), DragDropEffects.Copy)

    End Sub

    Public Function getSelectedContact() As ArrayList
        Dim myData As New ArrayList
        Try
            If lvContacts.SelectedItems.Count > 0 Then

                Dim _Bitmap As New Bitmap(My.Resources.row_gray)

                noDropCursor = New Cursor(_Bitmap.GetHicon)

                Dim _Bitmap2 As New Bitmap(My.Resources.row_color)

                copyCursor = New Cursor(_Bitmap2.GetHicon)

                myData.Add("Contact")

                Dim i As Integer = 0

                Dim myItems(lvContacts.SelectedItems.Count - 1) As ListViewItem

                For Each myItem In lvContacts.SelectedItems

                    myItems(i) = myItem

                    i = i + 1

                Next

                myData.Add(myItems)

            End If

            Return myData

        Catch ex As Exception
            ErrorManager.WriteMessage("lvContacts_ItemDrag", ex.ToString(), Me.ParentForm.Text)
        End Try
    End Function

    Private Sub UCContactSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim types As Setting.SettingCollection

        Try
            txtFullName.Focus()
            types = ContactInfo.ContactInfoManager.GetAllContactType()

            If types IsNot Nothing AndAlso types.Count > 0 Then

                types.Add(New Setting.Setting("همه موارد", 10))

                cmbContactType.DisplayMember = "settingName"

                cmbContactType.ValueMember = "settingValue"

                cmbContactType.DataSource = types

                cmbContactType.SelectedValue = _roleType

            Else

                types = New Setting.SettingCollection

                types.Add(New Setting.Setting("همه موارد", 10))

                cmbContactType.SelectedValue = _roleType

            End If

        Catch ex As Exception
            ''''ErrorManager.WriteMessage("UCContactSearch_Load", ex.ToString())
        End Try



        Dim largeImage As New ImageList
        Dim smallImage As New ImageList

        largeImage.Images.Add("0", Global.WFControls.VB.My.Resources.Resources.NOPIC)

        largeImage.ImageSize = New Size(50, 50)

        smallImage.Images.Add("0", Global.WFControls.VB.My.Resources.Resources.NOPIC)

        smallImage.ImageSize = New Size(25, 25)


        lvContacts.LargeImageList = largeImage

        lvContacts.SmallImageList = smallImage


        eventRun = True

        RefreshContacts()



    End Sub

    Private Sub cmbContactType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbContactType.SelectedIndexChanged

        SearchContacts(DadMessages.Messages.FailSearch)

    End Sub

    Private Sub txtFullName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFullName.TextChanged

        SearchContacts(DadMessages.Messages.FailSearch)

    End Sub


#End Region

#Region "Utility"

    Private Sub lstviewDisplayItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstviewDisplayItems.SelectedIndexChanged
        lvContacts.View = lstviewDisplayItems.SelectedIndex
        SearchContacts(DadMessages.Messages.FailSearch)
    End Sub

    Dim listContacts As ContactSearchCollection
    Private Sub SearchContacts(ByVal msg As String)

        Dim listContacts As ContactSearchCollection
        Try

            If (Not eventRun) Then
                Return
            End If

            Dim Query As String = String.Empty

            If cmbContactType.SelectedValue = "10" Then
                Query = " where   contactinfo.custFullName    LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custCellphone  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custHomeTel  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custOfficeTel  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' "
            Else
                Query = " where contactinfo.custType=" & cmbContactType.SelectedValue & " and   ( contactinfo.custFullName    LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custCellphone  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custHomeTel  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custOfficeTel  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' )"
            End If


            ''If cmbContactType.SelectedValue <> "10" Then
            ''    Query = " where contactinfo.custType=" & cmbContactType.SelectedValue
            ''End If

            ''If txtFullName.Text.Trim() <> String.Empty Then

            ''    If Query <> String.Empty Then

            ''        Query &= " and contactinfo.custType=" & cmbContactType.SelectedValue & " and   contactinfo.custFullName    LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custCellphone  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custHomeTel  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custOfficeTel  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' "
            ''    Else
            ''        Query = " where contactinfo.custType=" & cmbContactType.SelectedValue & " and    contactinfo.custFullName    LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custCellphone  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custHomeTel  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' or custOfficeTel  LIKE '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtFullName.Text.Trim()) & "%' "

            ''    End If
            ''End If
            listContacts = ContactInfoManager.AdvanceSearchContactsByName(Query)


            lvContacts.Items.Clear()

            Dim lvItem As New ListViewItem
            Dim lvDetail As New ListViewItem

            lvItem.SubItems.Add("")
            lvItem.SubItems.Add("")
            lvItem.SubItems.Add("")

            If listContacts IsNot Nothing AndAlso listContacts.Count > 0 Then

                For Each Item As ContactSearch In listContacts

                    Dim imageKey As String = Item.custID

                    If Item.imageExtension = String.Empty Then

                        lvItem.ImageKey = defaulImageKey

                    Else

                        Try

                            Dim imageFullpath As String = Lawyer.Common.VB.Common.FileManager.GetContactPicturePath() & imageKey & Item.imageUpdateDate

                            imageFullpath &= Item.imageExtension

                            Dim imagelist As ImageList = lvContacts.LargeImageList

                            If Not imagelist.Images.ContainsKey(imageKey & Item.imageUpdateDate) Then

                                If Not System.IO.File.Exists(imageFullpath) Then

                                    BaseForm.ImageManager.WriteImage(imageKey, imageFullpath)

                                End If

                                imagelist.Images.Add(imageKey & Item.imageUpdateDate, Bitmap.FromFile(imageFullpath))

                            End If

                            lvItem.ImageKey = imageKey & Item.imageUpdateDate

                        Catch ex As Exception

                            lvItem.ImageKey = defaulImageKey

                        End Try

                    End If

                    lvItem.Text = Item.custFullName

                    'lvItem.SubItems(1).Text = Item.custCellphone
                    lvItem.SubItems(1).Text = Item.custID
                    lvItem.SubItems(2).Text = Item.custphone2
                    lvItem.SubItems(3).Text = Item.custID




                    lvItem.Font = New System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

                    lvItem.ToolTipText = CType(Item.custType, Enums.RoleType).ToString()

                    lvContacts.Items.Add(lvItem.Clone())

                Next

            End If

            '' ''lvContacts.Columns.Add("مشخصات", 200, HorizontalAlignment.Left)
            '' ''lvContacts.Columns.Add("شماره همراه", 100, HorizontalAlignment.Left)
            '' ''lvContacts.Columns.Add("شماره تلفن", 100, HorizontalAlignment.Left)
            'lvContacts.Items.AddRange(New ListViewItem() {lvDetail})
            'lvContacts.Sorting = SortOrder.Ascending


            'Add the items to the ListView.



            RaiseEvent DeleteMessage()

        Catch ex As Exception
            ErrorManager.WriteMessage("SearchContacts", ex.ToString(), Me.ParentForm.Text)
            RaiseEvent ShowEditForm(msg, True)

        End Try

    End Sub

    Private Sub lvContacts_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles lvContacts.GiveFeedback

        e.UseDefaultCursors = False

        Select Case e.Effect

            Case DragDropEffects.None

                Cursor.Current = noDropCursor

            Case DragDropEffects.Copy

                Cursor.Current = copyCursor

        End Select

    End Sub

#End Region

#Region "Methods"

    Public Sub RefreshContacts()

        SearchContacts("خطا در نمایش کاربران")

    End Sub

    Public WriteOnly Property RoleType() As Int16

        Set(ByVal value As Int16)
            _roleType = value.ToString
        End Set
    End Property

#End Region

    ''' <summary>
    ''' چاپ لیست اشخاص
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        printlist()
    End Sub
    Private Sub printlist()
        Try
            Dim contactType As String = ""

            If (cmbContactType.SelectedValue < 10) Then ' همه موارد
                contactType = " and custType=" + cmbContactType.SelectedValue + ""
            End If

            Dim query As String = "select settings.settingName as custUserName, contactinfo.*  from contactinfo join settings on custtype=settings.settingValue where settinggroupid='e3418d71-32b5-4075-9942-f268427cbf46' and settingvalue is not null " + contactType + " ; "

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
            Dim dt As DataTable = db.GetDataTableFromSqlCommandText("ContactInfo", query, Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim rf As New MyReports()
            Dim dir As String = CurDir()
            rf.ShowReport(dt, "VBDataSet_contactinfo", "WFControls.VB.rptContact.rdlc", Nothing)
            rf.Show()

        Catch ex As Exception


        End Try
    End Sub

#Region " حذف کاربر"
    Private Sub mnuDeleteUsers_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub deleteUsers(ByVal data As ArrayList)
        Try

            'Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim msgbox As New LawyerCommonControls.dadMessageBox(Lawyer.Common.VB.DadMessages.Messages.ConfirmDelete, "حذف کاربر")

                If msgbox.ShowMessage() = Windows.Forms.DialogResult.Yes Then

                    Dim contact() As ListViewItem = data.Item(1)

                    For Each Item As ListViewItem In contact

                        ''''یک کاربر درسیستم وجود دارد

                        Dim msg As String = ContactInfoManager.DelContactByID(Item.SubItems(1).Text)

                        If msg <> String.Empty Then

                            RefreshContacts()

                            MessageBox.Show(msg + " ( " + Item.Text + " )")

                            Exit Sub
                        End If



                    Next

                    RefreshContacts()

                End If

            End If

        Catch ex As Exception


            ErrorManager.WriteMessage("btnDelUser_DragDrop", ex.ToString(), Me.Text)
        End Try

    End Sub

#End Region


    Private Sub ctxMenuNewAddNewUser_Click(sender As Object, e As EventArgs) Handles ctxMenuNewAddNewUser.Click
        RaiseEvent ShowNewForm()
    End Sub

    Private Sub ctxMenuDeleteSelectedUsers_Click(sender As Object, e As EventArgs) Handles ctxMenuDeleteSelectedUsers.Click
        deleteUsers(getSelectedContact())
    End Sub

    Private Sub ctxMenuPrintList_Click(sender As Object, e As EventArgs) Handles ctxMenuPrintList.Click
        printlist()
    End Sub

    Private Sub ctxMenuSmsSendToList_Click(sender As Object, e As EventArgs) Handles ctxMenuSmsSendToList.Click
        Try
            Dim contactType As String = ""

            If (cmbContactType.SelectedValue < 10) Then ' همه موارد
                contactType = " and custType=" + cmbContactType.SelectedValue + ""
            End If

            Dim query As String = "select settings.settingName as custUserName, contactinfo.custFullname as receiverName, contactinfo.custcellphone as receiverNumber,'' as fileCaseID,'' as timeID,'ارسال گروهی' as smsSubject  from contactinfo join settings on custtype=settings.settingValue where settinggroupid='e3418d71-32b5-4075-9942-f268427cbf46' and contactinfo.custcellphone is not null and settingvalue is not null " + contactType + " ; "

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
            Dim dt As DataTable = db.GetDataTableFromSqlCommandText("ContactInfo", query, Nothing)

            If db.HasError Then Throw db.ErrorException

            If Lawyer.Common.VB.SmsManager.getSmsConfig() = True Then
                RaiseEvent _showSmsForm(Nothing, Nothing, dt, Nothing)
            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Sub ctxMenuSmsSendToSelected_Click(sender As Object, e As EventArgs) Handles ctxMenuSmsSendToSelected.Click

        Try

            Dim dtList As New DataTable("SelectedContacts")

            Dim receiverID As New DataColumn("receiverID")
            Dim receiverName As New DataColumn("receiverName")
            Dim receiverNumber As New DataColumn("receiverNumber")
            Dim fileCaseID As New DataColumn("fileCaseID")
            Dim timeID As New DataColumn("timeID")
            Dim smsSubject As New DataColumn("smsSubject")

            dtList.Columns.Add(receiverID)
            dtList.Columns.Add(receiverName)
            dtList.Columns.Add(receiverNumber)
            dtList.Columns.Add(fileCaseID)
            dtList.Columns.Add(timeID)
            dtList.Columns.Add(smsSubject)


            Dim myItems(lvContacts.SelectedItems.Count - 1) As ListViewItem

            ' lvContacts.SelectedItems().Item(0).SubItems(1)
            Dim i As Integer = 0

            For Each myItem In lvContacts.SelectedItems

                Dim dr As DataRow = dtList.NewRow()

                Dim cc As Lawyer.Common.VB.ContactInfo.Contact = Lawyer.Common.VB.ContactInfo.ContactInfoManager.GetContactByID(lvContacts.SelectedItems().Item(i).SubItems(1).Text)
                dr("receiverName") = cc.custFullName
                dr("receiverNumber") = cc.custCellPhone
                dr("receiverID") = cc.custID
                dr("fileCaseID") = ""
                dr("timeID") = ""
                dr("smsSubject") = "ارسال گروهی"

                dtList.Rows.Add(dr)
                dr = Nothing
                i += 1

            Next

            If Lawyer.Common.VB.SmsManager.getSmsConfig() = True Then
                RaiseEvent _showSmsForm(Nothing, Nothing, dtList, Nothing)
            End If


        Catch ex As Exception

        End Try
    End Sub
End Class
