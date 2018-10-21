Imports System.IO
Imports NwdSolutions.Web.GeneralUtilities
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.Competencys
Imports Lawyer.Common.VB.Competencys.Enums
Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB.LawyerError


Public Class CompetencySearch

#Region "- Property -"

    Private _CompetencyOnGrid As CompetencyOnGrid
    Public Property Pro_CompetencyOnGrid() As CompetencyOnGrid
        Get
            Return _CompetencyOnGrid
        End Get
        Set(ByVal value As CompetencyOnGrid)
            _CompetencyOnGrid = value
        End Set
    End Property


#End Region

#Region "- New -"

    Public Sub New()

        InitializeComponent()
        Me.dgvLaws.EditMode = DataGridViewEditMode.EditOnEnter

    End Sub

#End Region

#Region "- Load -"

    Private Sub CompetencySearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        ' Me.ActiveControl = Me.txtTitle

    End Sub

    Private Sub LawSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each c As Control In Me.Panel1.Controls
            c.AllowDrop = True
        Next

        Me.lblMessage.Text = String.Empty
        PopulateDataGridView()

        Try
            Me.txtTitle.AutoCompleteCustomSource = CompetencyOnGridManager.GettsStateCollection(Me.txtTitle.Text)
        Catch ex As Exception
            Me.lblMessage.Text = "خطا در نمایش بارگذاری استانها"
            ErrorManager.WriteMessage("LawSearch_Load()", ex.ToString, Me.Text)
        End Try


        ToolTip1.SetToolTip(btnAdd, "صلاحیت جدید")
        ToolTip1.SetToolTip(pbDel, "حذف صلاحیت")
        ToolTip1.SetToolTip(pbEdit, "ویرایش صلاحیت")


    End Sub

    Sub PopulateDataGridView()

        With Me.dgvLaws
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoGenerateColumns = False
            .Columns.Clear()
        End With

        '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        '0
        Me.dgvLaws.Columns.Add("tsid", "")
        With Me.dgvLaws.Columns("tsid")
            .DataPropertyName = "tsid"
            .Visible = False
        End With

        '1
        Me.dgvLaws.Columns.Add("tsState", "استان")
        With Me.dgvLaws.Columns("tsState")
            .DataPropertyName = "tsState"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Automatic
            .Width = 90
        End With

        '2
        Me.dgvLaws.Columns.Add("tsProvince", "شهرستان")
        With Me.dgvLaws.Columns("tsProvince")
            .DataPropertyName = "tsProvince"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Automatic
            .Width = 85
        End With

        '3
        Me.dgvLaws.Columns.Add("tsName", "حوزه")
        With Me.dgvLaws.Columns("tsName")
            .DataPropertyName = "tsName"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Automatic
            .Width = 170
        End With

        '4
        Me.dgvLaws.Columns.Add("tsMapField", "")
        With Me.dgvLaws.Columns("tsMapField")
            .DataPropertyName = "tsMapField"
            .Visible = False
        End With

        '5
        Me.dgvLaws.Columns.Add("tsDescription", "")
        With Me.dgvLaws.Columns("tsDescription")
            .DataPropertyName = "tsDescription"
            .Visible = False
        End With

        '>>>>>>>>>>>>>>>>>>>>>>>>>>> ComboBoxColumn    >>>>>>>>>>>>>>>>>>>>>>>>>

        '6
        Dim dgvCbc__1 As New DataGridViewComboBoxColumn
        With dgvCbc__1
            .Name = "Shobe"
            .HeaderText = "شعبه"
            .Width = 80
            .DataPropertyName = "--"
            '.DropDownWidth = 20
            .FlatStyle = FlatStyle.Flat
        End With
        Me.dgvLaws.Columns.Add(dgvCbc__1)

        '>>>>>>>>>>>>>>>>>>>>>>>>>>> ButtonColumn    >>>>>>>>>>>>>>>>>>>>>>>>>

        '7
        Dim dgvBC As New DataGridViewButtonColumn
        With dgvBC
            .Name = "Select"
            .HeaderText = "انتخاب"
            .Text = "انتخاب"
            .Width = 50
            .UseColumnTextForButtonValue = True
        End With
        Me.dgvLaws.Columns.Add(dgvBC)


        '8
        Dim dgvBCShow As New DataGridViewButtonColumn
        With dgvBCShow
            .Name = "View"
            .HeaderText = "نقشه"
            ' .Text = "مشاهده"
            .Width = 40
            .UseColumnTextForButtonValue = True
            .ToolTipText = "مشاهده نقشه"
        End With
        Me.dgvLaws.Columns.Add(dgvBCShow)

        '---------------------------------------------

        'For Each dgvCol As DataGridViewColumn In Me.dgvLaws.Columns
        '    dgvCol.SortMode = DataGridViewColumnSortMode.Programmatic
        'Next
        ' Me.dgvLaws.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect

    End Sub

