Imports Lawyer.Common.VB.tempDocs
Imports Lawyer.Common.VB.LawyerError

Public Class UcAddTempDocsDetail

    Enum textBoxClick

        Category = 1

        Type = 2

    End Enum

    Private txtClick As textBoxClick
    Delegate Sub ShowConfirm(ByVal text As String, ByVal title As String)
    Event ShowMessageBox As ShowConfirm
    Public YesClicked As Boolean = False
    Private ISEditMode As Boolean = False

    Private Sub UcAddTempDocsDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

       
            lblMessage.Text = String.Empty

            cmbCat.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            cmbCat.AutoCompleteSource = AutoCompleteSource.ListItems

            FillCategory()

            FillType()

            ' FillTypeChild()

        Catch ex As Exception

        End Try

    End Sub


#Region "Finish"

    Private Sub cmbCat_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCat.KeyDown

        Try
            lblMessage.Text = String.Empty

            If (e.KeyCode = Keys.Enter) Then


                If cmbCat.Text.Trim() = String.Empty Then

                    Exit Sub

                End If

                Dim c As New tempDocDetailReview

                c.tpCatName = cmbCat.Text.Trim()

                c.tpDID = Guid.NewGuid().ToString()

                If cmbCat.SelectedIndex = -1 Then

                    If tempDocsDetailManager.AddCategory(c, String.Empty, String.Empty) Then

                        'Dim newItem As New tempDocDetailReview

                        'newItem.tpCatName = c.tpCatName

                        'newItem.tpDID = c.tpDID

                        'CType(cmbCat.DataSource, BindingSource).Add(newItem)

                        'cmbCat.DisplayMember = "tpCatName"

                        'cmbCat.ValueMember = "tpDID"

                        FillCategory()

                        Try

                            cmbCat.SelectedValue = c.tpDID

                            cmbCat.Select(0, c.tpCatName.Length)

                            lblMessage.Text = "طبقه بندی جدید ثبت شد."

                            clearComboboxItems(cmbType)

                        Catch ex As Exception

                            lblMessage.Text = "خطا در ثبت طبقه بندی"

                        End Try

                    End If

                End If

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت طبقه بندی"

            ErrorManager.WriteMessage("cmbCat_KeyDown", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub cmbCat_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.MouseEnter

        lblMessage.Text = String.Empty

        txtClick = textBoxClick.Category

    End Sub

    Private Sub cmbCat_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCat.Leave

        lblMessage.Text = String.Empty


        Try

            If cmbCat.SelectedIndex = -1 Then

                clearComboboxItems(cmbType)

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("cmbCat_Leave", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub cmbCat_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedValueChanged

        lblMessage.Text = String.Empty

        FillType()

    End Sub

    Private Sub cmbType_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.MouseEnter


        lblMessage.Text = String.Empty

        txtClick = textBoxClick.Type

    End Sub

    Private Sub FillCategory()

        Try

            Dim categorysource As New BindingSource

            cmbCat.DisplayMember = "tpCatName"

            cmbCat.ValueMember = "tpDID"

            cmbType.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            cmbType.AutoCompleteSource = AutoCompleteSource.ListItems

            categorysource.DataSource = tempDocsDetailManager.GetTempDocsReviewsByParentID(String.Empty)

            If categorysource.DataSource IsNot Nothing AndAlso categorysource.Count > 0 Then

                cmbCat.DataSource = categorysource

                cmbCat.SelectedIndex = 0

            Else

                clearComboboxItems(cmbCat)

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("FillCategory", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub FillTypeChild()

        Try

            DataGridView1.AutoGenerateColumns = False

            lblMessage.Text = String.Empty

            cmbType.SelectedIndex = cmbType.FindStringExact(cmbType.Text)

            If cmbType.SelectedIndex <> -1 Then

                Dim categorysource As New BindingSource

                categorysource.DataSource = tempDocsDetailManager.GetTempDocsByParentID(cmbType.SelectedValue.ToString())

                If categorysource Is Nothing OrElse categorysource.Count = 0 Then

                    clearDataGridItems()

                Else

                    DataGridView1.DataSource = categorysource

                End If

            Else
                clearDataGridItems()

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("FillTypeChild", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub FillType()

        Try

            lblMessage.Text = String.Empty

            cmbCat.SelectedIndex = cmbCat.FindStringExact(cmbCat.Text)

            If cmbCat.SelectedIndex <> -1 Then

                Dim categorysource As New BindingSource

                cmbType.DisplayMember = "tpCatName"

                cmbType.ValueMember = "tpDID"

                categorysource.DataSource = tempDocsDetailManager.GetTempDocsReviewsByParentID(cmbCat.SelectedValue.ToString())

                If categorysource Is Nothing OrElse categorysource.Count = 0 Then

                    clearComboboxItems(cmbType)

                Else

                    cmbType.DataSource = categorysource

                End If

            Else
                clearComboboxItems(cmbType)

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("FillType", ex.ToString(), Me.ParentForm.Text)
        End Try


    End Sub

    Private Sub cmbType_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbType.KeyDown


        Try

            lblMessage.Text = String.Empty

            If (e.KeyCode = Keys.Enter) Then


                If cmbType.Text.Trim() = String.Empty Then

                    Exit Sub

                End If

                If cmbCat.SelectedIndex = -1 Then

                    lblMessage.Text = "طبقه بندی را مشخص نمایید."

                    Exit Sub

                End If

                Dim c As New tempDocDetailReview

                c.tpCatName = cmbType.Text.Trim()

                c.tpDID = Guid.NewGuid().ToString()

                If cmbType.SelectedIndex = -1 Then

                    If tempDocsDetailManager.AddCategory(c, cmbCat.SelectedValue().ToString(), cmbCat.SelectedValue().ToString()) Then

                        'Dim newItem As New tempDocDetailReview

                        'newItem.tpCatName = c.tpCatName

                        'newItem.tpDID = c.tpDID

                        'CType(cmbType.DataSource, BindingSource).Add(newItem)

                        'cmbType.SelectedValue = c.tpDID

                        'cmbType.DisplayMember = "tpCatName"

                        'cmbType.ValueMember = "tpDID"

                        FillType()

                        Try

                            cmbType.SelectedValue = c.tpDID

                            cmbType.Select(0, c.tpCatName.Length)

                            lblMessage.Text = "عنوان جدید ثبت شد."

                        Catch ex As Exception

                            lblMessage.Text = "خطا در ثبت عنوان"

                        End Try

                    End If

                End If

            End If

        Catch ex As Exception

            lblMessage.Text = "خطا در ثبت عنوان"

            ErrorManager.WriteMessage("cmbType_KeyDown", ex.ToString(), Me.ParentForm.Text)

        End Try


    End Sub

    Private Sub clearComboboxItems(ByRef cmb As ComboBox)

        Try
            If cmb.DataSource IsNot Nothing Then

                CType(cmb.DataSource, BindingSource).Clear()

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("clearComboboxItems", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub clearDataGridItems()

        Try

            '' ''Dim t As New BindingSource
            '' ''t.Add(New TempDocsDetail("شرح دادخواست", "Dadkhast"))
            '' ''t.Add(New TempDocsDetail("شرح خواسته", "Khaste"))
            '' ''t.Add(New TempDocsDetail("دلایل و منضمات", "Dalayel"))


            Dim t As New BindingSource
            t.Add(New TempDocsDetail("شرح شکوائیه", "DesShekv"))
            '' ''t.Add(New TempDocsDetail("شرح خواسته", "Khaste"))
            '' ''t.Add(New TempDocsDetail("دلایل و منضمات", "Dalayel"))

            If DataGridView1.DataSource IsNot Nothing Then


                CType(DataGridView1.DataSource, BindingSource).Clear()

                'DataGridView1.Rows(i).Cells("clmcatName").Value = "شرح دادخواست"
                'DataGridView1.Rows(i).Cells("clmntpControlKey").Value = "Dadkhast"
                'i = DataGridView1.Rows.Add()
                'DataGridView1.Rows(i).Cells("clmcatName").Value = "شرح خواسته"
                'DataGridView1.Rows(i).Cells("clmntpControlKey").Value = "Khaste"

                'i = DataGridView1.Rows.Add()
                'DataGridView1.Rows(i).Cells("clmcatName").Value = "دلایل و منضمات"
                'DataGridView1.Rows(i).Cells("clmntpControlKey").Value = "Dalayel"

            End If

            DataGridView1.DataSource = t

        Catch ex As Exception

            ErrorManager.WriteMessage("clearDataGridItems", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub


#End Region

    Private Sub toolStripDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolStripDel.Click

        lblMessage.Text = String.Empty

        YesClicked = False

        Try
            Select Case txtClick

                '' ''Case textBoxClick.Category

                '' ''    If cmbCat.SelectedIndex <> -1 Then

                '' ''        Try

                '' ''            RaiseEvent ShowMessageBox(" آیا برای حذف مطمئن هستید؟", "حذف طبقه بندی")

                '' ''            If YesClicked Then

                '' ''                If tempDocsDetailManager.DelCategory(cmbCat.SelectedValue.ToString()) Then

                '' ''                    FillCategory()

                '' ''                End If

                '' ''            End If

                '' ''        Catch ex As Exception

                '' ''            lblMessage.Text = "خطا در حذف طبقه بندی"

                '' ''        End Try


                '' ''    End If

                Case textBoxClick.Type

                    If cmbType.SelectedIndex <> -1 Then

                        Try

                            RaiseEvent ShowMessageBox(" آیا برای حذف مطمئن هستید؟", "حذف عنوان")

                            If YesClicked Then

                                If tempDocsDetailManager.DelTitle(cmbType.SelectedValue.ToString()) Then

                                    FillType()

                                End If

                            End If

                        Catch ex As Exception

                            lblMessage.Text = "خطا در حذف عنوان"

                        End Try


                    End If

            End Select

        Catch ex As Exception
            ErrorManager.WriteMessage("toolStripDel_Click", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Private Sub cmbType_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedValueChanged

        lblMessage.Text = String.Empty

        FillTypeChild()

    End Sub

    Private Sub cmbType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.Leave

        lblMessage.Text = String.Empty


        Try

            If cmbType.SelectedIndex = -1 Then

                clearDataGridItems()

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("cmbType_Leave", ex.ToString(), Me.ParentForm.Text)

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            Dim param As New TempDocsDetail

            If ISEditMode Then

            Else
                For index As Integer = 0 To 0
                    param.tpCatName = DataGridView1.Rows(index).Cells("clmcatName").Value
                    param.tpControlKey = DataGridView1.Rows(index).Cells("clmntpControlKey").Value
                    param.tpDID = Guid.NewGuid().ToString()
                    param.tpkeyContent = DataGridView1.Rows(index).Cells("clmtpkeyContent").Value
                    param.tpParentID = cmbType.SelectedValue()
                    param.tpPParentId = cmbCat.SelectedValue()

                    tempDocsDetailManager.AddChile(param)

                    lblMessage.Text = "ثبت انجام شد."

                Next

            End If
           

        Catch ex As Exception
            lblMessage.Text = "خطا در انجام عملیات."
        End Try
    End Sub

    Private Function CheckBeforesave()

        Return True

    End Function

End Class
