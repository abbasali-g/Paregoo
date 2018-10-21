Imports System.IO
Imports System.Reflection
Imports Microsoft.Office.Interop
Namespace Common

    Public Class FileManager


#Region "LReview"

#Region "Methods"


        Public Shared Function GetFileFromBinaryFormat(ByVal binaryFile() As Byte, ByVal filefullName As String, Optional ByVal delete As Boolean = True, Optional ByVal ignoreExist As Boolean = True, Optional ByVal IsInZipFormat As Boolean = True) As String

            Dim newFileName As String = IO.Path.GetDirectoryName(filefullName) + "\" + IO.Path.GetFileNameWithoutExtension(filefullName) & "1" & IO.Path.GetExtension(filefullName)

            newFileName = IO.Path.ChangeExtension(newFileName, ".zip")

            If Not ignoreExist Then

                If System.IO.File.Exists(filefullName) Then

                    Return filefullName

                End If

            End If

            Dim fs As FileStream

            Dim fileSize As Integer = binaryFile.Length

            Dim path As String = filefullName

            If IsInZipFormat Then

                path = newFileName

            End If

            fs = New FileStream(path, FileMode.Create, FileAccess.Write)


            fs.Write(binaryFile, 0, fileSize)
            

            fs.Close()

            'unzip
            If IsInZipFormat Then

                Dim oZipFile As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile(path)
                Try


                    oZipFile.ExtractAll(System.IO.Path.GetDirectoryName(path), Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)

                    oZipFile.Dispose()

                Catch ex As Exception

                    oZipFile.Dispose()

                    File.Delete(path)

                    Return filefullName

                End Try


                If delete Then

                    Dim Source As DirectoryInfo = New DirectoryInfo(IO.Path.GetFileNameWithoutExtension(path))

                    Dim files As FileInfo() = Source.GetFiles()

                    IO.File.Copy(files(0).FullName, filefullName)

                    Source = Nothing

                    oZipFile = Nothing

                    Directory.Delete(IO.Path.GetFileNameWithoutExtension(path), True)

                End If

            End If

            File.Delete(path)

            Return filefullName

        End Function

        Public Shared Function GetFileInBinaryFormat(ByVal fileFullName As String, ByVal newName As String, Optional ByVal GetInZipFormat As Boolean = True) As Byte()

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

                fileFullName = IO.Path.ChangeExtension(newName, ".zip")

                zip.Dispose()

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

            Dim rawData(FileSize) As Byte

            fs.Read(rawData, 0, FileSize)

            fs.Close()

            fs.Dispose()

            System.IO.File.Delete(newName)

            System.IO.File.Delete(fileFullName)

            Return rawData

        End Function

        Public Shared Function GetFileFromBinaryFormat2(ByVal binaryFile() As Byte, ByVal filefullName As String) As String

            Dim fs As FileStream

            Dim fileSize As Integer = binaryFile.Length

            Dim path As String = filefullName

            fs = New FileStream(path, FileMode.Create, FileAccess.Write)

            fs.Write(binaryFile, 0, fileSize)

            fs.Close()

            Return filefullName


        End Function

        Public Shared Sub executeWordFile(ByVal ID As String, ByVal fileVirtualPath As String, ByVal fileName As String, ByVal tableName As String, Optional ByVal fileCaseID As String = "null")

            Try
                Dim fi As New System.IO.FileInfo(fileVirtualPath)
                'abbas
                'write filename,tablename,conString to textfile 
                Dim wr As New System.IO.StreamWriter(fi.DirectoryName & "\" & ID & ".txt")
                wr.WriteLine(Lawyer.Common.VB.Common.SecurityHelper.EncryptUTF(fileName))
                wr.WriteLine(Lawyer.Common.VB.Common.SecurityHelper.EncryptUTF(tableName))
                wr.WriteLine(Lawyer.Common.VB.Common.SecurityHelper.EncryptUTF(Lawyer.Common.VB.CommonSetting.CommonSettingManager.ConnectionString))
                wr.WriteLine(Lawyer.Common.VB.Common.SecurityHelper.EncryptUTF(fileCaseID))

                wr.Close()

            Catch ex As Exception

            End Try


            Dim startInfo As New ProcessStartInfo()
            startInfo.FileName = "WINWORD.EXE"
            startInfo.Arguments = """" & fileVirtualPath & """"


            Process.Start(startInfo)

        End Sub

#End Region

#End Region

        Public Shared Function GetFileInBinaryFormat(ByVal fileFullName As String, Optional ByVal GetInZipFormat As Boolean = True) As Byte()


            If fileFullName = String.Empty OrElse Not System.IO.File.Exists(fileFullName) Then

                Return Nothing

            End If

            Dim fs As FileStream


            If GetInZipFormat Then

                Dim zip As New Ionic.Zip.ZipFile()

                Try

                    zip.AddFile(fileFullName, "")

                    zip.Save(IO.Path.ChangeExtension(fileFullName, ".zip"))

                    fileFullName = IO.Path.ChangeExtension(fileFullName, ".zip")

                Catch ex As Exception

                End Try

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

            Dim rawData(FileSize) As Byte

            fs.Read(rawData, 0, FileSize)

            fs.Close()

            Return rawData

        End Function

        Public Shared ReadOnly Property GetTempDocsFilesPath() As String
            Get

                Dim dPath As String = App_ParentPath() + "\Docs"

                Try

                    If Not Directory.Exists(dPath) Then

                        Directory.CreateDirectory(dPath)

                    End If

                Catch ex As Exception

                End Try

                Return dPath + "\"

            End Get
        End Property

        Public Shared ReadOnly Property GetTimingFilesPath() As String
            Get

                Dim dPath As String = App_ParentPath() + "\Timing"

                Try

                    If Not Directory.Exists(dPath) Then

                        Directory.CreateDirectory(dPath)

                    End If

                Catch ex As Exception

                End Try

                Return dPath + "\"


            End Get

        End Property

        Public Shared ReadOnly Property GetContactPicturePath() As String
            Get

                Dim dPath As String = App_ParentPath() + "\Contact"

                Try

                    If Not Directory.Exists(dPath) Then

                        Directory.CreateDirectory(dPath)

                    End If

                Catch ex As Exception

                End Try

                Return dPath + "\"

            End Get

        End Property

        Public Shared ReadOnly Property GetDocsImagePath() As String
            Get
                Dim dPath As String = App_ParentPath() + "\Icons"

                Try

                    If Not Directory.Exists(dPath) Then

                        Directory.CreateDirectory(dPath)

                    End If

                Catch ex As Exception

                End Try

                Return dPath + "\"

            End Get
        End Property

        Public Shared ReadOnly Property GetTajmiPath() As String

            Get

                Dim dPath As String = App_ParentPath() + "\tajmi"

                Try

                    If Not Directory.Exists(dPath) Then

                        Directory.CreateDirectory(dPath)

                    End If

                Catch ex As Exception

                End Try

                Return dPath

            End Get

        End Property

        Public Shared ReadOnly Property GetMailCofigPath() As String
            Get

                Dim dPath As String = App_Path() + "\SettingFiles"

                Try
                    If Not Directory.Exists(dPath) Then

                        Directory.CreateDirectory(dPath)

                    End If

                Catch ex As Exception

                End Try

                Return dPath + "\MailSetting.xml"

            End Get

        End Property

        Public Shared ReadOnly Property GetLoginConfigPath() As String

            Get

                Dim dPath As String = App_Path() + "\SettingFiles"

                Try
                    If Not Directory.Exists(dPath) Then

                        Directory.CreateDirectory(dPath)

                    End If

                Catch ex As Exception

                End Try

                Return dPath + "\Default.config"

            End Get

        End Property

        Public Shared ReadOnly Property GetAutoConfigExePath() As String

            Get
                Return App_RootPath() + "\ConfigMysql.exe"

            End Get

        End Property

        Public Shared ReadOnly Property GetErrorFilePath() As String
            Get

                Try

                    Dim dirName As String = App_Path() + "\SettingFiles"

                    If Not Directory.Exists(dirName) Then

                        Directory.CreateDirectory(dirName)

                    End If

                    Return dirName + "\LogFile.txt"

                Catch ex As Exception

                    Return String.Empty

                End Try

            End Get

        End Property

        Public Shared ReadOnly Property GetNewVersionPath() As String

            Get
                Try
                   
                    Return App_RootPath()

                Catch ex As Exception

                    Return String.Empty

                End Try


            End Get

        End Property

        Public Shared ReadOnly Property GetEmptyWordPath() As String

            Get
                Dim fPath As String = App_ParentPath() + "\emptyWord.docx"

                Try
                    If Not File.Exists(fPath) Then

                        Dim oApp As New Word.Application
                        Dim oDoc As New Word.Document

                        oApp = CreateObject("Word.Application")
                        oDoc = oApp.Documents.Add
                        oApp.Visible = False

                        oDoc.SaveAs(fPath)
                        oDoc.Close()
                        oApp.Quit()
                        oApp = Nothing
                        oDoc = Nothing

                    End If

                Catch ex As Exception

                End Try

                Return fPath

            End Get

        End Property


#Region "Sarandy Path"

        'Private _GetTempBookPath As String 
        Public Shared ReadOnly Property GetDbPdfPath() As String
            Get

                Dim dPath As String = App_ParentPath() + "\Books\Db2Pdf\"

                Try
                    If Not Directory.Exists(dPath) Then

                        Directory.CreateDirectory(dPath)

                    End If

                Catch ex As Exception

                End Try

                Return dPath

            End Get

        End Property

        Public Shared ReadOnly Property GetBmPicPath() As String

            Get
                Dim dPath As String = App_RootPath() + "\bmPics"

                Try
                    If Not Directory.Exists(dPath) Then

                        Directory.CreateDirectory(dPath)

                    End If

                Catch ex As Exception

                End Try

                Return dPath

            End Get

        End Property

        Public Shared ReadOnly Property GetDoubtableLawFilePath() As String
            Get
                Return App_Path() + "\DoubtableLaw.txt"
            End Get

        End Property

        Public Shared ReadOnly Property GetSettingFilePath() As String
            Get
                Return App_Path() + "\Setting.txt"
            End Get

        End Property

        Public Shared ReadOnly Property GetAttachmentZipFilePath() As String
            Get
                Return App_Path() + "\Attachment.zip"
            End Get

        End Property

        Public Shared ReadOnly Property GetTempPdfPath() As String
            Get
                Return App_Path() + "\Temp.pdf"
            End Get

        End Property

        Public Shared ReadOnly Property GetBookMarkedPdfPath() As String
            Get
                Return App_Path() + "\Temp_B.pdf"
            End Get

        End Property

        Public Shared ReadOnly Property GetFaxFilePath() As String
            Get
                Return App_Path() + "\Fax.txt"
            End Get

        End Property

        Public Shared ReadOnly Property GetBookConvertFilePath() As String
            Get
                Return App_Path() + "\Lib.txt"
            End Get

        End Property

        Public Shared Function App_Path() As String

            Dim dPath As String = String.Empty

            Try
                dPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\DefaultFolders"

                If Not Directory.Exists(dPath) Then

                    Directory.CreateDirectory(dPath)

                End If

            Catch ex As Exception

            End Try

            Return dPath

        End Function

        Public Shared Function App_RootPath() As String

            Return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)

        End Function

        Public Shared Function App_ParentPath() As String

            Dim dPath As String = String.Empty

            Try

                'dPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()(2)) + "\DefaultFolders"

                dPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\DefaultFolders"

                If Not Directory.Exists(dPath) Then

                    Directory.CreateDirectory(dPath)

                End If

            Catch ex As Exception

            End Try

            Return dPath

        End Function

        Public Shared Sub EmptyDirectory()

            Try

                Dim path As String = App_ParentPath() + "\Docs"
                If Directory.Exists(path) Then
                    Directory.Delete(path, True)
                End If



                path = App_ParentPath() + "\Timing"

                If Directory.Exists(path) Then
                    Directory.Delete(path, True)
                End If


                path = App_ParentPath() + "\Books\Db2Pdf"

                If Directory.Exists(path) Then
                    Directory.Delete(path, True)
                End If
            Catch ex As Exception

            End Try


        End Sub


#End Region

    End Class

End Namespace

