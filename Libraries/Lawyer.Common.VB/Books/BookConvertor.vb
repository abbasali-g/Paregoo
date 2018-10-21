Imports System.IO

Namespace Books


    Public Class BookConvertor


#Region "Property"

        Private _Message As String
        Public ReadOnly Property Message() As String
            Get
                Return _Message
            End Get

        End Property


        Private Fields As New ArrayList '----------------- Fields(Field.عنوان)

        Private Sub FillFields()

            Fields.Add("عنوان و نام پديدآور :")
            Fields.Add("موضوع :")

        End Sub

        Enum Field
            عنوان = 0
            موضوع = 1
        End Enum

#End Region


        Private Function GetFileNames(ByVal path As String) As ArrayList

            Dim FileNames As New System.Collections.ArrayList()
            Dim TotalFiles As Integer = 0 : Dim FileName As String

            Try

                For Each FileName In Directory.GetFiles(path)

                    If FileName.Substring(FileName.Length - 4) = ".txt" Then
                        FileNames.Insert(TotalFiles, FileName)
                        TotalFiles += 1
                    End If

                Next

            Catch ex As Exception
            End Try

            Return FileNames


        End Function

#Region "unUsed"

        Public Function ReadAllBooksInfoFromFile(ByVal FileName As String) As BookCollection

            FillFields()

            Dim bcc As New BookCollection
            bcc = GetFarsiRecordValuesForAllBooks(FileName)

            If bcc Is Nothing Then
                _Message = " فایل بدون اطلاعات"
            End If

            Return bcc

        End Function

        Private Function GetFarsiRecordValuesForAllBooks(ByVal FileName As String) As BookCollection

            Dim bcc As New BookCollection
            Dim Book As New Book

            Try

                Dim OnvanVaName As String = GetFieldValue(FileName, Fields(Field.عنوان))
                Book.libName = RemoveInvalidChar(Trim(OnvanVaName))

                If Book.libName = String.Empty Then
                    Return Nothing
                End If

                Dim MOZU As String = GetFieldValue(FileName, Fields(Field.موضوع))
                Book.libSubject = RemoveInvalidChar(Trim(MOZU))


                Dim FileContent As String = GetFileContent(FileName) '----------Summary
                Book.libSummary = RemoveInvalidChar(Trim(FileContent))

                Book.libFileName = FileName

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

            Return bcc

        End Function

#End Region

        '---------------------------------------------------------

        Public Function ReadBookInfoFromFile(ByVal FileName As String) As Book

            FillFields()

            Dim book As New Book
            book = GetFarsiRecordValues(FileName)

            If book Is Nothing Then
                _Message = " فایل بدون اطلاعات"
                Throw New Exception(_Message)
            End If

            Return book

        End Function

        Private Function GetFarsiRecordValues(ByVal FileName As String) As Book

            Dim Book As New Book

            Try

                Dim OnvanVaName As String = GetFieldValue(FileName, Fields(Field.عنوان))
                Book.libName = RemoveInvalidChar(Trim(OnvanVaName))

                If Book.libName = String.Empty Then
                    Return Nothing
                End If

                Dim MOZU As String = GetFieldValue(FileName, Fields(Field.موضوع))
                Book.libSubject = RemoveInvalidChar(Trim(MOZU))


                Dim FileContent As String = GetFileContent(FileName) '----------Summary
                Book.libSummary = RemoveInvalidChar(Trim(FileContent))

                Book.libFileName = FileName

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

            Return Book

        End Function


#Region "Inside Function"


        Private Function GetFieldValue(ByVal FileName As String, ByVal FieldTitle As String) As String

            Dim ReadFileLine As String = String.Empty
            Dim Find As String = String.Empty

            Dim MainField As New ArrayList
            MainField = Fields

            Try

                Dim re As StreamReader = File.OpenText(FileName)

                While re.EndOfStream <> True 'Make string  from find field until next field.(read from first) 

                    ReadFileLine = re.ReadLine

                    ReadFileLine = ReadFileLine.Replace(" 	: 	", ":").Trim ' for fire fox browser

                    If ReadFileLine.IndexOf(FieldTitle, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 Then

                        ReadFileLine = ReadFileLine.Replace(FieldTitle, "").Trim

                        Find += ReadFileLine
                        Exit While

                    End If 'input.IndexOf(word,

                End While

                re.Close()

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

            Return Find.Trim

        End Function

        Private Function GetFileContent(ByVal FileName As String) As String

            Dim re As StreamReader = File.OpenText(FileName)
            Return re.ReadToEnd.Trim

        End Function

        Private Function RemoveInvalidChar(ByVal str As String) As String

            'Dim str As String = "‏رده بندی کنگره:‏‫‬‭TA۴۱۸/۷۴‏‫۱۳۸۶ ‏‫‭/آ۹م۴‬"
            'Dim Str2Char() As Char = str.ToCharArray
            'Dim str2(str.ToCharArray.Length - 1) As String
            'For ii As Integer = 0 To str.ToCharArray.Length - 1
            '    str2(ii) = AscW(Str2Char(ii))
            'Next

            '----------------------------------------
            Dim GoodStr As String = String.Empty
            Dim i As Integer = 1
            Dim ch As Char

            Try

                While i <= Len(str)

                    ch = Mid(str, i, 1)
                    If AscW(ch) <= 8000 Or AscW(ch) = 8204 Then '--- remove higher than 8000
                        If AscW(ch) = 8204 Then
                            If i + 1 <= Len(str) Then
                                If AscW(Mid(str, i + 1, 1)) <> 32 Then
                                    ch = " "
                                Else
                                    i = i + 1
                                    Continue While
                                End If
                            Else '---- remove 8204
                                i = i + 1
                                Continue While
                            End If
                        End If
                        If AscW(ch) >= 1776 And AscW(ch) <= 1785 Then  '------ convert farsi num to english num
                            ch = Chr(AscW(ch) - 1728) '-- 48 to 57
                        End If

                        GoodStr = GoodStr + ch
                    End If
                    i = i + 1

                End While

                Return GoodStr


            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try


        End Function


#End Region


    End Class


End Namespace
