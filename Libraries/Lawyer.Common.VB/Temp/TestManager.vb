Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Namespace Temp
    Public Class TestManager

        Public Shared Function GetName()
            Try
                Dim params(0) As MySqlParameter
                params(0) = New MySqlParameter("p", 2)

                Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

                Dim dt As DataTable = db.GetDataTableFromProcedure("st", params)
                If db.HasError Then Throw db.ErrorException
                Dim n As String = dt.Rows(0).Item("name").ToString
                Return n

            Catch ex As Exception

            End Try

        End Function

    End Class
End Namespace

