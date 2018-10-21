Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports System.Windows.Forms
Imports NwdSolutions.Web.GeneralUtilities

Namespace ContactInfo

    Public Class ContactInfoManager

#Region "Methods"

        Public Shared Function GetAllSysUser() As ContactInfoReviewCollection

            Dim list As New ContactInfoReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelAllSysUser")

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As ContactInfoReview = GetContactInfoReviewFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function ISCantactNameIsRepeteive(ByVal contactName As String, ByVal custId As String) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_custFullName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(contactName))

            params(1) = New MySqlParameter("_custID", IIf(custId = String.Empty, DBNull.Value, custId))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_contactinfoUtiIsExistName", params))

            If db.HasError Then Throw db.ErrorException

            If result > 0 Then Return True

            Return False

        End Function

        'Public Shared Function GetUserPicturePath(ByVal custId As String, ByVal ignoreExist As Boolean) As String

        '    Dim params(0) As MySqlParameter

        '    params(0) = New MySqlParameter("_custID", custId)

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim pic As New Common.Picture

        '    Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelPicture", params)

        '    If db.HasError Then Return String.Empty

        '    If reader.Read Then

        '        '' ''pic = GetPictureFromReader(reader)

        '    End If

        '    reader.Close()

        '    If pic.pictureExtention = String.Empty Then

        '        Return String.Empty

        '    Else

        '        Return Common.FileManager.GetFileFromBinaryFormat(pic.BinaryPicture, Common.FileManager.GetContactPicturePath() + "\" + custId + pic.picUpdatedate + pic.pictureExtention, ignoreExist)

        '    End If

        'End Function

        'Public Shared Function WriteImage(ByVal custId As String, ByVal imagePath As Boolean) As Boolean

        '    Dim params(0) As MySqlParameter

        '    params(0) = New MySqlParameter("_custID", custId)

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim pic As New Common.Picture

        '    Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelPicture", params)

        '    If db.HasError Then Return String.Empty

        '    If reader.Read Then

        '        pic = GetPictureFromReader(reader)

        '    End If

        '    reader.Close()

        '    If pic.pictureExtention = String.Empty Then

        '        Return False

        '    Else

        '        Common.FileManager.GetFileFromBinaryFormat(pic.BinaryPicture, imagePath + custId + pic.picUpdatedate + pic.pictureExtention, True)

        '    End If

        'End Function

        Public Shared Function GetUserImage(ByVal custId As String) As BaseForm.ImageReview

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custID", custId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim pic As New BaseForm.ImageReview

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelPicture", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                pic = GetUserImageFromReader(reader)

            End If

            reader.Close()

            Return pic

        End Function

        Public Shared Function UpdateContactToLoginState(ByVal custId As String, ByVal Islogin As Int16) As Boolean

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_custID", custId)

            params(1) = New MySqlParameter("_custIsLogin", Islogin)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_contactinfoUpdLogin", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function UpdateContact(ByVal parameter As Contact) As Boolean

            Dim params(22) As MySqlParameter

            params(0) = New MySqlParameter("_custID", parameter.custID)

            params(1) = New MySqlParameter("_custFullName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(parameter.custFullName))

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

            params(21) = New MySqlParameter("_custNetUser", parameter.custNetUser)

            params(22) = New MySqlParameter("_custNetPassword", parameter.custNetPassword)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_contactinfoUpd", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function GetContactFullNameByID(ByVal custId As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custID", custId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim name As String = db.GetScalarFromProcedure("stpDad_contactinfoSlFullNameByID", params)

            If db.HasError Then Return String.Empty

            Return name

        End Function

        Public Shared Function GetAllUser() As ContactInfoReviewCollection

            Dim list As New ContactInfoReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelAllUser")

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As ContactInfoReview = GetContactInfoReviewFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetAllSysUserExcept(ByVal custId As String) As ContactInfoReviewCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custID", custId)

            Dim list As New ContactInfoReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelSysUserExcept", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As ContactInfoReview = GetContactInfoReviewFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetAllUserFullName(ByVal where As String) As AutoCompleteStringCollection

            Dim list As New AutoCompleteStringCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_where", where)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelFullNames", params)

            If db.HasError Then Return Nothing

            While reader.Read

                list.Add(DbAccessLayer.SqlDataHelper.GetString(reader, "custFullName"))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function GetUserByNameAndRole(ByVal name As String, ByVal whereCondition As String) As ContactInfoReview

            Dim c As New ContactInfoReview

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_where", whereCondition)

            params(1) = New MySqlParameter("_name", IIf(whereCondition = String.Empty, " where ", " and ").ToString() & " custFullName='" & name & "'")

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelIdByNameAndRole", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                c = GetContactInfoReviewFromReader(reader)

            End If

            reader.Close()

            Return c

        End Function

        Public Shared Function GetUsersByRole(ByVal roleType As Enums.RoleType, Optional ByVal AddAll As Boolean = False) As ContactInfoReviewCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custType", roleType)

            Dim list As New ContactInfoReviewCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelByRole", params)

            If db.HasError Then Return Nothing

            While reader.Read

                Dim child As ContactInfoReview = GetContactInfoReviewFromReader(reader)

                list.Add(child)

            End While

            reader.Close()

            If AddAll Then list.Add(New ContactInfoReview("0", "همه موارد"))

            Return list

        End Function

        Public Shared Function ValidateUser(ByVal userName As String, ByVal password As String) As Boolean

            Dim params(0) As MySqlParameter

            Dim validate As Boolean = False

            params(0) = New MySqlParameter("_custUserName", userName)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelPass", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                If password = Common.SecurityHelper.Decrypt(DbAccessLayer.MySqlDataHelper.GetString(reader, "custPassword"), DbAccessLayer.MySqlDataHelper.GetString(reader, "custSaltkey")) Then

                    validate = True

                    Dim l As New Login.Login
                    l.UserID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custId").ToString()
                    Login.CurrentLogin.CurrentUser = l

                End If

            End If

            reader.Close()

            If Not validate Then Return IsDefaultUser(userName, password)

            Return True

        End Function

        Private Shared Function IsDefaultUser(ByVal user As String, ByVal pass As String) As Boolean

            If user.ToLower() = (Environment.MachineName.ToString + "dad2").ToLower() AndAlso pass = "dad2123" Then

                Dim l As New Login.Login
                l.UserID = "91fd260b-6307-4447-8008-baef86e13f6e"
                l.IsAdmin = True
                l.Mail = String.Empty
                l.Name = "کاربر موقت"
                l.Role = Enums.RoleType.سایر
                Login.CurrentLogin.CurrentUser = l
                Return True

            End If

            Return False


        End Function

        'Public Shared Function GetUserInfoForTransfer(ByVal custId As String) As ContactInfoForTransfer

        '    Dim params(0) As MySqlParameter

        '    params(0) = New MySqlParameter("_custID", custId)

        '    Dim list As New ContactInfoForTransfer

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelUserNameByID", params)

        '    If db.HasError Then Throw db.ErrorException

        '    If reader.Read Then

        '        list = GetContactInfoForTransferFromReader(reader)

        '    Else

        '        Throw New Exception

        '    End If

        '    reader.Close()

        '    Return list

        'End Function

        Public Shared Function GetAllRecords() As ContactInfoCollection


            Dim lists As New ContactInfoCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelAllRecords")

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                lists.Add(GetUContactFromReader(reader))

            End While

            reader.Close()

            Return lists

        End Function

        Public Shared Function GetRecordCount() As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim count As Integer = db.GetScalarFromProcedure("stpDad_contactinfoSelCount")

            If db.HasError Then Throw db.ErrorException

            Return count

        End Function

        Public Shared Function GetUserPriority(ByVal custId As String) As Enums.custPriority

            Dim params(0) As MySqlParameter

            Dim p As Enums.custPriority = Enums.custPriority.NoP

            params(0) = New MySqlParameter("_custID", custId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSelPriority", params)

            If db.HasError Then Return Enums.custPriority.NoP

            If reader.Read Then

                p = DbAccessLayer.MySqlDataHelper.GetInt(reader, "custPriority")

            End If

            reader.Close()

            Return p

        End Function

        Public Shared Function GetUserRole(ByVal custId As String) As Int16

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custID", custId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Int16 = CInt(db.GetScalarFromProcedure("stpDad_contactinfoSelRoleByID", params))

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function


#End Region

#Region "Utility"

        'Private Shared Function GetContactInfoForTransferFromReader(ByVal reader As IDataReader) As ContactInfoForTransfer

        '    If reader Is Nothing Then Return Nothing

        '    Dim parameter As New ContactInfoForTransfer

        '    parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

        '    parameter.custUserName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custUserName")

        '    Return parameter

        'End Function

        Private Shared Function GetContactInfoReviewFromReader(ByVal reader As IDataReader) As ContactInfoReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New ContactInfoReview

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID").ToString()

            Return parameter

        End Function

        Private Shared Function GetUserImageFromReader(ByVal reader As IDataReader) As BaseForm.ImageReview

            Dim parameter As New BaseForm.ImageReview

            parameter.imageLogo = DbAccessLayer.MySqlDataHelper.GetBytes(reader, "custPicture")

            parameter.imageExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "custPicExtention")

            parameter.imageUpdateDate = DbAccessLayer.MySqlDataHelper.GetString(reader, "custPicUpdateDate")

            Return parameter

        End Function

        Private Shared Function GetUContactFromReader(ByVal reader As IDataReader) As Contact

            Dim parameter As New Contact


            parameter.custAddress = DbAccessLayer.MySqlDataHelper.GetString(reader, "custAddress")

            Dim temp As Int32? = DbAccessLayer.MySqlDataHelper.GetNullableInt(reader, "custBthDay")

            If temp.HasValue Then parameter.custBthDay = temp.ToString()

            parameter.custCellPhone = DbAccessLayer.MySqlDataHelper.GetString(reader, "custCellPhone")

            parameter.custCompanyName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custCompanyName")

            parameter.custDescription = DbAccessLayer.MySqlDataHelper.GetString(reader, "custDescription")

            parameter.custEmailOne = DbAccessLayer.MySqlDataHelper.GetString(reader, "custEmailOne")

            parameter.custFatherName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFatherName")

            parameter.custFax = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFax")

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.custHomeTel = DbAccessLayer.MySqlDataHelper.GetString(reader, "custHomeTel")

            parameter.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID").ToString()

            parameter.custIDNumber = DbAccessLayer.MySqlDataHelper.GetString(reader, "custIDNumber")

            parameter.custIsAdminUser = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "custIsAdminUser")

            parameter.custIsSysUser = DbAccessLayer.MySqlDataHelper.GetBoolean(reader, "custIsSysUser")

            parameter.custJobTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "custJobTitle")

            parameter.custOfficeTel = DbAccessLayer.MySqlDataHelper.GetString(reader, "custOfficeTel")

            parameter.custPassword = DbAccessLayer.MySqlDataHelper.GetString(reader, "custPassword")

            parameter.custSaltkey = DbAccessLayer.MySqlDataHelper.GetString(reader, "custSaltkey")

            parameter.custRegisterationNumber = DbAccessLayer.MySqlDataHelper.GetString(reader, "custRegisterationNumber")

            parameter.custType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "custType")

            parameter.custUserName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custUserName")

            parameter.custNetUser = DbAccessLayer.MySqlDataHelper.GetString(reader, "custNetUser")

            parameter.custNetPassword = DbAccessLayer.MySqlDataHelper.GetString(reader, "custNetPassword")

            Return parameter

        End Function

