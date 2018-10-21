Imports Lawyer.Common.VB.BaseUserControl.ListView

Public Class DragAndDropListView

#Region "Properties"
    Private _ImageSize As Int16

    Public Property ImageSize() As Int16
        Get
            If _ImageSize = 0 Then Return 50
            Return _ImageSize
        End Get
        Set(ByVal value As Int16)
            _ImageSize = value
        End Set
    End Property

#End Region

    Public Sub Bind(ByVal items As DragAndDropListCollection)
        ListView1 = New ListView()
        ListView1.Dock = DockStyle.Fill
        ListView1.View = View.LargeIcon
        ListView1.MultiSelect = False
        ListView1.ListViewItemSorter = New ListViewIndexComparer()
        ListView1.InsertionMark.Color = ListView1.BackColor
        Dim imageListLarge As New ImageList()

        Dim imageindex As Integer = 0

        For Each Item As DragAndDropList In items


            imageListLarge.Images.Add(Bitmap.FromFile(Item.ImageUrl1))
            ListView1.Items.Add(Item.Title, imageindex)
            imageListLarge.Images.Add(Bitmap.FromFile(Item.ImageUrl2))
            ListView1.Items(imageindex).SubItems.Add(Item.Form)
            ListView1.Items.Add(imageindex).SubItems.Add(Item.ImageUrl1 & ";" & Item.ImageUrl2)
            imageindex += 2

        Next

        ''?????? پرکردن فیلدها یخالی بر حسب سایز listview

        imageListLarge.ImageSize = New Size(ImageSize, ImageSize)
        ListView1.LargeImageList = imageListLarge
        ' Initialize the drag-and-drop operation when running
        ' under Windows XP or a later operating system.
        ListView1.AllowDrop = True
    End Sub

    Private Sub ListView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop

        Dim targetIndex As Integer = ListView1.InsertionMark.Index
        If targetIndex = -1 Then
            Return
        End If

        Dim draggedItem As ListViewItem = CType(e.Data.GetData(GetType(ListViewItem)), ListViewItem)

        If draggedItem.Text = String.Empty Then Return

        ListView1.Items.Insert(targetIndex, CType(draggedItem.Clone(), ListViewItem))
        Dim item2 As ListViewItem = ListView1.Items(targetIndex + 1)
        If item2.Text = String.Empty Then
            ListView1.Items.Insert(draggedItem.Index, CType(item2.Clone(), ListViewItem))
            ListView1.Items.Remove(item2)
        End If
        ListView1.Items.Remove(draggedItem)

    End Sub

    Private Sub ListView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter
        e.Effect = e.AllowedEffect
    End Sub

    Private Sub ListView1_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DragLeave
        ListView1.InsertionMark.Index = -1
    End Sub

    Private Sub ListView1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragOver
        Dim targetPoint As Point = ListView1.PointToClient(New Point(e.X, e.Y))

        Dim targetIndex As Integer = ListView1.InsertionMark.NearestIndex(targetPoint)

        ListView1.InsertionMark.Index = targetIndex

    End Sub

    Private Sub ListView1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles ListView1.ItemDrag
        ListView1.DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub


End Class
