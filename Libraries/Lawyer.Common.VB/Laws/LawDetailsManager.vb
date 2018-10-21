Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports NwdSolutions.Web.GeneralUtilities


Namespace Laws


    Public Class LawDetailsManager

#Region "For Convert"


        Public Shared Function testInsertdet(ByVal LawDetails As LawDetails) As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(2) As MySqlParameter

            'IIf(String.IsNullOrEmpty(job.JobCatDesc), DBNull.Value, job.JobCatDesc))

            params(0) = New MySqlParameter("_lawID", General.DbReplace(LawDetails.lawID))
            params(1) = New MySqlParameter("_lawDetTitle", General.DbReplace(LawDetails.lawDetTitle))
            params(2) = New MySqlParameter("_lawDetContent", General.DbReplace(LawDetails.lawDetContent))

            Dim result As Integer = db.GetScalarFromProcedure("test_ins", params)

            If db.HasError Then Return False
            Return result

        End Function


        'test_upd

        Public Shared Function testUpdatedet(ByVal LawDetails As LawDetails) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", LawDetails.lawID)
            params(1) = New MySqlParameter("_lawTitle", LawDetails.lawDetContent)

            Dim result As Integer = db.ExecuteProcedure("test_upd", params)

            If db.HasError Then Return False
            Return True

        End Function


        Public Shared Function GetLowId() As List(Of Integer)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_LawId", LowId)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("test_selAll", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim LowIds As New List(Of Integer)
            While reader.Read
                Dim LowId As Integer = GetLowId(reader)
                LowIds.Add(LowId)
            End While
            reader.Close()

            Return LowIds

        End Function



#End Region



        Public Shared Function GetLawDetailsByLawId(ByVal lawID As Integer) As LawDetailsCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", lawID)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDetailsSelByLawId", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawDetailsCollection As New LawDetailsCollection
            While reader.Read
                Dim LawDetails As LawDetails = GetLawDetail(reader)
                LawDetailsCollection.Add(LawDetails)
            End While
            reader.Close()

            Return LawDetailsCollection

        End Function

        Public Shared Function GetLawDetailsByLawIdAndContent(ByVal lawID As Integer, ByVal lawDetContent As String) As LawDetailsCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", lawID)
            params(1) = New MySqlParameter("_lawDetContent", lawDetContent)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDetailsSelByLawIdAndContent", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawDetailsCollection As New LawDetailsCollection
            While reader.Read
                Dim LawDetails As LawDetails = GetLawDetail(reader)
                LawDetailsCollection.Add(LawDetails)
            End While
            reader.Close()

            Return LawDetailsCollection

        End Function

        Public Shared Function GetLawDetailsByContent(ByVal lawDetContent As String) As LawDetailsCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawDetContent", lawDetContent)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDetailsSelByContent", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawDetailsCollection As New LawDetailsCollection
            While reader.Read
                Dim LawDetails As LawDetails = GetLawDetail(reader)
                LawDetailsCollection.Add(LawDetails)
            End While
            reader.Close()

            Return LawDetailsCollection

        End Function

        Public Shared Function GetLawDetailsBylawDetID(ByVal lawDetID As Integer) As LawDetailsCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawDetID", lawDetID)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDetailsSelBylawDetID", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawDetailsCollection As New LawDetailsCollection
            While reader.Read
                Dim LawDetails As LawDetails = GetLawDetail(reader)
                LawDetailsCollection.Add(LawDetails)
            End While
            reader.Close()

            Return LawDetailsCollection

        End Function


        Public Shared Function LawdetailsDel(ByVal lawID As Integer) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", lawID)

            Dim rocount As Integer = CInt(db.ExecuteProcedure("stpDad_LawdetailsDel", params))

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function




#Region "Utility"


        Private Shared Function GetLawDetail(ByVal reader As IDataReader) As LawDetails

            If reader Is Nothing Then Return Nothing

            Dim LawDetails As New LawDetails
            LawDetails.lawDetID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawDetID")
            LawDetails.lawID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawID")
            LawDetails.lawDetTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawDetTitle")
            LawDetails.lawDetContent = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawDetContent")
            LawDetails.lawDetType = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawDetType")
            LawDetails.lawDetOwner = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawDetOwner")
            LawDetails.lawDetParent = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "lawDetParent")
            LawDetails.lawDetSubParent = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "lawDetSubParent")

            Return LawDetails

        End Function


        Private Shared Function GetLowId(ByVal reader As IDataReader) As Integer

            If reader Is Nothing Then Return Nothing

            Dim lawID As Integer
            lawID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawID")

            Return lawID

        End Function

#End Region


    End Class


End Namespace
