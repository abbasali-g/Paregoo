Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient
Imports NwdSolutions.Web.GeneralUtilities

Namespace Laws

    Public Class LawOnGridManager



        Public Shared Function GetSynonyms(ByVal Word As String) As DataTable 'LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("pWord", General.DbReplace(Word))

            'Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSearchByTitle", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_lawsynonymwordSelByWord", params)

            If db.HasError Then Throw db.ErrorException

            'Dim LawOnGrids As New LawOnGridCollection
            'While reader.Read
            '    Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
            '    LawOnGrids.Add(LawOnGrid)
            'End While
            'reader.Close()

            'Return LawOnGrids
            Return dt

        End Function







        Public Shared Function GetLawsByTitle(ByVal title As String, ByVal where As String) As DataTable 'LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pTitle", General.DbReplace(title))
            params(1) = New MySqlParameter("_where", IIf(where = String.Empty, DBNull.Value, where))

            'Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSearchByTitle", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_LawsSearchByTitle", params)

            If db.HasError Then Throw db.ErrorException

            'Dim LawOnGrids As New LawOnGridCollection
            'While reader.Read
            '    Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
            '    LawOnGrids.Add(LawOnGrid)
            'End While
            'reader.Close()

            'Return LawOnGrids
            Return dt

        End Function


        Public Shared Function GetLawsByTitle_Like(ByVal title As String, ByVal where As String) As DataTable 'LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pTitle", General.DbReplace(title))
            params(1) = New MySqlParameter("_where", IIf(where = String.Empty, DBNull.Value, where))

            'Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSearchByTitle_Like", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_LawsSearchByTitle_Like", params)

            If db.HasError Then Throw db.ErrorException

            'Dim LawOnGrids As New LawOnGridCollection
            'While reader.Read
            '    Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
            '    LawOnGrids.Add(LawOnGrid)
            'End While
            'reader.Close()

            'Return LawOnGrids

            Return dt

        End Function


        Public Shared Function GetRaviyyeByTitle(ByVal title As String, ByVal where As String) As DataTable 'LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pTitle", General.DbReplace(title))
            params(1) = New MySqlParameter("_where", IIf(where = String.Empty, DBNull.Value, where))

            ' Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_Law_RaviyyeSelByTitle", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_Law_RaviyyeSelByTitle", params)

            If db.HasError Then Throw db.ErrorException

            'Dim LawOnGrids As New LawOnGridCollection
            'While reader.Read
            '    Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
            '    LawOnGrids.Add(LawOnGrid)
            'End While
            'reader.Close()

            'Return LawOnGrids

            Return dt

        End Function


        Public Shared Function GetRaviyyeByTitle_Like(ByVal title As String, ByVal where As String) As DataTable 'LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pTitle", General.DbReplace(title))
            params(1) = New MySqlParameter("_where", IIf(where = String.Empty, DBNull.Value, where))

            ' Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_Law_RaviyyeSelByTitle_Like", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_Law_RaviyyeSelByTitle_Like", params)

            If db.HasError Then Throw db.ErrorException

            'Dim LawOnGrids As New LawOnGridCollection
            'While reader.Read
            '    Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
            '    LawOnGrids.Add(LawOnGrid)
            'End While
            'reader.Close()

            'Return LawOnGrids

            Return dt

        End Function



        Public Shared Function GetLawsByKeyWord(ByVal Keyword As String, ByVal where As String) As LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pKeyWordName", General.DbReplace(Keyword))
            params(1) = New MySqlParameter("_Where", IIf(where = String.Empty, DBNull.Value, where))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSearchByKeyWordName", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawOnGrids As New LawOnGridCollection
            While reader.Read
                Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
                LawOnGrids.Add(LawOnGrid)
            End While
            reader.Close()

            Return LawOnGrids

        End Function


        Public Shared Function GetRaviyyeByKeyWord(ByVal Keyword As String, ByVal where As String) As LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("_lawkeywordname", General.DbReplace(Keyword))
            params(1) = New MySqlParameter("_where", IIf(where = String.Empty, DBNull.Value, where))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_Law_RaviyyeSelByKeyWordName", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawOnGrids As New LawOnGridCollection
            While reader.Read
                Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
                LawOnGrids.Add(LawOnGrid)
            End While
            reader.Close()

            Return LawOnGrids

        End Function



        Public Shared Function GetLawsByLawIDInFu(ByVal userID As String) As DataTable 'LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_userID", userID) 'guid

            ' Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSelByFuForGrid", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_LawsSelByFuForGrid", params)

            If db.HasError Then Throw db.ErrorException

            'Dim LawOnGrids As New LawOnGridCollection
            'While reader.Read
            '    Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
            '    LawOnGrids.Add(LawOnGrid)
            'End While
            'reader.Close()

            'Return LawOnGrids

            Return dt

        End Function




        Public Shared Function GetLawsByContent(ByVal Content As String, ByVal Where As String) As DataTable 'LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pContent", General.DbReplace(Content))
            params(1) = New MySqlParameter("_Where", IIf(Where = String.Empty, DBNull.Value, Where))

            'Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSearchByContent", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_LawsSearchByContent", params)

            If db.HasError Then Throw db.ErrorException

            'Dim LawOnGrids As New LawOnGridCollection
            'While reader.Read
            '    Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
            '    LawOnGrids.Add(LawOnGrid)
            'End While
            'reader.Close()

            'Return LawOnGrids

            Return dt

        End Function


        'for tree
        Public Shared Function GetLawsByContent_ForTree(ByVal Content As String, ByVal Where As String) As LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pContent", General.DbReplace(Content))
            params(1) = New MySqlParameter("_Where", IIf(Where = String.Empty, DBNull.Value, Where))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSearchByContent", params)


            If db.HasError Then Throw db.ErrorException

            Dim LawOnGrids As New LawOnGridCollection
            While reader.Read
                Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
                LawOnGrids.Add(LawOnGrid)
            End While
            reader.Close()

            Return LawOnGrids

        End Function

        Public Shared Function GetLawsByContent_Like(ByVal Content As String, ByVal Where As String) As DataTable 'LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pContent", General.DbReplace(Content))
            params(1) = New MySqlParameter("_Where", IIf(Where = String.Empty, DBNull.Value, Where))

            ' Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawsSearchByContent_Like", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_LawsSearchByContent_Like", params)


            If db.HasError Then Throw db.ErrorException

            'Dim LawOnGrids As New LawOnGridCollection
            'While reader.Read
            '    Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
            '    LawOnGrids.Add(LawOnGrid)
            'End While
            'reader.Close()

            'Return LawOnGrids

            Return dt

        End Function



        Public Shared Function GetLawsAndRaviyyeByContent(ByVal Content As String, ByVal Where As String) As LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pContent", General.DbReplace(Content))
            params(1) = New MySqlParameter("_Where", IIf(Where = String.Empty, DBNull.Value, Where))

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_Law_RavviyeSelByContent", params)

            If db.HasError Then Throw db.ErrorException

            Dim LawOnGrids As New LawOnGridCollection
            While reader.Read
                Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
                LawOnGrids.Add(LawOnGrid)
            End While
            reader.Close()

            Return LawOnGrids

        End Function


        Public Shared Function GetLawByLawIdForTitle(ByVal LawId As Integer) As String

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_LawId", LawId)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_SelLawsByLawIdForLawTitle", params)

            If db.HasError Then Throw db.ErrorException

            Dim str As String = String.Empty
            While reader.Read
                str = GetTitleFromReader(reader)
            End While
            reader.Close()

            Return str

        End Function

        Public Shared Function GetSubjectiveSearch(ByVal title As String, ByVal where As String) As DataTable 'LawOnGridCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(1) As MySqlParameter
            params(0) = New MySqlParameter("pTitle", General.DbReplace(title))
            params(1) = New MySqlParameter("_where", IIf(where = String.Empty, DBNull.Value, where))

            'Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_SubjectiveSerach", params)
            Dim dt As DataTable = db.GetDataTableFromProcedure("stpDad_SubjectiveSerach", params)

            If db.HasError Then Throw db.ErrorException

            'Dim LawOnGrids As New LawOnGridCollection
            'While reader.Read
            '    Dim LawOnGrid As LawOnGrid = GetLawFromReader(reader)
            '    LawOnGrids.Add(LawOnGrid)
            'End While
            'reader.Close()

            'Return LawOnGrids

            Return dt

        End Function


#Region "Utility"

        Private Shared Function GetLawFromReader(ByVal reader As IDataReader) As LawOnGrid

            If reader Is Nothing Then Return Nothing

            Dim LawOnGrid As New LawOnGrid
            LawOnGrid.lawID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawID")
            LawOnGrid.lawLRText = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawLRText")
            LawOnGrid.lawTitle = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawTitle")
            LawOnGrid.lawPassedDate = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawPassedDate")

            Return LawOnGrid

        End Function



        Private Shared Function GetTitleFromReader(ByVal reader As IDataReader) As String

            If reader Is Nothing Then Return String.Empty

            Dim str As String = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawTitle")

            Return str

        End Function





#End Region



    End Class


End Namespace
