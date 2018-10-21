Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports NwdSolutions.Web.GeneralUtilities


Namespace Competencys

    Public Class CompetencyManager



        Public Shared Function GetCompetencyByLibID(ByVal tsid As Guid) As Competency

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tsid", tsid)


            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolssalahiatSelByTsid", params)

            If db.HasError Then Throw db.ErrorException

            'Dim Books As New BookCollection
            'While reader.Read
            reader.Read()
            Dim Competency As Competency = GetCompetency(reader)
            'Books.Add(Book)
            'End While
            reader.Close()

            Return Competency

        End Function

        Public Shared Function GetCompetencyByLibID(ByVal tsid As String) As Competency

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tsid", tsid)


            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolssalahiatSelByTsid", params)

            If db.HasError Then Throw db.ErrorException

            'Dim Books As New BookCollection
            'While reader.Read
            reader.Read()
            Dim Competency As Competency = GetCompetency(reader)
            'Books.Add(Book)
            'End While
            reader.Close()

            Return Competency

        End Function

        Public Shared Function GetToolsSalahiatBranchById(ByVal tsid As String) As CompetencyBranchReview

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tsbID", tsid)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolssalahiatbranchesSelBytsbID", params)

            If db.HasError Then Throw db.ErrorException

            reader.Read()

            Dim Competency As CompetencyBranchReview = GetCompetencyBranchReviewFromReader(reader)

            reader.Close()

            Return Competency

        End Function

        Public Shared Function InsertToolssalahiat(ByVal Competency As Competency) As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(7) As MySqlParameter
            'IIf(String.IsNullOrEmpty(job.JobCatDesc), DBNull.Value, job.JobCatDesc))

            params(0) = New MySqlParameter("_tsid", Competency.tsid)
            params(1) = New MySqlParameter("_tsState", General.DbReplace(Competency.tsState))
            params(2) = New MySqlParameter("_tsProvince", General.DbReplace(Competency.tsProvince))
            params(3) = New MySqlParameter("_tsName", General.DbReplace(Competency.tsName))
            params(4) = New MySqlParameter("_tsType", Competency.tsType)
            params(5) = New MySqlParameter("_tsHokmType", General.DbReplace(Competency.tsHokmType))
            params(6) = New MySqlParameter("_tsMapField", Competency.tsMapField) ' no DbReplace
            params(7) = New MySqlParameter("_tsDescription", General.DbReplace(Competency.tsDescription))


            Dim ExecuteInt As Integer = db.ExecuteProcedure("stpDad_ToolssalahiatIns", params)

            If db.HasError Then Throw db.ErrorException
            Return ExecuteInt

        End Function

        Public Shared Function UpdateToolssalahiat(ByVal Competency As Competency) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(7) As MySqlParameter
            'IIf(String.IsNullOrEmpty(job.JobCatDesc), DBNull.Value, job.JobCatDesc))

            params(0) = New MySqlParameter("_tsid", Competency.tsid)

            params(1) = New MySqlParameter("_tsState", General.DbReplace(Competency.tsState))
            params(2) = New MySqlParameter("_tsProvince", General.DbReplace(Competency.tsProvince))
            params(3) = New MySqlParameter("_tsName", General.DbReplace(Competency.tsName))
            params(4) = New MySqlParameter("_tsType", Competency.tsType)
            params(5) = New MySqlParameter("_tsHokmType", General.DbReplace(Competency.tsHokmType))
            params(6) = New MySqlParameter("_tsMapField", Competency.tsMapField) ' no DbReplace
            params(7) = New MySqlParameter("_tsDescription", General.DbReplace(Competency.tsDescription))

            Dim result As Integer = db.ExecuteProcedure("stpDad_ToolssalahiatUpd", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function

        Public Shared Function DeleteCompetency(ByVal tsid As Guid) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tsid", tsid)

            Dim rocount As Integer = CInt(db.ExecuteProcedure("stpDad_toolssalahiatDelByTsid", params))

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function


        Public Shared Function GetLawTypsForDrp() As CompetencyCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("pTitle", title)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolssalahiatSelFordrp_Case", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim CompetencyCollection As New CompetencyCollection
            While reader.Read
                Dim Competency As Competency = GetCompetencyForDrp(reader)
                CompetencyCollection.Add(Competency)
            End While
            reader.Close()

            Return CompetencyCollection

        End Function


        Public Shared Function GetCompetencysEnumsTsType() As Setting.SettingCollection

            Return Setting.SettingManager.GetSettingsByName("CompetencysEnumsTsType")

        End Function



#Region "Utility"


        Private Shared Function GetCompetency(ByVal reader As IDataReader) As Competency

            If reader Is Nothing Then Return Nothing

            Dim Competency As New Competency

            Competency.tsid = DbAccessLayer.SqlDataHelper.GetGuid(reader, "tsid")
            Competency.tsState = DbAccessLayer.SqlDataHelper.GetString(reader, "tsState")
            Competency.tsProvince = DbAccessLayer.SqlDataHelper.GetString(reader, "tsProvince")
            Competency.tsName = DbAccessLayer.SqlDataHelper.GetString(reader, "tsName")
            Competency.tsType = DbAccessLayer.SqlDataHelper.GetInt16(reader, "tsType") 'in db tiny int to smallint >> int16
            Competency.tsHokmType = DbAccessLayer.SqlDataHelper.GetString(reader, "tsHokmType")
            Competency.tsMapField = DbAccessLayer.SqlDataHelper.GetString(reader, "tsMapField")
            Competency.tsDescription = DbAccessLayer.SqlDataHelper.GetString(reader, "tsDescription")


            Return Competency

        End Function

        Private Shared Function GetCompetencyBranchReviewFromReader(ByVal reader As IDataReader) As CompetencyBranchReview

            If reader Is Nothing Then Return Nothing

            Dim Competency As New CompetencyBranchReview

            Competency.tsbName = DbAccessLayer.SqlDataHelper.GetString(reader, "tsbName")

            Competency.tsbType = DbAccessLayer.SqlDataHelper.GetInt16(reader, "tsbType")

            Return Competency

        End Function


        Private Shared Function GetCompetencyForDrp(ByVal reader As IDataReader) As Competency

            If reader Is Nothing Then Return Nothing

            Dim Competency As New Competency
            Competency.tsType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "tsType")

            'Select Case Competency.tsType

            '    Case 0
            '        Competency.tsTypeEnums = Enums.tsType.مجتمع
            '    Case 1
            '    Case 2
            '    Case 3
            '    Case 4
            '    Case 11
            '    Case Else

            'End Select

            Competency.tsTypeEnums = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsTypeCase") 'tsTypeCase >>> tsTypeEnums



            Return Competency

        End Function



#End Region



    End Class

End Namespace
