Imports WFControls.VB
Imports System.Threading
Imports System.IO

Public Class frmWinExplorer

    Private Shared Event1 As New ManualResetEvent(True)
    Private LastSelectedCSI As CShItem
    Dim testTime As New DateTime(1, 1, 1, 0, 0, 0)
    Dim moveCursor, nodropCursor As Cursor

    Private Sub SetUpComboBox(ByVal item As CShItem)
        BackList = New ArrayList()
        With cb1
            .Items.Clear()
            .Text = ""
            Dim CSI As CShItem = item
            Do While Not IsNothing(CSI.Parent)
                CSI = CSI.Parent
                BackList.Add(CSI)
                .Items.Add(CSI.DisplayName)
            Loop
            .SelectedIndex = -1
        End With
        lv1.Focus()
    End Sub

    Private Sub AfterNodeSelect(ByVal pathName As String, ByVal CSI As CShItem) Handles ExpTree1.ExpTreeNodeSelected
        Dim dirList As New ArrayList()
        Dim fileList As New ArrayList()
        Dim TotalItems As Integer
        LastSelectedCSI = CSI
        If CSI.DisplayName.Equals(CShItem.strMyComputer) Then
            dirList = CSI.GetDirectories 'avoid re-query since only has dirs
        Else
            dirList = CSI.GetDirectories
            fileList = CSI.GetFiles
        End If
        SetUpComboBox(CSI)
        TotalItems = dirList.Count + fileList.Count
        Event1.WaitOne()
        If TotalItems > 0 Then
            Dim item As CShItem
            dirList.Sort()
            fileList.Sort()
            Me.Text = pathName
            sbr1.Text = pathName & "                 " & _
                        dirList.Count & " Directories " & fileList.Count & " Files"
            Dim combList As New ArrayList(TotalItems)
            combList.AddRange(dirList)
            combList.AddRange(fileList)

            'Build the ListViewItems & add to lv1
            lv1.BeginUpdate()
            lv1.Items.Clear()
            For Each item In combList
                Dim lvi As New ListViewItem(item.DisplayName)
                With lvi
                    If Not item.IsDisk And item.IsFileSystem And Not item.IsFolder Then
                        If item.Length > 1024 Then
                            .SubItems.Add(Format(item.Length / 1024, "#,### KB"))
                        Else
                            .SubItems.Add(Format(item.Length, "##0 Bytes"))
                        End If
                    Else
                        .SubItems.Add("")
                    End If
                    .SubItems.Add(item.TypeName)
                    If item.IsDisk Then
                        .SubItems.Add("")
                    Else
                        If item.LastWriteTime = testTime Then '"#1/1/0001 12:00:00 AM#" is empty
                            .SubItems.Add("")
                        Else
                            .SubItems.Add(item.LastWriteTime)
                        End If
                    End If
                    '.ImageIndex = SystemImageListManager.GetIconIndex(item, False)
                    .Tag = item
                End With
                lv1.Items.Add(lvi)
            Next
            lv1.EndUpdate()
            LoadLV1Images()
        Else
            lv1.Items.Clear()
            sbr1.Text = pathName & " Has No Items"
        End If
    End Sub

    Private Sub LoadLV1Images()
        Dim ts As New ThreadStart(AddressOf DoLoadLv)
        Dim ot As New Thread(ts)
#If Ver = 2005 Then
            ot.SetApartmentState(ApartmentState.STA)
#Else
        ot.ApartmentState = ApartmentState.STA
#End If
        Event1.Reset()
        ot.Start()
    End Sub


    Private Sub DoLoadLv()
        Dim lvi As ListViewItem
        For Each lvi In lv1.Items
            lvi.ImageIndex = SystemImageListManager.GetIconIndex(lvi.Tag, False)
        Next
        Event1.Set()
    End Sub

    Private Sub lv1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv1.VisibleChanged
        If lv1.Visible Then
            SystemImageListManager.SetListViewImageList(lv1, True, False)
            SystemImageListManager.SetListViewImageList(lv1, False, False)
        End If
    End Sub

    Private BackList As ArrayList


    Private Sub cb1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb1.SelectedIndexChanged
        With cb1
            If .SelectedIndex > -1 AndAlso _
                 .SelectedIndex < BackList.Count Then
                Dim item As CShItem = BackList(.SelectedIndex)
                BackList = New ArrayList()
                .Items.Clear()
                ExpTree1.RootItem = item
            End If
        End With
    End Sub

    Private Sub lv1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lv1.MouseDoubleClick
        Dim lvi As ListViewItem = lv1.GetItemAt(e.X, e.Y)
        If IsNothing(lvi) Then Exit Sub
        If IsNothing(lv1.SelectedItems) OrElse lv1.SelectedItems.Count < 1 Then Exit Sub
        Dim item As CShItem = lv1.SelectedItems(0).Tag
        If item.IsFolder Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Event1.WaitOne()
                SetUpComboBox(item)
                ExpTree1.RootItem = item
            ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
                Event1.WaitOne()
                ExpTree1.ExpandANode(item)
            End If
        End If
    End Sub
    Private Sub lv1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lv1.ItemDrag
        'Debug.WriteLine("Item Drag -- Item = " & e.Item.text)
        With lv1
            If .SelectedItems.Count > 0 Then

                Dim _Bitmap As New Bitmap(My.Resources.row_color)

                moveCursor = New Cursor(_Bitmap.GetHicon)

                Dim _Bitmap2 As New Bitmap(My.Resources.row_gray)

                nodropCursor = New Cursor(_Bitmap2.GetHicon)


                Dim toDrag As New ArrayList()
                Dim lvItem As ListViewItem
                Dim strD(.SelectedItems.Count - 1) As String
                Dim i As Integer
                For Each lvItem In .SelectedItems
                    toDrag.Add(lvItem.Tag)
                    strD(i) = CType(lvItem.Tag, CShItem).Path
                    i += 1
                Next
                'NOTE: FileDrop allowing auto conversion will generate
                ' a Shell IDList Array on demand... but in some cases, the
                ' resultant PIDLs can be different from what we want, so
                ' do our own.
                Dim Dobj As New DataObject()
                Dim ms As MemoryStream
                ms = CProcDataObject.MakeShellIDArray(toDrag)
                With Dobj
                    If Not ms Is Nothing Then
                        .SetData("Shell IDList Array", True, ms)
                    End If
                    .SetData("FileDrop", True, strD)
                    .SetData(toDrag)
                End With
                Dim dEff As DragDropEffects
                'If e.Button = Windows.Forms.MouseButtons.Right Then
                '    dEff = DragDropEffects.Copy Or DragDropEffects.Move Or DragDropEffects.Link
                'Else
                'dEff = DragDropEffects.Copy Or DragDropEffects.Move
                'End If

                dEff = DragDropEffects.Copy
                Dim res As DragDropEffects = .DoDragDrop(Dobj, dEff)
                'Debug.WriteLine(res)
                'Debug.WriteLine("")
            End If
        End With
    End Sub

    Private Sub lv1_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles lv1.GiveFeedback

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

End Class