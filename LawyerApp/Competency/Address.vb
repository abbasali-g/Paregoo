Imports System.IO
Imports NwdSolutions.Web.GeneralUtilities
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.Competencys
Imports Lawyer.Common.VB.Competencys.Enums
Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB.LawyerError


Public Class Address


#Region "- Load -"

    Private Sub Address_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ActiveControl = Me.txtTitle

    End Sub

    Private Sub LawSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each c As Control In Me.Panel1.Controls
            c.AllowDrop = True
        Next

        Me.lblMessage.Text = String.Empty



        Dim SettingCollection As New SettingCollection
        SettingCollection = CompetencyManager.GetCompetencysEnumsTsType()
        Dim Setting As New Setting
        Setting.settingName = "همه موارد"
        Setting.settingValue = -100
        SettingCollection.Insert(0, Setting)

        Me.cbbtsType.DataSource = SettingCollection
        Me.cbbtsType.DisplayMember = "settingName"
        Me.cbbtsType.ValueMember = "settingValue"

        'Dim CompetencyCollection As New CompetencyCollection
        'CompetencyCollection = CompetencyManager.GetLawTypsForDrp
        '' Dim LawCat As New LawCat
        ''LawCatCollection.Insert(0, LawCat)

        'Me.cbbtsType.DataSource = CompetencyCollection
        'Me.cbbtsType.DisplayMember = "tsTypeEnums"
        'Me.cbbtsType.ValueMember = "tsType"


        PopulateDataGridView()

        Try
            ' Me.txtTitle.AutoCompleteCustomSource = CompetencyOnGridManager.GettsStateCollection(Me.txtTitle.Text)
        Catch ex As Exception
            'Me.lblMessage.Text = "خطا در نمایش بارگذاری استانها"
        End Try


        ToolTip1.SetToolTip(btnAdd, "صلاحیت جدید")
        ToolTip1.SetToolTip(pbDel, "حذف صلاحیت")
        ToolTip1.SetToolTip(pbEdit, "ویرایش صلاحیت")

        ToolTip1.SetToolTip(btnSearch, "جستجو")



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
        Me.dgvLaws.Columns.Add("settingName", "نوع")
        With Me.dgvLaws.Columns("settingName")
            .DataPropertyName = "settingName"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Automatic
            .Width = 100
        End With


        '4
        Me.dgvLaws.Columns.Add("tsName", "نام")
        With Me.dgvLaws.Columns("tsName")
            .DataPropertyName = "tsName"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Automatic
            .Width = 198
        End With


        '5
        Me.dgvLaws.Columns.Add("tsMapField", "")
        With Me.dgvLaws.Columns("tsMapField")
            .DataPropertyName = "tsMapField"
            .Visible = False
        End With

        '6
        Me.dgvLaws.Columns.Add("tsDescription", "")
        With Me.dgvLaws.Columns("tsDescription")
            .DataPropertyName = "tsDescription"
            .Visible = False
        End With


        '>>>>>>>>>>>>>>>>>>>>>>>>>>> ButtonColumn    >>>>>>>>>>>>>>>>>>>>>>>>>

        '7
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

        If e.KeyCode = Keys.Return And (Not String.IsNullOrEmpty(Me.txtTitle.Text)) Then
            FillGrid()
        End If
    End Sub
    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub

    Sub FillGrid()

        Try

            If String.IsNullOrEmpty(txtTitle.Text) Then
                Exit Sub
            End If

            Me.lblMessage.Text = String.Empty

            Dim _tsType As Integer = Me.cbbtsType.SelectedValue
            dgvLaws.DataSource = CompetencyOnGridManager.GetCompetencys_FullLike_DataTable(txtTitle.Text, _tsType)
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
            If e.RowIndex > -1 And (e.ColumnIndex = Me.dgvLaws.Columns("View").Index) Then 'Or e.ColumnIndex = Me.dgvLaws.Columns("Select").Index

                If Not IsDBNull(Me.dgvLaws(Me.dgvLaws.Columns("tsMapField").Index, e.RowIndex).Value) Then
                    Me.Map1.BindMap(Me.dgvLaws(Me.dgvLaws.Columns("tsMapField").Index, e.RowIndex).Value)
                Else
                    Me.lblMessage.Text = "آدرس نقشه موجود نیست"
                End If

            Else
                Return
            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در نمایش نقشه"
            ErrorManager.WriteMessage("dgvLaws_CellClick()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#Region "- Command -"

    Private Sub cbbtsType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbtsType.SelectedIndexChanged

        '    If Me.rbMojtame.Checked Then
        FillGrid()
        '    End If


    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim AddressAdd As New AddressAdd
        AddressAdd.ShowDialog(Me)

    End Sub

    Private Sub pbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEdit.Click

        If Me.dgvLaws.SelectedRows.Count > 0 Then
            EditCompetency(Me.dgvLaws.SelectedRows.Item(0).Cells(0).Value)
        End If

    End Sub

    Sub EditCompetency(ByVal _Tsid As Guid)

        Try

            Dim AddressAdd As New AddressAdd
            AddressAdd.Tsid = _Tsid 'edit mode
            AddressAdd.ShowDialog(Me)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ویرایش  "
            ErrorManager.WriteMessage("EditCompetency", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub pbDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDel.Click

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

    'Private Sub rdbCity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If rdbCity.Checked Then
    '        lblCity.Text = "شهر :"
    '        lblStreet.Text = "خیابان :"
    '    Else
    '        lblCity.Text = "طول جغرافیایی :"
    '        lblStreet.Text = "عرض جغرافیایی :"

    '    End If

    'End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            lblMessage.Text = String.Empty

            'If rdbCity.Checked Then
            ' Map1.BindMap(txtLat.Text, txtCity.Text)
            'Else
            'Map1.BindMapLatLong(txtCity.Text, txtLat.Text)
            ' End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در نمایش نقشه"
            ErrorManager.WriteMessage("btnSearch_Click()", ex.ToString, Me.Text)
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

            If e.Clicks = 1 AndAlso e.RowIndex <> -1 AndAlso Not e.ColumnIndex = Me.dgvLaws.Columns("View").Index Then ' AndAlso Not e.ColumnIndex = Me.dgvLaws.Columns("Select").Index' e.Clicks = 1 for work CellDoubleClick 'Not e.ColumnIndex = 7 for work cellclik on buttomn

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

    Private Sub pbDel_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDel.DragEnter

        _DragEnter2(sender, e)

    End Sub

    Private Sub pbDel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbDel.DragDrop

        If e.Data.GetDataPresent(GetType(Guid)) Then
            Dim _Guid As New Guid
            _Guid = e.Data.GetData(GetType(Guid))

            DelCompetencyAndRelated(_Guid)

        End If

    End Sub

#End Region

#Region "- Drag In Edit -"

    Private Sub pbEdit_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbEdit.DragEnter

        _DragEnter2(sender, e)

    End Sub

    Private Sub pbEdit_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles pbEdit.DragDrop

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

 
End Class