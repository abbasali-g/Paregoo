Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.Setting
Imports Lawyer.Common.VB.ContactInfo

Namespace Shaxes
    Public Class FinanceManager



#Region "LReview"

#Region "Methods"


        Public Shared Function DeleteFinanceByID(ByVal financeId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_financeID", financeId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_financeDelById", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function DeleteFinanceBytimeID(ByVal timeID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", timeID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_financeDelByTimeID", params)

            If db.HasError Then Return False

            Return True

        End Function


        Public Shared Function SearchFinance(ByVal movakelWhere As String, ByVal whereCondition As String, ByVal isFileCase As Boolean) As DataTable

            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("_Movakel", movakelWhere)

            params(1) = New MySqlParameter("_Query", whereCondition)

            params(2) = New MySqlParameter("_isFileCase", IIf(isFileCase, 1, 0))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_financeSearch", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function

        Public Shared Function SearchFinance_Collection(ByVal movakelWhere As String, ByVal whereCondition As String, ByVal isFileCase As Boolean) As FinanceSearchCollection

            Dim l As New FinanceSearchCollection

            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("_Movakel", movakelWhere)

            params(1) = New MySqlParameter("_Query", whereCondition)

            params(2) = New MySqlParameter("_isFileCase", IIf(isFileCase, 1, 0))

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_financeSearch", params)

            If db.HasError Then Return Nothing

            While reader.Read

                l.Add(GetFinanceSearchByFilecaseIdFromReader(reader))

            End While

            reader.Close()

            Return l

        End Function

        Public Shared Function SearchFinance_Moshavere(ByVal _fQuery As String) As FinanceSearchCollection

            Dim l As New FinanceSearchCollection

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_fQuery", _fQuery)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_financeSearch2", params)

            If db.HasError Then Return Nothing

            While reader.Read

                l.Add(GetFinanceSearchByFilecaseIdFromReader(reader))

            End While

            reader.Close()

            Return l

        End Function



        Public Shared Function SearchFinanceByfileCaseId(ByVal filecaseId As String) As FinanceSearchCollection

            ''abbas added 
            If Login.CurrentLogin.CurrentUser.Role = Enums.RoleType.منشی Then
                Return Nothing
            End If

            Dim params(0) As MySqlParameter

            Dim l As New FinanceSearchCollection

            params(0) = New MySqlParameter("_filecaseId", filecaseId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_financeSearchByFilecaseId", params)

            If db.HasError Then Return Nothing

            While reader.Read

                l.Add(GetFinanceSearchByFilecaseIdFromReader(reader))

            End While

            reader.Close()

            Return l

        End Function

        Public Shared Function SearchFinanceByPermission_Collection(ByVal movakelWhere As String, ByVal whereCondition As String, ByVal isFileCase As Boolean, ByVal financeAccessp As String) As FinanceSearchCollection

            Dim l As New FinanceSearchCollection

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_Movakel", movakelWhere)

            params(1) = New MySqlParameter("_Query", whereCondition)

            params(2) = New MySqlParameter("_isFileCase", IIf(isFileCase, 1, 0))

            params(3) = New MySqlParameter("_financeAccess", financeAccessp)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_financeSearchByPermission", params)

            If db.HasError Then Return Nothing

            While reader.Read

                l.Add(GetFinanceSearchByFilecaseIdFromReader(reader))

            End While

            reader.Close()

            Return l

        End Function


        Public Shared Function SearchFinanceByPermission(ByVal movakelWhere As String, ByVal whereCondition As String, ByVal isFileCase As Boolean, ByVal financeAccessp As String) As DataTable

            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_Movakel", movakelWhere)

            params(1) = New MySqlParameter("_Query", whereCondition)

            params(2) = New MySqlParameter("_isFileCase", IIf(isFileCase, 1, 0))

            params(3) = New MySqlParameter("_financeAccess", financeAccessp)


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_financeSearchByPermission", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function

        Public Shared Function GetBankBranches(ByVal BankID As String) As Setting.SettingCollection

            Return Setting.SettingManager.GetSettingsByGroupId(BankID)

        End Function

        Public Shared Function AddFinance(ByVal parameter As Finance) As Boolean

            Dim params(14) As MySqlParameter

            params(0) = New MySqlParameter("_financeID", parameter.financeID)
            params(1) = New MySqlParameter("_fileCaseID", IIf(parameter.fileCaseID = String.Empty, DBNull.Value, parameter.fileCaseID))
            params(2) = New MySqlParameter("_fileID", IIf(parameter.fileID = String.Empty, DBNull.Value, parameter.fileID))
            params(3) = New MySqlParameter("_finaceTypeID", IIf(parameter.finaceTypeID = String.Empty, DBNull.Value, parameter.finaceTypeID))
            params(4) = New MySqlParameter("_timeID", IIf(parameter.timeID = String.Empty, DBNull.Value, parameter.timeID))
            params(5) = New MySqlParameter("_financePaymentType", IIf(parameter.financePaymentType = String.Empty, DBNull.Value, parameter.financePaymentType))
            params(6) = New MySqlParameter("_financePaymentDate", parameter.financePaymentDate)
            params(7) = New MySqlParameter("_financeAmount", parameter.financeAmount)
            params(8) = New MySqlParameter("_financePaymentTime", parameter.financePaymentTime)
            params(9) = New MySqlParameter("_financeBranchID", IIf(parameter.financeBranchID = String.Empty, DBNull.Value, parameter.financeBranchID))
            params(10) = New MySqlParameter("_financeBankID", IIf(parameter.financeBankID = String.Empty, DBNull.Value, parameter.financeBankID))
            params(11) = New MySqlParameter("_financeChequeSerial", IIf(parameter.financeChequeSerial = String.Empty, DBNull.Value, parameter.financeChequeSerial))
            params(12) = New MySqlParameter("_financeChequeDate", IIf(parameter.financeChequeDate = String.Empty, DBNull.Value, parameter.financeChequeDate))
            params(13) = New MySqlParameter("_financeCustID", parameter.financeCustID)
            params(14) = New MySqlParameter("_financeDesc", parameter.financeDesc)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_financeIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function AddOfficeFinance(ByVal parameter As OfficeFinance) As Boolean

            Dim params(5) As MySqlParameter

            params(0) = New MySqlParameter("_financeID", parameter.financeID)
            params(1) = New MySqlParameter("_finaceTypeID", parameter.finaceTypeID)
            params(2) = New MySqlParameter("_financePaymentDate", parameter.financePaymentDate)
            params(3) = New MySqlParameter("_financeAmount", parameter.financeAmount)
            params(4) = New MySqlParameter("_custId", parameter.custId)
            params(5) = New MySqlParameter("_financeDesc", parameter.financeDesc)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_officefinanceIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function AddFinance_Moshavereh(ByVal parameter As Finance, ByVal financeID2 As String) As Boolean

            Dim params(10) As MySqlParameter

            params(0) = New MySqlParameter("_financeID1", parameter.financeID)
            params(2) = New MySqlParameter("_fileID", IIf(parameter.fileID = String.Empty, DBNull.Value, parameter.fileID))
            params(3) = New MySqlParameter("_finaceTypeID", IIf(parameter.finaceTypeID = String.Empty, DBNull.Value, parameter.finaceTypeID))
            params(4) = New MySqlParameter("_timeID", IIf(parameter.timeID = String.Empty, DBNull.Value, parameter.timeID))
            params(5) = New MySqlParameter("_financePaymentType", "0")
            params(6) = New MySqlParameter("_financePaymentDate", parameter.financePaymentDate)
            params(7) = New MySqlParameter("_financeAmount", parameter.financeAmount)
            params(8) = New MySqlParameter("_financePaymentTime", parameter.financePaymentTime)
            params(1) = New MySqlParameter("_financeCustID", parameter.financeCustID)
            params(9) = New MySqlParameter("_financeDesc", parameter.financeDesc)
            params(10) = New MySqlParameter("_financeID2", financeID2)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_FinanaceMoshavereIns", params)

            If db.HasError Then Return False

            Return True

        End Function

        Public Shared Function GetFinaceByID(ByVal financeId As String) As Finance

            Dim f As Finance = Nothing

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_financeID", financeId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_financeSelAllByID", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                f = GetFinanceFromReader(reader)

            End If

            reader.Close()

            Return f

        End Function

        Public Shared Function EditFinance(ByVal parameter As Finance) As Boolean

            Dim params(11) As MySqlParameter

            params(0) = New MySqlParameter("_financeID", parameter.financeID)
            params(1) = New MySqlParameter("_finaceTypeID", IIf(parameter.finaceTypeID = String.Empty, DBNull.Value, parameter.finaceTypeID))
            params(2) = New MySqlParameter("_financePaymentType", IIf(parameter.financePaymentType = String.Empty, DBNull.Value, parameter.financePaymentType))
            params(3) = New MySqlParameter("_financePaymentDate", parameter.financePaymentDate)
            params(4) = New MySqlParameter("_financeAmount", parameter.financeAmount)
            params(5) = New MySqlParameter("_financePaymentTime", parameter.financePaymentTime)
            params(6) = New MySqlParameter("_financeBranchID", IIf(parameter.financeBranchID = String.Empty, DBNull.Value, parameter.financeBranchID))
            params(7) = New MySqlParameter("_financeBankID", IIf(parameter.financeBankID = String.Empty, DBNull.Value, parameter.financeBankID))
            params(8) = New MySqlParameter("_financeChequeSerial", IIf(parameter.financeChequeSerial = String.Empty, DBNull.Value, parameter.financeChequeSerial))
            params(9) = New MySqlParameter("_financeChequeDate", IIf(parameter.financeChequeDate = String.Empty, DBNull.Value, parameter.financeChequeDate))
            params(10) = New MySqlParameter("_financeCustID", parameter.financeCustID)
            params(11) = New MySqlParameter("_financeDesc", parameter.financeDesc)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_financeUpd", params)

            If db.HasError Then Return False

            Return True

        End Function


        Public Shared Function IsExistFinanceByFinaceType(ByVal finaceTypeID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_finaceTypeID", finaceTypeID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Long = CLng(db.GetScalarFromProcedure("stpDad_financeUtiIsExistType", params))

            If db.HasError Then Return False

            If result = 0 Then

                Return True

            End If

            Return False

        End Function




#End Region

#Region "Utility"


#End Region

#End Region

#Region "Methods"

        Public Shared Function GetBankList() As Setting.SettingCollection

            Return Setting.SettingManager.GetBankList()

        End Function



        Public Shared Function GetFinanceTypeList() As Setting.SettingCollection

            Return Setting.SettingManager.GetFinanceTypeList()

        End Function




        Public Shared Function GetPaymentTypeList() As Setting.SettingCollection

            Return Setting.SettingManager.GetSettingsByName("PaymentType")

        End Function



        'Public Shared Function SearchFinance(ByVal movakelWhere As String, ByVal whereCondition As String) As FinanceSearchCollection

        '    Dim params(1) As MySqlParameter

        '    params(0) = New MySqlParameter("_Movakel", IIf(movakelWhere = String.Empty, DBNull.Value, movakelWhere))

        '    params(1) = New MySqlParameter("_Query", whereCondition)

        '    Dim list As New FinanceSearchCollection

        '    Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

        '    Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_financeSearch", params)

        '    If db.HasError Then Return Nothing

        '    While reader.Read

        '        list.Add(GetFinanceSearchFromReader(reader))

        '    End While

        '    Return list

        'End Function



        Public Shared Sub SearchFinanceSelByFileCaseID(ByVal fileCaseId As String, ByVal filepath As String)


            Dim list As FinanceSearchCollection = SearchFinanceByfileCaseId(fileCaseId)

            Dim dt As New DataTable

            dt.Columns.Add("AmountDaryafti", System.Type.GetType("System.Double"))
            dt.Columns.Add("AmountHazine", System.Type.GetType("System.Double"))
            dt.Columns.Add("financeChequeSerial")
            dt.Columns.Add("financeDesc")
            dt.Columns.Add("financePaymentDate")
            dt.Columns.Add("financePaymentTime")
            dt.Columns.Add("financeType")
            dt.Columns.Add("Shobe")

            dt.Columns("AmountHazine").Caption = "مبلغ هزینه"
            dt.Columns("AmountDaryafti").Caption = "مبلغ دریافتی"
            dt.Columns("financeType").Caption = "نوع هزینه"
            dt.Columns("financePaymentDate").Caption = "تاریخ "
            dt.Columns("financePaymentTime").Caption = "زمان "
            dt.Columns("financeChequeSerial").Caption = "شماره چک"
            dt.Columns("Shobe").Caption = "نام شعبه"
            dt.Columns("financeDesc").Caption = "شرح"


            For Each Item As Lawyer.Common.VB.Shaxes.FinanceSearch In list
                Dim dtNewRow As DataRow
                dtNewRow = dt.NewRow()
                dtNewRow.Item("AmountHazine") = Item.AmountHazine
                dtNewRow.Item("AmountDaryafti") = Item.AmountDaryafti
                dtNewRow.Item("financeType") = Item.financeType
                dtNewRow.Item("financePaymentDate") = Item.financePaymentDate
                dtNewRow.Item("financePaymentTime") = Item.financePaymentTime
                dtNewRow.Item("financeChequeSerial") = Item.financeChequeSerial
                dtNewRow.Item("Shobe") = Item.Shobe
                dtNewRow.Item("financeDesc") = Item.financeDesc
                dt.Rows.Add(dtNewRow)

            Next

            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Common.ExcelManager.CreateExcel(filepath, dt, False)

        End Sub


        Public Shared Function GetFinaceReviewByID(ByVal financeId As String) As FinanceReview

            Dim f As New FinanceReview

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_financeID", financeId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_financeSelBaseInfo", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                f = GetFinanceReviewFromReader(reader)

            End If

            reader.Close()

            Return f

        End Function

        'مبلغ مشاوره را معین می کند
        Public Shared Function GetMoshavereCost(ByVal timeID As String) As Double

            Dim f As New Finance

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", timeID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim amount As Double = CDbl(db.GetScalarFromProcedure("stpDad_financeSel_Mosh_Amount", params))

            If db.HasError Then Throw db.ErrorException

            Return amount

        End Function


        Public Shared Function GetFinanaceCustInfo(ByVal tmieId As String) As ContactInfoReview

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", tmieId)

            Dim k As New ContactInfoReview

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_financselCustInfo", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                k = GetContactInfoReviewFromReader(reader)

            End If

            reader.Close()

            Return k

        End Function

        'آیا برای مشاوره مبلغی گرفته شده است
        Public Shared Function IsExistMoshaveredaryafti(ByVal timeID As String) As Boolean

            Dim f As New Finance

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_timeID", timeID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim amount As Boolean = CBool(db.GetScalarFromProcedure("stpDad_financeUtiRegMoshavere", params))

            If db.HasError Then Throw db.ErrorException

            Return amount

        End Function



#End Region

#Region "Utility"


        Private Shared Function GetFinanceSearchByFilecaseIdFromReader(ByVal reader As IDataReader) As FinanceSearch

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FinanceSearch

            parameter.financeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "financeID").ToString

            parameter.financePaymentDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "financePaymentDate")

            parameter.financePaymentType = DbAccessLayer.MySqlDataHelper.GetNullableInt16(reader, "financePaymentType")

            parameter.financeAmount = DbAccessLayer.MySqlDataHelper.GetDouble(reader, "financeAmount")

            parameter.financePaymentTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "financePaymentTime")

            parameter.financeChequeSerial = DbAccessLayer.MySqlDataHelper.GetString(reader, "financeChequeSerial")

            parameter.financeDesc = DbAccessLayer.MySqlDataHelper.GetString(reader, "financeDesc")

            parameter.financeType = DbAccessLayer.MySqlDataHelper.GetString(reader, "financeType")

            parameter.BranchName = DbAccessLayer.MySqlDataHelper.GetString(reader, "BranchName")

            parameter.bankName = DbAccessLayer.MySqlDataHelper.GetString(reader, "bankName")

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.FileCaseNumber = DbAccessLayer.MySqlDataHelper.GetString(reader, "FileCaseNumber")

            parameter.finaceTypeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "finaceTypeID").ToString

            Return parameter

        End Function

        Private Shared Function GetFinanceFromReader(ByVal reader As IDataReader) As Finance

            If reader Is Nothing Then Return Nothing

            Dim parameter As New Finance

            Dim gId As New Guid
            Dim i As Int32?

            gId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID")

            If gId <> Guid.Empty Then
                parameter.fileCaseID = gId.ToString()
            End If

            gId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID")

            If gId <> Guid.Empty Then
                parameter.fileID = gId.ToString()
            End If

            parameter.finaceTypeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "finaceTypeID").ToString()

            parameter.financeAmount = DbAccessLayer.MySqlDataHelper.GetDouble(reader, "financeAmount")


            gId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "financeBankID")
            If gId <> Guid.Empty Then
                parameter.financeBankID = gId.ToString()
            End If


            gId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "financeBranchID")
            If gId <> Guid.Empty Then
                parameter.financeBranchID = gId.ToString()
            End If

            parameter.financeChequeSerial = DbAccessLayer.MySqlDataHelper.GetString(reader, "financeChequeSerial")

            i = DbAccessLayer.MySqlDataHelper.GetInt(reader, "financeChequeDate")

            If i.HasValue Then
                parameter.financeChequeDate = CStr(i)
            End If

            parameter.financeCustID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "financeCustID").ToString

            parameter.financeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "financeID").ToString

            parameter.financePaymentDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "financePaymentDate")

            parameter.financePaymentTime = DbAccessLayer.MySqlDataHelper.GetString(reader, "financePaymentTime")

            parameter.financeDesc = DbAccessLayer.MySqlDataHelper.GetString(reader, "financeDesc")

            parameter.financePaymentType = CStr(DbAccessLayer.MySqlDataHelper.GetInt16(reader, "financePaymentType"))

            gId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID")
            If gId <> Guid.Empty Then
                parameter.timeID = gId.ToString()
            End If

            Return parameter

        End Function

        Private Shared Function GetFinanceReviewFromReader(ByVal reader As IDataReader) As FinanceReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New FinanceReview

            Dim gId As New Guid


            gId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileCaseID")

            If gId <> Guid.Empty Then
                parameter.fileCaseID = gId.ToString()
            End If

            gId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "fileID")

            If gId <> Guid.Empty Then
                parameter.fileID = gId.ToString()
            End If

            parameter.finaceTypeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "finaceTypeID").ToString()


            parameter.financeCustID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "financeCustID").ToString

            parameter.financeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "financeID").ToString

            gId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "timeID")
            If gId <> Guid.Empty Then
                parameter.timeID = gId.ToString()
            End If

            Return parameter

        End Function

        Private Shared Function GetContactInfoReviewFromReader(ByVal reader As IDataReader) As ContactInfoReview

            If reader Is Nothing Then Return Nothing

            Dim parameter As New ContactInfoReview

            parameter.custFullName = DbAccessLayer.MySqlDataHelper.GetString(reader, "custFullName")

            parameter.custID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custID").ToString()

            Return parameter

        End Function

