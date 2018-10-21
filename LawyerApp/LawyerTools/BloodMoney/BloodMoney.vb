Imports Lawyer.Common.VB.BloodMoneys
Imports System.Text
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.LawyerError

Public Class BloodMoney

#Region "- Load -"

    Dim CurrentTn As New BmTreeNode
    Dim BmOnGridCollection_DataSource As New BmOnGridCollection
    Dim ISWomanPrice As Boolean


    Private Sub BloodMoney_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Dim a As Integer = 8
        'a = HS.General.Utilities.GetNullableValue(Of Integer)(8)



        Try

            Me.lblMessage.Text = String.Empty

            Me.lblMessage.Text = String.Empty

            Me.AllowDrop = True
            For Each c As Control In Me.Controls
                c.AllowDrop = True
            Next
            For Each c As Control In Me.pnlSide.Controls
                c.AllowDrop = True
            Next

            Me.lblMessage.Text = String.Empty

            BindTree(IIf(rdbMan.Checked, "M", "W"))

            PopulateDataGridView()

            Me.cbbBmiYear.DataSource = BmIndexManager.GetBmiYear
            'Me.cbbBmiYear.DisplayMember = "lawTypeName"
            'Me.cbbBmiYear.ValueMember = "lawTypeID"

            Dim CurYear As String = DateManager.GetCurrentYear

            For i = 0 To Me.cbbBmiYear.Items.Count - 1

                Dim _Year As Integer = CType(Me.cbbBmiYear.Items(i), Integer)
                If _Year = CInt(CurYear) Then
                    Me.cbbBmiYear.SelectedIndex = i
                End If
            Next

            ToolTip1.SetToolTip(pbEmail, "ایمیل")
            'ToolTip1.SetToolTip(pbFax, "فاکس")
            ToolTip1.SetToolTip(pbDel, "حذف")

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری صفحه"
            ErrorManager.WriteMessage("BloodMoney_Load()", ex.ToString, Me.Text)
        End Try



    End Sub

    Sub BindTree(ByVal sex As Char)

        Try
            Me.lblMessage.Text = String.Empty

            Dim BloodMoneyCollection As New BloodMoneyCollection
            BloodMoneyCollection = BloodMoneyManager.GetBloodMoneyForTree(sex)

            BmTree.BindTreeView(Me.TreeView1, BloodMoneyCollection, True)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری درخت"
            ErrorManager.WriteMessage("BindTree()", ex.ToString, Me.Text)
        End Try

    End Sub

    Sub PopulateDataGridView()

        With Me.dgvBm
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoGenerateColumns = False
            .Columns.Clear()
        End With

        '----------------------------

        '0
        Me.dgvBm.Columns.Add("bmName", "شرح")
        With Me.dgvBm.Columns("bmName")
            .DataPropertyName = "bmName"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .Width = 223
        End With

        ''---------------------------------------------

        '1
        Me.dgvBm.Columns.Add("QP", "درصد / تعداد")
        With Me.dgvBm.Columns("QP")
            .DataPropertyName = "QP"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Automatic
            .Width = 120
        End With

        ''---------------------------------------------

        '2
        Me.dgvBm.Columns.Add("CalculateValue", "ارزش")
        With Me.dgvBm.Columns("CalculateValue")
            .DataPropertyName = "CalculateValue"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Programmatic
            .Width = 120

            .DefaultCellStyle.Format = "c0"
        End With


        'With Me.DataGridView1.Rows
        '    .Add(New String() {"1", "Parker", "Seattle"})
        '    .Add(New String() {"2", "Parker", "New York"})
        '    .Add(New String() {"3", "Watson", "Seattle"})
        '    .Add(New String() {"4", "Jameson", "New Jersey"})
        '    .Add(New String() {"5", "Brock", "New York"})
        '    .Add(New String() {"6", "Conner", "Portland"})
        'End With

        'Dim lr As New List(Of String())
        'lr.Add(New String() {T1, Madde})

    End Sub

#End Region

