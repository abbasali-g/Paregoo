Imports Lawyer.Common.VB.Credits
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB.Common

Public Class Credit

#Region "- Load -"


    Dim MonthOldAL As New ArrayList
    Dim MonthNewAL As New ArrayList


    Private Sub Credit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblMessage.Text = String.Empty

        ControlState()
        FillComboBoxs()

        Me.ToolTip1.SetToolTip(rdbCheque, "چک")
        Me.ToolTip1.SetToolTip(rdbMony, "سایر مطالبات")
        Me.ToolTip1.SetToolTip(rdbWoman, "مهریه")
        Me.ToolTip1.SetToolTip(ckbDead, "فوت همسر")

    End Sub

    Sub ControlState()

        Me.cbbOldMonth.Enabled = Not Me.rdbWoman.Checked
        Me.cbbNewMonth.Enabled = Not Me.rdbWoman.Checked
        Me.ckbDead.Enabled = Me.rdbWoman.Checked

        If Me.rdbWoman.Checked Then

            Me.lblGrayDate.Text = "تاریخ عقد"
            If ckbDead.Checked Then
                Me.lblColorDate.Text = "تاریخ فوت"
            Else
                Me.lblColorDate.Text = "تاریخ طلاق"
            End If
            Me.lblGrayAmount.Text = "مبلغ مهریه"

        ElseIf Me.rdbMony.Checked Then

            Me.lblGrayDate.Text = "تاریخ تقدیم دادخواست"
            Me.lblColorDate.Text = "تاریخ تادیه"
            Me.lblGrayAmount.Text = "مبلغ قراردادی طلب"

        ElseIf Me.rdbCheque.Checked Then

            Me.lblGrayDate.Text = "تاریخ چک"
            Me.lblColorDate.Text = "تاریخ تادیه"
            Me.lblGrayAmount.Text = "مبلغ چک"


        End If

      ResetInputAndResult()


    End Sub

    Sub FillComboBoxs()


        Try

       

            Dim months() As String = {"", _
                                           "فروردین", _
                                           "اردیبهشت", _
                                           "خرداد", _
                                           "تیر", _
                                           "مرداد", _
                                           "شهریور", _
                                           "مهر", _
                                           "آبان", _
                                           "آذر", _
                                           "دی", _
                                           "بهمن", _
                                           "اسفند"}

            Me.cbbOldMonth.DataSource = months

            Dim monthListNew As New List(Of String)(months)
            Me.cbbNewMonth.DataSource = monthListNew

            '------------------------------

            Dim CurYear As String = DateManager.GetCurrentYear

            Dim List As New List(Of String)
            List = CreditManager.GetYears

            Me.cbbOldYear.DataSource = List
            Me.cbbOldYear.SelectedIndex = Me.cbbOldYear.Items.Count - 2


            Dim YearsListNew As New List(Of String)(List)
            Me.cbbNewYear.DataSource = YearsListNew

            ' For i = 0 To Me.cbbNewYear.Items.Count - 1

            'Dim _Year As Integer = CType(Me.cbbNewYear.Items(i), Integer)
            ' If _Year = CInt(CurYear) Then
            Me.cbbNewYear.SelectedIndex = Me.cbbNewYear.Items.Count - 1 'i
            'End If
            'Next


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در لود کنترل ها"
            ErrorManager.WriteMessage("FillComboBoxs()", ex.ToString, Me.Text)
        End Try



    End Sub

#End Region

