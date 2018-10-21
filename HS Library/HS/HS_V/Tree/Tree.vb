Imports System.Web.UI.WebControls

Namespace HS.Tree


    Public Class Tree

        'SELECT     CategoryID as NodeID, ISNULL(ParentID, 0) AS ParentID, [Name] as Title, Code,dbo.GetChildCount(CategoryID) as childCount
        'FROM         Category

        'SELECT @ChildCount=count(*)  FROM [BookMax].[dbo].[Category] where ParentID =@CatId


        Private _Dt As DataTable

        Public Sub BindTreeView(ByRef TreeView As TreeView, ByVal Dt As DataTable, Optional ByVal GetChildNodes As Boolean = False)

            Try

                TreeView.Nodes.Clear()

                Dim _Node As TreeNode
                Dim _ImageUrl As String = String.Empty



                For i As Integer = 0 To Dt.Rows.Count - 1


                    If Dt.Rows(i).Item("ChildCount") = 0 Then
                        'ImageAddress = "../../Forms/others/Images/tik.png"
                        'ImageAddress = "../../Pic/Tree/Folder.gif"
                    Else
                        _ImageUrl = "../../Pic/Tree/Nioc.png"
                    End If



                    If Dt.Rows(i).Item("ParentID") = 0 Then '------A Root

                        _Node = New TreeNode
                        _Node.Text = Dt.Rows(i).Item("Title")
                        _Node.Value = Dt.Rows(i).Item("NodeID")
                        _Node.ImageUrl = _ImageUrl
                        _Node.ToolTip = Dt.Rows(i).Item("Title")

                        TreeView.Nodes.Add(_Node) '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


                        If GetChildNodes = True Then

                            _Dt = Dt

                            If Dt.Rows(i).Item("ChildCount") > 0 Then ' if has child ''------- Sarandy

                                Dim NodeDV As New DataView(Dt)
                                NodeDV.RowFilter = "ParentID =" + _Node.Value

                                AddChildNodesOfThisNode(_Node, NodeDV)

                            End If

                        End If

                        'j += 1




                    End If
                Next




            Catch ex As Exception
                Throw New Exception("Error!!!", ex)
            End Try

        End Sub

        Private Sub AddChildNodesOfThisNode(ByRef _Node As TreeNode, ByVal DV As DataView)

            Try

                Dim _ChildNode As TreeNode
                Dim _ImageUrl As String = String.Empty


                For i As Integer = 0 To DV.Count - 1


                    If DV.Item(i).Item("ChildCount") = 0 Then
                        'ImageAddress = "../../Forms/others/Images/tik.png"
                        _ImageUrl = "../../Pic/Tree/Book.png"
                    Else
                        'ImageAddress = "../../Forms/others/Images/Plus.png"
                        _ImageUrl = "../../Pic/Tree/Folder.gif"
                    End If


                    _ChildNode = New TreeNode
                    _ChildNode.Text = DV.Item(i).Item("Title")
                    _ChildNode.Value = DV.Item(i).Item("NodeID")
                    _ChildNode.ImageUrl = _ImageUrl
                    _ChildNode.ToolTip = DV.Item(i).Item("Title")
                    'Item.ImageToolTip

                    _Node.ChildNodes.Add(_ChildNode) '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


                    If DV.Item(i).Item("ChildCount") > 0 Then '-------- if has child

                        Dim ChildNodeDV As New DataView(_Dt)
                        ChildNodeDV.RowFilter = "ParentID =" + _ChildNode.Value

                        AddChildNodesOfThisNode(_ChildNode, ChildNodeDV)

                    End If



                Next


            Catch ex As System.Exception
                Throw New Exception("Error!!!", ex)
            End Try

        End Sub


    End Class


End Namespace
