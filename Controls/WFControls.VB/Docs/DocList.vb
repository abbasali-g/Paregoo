Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.BaseUserControl.ListView
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Word
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.LawyerError

Public Class DocList

    Dim ParentInfo As DocParentInfo
    Dim TempItem As ListViewItem
    Delegate Sub ShowForm(ByVal ID As String, ByVal filePath As String, ByVal TableName As String, ByVal fileName As String)
    Event ShowDocContent As ShowForm

    Delegate Sub ConfirmFormS(ByVal myItems As ListView.SelectedListViewItemCollection)
    Event ConfirmDelete As ConfirmFormS

   

    Delegate Sub ConfirmFormD(ByVal myItems As ListViewItem())
    Event ConfirmDeleteDrag As ConfirmFormD

    Dim treeParentId As String = String.Empty
    Dim moveCursor, nodropCursor As Cursor
    Dim l As Loading


    'DocID
    'IsCat
    'Extension


#Region "Events"

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click

        lblMessage.Text = String.Empty

        Try

            TempItem = New ListViewItem("پوشه جدید", BaseForm.ImageManager.GetDefaultIcon_TempDocsTable(""))

            TempItem.SubItems.Add(Guid.NewGuid().ToString())

            TempItem.SubItems.Add(1)

            TempItem.SubItems.Add("")

            TempItem.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

            Dim index As Integer = ListView1.Items.Count

            ListView1.Items.Insert(index, TempItem.Clone())

            ListView1.Items(index).BeginEdit()

            BtnNew.Enabled = False

        Catch ex As Exception
            ErrorManager.WriteMessage("BtnNew_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub DocList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            lblMessage.Text = String.Empty

            ToolTip1.SetToolTip(BtnNew, "پوشه جدید")

            ToolTip1.SetToolTip(btnBack, "بازگشت")

            ToolTip1.SetToolTip(btnDelete, "حذف")

            'ToolTip1.SetToolTip(btnRefresh, "به روز رسانی")

            ToolTip1.SetToolTip(btnCancelSearch, "لغو عملیات جستجو")

            ParentInfo = New DocParentInfo

            ParentInfo.docID = String.Empty

            ParentInfo.docType = String.Empty

            ListView1.ListViewItemSorter = New ListViewIndexComparer()

            ListView1.LabelEdit = True

            ListView1.AllowDrop = True

            btnCancelSearch.Visible = False

            ListView1.LargeImageList = New ImageList

            ListView1.LargeImageList.ImageSize = New Size(32, 32)

            LoadDefaultImage()

            BindChilds(String.Empty)

            '  BindTree(String.Empty)

            ' TreeView1.SelectedNode = TreeView1.Nodes(0)

            SetCurrentFile(" اسناد تیپ ")

        Catch ex As Exception
            '' ''ErrorManager.WriteMessage("DocList_Load", ex.ToString())
        End Try

    End Sub

    Private Sub SetCurrentFile(ByVal filename As String)

        If filename = String.Empty Then

            filename = "اسناد تیپ"
        End If

        txtCurrentFile.Text = "پوشه جاری ---> " & filename


    End Sub

    Private Sub ListView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter

        Try

            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ListView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop

        lblMessage.Text = String.Empty

        Dim files() As String
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                files = e.Data.GetData(DataFormats.FileDrop)

            Else

                Exit Sub

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("ListView1_DragDrop,Part1", ex.ToString(), Me.ParentForm.Text)
            Exit Sub
        End Try

        Dim th As New Threading.Thread(AddressOf AddFile)


        l = New Loading

        Me.Controls.Add(l)

        l.BringToFront()

        l.Location = New Drawing.Point(200, 200)

        Try


            th.Start(files)

            'AddFile(files)
        Catch ex As Exception

            th.Abort()
            ErrorManager.WriteMessage("ListView1_DragDrop,Part2", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub btnDelete_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelete.DragEnter

        Try
            e.Effect = DragDropEffects.Copy

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDelete_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnDelete.DragDrop

        lblMessage.Text = String.Empty

        Try

           
            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "DocList" Then

                Dim myItems() As ListViewItem = data.Item(1)

                RaiseEvent ConfirmDeleteDrag(myItems)

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("btnDelete_DragDrop", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        lblMessage.Text = String.Empty

        Try

            If ListView1.SelectedItems IsNot Nothing AndAlso ListView1.SelectedItems.Count > 0 Then

                RaiseEvent ConfirmDelete(ListView1.SelectedItems)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            lblMessage.Text = String.Empty

            'BindTree(String.Empty)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripAddFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripAddFile.Click
        Try


            lblMessage.Text = String.Empty

            BrowseImage()

        Catch ex As Exception
            ErrorManager.WriteMessage("ToolStripAddFile_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick

        lblMessage.Text = String.Empty

        Try

            ' Directory
            If ListView1.SelectedItems(0).SubItems(2).Text Then

                'for treeView
                If ParentInfo.docID = String.Empty Then

                    treeParentId = ListView1.SelectedItems(0).SubItems(1).Text

                End If
                ' 1- گرفتن مشخصات Parent
                ParentInfo.docID = ListView1.SelectedItems(0).SubItems(1).Text
                ParentInfo.docType = ListView1.SelectedItems(0).Text
                SetCurrentFile(ListView1.SelectedItems(0).Text)
                '2 - گرفتن فرزندان

                BindChilds(ParentInfo.docID)





                'For Each Item As TreeNode In TreeView1.SelectedNode.Nodes

                '    If Item.Name = ParentInfo.docID Then

                '        ExpandNode(Item)
                '        Exit For

                '    End If

                'Next


                'File
            Else

                Dim file As String = TempDocManager.WriteFile(ListView1.SelectedItems(0).SubItems(1).Text, ListView1.SelectedItems(0).SubItems(3).Text)
                If Not String.IsNullOrEmpty(file) Then
                    If ListView1.SelectedItems(0).SubItems(3).Text = ".txt" OrElse ListView1.SelectedItems(0).SubItems(3).Text = ".dot" OrElse ListView1.SelectedItems(0).SubItems(3).Text = ".dotx" OrElse ListView1.SelectedItems(0).SubItems(3).Text = ".docx" OrElse ListView1.SelectedItems(0).SubItems(3).Text = ".doc" Then
                        ''abbas
                        'RaiseEvent ShowDocContent(ListView1.SelectedItems(0).SubItems(1).Text, file, "tempdocs", ListView1.SelectedItems(0).Text)

                        'abbas
                        'write filename,tablename,conString to textfile 

                        Lawyer.Common.VB.Common.FileManager.executeWordFile(ListView1.SelectedItems(0).SubItems(1).Text, file, ListView1.SelectedItems(0).Text, "tempdocs")


                    Else

                        System.Diagnostics.Process.Start(file)
                    End If

                End If

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("ListView1_DoubleClick", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        lblMessage.Text = String.Empty

        Try

            ' 1- گرفتن مشخصات Parent

            If ParentInfo.docID <> String.Empty Then
                ParentInfo = TempDocManager.GetParentinfoBychildId(ParentInfo.docID)
                '2 - گرفتن فرزندان

                BindChilds(ParentInfo.docID)


                SetCurrentFile(ParentInfo.docType)

                'ExpandNode(TreeView1.SelectedNode.Parent)
              

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("btnBack_Click", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub ListView1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit

        lblMessage.Text = String.Empty

        Try

            'تغییر پوشه ای که به صورت Temp ایجاد شده است
            BtnNew.Enabled = True

            Dim IsLabelNothing As Boolean = False

            Dim itemName As String = e.Label

            Dim curItem As ListViewItem

            If e.Label = "" OrElse e.Label.Trim() = "" Then

                itemName = ListView1.Items(e.Item).Text

                IsLabelNothing = True

            End If

            curItem = ListView1.Items(e.Item)

            'اضافه کردن پوشه
            If TempItem IsNot Nothing Then

                If Not String.IsNullOrEmpty(TempDocManager.IsExistDocName(itemName, ParentInfo.docID, curItem.SubItems(3).Text, curItem.SubItems(2).Text)) Then

                    e.CancelEdit = True

                    ListView1.Items.Remove(curItem)

                    ListView1.Refresh()

                    TempItem = Nothing

                    Exit Sub

                End If

                If IsLabelNothing Then

                    e.CancelEdit = True

                    curItem.Selected = True

                End If

                If Not AddDirectory(curItem, "USE", itemName) Then

                    ListView1.Items.Remove(curItem)
                    ListView1.Refresh()

                End If

                TempItem = Nothing

            Else

                If e.Label = "" OrElse e.Label.Trim() = "" Then

                    e.CancelEdit = True

                    Exit Sub

                End If

                Dim docId As String = (TempDocManager.IsExistDocName(itemName, ParentInfo.docID, curItem.SubItems(3).Text, curItem.SubItems(2).Text))

                If String.IsNullOrEmpty(docId) OrElse docId = curItem.SubItems(1).Text Then

                    If Not TempDocManager.EditDocName(curItem.SubItems(1).Text, e.Label, ParentInfo.docID, curItem.SubItems(2).Text) Then

                        e.CancelEdit = True

                    Else
                        Dim name As String = String.Empty
                        'for tree
                        If ParentInfo.docID = String.Empty Then

                            treeParentId = curItem.SubItems(1).Text

                            name = itemName

                        End If


                        'UpdateTree(treeParentId, name, False)

                    End If

                Else

                    e.CancelEdit = True

                    Exit Sub

                End If


            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("ListView1_AfterLabelEdit", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub ChangeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeName.Click

        lblMessage.Text = String.Empty

        Try

            ListView1.SelectedItems(0).BeginEdit()

        Catch ex As Exception

        End Try


    End Sub

    'Private Sub changeImage_Other_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles changeImage_Other.Click

    '    lblMessage.Text = String.Empty

    '    Try

    '        Dim pic As New BaseForm.Image

    '        OpenFileDialog1.FileName = String.Empty

    '        Me.OpenFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"

    '        If (Me.OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then


    '            pic.imagePath = OpenFileDialog1.FileName

    '            pic.imageID = Guid.NewGuid().ToString()

    '            pic.imageExtension = System.IO.Path.GetExtension(pic.imagePath)
    '            '
    '            pic.imageUpdateDate = Common.DateManager.GetFileUpdateDate()

    '            pic.imageName = System.IO.Path.GetFileNameWithoutExtension(pic.imagePath)

    '            Dim imageFullpath As String = pic.imageID & pic.imageUpdateDate & pic.imageExtension

    '            If BaseForm.ImageManager.AddImage(pic, imageFullpath) Then

    '                ListView1.LargeImageList.Images.Add(pic.imageID, Bitmap.FromFile(imageFullpath))

    '                For Each Item As ListViewItem In ListView1.SelectedItems

    '                    If TempDocManager.EditDocLogo(Item.SubItems(1).Text, pic.imageID) Then

    '                        Item.ImageKey = pic.imageID

    '                    End If

    '                Next


    '            End If

    '        End If

    '    Catch ex As Exception

    '    End Try


    'End Sub

    'Private Sub ChangeImage_default_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeImage_default.Click

    '    lblMessage.Text = String.Empty

    '    Try

    '        For Each Item As ListViewItem In ListView1.SelectedItems

    '            Dim imageid As String = BaseForm.ImageManager.GetDefaultIcon_TempDocsTable(Item.SubItems(3).Text)

    '            If Item.ImageKey <> imageid AndAlso TempDocManager.EditDocLogo(Item.SubItems(1).Text, imageid) Then

    '                Item.ImageKey = imageid

    '            End If

    '        Next

    '    Catch ex As Exception

    '    End Try


    'End Sub

    Private Sub ListView1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles ListView1.ItemDrag

        lblMessage.Text = String.Empty

        Try

            Dim _Bitmap As New Bitmap(My.Resources.row_color)

            moveCursor = New Cursor(_Bitmap.GetHicon)

            Dim _Bitmap2 As New Bitmap(My.Resources.row_gray)

            nodropCursor = New Cursor(_Bitmap2.GetHicon)

            Dim myData As New ArrayList

            myData.Add("DocList")

            Dim myItem As ListViewItem

            Dim i As Integer = 0

            Dim myItems((sender.SelectedItems.Count - 1)) As ListViewItem

            For Each myItem In sender.SelectedItems

                myItems(i) = myItem

                i = i + 1
            Next

            ''For Deleting
            'ItemDeleting = True

            myData.Add(myItems)

            sender.DoDragDrop(New DataObject("ArrayList", myData), DragDropEffects.Copy)

        Catch ex As Exception
            ErrorManager.WriteMessage("ListView1_ItemDrag", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub ListView1_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles ListView1.GiveFeedback

        lblMessage.Text = String.Empty

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




#End Region

#Region "Utility"

    Private Sub LoadDefaultImage()

        Try

            Dim list As BaseForm.ImageCollection = BaseForm.ImageManager.GetImagesByGroupName("TempDocs")

            If list IsNot Nothing Then

                For Each Item As BaseForm.Image In list

                    Dim imagefullPath As String = FileManager.GetDocsImagePath() & Item.imageID & Item.imageUpdateDate & Item.imageExtension

                    Dim imageKey As String = Item.imageID

                    If Not System.IO.File.Exists(imagefullPath) Then

                        BaseForm.ImageManager.WriteImage(imageKey, imagefullPath)

                    End If

                    ListView1.LargeImageList.Images.Add(Item.imageID, Bitmap.FromFile(imagefullPath))
                Next

            End If


        Catch ex As Exception
            ErrorManager.WriteMessage("LoadDefaultImage", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub BindChilds(ByVal parentId As String)

        Dim childs As DocChildInfoCollection = TempDocManager.GetChildDocsByParentID(parentId)

        ListView1.Clear()

        If childs IsNot Nothing Then

            For Each Item As DocChildInfo In childs

                Try

                    Dim imageKey As String = Item.docImageID

                    Dim imageFullpath As String = FileManager.GetDocsImagePath() & imageKey & Item.imageUpdateDate & Item.imageExtension

                    Dim imagelist As ImageList = ListView1.LargeImageList

                    If Not imagelist.Images.ContainsKey(imageKey) Then

                        If Not System.IO.File.Exists(imageFullpath) Then


                            BaseForm.ImageManager.WriteImage(imageKey, imageFullpath)

                        End If


                        Try
                            imagelist.Images.Add(imageKey, Bitmap.FromFile(imageFullpath))

                        Catch ex As Exception

                        End Try


                    End If

                    Dim l As New ListViewItem(Item.docName, Item.docImageID)

                    l.SubItems.Add(Item.docID)

                    l.SubItems.Add(Item.docIsCat)

                    l.SubItems.Add(Item.docExtension) 'Extension

                    ListView1.Items.Add(l)

                Catch ex As Exception
                    ErrorManager.WriteMessage("BindChilds", ex.ToString(), Me.ParentForm.Text)
                    lblMessage.Text = "خطا در بارگذاری مستندات"

                End Try

            Next


        End If

    End Sub

    Private Function AddDirectory(ByVal item As ListViewItem, ByVal docOwner As String, ByVal docname As String) As Boolean

        Try

            Dim doc As New TempDocs

            doc.docChild = ParentInfo.docID

            doc.docContent = String.Empty

            doc.docExtension = item.SubItems(3).Text

            doc.docID = item.SubItems(1).Text

            doc.docImageID = item.ImageKey

            doc.docIsCat = item.SubItems(2).Text

            doc.docName = docname

            doc.docOwner = docOwner

            doc.docType = String.Empty

            If TempDocManager.AddTempDocs(doc) Then

                ''If ParentInfo.docID = String.Empty Then

                ''    UpdateTree(doc.docID, doc.docName, True)

                ''Else

                ''    UpdateTree(treeParentId, Nothing, True)

                ''End If


                Return True

            Else

                Return False

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("AddDirectory", ex.ToString(), Me.ParentForm.Text)
            Return False

        End Try


    End Function

    Private Function IsTureFile(ByVal extension As String)

        extension = extension.ToLower()

        If extension = ".txt" OrElse extension = ".doc" OrElse extension = ".docx" OrElse extension = ".dot" OrElse extension = ".dotx" OrElse extension = ".jpg" _
        OrElse extension = ".gif" OrElse extension = ".png" OrElse extension = ".bmp" OrElse extension = ".tif" OrElse extension = ".tiff" OrElse extension = ".jpeg" _
         OrElse extension = ".pdf" OrElse extension = ".xls" OrElse extension = ".xlsx" Then

            Return True

        End If

        Return False

    End Function

    Public Sub Delete(ByVal myItems As ListViewItem())

        Try

            For Each Item As ListViewItem In myItems

                If TempDocManager.DeleteDocTemp(Item.SubItems(1).Text) <> 0 Then

                    'If CBool(Item.SubItems(2).Text) Then
                    '    'سطح اول
                    '    If ParentInfo.docID = String.Empty Then

                    '        TreeView1.Nodes(0).Nodes(Item.SubItems(1).Text).Remove()

                    '    Else

                    '        UpdateTree(treeParentId, Nothing, False)

                    '    End If

                    'End If

                    ListView1.Items.Remove(Item)

                End If

            Next

        Catch ex As Exception
            ErrorManager.WriteMessage("Delete, ListviewItem", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Public Sub Delete(ByVal myItems As ListView.SelectedListViewItemCollection)

        Try

            For Each Item As ListViewItem In myItems

                If TempDocManager.DeleteDocTemp(Item.SubItems(1).Text) <> 0 Then

                    ' ''If CBool(Item.SubItems(2).Text) Then
                    ' ''    'سطح اول
                    ' ''    If ParentInfo.docID = String.Empty Then

                    ' ''        TreeView1.Nodes(0).Nodes(Item.SubItems(1).Text).Remove()

                    ' ''    Else

                    ' ''        UpdateTree(treeParentId, Nothing, False)

                    ' ''    End If

                    ' ''End If

                    ListView1.Items.Remove(Item)

                End If

            Next
          
        Catch ex As Exception
            ErrorManager.WriteMessage("Delete, SelectedListViewItemCollection", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub BrowseImage()

        OpenFileDialog1.Multiselect = True

        OpenFileDialog1.FileName = String.Empty

        If (Me.OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            'اضافه کردن فایل Drop

            Dim th As New Threading.Thread(AddressOf AddFile)


            Dim files() As String = OpenFileDialog1.FileNames()

            l = New Loading

            Me.Controls.Add(l)

            l.BringToFront()

            l.Location = New Drawing.Point(200, 200)

            Try

                ' th.Start(files)
                AddFile(files)

            Catch ex As Exception

                th.Abort()
                ErrorManager.WriteMessage("BrowseImage", ex.ToString(), Me.ParentForm.Text)
            End Try

        End If

        OpenFileDialog1.Multiselect = False

    End Sub

    Private Delegate Sub RestartApplication(ByVal show As Boolean)


    Private Sub showLoading(ByVal show As Boolean)

        If show Then

            SyncLock (Me)

                l.Show()

                BtnNew.Enabled = False

            End SyncLock

        Else

            SyncLock (Me)

                If l IsNot Nothing Then

                    l.Hide()

                    l.Dispose()



                End If

                BtnNew.Enabled = True

            End SyncLock


        End If

    End Sub

    Private Function AddFile(ByVal Files As String()) As Boolean

        SyncLock (Me)

            Dim DoUpdate As RestartApplication

            DoUpdate = New RestartApplication(AddressOf showLoading)

            DoUpdate.Invoke(True)

            Dim extension As String

            Dim name As String

            For Each Item As String In Files

                Try

                    extension = System.IO.Path.GetExtension(Item)

                    name = System.IO.Path.GetFileName(Item)

                    If extension <> String.Empty AndAlso IsTureFile(extension) Then

                        Dim docOwner As String = "USE"

                        Dim doc As New TempDocs

                        doc.docName = System.IO.Path.GetFileNameWithoutExtension(Item)

                        doc.docExtension = System.IO.Path.GetExtension(Item)

                        doc.docIsCat = 0

                        If String.IsNullOrEmpty(TempDocManager.IsExistDocName(doc.docName, ParentInfo.docID, doc.docExtension, doc.docIsCat)) Then

                            doc.docChild = ParentInfo.docID

                            doc.docContent = String.Empty

                            doc.docID = Guid.NewGuid().ToString()

                            doc.docImageID = BaseForm.ImageManager.GetDefaultIcon_TempDocsTable(doc.docExtension)

                            doc.docOwner = docOwner

                            doc.docType = ParentInfo.docType

                            If ParentInfo.docID = String.Empty Then doc.docType = doc.docName

                            extension = doc.docExtension

                            doc.docContent = ""

                            If extension = ".doc" OrElse extension = ".docx" OrElse extension = ".doc" OrElse extension = ".dot" OrElse extension = ".txt" Then

                                Dim wordApp As Word.ApplicationClass = New Word.ApplicationClass

                                Dim file As Object = Item

                                Dim Nothingobj As Object = System.Reflection.Missing.Value

                                Dim objectFormat As Word.WdSaveFormat = WdSaveFormat.wdFormatPDF

                                Dim docWord As Document = wordApp.Documents.Open(file, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj, Nothingobj)

                                doc.docContent = docWord.Content.Text

                                docWord.Close()

                                wordApp.Quit()

                                docWord = Nothing

                                wordApp = Nothing

                            End If

                            If ParentInfo.docID = String.Empty Then doc.docType = doc.docName

                            doc.docFullPath = Item

                            If TempDocManager.AddTempDocs(doc) Then

                                Dim item1 As New ListViewItem(doc.docName, doc.docImageID)

                                item1.SubItems.Add(doc.docID)

                                item1.SubItems.Add(0)

                                item1.SubItems.Add(doc.docExtension)

                                ListView1.Items.Add(item1)

                            End If


                        Else

                            lblMessage.Text = "فایل تکراری می باشد."

                        End If

                    End If

                Catch ex As Exception

                    lblMessage.Text = ex.Message

                    ErrorManager.WriteMessage("AddFile", ex.ToString(), Me.ParentForm.Text)

                End Try

            Next

            DoUpdate.Invoke(False)

        End SyncLock




    End Function

#End Region

    '#Region "TreeView"

    '    Private Sub BindNode(ByRef node As TreeNode, ByVal childs As DocParentInfoCollection)


    '        For Each Item As DocParentInfo In childs

    '            Dim n As TreeNode = node.Nodes.Add(Item.docID, Item.docType, 2)

    '            'n.SelectedImageIndex = 2

    '            Dim c As DocParentInfoCollection = TempDocManager.GetChildDocsByParentIDForTree(Item.docID)

    '            If c IsNot Nothing AndAlso c.Count > 0 Then

    '                BindNode(n, c)

    '                n.ImageIndex = 0

    '                n.SelectedImageIndex = 1

    '            End If

    '        Next



    '    End Sub

    '    Private Sub TreeView1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    '        'TreeView1.SelectedNode = TreeView1.HitTest(e.X, e.Y).Node

    '    End Sub

    '    ' '' ''Private Sub BindTree(ByVal parentId As String)

    '    ' '' ''    Try

    '    ' '' ''        'Dim sc As TreeNode = TreeView1.SelectedNode

    '    ' '' ''        Dim treeImageList As New ImageList

    '    ' '' ''        treeImageList.Images.Add(New Bitmap(My.Resources.bullet_white))
    '    ' '' ''        treeImageList.Images.Add(New Bitmap(My.Resources.bullet_green161))
    '    ' '' ''        treeImageList.Images.Add(New Bitmap(My.Resources.bullet_blue_alt2))

    '    ' '' ''        'treeImageList.Images.Add(ListView1.LargeImageList.Images(BaseForm.ImageManager.GetDefaultIcon_TempDocsTable("")))

    '    ' '' ''        TreeView1.ImageList = treeImageList

    '    ' '' ''        TreeView1.Nodes.Clear()

    '    ' '' ''        Dim childs As DocParentInfoCollection = TempDocManager.GetChildDocsByParentIDForTree(parentId)

    '    ' '' ''        BindNode(TreeView1.Nodes.Add(String.Empty, "اسناد تیپ", 0, 1), childs)

    '    ' '' ''        'ExpandNode(sc)

    '    ' '' ''    Catch ex As Exception
    '    ' '' ''        ErrorManager.WriteMessage("BindTree", ex.ToString(), Me.ParentForm.Text)
    '    ' '' ''    End Try

    '    ' '' ''End Sub

    '    ' '' ''Private Sub UpdateTree(ByVal nodeKey As String, ByVal name As String, ByVal IsAddStatus As Boolean)

    '    ' '' ''    Try

    '    ' '' ''        'Dim sc As TreeNode = TreeView1.SelectedNode
    '    ' '' ''        'اضافه کردن پوشه در سطح اول


    '    ' '' ''        If ParentInfo.docID = String.Empty AndAlso IsAddStatus Then

    '    ' '' ''            Dim childs As DocParentInfoCollection = TempDocManager.GetChildDocsByParentIDForTree(nodeKey)

    '    ' '' ''            If childs Is Nothing OrElse childs.Count = 0 Then

    '    ' '' ''                TreeView1.Nodes(0).Nodes.Add(nodeKey, name, 2)

    '    ' '' ''            Else
    '    ' '' ''                BindNode(TreeView1.Nodes(0).Nodes.Add(nodeKey, name, 0, 1), childs)

    '    ' '' ''            End If


    '    ' '' ''        Else


    '    ' '' ''            TreeView1.Nodes(0).Nodes(nodeKey).Nodes.Clear()

    '    ' '' ''            'برای پوشه root
    '    ' '' ''            If name <> Nothing Then TreeView1.Nodes(0).Nodes(nodeKey).Text = name

    '    ' '' ''            Dim childs As DocParentInfoCollection = TempDocManager.GetChildDocsByParentIDForTree(nodeKey)
    '    ' '' ''            TreeView1.Nodes(0).Nodes(nodeKey).ImageIndex = 2
    '    ' '' ''            TreeView1.Nodes(0).Nodes(nodeKey).SelectedImageIndex = 2

    '    ' '' ''            If childs IsNot Nothing OrElse childs.Count > 0 Then
    '    ' '' ''                TreeView1.Nodes(0).Nodes(nodeKey).ImageIndex = 0
    '    ' '' ''                TreeView1.Nodes(0).Nodes(nodeKey).SelectedImageIndex = 1
    '    ' '' ''            End If
    '    ' '' ''            BindNode(TreeView1.Nodes(0).Nodes(nodeKey), childs)

    '    ' '' ''        End If

    '    ' '' ''        'ExpandNode(sc)

    '    ' '' ''    Catch ex As Exception
    '    ' '' ''        ErrorManager.WriteMessage("UpdateTree", ex.ToString(), Me.ParentForm.Text)
    '    ' '' ''    End Try


    '    ' '' ''End Sub

    '    ' '' ''Private Sub TreeView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ' '' ''    lblMessage.Text = String.Empty

    '    ' '' ''    Try

    '    ' '' ''        ' 1- گرفتن مشخصات Parent
    '    ' '' ''        If TreeView1.SelectedNode.Level = 1 Then

    '    ' '' ''            treeParentId = TreeView1.SelectedNode.Name

    '    ' '' ''        End If

    '    ' '' ''        ParentInfo.docID = TreeView1.SelectedNode.Name
    '    ' '' ''        ParentInfo.docType = TreeView1.SelectedNode.Text

    '    ' '' ''        SetCurrentFile(ParentInfo.docType)
    '    ' '' ''        '2 - گرفتن فرزندان

    '    ' '' ''        BindChilds(ParentInfo.docID)

    '    ' '' ''    Catch ex As Exception
    '    ' '' ''        ErrorManager.WriteMessage("TreeView1_DoubleClick", ex.ToString(), Me.ParentForm.Text)
    '    ' '' ''    End Try

    '    ' '' ''End Sub

    '    'Private Sub ExpandNode(ByVal node As TreeNode)

    '    '    TreeView1.SelectedNode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))

    '    '    Dim str As String = TreeView1.PathSeparator
    '    '    TreeView1.SelectedNode = node

    '    '    'If TreeView1.SelectedNode.IsExpanded Then
    '    '    '    TreeView1.SelectedNode.Collapse()
    '    '    '    TreeView1.SelectedNode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
    '    '    'Else
    '    '    TreeView1.SelectedNode.Expand()
    '    '    'TreeView1.SelectedNode = TreeView1.SelectedNode.Nodes(0)
    '    '    TreeView1.SelectedNode.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(61, Byte), Integer))
    '    '    'End If

    '    'End Sub


    '#End Region

#Region "Search"

    Private Sub txtFileName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFileName.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then

                SetCurrentFile("لیست جستجو")
                ''SplitContainer1.Panel2Collapsed = True
                BindChildsByFullText()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BindChildsByFullText()

        Try

            If txtFileName.Text.Trim() <> String.Empty Then

                Dim childs As DocChildInfoCollection = TempDocManager.GetFilesByFulltextSearch(txtFileName.Text)

                ListView1.Clear()

                If childs IsNot Nothing Then

                    For Each Item As DocChildInfo In childs

                        Dim imageKey As String = Item.docImageID

                        Dim imageFullpath As String = FileManager.GetDocsImagePath() & imageKey & Item.imageUpdateDate & Item.imageExtension

                        Dim imagelist As ImageList = ListView1.LargeImageList

                        If Not imagelist.Images.ContainsKey(imageKey) Then

                            If Not System.IO.File.Exists(imageFullpath) Then


                                BaseForm.ImageManager.WriteImage(imageKey, imageFullpath)

                            End If

                            Try
                                imagelist.Images.Add(imageKey, Bitmap.FromFile(imageFullpath))
                            Catch ex As Exception

                            End Try


                        End If

                        Dim l As New ListViewItem(Item.docName, Item.docImageID)

                        l.SubItems.Add(Item.docID)

                        l.SubItems.Add(Item.docIsCat)

                        l.SubItems.Add(Item.docExtension) 'Extension

                        ListView1.Items.Add(l)

                    Next


                End If

            End If
           

            SetForSearch(False)

        Catch ex As Exception
            ErrorManager.WriteMessage("BindChildsByFullText", ex.ToString(), Me.ParentForm.Text)
        End Try
       

    End Sub

    Private Sub SetForSearch(ByVal ignoreSearch As Boolean)

        If ignoreSearch Then

            BindChilds(String.Empty)

            btnCancelSearch.Visible = False

            txtFileName.Text = String.Empty

            pnlActions.Enabled = True

            ListView1.ContextMenuStrip = ContextMenuStrip1

            ListView1.AllowDrop = True

            '' SplitContainer1.Panel2Collapsed = False

            SetCurrentFile("اسناد تیپ")

        Else

            btnCancelSearch.Visible = True

            pnlActions.Enabled = False

            ListView1.ContextMenuStrip = Nothing

            ListView1.AllowDrop = False


        End If

    End Sub

    Private Sub btnCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelSearch.Click
        lblMessage.Text = String.Empty

        SetForSearch(True)

    End Sub

    Public Sub Search(ByVal searchStr As String)

        txtFileName.Text = searchStr

        SetCurrentFile("لیست جستجو")
        ''SplitContainer1.Panel2Collapsed = True
        BindChildsByFullText()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        BindChildsByFullText()
    End Sub

#End Region

  
   
End Class