#Region "- Drag out Tree -"

    Dim moveCursor, nodropCursor, copyCursor As Cursor

    Private Sub TreeView1_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles TreeView1.GiveFeedback

        e.UseDefaultCursors = False

        Select Case e.Effect
            Case DragDropEffects.Move
                Cursor.Current = moveCursor
            Case DragDropEffects.None
                Cursor.Current = nodropCursor
            Case DragDropEffects.Copy
                Cursor.Current = moveCursor '  Cursor.Current = copyCursor
        End Select

    End Sub

    Private Sub TreeView1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseDown

        TreeView1.SelectedNode = TreeView1.HitTest(e.X, e.Y).Node

    End Sub

    Private Sub TreeView1_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles TreeView1.ItemDrag

        Try

            Me.lblMessage.Text = String.Empty

            Dim BmTreeNode As New BmTreeNode
            BmTreeNode = e.Item

            If BmTreeNode.BloodMoney.Childs = 0 Then

                Dim _Bitmap As New Bitmap(My.Resources.row_color)
                moveCursor = New Cursor(_Bitmap.GetHicon)

                Dim _Bitmap2 As New Bitmap(My.Resources.row_gray)
                nodropCursor = New Cursor(_Bitmap2.GetHicon)

                Me.TreeView1.DoDragDrop(BmTreeNode, DragDropEffects.Copy)

            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در درگ از درخت"
            ErrorManager.WriteMessage("TreeView1_ItemDrag()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#Region "- Drag In DataGridView -"

    Sub _DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(GetType(BmTreeNode)) Then ' e.Data.GetDataPresent(DataFormats.StringFormat) 
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub dgvBm_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvBm.DragEnter

        _DragEnter(sender, e)

    End Sub

    Private Sub dgvBm_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles dgvBm.DragDrop

        If e.Data.GetDataPresent(GetType(BmTreeNode)) Then

            Me.lblMessage.Text = String.Empty

            CurrentTn = e.Data.GetData(GetType(BmTreeNode))
            ShowMsgOrCalculate(CurrentTn)

        End If

    End Sub

    Sub ShowMsgOrCalculate(ByVal BmTreeNode As BmTreeNode)

        Me.txtBmNameHeader.Text = BmTreeNode.BloodMoney.bmName

        If BmTreeNode.BloodMoney.bmCalcType = "P" Then

            Me.pnlPercent.Visible = True
            Me.acValue.Text = ""
            Me.acValue.Focus()
            Me.lblType.Text = BmTreeNode.BloodMoney.bmLawText ' Me.lblType.Text = "درصد"

        ElseIf BmTreeNode.BloodMoney.bmCalcType = "Q" Then

            Me.pnlPercent.Visible = True
            Me.acValue.Text = ""
            Me.acValue.Focus()
            Me.lblType.Text = BmTreeNode.BloodMoney.bmLawText 'Me.lblType.Text = "تعداد"

        ElseIf BmTreeNode.BloodMoney.bmCalcType = "N" Then '"F"

            Me.pnlPercent.Visible = True
            Me.acValue.Text = ""
            Me.acValue.Focus()
            Me.lblType.Text = BmTreeNode.BloodMoney.bmLawText  ' Me.lblType.Text = "مبلغ به ریال"

        ElseIf BmTreeNode.BloodMoney.bmCalcType = "F" OrElse BmTreeNode.BloodMoney.bmCalcType = "D" Then '"N"

            CalculateAndAddRow()
            FillGrid()

        End If

    End Sub

    Sub FillGrid()

        Try

            Me.lblMessage.Text = String.Empty

            Dim BindingSource As New BindingSource
            BindingSource.DataSource = BmOnGridCollection_DataSource

            Me.dgvBm.DataSource = BindingSource

            Dim Sum As Long = 0
            For i As Integer = 0 To BmOnGridCollection_DataSource.Count - 1
                Sum += BmOnGridCollection_DataSource(i).CalculateValue
            Next

            Me.tsslSum.Text = String.Format("{0:#,#}", Sum)
            Me.tsslCount.Text = BmOnGridCollection_DataSource.Count

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری گرید"
            ErrorManager.WriteMessage("FillGrid()", ex.ToString, Me.Text)
        End Try

    End Sub


#End Region

#Region "- Double Click TreeNode -"

    Private Sub TreeView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick

        If Not TreeView1.SelectedNode Is Nothing Then

            Me.lblMessage.Text = String.Empty

            CurrentTn = TreeView1.SelectedNode
            ShowMsgOrCalculate(CurrentTn)

        End If


    End Sub

#End Region

#Region "- CalculateAndAddRow -"

    Sub CalculateAndAddRow()


        Try

            Me.lblMessage.Text = String.Empty


            Dim BmiValue As Single = GetBmiValue()
            ' BmiValue = IIf(ISWomanPrice, BmiValue / 2, BmiValue)

            Dim BmOnGrid As New BmOnGrid
            BmOnGrid.bmName = CurrentTn.BloodMoney.bmName

            If CurrentTn.BloodMoney.bmCalcType = "P" Then

                BmOnGrid.QP = Me.acValue.Amount.ToString + " % "
                BmOnGrid.CalculateValue = BmiValue * (Me.CurrentTn.BloodMoney.bmValue * Me.acValue.Amount / 100 + Me.CurrentTn.BloodMoney.bmValueToBeAdded)
                'single & Double >>> Long

                '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                If Not CurrentTn.BloodMoney.bmLawText.Contains("ارش") Then '--------------ارش نباشد نصف میشود
                    BmOnGrid.CalculateValue = CheckWomanPrice(BmOnGrid.CalculateValue, BmiValue)
                End If
                '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            ElseIf CurrentTn.BloodMoney.bmCalcType = "Q" Then

                BmOnGrid.QP = Me.acValue.Amount.ToString + " تا "
                BmOnGrid.CalculateValue = (BmiValue * Me.CurrentTn.BloodMoney.bmValue) * Me.acValue.Amount

                ' If ISWomanPrice = False Then
                BmOnGrid.CalculateValue = CheckWomanPrice(BmOnGrid.CalculateValue, BmiValue)
                'End If

            ElseIf CurrentTn.BloodMoney.bmCalcType = "N" Then '"F"

                BmOnGrid.QP = "مقدار ثابت وارد شده"
                BmOnGrid.CalculateValue = Me.acValue.Amount

            ElseIf CurrentTn.BloodMoney.bmCalcType = "F" OrElse CurrentTn.BloodMoney.bmCalcType = "D" Then '"N"


                Select Case CurrentTn.BloodMoney.bmCalcType
                    Case "F"
                        BmOnGrid.QP = "مقدار ثابت محاسبه شده"
                    Case "D"
                        BmOnGrid.QP = "مقدار ثابت توضیح دار"
                End Select

                BmOnGrid.CalculateValue = BmiValue * Me.CurrentTn.BloodMoney.bmValue

                'If ISWomanPrice = False Then
                BmOnGrid.CalculateValue = CheckWomanPrice(BmOnGrid.CalculateValue, BmiValue)
                'End If

            End If

            BmOnGridCollection_DataSource.Add(BmOnGrid)

            '------------------------------- cheke for linke child

            Dim BmTreeNodeCollection As New List(Of BmTreeNode)
            BmTreeNodeCollection = CheckLinkeChilds(Me.CurrentTn.BloodMoney.bmID)

            If BmTreeNodeCollection IsNot Nothing AndAlso BmTreeNodeCollection.Count > 0 Then

                For i As Integer = 0 To BmTreeNodeCollection.Count - 1
                    CurrentTn = BmTreeNodeCollection(i)
                    ShowMsgOrCalculate(CurrentTn)
                Next
            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در انجام محاسبه"
            ErrorManager.WriteMessage("CalculateAndAddRow()", ex.ToString, Me.Text)
        End Try


    End Sub

    Function GetBmiValue() As Single

        Try

            Me.lblMessage.Text = String.Empty

            Dim BmiType As Integer

            Select Case True
                Case Me.rdbCamel.Checked
                    BmiType = Enums.BmiType.Camel
                Case Me.rdbCow.Checked
                    BmiType = Enums.BmiType.Cow
                Case Me.rdbSheep.Checked
                    BmiType = Enums.BmiType.Sheep
            End Select

            Dim BmiValue As Single = BmIndexManager.GetBmiValue(Me.cbbBmiYear.Text, BmiType)

            'Select Case True
            '    Case Me.rdbWoman.Checked
            '        BmiValue = BmiValue / 2
            'End Select

            Return BmiValue

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در گرفتن دیه سال"
            ErrorManager.WriteMessage("GetBmiValue()", ex.ToString, Me.Text)
        End Try


    End Function

    Function CheckWomanPrice(ByVal CalculateValue As Long, ByVal BmiValue As Single) As Long

        If Me.rdbWoman.Checked AndAlso CalculateValue > BmiValue / 3 Then

            'ISWomanPrice = True

            CalculateValue /= 2

            'For i As Integer = 0 To CurrentDataSource.Count - 1
            '    CurrentDataSource(i).CalculateValue /= 2
            'Next

        End If

        Return CalculateValue

    End Function

    Function CheckLinkeChilds(ByVal bmLinkedParentID As Integer) As List(Of BmTreeNode)

        Try

            Dim BloodMoneyCollection As New BloodMoneyCollection
            BloodMoneyCollection = BloodMoneyManager.GetLinkeChilds(bmLinkedParentID)


            Dim BmTreeNode As New BmTreeNode
            Dim BmTreeNodeCollection As New List(Of BmTreeNode)
            For i As Integer = 0 To BloodMoneyCollection.Count - 1
                BmTreeNode = New BmTreeNode(BloodMoneyCollection(i))
                BmTreeNodeCollection.Add(BmTreeNode)
            Next

            Return BmTreeNodeCollection


        Catch ex As Exception
            ErrorManager.WriteMessage("CheckLinkeChilds()", ex.ToString, Me.Text)
            Throw ex
        End Try

    End Function

#End Region

#Region "- Pnl Percent -"

    Private Sub acValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles acValue.KeyDown

        If e.KeyCode = Keys.Return And (Not String.IsNullOrEmpty(Me.acValue.Amount)) Then

            pbOk_Click(sender, e)

        End If
    End Sub

    Private Sub pbOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbOk.Click

        If Not String.IsNullOrEmpty(Me.acValue.Amount) Then

            CalculateAndAddRow()
            FillGrid()

            Clear()

        End If

    End Sub

    Private Sub pbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbCancel.Click

        Clear()

    End Sub

    Sub Clear()

        Me.txtBmNameHeader.Text = ""
        Me.acValue.Text = ""
        Me.pnlPercent.Visible = False

    End Sub

#End Region

#Region "- Drag out grid -"

    Private Sub dgvBm_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles dgvBm.GiveFeedback

        e.UseDefaultCursors = False

        Select Case e.Effect
            Case DragDropEffects.Move
                Cursor.Current = moveCursor
            Case DragDropEffects.None
                Cursor.Current = nodropCursor
            Case DragDropEffects.Copy
                Cursor.Current = moveCursor '  Cursor.Current = copyCursor
        End Select

    End Sub

    Private Sub dgvBm_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBm.CellMouseDown

        If e.RowIndex <> -1 Then

            'If e.ColumnIndex = 2 Then

            Dim _Bitmap As New Bitmap(My.Resources.row_color)
            moveCursor = New Cursor(_Bitmap.GetHicon)

            Dim _Bitmap2 As New Bitmap(My.Resources.row_gray)
            nodropCursor = New Cursor(_Bitmap2.GetHicon)


            Me.dgvBm.DoDragDrop(Me.dgvBm.Rows(e.RowIndex), DragDropEffects.Copy)

            'End If

        End If


    End Sub


#End Region

#Region "- Drag In Delete -"

    Sub _DragEnter2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub pbDel_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDel.DragEnter

        _DragEnter2(sender, e)

    End Sub

    Private Sub pbDel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDel.DragDrop

        If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then

            Dim DataGridViewRow As New DataGridViewRow
            DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)

            Me.dgvBm.Rows.Remove(DataGridViewRow) ' this effected on dadasource automatically

            FillGrid()

        End If


    End Sub

