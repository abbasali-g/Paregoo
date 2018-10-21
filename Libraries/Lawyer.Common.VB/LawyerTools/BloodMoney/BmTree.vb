Imports System.Windows.Forms
Imports System.Drawing

Namespace BloodMoneys

    Public Class BmTree




        Public Shared Sub BindTreeView(ByRef Tv As TreeView, ByVal BloodMoneyCollection As BloodMoneyCollection, Optional ByVal GetChildNodes As Boolean = False)

            Try

                Tv.Nodes.Clear()

                Dim RootNode As BmTreeNode

                Tv.ImageList = CreateImageList()
                Tv.SelectedImageIndex = 5


                For i As Integer = 0 To BloodMoneyCollection.Count - 1


                    If BloodMoneyCollection(i).Childs = 0 Then
                        'ImageAddress = "../../Forms/others/Images/tik.png"
                        'ImageAddress = "../../Pic/Tree/Folder.gif"
                    Else
                        ' _ImageUrl = "../../Pic/Tree/Nioc.png"
                    End If



                    If BloodMoneyCollection(i).bmParentID = 0 Then '------A Root

                        RootNode = New BmTreeNode(BloodMoneyCollection(i))
                        RootNode.Text = BloodMoneyCollection(i).bmName

                        ' _Node.Value = BloodMoneyCollection(i).bmValue
                        ' _Node.ImageUrl = _ImageUrl
                        RootNode.ToolTipText = BloodMoneyCollection(i).bmName
                        ' RootNode.Tag

                        ''-----------------------------------
                        'tv.ImageIndex = 0
                        'tv.SelectedImageIndex = 1
                        '' Me.rootImageIndex = 2

                        Select Case BloodMoneyCollection(i).bmID
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
                            If BloodMoneyCollection(i).Childs > 0 Then ' if has child ''------- Sarandy
                                AddChildNodesForBaseNode(RootNode, BloodMoneyCollection)
                            End If
                        End If


                    End If


                Next


            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Sub

        Private Shared Sub AddChildNodesForBaseNode(ByRef BaseNode As BmTreeNode, ByVal BloodMoneyCollection As BloodMoneyCollection)

            Try

                Dim ChildNode As BmTreeNode
                'Dim _ImageUrl As String = String.Empty

                Dim NewBmc As New BloodMoneyCollection
                NewBmc = FilterCollection(BloodMoneyCollection, BaseNode.BloodMoney.bmID)


                For i As Integer = 0 To NewBmc.Count - 1

                    ChildNode = New BmTreeNode(NewBmc(i))
                    ChildNode.Text = NewBmc(i).bmName
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

                        AddChildNodesForBaseNode(ChildNode, BloodMoneyCollection)

                    End If


                Next


            Catch ex As System.Exception
                Throw New Exception("Error!!!", ex)
            End Try

        End Sub

        Private Shared Function FilterCollection(ByVal bmc As BloodMoneyCollection, ByVal ParentID As Integer) As BloodMoneyCollection
            ''abbas
            ''Dim IE As IEnumerable(Of BloodMoney) = bmc.Where(Function(bm, index) bm.bmParentID = ParentID)

            Dim NewBmc As New BloodMoneyCollection
            For Each bm As BloodMoney In bmc ''IE
                If bm.bmParentID = ParentID Then NewBmc.Add(bm)
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
