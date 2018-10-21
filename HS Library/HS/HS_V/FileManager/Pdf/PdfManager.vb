Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Namespace HS.FileManager.Pdf


    Public Class PdfManager

        Public Shared Function CreatePdfFromPdfAndImage(ByVal FileList() As String, ByVal OutputPdf As String, ByVal Printable As Boolean, ByVal Bookmarks() As String) As Boolean


            Dim Document As New iTextSharp.text.Document

            Dim writer As PdfWriter = PdfWriter.GetInstance(Document, New FileStream(OutputPdf, FileMode.Create))
            If Printable Then
                writer.SetEncryption(Nothing, Nothing, PdfWriter.ALLOW_PRINTING, PdfWriter.STANDARD_ENCRYPTION_128)
            Else
                writer.SetEncryption(Nothing, Nothing, PdfWriter.ALLOW_COPY, PdfWriter.STANDARD_ENCRYPTION_128)
            End If


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

                    '-------------------

                    If Not Bookmarks Is Nothing Then
                        writer.ViewerPreferences = PdfWriter.PageModeUseOutlines
                        If Bookmarks(i) <> "" Then

                            Dim cb As PdfContentByte = writer.DirectContent
                            Dim root As PdfOutline = cb.RootOutline
                            Dim dest As PdfAction = PdfAction.GotoLocalPage(i + 1, New PdfDestination(PdfDestination.FITB), writer)
                            Dim what As PdfOutline = New PdfOutline(root, dest, Bookmarks(i))

                        End If
                    Else
                        writer.ViewerPreferences = PdfWriter.PageLayoutSinglePage
                    End If
                    '-------------------


                Next


                Return True


            Catch ex As IOException
                '    _HasError = True
                '    _Exception = ex
                '   SetMessage(ex.Message)
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


        Public Shared Function CreateSetEncryptionPdf(ByVal InputPdf As String, ByVal OutputPdf As String, ByVal Printable As Boolean, ByVal SelPages As String) As Boolean

            Dim reader As PdfReader = New PdfReader(InputPdf)

            If Not SelPages Is Nothing Then
                reader.SelectPages(SelPages)
            End If


            Dim stamper As PdfStamper = New PdfStamper(reader, New FileStream(OutputPdf, FileMode.Create))

            If Printable Then
                stamper.SetEncryption(Nothing, Nothing, PdfWriter.ALLOW_PRINTING, PdfWriter.STANDARD_ENCRYPTION_128)
            Else
                stamper.SetEncryption(Nothing, Nothing, PdfWriter.ALLOW_COPY, PdfWriter.STANDARD_ENCRYPTION_128)
            End If

            stamper.Close()

            Return True

        End Function





    End Class


End Namespace