Imports System.IO
Imports System.Web.UI.WebControls

Imports iTextSharp.text
Imports iTextSharp.text.pdf


Imports System.Configuration
Imports System.Runtime.InteropServices.ComTypes
Imports System.Runtime.InteropServices
Imports FileTypes
Imports System.Web




Namespace HS.FileManager.Folder


    Public Class General
        ' Inherits System.Web.UI.Page '-------------------MapPath

        ' Dim Access As New HS.Dal.Access("ConAc")


#Region "Event"

        ' Public Event FileDown_Down(ByVal sender As Object, ByVal e As String) 'As EventHandler

        'Public Class MyBook_EventArgs : Inherits EventArgs ' unused

        '    Public Sub New(ByVal BookOnCase As String)
        '        _BookOnCase = BookOnCase
        '    End Sub


        '    Private _BookOnCase As BookOnCase
        '    Public ReadOnly Property BookOnCase() As BookOnCase
        '        Get
        '            Return _BookOnCase
        '        End Get

        '    End Property

        'End Class



        '#Region "Property"


        '        Private _Name As String
        '        Public Property Name() As String
        '            Get
        '                Return _Name
        '            End Get
        '            Set(ByVal value As String)
        '                _Name = value
        '                RaiseEvent FileDown_Down(Me, _Name)
        '            End Set
        '        End Property

        '#End Region





#End Region

#Region "Property"

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


      

        Function GetFileListFromFolder(ByVal path As String) As List(Of String)

            Try

                Dim ImL As New List(Of String)

                If Directory.Exists(path) Then


                    For Each FileName As String In Directory.GetFiles(path) 'Directory.GetFiles(path, "*.jpg")
                        ImL.Add(FileName)
                    Next

                Else
                    Return Nothing
                End If

                Return ImL

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Function

        Function GetFileListFromFolder(ByVal path As String, ByVal AllowedExtensions As String()) As List(Of String)

            Try

                Dim ImL As New List(Of String)

                If Directory.Exists(path) Then

                    For i As Integer = 0 To AllowedExtensions.Length - 1 '---------------{".jpg", ".tif", ".pdf"}

                        For Each FileName As String In Directory.GetFiles(path, AllowedExtensions(i).ToLower)
                            ImL.Add(FileName)
                        Next

                    Next


                Else
                    Return Nothing
                End If

                Return ImL

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Function

        Sub DeleteAllFilesInFolder(ByVal path As String, ByVal DelSubDir As Boolean)



            Dim i As Integer

            If Directory.Exists(path) Then




                Dim dir As New DirectoryInfo(path)

                Dim Dire() As DirectoryInfo = dir.GetDirectories()
                Dim file() As FileInfo = dir.GetFiles()


                If file.Length > 0 Then
                    For i = 0 To file.Length - 1
                        file(i).Delete()
                    Next
                End If


                If DelSubDir Then

                    If Dire.Length > 0 Then
                        For i = 0 To Dire.Length - 1
                            Dire(i).Delete(True)
                        Next
                    End If

                End If



            End If



        End Sub

        Sub DeleteFolder(ByVal path As String)

            DeleteAllFilesInFolder(path, True)
            If Directory.Exists(path) Then
                Directory.Delete(path)
            End If


        End Sub



    End Class


End Namespace
