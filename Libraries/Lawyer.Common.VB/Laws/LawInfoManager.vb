Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports NwdSolutions.Web.GeneralUtilities

Namespace LawInfos


    Public Class LawInfoManager


        Public Shared Function GetLawInfo(ByVal LawId As Integer) As LawInfoCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("pLowId", LawId)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawSearchByID_Date", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawInfos As New LawInfoCollection
            While reader.Read
                Dim lawInfo As LawInfo = GetLawInfoFromReader(reader)
                LawInfos.Add(lawInfo)
            End While
            reader.Close()

            Return LawInfos

        End Function


        Public Shared Function GetLawravieInfo(ByVal LawId As Integer) As LawInfoCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_LawId", LawId)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawravieSelByLawId", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawInfos As New LawInfoCollection
            While reader.Read
                Dim lawInfo As LawInfo = GetLawInfoFromReader(reader)
                LawInfos.Add(lawInfo)
            End While
            reader.Close()

            Return LawInfos

        End Function




        Public Shared Function UpdateLawNote(ByVal LawNote As String, ByVal LawId As Integer) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pLawNote", General.DbReplace(LawNote))
            params(1) = New MySqlParameter("pLawId", LawId)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_LawsUpdLowNote", params))

            If db.HasError Then Return False
            Return result

        End Function



#Region "Utility"


        Private Shared Function GetLawInfoFromReader(ByVal reader As IDataReader) As LawInfo

            If reader Is Nothing Then Return Nothing

            Dim lawInfo As New LawInfo
            lawInfo.lawPassedDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawPassedDate")
            lawInfo.lawPublishedDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawPublishedDate")
            lawInfo.lawPublicationNumber = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawPublicationNumber")

            lawInfo.lawNote = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawNote")

            Dim _lawMansoukh As Short
            If IsDBNull(reader("lawMansoukh")) Then
                _lawMansoukh = 0
            ElseIf TypeOf reader("lawMansoukh") Is Long Then
                _lawMansoukh = CShort(reader("lawMansoukh"))
            Else
                _lawMansoukh = reader("lawMansoukh")
            End If

            lawInfo.lawMansoukh = _lawMansoukh ' DbAccessLayer.MySqlDataHelper.GetInt16(reader, "lawMansoukh")
            lawInfo.lawMansoukhDescription = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawMansoukhDescription")

            lawInfo.lawTypeName = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawTypeName")
            lawInfo.lawCatName = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawCatName")

            Return lawInfo


        End Function




#End Region











    End Class


End Namespace