#End Region

#Region "- Drag in Email -"


    Dim frmEmail As New frmEmail

    Private Sub pbEmail_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbEmail.DragDrop

        Try

            Me.lblMessage.Text = String.Empty

            If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then


                Dim DataGridViewRow As New DataGridViewRow
                DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)


                Dim sb As New StringBuilder
                sb.Append(" شرح:  " + DataGridViewRow.Cells(0).Value + vbNewLine)
                sb.Append("  درصد / تعداد:  " + DataGridViewRow.Cells(1).Value + vbNewLine)
                sb.Append(" مبلغ به ریال:  " + DataGridViewRow.Cells(2).Value.ToString + vbNewLine)

                '>>> From_Email and DisplayName set inside frmEmail

                frmEmail.ESubject = "محاسبه دیه"
                frmEmail.EBody = sb.ToString
                'frmEmail.EAttachment = "c:\aa.as"
                frmEmail.ShowDialog()


            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در اطلاعات ایمیل"
            ErrorManager.WriteMessage("pbEmail_DragDrop()", ex.ToString, Me.Text)
        End Try


    End Sub

    Private Sub pbEmail_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbEmail.DragEnter

        _DragEnter2(sender, e)
        'If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
        '    Me.Email1.Visible = True
        'End If

    End Sub

    Private Sub pbEmail_DragLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEmail.DragLeave

        'Me.Email1.Visible = False
        'Me.Email1.Clear = True


    End Sub

    Private Sub pbEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEmail.Click

        If BmOnGridCollection_DataSource.Count > 0 Then ' email all of the rows

            Dim sb As New StringBuilder

            sb.Append(" شرح  " + "|" + "  درصد / تعداد  " + "|" + " مبلغ به ریال  " + vbNewLine)
            sb.Append("_________________________" + vbNewLine)
            For i = 0 To BmOnGridCollection_DataSource.Count - 1
                sb.Append(BmOnGridCollection_DataSource.Item(i).bmName + "  " + BmOnGridCollection_DataSource.Item(i).QP + "  " + BmOnGridCollection_DataSource.Item(i).CalculateValue.ToString + vbNewLine)
                sb.Append("_________________________" + vbNewLine)
            Next
            sb.Append(" مبلغ کل" + tsslSum.Text)

            '>>> From_Email and DisplayName set inside frmEmail

            frmEmail.ESubject = "محاسبه دیه"
            frmEmail.EBody = sb.ToString
            'frmEmail.EAttachment = "c:\aa.as"
            frmEmail.ShowDialog()


        End If

    End Sub


