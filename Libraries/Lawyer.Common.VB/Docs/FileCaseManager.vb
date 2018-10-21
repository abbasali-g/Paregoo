Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports System.Windows.Forms
Imports Lawyer.Common.VB.Common

Namespace Docs
    Public Class FileCaseManager


#Region "Methods"
        '' ''Enum fileCaseFileType

        '' ''    حقوقی = 1

        '' ''    کیفری = 2

        '' ''    بدوی = 3

        '' ''    تجدید = 4

        '' ''    همه = 5

        '' ''End Enum

        Public Shared Function GetMaxFileCaseNoInSystem() As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Int32 = CInt(db.GetScalarFromProcedure("stpDad_filecasesSelMaxNoInSystem"))

            If db.HasError Then Return 0

            Return result

        End Function

        Public Shared Function IsExitsFileCaseNoInSystem(ByVal id As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_ID", id)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_filecasesIsExistsNoINSystem", params))

            If db.HasError Then Return True

            Return result

        End Function

        Public Shared Function GetAllFileCaseGhararType() As AutoCompleteStringCollection

            Dim list As New AutoCompleteStringCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filecasesSelGhararType")

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(DbAccessLayer.SqlDataHelper.GetString(reader, "fileCaseGhararType"))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function IsFileCaseClosed(ByVal id As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", id)

            Dim result As Int32?

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filecasesIsClosed", params)

            If reader.Read Then

                result = DbAccessLayer.SqlDataHelper.GetNullableInt(reader, "fileCaseCloseDate")

            End If

            If db.HasError Then Throw db.ErrorException

            If result.HasValue Then

                Return True

            Else
                Return False

            End If



        End Function

        Public Shared Function GetAllFileCaseSubjects() As AutoCompleteStringCollection

            Dim list As New AutoCompleteStringCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filecasesSelSubjects")

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(DbAccessLayer.SqlDataHelper.GetString(reader, "fileCaseSubject"))

            End While

            reader.Close()

            Return list

        End Function


        Public Shared Function GetFileCaseSteps(ByVal addNullValue As Boolean) As Setting.SettingCollection


            Dim l As Setting.SettingCollection = Setting.SettingManager.GetSettingsByName("FileCaseStep")

            If addNullValue Then

                l.Add(New Setting.Setting("نامشخص", "-1"))
            End If

            Return l

        End Function

        Public Shared Function GetFileCaseStepTextByValue(ByVal value As String) As Setting.Setting

            Return Setting.SettingManager.GetSettingsByValue("FileCaseStep", value)


        End Function


        Public Shared Function AddFileCase(ByVal parameter As FileCase, ByVal filecaseId As String) As Integer

            Dim params(8) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseCat", parameter.fileCaseCat)

            params(1) = New MySqlParameter("_fileCaseComplainant", parameter.fileCaseComplainant)

            params(2) = New MySqlParameter("_fileCaseDescription", parameter.fileCaseDescription)

            params(3) = New MySqlParameter("_fileCaseOpenDate", parameter.fileCaseOpenDate)

            params(4) = New MySqlParameter("_fileCaseStep", parameter.fileCaseStep)

            params(5) = New MySqlParameter("_fileCaseSubject", IIf(String.IsNullOrEmpty(parameter.fileCaseSubject), DBNull.Value, parameter.fileCaseSubject))

            params(6) = New MySqlParameter("_fileCaseType", parameter.fileCaseType)

            params(7) = New MySqlParameter("_fileID", parameter.fileID)

            params(8) = New MySqlParameter("_fileCaseID", filecaseId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_filecasesInsByRelation", params))

            If db.HasError Then Return 0

            Return result


        End Function

        Public Shared Function AddFileCase(ByVal fileCaseOpenDate As String, ByVal fileCaseSubject As String, ByVal fileID As String, ByVal fileCaseID As String) As Integer

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseOpenDate", fileCaseOpenDate)

            params(1) = New MySqlParameter("_fileCaseSubject", fileCaseSubject)

            params(2) = New MySqlParameter("_fileID", fileID)

            params(3) = New MySqlParameter("_fileCaseID", fileCaseID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_filecasesInsByDefaultValue", params))

            If db.HasError Then Return 0

            Return result


        End Function

        Public Shared Function GetFileCaseByID(ByVal fileCaseID As String) As FileCase

            Dim f As FileCase = Nothing

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filecasesSelAllByID", params)

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                f = GetFileCaseFromReader(reader)

            End While

            reader.Close()

            Return f

        End Function

        Public Shared Function EditFileCase(ByVal parameter As FileCase) As Boolean

            Dim params(15) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseAreaID", IIf(parameter.fileCaseAreaID = String.Empty, DBNull.Value, parameter.fileCaseAreaID))

            params(1) = New MySqlParameter("_fileCaseID", parameter.fileCaseID)

            params(2) = New MySqlParameter("_fileCaseCat", parameter.fileCaseCat)

            params(3) = New MySqlParameter("_fileCasePass", parameter.fileCasePass)

            '' ''params(3) = New MySqlParameter("_fileCaseCloseDate", parameter.fileCaseCloseDate)

            params(4) = New MySqlParameter("_fileCaseComplainant", parameter.fileCaseComplainant)

            params(5) = New MySqlParameter("_fileCaseDescription", parameter.fileCaseDescription)

            params(6) = New MySqlParameter("_fileCaseNumberInCourt", IIf(parameter.fileCaseNumberInCourt = String.Empty, DBNull.Value, parameter.fileCaseNumberInCourt))

            params(7) = New MySqlParameter("_fileCaseNumberInSystem", IIf(parameter.fileCaseNumberInSystem = String.Empty, DBNull.Value, parameter.fileCaseNumberInSystem))

            params(8) = New MySqlParameter("_fileCaseOpenDate", parameter.fileCaseOpenDate)

            params(9) = New MySqlParameter("_fileCaseRelatedID", DBNull.Value)

            params(10) = New MySqlParameter("_fileCaseStep", parameter.fileCaseStep)

            params(11) = New MySqlParameter("_fileCaseSubAreaID", IIf(parameter.fileCaseSubAreaID = String.Empty, DBNull.Value, parameter.fileCaseSubAreaID))

            params(12) = New MySqlParameter("_fileCaseSubject", IIf(String.IsNullOrEmpty(parameter.fileCaseSubject), DBNull.Value, parameter.fileCaseSubject))

            params(13) = New MySqlParameter("_fileCaseType", parameter.fileCaseType)

            params(14) = New MySqlParameter("_fileID", parameter.fileID)

          
            params(15) = New MySqlParameter("_fileCaseNumberInBranch", IIf(parameter.fileCaseNumberInBranch = String.Empty, DBNull.Value, parameter.fileCaseNumberInBranch))

            '' ''params(16) = New MySqlParameter("_fileCaseNumberYear", IIf(parameter.fileCaseNumberYear = String.Empty, DBNull.Value, parameter.fileCaseNumberYear))

            '' ''params(16) = New MySqlParameter("_filecaseResultDetail", parameter.filecaseResultDetail)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filecasesUpd", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditLastAction(ByVal fileCaseId As String, ByVal fileCaseLastAction As String) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseLastAction", fileCaseLastAction)

            params(1) = New MySqlParameter("_fileCaseID", fileCaseId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filecasesUpdLastAction", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditOtherDescription(ByVal fileCaseId As String, ByVal parameter As FileCase) As Boolean

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseOtherDescription", parameter.fileCaseOtherDescription)

            params(1) = New MySqlParameter("_filecaseResultDetail", parameter.filecaseResultDetail)

            params(2) = New MySqlParameter("_fileCaseCloseDate", parameter.fileCaseCloseDate)

            params(3) = New MySqlParameter("_fileCaseID", fileCaseId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filecasesUpdOtherDescription", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditResult(ByVal parameter As FileCaseResult) As Boolean

            Dim params(4) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseResult", parameter.fileCaseResult)

            params(1) = New MySqlParameter("_fileCaseID", parameter.fileCaseID)

            params(2) = New MySqlParameter("_filecaseResultDetail", parameter.filecaseResultDetail)

            params(3) = New MySqlParameter("_fileCaseGhararType", parameter.fileCaseGhararType)

            params(4) = New MySqlParameter("_fileCaseCost", parameter.fileCaseCost)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filecasesUpdResult", params)

            If db.HasError Then Return False

            Return True

        End Function

        'Public Shared Function GetAllGhararType() As Setting.SettingCollection

        '    Return Setting.SettingManager.GetSettingsByName("GhararType")

        'End Function

        Public Shared Function GetCurrentCaseByUserID(ByVal userId As String) As CurrentFileCaseCollection

            Dim list As New CurrentFileCaseCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_contactInfoID", userId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filecasesSelCurByContID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetCurrentFileCaseFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function DeleteAllInfoDfFileCase(ByVal fileID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_filecasesDelAllInfo", params))

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetAllTimingIDByFilecaseID(ByVal fileCaseId As String) As ArrayList

            Dim list As New ArrayList

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSetAllIDByFilecaseID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID").ToString)

            End While

            reader.Close()

            Return list

        End Function


        Public Shared Function GetFileCaseNumbers(ByVal fileCaseId As String) As FileCaseNumber

            Dim list As New FileCaseNumber

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileCaseID", fileCaseId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_filecasesSelNumberByID", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                list = GetFileCaseNumberFromReader(reader)

            End If

            reader.Close()

            Return list

        End Function

        Public Shared Function GetFileCaseDetailForTooltip(ByVal FileId As String) As DataSet

            Dim list As New FileCaseNumber

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", FileId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim ds As DataSet = db.GetDataSetFromProcedure("stpDad_filecasesSelDetailForTooltip", params)

            If db.HasError Then Return Nothing

            Return ds

        End Function

        Public Shared Sub WriteDefaultFiles(ByVal fType As Enums.FileCaseStep, ByVal deleteBefore As Boolean, ByVal fileCaseId As String)

            Try

                Dim fileId As String = FileDocManager.GetFileIdByTypeAndFilecaseID(Enums.FileType.دایرکتوری_اوراق, fileCaseId)

                If fileId = String.Empty Then

                    Exit Sub

                End If

                Dim l As TempDocReviewCollection = Nothing

                Select Case fType

                    Case Enums.FileCaseStep.بدوی

                        ' حذف فایل
                        If deleteBefore Then

                            DeleteDefaultFiles(fileId, Enums.FileCaseStep.بدوی)

                            DeleteDefaultFiles(fileId, Enums.FileCaseStep.تجدید)

                        End If

                        l = GetDefaultFilesByType(Enums.FileCaseStep.بدوی)

                        'ایجاد فایل 

                    Case Enums.FileCaseStep.تجدید

                        ' حذف فایل
                        If deleteBefore Then

                            DeleteDefaultFiles(fileId, Enums.FileCaseStep.بدوی)

                            DeleteDefaultFiles(fileId, Enums.FileCaseStep.تجدید)

                        End If

                        l = GetDefaultFilesByType(Enums.FileCaseStep.تجدید)

                    Case Enums.FileCaseStep.حقوقی

                        ' حذف فایل
                        If deleteBefore Then

                            DeleteDefaultFiles(fileId, Enums.FileCaseStep.حقوقی)

                            DeleteDefaultFiles(fileId, Enums.FileCaseStep.کیفری)

                        End If

                        l = GetDefaultFilesByType(Enums.FileCaseStep.حقوقی)

                    Case Enums.FileCaseStep.کیفری

                        ' حذف فایل
                        If deleteBefore Then

                            DeleteDefaultFiles(fileId, Enums.FileCaseStep.حقوقی)

                            DeleteDefaultFiles(fileId, Enums.FileCaseStep.کیفری)

                        End If

                        l = GetDefaultFilesByType(Enums.FileCaseStep.کیفری)

                    Case Enums.FileCaseStep.همه

                        l = GetDefaultFilesByType(Enums.FileCaseStep.همه)

                    Case Else

                        DeleteDefaultFiles(fileId)

                End Select

                Dim fileFullPath As String

                For Each Item As TempDocReview In l

                    Try

                        If Item.docFile IsNot Nothing AndAlso Item.docFile.Length > 0 Then

                            fileFullPath = FileManager.GetTempDocsFilesPath() & Item.docID & Item.docExtension

                            FileManager.GetFileFromBinaryFormat(Item.docFile, fileFullPath, False)

                        End If


                        FileDocManager.AddFileDocByAllValue(fileId, fileCaseId, DateManager.GetCurrentShamsiDateInNumericFormat(), DateManager.GetCurrentTime(), fileFullPath, Item, fType)

                    Catch ex As Exception

                    End Try

                Next

            Catch ex As Exception

            End Try

        End Sub

        Private Shared Sub DeleteDefaultFiles(ByVal fileId As String, ByVal type As Enums.FileCaseStep)

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileId)

            params(1) = New MySqlParameter("_fileDocType", type)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsDelbyIDAndType", params)

            If db.HasError Then Throw db.ErrorException

        End Sub


        Private Shared Sub DeleteDefaultFiles(ByVal fileId As String)

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fileID", fileId)

            params(1) = New MySqlParameter("_fileDocType", DBNull.Value)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_filedocsDelbyIDAndType", params)

            If db.HasError Then Throw db.ErrorException

        End Sub

        Private Shared Function GetDefaultFilesByType(ByVal type As Enums.FileCaseStep) As TempDocReviewCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("ftype", type)

            Dim l As New TempDocReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_tempdocsSelDefaultFileBytype", params)

            If db.HasError Then Return Nothing

            While reader.Read

                l.Add(GetTempDocReviewFromReader(reader))

            End While

            reader.Close()

            Return l

        End Function

        Public Shared Function Test() As FileCaseCollection

            Dim list As New FileCaseCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("testRpt2")

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetFileCaseFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

#End Region

#Region "Utility"

        Private Shared Function GetFileCaseFromReader(ByVal reader As IDataReader) As FileCase

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FileCase

            Dim id As New Guid

            id = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseAreaID")

            If id <> Guid.Empty Then
                parameter.fileCaseAreaID = id.ToString()
            End If

            'id = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseBranchID")

            'If id <> Guid.Empty Then
            '    parameter.fileCaseBranchID = id.ToString()
            'End If

            id = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseSubAreaID")

            If id <> Guid.Empty Then
                parameter.fileCaseSubAreaID = id.ToString()
            End If

            parameter.fileCaseID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID").ToString()

            parameter.fileCaseCat = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "fileCaseCat")

            parameter.fileCaseCloseDate = DbAccessLayer.MySqlDataHelper.GetNullableInt(reader, "fileCaseCloseDate")

            parameter.fileCaseComplainant = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "fileCaseComplainant")

            parameter.fileCaseDescription = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseDescription")

            parameter.fileCaseNumberInCourt = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInCourt")

            parameter.fileCaseNumberInSystem = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInSystem")

            parameter.fileCaseOpenDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "fileCaseOpenDate")

            parameter.fileCaseRelatedID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseRelatedID").ToString()

            Dim i As Int16? = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "fileCaseStep")

            If i.HasValue Then

                parameter.fileCaseStep = i

            Else

                parameter.fileCaseStep = -1

            End If

            '' ''parameter.fileCaseStep = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "fileCaseStep")

            parameter.fileCaseSubject = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseSubject")

            parameter.fileCaseType = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "fileCaseType")

            parameter.fileID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString()

            parameter.fileCaseLastAction = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseLastAction")

            parameter.fileCaseOtherDescription = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseOtherDescription")

            parameter.fileCaseResult = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseResult")

            parameter.filecaseResultDetail = DbAccessLayer.MySqlDataHelper.GetString(reader, "filecaseResultDetail")

            parameter.fileCaseGhararType = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseGhararType")

            parameter.fileCaseCost = DbAccessLayer.MySqlDataHelper.GetNullableDouble(reader, "fileCaseCost")

            '' ''parameter.fileCaseNumberYear = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberYear")

            parameter.fileCaseNumberInBranch = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInBranch")

            parameter.fileCasePass = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCasePass")

            Return parameter

        End Function

        Private Shared Function GetFileCaseNumberFromReader(ByVal reader As IDataReader) As FileCaseNumber

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FileCaseNumber

            parameter.fileCaseNumberInBranch = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInBranch")

            parameter.fileCaseNumberInCourt = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInCourt")

            parameter.fileCaseNumberInSystem = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInSystem")

            Return parameter

        End Function

        Private Shared Function GetCurrentFileCaseFromReader(ByVal reader As IDataReader) As CurrentFileCase

            If reader Is Nothing Then Return Nothing

            Dim parameter As New CurrentFileCase

            parameter.fileCaseID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID").ToString()

            Dim name As String = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseSubject")

            If name = String.Empty Then name = "وارد نشده"

            parameter.fileCaseSubject = name

            parameter.fileID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString()

            Return parameter

        End Function

        Private Shared Function GetTempDocReviewFromReader(ByVal reader As IDataReader) As TempDocReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New TempDocReview

            parameter.docExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "docExtension")

            parameter.docFile = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "docFile")

            parameter.docContent = DbAccessLayer.MySqlDataHelper.GetString(reader, "docContent")

            parameter.docID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "docID").ToString()

            parameter.docImageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "docImageID").ToString()

            parameter.docName = DbAccessLayer.MySqlDataHelper.GetString(reader, "docName")

            Return parameter

        End Function

