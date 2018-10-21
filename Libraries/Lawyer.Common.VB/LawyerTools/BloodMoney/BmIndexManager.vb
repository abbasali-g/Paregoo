Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient


Namespace BloodMoneys


    Public Class BmIndexManager


        Public Shared Function GetBmiValue(ByVal bmiYear As Integer, ByVal bmiType As Integer) As Single

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_bmiYear", bmiYear) 'General.DbReplace(jobName)
            params(1) = New MySqlParameter("_bmiType", bmiType) 'General.DbReplace(jobName)

            Dim result As String = CSng(db.GetScalarFromProcedure("stpDad_ToolsbmindexSelValueByYearType", params))

            If db.HasError Then Throw db.ErrorException
            Return result

        End Function


        Public Shared Function GetBmiYear() As List(Of Integer)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_LawID", LawID)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolsbmindexSelYears", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim li As New List(Of Integer)
            While reader.Read
                'reader.Read()
                Dim i As Integer = GetYear(reader)
                li.Add(i)
            End While
            reader.Close()

            Return li

        End Function



#Region "Utility"



        Private Shared Function GetYear(ByVal reader As IDataReader) As Integer

            If reader Is Nothing Then Return Nothing

            Dim i As Integer
            i = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "bmiYear")

            Return i

        End Function





#End Region



    End Class


End Namespace
