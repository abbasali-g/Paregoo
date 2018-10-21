Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities
Imports System.Windows.Forms

Namespace Laws

    Public Class LawDirectoryManager


        Public Shared Function GetLDkeyword_ACSC(ByVal lkText As String) As AutoCompleteStringCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lkText", General.DbReplace(lkText))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_lawdirectorykeywordsSelBylkTextForAutoComplate", params)

            If db.HasError Then Throw db.ErrorException

            Dim ACSC As New AutoCompleteStringCollection
            While reader.Read
                Dim LawKeyWord As String = GetKeyWord(reader)
                ACSC.Add(LawKeyWord)
            End While
            reader.Close()

            Return ACSC

        End Function



        Public Shared Function GetLawDirectoryForTree() As LawDirectoryCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_bmSex", bmSex)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDirectorySelAllWithChild", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim LawDirectoryCollection As New LawDirectoryCollection
            While reader.Read
                Dim LawDirectory As LawDirectory = GetLawDirectory(reader)
                LawDirectoryCollection.Add(LawDirectory)
            End While
            reader.Close()

            Return LawDirectoryCollection

        End Function


        Public Shared Function GetLawDirectoryForTreeInSearch(ByVal ldID As Integer) As LawDirectoryCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_ldID", ldID)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDirectorySelByldIDWithChild", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawDirectoryCollection As New LawDirectoryCollection
            While reader.Read
                Dim LawDirectory As LawDirectory = GetLawDirectory(reader)
                LawDirectoryCollection.Add(LawDirectory)
            End While
            reader.Close()

            Return LawDirectoryCollection

        End Function


        Public Shared Function UpdateLawDirectory(ByVal LawDirectory As LawDirectory) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_ldName", General.DbReplace(LawDirectory.ldName))
            params(1) = New MySqlParameter("_ldID", LawDirectory.ldID)

            Dim result As Integer = db.ExecuteProcedure("stpDad_LawDirectoryUpdIdName", params)

            If db.HasError Then Throw db.ErrorException
            Return True


        End Function


        Public Shared Function InsertLawDirectory(ByVal LawDirectory As LawDirectory) As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            'IIf(String.IsNullOrEmpty(job.JobCatDesc), DBNull.Value, job.JobCatDesc))
            params(0) = New MySqlParameter("_ldName", General.DbReplace(LawDirectory.ldName))
            params(1) = New MySqlParameter("_ldParent", General.DbReplace(LawDirectory.ldParent))

            Dim result As Integer = db.GetScalarFromProcedure("stpDad_LawDirectoryIns", params)

            If db.HasError Then Throw db.ErrorException
            Return result

        End Function


        Public Shared Function DeleteLawDirectory(ByVal ldID As Integer) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_ldID", ldID)
            Dim rocount As Integer = CInt(db.ExecuteProcedure("stpDad_LawDirectoryDel", params))

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function




#Region "Utility"


        Private Shared Function GetLawDirectory(ByVal reader As IDataReader) As LawDirectory

            If reader Is Nothing Then Return Nothing

            Dim LawDirectory As New LawDirectory
            LawDirectory.ldID = DbAccessLayer.SqlDataHelper.GetInt(reader, "ldID")
            LawDirectory.ldName = DbAccessLayer.SqlDataHelper.GetString(reader, "ldName")
            LawDirectory.ldParent = DbAccessLayer.SqlDataHelper.GetInt(reader, "ldParent")
            LawDirectory.Childs = DbAccessLayer.SqlDataHelper.GetInt(reader, "Childs")

            ' BloodMoney.bmParentID = DbAccessLayer.SqlDataHelper.GetInt64(reader, "bmParentID") 'ifnull make long

            Return LawDirectory

        End Function


        Private Shared Function GetKeyWord(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim KeyWord As String
            KeyWord = DbAccessLayer.MySqlDataHelper.GetString(reader, "lkText")

            Return KeyWord

        End Function







#End Region



    End Class


End Namespace
