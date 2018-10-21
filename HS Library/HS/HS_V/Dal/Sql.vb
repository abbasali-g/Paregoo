Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Configuration
'Imports MySql.Data.MySqlClient
'Imports MySql.Data

Namespace HS.Dal

    

    Public Class Sql


#Region "Property"



        Private _ConnectionString As String
        Public ReadOnly Property ConnectionString() As String
            Get
                Return Me._ConnectionString
            End Get
        End Property

        Private _Connection As SqlConnection
        Public ReadOnly Property Connection() As IDbConnection
            Get
                Return Me._Connection
            End Get
        End Property

        Public ReadOnly Property SqlConnection() As SqlConnection
            Get
                Return DirectCast(Connection, SqlConnection)
            End Get
        End Property

      

        Private _HandleError As Boolean = True
        Public Property HandleError() As Boolean
            Get
                Return _HandleError
            End Get
            Set(ByVal value As Boolean)
                _HandleError = value

                Me.ClearError()
            End Set
        End Property





        Private _HasError As Boolean = False
        Public ReadOnly Property HasError() As Boolean
            Get
                Return _HasError
            End Get
        End Property

        Private _Exception As Exception = Nothing
        Public ReadOnly Property ErrorException() As Exception
            Get
                Return _Exception
            End Get
        End Property


        Private _Message As String
        Public Property Message() As String
            Get
                Return _Message
            End Get
            Set(ByVal value As String)
                _Message = value
            End Set

        End Property



        Public Sub ClearError()

            _HasError = False
            _Exception = Nothing

        End Sub


        Private Sub SetMessage(ByVal Message As String)

            Dim _Bool As Boolean = True
            Select Case _Bool

                Case Message.Contains("No value given for one or more required parameters.")
                    _Message = "اشکال در فیلدها و یا پارامترهای ارسالی"
                Case Message.Contains("Data type mismatch in criteria expression.")
                    _Message = "اشکال در نوع فیلدهای ارسالی"
                Case Message.Contains("Could not find file")
                    _Message = "فایل بانک اطلاعاتی پیدا نشد."
                Case Message.Contains("already opened exclusively")
                    _Message = "فایل بانک اطلاعاتی باز است."
                Case Else
                    _Message = Message

            End Select

        End Sub



        Private Sub SetError(ByVal ex As Exception)

            Me._HasError = True
            Me._Exception = ex

            If Me._Connection.State = ConnectionState.Open Then
                Try
                    Me._Connection.Close()
                Catch
                End Try
            End If

            If Not _HandleError Then
                Throw ex
            End If

            SetMessage(ex.Message) ' by sarandy

        End Sub

        


#End Region

#Region " New "

        ' private static readonly string _conString;
        'Static Sql0()
        '{
        '    _conString = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        '}

        ' Private Shared ReadOnly _conString As String
        'Shared Sub New()
        '    '_conString = WebConfigurationManager.ConnectionStrings("constr").ConnectionString
        'End Sub


        Public Sub New()
            SetConnectionString(-1, Nothing, True)
        End Sub

        Public Sub New(ByVal HandleError As Boolean)
            SetConnectionString(-1, Nothing, HandleError)
        End Sub

        Public Sub New(ByVal ConStrType As Enums.ConnectionStringSourceType, ByVal ConNameOrConStr As String)
            SetConnectionString(CInt(ConStrType), ConNameOrConStr, True)
        End Sub

        Public Sub New(ByVal ConStrType As Enums.ConnectionStringSourceType, ByVal ConNameOrConStr As String, ByVal HandleError As Boolean)
            SetConnectionString(CInt(ConStrType), ConNameOrConStr, HandleError)
        End Sub

        Private Sub SetConnectionString(ByVal ConStrType As Integer, ByVal ConNameOrConStr As String, ByVal handleError As Boolean)

            Select Case ConStrType

                Case CInt(Enums.ConnectionStringSourceType.ConnectionString) '0

                    _ConnectionString = ConNameOrConStr
                    Exit Select

                Case CInt(Enums.ConnectionStringSourceType.AppConfigConName) '1

                    _ConnectionString = ConfigurationManager.ConnectionStrings(ConNameOrConStr).ConnectionString
                    Exit Select

                Case CInt(Enums.ConnectionStringSourceType.WebConfigConName) '2

                    _ConnectionString = WebConfigurationManager.ConnectionStrings(ConNameOrConStr).ConnectionString
                    Exit Select

                Case Else


                    Try
                        _ConnectionString = ConfigurationManager.ConnectionStrings("SqlConStr").ConnectionString
                    Catch
                        Try
                            _ConnectionString = WebConfigurationManager.ConnectionStrings("SqlConStr").ConnectionString
                        Catch
                            Throw New Exception("ConStr parameter not found in App.config or Web.config files.")
                        End Try
                    End Try
                    Exit Select

            End Select


            _Connection = New SqlConnection(Me._ConnectionString)
            _HandleError = handleError


        End Sub


