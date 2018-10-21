Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Common


Namespace Timing
    Public Class TimingManager

#Region "Methods"

        Public Shared Function AddTiming(ByVal parameter As Timing) As Boolean

            Dim params(9) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", parameter.timeID)

            params(1) = New MySqlParameter("_fileID", IIf(parameter.fileID = String.Empty, DBNull.Value, parameter.fileID))

            params(2) = New MySqlParameter("_fileCaseID", IIf(parameter.fileCaseID = String.Empty, DBNull.Value, parameter.fileCaseID))

            params(3) = New MySqlParameter("_timeType", parameter.timeType)

            params(4) = New MySqlParameter("_timeText", IIf(parameter.timeText = String.Empty, DBNull.Value, parameter.timeText))

            params(5) = New MySqlParameter("_timeSourceCustID", parameter.timeSourceCustID)

            params(6) = New MySqlParameter("_timeTitle", IIf(parameter.timeTitle = String.Empty, DBNull.Value, NwdSolutions.Web.GeneralUtilities.General.DbReplace(parameter.timeTitle)))

            params(7) = New MySqlParameter("_timingNo", IIf(parameter.timingNo = String.Empty, DBNull.Value, parameter.timingNo))

            params(8) = New MySqlParameter("_timeSms", parameter.timeSms)

            params(9) = New MySqlParameter("_timeNet", parameter.timeNet)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_timingIns", params)

            If db.HasError Then Return False

            Return True

        End Function


        ''' <summary>
        ''' Timing Type 
        ''' های مربوط به یک پرونده
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetFileCaseTimingType() As Setting.SettingCollection

            Return Setting.SettingManager.GetSettingsByName("TimingType")

        End Function

        Public Shared Function GetTimingStatus() As Setting.SettingCollection

            Return Setting.SettingManager.GetSettingsByName("TimingStatus")

        End Function

        Public Shared Function GetTodayMessages(ByVal timeDate As Int32) As TimingReviewCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeDate", timeDate)

            Dim list As New TimingReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSelMessages", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim t As TimingReview = GetTimingReviewFromReader(reader)

                list.Add(t)

            End While

            Return list

        End Function

        Public Shared Function EditTimingDoneField(ByVal timeId As Integer, ByVal timeDone As Boolean) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", timeId)

            params(1) = New MySqlParameter("_timeDone", timeDone)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_timingUpdDone", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditTiming_Moshavere(ByVal moshavere As Timing) As Boolean

            Dim params(5) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", moshavere.timeID)

            params(1) = New MySqlParameter("_timeTitle", moshavere.timeTitle)

            params(2) = New MySqlParameter("_timeText", moshavere.timeText)

            params(3) = New MySqlParameter("_timingNo", moshavere.timingNo)

            params(4) = New MySqlParameter("_timeSms", moshavere.timeSms)

            params(5) = New MySqlParameter("_timeNet", moshavere.timeNet)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_timingUpd", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function TiminigHasDocs(ByVal timeId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_deskTimeID", timeId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Boolean = CBool(db.GetScalarFromProcedure("stpDad_deskdocsUtiIsExistsByTimeID", params))

            If db.HasError Then Return False

            Return result

        End Function

        Public Shared Function GetTypeName(ByVal type As Int16) As String


            Select Case type

                Case 0

                    Return "وقت نظارت پرونده"
                Case 1
                    Return "وقت پیگیری پرونده"
                Case 2
                    Return "وقت رسیدگی"
                Case 3
                    Return "جلسه"
                Case 4
                    Return "مشاوره"
                Case 5
                    Return "کار"
                Case 6
                    Return "مکاتبات"

                Case 7

                    Return "اخطاریه"

            End Select


        End Function

        Public Shared Function GetTimingInfoByID(ByVal timeID As String) As Timing

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", timeID)

            Dim t As New Timing

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSelAllByID", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                t = GetTimingFromReader(reader)

            End If

            Return t

        End Function

        Public Shared Function DeleteTiming(ByVal timeId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", timeId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_timingDel", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function DeleteTimingDoc(ByVal docID As String, ByVal timeId As String) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", timeId)

            params(1) = New MySqlParameter("_deskDocID", docID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_deskdocsDelByID", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetTimingCreator(ByVal timeID As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", timeID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim creator As String = db.GetScalarFromProcedure("stpDad_timingSelCreator", params).ToString()

            If db.HasError Then Return Nothing

            Return creator

        End Function

        'Public Shared Function TimingSearch(ByVal tpWhere As String, ByVal tWhere As String, ByVal fcWhere As String, ByVal fileCaseMode As Boolean) As TimingSearchCollection

        '    Dim params(3) As MySqlParameter

        '    params(0) = New MySqlParameter("_filecaseMode", IIf(fileCaseMode, 1, 0))
        '    params(1) = New MySqlParameter("_tQuery", tWhere)
        '    params(2) = New MySqlParameter("_tpQuery", tpWhere)
        '    params(3) = New MySqlParameter("_fcQuery", fcWhere)

        '    Dim list As New TimingSearchCollection

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingsearch_time", params)

        '    If db.HasError Then Return Nothing

        '    While reader.Read

        '        list.Add(GetTimingSearchFromReader(reader))

        '    End While

        '    reader.Close()

        '    Return list

        'End Function

        Public Shared Function TimingSearch(ByVal tpWhere As String, ByVal tWhere As String, ByVal fcWhere As String, ByVal fileCaseMode As Boolean) As TimingFullSearchCollection

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_filecaseMode", IIf(fileCaseMode, 1, 0))
            params(1) = New MySqlParameter("_tQuery", tWhere)
            params(2) = New MySqlParameter("_tpQuery", tpWhere)
            params(3) = New MySqlParameter("_fcQuery", fcWhere)

            Dim list As New TimingFullSearchCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingsearch_time", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetTimingFullSearchFromReader(reader))

            End While

            reader.Close()

            ' '' ''Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_timingsearch_time", params)

            ' '' ''If db.HasError Then Throw db.ErrorException

            ' '' ''Return dt
            Return list

        End Function

        Public Shared Function MoshavereSearchByFileCase(ByVal _financeCustID As String) As MoshavereSearchCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_financeCustID", _financeCustID)


            Dim list As New MoshavereSearchCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSearchMoshavereByFilecase", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetMoshavereSearchByFilecaseFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function MoshavereSearch(ByVal _fQuery As String, ByVal _tpQuery As String) As MoshavereSearchCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_fQuery", _fQuery)

            params(1) = New MySqlParameter("_tpQuery", _tpQuery)

            Dim list As New MoshavereSearchCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSearchMoshavere", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetMoshavereSearchByFilecaseFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function


        'Public Shared Function TimingSearch() As ArrayList

        '    Dim params(2) As MySqlParameter

        '    params(0) = New MySqlParameter("_tpTargetCustID", Login.CurrentLogin.CurrentUser.UserID)
        '    params(1) = New MySqlParameter("_timeDate", DateManager.GetCurrentShamsiDateInNumericFormat())
        '    params(2) = New MySqlParameter("_timeActualTime", DateManager.GetCurrentTime())


        '    Dim list As New ArrayList

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSelCurrentTiming", params)

        '    If db.HasError Then Return Nothing

        '    While reader.Read

        '        list.Add(DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle") + " " + DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTime"))

        '    End While

        '    reader.Close()

        '    Return list

        'End Function

        Public Shared Function TimingSearchByFilecaseId(ByVal filecaseId As String, ByVal userId As String) As TimingFullSearchCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_filecaseID", filecaseId)

            params(1) = New MySqlParameter("_tpTargetCustID", userId)
          
            Dim list As New TimingFullSearchCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSearchByFilecaseId", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetTimingFullSearchByfilecaseFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function IsExistTiminglistByTimingType(ByVal _timeType As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeType", _timeType)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Long = CLng(db.GetScalarFromProcedure("stpDad_timingUtiIsExistRecByType", params))

            If db.HasError Then Return False

            If result = 0 Then

                Return True

            End If

            Return False

        End Function
       
        Public Shared Function GetMoshavereInfoByID(ByVal timId As String) As DataTable

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeid", timId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_rptTimingSelmoshavere", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function



        
#End Region

#Region "Utility"

        Private Shared Function GetTimingReviewFromReader(ByVal reader As IDataReader) As TimingReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New TimingReview

            parameter.description = DbAccessLayer.MySqlDataHelper.GetString(reader, "description")

            parameter.timeID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeID")

            Return parameter

        End Function

        Private Shared Function GetTimingFromReader(ByVal reader As IDataReader) As Timing

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Timing

            parameter.fileCaseID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID").ToString()

            parameter.fileID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID").ToString()

            parameter.timeSourceCustID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeSourceCustID").ToString()

            parameter.timeText = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeText")

            parameter.timeTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle")

            parameter.timeType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeType")

            parameter.timingNo = DbAccessLayer.MySqlDataHelper.GetString(reader, "timingNo")

            parameter.timeNet = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeNet")

            parameter.timeSms = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeSms")

            Return parameter

        End Function

        Private Shared Function GetTimingSearchFromReader(ByVal reader As IDataReader) As TimingSearch

            If reader Is Nothing Then Return Nothing

            Dim parameter As New TimingSearch

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.timeDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDate")

            parameter.timeDone = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "timeDone")

            parameter.timeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID").ToString()

            parameter.timeTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTime")

            parameter.timeTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle")

            parameter.tpID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpID").ToString()

            parameter.fileCaseNumber = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumber")

            parameter.timeNet = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeNet")

            parameter.timeSms = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeSms")

            Return parameter

        End Function

        Private Shared Function GetTimingFullSearchFromReader(ByVal reader As IDataReader) As TimingFullSearch

            If reader Is Nothing Then Return Nothing

            Dim parameter As New TimingFullSearch


            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")
            parameter.targetcustName = DbAccessLayer.MySqlDataHelper.GetString(reader, "targetcustName")

            parameter.timeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID").ToString

            parameter.timeDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDate")

            parameter.timeTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle")

            parameter.tpID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpID").ToString()

            parameter.timeDone = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "timeDone")
            parameter.timeText = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeText")
            parameter.timeTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTime")
            parameter.timeType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeType")
            ' ''parameter.timeNet = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeNet")
            ' ''parameter.timeSms = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeSms")

            parameter.fileCaseNumberInBranch = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInBranch")
            parameter.fileCaseNumberInCourt = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInCourt")
            parameter.fileCaseNumberInSystem = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInSystem")

            parameter.timeTypeName = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTypeName")

            parameter.filecaseid = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "filecaseid").ToString

            Return parameter

        End Function

        Private Shared Function GetMoshavereSearchByFilecaseFromReader(ByVal reader As IDataReader) As MoshavereSearch

            If reader Is Nothing Then Return Nothing

            Dim parameter As New MoshavereSearch

            parameter.timeDone = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "timeDone")

            parameter.timeTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle")

            parameter.sender = DbAccessLayer.MySqlDataHelper.GetString(reader, "sender")

            parameter.timeDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDate")

            parameter.timeTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTime")

            parameter.financeAmount = DbAccessLayer.MySqlDataHelper.GetDouble(reader, "financeAmount")

            parameter.reciever = DbAccessLayer.MySqlDataHelper.GetString(reader, "reciever")

            parameter.timeText = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeText")

            parameter.movakel = DbAccessLayer.MySqlDataHelper.GetString(reader, "movakel")

            parameter.tpid = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpid").ToString()

            parameter.financeCustID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "financeCustID").ToString()

            Return parameter

        End Function

        

        Private Shared Function GetTimingFullSearchByfilecaseFromReader(ByVal reader As IDataReader) As TimingFullSearch

            If reader Is Nothing Then Return Nothing

            Dim parameter As New TimingFullSearch

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.timeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID").ToString

            parameter.timeDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDate")

            parameter.timeTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle")

            parameter.tpID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpID").ToString()

            parameter.timeDone = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "timeDone")

            parameter.timeText = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeText")

            parameter.timeTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTime")

            parameter.timeType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeType")

            parameter.timeTypeName = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTypeName")

            Try
                parameter.timeNet = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeNet")

                parameter.timeSms = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeSms")

            Catch ex As Exception
                parameter.timeNet = 0

                parameter.timeSms = 0

            End Try
           
            Return parameter

        End Function


#End Region

#Region "TimeDocs"

        Public Shared Function AddTimeDocs(ByVal parameter As deskDocs) As Boolean

            Dim params(5) As MySqlParameter

            params(0) = New MySqlParameter("_deskDocBinary", Common.FileManager.GetFileInBinaryFormat(parameter.FileFullPath, parameter.deskDocID, True))

            params(1) = New MySqlParameter("_deskDocExtension", parameter.deskDocExtension)

            params(2) = New MySqlParameter("_deskDocID", parameter.deskDocID)

            params(3) = New MySqlParameter("_deskDocName", parameter.deskDocName)

            params(4) = New MySqlParameter("_deskImageID", parameter.deskImageID)

            params(5) = New MySqlParameter("_deskTimeID", parameter.deskTimeID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_deskdocsIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditTimeDocs(ByVal fileFullPath As String, ByVal fileName As String, ByVal conString As String) As Boolean

            Dim fi As New System.IO.FileInfo(fileFullPath)
            Dim ID As String = System.IO.Path.GetFileNameWithoutExtension(fi.Name)
            Dim extension = fi.Extension

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_deskDocBinary", Common.FileManager.GetFileInBinaryFormat(fileFullPath))

            params(1) = New MySqlParameter("_deskDocExtension", extension)

            params(2) = New MySqlParameter("_deskDocID", ID)

            params(3) = New MySqlParameter("_deskDocName", fileName)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(conString, DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_deskdocsUpd", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetAllTimingDeskDocs(ByVal deskTimeID As String) As DeskDocsReviewCollection

            Dim params(0) As MySqlParameter
            Dim list As New DeskDocsReviewCollection

            params(0) = New MySqlParameter("_deskTimeID", deskTimeID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_deskdocsSelAllByTimeID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As DeskDocsReview = GetDeskDocsReviewFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetAllForwardTimingDeskDocs(ByVal deskTimeID As String) As DeskDocsCollection

            Dim params(0) As MySqlParameter

            Dim list As New DeskDocsCollection

            params(0) = New MySqlParameter("_deskTimeID", deskTimeID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_deskdocsSel_Forward", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(GetDeskDocsFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

        Private Shared Function GetDeskDocsReviewFromReader(ByVal reader As IDataReader) As DeskDocsReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New DeskDocsReview

            parameter.deskDocID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "deskDocID").ToString

            parameter.deskDocName = DbAccessLayer.MySqlDataHelper.GetString(reader, "deskDocName")

            parameter.deskImageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "deskImageID").ToString

            Return parameter

        End Function


        Private Shared Function GetDeskDocsFromReader(ByVal reader As IDataReader) As deskDocs

            If reader Is Nothing Then Return Nothing

            Dim parameter As New deskDocs

            parameter.deskDocBinary = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "deskDocBinary")

            parameter.deskDocExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "deskDocExtension")

            parameter.deskDocID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "deskDocID").ToString

            parameter.deskDocName = DbAccessLayer.MySqlDataHelper.GetString(reader, "deskDocName")

            parameter.deskImageID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "deskImageID").ToString

            parameter.deskTimeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "deskTimeID").ToString

            If parameter.deskDocBinary IsNot Nothing AndAlso parameter.deskDocBinary.Length > 0 Then

                parameter.FileFullPath = FileManager.GetTimingFilesPath() & parameter.deskDocID & parameter.deskDocExtension

                FileManager.GetFileFromBinaryFormat(parameter.deskDocBinary, parameter.FileFullPath, False, True)

            End If

            Return parameter

        End Function

        Public Shared Function WriteFile(ByVal ID As String) As String

            Dim params(0) As MySqlParameter


            Dim content() As Byte = Nothing

            Dim extension As String = String.Empty

            params(0) = New MySqlParameter("_deskDocID", ID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_deskdocsSelDocContent", params)

            If db.HasError Then Return Nothing

            While reader.Read

                content = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "deskDocBinary")

                extension = DbAccessLayer.MySqlDataHelper.GetString(reader, "deskDocExtension")

            End While

            reader.Close()

            If content IsNot Nothing AndAlso content.Length > 0 Then

                Dim fileFullPath As String = FileManager.GetTimingFilesPath() & ID & extension

                FileManager.GetFileFromBinaryFormat(content, fileFullPath, False, True)

                Return fileFullPath

            End If

            Return Nothing


        End Function



#End Region

    End Class
End Namespace