#End Region

#Region "OfficeManager"

        Public Shared Function GetOtherFinanceTypeList() As Setting.SettingCollection

            Return Setting.SettingManager.GetOtherFinanceTypeList()

        End Function

        Public Shared Function IsExistOfficeFinanceByFinaceType(ByVal finaceTypeID As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_finaceTypeID", finaceTypeID)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim result As Long = CLng(db.GetScalarFromProcedure("stpDad_officefinanceUtiIsExistType", params))

            If db.HasError Then Return False

            If result = 0 Then

                Return True

            End If

            Return False

        End Function

        Public Shared Function SearchOfficeFinance(ByVal query As String) As DataTable

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_Query", query)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_officefinanceSearch", params)

            If db.HasError Then Return Nothing

            Return dt

        End Function

        Public Shared Function GetOfficeFinaceByID(ByVal financeId As String) As OfficeFinance

            Dim f As OfficeFinance = Nothing

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_financeID", financeId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_officefinanceSelAllbyId", params)

            If db.HasError Then Return Nothing

            If reader.Read Then

                f = GetOfficeFinanceFromReader(reader)

            End If

            reader.Close()

            Return f

        End Function

        Public Shared Function EditOfficeFinance(ByVal parameter As OfficeFinance) As Boolean

            Dim params(5) As MySqlParameter

            params(0) = New MySqlParameter("_financeID", parameter.financeID)
            params(1) = New MySqlParameter("_finaceTypeID", parameter.finaceTypeID)
            params(2) = New MySqlParameter("_financePaymentDate", parameter.financePaymentDate)
            params(3) = New MySqlParameter("_financeAmount", parameter.financeAmount)
            params(4) = New MySqlParameter("_custId", parameter.custId)
            params(5) = New MySqlParameter("_financeDesc", parameter.financeDesc)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_officefinanceUpdById", params)

            If db.HasError Then Return False

            Return True

        End Function


        Public Shared Function DeleteOfficeFinanceByID(ByVal financeId As String) As Boolean

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_financeID", financeId)

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            db.ExecuteProcedure("stpDad_officefinanceDelById", params)

            If db.HasError Then Return False

            Return True

        End Function

        Private Shared Function GetOfficeFinanceFromReader(ByVal reader As IDataReader) As OfficeFinance

            If reader Is Nothing Then Return Nothing

            Dim parameter As New OfficeFinance

            parameter.finaceTypeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "finaceTypeID").ToString()

            parameter.financeAmount = DbAccessLayer.MySqlDataHelper.GetDouble(reader, "financeAmount")

            parameter.custId = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "custId").ToString

            parameter.financeID = DbAccessLayer.MySqlDataHelper.GetGuid(reader, "financeID").ToString

            parameter.financePaymentDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "financePaymentDate")

            parameter.financeDesc = DbAccessLayer.MySqlDataHelper.GetString(reader, "financeDesc")

            Return parameter

        End Function

#End Region

    End Class



End Namespace

