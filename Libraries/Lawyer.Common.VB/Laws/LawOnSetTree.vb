Imports System.Windows.Forms
Imports System.Drawing

Namespace Laws

    Public Class LawOnSetTree

        Public Shared Sub BindTreeView(ByRef Tv As TreeView, ByVal LawOnSetCollection As LawOnSetCollection, Optional ByVal GetChildNodes As Boolean = False)

            Try

                Tv.Nodes.Clear()

                Dim RootNode As TreeNode

                Tv.ImageList = CreateImageList()
                Tv.SelectedImageIndex = 5


                For i As Integer = 0 To LawOnSetCollection.Count - 1


                    If LawOnSetCollection(i).Childs = 0 Then
                        'ImageAddress = "../../Forms/others/Images/tik.png"
                        'ImageAddress = "../../Pic/Tree/Folder.gif"
                    Else
                        ' _ImageUrl = "../../Pic/Tree/Nioc.png"
                    End If



                    If LawOnSetCollection(i).ldParent = 0 Then '------A Root

                        RootNode = New TreeNode 'BmTreeNode(BloodMoneyCollection(i))
                        RootNode.Tag = LawOnSetCollection(i)

                        RootNode.Text = LawOnSetCollection(i).ldName

                        ' _Node.Value = BloodMoneyCollection(i).bmValue
                        ' _Node.ImageUrl = _ImageUrl
                        RootNode.ToolTipText = LawOnSetCollection(i).ldName
                        ' RootNode.Tag

                        ''-----------------------------------
                        'tv.ImageIndex = 0
                        'tv.SelectedImageIndex = 1
                        '' Me.rootImageIndex = 2

                        Select Case LawOnSetCollection(i).ldID
                            Case 2
                                ' RootNode.ImageIndex = 1

                            Case 4
                                ' RootNode.ImageIndex = 2
                            Case 7
                                '  RootNode.ImageIndex = 3

                            Case 5
                                '  RootNode.ImageIndex = 4
                            Case Else

                        End Select



                        Tv.Nodes.Add(RootNode) '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


                        If GetChildNodes = True Then
                            If LawOnSetCollection(i).Childs > 0 Then ' if has child ''------- Sarandy
                                AddChildNodesForBaseNode(RootNode, LawOnSetCollection)
                            End If
                        End If


                    End If


                Next


            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Sub

        Private Shared Sub AddChildNodesForBaseNode(ByRef BaseNode As TreeNode, ByVal LawOnSetCollection As LawOnSetCollection)

            Try

                Dim ChildNode As TreeNode 'BmTreeNode
                'Dim _ImageUrl As String = String.Empty

                Dim NewBmc As New LawOnSetCollection
                NewBmc = FilterCollection(LawOnSetCollection, CType(BaseNode.Tag, LawOnSet).ldID) 'BaseNode.BloodMoney.bmID


                For i As Integer = 0 To NewBmc.Count - 1

                    ChildNode = New TreeNode 'BmTreeNode(NewBmc(i))
                    ChildNode.Tag = NewBmc(i)

                    ChildNode.Text = NewBmc(i).ldName
                    ' _ChildNode.Value = DV.Item(i).Item("NodeID")
                    ' _ChildNode.ImageUrl = _ImageUrl
                    '_ChildNode.ToolTip = DV.Item(i).Item("Title")
                    'Item.ImageToolTip



                    If NewBmc(i).Childs = 0 Then
                        ChildNode.ImageIndex = 6
                        'ImageAddress = "../../Forms/others/Images/tik.png"
                        ' _ImageUrl = "../../Pic/Tree/Book.png"
                    Else
                        'ImageAddress = "../../Forms/others/Images/Plus.png"
                        '_ImageUrl = "../../Pic/Tree/Folder.gif"
                    End If




                    BaseNode.Nodes.Add(ChildNode)


                    If NewBmc(i).Childs > 0 Then '-------- if has child

                        AddChildNodesForBaseNode(ChildNode, LawOnSetCollection)

                    End If


                Next


            Catch ex As System.Exception
                Throw New Exception("Error!!!", ex)
            End Try

        End Sub

        Private Shared Function FilterCollection(ByVal bmc As LawOnSetCollection, ByVal ParentID As Integer) As LawOnSetCollection

            Dim IE As IEnumerable(Of LawOnSet) = bmc.Where(Function(bm, index) bm.ldParent = ParentID)

            Dim NewBmc As New LawOnSetCollection
            For Each bm As LawOnSet In IE
                NewBmc.Add(bm)
            Next

            Return NewBmc

        End Function


        '-------------------

        Private Shared Function CreateImageList() As ImageList


            Dim myImageList As New ImageList()
            myImageList.ImageSize = New Size(16, 16)


            myImageList.Images.Add(New Bitmap(My.Resources.bullet_white))
            myImageList.Images.Add(New Bitmap(My.Resources.eye16))
            myImageList.Images.Add(New Bitmap(My.Resources.ear16))
            myImageList.Images.Add(New Bitmap(My.Resources.tooth))
            myImageList.Images.Add(New Bitmap(My.Resources.lip))
            myImageList.Images.Add(New Bitmap(My.Resources.bullet_green161))
            myImageList.Images.Add(New Bitmap(My.Resources.bullet_blue_alt2))

            Return myImageList

        End Function


    End Class


End Namespace
