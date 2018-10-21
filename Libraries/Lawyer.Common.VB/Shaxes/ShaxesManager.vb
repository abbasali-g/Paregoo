Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB.ContactInfo

Namespace Shaxes

    Public Class ShaxesManager

        Public Shared Function SetDiehOfYear(ByVal year As Int32, ByVal yearValue As Double) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_bmiYear", year)
            params(1) = New MySqlParameter("_bmiValue", yearValue)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_shaxesSetDieh", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function SetMonthShaxes(ByVal year As Int32, ByVal monthNumber As Integer, ByVal monthValue As Double, ByVal yearMean As Double) As Boolean

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_year", year)
            params(1) = New MySqlParameter("_m", "m" + monthNumber.ToString())
            params(2) = New MySqlParameter("_mv", monthValue)
            params(3) = New MySqlParameter("_mean", yearMean)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_shaxesSetShaxesMonth", params)

            If db.HasError Then Return False

            Return True

        End Function


    End Class

End Namespace
