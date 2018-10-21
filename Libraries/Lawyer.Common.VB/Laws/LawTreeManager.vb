Imports System.Windows.Forms
Imports System.Drawing

Namespace Laws

    Public Class LawTreeManager


        Public Shared Sub BindTreeView(ByRef Tv As TreeView, ByVal LawOnGridCollection As LawOnGridCollection, ByVal LawDetailsCollection As LawDetailsCollection, Optional ByVal GetChildNodes As Boolean = False)

            Try

                Tv.Nodes.Clear()

                Dim RootNode As LawTreeNode

                Tv.ImageList = CreateImageList()
                Tv.SelectedImageIndex = 5


                For i As Integer = 0 To LawOnGridCollection.Count - 1


                    'If BloodMoneyCollection(i).Childs = 0 Then
                    '    'ImageAddress = "../../Forms/others/Images/tik.png"
                    '    'ImageAddress = "../../Pic/Tree/Folder.gif"
                    'Else
                    '    ' _ImageUrl = "../../Pic/Tree/Nioc.png"
                    'End If



                    ' If BloodMoneyCollection(i).bmParentID = 0 Then '------A Root

                    RootNode = New LawTreeNode '(BloodMoneyCollection(i))
                    RootNode.Tag = LawOnGridCollection(i)

                    Dim Constr As String
                    If LawOnGridCollection(i).lawTitle.Length > 60 Then
                        Constr = LawOnGridCollection(i).lawTitle.Substring(0, 60) + "..."
                    Else
                        Constr = LawOnGridCollection(i).lawTitle
                    End If

                    RootNode.Text = Constr
                    RootNode.ToolTipText = LawOnGridCollection(i).lawTitle

                    ' _Node.Value = BloodMoneyCollection(i).bmValue
                    ' _Node.ImageUrl = _ImageUrl


                    ''-----------------------------------
                    'tv.ImageIndex = 0
                    'tv.SelectedImageIndex = 1
                    '' Me.rootImageIndex = 2

                    Select Case LawOnGridCollection(i).lawID
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
                        'If LawOnGridCollection(i).Childs > 0 Then ' if has child ''------- Sarandy
                        AddChildNodesForBaseNode(RootNode, LawDetailsCollection)
                        'End If
                    End If


                    'End If


                Next


            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Sub


        Private Shared Sub AddChildNodesForBaseNode(ByRef BaseNode As LawTreeNode, ByVal LawDetailsCollection As LawDetailsCollection)

            Try

                Dim ChildNode As LawTreeNode
                'Dim _ImageUrl As String = String.Empty

                Dim NewLdc As New LawDetailsCollection
                NewLdc = FilterCollection(LawDetailsCollection, CType(BaseNode.Tag, LawOnGrid).lawID)


                For i As Integer = 0 To NewLdc.Count - 1

                    ChildNode = New LawTreeNode ' BmTreeNode(NewBmc(i))


                    Dim Constr As String
                    If NewLdc(i).lawDetContent.Length > 50 Then
                        Constr = NewLdc(i).lawDetContent.Substring(0, 50) + "..."
                    Else
                        Constr = NewLdc(i).lawDetContent
                    End If

                    ChildNode.Text = Constr
                    ChildNode.Tag = NewLdc(i)
                    ' _ChildNode.Value = DV.Item(i).Item("NodeID")
                    ' _ChildNode.ImageUrl = _ImageUrl
                    '_ChildNode.ToolTip = DV.Item(i).Item("Title")
                    'Item.ImageToolTip



                    'If NewBmc(i).Childs = 0 Then
                    ChildNode.ImageIndex = 6
                    '    'ImageAddress = "../../Forms/others/Images/tik.png"
                    '    ' _ImageUrl = "../../Pic/Tree/Book.png"
                    'Else
                    '    'ImageAddress = "../../Forms/others/Images/Plus.png"
                    '    '_ImageUrl = "../../Pic/Tree/Folder.gif"
                    'End If


                    '  BaseNode

                    BaseNode.Nodes.Add(ChildNode)


                    'If NewBmc(i).Childs > 0 Then '-------- if has child

                    '    AddChildNodesForBaseNode(ChildNode, BloodMoneyCollection)

                    'End If


                Next

            Catch ex As System.Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Sub

        Private Shared Function FilterCollection(ByVal Ldc As LawDetailsCollection, ByVal ParentID As Integer) As LawDetailsCollection
            ''abbas
            ''Dim IE As IEnumerable(Of LawDetails) = Ldc.Where(Function(Ld, index) Ld.lawID = ParentID)

            Dim NewLdc As New LawDetailsCollection
            For Each Ld As LawDetails In Ldc ''IE
                If Ld.lawID = ParentID Then NewLdc.Add(Ld)
            Next

            Return NewLdc

        End Function

       
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
