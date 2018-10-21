Imports System.IO

Namespace HS.FileManager.TextFile

    Public Class General


#Region "- TextFile  -"


        ' Read From a Text File
        Public Shared Function ReadToEnd(ByVal fileLoc As String) As String

            Try

                If File.Exists(fileLoc) Then
                    Using sr As StreamReader = New StreamReader(fileLoc)

                        Return sr.ReadToEnd()
                        sr.Close()
                    End Using
                Else
                    Return Nothing
                End If


            Catch ex As Exception
                Throw ex
            End Try


        End Function



        ' Write to a Text File
        Public Shared Function TextFile_Write(ByVal fileLoc As String, ByVal CanAppend As Boolean, ByVal Text As String) As String

            Try

                Using sw As StreamWriter = New StreamWriter(fileLoc, CanAppend) 'create if not exist and overwrite if exist
                    sw.Write(Text)
                    'sw.WriteLine(vbNewLine + "Hasan Amin Sarand")
                End Using


            Catch ex As Exception
                Throw ex
            End Try

            Return String.Empty

        End Function



        Public Sub AppendTextToFile(ByVal str As Integer, ByVal _File As String)

            Try


                Dim sw As StreamWriter
                ' Dim _File As String = FileManager.GetDoubtableLawFilePath() '"c:" + "\DoubtableLaw.txt" 

                ' Create a Text File
                'Dim fs As FileStream = Nothing
                If (Not File.Exists(_File)) Then
                    sw = File.CreateText(_File)
                    ' fs = File.Create(_File)
                    Using sw
                    End Using
                End If

                ' Write to a Text File (append)
                If File.Exists(_File) Then

                    sw = File.AppendText(_File)
                    Using sw ' = New StreamWriter(_File)

                        sw.WriteLine(str.ToString)
                        sw.Flush()
                        sw.Close()

                    End Using
                End If

            Catch ex As Exception
                Throw ex
            End Try



        End Sub



        Public Shared Function TextToUnicodeFile(ByVal Text As String, ByVal FileFullPath As String, Optional ByVal CanAppend As Boolean = False) As String

            Try

                Using sw As StreamWriter = New StreamWriter(FileFullPath, CanAppend, System.Text.Encoding.Unicode) 'create if not exist and overwrite if exist

                    sw.Write(Text)
                    'sw.WriteLine(vbNewLine + "Hasan Amin Sarand")
                    sw.Flush()
                    sw.Close()

                End Using

                Return FileFullPath

            Catch ex As Exception
                Throw ex
            End Try


        End Function


        ' Delete a text file
        Private Function TextFile_Delete(ByVal fileLoc As String) As String

            Try

                If File.Exists(fileLoc) Then
                    File.Delete(fileLoc)
                End If

            Catch ex As Exception
                Return ex.Message
            End Try

            Return String.Empty

        End Function
        ' Create a Text File
        Private Function TextFile_Create(ByVal fileLoc As String) As String

            Try



                If (Not File.Exists(fileLoc)) Then
                    Dim fs As FileStream = New FileStream(fileLoc, FileMode.OpenOrCreate)
                    Using fs

                    End Using
                End If

            Catch ex As Exception
                Return ex.Message
            End Try

            Return String.Empty

        End Function
























        ' Copy a Text File
        Private Sub btnCopy_Click(ByVal fileLoc As String)
            Dim fileLocCopy As String = "d:\sample1.txt"
            If File.Exists(fileLoc) Then
                ' If file already exists in destination, delete it.
                If File.Exists(fileLocCopy) Then
                    File.Delete(fileLocCopy)
                End If
                File.Copy(fileLoc, fileLocCopy)
            End If
        End Sub
        ' Move a Text file
        Private Sub btnMove_Click(ByVal fileLoc As String)
            ' Create unique file name
            Dim fileLocMove As String = "d:\sample1" & System.DateTime.Now.Ticks & ".txt"
            If File.Exists(fileLoc) Then
                File.Move(fileLoc, fileLocMove)
            End If
        End Sub

#End Region

    End Class

End Namespace
