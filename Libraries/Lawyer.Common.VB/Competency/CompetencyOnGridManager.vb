Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities
Imports System.Windows.Forms


Namespace Competencys

    Public Class CompetencyOnGridManager


        Public Shared Function GetToolssalahiatSelByTsStateForGird_Like_DataTable(ByVal tsState As String, ByVal tbType As Integer) As DataTable

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_tsState", General.DbReplace(tsState))
            params(1) = New MySqlParameter("_tbType", General.DbReplace(tbType))


            Dim Dt As DataTable = db.GetDataTableFromProcedure("stpDad_ToolssalahiatSelByTsStateForGird_Like", params)

            If db.HasError Then Throw db.ErrorException

            'Dim CompetencyCollection As New CompetencyCollection
            'While reader.Read
            '    Dim Competency As Competency = GetCompetency(reader)
            '    CompetencyCollection.Add(Competency)
            'End While
            'reader.Close()

            Return Dt

        End Function

        'stpDad_ToolssalahiatSelBytsNameAndtsDescription_Full`(_tsNametsDescription varchar(45))

        Public Shared Function GetCompetencys_FullLike_DataTable(ByVal tsNametsDescription As String, ByVal tsType As Integer) As DataTable

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_tsType", General.DbReplace(tsType))
            params(1) = New MySqlParameter("_tsNametsDescription", General.DbReplace(tsNametsDescription))

            Dim Dt As DataTable = db.GetDataTableFromProcedure("stpDad_ToolssalahiatSelBytsNameAndtsDescription_Full", params)

            If db.HasError Then Throw db.ErrorException

            'Dim CompetencyCollection As New CompetencyCollection
            'While reader.Read
            '    Dim Competency As Competency = GetCompetency(reader)
            '    CompetencyCollection.Add(Competency)
            'End While
            'reader.Close()

            Return Dt

        End Function



        Public Shared Function GetToolssalahiatSelByTsStateForGird_Like(ByVal tsState As String) As CompetencyOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tsState", General.DbReplace(tsState))


            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolssalahiatSelByTsStateForGird_Like", params)

            If db.HasError Then Throw db.ErrorException

            Dim CompetencyOnGridCollection As New CompetencyOnGridCollection
            While reader.Read
                Dim CompetencyOnGrid As CompetencyOnGrid = GetCompetency(reader)
                CompetencyOnGridCollection.Add(CompetencyOnGrid)
            End While
            reader.Close()

            Return CompetencyOnGridCollection

        End Function

        Public Shared Function GettsStateCollection(ByVal tsState As String) As AutoCompleteStringCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tsState", General.DbReplace(tsState))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolssalahiatSelByTsStateForAutoComplate", params)

            If db.HasError Then Throw db.ErrorException

            Dim AutoCompleteStringCollection As New AutoCompleteStringCollection
            While reader.Read
                Dim AutoCompleteString As String = GetAutoCompleteString(reader)
                AutoCompleteStringCollection.Add(AutoCompleteString)
            End While
            reader.Close()

            Return AutoCompleteStringCollection

        End Function

        Public Shared Function GettsStateCollectiontsProvince(ByVal tsProvince As String) As AutoCompleteStringCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tsProvince", General.DbReplace(tsProvince))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolssalahiatSelByTsProvinceForAutoComplate", params)

            If db.HasError Then Throw db.ErrorException

            Dim AutoCompleteStringCollection As New AutoCompleteStringCollection
            While reader.Read
                Dim AutoCompleteString As String = GetAutoCompleteStringtsProvince(reader)
                AutoCompleteStringCollection.Add(AutoCompleteString)
            End While
            reader.Close()

            Return AutoCompleteStringCollection

        End Function

        Public Shared Function GettsStateCollectiontsName(ByVal tsName As String) As AutoCompleteStringCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_tsName", General.DbReplace(tsName))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolssalahiatSelByTsNameForAutoComplate", params)

            If db.HasError Then Throw db.ErrorException

            Dim AutoCompleteStringCollection As New AutoCompleteStringCollection
            While reader.Read
                Dim AutoCompleteString As String = GetAutoCompleteStringtsName(reader)
                AutoCompleteStringCollection.Add(AutoCompleteString)
            End While
            reader.Close()

            Return AutoCompleteStringCollection

        End Function

        Public Shared Function GetsToolssalahiatbranchesSelByTsidAndTsbType(ByVal tsid As String, ByVal tsbType As Integer) As CompetencyOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_tsid", General.DbReplace(tsid))
            params(1) = New MySqlParameter("_tsbType", General.DbReplace(tsbType))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolssalahiatbranchesSelByTsidAndTsbType", params)

            If db.HasError Then Throw db.ErrorException

            Dim CompetencyOnGridCollection As New CompetencyOnGridCollection
            While reader.Read
                Dim CompetencyOnGrid As CompetencyOnGrid = GetCompetencyBranches(reader)
                CompetencyOnGridCollection.Add(CompetencyOnGrid)
            End While
            reader.Close()

            Return CompetencyOnGridCollection

        End Function



