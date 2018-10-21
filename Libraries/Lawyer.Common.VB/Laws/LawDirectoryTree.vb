Imports System.Windows.Forms
Imports System.Drawing

Namespace Laws

    Public Class LawDirectoryTree

        Public Shared Sub BindTreeView(ByRef Tv As TreeView, ByVal LawDirectoryCollection As LawDirectoryCollection, ByVal LawOnSetCollection As LawOnSetCollection, ByVal CmsTree As ContextMenuStrip, ByVal CmsRoot As ContextMenuStrip, ByVal CmsLaw As ContextMenuStrip, Optional ByVal GetChildNodes As Boolean = False)

            Try

                Tv.Nodes.Clear()

                Dim RootNode As TreeNode

                Tv.ImageList = CreateImageList()

                Tv.SelectedImageIndex = 5


                For i As Integer = 0 To LawDirectoryCollection.Count - 1


                    If LawDirectoryCollection(i).Childs = 0 Then
                        'ImageAddress = "../../Forms/others/Images/tik.png"
                        'ImageAddress = "../../Pic/Tree/Folder.gif"
                    Else
                        ' _ImageUrl = "../../Pic/Tree/Nioc.png"
                    End If



                    If LawDirectoryCollection(i).ldParent = 0 Then '------A Root

                        RootNode = New TreeNode 'BmTreeNode(BloodMoneyCollection(i))
                        RootNode.Tag = LawDirectoryCollection(i)

                        RootNode.Text = LawDirectoryCollection(i).ldName

                        ' _Node.Value = BloodMoneyCollection(i).bmValue
                        ' _Node.ImageUrl = _ImageUrl
                        RootNode.ToolTipText = LawDirectoryCollection(i).ldName

                      

                        ''-----------------------------------
                        'tv.ImageIndex = 0
                        'tv.SelectedImageIndex = 1
                        '' Me.rootImageIndex = 2

                        Select Case LawDirectoryCollection(i).ldID
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


                        RootNode.ImageIndex = 7
                        RootNode.SelectedImageIndex = 7

                        RootNode.ContextMenuStrip = CmsRoot


                        Tv.Nodes.Add(RootNode) '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>




                        If GetChildNodes = True Then
                            If LawDirectoryCollection(i).Childs > 0 Then ' if has child ''------- Sarandy
                                AddChildNodesForBaseNode(RootNode, LawDirectoryCollection, LawOnSetCollection, CmsTree, CmsLaw)
                            End If
                        End If

                        '--------------------------------- expand
                        RootNode.Expand()


                    End If





                Next


            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Sub

        Private Shared Sub AddChildNodesForBaseNode(ByRef BaseNode As TreeNode, ByVal LawDirectoryCollection As LawDirectoryCollection, ByVal LawOnSetCollection As LawOnSetCollection, ByVal CmsTree As ContextMenuStrip, ByVal CmsLaw As ContextMenuStrip)

            Try

                Dim ChildNode As TreeNode 'BmTreeNode
                'Dim _ImageUrl As String = String.Empty

                Dim NewBmc As New LawDirectoryCollection
                NewBmc = FilterCollection(LawDirectoryCollection, CType(BaseNode.Tag, LawDirectory).ldID) 'BaseNode.BloodMoney.bmID


                For i As Integer = 0 To NewBmc.Count - 1

                    ChildNode = New TreeNode 'BmTreeNode(NewBmc(i))
                    ChildNode.Tag = NewBmc(i)

                    ChildNode.Text = NewBmc(i).ldName
                    ' _ChildNode.Value = DV.Item(i).Item("NodeID")
                    ' _ChildNode.ImageUrl = _ImageUrl
                    '_ChildNode.ToolTip = DV.Item(i).Item("Title")
                    'Item.ImageToolTip


                    If NewBmc(i).Childs = 0 Then

                        '  ChildNode.ImageIndex = 6

                        'ImageAddress = "../../Forms/others/Images/tik.png"
                        ' _ImageUrl = "../../Pic/Tree/Book.png"
                    Else
                        'ImageAddress = "../../Forms/others/Images/Plus.png"
                        '_ImageUrl = "../../Pic/Tree/Folder.gif"
                    End If


                    ChildNode.ContextMenuStrip = CmsTree

                    ChildNode.ImageIndex = 9 'folder close
                    ChildNode.SelectedImageIndex = 9 ' 8 'folder open

                    BaseNode.Nodes.Add(ChildNode)

                    '-------------------------add child for this node from other collection
                    AddGrandChildNodesForBaseNode(ChildNode, LawOnSetCollection, CmsLaw)
                    '--------------------------

                    If NewBmc(i).Childs > 0 Then '-------- if has child

                        AddChildNodesForBaseNode(ChildNode, LawDirectoryCollection, LawOnSetCollection, CmsTree, CmsLaw)

                    End If


                Next


            Catch ex As System.Exception
                Throw New Exception("Error!!!", ex)
            End Try

        End Sub


        Private Shared Sub AddGrandChildNodesForBaseNode(ByVal ChildNode As TreeNode, ByVal LawOnSetCollection As LawOnSetCollection, ByVal CmsLaw As ContextMenuStrip)

            Dim GrandChildNode As TreeNode 'BmTreeNode
            'Dim _ImageUrl As String = String.Empty

            Dim GcnC As New LawOnSetCollection
            GcnC = FilterLawOnSetCollection(LawOnSetCollection, CType(ChildNode.Tag, LawDirectory).ldID) 'BaseNode.BloodMoney.bmID


            For ii As Integer = 0 To GcnC.Count - 1

                GrandChildNode = New TreeNode 'BmTreeNode(NewBmc(i))
                GrandChildNode.Tag = GcnC(ii)

                GrandChildNode.Text = GcnC(ii).lawDetTitle + " " + GcnC(ii).lawTitle
                ' _ChildNode.Value = DV.Item(i).Item("NodeID")
                ' _ChildNode.ImageUrl = _ImageUrl
                '_ChildNode.ToolTip = DV.Item(i).Item("Title")
                'Item.ImageToolTip



                If GcnC(ii).Childs = 0 Then
                    GrandChildNode.ImageIndex = 6
                    'ImageAddress = "../../Forms/others/Images/tik.png"
                    ' _ImageUrl = "../../Pic/Tree/Book.png"
                Else
                    'ImageAddress = "../../Forms/others/Images/Plus.png"
                    '_ImageUrl = "../../Pic/Tree/Folder.gif"
                End If


                GrandChildNode.ImageIndex = 0
                GrandChildNode.SelectedImageIndex = 5

                GrandChildNode.ContextMenuStrip = CmsLaw

                ChildNode.Nodes.Add(GrandChildNode)

            Next


        End Sub


        Private Shared Function FilterCollection(ByVal bmc As LawDirectoryCollection, ByVal ParentID As Integer) As LawDirectoryCollection
            ''abbas
            ''Dim IE As IEnumerable(Of LawDirectory) = bmc.Where(Function(bm, index) bm.ldParent = ParentID)

            Dim NewBmc As New LawDirectoryCollection
            For Each bm As LawDirectory In bmc ''IE
                If bm.ldID = ParentID Then NewBmc.Add(bm)
                NewBmc.Add(bm)
            Next

            Return NewBmc

        End Function


        Private Shared Function FilterLawOnSetCollection(ByVal bmc As LawOnSetCollection, ByVal ParentID As Integer) As LawOnSetCollection
            ''abbas
            'Dim IE As IEnumerable(Of LawOnSet) = bmc.Find(Function(bm, index) bm.ldID = ParentID)

            Dim NewBmc As New LawOnSetCollection
            For Each bm As LawOnSet In bmc
                If bm.ldID = ParentID Then NewBmc.Add(bm)
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
            myImageList.Images.Add(New Bitmap(My.Resources.LawSet))
            myImageList.Images.Add(New Bitmap(My.Resources.folder))
            myImageList.Images.Add(New Bitmap(My.Resources.FolderClose))

            Return myImageList

        End Function



    End Class

End Namespace
