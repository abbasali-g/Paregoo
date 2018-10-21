Imports Lawyer.Common.VB.LawKeyWords
Imports Lawyer.Common.VB.LawInfos
Imports System.IO
Imports NwdSolutions.Web.GeneralUtilities
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.Competencys
Imports Lawyer.Common.VB.Competencys.Enums
Imports Lawyer.Common.VB.LawyerError
Imports GeneralUtilities


Public Class CompetencyAdd

#Region "- Property -"

    Dim _PageMode As PageMode = PageMode.Add

    Private _tsid As Guid
    Public WriteOnly Property Tsid() As Guid

        Set(ByVal value As Guid)
            _tsid = value

            _PageMode = Enums.PageMode.Edit

        End Set
    End Property


#End Region

#Region "- Load -"

    Private Sub LawSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each c As Control In Me.Controls
            c.AllowDrop = True
        Next

        Me.lblMessage.Text = String.Empty

        PopulateListView()


        Try
            Me.txtTsState.AutoCompleteCustomSource = CompetencyOnGridManager.GettsStateCollection(Me.txtTsState.Text)
            Me.txtTsProvince.AutoCompleteCustomSource = CompetencyOnGridManager.GettsStateCollectiontsProvince(Me.txtTsProvince.Text)
            Me.txtTsName.AutoCompleteCustomSource = CompetencyOnGridManager.GettsStateCollectiontsName(Me.txtTsName.Text)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در نمایش بارگذاری کلیدواژه ها"
        End Try


        If _PageMode = Enums.PageMode.Edit Then

            FillForm()

            FillListView()

        End If

        'pnlDadsaraDetail.Visible = False

        If Not rbDadsara.Checked Then
            rdBazporsi.Visible = False

            rdbDadyari.Visible = False

        End If


        'ToolTip1.SetToolTip(Me.btnTreeShow, "نمایش ساختار درختی")


    End Sub

    Sub PopulateListView()

        Me.lvBranch.View = View.Details
        Me.lvBranch.CheckBoxes = False
        Me.lvBranch.FullRowSelect = True
        Me.lvBranch.GridLines = True
        Me.lvBranch.Sorting = SortOrder.Ascending

        Me.lvBranch.Columns.Add("نوع شاخه", 80, HorizontalAlignment.Center)
        Me.lvBranch.Columns.Add("نام شاخه", -2, HorizontalAlignment.Left)

    End Sub

    Sub FillForm()

        Try

            Dim Competency As New Competency
            Competency = CompetencyManager.GetCompetencyByLibID(_tsid)

            Me.txtTsState.Text = Competency.tsState
            Me.txtTsProvince.Text = Competency.tsProvince
            Me.txtTsName.Text = Competency.tsName


            Select Case Competency.tsType
                Case tsType.مجتمع
                    Me.rbMojtame.Checked = True
                Case tsType.دادسرا
                    Me.rbDadsara.Checked = True
                Case tsType.شبهه
                    Me.rbShebhe.Checked = True
                Case tsType.شورا
                    Me.rbShura.Checked = True
                Case tsType.دیوانعالی
                    Me.rbDivan.Checked = True
                Case tsType.عدالت
                    Me.rdEdalat.Checked = True

            End Select


            Select Case Competency.tsHokmType
                Case tsHokmType.حقوقي.ToString
                    Me.rbHugugi.Checked = True
                Case tsHokmType.كيفري.ToString
                    Me.rbKeyfari.Checked = True
                Case Else

            End Select


            If Competency.tsMapField.Contains(";") Then
                Dim s() As String : s = Competency.tsMapField.Split(";")
                Me.txtMapStreet.Text = s.GetValue(0)
                Me.txtMapCity.Text = Trim(s.GetValue(1))
            Else
                Me.txtMapStreet.Text = String.Empty
                Me.txtMapCity.Text = Competency.tsMapField
            End If

            Me.txtNote.Text = Competency.tsDescription

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری اطلاعات صلاحیت"
            ErrorManager.WriteMessage("FillForm()", ex.ToString, Me.Text)
        End Try


    End Sub

    Sub FillListView()

        Try

            Dim CompetencyBranchCollection As New CompetencyBranchCollection
            CompetencyBranchCollection = CompetencyBranchManager.GetCompetencyBranchByLibID(_tsid)

            For i = 0 To CompetencyBranchCollection.Count - 1

                'Dim Type As String = String.Empty
                'Select Case CompetencyBranchCollection(i).tsbType
                '    Case tsbType.شعبه
                '        Type = tsbType.شعبه.ToString
                '    Case tsbType.کلانتری
                '        Type = tsbType.کلانتری.ToString
                'End Select

                Dim Type As tsbType = CompetencyBranchCollection(i).tsbType

                Dim _ListViewItem As New ListViewItem(Type.ToString())
                _ListViewItem.SubItems.Add(CompetencyBranchCollection(i).tsbName)
                _ListViewItem.SubItems.Add(Type)
                Me.lvBranch.Items.Add(_ListViewItem)

            Next


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری شاخه ها"
            ErrorManager.WriteMessage("FillListView()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#Region "- Branch -"


    Private Sub txtBranchName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBranchName.KeyDown

        If e.KeyCode = Keys.Return And (Not String.IsNullOrEmpty(txtBranchName.Text)) Then
            btnAddKey_Click(sender, e)
        End If

    End Sub

    Private Sub btnAddKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddKey.Click

        If Not String.IsNullOrEmpty(txtBranchName.Text) Then

            Dim Type As tsbType = tsbType.شعبه
            If Not (rbBranchShobe.Checked) AndAlso rdBazporsi.Visible Then

                If rdBazporsi.Checked Then

                    Type = tsbType.بازپرسی

                Else

                    Type = tsbType.دادیاری

                End If

            End If
            'Select Case True
            '    Case rbBranchShobe.Checked
            '        Type = tsbType.شعبه.ToString()
            '    Case rbBranchKalantari.Checked
            '        Type = tsbType.کلانتری.ToString()
            '    Case Else

            'End Select

            'If rdBazporsi.Visible Then

            '    If rdBazporsi.Checked Then
            '        Type += "-" & tsbType.بازپرسی.ToString()
            '    Else
            '        Type += "-" & tsbType.دادیاری.ToString()
            '    End If
            'End If
            'Dim _ListViewItem As New ListViewItem(Type)
            '_ListViewItem.SubItems.Add(Me.txtBranchName.Text)
            'Me.lvBranch.Items.Add(_ListViewItem)
            Dim _ListViewItem As New ListViewItem(Type.ToString)
            _ListViewItem.SubItems.Add(Me.txtBranchName.Text)
            _ListViewItem.SubItems.Add(Type)
            Me.lvBranch.Items.Add(_ListViewItem)

            Me.txtBranchName.Text = String.Empty
            Me.txtBranchName.Focus()

        End If


    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

        If Me.lvBranch.SelectedItems.Count > 0 Then

            For i As Integer = 0 To Me.lvBranch.SelectedItems.Count - 1
                Me.lvBranch.Items(0).Remove()
            Next


        End If





    End Sub


#End Region

#Region "- Save -"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            Dim Competency As New Competency
            Competency = Form2Competency()


            If Competency IsNot Nothing Then

                If _PageMode = PageMode.Add Then

                    Competency.tsid = Guid.NewGuid '  NewGuid
                    If CompetencyManager.InsertToolssalahiat(Competency) > 0 Then
                        InsertToolssalahiatbranches(Competency.tsid)
                    End If

                Else '-------------- Edit Mode

                    Competency.tsid = _tsid ' use exist
                    If CompetencyManager.UpdateToolssalahiat(Competency) Then
                        If CompetencyBranchManager.DeleteCompetencyBranch(Competency.tsid.ToString) Then
                            InsertToolssalahiatbranches(Competency.tsid)
                        End If
                    End If

                End If


            End If


            Me.Close()

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ذخیره صفحه"
            ErrorManager.WriteMessage("btnSave_Click()", ex.ToString, Me.Text)
        End Try


    End Sub

    Function Form2Competency() As Competency

        Try

            Dim Competency As New Competency

            Competency.tsState = General.DbReplace(txtTsState.Text.Trim)
            Competency.tsProvince = General.DbReplace(txtTsProvince.Text.Trim)
            Competency.tsName = General.DbReplace(txtTsName.Text.Trim)

            ' Not Valid
            If String.IsNullOrEmpty(Competency.tsState) Or String.IsNullOrEmpty(Competency.tsProvince) Or String.IsNullOrEmpty(Competency.tsName) Then
                Return Nothing
            End If

            Select Case True
                Case Me.rbMojtame.Checked
                    Competency.tsType = tsType.مجتمع
                Case Me.rbDadsara.Checked
                    Competency.tsType = tsType.دادسرا
                Case Me.rbShebhe.Checked
                    Competency.tsType = tsType.شبهه
                Case Me.rbShura.Checked
                    Competency.tsType = tsType.شورا
                Case Me.rbDivan.Checked
                    Competency.tsType = tsType.دیوانعالی
                Case Me.rdEdalat.Checked
                    Competency.tsType = tsType.عدالت
            End Select

            'string save
            Select Case True
                Case Me.rbKeyfari.Checked
                    Competency.tsHokmType = tsHokmType.كيفري.ToString
                Case Me.rbHugugi.Checked
                    Competency.tsHokmType = tsHokmType.حقوقي.ToString
            End Select


            If Not String.IsNullOrEmpty(Me.txtMapStreet.Text) And Not String.IsNullOrEmpty(Me.txtMapCity.Text) Then
                ' Competency.tsMapField = Me.txtMapStreet.Text + ", " + Me.txtMapCity.Text + ","
                Competency.tsMapField = Me.txtMapStreet.Text + ";" + Me.txtMapCity.Text
            ElseIf Not String.IsNullOrEmpty(Me.txtMapCity.Text) Then
                Competency.tsMapField = Me.txtMapCity.Text
            Else
                Competency.tsMapField = String.Empty
            End If

            Competency.tsDescription = General.DbReplace(txtNote.Text.Trim)

            Return Competency

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در خواندن صفحه"
            ErrorManager.WriteMessage("Form2Competency()", ex.ToString, Me.Text)
            Return Nothing
        End Try

    End Function

    Sub InsertToolssalahiatbranches(ByVal tsid As Guid)

        Try

            For i = 0 To Me.lvBranch.Items.Count - 1

                Dim CompetencyBranch As New CompetencyBranch

                CompetencyBranch.tsbID = Guid.NewGuid '  NewGuid
                CompetencyBranch.tsid = tsid
                'CompetencyBranch.tsbType = IIf(Me.lvBranch.Items(i).SubItems(0).Text = tsbType.شعبه.ToString, tsbType.شعبه, tsbType.کلانتری)

                If Not rbDadsara.Checked Then

                    CompetencyBranch.tsbType = tsbType.شعبه

                Else

                    CompetencyBranch.tsbType = Me.lvBranch.Items(i).SubItems(2).Text

                End If

                CompetencyBranch.tsbName = Me.lvBranch.Items(i).SubItems(1).Text

                CompetencyBranchManager.InsertToolssalahiatbranchesIns(CompetencyBranch)


            Next


        Catch ex As Exception
            Me.lblMessage.Text = " خطا در ذخیره شاخه ها"
            ErrorManager.WriteMessage("InsertToolssalahiatbranches()", ex.ToString, Me.Text)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

#End Region

#Region "Nahani"

    Private Sub rbDadsara_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDadsara.CheckedChanged, rbShura.CheckedChanged, rbShebhe.CheckedChanged, rbMojtame.CheckedChanged, rbDivan.CheckedChanged, rdEdalat.CheckedChanged

        rdBazporsi.Visible = rbDadsara.Checked

        rdbDadyari.Visible = rbDadsara.Checked

    End Sub

#End Region


End Class