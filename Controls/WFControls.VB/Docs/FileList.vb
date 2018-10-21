Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.BaseUserControl.ListView
Imports Lawyer.Common.VB
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Word
Imports System.Text
Imports System.IO
Imports Lawyer.Common.VB.TimeParties
Imports System.Net
Imports Lawyer.Common.VB.LawyerError
Imports WFControls.VB.TwainLib
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports Lawyer.Common.VB.CommonSetting


Public Class FileList : Implements IMessageFilter

    Dim treeParentId As String = String.Empty
    Dim TempItem As ListViewItem
    Dim OraghItem As ListViewItem
    Dim ParentInfo As FileParentInfo

    Delegate Sub ShowForm(ByVal ID As String, ByVal formName As Enums.FileType, ByVal FileID As String)
    Event ShowSpecificForm As ShowForm

    Dim defaultImages As New Dictionary(Of String, BaseForm.Image)
    Dim fileCaseStep As Enums.FileCaseStep
    Dim fileCaseId As String = String.Empty

    Delegate Sub ShowDocForm(ByVal ID As String, ByVal filePath As String, ByVal TableName As String, ByVal fileName As String, ByVal filecaseId As String)
    Event ShowDocContent As ShowDocForm

    Dim moveCursor, nodropCursor As Cursor
    Delegate Sub ShowConStr(ByVal islocal As Boolean)
    Event SetConnectionString As ShowConStr
    Delegate Sub ShowConfirm(ByVal text As String, ByVal title As String)
    Event ShowMessageBox As ShowConfirm
    Public YesClicked As Boolean = False
    Private IsLocal As Boolean = False
    Private IsCollapse As Boolean = False
    Private copyItem As Dictionary(Of String, String)

    Delegate Sub ReportForm(ByVal dt As System.Data.DataTable, ByVal title As String)
    Event ShowReport As ReportForm

    Private navigation As New ArrayList
    Private cutItem(2) As String
    Private pasteClick As Boolean = False
    Delegate Sub ContactDetailHandler(ByVal custId As String)
    Event ContactDetail As ContactDetailHandler

    Delegate Sub AsnadHandler()
    Event AsnadTip As AsnadHandler

    Delegate Sub _dlgOpenTempDocHandler()
    Event _dlgOpenTempDoc As _dlgOpenTempDocHandler


#Region "LReview"

