Imports Lawyer.Common.VB.Laws
Imports Microsoft.Reporting.WinForms
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.LawyerError
Imports myReport = HS.Report_Rdlc
Imports Lawyer.Common.VB.Timing


Public Class MyReports

#Region "variable"

    Private _isCollectionMode As Boolean
    Private _title As String
    Private _param As Dictionary(Of String, String)
    Private _reportName As String

    Private _emptyreport As Boolean = False

#End Region

#Region "- Property  -"

    Private _ReportDataTable As DataTable

    Private _ICollection As ICollection

    Private _OtherParameter As String

    Public WriteOnly Property ReportDataTable(ByVal title As String, ByVal reportName As String, ByVal param As Dictionary(Of String, String)) As DataTable

        Set(ByVal value As DataTable)

            _isCollectionMode = False

            _ReportDataTable = value

            _title = title

            _reportName = reportName

            _param = param


        End Set
    End Property

    Public WriteOnly Property ReportCollection(ByVal title As String, ByVal reportName As String, ByVal param As Dictionary(Of String, String), Optional ByVal otherParameter As String = "") As ICollection

        Set(ByVal value As ICollection)

            _isCollectionMode = True

            _ICollection = value

            _title = title

            _reportName = reportName

            _param = param

            _OtherParameter = otherParameter

        End Set

    End Property

    Public Sub SimpleReport(ByVal reportName As String, ByVal param As Dictionary(Of String, String), Optional ByVal emptyreport As Boolean = False)


        _reportName = reportName

        _param = param

        _emptyreport = emptyreport
    End Sub


#End Region

#Region "- ShowReport -"

    Private Sub FillReport()

        Try
            ' Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

            lblTitle.Text = _title

            Dim param() As ReportParameter
            If _param IsNot Nothing AndAlso _param.Count > 0 Then
                param = New ReportParameter(_param.Count - 1) {}
                Dim index As Integer = 0
                For Each Item As String In _param.Keys
                    param(index) = New ReportParameter(Item, _param(Item))
                    index += 1
                Next

            End If

            If _isCollectionMode Then

                'Dim datasources() As String

                'If _reportName = "testRpt2" Then
                '    datasources = New String() {String.Format("DataSet1_{0}", _reportName), String.Format("DataSet1_{0}", "")}
                'Else
                '    datasources = New String() {String.Format("DataSet1_{0}", _reportName)}
                'End If

                ShowReport(_ICollection, String.Format("DataSet1_{0}", _reportName), String.Format("WFControls.VB.{0}.rdlc", _reportName), param)

            Else

                ShowReport(_ReportDataTable, String.Format("DataSet1_{0}", _reportName), String.Format("WFControls.VB.{0}.rdlc", _reportName), param)

            End If



        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("FillReport()", ex.ToString, Me.Text)
        End Try

    End Sub

    Public Sub ShowReport(ByVal _Dt As DataTable, ByVal _ReportDataSources As String, ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)

        Try

            If _Dt IsNot Nothing Then

                Me.ReportViewer1.Reset()

                Me.ReportViewer1.LocalReport.DataSources.Add(myReport.ReportDataSource.GetRds(_Dt.Copy(), _ReportDataSources))

                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = _ReportRdlc

                If Params IsNot Nothing Then

                    ReportViewer1.LocalReport.SetParameters(Params)

                End If

                Me.ReportViewer1.RefreshReport()
            End If

            If _emptyreport = True Then

                Me.ReportViewer1.Reset()

                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = _ReportRdlc

                If Params IsNot Nothing Then

                    ReportViewer1.LocalReport.SetParameters(Params)

                End If

                Me.ReportViewer1.RefreshReport()

            End If

        Catch ex As Exception
            'lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("ShowReport()", ex.ToString, Me.Text)
        End Try
        Me.Show()

    End Sub

    Private Sub ShowReport(ByVal _Collection As ICollection, ByVal _ReportDataSources As String, ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)

        Try

            If _Collection IsNot Nothing Then

                Me.ReportViewer1.Reset()
                Me.ReportViewer1.LocalReport.DataSources.Add(myReport.ReportDataSource.GetRds(_Collection, _ReportDataSources))
                If _ReportDataSources = "DataSet1_testRpt2" Then
                    Me.ReportViewer1.LocalReport.DataSources.Add(myReport.ReportDataSource.GetRds(TimingManager.TimingSearchByFilecaseId(_OtherParameter, Lawyer.Common.VB.Login.CurrentLogin.CurrentUser.UserID), "DataSet1_stp_rptTiming"))
                End If
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = _ReportRdlc
                If Params IsNot Nothing Then
                    ReportViewer1.LocalReport.SetParameters(Params)
                End If
                Me.ReportViewer1.RefreshReport()

                'Else
                '    lblMessage.Text = "خطا در دریافت اطلاعات"
            End If

        Catch ex As Exception
            lblMessage.Text = "خطا در بارگذاری گزارش"
            ErrorManager.WriteMessage("ShowReport()", ex.ToString, Me.Text)
        End Try


    End Sub

    'Private Sub ShowReport(ByVal _Collection As ICollection, ByVal _ReportDataSources As String(), ByVal _ReportRdlc As String, ByVal Params() As ReportParameter)

    '    Try

    '        If _Collection IsNot Nothing Then

    '            Me.ReportViewer1.Reset()

    '            For index As Integer = 0 To _ReportDataSources.Length - 1

    '                Me.ReportViewer1.LocalReport.DataSources.Add(myReport.ReportDataSource.GetRds(_Collection, _ReportDataSources(index)))

    '            Next

    '            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = _ReportRdlc
    '            If Params IsNot Nothing Then
    '                ReportViewer1.LocalReport.SetParameters(Params)
    '            End If
    '            Me.ReportViewer1.RefreshReport()

    '        Else
    '            lblMessage.Text = "خطا در دریافت اطلاعات"
    '        End If

    '    Catch ex As Exception
    '        lblMessage.Text = "خطا در بارگذاری گزارش"
    '        ErrorManager.WriteMessage("ShowReport()", ex.ToString, Me.Text)
    '    End Try


    'End Sub

#End Region

#Region "Form"

    Private Sub Reports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        lblMessage.Text = String.Empty

        FillReport()

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportsFix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try

    End Sub

#End Region

    Private Sub MyReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class