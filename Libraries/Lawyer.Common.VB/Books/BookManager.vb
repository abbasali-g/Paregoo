Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities


Namespace Books

    Public Class BookManager


        Public Shared Function GetBooksForGrid(ByVal libSummary As String) As BookCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_libSummary", General.DbReplace(libSummary))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LibrarySelBySummaryForGridAll", params)

            If db.HasError Then Throw db.ErrorException

            Dim Books As New BookCollection
            While reader.Read
                Dim Book As Book = GetBookForGrid(reader)
                Books.Add(Book)
            End While
            reader.Close()

            Return Books

        End Function


        Public Shared Function GetBooksForGrid_Like(ByVal libSummary As String) As BookCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_libSummary", General.DbReplace(libSummary))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LibrarySelBySummaryForGridAll_Like", params)

            If db.HasError Then Throw db.ErrorException

            Dim Books As New BookCollection
            While reader.Read
                Dim Book As Book = GetBookForGrid(reader)
                Books.Add(Book)
            End While
            reader.Close()

            Return Books

        End Function

        Public Shared Function GetBooksForGridMe(ByVal libSummary As String) As BookCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_libSummary", General.DbReplace(libSummary))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LibrarySelBySummaryForGridMe", params)

            If db.HasError Then Throw db.ErrorException

            Dim Books As New BookCollection
            While reader.Read
                Dim Book As Book = GetBookForGrid(reader)
                Books.Add(Book)
            End While
            reader.Close()

            Return Books

        End Function

        Public Shared Function GetBooksForGridMe_Like(ByVal libSummary As String) As BookCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_libSummary", General.DbReplace(libSummary))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LibrarySelBySummaryForGridMe_Like", params)

            If db.HasError Then Throw db.ErrorException

            Dim Books As New BookCollection
            While reader.Read
                Dim Book As Book = GetBookForGrid(reader)
                Books.Add(Book)
            End While
            reader.Close()

            Return Books

        End Function




        Public Shared Function GetBookInfo(ByVal libID As Guid) As Book

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_libID", libID)


            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_BookSelLibSummaryByLibID", params)

            If db.HasError Then Throw db.ErrorException

            'Dim Books As New BookCollection
            'While reader.Read
            reader.Read()
            Dim Book As Book = GetBookInfo(reader)
            'Books.Add(Book)
            'End While
            reader.Close()

            Return Book

        End Function

        Public Shared Function GetBookForToolTip(ByVal libID As Guid) As Book

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_libID", libID)


            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LibrarySelByLibIDForToolTip", params)

            If db.HasError Then Throw db.ErrorException

            'Dim Books As New BookCollection
            'While reader.Read
            reader.Read()
            Dim Book As Book = GetBookForToolTip(reader)
            'Books.Add(Book)
            'End While
            reader.Close()

            Return Book

        End Function

        Public Shared Function InsertBook(ByVal Book As Book) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(4) As MySqlParameter

            params(0) = New MySqlParameter("_libID", Book.libID.ToString())
            params(1) = New MySqlParameter("_libName", General.DbReplace(Book.libName))
            params(2) = New MySqlParameter("_libSubject", General.DbReplace(Book.libSubject))
            params(3) = New MySqlParameter("_libSummary", General.DbReplace(Book.libSummary))

            Book.libFile = Common.FileManager.GetFileInBinaryFormat(Book.libFileName)
            params(4) = New MySqlParameter("_libFile", IIf(Nothing, DBNull.Value, Book.libFile))

            Dim result As Integer = db.ExecuteProcedure("stpDad_LibraryIns", params)

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function

        Public Shared Function DeleteBook(ByVal libID As Guid) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
            Dim params(0) As MySqlParameter

            params(0) = New MySqlParameter("_libID", libID)

            Dim rocount As Integer = CInt(db.ExecuteProcedure("stpDad_BookDel", params))

            If db.HasError Then Throw db.ErrorException
            Return True

        End Function


        Public Shared Function GetLibFileByLibID(ByVal libID As Guid) As Byte()

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_libID", libID)


            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LibrarySelLibFileByLibID", params)

            If db.HasError Then Throw db.ErrorException

            'Dim Books As New BookCollection
            'While reader.Read
            reader.Read()
            Dim LibFile As Byte() = GetLibFile(reader)
            'Books.Add(Book)
            'End While
            reader.Close()

            Return LibFile

        End Function

        Public Shared Function GetBookByLibID(ByVal LibID As Guid) As Book

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_LibID", LibID)


            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LibrarySelByLibID", params)

            If db.HasError Then Throw db.ErrorException

            'Dim Books As New BookCollection
            'While reader.Read
            reader.Read()
            Dim Book As Book = GetBookForEdit(reader)
            'Books.Add(Book)
            'End While
            reader.Close()

            Return Book

        End Function

        Public Shared Function UpdateBookWithFile(ByVal Book As Book) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
            Dim params(4) As MySqlParameter

            params(0) = New MySqlParameter("_libID", Book.libID)

            params(1) = New MySqlParameter("_libName", General.DbReplace(Book.libName))
            params(2) = New MySqlParameter("_libSubject", General.DbReplace(Book.libSubject))
            params(3) = New MySqlParameter("_libSummary", General.DbReplace(Book.libSummary))

            'Book.HasFile
            'Book.libFileName
            Book.libFile = Common.FileManager.GetFileInBinaryFormat(Book.libFileName, "TempPdfBook")
            params(4) = New MySqlParameter("_libFile", IIf(Nothing, DBNull.Value, Book.libFile))
            
            Dim result As Integer = db.ExecuteProcedure("stpDad_LibraryUpdWithFile", params)

            If db.HasError Then Throw db.ErrorException
            Return True


        End Function

        Public Shared Function UpdateBookWithoutFile(ByVal Book As Book) As Boolean

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)
            Dim params(3) As MySqlParameter

            params(0) = New MySqlParameter("_libID", Book.libID)

            params(1) = New MySqlParameter("_libName", General.DbReplace(Book.libName))
            params(2) = New MySqlParameter("_libSubject", General.DbReplace(Book.libSubject))
            params(3) = New MySqlParameter("_libSummary", General.DbReplace(Book.libSummary))

            'Book.HasFile
            'Book.libFileName
            ' Book.libFile = Common.FileManager.GetFileInBinaryFormat(Book.libFileName)
            ' params(4) = New MySqlParameter("_libFile", IIf(Nothing, DBNull.Value, Book.libFile))

            Dim result As Integer = db.ExecuteProcedure("stpDad_LibraryUpdWithoutFile", params)

            If db.HasError Then Throw db.ErrorException
            Return True


        End Function




