Imports System.IO
Imports System.Security.Cryptography
Imports System.Text


Namespace HS.General


    Public Class GeneralString


        Public Shared Function DbReplace(ByVal value As String) As String

            Return value.Replace("ی", "ي").Replace("ک", "ك").Replace("'", "''").ToString

        End Function

        Public Shared Function DBNull(ByVal Field As Object, Optional ByVal NullOut As String = "") As String
            Try

                If IsDBNull(Field) Then
                    Return NullOut
                Else
                    Return Field.ToString
                End If

            Catch ex As Exception
                Return ""
            End Try

        End Function


        Public Shared Function GetNullableValue(Of T)(ByVal Field As Object, Optional ByVal NullOut As String = "") As T 'where T : class
            Try

                If IsDBNull(Field) Then
                    Return Nothing
                Else
                    Return CType(Field, T)
                End If

            Catch ex As Exception
                'Return ""
            End Try

            'Public Shared Function Create(Of T As Class)() As T


            '    If InlineAssignHelper(GetType(T).ToString(), "sometype") Then



            '        Return TryCast(SomeTypeFactory.Create(), T)
            '    End If

            'End Function




        End Function


        Public Shared Function ReverseSlashString(ByVal SlashStr As String) As String

            Dim str() As String = SlashStr.Split("/")

            Dim NewStr As String = String.Empty
            For i As Integer = str.Length - 1 To 0 Step -1
                NewStr += str(i) + "/"
            Next
            NewStr = NewStr.Remove(Len(NewStr) - 1)

            Return NewStr

        End Function



     


#Region "Crypt"


        Public Shared Function EncryptText(ByVal strText As String) As String
            Return Encrypt(strText, "HassanAmin")
        End Function

        Public Shared Function DecryptText(ByVal strText As String) As String
            Return Decrypt(strText, "HassanAmin")
        End Function


        Private Shared Function Encrypt(ByVal _Text As String, ByVal _Key As String) As String

            Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

            Try

                Dim KeyByte() As Byte = Encoding.UTF8.GetBytes(Left(_Key, 8))
                Dim TextByte() As Byte = Encoding.UTF8.GetBytes(_Text)

                Dim _Stream As New MemoryStream()

                Dim _Crypt As New DESCryptoServiceProvider()
                Dim _CryptoStream As New CryptoStream(_Stream, _Crypt.CreateEncryptor(KeyByte, IV), CryptoStreamMode.Write)
                _CryptoStream.Write(TextByte, 0, TextByte.Length)
                _CryptoStream.FlushFinalBlock()

                Return Convert.ToBase64String(_Stream.ToArray())

            Catch ex As Exception
                Return ex.Message
            End Try

        End Function

        Private Shared Function Decrypt(ByVal _Text As String, ByVal _Key As String) As String

            Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
            Dim TextByte(_Text.Length) As Byte

            Try

                Dim KeyByte() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(_Key, 8))
                TextByte = Convert.FromBase64String(_Text)

                Dim _Stream As New MemoryStream()

                Dim _Crypt As New DESCryptoServiceProvider()
                Dim _CryptoStream As New CryptoStream(_Stream, _Crypt.CreateDecryptor(KeyByte, IV), CryptoStreamMode.Write)
                _CryptoStream.Write(TextByte, 0, TextByte.Length)
                _CryptoStream.FlushFinalBlock()

                Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
                Return encoding.GetString(_Stream.ToArray())

            Catch ex As Exception
                Return ex.Message
            End Try

        End Function



#End Region





    End Class


End Namespace