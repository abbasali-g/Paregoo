Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports NwdSolutions.Web.GeneralUtilities

Namespace Laws


    Public Class LawManager

        Public Shared Function GetLawContent_Old(ByVal LawId As Integer) As String

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", LawId) 'General.DbReplace(jobName)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawSelByLowId_Old", params)


            If db.HasError Then Throw db.ErrorException


            Dim str As String = String.Empty
            ' While reader.Read
            reader.Read()
            str = GetlawDetContentFromReader_Old(reader)
            ' End While
            reader.Close()


            Return Trim(str)


        End Function

        Public Shared Function GetLawContent(ByVal LawId As Integer) As String

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", LawId) 'General.DbReplace(jobName)

            ' Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawSelByLowId", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_LawSelByLowId", params)

            If db.HasError Then Throw db.ErrorException


            Dim str As String = String.Empty

            For i As Integer = 0 To dt.Rows.Count - 1
                str = Trim(str) + vbNewLine + dt.Rows(i)("lawdetcontent")
            Next

            'While reader.Read
            '    ' reader.Read()
            '    str = Trim(str) + vbNewLine + GetlawDetContentFromReader(reader)
            'End While
            'reader.Close()

            Return Trim(str)


        End Function

        Public Shared Function GetLawRavieNote(ByVal lawRID As Integer) As String

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawRID", lawRID) 'General.DbReplace(jobName)

            Dim result As DataRow = db.GetDataRowFromProcedure("stpDad_LawRavieSelBylawRID", params)

            If db.HasError Then Throw db.ErrorException

            Return result(0)

        End Function

        Public Shared Function GetLawRaviyeNote(ByVal LawId As Integer) As String

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawRID", LawId) 'General.DbReplace(jobName)

            Dim result As DataRow = db.GetDataRowFromProcedure("stpDad_LawSelByLowId", params)

            If db.HasError Then Throw db.ErrorException

            Return result(0)

        End Function

        Public Shared Function GetKeyword(ByVal Str As String) As String

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("pKeyword", Str) 'General.DbReplace(jobName)

            Dim result As String = CStr(db.GetScalarFromProcedure("stpDad_LawKeyWordSearchByName", params))

            If db.HasError Then Throw db.ErrorException

            Return result


        End Function

        Public Shared Function GetLawByID(ByVal LawID As String) As Law


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_LawID", LawID)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawSelByLawId_ForAllCol", params)

            If db.HasError Then Throw db.ErrorException

            Dim Law As New Law
            ' While reader.Read
            reader.Read()
            Law = GetLawFromReader(reader)
            '  End While
            reader.Close()

            Law.lawContent = GetLawContent(LawID) ' from other function


            Return Law

        End Function

        Public Shared Function GetLawByIDForEmail(ByVal LawID As String) As Law


            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_LawID", LawID)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSelByLawIDForTandC", params)

            If db.HasError Then Throw db.ErrorException

            Dim Law As New Law
            'While reader.Read
            reader.Read()
            Law = GetLawFromReaderForEmail(reader)
            ' End While
            reader.Close()

            Law.lawContent = GetLawContent(LawID) ' from other function

            Return Law

        End Function

        Public Shared Function InsertLaw(ByVal Law As Law) As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(12) As MySqlParameter
            'IIf(String.IsNullOrEmpty(job.JobCatDesc), DBNull.Value, job.JobCatDesc))
            params(0) = New MySqlParameter("_lawTitle", General.DbReplace(Law.lawTitle))
            ' params(1) = New MySqlParameter("_lawContent", General.DbReplace(Law.lawContent))
            params(1) = New MySqlParameter("_lawTypeID", Law.lawTypeID)
            params(2) = New MySqlParameter("_lawPassedDate", Law.lawPassedDate)
            params(3) = New MySqlParameter("_lawPublishedDate", Law.lawPublishedDate)
            params(4) = New MySqlParameter("_lawPublicationNumber", Law.lawPublicationNumber)
            params(5) = New MySqlParameter("_lawNote", General.DbReplace(Law.lawNote))
            params(6) = New MySqlParameter("_lawMansoukh", Law.lawMansoukh)
            params(7) = New MySqlParameter("_lawMansoukhDescription", General.DbReplace(Law.lawMansoukhDescription))
            params(8) = New MySqlParameter("_lawOwner", General.DbReplace(Law.lawOwner))
            params(9) = New MySqlParameter("_lawLRType", Law.lawLRType)
            params(10) = New MySqlParameter("_lawLRText", General.DbReplace(Law.lawLRText))
            params(11) = New MySqlParameter("_lawCatID", Law.lawCatID)

            params(12) = New MySqlParameter("_lawID", Law.lawID)

            Dim result As Integer = db.GetScalarFromProcedure("stpDad_LawIns", params)

            If db.HasError Then Throw db.ErrorException
            Return result

        End Function

        Public Shared Function UpdateLaw(ByVal Law As Law) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(11) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", Law.lawID)
            params(1) = New MySqlParameter("_lawTitle", Law.lawTitle)
            'params(2) = New MySqlParameter("_lawContent", Law.lawContent)
            params(2) = New MySqlParameter("_lawTypeID", Law.lawTypeID)
            params(3) = New MySqlParameter("_lawPassedDate", Law.lawPassedDate)
            params(4) = New MySqlParameter("_lawPublishedDate", Law.lawPublishedDate)
            params(5) = New MySqlParameter("_lawPublicationNumber", Law.lawPublicationNumber)
            params(6) = New MySqlParameter("_lawNote", Law.lawNote)
            params(7) = New MySqlParameter("_lawMansoukh", Law.lawMansoukh)
            params(8) = New MySqlParameter("_lawMansoukhDescription", Law.lawMansoukhDescription)
            params(9) = New MySqlParameter("_lawLRType", Law.lawLRType)
            params(10) = New MySqlParameter("_lawLRText", Law.lawLRText)
            params(11) = New MySqlParameter("_lawCatID", Law.lawCatID)
            'Law.lawOwner

            Dim result As Integer = db.ExecuteProcedure("stpDad_LawUpd", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function

        Public Shared Function DeleteLaw(ByVal lawID As Integer) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", lawID)

            Dim rocount As Integer = CInt(db.ExecuteProcedure("stpDad_LawDel", params))

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function

        Public Shared Function GetLawOwner(ByVal LawId As Integer) As String

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_lawID", LawId) 'General.DbReplace(jobName)

            Dim result As String = CStr(db.GetScalarFromProcedure("stpDad_LowsSelByLawID_ForLawOwner", params))

            If db.HasError Then Throw db.ErrorException
            Return result

        End Function

        Public Shared Function GetLawDadMaxId() As Integer

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_lawID", LawId) 'General.DbReplace(jobName)

            Dim result As Integer = CInt(db.GetScalarFromProcedure("stpDad_GetLawDadMaxId", Nothing))

            If db.HasError Then Throw db.ErrorException
            Return result

        End Function




#Region "Utility"

        Private Shared Function GetLawFromReader(ByVal reader As IDataReader) As Law

            If reader Is Nothing Then Return Nothing

            Dim law As New Law
            law.lawID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawID")
            law.lawTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawTitle")
            'law.lawContent = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawContent")
            law.lawTypeID = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "lawTypeID")
            law.lawPassedDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawPassedDate")
            law.lawPublishedDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawPublishedDate")
            law.lawPublicationNumber = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawPublicationNumber")
            law.lawNote = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawNote")
            law.lawMansoukh = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "lawMansoukh")
            law.lawOwner = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawOwner")
            law.lawLRType = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "lawLRType")
            law.lawLRText = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawLRText")
            law.lawCatID = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "lawCatID")
            law.lawMansoukhDescription = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawMansoukhDescription")

            Return law

        End Function

        Private Shared Function GetLawFromReaderForEmail(ByVal reader As IDataReader) As Law

            If reader Is Nothing Then Return Nothing

            Dim law As New Law
            law.lawTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawTitle")
            'law.lawContent = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawContent")

            Return law

        End Function

        Private Shared Function GetlawDetContentFromReader(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim str As String
            str = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawDetContent")

            Return str

        End Function

        Private Shared Function GetlawDetContentFromReader_Old(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return Nothing

            Dim str As String
            str = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawContent")

            Return str

        End Function

#End Region





    End Class





End Namespace
