Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities
Imports System.Windows.Forms

Namespace Guilts

    Public Class GuiltManager


        Public Shared Function GetTgTitleForAutoComplate_ACSC(ByVal tgTitle As String) As AutoCompleteStringCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tgTitle", General.DbReplace(tgTitle))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolsguiltkeywordsSelBytgTitleForAutoComplate", params)

            If db.HasError Then Throw db.ErrorException

            Dim ACSC As New AutoCompleteStringCollection
            While reader.Read
                Dim LawKeyWord As String = GetKeyWord(reader)
                ACSC.Add(LawKeyWord)
            End While
            reader.Close()

            Return ACSC

        End Function


        Public Shared Function GetGuiltsForGrid(ByVal TitlePenalty As String) As GuiltCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_TitlePenalty", General.DbReplace(TitlePenalty))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolsguiltSelByTitlePenalty", params)

            If db.HasError Then Throw db.ErrorException

            Dim GuiltCollection As New GuiltCollection
            While reader.Read
                Dim Guilt As Guilt = GetGuiltForGrid(reader)
                GuiltCollection.Add(Guilt)
            End While
            reader.Close()

            Return GuiltCollection

        End Function


        Public Shared Function GetGuiltsForGrid_Like(ByVal TitlePenalty As String) As GuiltCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_TitlePenalty", General.DbReplace(TitlePenalty))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolsguiltSelByTitlePenalty_Like", params)

            If db.HasError Then Throw db.ErrorException

            Dim GuiltCollection As New GuiltCollection
            While reader.Read
                Dim Guilt As Guilt = GetGuiltForGrid(reader)
                GuiltCollection.Add(Guilt)
            End While
            reader.Close()

            Return GuiltCollection

        End Function


        Public Shared Function GetGuiltInfo(ByVal tgID As Integer) As Guilt

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tgID", tgID)  'General.DbReplace(jobName)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolsguiltSelByTgID", params)

            If db.HasError Then Throw db.ErrorException

            'Dim Books As New BookCollection
            'While reader.Read
            reader.Read()
            Dim Guilt As Guilt = GetGuiltInfo(reader)
            'Books.Add(Book)
            'End While
            reader.Close()

            Return Guilt

        End Function


#Region "Utility"


        Private Shared Function GetKeyWord(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim KeyWord As String
            KeyWord = DbAccessLayer.MySqlDataHelper.GetString(reader, "tgTitle")

            Return KeyWord

        End Function






        Private Shared Function GetGuiltForGrid(ByVal reader As IDataReader) As Guilt

            If reader Is Nothing Then Return Nothing

            Dim Guilt As New Guilt
            Guilt.tgID = DbAccessLayer.SqlDataHelper.GetInt(reader, "tgID")
            Guilt.tgTitle = DbAccessLayer.SqlDataHelper.GetString(reader, "tgTitle")

            Return Guilt

        End Function


        Private Shared Function GetGuiltInfo(ByVal reader As IDataReader) As Guilt

            If reader Is Nothing Then Return Nothing

            Dim Guilt As New Guilt
            'Guilt.tgID = DbAccessLayer.SqlDataHelper.GetInt(reader, "tgID")
            Guilt.tgTitle = DbAccessLayer.SqlDataHelper.GetString(reader, "tgTitle")
            Guilt.tgRuleDef = DbAccessLayer.SqlDataHelper.GetString(reader, "tgRuleDef")
            Guilt.tgPenalty = DbAccessLayer.SqlDataHelper.GetString(reader, "tgPenalty")
            Guilt.tgRelatedRules = DbAccessLayer.SqlDataHelper.GetString(reader, "tgRelatedRules")
            Guilt.tgRuleTile = DbAccessLayer.SqlDataHelper.GetString(reader, "tgRuleTile")
            Guilt.tgRulePassedDate = DbAccessLayer.SqlDataHelper.GetString(reader, "tgRulePassedDate")
            Guilt.tgDescription = DbAccessLayer.SqlDataHelper.GetString(reader, "tgDescription")


            Return Guilt

        End Function





#End Region


    End Class

End Namespace
