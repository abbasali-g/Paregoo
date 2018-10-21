Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities
Imports System.Text

Namespace Judgments

    Public Class JudgmentManager


        Public Shared Function GetJudgmentLevels() As JudgmentCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_Year", General.DbReplace(Year))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToodadrasiSelAll", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim JudgmentCollection As New JudgmentCollection
            While reader.Read
                Dim Judgment As Judgment = GetJudgment(reader)
                JudgmentCollection.Add(Judgment)
            End While
            reader.Close()

            Return JudgmentCollection

        End Function

        Public Shared Function GetFixedValue(ByVal tdID As Integer) As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tdID", tdID) 'General.DbReplace(jobName)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_ToodadrasiSelBytdID", params))

            If db.HasError Then Throw db.ErrorException
            Return result

        End Function


        Public Shared Function GetOtherJudgmens() As StringBuilder

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_Year", General.DbReplace(Year))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolsdadrasiothersSelAll", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim StringBuilder As New StringBuilder
            While reader.Read
                StringBuilder.Append(vbNewLine + GetTdoText(reader) + vbNewLine)
            End While
            reader.Close()

            Return StringBuilder

        End Function




#Region "Utility"


        Private Shared Function GetJudgment(ByVal reader As IDataReader) As Judgment

            If reader Is Nothing Then Return Nothing

            Dim Judgment As New Judgment
            Judgment.tdID = DbAccessLayer.SqlDataHelper.GetInt(reader, "tdID")
            Judgment.tdLevelName = DbAccessLayer.SqlDataHelper.GetString(reader, "tdLevelName")
            Judgment.tdLevelFixedValue = DbAccessLayer.SqlDataHelper.GetReal(reader, "tdLevelFixedValue")

            Return Judgment

        End Function



        Private Shared Function GetTdoText(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim Str As String
            Str = DbAccessLayer.SqlDataHelper.GetString(reader, "tdoText")

            Return str

        End Function






#End Region






    End Class

End Namespace
