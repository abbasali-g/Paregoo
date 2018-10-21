Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting

Namespace Laws


    Public Class LawOrgLinkManager



        Public Shared Function InsertLawOrgLink(ByVal LawOrgLink As LawOrgLink) As Boolean


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            'IIf(String.IsNullOrEmpty(job.JobCatDesc), DBNull.Value, job.JobCatDesc))
            params(0) = New MySqlParameter("_lawID", LawOrgLink.lawID)
            params(1) = New MySqlParameter("_lawOrgNameID", LawOrgLink.lawOrgNameID)

            Dim result As Integer = db.ExecuteProcedure("stpDad_LawOrgsIns", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function


        Public Shared Function DeleteLaworgs(ByVal lawID As Integer) As Boolean


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", lawID)

            Dim result As Integer = db.ExecuteProcedure("stpDad_LaworgsDel", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function



        Public Shared Function GetLawOrgLinkByLawId(ByVal LawId As Integer) As List(Of Integer)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_LawId", LawId)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_laworgsSelByLawId_ForName", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawOrgLinks As New List(Of Integer)
            While reader.Read
                Dim LawOrgLink As Integer = GetLawOrgNameIdFromReader(reader)
                LawOrgLinks.Add(LawOrgLink)
            End While
            reader.Close()

            Return LawOrgLinks

        End Function


#Region "Utility"

        Private Shared Function GetLawOrgNameIdFromReader(ByVal reader As IDataReader) As Integer

            If reader Is Nothing Then Return Nothing

            Dim lawOrgNameID As Integer = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawOrgNameID")

            Return lawOrgNameID

        End Function

#End Region



    End Class

End Namespace
