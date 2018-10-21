Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting

Namespace FileParties
    Public Class FilePartiesManager

#Region "Methods"

        Public Shared Function AddParties(ByVal parameter As Dictionary(Of String, String()), ByVal fileCaseID As String, ByVal fileID As String, ByVal roleId As Integer, ByVal custPriority As ContactInfo.Enums.custPriority) As Integer

            Dim params(6) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            For Each Item As String In parameter.Keys

                params(0) = New MySqlParameter("_contactInfoID", Item)
                params(1) = New MySqlParameter("_fileCaseID", fileCaseID)
                params(2) = New MySqlParameter("_fileCaseRole", roleId)
                params(3) = New MySqlParameter("_fileID", fileID)
                params(4) = New MySqlParameter("_filePartyID", Guid.NewGuid())
                params(5) = New MySqlParameter("_custPriority", IIf(custPriority = ContactInfo.Enums.custPriority.NoP, DBNull.Value, custPriority))
                params(6) = New MySqlParameter("_financeAccess", CBool(parameter.Item(Item)(1)))

                db.ExecuteProcedure("stpDad_filepartiesIns", params)

                If db.HasError Then Throw db.ErrorException

            Next

        End Function


        Public Shared Sub EditFinanceAccess(ByVal financeAccess As String, ByVal fileCaseID As String, ByVal roleId As String)

            Dim params(2) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            params(0) = New MySqlParameter("_financeAccess", financeAccess)
            params(1) = New MySqlParameter("_fileCaseID", fileCaseID)
            params(2) = New MySqlParameter("_fileCaseRole", roleId)

            db.ExecuteProcedure("stpDad_filepartiesUpdfinanceAccess", params)

            If db.HasError Then Throw db.ErrorException


        End Sub

        Public Shared Function AddfileParties(ByVal parameter As FileParties, ByVal custPriority As ContactInfo.Enums.custPriority) As Integer

            Dim params(6) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            params(0) = New MySqlParameter("_contactInfoID", parameter.contactInfoID)
            params(1) = New MySqlParameter("_fileCaseID", parameter.fileCaseID)
            params(2) = New MySqlParameter("_fileCaseRole", parameter.fileCaseRole)
            params(3) = New MySqlParameter("_fileID", parameter.fileID)
            params(4) = New MySqlParameter("_filePartyID", Guid.NewGuid())
            params(5) = New MySqlParameter("_custPriority", IIf(custPriority = ContactInfo.Enums.custPriority.NoP, DBNull.Value, custPriority))
            params(6) = New MySqlParameter("_financeAccess", parameter.financeAccess)


            db.ExecuteProcedure("stpDad_filepartiesIns", params)

            If db.HasError Then Throw db.ErrorException

        End Function

        Public Shared Function GetPartiesByRoleID(ByVal fileCaseID As String, ByVal roleId As Integer) As FilePartiesBaseInfoCollection

            Dim params(1) As MySqlParameter
            Dim parties As New FilePartiesBaseInfoCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)
            params(1) = New MySqlParameter("_fileCaseRole", roleId)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filepartiesSelByRoleID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                parties.Add(GetFilePartiesBaseInfoFromReader2(reader))

            End While

            Return parties


        End Function

        Public Shared Function GetPartiesByFileCaseID(ByVal fileCaseID As String) As FilePartiesBaseInfoCollection

            Dim list As New FilePartiesBaseInfoCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filepartiesSelByFileCaseID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim f As FilePartiesBaseInfo = GetFilePartiesBaseInfoFromReader(reader)

                list.Add(f)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetPartiesAccessByFileCaseID(ByVal fileCaseID As String) As FilePartiesAccessCollection

            Dim list As New FilePartiesAccessCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filepartiesSelByFileCaseID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetFilePartiesAccessBaseInfoFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function


        Public Shared Function DelPartiesByFileCaseID(ByVal fileCaseID As String) As Integer

            Dim params(0) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            db.ExecuteProcedure("stpDad_filepartiesDelByFileCaseID", params)

            If db.HasError Then Return False

            Return True


        End Function

        Public Shared Function GetPartiesByFileCaseOwnerUsers(ByVal fileCaseID As String) As FilePartiesBaseInfoCollection

            Dim list As New FilePartiesBaseInfoCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filepartiesSelByfileCaseOwnerRole", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim f As FilePartiesBaseInfo = GetFilePartiesBaseInfoFromReader2(reader)

                list.Add(f)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetPartiesByFileCaseOwnerUsersExcept(ByVal fileCaseID As String, ByVal custId As String) As FilePartiesBaseInfoCollection

            Dim list As New FilePartiesBaseInfoCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            params(1) = New MySqlParameter("_custID", custId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filepartiesSelByfileCaseOwnerRoleExcept", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim f As FilePartiesBaseInfo = GetFilePartiesBaseInfoFromReader2(reader)

                list.Add(f)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetAllPartiesByFileCase(ByVal fileCaseID As String) As FilePartiesCollection

            Dim list As New FilePartiesCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filepartiesSelAllByFilecase", params)

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                list.Add(GetFilePartiesFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function UserHasPermission(ByVal fileCaseID As String, ByVal userId As String) As Boolean

            Dim list As New FilePartiesCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            params(1) = New MySqlParameter("_contactInfoID", userId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_filepartiesUtiHasPermission", params))

            If db.HasError Then Throw db.ErrorException

            If result > 0 Then Return True

            Return False


        End Function

        Public Shared Function UserHasFinanceAccess(ByVal fileCaseID As String, ByVal userId As String, ByVal role As Enums.FileCaseRole) As Boolean

            Dim list As New FilePartiesCollection

            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            params(1) = New MySqlParameter("_contactInfoID", userId)

            params(2) = New MySqlParameter("_fileCaseRole", role)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_filepartiesUtiHasAccess", params))

            If db.HasError Then Throw db.ErrorException

            If result > 0 Then Return True

            Return False


        End Function


        Public Shared Function IsExitContactID(ByVal userId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_contactInfoID", userId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_filepartiesIsExistContactId", params))

            If db.HasError Then Throw db.ErrorException

            If result > 0 Then Return True

            Return False


        End Function

#End Region

#Region "Utility"

        Private Shared Function GetFilePartiesBaseInfoFromReader(ByVal reader As IDataReader) As FilePartiesBaseInfo

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FilePartiesBaseInfo

            parameter.contactInfoID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "contactInfoID").ToString()

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.fileCaseRole = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "fileCaseRole")

            Return parameter

        End Function

        Private Shared Function GetFilePartiesAccessBaseInfoFromReader(ByVal reader As IDataReader) As FilePartiesAccess

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FilePartiesAccess

            parameter.contactInfoID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "contactInfoID").ToString()

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.fileCaseRole = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "fileCaseRole")

            parameter.financeAccess = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "financeAccess")

            Return parameter

        End Function


        ''' <summary>
        ''' بدون Role
        ''' </summary>
        ''' <param name="reader"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetFilePartiesBaseInfoFromReader2(ByVal reader As IDataReader) As FilePartiesBaseInfo

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FilePartiesBaseInfo

            parameter.contactInfoID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "contactInfoID").ToString()

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            Return parameter

        End Function

        Private Shared Function GetFilePartiesFromReader(ByVal reader As IDataReader) As FileParties

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FileParties

            parameter.contactInfoID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "contactInfoID").ToString()

            parameter.fileCaseID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID").ToString()

            parameter.fileCaseRole = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "fileCaseRole")

            parameter.fileID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString()

            parameter.filePartyID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "filePartyID").ToString()

            parameter.financeAccess = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "financeAccess")

            Return parameter

        End Function

#End Region

    End Class
End Namespace


