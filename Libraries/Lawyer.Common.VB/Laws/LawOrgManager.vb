Imports Lawyer.Common.VB.CommonSetting

Namespace LawOrgs


    Public Class LawOrgManager


        Public Shared Function GetLawOrgsForDrp() As LawOrgCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("pTitle", title)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawOrgNameSelAll", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim LawOrgs As New LawOrgCollection
            While reader.Read
                Dim LawOrg As LawOrg = GetLawOrgFromReaderForDrp(reader)
                LawOrgs.Add(LawOrg)
            End While
            reader.Close()

            Return LawOrgs

        End Function



#Region "Utility"


        Private Shared Function GetLawOrgFromReaderForDrp(ByVal reader As IDataReader) As LawOrg

            If reader Is Nothing Then Return Nothing

            Dim LawOrg As New LawOrg
            LawOrg.lawOrgNameID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawOrgNameID")
            LawOrg.lawOrgName = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawOrgName")

            Return LawOrg

        End Function



#End Region



    End Class


End Namespace
