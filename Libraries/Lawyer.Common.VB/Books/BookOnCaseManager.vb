Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities
Imports Lawyer.Common.VB.CommonSetting

Namespace Books

    Public Class BookOnCaseManager

        Public Shared Function InsertBookInCase(ByVal BookOnCase As BookOnCase) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(4) As MySqlParameter

            params(0) = New MySqlParameter("_shelfID", BookOnCase.shelfID)
            params(1) = New MySqlParameter("_shelfNumber", General.DbReplace(BookOnCase.shelfNumber))
            params(2) = New MySqlParameter("_shelfRow", General.DbReplace(BookOnCase.shelfRow))
            params(3) = New MySqlParameter("_shelfColumn", General.DbReplace(BookOnCase.shelfColumn))
            params(4) = New MySqlParameter("_libID", BookOnCase.libID)

            Dim result As Integer = db.ExecuteProcedure("stpDad_Libraryshelf", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function


        Public Shared Function GetCaseBooksByOneBookLibID(ByVal libID As Guid) As BookOnCaseCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_libID", libID)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_libraryshelfSelMinBookCaseBylibID", params)

            If db.HasError Then Throw db.ErrorException

            Dim BookOnCaseCollection As New BookOnCaseCollection
            Dim BookOnCase As New BookOnCase
            While reader.Read
                'reader.Read()
                BookOnCase = GetBookOnCase(reader)
                BookOnCaseCollection.Add(BookOnCase)
            End While
            reader.Close()

            Return BookOnCaseCollection

        End Function
        

        Public Shared Function GetCaseBooksByShelfNumber(ByVal ShelfNumber As Integer) As BookOnCaseCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_ShelfNumber", ShelfNumber)  'General.DbReplace(jobName)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LibraryshelfSelByShelfNumber", params)

            If db.HasError Then Throw db.ErrorException

            Dim BookOnCaseCollection As New BookOnCaseCollection
            Dim BookOnCase As New BookOnCase
            While reader.Read
                'reader.Read()
                BookOnCase = GetBookOnCase(reader)
                BookOnCaseCollection.Add(BookOnCase)
            End While
            reader.Close()

            Return BookOnCaseCollection

        End Function


        Public Shared Function DeleteBookFromCase(ByVal BookOnCase As BookOnCase) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
            Dim params(2) As MySqlParameter

            params(0) = New MySqlParameter("_shelfNumber", BookOnCase.shelfNumber)
            params(1) = New MySqlParameter("_shelfRow", BookOnCase.shelfRow)
            params(2) = New MySqlParameter("_shelfColumn", BookOnCase.shelfColumn)

            Dim rocount As Integer = CInt(db.ExecuteProcedure("stpDad_LibraryshelfDelByRowColNumber", params))

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function



#Region "Utility"




        Private Shared Function GetBookOnCase(ByVal reader As IDataReader) As BookOnCase

            If reader Is Nothing Then Return Nothing

            Dim BookOnCase As New BookOnCase
            BookOnCase.shelfID = DbAccessLayer.SqlDataHelper.GetGuid(reader, "shelfID")
            BookOnCase.shelfNumber = DbAccessLayer.SqlDataHelper.GetInt16(reader, "shelfNumber")

            BookOnCase.shelfRow = DbAccessLayer.SqlDataHelper.GetInt16(reader, "shelfRow")
            BookOnCase.shelfColumn = DbAccessLayer.SqlDataHelper.GetInt16(reader, "shelfColumn")
            BookOnCase.libID = DbAccessLayer.SqlDataHelper.GetGuid(reader, "libID")

            Return BookOnCase

        End Function


#End Region





    End Class


End Namespace