#End Region

#Region "- Drag in Fax -"


    'Dim frmFox As New frmFox

    'Private Sub pbFax_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbFax.DragDrop

    '    Try

    '        Me.lblMessage.Text = String.Empty

    '        If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then

    '            Dim DataGridViewRow As New DataGridViewRow
    '            DataGridViewRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)


    '            Dim sb As New StringBuilder
    '            sb.Append(" شرح:  " + DataGridViewRow.Cells(0).Value + vbNewLine)
    '            sb.Append("  درصد / تعداد:  " + DataGridViewRow.Cells(1).Value + vbNewLine)
    '            sb.Append(" مبلغ به ریال:  " + DataGridViewRow.Cells(2).Value.ToString + vbNewLine)

    '            'frmFox.FFileNam
    '            frmFox.frmTextRich = sb.ToString
    '            frmFox.ShowDialog()


    '        End If

    '    Catch ex As Exception
    '        Me.lblMessage.Text = "خطا در اطلاعات فاکس"
    '        ErrorManager.WriteMessage("pbFax_DragDrop()", ex.ToString, Me.Text)
    '    End Try


    'End Sub

    'Private Sub pbFax_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbFax.DragEnter

    '    _DragEnter2(sender, e)

    '    'If e.Data.GetDataPresent(GetType(DataGridViewRow)) Then
    '    '    Me.Fax1.Visible = True
    '    'End If

    'End Sub

    'Private Sub pbFax_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbFax.DragLeave

    '    'Me.Fax1.Visible = False
    '    'Me.Fax1.Clear = True

    'End Sub

    'Private Sub pbFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbFax.Click

    '    If BmOnGridCollection_DataSource.Count > 0 Then ' fax all of the rows

    '        Dim sb As New StringBuilder

    '        sb.Append(" شرح  " + "|" + "  درصد / تعداد  " + "|" + " مبلغ به ریال  " + vbNewLine)
    '        sb.Append("_________________________" + vbNewLine)
    '        For i = 0 To BmOnGridCollection_DataSource.Count - 1
    '            sb.Append(BmOnGridCollection_DataSource.Item(i).bmName + "  " + BmOnGridCollection_DataSource.Item(i).QP + "  " + BmOnGridCollection_DataSource.Item(i).CalculateValue.ToString + vbNewLine)
    '            sb.Append("_________________________" + vbNewLine)
    '        Next
    '        sb.Append(" مبلغ کل" + tsslSum.Text)

    '        'frmFox.FFileNam
    '        frmFox.frmTextRich = sb.ToString
    '        frmFox.ShowDialog()


    '    End If



    'End Sub

