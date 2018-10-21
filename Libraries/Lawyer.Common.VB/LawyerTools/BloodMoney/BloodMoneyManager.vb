Imports Lawyer.Common.VB.CommonSetting
Imports MySql.Data.MySqlClient

Namespace BloodMoneys

    Public Class BloodMoneyManager


        Public Shared Function GetBloodMoneyForTree(ByVal bmSex As Char) As BloodMoneyCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_bmSex", bmSex)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolsbmSelAllForTree", params)

            If db.HasError Then Throw db.ErrorException

            Dim BloodMoneyCollection As New BloodMoneyCollection

            While reader.Read
                Dim BloodMoney As BloodMoney = GetBloodMoney(reader)
                BloodMoneyCollection.Add(BloodMoney)
            End While

            reader.Close()

            Return BloodMoneyCollection

        End Function


        Public Shared Function GetLinkeChilds(ByVal bmLinkedParentID As Integer) As BloodMoneyCollection

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim params(0) As MySqlParameter
            params(0) = New MySqlParameter("_bmLinkedParentID", bmLinkedParentID)

            Dim reader As IDataReader = db.GetDataReaderFromProcedure("stpDad_ToolsbmSelLinkedChilds", params)

            If db.HasError Then Throw db.ErrorException

            Dim BloodMoneyCollection As New BloodMoneyCollection
            While reader.Read
                Dim BloodMoney As BloodMoney = GetBloodMoney(reader)
                BloodMoneyCollection.Add(BloodMoney)
            End While
            reader.Close()

            Return BloodMoneyCollection

        End Function



#Region "Utility"


        Private Shared Function GetBloodMoney(ByVal reader As IDataReader) As BloodMoney





            If reader Is Nothing Then Return Nothing

            Dim BloodMoney As New BloodMoney
            BloodMoney.bmID = DbAccessLayer.SqlDataHelper.GetInt(reader, "bmID")
            'If BloodMoney.bmID = 42 Then
            '    Dim a As String = "ddd"
            'End If

            BloodMoney.bmName = DbAccessLayer.SqlDataHelper.GetString(reader, "bmName")
            BloodMoney.bmSex = DbAccessLayer.SqlDataHelper.GetString(reader, "bmSex")
            BloodMoney.bmValue = DbAccessLayer.SqlDataHelper.GetDecimal(reader, "bmValue") 'Decimal
            'Dim s As Single = DbAccessLayer.SqlDataHelper.GetDecimal(reader, "bmValue")
            'Dim d As Double = DbAccessLayer.SqlDataHelper.GetDecimal(reader, "bmValue")
            'Dim de As Decimal = DbAccessLayer.SqlDataHelper.GetDecimal(reader, "bmValue")


            BloodMoney.bmValuLable = DbAccessLayer.SqlDataHelper.GetString(reader, "bmValuLable")
            BloodMoney.bmParentID = DbAccessLayer.SqlDataHelper.GetInt64(reader, "bmParentID") 'ifnull make long
            BloodMoney.Childs = DbAccessLayer.SqlDataHelper.GetInt(reader, "Childs")

            BloodMoney.bmCalcType = DbAccessLayer.SqlDataHelper.GetString(reader, "bmCalcType")
            BloodMoney.bmDefaultValue = DbAccessLayer.SqlDataHelper.GetReal(reader, "bmDefaultValue")
            BloodMoney.bmValueToBeAdded = DbAccessLayer.SqlDataHelper.GetDecimal(reader, "bmValueToBeAdded") 'Decimal
            BloodMoney.bmLawText = DbAccessLayer.SqlDataHelper.GetString(reader, "bmLawText")

            BloodMoney.bmLinkedParentID = DbAccessLayer.SqlDataHelper.GetInt64(reader, "bmLinkedParentID") 'ifnull make long

            BloodMoney.bmImages = DbAccessLayer.SqlDataHelper.GetString(reader, "bmImages")
            BloodMoney.bmDescription = DbAccessLayer.SqlDataHelper.GetString(reader, "bmDescription")

            Return BloodMoney





        End Function


#End Region





    End Class

End Namespace
