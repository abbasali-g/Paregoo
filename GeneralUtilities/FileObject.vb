Imports Microsoft.VisualBasic
Imports System.IO

Public Class FileObject

    Public Shared Function SaveTextInFile(ByVal Page As System.Web.UI.Page, ByVal Directory As String, ByVal FileName As String, ByVal TextToSave As String) As Boolean

        Try

            Dim fp As IO.StreamWriter : Dim fs As IO.FileStream : Dim DI As IO.DirectoryInfo

            Dim Dir As String = ""

            If Directory IsNot Nothing Then

                If Strings.Left(Directory, 1) = "\" Then

                    Directory = Directory.Substring(1, Directory.Length - 1)

                End If

                If Strings.Right(Directory, 1) = "\" Then

                    Directory = Directory.Substring(0, Directory.Length - 1)

                End If

                Dir = "~\" & Directory

                If Not IO.Directory.Exists(Page.Server.MapPath(Dir)) Then

                    DI = IO.Directory.CreateDirectory(Page.Server.MapPath(Dir))

                End If



            Else

                Dir = "~\"

            End If

            If FileName IsNot Nothing Then

                If Not IO.File.Exists(Page.Server.MapPath(Dir)) Then

                    fs = IO.File.Create(Page.Server.MapPath(Dir))

                    fs.Close()

                End If

            End If

            fp = System.IO.File.CreateText(Page.Server.MapPath(Dir))

            fp.WriteLine(TextToSave)

            fp.Close()

            Return True

        Catch ex As Exception

            Return False

        End Try

    End Function

    ''' <summary>
    ''' فایل  در روت ذخیره می شود
    ''' </summary>
    ''' <param name="Page"></param>
    ''' <param name="FileName"></param>
    ''' <param name="TextToSave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveTextInFile(ByVal Page As System.Web.UI.Page, ByVal FileName As String, ByVal TextToSave As String) As Boolean

        Try

            Dim _Success As Boolean = False

            _Success = SaveTextInFile(Page, Nothing, FileName, TextToSave)

            Return _Success

        Catch ex As Exception

            Return False

        End Try

    End Function

End Class
