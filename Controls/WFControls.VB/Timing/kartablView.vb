Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.TimeParties
Imports Lawyer.Common.VB.Timing
Imports Lawyer.Common.VB.Docs
Imports System.IO
Imports Lawyer.Common.VB.LawyerError

Public Class kartablView

    Private timeId As String = String.Empty

#Region "Events"

    Public Function Bind(ByVal timePartiesID As String) As Boolean

        Try
            lstFiles.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Underline, GraphicsUnit.Point)

            'lstFiles.ForeColor = Color.Blue

            LoadDefaultImageFromTempDoc()

            k = TimePartiesManager.GetKartablByIDForView(timePartiesID)

            If k IsNot Nothing Then

                txtFrom.Text = k.sender

                Dim kdate As String = k.timeDate.ToString


                txtDate.Text = kdate.Substring(0, 4) + "/" + kdate.Substring(4, 2) + "/" + kdate.Substring(6, 2)

                txtTime.Text = k.timeTime

                txtTitle.Text = k.timeTitle

                rcDescription.Text = k.timeText

            End If

            Dim docs As DeskDocsReviewCollection = TimingManager.GetAllTimingDeskDocs(k.timeID)

            If docs IsNot Nothing Then

                For Each Item As DeskDocsReview In docs

                    Dim dr As Integer = lstFiles.Rows.Add()

                    lstFiles.Rows(dr).Cells("gvClmTitle").Value = Item.deskDocName

                    lstFiles.Rows(dr).Cells("gvClmID").Value = Item.deskDocID

                    lstFiles.Rows(dr).Cells("gvClmImage").Value = images.Images(Item.deskImageID)

                    'lstFiles.Rows(dr).Cells("clmnSaveAs").Value = "ذخیره"

                Next

            End If

            If k.tpTargetCustID <> k.timeSourceCustID Then

                timeId = String.Empty

            Else

                timeId = k.timeID

            End If

            Return True

        Catch ex As Exception
            ErrorManager.WriteMessage("Bind", ex.ToString(), Me.ParentForm.Text)
            Return False
        End Try





    End Function

#End Region

#Region "Utility"

    Private images As New ImageList
    'Delegate Sub ShowDocForm(ByVal filePath As String, ByVal fileName As String)
    'Event ShowDocContent As ShowDocForm
    Private k As KartablDetail

    Private Sub LoadDefaultImageFromTempDoc()

        images.ImageSize = New Size(16, 16)

        Dim list As BaseForm.ImageCollection = BaseForm.ImageManager.GetImagesByGroupName("Size16")

        If list IsNot Nothing Then

            For Each Item As BaseForm.Image In list

                Try

                    Dim imagefullPath As String = FileManager.GetDocsImagePath() & Item.imageID & Item.imageUpdateDate & Item.imageExtension

                    Dim imageKey As String = Item.imageID

                    If Not System.IO.File.Exists(imagefullPath) Then

                        BaseForm.ImageManager.WriteImage(imageKey, imagefullPath)

                    End If

                    images.Images.Add(Item.imageID, Bitmap.FromFile(imagefullPath))

                Catch ex As Exception

                End Try

            Next

        End If

    End Sub

    Private Sub lstFiles_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lstFiles.CellClick

        Try
            Dim file As String = TimingManager.WriteFile(lstFiles.Rows(e.RowIndex).Cells(2).Value)

            If e.ColumnIndex = 3 Then

                With SaveFileDialog1

                    .FileName = Path.GetFileName(file)

                    '.Filter = Path.GetExtension(file)

                    If .ShowDialog = Windows.Forms.DialogResult.OK Then

                        '.FileName = Path.GetFileName(file)
                        Dim newfile As String = .FileName
                        newfile = Path.ChangeExtension(newfile, Path.GetExtension(file))
                        IO.File.Copy(file, newfile)

                    End If

                End With

            End If

        Catch ex As Exception
            ErrorManager.WriteMessage("lstFiles_CellClick", ex.ToString(), Me.ParentForm.Text)
        End Try

    End Sub

    Public Function IsDeletable() As String

        Return timeId

    End Function

#End Region

    'Private Sub lstFiles_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lstFiles.CellDoubleClick

    '    Try

    '        Dim file As String = TimingManager.WriteFile(lstFiles.Rows(e.RowIndex).Cells(2).Value)

    '        If e.ColumnIndex = 1 Then


    '            Dim extension As String = System.IO.Path.GetExtension(file)

    '            If extension = ".txt" OrElse extension = ".dot" OrElse extension = ".dotx" OrElse extension = ".docx" OrElse extension = ".doc" Then

    '                RaiseEvent ShowDocContent(file)

    '            Else

    '                System.Diagnostics.Process.Start(file)

    '            End If

    '        End If

    '    Catch ex As Exception
    '        ErrorManager.WriteMessage("lstFiles_CellDoubleClick", ex.ToString(), Me.ParentForm.Text)
    '    End Try
    'End Sub
End Class