#End Region

#Region "Reports"


        Public Shared Function GetReportBySubject(ByVal Query As String) As DataTable

            Dim list As New CurrentFileCaseCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("pQuery", Query)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_rptFilecaseSelBysubject", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function

        Public Shared Function GetReportByDaramad(ByVal Query1 As String, ByVal Query2 As String) As DataTable

            Dim list As New CurrentFileCaseCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("pQuery1", Query1)

            params(1) = New MySqlParameter("pQuery2", Query2)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_rptFileCaseByDaramad", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function

        Public Shared Function GetReportByHazine(ByVal Query1 As String, ByVal Query2 As String) As DataTable

            Dim list As New CurrentFileCaseCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("pQuery1", Query1)

            params(1) = New MySqlParameter("pQuery2", Query2)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_rptFileCaseByHazine", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function

        Public Shared Function GetReportByResult(ByVal Query1 As String, ByVal Query2 As String) As DataTable

            Dim list As New CurrentFileCaseCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("pQuery1", Query1)

            params(1) = New MySqlParameter("pQuery2", Query2)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_rptFileCaseSelByResult", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function

        Public Shared Function GetReportByOragh(ByVal Query1 As String, ByVal Query2 As String) As DataTable

            Dim list As New CurrentFileCaseCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("pQuery1", Query1)

            params(1) = New MySqlParameter("pQuery2", Query2)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_rptFileCaseSelByOragh", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function

        Public Shared Function GetReportByMoshavere(ByVal Query1 As String) As DataTable

            Dim list As New CurrentFileCaseCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("pQuery", Query1)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_rptFileCaseSelMoshToGharardad", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function


        Public Shared Function GetReportByMovakel(ByVal Query1 As String, ByVal Query2 As String) As FilecaseReportCollection

            Dim list As New FilecaseReportCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("pMovakel", Query1)

            params(1) = New MySqlParameter("pFilecase", Query2)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_rptFilecasesByMovakel", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetFileCaseReportFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetReportFinanceByMovakel(ByVal pfinance As String, ByVal pfilecase As String, ByVal pcontact As String) As DataTable

            Dim list As New FilecaseReportCollection

            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("pfinance", pfinance)

            params(1) = New MySqlParameter("pfilecase", pfilecase)

            params(2) = New MySqlParameter("pcontact", pcontact)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_rptFinanceByMovakel", params)

            Return dt

            'Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_rptFinanceByMovakel", params)

            'If db.HasError Then Return Nothing

            'While reader.Read

            '    list.Add(GetFileCaseReportFromReader(reader))

            'End While

            'reader.Close()

            'Return list

        End Function

        Private Shared Function GetFileCaseReportFromReader(ByVal reader As IDataReader) As FilecaseReport

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FilecaseReport

            parameter.fileCaseID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID").ToString()
            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")
            parameter.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID").ToString()
            parameter.davi = DbAccessLayer.MySqlDataHelper.GetString(reader, "davi")
            parameter.fileCaseCloseDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "fileCaseCloseDate")
            parameter.FileCaseNumber = DbAccessLayer.MySqlDataHelper.GetString(reader, "FileCaseNumber")
            parameter.fileCaseNumberInSystem = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInSystem")
            parameter.fileCaseOpenDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "fileCaseOpenDate")
            parameter.fileCaseStep1 = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "fileCaseStep")
            parameter.fileCaseSubject = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseSubject")
            parameter.fileRelationId = DbAccessLayer.MySqlDataHelper.GetInt(reader, "fileRelationId").ToString()
            parameter.status = DbAccessLayer.MySqlDataHelper.GetString(reader, "status")

            Return parameter

        End Function


#End Region

    End Class
End Namespace

