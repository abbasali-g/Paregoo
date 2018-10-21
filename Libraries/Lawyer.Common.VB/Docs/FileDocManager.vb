Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Common
Imports NwdSolutions.Web.GeneralUtilities

Namespace Docs
    Public Class FileDocManager

#Region "Methods"

        Public Shared Function GetFileChildsByParentID(ByVal parentID As String) As FileChildInfoCollection

            Dim params(0) As MySqlParameter

            Dim docs As New FileChildInfoCollection

            params(0) = New MySqlParameter("_pId", IIf(parentID = String.Empty, DBNull.Value, parentID))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelChildsByParentID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim doc As FileChildInfo = GetFileChildInfoFromReader(reader)

                docs.Add(doc)

            End While

            reader.Close()

            Return docs

        End Function

        Public Shared Function SearchFiles(ByVal fileName As String, ByVal isArchive As Boolean) As FileChildInfoCollection

            Dim params(1) As MySqlParameter

            Dim docs As New FileChildInfoCollection

            params(0) = New MySqlParameter("_fName", General.DbReplace(fileName))

            params(1) = New MySqlParameter("_fileIsArchive", IIf(isArchive, 1, 0))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSearchFiles", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim doc As FileChildInfo = GetFileChildInfoFromReader(reader)

                docs.Add(doc)

            End While

            reader.Close()

            Return docs

        End Function

        Public Shared Function GetFileIdByTypeAndFilecaseID(ByVal type As Int16, ByVal filecaseId As String) As String

            Dim params(1) As MySqlParameter

            Dim Id As String = String.Empty

            params(0) = New MySqlParameter("_fileCaseID", filecaseId)

            params(1) = New MySqlParameter("_fileType", type)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelIdByType", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                Id = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString()

            End If

            reader.Close()

            Return Id

        End Function

        Public Shared Function GetFilesBySearch(ByVal partWhere As String, ByVal fileWhere As String, ByVal txtWhere As String, ByVal fileWhere2 As String, ByVal isFileArchive As Boolean) As FileChildInfoCollection

            Dim params(4) As MySqlParameter

            Dim docs As New FileChildInfoCollection

            params(0) = New MySqlParameter("partWhere", partWhere)

            params(1) = New MySqlParameter("fileWhere", fileWhere)

            params(2) = New MySqlParameter("txtWhere", txtWhere)

            params(3) = New MySqlParameter("fileWhere2", fileWhere2)

            params(4) = New MySqlParameter("_fileArchive", IIf(isFileArchive, "fileIsArchive=1", "fileIsArchive =0 or fileIsArchive is null"))


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSearch", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim doc As FileChildInfo = GetFileChildInfoFromReader(reader)

                docs.Add(doc)

            End While

            reader.Close()

            Return docs

        End Function

        Public Shared Function GetFilesBySimpleSearch(ByVal _fileArchive As String, ByVal _contactinfo As String, ByVal _filecase As String) As FileChildInfoCollection
            Dim params(2) As MySqlParameter

            Dim docs As New FileChildInfoCollection

            params(0) = New MySqlParameter("_filecase", _filecase)

            params(1) = New MySqlParameter("_contactinfo", _contactinfo)

            params(2) = New MySqlParameter("_fileArchive", _fileArchive)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSimpleSearch", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim doc As FileChildInfo = GetFileChildInfoFromReader(reader)

                docs.Add(doc)

            End While

            reader.Close()

            Return docs

        End Function






        Public Shared Function CreateFile(ByVal doc As Files) As Boolean

            Dim params(7) As MySqlParameter

            params(0) = New MySqlParameter("_fileImageID", doc.fileImageID)
            params(1) = New MySqlParameter("_fileChilds", IIf(doc.fileChilds = String.Empty, DBNull.Value, doc.fileChilds))
            params(2) = New MySqlParameter("_fileIsCat", doc.fileIsCat)
            params(3) = New MySqlParameter("_fName", General.DbReplace(doc.fileName))
            params(4) = New MySqlParameter("_fileType", doc.FileType)
            params(5) = New MySqlParameter("_fileID", doc.fileID)
            params(6) = New MySqlParameter("_fileCustID", IIf(doc.fileCustID = "0", DBNull.Value, doc.fileCustID))
            params(7) = New MySqlParameter("_fileCaseID", IIf(doc.fileCaseID = String.Empty, DBNull.Value, doc.fileCaseID))
            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function IsExistFileName(ByVal filename As String, ByVal parentID As String) As String


            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(filename))

            params(1) = New MySqlParameter("_fileChilds", IIf(parentID = String.Empty, DBNull.Value, parentID))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("stpDad_filesUtiIsExistFileName", params).ToString

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function GetFileNameByCustId(ByVal custId As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCustID", custId)

            Dim result As String = String.Empty

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDadfilesSelNameByCustId", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read() Then

                result = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileName")

            End If

            Return result

        End Function

        Public Shared Function UpdateFileName(ByVal fileID As String, ByVal fileName As String) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(fileName))

            params(1) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesUpdFileName", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function UpdateFileImage(ByVal fileID As String, ByVal fileImageID As String) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileImageID", fileImageID)

            params(1) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesUpdImage", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetParentinfoBychildId(ByVal childId As String) As FileParentInfo

            Dim params(0) As MySqlParameter

            Dim file As New FileParentInfo

            params(0) = New MySqlParameter("_fileID", childId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelParentInfo", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                file = GetFileParentInfoFromReader(reader)

            End If

            reader.Close()

            Return file

        End Function

        Public Shared Function GetFileLocker(ByVal childId As String) As ContactInfo.ContactInfoReview

            Dim params(0) As MySqlParameter

            Dim locker As ContactInfo.ContactInfoReview = Nothing

            params(0) = New MySqlParameter("_fileID", childId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelFileLocker", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                locker = GetFileLockerInfoFromReader(reader)

            End If

            reader.Close()

            Return locker

        End Function

        Public Shared Function GetFileNameByID(ByVal fileId As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("StpDad_filesSelNameByID", params).ToString()

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function GetFileCaseID(ByVal fileID As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("stpDad_filesSelfileCaseID", params).ToString

            If db.HasError Then Return Nothing

            Return result

        End Function

        Public Shared Function GetFileParentId(ByVal fileID As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("stpDad_filesSelParentID", params).ToString

            If db.HasError Then Return Nothing

            Return result

        End Function

        Public Shared Function IsFileLocked(ByVal fileID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_filesUtiIsFileLocked", params))

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function UpdateFileLocker(ByVal fileID As String, ByVal locker As String, ByVal ImageID As String, ByVal fileType As Integer) As Boolean

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_FileLocker", IIf(locker = String.Empty, DBNull.Value, locker))

            params(1) = New MySqlParameter("_fileID", fileID)

            params(2) = New MySqlParameter("_fileImageID", ImageID)

            params(3) = New MySqlParameter("_fileType", fileType)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesUpdLocker", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function UpdateFileArchive(ByVal fileID As String, ByVal isArchive As Boolean, ByVal imageID As String) As Boolean

            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("_fileIsArchive", isArchive)

            params(1) = New MySqlParameter("_fileID", fileID)

            params(2) = New MySqlParameter("_fileImageID", imageID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesUpdArchive", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditFile(ByVal docID As String, ByVal filePath As String, ByVal docContent As String) As Boolean

            Dim params(2) As MySqlParameter
            params(0) = New MySqlParameter("_fileDocID", docID)
            params(1) = New MySqlParameter("_fileDocBinary", Common.FileManager.GetFileInBinaryFormat(filePath))

            If docContent = String.Empty Then
                params(2) = New MySqlParameter("_fileDocContent", DBNull.Value)

            Else
                params(2) = New MySqlParameter("_fileDocContent", NwdSolutions.Web.GeneralUtilities.General.DbReplace(docContent))

            End If

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsUpdFile", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditFile(ByVal docID As String, ByVal filePath As String, ByVal docContent As String, ByVal conString As String) As Boolean

            Dim params(2) As MySqlParameter
            params(0) = New MySqlParameter("_fileDocID", docID)
            params(1) = New MySqlParameter("_fileDocBinary", Common.FileManager.GetFileInBinaryFormat(filePath))

            If docContent = String.Empty Then
                params(2) = New MySqlParameter("_fileDocContent", DBNull.Value)

            Else
                params(2) = New MySqlParameter("_fileDocContent", NwdSolutions.Web.GeneralUtilities.General.DbReplace(docContent))

            End If

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(conString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsUpdFile", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetChildDocsByParentIDForTree(ByVal parentID As String) As DocParentInfoCollection

            Dim params(0) As MySqlParameter

            Dim docs As New DocParentInfoCollection

            params(0) = New MySqlParameter("_pId", IIf(parentID = String.Empty, DBNull.Value, parentID))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelChildsByParentIdForTree", params)

            If db.HasError Then Return Nothing

            While reader.Read

                docs.Add(GetDocParentInfoFromReader(reader))

            End While

            reader.Close()

            Return docs

        End Function

        Public Shared Function GetChildDocsByParentIDAndType(ByVal parentID As String, ByVal fileType As Int16) As ArrayList

            Dim params(1) As MySqlParameter

            Dim ids As ArrayList = New ArrayList()

            params(0) = New MySqlParameter("_fileID", IIf(parentID = String.Empty, DBNull.Value, parentID))

            params(1) = New MySqlParameter("_filetype", fileType)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelChildsIDByPIDAndType", params)

            If db.HasError Then Return Nothing

            While reader.Read

                ids.Add(DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString)

            End While

            reader.Close()

            Return ids

        End Function

        Public Shared Function GetFileType(ByVal fileID As String) As Integer

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Int16?

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelTypeByID", params)

            If db.HasError Then Return -1

            If reader.Read() Then

                result = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "fileType")

            End If

            reader.Close()

            Return result

        End Function

        Public Shared Function GetFileAllInfoByID(ByVal fileId As String) As Files

            Dim params(0) As MySqlParameter

            Dim file As New Files

            params(0) = New MySqlParameter("_fileID", fileId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelAllByID", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                file = GetFilesFromReader(reader)

            End If

            reader.Close()

            Return file

        End Function

        Public Shared Function UpdateParentId(ByVal prefileID As String, ByVal newfileID As String) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_prefileID", prefileID)

            params(1) = New MySqlParameter("_newfileID", newfileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesUpdParentId", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function GetFilesForTransfer(ByVal fileCaseId As String, Optional ByVal IncludeTiming As Boolean = False) As FilesCollection

            Dim params(1) As MySqlParameter

            Dim list As New FilesCollection

            params(0) = New MySqlParameter("_fileCaseID", fileCaseId)

            params(1) = New MySqlParameter("_icludeTiming", IncludeTiming)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelForTransfer", params)

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                list.Add(GetFilesForTransferFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function DeleteFileById(ByVal fileID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_DelfilesDelFile", params))

            If db.HasError Then Return False

            Return result

        End Function

        Public Shared Function DeleteFile(ByVal fileID As String) As Long

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Long = db.GetScalarFromProcedure("stpDad_filesDelFile", params)

            If db.HasError Then Return 2

            Return result

        End Function

        Public Shared Function GetFileCustId(ByVal fileID As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim custId As String = String.Empty

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelFilecustId", params)

            If db.HasError Then Return String.Empty

            If reader.Read Then

                custId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCustID").ToString()
            End If

            reader.Close()

            Return custId

        End Function

        Public Shared Function StructureISNewVersion(ByVal _fileChilds As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileChilds", _fileChilds)

            Dim custId As String = String.Empty

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Long = db.GetScalarFromProcedure("stpDad_filesUtiIsNewVersion", params)

            If db.HasError Then Throw db.ErrorException


            If result > 0 Then Return True

            Return False

        End Function


#Region "FileDocs"

        Public Shared Function AddFileDoc(ByVal _fileDocID As String, ByVal _fileID As String, ByVal _fileCaseID As String, ByVal _docID As String, ByVal _fileDocDate As String, ByVal _fileDocTime As String, ByVal filePath As String) As Boolean

            Dim params(6) As MySqlParameter
            params(0) = New MySqlParameter("_fileDocID", _fileDocID)
            params(1) = New MySqlParameter("_fileID", _fileID)
            params(2) = New MySqlParameter("_fileCaseID", _fileCaseID)
            params(3) = New MySqlParameter("_docID", _docID)
            params(4) = New MySqlParameter("_fileDocDate", _fileDocDate)
            params(5) = New MySqlParameter("_fileDocTime", _fileDocTime)
            params(6) = New MySqlParameter("_fileDocBinary", Common.FileManager.GetFileInBinaryFormat(filePath, _fileDocID))


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function AddFileDocByAllValue(ByVal _fileID As String, ByVal _fileCaseID As String, ByVal _fileDocDate As String, ByVal _fileDocTime As String, ByVal filePath As String, ByVal t As TempDocReview, ByVal fileDocType As Int16) As Boolean

            Dim params(10) As MySqlParameter
            Dim _fileDocID As String = Guid.NewGuid.ToString()
            params(0) = New MySqlParameter("_fileDocID", _fileDocID)
            params(1) = New MySqlParameter("_fileID", _fileID)
            params(2) = New MySqlParameter("_fileCaseID", _fileCaseID)
            params(3) = New MySqlParameter("_fileDocType", fileDocType)
            params(4) = New MySqlParameter("_fileDocDate", _fileDocDate)
            params(5) = New MySqlParameter("_fileDocTime", _fileDocTime)
            params(6) = New MySqlParameter("_fileDocBinary", Common.FileManager.GetFileInBinaryFormat(filePath, _fileDocID))
            params(7) = New MySqlParameter("_fileDocName", t.docName)
            params(8) = New MySqlParameter("_fileDocContent", t.docContent)
            params(9) = New MySqlParameter("_fileDocImageID", t.docImageID)
            params(10) = New MySqlParameter("_fileDocExtension", t.docExtension)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsInsAll", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function AddFileDocByRelation(ByVal _fileDocID As String, ByVal _fileID As String, ByVal _fileCaseID As String, ByVal _prefileDocID As String, ByVal filePath As String) As Boolean

            Dim params(4) As MySqlParameter
            params(0) = New MySqlParameter("_fileDocID", _fileDocID)
            params(1) = New MySqlParameter("_fileID", _fileID)
            params(2) = New MySqlParameter("_fileCaseID", _fileCaseID)
            params(3) = New MySqlParameter("_prefileDocID", _prefileDocID)
            params(4) = New MySqlParameter("_fileDocBinary", Common.FileManager.GetFileInBinaryFormat(filePath, _fileDocID))


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsInsByRelation", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function AddFileDoc(ByVal parameter As FileDocs) As Boolean

            Dim params(10) As MySqlParameter
            params(0) = New MySqlParameter("_fileCaseID", parameter.fileCaseID)
            params(1) = New MySqlParameter("_fileDocBinary", Common.FileManager.GetFileInBinaryFormat(parameter.DocFullPath, parameter.fileDocID))
            If parameter.fileDocContent = String.Empty Then

                params(2) = New MySqlParameter("_fileDocContent", DBNull.Value)

            Else
                params(2) = New MySqlParameter("_fileDocContent", NwdSolutions.Web.GeneralUtilities.General.DbReplace(parameter.fileDocContent))

            End If
            params(3) = New MySqlParameter("_fileDocDate", parameter.fileDocDate)
            params(4) = New MySqlParameter("_fileDocExtension", parameter.fileDocExtension)
            params(5) = New MySqlParameter("_fileDocID", parameter.fileDocID)
            params(6) = New MySqlParameter("_fileDocImageID", parameter.fileDocImageID)
            params(7) = New MySqlParameter("_fileDocName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(parameter.fileDocName))
            params(8) = New MySqlParameter("_fileDocTime", parameter.fileDocTime)
            params(9) = New MySqlParameter("_fileID", parameter.fileID)
            params(10) = New MySqlParameter("_fileType", DBNull.Value)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsInsAllValue", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function IsExistFileDocName(ByVal _fileID As String, ByVal _fileDocExtension As String, ByVal _fileDocName As String) As String


            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", _fileID)

            params(1) = New MySqlParameter("_fileDocExtension", _fileDocExtension)

            params(2) = New MySqlParameter("_fileDocName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(_fileDocName))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("stpDad_filedocsUtiIsExistDocName", params).ToString

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function GetFileDocsChildsByFileID(ByVal fileId As String) As FileDocsChildInfoCollection

            Dim params(0) As MySqlParameter

            Dim docs As New FileDocsChildInfoCollection

            params(0) = New MySqlParameter("_fileID", fileId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filedocsSelByFileID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim doc As FileDocsChildInfo = GetFileDocsChildInfoFromReader(reader)

                docs.Add(doc)

            End While

            reader.Close()

            Return docs

        End Function


        Public Shared Function GetFileDocIdsByFileID(ByVal fileId As String) As ArrayList

            Dim params(0) As MySqlParameter

            Dim docs As New ArrayList

            params(0) = New MySqlParameter("_fileID", fileId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filedocsSelDocIdsByFileID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                docs.Add(DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileDocID").ToString)

            End While

            reader.Close()

            Return docs

        End Function

        Public Shared Function WriteFile(ByVal ID As String) As String

            Dim params(0) As MySqlParameter

            Dim content() As Byte = Nothing
            Dim extension As String = String.Empty

            params(0) = New MySqlParameter("_fileDocID", ID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filedocsSelContent", params)

            If db.HasError Then Return Nothing

            While reader.Read

                content = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "fileDocBinary")

                extension = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileDocExtension")

            End While

            reader.Close()

            If content IsNot Nothing AndAlso content.Length > 0 Then

                Dim fileFullPath As String = FileManager.GetTempDocsFilesPath() & ID & extension

                FileManager.GetFileFromBinaryFormat(content, fileFullPath, False, True)

                Return fileFullPath

            End If

            Return Nothing


        End Function

        Public Shared Sub CreatTajmii(ByVal fileId As String, ByVal filepath As String)

            Dim params(0) As MySqlParameter

            Dim docs As New FileDocsReviewCollection

            params(0) = New MySqlParameter("_fileID", fileId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filedocsSelFilesForTajmii", params)

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                docs.Add(GetFileDocsReviewFromReader(reader))

            End While

            reader.Close()

            For Each Item As FileDocsReview In docs

                If Item.fileDocBinary IsNot Nothing AndAlso Item.fileDocBinary.Length > 0 Then

                    FileManager.GetFileFromBinaryFormat(Item.fileDocBinary, filepath & Item.fileDocName & Item.fileDocExtension, False, True)

                End If

            Next

        End Sub

        Public Shared Function UpdateDocFileName(ByVal fileID As String, ByVal fileName As String) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileDocName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(fileName))

            params(1) = New MySqlParameter("_fileDocID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsUpdDocName", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetAllFileDocsByFileCaseID(ByVal filecaseId As String) As FileDocsCollection

            Dim params(0) As MySqlParameter

            Dim docs As New FileDocsCollection

            params(0) = New MySqlParameter("_fileCaseID", filecaseId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filedocsSelAllByFilecaseID", params)

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                docs.Add(GetFiledocsFromReader(reader))

            End While

            reader.Close()

            Return docs

        End Function

        Public Shared Function DeleteFileDocById(ByVal fileID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileDocID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_filedocsDelById", params))

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetFileDocsReportByFilecase(ByVal fileCaseID As String, ByVal fileType As Int16) As System.Data.DataTable

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            params(1) = New MySqlParameter("_fileType", fileType)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As System.Data.DataTable = db.GetDataTableFromProcedure("stpDad_rptfiledocsSelByFilecaseIDAndType", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function


        Public Shared Function GetFileCaseCountByFileId(ByVal fileId As String) As ArrayList

            Dim params(0) As MySqlParameter

            Dim filecaseCount As ArrayList = New ArrayList()

            params(0) = New MySqlParameter("_fileId", fileId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelFilecaseCount", params)

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                filecaseCount.Add(New String() {DbAccessLayer.MySqlDataHelper.GetInt64(reader, "count").ToString(), DbAccessLayer.MySqlDataHelper.GetInt(reader, "closed").ToString()})

            End While

            reader.Close()

            Return filecaseCount

        End Function


#End Region

#Region "Relation"

        Public Shared Function DelRelation(ByVal fileID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesDelRelation", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function GetMaxRelationId() As Integer


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim ID As Integer = db.GetScalarFromProcedure("stpDad_filesSelMaxRelationID")

            If db.HasError Then Throw db.ErrorException

            Return ID

        End Function

        Public Shared Sub UpdateRelation(ByVal query As String)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteSqlCommandText(query)

            If db.HasError Then Throw db.ErrorException

        End Sub


#End Region

#Region "Copy Paste"

        Public Shared Function CutFilecase(ByVal fileID As String, ByVal fileChildId As String) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            params(1) = New MySqlParameter("_fileChilds", fileChildId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesUpdFilesChild", params)

            If db.HasError Then Return False

            Return True

        End Function

#End Region


#End Region

#Region "Utility"

        Private Shared Function GetFileChildInfoFromReader(ByVal reader As IDataReader) As FileChildInfo

            If reader Is Nothing Then Return Nothing

            Dim doc As New FileChildInfo

            doc.fileID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString

            doc.fileIsCat = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "fileIsCat")

            doc.fileName = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileName")

            doc.fileType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "fileType")

            doc.fileImageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileImageID").ToString()

            doc.ImageUpdateDate = DbAccessLayer.MySqlDataHelper.GetString(reader, "ImageUpdateDate")

            doc.imageExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageExtension")

            Dim i As Integer? = DbAccessLayer.MySqlDataHelper.GetNullableInt(reader, "fileRelationId")

            If i.HasValue Then doc.fileRelationId = i.ToString()

            Return doc

        End Function

        Private Shared Function GetFileDocsChildInfoFromReader(ByVal reader As IDataReader) As FileDocsChildInfo

                If reader Is Nothing Then Return Nothing

                Dim parameter As New FileDocsChildInfo

                parameter.fileDocID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileDocID").ToString

                parameter.fileDocImageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileDocImageID").ToString

                parameter.fileDocName = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileDocName")

                parameter.fileDocExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileDocExtension")

                Return parameter

        End Function

        Private Shared Function GetFiledocsFromReader(ByVal reader As IDataReader) As FileDocs

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FileDocs

            parameter.fileCaseID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID").ToString

            parameter.fileDocBinary = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "fileDocBinary")

            parameter.fileDocContent = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileDocContent")

            parameter.fileDocDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "fileDocDate")

            parameter.fileDocExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileDocExtension")

            parameter.fileDocID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileDocID").ToString

            parameter.fileDocImageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileDocImageID").ToString

            parameter.fileDocName = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileDocName")

            parameter.fileDocTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "filedoctime")

            parameter.fileID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString

            parameter.fileType = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "fileDocType")

            Return parameter

        End Function

        Private Shared Function GetFileDocsReviewFromReader(ByVal reader As IDataReader) As FileDocsReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FileDocsReview

            parameter.fileDocName = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileDocName")

            parameter.fileDocExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileDocExtension")

            parameter.fileDocBinary = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "fileDocBinary")

            Return parameter

        End Function

        Private Shared Function GetFileParentInfoFromReader(ByVal reader As IDataReader) As FileParentInfo

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FileParentInfo

            parameter.fileId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileId").ToString()

            parameter.FileType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "FileType")

            parameter.FileCaseId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID").ToString()

            parameter.fileName = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileName")

            Return parameter

        End Function

        Private Shared Function GetFilesFromReader(ByVal reader As IDataReader) As Files

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Files

            parameter.fileCaseID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID").ToString()

            parameter.fileChilds = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileChilds").ToString()

            parameter.fileCustID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCustID").ToString()

            parameter.fileID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileId").ToString()

            parameter.fileImageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileImageID").ToString()

            parameter.fileIsCat = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "fileIsCat")

            parameter.fileName = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileName")

            parameter.FileType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "FileType")

            Return parameter

        End Function

        Private Shared Function GetFilesForTransferFromReader(ByVal reader As IDataReader) As Files

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Files

            parameter.fileCaseID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID").ToString()

            parameter.fileChilds = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileChilds").ToString()

            parameter.fileCustID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCustID").ToString()

            parameter.fileID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileId").ToString()

            parameter.fileImageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileImageID").ToString()

            parameter.fileIsCat = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "fileIsCat")

            parameter.fileName = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileName")

            parameter.FileType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "FileType")

            parameter.FileLocker = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "FileLocker").ToString()

            Return parameter

        End Function

        Private Shared Function GetFileLockerInfoFromReader(ByVal reader As IDataReader) As ContactInfo.ContactInfoReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New ContactInfo.ContactInfoReview

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID").ToString()

            Return parameter

        End Function

        Private Shared Function GetDocParentInfoFromReader(ByVal reader As IDataReader) As DocParentInfo

            If reader Is Nothing Then Return Nothing

            Dim doc As New DocParentInfo

            doc.docType = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileName")

            doc.docID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString

            Return doc

        End Function

#End Region

    End Class
End Namespace

