Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports System.Windows.Forms
Imports NwdSolutions.Web.GeneralUtilities

Namespace LawKeyWords


    Public Class LawKeyWordManager

        Public Shared Function GetLawkeywordStringCollection(ByVal KeyPart As String, ByVal _lawKeywordLR As Integer) As AutoCompleteStringCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_tgTitle", General.DbReplace(tgTitle))

            'Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolsguiltkeywordsSelBytgTitleForAutoComplate", params)

            Dim Qu As String = "SELECT DISTINCT lawKeywordName FROM  lawkeywords WHERE   (lawKeywordName LIKE '" + General.DbReplace(KeyPart) + "%') and char_length(lawKeywordName) > 3  and lawKeywordLR=" + _lawKeywordLR.ToString + "  ORDER BY lawKeywordName"
            Dim reader As IDataReader = db.GetSqlDataReaderFromCommandText(Qu, Nothing)


            If db.HasError Then Throw db.ErrorException

            Dim ACSC As New AutoCompleteStringCollection
            While reader.Read
                Dim LawKeyWord As String = GetLawKeyWordToStringFromReader(reader)
                ACSC.Add(LawKeyWord)
            End While
            reader.Close()

            Return ACSC

        End Function



        Public Shared Function InsertLawKeyWord(ByVal LawKeyWord As LawKeyWord) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(3) As MySqlParameter
            params(0) = New MySqlParameter("_lawKeywordName", General.DbReplace(LawKeyWord.lawKeywordName))
            params(1) = New MySqlParameter("_lawID", General.DbReplace(LawKeyWord.lawID))
            params(2) = New MySqlParameter("_lawKeywordOwner", General.DbReplace(LawKeyWord.lawKeywordOwner))
            params(3) = New MySqlParameter("_lawKeywordLR", General.DbReplace(LawKeyWord.lawKeywordLR))

            Dim result As Integer = db.ExecuteProcedure("stpDad_lawkeywordsIns", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function

        Public Shared Function DeleteLawKeyWord(ByVal lawID As Integer) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", lawID)

            Dim result As Integer = db.ExecuteProcedure("stpDad_LawkeywordsDel", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function


        Public Shared Function GetLawkeywordsByLowId(ByVal LowId As Integer) As List(Of String)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_LawId", LowId)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_lawkeywordsSelByLawId_ForName", params)

            If db.HasError Then Throw db.ErrorException

            Dim lawKeywords As New List(Of String)
            While reader.Read
                Dim LawKeyWord As String = GetLawKeyWordToStringFromReader(reader)
                lawKeywords.Add(LawKeyWord)
            End While
            reader.Close()

            Return lawKeywords

        End Function


#Region "Utility"


        Private Shared Function GetLawKeyWordFromReader(ByVal reader As IDataReader) As LawKeyWord

            If reader Is Nothing Then Return Nothing

            Dim LawKeyWord As New LawKeyWord
            LawKeyWord.lawKeywordName = DbAccessLayer.SqlDataHelper.GetString(reader, "lawKeywordName")

            Return LawKeyWord

        End Function

        Private Shared Function GetLawKeyWordToStringFromReader(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim LawKeyWord As String
            LawKeyWord = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawKeywordName")

            Return LawKeyWord

        End Function


#End Region


    End Class


End Namespace