#End Region

#Region "- ImageView -"

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        If Not TreeView1.SelectedNode Is Nothing Then

            Me.lblMessage.Text = String.Empty

            Try

                Me.ImageViewer1.ImagePath = FileManager.GetBmPicPath ' App_Path() + "\bmPics"
                Me.ImageViewer1.ImageList = Field2List(CType(TreeView1.SelectedNode, BmTreeNode).BloodMoney.bmImages)

            Catch ex As Exception
                Me.lblMessage.Text = "خطا در نمایش تصاویر"
                ErrorManager.WriteMessage("TreeView1_AfterSelect()", ex.ToString, Me.Text)
            End Try


            Try

                Me.txtDescription.Text = CType(TreeView1.SelectedNode, BmTreeNode).BloodMoney.bmDescription

            Catch ex As Exception
                Me.lblMessage.Text = "خطا در نمایش توضیحات"
                ErrorManager.WriteMessage("TreeView1_AfterSelect()", ex.ToString, Me.Text)
            End Try


        End If


    End Sub

    Function Field2List(ByVal str As String) As List(Of String)


        If Not String.IsNullOrEmpty(str) Then

            Dim strArray() As String
            Dim Separators() As String = {","}

            strArray = str.Split(Separators, StringSplitOptions.None)


            Dim genericList As New List(Of String)
            genericList.AddRange(strArray) '------------ Convert Array to list

            Return genericList

        Else

            Return Nothing

        End If


    End Function

