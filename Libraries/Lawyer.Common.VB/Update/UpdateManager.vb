Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting

Namespace Update

    Public Class UpdateManager

        Public Shared Function GetNewVersionFiles(ByVal curVersion As Int32) As Byte()

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_version", curVersion)

            Dim content As Byte()

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_settingsSelByName", params)

            If db.HasError Then Throw New Exception

            If reader.Read Then

                content = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "updContent")

            End If

            reader.Close()

            Return content

        End Function

        Public Shared Function GetCurrentVersion(ByVal versionType As Char) As Integer

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_updDescription", versionType)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim version As String = db.GetScalarFromProcedure("stpDad_updateSelLastVersion", params)

            If db.HasError Then Throw db.ErrorException

            If version = String.Empty Then
                Return Lawyer.Common.Default.DefaultValue.DefaultDatabaseVI

            Else
                Return Convert.ToInt32(version.Replace(".", ""))
            End If


            Return version

        End Function

    End Class


End Namespace

