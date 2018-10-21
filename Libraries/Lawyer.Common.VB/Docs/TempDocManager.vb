Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Common

Namespace Docs
    Public Class TempDocManager


#Region "Lreview"

#Region "Utility"


        Private Shared Function GetDocChildInfoFromReader(ByVal reader As IDataReader) As DocChildInfo

            If reader Is Nothing Then Return Nothing

            Dim doc As New DocChildInfo

            doc.docID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "docID").ToString()

            doc.docName = DbAccessLayer.MySqlDataHelper.GetString(reader, "docName")

            doc.docIsCat = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "docIsCat")

            doc.docImageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "docImageID").ToString()

            doc.docExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "docExtension")

            doc.imageExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageExtension")

            doc.imageUpdateDate = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageUpdateDate")

            Return doc

        End Function

#End Region

#Region "Methods"

        Public Shared Function GetChildDocsByParentID(ByVal parentID As String) As DocChildInfoCollection

            Dim params(0) As MySqlParameter

            Dim docs As New DocChildInfoCollection

            params(0) = New MySqlParameter("_pId", IIf(parentID = String.Empty, DBNull.Value, parentID))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsSelChildsByParentId", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim doc As DocChildInfo = GetDocChildInfoFromReader(reader)

                docs.Add(doc)

            End While

            reader.Close()

            Return docs

        End Function

        Public Shared Function AddTempDocs(ByVal doc As TempDocs) As Boolean

            Dim params(9) As MySqlParameter

            params(0) = New MySqlParameter("_docName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(doc.docName))
            params(1) = New MySqlParameter("_docIsCat", doc.docIsCat)
            params(2) = New MySqlParameter("_docChild", IIf(doc.docChild = String.Empty, DBNull.Value, doc.docChild))
            If doc.docIsCat = 0 Then doc.docFile = Common.FileManager.GetFileInBinaryFormat(doc.docFullPath, doc.docID)
            params(3) = New MySqlParameter("_docFile", IIf(doc.docIsCat = 1, DBNull.Value, doc.docFile))
            params(4) = New MySqlParameter("_docOwner", doc.docOwner)
            If doc.docContent = String.Empty Then
                params(5) = New MySqlParameter("_docContent", DBNull.Value)

            Else
                params(5) = New MySqlParameter("_docContent", NwdSolutions.Web.GeneralUtilities.General.DbReplace(doc.docContent))

            End If
            params(6) = New MySqlParameter("_docType", IIf(doc.docType = String.Empty, DBNull.Value, doc.docType))
            params(7) = New MySqlParameter("_docExtension", IIf(doc.docExtension = String.Empty, DBNull.Value, doc.docExtension))
            params(8) = New MySqlParameter("_docID", doc.docID)
            params(9) = New MySqlParameter("_docImageID", doc.docImageID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function IsExistDocName(ByVal docname As String, ByVal parentID As String, ByVal docExtension As String, ByVal docIsCat As Boolean) As String

            Dim params(3) As MySqlParameter

            If docname.Length > 45 Then docname = docname.Substring(0, 45)

            params(0) = New MySqlParameter("_docName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(docname))

            params(1) = New MySqlParameter("_docIsCat", docIsCat)

            params(2) = New MySqlParameter("_docExtension", IIf(docExtension = String.Empty, DBNull.Value, docExtension))

            params(3) = New MySqlParameter("_docChild", IIf(parentID = String.Empty, DBNull.Value, parentID))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("stpDad_tempdocsUtiIsExistDocName", params).ToString

            If db.HasError Then Throw db.ErrorException

            Return result


        End Function

        Public Shared Function GetParentinfoBychildId(ByVal childId As String) As DocParentInfo

            Dim params(0) As MySqlParameter

            Dim doc As New DocParentInfo

            params(0) = New MySqlParameter("_cid", childId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsSelParentInfo", params)

            If db.HasError Then Return Nothing

            While reader.Read

                doc = GetDocParentInfoFromReader(reader)

            End While

            reader.Close()

            Return doc

        End Function

        Public Shared Function EditDocLogo(ByVal docID As String, ByVal imageID As String) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_imageID", imageID)

            params(1) = New MySqlParameter("docID", docID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsUpdLogo", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetChildDocsByParentIDForTree(ByVal parentID As String) As DocParentInfoCollection

            Dim params(0) As MySqlParameter

            Dim docs As New DocParentInfoCollection

            params(0) = New MySqlParameter("_pId", IIf(parentID = String.Empty, DBNull.Value, parentID))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsSelChildsByParentIdForTree", params)

            If db.HasError Then Return Nothing

            While reader.Read

                docs.Add(GetDocParentInfoFromReader(reader))

            End While

            reader.Close()

            Return docs

        End Function

        Public Shared Function GetFilesByFulltextSearch(ByVal content As String) As DocChildInfoCollection

            Dim params(1) As MySqlParameter

            Dim docs As New DocChildInfoCollection


            If content.Length <= 3 Then
                params(0) = New MySqlParameter("_docContent", NwdSolutions.Web.GeneralUtilities.General.DbReplace(content))

                params(1) = New MySqlParameter("_IsFullText", 0)

            Else
                params(1) = New MySqlParameter("_IsFullText", 1)
                params(0) = New MySqlParameter("_docContent", NwdSolutions.Web.GeneralUtilities.General.DbReplace(content) & "*")


            End If


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsSearch", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim doc As DocChildInfo = GetDocChildInfoFromReader(reader)

                docs.Add(doc)

            End While

            reader.Close()

            Return docs

        End Function

        Public Shared Function WriteFile(ByVal ID As String, ByVal docExtension As String) As String

            Dim params(0) As MySqlParameter

            Dim content() As Byte = Nothing

            params(0) = New MySqlParameter("_docID", ID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsSeldocFileByID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                content = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "docFile")

            End While

            reader.Close()

            If content IsNot Nothing AndAlso content.Length > 0 Then

                Dim fileFullPath As String = FileManager.GetTempDocsFilesPath() & ID & docExtension

                FileManager.GetFileFromBinaryFormat(content, fileFullPath, False)

                Return fileFullPath

            End If

           

            Return Nothing


        End Function

#End Region

#End Region


        Public Shared Function GetCatDefaultImage(ByVal docID As Integer) As String

            Dim params(0) As MySqlParameter

            Dim docs As New TempDocsCollection

            Dim defaulImage As String = String.Empty

            params(0) = New MySqlParameter("_docID", docID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsSelDirDefaultImage", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                defaulImage = DbAccessLayer.SqlDataHelper.GetString(reader, "docFileName")

            End If

            reader.Close()

            Return defaulImage

        End Function

        Public Shared Function GetDocNameById(ByVal docID As String) As String

            Dim params(0) As MySqlParameter

            Dim docs As New DocParentInfoCollection

            params(0) = New MySqlParameter("_docID", docID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = CStr(db.GetScalarFromProcedure("stpDad_tempdocsSelNameByID", params))

            If db.HasError Then Return Nothing

            Return result

        End Function

        Public Shared Function EditDocName(ByVal docID As String, ByVal docName As String, ByVal parentId As String, ByVal docIsCat As Boolean) As Boolean

            If docName.Length > 45 Then docName = docName.Substring(0, 45)
            Dim params(3) As MySqlParameter
            params(0) = New MySqlParameter("dname", NwdSolutions.Web.GeneralUtilities.General.DbReplace(docName))
            params(1) = New MySqlParameter("docID", docID)
            params(2) = New MySqlParameter("_parentID", parentId)
            params(3) = New MySqlParameter("_docIsCat", docIsCat)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsUpdName", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function DeleteDocTemp(ByVal docID As String) As Integer

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_docID", docID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_tempdocsDelByDocID", params))

            If db.HasError Then Return 0

            Return result

        End Function

        Public Shared Function EditFile(ByVal docID As String, ByVal filePath As String, ByVal docContent As String) As Boolean

            Dim params(2) As MySqlParameter
            params(0) = New MySqlParameter("_docID", docID)
            params(1) = New MySqlParameter("_docFile", Common.FileManager.GetFileInBinaryFormat(filePath))

            If docContent = String.Empty Then

                params(2) = New MySqlParameter("_docContent", DBNull.Value)

            Else
                params(2) = New MySqlParameter("_docContent", NwdSolutions.Web.GeneralUtilities.General.DbReplace(docContent))

            End If

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsUpdFile", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditFile(ByVal docID As String, ByVal filePath As String, ByVal docContent As String, ByVal conString As String) As Boolean

            Dim params(2) As MySqlParameter
            params(0) = New MySqlParameter("_docID", docID)
            params(1) = New MySqlParameter("_docFile", Common.FileManager.GetFileInBinaryFormat(filePath))

            If docContent = String.Empty Then

                params(2) = New MySqlParameter("_docContent", DBNull.Value)

            Else
                params(2) = New MySqlParameter("_docContent", NwdSolutions.Web.GeneralUtilities.General.DbReplace(docContent))

            End If

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(conString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_tempdocsUpdFile", params)

            If db.HasError Then Return False

            Return True

        End Function

        'server=127.0.0.1;Port=9918;uid=root; pwd=@@%!mysqlnahani;database=nwdicdad2;




#Region "Utility"

    

        Private Shared Function GetDocParentInfoFromReader(ByVal reader As IDataReader) As DocParentInfo

            If reader Is Nothing Then Return Nothing

            Dim doc As New DocParentInfo

            doc.docType = DbAccessLayer.MySqlDataHelper.GetString(reader, "docName")

            doc.docID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "docID").ToString


            Return doc

        End Function


#End Region
    End Class


End Namespace

