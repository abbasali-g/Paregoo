Imports System.IO

Public Class FileManager

    Public Shared Function GetFileInBinaryFormat(ByVal fileFullName As String) As Byte()


        If fileFullName = String.Empty OrElse Not System.IO.File.Exists(fileFullName) Then

            Return Nothing

        End If

        Dim fs As FileStream

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

        Dim rawData(FileSize) As Byte

        fs.Read(rawData, 0, FileSize)

        fs.Close()

        Return rawData

    End Function

    Public Shared Function GetFileFromBinaryFormat(ByVal binaryFile() As Byte, ByVal filefullName As String, Optional ByVal ignoreExist As Boolean = True) As String

        If Not ignoreExist Then

            If System.IO.File.Exists(filefullName) Then

                Return filefullName

            End If

        End If

        Dim fs As FileStream

        Dim fileSize As Integer = binaryFile.Length

        Dim path As String = filefullName

        fs = New FileStream(path, FileMode.Create, FileAccess.Write)

        fs.Write(binaryFile, 0, fileSize)

        fs.Close()

        Return path

    End Function

    Public Shared Function GetFileFromZipBinaryFormat(ByVal binaryFile() As Byte, ByVal filefullName As String, ByVal ignoreExist As Boolean) As String

        If Not ignoreExist Then

            If System.IO.File.Exists(filefullName) Then

                Return filefullName

            End If

        End If

        Dim fs As FileStream

        Dim fileSize As Integer = binaryFile.Length

        Dim path As String = filefullName

        fs = New FileStream(path, FileMode.Create, FileAccess.Write)

        fs.Write(binaryFile, 0, fileSize)

        fs.Close()

        Dim oZipFile As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile(path)

        oZipFile.ExtractAll(System.IO.Path.GetDirectoryName(path), Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)

        oZipFile.Dispose()

        System.IO.File.Delete(path)

        Return filefullName

    End Function


End Class
