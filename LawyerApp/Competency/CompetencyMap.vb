Imports System.IO
Imports NwdSolutions.Web.GeneralUtilities
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.Competencys
Imports Lawyer.Common.VB.Competencys.Enums


Public Class CompetencyMap

#Region "- Property -"


    Private _CityStreet As String
    Public Property CityStreet() As String
        Get
            Return _CityStreet
        End Get
        Set(ByVal value As String)
            _CityStreet = value
            Me.Map1.BindMap(_CityStreet)
        End Set
    End Property



#End Region

#Region "- Load -"

    Private Sub LawSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'For Each c As Control In Me.Panel1.Controls
        '    c.AllowDrop = True
        'Next

        Me.lblMessage.Text = String.Empty
        
        
        ' ToolTip1.SetToolTip(pbEdit, "ویرایش صلاحیت")


    End Sub

#End Region

#Region "- Other -"

    Private Sub Map1_ShowMessage(ByVal msg As String) Handles Map1.ShowMessage

        Me.lblMessage.Text = msg

    End Sub

#End Region


End Class