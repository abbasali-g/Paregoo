Imports Lawyer.Common.VB.Judgments
Imports Lawyer.Common.VB.LawyerError


Public Class Judgment


#Region " Load "

    Private Sub Judgment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblMessage.Text = String.Empty

        ToolTip1.SetToolTip(ckbCalendar, "قابل تقویم نیست «مقطوع»")

        ToolTip1.SetToolTip(rdbCalcValue, "محاسبه هزینه")

        ToolTip1.SetToolTip(rdbFixValue, "  «قرار یا محکوم به غیر مالی» هزینه مقطوع ")

        FillComboBoxs()

        ControlState()

    End Sub

    Sub FillComboBoxs()

        Try

            Me.cbbJudgmentLevel.DataSource = JudgmentManager.GetJudgmentLevels()
            Me.cbbJudgmentLevel.DisplayMember = "tdLevelName"
            Me.cbbJudgmentLevel.ValueMember = "tdID"

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بار گذاری کمبو"
            ErrorManager.WriteMessage("FillComboBoxs()", ex.ToString, Me.Text)
        End Try


    End Sub

    Dim WithCalculate As Boolean

    Sub ControlState()

        Clear()


        Me.ckbCalendar.Visible = cbbJudgmentLevel.Text.Contains("بدوی")
        Me.rdbCalcValue.Visible = Not cbbJudgmentLevel.Text.Contains("بدوی")
        '' ''Me.rdbFixValue.Visible = Not cbbJudgmentLevel.Text.Contains("بدوی")


        Me.txtTdoText.Visible = cbbJudgmentLevel.Text.Contains("سایر")
        Me.Panel2.Visible = Not cbbJudgmentLevel.Text.Contains("سایر")
        Me.lblMessage.Visible = Not cbbJudgmentLevel.Text.Contains("سایر")
        Me.pbColor.Visible = Not cbbJudgmentLevel.Text.Contains("سایر")
        Me.acAmount.Visible = Not cbbJudgmentLevel.Text.Contains("سایر")
        Me.Label1.Visible = Not cbbJudgmentLevel.Text.Contains("سایر")

        If cbbJudgmentLevel.Text.Contains("بدوی") Then

            Me.pbGray.Visible = Not Me.ckbCalendar.Checked
            Me.acWanted.Visible = Not Me.ckbCalendar.Checked
            Me.lblWanted.Visible = Not Me.ckbCalendar.Checked
            Me.lblWanted.Text = "میزان خواسته"
            WithCalculate = Not Me.ckbCalendar.Checked



        ElseIf cbbJudgmentLevel.Text.Contains("سایر") Then

            Me.pbGray.Visible = False
            Me.acWanted.Visible = False
            Me.lblWanted.Visible = False
            WithCalculate = False


        Else

            Me.pbGray.Visible = Me.rdbCalcValue.Checked
            Me.acWanted.Visible = Me.rdbCalcValue.Checked
            Me.lblWanted.Visible = Me.rdbCalcValue.Checked
            Me.lblWanted.Text = "میزان محکوم به"
            WithCalculate = Me.rdbCalcValue.Checked

        End If


        If acWanted.Visible Then
            'txtWanted.Focus()
        End If

    End Sub

    Sub Clear()
        Me.acWanted.Text = String.Empty
        Me.acAmount.Text = String.Empty
    End Sub

#End Region

#Region " Calculate "

    Private Sub acWanted_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acWanted.TextChanged

        If Calculate() Then

        End If
    End Sub


    Function Calculate() As Boolean

        Try

            Me.lblMessage.Text = String.Empty

            If WithCalculate Then

                If Not String.IsNullOrEmpty(Trim(Me.acWanted.Amount)) Then

                    Dim Wanted As Long = Me.acWanted.Amount
                    Dim Amount, Difference As Long


                    If cbbJudgmentLevel.Text.Contains("بدوی") Then

                        If Wanted <= 10000000 Then
                            Amount = Wanted * 1.5 / 100
                        Else
                            Difference = Wanted - 10000000
                            Amount = (10000000 * 1.5 / 100) + (Difference * 2 / 100)
                        End If
                        Me.acAmount.Text = Amount

                    ElseIf cbbJudgmentLevel.Text.Contains("فرجام") Or cbbJudgmentLevel.Text.Contains("هیات تشخیص") Or cbbJudgmentLevel.Text.Contains("اعاده") Or cbbJudgmentLevel.Text.Contains("ثالث") Then

                        If Wanted <= 10000000 Then
                            Amount = Wanted * 3 / 100
                        Else
                            Difference = Wanted - 10000000
                            Amount = (10000000 * 3 / 100) + (Difference * 4 / 100)
                        End If
                        Me.acAmount.Text = Amount

                    ElseIf cbbJudgmentLevel.Text.Contains("واخواهی") Or cbbJudgmentLevel.Text.Contains("استان") Then

                        Amount = Wanted * 3 / 100
                        Me.acAmount.Text = Amount

                    Else

                        Me.lblMessage.Text = "خطا در تشخیص مرحله دادرسی"

                    End If 'Level



                Else

                    Me.acAmount.Text = 0

                End If

            Else '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  fix


                If cbbJudgmentLevel.Text.Contains("سایر") Then

                    Me.txtTdoText.Text = JudgmentManager.GetOtherJudgmens().ToString()

                Else

                    Me.acAmount.Text = JudgmentManager.GetFixedValue(Me.cbbJudgmentLevel.SelectedValue)

                End If

            End If

        Catch ex As Exception
            Me.acAmount.Text = 0
            Me.lblMessage.Text = "عدد بسیار بزرگ است"
            ErrorManager.WriteMessage("Calculate()", ex.ToString, Me.Text)
        End Try

    End Function

#End Region

#Region " Changed Control"

    Private Sub cbbJudgmentLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbJudgmentLevel.SelectedIndexChanged

        ControlState()
        Calculate()

    End Sub

    Private Sub rdbCalcValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCalcValue.CheckedChanged

        ControlState()
        Calculate()

    End Sub

    Private Sub ckbCalendar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbCalendar.CheckedChanged

        ControlState()
        Calculate()

    End Sub

#End Region




End Class