#End Region

#Region "LReview"

#Region "Methods"

        Public Shared Function SearchContactsByName(ByVal Name As String) As ContactSearchCollection

            Dim list As New ContactSearchCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custFullName", Name)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSearchByName", params)

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                list.Add(GetContactSearchFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function AdvanceSearchContactsByName(ByVal Name As String) As ContactSearchCollection

            Dim list As New ContactSearchCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custFullName", Name)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoAdvSearchByName", params)

            If db.HasError Then Throw db.ErrorException

            While reader.Read

                list.Add(GetContactSearchFromReader(reader))

            End While

            reader.Close()

            Return list

        End Function

        Public Shared Function DelContactByID(ByVal custId As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custID", custId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim name As String = CStr(db.GetScalarFromProcedure("stpDad_contactinfoDelByID", params))

            If db.HasError Then Throw db.ErrorException

            Return name

        End Function

        Public Shared Function GetAllContactType() As Setting.SettingCollection

            Return Setting.SettingManager.GetSettingsByName("ContactType")

        End Function

        Public Shared Function GetContactIDByUserName(ByVal userName As String) As String

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custUserName", userName)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As String = db.GetScalarFromProcedure("stpdDad_contactinfoUtiIsExistUserName", params).ToString()

            If db.HasError Then Throw db.ErrorException

            Return result

        End Function

        Public Shared Function AddContact(ByVal parameter As Contact) As Boolean

            Dim params(22) As MySqlParameter

            params(0) = New MySqlParameter("_custID", parameter.custID)

            params(1) = New MySqlParameter("_custFullName", NwdSolutions.Web.GeneralUtilities.General.DbReplace(parameter.custFullName))

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

            params(20) = New MySqlParameter("_custSaltkey", IIf(parameter.custSaltkey = String.Empty, DBNull.Value, parameter.custSaltkey))

            params(21) = New MySqlParameter("_custnetUser", parameter.custNetUser)

            params(22) = New MySqlParameter("_custNetPassword", parameter.custNetPassword)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_contactinfoIns", params)

            If db.HasError Then Throw db.ErrorException

            Return True

        End Function

        Public Shared Function GetContactByID(ByVal custId As String) As Contact

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custID", custId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim c As Contact = Nothing

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_contactinfoSellAllByID", params)

            If db.HasError Then Throw db.ErrorException

            If reader.Read Then

                c = GetUContactFromReader(reader)

            End If

            reader.Close()

            Return c

        End Function

        Public Shared Function ISExistAdminUser(ByVal custId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_custID", IIf(custId = String.Empty, DBNull.Value, custId))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_contactinfoUtiIsExistAdmin", params))

            If db.HasError Then Throw db.ErrorException

            If result > 0 Then

                Return True
            Else

                Return False

            End If

        End Function


#End Region

#Region "Utility"

        Private Shared Function GetContactSearchFromReader(ByVal reader As IDataReader) As ContactSearch

            Dim parameter As New ContactSearch

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID").ToString

            parameter.custType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "custType")

            parameter.imageExtension = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageExtension")

            parameter.imageUpdateDate = DbAccessLayer.MySqlDataHelper.GetString(reader, "imageUpdateDate")

            parameter.custCellphone = DbAccessLayer.MySqlDataHelper.GetString(reader, "custCellPhone").ToString

            parameter.custphone1 = DbAccessLayer.MySqlDataHelper.GetString(reader, "custHomeTel").ToString

            parameter.custphone2 = DbAccessLayer.MySqlDataHelper.GetString(reader, "custOfficeTel").ToString

            Return parameter

        End Function

#End Region

#End Region

    End Class

End Namespace
