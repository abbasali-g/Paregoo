Imports Lawyer.Common.VB.Laws
Imports Microsoft.Reporting.WinForms
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Login


Public Class Reports

#Region "- Enum -"

    Enum ReportType

        Daramad = 1
        Hazine = 2
        LahAlayh = 3
        Moshavere = 4
        Oragh = 5
        subject = 6
        movakel = 7
        Incoming = 8
        mali = 9

    End Enum

#End Region

#Region "- Load -"

    Private _ReportType As ReportType

    Private Sub Reports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

        ToolTip1.SetToolTip(btnContactSearh, "لیست افراد")
        lblMessage.Text = String.Empty

        _ReportType = ReportType.subject
        txtReportTitle.Text = "لطفا نوع گزارش را انتخاب نمایید"

        'fromDate.SetToday = True

        'toDate.SetToday = True

        grpFilecase.Visible = False

        BindSubject(False)

    End Sub

#End Region

#Region "- Report Select -"


    Private Sub toolStripReportByDaramad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        _ReportType = ReportType.Daramad

        txtTitle.Text = "نام وکیل :"

        txtContent.AllowDrop = True

        txtContent.Text = CurrentLogin.CurrentUser.Name

        txtReportTitle.Text = CType(sender, ToolStripMenuItem).Text
        TxtContentEvent(True)
        BindSubject(True)
    End Sub

    Private Sub toolStripReportByHazine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        txtContent.AllowDrop = True

        _ReportType = ReportType.Hazine
        txtContent.Text = CurrentLogin.CurrentUser.Name
        txtTitle.Text = "نام وکیل :"
        txtReportTitle.Text = CType(sender, ToolStripMenuItem).Text
        TxtContentEvent(True)
        BindSubject(True)
    End Sub

    Private Sub toolStripReportByLah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '_ReportType = ReportType.LahAlayh

        'txtContent.AllowDrop = True

        'txtTitle.Text = "نام وکیل :"
        'txtContent.Text = String.Empty
        'txtReportTitle.Text = CType(sender, ToolStripMenuItem).Text
        'TxtContentEvent(True)
        'BindSubject(True)
    End Sub

    Private Sub toolstripReportByMoshavere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '_ReportType = ReportType.Moshavere


        'txtContent.AllowDrop = True



        'txtTitle.Text = "نام وکیل :"
        'txtContent.Text = String.Empty
        'txtReportTitle.Text = CType(sender, ToolStripMenuItem).Text
        'TxtContentEvent(True)
        'BindSubject(True)

    End Sub

    Private Sub toolStipReportByOragh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '_ReportType = ReportType.Oragh

        'txtContent.AllowDrop = True

        'txtTitle.Text = "نام وکیل :"
        'txtContent.Text = String.Empty
        'txtReportTitle.Text = CType(sender, ToolStripMenuItem).Text
        'TxtContentEvent(True)
        'BindSubject(True)

    End Sub

    Private Sub ToolstripReportBySubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolstripReportBySubject.Click

        grpFilecase.Visible = False

        txtContent.AllowDrop = False

        _ReportType = ReportType.subject

        txtTitle.Text = "موضوع :"

        txtContent.Text = String.Empty

        txtReportTitle.Text = CType(sender, ToolStripMenuItem).Text
        TxtContentEvent(False)
        BindSubject(False)

    End Sub

    Private Sub BindSubject(ByVal clear As Boolean)

        Try

            If clear Then

                txtContent.AutoCompleteMode = AutoCompleteMode.None

                txtContent.AutoCompleteSource = AutoCompleteSource.None

            Else

                txtContent.AutoCompleteMode = AutoCompleteMode.SuggestAppend

                txtContent.AutoCompleteSource = AutoCompleteSource.CustomSource

                txtContent.AutoCompleteCustomSource = FileCaseManager.GetAllFileCaseSubjects()

            End If
          

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ToolstripReportByMovakel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolstripReportByMovakel.Click
        grpFilecase.Visible = False
        txtContent.AllowDrop = True

        _ReportType = ReportType.movakel

        txtTitle.Text = "نام موکل :"

        txtContent.Text = String.Empty

        txtReportTitle.Text = CType(sender, ToolStripMenuItem).Text
        TxtContentEvent(True)
        BindSubject(True)

    End Sub

    Private Sub ToolStripMenuItemMali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemMali.Click

        grpFilecase.Visible = True

        txtContent.AllowDrop = True

        _ReportType = ReportType.mali

        txtTitle.Text = "نام موکل :"

        txtContent.Text = String.Empty

        txtReportTitle.Text = CType(sender, ToolStripMenuItem).Text

        TxtContentEvent(True)

        BindSubject(True)

    End Sub

    Private Sub TxtContentEvent(ByVal isAdd As Boolean)



        RemoveHandler txtContent.KeyPress, AddressOf txtPersonName_KeyPress

        If isAdd Then

            AddHandler txtContent.KeyPress, AddressOf txtPersonName_KeyPress

        Else

            UcContacts1.Visible = False

            SplitContainer1.SplitterDistance = 75

        End If
    End Sub