#End Region

#Region "- Command -"

    Private Sub rdbMan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMan.CheckedChanged

        If Me.rdbMan.Checked Then

            Me.dgvBm.Rows.Clear() ' this effected on dadasource automatically
            ' FillGrid()
            Me.tsslSum.Text = 0
            Me.tsslCount.Text = 0

        End If


        BindTree(IIf(rdbMan.Checked, "M", "W"))

    End Sub

    Private Sub rdbWoman_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbWoman.CheckedChanged


        If Me.rdbWoman.Checked Then

            Me.dgvBm.Rows.Clear() ' this effected on dadasource automatically
            ' FillGrid()
            Me.tsslSum.Text = 0
            Me.tsslCount.Text = 0

        End If


    End Sub

    Private Sub rdbCamel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCamel.CheckedChanged

        If Me.rdbCamel.Checked Then

            Me.dgvBm.Rows.Clear() ' this effected on dadasource automatically
            'FillGrid()
            Me.tsslSum.Text = 0
            Me.tsslCount.Text = 0

        End If




    End Sub

    Private Sub rdbCow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCow.CheckedChanged

        If Me.rdbCow.Checked Then

            Me.dgvBm.Rows.Clear() ' this effected on dadasource automatically
            ' FillGrid()
            Me.tsslSum.Text = 0
            Me.tsslCount.Text = 0

        End If


    End Sub

    Private Sub rdbSheep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSheep.CheckedChanged

        If Me.rdbSheep.Checked Then

            Me.dgvBm.Rows.Clear() ' this effected on dadasource automatically
            'FillGrid()
            Me.tsslSum.Text = 0
            Me.tsslCount.Text = 0

        End If


    End Sub

    Private Sub cbbBmiYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbBmiYear.SelectedIndexChanged

        Me.dgvBm.Rows.Clear() ' this effected on dadasource automatically
        'FillGrid()
        Me.tsslSum.Text = 0
        Me.tsslCount.Text = 0

    End Sub

#End Region

End Class