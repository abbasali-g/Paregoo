Public Class LawyerSFees

#Region "- Load -"

    Dim Current_HvPaye As Double

    Private Sub LawyerSFees_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Me.ActiveControl = Me.acBaseLawyerSFee

    End Sub

    Private Sub LawyerSFees_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ControlState()
        AddHandlersToacBaseLawyerSFee_TextChanged()

        Me.lbResult.DataSource = List()
        Me.lbResult.SelectedIndex = -1

        Me.lblMessage.Text = String.Empty

    End Sub

    Sub AddHandlersToacBaseLawyerSFee_TextChanged()


        AddHandler rdbKar.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler rdbKarArshad.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler rdbDoctora.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged


        AddHandler rdbCentral.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler rdbLarge.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler rdbOther.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged


        AddHandler rdbWokala.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler rdbMoshaveran.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged

        AddHandler cbbYears.SelectedIndexChanged, AddressOf acBaseLawyerSFee_TextChanged
        '-----------------------------------------

        AddHandler rdbLegal.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged

        AddHandler rdbFinancial.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler rdbUnexpected.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler rdbDefence.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged

        '------------------
        AddHandler chbStudy.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler chbInitial.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler chbExecution.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler chbRenewal.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler chbDivan.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged

        '-------------------
        AddHandler rdbFirst.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler txtCharge.TextChanged, AddressOf acBaseLawyerSFee_TextChanged

        '-----------------------------------

        AddHandler chbStudy2.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler chbCourt.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler chbInitial2.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler chbRenewal2.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged
        AddHandler chbExecution2.CheckedChanged, AddressOf acBaseLawyerSFee_TextChanged

    End Sub

    Sub ControlState()


        Me.pnlLegal.Visible = Me.rdbLegal.Checked
        Me.pnlPenal.Visible = Me.rdbPenal.Checked

        If Me.pnlLegal.Visible Then 'حقوقی


            Me.acBaseLawyerSFee.Enabled = True

            Me.pnlClaims.Visible = Me.rdbUnexpected.Checked

            '-----------------------
            chbInitial.Enabled = Not chbStudy.Checked
            chbRenewal.Enabled = Not chbStudy.Checked
            chbDivan.Enabled = Not chbStudy.Checked
            chbExecution.Enabled = Not chbStudy.Checked

            If Not chbInitial.Enabled Then
                chbInitial.Checked = False
            End If

            If Not chbRenewal.Enabled Then
                chbRenewal.Checked = False
            End If

            If Not chbDivan.Enabled Then
                chbDivan.Checked = False
            End If

            If Not chbExecution.Enabled Then
                chbExecution.Checked = False
            End If
            '-----------------------------

            chbRenewal.Enabled = Not chbStudy.Checked AndAlso Not chbDivan.Checked
            If Not chbRenewal.Enabled Then
                chbRenewal.Checked = False
            End If

            chbDivan.Enabled = Not chbStudy.Checked AndAlso Not chbRenewal.Checked
            If Not chbDivan.Enabled Then
                chbDivan.Checked = False
            End If

        Else ' کیفری


            Me.acBaseLawyerSFee.Text = String.Empty
            Me.acBaseLawyerSFee.Enabled = False
            Me.lblMsg.Visible = False

            chbCourt.Enabled = Not chbStudy2.Checked
            chbInitial2.Enabled = Not chbStudy2.Checked
            chbRenewal2.Enabled = Not chbStudy2.Checked
            chbExecution2.Enabled = Not chbStudy2.Checked

            If Not chbCourt.Enabled Then
                chbCourt.Checked = False
            End If

            If Not chbInitial2.Enabled Then
                chbInitial2.Checked = False
            End If

            If Not chbRenewal2.Enabled Then
                chbRenewal2.Checked = False
            End If

            If Not chbExecution2.Enabled Then
                chbExecution2.Checked = False
            End If

        End If


    End Sub

    Function List() As List(Of String)

        Dim ls As New List(Of String)
        ls.Add("قراداد ابطال دادخواست پیش از دفاع از دعوی = 25% حقل الوکاله مرحله بدوی ( یعنی 25% از 60% که می شود 15% از کل حق الوکاله )")
        ls.Add("قرارداد ابطال دادخواست پس از دفاع از دعوی = 50% از حق الوکاله مرحله بدوی (یعنی 50% از 60% که می شود 30% ازکل حق الوکاله)")
        ls.Add("قرارداد سقوط دعوی تجدید نظر پیش از پاسخ یا دفاع از دعوی = 25% حق الوکاله مرحله بدوی (یعنی 50% از 60% که می شود 30% از کل حق الوکاله)")
        ls.Add("قرار سقوط دعوی تجدید نظر پس از پاسخ یا دفاع از دعوی = 50% از حق الوکاله مرحله بدوی (یعنی 50% از 60% که می شود 30% از کل حق الوکاله )")
        ls.Add("قرار رد دعوی به جهت ایراد مرور زمان = کل حق الوکاله آن مرحله)")
        ls.Add("قرار رد دعوی به جهت به جهت ایراد اعتبار امر مختوم = کل حق الوکاله آن مرحله")
        ls.Add("قرار سقوط دعوی اعتراض به ثبت  = کل حق الوکاله آن مرحله آن مرحله")
        ls.Add("قرار رد تقاضای اعاده  دادرسی =  کل حق الوکاله آن مرحله")
        ls.Add("سایر قراردادها = نصف حق الوکاله آن مرحله ")
        ls.Add("اعلام وکالت بعد از نقض رای = نصف حق الوکاله آن مرحله")
        ls.Add("عزل وکیل بعد از اتمام کار وکیل = کل حق الوکاله آن مرحله ")
        ls.Add("عزل وکیل بعد از اینکه پرونده معد حکم باشد = کل حق الوکاله آن مرحله")
        ls.Add("عزل وکیل قبل از اتمام کار وکیل و قبل از اینکه پرونده معد حکم باشد = حق الوکاله به تناسب کار به تشخیص کانون یا مرجع قضایی")
        ls.Add("انتقای موضوع وکالت بعد از اینکه پرونده معد حکم باشد = کل حق الوکاله آن مرحله")
        ls.Add("تقای موضوع وکالت بعد از اینکه پرونده معد حکم باشد = کل حق الوکاله آن مرحله")
        ls.Add("انتقای موضوع وکالت قبل از اتمام کار وکیل و قبل از اینکه پرونده معد حکم باشد = حق الوکاله به تناسب کار به تشخیص کانون یا مرجع قضایی")
        ls.Add("ارجاع شدن پرونده  به داوری و منجر شدن به رای داور = حق الوکاله مرحله بدوی ( یعنی 60% از کل)")
        ls.Add("منجر شدن به صلح = حق الوکاله مرحله بدوی ( یعنی 60% از کل) این نتایج به ؟ غیره اعمال نمی شود ، ولی به حق الوکاله تاثیر دارد.")

        Return ls
    End Function

