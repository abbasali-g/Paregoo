Imports System.IO
Imports System.Web.UI.WebControls

Imports iTextSharp.text
Imports iTextSharp.text.pdf


Imports System.Configuration
Imports System.Runtime.InteropServices.ComTypes
Imports System.Runtime.InteropServices
Imports HS.FileManager.Pdf.FileType
Imports System.Web




Namespace HS.FileManager.Pdf


    Public Class General
        'Inherits System.Web.UI.Page '-------------------MapPath

        Dim Access As New HS.Dal.Access("ConAc")


#Region "Event"

        Public Event FileDown_Down(ByVal sender As Object, ByVal e As String) 'As EventHandler

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



#Region "Property"


        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
                RaiseEvent FileDown_Down(Me, _Name)
            End Set
        End Property

#End Region





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


#Region "- Pdf -"

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


                    Else


                        Dim TextImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(FileList(i))

                        ' SetPageSize -->  NewPage --> Add
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
                _HasError = True
                _Exception = ex
                SetMessage(ex.Message)
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

        '------------------------------------------------

        Function CreatePdfFromImages(ByVal Images() As String, ByVal FileOut As String, ByVal Printable As Boolean, ByVal Bookmarks() As String) As Integer


            Dim Document As New Document

            Try

                Dim write As PdfWriter = PdfWriter.GetInstance(Document, New FileStream(FileOut, FileMode.Create))

                'write.ViewerPreferences = PdfWriter.HideToolbar
                'write.ViewerPreferences = PdfWriter.HideWindowUI
                write.ViewerPreferences = PdfWriter.PageLayoutSinglePage

                If Printable Then
                    write.SetEncryption(Nothing, Nothing, PdfWriter.ALLOW_PRINTING, PdfWriter.STANDARD_ENCRYPTION_128)
                Else
                    write.SetEncryption(Nothing, Nothing, PdfWriter.ALLOW_COPY, PdfWriter.STANDARD_ENCRYPTION_128)
                End If

                If Not Bookmarks Is Nothing Then
                    write.ViewerPreferences = PdfWriter.PageModeUseOutlines
                End If

                '---------------------------------------------------------------------

                Dim TextImage(Images.Length - 1) As iTextSharp.text.Image

                For i As Integer = 0 To Images.Length - 1
                    TextImage(i) = iTextSharp.text.Image.GetInstance(Images(i))
                Next

                '------------------------------------------------------------------------------------

                For i = 0 To Images.Length - 1

                    Document.SetPageSize(New Rectangle(TextImage(i).Width + 70, TextImage(i).Height + 70))
                    Document.Open()

                    Document.Add(TextImage(i))


                    If Not Bookmarks Is Nothing AndAlso Bookmarks(i) <> "" Then


                        Dim Root As PdfOutline = write.DirectContent.RootOutline 'Dim cb As PdfContentByte = write.DirectContent
                        Dim GoToPage As PdfAction = PdfAction.GotoLocalPage(i + 1, New PdfDestination(PdfDestination.FITB), write)

                        Dim OutLine As PdfOutline = New PdfOutline(Root, GoToPage, Bookmarks(i))


                    End If

                    Document.NewPage() 'next image insert in new page

                Next


                '-----------------------------------------------------------------------------------------

                'write.Close()

                Return 1


            Catch ex As IOException
                _HasError = True
                _Exception = ex
                SetMessage(ex.Message)
                Return -1 'Nothing 
                ' Exit Function

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            Finally
                Document.Close()
            End Try


        End Function

        '------------------- create fish lq-2180

        Sub MergePdfInDocument(ByVal Page As System.Web.UI.Page, ByVal PartName As String, ByVal DtGisOfCode As DataTable, ByVal ImportedPageNo As Integer, ByVal FileOut As String, ByVal W_Pt As Single, ByVal H_Pt As Single, ByVal Title_L As List(Of String), ByVal IsDoubleSide As Boolean)

            Dim Pat As String = Page.MapPath("~")
            Dim _FileOut As String = Pat + "\" + FileOut

            Dim pagesize As Rectangle = New Rectangle(W_Pt, H_Pt) 'in * 72point'>>>> 14.92*7.32  Rectangle(1074, 527)
            'pagesize.BackgroundColor = New iTextSharp.text.BaseColor(&HFF, &HFF, &HDE)
            Dim document As Document = New Document(pagesize, 0, 0, 0, 0) '---- w=37.8 cm h=18.6 cm 


            Try

                Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(_FileOut, FileMode.Create))
                document.Open()

                Dim ExistNo As Integer = 0

                For i = 0 To DtGisOfCode.Rows.Count - 1

                    Dim CurrentFile As String = PartName + "_" + DtGisOfCode.Rows(i).Item("nosaziCode").ToString + ".pdf"


                    If IO.File.Exists(CurrentFile) Then

                        ExistNo += 1

                        AddPage2Document(document, writer, CurrentFile, ImportedPageNo)


                        If IsDoubleSide AndAlso ExistNo Mod 2 = 0 Then 'after even page add back sheet
                            AddBackSheet2Document(document, writer, Pat + "\Fish2Back.pdf", 1)
                        End If


                        Title_L.Add(DtGisOfCode.Rows(i).Item("nosaziCode").ToString)

                    End If

                Next


            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            Finally
                document.Close()
            End Try


        End Sub

        Private Sub AddPage2Document(ByVal document As Document, ByVal writer As PdfWriter, ByVal CurrentFile As String, ByVal ImportedPageNo As Integer)

            ' file --> reader --> writer --> page --> image --> document

            Dim reader As PdfReader = New PdfReader(CurrentFile)


            For i As Integer = 1 To ImportedPageNo

                Dim page As PdfImportedPage = writer.GetImportedPage(reader, i)

                Dim TextImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(page)
                ' image.ScalePercent(15.0F)
                'document.Add(New Paragraph("-------------------"))

                document.Add(TextImage)


            Next






        End Sub

        Private Sub AddBackSheet2Document(ByVal document As Document, ByVal writer As PdfWriter, ByVal CurrentFile As String, ByVal ImportedPageNo As Integer)

            ' file --> reader --> writer --> page --> image --> document

            Dim reader As PdfReader = New PdfReader(CurrentFile)


            For i As Integer = 1 To ImportedPageNo

                Dim page As PdfImportedPage = writer.GetImportedPage(reader, i)

                Dim image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(page)
                ' image.ScalePercent(15.0F)
                'document.Add(New Paragraph("-------------------"))

                document.Add(image)


            Next

        End Sub

        '----------------------------------

        Sub AddBookMark2Pdf(ByVal Page As System.Web.UI.Page, ByVal FileIn As String, ByVal FileOut As String, ByVal Title_L As List(Of String), ByVal IsDoubleSide As Boolean)


            Dim Pat As String = Page.MapPath("~")
            Dim _FileOut As String = Pat + "\" + FileOut


            Dim Document As New iTextSharp.text.Document '= New iTextSharp.text.Document(P_Reader.GetPageSizeWithRotation(1))

            Try

                Dim P_Copy As PdfCopy = New PdfCopy(Document, New FileStream(_FileOut, FileMode.Create))
                Document.Open()


                Dim CurrentFile As String = Pat + "\" + FileIn

                If IO.File.Exists(CurrentFile) Then

                    Dim P_Reader As PdfReader = New PdfReader(CurrentFile)


                    For i As Integer = 0 To Title_L.Count - 1

                        ' 28 title import 14 page and 2 ta 2 ta goto one page

                        Dim PageNoForBookmark As Integer

                        If IsDoubleSide Then
                            PageNoForBookmark = IIf((i + 1) Mod 2 = 0, i + 1 - 1, i + 1) ' tile is same size of page but doublside
                        Else
                            PageNoForBookmark = Int((i + 1) / 2) + (i + 1) Mod 2 'page is half of bookmark
                        End If

                        P_Copy.ViewerPreferences = PdfWriter.PageModeUseOutlines
                        P_Copy.ViewerPreferences = PdfWriter.PageLayoutSinglePage

                        Dim Root As PdfOutline = P_Copy.DirectContent.RootOutline
                        Dim GoToPage As PdfAction = PdfAction.GotoLocalPage(PageNoForBookmark, New PdfDestination(PdfDestination.FITB), P_Copy)
                        Dim DtBookmark As DataTable = Access.GetDataTableFromText("select ownerName,lastname from MomayezyData where nosazicode='" + Title_L(i) + "'", Nothing)

                        Dim OutLine As PdfOutline = New PdfOutline(Root, GoToPage, Title_L(i) + " (" + DtBookmark.Rows(0).Item("ownerName").ToString + "  " + DtBookmark.Rows(0).Item("LastName").ToString + " )")

                        '------------ file --> reader --> Pcopy --> AddPage 

                        If IsDoubleSide Then

                            Dim _page As PdfImportedPage = P_Copy.GetImportedPage(P_Reader, i + 1)
                            P_Copy.AddPage(_page)
                        Else


                            If (i + 1) Mod 2 = 1 Then ' no added  page for zoj bookmark

                                Dim _page As PdfImportedPage = P_Copy.GetImportedPage(P_Reader, PageNoForBookmark)
                                P_Copy.AddPage(_page)

                            End If



                        End If





                    Next

                End If

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            Finally
                Document.Close()
            End Try

        End Sub

        '--------------------------------------


        Public Shared Function ExtractImages(ByVal sourcePdf As String) As List(Of System.Drawing.Image)

            Dim imgList As New List(Of System.Drawing.Image)

            Dim Raf As iTextSharp.text.pdf.RandomAccessFileOrArray = Nothing
            Dim PReader As iTextSharp.text.pdf.PdfReader = Nothing
            Dim PObject As iTextSharp.text.pdf.PdfObject = Nothing
            Dim PStream As iTextSharp.text.pdf.PdfStream = Nothing


            Try

                Raf = New iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdf)
                PReader = New iTextSharp.text.pdf.PdfReader(Raf, Nothing)

                For i As Integer = 0 To PReader.XrefSize - 1

                    PObject = PReader.GetPdfObject(i)

                    If Not IsNothing(PObject) AndAlso PObject.IsStream() Then

                        PStream = DirectCast(PObject, iTextSharp.text.pdf.PdfStream)
                        Dim subtype As iTextSharp.text.pdf.PdfObject = PStream.Get(iTextSharp.text.pdf.PdfName.SUBTYPE)

                        If Not IsNothing(subtype) AndAlso subtype.ToString = iTextSharp.text.pdf.PdfName.IMAGE.ToString Then

                            Dim bytes() As Byte = iTextSharp.text.pdf.PdfReader.GetStreamBytesRaw(CType(PStream, iTextSharp.text.pdf.PRStream))

                            If Not IsNothing(bytes) Then

                                Try
                                    Using memStream As New System.IO.MemoryStream(bytes)
                                        memStream.Position = 0
                                        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(memStream)
                                        imgList.Add(img)
                                    End Using
                                Catch ex As Exception
                                    'Most likely the image is in an unsupported format
                                    'Do nothing
                                    'You can add your own code to handle this exception if you want to
                                End Try

                            End If
                        End If
                    End If
                Next
                PReader.Close()
            Catch ex As Exception
                ' MessageBox.Show(ex.Message)
            End Try
            Return imgList
        End Function


        '----------------------
        Public Function CopyToClipboard(ByVal SourceDir As String) As Boolean


            ' Dim FileTypeCollection As New FileTypeCollection

            ' Acrobat objects
            Dim pdfDoc As Acrobat.CAcroPDDoc
            Dim pdfPage As Acrobat.CAcroPDPage
            Dim pdfRect As Acrobat.CAcroRect
            Dim pdfRectTemp As Object


            Try

                ' Get list of files to process from the input path
                ' Could change to read list from database instead 

                Dim Files As New ArrayList
                Files.AddRange(IO.Directory.GetFiles(SourceDir, "*.pdf", IO.SearchOption.AllDirectories))



                For n As Integer = 0 To Files.Count - 1 ' All File


                    If IO.Path.GetExtension(Files(n)) = ".pdf" Then


                        Try



                            Dim CurFile As String = Files(n)

                            Dim pageCount As Integer
                            Dim ret As Integer

                            ' Could skip if thumbnail already exists in output path
                            ''Dim fi As New FileInfo(inputFile)
                            ''If Not fi.Exists() Then
                            ''
                            ''End If

                            ' Create the document (Can only create the AcroExch.PDDoc object using late-binding)
                            pdfDoc = CreateObject("AcroExch.PDDoc")

                            ' Open the document
                            ret = pdfDoc.Open(CurFile)

                            If ret = False Then
                                Throw New FileNotFoundException
                            End If

                            ' Get the number of pages
                            pageCount = pdfDoc.GetNumPages()


                            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                            For i As Integer = 0 To pageCount - 1

                                'Dim outputFile As String = Files(n) + (i + 1).ToString + ".png"


                                ' Get the first page
                                pdfPage = pdfDoc.AcquirePage(i) '0

                                ' Get the size of the page
                                ' This is really strange bug/documentation problem
                                ' The PDFRect you get back from GetSize has properties
                                ' x and y, but the PDFRect you have to supply CopyToClipboard
                                ' has left, right, top, bottom
                                pdfRectTemp = pdfPage.GetSize

                                ' Create PDFRect to hold dimensions of the page
                                pdfRect = CreateObject("AcroExch.Rect")

                                pdfRect.Left = 0
                                pdfRect.right = pdfRectTemp.x
                                pdfRect.Top = 0
                                pdfRect.bottom = pdfRectTemp.y

                                ' Render to clipboard, scaled by 100 percent (ie. original size)
                                ' Even though we want a smaller image, better for us to scale in .NET
                                ' than Acrobat as it would greek out small text
                                ' see http://www.adobe.com/support/techdocs/1dd72.htm

                                Call pdfPage.CopyToClipboard(pdfRect, 0, 0, 100)


                                Dim clipboardData As Windows.Forms.IDataObject = Windows.Forms.Clipboard.GetDataObject()

                                If (clipboardData.GetDataPresent(Windows.Forms.DataFormats.Bitmap)) Then


                                    Dim outputFile As String = IO.Path.GetDirectoryName(Files(n)) + "\" + IO.Path.GetFileNameWithoutExtension(Files(n)) + "_" + (i + 1).ToString + ".jpg"

                                    ' ResizingImageSave(Files(n), outputFile, 50, False)
                                    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                    ResizingImageSave(clipboardData.GetData(Windows.Forms.DataFormats.Bitmap), outputFile, pdfRectTemp.x, False, "")
                                    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                                    RaiseEvent FileDown_Down(Me, outputFile)

                                End If

                                'Dim FileType As New FileType
                                'FileType.Path = pdfInputPath
                                'FileType.Kind = "pdf"
                                'FileType.Name = IO.Path.GetFileName(Files(n))
                                'FileType.PageNo = i + 1
                                'FileType.ThumbImage = "~\Temp\Thumb\" + IO.Path.GetFileName(Files(n)) + (i + 1).ToString + ".png"

                                'FileTypeCollection.Add(FileType)

                            Next

                            pdfDoc.Close()
                            Marshal.ReleaseComObject(pdfPage)
                            Marshal.ReleaseComObject(pdfRect)
                            Marshal.ReleaseComObject(pdfDoc)

                        Catch ex As Exception
                            Throw New Exception(ex.Message, ex)
                        End Try
                    End If
                Next n 'files.Length - 1

                Return True

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try




        End Function




        Public Function CopyToClipboard(ByVal SourceDir As String, ByVal ThumbDir As String, ByVal _templatePortraitFile As String, ByVal _templateLandscapeFile As String) As FileTypeCollection

            ' Dim a As String = hc.Server.MapPath("~\temp")


            Dim FileTypeCollection As New FileTypeCollection

            ' Acrobat objects
            Dim pdfDoc As Acrobat.CAcroPDDoc
            Dim pdfPage As Acrobat.CAcroPDPage
            Dim pdfRect As Acrobat.CAcroRect
            Dim pdfRectTemp As Object


            Dim pdfInputPath As String = SourceDir 'Server.MapPath("~") + "\temp" 'page.MapPath("~")
            Dim pngOutputPath As String = ThumbDir
            Dim templatePortraitFile As String = _templatePortraitFile
            Dim templateLandscapeFile As String = _templateLandscapeFile


            Try

                ' Get list of files to process from the input path
                ' Could change to read list from database instead 
                Dim Files As New ArrayList
                'Files.AddRange(Directory.GetFiles(pdfInputPath, "*.pdf"))
                Files.AddRange(Directory.GetFiles(pdfInputPath, "*.jpg"))
                Files.AddRange(Directory.GetFiles(pdfInputPath, "*.gif"))


                ' Dim files() As String = Directory.GetFiles(pdfInputPath, "*.pdf")
                ' files. = Directory.GetFiles(pdfInputPath, "*.jpg")





                For n As Integer = 0 To Files.Count - 1 ' All File


                    If IO.Path.GetExtension(Files(n)) = ".pdf" Then


                        'Try



                        '    Dim inputFile As String = Files(n)

                        '    ' Dim outputFile As String = files(n) + ".png"

                        '    Dim pageCount As Integer
                        '    Dim ret As Integer

                        '    ' Could skip if thumbnail already exists in output path
                        '    ''Dim fi As New FileInfo(inputFile)
                        '    ''If Not fi.Exists() Then
                        '    ''
                        '    ''End If

                        '    ' Create the document (Can only create the AcroExch.PDDoc object using late-binding)
                        '    pdfDoc = CreateObject("AcroExch.PDDoc")

                        '    ' Open the document
                        '    ret = pdfDoc.Open(inputFile)

                        '    If ret = False Then
                        '        Throw New FileNotFoundException
                        '    End If

                        '    ' Get the number of pages
                        '    pageCount = pdfDoc.GetNumPages()


                        '    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                        '    For i As Integer = 0 To pageCount - 1

                        '        'Dim outputFile As String = Files(n) + (i + 1).ToString + ".png"
                        '        Dim outputFile As String = ThumbDir + "\" + IO.Path.GetFileName(Files(n)) + (i + 1).ToString + ".png"

                        '        ' Get the first page
                        '        pdfPage = pdfDoc.AcquirePage(i) '0

                        '        ' Get the size of the page
                        '        ' This is really strange bug/documentation problem
                        '        ' The PDFRect you get back from GetSize has properties
                        '        ' x and y, but the PDFRect you have to supply CopyToClipboard
                        '        ' has left, right, top, bottom
                        '        pdfRectTemp = pdfPage.GetSize

                        '        ' Create PDFRect to hold dimensions of the page
                        '        pdfRect = CreateObject("AcroExch.Rect")

                        '        pdfRect.Left = 0
                        '        pdfRect.right = pdfRectTemp.x
                        '        pdfRect.Top = 0
                        '        pdfRect.bottom = pdfRectTemp.y

                        '        ' Render to clipboard, scaled by 100 percent (ie. original size)
                        '        ' Even though we want a smaller image, better for us to scale in .NET
                        '        ' than Acrobat as it would greek out small text
                        '        ' see http://www.adobe.com/support/techdocs/1dd72.htm

                        '        Call pdfPage.CopyToClipboard(pdfRect, 0, 0, 100)






                        '        Dim clipboardData As Windows.Forms.IDataObject = Windows.Forms.Clipboard.GetDataObject()

                        '        If (clipboardData.GetDataPresent(Windows.Forms.DataFormats.Bitmap)) Then



                        '            Dim pdfBitmap As Drawing.Bitmap = clipboardData.GetData(Windows.Forms.DataFormats.Bitmap)

                        '            If pdfBitmap Is Nothing Then
                        '                Throw New Exception("pdfBitmap is nothing")
                        '            End If


                        '            ' Size of generated thumbnail in pixels
                        '            Dim Thumb_Width As Integer = 38  '
                        '            Dim Thumb_Height As Integer = 52

                        '            Dim templateFile As String

                        '            ' Switch between portrait and landscape
                        '            If (pdfRectTemp.x < pdfRectTemp.y) Then
                        '                templateFile = templatePortraitFile
                        '            Else
                        '                templateFile = templateLandscapeFile
                        '                ' Swap width and height (little trick not using third temp variable)
                        '                Thumb_Width = Thumb_Width Xor Thumb_Height
                        '                Thumb_Height = Thumb_Width Xor Thumb_Height
                        '                Thumb_Width = Thumb_Width Xor Thumb_Height
                        '            End If


                        '            ' Load the template graphic
                        '            Dim templateBitmap As Drawing.Bitmap = New Drawing.Bitmap(templateFile)
                        '            Dim templateImage As Drawing.Image = Drawing.Image.FromFile(templateFile)

                        '            ' Render to small image using the bitmap class
                        '            Dim pdfImage As Drawing.Image = pdfBitmap.GetThumbnailImage(Thumb_Width, Thumb_Height, Nothing, Nothing)

                        '            ' Dim Original As Drawing.Image = Drawing.Image.FromFile(Image_path)
                        '            'Dim Thumb As Drawing.Image = Original.GetThumbnailImage(Thumb_Width, Original.Height / Original.Width * Thumb_Width, Nothing, New IntPtr())




                        '            ' Create new blank bitmap (+ 7 for template border)
                        '            Dim thumbnailBitmap As Drawing.Bitmap = New Drawing.Bitmap(Thumb_Width + 7, Thumb_Height + 7, Drawing.Imaging.PixelFormat.Format32bppArgb)

                        '            ' To overlayout the template with the image, we need to set the transparency
                        '            ' http://www.sellsbrothers.com/writing/default.aspx?content=dotnetimagerecoloring.htm
                        '            templateBitmap.MakeTransparent()

                        '            Dim thumbnailGraphics As Drawing.Graphics = Drawing.Graphics.FromImage(thumbnailBitmap)

                        '            ' Draw rendered pdf image to new blank bitmap
                        '            thumbnailGraphics.DrawImage(pdfImage, 2, 2, Thumb_Width, Thumb_Height)

                        '            ' Draw template outline over the bitmap (pdf with show through the transparent area)
                        '            thumbnailGraphics.DrawImage(templateImage, 0, 0)

                        '            ' Save as .png file
                        '            thumbnailBitmap.Save(outputFile, Drawing.Imaging.ImageFormat.Png)


                        '            Console.WriteLine("Generated thumbnail... {0}", outputFile)

                        '            thumbnailGraphics.Dispose()


                        '        End If


                        '        Dim FileType As New FileType
                        '        FileType.Path = pdfInputPath
                        '        FileType.Kind = "pdf"
                        '        FileType.Name = IO.Path.GetFileName(Files(n))
                        '        FileType.PageNo = i + 1
                        '        FileType.ThumbImage = "~\Temp\Thumb\" + IO.Path.GetFileName(Files(n)) + (i + 1).ToString + ".png"

                        '        FileTypeCollection.Add(FileType)





                        '    Next

                        '    pdfDoc.Close()
                        '    Marshal.ReleaseComObject(pdfPage)
                        '    Marshal.ReleaseComObject(pdfRect)
                        '    Marshal.ReleaseComObject(pdfDoc)

                        'Catch ex As Exception
                        '    Throw New Exception(ex.Message, ex)
                        'End Try

                    ElseIf IO.Path.GetExtension(Files(n)) = ".jpg" Then

                        Dim outputFile As String = ThumbDir + "\" + IO.Path.GetFileName(Files(n)) + ".jpg"
                        Dim ImageManager As New HS.Images.ImageManager
                        ImageManager.ResizingImageSave(Files(n), outputFile, 50, False)

                        Dim FileType As New FileType
                        FileType.Path = pdfInputPath
                        FileType.Kind = "jpg"
                        FileType.Name = IO.Path.GetFileName(Files(n))
                        FileType.PageNo = -1
                        FileType.ThumbImage = "~\Temp\Thumb\" + IO.Path.GetFileName(Files(n)) + ".jpg"

                        FileTypeCollection.Add(FileType)


                    ElseIf IO.Path.GetExtension(Files(n)) = ".gif" Then

                        Dim outputFile As String = ThumbDir + "\" + IO.Path.GetFileName(Files(n)) + ".jpg"
                        Dim ImageManager As New HS.Images.ImageManager
                        ImageManager.ResizingImageSave(Files(n), outputFile, 50, False)

                        Dim FileType As New FileType
                        FileType.Path = pdfInputPath
                        FileType.Kind = "gif"
                        FileType.Name = IO.Path.GetFileName(Files(n))
                        FileType.PageNo = -1
                        FileType.ThumbImage = "~\Temp\Thumb\" + IO.Path.GetFileName(Files(n)) + ".jpg"

                        FileTypeCollection.Add(FileType)

                    End If


                Next n 'files.Length - 1


            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

            Return FileTypeCollection


        End Function

        '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        ''' <summary>
        ''' Remove specified page(s) from a pdf file
        ''' </summary>
        ''' <param name="sourcePdf">The source pdf to have pages removed from</param>
        ''' <param name="pagesToRemove">List of pages to be removed</param>
        ''' <param name="outputPdf">The output pdf after pages removed</param>
        ''' <returns>True if successful, false if failed</returns>
        ''' <remarks></remarks>
        ''' 

        Public Shared Function RemovePages(ByVal sourcePdf As String, ByVal pagesToRemove As List(Of Integer), ByVal outputPdf As String) As Boolean

            Dim AllpageDeleted As Boolean = False

            Dim result As Boolean = False

            Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
            Dim doc As iTextSharp.text.Document = Nothing
            Dim copier As iTextSharp.text.pdf.PdfCopy = Nothing

            Try

                reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
                doc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1))
                copier = New iTextSharp.text.pdf.PdfCopy(doc, New IO.FileStream(outputPdf, IO.FileMode.Create))
                doc.Open()

                For i As Integer = 1 To reader.NumberOfPages
                    If Not pagesToRemove.Contains(i) Then
                        copier.AddPage(copier.GetImportedPage(reader, i))
                    End If
                Next


                If doc.PageNumber = 0 Then
                    AllpageDeleted = True
                    result = True
                End If

                doc.Close()
                reader.Close()
                result = True
            Catch ex As Exception
                'Put your own code to handle exception here
                Debug.Write(ex.Message)
            Finally
                If Not doc Is Nothing AndAlso doc.IsOpen Then
                    doc.Close()
                End If
            End Try

            If AllpageDeleted Then
                'copier.Close()
                'IO.File.Delete(outputPdf)
            End If

            Return result
        End Function

        Public Overloads Shared Sub CreateBlankPdf(ByVal pageSize As iTextSharp.text.Rectangle, ByVal outPdf As String)
            Dim doc As iTextSharp.text.Document = Nothing
            Dim writer As iTextSharp.text.pdf.PdfWriter = Nothing
            Try
                doc = New iTextSharp.text.Document(pageSize)
                writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New IO.FileStream(outPdf, IO.FileMode.Create))
                doc.Open()
                doc.Add(New iTextSharp.text.Paragraph(" "))
                doc.Close()
            Catch ex As Exception
                Debug.Write(ex.Message)
            End Try
        End Sub

        Public Overloads Shared Sub CreateBlankPdf(ByVal sourcePdf As String, ByVal outPdf As String)
            Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
            Dim doc As iTextSharp.text.Document = Nothing
            Dim writer As iTextSharp.text.pdf.PdfWriter = Nothing
            Try
                reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
                doc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1))
                writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New IO.FileStream(outPdf, IO.FileMode.Create))
                doc.Open()
                doc.Add(New iTextSharp.text.Paragraph(" "))
                doc.Close()
            Catch ex As Exception
                Debug.Write(ex.Message)
            End Try
        End Sub

        Public Shared Sub DrawShapesDemo(ByVal sourcePdf As String, ByVal outputPdf As String)
            Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
            Dim stamper As iTextSharp.text.pdf.PdfStamper = Nothing
            Dim cb As iTextSharp.text.pdf.PdfContentByte = Nothing
            Dim rect As iTextSharp.text.Rectangle = Nothing
            Dim pageCount As Integer = 0
            Dim borderColor, fillColor As iTextSharp.text.BaseColor
            Try
                reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
                rect = reader.GetPageSizeWithRotation(1)
                stamper = New iTextSharp.text.pdf.PdfStamper(reader, New System.IO.FileStream(outputPdf, IO.FileMode.Create))
                ' Set up the border and fill color for the shapes to be drawn
                borderColor = iTextSharp.text.BaseColor.BLUE
                fillColor = iTextSharp.text.BaseColor.PINK
                'Loop thru the pages and draw various shapes to their overcontent layer
                pageCount = reader.NumberOfPages()
                For i As Integer = 1 To pageCount
                    'Get the undercontent layer of this page
                    cb = stamper.GetUnderContent(i)
                    '<<< Note: if you want the drawings to appear on top of the contents (covering it)
                    ' then you need to get the overcontent layer.
                    'cb = stamper.GetOverContent(i)

                    'Set the boder color of the shapes
                    cb.SetColorStroke(borderColor)
                    'Set the fill color of the shapes
                    cb.SetColorFill(fillColor)
                    'Start drawing shapes. 

                    ' >>>> Remember, the cordinate of the LOWER-LEFT corner of a page is (0, 0)
                    ' 1 in = 72 units, so a 8.5 x 11 page will have a width of 612 units and a height of 792 units.
                    ' Figuring out where to draw your shapes will be much easier if you use a piece of paper to
                    ' plot out the cordinates first.

                    'Draw a circle centered at (135, 500) with a radius of 50
                    cb.Circle(135, 500, 50)
                    'Draw an ellipse that fits in a ractangle with (190, 450) as the lower-left corner
                    'and (400, 550) as the upper-right corner
                    cb.Ellipse(190, 450, 400, 550)
                    'Draw a square with the lower-left corner is (410, 450) and the width (and height) = 100
                    cb.Rectangle(410, 450, 100, 100)
                    'Draw a rounded rectangle
                    cb.RoundRectangle(150, 330, 200, 100, 20)
                    'Color fill the shapes above
                    cb.FillStroke()
                    'Draw a line starting from (150, 310) to (450, 310)
                    cb.MoveTo(150, 310)
                    cb.LineTo(450, 310)
                    cb.Stroke()
                    'Draw a triangle with vertices (290, 300), (150, 150) and (450, 150) without filling
                    cb.MoveTo(290, 300)
                    cb.LineTo(150, 150)
                    cb.LineTo(450, 150)
                    cb.ClosePathStroke()
                Next
                stamper.Close()
                reader.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>



        '------------------- create old fish

        Sub MergePdfInOnePdf(ByVal Page As System.Web.UI.Page, ByVal PartName As String, ByVal DtGisOfCode As DataTable, ByVal FileOut As String)

            Dim Pat As String = Page.MapPath("~")
            Dim _FileOut As String = Pat + "\" + FileOut


            Dim Document As New iTextSharp.text.Document '= New iTextSharp.text.Document(P_Reader.GetPageSizeWithRotation(1))
            Try



                Dim P_Copy As PdfCopy = New PdfCopy(Document, New FileStream(_FileOut, FileMode.Create))

                Document.Open()

                Dim TargetPage As Integer = 0

                For i = 0 To DtGisOfCode.Rows.Count - 1


                    Dim CurrentFile As String = PartName + "_" + DtGisOfCode.Rows(i).Item("nosaziCode").ToString + ".pdf"

                    If IO.File.Exists(CurrentFile) Then

                        AddPage2OnePdf(P_Copy, CurrentFile, DtGisOfCode.Rows(i).Item("nosaziCode").ToString, TargetPage)

                        'TargetPage += 2
                        TargetPage += 1

                    End If

                Next

            Catch ex As Exception

            Finally
                Document.Close()
            End Try

        End Sub

        Private Sub AddPage2OnePdf(ByVal P_Copy As PdfCopy, ByVal PageFileWPath As String, ByVal nosaziCode As String, ByVal TargetPage As Integer)


            Dim CurrentFile As String = PageFileWPath


            P_Copy.ViewerPreferences = PdfWriter.PageModeUseOutlines
            P_Copy.ViewerPreferences = PdfWriter.PageLayoutSinglePage

            Dim Root As PdfOutline = P_Copy.DirectContent.RootOutline
            Dim GoToPage As PdfAction = PdfAction.GotoLocalPage(TargetPage + 1, New PdfDestination(PdfDestination.FITB), P_Copy)
            Dim DtBookmark As DataTable = Access.GetDataTableFromText("select ownerName,lastname from MomayezyData where nosazicode='" + nosaziCode + "'", Nothing)

            Dim OutLine As PdfOutline = New PdfOutline(Root, GoToPage, nosaziCode + " (" + DtBookmark.Rows(0).Item("ownerName").ToString + "  " + DtBookmark.Rows(0).Item("LastName").ToString + " )")


            '------------ 2 or  1 page per pdf file
            ' file --> reader --> Copy --> AddPage 

            Dim P_Reader As PdfReader = New PdfReader(CurrentFile)

            P_Copy.AddPage(P_Copy.GetImportedPage(P_Reader, 1))

            'P_Copy.AddPage(P_Copy.GetImportedPage(P_Reader, 2)) 'by sarandy



        End Sub



