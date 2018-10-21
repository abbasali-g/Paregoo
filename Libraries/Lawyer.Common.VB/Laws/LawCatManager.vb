Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient

Namespace Laws

    Public Class LawCatManager


        Public Shared Function GetLawCat() As LawCatCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("_LawID", LawID)


            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawCatSelAll", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim LawCatCollection As New LawCatCollection
            While reader.Read
                'reader.Read()
                Dim LawCat As LawCat = GetLawCat(reader)
                LawCatCollection.Add(LawCat)
            End While
            reader.Close()

            Return LawCatCollection

        End Function


#Region "Utility"


        Private Shared Function GetLawCat(ByVal reader As IDataReader) As LawCat

            If reader Is Nothing Then Return Nothing

            Dim LawCat As New LawCat
            LawCat.lawCatID = DbAccessLayer.MySqlDataHelper.GetInt(reader, "lawCatID")
            LawCat.lawCatName = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawCatName")
            LawCat.lawCatLR = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "lawCatLR")

            Return LawCat

        End Function

#End Region



    End Class

End Namespace
