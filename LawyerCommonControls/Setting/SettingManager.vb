Imports LawyerCommonControls.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities

Namespace Setting
    Public Class SettingManager


#Region "LReview"

#Region "Methods"

        Public Shared Function GetSettingsByName(ByVal settingName As String) As SettingCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_settingName", settingName)

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_settingsSelByName", params)

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                Dim s As Setting = GetSettingFromReader(reader)

                list.Add(s)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetFinanceTypeList() As SettingCollection

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_settingsSelFinanceTypeList")

            If db.HasError Then Return Nothing

            While reader.Read

                Dim s As Setting = GetSettingFromReader2(reader)

                list.Add(s)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function AddSetting(ByVal parameter As SettingComplete) As Boolean

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_settingGroupID", parameter.settingGroupID)

            params(1) = New MySqlParameter("_settingID", parameter.settingID)

            params(2) = New MySqlParameter("_settingName", parameter.settingName)

            params(3) = New MySqlParameter("_settingValue", IIf(parameter.settingValue = String.Empty, DBNull.Value, parameter.settingValue))

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_SettingIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function InsertToCompetencysEnumsTsType(ByVal Parent As String, ByVal settingName As String) As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            'IIf(String.IsNullOrEmpty(job.JobCatDesc), DBNull.Value, job.JobCatDesc))
            params(0) = New MySqlParameter("_Parent", General.DbReplace(Parent))
            params(1) = New MySqlParameter("_settingName", General.DbReplace(settingName))


            Dim result As Integer = db.GetScalarFromProcedure("stpDad_settingsInsToCompetencysEnumsTsType", params)

            If db.HasError Then Throw db.ErrorException
            Return result

        End Function

        Public Shared Function GetSettingsByGroupId(ByVal GroupId As String) As SettingCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_settingGroupID", GroupId)

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_settingsSelBankBranches", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim s As Setting = GetSettingFromReader2(reader)

                list.Add(s)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function DelSettingByID(ByVal SettingID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_settingID", SettingID)

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_settingsDelByID", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function DelSettingByBranchID(ByVal SettingID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_settingID", SettingID)

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_settingsDelBranch", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function DelSettingByBankID(ByVal SettingID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_settingID", SettingID)

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_settingsDelBank", params)

            If db.HasError Then Return False

            Return True

        End Function



#End Region

#Region "Utility"

        Private Shared Function GetSettingFromReader(ByVal reader As IDataReader) As Setting

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Setting

            parameter.settingName = DbAccessLayer.MySqlDataHelper.GetString(reader, "settingName")

            parameter.settingValue = DbAccessLayer.MySqlDataHelper.GetString(reader, "settingValue")

            Return parameter

        End Function

        Private Shared Function GetSettingFromReader2(ByVal reader As IDataReader) As Setting

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Setting

            parameter.settingName = DbAccessLayer.MySqlDataHelper.GetString(reader, "settingName")

            parameter.settingValue = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "settingID").ToString

            Return parameter

        End Function

#End Region

#End Region

#Region "Methods"



        Public Shared Function GetBankList() As SettingCollection

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_settingsSelBankList")

            If db.HasError Then Return Nothing

            While reader.Read

                Dim s As Setting = GetSettingFromReader2(reader)

                list.Add(s)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetIDBySettingName(ByVal settingName As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_settingName", settingName)

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("stpDad_settingsSelIDByName", params).ToString()

            If db.HasError Then Return String.Empty

            Return result

        End Function

        Public Shared Function GetNameBySettingID(ByVal ID As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_settingID", ID)

            Dim list As New SettingCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("stpDad_settingsSelNameByID", params).ToString()

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function




#End Region




    End Class
End Namespace

