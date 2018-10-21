Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities
Imports Lawyer.Common.VB.CommonSetting

Namespace Laws


    Public Class LawFuManager

       
        Public Shared Function InsertLawFu(ByVal LawFu As LawFu) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(2) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", General.DbReplace(LawFu.lawID))
            params(1) = New MySqlParameter("_userID", General.DbReplace(LawFu.userID))
            params(2) = New MySqlParameter("_lawFULRTYe", General.DbReplace(LawFu.lawFULRTYe))

            Dim result As Integer = db.ExecuteProcedure("stpDad_LawFuIns", params)

            If db.HasError Then Return False
            Return True

        End Function


        Public Shared Function LawfuDel(ByVal lawID As Integer) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", lawID)

            Dim rocount As Integer = CInt(db.ExecuteProcedure("stpDad_LawfuDel", params))

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function



    End Class


End Namespace
