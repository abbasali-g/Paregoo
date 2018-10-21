Imports System

Namespace CommonVB

    Public Class SecurityHelper : Inherits Global.Common.Security.SecurityHelper

        Private Shared ReadOnly Property Key() As String

            Get

                Return "1213214532123454"

            End Get

        End Property

        Public Shared Shadows Function Encrypt(ByVal PlainText As String) As String

            Return Global.Common.Security.SecurityHelper.Encrypt(PlainText, Key)

        End Function

        Public Shared Shadows Function Encrypt(ByVal PlainText As String, ByVal key As String) As String

            If Not String.IsNullOrEmpty(PlainText) Then _
                Return Global.Common.Security.SecurityHelper.Encrypt(PlainText, key)

            Return String.Empty

        End Function

        Public Shared Shadows Function Decrypt(ByVal EncryptedText As String) As String

            If String.IsNullOrEmpty(EncryptedText) Then Return String.Empty

            'Dim _dycrpt As String = EncryptedText.Replace(" ", "+")

            Try

                Return Global.Common.Security.SecurityHelper.Decrypt(EncryptedText, Key)

            Catch ex As Exception
            End Try

            Return String.Empty

        End Function

        Public Shared Shadows Function Decrypt(ByVal EncryptedText As String, ByVal key As String) As String

            If String.IsNullOrEmpty(EncryptedText) Then Return String.Empty

            Try

                If Not String.IsNullOrEmpty(EncryptedText) Then _
                    Return Global.Common.Security.SecurityHelper.Decrypt(EncryptedText, key)

            Catch ex As Exception

            End Try

            Return String.Empty

        End Function

    End Class

End Namespace