#End Region

#Region "- Calculate -"

    Private Sub acBaseLawyerSFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acBaseLawyerSFee.TextChanged

        ControlState()
        Calculate_HVekale()

    End Sub

    Sub Calculate_HVekale()

        Dim HV As Double

        If chbStudy.Checked Or chbStudy2.Checked Then ' مطالعه پرونده-- fix
            HV = 150000
        Else

            Dim Xa As Double = Me.acBaseLawyerSFee.Amount
            If rdbLegal.Checked Then 'حقوقی
                HV = Legal(Xa)
            ElseIf rdbPenal.Checked Then
                HV = Penal() ' کیفری
            End If


            Dim Ex As Double
            If chbExecution.Checked Or chbExecution2.Checked Then '  مرحله اجرا - fix
                If Not String.IsNullOrEmpty(Me.acBaseLawyerSFee.Amount) Then
                    Ex = 2 / 100 * Me.acBaseLawyerSFee.Amount
                    Ex = IIf(Ex > 5000000, 5000000, Ex)
                End If
            Else
                Ex = 0
            End If


            HV += Ex

        End If

        ShowHv(HV)

    End Sub

    Sub ShowHv(ByVal HV As Double)

        HV = Math.Round(HV)

        Me.txtLawyerFee.Text = String.Format("{0:0,0}", HV) ' حق الوکاله

        Dim Stamp As Double = 5 / 100 * HV
        Me.txtStamp.Text = String.Format("{0:0,0}", Stamp) ' تمبر

        Dim sum As Double
        If rdbWokala.Checked Then
            Me.txtHemayat.Text = String.Format("{0:0,0}", Me.txtStamp.Text / 2) 'صندوق حمایت
            Me.txtTaavon.Text = String.Format("{0:0,0}", Me.txtStamp.Text / 4) 'صندوق تعاون
            sum = Stamp + Stamp / 2 + Stamp / 4 '
        Else
            Me.txtHemayat.Text = 0
            Me.txtTaavon.Text = 0
            sum = Stamp '
        End If

        Me.txtSum.Text = String.Format("{0:0,0}", sum) ' جمع

    End Sub

    Function Legal(ByVal Xa As Double) As Double

        'غیر مالی
        If rdbLegal.Checked AndAlso rdbNoFinancial.Checked AndAlso (Me.acBaseLawyerSFee.Amount < 300000 Or Me.acBaseLawyerSFee.Amount > 4000000) Then
            Me.lblMsg.Visible = True
        Else
            Me.lblMsg.Visible = False
            Return HagolVekale(Xa, Me.rdbFinancial.Checked) 'اجرا به صورت مالی یا غیر مالی
        End If

    End Function


