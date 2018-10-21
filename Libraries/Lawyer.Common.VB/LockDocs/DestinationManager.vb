Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB.BaseForm
Imports NwdSolutions.Web.GeneralUtilities

Namespace LockDocs

    Public Class DestinationManager


        Public Shared Function GetCurrentVersion(ByVal versionType As Char) As Integer

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_updDescription", versionType)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim version As String = db.GetScalarFromProcedure("stpDad_updateSelLastVersion", params)

            If db.HasError Then Throw db.ErrorException

            If version = String.Empty Then
                Return Lawyer.Common.Default.DefaultValue.DefaultDatabaseVI

            Else
                Return Convert.ToInt32(version.Replace(".", ""))
            End If


            Return version

        End Function

        'Public Shared Function GetFileCaseAreaRecordCount() As Integer

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim count As Integer = db.GetScalarFromProcedure("stpDad_filecaseareaSelCount")

        '    If db.HasError Then Throw db.ErrorException

        '    Return count

        'End Function

        Public Shared Function GetFileType(ByVal fileID As String) As Integer

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Int16?

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelTypeByID", params)

            If db.HasError Then Return -1

            If reader.Read() Then

                result = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "fileType")

            End If

            reader.Close()

            Return result

        End Function

        Public Shared Function GetFileCaseAreaRecordCount() As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim count As Integer = db.GetScalarFromProcedure("stpDad_toolssalahiatSelCount")

            If db.HasError Then Throw db.ErrorException

            Return count

        End Function

        Public Shared Function GetFileCaseAreaRecordCount1() As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim count As Integer = db.GetScalarFromProcedure("stpDad_toolssalahiatbranchesSelCount")

            If db.HasError Then Throw db.ErrorException

            Return count

        End Function


        Public Shared Function AddArea(ByVal Competency As Competencys.Competency) As String

            Dim params(7) As MySqlParameter

            params(0) = New MySqlParameter("_tsid", Competency.tsid)
            params(1) = New MySqlParameter("_tsState", General.DbReplace(Competency.tsState))
            params(2) = New MySqlParameter("_tsProvince", General.DbReplace(Competency.tsProvince))
            params(3) = New MySqlParameter("_tsName", General.DbReplace(Competency.tsName))
            params(4) = New MySqlParameter("_tsType", Competency.tsType)
            params(5) = New MySqlParameter("_tsHokmType", General.DbReplace(Competency.tsHokmType))
            params(6) = New MySqlParameter("_tsMapField", Competency.tsMapField) ' no DbReplace
            params(7) = New MySqlParameter("_tsDescription", General.DbReplace(Competency.tsDescription))


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_ToolssalahiatIns2", params)

            If db.HasError Then Throw db.ErrorException

            Return Competency.tsid.ToString()

        End Function

        Public Shared Function AddArea1(ByVal Competency As Competencys.CompetencyBranch) As String

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_tsbID", Competency.tsbID)
            params(1) = New MySqlParameter("_tsid", Competency.tsid)
            params(2) = New MySqlParameter("_tsbType", General.DbReplace(Competency.tsbType))
            params(3) = New MySqlParameter("_tsbName", General.DbReplace(Competency.tsbName))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_toolssalahiatbranchesIns2", params)

            If db.HasError Then Throw db.ErrorException

            Return Competency.tsid.ToString()

        End Function

        Public Shared Function EmptyFileCaseArea() As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_toolssalahiatEmpty")

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function EmptyFileCaseArea1() As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_toolssalahiatbranchesEmpty")

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function GetContactInfoRecordCount() As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim count As Integer = db.GetScalarFromProcedure("stpDad_contactinfoSelCount")

            If db.HasError Then Throw db.ErrorException

            Return count

        End Function


        Public Shared Function EmptyContactInfo() As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_contactinfoEmpty")

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function DeleteFilesById(ByVal fileID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesDelByID", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function AddParties(ByVal parties As FileParties.FileParties) As Boolean

            Dim params(6) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            params(0) = New MySqlParameter("_contactInfoID", parties.contactInfoID)
            params(1) = New MySqlParameter("_fileCaseID", parties.fileCaseID)
            params(2) = New MySqlParameter("_fileCaseRole", parties.fileCaseRole)
            params(3) = New MySqlParameter("_fileID", parties.fileID)
            params(4) = New MySqlParameter("_filePartyID", parties.filePartyID)
            params(5) = New MySqlParameter("_custPriority", DBNull.Value)
            params(6) = New MySqlParameter("_financeAccess", parties.financeAccess)

            db.ExecuteProcedure("stpDad_filepartiesIns", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Sub DeleteFileCase(ByVal fileCaseID As String)

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesDelFileCase", params)

            If db.HasError Then Throw db.ErrorException

        End Sub

        Public Shared Sub AddFileCase(ByVal parameter As FileCase)

            Dim params(22) As MySqlParameter

            params(15) = New MySqlParameter("_fileCaseID", parameter.fileCaseID)

            params(4) = New MySqlParameter("_fileCaseComplainant", parameter.fileCaseComplainant)

            params(2) = New MySqlParameter("_fileCaseCat", parameter.fileCaseCat)

            params(13) = New MySqlParameter("_fileCaseType", parameter.fileCaseType)

            params(12) = New MySqlParameter("_fileCaseSubject", IIf(String.IsNullOrEmpty(parameter.fileCaseSubject), DBNull.Value, parameter.fileCaseSubject))

            params(5) = New MySqlParameter("_fileCaseDescription", parameter.fileCaseDescription)

            params(7) = New MySqlParameter("_fileCaseNumberInSystem", IIf(parameter.fileCaseNumberInSystem = String.Empty, DBNull.Value, parameter.fileCaseNumberInSystem))

            params(6) = New MySqlParameter("_fileCaseNumberInCourt", IIf(parameter.fileCaseNumberInCourt = String.Empty, DBNull.Value, parameter.fileCaseNumberInCourt))

            params(8) = New MySqlParameter("_fileCaseOpenDate", parameter.fileCaseOpenDate)

            params(3) = New MySqlParameter("_fileCaseCloseDate", IIf(Not parameter.fileCaseCloseDate.HasValue, DBNull.Value, parameter.fileCaseCloseDate))

            params(10) = New MySqlParameter("_fileCaseStep", parameter.fileCaseStep)

            params(14) = New MySqlParameter("_fileID", parameter.fileID)

            params(0) = New MySqlParameter("_fileCaseAreaID", IIf(parameter.fileCaseAreaID = Guid.Empty.ToString, DBNull.Value, parameter.fileCaseAreaID))

            params(11) = New MySqlParameter("_fileCaseSubAreaID", IIf(parameter.fileCaseSubAreaID = Guid.Empty.ToString, DBNull.Value, parameter.fileCaseSubAreaID))

            params(9) = New MySqlParameter("_fileCaseRelatedID", DBNull.Value)

            params(16) = New MySqlParameter("_fileCaseLastAction", IIf(parameter.fileCaseLastAction <> String.Empty, parameter.fileCaseLastAction, DBNull.Value))

            params(17) = New MySqlParameter("_fileCaseOtherDescription", IIf(parameter.fileCaseOtherDescription <> String.Empty, parameter.fileCaseOtherDescription, DBNull.Value))

            params(18) = New MySqlParameter("_fileCaseResult", IIf(parameter.fileCaseResult <> String.Empty, parameter.fileCaseResult, DBNull.Value))

            params(19) = New MySqlParameter("_filecaseResultDetail", IIf(parameter.filecaseResultDetail <> String.Empty, parameter.filecaseResultDetail, DBNull.Value))

            params(1) = New MySqlParameter("_fileCaseCost", IIf(parameter.fileCaseCost.HasValue, parameter.fileCaseCost, DBNull.Value))

            params(20) = New MySqlParameter("_fileCaseGhararType", parameter.fileCaseGhararType)

            params(21) = New MySqlParameter("_fileCaseNumberInBranch", parameter.fileCaseNumberInBranch)

            params(22) = New MySqlParameter("_fileCasePass", parameter.fileCasePass)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filecasesIns", params)

            If db.HasError Then Throw db.ErrorException

        End Sub

        Public Shared Sub AddFileDoc(ByVal parameter As FileDocs)

            Dim params(10) As MySqlParameter
            params(0) = New MySqlParameter("_fileCaseID", parameter.fileCaseID)
            params(1) = New MySqlParameter("_fileDocBinary", parameter.fileDocBinary)
            params(2) = New MySqlParameter("_fileDocContent", IIf(parameter.fileDocContent = String.Empty, DBNull.Value, parameter.fileDocContent))
            params(3) = New MySqlParameter("_fileDocDate", parameter.fileDocDate)
            params(4) = New MySqlParameter("_fileDocExtension", parameter.fileDocExtension)
            params(5) = New MySqlParameter("_fileDocID", parameter.fileDocID)
            params(6) = New MySqlParameter("_fileDocImageID", parameter.fileDocImageID)
            params(7) = New MySqlParameter("_fileDocName", parameter.fileDocName)
            params(8) = New MySqlParameter("_fileDocTime", parameter.fileDocTime)
            params(9) = New MySqlParameter("_fileID", parameter.fileID)
            params(10) = New MySqlParameter("_fileType", IIf(parameter.fileType.HasValue, parameter.fileType, DBNull.Value))


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsInsAllValue", params)

            If db.HasError Then Throw db.ErrorException

        End Sub

        Public Shared Sub CreateFile(ByVal doc As Files)

            Dim params(8) As MySqlParameter

            params(0) = New MySqlParameter("_fileImageID", doc.fileImageID)
            params(1) = New MySqlParameter("_fileChilds", IIf(doc.fileChilds.ToString = Guid.Empty.ToString(), DBNull.Value, doc.fileChilds))
            params(2) = New MySqlParameter("_fileIsCat", doc.fileIsCat)
            params(3) = New MySqlParameter("_fName", doc.fileName)
            params(4) = New MySqlParameter("_fileType", doc.FileType)
            params(5) = New MySqlParameter("_fileID", doc.fileID)
            params(6) = New MySqlParameter("_fileCustID", IIf(doc.fileCustID.ToString = Guid.Empty.ToString(), DBNull.Value, doc.fileCustID))
            params(7) = New MySqlParameter("_fileCaseID", IIf(doc.fileCaseID.ToString = Guid.Empty.ToString(), DBNull.Value, doc.fileCaseID))
            params(8) = New MySqlParameter("_FileLocker", IIf(doc.FileLocker.ToString = Guid.Empty.ToString(), DBNull.Value, doc.FileLocker))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filesInsTransfer", params)

            If db.HasError Then Throw db.ErrorException


        End Sub


        Public Shared Function GetFileCustId(ByVal fileID As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim custId As String = String.Empty

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelFilecustId", params)

            If db.HasError Then Return String.Empty

            If reader.Read Then

                custId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCustID").ToString()
            End If

            reader.Close()

            Return custId

        End Function

        '-----------------------------------------------------

        Public Shared Function IsExistContactById(ByVal custId As String) As Integer

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custID", custId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_contactinfoUtiIsExist", params))

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function IsExitsFileCaseNoInSystem(ByVal id As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_ID", id)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_filecasesIsExistsNoINSystem", params))

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function CheckLockDoc(ByVal fileId As String) As ContactInfo.ContactInfoReview

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileId)

            Dim result As ContactInfo.ContactInfoReview

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesCheckForTransfer", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                If DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID") = Guid.Empty Then

                    reader.Close()

                    Return Nothing

                Else
                    result = New ContactInfo.ContactInfoReview

                    result.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

                    result.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID").ToString()

                    reader.Close()

                    Return result

                End If

            End If

            reader.Close()


            Return Nothing
          

        End Function

        Public Shared Function IsExistsParentFile(ByVal fileId As String, ByVal filename As String) As Int16

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileId)

            params(1) = New MySqlParameter("_fileN", filename)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Int16 = db.GetScalarFromProcedure("stpDad_FilesUtiIsExistParent", params)

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function




        Public Shared Function SelFileIdByCustID(ByVal _fileCustID As String) As String

            Dim fileId As String = String.Empty

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCustID", _fileCustID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filesSelIDByCustID", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                fileId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString()

            End If

            reader.Close()

            Return fileId

        End Function

        Public Shared Function IsExistsFileByID(ByVal fileId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_filesUtiExistByID", params))

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function GetFileCaseByID(ByVal fileCaseID As String) As FileCase

            Dim f As New FileCase

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filecasesSelAllByID", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                f = GetFileCaseFromReader(reader)

            End If

            reader.Close()

            Return f

        End Function

        Public Shared Function GetFileNameByID(ByVal fileId As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("StpDad_filesSelNameByID", params).ToString()

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function AddContact(ByVal parameter As ContactInfo.Contact) As Boolean

            Dim params(22) As MySqlParameter

            params(0) = New MySqlParameter("_custID", parameter.custID)

            params(1) = New MySqlParameter("_custFullName", parameter.custFullName)

            params(2) = New MySqlParameter("_custCompanyName", IIf(parameter.custCompanyName = String.Empty, DBNull.Value, parameter.custCompanyName))

            params(3) = New MySqlParameter("_custJobTitle", IIf(parameter.custJobTitle = String.Empty, DBNull.Value, parameter.custJobTitle))

            params(4) = New MySqlParameter("_custRegisterationNumber", IIf(parameter.custRegisterationNumber = String.Empty, DBNull.Value, parameter.custRegisterationNumber))

            params(5) = New MySqlParameter("_custIDNumber", IIf(parameter.custIDNumber = String.Empty, DBNull.Value, parameter.custIDNumber))

            params(6) = New MySqlParameter("_custFatherName", IIf(parameter.custFatherName = String.Empty, DBNull.Value, parameter.custFatherName))

            params(7) = New MySqlParameter("_custBthDay", IIf(parameter.custBthDay = String.Empty, DBNull.Value, parameter.custBthDay))

            params(8) = New MySqlParameter("_custEmailOne", IIf(parameter.custEmailOne = String.Empty, DBNull.Value, parameter.custEmailOne))

            params(9) = New MySqlParameter("_custHomeTel", IIf(parameter.custHomeTel = String.Empty, DBNull.Value, parameter.custHomeTel))

            params(10) = New MySqlParameter("_custOfficeTel", IIf(parameter.custOfficeTel = String.Empty, DBNull.Value, parameter.custOfficeTel))

            params(11) = New MySqlParameter("_custCellPhone", IIf(parameter.custCellPhone = String.Empty, DBNull.Value, parameter.custCellPhone))

            params(12) = New MySqlParameter("_custFax", IIf(parameter.custFax = String.Empty, DBNull.Value, parameter.custFax))

            params(13) = New MySqlParameter("_custAddress", IIf(parameter.custAddress = String.Empty, DBNull.Value, parameter.custAddress))

            params(14) = New MySqlParameter("_custType", parameter.custType)

            params(15) = New MySqlParameter("_custDescription", IIf(parameter.custDescription = String.Empty, DBNull.Value, parameter.custDescription))

            params(16) = New MySqlParameter("_custUserName", IIf(parameter.custUserName = String.Empty, DBNull.Value, parameter.custUserName))

            params(17) = New MySqlParameter("_custPassword", IIf(parameter.custPassword = String.Empty, DBNull.Value, parameter.custPassword))

            params(18) = New MySqlParameter("_custIsSysUser", parameter.custIsSysUser)

            params(19) = New MySqlParameter("_custIsAdminUser", parameter.custIsAdminUser)

            params(20) = New MySqlParameter("_custSaltkey", parameter.custSaltkey)

            params(21) = New MySqlParameter("_custNetUser", IIf(parameter.custNetUser = String.Empty, DBNull.Value, parameter.custNetUser))

            params(22) = New MySqlParameter("_custNetPassword", IIf(parameter.custNetPassword = String.Empty, DBNull.Value, parameter.custNetPassword))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_contactinfoIns", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function AddImage(ByVal parameter As Image) As Boolean

            Dim params(4) As MySqlParameter

            params(0) = New MySqlParameter("_imageExtension", parameter.imageExtension)

            params(1) = New MySqlParameter("_imageID", parameter.imageID)

            params(2) = New MySqlParameter("_imageLogo", parameter.imageLogo)

            params(3) = New MySqlParameter("_imageName", parameter.imageName)

            params(4) = New MySqlParameter("_imageUpdateDate", parameter.imageUpdateDate)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_imagesTransfer", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        'Public Shared Function IsExitsFileCaseArea(ByVal id As String) As Boolean

        '    Dim params(0) As MySqlParameter

        '    params(0) = New MySqlParameter("_fileCaseAreaID", id)

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_filecaseareaUtiIsExist", params))

        '    If db.HasError Then Throw db.ErrorException

        '    Return result

        'End Function


        Public Shared Function IsExitsFileCaseArea(ByVal id As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tsid", id)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_toolssalahiatUtiIsExist", params))

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function AddTiming(ByVal parameter As Timing.Timing) As Boolean

            Dim params(6) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", parameter.timeID)

            params(1) = New MySqlParameter("_fileID", IIf(parameter.fileID = String.Empty, DBNull.Value, parameter.fileID))

            params(2) = New MySqlParameter("_fileCaseID", IIf(parameter.fileCaseID = String.Empty, DBNull.Value, parameter.fileCaseID))

            params(3) = New MySqlParameter("_timeType", parameter.timeType)

            params(4) = New MySqlParameter("_timeText", IIf(parameter.timeText = String.Empty, DBNull.Value, parameter.timeText))

            params(5) = New MySqlParameter("_timeSourceCustID", parameter.timeSourceCustID)

            params(6) = New MySqlParameter("_timeTitle", IIf(parameter.timeTitle = String.Empty, DBNull.Value, parameter.timeTitle))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_timingIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function AddParties(ByVal parameter As TimeParties.TimeParties) As Boolean

            Dim params(9) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            params(0) = New MySqlParameter("_tpID", parameter.tpID)

            params(1) = New MySqlParameter("_timeID", parameter.timeID)

            params(2) = New MySqlParameter("_tpTargetCustID", parameter.tpTargetCustID)

            params(3) = New MySqlParameter("_timeDate", parameter.timeDate)

            params(4) = New MySqlParameter("_timeTime", parameter.timeTime)

            params(5) = New MySqlParameter("_timeReminderBefore", IIf(parameter.timeReminderBefore = String.Empty, DBNull.Value, parameter.timeReminderBefore))

            params(6) = New MySqlParameter("_timeStatus", IIf(parameter.timeStatus = String.Empty, DBNull.Value, parameter.timeStatus))

            params(7) = New MySqlParameter("_timeActualTime", parameter.timeActualTime)

            params(8) = New MySqlParameter("_timeDone", parameter.timeDone)

            params(9) = New MySqlParameter("_timeDuration", IIf(parameter.timeDuration = String.Empty, DBNull.Value, parameter.timeDuration))

            db.ExecuteProcedure("stpDad_timepartiesIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function IsExitsFileByType(ByVal fcid As String, ByVal fileType As Docs.Enums.FileType) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fcid)

            params(1) = New MySqlParameter("_fileType", fileType)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_filesUtiIsExistByType", params))

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function IsExistFileName(ByVal filename As String, ByVal parentID As String) As String


            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fName", filename)

            params(1) = New MySqlParameter("_fileChilds", IIf(parentID = String.Empty, DBNull.Value, parentID))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(Common.DestConnectionString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("stpDad_filesUtiIsExistFileName", params).ToString

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function



#Region "Utility"


        Private Shared Function GetFileCaseFromReader(ByVal reader As IDataReader) As FileCase

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FileCase

            parameter.fileCaseAreaID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseAreaID").ToString()

            parameter.fileCaseBranchID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseBranchID").ToString()

            parameter.fileCaseSubAreaID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseSubAreaID").ToString()

            parameter.fileCaseCat = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "fileCaseCat")

            parameter.fileCaseCloseDate = DbAccessLayer.MySqlDataHelper.GetNullableInt(reader, "fileCaseCloseDate")

            parameter.fileCaseComplainant = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "fileCaseComplainant")

            parameter.fileCaseDescription = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseDescription")

            parameter.fileCaseNumberInCourt = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInCourt")

            parameter.fileCaseNumberInSystem = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInSystem")

            parameter.fileCaseOpenDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "fileCaseOpenDate")

            parameter.fileCaseRelatedID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseRelatedID").ToString()

            parameter.fileCaseStep = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "fileCaseStep")

            parameter.fileCaseSubject = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseSubject")

            parameter.fileCaseType = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "fileCaseType")

            parameter.fileID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString()

            parameter.fileCaseLastAction = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseLastAction")

            parameter.fileCaseOtherDescription = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseOtherDescription")

            parameter.fileCaseResult = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "fileCaseResult")

            parameter.filecaseResultDetail = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "filecaseResultDetail")

            parameter.fileCaseGhararType = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "fileCaseGhararType")

            parameter.fileCaseCost = DbAccessLayer.MySqlDataHelper.GetNullableDouble(reader, "fileCaseCost")

            Return parameter

        End Function


#End Region

    End Class

End Namespace