#Region "Utility"

        Private Shared Function GetCompetency(ByVal reader As IDataReader) As CompetencyOnGrid

            If reader Is Nothing Then Return Nothing

            Dim CompetencyOnGrid As New CompetencyOnGrid

            CompetencyOnGrid.tsid = DbAccessLayer.SqlDataHelper.GetGuid(reader, "tsid")
            CompetencyOnGrid.tsState = DbAccessLayer.SqlDataHelper.GetString(reader, "tsState")
            CompetencyOnGrid.tsProvince = DbAccessLayer.SqlDataHelper.GetString(reader, "tsProvince")
            CompetencyOnGrid.tsName = DbAccessLayer.SqlDataHelper.GetString(reader, "tsName")
            CompetencyOnGrid.tsDescription = DbAccessLayer.SqlDataHelper.GetString(reader, "tsDescription")

            CompetencyOnGrid.tsbID = DbAccessLayer.SqlDataHelper.GetGuid(reader, "tsbID")
            CompetencyOnGrid.tsbName = DbAccessLayer.SqlDataHelper.GetString(reader, "tsbName")

            Return CompetencyOnGrid

        End Function

        Private Shared Function GetCompetencyBranches(ByVal reader As IDataReader) As CompetencyOnGrid

            If reader Is Nothing Then Return Nothing

            Dim CompetencyOnGrid As New CompetencyOnGrid

            'CompetencyOnGrid.tsid = DbAccessLayer.SqlDataHelper.GetGuid(reader, "tsid")
            'CompetencyOnGrid.tsState = DbAccessLayer.SqlDataHelper.GetString(reader, "tsState")
            'CompetencyOnGrid.tsProvince = DbAccessLayer.SqlDataHelper.GetString(reader, "tsProvince")
            'CompetencyOnGrid.tsName = DbAccessLayer.SqlDataHelper.GetString(reader, "tsName")
            'CompetencyOnGrid.tsDescription = DbAccessLayer.SqlDataHelper.GetString(reader, "tsDescription")

            CompetencyOnGrid.tsbID = DbAccessLayer.SqlDataHelper.GetGuid(reader, "tsbID")
            Dim type As Enums.tsbType = DbAccessLayer.SqlDataHelper.GetInt16(reader, "tsbType").ToString()
            CompetencyOnGrid.tsbName = type.ToString() + " : " + DbAccessLayer.SqlDataHelper.GetString(reader, "tsbName")
            'If type = Enums.tsbType.بازپرسی OrElse type = Enums.tsbType.دادیاری Then
            '    CompetencyOnGrid.tsbName = type.ToString() + " - " + DbAccessLayer.SqlDataHelper.GetString(reader, "tsbName")

            'Else
            'CompetencyOnGrid.tsbName = DbAccessLayer.SqlDataHelper.GetString(reader, "tsbName")

            'End If

            Return CompetencyOnGrid

        End Function

        Private Shared Function GetAutoCompleteString(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim tsState As String
            tsState = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsState")

            Return tsState

        End Function

        Private Shared Function GetAutoCompleteStringtsProvince(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim tsState As String
            tsState = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsProvince")

            Return tsState

        End Function

        Private Shared Function GetAutoCompleteStringtsName(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim tsState As String
            tsState = DbAccessLayer.MySqlDataHelper.GetString(reader, "tsName")

            Return tsState

        End Function

#End Region


    End Class


End Namespace
