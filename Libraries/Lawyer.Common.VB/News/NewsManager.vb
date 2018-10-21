Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting

Namespace News

    Public Class NewsManager

        Public Shared Function GetAllNews() As NewsCollection

            Dim list As New NewsCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_newsSelAll")

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetNewsFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function


        Private Shared Function GetNewsFromReader(ByVal reader As IDataReader) As news

            If reader Is Nothing Then Return Nothing

            Dim parameter As New news

            parameter.newsDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "newsDate")

            parameter.newsDescription = DbAccessLayer.MySqlDataHelper.GetString(reader, "newsDescription")

            parameter.newsId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "newsId").ToString()

            parameter.newsTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "newsTitle")

            Return parameter

        End Function

    End Class

End Namespace
