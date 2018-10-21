Imports System.IO

Namespace LawyerError

    Public Class ErrorManager


        Public Shared Sub WriteMessage(ByVal functionName As String, ByVal errorMsg As String, ByVal frmName As String)

            Try

                Dim _File As String = Common.FileManager.GetErrorFilePath()

                Dim sw As StreamWriter = Nothing

                If _File <> String.Empty Then

                    If Not File.Exists(_File) Then

                        sw = New StreamWriter(File.Create(_File))

                    End If

                    If sw Is Nothing Then

                        sw = New StreamWriter(_File, True)

                    End If

                    sw.WriteLine()

                    sw.WriteLine("---------------------" & "نام فرم :" & frmName & "---------------------")

                    sw.WriteLine(functionName)

                    sw.Write(errorMsg)

                    sw.Flush()

                    sw.Close()

                End If

            Catch ex As Exception

            End Try

        End Sub

        Public Shared Function ReadMessage() As String

            Try

                Dim content As String = String.Empty

                Dim sr As StreamReader = Nothing

                Dim _File As String = Common.FileManager.GetErrorFilePath()

                If _File <> String.Empty Then

                    If Not File.Exists(_File) Then

                        sr = New StreamReader(File.Create(_File))

                    End If

                    If sr Is Nothing Then

                        sr = New StreamReader(_File)

                    End If

                    'parameter.Subject = sr.ReadLine()

                    content = sr.ReadLine() & vbCrLf

                    Do While sr.Peek() >= 0

                        content &= sr.ReadLine() & vbCrLf

                    Loop

                    sr.Close()

                    Return content

                Else

                    Return Nothing

                End If



            Catch ex As Exception

                Return Nothing

            End Try

        End Function

        Public Shared Sub ClearFile()
            Try

                Dim _File As String = Common.FileManager.GetErrorFilePath()

                Dim sw As StreamWriter = Nothing

                If _File <> String.Empty Then


                    sw = New StreamWriter(_File)

                    sw.WriteLine()

                    sw.Flush()

                    sw.Close()

                End If

            Catch ex As Exception

            End Try

        End Sub

    End Class

End Namespace


