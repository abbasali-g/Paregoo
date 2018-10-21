Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Data.OleDb

Namespace HS.Dal


    Public Class Access


        Public Sub New(ByVal ConName As String)
            ' "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MDBMAMAGAN.mdb"
            _conString = WebConfigurationManager.ConnectionStrings(ConName).ConnectionString

        End Sub

        Public Sub New()
            '  _conString = WebConfigurationManager.ConnectionStrings("ConAc").ConnectionString
        End Sub



#Region "- Property -"


        Private _conString As String
        Public ReadOnly Property conString() As String
            Get
                Return _conString
            End Get
        End Property




        Private _HasError As Boolean = False
        Public ReadOnly Property HasError() As Boolean
            Get
                Return _HasError
            End Get

        End Property


        Private _Exception As Exception = Nothing
        Public ReadOnly Property Exception() As Exception
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

        Public Sub Clear()

            _Message = Nothing
            _HasError = Nothing

        End Sub


#End Region



        Public Function GetDataTableFromText(ByVal Quary As String, ByVal param() As OleDbParameter) As DataTable

            Dim Dt As New DataTable

            Try


                Dim con As OleDbConnection = New OleDbConnection(_conString)
                Dim dad As OleDbDataAdapter = New OleDbDataAdapter(Quary, con) 'aslo we can make dad with command -->  '    Dim cmd As OleDbCommand = New OleDbCommand(query, ConString)   '    Dim adt4 As OleDbDataAdapter = New OleDbDataAdapter(cmd)


                If param IsNot Nothing Then
                    Dim paramCollection As OleDbParameterCollection = dad.SelectCommand.Parameters
                    For i As Integer = 0 To param.Length - 1
                        If param(i) IsNot Nothing Then
                            paramCollection.Add(param(i))
                        End If
                    Next
                End If
                ' sqlCmd.Parameters.AddRange(New SqlParameter() {New SqlParameter("@UserName", UserName), New SqlParameter("@FormCatID", FormCatID)})


                Using dad
                    dad.Fill(Dt)
                End Using


                If Dt.Rows.Count = 0 Then
                    _Message = "رکوردی پیدا نشد"
                Else
                    _Message = "عملیات  با موفقیت انجام شد ."
                End If

                Return Dt

            Catch ex As OleDbException
                _HasError = True
                _Exception = ex
                SetMessage(ex.Message)
                Return Nothing
            Catch ex As Exception
                _HasError = True
                _Exception = ex
                _Message = "خطا در انجام عملیات !!!..."
                Return Nothing
            End Try

        End Function

        Public Function GetDataRowFromText(ByVal Quary As String, ByVal param() As OleDbParameter) As DataRow

            Dim Dt As New DataTable

            Try

                Dim con As OleDbConnection = New OleDbConnection(_conString)
                Dim dad As OleDbDataAdapter = New OleDbDataAdapter(Quary, con)

                If param IsNot Nothing Then
                    Dim paramCollection As OleDbParameterCollection = dad.SelectCommand.Parameters
                    For i As Integer = 0 To param.Length - 1
                        If param(i) IsNot Nothing Then
                            paramCollection.Add(param(i))
                        End If
                    Next
                End If


                Using dad
                    dad.Fill(Dt)
                End Using

                If Dt.Rows.Count = 0 Then
                    _Message = "رکوردی پیدا نشد"
                    Return Nothing
                Else
                    _Message = "عملیات  با موفقیت انجام شد ."
                    Return Dt.Rows(0)
                End If


            Catch ex As OleDbException
                _HasError = True
                _Exception = ex
                SetMessage(ex.Message)
                Return Nothing
            Catch ex As Exception
                _HasError = True
                _Exception = ex
                _Message = ex.Message
                Return Nothing
            End Try

        End Function

        Public Function GetScalarFromText(ByVal Quary As String, ByVal param() As OleDbParameter) As Integer

            Dim _new As Integer = 0

            Try

                Dim con As New OleDbConnection(_conString)
                Dim cmd As New OleDbCommand(Quary, con)

                If param IsNot Nothing Then
                    Dim paramCollection As OleDbParameterCollection = cmd.Parameters
                    For i As Integer = 0 To param.Length - 1
                        If param(i) IsNot Nothing Then
                            paramCollection.Add(param(i))
                        End If
                    Next
                End If


                Using con
                    con.Open()
                    '   _new = CInt(General.Utilities.GetNullableValue(cmd.ExecuteScalar(), "0"))
                End Using


                Return _new


            Catch ex As OleDbException
                _HasError = True
                _Exception = ex
                SetMessage(ex.Message)
                Return Nothing
            Catch ex As Exception
                _HasError = True
                _Exception = ex
                _Message = "خطا در انجام عملیات !!!..."
                Return Nothing
            End Try

        End Function

        Public Function ExecuteText(ByVal Quary As String, ByVal param() As OleDbParameter) As Integer

            Dim result As Integer = 0

            Try

                Dim con As OleDbConnection = New OleDbConnection(_conString)
                Dim cmd As OleDbCommand = New OleDbCommand(Quary, con)


                If param IsNot Nothing Then
                    Dim paramCollection As OleDbParameterCollection = cmd.Parameters
                    For i As Integer = 0 To param.Length - 1
                        If param(i) IsNot Nothing Then
                            paramCollection.Add(param(i))
                        End If
                    Next
                End If


                Using con
                    con.Open()
                    result = CType(cmd.ExecuteNonQuery(), Integer)
                End Using


                _Message = "عملیات  با موفقیت انجام شد ."
                Return result


            Catch ex As OleDbException
                _HasError = True
                _Exception = ex
                SetMessage(ex.Message)
                Return Nothing
            Catch ex As Exception
                _HasError = True
                _Exception = ex
                _Message = "خطا در انجام عملیات !!!..."
                Return Nothing
            End Try

        End Function



       
    End Class

End Namespace