#End Region

#Region "- Search -"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click


        lblMessage.Text = String.Empty


        Try

            Select Case _ReportType

                Case ReportType.movakel

                    Dim Q1, Q2 As String
                    Q1 = String.Empty
                    Q2 = String.Empty
                   
                    If txtContent.Text.Trim() <> String.Empty Then
                        Q1 = " and contactinfo.custFullName like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtContent.Text.Trim()) & "%'"
                    End If
                    If fromDate.GetShamsiDateInNumericFormat.HasValue Then
                        Q2 = "  fileCaseOpenDate>= " & fromDate.GetShamsiDateInNumericFormat
                    End If
                    If toDate.GetShamsiDateInNumericFormat.HasValue Then
                        If Q2 <> String.Empty Then Q2 &= " and "
                        Q2 &= " fileCaseOpenDate<= " & toDate.GetShamsiDateInNumericFormat
                    End If
                    If Q2 <> String.Empty Then Q2 = " where " & Q2

                    Dim c As FilecaseReportCollection = FileCaseManager.GetReportByMovakel(Q1, Q2)

                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", "گزارش کلی پرونده ها")
                    ShowReport(c, "rpt_DataSet_rpt_PersonCases", "LawyerApp.PersonCases.rdlc", Params)


                Case ReportType.mali

                    Dim Qfi, Qf, Qc As String
                    Qfi = String.Empty
                    Qf = String.Empty
                    Qc = String.Empty


                    If txtContent.Text.Trim() <> String.Empty Then

                        Qc = " where custFullName like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtContent.Text.Trim()) & "%'"

                    End If

                    If fromDate.GetShamsiDateInNumericFormat.HasValue Then

                        Qf = "  and financePaymentDate>= " & fromDate.GetShamsiDateInNumericFormat

                    End If

                    If toDate.GetShamsiDateInNumericFormat.HasValue Then

                        Qf &= " and financePaymentDate<= " & toDate.GetShamsiDateInNumericFormat

                    End If


                    If rdbClose.Checked Then
                        Qfi = " not null"
                    Else
                        Qfi = " null"
                    End If

                    Dim dt As DataTable = FileCaseManager.GetReportFinanceByMovakel(Qf, Qfi, Qc)

                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", "گزارش مالی پرونده ها")
                    ShowReport(dt, "rpt_DataSet_dt_rptIncoming", "LawyerApp.Incoming.rdlc", Params)


                Case ReportType.Daramad


                    Dim Q1, Q2 As String
                    Q1 = String.Empty
                    Q2 = String.Empty

                    If CurrentLogin.CurrentUser.IsAdmin Then
                        If txtContent.Text.Trim() <> String.Empty Then
                            Q1 = " and contactinfo.custFullName like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtContent.Text.Trim()) & "%'"
                        End If
                    Else

                        If txtContent.Text.Trim() <> CurrentLogin.CurrentUser.Name Then
                            Dim Params1(0) As ReportParameter
                            Params1(0) = New ReportParameter("pDate", "   ")
                            Dim c1 As New FilecaseReportCollection
                            ShowReport(c1, "rpt_DataSet_rpt_PersonCases", "LawyerApp.PersonCases.rdlc", Params1)
                            Exit Sub
                        Else

                            Q1 = " and contactinfo.custId ='" & CurrentLogin.CurrentUser.UserID & "'"

                        End If
                    End If

                    'If txtContent.Text.Trim() <> String.Empty Then
                    '    Q1 = " and contactinfo.custFullName like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtContent.Text.Trim()) & "%'"
                    'End If
                    If fromDate.GetShamsiDateInNumericFormat.HasValue Then
                        Q2 = "  fileCaseOpenDate>= " & fromDate.GetShamsiDateInNumericFormat
                    End If
                    If toDate.GetShamsiDateInNumericFormat.HasValue Then
                        If Q2 <> String.Empty Then Q2 &= " and "
                        Q2 &= " fileCaseOpenDate<= " & toDate.GetShamsiDateInNumericFormat
                    End If
                    If Q2 <> String.Empty Then Q2 = " where " & Q2

                    Dim dt As DataTable = FileCaseManager.GetReportByDaramad(Q1, Q2)
                    ShowReport(dt, "rpt_DataSet_stpRpt3", "LawyerApp.Daramad.rdlc", Nothing)


                Case ReportType.Hazine


                    Dim Q1, Q2 As String
                    Q1 = String.Empty
                    Q2 = String.Empty

                    If CurrentLogin.CurrentUser.IsAdmin Then
                        If txtContent.Text.Trim() <> String.Empty Then
                            Q1 = " and contactinfo.custFullName like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtContent.Text.Trim()) & "%'"
                        End If
                    Else

                        If txtContent.Text.Trim() <> CurrentLogin.CurrentUser.Name Then
                            Dim Params1(0) As ReportParameter
                            Params1(0) = New ReportParameter("pDate", "   ")
                            Dim c1 As New FilecaseReportCollection
                            ShowReport(c1, "rpt_DataSet_rpt_PersonCases", "LawyerApp.PersonCases.rdlc", Params1)
                            Exit Sub
                        Else

                            Q1 = " and contactinfo.custId ='" & CurrentLogin.CurrentUser.UserID & "'"

                        End If
                    End If

                    'If txtContent.Text.Trim() <> String.Empty Then
                    '    Q1 = " and contactinfo.custFullName like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtContent.Text.Trim()) & "%'"
                    'End If

                    If fromDate.GetShamsiDateInNumericFormat.HasValue Then
                        Q2 = " fileCaseOpenDate>= " & fromDate.GetShamsiDateInNumericFormat
                    End If

                    If toDate.GetShamsiDateInNumericFormat.HasValue Then
                        If Q2 <> String.Empty Then Q2 &= " and "
                        Q2 &= " fileCaseOpenDate<= " & toDate.GetShamsiDateInNumericFormat
                    End If
                    If Q2 <> String.Empty Then Q2 = " where " & Q2

                    Dim dt As DataTable = FileCaseManager.GetReportByHazine(Q1, Q2)
                    ShowReport(dt, "rpt_DataSet_stpRpt3", "LawyerApp.Hazine.rdlc", Nothing)


                Case ReportType.LahAlayh


                    'Dim Q1, Q2 As String
                    'Q1 = String.Empty
                    'Q2 = String.Empty

                    'If txtContent.Text.Trim() <> String.Empty Then
                    '    Q1 = " and contactinfo.custFullName like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtContent.Text.Trim()) & "%'"
                    'End If

                    'If fromDate.GetShamsiDateInNumericFormat.HasValue Then
                    '    Q2 = " and fileCaseOpenDate>= " & fromDate.GetShamsiDateInNumericFormat
                    'End If

                    'If toDate.GetShamsiDateInNumericFormat.HasValue Then
                    '    Q2 &= " and fileCaseOpenDate<= " & toDate.GetShamsiDateInNumericFormat
                    'End If

                    'Dim dt As DataTable = FileCaseManager.GetReportByResult(Q1, Q2)
                    'ShowReport(dt, "rpt_DataSet_stpRpt", "LawyerApp.LahAleyh.rdlc", Nothing)


                Case ReportType.Moshavere


                    'Dim Q1 = String.Empty

                    'If txtContent.Text.Trim() <> String.Empty Then
                    '    Q1 = " and  custFullName like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtContent.Text.Trim()) & "%'"
                    'End If

                    'If fromDate.GetShamsiDateInNumericFormat.HasValue Then
                    '    Q1 &= " and  fileCaseOpenDate>= " & fromDate.GetShamsiDateInNumericFormat
                    'End If

                    'If toDate.GetShamsiDateInNumericFormat.HasValue Then
                    '    Q1 &= " and  fileCaseOpenDate<= " & toDate.GetShamsiDateInNumericFormat
                    'End If

                    'Dim dt As DataTable = FileCaseManager.GetReportByMoshavere(Q1)
                    'ShowReport(dt, "rpt_DataSet_stpRpt", "LawyerApp.Moshaver2Garardad.rdlc", Nothing)


                Case ReportType.Oragh


                    'Dim Q1, Q2 As String
                    'Q1 = String.Empty
                    'Q2 = String.Empty

                    'If txtContent.Text.Trim() <> String.Empty Then
                    '    Q1 = " and contactinfo.custFullName like '%" & NwdSolutions.Web.GeneralUtilities.General.DbReplace(txtContent.Text.Trim()) & "%'"
                    'End If

                    'If fromDate.GetShamsiDateInNumericFormat.HasValue Then
                    '    Q2 = " fileCaseOpenDate>= " & fromDate.GetShamsiDateInNumericFormat
                    'End If

                    'If toDate.GetShamsiDateInNumericFormat.HasValue Then
                    '    If Q2 <> String.Empty Then Q2 &= " and "
                    '    Q2 &= " fileCaseOpenDate<= " & toDate.GetShamsiDateInNumericFormat
                    'End If
                    'If Q2 <> String.Empty Then Q2 = " where " & Q2

                    'Dim dt As DataTable = FileCaseManager.GetReportByOragh(Q1, Q2)
                    'ShowReport(dt, "rpt_DataSet_stpRpt2", "LawyerApp.OragNo.rdlc", Nothing)


                Case ReportType.subject


                    Dim Q As String = String.Empty

                    If fromDate.GetShamsiDateInNumericFormat.HasValue Then
                        Q = " fileCaseOpenDate>= " & fromDate.GetShamsiDateInNumericFormat
                    End If

                    If toDate.GetShamsiDateInNumericFormat.HasValue Then
                        If Q <> String.Empty Then Q &= " and "
                        Q &= " fileCaseOpenDate<= " & toDate.GetShamsiDateInNumericFormat
                    End If

                    If txtContent.Text.Trim() <> String.Empty Then
                        If Q <> String.Empty Then Q &= " and "
                        Q &= " fileCaseSubject like '%" & txtContent.Text.Trim() & "%'"
                    End If

                    If Q <> String.Empty Then Q = " where " & Q

                    Dim dt As DataTable = FileCaseManager.GetReportBySubject(Q)
                    ShowReport(dt, "rpt_DataSet_stpRpt", "LawyerApp.Subject.rdlc", Nothing)




                Case ReportType.Incoming

                    Dim _ReportDataTable As New DataTable

                    'TODO: This line of code loads data into the 'rpt_DataSet.dt_rptIncoming' table. You can move, or remove it, as needed.
                    ' Me.dt_rptIncomingTableAdapter.Fill(Me.rpt_DataSet.dt_rptIncoming)
                    ' _ReportDataTable = Me.rpt_DataSet.dt_rptIncoming.Copy()


                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", "پارامتر")
                    lblTitle.Text = "گزارش مالی پرونده ها"
                    ShowReport(_ReportDataTable, "rpt_DataSet_dt_rptIncoming", "LawyerApp.Incoming.rdlc", Params)


            End Select



        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("btnSearch_Click()", ex.ToString, Me.Text)
        End Try

    End Sub


    Private Sub ShowReport(ByVal _Dt As DataTable, ByVal _ReportDataSources As String, ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)

        Try

            If _Dt IsNot Nothing Then

                Me.ReportViewer1.Reset()
                Me.ReportViewer1.LocalReport.DataSources.Add(HS.Report.ReportDataSource.GetRds(_Dt, _ReportDataSources))
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = _ReportRdlc
                If Params IsNot Nothing Then
                    ReportViewer1.LocalReport.SetParameters(Params)
                End If
                Me.ReportViewer1.RefreshReport()

            Else
                lblMessage.Text = "خطا در دریافت اطلاعات"
            End If

        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("ShowReport()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub ShowReport(ByVal _Collection As ICollection, ByVal _ReportDataSources As String, ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)

        Try

            If _Collection IsNot Nothing Then

                Me.ReportViewer1.Reset()
                Me.ReportViewer1.LocalReport.DataSources.Add(HS.Report.ReportDataSource.GetRds(_Collection, _ReportDataSources))
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = _ReportRdlc
                If Params IsNot Nothing Then
                    ReportViewer1.LocalReport.SetParameters(Params)
                End If
                Me.ReportViewer1.RefreshReport()

            Else
                lblMessage.Text = "خطا در دریافت اطلاعات"
            End If

        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("ShowReport()", ex.ToString, Me.Text)
        End Try


    End Sub

#End Region

    Private Sub txtContent_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtContent.DragDrop
        Try

            lblMessage.Text = String.Empty

            Dim data As ArrayList = e.Data.GetData("ArrayList")

            If data.Item(0) = "Contact" Then

                Dim contact() As ListViewItem = data.Item(1)

                If contact IsNot Nothing AndAlso contact.Count > 0 Then

                    txtContent.Text = contact(0).Text

                End If

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("txtContent_DragDrop", ex.ToString(), Me.Text)
        End Try
    End Sub

    Private Sub txtContent_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtContent.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub UcContacts1_ContactAdd(ByVal c As Lawyer.Common.VB.ContactInfo.ContactInfoReview) Handles UcContacts1.ContactAdd
        Try
            txtContent.Text = c.custFullName
            UcContacts1.Hide()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtPersonName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        SplitContainer1.SplitterDistance = 105

        UcContacts1.Focus()

        Dim t As TextBox = CType(sender, TextBox)

        UcContacts1.BindContacts(WFControls.VB.ucContacts.SearchType.role, "", UcContacts1.Location, e.KeyChar, t.Name)

    End Sub

    Private Sub UcContacts1_ContactDetail(ByVal custId As String) Handles UcContacts1.ContactDetail

        Dim f As New ContactAdd(custId)

        f.ShowDialog()

    End Sub

    Private Sub btnContactSearh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContactSearh.Click
        Dim f As New ContactSearch

        f.Show()
    End Sub

    
End Class