#End Region

        Public Sub ResizingImageSave(ByVal clipboardBitmap As Drawing.Bitmap, ByVal Thumb_path As String, ByVal Thumb_Width As Integer, ByVal DelSource As Boolean, ByVal Image_path As String) 'thumb_Width=200 or 350 or 100

            Try


                Dim Original As Drawing.Image = clipboardBitmap

                If Original Is Nothing Then
                    Throw New Exception("Original is nothing")
                End If

                Dim Thumb As Drawing.Image = Original.GetThumbnailImage(Thumb_Width, Original.Height / Original.Width * Thumb_Width, Nothing, New IntPtr())

                '-----------------  White Canvas

                Dim Canvas As Drawing.Graphics = Drawing.Graphics.FromImage(Thumb)
                Canvas.Clear(Drawing.Color.White)

                Canvas.SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
                Canvas.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

                Canvas.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                Canvas.PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.HighQuality


                Dim h As Integer = Original.Height / Original.Width * Thumb_Width
                Canvas.DrawImage(Original, 0, 0, Thumb_Width, h)

                '---------------
                Thumb.Save(Thumb_path, Drawing.Imaging.ImageFormat.Jpeg)

                Original.Dispose()

                If DelSource AndAlso System.IO.File.Exists(Image_path) Then
                    System.IO.File.Delete(Image_path)
                End If



            Catch ex As Exception
                _HasError = True
                _Message = " خطا در ذخیره فایل تصویر " + ex.Message
            End Try


            '~~~~~~~~~~~~~~~~~~~~~~~
            ' no diffrent bitwein / or \
            ' Server.MapPath("")       current folder  E:\_web project\Archive_BidBoland
            ' Server.MapPath("~")      root folder
            ' Server.MapPath("map")                    E:\_web project\Archive_BidBoland\map

            ' Server.MapPath("\")                      c:\inetpub\wwwroot\
            ' Server.MapPath("\map") map not vdir  --> c:\inetpub\wwwroot\map
            ' Server.MapPath("\maps") maps is vdir --> E:\_web project\Archive_BidBoland_VDir\Maps 

            '------------------------------------

        End Sub


    End Class


End Namespace
