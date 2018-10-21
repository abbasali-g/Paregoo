Imports Lawyer.Common.VB.CommonSetting

Namespace Laws

    Public Class CustEmailManager


        Public Shared Function GetCustEmails() As CustEmailCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("pTitle", title)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ContactinfoSelSysUserForEmails", Nothing)

            If db.HasError Then Throw db.ErrorException


            Dim CustEmails As New CustEmailCollection

            While reader.Read
                Dim CustEmail As CustEmail = GetCustEmailFromReader(reader)
                CustEmails.Add(CustEmail)
            End While

            reader.Close()

            Return CustEmails

        End Function



#Region "Utility"



        Private Shared Function GetCustEmailFromReader(ByVal reader As IDataReader) As CustEmail

            If reader Is Nothing Then Return Nothing

            Dim CustEmail As New CustEmail

            CustEmail.custID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "custID")
            CustEmail.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")
            CustEmail.custEmailOne = DbAccessLayer.MySqlDataHelper.GetString(reader, "custEmailOne")
            CustEmail.custEmailTwo = DbAccessLayer.MySqlDataHelper.GetString(reader, "custEmailTwo")

            Return CustEmail

        End Function



#End Region






    End Class


End Namespace