#End Region

#Region "- Search -"

    Private Sub txtTitle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTitle.KeyDown

        'If e.KeyChar = "+" Then
        '    e.Handled = True
        '    TextBox2.Focus()
        'End If

        If e.KeyCode = Keys.Return And (Not String.IsNullOrEmpty(Me.txtTitle.Text)) Then

            FillGrid()

        End If


    End Sub

    Sub FillGrid()

        Try

            If String.IsNullOrEmpty(txtTitle.Text) Then
                Exit Sub
            End If

            Me.lblMessage.Text = String.Empty


            Dim _tsType As Integer
            Select Case True
                Case Me.rbMojtame.Checked
                    _tsType = tsType.مجتمع
                Case Me.rbDadsara.Checked
                    _tsType = tsType.دادسرا
                Case Me.rbShebhe.Checked
                    _tsType = tsType.شبهه
                Case Me.rbShura.Checked
                    _tsType = tsType.شورا
                Case Me.rbDivan.Checked
                    _tsType = tsType.دیوانعالی
                Case Me.rbEdalat.Checked
                    _tsType = tsType.عدالت

            End Select

            dgvLaws.DataSource = CompetencyOnGridManager.GetToolssalahiatSelByTsStateForGird_Like_DataTable(txtTitle.Text, _tsType)

            Me.dgvLaws.Focus()

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در انجام جستجو"
            ErrorManager.WriteMessage("FillGrid()", ex.ToString, Me.Text)
        End Try


    End Sub


    Private Sub dgvLaws_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvLaws.CellPainting


        If e.ColumnIndex = Me.dgvLaws.Columns("View").Index And e.RowIndex > -1 Then

            Dim img As Image = My.Resources.map32

            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            'e.Graphics.FillRectangle(Brushes.Magenta, e.CellBounds.Left + 10, e.CellBounds.Top + 5, 10, 10)
            'e.Graphics.DrawImage(img, e.CellBounds.Location)
            e.Graphics.DrawImage(img, e.CellBounds.Left + 4, e.CellBounds.Top + 3, 32, 15)
            e.Handled = True

        End If


    End Sub

    Private Sub dgvLaws_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvLaws.DataBindingComplete

        'Also Effect after Sorting

        Try

            For i As Integer = 0 To Me.dgvLaws.RowCount - 1

                Dim CC1 As New CompetencyOnGridCollection
                CC1 = CompetencyOnGridManager.GetsToolssalahiatbranchesSelByTsidAndTsbType(CType(Me.dgvLaws.Rows(i).Cells(0).Value, Guid).ToString, tsbType.شعبه)

                Dim cboShobe As New DataGridViewComboBoxCell
                cboShobe.DataSource = CC1
                cboShobe.DisplayMember = "tsbName"
                cboShobe.ValueMember = "tsbID"

                If CC1.Count > 0 Then
                    Me.dgvLaws.Rows(i).Cells(Me.dgvLaws.Columns("Shobe").Index) = cboShobe
                    ' Me.dgvLaws.Rows(i).Cells(5).Value = Collection__1.Item(0).tsbName
                    'Me.dgvLaws.UpdateCellValue(5, i)
                Else
                    '  Me.dgvLaws.Rows(i).Cells(Me.dgvLaws.Columns("view").Index).Value = String.Empty
                End If


                'Dim CC2 As New CompetencyOnGridCollection
                'CC2 = CompetencyOnGridManager.GetsToolssalahiatbranchesSelByTsidAndTsbType(CType(Me.dgvLaws.Rows(i).Cells(0).Value, Guid).ToString, tsbType.کلانتری)

                'Dim cboKalantary As New DataGridViewComboBoxCell
                'cboKalantary.DataSource = CC2
                'cboKalantary.DisplayMember = "tsbName"
                'cboKalantary.ValueMember = "tsbID"

                'Me.dgvLaws.Rows(i).Cells(Me.dgvLaws.Columns("Kalantary").Index) = cboKalantary

                'If CC2.Count > 0 Then
                '    ' Me.dgvLaws.Rows(i).Cells(6).Value = Collection__2.Item(0).tsbName
                '    'Me.dgvLaws.UpdateCellValue(6, i)
                'End If

            Next

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در پر کردن کمبوها"
            ErrorManager.WriteMessage("dgvLaws_DataBindingComplete()", ex.ToString, Me.Text)
        End Try

    End Sub

    'Private Sub dgvLaws_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvLaws.DataError
    '    'Sarandy: For No Error
    'End Sub

