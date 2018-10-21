Imports System.IO

Namespace HS.Data.FileBytes

    Public Class General

        Public Shared Function BytesToFile(ByVal binaryFile() As Byte, ByVal filefullName As String, Optional ByVal ignoreExist As Boolean = True) As String

            If Not ignoreExist Then
                If System.IO.File.Exists(filefullName) Then
                    Return filefullName
                End If
            End If


            Dim fs As FileStream
            Dim path As String = filefullName

            fs = New FileStream(path, FileMode.Create, FileAccess.Write)
            fs.Write(binaryFile, 0, binaryFile.Length)
            fs.Close()

            Return filefullName


        End Function


        Public Shared Function FileToBytes(ByVal fileFullName As String, ByVal newName As String, Optional ByVal GetInZipFormat As Boolean = True) As Byte()

            newName = System.IO.Path.GetDirectoryName(fileFullName) + "\" + newName + System.IO.Path.GetExtension(fileFullName)

            System.IO.File.Copy(fileFullName, newName)

            If newName = String.Empty OrElse Not System.IO.File.Exists(newName) Then
                Return Nothing
            End If

            Dim fs As FileStream

            If GetInZipFormat Then

                Dim zip As New Ionic.Zip.ZipFile()
                zip.AddFile(newName, "")
                zip.Save(IO.Path.ChangeExtension(newName, ".zip"))
                zip.Dispose()

                fileFullName = IO.Path.ChangeExtension(newName, ".zip")

            End If

            fs = New FileStream(fileFullName, FileMode.Open, FileAccess.Read)

            Dim FileSize As Integer

            ' if filesize=fs.length => مقدار در اندیس آخر =00  , doc file ignore 00 at last index but .docx  don't ignore
            ' .docx file does not work but all files work 
            'if filesize=fs.length -1=> .txt file does not work
            If System.IO.Path.GetExtension(fileFullName) = ".txt" Then
                FileSize = fs.Length
            Else
                FileSize = fs.Length - 1
            End If

            Dim Bytes(FileSize) As Byte
            fs.Read(Bytes, 0, FileSize)
            fs.Close()
            fs.Dispose()

            System.IO.File.Delete(newName)
            System.IO.File.Delete(fileFullName)

            Return Bytes

        End Function





    End Class



End Namespace