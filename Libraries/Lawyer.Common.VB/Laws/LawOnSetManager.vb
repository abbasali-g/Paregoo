Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities

Namespace Laws



    Public Class LawOnSetManager


        Public Shared Function GetLawOnSetForTree() As LawOnSetCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_bmSex", bmSex)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDirectorySelAllForTree", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim LawOnSetCollection As New LawOnSetCollection
            While reader.Read
                Dim LawOnSet As LawOnSet = GetLawOnSet(reader)
                LawOnSetCollection.Add(LawOnSet)
            End While
            reader.Close()

            Return LawOnSetCollection

        End Function

        Public Shared Function GetLawOnSetBylawDetContentForTree_Like(ByVal lawDetContent As String) As LawOnSetCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawDetContent", General.DbReplace(lawDetContent))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawOnSetSelBylawDetContentForTree_Like", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawOnSetCollection As New LawOnSetCollection
            While reader.Read
                Dim LawOnSet As LawOnSet = GetLawOnSet(reader)
                LawOnSetCollection.Add(LawOnSet)
            End While
            reader.Close()

            Return LawOnSetCollection

        End Function


        Public Shared Function DeleteLawOnSet(ByVal lsid As Integer, ByVal ltid As Integer) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_lsid", lsid)
            params(1) = New MySqlParameter("_ltid", ltid)

            Dim rocount As Integer = CInt(db.ExecuteProcedure("stpDad_LawOnSetDelBylsid", params))

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function


        Public Shared Function InsertLawOnSet(ByVal LawOnSet As LawOnSet) As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(2) As MySqlParameter
            'IIf(String.IsNullOrEmpty(job.JobCatDesc), DBNull.Value, job.JobCatDesc))
            params(0) = New MySqlParameter("_ldid", General.DbReplace(LawOnSet.ldID))
            params(1) = New MySqlParameter("_lawid", General.DbReplace(LawOnSet.lawid))
            params(2) = New MySqlParameter("_lawdetid", General.DbReplace(LawOnSet.lawdetid))

            Dim result As Integer = db.GetScalarFromProcedure("stpDad_LawOnSetIns", params)

            If db.HasError Then Throw db.ErrorException
            Return result

        End Function



#Region "Utility"


        Private Shared Function GetLawOnSet(ByVal reader As IDataReader) As LawOnSet

            If reader Is Nothing Then Return Nothing

            Dim LawOnSet As New LawOnSet
            LawOnSet.ldID = DbAccessLayer.SqlDataHelper.GetInt(reader, "ldID")
            LawOnSet.ldName = DbAccessLayer.SqlDataHelper.GetString(reader, "ldName")
            LawOnSet.ldParent = DbAccessLayer.SqlDataHelper.GetInt64(reader, "ldParent") 'ifnull make long

            LawOnSet.ltid = DbAccessLayer.SqlDataHelper.GetInt(reader, "ltid")
            LawOnSet.lawid = DbAccessLayer.SqlDataHelper.GetInt(reader, "lawid")
            LawOnSet.lsid = DbAccessLayer.SqlDataHelper.GetInt(reader, "lsid")
            LawOnSet.lawdetid = DbAccessLayer.SqlDataHelper.GetInt(reader, "lawdetid")

            LawOnSet.lawTitle = DbAccessLayer.SqlDataHelper.GetString(reader, "lawTitle")
            LawOnSet.lawDetTitle = DbAccessLayer.SqlDataHelper.GetString(reader, "lawDetTitle")
            'LawOnSet.lawDetContent = DbAccessLayer.SqlDataHelper.GetString(reader, "lawDetContent")

            LawOnSet.Childs = DbAccessLayer.SqlDataHelper.GetInt(reader, "Childs")

            Return LawOnSet

        End Function




#End Region



    End Class

End Namespace
