Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting

Namespace tempDocs

    Public Class tempDocsDetailManager

        Public Shared Function AddCategory(ByVal parameter As tempDocDetailReview, ByVal ParentId As String, ByVal pparentID As String) As Boolean

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_tpDID", parameter.tpDID)

            params(1) = New MySqlParameter("_tpCatName", parameter.tpCatName)

            params(2) = New MySqlParameter("_tpParentID", IIf(ParentId = String.Empty, DBNull.Value, ParentId))

            params(3) = New MySqlParameter("_tpPParentId", IIf(pparentID = String.Empty, DBNull.Value, pparentID))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsdetailsAddCat", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetTempDocsReviewsByParentID(ByVal ParentId As String) As tempDocDetailReviewCollection

            Dim list1 As New tempDocDetailReviewCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpParentID", IIf(ParentId = String.Empty, DBNull.Value, ParentId))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsdetailsSelReviewByPID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list1.Add(GettempDocDetailReviewFromReader(reader))

            End While

            reader.Close()

            Return list1

        End Function

        Public Shared Function GetTempDocsReviewsByParentID(ByVal ParentId As String, ByVal conString As String) As tempDocDetailReviewCollection

            Dim list1 As New tempDocDetailReviewCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpParentID", IIf(ParentId = String.Empty, DBNull.Value, ParentId))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(conString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsdetailsSelReviewByPID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list1.Add(GettempDocDetailReviewFromReader(reader))

            End While

            reader.Close()

            Return list1

        End Function

        Public Shared Function DelCategory(ByVal tpId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpDID", tpId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsdetailsDelCat", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function DelTitle(ByVal tpId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpDID", tpId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsdetailsDelTitle", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetTempDocsByParentID(ByVal ParentId As String) As TempDocsDetailCollection

            Dim list1 As New TempDocsDetailCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpParentID", IIf(ParentId = String.Empty, DBNull.Value, ParentId))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsdetailsSelAllByPID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list1.Add(GettempDocDetailFromReader(reader))

            End While

            reader.Close()

            Return list1

        End Function

        Public Shared Function GetTempDocsByParentID(ByVal ParentId As String, ByVal conString As String) As TempDocsDetailCollection

            Dim list1 As New TempDocsDetailCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpParentID", IIf(ParentId = String.Empty, DBNull.Value, ParentId))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(conString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsdetailsSelAllByPID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list1.Add(GettempDocDetailFromReader(reader))

            End While

            reader.Close()

            Return list1

        End Function

        Public Shared Function AddChile(ByVal parameter As TempDocsDetail) As Boolean

            Dim params(5) As MySqlParameter

            params(0) = New MySqlParameter("_tpDID", parameter.tpDID)

            params(1) = New MySqlParameter("_tpCatName", parameter.tpCatName)

            params(2) = New MySqlParameter("_tpParentID", IIf(parameter.tpParentID = String.Empty, DBNull.Value, parameter.tpParentID))

            params(3) = New MySqlParameter("_tpPParentId", IIf(parameter.tpPParentId = String.Empty, DBNull.Value, parameter.tpPParentId))

            params(4) = New MySqlParameter("_tpControlKey", IIf(parameter.tpControlKey = String.Empty, DBNull.Value, parameter.tpControlKey))

            params(5) = New MySqlParameter("_tpkeyContent", IIf(parameter.tpkeyContent = String.Empty, DBNull.Value, parameter.tpkeyContent))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsdetailsIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditContent(ByVal tpDID As String, ByVal tpkeyContent As String, ByVal connection As String)

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_tpDID", tpDID)

            params(1) = New MySqlParameter("_tpkeyContent", IIf(tpkeyContent = String.Empty, DBNull.Value, tpkeyContent))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(connection, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsdetailsUpd", params)

            If db.HasError Then Return False

            Return True

        End Function


        Public Shared Function EditContent(ByVal tpDID As String, ByVal tpkeyContent As String)

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_tpDID", tpDID)

            params(1) = New MySqlParameter("_tpkeyContent", IIf(tpkeyContent = String.Empty, DBNull.Value, tpkeyContent))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsdetailsUpd", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetContentByID(ByVal tpDID As String, ByVal connection As String) As String

            Dim content As String = String.Empty

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpDID", tpDID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(connection, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsdetailsSelContent", params)

            If db.HasError Then Throw New Exception

            If reader.Read Then

                content = DbAccessLayer.MySqlDataHelper.GetString(reader, "tpkeyContent")

            End If

            reader.Close()

            Return content

        End Function

        Public Shared Function GetContentByID(ByVal tpDID As String) As String

            Dim content As String = String.Empty

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpDID", tpDID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsdetailsSelContent", params)

            If db.HasError Then Throw New Exception

            If reader.Read Then

                content = DbAccessLayer.MySqlDataHelper.GetString(reader, "tpkeyContent")

            End If

            reader.Close()

            Return content

        End Function

#Region "Utility"

        Private Shared Function GettempDocDetailReviewFromReader(ByVal reader As IDataReader) As tempDocDetailReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New tempDocDetailReview

            parameter.tpCatName = DbAccessLayer.MySqlDataHelper.GetString(reader, "tpCatName")

            parameter.tpDID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpDID").ToString
           
            Return parameter

        End Function

        Private Shared Function GettempDocDetailFromReader(ByVal reader As IDataReader) As TempDocsDetail

            If reader Is Nothing Then Return Nothing

            Dim parameter As New TempDocsDetail

            parameter.tpCatName = DbAccessLayer.MySqlDataHelper.GetString(reader, "tpCatName")

            parameter.tpDID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpDID").ToString

            parameter.tpControlKey = DbAccessLayer.MySqlDataHelper.GetString(reader, "tpControlKey")

            parameter.tpkeyContent = DbAccessLayer.MySqlDataHelper.GetString(reader, "tpkeyContent")

            parameter.tpParentID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpParentID").ToString()

            parameter.tpPParentId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpPParentId").ToString

            Return parameter

        End Function
#End Region



    End Class
End Namespace