#End Region

#Region " Radio Button "

    Private Sub rbMojtame_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMojtame.CheckedChanged

        If Me.rbMojtame.Checked Then
            FillGrid()

        End If


    End Sub

    Private Sub rbDadsara_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDadsara.CheckedChanged

        If Me.rbDadsara.Checked Then
            FillGrid()
        End If


    End Sub

    Private Sub rbShebhe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbShebhe.CheckedChanged

        If Me.rbShebhe.Checked Then
            FillGrid()
        End If

    End Sub

    Private Sub rbShura_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbShura.CheckedChanged

        If Me.rbShura.Checked Then
            FillGrid()
        End If

    End Sub

    Private Sub rbDivan_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbDivan.CheckedChanged

        If Me.rbDivan.Checked Then
            FillGrid()
        End If

    End Sub

    Private Sub rbEdalat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEdalat.CheckedChanged

        If Me.rbEdalat.Checked Then
            FillGrid()
        End If
    End Sub

#End Region

#Region "- DataGrid Event -"

    Private Sub dgvLaws_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLaws.RowEnter

        ' Me.txtNote.Text = String.Empty

        If Me.dgvLaws.Rows(e.RowIndex).Cells.Count > 1 Then
            Me.txtNote.Text = Me.dgvLaws.Rows(e.RowIndex).Cells(Me.dgvLaws.Columns("tsDescription").Index).Value
        End If


    End Sub

    Private Sub dgvLaws_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLaws.CellClick

        Try


            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Button Click on Grid >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            If e.RowIndex > -1 And (e.ColumnIndex = Me.dgvLaws.Columns("Select").Index Or e.ColumnIndex = Me.dgvLaws.Columns("View").Index) Then


                If e.ColumnIndex = Me.dgvLaws.Columns("Select").Index Then

                    Dim CompetencyOnGrid As New CompetencyOnGrid

                    CompetencyOnGrid.tsid = Me.dgvLaws(Me.dgvLaws.Columns("tsid").Index, e.RowIndex).Value
                    CompetencyOnGrid.tsState = Me.dgvLaws(Me.dgvLaws.Columns("tsState").Index, e.RowIndex).Value
                    CompetencyOnGrid.tsProvince = Me.dgvLaws(Me.dgvLaws.Columns("tsProvince").Index, e.RowIndex).Value
                    CompetencyOnGrid.tsName = Me.dgvLaws(Me.dgvLaws.Columns("tsName").Index, e.RowIndex).Value
                    CompetencyOnGrid.tsMapField = Me.dgvLaws(Me.dgvLaws.Columns("tsMapField").Index, e.RowIndex).Value
                    'CompetencyOnGrid.tsDescription

                    CompetencyOnGrid.tsbID = Me.dgvLaws(Me.dgvLaws.Columns("Shobe").Index, e.RowIndex).Value ' after selecting combo have value
                    CompetencyOnGrid.tsbName = Me.dgvLaws(Me.dgvLaws.Columns("Shobe").Index, e.RowIndex).FormattedValue

                    Me.Pro_CompetencyOnGrid = CompetencyOnGrid
                    Me.Close()


                ElseIf e.ColumnIndex = Me.dgvLaws.Columns("View").Index Then


                    If Not IsDBNull(Me.dgvLaws(Me.dgvLaws.Columns("tsMapField").Index, e.RowIndex).Value) Then
                        Me.Map1.BindMap(Me.dgvLaws(Me.dgvLaws.Columns("tsMapField").Index, e.RowIndex).Value)
                    Else
                        Me.lblMessage.Text = "آدرس نقشه موجود نیست"
                    End If


                    'Dim CompetencyMap As New CompetencyMap
                    'CompetencyMap.CityStreet = Me.dgvLaws(Me.dgvLaws.Columns("tsMapField").Index, e.RowIndex).Value
                    'CompetencyMap.Show(Me)

                End If

            Else
                Return
            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ارسال اطلاعات"
            ErrorManager.WriteMessage("dgvLaws_CellClick()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#Region "- Command -"

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub pbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.dgvLaws.SelectedRows.Count > 0 Then
            EditCompetency(Me.dgvLaws.SelectedRows.Item(0).Cells(0).Value)
        End If

    End Sub

    Sub EditCompetency(ByVal _Tsid As Guid)

        Try

            Dim CompetencyAdd As New CompetencyAdd
            CompetencyAdd.Tsid = _Tsid 'edit mode
            CompetencyAdd.ShowDialog(Me)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ویرایش  "
            ErrorManager.WriteMessage("EditCompetency()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub pbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.dgvLaws.SelectedRows.Count > 0 Then
            DelCompetencyAndRelated(Me.dgvLaws.SelectedRows.Item(0).Cells(0).Value)
        End If

    End Sub

    Sub DelCompetencyAndRelated(ByVal _tsid As Guid)

        Try

            Dim dmb As New dadMessageBox("از حذف این صلاحیت مطمئن هستید؟", "هشدار")
            If dmb.ShowMessage() = DialogResult.Yes Then

                CompetencyManager.DeleteCompetency(_tsid) 'guid
                CompetencyBranchManager.DeleteCompetencyBranch(_tsid.ToString) 'string
                FillGrid()

            End If

            ' Dim response As MsgBoxResult = (MsgBox("از حذف این کتاب مطمئن هستید؟", MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNo))
            ' If response = MsgBoxResult.Yes Then
            ' End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در حذف صلاحیت"
            ErrorManager.WriteMessage("DelCompetencyAndRelated()", ex.ToString, Me.Text)
        End Try

    End Sub

#End Region

#Region "- Drag out grid -"

    Dim moveCursor, nodropCursor, copyCursor As Cursor

    Private Sub dgvLaws_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles dgvLaws.GiveFeedback

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

    Private Sub dgvLaws_CellMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvLaws.CellMouseDown

        Try

            If e.Clicks = 1 AndAlso e.RowIndex <> -1 AndAlso Not e.ColumnIndex = Me.dgvLaws.Columns("Select").Index AndAlso Not e.ColumnIndex = Me.dgvLaws.Columns("View").Index AndAlso Not e.ColumnIndex = Me.dgvLaws.Columns("Shobe").Index Then ' e.Clicks = 1 for work CellDoubleClick 'Not e.ColumnIndex = 7 for work cellclik on buttomn

                'If e.ColumnIndex = 2 Then

                Dim _Bitmap As New Bitmap(My.Resources.row_color)
                moveCursor = New Cursor(_Bitmap.GetHicon)

                Dim _Bitmap2 As New Bitmap(My.Resources.row_gray)
                nodropCursor = New Cursor(_Bitmap2.GetHicon)

                Me.dgvLaws.DoDragDrop(CType(Me.dgvLaws.Rows(e.RowIndex).Cells(0).Value, Guid), DragDropEffects.Copy)


                'If e.Button = Windows.Forms.MouseButtons.Left Then
                '    e.
                'End If


            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در درگ"
            ErrorManager.WriteMessage("dgvLaws_CellMouseDown()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#Region "- Drag In Delete -"


    Sub _DragEnter2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(GetType(Guid)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub pbDel_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        _DragEnter2(sender, e)

    End Sub

    Private Sub pbDel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(GetType(Guid)) Then
            Dim _Guid As New Guid
            _Guid = e.Data.GetData(GetType(Guid))

            DelCompetencyAndRelated(_Guid)

        End If

    End Sub

#End Region

#Region "- Drag In Edit -"

    Private Sub pbEdit_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

        _DragEnter2(sender, e)

    End Sub

    Private Sub pbEdit_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(GetType(Guid)) Then
            Dim _Guid As New Guid
            _Guid = e.Data.GetData(GetType(Guid))

            EditCompetency(_Guid)

        End If

    End Sub





#End Region

#Region "- Other -"

    Private Sub Map1_ShowMessage(ByVal msg As String) Handles Map1.ShowMessage

        Me.lblMessage.Text = msg

    End Sub

#End Region



    Private Sub dgvLaws_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLaws.CellDoubleClick

        Try

            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Button Click on Grid >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            If e.RowIndex > -1 And (e.ColumnIndex = Me.dgvLaws.Columns("tsState").Index Or e.ColumnIndex = Me.dgvLaws.Columns("tsProvince").Index Or e.ColumnIndex = Me.dgvLaws.Columns("tsName").Index) Then

                EditCompetency(Me.dgvLaws.Rows(e.RowIndex).Cells("tsid").Value)

            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ارسال اطلاعات"
            ErrorManager.WriteMessage("dgvLaws_CellDoubleClick()", ex.ToString, Me.Text)
        End Try

    End Sub

  
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim CompetencyAdd As New CompetencyAdd
        CompetencyAdd.ShowDialog(Me)
    End Sub

    Private Sub pbEdit_Click_1(sender As Object, e As EventArgs) Handles pbEdit.Click
        If Me.dgvLaws.SelectedRows.Count > 0 Then
            EditCompetency(Me.dgvLaws.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub pbDel_Click_1(sender As Object, e As EventArgs) Handles pbDel.Click
        If Me.dgvLaws.SelectedRows.Count > 0 Then
            DelCompetencyAndRelated(Me.dgvLaws.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub
End Class