#End Region

#Region "- DatabaseAccessLayer Members -"


        Public Function BuildCommand(ByVal CmdType As System.Data.CommandType, ByVal CommandText As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As IDbCommand

            Me.ClearError()

            Using Cmd As New SqlCommand(CommandText, _Connection)
                Cmd.CommandType = CmdType

                If Parameters IsNot Nothing Then
                    Try
                        Cmd.Parameters.Clear()
                        For Each parameter As SqlParameter In Parameters
                            Cmd.Parameters.Add(parameter)
                        Next
                    Catch ex As Exception
                        Me.SetError(ex)
                    End Try
                End If

                Return DirectCast(Cmd, IDbCommand)

            End Using


        End Function

        Public Function BuildSqlCommand(ByVal CommandType As CommandType, ByVal CommandText As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As SqlCommand
            Return DirectCast(BuildCommand(CommandType, CommandText, Parameters), SqlCommand)
        End Function



        Public Function ExecuteProcedure(ByVal SP As String, ByVal ParamArray Param As System.Data.IDataParameter()) As Integer

            Me.ClearError()
            Dim result As Integer = Integer.MinValue

            Using command As SqlCommand = DirectCast(BuildCommand(CommandType.StoredProcedure, SP, Param), SqlCommand)
                command.CommandTimeout = 0

                Try

                    Using _Connection
                        _Connection.Open()
                        result = command.ExecuteNonQuery()
                    End Using

                Catch ex As Exception
                    Me.SetError(ex)
                End Try

            End Using

            Return result

        End Function

        Public Function ExecuteQuery(ByVal Query As String, ByVal ParamArray Param As System.Data.IDataParameter()) As Integer

            Me.ClearError()
            Dim result As Integer = Integer.MinValue

            Using command As SqlCommand = DirectCast(BuildCommand(CommandType.Text, Query, Param), SqlCommand)
                command.CommandTimeout = 0

                Try

                    Using _Connection
                        _Connection.Open()
                        result = command.ExecuteNonQuery()
                    End Using

                Catch ex As Exception
                    Me.SetError(ex)
                End Try

            End Using

            Return result

        End Function


        Public Function GetScalarFromProcedure(ByVal SP As String, ByVal ParamArray Param As System.Data.IDataParameter()) As Object

            Me.ClearError()
            Dim result As Object = Nothing

            Using command As SqlCommand = DirectCast(BuildCommand(CommandType.StoredProcedure, SP, Param), SqlCommand)
                command.CommandTimeout = 0

                Try

                    Using _Connection
                        _Connection.Open()
                        result = command.ExecuteScalar()
                    End Using

                Catch ex As Exception
                    Me.SetError(ex)
                End Try

            End Using

            Return result

        End Function

        Public Function GetScalarFromQuery(ByVal Query As String, ByVal ParamArray Param As System.Data.IDataParameter()) As Object

            Me.ClearError()
            Dim result As Object = Nothing

            Using command As SqlCommand = DirectCast(BuildCommand(CommandType.Text, Query, Param), SqlCommand)
                command.CommandTimeout = 0

                Try

                    Using _Connection
                        _Connection.Open()
                        result = command.ExecuteScalar()
                    End Using

                Catch ex As Exception
                    Me.SetError(ex)
                End Try

            End Using

            Return result

        End Function


        Public Function GetDataTableFromProcedure(ByVal TableName As String, ByVal StoredProcedureName As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As DataTable

            Me.ClearError()

            Using Dt As New DataTable()

                If TableName IsNot Nothing Then
                    Dt.TableName = TableName
                End If

                Using DataAdapter As New SqlDataAdapter()
                    DataAdapter.SelectCommand = DirectCast(Me.BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters), SqlCommand)
                    DataAdapter.SelectCommand.CommandTimeout = 0

                    Try

                        Using _Connection
                            DataAdapter.Fill(Dt)
                        End Using

                    Catch ex As Exception
                        Me.SetError(ex)
                        Return Nothing
                    End Try

                End Using

                Return Dt

            End Using

        End Function

        Public Function GetDataTableFromProcedure(ByVal StoredProcedureName As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As DataTable
            Return GetDataTableFromProcedure(Nothing, StoredProcedureName, Parameters)
        End Function

        Public Function GetDataTableFromSqlCommandText(ByVal TableName As String, ByVal SqlCommandText As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As DataTable

            Me.ClearError()

            Using Dt As New DataTable()

                If TableName IsNot Nothing Then
                    Dt.TableName = TableName
                End If

                Using DataAdapter As New SqlDataAdapter()
                    DataAdapter.SelectCommand = DirectCast(Me.BuildCommand(CommandType.Text, SqlCommandText, Parameters), SqlCommand)
                    DataAdapter.SelectCommand.CommandTimeout = 0

                    Try
                        Using _Connection
                            DataAdapter.Fill(Dt)
                        End Using
                    Catch ex As Exception
                        Me.SetError(ex)
                        Return Nothing
                    End Try

                End Using

                Return Dt

            End Using

        End Function

        Public Function GetDataTableFromSqlCommandText(ByVal SqlCommandText As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As DataTable
            Return GetDataTableFromSqlCommandText(Nothing, SqlCommandText, Parameters)
        End Function


        Public Function GetDataSetFromProcedure(ByVal StoredProcedureName As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As DataSet

            Me.ClearError()

            Using Ds As New DataSet()
                Using DataAdapter As New SqlDataAdapter()
                    DataAdapter.SelectCommand = DirectCast(Me.BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters), SqlCommand)
                    DataAdapter.SelectCommand.CommandTimeout = 0

                    Try
                        Using _Connection
                            DataAdapter.Fill(Ds)
                        End Using
                    Catch ex As Exception
                        Me.SetError(ex)
                        Return Nothing
                    End Try

                End Using

                Return Ds

            End Using
        End Function

        Public Function GetDataSetFromSqlCommandText(ByVal SqlCommandText As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As DataSet

            Me.ClearError()

            Using Ds As New DataSet()

                Using DataAdapter As New SqlDataAdapter()
                    DataAdapter.SelectCommand = DirectCast(Me.BuildCommand(CommandType.Text, SqlCommandText, Parameters), SqlCommand)
                    DataAdapter.SelectCommand.CommandTimeout = 0

                    Try
                        Using _Connection
                            DataAdapter.Fill(Ds)
                        End Using
                    Catch ex As Exception
                        Me.SetError(ex)
                        Return Nothing
                    End Try

                End Using

                Return Ds

            End Using
        End Function


        Public Function GetDataRowFromProcedure(ByVal StoredProcedureName As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As DataRow

            Me.ClearError()

            Using Dt As New DataTable()

                Using DataAdapter As New SqlDataAdapter()
                    DataAdapter.SelectCommand = DirectCast(BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters), SqlCommand)
                    DataAdapter.SelectCommand.CommandTimeout = 0

                    Try
                        Using _Connection
                            DataAdapter.Fill(Dt)
                        End Using
                    Catch ex As Exception
                        Me.SetError(ex)
                        Return Nothing
                    End Try

                End Using

                If Dt.Rows.Count > 0 Then
                    Return Dt.Rows(0)
                Else
                    Return Nothing
                End If

            End Using
        End Function

        Public Function GetDataRowFromSqlCommandText(ByVal SqlCommandText As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As DataRow

            Me.ClearError()

            Using Dt As New DataTable()

                Using DataAdapter As New SqlDataAdapter()
                    DataAdapter.SelectCommand = DirectCast(BuildCommand(CommandType.Text, SqlCommandText, Parameters), SqlCommand)
                    DataAdapter.SelectCommand.CommandTimeout = 0

                    Try
                        Using _Connection
                            DataAdapter.Fill(Dt)
                        End Using
                    Catch ex As Exception
                        Me.SetError(ex)
                        Return Nothing
                    End Try
                End Using

                If Dt.Rows.Count > 0 Then
                    Return Dt.Rows(0)
                Else
                    Return Nothing
                End If
            End Using

        End Function


        '~~~~~~~~~~~~~~~~~~~~~ Reders must be closed.

        Public Function GetDataReaderFromProcedure(ByVal StoredProcedureName As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As IDataReader

            Me.ClearError()
            Dim result As SqlDataReader = Nothing

            Using command As SqlCommand = DirectCast(BuildCommand(CommandType.StoredProcedure, StoredProcedureName, Parameters), SqlCommand)
                command.CommandTimeout = 0

                Try

                    Me._Connection.Open()
                    result = command.ExecuteReader(CommandBehavior.CloseConnection)

                Catch ex As Exception
                    Me.SetError(ex)
                End Try

            End Using

            Return DirectCast(result, IDataReader)

        End Function

        Public Function GetSqlDataReaderFromProcedure(ByVal StoredProcedureName As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As SqlDataReader
            Return DirectCast(GetDataReaderFromProcedure(StoredProcedureName, Parameters), SqlDataReader)
        End Function

        Public Function GetDataReaderFromCommandText(ByVal SqlCommandText As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As IDataReader

            Me.ClearError()
            Dim result As SqlDataReader = Nothing

            Using command As SqlCommand = DirectCast(BuildCommand(CommandType.Text, SqlCommandText, Parameters), SqlCommand)
                command.CommandTimeout = 0

                Try
                    Me._Connection.Open()
                    result = command.ExecuteReader(CommandBehavior.CloseConnection)
                Catch ex As Exception
                    Me.SetError(ex)
                End Try

            End Using

            Return DirectCast(result, IDataReader)
        End Function

        Public Function GetSqlDataReaderFromCommandText(ByVal SqlCommandText As String, ByVal ParamArray Parameters As System.Data.IDataParameter()) As SqlDataReader
            Return DirectCast(GetDataReaderFromCommandText(SqlCommandText, Parameters), SqlDataReader)
        End Function



#End Region


        Public Function ExecuteSqlTextWithTransaction(ByVal Quary As String, ByVal Param As SqlParameter()) As Object


            Dim StrScript As String = String.Empty

            '----------------------

            StrScript += "BEGIN TRY "
            StrScript += "BEGIN TRANSACTION "

            StrScript += Quary & " "
            'StrScript += "select 1/0 aa ";

            StrScript += "COMMIT TRAN "
            StrScript += "END TRY "


            StrScript += "BEGIN CATCH "
            StrScript += "IF @@TRANCOUNT > 0 "
            StrScript += "ROLLBACK TRAN "
            StrScript += "DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int "
            StrScript += "SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY() "
            StrScript += "RAISERROR(@ErrMsg, @ErrSeverity, 1) "
            'StrScript +="SELECT ERROR_MESSAGE() AS ErrorMessage ";
            StrScript += "END CATCH "

            '--------------------------------------------   

            Me.ClearError()
            Dim result As Object = Nothing


            Using Cmd As SqlCommand = DirectCast(BuildCommand(CommandType.Text, StrScript, Param), SqlCommand)
                Cmd.CommandTimeout = 0


                Try
                    Using Cmd.Connection
                        Cmd.Connection.Open()
                        result = Cmd.ExecuteNonQuery()
                    End Using

                Catch ex As Exception
                    Me.SetError(ex)
                End Try

            End Using

            Return result

        End Function

        Public Function ExecuteSqlTextWithTransaction(ByVal Statemants() As String) As Integer

            ' Dim Statemants() As String = {"insert 1", "insert 2"}

            Me.ClearError()
            Dim RAffect As Integer = -1


            Using Cmd As SqlCommand = DirectCast(BuildCommand(CommandType.Text, "", Nothing), SqlCommand)
                Cmd.CommandTimeout = 0


                Try
                    Using Cmd.Connection
                        Dim Trn As SqlClient.SqlTransaction = Cmd.Connection.BeginTransaction("SampleTransaction")
                        Cmd.Transaction = Trn

                        Cmd.Connection.Open()

                        Try

                            For i = 0 To Statemants.Length - 1
                                Cmd.CommandText = Statemants(i)
                                RAffect = Cmd.ExecuteNonQuery
                            Next

                            Trn.Commit()

                        Catch ex As Exception

                            Try
                                Trn.Rollback()
                            Catch ex2 As Exception
                            End Try

                        End Try



                    End Using

                Catch ex As Exception
                    Me.SetError(ex)
                End Try

            End Using


            Return RAffect

        End Function







        'Private Function GetDataTable() As DataTable
        '    Dim sql As String = "SELECT Id, Description FROM MyTable"
        '    Using myConnection As New SqlConnection(connectionString)
        '        Using myCommand As New SqlCommand(sql, myConnection)
        '            myConnection.Open()
        '            Using myReader As SqlDataReader = myCommand.ExecuteReader()
        '                Dim myTable As New DataTable()
        '                myTable.Load(myReader)
        '                myConnection.Close()
        '                Return myTable
        '            End Using
        '        End Using
        '    End Using
        'End Function





    End Class


End Namespace