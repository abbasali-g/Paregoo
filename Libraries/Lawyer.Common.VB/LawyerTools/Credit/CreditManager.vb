Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities

Namespace Credits

    Public Class CreditManager


        Public Shared Function GetIndices(ByVal Year As Integer) As Index

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_Year", General.DbReplace(Year))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolsindicesSelByYear", params)

            If db.HasError Then Throw db.ErrorException

            Dim Index As Index = Nothing
            While reader.Read
                Index = GetIndex(reader)
            End While
            reader.Close()

            Return Index

        End Function


        'Public Shared Function GetLawByIDForEmail(ByVal LawID As String) As Law

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim params(0) As MySqlParameter
        '    params(0) = New MySqlParameter("_LawID", LawID)

        '    Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSelByLawIDForTandC", params)

        '    If db.HasError Then Throw db.ErrorException

        '    Dim Law As New Law
        '    'While reader.Read
        '    reader.Read()
        '    Law = GetLawFromReaderForEmail(reader)
        '    ' End While
        '    reader.Close()

        '    Return Law

        'End Function


        'stpDad_toolsindicesSelYears()

        Public Shared Function GetYears() As List(Of String)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_settingName", settingName)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_toolsindicesSelYears", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim list As New List(Of String)
            While reader.Read

                Dim str As String = GetYearFromReader(reader)
                list.Add(str)

            End While

            reader.Close()

            Return list

        End Function



#Region "Utility"


        Private Shared Function GetIndex(ByVal reader As IDataReader) As Index

            If reader Is Nothing Then Return Nothing

            Dim Index As New Index
            Index.indexID = DbAccessLayer.SqlDataHelper.GetInt(reader, "indexID")
            Index.m1 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m1")
            Index.m2 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m2")
            Index.m3 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m3")
            Index.m4 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m4")
            Index.m5 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m5")
            Index.m6 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m6")
            Index.m7 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m7")
            Index.m8 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m8")
            Index.m9 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m9")
            Index.m10 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m10")
            Index.m11 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m11")
            Index.m12 = DbAccessLayer.SqlDataHelper.GetReal(reader, "m12")
            Index.mean = DbAccessLayer.SqlDataHelper.GetReal(reader, "mean")

            Return Index

        End Function

        Private Shared Function GetYearFromReader(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim str As String
            str = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "year")

            Return str

        End Function


#End Region




    End Class



End Namespace
