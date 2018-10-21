Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.ContactInfo
Imports Lawyer.Common.VB.Common

Namespace TimeParties

    Public Class TimePartiesManager

#Region "Methods"

        Public Shared Function AddParties(ByVal parameter As TimeParties) As Boolean

            Dim params(12) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

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

            params(10) = New MySqlParameter("_timeEnd", parameter.timeEnd)

            params(11) = New MySqlParameter("_timeReminderType", parameter.timeReminderType)

            params(12) = New MySqlParameter("_timeActualDate", parameter.timeActualDate)

            db.ExecuteProcedure("stpDad_timepartiesIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetTodayReminders(ByVal timeDate As Int32, ByVal userId As String) As TimePartiesReviewCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_timeDate", timeDate)

            params(1) = New MySqlParameter("_userId", userId)

            Dim list As New TimePartiesReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSelReminderByUserID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As TimePartiesReview = GetTimePartiesReviewFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetDesktopReminders(ByVal fromDate As Int32, ByVal toDate As Int32, ByVal userId As String) As DataTable

            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("_frmDate", fromDate)
            params(1) = New MySqlParameter("_toDate", toDate)
            params(2) = New MySqlParameter("_userId", userId)

            Dim list As New TimePartiesReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As DataTable = db.GetDataTableFromProcedure("Timing", "stpDad_timingDesktopSelAllByID", params)

            If db.HasError Then Return Nothing

            Return reader

        End Function

        Public Shared Function GetCurrentTiming() As TimePartiesReviewCollection

            Dim params(2) As MySqlParameter
            params(0) = New MySqlParameter("_tpTargetCustID", Login.CurrentLogin.CurrentUser.UserID)
            params(1) = New MySqlParameter("_timeDate", DateManager.GetCurrentShamsiDateInNumericFormat())
            params(2) = New MySqlParameter("_timeActualTime", DateManager.GetCurrentTime())

            Dim list As New TimePartiesReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSelCurrentTiming", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As TimePartiesReview = GetTimePartiesReviewFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function


        'Public Shared Function TimingSearchByTiming(ByVal tpWhere As String, ByVal tWhere As String, ByVal fcWhere As String, ByVal fileCaseMode As Boolean) As TimePartiesReviewCollection

        '    Dim params(1) As MySqlParameter

        '    params(0) = New MySqlParameter("_timeDate", timeDate)

        '    params(1) = New MySqlParameter("_userId", userId)

        '    Dim list As New TimePartiesReviewCollection

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSelReminderByUserID", params)

        '    If db.HasError Then Return Nothing

        '    While reader.Read

        '        Dim child As TimePartiesReview = GetTimePartiesReviewFromReader(reader)

        '        list.Add(child)

        '    End While

        '    Return list

        'End Function

        Public Shared Function IsUserBusy(ByVal userId As String, ByVal taskDate As Integer, ByVal taskTime As String) As Int32

            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("_tpTargetCustID", userId)
            params(1) = New MySqlParameter("_timeDate", taskDate)
            params(2) = New MySqlParameter("_time", taskTime)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_timepartiesUtiCheckTask", params))

            If db.HasError Then Return 1

            Return result

        End Function

        Public Shared Function IsUserBusyForEdit(ByVal userId As String, ByVal taskDate As Integer, ByVal taskTime As String, ByVal timeId As String) As Int32

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_tpTargetCustID", userId)
            params(1) = New MySqlParameter("_timeDate", taskDate)
            params(2) = New MySqlParameter("_time", taskTime)
            params(3) = New MySqlParameter("_timeId", timeId)

            Dim list As New KartablCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_timepartiesUtiCheckTask2", params))

            If db.HasError Then Return 1

            Return result

        End Function


        Public Shared Function GetUserKartabl(ByVal userId As String) As KartablCollection

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_userId", userId)

            params(1) = New MySqlParameter("_curDate", Common.DateManager.GetCurrentShamsiDateInNumericFormat())

            Dim list As New KartablCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingSelKartablByUserID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As Kartabl = GetKartablFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function TimingSearchByMessage(ByVal tpWhere As String, ByVal tWhere As String, ByVal fcWhere As String, ByVal fileCaseMode As Boolean) As Timing.TimingFullSearchCollection

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_filecaseMode", IIf(fileCaseMode, 1, 0))
            params(1) = New MySqlParameter("_tQuery", tWhere)
            params(2) = New MySqlParameter("_tpQuery", tpWhere)
            params(3) = New MySqlParameter("_fcQuery", fcWhere)

            Dim list As New Timing.TimingFullSearchCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingsearch", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As Timing.TimingFullSearch = GetTimingFullSearchFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function

        'Public Shared Function TimingSearchByMessage(ByVal tpWhere As String, ByVal tWhere As String, ByVal fcWhere As String, ByVal fileCaseMode As Boolean) As KartablCollection

        '    Dim params(3) As MySqlParameter

        '    params(0) = New MySqlParameter("_filecaseMode", IIf(fileCaseMode, 1, 0))
        '    params(1) = New MySqlParameter("_tQuery", tWhere)
        '    params(2) = New MySqlParameter("_tpQuery", tpWhere)
        '    params(3) = New MySqlParameter("_fcQuery", fcWhere)

        '    Dim list As New KartablCollection

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingsearch", params)

        '    If db.HasError Then Return Nothing

        '    While reader.Read

        '        Dim child As Kartabl = GetKartablFromReader(reader)

        '        list.Add(child)

        '    End While

        '    reader.Close()

        '    Return list

        'End Function

        Public Shared Function TimingSearchByAlarm(ByVal tpWhere As String, ByVal tWhere As String, ByVal fcWhere As String, ByVal fileCaseMode As Boolean) As KartablCollection

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_filecaseMode", IIf(fileCaseMode, 1, 0))
            params(1) = New MySqlParameter("_tQuery", tWhere)
            params(2) = New MySqlParameter("_tpQuery", tpWhere)
            params(3) = New MySqlParameter("_fcQuery", fcWhere)

            Dim list As New KartablCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timingsearch_time", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As Kartabl = GetKartablFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function EditTimingDoneField(ByVal tpId As String, ByVal timeDone As Boolean) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_tpID", tpId)

            params(1) = New MySqlParameter("_timeDone", timeDone)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_timePartiesUpdDone", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetKartablByIDForView(ByVal tpID As String) As KartablDetail

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpID", tpID)

            Dim k As New KartablDetail

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timepartiesSelKartablForView", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                k = GetKartablDetailFromReader(reader)

            End If

            reader.Close()

            Return k

        End Function

        Public Shared Function GetKartablSender(ByVal tpID As String) As ContactInfoReview

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpID", tpID)

            Dim k As New ContactInfoReview

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timepartiesSelSender", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                k = GetContactInfoReviewFromReader(reader)

            End If

            reader.Close()

            Return k

        End Function

        Public Shared Function GetTimePartiesInfoByID(ByVal tpID As String) As TimeParties

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_tpID", tpID)

            Dim t As New TimeParties

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timepartiesSelAllByID", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                t = GetTimePartiesForEditFromReader(reader)

            End If

            reader.Close()

            Return t

        End Function

        Public Shared Function EditParties(ByVal parameter As TimeParties) As Boolean

            Dim params(10) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            params(0) = New MySqlParameter("_tpID", parameter.tpID)

            params(1) = New MySqlParameter("_timeDate", parameter.timeDate)

            params(2) = New MySqlParameter("_timeTime", parameter.timeTime)

            params(3) = New MySqlParameter("_timeReminderBefore", IIf(parameter.timeReminderBefore = String.Empty, DBNull.Value, parameter.timeReminderBefore))

            params(4) = New MySqlParameter("_timeStatus", IIf(parameter.timeStatus = String.Empty, DBNull.Value, parameter.timeStatus))

            params(5) = New MySqlParameter("_timeActualTime", parameter.timeActualTime)

            params(6) = New MySqlParameter("_timeDuration", IIf(parameter.timeDuration = String.Empty, DBNull.Value, parameter.timeDuration))

            params(7) = New MySqlParameter("_timeEnd", parameter.timeEnd)

            params(8) = New MySqlParameter("_timeDone", parameter.timeDone)

            params(9) = New MySqlParameter("_timeActualDate", parameter.timeActualDate)

            params(10) = New MySqlParameter("_timeReminderType", parameter.timeReminderType)

            db.ExecuteProcedure("stpDad_timepartiesUpd", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function EditReminder(ByVal parameter As TimeParties) As Boolean

            Dim params(10) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            params(0) = New MySqlParameter("_tpID", parameter.tpID)

            params(3) = New MySqlParameter("_timeReminderBefore", IIf(parameter.timeReminderBefore = String.Empty, DBNull.Value, parameter.timeReminderBefore))

            params(5) = New MySqlParameter("_timeActualTime", parameter.timeActualTime)

            params(6) = New MySqlParameter("_timeDuration", IIf(parameter.timeDuration = String.Empty, DBNull.Value, parameter.timeDuration))

            params(7) = New MySqlParameter("_timeEnd", parameter.timeEnd)

            params(8) = New MySqlParameter("_timeDone", parameter.timeDone)

            params(9) = New MySqlParameter("_timeActualDate", parameter.timeActualDate)

            params(10) = New MySqlParameter("_timeReminderType", parameter.timeReminderType)

            db.ExecuteProcedure("stpDad_timepartiesUpdReminder", params)

            If db.HasError Then Return False

            Return True

        End Function
        Public Shared Function EditPartiesByMoshavere(ByVal parameter As TimeParties) As Boolean

            Dim params(11) As MySqlParameter

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            params(0) = New MySqlParameter("_tpID", parameter.tpID)

            params(1) = New MySqlParameter("_timeDate", parameter.timeDate)

            params(2) = New MySqlParameter("_timeTime", parameter.timeTime)

            params(3) = New MySqlParameter("_timeReminderBefore", IIf(parameter.timeReminderBefore = String.Empty, DBNull.Value, parameter.timeReminderBefore))

            params(4) = New MySqlParameter("_timeStatus", IIf(parameter.timeStatus = String.Empty, DBNull.Value, parameter.timeStatus))

            params(5) = New MySqlParameter("_timeActualTime", parameter.timeActualTime)

            params(6) = New MySqlParameter("_timeDuration", IIf(parameter.timeDuration = String.Empty, DBNull.Value, parameter.timeDuration))

            params(7) = New MySqlParameter("_timeEnd", parameter.timeEnd)

            params(8) = New MySqlParameter("_timeDone", parameter.timeDone)

            params(9) = New MySqlParameter("_tpTargetCustID", parameter.tpTargetCustID)

            params(10) = New MySqlParameter("_timeActualDate", parameter.timeActualDate)

            params(11) = New MySqlParameter("_timeReminderType", parameter.timeReminderType)


            db.ExecuteProcedure("stpDad_timepartiesUpdMoshavere", params)

            If db.HasError Then Return False

            Return True

        End Function
        Public Shared Function GetAllPartiesByTiming(ByVal tmieId As String) As ContactInfoReviewCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", tmieId)

            Dim k As New ContactInfoReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_timepartiesSelByTimeID", params)

            If db.HasError Then Return Nothing

            While reader.Read

                k.Add(GetContactInfoReviewFromReader(reader))

            End While

            reader.Close()

            Return k

        End Function



#End Region

#Region "Utility"

        Private Shared Function GetTimePartiesReviewFromReader(ByVal reader As IDataReader) As TimePartiesReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New TimePartiesReview

            parameter.timeTypeName = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTypeName")

            parameter.timeActualTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeActualTime")

            parameter.timeTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTime")

            parameter.timeDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDate").ToString()

            parameter.timeTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle")

            parameter.timeDone = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "timeDone")

            parameter.tpID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpID").ToString()

            parameter.timeType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeType")

            Return parameter

        End Function

        Private Shared Function GetKartablFromReader(ByVal reader As IDataReader) As Kartabl

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Kartabl

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.timeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID").ToString

            parameter.timeDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDate")

            parameter.timeTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle")

            parameter.tpID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpID").ToString()

            parameter.fileCaseNumber = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumber")

            Return parameter

        End Function


        Private Shared Function GetTimingFullSearchFromReader(ByVal reader As IDataReader) As Timing.TimingFullSearch

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Timing.TimingFullSearch

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.timeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID").ToString

            parameter.timeDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDate")

            parameter.timeTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle")

            parameter.tpID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpID").ToString()

            parameter.timeDone = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "timeDone")
            parameter.timeText = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeText")
            parameter.timeTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTime")
            parameter.timeType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "timeType")

            parameter.fileCaseNumberInBranch = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInBranch")
            parameter.fileCaseNumberInCourt = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInCourt")
            parameter.fileCaseNumberInSystem = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberInSystem")
            parameter.fileCaseNumberYear = DbAccessLayer.MySqlDataHelper.GetString(reader, "fileCaseNumberYear")

            Return parameter

        End Function

        Private Shared Function GetKartablDetailFromReader(ByVal reader As IDataReader) As KartablDetail

            If reader Is Nothing Then Return Nothing

            Dim parameter As New KartablDetail

            parameter.sender = DbAccessLayer.MySqlDataHelper.GetString(reader, "sender")

            parameter.timeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID").ToString

            parameter.timeDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDate")

            parameter.timeTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTitle")

            parameter.timeText = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeText")

            parameter.timeSourceCustID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeSourceCustID").ToString()

            parameter.tpTargetCustID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpTargetCustID").ToString()

            parameter.timeTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTime")

            Return parameter

        End Function

        Private Shared Function GetContactInfoReviewFromReader(ByVal reader As IDataReader) As ContactInfoReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New ContactInfoReview

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID").ToString()

            Return parameter

        End Function

        Private Shared Function GetTimePartiesForEditFromReader(ByVal reader As IDataReader) As TimeParties

            If reader Is Nothing Then Return Nothing

            Dim parameter As New TimeParties

            Dim i32 As Int32?

            Dim i16 As Int16?

            parameter.timeDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDate")

            parameter.timeDone = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "timeDone")

            i32 = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeDuration")

            If i32.HasValue Then parameter.timeDuration = i32

            parameter.timeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID").ToString

            i32 = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeReminderBefore")

            If i32.HasValue Then parameter.timeReminderBefore = i32

            i16 = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "timeStatus")

            If i16.HasValue Then parameter.timeStatus = i16

            parameter.timeTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "timeTime")

            parameter.tpTargetCustID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "tpTargetCustID").ToString

            parameter.timeReminderType = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "timeReminderType")

            parameter.timeActualDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "timeActualDate")

            Return parameter

        End Function

#End Region

    End Class
End Namespace

