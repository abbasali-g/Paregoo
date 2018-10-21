Imports MySql.Data.MySqlClient
Imports Lawyer.Common.VB.CommonSetting
Imports NwdSolutions.Web.GeneralUtilities


Namespace Books

    Public Class BookCaseManager


        Public Shared Function GetAllCase() As BookCaseCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LibraryshelfSelAllCase", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim BookCaseCollection As New BookCaseCollection
            While reader.Read
                Dim BookCase As BookCase = GetBookCase(reader)
                BookCaseCollection.Add(BookCase)
            End While
            reader.Close()

            Return BookCaseCollection

        End Function


        Public Shared Function InsertCase(ByVal BookCase As BookCase) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_shelfID", BookCase.shelfID)
            params(1) = New MySqlParameter("_shelfName", General.DbReplace(BookCase.shelfName))

            Dim result As Integer = db.ExecuteProcedure("stpDad_LibraryshelfInsCase", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function

        Public Shared Function UpdateCaseName(ByVal BookCase As BookCase) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter

            params(0) = New MySqlParameter("_shelfNumber", BookCase.shelfNumber)
            params(1) = New MySqlParameter("_shelfName", General.DbReplace(BookCase.shelfName))

            Dim result As Integer = db.ExecuteProcedure("stpDad_LibraryshelfUpdShelfNameByShelfNumber", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function


        Public Shared Function DeleteCase(ByVal ShelfNumber As Integer) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_shelfNumber", ShelfNumber)

            Dim result As Integer = db.ExecuteProcedure("stpDad_LibraryshelfDelCaseByShelfNumber", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function



#Region "Utility"


        Private Shared Function GetBookCase(ByVal reader As IDataReader) As BookCase

            If reader Is Nothing Then Return Nothing

            Dim BookCase As New BookCase
            BookCase.shelfID = DbAccessLayer.SqlDataHelper.GetGuid(reader, "shelfID")
            BookCase.shelfNumber = DbAccessLayer.SqlDataHelper.GetInt16(reader, "shelfNumber")
            BookCase.shelfName = DbAccessLayer.SqlDataHelper.GetString(reader, "shelfName")

            Return BookCase

        End Function

#End Region


    End Class

End Namespace