#Region "Utility"


        Private Shared Function GetBookForGrid(ByVal reader As IDataReader) As Book

            If reader Is Nothing Then Return Nothing

            Dim Book As New Book
            Book.libID = DbAccessLayer.SqlDataHelper.GetGuid(reader, "libID")
            Book.libName = DbAccessLayer.SqlDataHelper.GetString(reader, "libName")
            Book.libSubject = DbAccessLayer.SqlDataHelper.GetString(reader, "libSubject")

            Return Book

        End Function


        Private Shared Function GetBookForEdit(ByVal reader As IDataReader) As Book

            If reader Is Nothing Then Return Nothing

            Dim Book As New Book
            ' Book.libID = DbAccessLayer.SqlDataHelper.GetGuid(reader, "libID")
            Book.libName = DbAccessLayer.SqlDataHelper.GetString(reader, "libName")
            Book.libSubject = DbAccessLayer.SqlDataHelper.GetString(reader, "libSubject")
            Book.libSummary = DbAccessLayer.SqlDataHelper.GetString(reader, "libSummary")
            Book.libFile = DbAccessLayer.SqlDataHelper.GetBytes(reader, "libFile")

            Return Book

        End Function


        Private Shared Function GetBookInfo(ByVal reader As IDataReader) As Book

            If reader Is Nothing Then Return Nothing

            Dim Book As New Book
            Book.libSummary = DbAccessLayer.SqlDataHelper.GetString(reader, "libSummary")
            Book.HasFile = Not (DbAccessLayer.SqlDataHelper.GetBoolean(reader, "HasFile"))
            'Book.libFile = DbAccessLayer.SqlDataHelper.GetBytes(reader, "libFile")

            Return Book

        End Function

        Private Shared Function GetBookForToolTip(ByVal reader As IDataReader) As Book

            If reader Is Nothing Then Return Nothing

            Dim Book As New Book
            Book.libName = DbAccessLayer.SqlDataHelper.GetString(reader, "libName")
            Book.libSubject = DbAccessLayer.SqlDataHelper.GetString(reader, "libSubject")

            Return Book

        End Function

        Private Shared Function GetLibFile(ByVal reader As IDataReader) As Byte()

            If reader Is Nothing Then Return Nothing

            Dim LibFile As Byte()
            LibFile = DbAccessLayer.SqlDataHelper.GetBytes(reader, "LibFile")

            Return LibFile

        End Function



#End Region


    End Class

End Namespace
