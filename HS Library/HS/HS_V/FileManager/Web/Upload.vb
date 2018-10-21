Imports System.Web.UI.WebControls
Imports System.IO

Namespace HS.FileManager.Web

    Public Class Upload

#Region "- Property -"

        Private _HasError As Boolean
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


        Private _HasFile As Boolean
        Public ReadOnly Property HasFile() As Boolean
            Get
                Return _HasFile
            End Get

        End Property

        Public Sub Clear()

            _Message = Nothing
            _HasError = Nothing
            _HasFile = Nothing

        End Sub


        Private Sub SetMessage(ByVal Message As String)

            Dim _Bool As Boolean = True
            Select Case _Bool

                Case Message.Contains("is not a recognized imageformat")
                    _Message = "فایل غیر تصویری می باشد"
                Case Else
                    _Message = Message

            End Select


        End Sub


#End Region


        Public Function FileUpload_HasOkSize(ByVal FileUpload As FileUpload, ByVal AllowedExtensions As String(), ByVal Size_MB As Integer) As String

            '(hasfile ==> chack Ext & Size ) 

            Dim FullName As String = "Empty"


            If FileUpload.HasFile Then

                _HasFile = True

                Dim fileOK As Boolean = False

                Dim FileExtension As String = System.IO.Path.GetExtension(FileUpload.FileName).ToLower()

                For i As Integer = 0 To AllowedExtensions.Length - 1 '---------------{".jpg", ".tif", ".pdf"}
                    If FileExtension.ToLower = AllowedExtensions(i).ToLower Then
                        fileOK = True
                    End If
                Next


                '-------------------------------------

                If fileOK Then

                    If (FileUpload.PostedFile.ContentLength < Size_MB * 1024 * 1024) Then  ' Allow only files less than size_MB bytes to be uploaded.

                        _HasError = False

                        'Dim Path As String = Server.MapPath("\" & vdir & "\")
                        'FU.SaveAs(Path & FullName)

                    Else
                        _HasError = True
                        _Message = "فایل شما به علت دارا بودن فایل ضمیمه بزرگتر از " + Size_MB.ToString + " مگا بایت یا نداشتن پسوند مجاز ارسال نشد "
                    End If


                Else
                    _HasError = True
                    _Message = " نوع فایل مجاز نمی باشد "
                End If



            Else
                _HasFile = False
                _Message = "فایل مربوطه انتخاب نشده است"
            End If


            Return FullName


        End Function



#Region "- Get Managed WebFolder -"


        Public Function GetManagedWebFolder(ByVal Page As System.Web.UI.Page, ByVal Folder As String) As String ' Folder = "~/DocumentFiles/Books"


            Try

                Dim FolderNo As Integer = SubDirectory(Page.MapPath(Folder)) '--------------- TotalFolder
                Dim ActiveFolderNo As Integer
                Dim CheakFolder As String

                If FolderNo <> 0 Then

                    CheakFolder = IIf(FolderNo.ToString.Length = 1, Folder + "/0" + CStr(FolderNo), Folder + "/" + CStr(FolderNo))

                    ActiveFolderNo = IIf(FilesCount(Page.MapPath(CheakFolder)) > 1000, FolderNo + 1, FolderNo)

                    Folder = IIf(ActiveFolderNo.ToString.Length = 1, Folder + "/0" + CStr(ActiveFolderNo), Folder + "/" + CStr(ActiveFolderNo))


                Else
                    Folder = Folder + "/01"
                End If

                Directory.CreateDirectory(Page.MapPath(Folder))

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

            Return Folder + "/"

        End Function

        Private Function SubDirectory(ByVal Path As String) As Integer

            Try


                Dim TotalFolders As Integer = 0

                Dim FolderName As String
                For Each FolderName In Directory.GetDirectories(Path)
                    TotalFolders += 1
                Next

                Return TotalFolders

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Function

        Private Function FilesCount(ByVal path As String) As Integer

            Try


                Dim TotalFiles As Integer = 0

                Dim FileName As String
                For Each FileName In Directory.GetFiles(path)
                    TotalFiles += 1
                Next

                Return TotalFiles

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Function


#End Region







    End Class

End Namespace