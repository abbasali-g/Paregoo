Imports Lawyer.Common.VB.LawKeyWords
Imports Lawyer.Common.VB.LawInfos
Imports System.IO
Imports NwdSolutions.Web.GeneralUtilities
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.Competencys
Imports Lawyer.Common.VB.Competencys.Enums
Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB.LawyerError
Imports GeneralUtilities


Public Class AddressAdd

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


        Dim SettingCollection As New SettingCollection
        SettingCollection = CompetencyManager.GetCompetencysEnumsTsType()
        'Dim Setting As New Setting
        'Setting.settingName = "همه موارد"
        'Setting.settingValue = -100
        'SettingCollection.Insert(0, Setting)
        Me.cbbtsType.DataSource = SettingCollection
        Me.cbbtsType.DisplayMember = "settingName"
        Me.cbbtsType.ValueMember = "settingValue"


        Try
            Me.txtTsState.AutoCompleteCustomSource = CompetencyOnGridManager.GettsStateCollection(Me.txtTsState.Text)
            Me.txtTsProvince.AutoCompleteCustomSource = CompetencyOnGridManager.GettsStateCollectiontsProvince(Me.txtTsProvince.Text)
            Me.txtTsName.AutoCompleteCustomSource = CompetencyOnGridManager.GettsStateCollectiontsName(Me.txtTsName.Text)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در نمایش بارگذاری کلیدواژه ها"
        End Try


        If _PageMode = Enums.PageMode.Edit Then

            FillForm()

        End If

        'ToolTip1.SetToolTip(Me.btnTreeShow, "نمایش ساختار درختی")


    End Sub

    Sub FillForm()

        Try

            Dim Competency As New Competency
            Competency = CompetencyManager.GetCompetencyByLibID(_tsid)

            Me.txtTsState.Text = Competency.tsState
            Me.txtTsProvince.Text = Competency.tsProvince
            Me.txtTsName.Text = Competency.tsName


            For i = 0 To Me.cbbtsType.Items.Count - 1

                If CType(Me.cbbtsType.Items(i), Setting).settingValue = Competency.tsType Then
                    Me.cbbtsType.SelectedIndex = i

                End If
            Next



            ' Select Case Competency.tsHokmType
            'Case tsHokmType.حقوقي.ToString
            '    Me.rbHugugi.Checked = True
            'Case tsHokmType.كيفري.ToString
            '    Me.rbKeyfari.Checked = True
            'Case Else

            'End Select


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

#End Region

#Region "- Save -"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            Dim Competency As New Competency
            Competency = Form2Competency()


            If Competency IsNot Nothing Then

                If _PageMode = PageMode.Add Then

                    Competency.tsid = Guid.NewGuid '  NewGuid
                    Competency.tsHokmType = String.Empty ' not used

                    If CompetencyManager.InsertToolssalahiat(Competency) > 0 Then
                        '  InsertToolssalahiatbranches(Competency.tsid)
                    End If

                Else '-------------- Edit Mode

                    Competency.tsid = _tsid ' use exist
                    Competency.tsHokmType = String.Empty

                    If CompetencyManager.UpdateToolssalahiat(Competency) Then
                        If CompetencyBranchManager.DeleteCompetencyBranch(Competency.tsid.ToString) Then
                            ' InsertToolssalahiatbranches(Competency.tsid)
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
                Me.lblMessage.Text = " استان و شهر و نام نباید خالی باشد"
                Return Nothing
            End If

            If Me.cbbtsType.SelectedItem IsNot Nothing Then
                Competency.tsType = Me.cbbtsType.SelectedValue
            Else ' insert new item get its ID
                Competency.tsType = SettingManager.InsertToCompetencysEnumsTsType("CompetencysEnumsTsType", Me.cbbtsType.Text)
            End If


            If Not String.IsNullOrEmpty(Me.txtMapStreet.Text) And Not String.IsNullOrEmpty(Me.txtMapCity.Text) Then
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

#End Region

End Class