#Region " Sub_Calculate "

    Dim WithoutHV_Level As Boolean = False

    Function HagolVekale(ByVal Xa As Double, ByVal IsFinancial As Boolean) As Double


        Dim HvPaye As Double
        Dim HV As Double

        WithoutHV_Level = False

        If IsFinancial Then ' مالی

            Select Case True

                Case Xa <= 0

                Case Xa > 0 And Xa < 3000000 + 1

                    HvPaye = 10 / 100 * Xa + 150000

                    WithoutHV_Level = True
                    HV = HvPaye2HV(HvPaye)

                    HV = IIf(HV > 300000, 300000, HV)

                    '>>>>>>>>>>>>>>>>> No Renewal
                    Me.chbRenewal.Enabled = False
                    Me.chbRenewal.Checked = False

                    Me.chbRenewal2.Enabled = False
                    Me.chbRenewal2.Checked = False
                    '>>>>>>>>>>>>>>>>>

                Case Xa <= 100000000

                    HvPaye = 6 / 100 * Xa
                    HV = HvPaye2HV(HvPaye)
                    HV = IIf(HV >= 6000000, 6000000, HV)

                Case Xa <= 1000000000

                    HvPaye = (6 / 100 * 100000000) + (4 / 100 * (Xa - 100000000))
                    HV = HvPaye2HV(HvPaye)
                    HV = IIf(HV > 42000000, 42000000, HV)

                Case Xa <= 5000000000

                    HvPaye = (6 / 100 * 100000000) + (4 / 100 * 1000000000) + (3 / 100 * (Xa - 1100000000))
                    HV = HvPaye2HV(HvPaye)
                    HV = IIf(HV > 162000000, 162000000, HV)

                Case Xa > 5000000000

                    HvPaye = (6 / 100 * 100000000) + (4 / 100 * 1000000000) + (3 / 100 * 5000000000) + (2 / 100 * (Xa - 6100000000))
                    HV = HvPaye2HV(HvPaye)
                    HV = IIf(HV > 200000000, 200000000, HV)

            End Select


        Else 'غیر مالی

            HvPaye = Xa
            HV = HvPaye2HV(HvPaye)


        End If


        Current_HvPaye = HvPaye '--------------- برای نتایج رسیدگی


        Return HV

    End Function

    Function HvPaye2HV(ByVal HvPaye As Double) As Double

        Dim R As Integer = LevelStatus()
        Dim M As Integer = LawyerStatus()

        Dim HV_Level As Double
        If WithoutHV_Level = False Then
            HV_Level = R / 100 * HvPaye
        Else
            HV_Level = HvPaye ' Case Xa > 0 And Xa < 3000000 + 1
        End If

        Dim HV_Lawyer As Double = M / 100 * HV_Level

        Dim HV As Double = HV_Level + HV_Lawyer

        Return HV

    End Function

    Function LawyerStatus() As Integer


        Dim Percent As Integer = 0

        Select Case True
            Case Me.rdbKarArshad.Checked
                Percent += 5
            Case Me.rdbDoctora.Checked
                Percent += 10
        End Select


        Dim Years As Integer = CInt(IIf(Me.cbbYears.Text = String.Empty, 0, Me.cbbYears.Text))
        Years = IIf(Years > 20, 20, Years)
        Percent += Years


        Select Case True
            Case Me.rdbCentral.Checked
                Percent += 10
            Case Me.rdbLarge.Checked
                Percent += 5
        End Select


        Return Percent


    End Function

    Function LevelStatus() As Integer

        Dim Percent As Integer = 0

        If rdbLegal.Checked Then ' حقوقی


            If chbStudy.Checked Then
                ' مطالعه پرونده -------fix in CalculateV
            End If


            If chbInitial.Checked AndAlso rdbUnexpected.Checked AndAlso rdbDefence.Checked Then
                Percent += 30 'طاری دفاع بدوی
            ElseIf chbInitial.Checked Then
                Percent += 60
            End If

            If chbRenewal.Checked AndAlso rdbUnexpected.Checked AndAlso rdbDefence.Checked Then
                Percent += 20 ' طاری دفاع تجدید نظر
            ElseIf chbRenewal.Checked Then
                Percent += 40
            End If


            If chbDivan.Checked Then
                Percent += 20 'دیوانعالی کشور
            End If

            If chbExecution.Checked Then
                ' اجرای احکام ------ fix in CalculateV
            End If


        Else '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> کیفری

            If chbStudy2.Checked Then
                ' مطالعه پرونده -------fix in CalculateV
            End If


            If chbCourt.Checked Then
                Percent += 50
            End If

            If chbInitial2.Checked Then
                Percent += 60 ' بدوی
            End If

            If chbRenewal2.Checked Then
                Percent += 40 ' تجدیدنظر
            End If

            If chbExecution2.Checked Then
                ' اجرای احکام ------ fix in CalculateV
            End If



        End If


        Return Percent


    End Function

