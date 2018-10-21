Imports Lawyer.Common.VB.Guilts
Imports Lawyer.Common.VB.LawyerError
Imports NwdSolutions.Web.GeneralUtilities


Public Class GuiltSearch

#Region "- Load -"

    Private Sub GuiltSearch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ActiveControl = Me.txtSearch
    End Sub

    Private Sub GuiltSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblMessage.Text = String.Empty

        Me.AllowDrop = True
        For Each c As Control In Me.Controls
            c.AllowDrop = True
        Next

        Gridpreparation()


        'Try
        '    Me.txtSearch.AutoCompleteCustomSource = GuiltManager.GetTgTitleForAutoComplate_ACSC(Me.txtSearch.Text)
        'Catch ex As Exception
        '    Me.lblMessage.Text = "خطا در بارگذاری کلیدواژه ها"
        '    ErrorManager.WriteMessage("GuiltSearch_Load()", ex.ToString, Me.Text)
        'End Try




    End Sub

    Sub Gridpreparation()

        With Me.dgvGuilts
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoGenerateColumns = False
            .Columns.Clear()
        End With

        '---------------------------------------------
        '0
        Me.dgvGuilts.Columns.Add("tgID", "")
        With Me.dgvGuilts.Columns("tgID")
            .DataPropertyName = "tgID"
            .Visible = False
        End With

        '---------------------------------------------
        '1
        Me.dgvGuilts.Columns.Add("tgTitle", "عنوان مجرمانه")
        With Me.dgvGuilts.Columns("tgTitle")
            .DataPropertyName = "tgTitle"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.Automatic
            .Width = 630
        End With

    End Sub

#End Region

#Region "- Search -"

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        e.KeyChar = General.DbReplace(e.KeyChar)
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown

        If e.KeyCode = Keys.Return And (Not String.IsNullOrEmpty(Me.txtSearch.Text)) Then

            FillGrid()

        End If

    End Sub

    Sub FillGrid()

        Try

            Me.lblMessage.Text = String.Empty

            If String.IsNullOrEmpty(Me.txtSearch.Text) Then
                Exit Sub
            End If

            Dim GuiltCollection As New GuiltCollection

            If Trim(Me.txtSearch.Text.Length) > 3 Then
                GuiltCollection = GuiltManager.GetGuiltsForGrid(Me.txtSearch.Text + "*")
            Else
                GuiltCollection = GuiltManager.GetGuiltsForGrid_Like(Me.txtSearch.Text)
            End If

            If GuiltCollection.Count = 0 Then
                Me.lblMessage.Text = "موردی یافت نشد"
            Else
                Me.dgvGuilts.DataSource = GuiltCollection
                Me.dgvGuilts.Focus()
            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بار گذاری اطلاعات"
            ErrorManager.WriteMessage("FillGrid()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

#Region "- Info -"

    Private Sub dgvGuilts_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGuilts.RowEnter

        FillInfo(Me.dgvGuilts.Rows(e.RowIndex).Cells(0).Value)

    End Sub

    Sub FillInfo(ByVal tgID As Integer)

        Try

            Me.lblMessage.Text = String.Empty

            Dim Guilt As New Guilt

            Guilt = GuiltManager.GetGuiltInfo(tgID)

            Me.txttgTitle.Text = Guilt.tgTitle
            Me.txttgPenalty.Text = Guilt.tgPenalty

            Me.txttgRuleTile.Text = Guilt.tgRuleTile
            Me.txttgRelatedRules.Text = Guilt.tgRelatedRules

            Me.txttgRuleDef.Text = Guilt.tgRuleDef
            Me.txttgDescription.Text = Guilt.tgDescription
            Me.txttgRulePassedDate.Text = Guilt.tgRulePassedDate

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری اطلاعات تکمیلی جرم"
            ErrorManager.WriteMessage("FillInfo()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub
End Class