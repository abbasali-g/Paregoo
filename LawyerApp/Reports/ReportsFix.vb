Imports Lawyer.Common.VB.Laws
Imports Microsoft.Reporting.WinForms
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.LawyerError



Public Class ReportsFix

#Region "- Enum -"

    Enum ReportType

        CaseDocuments = 1
        Hazine = 2
        Actions = 3
        PersonCases = 4
        ClericalSpending = 5
        ActionsNumberLess = 6
        Consulting = 7
        Consulting_Lawyer = 8
        HazineOfOneCase = 9
        Hazine_H = 10
        Hazine_D = 11

    End Enum

#End Region

#Region "- Property  -"

    Private _ReportViewType As ReportType
    Private ReadOnly Property ReportViewType() As ReportType
        Get
            Return _ReportViewType
        End Get

    End Property

    Private _ReportViewParameter As String
    Private ReadOnly Property ReportViewParameter() As String
        Get
            If _ReportViewParameter Is Nothing Then
                _ReportViewParameter = String.Empty
            End If

            Return _ReportViewParameter
        End Get

    End Property


    Private _ReportDataTable As DataTable
    Public Property ReportDataTable(ByVal ReportViewType As ReportType, ByVal ReportViewParameter As String) As DataTable
        Get
            Return _ReportDataTable
        End Get
        Set(ByVal value As DataTable)
            _ReportDataTable = value

            _ReportViewType = ReportViewType
            _ReportViewParameter = ReportViewParameter

        End Set
    End Property

    Private _ICollection As ICollection
    Public Property ReportCollection(ByVal ReportViewType As ReportType, ByVal ReportViewParameter As String) As ICollection
        Get
            Return _ICollection
        End Get
        Set(ByVal value As ICollection)
            _ICollection = value

            _ReportViewType = ReportViewType
            _ReportViewParameter = ReportViewParameter

        End Set
    End Property



#End Region

#Region "- New -"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "- Load -"

    Private Sub Reports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

        lblMessage.Text = String.Empty
        '_ReportViewType = ReportType.Hazine_H
        '_ReportViewParameter = "ینمس منبلا بمنال نتال نتسا نتال نتاس " + vbCrLf + "لنتسیا سنتا سنتیبا نستیبا نستیبا "


        FillReport()

        Me.ReportViewer2.RefreshReport()
        Me.ReportViewer2.RefreshReport()
        Me.ReportViewer2.RefreshReport()
    End Sub

#End Region