#Region "Events"

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        lblMessage.Text = String.Empty

        Try
            ' 1- گرفتن مشخصات Parent

            If ParentInfo.fileId <> String.Empty Then

                Dim curfileType As Integer = setFileType(False)

                'در حالت search

                'abbas
                ''   If pnlSearch.Visible And curfileType = Enums.FileType.پرونده Then
                ' ''If pnlSearch.Visible And curfileType = Enums.FileType.پرونده Then

                ' ''    Search()

                ' ''Else

                ParentInfo = FileDocManager.GetParentinfoBychildId(ParentInfo.fileId)
                '2 - گرفتن فرزندان

                ParentInfo.FileType = curfileType

                BindChilds(ParentInfo.fileId)

                If ParentInfo.fileId = String.Empty Then

                    ClearNavigation()

                Else

                    BackNavigation()

                End If


                '' ''End If


            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("btnBack_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLock.Click
        lblMessage.Text = String.Empty
        Try

            If lvFiles.SelectedItems IsNot Nothing AndAlso lvFiles.SelectedItems.Count > 0 Then


                Lock(lvFiles.SelectedItems)

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("btnLock_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub Lock_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnLock.DragDrop
        lblMessage.Text = String.Empty
        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Lock" Then

                Dim myItems() As ListViewItem = data.Item(1)

                Lock(myItems)

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("Lock_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub Lock_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnLock.DragEnter
        lblMessage.Text = String.Empty
        Try
            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        lblMessage.Text = String.Empty
        Try

            If lvFiles.SelectedItems IsNot Nothing AndAlso lvFiles.SelectedItems.Count > 0 Then

                Unlock(lvFiles.SelectedItems)

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("btnUnlock_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub btnShowLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowLink.Click
        lblMessage.Text = String.Empty
        Try
            If lvFiles.SelectedItems.Count > 0 Then

                lvFiles.Focus()

                Dim retionId As String = lvFiles.SelectedItems(0).SubItems(5).Text

                If retionId <> String.Empty Then
                    For Each Item As ListViewItem In lvFiles.Items

                        If Item.SubItems(5).Text = retionId Then
                            lvFiles.Items(Item.Index).Selected = True
                        End If

                    Next
                End If


            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("btnShowLink_Click", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub btnAddLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLink.Click
        lblMessage.Text = String.Empty
        Try

            If lvFiles.SelectedItems IsNot Nothing AndAlso lvFiles.SelectedItems.Count > 0 Then

                AddLink(lvFiles.SelectedItems)

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("btnAddLink_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub btnDelLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelLink.Click
        lblMessage.Text = String.Empty
        Try

            If lvFiles.SelectedItems IsNot Nothing AndAlso lvFiles.SelectedItems.Count > 0 Then

                DelLink(lvFiles.SelectedItems)

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("btnDelLink_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub btnCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelSearch.Click
        lblMessage.Text = String.Empty
        Try
            SetForSearch(True)
            ' SetCollapse()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtList_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtList.KeyUp
        'how dirty code i wrote here
        If txtList.Text.Trim = String.Empty Then
            SetForSearch(True)
            filterList()
            SetResultCount()
            txtList.Focus()
            Exit Sub
        End If


        lblMessage.Text = String.Empty
        If e.KeyCode = Keys.Back Then
            Try
                SetForSearch(True)
                filterList()
                txtList.Focus()
                Exit Sub
            Catch ex As Exception

            End Try
        End If

        If e.KeyCode = Keys.Escape Then
            Try
                SetForSearch(True)
                txtList.Text = ""
                txtList.Focus()
                Exit Sub
            Catch ex As Exception

            End Try
        End If
        filterList()

        SetResultCount()

        txtList.Focus()

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblMessage.Text = String.Empty
        Try
            SetForSearch(True)
            ' SetCollapse()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        searchFiles()
    End Sub
    Private Sub txtSubject_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubject.KeyUp
        If e.KeyCode = 13 Then
            Search(True)
        End If
    End Sub


    Private Sub searchFiles()
        UcContacts1.Hide()
        lblMessage.Text = String.Empty

        Try
            Search(True)
        Catch ex As Exception
            UcContacts1.Hide()
            ErrorManager.WriteMessage("btnSearch_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub



    Private Sub UnLock_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnUnlock.DragEnter
        lblMessage.Text = String.Empty
        Try

            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub UnLock_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnUnlock.DragDrop


        lblMessage.Text = String.Empty
        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Lock" Then

                Dim myItems() As ListViewItem = data.Item(1)

                Unlock(myItems)

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("UnLock_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub btnAddLink_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnAddLink.DragDrop
        lblMessage.Text = String.Empty
        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Lock" Then

                Dim myItems() As ListViewItem = data.Item(1)

                AddLink(myItems)

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("btnAddLink_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub btnAddLink_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnAddLink.DragEnter
        lblMessage.Text = String.Empty
        Try
            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDelLink_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelLink.DragDrop
        lblMessage.Text = String.Empty
        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Lock" Then

                Dim myItems() As ListViewItem = data.Item(1)

                DelLink(myItems)

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("btnDelLink_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub btnDelLink_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelLink.DragEnter
        lblMessage.Text = String.Empty
        Try
            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        lblMessage.Text = String.Empty
        Try

            BindTree(String.Empty)

        Catch ex As Exception
            ErrorManager.WriteMessage("btnRefresh_Click", ex.ToString(), Me.ParentForm.Text)
        End Try
    End Sub

    Private Sub File_ChangeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles File_ChangeName.Click
        lblMessage.Text = String.Empty
        Try

            lvFiles.SelectedItems(0).BeginEdit()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lvFiles_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles lvFiles.AfterLabelEdit
        lblMessage.Text = String.Empty
        Try

            If lvFiles.SelectedItems.Count > 0 AndAlso CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.مشاوره Then

                e.CancelEdit = True

            End If

            'تغییر پوشه ای که به صورت Temp ایجاد شده است
            btnNewFile.Enabled = True

            btnNewOragh.Enabled = True

            btnScan.Enabled = True

            Dim IsLabelNothing As Boolean = False

            Dim itemName As String = e.Label

            Dim curItem As ListViewItem

            If e.Label = "" OrElse e.Label.Trim() = "" Then

                itemName = lvFiles.Items(e.Item).Text

                IsLabelNothing = True

            End If

            curItem = lvFiles.Items(e.Item)

            If TempItem IsNot Nothing Then

                Try
                    If Not String.IsNullOrEmpty(FileDocManager.IsExistFileName(itemName, ParentInfo.fileId)) Then

                        Throw New Exception

                    End If

                Catch ex As Exception

                    e.CancelEdit = True

                    lvFiles.Items.Remove(curItem)

                    lvFiles.Refresh()

                    TempItem = Nothing

                    Exit Sub

                End Try


                If IsLabelNothing Then

                    e.CancelEdit = True

                    curItem.Selected = True

                End If


                If cutItem IsNot Nothing AndAlso cutItem(2) = "0" And pasteClick Then
                    'Cut
                    Try

                        FileDocManager.CutFilecase(cutItem(0), ParentInfo.fileId)

                        BindChilds(ParentInfo.fileId)

                        cutItem = Nothing

                    Catch ex As Exception

                        lblMessage.Text = "خطا در ایجاد پرونده"

                        BindChilds(ParentInfo.fileId)

                    End Try

                    pasteClick = False

                    Exit Sub

                End If

                Dim result As Boolean = CreateFile(curItem, itemName, 0)

                If result = False Then

                    lvFiles.Items.Remove(curItem)
                    lvFiles.Refresh()
                    Exit Sub
                End If

                Dim preParentId = ParentInfo.fileId

                'correct
                If ParentInfo.FileType = Enums.FileType.پرونده Then

                    createDefaultDirectories(curItem.SubItems(1).Text, curItem.SubItems(4).Text, curItem)

                    RaiseEvent ShowSpecificForm(curItem.SubItems(4).Text, Enums.FileType.مشخصات_پرونده, String.Empty)

                End If

                TempItem = Nothing

            Else

                If ParentInfo.FileType = Enums.FileType.محتویات_اوراق OrElse ParentInfo.FileType = Enums.FileType.محتویات_متفرقه OrElse ParentInfo.FileType = Enums.FileType.محتویات_مستندات Then

                    Try


                        If OraghItem IsNot Nothing Then

                            Try
                                lblMessage.Text = "لطفا چند لحظه صبر نمایید."
                                Me.Refresh()
                                Dim id As String = FileDocManager.IsExistFileDocName(ParentInfo.fileId, curItem.SubItems(4).Text, itemName)

                                If id <> String.Empty AndAlso id <> curItem.SubItems(1).Text Then

                                    Throw New Exception

                                Else

                                    OraghItem.Text = itemName

                                    If Not AddEmptyFileDocs() Then

                                        Throw New Exception

                                    End If

                                End If

                                lblMessage.Text = ""

                            Catch ex As Exception

                                lvFiles.Items.Remove(curItem)

                                lvFiles.Refresh()

                                e.CancelEdit = True

                                lblMessage.Text = String.Empty

                            End Try


                            OraghItem = Nothing

                        Else

                            Dim id As String = FileDocManager.IsExistFileDocName(ParentInfo.fileId, curItem.SubItems(4).Text, e.Label)

                            If id <> String.Empty AndAlso id <> curItem.SubItems(1).Text Then

                                Throw New Exception

                            Else

                                If Not FileDocManager.UpdateDocFileName(curItem.SubItems(1).Text, itemName) Then

                                    e.CancelEdit = True

                                End If

                            End If

                        End If


                    Catch ex As Exception

                        e.CancelEdit = True

                    End Try

                ElseIf CInt(curItem.SubItems(3).Text) = Enums.FileType.پرونده_قفل_شده Then

                    lblMessage.Text = "امکان تغییر پرونده ی قفل شده وجود ندارد."

                    e.CancelEdit = True

                Else

                    Try

                        Dim id As String = FileDocManager.IsExistFileName(e.Label, ParentInfo.fileId)

                        If id <> String.Empty AndAlso id <> curItem.SubItems(1).Text Then

                            e.CancelEdit = True
                        Else

                            If Not FileDocManager.UpdateFileName(curItem.SubItems(1).Text, itemName) Then

                                e.CancelEdit = True

                            Else

                                Dim name As String = String.Empty
                                'for tree
                                If ParentInfo.fileId = String.Empty Then

                                    treeParentId = curItem.SubItems(1).Text

                                    name = itemName

                                End If

                                UpdateTree(treeParentId, name, False)

                            End If

                        End If


                    Catch ex As Exception

                        e.CancelEdit = True

                    End Try

                End If


            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("lvFiles_AfterLabelEdit", ex.ToString(), Me.ParentForm.Text)
        End Try

        SetResultCount()

    End Sub

    Private Sub File_ChangeImage_Default_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles File_ChangeImage_Default.Click
        lblMessage.Text = String.Empty
        Try
            Dim imageid As String = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل)

            For Each Item As ListViewItem In lvFiles.SelectedItems

                If Item.ImageKey <> imageid AndAlso FileDocManager.UpdateFileImage(Item.SubItems(1).Text, imageid) Then

                    Item.ImageKey = imageid

                End If

            Next

        Catch ex As Exception
            ErrorManager.WriteMessage("File_ChangeImage_Default_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub File_ChangeImage_Other_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles File_ChangeImage_Other.Click
        lblMessage.Text = String.Empty
        Try

            Dim pic As New BaseForm.Image

            OpenFileDialog1.FileName = String.Empty

            Me.OpenFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"

            If (Me.OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then


                pic.imagePath = OpenFileDialog1.FileName

                pic.imageID = Guid.NewGuid().ToString()

                pic.imageExtension = System.IO.Path.GetExtension(pic.imagePath)

                pic.imageUpdateDate = DateManager.GetFileUpdateDate()

                pic.imageName = System.IO.Path.GetFileNameWithoutExtension(pic.imagePath)

                Dim imageFullpath As String = FileManager.GetDocsImagePath & pic.imageID & pic.imageUpdateDate & pic.imageExtension

                If BaseForm.ImageManager.AddImage(pic, imageFullpath) Then

                    lvFiles.LargeImageList.Images.Add(pic.imageID, Bitmap.FromFile(imageFullpath))

                    For Each Item As ListViewItem In lvFiles.SelectedItems

                        If FileDocManager.UpdateFileImage(Item.SubItems(1).Text, pic.imageID) Then

                            Item.ImageKey = pic.imageID

                        End If

                    Next


                End If

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("File_ChangeImage_Other_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub toolStrip_Global_ChangeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStrip_Global_ChangeName.Click

        lblMessage.Text = String.Empty
        Try
            If lvFiles.SelectedItems.Count > 0 Then
                lvFiles.SelectedItems(0).BeginEdit()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddFileByDrag(ByVal files() As String)


        lblMessage.Text = String.Empty

        Try


            Dim th As New Threading.Thread(AddressOf AddFile)

            l = New Loading

            Me.Controls.Add(l)

            l.BringToFront()

            l.Location = New Drawing.Point(200, 200)

            Try

                th.Start(files)

            Catch ex As Exception

                th.Abort()

            End Try

        Catch ex As Exception
            ErrorManager.WriteMessage("AddFileByDrag", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub ToolStripAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripAddFile.Click

        lblMessage.Text = String.Empty

        Try

            OpenFileDialog1.Multiselect = True

            OpenFileDialog1.FileName = String.Empty

            If (Me.OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then

                AddFileByDrag(OpenFileDialog1.FileNames())

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Change_Case_name_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Change_Case_name.Click
        lblMessage.Text = String.Empty
        Try
            'در حالت جستجو fileId 
            'مربوط به parent 
            'وجود ندارد
            ' '' ''If pnlSearch.Visible Then
            ' '' ''    ParentInfo.fileId = FileDocManager.GetFileParentId(lvFiles.SelectedItems(0).SubItems(1).Text)
            ' '' ''    ParentInfo.FileType = Enums.FileType.فایل
            ' '' ''    lvFiles.SelectedItems(0).BeginEdit()
            ' '' ''Else
            lvFiles.SelectedItems(0).BeginEdit()

            '' ''End If

        Catch ex As Exception

        End Try

    End Sub

    'ارسال پرونده به سرور
    Private Sub ToolstripSendToServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolstripSendToServer.Click

        lblMessage.Text = String.Empty

        Dim fId As String = FileDocManager.GetFileCaseID(lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).SubItems(1).Text)

        If Not UserHasPermission(Login.CurrentLogin.CurrentUser.UserID, fId) Then

            lblMessage.Text = "مجوز دسترسی به پرونده داده نشده است"

            Exit Sub

        End If


        YesClicked = False

        Try


            If lvFiles.SelectedItems.Count = 1 Then

                Dim fileId As String = lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).SubItems(1).Text

                '1) تنظیم another computer Ip
                RaiseEvent SetConnectionString(False)

                '2) is Correct connection
                If Not LockDocs.Common.IsCorrectDestComputer() Then

                    MessageBox.Show("کامپیوترمقصد تنظیم نشده است")

                Else

                    Dim result As String = LockDocs.Transfer.CheckBeforeTransferToServer(lvFiles.Items(lvFiles.SelectedItems.Item(0).Index), ParentInfo.fileId)

                    If result <> String.Empty Then

                        lblMessage.Text = result

                    Else

                        If TransferParentFileToServer_new2(ParentInfo.fileId, fileId) Then

                            'If TransferParentFileToServer(ParentInfo.fileId) Then

                            If Not LockDocs.Transfer.TransferFileCase(ParentInfo.fileId, fileId, False) Then

                                Throw New Exception

                            End If

                            If LockDocs.Transfer.TransferError <> String.Empty Then

                                lblMessage.Text = LockDocs.Transfer.TransferError

                            Else

                                lblMessage.Text = "انتقال انجام شد"

                            End If

                        End If

                    End If

                End If

                '3) در هر لحظه امکان ارسال یک پرونده وجود دارد
            ElseIf lvFiles.SelectedItems.Count > 1 Then

                lblMessage.Text = "یکی از پرونده ها را انتخاب کنید"

            End If


        Catch ex As Exception

            lblMessage.Text = "خطا در انتقال"
            ErrorManager.WriteMessage("ToolstripSendToServer_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    ''ارسال پرونده به سرور
    'Private Sub ToolstripSendToServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolstripSendToServer.Click

    '    lblMessage.Text = String.Empty

    '    Dim fId As String = FileDocManager.GetFileCaseID(lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).SubItems(1).Text)

    '    If Not UserHasPermission(Login.CurrentLogin.CurrentUser.UserID, fId) Then

    '        lblMessage.Text = "مجوز دسترسی به پرونده داده نشده است"

    '        Exit Sub

    '    End If


    '    YesClicked = False

    '    Try


    '        If lvFiles.SelectedItems.Count = 1 Then

    '            Dim fileId As String = lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).SubItems(1).Text

    '            '1) تنظیم another computer Ip
    '            RaiseEvent SetConnectionString(False)

    '            '2) is Correct connection
    '            If Not LockDocs.Common.IsCorrectDestComputer() Then

    '                MessageBox.Show("کامپیوترمقصد تنظیم نشده است")

    '            Else

    '                Dim result As String = LockDocs.Transfer.CheckBeforeTransferToServer(lvFiles.Items(lvFiles.SelectedItems.Item(0).Index), ParentInfo.fileId)

    '                If result <> String.Empty Then

    '                    lblMessage.Text = result

    '                Else

    '                    If TransferParentFileToServer_new(ParentInfo.fileId, fileId) Then

    '                        'If TransferParentFileToServer(ParentInfo.fileId) Then

    '                        If Not LockDocs.Transfer.TransferFileCase(ParentInfo.fileId, fileId, False) Then

    '                            Throw New Exception

    '                        End If

    '                        If LockDocs.Transfer.TransferError <> String.Empty Then

    '                            lblMessage.Text = LockDocs.Transfer.TransferError

    '                        Else

    '                            lblMessage.Text = "انتقال انجام شد"

    '                        End If

    '                    End If

    '                End If

    '            End If

    '            '3) در هر لحظه امکان ارسال یک پرونده وجود دارد
    '        ElseIf lvFiles.SelectedItems.Count > 1 Then

    '            lblMessage.Text = "یکی از پرونده ها را انتخاب کنید"

    '        End If


    '    Catch ex As Exception

    '        lblMessage.Text = "خطا در انتقال"
    '        ErrorManager.WriteMessage("ToolstripSendToServer_Click", ex.ToString(), Me.ParentForm.Text)
    '    End Try

    'End Sub

    '' دریافت پرونده از سرور
    'Private Sub ToolStripsendToLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripsendToLocal.Click

    '    YesClicked = False

    '    lblMessage.Text = String.Empty

    '    Try

    '        If lvFiles.SelectedItems.Count = 1 Then

    '            '1) تنظیم another computer Ip
    '            RaiseEvent SetConnectionString(True)

    '            '2) is Correct connection
    '            If Not LockDocs.Common.IsCorrectDestComputer() Then

    '                lblMessage.Text = "کامپیوترمقصد تنظیم نشده است"

    '            Else

    '                Dim result As String = LockDocs.Transfer.TransferToLocal(lvFiles.Items(lvFiles.SelectedItems.Item(0).Index), ParentInfo.fileId)

    '                If result <> String.Empty Then

    '                    lblMessage.Text = result

    '                Else

    '                    lblMessage.Text = "انتقال انجام شد"
    '                End If

    '            End If

    '            '3) در هر لحظه امکان ارسال یک پرونده وجود دارد
    '        ElseIf lvFiles.SelectedItems.Count > 1 Then

    '            lblMessage.Text = "یکی از پرونده ها را انتخاب کنید"

    '        End If


    '    Catch ex As Exception

    '        lblMessage.Text = "خطا در انتقال"
    '        ErrorManager.WriteMessage("ToolStripsendToLocal_Click", ex.ToString(), Me.ParentForm.Text)
    '    End Try

    'End Sub

    ' دریافت پرونده از سرور

    Private Sub ToolStripsendToLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripsendToLocal.Click

        YesClicked = False

        lblMessage.Text = String.Empty

        Try

            If lvFiles.SelectedItems.Count = 1 Then

                '1) تنظیم another computer Ip
                RaiseEvent SetConnectionString(True)

                '2) is Correct connection
                If Not LockDocs.Common.IsCorrectDestComputer() Then

                    lblMessage.Text = "کامپیوترمقصد تنظیم نشده است"

                Else

                    Dim result As String = LockDocs.Transfer.TransferToLocal_new(lvFiles.Items(lvFiles.SelectedItems.Item(0).Index), ParentInfo.fileId)

                    If result <> String.Empty Then

                        lblMessage.Text = result

                    Else

                        lblMessage.Text = "انتقال انجام شد"
                    End If

                End If

                '3) در هر لحظه امکان ارسال یک پرونده وجود دارد
            ElseIf lvFiles.SelectedItems.Count > 1 Then

                lblMessage.Text = "یکی از پرونده ها را انتخاب کنید"

            End If


        Catch ex As Exception

            lblMessage.Text = "خطا در انتقال"
            ErrorManager.WriteMessage("ToolStripsendToLocal_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub lvFiles_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvFiles.DragDrop

        lblMessage.Text = String.Empty

        Try

            btnNewFile.Enabled = False

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If ParentInfo.FileType = Enums.FileType.فایل AndAlso data.Item(0) = "Contact" Then

                AddFileWithDrag2(data)

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در ایجاد فایل"

            ErrorManager.WriteMessage("lvFiles_DragDrop, Part1", ex.ToString(), Me.ParentForm.Text)

        End Try


        Try
            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "DocList" AndAlso (ParentInfo.FileType = Enums.FileType.محتویات_اوراق OrElse ParentInfo.FileType = Enums.FileType.محتویات_متفرقه OrElse ParentInfo.FileType = Enums.FileType.محتویات_مستندات) Then

                Dim temp As New ListViewItem

                temp.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

                temp.Text = ""

                temp.SubItems.Add("")

                temp.SubItems.Add(0)

                temp.SubItems.Add(ParentInfo.FileType)

                temp.SubItems.Add("") 'fileExtension

                Dim myItems() As ListViewItem = data.Item(1)

                For Each item As ListViewItem In myItems

                    Try

                        temp.Text = item.Text

                        temp.ImageKey = item.ImageKey
                        'مورد ارسالی فایل می باشد
                        If Not CBool(item.SubItems(2).Text) Then

                            temp.SubItems(4).Text = item.SubItems(3).Text

                            temp.SubItems(1).Text = Guid.NewGuid.ToString()

                            If String.IsNullOrEmpty(FileDocManager.IsExistFileDocName(ParentInfo.fileId, item.SubItems(3).Text, item.Text)) Then

                                Dim file As String = TempDocManager.WriteFile(item.SubItems(1).Text, item.SubItems(3).Text)


                                If FileDocManager.AddFileDoc(temp.SubItems(1).Text, ParentInfo.fileId, ParentInfo.FileCaseId, item.SubItems(1).Text, DateManager.GetCurrentShamsiDateInNumericFormat(), DateManager.GetCurrentTime(), file) Then

                                    lvFiles.Items.Add(temp.Clone())

                                End If


                            End If



                        End If


                    Catch ex As Exception

                    End Try

                Next

                btnNewFile.Enabled = True
                SetResultCount()
                Exit Sub

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("lvFiles_DragDrop, Part2", ex.ToString(), Me.ParentForm.Text)

        End Try

        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) AndAlso (ParentInfo.FileType = Enums.FileType.محتویات_اوراق OrElse ParentInfo.FileType = Enums.FileType.محتویات_متفرقه OrElse ParentInfo.FileType = Enums.FileType.محتویات_مستندات) Then
                AddFileByDrag(e.Data.GetData(DataFormats.FileDrop))
            Else
                SetResultCount()
                Exit Sub

            End If
        Catch ex As Exception

        End Try

        SetResultCount()

    End Sub

    Private Sub lvFiles_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvFiles.DragEnter
        lblMessage.Text = String.Empty
        Try

            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lvFiles_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvFiles.ItemDrag

    End Sub

    Private Sub lvFiles_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles lvFiles.GiveFeedback

        e.UseDefaultCursors = False

        Select Case e.Effect

            Case DragDropEffects.Move

                Cursor.Current = moveCursor

            Case DragDropEffects.None

                Cursor.Current = nodropCursor

            Case DragDropEffects.Copy

                Cursor.Current = moveCursor

        End Select

    End Sub

    Private Sub lvFiles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFiles.DoubleClick

        Try

            lblMessage.Text = String.Empty

            Dim filename As String = lvFiles.SelectedItems(0).Text
            ' Directory
            If lvFiles.SelectedItems(0).SubItems(2).Text Then

                '///////////////////////For Tree
                If CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.فایل Then


                    treeParentId = lvFiles.SelectedItems(0).SubItems(1).Text

                    '' ''SetCurrentFile(filename)



                End If
                '///////////////////////

                'If locker Is Nothing Then
                If CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.دایرکتوری_اوراق OrElse CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.دایرکتوری_مستندات OrElse CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.دایرکتوری_متفرقه Then

                    ' 1- گرفتن مشخصات Parent
                    ParentInfo.fileId = lvFiles.SelectedItems(0).SubItems(1).Text

                    ParentInfo.FileType = setFileType(True)

                    '2 - گرفتن فرزندان

                    BindFileDocChilds(ParentInfo.fileId)


                ElseIf CInt(lvFiles.SelectedItems(0).SubItems(3).Text) <> Enums.FileType.پرونده_قفل_شده Then


                    If CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.پرونده Then

                        Dim fId As String = FileDocManager.GetFileCaseID(lvFiles.SelectedItems(0).SubItems(1).Text)

                        'if user is monshi let open the doc
                        If Not UserHasPermission(Login.CurrentLogin.CurrentUser.UserID, fId) And Login.CurrentLogin.CurrentUser.Role <> ContactInfo.Enums.RoleType.منشی Then
                            lblMessage.Text = "مجوز دسترسی به شما داده نشده است"
                            Exit Sub
                        End If

                        ParentInfo.FileCaseId = fId
                    End If

                    ' 1- گرفتن مشخصات Parent
                    ParentInfo.fileId = lvFiles.SelectedItems(0).SubItems(1).Text

                    ParentInfo.FileType = setFileType(True)

                    ParentInfo.fileName = filename


                    '2 - گرفتن فرزندان

                    BindChilds(ParentInfo.fileId)


                Else

                    Dim locker As ContactInfo.ContactInfoReview = FileDocManager.GetFileLocker(lvFiles.SelectedItems(0).SubItems(1).Text)

                    lvFiles.SelectedItems(0).ToolTipText = "توسط " & locker.custFullName & "قفل شده است"

                    filename = String.Empty

                End If

                If filename <> String.Empty Then
                    SetCurrentFile(filename)
                End If
                'File
            Else

                Select Case lvFiles.SelectedItems(0).SubItems(3).Text

                    Case Enums.FileType.مشخصات_پرونده

                        RaiseEvent ShowSpecificForm(ParentInfo.FileCaseId, Enums.FileType.مشخصات_پرونده, String.Empty)


                    Case Enums.FileType.محتویات_اوراق, Enums.FileType.محتویات_مستندات, Enums.FileType.محتویات_متفرقه

                        'نوشتن فایل و باز کردن
                        Dim file As String = FileDocManager.WriteFile(lvFiles.SelectedItems(0).SubItems(1).Text)

                        If Not String.IsNullOrEmpty(file) Then

                            Dim extension As String = System.IO.Path.GetExtension(file)

                            If extension = ".txt" OrElse extension = ".dot" OrElse extension = ".dotx" OrElse extension = ".docx" OrElse extension = ".doc" Then

                                RaiseEvent ShowDocContent(lvFiles.SelectedItems(0).SubItems(1).Text, file, "filedocs", lvFiles.SelectedItems(0).Text, ParentInfo.FileCaseId)


                            Else

                                System.Diagnostics.Process.Start(file)

                            End If

                        End If

                    Case Enums.FileType.تجمیع_پرونده

                        Try
                            Dim pdfPath As String = CreatePdfFile()
                            lblMessage.Text = String.Empty
                            Me.Refresh()
                            If pdfPath <> String.Empty Then System.Diagnostics.Process.Start(pdfPath)

                        Catch ex As Exception
                            lblMessage.Text = "خطا در ایجاد فایل تجمیع پرونده"
                        End Try

                    Case Else
                        ' no body has permission to mali

                        If lvFiles.SelectedItems(0).SubItems(3).Text = Enums.FileType.مالی Then

                            If Login.CurrentLogin.CurrentUser.IsAdmin Or FileParties.FilePartiesManager.UserHasFinanceAccess(ParentInfo.FileCaseId, Login.CurrentLogin.CurrentUser.UserID, FileParties.Enums.FileCaseRole.وکیل) Or Login.CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.منشی Then

                                RaiseEvent ShowSpecificForm(ParentInfo.FileCaseId, lvFiles.SelectedItems(0).SubItems(3).Text, lvFiles.SelectedItems(0).SubItems(1).Text)

                            Else

                                lblMessage.Text = "مجوز دسترسی به شما داده نشده است. "

                                Exit Sub

                            End If

                        Else

                            RaiseEvent ShowSpecificForm(ParentInfo.FileCaseId, lvFiles.SelectedItems(0).SubItems(3).Text, lvFiles.SelectedItems(0).SubItems(1).Text)

                        End If

                End Select

            End If


        Catch ex As Exception

            UcContacts1.Hide()

            ErrorManager.WriteMessage("lvFiles_DoubleClick", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    '??????????????????????????تغییرات برای ارسال و دریافت برای سرور
    Dim frmLoaded As Boolean = False
    Private Sub FileList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ''''abbas

            ''''Login.LoginManager.SetCurrentLoginDebug("df8718ac-77b0-4ca2-a7e2-d4bdaaa521e7")

            If frmLoaded Then Exit Sub
            frmLoaded = True
            lvFiles.ShowItemToolTips = True

            cutItem = Nothing

            cmbstatus.SelectedIndex = 0

            IsCollapse = True

            lblMessage.Text = String.Empty

            '' ''lvFiles.ListViewItemSorter = New ListViewIndexComparer()

            lvFiles.LabelEdit = True

            lvFiles.AllowDrop = True

            lvFiles.LargeImageList = New ImageList()
            lvFiles.SmallImageList = New ImageList()

            lvFiles.LargeImageList.ImageSize = New Size(DefaultImageSize.DocsList, DefaultImageSize.DocsList)
            lvFiles.SmallImageList.ImageSize = New Size(25, 25)

            ' lvFiles.LargeImageList.ImageSize = New Size(30, 30)

            LoadDefaultImage()

            LoadDefaultImageFromTempDoc()

            ParentInfo = New FileParentInfo

            ParentInfo.fileId = String.Empty

            ParentInfo.FileCaseId = String.Empty

            ParentInfo.FileType = Enums.FileType.فایل  ' تشکیل فایل

            BindChilds(String.Empty)

            ' BindTree("")

            ToolTip1.SetToolTip(btnAddLink, "ایجاد ارتباط")

            ToolTip1.SetToolTip(btnDelLink, "حذف ارتباط")

            ToolTip1.SetToolTip(btnBack, "بازگشت")

            ToolTip1.SetToolTip(btnDelete, "حذف")

            ToolTip1.SetToolTip(btnNewFile, "تشکیل فایل")

            ToolTip1.SetToolTip(btnArchiveFile, "آرشیو فایل")

            ToolTip1.SetToolTip(btnRefresh, "به روز رسانی")

            ToolTip1.SetToolTip(btnShowLink, "نمایش پرونده های مرتبط")

            ToolTip1.SetToolTip(btnLock, "قفل گذاری")

            ToolTip1.SetToolTip(btnUnlock, "قفل گشایی")

            ToolTip1.SetToolTip(btnCancelSearch, "لغو عملیات جستجو")

            ''ToolTip1.SetToolTip(pnlCollapse, "جستجوی پرونده")

            ToolTip1.SetToolTip(btnReport, "لیست محتویات پرونده")

            ToolTip1.SetToolTip(btnPrint, "چاپ مشخصات پرونده")

            ToolTip1.SetToolTip(btnNewOragh, "جدید")

            ToolTip1.SetToolTip(btnAsnad, "اسناد تیپ")

            ToolTip1.SetToolTip(btnScan, "اسکن")

            ToolTip1.SetToolTip(btnAddFolder, "افزودن طبقه بندی پرونده ها")

            'search
            BindSearchControls()

            '-----------------------correct

            '' ''contextParvande.Items("ToolstripSendToServer").Enabled = True

            '' ''contextParvande.Items("ToolStripsendToLocal").Enabled = True

            '' ''Try

            '' ''    Select Case ISLocalVersion()

            '' ''        Case 0
            '' ''            contextParvande.Items("ToolstripSendToServer").Enabled = False

            '' ''            contextParvande.Items("ToolStripsendToLocal").Enabled = False
            '' ''        Case 1

            '' ''            contextParvande.Items("ToolStripsendToLocal").Enabled = False

            '' ''            IsLocal = True

            '' ''        Case 2

            '' ''            contextParvande.Items("ToolstripSendToServer").Enabled = False

            '' ''            IsLocal = False

            '' ''    End Select


            '' ''Catch ex As Exception

            '' ''    contextParvande.Items("ToolstripSendToServer").Enabled = False

            '' ''    contextParvande.Items("ToolStripsendToLocal").Enabled = False

            '' ''End Try
            '-----------------------------------------Correct
            Try
                'monshi has access to open file
                If Login.CurrentLogin.CurrentUser.IsAdmin OrElse Login.CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.وکیل OrElse Login.CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.منشی Then


                    contextParvande.Items("ToolStripCreateCase").Enabled = True

                Else

                    contextParvande.Items("ToolStripCreateCase").Enabled = False

                End If

            Catch ex As Exception

            End Try

            '' ''SetCurrentFile(" فایلهای تشکیل شده ")


            contextParvande.Items("ToolstripSendToServer").Enabled = False

            contextParvande.Items("ToolStripsendToLocal").Enabled = False

            ' combox of state
            bindCmbState()
            '''''''''

        Catch ex As Exception

        End Try

    End Sub

    Private Sub bindCmbState()
        Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
        Dim datatable As System.Data.DataTable = db.GetDataTableFromSqlCommandText("vewparvandekolli", "select distinct tsstate from vewparvandekolli", Nothing)
        If db.HasError Then Throw db.ErrorException
        Dim dr As DataRow = datatable.NewRow()
        dr(0) = "---"
        datatable.Rows.InsertAt(dr, 0)
        cmbstate.DisplayMember = "tsstate"
        cmbstate.ValueMember = "tsstate"
        cmbstate.DataSource = datatable
    End Sub



    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        YesClicked = False

        lblMessage.Text = String.Empty

        Try

            If lvFiles.SelectedItems IsNot Nothing AndAlso lvFiles.SelectedItems.Count > 0 Then

                DelFile(lvFiles.SelectedItems)

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("btnDelete_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub btnDelete_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelete.DragEnter

        lblMessage.Text = String.Empty
        Try
            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDelete_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelete.DragDrop

        YesClicked = False

        lblMessage.Text = String.Empty

        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Lock" Then

                Dim myItems() As ListViewItem = data.Item(1)

                DelFile(myItems)

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("btnDelete_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    '??????????????????????????تغییرات برای ارسال و دریافت برای سرور
    Private Sub lvFiles_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvFiles.MouseUp

        If e.Button = MouseButtons.Right Then

            ToolStripAddFile.Visible = True

            Select Case ParentInfo.FileType

                Case Enums.FileType.فایل

                    lvFiles.ContextMenuStrip = contextFile

                    If lvFiles.SelectedItems.Count = 0 Then

                        lvFiles.ContextMenuStrip = Nothing

                        Exit Sub

                    Else

                        lvFiles.ContextMenuStrip = contextFile

                    End If

                Case Enums.FileType.پرونده, Enums.FileType.پرونده_قفل_شده

                    lvFiles.ContextMenuStrip = contextParvande

                    If lvFiles.SelectedItems.Count = 0 Then

                        Change_Case_name.Enabled = False

                        ToolstripSendToServer.Enabled = False

                        ToolStripsendToLocal.Enabled = False

                        CopyToolStripMenuItem.Visible = False

                        CutToolStripMenuItem.Visible = False

                    Else

                        Change_Case_name.Enabled = True

                        '' ''ToolstripSendToServer.Enabled = IsLocal

                        '' ''ToolStripsendToLocal.Enabled = Not IsLocal

                        CopyToolStripMenuItem.Visible = True

                        CutToolStripMenuItem.Visible = True

                        If lvFiles.SelectedItems.Count > 1 OrElse CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.پرونده_قفل_شده Then

                            CopyToolStripMenuItem.Visible = False

                            CutToolStripMenuItem.Visible = False

                        End If

                    End If


                    If cutItem Is Nothing Then

                        PasteToolStripMenuItem.Enabled = False

                    Else

                        PasteToolStripMenuItem.Enabled = True

                    End If

                Case Enums.FileType.محتویات_اوراق, Enums.FileType.محتویات_متفرقه, Enums.FileType.محتویات_مستندات

                    lvFiles.ContextMenuStrip = contextGlobal

                    If lvFiles.SelectedItems.Count = 0 Then

                        toolStrip_Global_ChangeName.Enabled = False

                    Else

                        toolStrip_Global_ChangeName.Enabled = True

                    End If

                Case Enums.FileType.محتویات_فایل

                    If lvFiles.SelectedItems.Count = 0 Then

                        lvFiles.ContextMenuStrip = Nothing

                        Exit Sub
                    Else
                        If CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.مشاوره Then

                            lvFiles.ContextMenuStrip = Nothing

                            Exit Sub

                        End If

                        lvFiles.ContextMenuStrip = contextGlobal

                        ToolStripAddFile.Visible = False

                    End If

                Case Else

                    lvFiles.ContextMenuStrip = Nothing

                    Exit Sub

            End Select

            lvFiles.ContextMenuStrip.Show(lvFiles, New Drawing.Point(e.X, e.Y))

        Else

            lvFiles.ContextMenuStrip = Nothing

        End If

    End Sub

    Private Sub pnlCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ''' SetCollapse()

    End Sub

    ' ''Private Sub SetCollapse()

    ' ''    If IsCollapse Then

    ' ''        Panel2.Height = 90

    ' ''        pnlFileSearch.Height = 0

    ' ''        pnlCollapse.Image = Global.WFControls.VB.My.Resources.Resources.collpase

    ' ''        ToolTip1.SetToolTip(pnlCollapse, "")

    ' ''    Else

    ' ''        Panel2.Height = 0

    ' ''        pnlFileSearch.Height = 27

    ' ''        pnlCollapse.Image = Global.WFControls.VB.My.Resources.Resources.expand

    ' ''        ToolTip1.SetToolTip(pnlCollapse, "جستجوی پرونده")

    ' ''    End If

    ' ''    '' ''Panel1.Height = SplitContainer1.Panel2.Height - 38 - Panel2.Height
    ' ''    Panel1.Height = SplitContainer1.Panel2.Height - 36 - (Panel2.Height + pnlFileSearch.Height)
    ' ''    IsCollapse = Not IsCollapse
    ' ''End Sub

    Private Sub FlowLayoutPanel2_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel2.SizeChanged

        ' ''If IsCollapse Then

        ' ''    Panel2.Height = 0

        ' ''Else

        ' ''    Panel2.Height = 88

        ' ''End If

        ''''Panel1.Height = CType(sender, FlowLayoutPanel).Height - Panel2.Height - 36 - pnlFileSearch.Height
        ''''Panel1.Height = CType(sender, FlowLayoutPanel).Height - Panel2.Height - 36
        If SplitContainer1.Panel2.Width < 650 Then

            CType(sender, FlowLayoutPanel).AutoScroll = True
        Else

            CType(sender, FlowLayoutPanel).AutoScroll = False

            If IsCollapse Then

                '''' Panel2.Width = CType(sender, FlowLayoutPanel).Width - 5

                Panel1.Width = CType(sender, FlowLayoutPanel).Width - 5

            Else

                '''  Panel2.Width = CType(sender, FlowLayoutPanel).Width - 5

                Panel1.Width = CType(sender, FlowLayoutPanel).Width - 5

            End If


        End If

    End Sub

    Private Sub AddNewFile(ByVal isScan As Boolean)

        lblMessage.Text = String.Empty

        Try

            If isScan Then

                OraghItem = New ListViewItem("اسکن " & lvFiles.Items.Count + 1, BaseForm.ImageManager.GetDefaultIcon_TempDocsTable(".jpg"))

            Else

                OraghItem = New ListViewItem(IIf(ParentInfo.FileType = Enums.FileType.محتویات_اوراق, "اوراق ", "سند ").ToString() & lvFiles.Items.Count + 1, BaseForm.ImageManager.GetDefaultIcon_TempDocsTable(".docx"))

            End If

            OraghItem.SubItems.Add(Guid.NewGuid().ToString())

            OraghItem.SubItems.Add(0)

            OraghItem.SubItems.Add((ParentInfo.FileType)) ' نوع فایل

            If isScan Then

                OraghItem.SubItems.Add(Path.GetExtension(scanImage))

            Else

                OraghItem.SubItems.Add(".docx")

            End If

            OraghItem.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

            Dim index As Integer = lvFiles.Items.Count

            lvFiles.Items.Insert(index, OraghItem.Clone())

            lvFiles.Items(index).BeginEdit()

            btnNewOragh.Enabled = False

            btnScan.Enabled = False


        Catch ex As Exception

            ErrorManager.WriteMessage("btnNewOragh_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub btnNewOragh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewOragh.Click

        scanImage = FileManager.GetEmptyWordPath()

        AddNewFile(False)

    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try
            lblMessage.Text = String.Empty

            Dim number As FileCaseNumber = FileCaseManager.GetFileCaseNumbers(ParentInfo.FileCaseId)

            Dim title As String = "شماره سیستمی پرونده : " & number.fileCaseNumberInSystem & vbCrLf

            title &= "شماره پرونده در مرجع قضایی : " & number.fileCaseNumberInCourt & "/" & number.fileCaseNumberInBranch

            Dim dt As System.Data.DataTable = FileDocManager.GetFileDocsReportByFilecase(ParentInfo.FileCaseId, Enums.FileType.دایرکتوری_مستندات)

            RaiseEvent ShowReport(dt, title)

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Utility"

    Private Sub SetResultCount()

        lblFileCount.Text = "تعداد : " + lvFiles.Items.Count.ToString()

        lvFiles.Focus()
    End Sub

    Private Sub SetCurrentFile(ByVal filename As String)

        If filename = String.Empty Then

            txtCurrentFile.Text = "لیست جستجو"

        Else

            AppendNavigation(filename)

        End If

    End Sub

    Private Function ISLocalVersion() As Integer

        Dim islocal As Boolean = False

        Dim currentConfig As Lawyer.Common.CS.ConfigFile.Config = Nothing

        Try
            currentConfig = Lawyer.Common.CS.ConfigFile.Config.Load(FileManager.GetLoginConfigPath())

            If currentConfig Is Nothing Then

                Return 0

            End If

        Catch ex As Exception

            Return 0

        End Try

        If currentConfig IsNot Nothing Then

            Dim h As System.Net.IPHostEntry = Dns.GetHostByName(System.Net.Dns.GetHostName)

            For index As Integer = 0 To h.AddressList.Length - 1

                If currentConfig.LIP.ToLower() = h.AddressList.GetValue(index).ToString Then

                    Return 1

                End If

            Next

            If currentConfig.LIP.ToLower() <> "localhost" AndAlso currentConfig.LIP.ToLower() <> "127.0.0.1" Then

                Return 2

            End If

            Return 1

        Else

            Return 0

        End If

    End Function

    Private Sub Search()


        lvFiles.Clear()

        ParentInfo.FileType = Enums.FileType.پرونده

        SetDesign()

        SetForSearch(False)

        SetCurrentFile("")


        Dim _fileArchive As String = ""
        If cmbstatus.SelectedIndex = 0 Then
            _fileArchive = " and (filecases.filecaseclosedate is  null) "
        ElseIf cmbstatus.SelectedIndex = 1 Then
            _fileArchive = " and (filecases.filecaseclosedate is not null) "
        End If

        Dim _contactinfo As String = ""
        If cmbFileSearch.SelectedValue <> "10" And cmbFileSearch.SelectedValue <> "11" And cmbFileSearch.SelectedValue <> "12" And cmbFileSearch.SelectedValue <> "3" Then
            _contactinfo = "  and contactinfo.custtype=" & cmbFileSearch.SelectedValue & " and contactinfo.custfullname like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim) & "%'"
        End If

        Dim _filecase As String = ""
        If (cmbFileSearch.SelectedValue = "10" Or cmbFileSearch.SelectedValue = "3") And txtSubject.Text.Trim(AccessibleDescription) <> String.Empty Then
            _filecase = " and ( fileCaseSubject  like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(Me.txtSubject.Text.Trim) & "%' "
            _filecase += " or match (fileDocContent,fileDocName) against ('" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(Me.txtSubject.Text.Trim) & "*' in boolean mode) )"
        End If

        If cmbFileSearch.SelectedValue = "11" And txtSubject.Text.Trim(AccessibleDescription) <> String.Empty Then
            _filecase = " and (filecases.fileCaseNumberInSystem  like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim()) & "%')"
        End If

        If cmbFileSearch.SelectedValue = "12" And txtSubject.Text.Trim(AccessibleDescription) <> String.Empty Then
            _filecase = " and ( filecases.fileCaseNumberInCourt like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim) & "%'  or filecases.fileCaseNumberInBranch like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim) & "%')"
        End If


        Dim childs As FileChildInfoCollection = FileDocManager.GetFilesBySimpleSearch(_fileArchive, _contactinfo, _filecase)

        If childs IsNot Nothing Then

            For Each Item As FileChildInfo In childs

                Try

                    Dim imageKey As String = Item.fileImageID

                    Dim imageFullpath As String = FileManager.GetDocsImagePath() & imageKey & Item.ImageUpdateDate

                    If Item.imageExtension = String.Empty Then

                        imageFullpath &= defaultImages(BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل)).imageExtension

                    Else
                        imageFullpath &= Item.imageExtension

                    End If

                    Dim imagelist As ImageList = lvFiles.LargeImageList

                    If Not imagelist.Images.ContainsKey(imageKey) Then

                        If Not System.IO.File.Exists(imageFullpath) Then

                            BaseForm.ImageManager.WriteImage(imageKey, imageFullpath)

                        End If

                        imagelist.Images.Add(imageKey, Bitmap.FromFile(imageFullpath))

                    End If

                    Dim newItem As New ListViewItem(Item.fileName, imageKey)

                    newItem.SubItems.Add(Item.fileID)

                    newItem.SubItems.Add(Item.fileIsCat)

                    newItem.SubItems.Add(Item.fileType) ' نوع فایل

                    newItem.SubItems.Add(Item.fileRelationId) 'RelationID

                    lvFiles.Items.Add(newItem)


                Catch ex As Exception

                End Try


            Next

        End If

        SetResultCount()

    End Sub

    Private Sub BindChilds(ByVal parentId As String)

        Try
            lvFiles.Items.Clear()

            SetDesign()
            Dim childs As FileChildInfoCollection
            If String.IsNullOrEmpty(parentId) Then
                'جستجوی فایل
                childs = FileDocManager.SearchFiles(txtSubject.Text.Trim(), chkArchive.Checked)
            Else
                childs = FileDocManager.GetFileChildsByParentID(parentId)

            End If

            Dim imagelist As ImageList = lvFiles.LargeImageList


            If childs IsNot Nothing Then


                For Each Item As FileChildInfo In childs

                    Try

                        Dim imageKey As String = Item.fileImageID

                        Dim imageFullpath As String = FileManager.GetDocsImagePath() & imageKey & Item.ImageUpdateDate

                        If Item.imageExtension = String.Empty Then

                            imageFullpath &= defaultImages(BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل)).imageExtension

                        Else
                            imageFullpath &= Item.imageExtension

                        End If


                        If Not imagelist.Images.ContainsKey(imageKey) Then

                            If Not System.IO.File.Exists(imageFullpath) Then

                                If Item.imageExtension = String.Empty Then

                                    ''نوشتن تصویر پیش فرض

                                    FileManager.GetFileFromBinaryFormat(defaultImages(BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل)).imageLogo, imageFullpath, False, True)

                                Else

                                    BaseForm.ImageManager.WriteImage(imageKey, imageFullpath)

                                End If

                            End If
                            '
                            imagelist.Images.Add(imageKey, Bitmap.FromFile(imageFullpath))

                        End If



                        Dim newItem As New ListViewItem(Item.fileName, imageKey)

                        newItem.SubItems.Add(Item.fileID)

                        newItem.SubItems.Add(Item.fileIsCat)

                        newItem.SubItems.Add(Item.fileType) ' نوع فایل

                        newItem.SubItems.Add(String.Empty) ' fileCaseId

                        newItem.SubItems.Add(Item.fileRelationId) 'RelationID

                        lvFiles.Items.Add(newItem)

                    Catch ex As Exception

                    End Try

                Next

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("BindChilds", ex.ToString(), Me.ParentForm.Text)
        End Try

        SetResultCount()

    End Sub

    Private Function setFileType(ByVal isIncrease As Boolean) As Enums.FileType

        If isIncrease Then

            Select Case ParentInfo.FileType

                Case Enums.FileType.فایل

                    ' If FileDocManager.StructureISNewVersion(ParentInfo.fileId) Then

                    Return Enums.FileType.محتویات_فایل

                    'Else
                    'Return Enums.FileType.پرونده

                    'End If

                Case Enums.FileType.پرونده

                    Return Enums.FileType.محتویات_پرونده

                Case Else

                    If CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.دایرکتوری_اوراق Then

                        Return Enums.FileType.محتویات_اوراق

                    ElseIf CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.دایرکتوری_متفرقه Then
                        Return Enums.FileType.محتویات_متفرقه
                    ElseIf CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.دایرکتوری_مستندات Then
                        Return Enums.FileType.محتویات_مستندات
                    ElseIf CInt(lvFiles.SelectedItems(0).SubItems(3).Text) = Enums.FileType.تعیین_موضوع Then
                        Return Enums.FileType.پرونده
                    End If

            End Select


        Else

            Select Case ParentInfo.FileType

                Case Enums.FileType.فایل

                    Return Enums.FileType.فایل

                Case Enums.FileType.محتویات_فایل

                    Return Enums.FileType.فایل

                Case Enums.FileType.پرونده

                    If FileDocManager.GetFileType(ParentInfo.fileId) = Enums.FileType.تعیین_موضوع Then

                        Return Enums.FileType.محتویات_فایل

                    Else

                        Return Enums.FileType.فایل

                    End If

                Case Enums.FileType.محتویات_اوراق

                    Return Enums.FileType.محتویات_پرونده

                Case Enums.FileType.محتویات_متفرقه

                    Return Enums.FileType.محتویات_پرونده
                Case Enums.FileType.محتویات_مستندات

                    Return Enums.FileType.محتویات_پرونده

                Case Enums.FileType.محتویات_پرونده

                    Return Enums.FileType.پرونده

            End Select

        End If

    End Function

    Private Sub SetForSearch(ByVal ignoreSearch As Boolean)

        If ignoreSearch Then

            ParentInfo = New FileParentInfo

            ParentInfo.fileId = String.Empty

            ParentInfo.FileCaseId = String.Empty

            ParentInfo.FileType = Enums.FileType.فایل  ' تشکیل فایل

            BindChilds(String.Empty)

            SetDesign()

            pnlSearch.Visible = False

            ToolStripCreateCase.Enabled = True

            ClearNavigation()

        Else

            pnlSearch.Visible = True

            pnlLink.Visible = False

            ToolStripCreateCase.Enabled = False

        End If

    End Sub

    Private Sub AddNewItemInListview(ByVal item As FileChildInfo, ByVal isTempItem As String)

        Dim imageKey As String = item.fileImageID

        TempItem = New ListViewItem(item.fileName, imageKey)

        TempItem.SubItems.Add(item.fileID)

        TempItem.SubItems.Add(item.fileIsCat)

        TempItem.SubItems.Add(item.fileType) ' نوع فایل

        ''''
        TempItem.SubItems.Add(String.Empty)

        TempItem.SubItems.Add(String.Empty)

        TempItem.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

        If item.fileType = Enums.FileType.پرونده Then TempItem.SubItems(4).Text = fileCaseId

        Dim index As Integer = lvFiles.Items.Count

        lvFiles.Items.Insert(index, TempItem.Clone())

        If isTempItem Then

            lvFiles.Items(index).BeginEdit()

        Else

            TempItem = Nothing

        End If

    End Sub

    Private Sub Lock(ByVal myItems As ListView.SelectedListViewItemCollection)

        Dim ImageID As String = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده_قفل_شده)

        Dim locker As String = Login.CurrentLogin.CurrentUser.UserID

        For Each item As ListViewItem In myItems

            Try
                If CInt(item.SubItems(3).Text) = Enums.FileType.پرونده Then

                    Dim fId As String = FileDocManager.GetFileCaseID(item.SubItems(1).Text)

                    If UserHasPermission(Login.CurrentLogin.CurrentUser.UserID, fId) Then

                        FileDocManager.UpdateFileLocker(item.SubItems(1).Text, locker, ImageID, Enums.FileType.پرونده_قفل_شده)

                    Else

                        lblMessage.Text = "مجوز دسترسی به پرونده داده نشده است"
                    End If


                End If

            Catch ex As Exception
                ErrorManager.WriteMessage("Lock,SelectedListViewItemCollection", ex.ToString(), Me.ParentForm.Text)
            End Try

        Next

        ''If Not pnlSearch.Visible Then

        BindChilds(ParentInfo.fileId)

        ''  Else
        ''
        '' Search()

        ''' End If


    End Sub

    Private Sub Lock(ByVal myItems() As ListViewItem)

        Dim ImageID As String = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده_قفل_شده)

        Dim locker As String = Login.CurrentLogin.CurrentUser.UserID

        For Each item As ListViewItem In myItems

            Try
                If CInt(item.SubItems(3).Text) = Enums.FileType.پرونده Then

                    Dim fId As String = FileDocManager.GetFileCaseID(item.SubItems(1).Text)

                    If UserHasPermission(Login.CurrentLogin.CurrentUser.UserID, fId) Then

                        FileDocManager.UpdateFileLocker(item.SubItems(1).Text, locker, ImageID, Enums.FileType.پرونده_قفل_شده)

                    Else

                        lblMessage.Text = "مجوز دسترسی به پرونده داده نشده است"
                    End If

                End If

            Catch ex As Exception
                ErrorManager.WriteMessage("Lock,ListViewItem", ex.ToString(), Me.ParentForm.Text)
            End Try

        Next

        ''   If Not pnlSearch.Visible Then

        BindChilds(ParentInfo.fileId)

        ''    Else

        ''    Search()

        '''  End If

    End Sub

    Private Sub Unlock(ByVal myItems As ListView.SelectedListViewItemCollection)

        Dim currentUser As String = Login.CurrentLogin.CurrentUser.UserID

        Dim ImageID As String = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده)

        For Each item As ListViewItem In myItems

            Try

                If CInt(item.SubItems(3).Text) = Enums.FileType.پرونده_قفل_شده Then

                    If FileDocManager.GetFileLocker(item.SubItems(1).Text).custID = currentUser Then

                        If FileCaseManager.IsFileCaseClosed(item.SubItems(1).Text) Then

                            ImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده_مختومه)

                        End If

                        FileDocManager.UpdateFileLocker(item.SubItems(1).Text, String.Empty, ImageID, Enums.FileType.پرونده)

                    End If

                End If


            Catch ex As Exception
                ErrorManager.WriteMessage("Unlock,SelectedListViewItemCollection", ex.ToString(), Me.ParentForm.Text)
            End Try

        Next

        '' ''If Not pnlSearch.Visible Then

        BindChilds(ParentInfo.fileId)

        '' ''Else

        '' ''    Search()

        '' ''End If

    End Sub

    Private Sub Unlock(ByVal myItems() As ListViewItem)

        Dim currentUser As String = Login.CurrentLogin.CurrentUser.UserID

        Dim ImageID As String = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده)

        For Each item As ListViewItem In myItems

            Try
                If CInt(item.SubItems(3).Text) = Enums.FileType.پرونده_قفل_شده Then

                    Dim locker As ContactInfo.ContactInfoReview = FileDocManager.GetFileLocker(item.SubItems(1).Text)

                    If locker IsNot Nothing AndAlso locker.custID = currentUser Then

                        FileDocManager.UpdateFileLocker(item.SubItems(1).Text, String.Empty, ImageID, Enums.FileType.پرونده)

                    Else

                        lblMessage.Text = "پرونده توسط " & locker.custFullName & " قفل شده است . "

                    End If

                End If

            Catch ex As Exception
                ErrorManager.WriteMessage("Unlock,ListViewItem", ex.ToString(), Me.ParentForm.Text)
            End Try

        Next

        ''If Not pnlSearch.Visible Then

        BindChilds(ParentInfo.fileId)

        ''Else

        ''    Search()

        ''End If

    End Sub

    Private Sub AddLink(ByVal myItems As ListView.SelectedListViewItemCollection)


        If myItems.Count > 1 Then
            'پیوند بایستی بیشتر از 2 پرونده باشد
            Dim relationId As String = String.Empty
            Dim itemRelationID As String = String.Empty
            Dim query As New StringBuilder
            Dim isCreateNewID As Boolean = False

            For Each item As ListViewItem In myItems

                itemRelationID = item.SubItems(5).Text

                If relationId = String.Empty AndAlso itemRelationID <> String.Empty Then
                    relationId = itemRelationID
                End If
                query.AppendLine("UPDATE    files   SET   fileRelationId ={0}  where fileID ='" & item.SubItems(1).Text & "';")

                If Not (isCreateNewID) AndAlso itemRelationID <> String.Empty AndAlso relationId <> itemRelationID Then
                    'New RelationID
                    relationId = FileDocManager.GetMaxRelationId()

                    isCreateNewID = True

                End If

            Next
            If relationId = String.Empty Then
                'New RelationID
                relationId = FileDocManager.GetMaxRelationId()
            End If

            Try
                FileDocManager.UpdateRelation(String.Format(query.ToString, relationId))

            Catch ex As Exception
                ErrorManager.WriteMessage("AddLink", ex.ToString(), Me.ParentForm.Text)
            End Try

            BindChilds(ParentInfo.fileId)

        End If

    End Sub

    Private Sub DelLink(ByVal myItems As ListView.SelectedListViewItemCollection)

        Try

            For Each item As ListViewItem In myItems


                FileDocManager.DelRelation(item.SubItems(1).Text)

            Next

            BindChilds(ParentInfo.fileId)

        Catch ex As Exception
            ErrorManager.WriteMessage("DelLink", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub AddLink(ByVal myItems() As ListViewItem)

        If myItems.Length > 1 Then
            'پیوند بایستی بیشتر از 2 پرونده باشد
            Dim relationId As String = String.Empty
            Dim itemRelationID As String = String.Empty
            Dim query As New StringBuilder
            Dim isCreateNewID As Boolean = False

            For Each item As ListViewItem In myItems

                itemRelationID = item.SubItems(5).Text

                If relationId = String.Empty AndAlso itemRelationID <> String.Empty Then
                    relationId = itemRelationID
                End If
                query.AppendLine("UPDATE    files   SET               fileRelationId ={0}  where fileID ='" & item.SubItems(1).Text & "';")

                If Not (isCreateNewID) AndAlso itemRelationID <> String.Empty AndAlso relationId <> itemRelationID Then
                    'New RelationID
                    relationId = FileDocManager.GetMaxRelationId()

                    isCreateNewID = True

                End If

            Next
            If relationId = String.Empty Then
                'New RelationID
                relationId = FileDocManager.GetMaxRelationId()
            End If

            Try
                FileDocManager.UpdateRelation(String.Format(query.ToString, relationId))
            Catch ex As Exception
                ErrorManager.WriteMessage("AddLink,ListViewItem", ex.ToString(), Me.ParentForm.Text)
            End Try

            BindChilds(ParentInfo.fileId)

        End If

    End Sub

    Private Sub DelLink(ByVal myItems() As ListViewItem)

        For Each item As ListViewItem In myItems


            FileDocManager.DelRelation(item.SubItems(1).Text)

        Next

        BindChilds(ParentInfo.fileId)

    End Sub

    Private Sub BindSearchControls()
        Try
            cmbFileSearch.Items.Clear()

            Dim col As Setting.SettingCollection = ContactInfo.ContactInfoManager.GetAllContactType()
            Dim s As New Setting.Setting
            s.settingName = "همه موارد"
            s.settingValue = "10"
            col.Add(s)

            Dim s1 As New Setting.Setting
            s1.settingName = "شماره پرونده"
            s1.settingValue = "11"
            col.Add(s1)

            Dim s2 As New Setting.Setting
            s2.settingName = "شماره قضایی"
            s2.settingValue = "12"
            col.Add(s2)


            cmbFileSearch.DataSource = col
            cmbFileSearch.DisplayMember = "settingName"
            cmbFileSearch.ValueMember = "settingValue"

            cmbFileSearch.SelectedValue = "11"


        Catch ex As Exception

        End Try

    End Sub

    'abbas commented
    'Private Sub BindSearchControls()

    '    Try
    '        pnlSearch.Visible = False

    '        cmbMovakel.DataSource = ContactInfo.ContactInfoManager.GetUsersByRole(ContactInfo.Enums.RoleType.موکل, True)
    '        cmbKarshenas.DataSource = ContactInfo.ContactInfoManager.GetUsersByRole(ContactInfo.Enums.RoleType.کارشناس, True)
    '        cmbVakil.DataSource = ContactInfo.ContactInfoManager.GetUsersByRole(ContactInfo.Enums.RoleType.وکیل, True)

    '        If cmbMovakel.Items.Count > 0 Then cmbMovakel.SelectedValue = "0"
    '        If cmbKarshenas.Items.Count > 0 Then cmbKarshenas.SelectedValue = "0"
    '        If cmbVakil.Items.Count > 0 Then cmbVakil.SelectedValue = "0"

    '        txtSubject.AutoCompleteCustomSource = FileCaseManager.GetAllFileCaseSubjects()

    '    Catch ex As Exception
    '        ErrorManager.WriteMessage("BindSearchControls", ex.ToString(), Me.ParentForm.Text)
    '    End Try

    'End Sub

    Private Function CreateFile(ByVal item As ListViewItem, ByVal docname As String, ByVal cutsid As String, Optional ByVal parentId As String = "") As Boolean

        Try

            Dim newFile As New Files

            newFile.fileImageID = item.ImageKey

            newFile.fileChilds = parentId

            If parentId = "" Then newFile.fileChilds = ParentInfo.fileId

            newFile.fileIsCat = item.SubItems(2).Text

            newFile.fileName = docname

            newFile.FileType = item.SubItems(3).Text

            newFile.fileID = item.SubItems(1).Text

            If cutsid = "0" Then
                cutsid = FileDocManager.GetFileCustId(newFile.fileChilds)
                If cutsid = String.Empty Then
                    cutsid = "0"
                End If
            End If

            newFile.fileCustID = cutsid


            Try
                newFile.fileCaseID = item.SubItems(4).Text
            Catch ex As Exception
                newFile.fileCaseID = String.Empty
            End Try

            If FileDocManager.CreateFile(newFile) Then

                'For Tree
                If ParentInfo.fileId = String.Empty Then

                    UpdateTree(newFile.fileID, newFile.fileName, True)

                Else

                    UpdateTree(treeParentId, Nothing, True)

                End If

                Return True


            End If

            Return False

        Catch ex As Exception
            ErrorManager.WriteMessage("CreateFile", ex.ToString(), Me.ParentForm.Text)

            Return False

        End Try

    End Function

    Private Function CreateFile_Moshavere(ByVal item As ListViewItem, ByVal docname As String, ByVal cutsid As String, Optional ByVal parentId As String = "") As Boolean

        Try

            Dim newFile As New Files

            newFile.fileImageID = item.ImageKey

            newFile.fileChilds = parentId

            If parentId = "" Then newFile.fileChilds = ParentInfo.fileId

            newFile.fileIsCat = item.SubItems(2).Text

            newFile.fileName = docname

            newFile.FileType = item.SubItems(3).Text

            newFile.fileID = item.SubItems(1).Text

            If cutsid = "0" Then
                cutsid = FileDocManager.GetFileCustId(newFile.fileChilds)
                If cutsid = String.Empty Then
                    cutsid = "0"
                End If
            End If

            newFile.fileCustID = cutsid


            Try
                newFile.fileCaseID = item.SubItems(4).Text
            Catch ex As Exception
                newFile.fileCaseID = String.Empty
            End Try

            If FileDocManager.CreateFile(newFile) Then


            End If

            Return False

        Catch ex As Exception
            ErrorManager.WriteMessage("CreateFile", ex.ToString(), Me.ParentForm.Text)

            Return False

        End Try

    End Function

    Private Sub AddFile(ByVal files As String())

        SyncLock (Me)

            Dim sLoading As showLoadinHandler

            sLoading = New showLoadinHandler(AddressOf showLoading)

            sLoading.Invoke(True)

            Dim extension As String

            Dim name As String

            For Each Item As String In files

                extension = System.IO.Path.GetExtension(Item)

                name = System.IO.Path.GetFileName(Item)

                If extension <> String.Empty AndAlso IsTureFile(extension) Then

                    AddFileDocs(Item)

                End If

            Next

            sLoading.Invoke(False)

        End SyncLock

        SetResultCount()

    End Sub

    Private Function IsTureFile(ByVal extension As String)

        extension = extension.ToLower()

        If extension = ".txt" OrElse extension = ".doc" OrElse extension = ".docx" OrElse extension = ".dot" OrElse extension = ".dotx" OrElse extension = ".jpg" _
        OrElse extension = ".gif" OrElse extension = ".png" OrElse extension = ".bmp" OrElse extension = ".tif" OrElse extension = ".tiff" OrElse extension = ".jpeg" _
         OrElse extension = ".pdf" OrElse extension = ".xls" OrElse extension = ".xlsx" Then

            Return True

        End If

        Return False

    End Function

    Private Function AddFileDocs(ByVal item As String) As Boolean

        Try
            ErrorManager.WriteMessage("من", item.ToString(), "")
            Dim doc As New FileDocs

            doc.fileDocName = System.IO.Path.GetFileNameWithoutExtension(item)

            doc.fileDocExtension = System.IO.Path.GetExtension(item)


            Try
                If Not String.IsNullOrEmpty(FileDocManager.IsExistFileDocName(ParentInfo.fileId, doc.fileDocExtension, doc.fileDocName)) Then

                    Exit Function

                End If

            Catch ex As Exception

                Exit Function

            End Try

            doc.fileDocID = Guid.NewGuid().ToString()

            doc.fileCaseID = ParentInfo.FileCaseId

            doc.fileDocDate = DateManager.GetCurrentShamsiDateInNumericFormat()

            doc.fileDocTime = DateManager.GetCurrentTime()

            doc.fileID = ParentInfo.fileId

            doc.fileDocImageID = BaseForm.ImageManager.GetDefaultIcon_TempDocsTable(doc.fileDocExtension)

            If doc.fileDocExtension = ".doc" OrElse doc.fileDocExtension = ".docx" OrElse doc.fileDocExtension = ".doc" OrElse doc.fileDocExtension = ".dot" OrElse doc.fileDocExtension = ".txt" Then

                Dim wordApp As Word.ApplicationClass = New ApplicationClass

                Dim file As Object = item

                Dim Nothingobj As Object = System.Reflection.Missing.Value

                Dim objectFormat As Word.WdSaveFormat = WdSaveFormat.wdFormatPDF

                Dim docWord As Document = wordApp.Documents.Open(file, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj)

                doc.fileDocContent = docWord.Content.Text

                docWord.Close()

                wordApp.Quit()

                docWord = Nothing

                wordApp = Nothing

            End If

            doc.DocFullPath = item

            If FileDocManager.AddFileDoc(doc) Then

                Dim item1 As New ListViewItem(doc.fileDocName, doc.fileDocImageID)

                item1.SubItems.Add(doc.fileDocID)

                item1.SubItems.Add(0)

                item1.SubItems.Add(ParentInfo.FileType)

                item1.SubItems.Add(doc.fileDocExtension)

                lvFiles.Items.Add(item1)

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("AddFileDocs", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Function

    Private Function AddEmptyFileDocs() As Boolean

        Try

            Dim doc As New FileDocs

            doc.fileDocName = OraghItem.Text

            'doc.fileDocExtension = System.IO.Path.GetExtension(FileManager.GetEmptyWordPath())
            doc.fileDocExtension = System.IO.Path.GetExtension(scanImage)

            doc.fileDocID = OraghItem.SubItems(1).Text

            doc.fileCaseID = ParentInfo.FileCaseId

            doc.fileDocDate = DateManager.GetCurrentShamsiDateInNumericFormat()

            doc.fileDocTime = DateManager.GetCurrentTime()

            doc.fileID = ParentInfo.fileId

            doc.fileDocImageID = BaseForm.ImageManager.GetDefaultIcon_TempDocsTable(doc.fileDocExtension)

            ' doc.DocFullPath = FileManager.GetEmptyWordPath()

            doc.DocFullPath = scanImage

            Return FileDocManager.AddFileDoc(doc)

        Catch ex As Exception

            ErrorManager.WriteMessage("AddEmptyFileDocs", ex.ToString(), Me.ParentForm.Text)

            Return False

        End Try

    End Function

    Private Function TransferParentFileToServer(ByVal parentId) As Boolean

        Dim pName As String = FileDocManager.GetFileNameByID(parentId)

        Dim fileIsNew As Boolean = False

        Select Case LockDocs.DestinationManager.IsExistsParentFile(parentId, pName)

            Case 0
                'یعنی فایل تشکیل نشده است
                fileIsNew = True

            Case 1
                ' فایل قبلا تشکیل شده است
                fileIsNew = False

            Case 2

                RaiseEvent ShowMessageBox("فایل تازه تشکیل داده شده قبلا در کامپیوتر مقصد تشکیل شده است، آیا می خواهید پرونده در همان فایل ایجاد شود", "ارسال پرونده")

                ' نام فایل تکراری است
                If YesClicked Then
                    'تغییر Guid در مبدا
                    FileDocManager.UpdateParentId(ParentInfo.fileId, LockDocs.DestinationManager.IsExistFileName(pName, String.Empty))

                    fileIsNew = False

                Else

                    lblMessage.Text = "لطفا نام فایل را تغییر دهید"

                    Return False

                End If

        End Select

        If fileIsNew Then

            'ثبت فایل
            Dim f As Files = FileDocManager.GetFileAllInfoByID(ParentInfo.fileId)

            '1) بررسی ثبت فیلد cust id
            f.FileLocker = Guid.Empty.ToString

            If f.fileCustID = Guid.Empty.ToString() OrElse InsertContactinfoTable(f.fileCustID) = String.Empty Then

                LockDocs.DestinationManager.CreateFile(f)

            Else

                f.fileCustID = Guid.Empty.ToString

                f.fileImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل)

                LockDocs.DestinationManager.CreateFile(f)

            End If

        End If

        Dim id As String = LockDocs.DestinationManager.IsExistFileName(lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).Text, parentId)
        'آیا نام پرونده تکراری است
        If id <> String.Empty And id <> lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).SubItems(1).Text Then

            lblMessage.Text = "نام پرونده تکراری است"

            Return False

        End If

        Return True

    End Function

    Private Function TransferParentFileToServer_new2(ByVal parentId As String, ByVal fileId As String) As Boolean

        ' if current fileId exists fileId = currentFileCase
        Dim ft As Int16? = LockDocs.DestinationManager.GetFileType(fileId)

        If ft.HasValue Then

            Select Case ft

                Case -1

                    lblMessage.Text = "در حال حاضر امکان انتقال پرونده وجود ندارد. "

                    Return False

                Case Else

                    If ft = Enums.FileType.پرونده OrElse ft = Enums.FileType.پرونده_قفل_شده Then

                        Return True

                    Else

                        lblMessage.Text = "پرونده قابل انتقال نیست. "

                        Return False

                    End If

            End Select


        Else

            lblMessage.Text = "پرونده قابل انتقال نیست. "

            Return False

            ' '' ''Else

            ' '' ''    Dim pt As Enums.FileType = FileDocManager.GetFileType(parentId)

            ' '' ''    If pt = Enums.FileType.فایل Then

            ' '' ''        lblMessage.Text = "امکان انتقال پرونده به دلیل ساختار قدیمی پرونده وجود ندارد."

            ' '' ''        Return False

            ' '' ''    End If


            ' '' ''    'if parent Exists
            ' '' ''    If LockDocs.DestinationManager.IsExistsFileByID(parentId) Then

            ' '' ''        Return True

            ' '' ''    Else
            ' '' ''        'موضوع دعوی وجود ندارد
            ' '' ''        'آیا فایل وجود دارد
            ' '' ''        'تعیین نوع پدر

            ' '' ''        Dim pparentID As String = FileDocManager.GetFileParentId(parentId)

            ' '' ''        If pparentID = String.Empty Then

            ' '' ''            lblMessage.Text = "امکان انتقال پرونده به دلیل طبقه بندی نادرست، وجود ندارد."

            ' '' ''            Return False

            ' '' ''        Else

            ' '' ''            If LockDocs.DestinationManager.IsExistsFileByID(pparentID) Then

            ' '' ''                'ایجاد تعیین موضوع دعوی
            ' '' ''                Return CreateSubjectFolder_Transfer(parentId, pparentID)

            ' '' ''            Else

            ' '' ''                If CreateFileFolder_Transfer(pparentID) Then

            ' '' ''                    CreateSubjectFolder_Transfer(parentId, pparentID)

            ' '' ''                    Return False

            ' '' ''                End If



            ' '' ''            End If

            ' '' ''        End If


            ' '' ''        lblMessage.Text = "امکان انتقال پرونده به دلیل طبقه بندی نادرست، وجود ندارد."

            ' '' ''        Return False

            ' '' ''    End If


        End If

    End Function

    Private Function CreateFileFolder_Transfer(ByVal fileid) As Boolean

        Dim c As String = LockDocs.DestinationManager.GetFileCustId(fileid)

        If c = String.Empty Then

            lblMessage.Text = "امکان انتقال پرونده وجود ندارد."

        Else

            If String.IsNullOrEmpty(FileDocManager.IsExistFileName(c, fileid)) Then


            End If

        End If

    End Function

    Private Function TransferParentFileToServer_new(ByVal parentId As String, ByVal fileId As String) As Boolean

        ' if current fileId exists fileId = currentFileCase
        Dim ft As Int16? = LockDocs.DestinationManager.GetFileType(fileId)

        If ft.HasValue Then

            Select Case ft

                Case -1

                    lblMessage.Text = "در حال حاضر امکان انتقال پرونده وجود ندارد. "

                    Return False

                Case Else

                    If ft = Enums.FileType.پرونده OrElse ft = Enums.FileType.پرونده_قفل_شده Then

                        'انتقال بدون حذف فایلها در files table
                        Return True

                    Else

                        lblMessage.Text = "پرونده قابل انتقال نیست. "

                        Return False

                    End If

            End Select

        Else
            'if parent Exists
            If LockDocs.DestinationManager.IsExistsFileByID(parentId) Then

                '?????????????????انتقال با ایجاد فایلها در files table
                Return True

            Else
                'تعیین نوع پدر
                Dim pt As Enums.FileType = FileDocManager.GetFileType(parentId)

                If pt = Enums.FileType.فایل Then

                    Return TransferParentFileToServer(parentId)

                ElseIf pt = Enums.FileType.تعیین_موضوع Then

                    Dim pparentID As String = FileDocManager.GetFileParentId(parentId)

                    If pparentID = String.Empty Then

                        lblMessage.Text = "امکان انتقال پرونده به دلیل طبقه بندی نادرست، وجود ندارد."

                        Return False

                    Else

                        If LockDocs.DestinationManager.IsExistsFileByID(pparentID) Then

                            'ایجاد تعیین موضوع دعوی
                            Return CreateSubjectFolder_Transfer(parentId, pparentID)

                            '??????????????????انتقال تمامی محتویات فایل

                        Else

                            'ایجاد فایل
                            'ایجاد تعیین موضوع دعوی
                            'انتقال تمامی محتویات فایل

                        End If

                    End If

                Else

                    lblMessage.Text = "امکان انتقال پرونده به دلیل طبقه بندی نادرست، وجود ندارد."

                    Return False

                End If


            End If

        End If

    End Function

    Private Function CreateSubjectFolder_Transfer(ByVal parentId As String, ByVal pParentId As String) As Boolean

        Dim pName As String = FileDocManager.GetFileNameByID(parentId)

        Dim fileIsNew As Boolean = False

        Dim existId As String = LockDocs.DestinationManager.IsExistFileName(pName, pParentId)

        If String.IsNullOrEmpty(existId) Then

            fileIsNew = True
        Else

            RaiseEvent ShowMessageBox("موضوع تازه تشکیل داده شده قبلا در کامپیوتر مقصد ایجاد شده است، آیا می خواهید پرونده به همان موضوع انتقال یابد؟", "ارسال پرونده")

            ' نام فایل تکراری است
            If YesClicked Then
                'تغییر Guid در مبدا
                FileDocManager.UpdateParentId(parentId, existId)

                fileIsNew = False

            Else

                lblMessage.Text = "لطفا عنوان موضوع را تغییر دهید"

                Return False

            End If


        End If

        If fileIsNew Then

            'ثبت موضوع
            Dim f As Files = FileDocManager.GetFileAllInfoByID(parentId)

            '1) بررسی ثبت فیلد cust id
            f.FileLocker = Guid.Empty.ToString

            LockDocs.DestinationManager.CreateFile(f)


        End If

        Dim id As String = LockDocs.DestinationManager.IsExistFileName(lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).Text, parentId)
        'آیا نام پرونده تکراری است
        If id <> String.Empty And id <> lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).SubItems(1).Text Then

            lblMessage.Text = "نام پرونده تکراری است"

            Return False

        End If

        Return True

    End Function

    '' ''Private Function CreateSubjectFolder_File(ByVal parentId As String, ByVal pparentId As String) As Boolean

    '' ''    'آیا برای custId فایلی تشکیل شده است

    '' ''    Dim pCustId As String = FileDocManager.GetFileCustId(pparentId)
    '' ''    If pCustId = String.Empty Then

    '' ''        lblMessage.Text = "به دلیل طبقه بندی نادرست امکان انتقال پرونده وجود ندارد."

    '' ''        Return False

    '' ''    Else

    '' ''    End If

    '' ''    Dim fId As String = LockDocs.DestinationManager.SelFileIdByCustID(pCustId)

    '' ''    If fId = String.Empty Then

    '' ''        'تشکیل فایل
    '' ''        'ولی امکان ایجاد نام فایل یکسان وجود ندارد
    '' ''    Else


    '' ''    End If
    '' ''    Dim prefileName As String = FileDocManager.GetFileNameByCustId(c.custID)

    '' ''    If Not String.IsNullOrEmpty(prefileName) Then

    '' ''        lblMessage.Text = "برای موکل مورد نظر قبلا فایلی با نام " & prefileName & ".تشکیل شده است "

    '' ''        Exit Function

    '' ''    End If

    '' ''    Dim pName As String = FileDocManager.GetFileNameByID(parentId)

    '' ''    Dim fileIsNew As Boolean = False

    '' ''    Select Case LockDocs.DestinationManager.IsExistsParentFile(parentId, pName)

    '' ''        Case 0
    '' ''            'یعنی فایل تشکیل نشده است
    '' ''            fileIsNew = True

    '' ''        Case 1
    '' ''            ' فایل قبلا تشکیل شده است
    '' ''            fileIsNew = False

    '' ''        Case 2

    '' ''            RaiseEvent ShowMessageBox("فایل تازه تشکیل داده شده قبلا در کامپیوتر مقصد تشکیل شده است، آیا می خواهید پرونده در همان فایل ایجاد شود", "ارسال پرونده")

    '' ''            ' نام فایل تکراری است
    '' ''            If YesClicked Then
    '' ''                'تغییر Guid در مبدا
    '' ''                FileDocManager.UpdateParentId(ParentInfo.fileId, LockDocs.DestinationManager.IsExistFileName(pName, String.Empty))

    '' ''                fileIsNew = False

    '' ''            Else

    '' ''                lblMessage.Text = "لطفا نام فایل را تغییر دهید"

    '' ''                Return False

    '' ''            End If

    '' ''    End Select

    '' ''    If fileIsNew Then

    '' ''        'ثبت فایل
    '' ''        Dim f As Files = FileDocManager.GetFileAllInfoByID(ParentInfo.fileId)

    '' ''        '1) بررسی ثبت فیلد cust id
    '' ''        f.FileLocker = Guid.Empty.ToString

    '' ''        If f.fileCustID = Guid.Empty.ToString() OrElse InsertContactinfoTable(f.fileCustID) = String.Empty Then

    '' ''            LockDocs.DestinationManager.CreateFile(f)

    '' ''        Else

    '' ''            f.fileCustID = Guid.Empty.ToString

    '' ''            f.fileImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل)

    '' ''            LockDocs.DestinationManager.CreateFile(f)

    '' ''        End If

    '' ''    End If

    '' ''    Dim id As String = LockDocs.DestinationManager.IsExistFileName(lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).Text, parentId)
    '' ''    'آیا نام پرونده تکراری است
    '' ''    If id <> String.Empty And id <> lvFiles.Items(lvFiles.SelectedItems.Item(0).Index).SubItems(1).Text Then

    '' ''        lblMessage.Text = "نام پرونده تکراری است"

    '' ''        Return False

    '' ''    End If

    '' ''    Return True

    '' ''End Function

    Private Function InsertContactinfoTable(ByVal custId As String) As String

        Dim c As ContactInfo.Contact = ContactInfo.ContactInfoManager.GetContactByID(custId)

        If c IsNot Nothing Then

            c.custIsSysUser = False

            c.custPassword = String.Empty

            c.custSaltkey = String.Empty

            c.custUserName = String.Empty

            '----مشخصات کاربری قابل انتقال نیست

            If Not LockDocs.DestinationManager.IsExistContactById(c.custID) Then

                Try

                    LockDocs.DestinationManager.AddImage(BaseForm.ImageManager.GetImageByID(c.custID))

                    LockDocs.DestinationManager.AddContact(c)

                Catch ex As Exception

                    Return " کاربر با نام  " & c.custFullName & " ثبت نشد ، لطفا در سروربه صورت دستی ثبت نمایید. "

                End Try

            End If

        End If

        Return String.Empty

    End Function

    Dim l As Loading

    Private Delegate Sub showLoadinHandler(ByVal show As Boolean)

    Private Sub showLoading(ByVal show As Boolean)

        If show Then

            SyncLock (Me)

                l.Show()

            End SyncLock

        Else

            SyncLock (Me)

                If l IsNot Nothing Then

                    l.Hide()

                    l.Dispose()



                End If

            End SyncLock


        End If

    End Sub

    Private Sub BindFileDocChilds(ByVal parentId As String)

        lvFiles.Clear()

        SetDesign()

        Dim childs As FileDocsChildInfoCollection = FileDocManager.GetFileDocsChildsByFileID(parentId)

        If childs IsNot Nothing Then

            For Each Item As FileDocsChildInfo In childs

                Dim newItem As New ListViewItem(Item.fileDocName, Item.fileDocImageID)

                newItem.ImageKey = Item.fileDocImageID

                newItem.SubItems.Add(Item.fileDocID)

                newItem.SubItems.Add(0)

                newItem.SubItems.Add(ParentInfo.FileType) ' نوع فایل
                newItem.SubItems.Add(Item.fileDocExtension)
                lvFiles.Items.Add(newItem)

            Next

        End If

        SetResultCount()

    End Sub

    Public Function SetSalahiyat(ByVal areaID As String, ByVal subArea As String) As String

        Dim str As String = String.Empty

        Try


            If areaID <> String.Empty Then

                Dim co As Competencys.Competency = Competencys.CompetencyManager.GetCompetencyByLibID(areaID)

                If co IsNot Nothing Then

                    str = co.tsState

                    If co.tsProvince <> String.Empty Then

                        str &= " - " & co.tsProvince

                    End If

                    If co.tsName <> String.Empty Then

                        str &= " - " & " حوزه : " & co.tsName

                    End If

                    If subArea <> String.Empty Then

                        Dim br As Competencys.CompetencyBranchReview = Competencys.CompetencyManager.GetToolsSalahiatBranchById(subArea)

                        If br IsNot Nothing Then


                            If br.tsbName <> String.Empty Then

                                str &= " - " & CType(br.tsbType, Competencys.Enums.tsbType).ToString() & " : " & br.tsbName

                            End If

                        End If

                    End If

                End If

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("SetSalahiyat", ex.ToString(), Me.ParentForm.Text)
            str = String.Empty

        End Try


        Return str

    End Function

    Private Sub writeTextFile(ByVal content As ArrayList, ByVal filepath As String)

        Try

            Dim sw As StreamWriter
            Dim _File As String = filepath

            ' Create a Text File
            'Dim fs As FileStream = Nothing
            If (Not File.Exists(_File)) Then
                sw = File.CreateText(_File)
                ' fs = File.Create(_File)
                Using sw
                End Using
            End If

            ' Write to a Text File (append)
            If File.Exists(_File) Then

                ' sw = File.AppendText(_File)

                Using sw2 = New StreamWriter(_File)

                    For index As Integer = 0 To content.Count - 1

                        sw2.WriteLine(content(index))
                    Next

                    sw2.Flush()
                    sw2.Close()

                End Using

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("writeTextFile", ex.ToString(), Me.ParentForm.Text)
        End Try



    End Sub

    Private Function CreatePdfFile() As String

        lblMessage.Text = "لطفا چند لحظه صبر نمایید..."
        Me.Refresh()

        Dim l As New ArrayList

        Dim hasPermission As Boolean = False


        l.Add(New String() {"1", "فرم ها"})
        l.Add(New String() {"2", "محتویات پرونده"})
        l.Add(New String() {"3", "متفرقه"})
        l.Add(New String() {"4", "مشخصات پرونده"})

        If Login.CurrentLogin.CurrentUser.IsAdmin OrElse FileParties.FilePartiesManager.UserHasFinanceAccess(ParentInfo.FileCaseId, Login.CurrentLogin.CurrentUser.UserID, FileParties.Enums.FileCaseRole.وکیل) Then

            hasPermission = True
            l.Add(New String() {"5", "اطلاعات مالی"})

        End If
        '
        'ایجاد پرونده مرتبط
        Dim f As New WFControls.CS.BaseUc.frmPropertyMsg(l, "تجمیع پرونده", "تجمیع پرونده")

        f.ShowDialog()

        copyItem = f.GetResult()

        If copyItem Is Nothing OrElse Not f.IsCheckedAtLeast Then

            Return String.Empty

        End If

        Dim filepath As String = FileManager.GetTajmiPath()

        Try

            Directory.Delete(filepath, True)

        Catch ex As Exception
            ErrorManager.WriteMessage("CreatePdfFile,part1", ex.ToString(), Me.ParentForm.Text)
        End Try

        Try
            Directory.CreateDirectory(filepath)
        Catch ex As Exception
            ErrorManager.WriteMessage("CreatePdfFile,part2", ex.ToString(), Me.ParentForm.Text)
        End Try

        filepath += "\"


        For Each Item As ListViewItem In lvFiles.Items

            ' Directory
            If Item.SubItems(2).Text Then

                If CInt(Item.SubItems(3).Text) = Enums.FileType.دایرکتوری_اوراق AndAlso copyItem.Item("1") = "True" Then

                    Try
                        If Not Directory.Exists(filepath & "Oragh") Then Directory.CreateDirectory(filepath & "Oragh")

                        FileDocManager.CreatTajmii(Item.SubItems(1).Text, filepath & "Oragh\")

                    Catch ex As Exception

                    End Try


                ElseIf CInt(Item.SubItems(3).Text) = Enums.FileType.دایرکتوری_مستندات AndAlso copyItem.Item("2") = "True" Then

                    Try
                        If Not Directory.Exists(filepath & "Documentation") Then Directory.CreateDirectory(filepath & "Documentation")

                        FileDocManager.CreatTajmii(Item.SubItems(1).Text, filepath & "Documentation\")

                    Catch ex As Exception

                    End Try

                ElseIf CInt(Item.SubItems(3).Text) = Enums.FileType.دایرکتوری_متفرقه AndAlso copyItem.Item("3") = "True" Then

                    Try
                        If Not Directory.Exists(filepath & "Other") Then Directory.CreateDirectory(filepath & "Other")

                        FileDocManager.CreatTajmii(Item.SubItems(1).Text, filepath & "Other\")


                    Catch ex As Exception

                    End Try

                End If

            Else

                Select Case Item.SubItems(3).Text

                    Case Enums.FileType.مشخصات_پرونده

                        If (copyItem.Item("4") = "True") Then



                            'ایجاد فایل مشخصات پرونده
                            Dim fc As FileCase = FileCaseManager.GetFileCaseByID(ParentInfo.FileCaseId)

                            Dim str As New ArrayList

                            str.Add("شماره پرونده در سیستم : " & fc.fileCaseNumberInSystem)
                            str.Add("شماره پرونده در مرجع قضایی : " & fc.fileCaseNumberInCourt & "/" & fc.fileCaseNumberInBranch & "/" & fc.fileCaseNumberYear)
                            str.Add("شماره پیگیری/رمز عبور : " & fc.fileCasePass)
                            str.Add("وضعیت پرونده : " & IIf(fc.fileCaseCloseDate.HasValue, "مختومه", "جاری"))
                            Dim d As String = fc.fileCaseOpenDate

                            str.Add("تاریخ تشکیل پرونده : " & d.Substring(0, 4) & "/" & d.Substring(4, 2) & "/" & d.Substring(6, 2))

                            If fc.fileCaseCloseDate.HasValue Then

                                d = fc.fileCaseCloseDate

                                str.Add("تاریخ مختومه پرونده : " & d.Substring(0, 4) & "/" & d.Substring(4, 2) & "/" & d.Substring(6, 2))

                            Else

                                str.Add("تاریخ مختومه پرونده : " & fc.fileCaseCloseDate)

                            End If

                            str.Add("موضوع دعوی : " & fc.fileCaseSubject)

                            str.Add("شرح دعوی : " & fc.fileCaseDescription)

                            Dim m As String = String.Empty


                            If fc.fileCaseComplainant = CBool(Enums.FileCaseComplainant.خوانده) Then

                                m = "خوانده"

                            Else

                                m = "خواهان"

                            End If


                            If fc.fileCaseType = CBool(Enums.FileCaseType.کیفری) Then

                                m &= " - " & "کیفری"

                            Else

                                m &= " - " & "حقوقی"

                            End If

                            Select Case fc.fileCaseCat

                                Case Enums.FileCaseCat.عادی

                                    m &= " - " & "عادی"

                                Case Enums.FileCaseCat.تسخیری

                                    m &= " - " & "تسخیری"

                                Case Else

                                    m &= " - " & "معاضدتی"

                            End Select

                            str.Add("مشخصات : " & m)
                            Dim movakel As String = String.Empty
                            Dim davi As String = String.Empty
                            Dim vakil As String = String.Empty
                            Dim karshenas As String = String.Empty

                            Dim parties As FileParties.FilePartiesBaseInfoCollection = FileParties.FilePartiesManager.GetPartiesByFileCaseID(ParentInfo.FileCaseId)

                            For Each p As FileParties.FilePartiesBaseInfo In parties
                                Select Case p.fileCaseRole

                                    Case FileParties.Enums.FileCaseRole.خوانده
                                        davi += ";" & p.custFullName

                                    Case FileParties.Enums.FileCaseRole.خواهان
                                        movakel += ";" & p.custFullName
                                    Case FileParties.Enums.FileCaseRole.کارشناس
                                        karshenas += ";" & p.custFullName

                                    Case FileParties.Enums.FileCaseRole.وکیل
                                        vakil += ";" & p.custFullName
                                End Select
                            Next

                            If movakel <> String.Empty Then movakel = movakel.Substring(1)
                            If davi <> String.Empty Then davi = davi.Substring(1)
                            If vakil <> String.Empty Then vakil = vakil.Substring(1)
                            If karshenas <> String.Empty Then karshenas = karshenas.Substring(1)

                            str.Add("موکل : " & movakel)
                            str.Add("طرف دعوی : " & davi)
                            str.Add("وکیل :" & vakil)
                            str.Add("کارشناس :" & karshenas)
                            str.Add("مرجع قضایی :" & SetSalahiyat(fc.fileCaseAreaID, fc.fileCaseSubAreaID))
                            'str.Add("حوزه قضایی :" & FileCaseArea.AreaManger.GetAreaNameByID(fc.fileCaseSubAreaID))
                            'str.Add("شعبه :" & FileCaseArea.AreaManger.GetAreaNameByID(fc.fileCaseBranchID))

                            ' '' ''str.Add("آخرین اقدامات" & "------------------------------------------------")

                            ' '' ''Dim text() As String = fc.fileCaseLastAction.Split(New String() {";"""}, StringSplitOptions.RemoveEmptyEntries)

                            ' '' ''For index As Integer = 0 To CInt(text.Length / 2) - 1

                            ' '' ''    str.Add(text(2 * index) & " : " & text(2 * index + 1))

                            ' '' ''Next


                            str.Add("سایر توضیحات : " & fc.fileCaseOtherDescription)

                            Dim result As String = String.Empty

                            '' ''If fc.fileCaseResult.HasValue Then

                            '' ''    If fc.fileCaseResult = 0 Then

                            '' ''        result = " قرار "


                            '' ''    Else

                            '' ''        result = " حکم "

                            '' ''    End If

                            '' ''End If
                            ''abbas
                            '' '' '' ''If fc.filecaseResultDetail <> String.Empty Then

                            '' '' '' ''    If fc.filecaseResultDetail = 0 Then
                            '' '' '' ''        'result &= " - " & " له "
                            '' '' '' ''        result &= " له "
                            '' '' '' ''    Else
                            '' '' '' ''        'result &= " - " & " علیه "
                            '' '' '' ''        result &= " علیه "
                            '' '' '' ''    End If

                            '' '' '' ''End If

                            '' ''If fc.fileCaseGhararType <> String.Empty Then

                            '' ''    result &= " - " & " شرح: " & fc.fileCaseGhararType.ToString

                            '' ''End If

                            '' ''If fc.fileCaseCost.HasValue Then

                            '' ''    result &= " - " & " میزان محکوم به : " & fc.fileCaseCost.ToString()

                            '' ''End If

                            ''''''' str.Add("نتیجه پرونده :" & result)
                            str.Add("نتیجه پرونده :" & fc.filecaseResultDetail)
                            Try
                                If Not Directory.Exists(filepath & "FileCase") Then Directory.CreateDirectory(filepath & "FileCase")
                                writeTextFile(str, filepath & "FileCase\filecase.txt")

                            Catch ex As Exception

                            End Try

                        End If

                    Case Enums.FileType.مالی
                        ' نوشتن فایل مالی

                        If (hasPermission AndAlso copyItem.Item("5") = "True") Then

                            Try

                                If Not Directory.Exists(filepath & "Mali") Then Directory.CreateDirectory(filepath & "Mali")

                                Shaxes.FinanceManager.SearchFinanceSelByFileCaseID(ParentInfo.FileCaseId, filepath & "Mali\mali.xls")

                            Catch ex As Exception

                            End Try

                        End If

                End Select

            End If


        Next

        Return PdfManager.CreatePdfFormFiles(filepath)

    End Function

    Public Sub ShowSpecificFileCase(ByVal fileId As String)
        Try
            ParentInfo.fileId = FileDocManager.GetFileParentId(fileId)
            ParentInfo.FileType = Enums.FileType.پرونده
            BindChilds(ParentInfo.fileId)

            For Each Item As ListViewItem In lvFiles.Items

                If Item.SubItems(1).Text = fileId Then

                    lvFiles.Focus()
                    lvFiles.Items(Item.Index).Selected = True

                    Return

                End If

            Next
        Catch ex As Exception
            ErrorManager.WriteMessage("ShowSpecificFileCase", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub createDefaultDirectories(ByVal parentId As String, ByVal fileCaseId As String, ByVal curItem As ListViewItem)

        Try
            Dim preFileId As String = String.Empty
            Dim fc As FileCase

            If copyItem IsNot Nothing Then preFileId = copyItem.Item(copyItem.Count.ToString)

            If preFileId <> String.Empty Then

                fc = FileCaseManager.GetFileCaseByID(FileDocManager.GetFileCaseID(preFileId))

            End If
            '1) دایرکتوری اوراق

            Dim item1 As New ListViewItem()

            item1.Text = "فرم ها"

            item1.SubItems.Add(Guid.NewGuid().ToString())

            item1.SubItems.Add(1)

            item1.SubItems.Add(Enums.FileType.دایرکتوری_اوراق)

            item1.SubItems.Add(fileCaseId)

            item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.دایرکتوری_اوراق)

            CreateFile(item1, item1.Text, 0, parentId)

            If preFileId <> String.Empty AndAlso copyItem.Item("2") = "True" Then

                Dim fileDocIds As ArrayList = FileDocManager.GetFileDocIdsByFileID(FileDocManager.GetFileIdByTypeAndFilecaseID(Enums.FileType.دایرکتوری_اوراق, fc.fileCaseID))

                For Each Item As String In fileDocIds

                    Try

                        Dim file As String = FileDocManager.WriteFile(Item)

                        FileDocManager.AddFileDocByRelation(Guid.NewGuid().ToString(), item1.SubItems(1).Text, fileCaseId, Item, file)

                    Catch ex As Exception

                    End Try

                Next

            Else

                FileCaseManager.WriteDefaultFiles(Enums.FileCaseStep.همه, False, fileCaseId)

                FileCaseManager.WriteDefaultFiles(Enums.FileCaseStep.حقوقی, False, fileCaseId)

            End If




            '2) مشخصات پرونده

            item1.Text = "مشخصات پرونده"

            item1.SubItems(1).Text = Guid.NewGuid().ToString()

            item1.SubItems(2).Text = 0

            item1.SubItems(3).Text = Enums.FileType.مشخصات_پرونده

            item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.مشخصات_پرونده)

            CreateFile(item1, item1.Text, 0, parentId)

            If fileCaseStep = 20 Then ''''for copy

                fileCaseStep = fc.fileCaseStep

            End If

            If preFileId = String.Empty OrElse copyItem.Item("1") = "False" Then

                FileCaseManager.AddFileCase(DateManager.GetCurrentShamsiDateInNumericFormat(), ParentInfo.fileName, parentId, fileCaseId)

                'اضافه کردن وکیل

                Dim Item As New FileParties.FileParties

                Item.fileCaseID = fileCaseId

                Item.fileID = parentId

                If Login.CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.وکیل Then

                    Item.financeAccess = True

                    Item.contactInfoID = Login.CurrentLogin.CurrentUser.UserID

                    Item.fileCaseRole = FileParties.Enums.FileCaseRole.وکیل

                    FileParties.FilePartiesManager.AddfileParties(Item, ContactInfo.Enums.custPriority.vakil)

                End If

                'اضافه کردن موکل

                Item.contactInfoID = FileDocManager.GetFileCustId(Item.fileID)

                If Item.contactInfoID <> String.Empty Then

                    Item.financeAccess = False

                    Item.fileCaseRole = FileParties.Enums.FileCaseRole.خواهان

                    FileParties.FilePartiesManager.AddfileParties(Item, ContactInfo.Enums.custPriority.movakel)

                End If

            Else

                If fc Is Nothing Then

                    preFileId = String.Empty

                    FileCaseManager.AddFileCase(DateManager.GetCurrentShamsiDateInNumericFormat(), fileCaseStep, parentId, fileCaseId)

                    lblMessage.Text = "ارتباط با پرونده جاری برقرار نشد."

                Else

                    fc.fileCaseOpenDate = DateManager.GetCurrentShamsiDateInNumericFormat()

                    fc.fileCaseStep = fileCaseStep

                    fc.fileID = parentId
                    'مشخصات پرونده
                    FileCaseManager.AddFileCase(fc, fileCaseId)
                    'افراد پرونده
                    Dim p As FileParties.FilePartiesCollection = FileParties.FilePartiesManager.GetAllPartiesByFileCase(fc.fileCaseID)

                    For Each Item As FileParties.FileParties In p

                        Item.fileCaseID = fileCaseId

                        Item.fileID = item1.SubItems(1).Text

                        Try

                            Dim c As ContactInfo.Enums.custPriority = ContactInfo.Enums.custPriority.NoP

                            Select Case CType(Item.fileCaseRole, FileParties.Enums.FileCaseRole)
                                Case FileParties.Enums.FileCaseRole.خوانده
                                    c = ContactInfo.Enums.custPriority.davi
                                Case FileParties.Enums.FileCaseRole.خواهان
                                    c = ContactInfo.Enums.custPriority.movakel
                                Case FileParties.Enums.FileCaseRole.کارشناس, FileParties.Enums.FileCaseRole.وکیل
                                    c = ContactInfo.Enums.custPriority.vakil
                            End Select

                            FileParties.FilePartiesManager.AddfileParties(Item, c)

                        Catch ex As Exception

                        End Try

                    Next

                End If

            End If


            '3) دایرکتوری مستندات

            item1.Text = "محتویات پرونده"

            item1.SubItems(1).Text = Guid.NewGuid().ToString()

            item1.SubItems(2).Text = 1

            item1.SubItems(3).Text = Enums.FileType.دایرکتوری_مستندات

            item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.دایرکتوری_مستندات)

            CreateFile(item1, item1.Text, 0, parentId)

            If preFileId <> String.Empty AndAlso copyItem.Item("3") = "True" Then

                Dim fileDocIds As ArrayList = FileDocManager.GetFileDocIdsByFileID(FileDocManager.GetFileIdByTypeAndFilecaseID(Enums.FileType.دایرکتوری_مستندات, fc.fileCaseID))

                For Each Item As String In fileDocIds

                    Try

                        Dim file As String = FileDocManager.WriteFile(Item)

                        FileDocManager.AddFileDocByRelation(Guid.NewGuid().ToString(), item1.SubItems(1).Text, fileCaseId, Item, file)

                    Catch ex As Exception

                    End Try

                Next

            End If


            '4) دایرکتوری متفرقه

            item1.Text = "متفرقه"

            item1.SubItems(1).Text = Guid.NewGuid().ToString()

            item1.SubItems(2).Text = 1

            item1.SubItems(3).Text = Enums.FileType.دایرکتوری_متفرقه

            item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.دایرکتوری_متفرقه)

            CreateFile(item1, item1.Text, 0, parentId)

            If preFileId <> String.Empty AndAlso copyItem.Item("4") = "True" Then


                Dim fileDocIds As ArrayList = FileDocManager.GetFileDocIdsByFileID(FileDocManager.GetFileIdByTypeAndFilecaseID(Enums.FileType.دایرکتوری_متفرقه, fc.fileCaseID))

                For Each Item As String In fileDocIds

                    Try

                        Dim file As String = FileDocManager.WriteFile(Item)

                        FileDocManager.AddFileDocByRelation(Guid.NewGuid().ToString(), item1.SubItems(1).Text, fileCaseId, Item, file)

                    Catch ex As Exception

                    End Try

                Next


            End If

            '5) زمانبندی کارها

            item1.Text = "اقدامات"

            item1.SubItems(1).Text = Guid.NewGuid().ToString()

            item1.SubItems(2).Text = 0

            item1.SubItems(3).Text = Enums.FileType.آلارم

            item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.آلارم)

            CreateFile(item1, item1.Text, 0, parentId)

            ' 6) مالی


            item1.Text = "مالی"

            item1.SubItems(1).Text = Guid.NewGuid().ToString()

            item1.SubItems(2).Text = 0

            item1.SubItems(3).Text = Enums.FileType.مالی

            item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.مالی)

            CreateFile(item1, item1.Text, 0, parentId)

            ' 7) تجمیع پرونده


            item1.Text = "تجمیع پرونده"

            item1.SubItems(1).Text = Guid.NewGuid().ToString()

            item1.SubItems(2).Text = 0

            item1.SubItems(3).Text = Enums.FileType.تجمیع_پرونده

            item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.تجمیع_پرونده)

            CreateFile(item1, item1.Text, 0, parentId)

            'ایجاد ارتباط با پرونده جاری
            If preFileId <> String.Empty AndAlso Not pasteClick Then

                Dim sList(1) As ListViewItem

                For Each Item As ListViewItem In lvFiles.Items
                    If Item.SubItems(1).Text = preFileId Then
                        sList(0) = lvFiles.Items(Item.Index)
                        Exit For
                    End If
                Next

                sList(1) = lvFiles.Items(curItem.Index)

                AddLink(sList)

            End If

            copyItem = Nothing

            If pasteClick Then

                pasteClick = False

                cutItem = Nothing

            End If

        Catch ex As Exception
            copyItem = Nothing
            lblMessage.Text = "خطا در ایجاد پرونده"
            Throw New Exception


        End Try

    End Sub

    Private Sub createFileDefaultDirectories(ByVal parentId As String)

        Try

            '1) دایرکتوری اوراق

            Dim item1 As New ListViewItem()

            item1.Text = "مشاوره ها"

            item1.SubItems.Add(Guid.NewGuid().ToString())

            item1.SubItems.Add(0)

            item1.SubItems.Add(Enums.FileType.مشاوره)

            item1.ImageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.مشاوره)

            CreateFile_Moshavere(item1, item1.Text, 0, parentId)

        Catch ex As Exception

            lblMessage.Text = "خطا در ایجاد فایل"

            Throw New Exception

        End Try

    End Sub

    Private Sub LoadDefaultImage()

        Try

            Dim list As BaseForm.ImageCollection = BaseForm.ImageManager.GetImagesByGroupName("Files")

            If list IsNot Nothing Then

                For Each Item As BaseForm.Image In list

                    Dim imagefullPath As String = FileManager.GetDocsImagePath() & Item.imageID & Item.imageUpdateDate & Item.imageExtension

                    Dim imageKey As String = Item.imageID

                    If imageKey = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل) Then

                        If Not defaultImages.ContainsKey(imageKey) Then
                            defaultImages.Add(imageKey, Item)
                        End If


                    End If

                    If Not System.IO.File.Exists(imagefullPath) Then

                        BaseForm.ImageManager.WriteImage(imageKey, imagefullPath)


                    End If

                    If Not lvFiles.LargeImageList.Images.ContainsKey(Item.imageID) Then

                        lvFiles.LargeImageList.Images.Add(Item.imageID, Bitmap.FromFile(imagefullPath))

                    End If

                Next

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("LoadDefaultImage", ex.ToString(), Me.ParentForm.Text)
        End Try




    End Sub

    Private Sub LoadDefaultImageFromTempDoc()

        Try

            Dim list As BaseForm.ImageCollection = BaseForm.ImageManager.GetImagesByGroupName("TempDocs")

            If list IsNot Nothing Then

                For Each Item As BaseForm.Image In list

                    Dim imagefullPath As String = FileManager.GetDocsImagePath() & Item.imageID & Item.imageUpdateDate & Item.imageExtension

                    Dim imageKey As String = Item.imageID

                    If Not System.IO.File.Exists(imagefullPath) Then

                        BaseForm.ImageManager.WriteImage(imageKey, imagefullPath)

                    End If

                    lvFiles.LargeImageList.Images.Add(Item.imageID, Bitmap.FromFile(imagefullPath))
                Next

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("LoadDefaultImageFromTempDoc", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub SetDesign()

        btnBack.Visible = True

        lvFiles.LabelEdit = True

        pnlDel.Visible = True

        pnlReport.Visible = False

        pnlNewOragh.Visible = False
        lblHelp.Visible = False
        lblFileCount.Visible = True

        pnlAddFolder.Visible = False

        RemoveHandler lvFiles.ItemMouseHover, AddressOf lvFiles_ItemMouseHover


        Select Case ParentInfo.FileType

            Case Enums.FileType.فایل

                lvFiles.AllowDrop = True

                lvFiles.ContextMenuStrip = contextFile

                pnlNewFile.Visible = True

                pnlLockContainer.Visible = False

                pnlLink.Visible = False

                AddHandler lvFiles.ItemMouseHover, AddressOf lvFiles_ItemMouseHover

            Case Enums.FileType.محتویات_فایل

                lvFiles.AllowDrop = True

                pnlAddFolder.Visible = True

                pnlNewFile.Visible = False

                pnlLockContainer.Visible = False

                pnlLink.Visible = False

                lvFiles.ContextMenuStrip = contextGlobal
                lblFileCount.Visible = False

            Case Enums.FileType.پرونده, Enums.FileType.پرونده_قفل_شده


                lvFiles.AllowDrop = True

                lvFiles.ContextMenuStrip = contextParvande

                pnlNewFile.Visible = False

                pnlLockContainer.Visible = True

                pnlLink.Visible = True

                ''abbas
                ''If pnlSearch.Visible Then
                ''btnBack.Visible = False
                ''End If
                lblHelp.Visible = True
                AddHandler lvFiles.ItemMouseHover, AddressOf lvFiles_ItemMouseHover


            Case Enums.FileType.محتویات_اوراق, Enums.FileType.محتویات_متفرقه, Enums.FileType.محتویات_مستندات

                lvFiles.AllowDrop = True

                lvFiles.ContextMenuStrip = contextGlobal

                pnlNewFile.Visible = False

                pnlLockContainer.Visible = False
                pnlLink.Visible = False

                '' If ParentInfo.FileType = Enums.FileType.محتویات_اوراق OrElse ParentInfo.FileType = Enums.FileType.محتویات_مستندات Then
                pnlNewOragh.Visible = True
                ''End If

            Case Else

                lvFiles.AllowDrop = False

                lvFiles.ContextMenuStrip = Nothing

                pnlNewFile.Visible = False

                pnlLockContainer.Visible = False
                pnlLink.Visible = False

                lvFiles.LabelEdit = False

                pnlDel.Visible = False

                pnlReport.Visible = True

                lblFileCount.Visible = False

        End Select

        If ParentInfo.FileType <> Enums.FileType.فایل AndAlso UcContacts1.Visible Then

            UcContacts1.Hide()

        End If

    End Sub

    Private Sub DelFile(ByVal myItems As ListView.SelectedListViewItemCollection)

        If Login.CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.منشی Then Return

        Select Case ParentInfo.FileType

            Case Enums.FileType.فایل


                RaiseEvent ShowMessageBox("آیا برای حذف مطمئن هستید ؟", "حذف فایل")

                If YesClicked Then

                    Dim msg As String = String.Empty

                    For Each item As ListViewItem In myItems

                        Try
                            'del file
                            Dim r As Long = FileDocManager.DeleteFile(item.SubItems(1).Text)

                            If r = 0 Then

                                msg &= " امکان حذف " & item.Text & " به دلیل تشکیل موضوع وجود ندارد. "

                            ElseIf r = 2 Then

                                msg &= " امکان حذف " & item.Text & " به دلیل ثبت مشاوره وجود ندارد. "
                            End If


                        Catch ex As Exception


                        End Try

                    Next

                    If msg <> String.Empty Then

                        lblMessage.Text = msg

                    End If

                End If

            Case Enums.FileType.محتویات_فایل

                If myItems.Count = 1 AndAlso CInt(myItems.Item(0).SubItems(3).Text) = Enums.FileType.مشاوره Then

                    lblMessage.Text = "امکان حذف وجود ندارد."

                    Exit Sub
                End If

                RaiseEvent ShowMessageBox("آیا برای حذف موضوع مطمئن هستید ؟", "حذف موضوع")

                If YesClicked Then

                    Dim msg As String = String.Empty

                    For Each item As ListViewItem In myItems

                        Try
                            'del file
                            If CInt(item.SubItems(3).Text) <> Enums.FileType.مشاوره AndAlso Not FileDocManager.DeleteFileById(item.SubItems(1).Text) Then

                                Throw New Exception

                            End If

                        Catch ex As Exception

                            If msg <> String.Empty Then msg &= " و "

                            msg = item.Text

                        End Try

                    Next

                    If msg <> String.Empty Then

                        msg = "امکان حذف " & msg & " به دلیل تشکیل پرونده وجود ندارد. "

                        lblMessage.Text = msg

                    End If

                End If

            Case Enums.FileType.پرونده

                RaiseEvent ShowMessageBox("درصورت تایید تمامی اطلاعات مالی و مستندات مربوط به پرونده حذف خواهد شد ، آیا مایل به حذف می باشید ؟", "حذف پرونده")

                If YesClicked Then

                    Dim msg As String = String.Empty

                    For Each item As ListViewItem In myItems

                        Try
                            If CInt(item.SubItems(3).Text) <> Enums.FileType.پرونده_قفل_شده Then


                                Dim fId As String = FileDocManager.GetFileCaseID(item.SubItems(1).Text)

                                If UserHasPermission(Login.CurrentLogin.CurrentUser.UserID, fId) Then

                                    'delete timing

                                    Dim a As ArrayList = FileCaseManager.GetAllTimingIDByFilecaseID(FileDocManager.GetFileCaseID(item.SubItems(1).Text))

                                    If a IsNot Nothing AndAlso a.Count > 0 Then

                                        For index As Integer = 0 To a.Count - 1

                                            Timing.TimingManager.DeleteTiming(a.Item(index).ToString)

                                        Next


                                    End If

                                    FileCaseManager.DeleteAllInfoDfFileCase(item.SubItems(1).Text)

                                Else

                                    lblMessage.Text = "مجوز دسترسی به پرونده داده نشده است"
                                End If

                            Else

                                lblMessage.Text = "امکان حذف پرونده قفل شده وجود ندارد."

                            End If
                            'del filecase

                        Catch ex As Exception
                            lblMessage.Text = "خطا در حذف پرونده"

                            ErrorManager.WriteMessage("DelFile-SelectedListViewItemCollection", ex.ToString(), Me.ParentForm.Text)


                        End Try

                    Next

                End If

            Case Else

                RaiseEvent ShowMessageBox("آیا برای حذف مطمئن هستید ؟", "حذف مستندات")

                If YesClicked Then

                    Dim msg As String = String.Empty

                    For Each item As ListViewItem In myItems

                        Try
                            FileDocManager.DeleteFileDocById(item.SubItems(1).Text)

                        Catch ex As Exception


                        End Try

                    Next

                End If

        End Select


        If ParentInfo.FileType = Enums.FileType.محتویات_اوراق OrElse ParentInfo.FileType = Enums.FileType.محتویات_متفرقه OrElse ParentInfo.FileType = Enums.FileType.محتویات_مستندات Then

            BindFileDocChilds(ParentInfo.fileId)

        Else
            BindChilds(ParentInfo.fileId)

        End If


    End Sub

    Private Sub DelFile(ByVal myItems() As ListViewItem)

        If Login.CurrentLogin.CurrentUser.Role = ContactInfo.Enums.RoleType.منشی Then Return

        Select Case ParentInfo.FileType

            Case Enums.FileType.فایل

                RaiseEvent ShowMessageBox("آیا برای حذف مطمئن هستید ؟", "حذف فایل")

                If YesClicked Then

                    Dim msg As String = String.Empty

                    For Each item As ListViewItem In myItems

                        Try
                            'del file
                            Dim r As Long = FileDocManager.DeleteFile(item.SubItems(1).Text)

                            If r = 0 Then

                                msg &= " امکان حذف " & item.Text & " به دلیل تشکیل موضوع وجود ندارد. "

                            ElseIf r = 2 Then

                                msg &= " امکان حذف " & item.Text & " به دلیل ثبت مشاوره وجود ندارد. "
                            End If


                        Catch ex As Exception

                            'If msg <> String.Empty Then msg &= " و "

                            'msg = item.Text

                        End Try

                    Next

                    If msg <> String.Empty Then

                        'msg = "امکان حذف " & msg & " به دلیل تشکیل پرونده وجود ندارد. "

                        lblMessage.Text = msg

                    End If

                End If

            Case Enums.FileType.محتویات_فایل

                If myItems.Length = 1 AndAlso CInt(myItems(0).SubItems(3).Text) = Enums.FileType.مشاوره Then

                    lblMessage.Text = "امکان حذف وجود ندارد."

                    Exit Sub
                End If

                RaiseEvent ShowMessageBox("آیا برای حذف موضوع مطمئن هستید ؟", "حذف موضوع")

                If YesClicked Then

                    Dim msg As String = String.Empty

                    For Each item As ListViewItem In myItems

                        Try
                            'del file
                            If CInt(item.SubItems(3).Text) <> Enums.FileType.مشاوره AndAlso Not FileDocManager.DeleteFileById(item.SubItems(1).Text) Then

                                Throw New Exception

                            End If

                        Catch ex As Exception

                            If msg <> String.Empty Then msg &= " و "

                            msg = item.Text

                        End Try

                    Next

                    If msg <> String.Empty Then

                        msg = "امکان حذف " & msg & " به دلیل تشکیل پرونده وجود ندارد. "

                        lblMessage.Text = msg

                    End If

                End If

            Case Enums.FileType.پرونده

                RaiseEvent ShowMessageBox("درصورت تایید تمامی اطلاعات مالی و مستندات مربوط به پرونده حذف خواهد شد ، آیا مایل به حذف می باشید ؟", "حذف پرونده")

                If YesClicked Then

                    Dim msg As String = String.Empty

                    For Each item As ListViewItem In myItems

                        Try
                            If CInt(item.SubItems(3).Text) <> Enums.FileType.پرونده_قفل_شده Then

                                Dim fId As String = FileDocManager.GetFileCaseID(item.SubItems(1).Text)

                                If UserHasPermission(Login.CurrentLogin.CurrentUser.UserID, fId) Then

                                    'delete timing

                                    Dim a As ArrayList = FileCaseManager.GetAllTimingIDByFilecaseID(FileDocManager.GetFileCaseID(item.SubItems(1).Text))

                                    If a IsNot Nothing AndAlso a.Count > 0 Then

                                        For index As Integer = 0 To a.Count - 1

                                            Timing.TimingManager.DeleteTiming(a.Item(index).ToString)

                                        Next


                                    End If

                                    FileCaseManager.DeleteAllInfoDfFileCase(item.SubItems(1).Text)

                                Else

                                    lblMessage.Text = "مجوز دسترسی به پرونده داده نشده است"
                                End If

                            Else

                                lblMessage.Text = "امکان حذف پرونده قفل شده وجود ندارد."

                            End If
                            'del filecase

                        Catch ex As Exception

                            lblMessage.Text = "خطا در حذف پرونده"

                            ErrorManager.WriteMessage("DelFile-listviewitem", ex.ToString(), Me.ParentForm.Text)


                        End Try

                    Next

                End If

            Case Else

                RaiseEvent ShowMessageBox("آیا برای حذف مطمئن هستید ؟", "حذف مستندات")

                If YesClicked Then

                    Dim msg As String = String.Empty

                    For Each item As ListViewItem In myItems

                        Try
                            FileDocManager.DeleteFileDocById(item.SubItems(1).Text)

                        Catch ex As Exception


                        End Try

                    Next

                End If

        End Select

        If ParentInfo.FileType = Enums.FileType.محتویات_اوراق OrElse ParentInfo.FileType = Enums.FileType.محتویات_متفرقه OrElse ParentInfo.FileType = Enums.FileType.محتویات_مستندات Then

            BindFileDocChilds(ParentInfo.fileId)

        Else
            BindChilds(ParentInfo.fileId)

        End If

    End Sub

    Private Function UserHasPermission(ByVal userId As String, ByVal fcaseId As String) As Boolean

        lblMessage.Text = String.Empty

        Try

            If Login.CurrentLogin.CurrentUser.IsAdmin Then Return True

            Return FileParties.FilePartiesManager.UserHasPermission(fcaseId, userId)

        Catch ex As Exception
            ErrorManager.WriteMessage("UserHasPermission", ex.ToString(), Me.ParentForm.Text)
            lblMessage.Text = "خطا در بررسی مجوز"

            Return False

        End Try

    End Function

#End Region

#Region "Methods"

    Public Sub Search(ByVal searchStr As String)

        'Try
        '    cmbKarshenas.SelectedValue = "0"

        '    cmbMovakel.SelectedValue = "0"
        '    cmbVakil.SelectedValue = "0"
        'Catch ex As Exception

        'End Try


        Search()

        'Panel2.Height = 90

        'pnlCollapse.Image = Global.WFControls.VB.My.Resources.Resources.collpase

        '''''Panel1.Height = SplitContainer1.Panel2.Height - 38 - Panel2.Height
        'Panel1.Height = SplitContainer1.Panel2.Height - 35 - (Panel2.Height + pnlFileSearch.Height)
        'IsCollapse = Not IsCollapse

        'ToolTip1.SetToolTip(pnlCollapse, "")


    End Sub


#End Region

#Region "Navigation"

    Private Sub AppendNavigation(ByVal fileName As String)

        If navigation.Count > 0 Then

            txtCurrentFile.Text &= " -> "

        End If

        txtCurrentFile.Text &= fileName

        navigation.Add(fileName)

    End Sub

    Private Sub ShowNavigation()

        txtCurrentFile.Text = String.Empty

        For index As Integer = 0 To navigation.Count - 1

            txtCurrentFile.Text &= navigation(index) & " -> "

        Next

        If txtCurrentFile.Text <> String.Empty Then

            txtCurrentFile.Text = txtCurrentFile.Text.Substring(0, txtCurrentFile.Text.Length - 4)

        End If

    End Sub

    Private Sub BackNavigation()

        If navigation.Count > 1 Then

            navigation.RemoveAt(navigation.Count - 1)

        End If

        ShowNavigation()

    End Sub

    Private Sub ClearNavigation()

        navigation.Clear()

        txtCurrentFile.Text = String.Empty

    End Sub



#End Region

#End Region

#Region "Copy/Paste"

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click

        CopyFileCase(True)

    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click

        CopyFileCase(False)

    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click

        pasteClick = True

        'Copy
        If cutItem(2) = "1" Then

            Dim l As New ArrayList
            l.Add(New String() {"1", "مشخصات پرونده"})
            l.Add(New String() {"2", "فرم ها"})
            l.Add(New String() {"3", "محتویات پرونده"})
            l.Add(New String() {"4", "متفرقه"})
            'ایجاد پرونده مرتبط
            Dim f As New WFControls.CS.BaseUc.frmPropertyMsg(l, "کپی محتویات پرونده جاری به پرونده جدید", "کپی پرونده")

            f.ShowDialog()

            copyItem = f.GetResult()

            If copyItem Is Nothing Then

                pasteClick = False

                Exit Sub

            Else
                copyItem.Add((copyItem.Count + 1).ToString(), cutItem(0))

            End If


            'ایجاد پرونده

            Dim item As New FileChildInfo

            item.fileID = Guid.NewGuid().ToString()

            item.fileName = " کپی " & cutItem(1)

            item.fileIsCat = 1

            item.fileType = Enums.FileType.پرونده

            Dim ControlName As String = CType(sender, ToolStripMenuItem).Name

            fileCaseStep = 20

            item.fileImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده)

            fileCaseId = Guid.NewGuid().ToString()

            AddNewItemInListview(item, True)

        Else

            'ایجاد پرونده

            Dim item As New FileChildInfo

            item.fileID = cutItem(0)

            item.fileName = cutItem(1)

            item.fileIsCat = 1

            item.fileType = Enums.FileType.پرونده

            Dim ControlName As String = CType(sender, ToolStripMenuItem).Name

            fileCaseStep = 20

            item.fileImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده)

            fileCaseId = Guid.NewGuid().ToString()

            AddNewItemInListview(item, True)

        End If

    End Sub

    Private Sub CopyFileCase(ByVal IsCopy As Boolean)


        Try
            If lvFiles.SelectedItems.Count > 1 Then

                lblMessage.Text = "لطفا یکی از پرونده ها را انتخاب نمایید."

                cutItem = Nothing

                Exit Sub

            End If

            lblMessage.Text = String.Empty


            If IsCopy Then

                cutItem = New String() {lvFiles.SelectedItems(0).SubItems(1).Text, lvFiles.SelectedItems(0).Text, "1"}

            Else

                cutItem = New String() {lvFiles.SelectedItems(0).SubItems(1).Text, lvFiles.SelectedItems(0).Text, "0"}

            End If


        Catch ex As Exception

            cutItem = Nothing

            ErrorManager.WriteMessage("CopyFileCase", ex.ToString(), Me.ParentForm.Text)

        End Try


    End Sub
#End Region

#Region "FileCaseTooltip"

    Private Sub lvFiles_ItemMouseHover(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemMouseHoverEventArgs)

        Try

            If ParentInfo.FileType = Enums.FileType.پرونده OrElse ParentInfo.FileType = Enums.FileType.پرونده_قفل_شده Then

                Dim maxlen As Integer = 0
                Dim sy As String = String.Empty
                Dim gh As String = String.Empty
                Dim subject As String = String.Empty
                Dim movakel As String = String.Empty

                Dim str As String = String.Empty

                Dim ds As DataSet = FileCaseManager.GetFileCaseDetailForTooltip(e.Item.SubItems(1).Text)

                If ds IsNot Nothing Then

                    If ds.Tables.Count > 0 AndAlso ds.Tables(0) IsNot Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then

                        If ds.Tables(0).Rows(0).Item("FileCaseNumber") <> "//" Then

                            gh = "شماره قضایی : " & ds.Tables(0).Rows(0).Item("FileCaseNumber")

                        Else

                            gh = "---- :" & "شماره قضایی "

                        End If

                        maxlen = gh.Length

                        If ds.Tables(0).Rows(0).Item("fileCaseNumberInSystem") IsNot DBNull.Value Then

                            sy = "شماره سیستمی : " & ds.Tables(0).Rows(0).Item("fileCaseNumberInSystem")

                        Else

                            sy = "---- :" & "شماره سیستمی "

                        End If

                        If sy.Length > maxlen Then maxlen = sy.Length

                        If ds.Tables(0).Rows(0).Item("fileCaseSubject") IsNot DBNull.Value Then

                            subject = "موضوع : " & ds.Tables(0).Rows(0).Item("fileCaseSubject")

                        Else

                            subject = "---- :" & "موضوع "

                        End If

                        If subject.Length > maxlen Then maxlen = subject.Length

                    End If

                    If ds.Tables.Count > 1 AndAlso ds.Tables(1) IsNot Nothing Then

                        For index As Integer = 0 To ds.Tables(1).Rows.Count - 1

                            movakel &= ds.Tables(1).Rows(index).Item("custFullName") & ";"

                        Next


                    End If


                End If

                If movakel <> String.Empty Then
                    movakel = "افراد پرونده : " & movakel.Substring(0, movakel.Length - 1)

                Else

                    movakel = "---- :" & "افراد پرونده "

                End If

                If movakel.Length > maxlen Then maxlen = movakel.Length

                str = gh.PadLeft(maxlen, " "c) & vbCrLf

                str &= sy.PadLeft(maxlen, " "c) & vbCrLf

                str &= subject.PadLeft(maxlen, " "c) & vbCrLf

                str &= movakel.PadLeft(maxlen, " "c) & vbCrLf

                e.Item.ToolTipText = str

            ElseIf ParentInfo.FileType = Enums.FileType.فایل Then

                Dim result As ArrayList = FileDocManager.GetFileCaseCountByFileId(e.Item.SubItems(1).Text)

                If result IsNot Nothing AndAlso result.Count > 0 Then

                    Dim str As String = String.Empty

                    For Each Item As String() In result

                        If Item(1) = "0" Then

                            str &= "تعداد پرونده های جاری : " & Item(0) & vbCrLf
                        Else

                            str &= "تعداد پرونده های مختومه : " & Item(0) & vbCrLf
                        End If

                    Next

                    If (Not String.IsNullOrEmpty(str)) Then

                        e.Item.ToolTipText = str

                    Else

                        e.Item.ToolTipText = "تعداد پرونده : 0"

                    End If

                Else

                    e.Item.ToolTipText = "تعداد پرونده : 0"

                End If

            End If

        Catch ex As Exception

            e.Item.ToolTipText = String.Empty

        End Try

    End Sub

#End Region

    Private Sub btnAddFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFolder.Click

        lblMessage.Text = String.Empty

        Try

            Dim item As New FileChildInfo

            item.fileID = Guid.NewGuid().ToString()

            item.fileName = "موضوع " & lvFiles.Items.Count

            item.fileIsCat = 1

            item.fileType = Enums.FileType.تعیین_موضوع

            item.fileImageID = BaseForm.ImageManager.GetDefaultIcon_TempDocsTable("")

            AddNewItemInListview(item, True)

        Catch ex As Exception

            ErrorManager.WriteMessage("btnAddFolder_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#Region "900415"

#Region "create file"

    Private Sub btnNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFile.Click

        lblMessage.Text = String.Empty

        Try

            'نمایش کاربر
            UcContacts1.Focus()

            UcContacts1.BindContacts(ucContacts.SearchType.role, ContactInfo.Enums.RoleType.موکل, New Drawing.Point(200, 200), "", "")



        Catch ex As Exception

            ErrorManager.WriteMessage("btnNewFile_Click", ex.ToString(), Me.ParentForm.Text)

        End Try


    End Sub

    Private Sub AddFileWithDrag(ByVal c As Lawyer.Common.VB.ContactInfo.ContactInfoReview)

        'قبلا با CustId مورد نظر فایل تشکیل شده است
        'یعنی برای موکل قبلا فایل تشکیل شده است
        Dim prefileName As String = FileDocManager.GetFileNameByCustId(c.custID)

        If Not String.IsNullOrEmpty(prefileName) Then

            lblMessage.Text &= "برای " & c.custFullName & " قبلا فایلی با نام " & prefileName & ".تشکیل شده است "
            'lblMessage.Text &= "برای موکل مورد نظر قبلا فایلی با نام " & prefileName & ".تشکیل شده است "

            Exit Sub

        End If

        'قبلا فایل ثبت شده است و یا نه
        If String.IsNullOrEmpty(FileDocManager.IsExistFileName(c.custFullName, ParentInfo.fileId)) Then

            Dim item1 As New ListViewItem(c.custFullName)

            item1.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

            item1.SubItems.Add(Guid.NewGuid().ToString())

            item1.SubItems.Add(1)

            item1.SubItems.Add(Enums.FileType.فایل)

            If Not lvFiles.LargeImageList.Images.ContainsKey(c.custID) Then

                Dim userImage As BaseForm.Image = BaseForm.ImageManager.GetImageByID(c.custID)

                Dim iconPath As String = String.Empty

                'فرد عکس ندارد
                If userImage Is Nothing OrElse userImage.imageExtension = String.Empty Then

                    userImage = defaultImages.Item(BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل))

                    iconPath = FileManager.GetDocsImagePath & userImage.imageID & userImage.imageUpdateDate & userImage.imageExtension

                    item1.ImageKey = userImage.imageID

                Else

                    iconPath = FileManager.GetDocsImagePath & c.custID & userImage.imageUpdateDate & userImage.imageExtension

                    item1.ImageKey = c.custID

                End If

                FileManager.GetFileFromBinaryFormat(userImage.imageLogo, iconPath, False, True)

                If Not lvFiles.LargeImageList.Images.ContainsKey(item1.ImageKey) Then

                    lvFiles.LargeImageList.Images.Add(item1.ImageKey, Bitmap.FromFile(iconPath))

                End If

            Else

                item1.ImageKey = c.custID
            End If

            'نمایش در لیست

            If CreateFile(item1, c.custFullName, c.custID) Then

                Dim index As Integer = lvFiles.Items.Count

                lvFiles.Items.Insert(index, item1.Clone())

                createFileDefaultDirectories(item1.SubItems(1).Text)

            End If


        Else

            lblMessage.Text &= "نام فایل تکراری است."

        End If

        SetResultCount()

    End Sub

    Private Sub AddFileWithDrag2(ByVal data As ArrayList)

        Dim myItems() As ListViewItem = data.Item(1)

        For Each item As ListViewItem In myItems

            If CInt(item.SubItems(2).Text) = ContactInfo.Enums.RoleType.موکل Then

                Dim c As New Lawyer.Common.VB.ContactInfo.ContactInfoReview
                c.custFullName = item.Text
                c.custID = item.SubItems(1).Text
                AddFileWithDrag(c)
                ' '' ''Dim prefileName As String = FileDocManager.GetFileNameByCustId(item.SubItems(1).Text)

                ' '' ''If String.IsNullOrEmpty(prefileName) Then


                ' '' ''    If String.IsNullOrEmpty(FileDocManager.IsExistFileName(item.Text, ParentInfo.fileId)) Then


                ' '' ''        Dim item1 As New ListViewItem(item.Text)

                ' '' ''        item1.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

                ' '' ''        item1.SubItems.Add(Guid.NewGuid().ToString())

                ' '' ''        item1.SubItems.Add(1)

                ' '' ''        item1.SubItems.Add(Enums.FileType.فایل)

                ' '' ''        If Not lvFiles.LargeImageList.Images.ContainsKey(item.SubItems(1).Text) Then

                ' '' ''            Dim userImage As BaseForm.Image = BaseForm.ImageManager.GetImageByID(item.SubItems(1).Text)

                ' '' ''            Dim iconPath As String = String.Empty

                ' '' ''            'فرد عکس ندارد
                ' '' ''            If userImage Is Nothing OrElse userImage.imageExtension = String.Empty Then

                ' '' ''                userImage = defaultImages.Item(BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل))

                ' '' ''                iconPath = FileManager.GetDocsImagePath & userImage.imageID & userImage.imageUpdateDate & userImage.imageExtension

                ' '' ''                item1.ImageKey = userImage.imageID

                ' '' ''            Else


                ' '' ''                iconPath = FileManager.GetDocsImagePath & item.SubItems(1).Text & userImage.imageUpdateDate & userImage.imageExtension

                ' '' ''                item1.ImageKey = item.SubItems(1).Text

                ' '' ''            End If

                ' '' ''            Common.FileManager.GetFileFromBinaryFormat(userImage.imageLogo, iconPath, False, True)

                ' '' ''            If Not lvFiles.LargeImageList.Images.ContainsKey(item1.ImageKey) Then

                ' '' ''                lvFiles.LargeImageList.Images.Add(item1.ImageKey, Bitmap.FromFile(iconPath))

                ' '' ''            End If

                ' '' ''        Else

                ' '' ''            item1.ImageKey = item.SubItems(1).Text
                ' '' ''        End If

                ' '' ''        'نمایش در لیست

                ' '' ''        If CreateFile(item1, item.Text, item.SubItems(1).Text) Then

                ' '' ''            Dim index As Integer = lvFiles.Items.Count

                ' '' ''            lvFiles.Items.Insert(index, item1.Clone())

                ' '' ''        End If


                ' '' ''    Else

                ' '' ''        lblMessage.Text &= " فایل " & item.Text & " قبلا ثبت شده است. "

                ' '' ''    End If
                ' '' ''Else

                ' '' ''    lblMessage.Text &= "برای " & item.Text & " قبلا فایلی با نام " & prefileName & ".تشکیل شده است "

                ' '' ''End If

            Else

                lblMessage.Text &= item.Text & " موکل نبوده و امکان تشکیل فایل نمی باشد. "

            End If
        Next

        btnNewFile.Enabled = True

        Exit Sub

    End Sub

    Private Sub UcContacts1_ContactAdd(ByVal c As Lawyer.Common.VB.ContactInfo.ContactInfoReview) Handles UcContacts1.ContactAdd

        lblMessage.Text = String.Empty

        If ParentInfo.FileType <> Enums.FileType.فایل Then

            UcContacts1.Hide()

            Exit Sub

        End If

        Try

            btnNewFile.Enabled = False

            AddFileWithDrag(c)
            'قبلا با CustId مورد نظر فایل تشکیل شده است
            'یعنی برای موکل قبلا فایل تشکیل شده است

            ' '' ''Dim prefileName As String = FileDocManager.GetFileNameByCustId(c.custID)

            ' '' ''If Not String.IsNullOrEmpty(prefileName) Then

            ' '' ''    lblMessage.Text = "برای موکل مورد نظر قبلا فایلی با نام " & prefileName & ".تشکیل شده است "

            ' '' ''    Exit Sub

            ' '' ''End If

            '' '' ''قبلا فایل ثبت شده است و یا نه
            ' '' ''If String.IsNullOrEmpty(FileDocManager.IsExistFileName(c.custFullName, ParentInfo.fileId)) Then

            ' '' ''    Dim item1 As New ListViewItem(c.custFullName)

            ' '' ''    item1.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

            ' '' ''    item1.SubItems.Add(Guid.NewGuid().ToString())

            ' '' ''    item1.SubItems.Add(1)

            ' '' ''    item1.SubItems.Add(Enums.FileType.فایل)

            ' '' ''    If Not lvFiles.LargeImageList.Images.ContainsKey(c.custID) Then

            ' '' ''        Dim userImage As BaseForm.Image = BaseForm.ImageManager.GetImageByID(c.custID)

            ' '' ''        Dim iconPath As String = String.Empty

            ' '' ''        'فرد عکس ندارد
            ' '' ''        If userImage Is Nothing OrElse userImage.imageExtension = String.Empty Then

            ' '' ''            userImage = defaultImages.Item(BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل))

            ' '' ''            iconPath = FileManager.GetDocsImagePath & userImage.imageID & userImage.imageUpdateDate & userImage.imageExtension

            ' '' ''            item1.ImageKey = userImage.imageID

            ' '' ''        Else

            ' '' ''            iconPath = FileManager.GetDocsImagePath & c.custID & userImage.imageUpdateDate & userImage.imageExtension

            ' '' ''            item1.ImageKey = c.custID

            ' '' ''        End If

            ' '' ''        Common.FileManager.GetFileFromBinaryFormat(userImage.imageLogo, iconPath, False, True)

            ' '' ''        If Not lvFiles.LargeImageList.Images.ContainsKey(item1.ImageKey) Then

            ' '' ''            lvFiles.LargeImageList.Images.Add(item1.ImageKey, Bitmap.FromFile(iconPath))

            ' '' ''        End If

            ' '' ''    Else

            ' '' ''        item1.ImageKey = c.custID
            ' '' ''    End If

            ' '' ''    'نمایش در لیست

            ' '' ''    If CreateFile(item1, c.custFullName, c.custID) Then

            ' '' ''        Dim index As Integer = lvFiles.Items.Count

            ' '' ''        lvFiles.Items.Insert(index, item1.Clone())

            ' '' ''        createFileDefaultDirectories(item1.SubItems(1).Text)

            ' '' ''    End If


            ' '' ''Else

            ' '' ''    lblMessage.Text = "نام فایل تکراری است."

            ' '' ''End If

            UcContacts1.Hide()

        Catch ex As Exception

            lblMessage.Text = "خطا در ایجاد فایل"

            ErrorManager.WriteMessage("UcContacts1_ContactAdd", ex.ToString(), Me.ParentForm.Text)

        End Try

        btnNewFile.Enabled = True

    End Sub

    Private Sub UcContacts1_ShowConfirm() Handles UcContacts1.ShowConfirm

        lblMessage.Text = String.Empty

        Try

            YesClicked = False

            RaiseEvent ShowMessageBox("فردی با نام مورد نظر یافت نشد، آیا می خواهید به عنوان موکل جدید ثبت شود؟ ", "فرد جدید")

            UcContacts1.YesClicked = YesClicked

        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت موکل جدید"

            ErrorManager.WriteMessage("UcContacts1_ShowConfirm", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub UcContacts1_ContactDetail(ByVal custId As String) Handles UcContacts1.ContactDetail, UcContacts1.showContactInfo

        lblMessage.Text = String.Empty

        RaiseEvent ContactDetail(custId)

        UcContacts1.RefreshContacts()

    End Sub

#End Region

#Region "Create Filecase"

    Private Sub ToolStripCreateCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripCreateCase.Click

        lblMessage.Text = String.Empty

        pasteClick = False

        Try

            copyItem = Nothing

            ' آیا ارتباطی بین پرونده های قبلی و جاری وجود دارد 
            If lvFiles.SelectedItems.Count = 1 Then

                Dim l As New ArrayList
                l.Add(New String() {"1", "مشخصات پرونده"})
                l.Add(New String() {"2", "فرم ها"})
                l.Add(New String() {"3", "محتویات پرونده"})
                l.Add(New String() {"4", "متفرقه"})
                'ایجاد پرونده مرتبط
                Dim f As New WFControls.CS.BaseUc.frmPropertyMsg(l, "کپی محتویات پرونده جاری به پرونده جدید", "کپی پرونده")

                f.ShowDialog()

                copyItem = f.GetResult()

                If copyItem Is Nothing Then

                    Exit Sub

                Else
                    copyItem.Add((copyItem.Count + 1).ToString(), lvFiles.SelectedItems(0).SubItems(1).Text)

                End If

            ElseIf lvFiles.SelectedItems.Count > 1 Then

                lblMessage.Text = "لطفا یکی از پرونده ها را انتخاب نمایید."

                Exit Sub

            End If

            'ایجاد پرونده

            Dim item As New FileChildInfo

            item.fileID = Guid.NewGuid().ToString()

            item.fileName = "پرونده " & lvFiles.Items.Count + 1

            item.fileIsCat = 1

            item.fileType = Enums.FileType.پرونده

            '' ''Dim ControlName As String = CType(sender, ToolStripMenuItem).Name

            fileCaseStep = -1

            item.fileImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده)

            fileCaseId = Guid.NewGuid().ToString()

            AddNewItemInListview(item, True)

        Catch ex As Exception

            ErrorManager.WriteMessage("ToolStripCreateCase_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

#End Region

#Region "TreeView"

    Private Sub UpdateTree(ByVal nodeKey As String, ByVal name As String, ByVal IsAddStatus As Boolean)

        Try

            'اضافه کردن پوشه در سطح اول


            If ParentInfo.fileId = String.Empty AndAlso IsAddStatus Then

                Dim childs As DocParentInfoCollection = FileDocManager.GetChildDocsByParentIDForTree(nodeKey)

                If childs Is Nothing OrElse childs.Count = 0 Then

                    'TreeView1.Nodes(0).Nodes.Add(nodeKey, name, 2)
                    Dim n As TreeNode = TreeView1.Nodes(0).Nodes.Add(nodeKey, name, 2)
                    n.Tag = False
                    n.SelectedImageIndex = 1


                Else
                    'BindNode(TreeView1.Nodes(0).Nodes.Add(nodeKey, name, 0, 1), childs)
                    BindAllNode(TreeView1.Nodes(0).Nodes.Add(nodeKey, name, 0, 1), childs)

                    Try
                        TreeView1.Nodes(0).Nodes(nodeKey).Tag = False

                    Catch ex As Exception

                    End Try

                End If


            Else

                TreeView1.Nodes(0).Nodes(nodeKey).Nodes.Clear()

                'برای پوشه root
                If name <> Nothing Then TreeView1.Nodes(0).Nodes(nodeKey).Text = name

                Dim childs As DocParentInfoCollection = FileDocManager.GetChildDocsByParentIDForTree(nodeKey)

                TreeView1.Nodes(0).Nodes(nodeKey).ImageIndex = 2

                TreeView1.Nodes(0).Nodes(nodeKey).SelectedImageIndex = 2

                If childs IsNot Nothing OrElse childs.Count > 0 Then

                    TreeView1.Nodes(0).Nodes(nodeKey).ImageIndex = 0

                    TreeView1.Nodes(0).Nodes(nodeKey).SelectedImageIndex = 1

                End If

                TreeView1.Nodes(0).Nodes(nodeKey).Tag = False

                'BindNode(TreeView1.Nodes(0).Nodes(nodeKey), childs)
                BindAllNode(TreeView1.Nodes(0).Nodes(nodeKey), childs)

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("UpdateTree", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub BindTree(ByVal parentId As String)

        Try

            Dim treeImageList As New ImageList

            treeImageList.Images.Add(New Bitmap(My.Resources.FolderClose1))
            treeImageList.Images.Add(New Bitmap(My.Resources.folderOpen))
            treeImageList.Images.Add(New Bitmap(My.Resources.FolderClose1))

            TreeView1.ImageList = treeImageList

            TreeView1.Nodes.Clear()

            Dim childs As DocParentInfoCollection = FileDocManager.GetChildDocsByParentIDForTree(parentId)

            BindNode(TreeView1.Nodes.Add(String.Empty, "لیست فایلها", 0, 1), childs)

            TreeView1.Nodes(0).Tag = False

            depth = 0

        Catch ex As Exception
            ErrorManager.WriteMessage("BindTree", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    'Private Sub BindTree(ByVal parentId As String)

    '    Try

    '        Dim treeImageList As New ImageList

    '        treeImageList.Images.Add(New Bitmap(My.Resources.FolderClose1))
    '        treeImageList.Images.Add(New Bitmap(My.Resources.folderOpen))
    '        treeImageList.Images.Add(New Bitmap(My.Resources.FolderClose1))

    '        TreeView1.ImageList = treeImageList

    '        TreeView1.Nodes.Clear()

    '        Dim childs As DocParentInfoCollection = FileDocManager.GetChildDocsByParentIDForTree(parentId)

    '        BindNode(TreeView1.Nodes.Add(String.Empty, "لیست فایلها", 0, 1), childs)

    '    Catch ex As Exception
    '        ErrorManager.WriteMessage("BindTree", ex.ToString(), Me.ParentForm.Text)
    '    End Try

    'End Sub

    'Private Sub BindNode(ByRef node As TreeNode, ByVal childs As DocParentInfoCollection)

    '    If childs IsNot Nothing Then
    '        For Each Item As DocParentInfo In childs

    '            Dim n As TreeNode = node.Nodes.Add(Item.docID, Item.docType, 2)

    '            'n.ImageIndex = 0

    '            Dim c As DocParentInfoCollection = FileDocManager.GetChildDocsByParentIDForTree(Item.docID)

    '            If c IsNot Nothing AndAlso c.Count > 0 Then

    '                BindNode(n, c)

    '                n.ImageIndex = 0

    '                n.SelectedImageIndex = 1

    '            End If

    '        Next
    '    End If


    'End Sub


    Private Sub BindNode(ByRef node As TreeNode, ByVal childs As DocParentInfoCollection)

        If childs IsNot Nothing Then
            For Each Item As DocParentInfo In childs

                Dim n As TreeNode = node.Nodes.Add(Item.docID, Item.docType, 2)

                n.Tag = False
                n.ImageIndex = 0

                ''    Dim c As DocParentInfoCollection = FileDocManager.GetChildDocsByParentIDForTree(Item.docID)

                ''    If c IsNot Nothing AndAlso c.Count > 0 Then


                ''        For Each Item1 As DocParentInfo In c

                ''            n.Nodes.Add(Item1.docID, Item1.docType, 2)
                ''        Next

                ''        '' ''BindNode(n, c)

                ''        n.ImageIndex = 0

                ''        n.SelectedImageIndex = 1

                ''    End If

                n.ImageIndex = 0

                n.SelectedImageIndex = 1

            Next



        End If


    End Sub

    Private Sub BindAllNode(ByVal node As TreeNode, ByVal childs As DocParentInfoCollection)

        If childs IsNot Nothing Then

            For Each Item As DocParentInfo In childs

                Dim n As TreeNode = node.Nodes.Add(Item.docID, Item.docType, 2)

                n.Tag = False

                Dim c As DocParentInfoCollection = FileDocManager.GetChildDocsByParentIDForTree(Item.docID)

                If c IsNot Nothing AndAlso c.Count > 0 Then

                    '' ''For Each Item1 As DocParentInfo In c

                    '' ''    n.Nodes.Add(Item1.docID, Item1.docType, 2)
                    '' ''Next

                    BindAllNode(n, c)

                    n.ImageIndex = 0

                    n.SelectedImageIndex = 1

                End If

                n.ImageIndex = 0

                n.SelectedImageIndex = 1

            Next


        End If


    End Sub

    Dim depth As Short = 0

    Private Sub TreeView1_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterExpand

        If e.Node.Level >= 2 OrElse e.Node.Tag = False Then

            For index As Integer = 0 To e.Node.Nodes.Count - 1

                e.Node.Nodes(index).Nodes.Clear()

                Dim childs As DocParentInfoCollection = FileDocManager.GetChildDocsByParentIDForTree(e.Node.Nodes(index).Name)

                NewBindNode(e.Node.Nodes(index), childs)

            Next

            e.Node.Tag = True

        End If

    End Sub

    Private Sub NewBindNode(ByVal node As TreeNode, ByVal childs As DocParentInfoCollection)

        For Each Item As DocParentInfo In childs

            Dim n As TreeNode = node.Nodes.Add(Item.docID, Item.docType, 0)
            n.Tag = False
            n.SelectedImageIndex = 1
        Next



    End Sub

    'Private Sub TreeView1_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand


    '    'Dim node As TreeNode = TreeView1.Nodes(0)

    '    'For index As Integer = 0 To depth - 1

    '    '    node = node.Nodes(0)

    '    'Next

    '    'MessageBox.Show(node.Text + " " + node.Nodes.Count.ToString())
    '    ' '' ''If e.Node.Tag = False Then

    '    ' '' ''    ''TreeView1.Nodes(0).Nodes(0).Nodes.Add("1", "lll", 2)

    '    ' '' ''    For index As Integer = 0 To e.Node.Nodes.Count - 1


    '    ' '' ''        Dim srt As String = e.Node.Nodes(index).Name

    '    ' '' ''        e.Node.Nodes(index).Nodes.Clear()

    '    ' '' ''        BindNode(e.Node.Nodes(index), FileDocManager.GetChildDocsByParentIDForTree(e.Node.Nodes(index).Name))

    '    ' '' ''        '    e.Node.Nodes(index).Nodes.Clear()
    '    ' '' ''        '    ''''TreeView1.Nodes(0).Nodes(index).Nodes.Add("1", "lll", 2)
    '    ' '' ''        '    BindNode(e.Node.Nodes(index), FileDocManager.GetChildDocsByParentIDForTree(e.Node.Nodes(index).Name))

    '    ' '' ''    Next

    '    ' '' ''    e.Node.Tag = True
    '    ' '' ''End If


    '    'depth += 1




    '    '' ''If e.Node.Level >= depth And node IsNot Nothing Then

    '    '' ''    MessageBox.Show(e.Node.Level.ToString + " " + depth.ToString())
    '    '' ''    'TreeView1.Nodes(0).Nodes(0).Nodes.Add("1", "lll", 2)

    '    '' ''    For index As Integer = 0 To node.Nodes.Count - 1

    '    '' ''        ''''TreeView1.Nodes(0).Nodes(index).Nodes.Add("1", "lll", 2)
    '    '' ''        BindNode(node.Nodes(index), FileDocManager.GetChildDocsByParentIDForTree(node.Nodes(index).Name))

    '    '' ''    Next

    '    '' ''    depth += 1

    '    '' ''End If

    '    'MessageBox.Show(e.Node.Name + e.Node.Nodes.Count.ToString() + e.Node.Text)

    '    'If Not (e.Node.Nodes.Count > 0) Then


    '    '    BindTree(e.Node.Name)

    '    'End If
    'End Sub

    Private Sub TreeView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick

        lblMessage.Text = String.Empty

        If pnlSearch.Visible Then

            SetForSearch(True)

        End If

        Try

            treeParentId = TreeView1.SelectedNode.Name

            If treeParentId = String.Empty Then

                ParentInfo.FileType = Enums.FileType.فایل

                ClearNavigation()

            Else

                Dim fileType As Enums.FileType = FileDocManager.GetFileType(treeParentId)

                If fileType <> Enums.FileType.پرونده_قفل_شده Then

                    ' 1- گرفتن مشخصات Parent
                    If fileType = Enums.FileType.فایل Then

                        If FileDocManager.StructureISNewVersion(treeParentId) Then

                            ParentInfo.FileType = Enums.FileType.محتویات_فایل

                        Else
                            ParentInfo.FileType = Enums.FileType.پرونده

                        End If

                    ElseIf fileType = Enums.FileType.تعیین_موضوع Then

                        ParentInfo.FileType = Enums.FileType.پرونده

                    Else

                        ParentInfo.FileType = Enums.FileType.محتویات_پرونده

                    End If

                    If fileType = Enums.FileType.پرونده Then

                        Dim fId As String = FileDocManager.GetFileCaseID(treeParentId)
                        If Not UserHasPermission(Login.CurrentLogin.CurrentUser.UserID, fId) Then
                            lblMessage.Text = "مجوز دسترسی به شما داده نشده است"
                            Exit Sub
                        End If
                        ParentInfo.FileCaseId = fId
                        'ParentInfo.FileCaseId = FileDocManager.GetFileCaseID(ParentInfo.fileId)
                        '' ''ParentInfo.FileCaseId = FileDocManager.GetFileCaseID(treeParentId)

                    End If

                    '' ''SetCurrentFile(TreeView1.SelectedNode.Text)
                    ShowTreeNavigation(TreeView1.SelectedNode)

                Else
                    'نمایش محتویات همان سطح
                    treeParentId = TreeView1.SelectedNode.Parent.Name

                    ParentInfo.FileType = Enums.FileType.پرونده

                    ShowTreeNavigation(TreeView1.SelectedNode.Parent)

                End If



            End If


            ParentInfo.fileId = treeParentId

            '2 - گرفتن فرزندان

            BindChilds(ParentInfo.fileId)

        Catch ex As Exception

            UcContacts1.Hide()

            lblMessage.Text = "خطا در بارگذاری "

            ErrorManager.WriteMessage("TreeView1_DoubleClick", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub TreeView1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseDown

        lblMessage.Text = String.Empty

        TreeView1.SelectedNode = TreeView1.HitTest(e.X, e.Y).Node

    End Sub

    Private Sub ShowTreeNavigation(ByVal node As TreeNode)

        ClearNavigation()

        If node.Parent IsNot Nothing Then

            Select Case ParentInfo.FileType

                Case Enums.FileType.فایل

                    AppendNavigation(ParentInfo.fileName)

                Case Enums.FileType.محتویات_فایل

                    AppendNavigation(node.Text)

                    'Case Enums.FileType.تعیین_موضوع

                    '    AppendNavigation(node.Parent.Text)

                    '    AppendNavigation(node.Text)

                Case Enums.FileType.پرونده

                    If node.Parent.Name <> String.Empty Then

                        AppendNavigation(node.Parent.Text)

                    End If


                    AppendNavigation(node.Text)

                Case Enums.FileType.محتویات_پرونده

                    If node.Parent.Name <> String.Empty Then

                        AppendNavigation(node.Parent.Parent.Text)

                    End If

                    AppendNavigation(node.Parent.Text)

                    AppendNavigation(node.Text)

            End Select

        End If

    End Sub

#End Region

#Region "Comment"

    Private Sub ToolStripT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        lblMessage.Text = String.Empty

        pasteClick = False

        Try

            copyItem = Nothing

            ' آیا ارتباطی بین پرونده های قبلی و جاری وجود دارد 
            If lvFiles.SelectedItems.Count = 1 Then

                Dim l As New ArrayList
                l.Add(New String() {"1", "مشخصات پرونده"})
                l.Add(New String() {"2", "فرم ها"})
                l.Add(New String() {"3", "محتویات پرونده"})
                l.Add(New String() {"4", "متفرقه"})
                'ایجاد پرونده مرتبط
                Dim f As New WFControls.CS.BaseUc.frmPropertyMsg(l, "کپی محتویات پرونده جاری به پرونده جدید", "کپی پرونده")

                f.ShowDialog()

                copyItem = f.GetResult()

                If copyItem Is Nothing Then

                    Exit Sub

                Else
                    copyItem.Add((copyItem.Count + 1).ToString(), lvFiles.SelectedItems(0).SubItems(1).Text)

                End If

            ElseIf lvFiles.SelectedItems.Count > 1 Then

                lblMessage.Text = "لطفا یکی از پرونده ها را انتخاب نمایید."

                Exit Sub

            End If

            'ایجاد پرونده

            Dim item As New FileChildInfo

            item.fileID = Guid.NewGuid().ToString()

            item.fileName = "پرونده " & CType(sender, ToolStripMenuItem).Text

            item.fileIsCat = 1

            item.fileType = Enums.FileType.پرونده

            Dim ControlName As String = CType(sender, ToolStripMenuItem).Name

            fileCaseStep = CInt(ControlName.Substring(ControlName.Length - 1))

            item.fileImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.پرونده)

            fileCaseId = Guid.NewGuid().ToString()

            AddNewItemInListview(item, True)

        Catch ex As Exception

            ErrorManager.WriteMessage("ToolStripT1_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region

    Private Sub LinkLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' SetCollapse()

    End Sub

#Region "Archive File"


    Private Sub btnArchiveFile_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnArchiveFile.DragEnter

        lblMessage.Text = String.Empty

        Try

            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnArchiveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchiveFile.Click

        lblMessage.Text = String.Empty

        Try

            ArchiveFile(lvFiles.SelectedItems, True)

        Catch ex As Exception

            ErrorManager.WriteMessage("btnArchiveFile_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub btnArchiveFile_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnArchiveFile.DragDrop

        lblMessage.Text = String.Empty

        Try

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Lock" Then

                Dim myItems() As ListViewItem = data.Item(1)

                ArchiveFile(myItems, True)

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("btnArchiveFile_DragDrop", ex.ToString(), Me.ParentForm.Text)

        End Try
    End Sub

    Private Sub ToolStripMenuItemArchiveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemArchiveFile.Click

        lblMessage.Text = String.Empty

        Try

            ArchiveFile(lvFiles.SelectedItems, True)

        Catch ex As Exception

            ErrorManager.WriteMessage("ToolStripMenuItemArchiveFile_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub ToolStripMenuItemunArchive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemunArchive.Click

        lblMessage.Text = String.Empty

        Try

            ArchiveFile(lvFiles.SelectedItems, False)

        Catch ex As Exception

            ErrorManager.WriteMessage("ToolStripMenuItemunArchive_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub ArchiveFile(ByVal myItems As ListView.SelectedListViewItemCollection, ByVal isArchive As Boolean)

        Dim ImageID As String

        If isArchive Then

            ImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.آرشیو_فایل)
        Else
            ImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل)
        End If


        For Each item As ListViewItem In myItems

            Try
                If item.ImageKey <> ImageID AndAlso FileDocManager.UpdateFileArchive(item.SubItems(1).Text, isArchive, ImageID) Then

                    item.ImageKey = ImageID

                    Dim subjects As ArrayList = FileDocManager.GetChildDocsByParentIDAndType(item.SubItems(1).Text, Enums.FileType.تعیین_موضوع)


                    For Each Item1 As String In subjects
                        FileDocManager.UpdateFileArchive(Item1, isArchive, BaseForm.ImageManager.GetDefaultIcon_TempDocsTable(""))
                    Next


                    If (isArchive <> chkArchive.Checked) Then
                        lvFiles.Items.Remove(item)
                    End If

                End If

            Catch ex As Exception

                ErrorManager.WriteMessage("ArchiveFile,SelectedListViewItemCollection", ex.ToString(), Me.ParentForm.Text)

            End Try

        Next

    End Sub

    Private Sub ArchiveFile(ByVal myItems() As ListViewItem, ByVal isArchive As Boolean)

        Dim ImageID As String

        If isArchive Then

            ImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.آرشیو_فایل)
        Else
            ImageID = BaseForm.ImageManager.GetDefaultIcon_FilesTable(Enums.FileType.فایل)
        End If


        For Each item As ListViewItem In myItems

            Try
                If item.ImageKey <> ImageID AndAlso FileDocManager.UpdateFileArchive(item.SubItems(1).Text, isArchive, ImageID) Then

                    item.ImageKey = ImageID
                    If (isArchive <> chkArchive.Checked) Then
                        lvFiles.Items.Remove(item)
                    End If
                End If

            Catch ex As Exception

                ErrorManager.WriteMessage("ArchiveFile,SelectedListViewItemCollection", ex.ToString(), Me.ParentForm.Text)

            End Try

        Next
    End Sub

#End Region

#Region "Search Files"

    Private Sub SearchArchiveFiles()

        lblMessage.Text = String.Empty

        SetForSearch(True)

    End Sub

    Private Sub chkArchive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkArchive.CheckedChanged

        Try

            SearchArchiveFiles()

        Catch ex As Exception

            ErrorManager.WriteMessage("chkArchive_CheckedChanged", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

#End Region


    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Try
                Dim param As New Dictionary(Of String, String)
                Dim movakel As String = String.Empty
                Dim vakil As String = String.Empty
                Dim karshenas As String = String.Empty
                Dim davi As String = String.Empty

                Dim PartiesBaseInfo As FileParties.FilePartiesAccessCollection = FileParties.FilePartiesManager.GetPartiesAccessByFileCaseID(ParentInfo.FileCaseId)

                For Each Item As FileParties.FilePartiesAccess In PartiesBaseInfo

                    Select Case Item.fileCaseRole

                        Case FileParties.Enums.FileCaseRole.خوانده

                            davi += " - " & Item.custFullName

                        Case FileParties.Enums.FileCaseRole.خواهان

                            movakel += " - " & Item.custFullName

                        Case FileParties.Enums.FileCaseRole.کارشناس

                            karshenas += " - " & Item.custFullName

                        Case FileParties.Enums.FileCaseRole.وکیل

                            vakil += " - " & Item.custFullName

                    End Select

                Next

                If davi <> String.Empty Then
                    davi = davi.Substring(2)
                End If
                If movakel <> String.Empty Then
                    movakel = movakel.Substring(2)
                End If
                If karshenas <> String.Empty Then
                    karshenas = karshenas.Substring(2)
                End If
                If vakil <> String.Empty Then
                    vakil = vakil.Substring(2)
                End If

                param.Add("pMovakel", movakel)

                param.Add("pVakil", vakil)

                param.Add("pKarshenas", karshenas)

                param.Add("pDavi", davi)

                Dim r As New MyReports()

                Dim List As New FileCaseCollection()

                List.Add(FileCaseManager.GetFileCaseByID(ParentInfo.FileCaseId))

                r.ReportCollection("مشخصات پرونده", "testRpt2", param, ParentInfo.FileCaseId) = List

                r.Show()

            Catch ex As Exception

            End Try
        Catch ex As Exception

            ErrorManager.WriteMessage("btnPrint_Click", ex.ToString(), Me.ParentForm.Text)

        End Try
    End Sub

    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        Try
            lblMessage.Text = String.Empty
            If tw.Select() Then
                Acquire()
            End If


        Catch ex As Exception

            Me.Enabled = True
            lblMessage.Text = "اسکنر نصب نشده است"
            ErrorManager.WriteMessage("btnScan_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

        SetResultCount()

    End Sub

    Private Sub chArchice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            SearchArchiveFiles()

        Catch ex As Exception

            ErrorManager.WriteMessage("btnSearchArchive_Click", ex.ToString(), Me.ParentForm.Text)

        End Try
    End Sub

    Private Sub txtList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try

            filterList()
            txtList.Focus()

        Catch ex As Exception
            ErrorManager.WriteMessage("txtFileName_KeyPress", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub
    Private Sub filterList()
        Try
            For Each item In lvFiles.Items
                If item.Text.ToLower().Contains(NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtList.Text)) Then
                    item.Selected = True
                Else
                    lvFiles.Items.Remove(item)
                End If
            Next

            SetResultCount()
        Catch ex As Exception

            ErrorManager.WriteMessage("btnSearch_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub btnAsnad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsnad.Click


        Try

            RaiseEvent AsnadTip()

        Catch ex As Exception

            ErrorManager.WriteMessage("btnAsnad_Click", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub


#Region "Scan"

    Public Sub New()
        InitializeComponent()
        Try
            tw = New Twain()
            tw.Init(Me.Handle)
        Catch ex As Exception

        End Try

    End Sub

    Private msgfilter As Boolean
    Private tw As Twain
    Private picnumber As Integer = 0
    Dim dibhand As IntPtr
    Dim pixptr As IntPtr

    <DllImport("kernel32.dll", ExactSpelling:=True)> Friend Shared Function GlobalLock(ByVal handle As IntPtr) As IntPtr
    End Function
    Private PreFilterMessageCount As Integer = 0

    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        Dim cmd As TwainCommand = tw.PassMessage(m)
        If (cmd = TwainCommand.Not) Then
            PreFilterMessageCount += 1
            If (PreFilterMessageCount > 50) Then
                lblMessage.Text = "اسکنر نصب نشده است"
                EndingScan()
                tw.CloseSrc()
                PreFilterMessageCount = 0
            End If
            Return False
        End If

        Select Case cmd
            Case TwainCommand.CloseRequest
                EndingScan()
                tw.CloseSrc()
            Case TwainCommand.CloseOk
                EndingScan()
                tw.CloseSrc()
            Case TwainCommand.DeviceEvent
            Case TwainCommand.TransferReady
                Dim pics As ArrayList = tw.TransferPictures()
                EndingScan()
                tw.CloseSrc()
                picnumber += 1
                Dim i As Integer
                For i = 0 To pics.Count - 1 Step 1
                    Dim img As IntPtr = CType(pics(i), IntPtr)
                    bmprect = New System.Drawing.Rectangle(0, 0, 0, 0)
                    dibhand = img
                    bmpptr = GlobalLock(dibhand)
                    pixptr = GetPixelInfo(bmpptr)
                    SaveDIBAs("", bmpptr, pixptr)
                    Dim picnum As Integer = i + 1
                Next
        End Select

        Return True
    End Function


    Dim bmi As BITMAPINFOHEADER

    Dim bmprect As System.Drawing.Rectangle

    Protected Function GetPixelInfo(ByVal bmpptr As IntPtr) As IntPtr
        bmi = New BITMAPINFOHEADER()
        Marshal.PtrToStructure(bmpptr, bmi)

        bmprect.X = bmprect.Y = 0
        bmprect.Width = bmi.biWidth
        bmprect.Height = bmi.biHeight

        If (bmi.biSizeImage = 0) Then
            bmi.biSizeImage = Int((((bmi.biWidth * bmi.biBitCount) + 31) & Hex(Not (31))) / 2 ^ 3) * bmi.biHeight
        End If

        Dim p As Integer = bmi.biClrUsed
        If ((p = 0) And (bmi.biBitCount <= 8)) Then
            p = Int(1 * 2 ^ bmi.biBitCount)
        End If
        p = (p * 4) + bmi.biSize + CType(bmpptr.ToInt32, Integer)
        Return New IntPtr(p)
    End Function

    Dim bmpptr As IntPtr

    Private Sub EndingScan()
        If (msgfilter) Then
            System.Windows.Forms.Application.RemoveMessageFilter(Me)
            msgfilter = False
            Me.Enabled = True
            'Me.Activate()
        End If
    End Sub

    Private Sub Acquire()

        If (Not msgfilter) Then
            PreFilterMessageCount = 0
            Me.Enabled = False
            msgfilter = True
            System.Windows.Forms.Application.AddMessageFilter(Me)
        End If

        tw.Acquire()

    End Sub

    <DllImport("gdiplus.dll", ExactSpelling:=True)> Friend Shared Function GdipCreateBitmapFromGdiDib(ByVal bminfo As IntPtr, ByVal pixdat As IntPtr, ByRef image As IntPtr) As Integer
    End Function

    <DllImport("gdiplus.dll", ExactSpelling:=True, CharSet:=CharSet.Unicode)> Friend Shared Function GdipSaveImageToFile(ByVal image As IntPtr, ByVal filename As String, <[In]()> ByRef clsid As Guid, ByVal encparams As IntPtr) As Integer
    End Function

    <DllImport("gdiplus.dll", ExactSpelling:=True)> Friend Shared Function GdipDisposeImage(ByVal image As IntPtr) As Integer
    End Function

    Private Shared codecs() As ImageCodecInfo = ImageCodecInfo.GetImageEncoders()
    Private Shared Function GetCodecClsid(ByVal filename As String, ByRef clsid As Guid) As Boolean
        clsid = Guid.Empty
        Dim ext As String = Path.GetExtension(filename)
        'Checking string for null
        If IsNothing(ext) Then
            Return False
        End If
        ext = "*" + ext.ToUpper()
        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If (codec.FilenameExtension.IndexOf(ext) >= 0) Then
                clsid = codec.Clsid
                Return True
            End If
        Next
        Return False
    End Function


    Public Function SaveDIBAs(ByVal picname As String, ByVal bminfo As IntPtr, ByVal pixdat As IntPtr) As Boolean
        Try

            Dim clsid As Guid

            scanImage = FileManager.GetTempDocsFilesPath() + Guid.NewGuid.ToString() + ".jpg"

            If Not GetCodecClsid(scanImage, clsid) Then

                lblMessage.Text = "خطا در ذخیره فایل"

                Return False

            End If

            Dim img As IntPtr = IntPtr.Zero

            Dim st As Integer = GdipCreateBitmapFromGdiDib(bminfo, pixdat, img)

            If (st <> 0) Or (Equals(img, IntPtr.Zero)) Then

                Return False

            End If

            st = GdipSaveImageToFile(img, scanImage, clsid, IntPtr.Zero)

            GdipDisposeImage(img)

            AddNewFile(True)

            Return st = 0

        Catch ex As Exception

            lblMessage.Text = ex.ToString()

        End Try

    End Function

    Private scanImage As String = String.Empty



#End Region





    Private Sub lvFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub btnParvandehRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParvandehRpt.Click
        Try
            Dim contactType As String = ""
            Dim query As String = "select * from vewparvandekolli"

            Dim subQuery = " where 1=1 "
            If cmbstate.Text <> "---" Then
                subQuery += " and tsstate='" + NwdSolutions.Web.GeneralUtilities.General.DbReplace(cmbstate.Text) + "'"
            End If

            If cmbstatus.SelectedValue <> 2 Then
                If cmbstatus.SelectedIndex = 0 Then subQuery += " and filecaseclosedate is null "
                If cmbstatus.SelectedIndex = 1 Then subQuery += " and filecaseclosedate is not null "
            End If

            If cmbFileSearch.SelectedValue <> "10" Then
                If cmbFileSearch.SelectedValue = 0 Then subQuery += " and vail like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim) & "%'"
                If cmbFileSearch.SelectedValue = 4 Then subQuery += " and movakel like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim) & "%'"
                If cmbFileSearch.SelectedValue = 5 Then subQuery += " and tarafdavi like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim) & "%'"
            End If

            If cmbFileSearch.SelectedValue = "10" And txtSubject.Text.Trim(AccessibleDescription) <> String.Empty Then
                subQuery += " and ( fileCaseSubject  like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(Me.txtSubject.Text.Trim) & "%' "
                subQuery += " or( fileCaseNumberInSystem  like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim()) & "%' or fileCaseNumberInCourt like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim) & "%'  or fileCaseNumberInBranch like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtSubject.Text.Trim) & "%') "
                '_filecase += " or match (fileDocContent,fileDocName) against ('" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(Me.txtSubject.Text.Trim) & "*' in boolean mode) )"
            End If
            query += subQuery


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
            Dim dt As System.Data.DataTable = db.GetDataTableFromSqlCommandText("vewparvandekolli", query, Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim rf As New NewReport()
            Dim dir As String = CurDir()
            rf.ShowReport(dt, "VBDataSet_vewparvandekolli", "WFControls.VB.rptParvandeh.rdlc", Nothing)


            rf.Show()

        Catch ex As Exception


        End Try
    End Sub

  
    Private Sub ctxAddShowTempDoc_Click(sender As Object, e As EventArgs) Handles ctxAddShowTempDoc.Click
        RaiseEvent _dlgOpenTempDoc()
    End Sub
End Class

<StructLayout(LayoutKind.Sequential, Pack:=2)> Friend Class BITMAPINFOHEADER
    Public biSize As Integer
    Public biWidth As Integer
    Public biHeight As Integer
    Public biPlanes As Short
    Public biBitCount As Short
    Public biCompression As Integer
    Public biSizeImage As Integer
    Public biXPelsPerMeter As Integer
    Public biYPelsPerMeter As Integer
    Public biClrUsed As Integer
    Public biClrImportant As Integer
End Class
