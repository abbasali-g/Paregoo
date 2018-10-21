Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports NwdSolutions.Web.GeneralUtilities


Namespace Competencys

    Public Class CompetencyBranchManager


        Public Shared Function GetCompetencyBranchByLibID(ByVal tsid As Guid) As CompetencyBranchCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tsid", tsid)


            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolssalahiatbranchesSelByTsid", params)

            If db.HasError Then Throw db.ErrorException

            Dim CompetencyBranchCollection As New CompetencyBranchCollection
            While reader.Read
                'reader.Read()
                Dim CompetencyBranch As CompetencyBranch = GetCompetencyBranch(reader)
                CompetencyBranchCollection.Add(CompetencyBranch)
            End While
            reader.Close()

            Return CompetencyBranchCollection

        End Function

        Public Shared Function InsertToolssalahiatbranchesIns(ByVal CompetencyBranch As CompetencyBranch) As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(3) As MySqlParameter
            'IIf(String.IsNullOrEmpty(job.JobCatDesc), DBNull.Value, job.JobCatDesc))

            params(0) = New MySqlParameter("_tsbID", CompetencyBranch.tsbID)
            params(1) = New MySqlParameter("_tsid", CompetencyBranch.tsid)
            params(2) = New MySqlParameter("_tsbType", General.DbReplace(CompetencyBranch.tsbType))
            params(3) = New MySqlParameter("_tsbName", General.DbReplace(CompetencyBranch.tsbName))

            Dim ExecuteInt As Integer = db.ExecuteProcedure("stpDad_toolssalahiatbranchesIns", params)

            If db.HasError Then Throw db.ErrorException
            Return ExecuteInt

        End Function

        Public Shared Function DeleteCompetencyBranch(ByVal tsid As String) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tsid", tsid)

            Dim result As Integer = db.ExecuteProcedure("stpDad_ToolssalahiatbranchesDelByTsid", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function


#Region "Utility"

        Private Shared Function GetCompetencyBranch(ByVal reader As IDataReader) As CompetencyBranch

            If reader Is Nothing Then Return Nothing

            Dim CompetencyBranch As New CompetencyBranch

            CompetencyBranch.tsbID = DbAccessLayer.SqlDataHelper.GetGuid(reader, "tsbID")
            'CompetencyBranch.tsid = DbAccessLayer.SqlDataHelper.GetGuid(reader, "tsid")
            CompetencyBranch.tsbType = DbAccessLayer.SqlDataHelper.GetInt16(reader, "tsbType")
            CompetencyBranch.tsbName = DbAccessLayer.SqlDataHelper.GetString(reader, "tsbName")

            Return CompetencyBranch

        End Function

#End Region


    End Class



End Namespace
