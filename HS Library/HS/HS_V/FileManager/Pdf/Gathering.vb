Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Text.RegularExpressions

Namespace HS.FileManager.Pdf

#Region "- FolderFiles Class -"

    Public Class FolderFiles


        Private _DirName As String
        Public Property DirName() As String
            Get
                Return _DirName
            End Get
            Set(ByVal value As String)
                _DirName = value
            End Set
        End Property


        Private _FileNames As New HashSet(Of String)
        Public Property FileNames() As HashSet(Of String)
            Get
                Return _FileNames
            End Get
            Set(ByVal value As HashSet(Of String))
                _FileNames = value
            End Set
        End Property


    End Class



#End Region


    Public Class Gathering

#Region "- Files -"

        Function GetFileListFromFolder(ByVal path As String, ByVal AllowedExtensions As String()) As List(Of FolderFiles)

            Dim FoFiList As New List(Of FolderFiles)

            Try

                If Directory.Exists(path) Then

                    Dim FoFi As New FolderFiles

                    FoFi.DirName = IO.Directory.GetParent(path + "\").Name()

                    For i As Integer = 0 To AllowedExtensions.Length - 1 '---------------{".jpg", ".tif", ".pdf"}

                        For Each FileName As String In Directory.GetFiles(path, AllowedExtensions(i).ToLower)

                            FoFi.FileNames.Add(FileName)
                            ' ImL.Add(FileName)
                        Next


                    Next
                    If FoFi.FileNames.Count > 0 Then
                        FoFiList.Add(FoFi)
                    End If


                    '---------------------------------

                    Dim subdirectoryEntries As String() = Directory.GetDirectories(path)
                    ' Recurse into subdirectories of this directory.
                    For Each subdirectory As String In subdirectoryEntries
                        FoFiList.AddRange(GetFileListFromFolder(subdirectory, AllowedExtensions))
                    Next subdirectory


                Else
                    Return Nothing
                End If

                Return FoFiList


            Catch ex As Exception
                Throw ex
            End Try


        End Function

#End Region

#Region "- Pdf -"

        Function Files2Pdf(ByVal FoFiList As List(Of FolderFiles), ByVal FileOut As String) As Integer()


            Dim Document As New iTextSharp.text.Document
            Dim Writer As PdfWriter = PdfWriter.GetInstance(Document, New FileStream(FileOut, FileMode.Create))

            'Writer.PageNumber

            Try

                Document.SetMargins(0, 0, 0, 0)


                Dim PageNoForBookMark(FoFiList.Count - 1) As Integer
                Dim AllPageNo As Integer = 0


                For i As Integer = 0 To FoFiList.Count - 1

                    Dim CurrentFolderPageNo As Integer = 0

                    For ii As Integer = 0 To FoFiList(i).FileNames.Count - 1


                        If FoFiList(i).FileNames(ii).ToLower.EndsWith(".pdf") Then

                            AddPdf2PdfDocument(FoFiList(i).FileNames(ii), Writer, Document, AllPageNo, CurrentFolderPageNo)

                        ElseIf FoFiList(i).FileNames(ii).ToLower.EndsWith(".jpg") Or FoFiList(i).FileNames(ii).ToLower.EndsWith(".gif") Or FoFiList(i).FileNames(ii).ToLower.EndsWith(".png") Or FoFiList(i).FileNames(ii).ToLower.EndsWith(".tif") Or FoFiList(i).FileNames(ii).ToLower.EndsWith(".bmp") Then

                            Dim TextImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(FoFiList(i).FileNames(ii))

                            ' SetPageSize -->  NewPage --> Add
                            Document.SetPageSize(New Rectangle(TextImage.Width, TextImage.Height)) 'pixel / 72 = inch  (in pdf)
                            If Not Document.IsOpen Then
                                Document.Open()
                            End If

                            Document.NewPage() ' new page is in new size then add image
                            Document.Add(TextImage)

                            AllPageNo += 1
                            CurrentFolderPageNo += 1


                        ElseIf FoFiList(i).FileNames(ii).ToLower.EndsWith(".docx") Or FoFiList(i).FileNames(ii).ToLower.EndsWith(".doc") Or FoFiList(i).FileNames(ii).ToLower.EndsWith(".dotx") Or FoFiList(i).FileNames(ii).ToLower.EndsWith(".dot") Then


                            Dim wApp As New Microsoft.Office.Interop.Word.Application
                            Dim wDoc As Microsoft.Office.Interop.Word.Document = Nothing

                            Dim FileName As Object = IO.Path.GetTempFileName 'IO.Path.ChangeExtension(FoFiList(i).FileNames(ii), "pdf")

                            Try

                                wDoc = wApp.Documents.Open(FoFiList(i).FileNames(ii))

                                Dim FileFormat As Object = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF
                                wDoc.SaveAs(FileName, FileFormat)

                            Catch ex As Runtime.InteropServices.COMException
                                ' MessageBox.Show("Error accessing Word document.")
                            Finally

                                ' Close the workbook object.
                                If Not wDoc Is Nothing Then
                                    wDoc.Close(False)
                                    wDoc = Nothing
                                End If
                                ' Quit Excel and release the ApplicationClass object.
                                If Not wApp Is Nothing Then
                                    wApp.Quit()
                                    wApp = Nothing
                                End If
                                GC.Collect()
                                GC.WaitForPendingFinalizers()
                                GC.Collect()
                                GC.WaitForPendingFinalizers()

                            End Try

                            AddPdf2PdfDocument(CStr(FileName), Writer, Document, AllPageNo, CurrentFolderPageNo)

                        ElseIf FoFiList(i).FileNames(ii).ToLower.EndsWith(".xlsx") Or FoFiList(i).FileNames(ii).ToLower.EndsWith(".xls") Then


                            Dim eApp As New Microsoft.Office.Interop.Excel.Application
                            Dim eBook As Microsoft.Office.Interop.Excel.Workbook = Nothing

                            Dim FileName As Object = IO.Path.ChangeExtension(IO.Path.GetTempPath + IO.Path.GetRandomFileName, "pdf") 'C:\Documents and Settings\vnz\Local Settings\Temp\tmp2C4.pdf


                            Try


                                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
                                eBook = eApp.Workbooks.Open(FoFiList(i).FileNames(ii))

                                Dim _ExportFilePath As String = FileName
                                Dim _ExportFormat As Microsoft.Office.Interop.Excel.XlFixedFormatType = Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF
                                Dim _ExportQuality As Microsoft.Office.Interop.Excel.XlFixedFormatQuality = Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard
                                'Dim paramToPage As Object = Type.Missing
                                'Dim missing As Object = System.Reflection.Missing.Value

                                eBook.ExportAsFixedFormat(Type:=_ExportFormat, Filename:=_ExportFilePath, Quality:=_ExportQuality)
                                'eBook.SaveAs(FileName, FileFormat)

                            Catch ex As Runtime.InteropServices.COMException
                                ' MessageBox.Show("Error accessing Word document.")
                            Finally

                                ' Close the workbook object.
                                If Not eBook Is Nothing Then
                                    eBook.Close(False)
                                    eBook = Nothing
                                End If
                                ' Quit Excel and release the ApplicationClass object.
                                If Not eApp Is Nothing Then
                                    eApp.Quit()
                                    eApp = Nothing
                                End If
                                GC.Collect()
                                GC.WaitForPendingFinalizers()
                                GC.Collect()
                                GC.WaitForPendingFinalizers()

                            End Try

                            AddPdf2PdfDocument(CStr(FileName), Writer, Document, AllPageNo, CurrentFolderPageNo)

                        ElseIf FoFiList(i).FileNames(ii).ToLower.EndsWith(".txt") Then


                            Dim ReadText As String = File.ReadAllText(FoFiList(i).FileNames(ii))


                            Dim Bf As iTextSharp.text.pdf.BaseFont = iTextSharp.text.pdf.BaseFont.CreateFont(System.Environment.GetEnvironmentVariable("windir") & "\Fonts" + "\tahoma.ttf", BaseFont.IDENTITY_H, True) '"utf-8" 'tahoma.ttf 'BLotus.ttf
                            Dim TextFont As iTextSharp.text.Font = New iTextSharp.text.Font(Bf, 12, iTextSharp.text.Font.NORMAL)
                            Dim Paragraph As New iTextSharp.text.Paragraph(ReadText, TextFont)


                            '-----------------------------------
                            Dim regex_match_arabic_hebrew As String = "[\u0600-\u06FF,\u0590-\u05FF]+"
                            Dim table As PdfPTable = New PdfPTable(1)
                            ' table.RunDirection = PdfWriter.RUN_DIRECTION_RTL


                            If (ReadText <> String.Empty And Regex.IsMatch(ReadText, regex_match_arabic_hebrew, RegexOptions.IgnoreCase)) Then


                                Dim cell As PdfPCell = New PdfPCell()
                                cell.Border = Rectangle.NO_BORDER
                                cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED
                                cell.PaddingTop = 50

                                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL

                                cell.AddElement(Paragraph)
                                table.AddCell(cell)

                            End If

                            '--------------------------------------

                            ' SetPageSize -->  NewPage --> Add
                            Document.SetPageSize(New Rectangle(595, 842)) 'A4 'cm --> in   in * 72 = pt   | 21cm=8.2 in 8.2*72=595
                            If Not Document.IsOpen Then
                                Document.Open()
                            End If

                            Document.NewPage() ' new page is in new size then add image
                            Document.Add(table)

                            AllPageNo += 1
                            CurrentFolderPageNo += 1

                        End If

                        PageNoForBookMark(i) = AllPageNo - (CurrentFolderPageNo - 1)

                    Next
                Next

                Return PageNoForBookMark





            Catch ex As IOException
                '  _HasError = True
                ' _Exception = ex
                ' SetMessage(ex.Message)
                'Return Nothing
                Throw ex

            Catch ex As Exception
                ' Return Nothing
                Throw ex
            Finally

                If Document.IsOpen Then
                    Document.Close()
                End If

            End Try







        End Function

        Sub AddPdf2PdfDocument(ByVal Filename As String, ByRef Writer As PdfWriter, ByRef Document As iTextSharp.text.Document, ByRef AllPageNo As Integer, ByRef CurrentFolderPageNo As Integer)

            Dim P_Reader As PdfReader = Nothing

            Try '-------------------------- for dammage file skip it
                P_Reader = New PdfReader(Filename)
            Catch ex As Exception
                'Continue For
                Exit Sub
            End Try


            For No As Integer = 1 To P_Reader.NumberOfPages

                Dim page As PdfImportedPage = Writer.GetImportedPage(P_Reader, No)
                Dim TextImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(page)

                Document.SetPageSize(P_Reader.GetPageSize(No))
                If Not Document.IsOpen Then
                    Document.Open()
                End If

                Document.NewPage()
                Document.Add(TextImage)

                AllPageNo += 1
                CurrentFolderPageNo += 1

            Next



        End Sub

        Sub AddBookMark2Pdf(ByVal FileIn As String, ByVal FileOut As String, ByVal PagesBookmark As Hashtable)



            Dim Document As New iTextSharp.text.Document '= New iTextSharp.text.Document(P_Reader.GetPageSizeWithRotation(1))

            Try

                Dim P_Copy As PdfCopy = New PdfCopy(Document, New FileStream(FileOut, FileMode.Create))
                Document.Open()

                If IO.File.Exists(FileIn) Then

                    Dim P_Reader As PdfReader = New PdfReader(FileIn)


                    For i As Integer = 1 To P_Reader.NumberOfPages


                        If PagesBookmark.Contains(i) Then

                            ' For Each De As DictionaryEntry In PagesBookmark

                            ' pageno   bookmark

                            P_Copy.ViewerPreferences = PdfWriter.PageModeUseOutlines
                            P_Copy.ViewerPreferences = PdfWriter.PageLayoutSinglePage

                            Dim Root As PdfOutline = P_Copy.DirectContent.RootOutline

                            Dim GoToPage As PdfAction = PdfAction.GotoLocalPage(i, New PdfDestination(PdfDestination.FITB), P_Copy)
                            Dim OutLine As PdfOutline = New PdfOutline(Root, GoToPage, CStr(PagesBookmark(i)))

                        End If

                        '------------ file --> reader --> Pcopy --> AddPage 

                        Dim _page As PdfImportedPage = P_Copy.GetImportedPage(P_Reader, i)
                        P_Copy.AddPage(_page)

                    Next
                End If

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            Finally
                Document.Close()
            End Try

        End Sub

        '------------------------------------------------------

        Function CreatePdfStreamPdfWithRandomLanguageSupport(ByVal textList As IEnumerable(Of String)) As Byte()
            '//C# does not support \p{Arabic} and \p{Hebrew} character classes. We have to roll our own.
            '	//We are assuming any string that contains an Arabic or Hebrew character is meant to be RTL.
            '	//Better would be to break strings into word tokens and test each word.


            Dim document As Document = New Document(PageSize.LETTER)



            Using stream As MemoryStream = New MemoryStream()

                Dim writer As PdfWriter = PdfWriter.GetInstance(document, stream)

                Try

                    ' //bunch of document setup here.
                    document.Open()

                    ' //arbitrarily, creating a 5 columnt table.


                    '  //embed a Unicode font with broad glyph support for any code point we might need.
                    '//only the glyphs for code points actually used will be embedded in the document



                    Dim arialunicodepath As String = Environment.GetEnvironmentVariable("SystemRoot") + "\fonts\BLotus.ttf"


                    Dim nationalBase As BaseFont = BaseFont.CreateFont(arialunicodepath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
                    Dim nationalTextFont As iTextSharp.text.Font = New Font(nationalBase, 9.0F, Font.NORMAL)


                    Dim table As PdfPTable = New PdfPTable(5)

                    For Each Text As String In textList
                        '//PdfPCell implements IPdfRunDirection


                        ' //Arabic and Hebrew strings need to be reversed for right-to-left rendering
                        '//which is done by setting IPdfRunDirection.RunDirection. Otherwise, your RTL language text
                        '//comes out as backwards gibberish.

                        Dim regex_match_arabic_hebrew As String = "[\u0600-\u06FF,\u0590-\u05FF]+"

                        If (Text <> String.Empty And Regex.IsMatch(Text, regex_match_arabic_hebrew, RegexOptions.IgnoreCase)) Then

                            Dim cell As PdfPCell = New PdfPCell()

                            cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL
                            ' //apply unicode font

                            Dim phrase As Phrase = New Phrase(Text, nationalTextFont)

                            'cell.Add(phrase)
                            cell.AddElement(phrase)
                            table.AddCell(cell)


                        End If


                    Next

                    document.Add(table)




                Catch ex As Exception

                Finally

                    document.Close()
                    writer.Close()

                End Try


                Return stream.GetBuffer()





            End Using

        End Function

        '--------- old

        Function CreatePdfFromPdfAndImage(ByVal FileList() As String, ByVal FileOut As String) As Boolean



            Dim Document As New iTextSharp.text.Document

            Dim writer As PdfWriter = PdfWriter.GetInstance(Document, New FileStream(FileOut, FileMode.Create))

            Try

                Document.SetMargins(0, 0, 0, 0)



                For i As Integer = 0 To FileList.Length - 1


                    If FileList(i).EndsWith(".pdf") Then


                        Dim P_Reader As PdfReader
                        Try '-------------------------- for dammage file skip it
                            P_Reader = New PdfReader(FileList(i))
                        Catch ex As Exception
                            Continue For
                        End Try


                        Dim Tp As Integer = P_Reader.NumberOfPages
                        For No As Integer = 1 To Tp

                            Document.SetPageSize(P_Reader.GetPageSize(No))
                            Document.Open()

                            Dim page As PdfImportedPage = writer.GetImportedPage(P_Reader, No)
                            Dim TextImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(page)

                            Document.Add(TextImage)

                        Next


                    ElseIf FileList(i).EndsWith(".jpg") Then

                        ' SetPageSize -->  NewPage --> Add

                        Dim TextImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(FileList(i))

                        Document.SetPageSize(New Rectangle(TextImage.Width, TextImage.Height)) 'pixel / 72 = inch  (in pdf)

                        If Not Document.IsOpen Then
                            Document.Open()
                        End If

                        Document.NewPage() ' new page is in new size then add image
                        Document.Add(TextImage)


                    End If

                Next

                Return True


            Catch ex As IOException
                '  _HasError = True
                ' _Exception = ex
                ' SetMessage(ex.Message)
                Return False

            Catch ex As Exception
                ' Throw New Exception(ex.Message, ex)
                Return False
            Finally

                If Document.IsOpen Then
                    Document.Close()
                End If

            End Try


        End Function

#End Region

    End Class


End Namespace