#Region "- Calculate -"

    Private Sub acCreditOld_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acCreditOld.TextChanged

        Calculate()

    End Sub

    Function Calculate() As Boolean

        Me.lblMessage.Text = String.Empty

        Try

            If Not String.IsNullOrEmpty(Trim(Me.acCreditOld.Amount)) AndAlso Not String.IsNullOrEmpty(Trim(cbbOldYear.Text)) AndAlso Not String.IsNullOrEmpty(Trim(cbbNewYear.Text)) Then



                Dim CreditOld As Long
                Try
                    CreditOld = Trim(Me.acCreditOld.Amount)
                Catch ex As Exception
                    CreditOld = 0
                    Me.lblMessage.Text = "عدد بسیار بزرگ است"
                End Try


                '------------------ Set Years ----------------------------

                Dim YearOld As Integer = Me.cbbOldYear.Text
                Dim YearNew As Integer = Me.cbbNewYear.Text

                Select Case True
                    Case (rdbWoman.Checked = True And ckbDead.Checked = False) 'Divorce ==> shakhese sale Gabl
                        YearNew -= 1
                End Select

                '------------------ Get indexs of Years ----------------------------

                Dim IndexOld As New Index
                IndexOld = CreditManager.GetIndices(YearOld)
                If IndexOld Is Nothing Then
                    Me.lblMessage.Text = " سال  " + YearOld.ToString + " در بانک وجود ندارد "
                    Return False
                End If


                Dim IndexNew As New Index
                IndexNew = CreditManager.GetIndices(YearNew)
                If IndexNew Is Nothing Then
                    Me.lblMessage.Text = " سال  " + YearNew.ToString + " در بانک وجود ندارد "
                    Return False
                End If



                '------------------------Mean or Mount of Year ---------------------------------

                Select Case True

                    Case Me.rdbMony.Checked Or Me.rdbCheque.Checked ' Month Can selected

                        IndexClassToArrayList(IndexOld, IndexNew)

                        If cbbOldMonth.SelectedIndex > 0 Then ' if Old Month selected ( not using mean of Year)
                            If MonthOldAL(cbbOldMonth.SelectedIndex - 1) <> 0 Then
                                IndexOld.mean = MonthOldAL(cbbOldMonth.SelectedIndex - 1)
                            End If
                        End If

                        If cbbNewMonth.SelectedIndex > 0 Then ' if  New Month selected ( not using mean of Year)
                            If MonthNewAL(cbbNewMonth.SelectedIndex - 1) <> 0 Then
                                IndexNew.mean = MonthNewAL(cbbNewMonth.SelectedIndex - 1)
                            End If
                        End If

                End Select




                Select Case True
                    Case YearNew > 1314 AndAlso IndexNew.mean = 0
                        Me.lblMessage.Text = " شاخص سال " + YearNew.ToString + " موجود نمی باشد "
                    Case YearOld > 1314 AndAlso IndexOld.mean = 0
                        Me.lblMessage.Text = " شاخص سال " + YearOld.ToString + " موجود نمی باشد "
                    Case Else
                        Me.acCreditNew.Amount = Math.Round(IndexNew.mean / IndexOld.mean * CreditOld)
                End Select

                Return True


            Else
                Me.acCreditNew.Amount = 0
            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در انجام محاسبه"
            ErrorManager.WriteMessage("Calculate()", ex.ToString, Me.Text)
        End Try


    End Function

    Sub IndexClassToArrayList(ByVal IndexOld As Index, ByVal IndexNew As Index)

        MonthOldAL.Clear()
        MonthOldAL.Add(IndexOld.m1)
        MonthOldAL.Add(IndexOld.m2)
        MonthOldAL.Add(IndexOld.m3)
        MonthOldAL.Add(IndexOld.m4)
        MonthOldAL.Add(IndexOld.m5)
        MonthOldAL.Add(IndexOld.m6)
        MonthOldAL.Add(IndexOld.m7)
        MonthOldAL.Add(IndexOld.m8)
        MonthOldAL.Add(IndexOld.m9)
        MonthOldAL.Add(IndexOld.m10)
        MonthOldAL.Add(IndexOld.m11)
        MonthOldAL.Add(IndexOld.m12)

        MonthNewAL.Clear()
        MonthNewAL.Add(IndexNew.m1)
        MonthNewAL.Add(IndexNew.m2)
        MonthNewAL.Add(IndexNew.m3)
        MonthNewAL.Add(IndexNew.m4)
        MonthNewAL.Add(IndexNew.m5)
        MonthNewAL.Add(IndexNew.m6)
        MonthNewAL.Add(IndexNew.m7)
        MonthNewAL.Add(IndexNew.m8)
        MonthNewAL.Add(IndexNew.m9)
        MonthNewAL.Add(IndexNew.m10)
        MonthNewAL.Add(IndexNew.m11)
        MonthNewAL.Add(IndexNew.m12)

    End Sub

#End Region

#Region "- Changed Control -"


    Private Sub rdbCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCheque.CheckedChanged

        If rdbCheque.Checked Then
            ControlState()
        End If

    End Sub

    Private Sub rdbMony_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMony.CheckedChanged

        If rdbMony.Checked Then
            ControlState()
        End If

    End Sub

    Private Sub rdbWoman_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbWoman.CheckedChanged

        If rdbWoman.Checked Then
            ControlState()
        End If

    End Sub

    Private Sub ckbDead_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbDead.CheckedChanged
        ControlState()
    End Sub

    Private Sub cbbOldYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbOldYear.SelectedIndexChanged
        ResetInputAndResult()
    End Sub

    Private Sub cbbOldMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbOldMonth.SelectedIndexChanged
        ResetInputAndResult()
    End Sub

    Private Sub cbbNewYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbNewYear.SelectedIndexChanged
        ResetInputAndResult()
    End Sub

    Private Sub cbbNewMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbbNewMonth.SelectedIndexChanged
        ResetInputAndResult()
    End Sub

    Sub ResetInputAndResult()

        RemoveHandler Me.acCreditOld.TextChanged, New EventHandler(AddressOf acCreditOld_TextChanged)
        Me.acCreditOld.Text = String.Empty
        AddHandler Me.acCreditOld.TextChanged, New EventHandler(AddressOf acCreditOld_TextChanged)

        Me.acCreditNew.Text = String.Empty

    End Sub


#End Region


End Class