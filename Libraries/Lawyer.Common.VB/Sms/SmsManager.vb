Imports Lawyer.Common.VB.CommonSetting

Public Class SmsManager

    Public Shared Function getSmsTemplateText() As System.Data.DataTable

        Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
        Dim cmd As String = "select * from smstemptext"

        Dim dt As DataTable = db.GetDataTableFromSqlCommandText("smstemptext", cmd, Nothing)
        If db.HasError Then Return Nothing

        Return dt

    End Function

    Public Shared Function addSmsTemplate(ByVal smsText As String) As Integer

        Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
        Dim cmd As String = "insert into smstemptext(`smstext`) values('" & smsText & "')"

        Dim rz As Integer = db.ExecuteSqlCommandText(cmd, Nothing)
        If db.HasError Then Return 0

        Return 1

    End Function

    Public Shared Function deleteSmsTemplate(ByVal ID As Integer) As Integer

        Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
        Dim cmd As String = "delete from smstemptext where smsTempID= " & ID & ""

        Dim rz As Integer = db.ExecuteSqlCommandText(cmd, Nothing)
        If db.HasError Then Return 0

        Return 1

    End Function

    Public Shared Function getReceiverListOfParvade(ByVal filecaseID As String) As DataTable

        Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
        Dim cmd As String = "select custid as receiverID,custfullname as receiverName,custcellphone as receiverNumber, filecases.filecaseid,'' as timeid,filecases.filecasenumberinsystem  as smsSubject from filecases join fileparties on filecases.filecaseid=fileparties.filecaseid join contactinfo on contactinfoid=custid and (custtype=0 or custtype=4) and custcellphone is not null where filecases.filecaseID='" & filecaseID & "';"

        Dim dt As DataTable = db.GetDataTableFromSqlCommandText("timing", cmd, Nothing)
        If db.HasError Then Return Nothing

        Return dt

    End Function

    Public Shared Function getReceiverListOfTiming(ByVal timeID As String) As DataTable

        Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
        Dim cmd As String = "select custid as receiverID,custfullname as receiverName,custcellphone as receiverNumber,filecaseid,timing.timeid,timetitle as smsSubject from timing join timeparties on timing.timeid=timeparties.timeid join contactinfo on custid=timeparties.tptargetcustid and custcellphone is not null where timing.timeid='" & timeID & "';"

        Dim dt As DataTable = db.GetDataTableFromSqlCommandText("timing", cmd, Nothing)
        If db.HasError Then Return Nothing

        Return dt

    End Function

    Public Shared Function sendSms(ByVal receiverID As String, ByVal receiverName As String, ByVal receiverNumber As String, ByVal fileCaseID As String, ByVal timeID As String,
                                   ByVal smsSubject As String, ByVal smsText As String) As Integer

        Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        Dim cmd As String = "INSERT INTO `nwdicdad2`.`smsoutbox` (`receiverID`, `receiverName`,`receiverNumber`,`fileCaseID`,`timeID`,`smsSubject`,`smsText`,`smsDateTime`,`smsStatus`)"
        cmd += " VALUES ('" & receiverID & "','" & receiverName & "','" & receiverNumber & "', '" & fileCaseID & "', '" & timeID & "', '" & smsSubject & " پرونده شماره:', '" & smsText & "', '" & DateTime.Now & "',0);"

        Dim rz As Integer = db.ExecuteSqlCommandText(cmd, Nothing)
        If db.HasError Then Return 0

        Return rz

    End Function

    Public Shared Function getSmsConfig() As Boolean

        Dim sc As Lawyer.Common.VB.Setting.SettingCollection = Lawyer.Common.VB.Setting.SettingManager.GetSettingsByName("smsConfig")
        Return Convert.ToBoolean(Convert.ToInt32(sc(0).settingValue))

    End Function

    Public Shared Function setSmsConfig(ByVal value As String) As Integer

        Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        Dim cmd As String = "update settings set settingValue='" + value + "' where settinggroupid='e99f1eaa-de4c-11e3-a32e-05bea91365c3'"

        Dim rz As Integer = db.ExecuteSqlCommandText(cmd, Nothing)
        If db.HasError Then Return 0

        Return rz

    End Function






End Class