#Region "- Report -"

    Private Sub FillReport()

        Try

            Select Case _ReportViewType

                Case ReportType.CaseDocuments

                    'TODO: This line of code loads data into the 'rpt_DataSet.rpt_CaseDocuments' table. You can move, or remove it, as needed.
                    'Me.rpt_CaseDocumentsTableAdapter.Fill(Me.rpt_DataSet.rpt_CaseDocuments, "3028a461-a7f6-4f51-a8d0-248f9906ed68", 8)
                    '_ReportDataTable = Me.rpt_DataSet.rpt_CaseDocuments.Copy

                    lblTitle.Text = "لیست محتویات پرونده"
                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pCaseSpecification", Me.ReportViewParameter)
                    ShowReport(_ReportDataTable, "rpt_DataSet_rpt_CaseDocuments", "LawyerApp.CaseDocuments.rdlc", Params)

                Case ReportType.Hazine

                    'TODO: This line of code loads data into the 'rpt_DataSet.rpt_Hazine' table. You can move, or remove it, as needed.
                    'Me.rpt_HazineTableAdapter.Fill(Me.rpt_DataSet.rpt_Hazine)
                    ' _ReportDataTable = Me.rpt_DataSet.rpt_Hazine.Copy

                    lblTitle.Text = "گزارش هزینه ها"
                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    ShowReport(_ReportDataTable, "rpt_DataSet_rpt_Hazine", "LawyerApp.fixHazine.rdlc", Params)



                Case ReportType.Actions

                    'TODO: This line of code loads data into the 'rpt_DataSet.rpt_FixActions' table. You can move, or remove it, as needed.
                    'Me.rpt_FixActionsTableAdapter.Fill(Me.rpt_DataSet.rpt_FixActions)
                    ' _ReportDataTable = Me.rpt_DataSet.rpt_FixActions.Copy

                    lblTitle.Text = "گزارش اقدامات"
                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    ShowReport(_ReportDataTable, "rpt_DataSet_rpt_FixActions", "LawyerApp.fixActions.rdlc", Params)



                Case ReportType.ActionsNumberLess

                    'TODO: This line of code loads data into the 'rpt_DataSet.rpt_FixActions' table. You can move, or remove it, as needed.
                    'Me.rpt_FixActionsTableAdapter.Fill(Me.rpt_DataSet.rpt_FixActions)
                    ' _ReportDataTable = Me.rpt_DataSet.rpt_FixActions.Copy

                    lblTitle.Text = "2گزارش اقدامات"
                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    ShowReport(_ReportDataTable, "rpt_DataSet_rpt_FixActions", "LawyerApp.fixActionsNumberLess.rdlc", Params)



                Case ReportType.PersonCases ' moved to meno report

                    'TODO: This line of code loads data into the 'rpt_DataSet.rpt_PersonCases' table. You can move, or remove it, as needed.
                    'Me.rpt_PersonCasesTableAdapter.Fill(Me.rpt_DataSet.rpt_PersonCases)
                    '_ReportDataTable = Me.rpt_DataSet.rpt_PersonCases.Copy

                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    ShowReport(_ReportDataTable, "rpt_DataSet_rpt_PersonCases", "LawyerApp.PersonCases.rdlc", Params)


                Case ReportType.ClericalSpending

                    'TODO: This line of code loads data into the 'rpt_DataSet.rpt_fixClericalSpending' table. You can move, or remove it, as needed.
                    ' Me.rpt_fixClericalSpendingTableAdapter.Fill(Me.rpt_DataSet.rpt_fixClericalSpending)
                    '_ReportDataTable = Me.rpt_DataSet.rpt_fixClericalSpending.Copy
                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    lblTitle.Text = "گزارش هزینه های دفتری"
                    ShowReport(_ReportDataTable, "rpt_DataSet_rpt_fixClericalSpending", "LawyerApp.fixClericalSpending.rdlc", Params)



                Case ReportType.Consulting

                    'TODO: This line of code loads data into the 'rpt_DataSet.rpt_FixConsulting' table. You can move, or remove it, as needed.
                    'Me.rpt_FixConsultingTableAdapter.Fill(Me.rpt_DataSet.rpt_FixConsulting)
                    '_ReportDataTable = Me.rpt_DataSet.rpt_FixConsulting.Copy

                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    lblTitle.Text = "گزارش مشاوره"
                    ShowReport(_ReportDataTable, "rpt_DataSet_rpt_FixConsulting", "LawyerApp.fixConsulting.rdlc", Params)


                Case ReportType.Consulting_Lawyer

                    'TODO: This line of code loads data into the 'rpt_DataSet.rpt_FixConsulting' table. You can move, or remove it, as needed.
                    'Me.rpt_FixConsultingTableAdapter.Fill(Me.rpt_DataSet.rpt_FixConsulting)
                    '_ReportDataTable = Me.rpt_DataSet.rpt_FixConsulting.Copy

                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    lblTitle.Text = "گزارش مشاوره"
                    ShowReport(_ReportDataTable, "rpt_DataSet_rpt_FixConsulting", "LawyerApp.fixConsulting_Lawyer.rdlc", Params)


                Case ReportType.HazineOfOneCase

                    'TODO: This line of code loads data into the 'rpt_DataSet.dt_rptFixHazine' table. You can move, or remove it, as needed.
                    ' Me.dt_rptFixHazineTableAdapter.Fill(Me.rpt_DataSet.dt_rptFixHazine)
                    '_ReportDataTable = Me.rpt_DataSet.dt_rptFixHazine.Copy

                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    lblTitle.Text = "گزارش هزینه های پرونده"
                    ShowReport(_ReportDataTable, "rpt_DataSet_dt_rptFixHazine", "LawyerApp.fixHazineOfOneCase.rdlc", Params)

                Case ReportType.Hazine_H

                    'TODO: This line of code loads data into the 'rpt_DataSet.dt_rptFixHazine' table. You can move, or remove it, as needed.
                    'Me.dt_rptFixHazineTableAdapter.Fill(Me.rpt_DataSet.dt_rptFixHazine)
                    '_ReportDataTable = Me.rpt_DataSet.dt_rptFixHazine.Copy

                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    lblTitle.Text = "گزارش هزینه ها"
                    ShowReport(_ReportDataTable, "rpt_DataSet_dt_rptFixHazine", "LawyerApp.fixHazine_H.rdlc", Params)

                Case ReportType.Hazine_D

                    'TODO: This line of code loads data into the 'rpt_DataSet.dt_rptFixHazine' table. You can move, or remove it, as needed.
                    ' Me.dt_rptFixHazineTableAdapter.Fill(Me.rpt_DataSet.dt_rptFixHazine)
                    ' _ReportDataTable = Me.rpt_DataSet.dt_rptFixHazine.Copy


                    Dim Params(0) As ReportParameter
                    Params(0) = New ReportParameter("pDate", Me.ReportViewParameter)
                    lblTitle.Text = "گزارش دریافتی ها"
                    ShowReport(_ReportDataTable, "rpt_DataSet_dt_rptFixHazine", "LawyerApp.fixHazine_D.rdlc", Params)



            End Select



        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("FillReport()", ex.ToString, Me.Text)
        End Try

    End Sub


