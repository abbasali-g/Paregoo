Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities

Namespace Laws

    Public Class LawDirectoryKeywordManager


        Public Shared Function InsertLawDirectoryKeyWord(ByVal LawDirectoryKeyword As LawDirectoryKeyword) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_lsid", General.DbReplace(LawDirectoryKeyword.lsid))
            params(1) = New MySqlParameter("_lkText", General.DbReplace(LawDirectoryKeyword.lkText))

            Dim result As Integer = db.ExecuteProcedure("stpDad_lawdirectorykeywordsIns", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function


        Public Shared Function DeleteLawDirectoryKeyWord(ByVal LawDirectoryKeyword As LawDirectoryKeyword) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_lsid", LawDirectoryKeyword.lsid)
            params(1) = New MySqlParameter("_lkText", General.DbReplace(LawDirectoryKeyword.lkText))

            Dim result As Integer = db.ExecuteProcedure("stpDad_lawdirectorykeywordsDel", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function



        Public Shared Function GetLawkeywordsBylsid(ByVal lsid As Integer) As List(Of String)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lsid", lsid)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_lawdirectorykeywordsSelBylsid", params)
            If db.HasError Then Throw db.ErrorException

            Dim lawKeywords As New List(Of String)
            While reader.Read
                Dim LawKeyWord As String = GetLawKeyWord(reader)
                lawKeywords.Add(LawKeyWord)
            End While
            reader.Close()

            Return lawKeywords


        End Function

#Region "Utility"


        Private Shared Function GetLawKeyWord(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim LawKeyWord As String
            LawKeyWord = DbAccessLayer.MySqlDataHelper.GetString(reader, "lkText")

            Return LawKeyWord

        End Function


#End Region


    End Class



End Namespace
