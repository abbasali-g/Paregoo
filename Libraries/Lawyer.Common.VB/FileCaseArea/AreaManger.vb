Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting

Namespace FileCaseArea
    Public Class AreaManger

#Region "Methods"

        Public Shared Function GetFileChildsByParentID(ByVal parentID As String) As AreaReviewCollection

            Dim params(0) As MySqlParameter

            Dim lists As New AreaReviewCollection

            params(0) = New MySqlParameter("_fileCaseAreaChilds", IIf(parentID = String.Empty, DBNull.Value, parentID))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filecaseareaSelByParentID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim a As AreaReview = GetAreaReviewFromReader(reader)

                lists.Add(a)

            End While

            reader.Close()

            Return lists

        End Function

        Public Shared Function AddArea(ByVal parameter As Area) As String

            Dim params(4) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseAreaName", parameter.fileCaseAreaName)
            params(1) = New MySqlParameter("_fileCaseAreaChilds", IIf(parameter.fileCaseAreaChilds = String.Empty, DBNull.Value, parameter.fileCaseAreaChilds))
            params(2) = New MySqlParameter("_fileCaseAreaAddress", parameter.fileCaseAreaAddress)
            params(3) = New MySqlParameter("_fileCaseAreaTel", parameter.fileCaseAreaTel)
            parameter.fileCaseAreaID = Guid.NewGuid().ToString()
            params(4) = New MySqlParameter("_fileCaseAreaID", parameter.fileCaseAreaID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filecaseareaIns", params)

            If db.HasError Then Return String.Empty

            Return parameter.fileCaseAreaID

        End Function

        Public Shared Function GetAreaNameByID(ByVal filecaseAreaId As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseAreaID", filecaseAreaId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = CStr(db.GetScalarFromProcedure("stpDad_filecaseareaSelNameByID", params))

            If db.HasError Then Throw New Exception

            Return result

        End Function


        Public Shared Function GetFileCaseAreaById(ByVal Id As String) As Competencys.Competency


            Dim params(0) As MySqlParameter

            Dim lists As New Competencys.Competency

            params(0) = New MySqlParameter("_tsid", Id)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolssalahiatSelAllById", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                lists = GetAreaFromReader(reader)

            End If

            reader.Close()

            Return lists

        End Function

        Public Shared Function GetFileCaseAreaById2(ByVal Id As String) As Competencys.CompetencyBranch


            Dim params(0) As MySqlParameter

            Dim lists As New Competencys.CompetencyBranch

            params(0) = New MySqlParameter("_tsbID", Id)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolssalahiatbranchesSelAllById", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                lists = GetAreaBranchFromReader(reader)

            End If

            reader.Close()

            Return lists

        End Function


        Public Shared Function GetAllRecords() As Competencys.CompetencyCollection


            Dim lists As New Competencys.CompetencyCollection


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolssalahiatSelAllRecords")

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                lists.Add(GetAreaFromReader(reader))

            End While

            reader.Close()

            Return lists

        End Function



        Public Shared Function GetAllRecords1() As Competencys.CompetencyBranchCollection


            Dim lists As New Competencys.CompetencyBranchCollection


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolssalahiatbranchesSelAllRecords")

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                lists.Add(GetAreaBranchFromReader(reader))

            End While

            reader.Close()

            Return lists

        End Function


        Public Shared Function GetRecordCount() As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim count As Integer = db.GetScalarFromProcedure("stpDad_filecaseareaSelCount")

            If db.HasError Then Throw db.ErrorException

            Return count

        End Function

        Public Shared Function GetRecordCount1() As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim count As Integer = db.GetScalarFromProcedure("stpDad_toolssalahiatbranchesSelCount")

            If db.HasError Then Throw db.ErrorException

            Return count

        End Function

        Public Shared Function GetSalahiatRecordCount() As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim count As Integer = db.GetScalarFromProcedure("stpDad_toolssalahiatSelCount")

            If db.HasError Then Throw db.ErrorException

            Return count

        End Function



#End Region

#Region "Utility"

        Private Shared Function GetAreaReviewFromReader(ByVal reader As IDataReader) As AreaReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New AreaReview

            parameter.fileCaseAreaID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseAreaID").ToString()

            parameter.fileCaseAreaName = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseAreaName")

            Return parameter

        End Function


        Private Shared Function GetAreaFromReader(ByVal reader As IDataReader) As Competencys.Competency

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Competencys.Competency

            parameter.tsid = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tsid")
            parameter.tsState = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsState")
            parameter.tsProvince = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsProvince")
            parameter.tsName = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsName")
            parameter.tsType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "tsType") 'in db tiny int to smallint >> int16
            parameter.tsHokmType = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsHokmType")
            parameter.tsMapField = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsMapField")
            parameter.tsDescription = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsDescription")

            Return parameter

        End Function

        Private Shared Function GetAreaBranchFromReader(ByVal reader As IDataReader) As Competencys.CompetencyBranch

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Competencys.CompetencyBranch

            parameter.tsid = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tsid")
            parameter.tsbID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tsbID")
            parameter.tsbName = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsbName")
            parameter.tsbType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "tsbType")

            Return parameter

        End Function
#End Region
    End Class
End Namespace

