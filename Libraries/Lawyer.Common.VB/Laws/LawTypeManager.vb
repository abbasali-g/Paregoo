Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient

Namespace LawTypes


    Public Class LawTypeManager


        Public Shared Function GetLawTypsForDrp() As LawTypeCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            'Dim params(0) As MySqlParameter
            'params(0) = New MySqlParameter("pTitle", title)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_LawTypeSelAll_ForDrp", Nothing)

            If db.HasError Then Throw db.ErrorException

            Dim LawTyps As New LawTypeCollection
            While reader.Read
                Dim LawType As LawType = GetLawTypeFromReaderForDrp(reader)
                LawTyps.Add(LawType)
            End While
            reader.Close()

            Return LawTyps

        End Function



#Region "Utility"




        Private Shared Function GetLawTypeFromReaderForDrp(ByVal reader As IDataReader) As LawType

            If reader Is Nothing Then Return Nothing

            Dim LawType As New LawType
            LawType.lawTypeID = DbAccessLayer.MySqlDataHelper.GetInt16(reader, "lawTypeID")
            LawType.lawTypeName = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawTypeName")
            ' LawType.lawTypeLR = DbAccessLayer.MySqlDataHelper.GetString(reader, "lawTitle")

            Return LawType

        End Function




#End Region




    End Class

End Namespace