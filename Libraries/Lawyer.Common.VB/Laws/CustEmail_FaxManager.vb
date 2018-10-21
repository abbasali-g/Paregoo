Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities


Namespace Laws

    Public Class CustEmail_FaxManager


        Public Shared Function GetCustEmails() As CustEmail_FaxCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("pTitle", title)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ContactinfoSelSysUserForEmails", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim CustEmails As New CustEmail_FaxCollection
            While reader.Read
                Dim CustEmail As CustEmail_Fax = GetCustEmailFromReader(reader)
                CustEmails.Add(CustEmail)
            End While
            reader.Close()

            Return CustEmails

        End Function


        Public Shared Function GetCustEmails(ByVal custFullName As String) As CustEmail_FaxCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_custFullName", General.DbReplace(custFullName))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ContactinfoSelSysUserForEmailsByName", params)

            If db.HasError Then Throw db.ErrorException

            Dim CustEmails As New CustEmail_FaxCollection
            While reader.Read
                Dim CustEmail As CustEmail_Fax = GetCustEmailFromReader(reader)
                CustEmails.Add(CustEmail)
            End While
            reader.Close()

            Return CustEmails

        End Function

        Public Shared Function GetCustEmailsByCustIDs(ByVal Where As String) As CustEmail_FaxCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_Where", Where)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ContactinfoSelForEmailsCustID", params)

            If db.HasError Then Throw db.ErrorException

            Dim CustEmails As New CustEmail_FaxCollection
            While reader.Read
                Dim CustEmail As CustEmail_Fax = GetCustEmailFromReader(reader)
                CustEmails.Add(CustEmail)
            End While
            reader.Close()

            Return CustEmails

        End Function


        Public Shared Function GetCustFaxs() As CustEmail_FaxCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("pTitle", title)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ContactinfoSelSysUserForFax", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim CustFaxs As New CustEmail_FaxCollection
            While reader.Read
                Dim CustFax As CustEmail_Fax = GetCustFaxFromReader(reader)
                CustFaxs.Add(CustFax)
            End While
            reader.Close()

            Return CustFaxs

        End Function


        Public Shared Function GetCustFaxs(ByVal FullName As String) As CustEmail_FaxCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_custFullName", General.DbReplace(FullName))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ContactinfoSelSysUserForFaxByName", params)

            If db.HasError Then Throw db.ErrorException

            Dim CustFaxs As New CustEmail_FaxCollection
            While reader.Read
                Dim CustFax As CustEmail_Fax = GetCustFaxFromReader(reader)
                CustFaxs.Add(CustFax)
            End While
            reader.Close()

            Return CustFaxs

        End Function

        Public Shared Function GetCustFaxsByCusIDs(ByVal Where As String) As CustEmail_FaxCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_Where", Where)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ContactinfoSelForFaxByCustID", params)

            If db.HasError Then Throw db.ErrorException

            Dim CustFaxs As New CustEmail_FaxCollection
            While reader.Read
                Dim CustFax As CustEmail_Fax = GetCustFaxFromReader(reader)
                CustFaxs.Add(CustFax)
            End While
            reader.Close()

            Return CustFaxs

        End Function


#Region "Utility"



        Private Shared Function GetCustEmailFromReader(ByVal reader As IDataReader) As CustEmail_Fax

            If reader Is Nothing Then Return Nothing

            Dim CustEmail As New CustEmail_Fax
            CustEmail.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID")
            CustEmail.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")
            CustEmail.custEmailOne = DbAccessLayer.MySqlDataHelper.GetString(reader, "custEmailOne")
            Return CustEmail

        End Function


        Private Shared Function GetCustFaxFromReader(ByVal reader As IDataReader) As CustEmail_Fax

            If reader Is Nothing Then Return Nothing

            Dim CustFax As New CustEmail_Fax
            CustFax.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID")
            CustFax.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")
            CustFax.custFax = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFax")

            Return CustFax

        End Function

#End Region



    End Class


End Namespace