#End Region

    Function Penal() As Double

        Dim HvPaye As Double
        Dim HV As Double

        If rdbFirst.Checked Then 'گروه اول
            HvPaye = 5000000
        ElseIf rdbSecond.Checked Then 'گروه دوم
            HvPaye = 10000000
        End If

        Dim ChargeCount As Integer = CInt(IIf(Me.txtCharge.Text = String.Empty, 0, Me.txtCharge.Text))
        ChargeCount = IIf(ChargeCount > 3, 3, ChargeCount)
        HvPaye += (ChargeCount * 500000)

        HV = HvPaye2HV(HvPaye)


        Current_HvPaye = HvPaye '--------------- برای نتایج رسیدگی


        Return HV

    End Function


#End Region

#Region "- Result -"

    Private Sub lbResult_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbResult.SelectedIndexChanged


        If Not String.IsNullOrEmpty(Me.txtLawyerFee.Text) Then


            Dim V_Result As Double

            Select Case Me.lbResult.SelectedIndex
                Case 0, 2
                    ' V_Result = 25 / 100 * Prm2V(CurrentP, 60)
                    V_Result = 15 / 100 * Me.txtLawyerFee.Text
                    Me.txtResult.Text = String.Format("{0:0,0}", V_Result)
                Case 1, 3
                    'V_Result = 50 / 100 * Prm2V(CurrentP, 60)
                    V_Result = 30 / 100 * Me.txtLawyerFee.Text
                    Me.txtResult.Text = String.Format("{0:0,0}", V_Result)
                Case 4, 5, 6, 7, 10, 11, 13, 14
                    V_Result = 100 / 100 * Me.txtLawyerFee.Text
                    Me.txtResult.Text = String.Format("{0:0,0}", V_Result)
                Case 8, 9
                    V_Result = 50 / 100 * Me.txtLawyerFee.Text
                    Me.txtResult.Text = String.Format("{0:0,0}", V_Result)
                Case 12, 15
                    Me.txtResult.Text = "به تناسب کار"
                Case 16, 17
                    'V_Result = Prm2V(CurrentP, 60)
                    V_Result = 60 / 100 * Me.txtLawyerFee.Text
                    Me.txtResult.Text = String.Format("{0:0,0}", V_Result)
            End Select

        End If

    End Sub

#End Region

    'Function Prm2V(ByVal p As Double, ByVal r As Double) As Double '--------------- برای نتایج رسیدگی


    '    Dim m As Integer = LawyerStatus()

    '    Dim v As Double = (r / 100 * p) + m / 100 * (p + (r / 100 + p))

    '    Return v

    'End Function


  
End Class