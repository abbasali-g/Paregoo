Imports Lawyer.Common.VB.LawyerError
Imports HS.FileManager

Namespace Common
    Public Class PdfManager

        Public Shared Function CreatePdfFormFiles(ByVal filepath As String) As String

            Try

                Dim path As String = filepath
                Dim AllowedExtensions As String() = {"*.pdf", "*.dotx", "*.dot", "*.docx", "*.doc", "*.xlsx", "*.xls", "*.txt", "*.jpg", "*.gif", "*.png", "*.tif", "*.bmp"}

                Dim Gathering As New Pdf.Gathering
                Dim FoFiList As New List(Of Pdf.FolderFiles)

                Try
                    FoFiList = Gathering.GetFileListFromFolder(path, AllowedExtensions)
                Catch ex As Exception
                    ErrorManager.WriteMessage("CreatePdfFormFiles(),Gathering.GetFileListFromFolder", ex.ToString, "Class PdfManager")
                    Throw ex
                End Try


                For i As Integer = 0 To FoFiList.Count - 1
                    Select Case FoFiList(i).DirName
                        Case "Documentation"
                            FoFiList(i).DirName = "مستندات"
                        Case "FileCase"
                            FoFiList(i).DirName = "مشخصات پرونده"
                        Case "Mali"
                            FoFiList(i).DirName = "اطلاعات مالی"
                        Case "Oragh"
                            FoFiList(i).DirName = "اوراق"
                        Case "Other"
                            FoFiList(i).DirName = "متفرقه"
                    End Select
                Next

                'Sarandy: create pdf from files and return pages thet ehch folder started.
                Dim PageNoForBookMark As Integer()
                Try
                    PageNoForBookMark = Gathering.Files2Pdf(FoFiList, FileManager.GetTempPdfPath) ' App_Path() + "\Temp.pdf" 'IO.Path.GetTempPath 
                Catch ex As Exception
                    ErrorManager.WriteMessage("CreatePdfFormFiles(),Gathering.Files2Pdf", ex.ToString, "Class PdfManager")
                    Throw ex
                End Try



                'Sarandy : For instance add to page 2 bookmark "Time"
                Dim PagesBookmark As New Hashtable
                For i As Integer = 0 To PageNoForBookMark.Length - 1
                    PagesBookmark.Add(PageNoForBookMark(i), FoFiList(i).DirName)
                Next

                Try
                    Gathering.AddBookMark2Pdf(FileManager.GetTempPdfPath, FileManager.GetBookMarkedPdfPath, PagesBookmark)
                Catch ex As Exception
                    ErrorManager.WriteMessage("CreatePdfFormFiles(),Gathering.AddBookMark2Pdf", ex.ToString, "Class PdfManager")
                    Throw ex
                End Try

            Catch ex As Exception
                ErrorManager.WriteMessage("CreatePdfFormFiles(),Body", ex.ToString, "Class PdfManager")
                Throw ex
            End Try

            Return FileManager.GetBookMarkedPdfPath 'App_Path() & "\Temp_B.pdf"


        End Function


    End Class
End Namespace