#Region "- ShowReport -"


    Private Sub ShowReport(ByVal _Dt As DataTable, ByVal _ReportDataSources As String, ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)

        Try

            If _Dt IsNot Nothing Then

                Me.ReportViewer2.Reset()
                Me.ReportViewer2.LocalReport.DataSources.Add(HS.Report_Rdlc.ReportDataSource.GetRds(_Dt.Copy(), _ReportDataSources))
                Me.ReportViewer2.LocalReport.ReportEmbeddedResource = _ReportRdlc
                If Params IsNot Nothing Then
                    ReportViewer2.LocalReport.SetParameters(Params)
                End If
                Me.ReportViewer2.RefreshReport()

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

                Me.ReportViewer2.Reset()
                Me.ReportViewer2.LocalReport.DataSources.Add(HS.Report_Rdlc.ReportDataSource.GetRds(_Collection, _ReportDataSources))
                Me.ReportViewer2.LocalReport.ReportEmbeddedResource = _ReportRdlc
                If Params IsNot Nothing Then
                    ReportViewer2.LocalReport.SetParameters(Params)
                End If
                Me.ReportViewer2.RefreshReport()

            Else
                lblMessage.Text = "خطا در دریافت اطلاعات"
            End If

        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("ShowReport()", ex.ToString, Me.Text)
        End Try


    End Sub

    Private Sub ShowReport(ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)

        Try

            ' If _Collection IsNot Nothing Then

            ' Me.ReportViewer2.Reset()
            ' Me.ReportViewer2.LocalReport.DataSources.Add(HS.Report.ReportDataSource.GetRds(_Collection, _ReportDataSources))
            Me.ReportViewer2.LocalReport.ReportEmbeddedResource = _ReportRdlc
            If Params IsNot Nothing Then
                ReportViewer2.LocalReport.SetParameters(Params)
            End If
            Me.ReportViewer2.RefreshReport()

            ' Else
            ' lblMessage.Text = "خطا در دریافت اطلاعات"
            ' End If

        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("ShowReport()", ex.ToString, Me.Text)
        End Try


    End Sub


#End Region


#End Region

End Class