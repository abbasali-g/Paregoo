Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities

Namespace Laws

    Public Class LawDetailsOnGridManager


        Public Shared Function GetLawDetailsOnGridSelByawDetContent_Full(ByVal lawDetContent As String) As LawDetailsOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawDetContent", General.DbReplace(lawDetContent))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDetailsOnGridSelByawDetContent_Full", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawDetailsOnGridCollection As New LawDetailsOnGridCollection
            While reader.Read
                Dim LawDetailsOnGrid As LawDetailsOnGrid = GetLawDetailsOnGrid(reader)
                LawDetailsOnGridCollection.Add(LawDetailsOnGrid)
            End While
            reader.Close()

            Return LawDetailsOnGridCollection

        End Function


        Public Shared Function GetLawDetailsOnGridSelBylawDetContentldId_Full(ByVal lawDetContent As String) As LawDetailsOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_ldID", ldID)
            params(0) = New MySqlParameter("_lawDetContent", General.DbReplace(lawDetContent))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDetailsOnGridSelBylawDetContentldId_Full", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawDetailsOnGridCollection As New LawDetailsOnGridCollection
            While reader.Read
                Dim LawDetailsOnGrid As LawDetailsOnGrid = GetLawDetailsOnGrid(reader)
                LawDetailsOnGridCollection.Add(LawDetailsOnGrid)
            End While
            reader.Close()

            Return LawDetailsOnGridCollection

        End Function


        Public Shared Function GetLawDetailsOnGridSelByawDetContent_Like(ByVal lawDetContent As String) As LawDetailsOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawDetContent", General.DbReplace(lawDetContent))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDetailsOnGridSelByawDetContent_Like", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawDetailsOnGridCollection As New LawDetailsOnGridCollection
            While reader.Read
                Dim LawDetailsOnGrid As LawDetailsOnGrid = GetLawDetailsOnGrid(reader)
                LawDetailsOnGridCollection.Add(LawDetailsOnGrid)
            End While
            reader.Close()

            Return LawDetailsOnGridCollection

        End Function


        Public Shared Function GetLawDetailsOnGridSelByLawDetContentldId_Like(ByVal lawDetContent As String) As LawDetailsOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            'params(1) = New MySqlParameter("_ldID", ldID)
            params(0) = New MySqlParameter("_lawDetContent", General.DbReplace(lawDetContent))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawDetailsOnGridSelBylawDetContentldId_Like", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawDetailsOnGridCollection As New LawDetailsOnGridCollection
            While reader.Read
                Dim LawDetailsOnGrid As LawDetailsOnGrid = GetLawDetailsOnGrid(reader)
                LawDetailsOnGridCollection.Add(LawDetailsOnGrid)
            End While
            reader.Close()

            Return LawDetailsOnGridCollection

        End Function


        Public Shared Function GetlawDetContentBylawDetID(ByVal lawDetID As Integer) As String

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawDetID", General.DbReplace(lawDetID))

            Dim Scalar As String = db.GetScalarFromProcedure("stpDad_LawDetailsSelBylawDetIDForlawDetContent", params)

            If db.HasError Then Throw db.ErrorException
            Return Scalar

        End Function



#Region "Utility"


        Private Shared Function GetLawDetailsOnGrid(ByVal reader As IDataReader) As LawDetailsOnGrid

            If reader Is Nothing Then Return Nothing

            Dim LawDetailsOnGrid As New LawDetailsOnGrid
            LawDetailsOnGrid.lawID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawID")
            LawDetailsOnGrid.lawDetID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawDetID")
            LawDetailsOnGrid.lawTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawTitle")
            LawDetailsOnGrid.lawDetTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawDetTitle")

            Return LawDetailsOnGrid

        End Function

#End Region



    End Class


End Namespace
