Imports Word
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.VB.LawyerError
Imports Shetab.LicenseControl.Helper

Public Class OpenDoc
    Private Const C_LicenceID As UInteger = LawyerSetting.LicenceId

#Region " New "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Try

            WinWordControl.WinWordControl.wordWnd = 0
            WinWordControl.WinWordControl.wAppC = Nothing
            objWinWordControl.wDoc = Nothing

            Protect(False)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری"
            ErrorManager.WriteMessage("New()", ex.ToString, Me.Text)
        End Try


    End Sub

    Dim _IsTemplate As Boolean

    Public Sub New(ByVal FileFullPath As String, ByVal FileId As String, ByVal TableName As String, ByVal fileName As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ''Try

        ''    WinWordControl.WinWordControl.wordWnd = 0
        ''    WinWordControl.WinWordControl.wAppC = Nothing
        ''    objWinWordControl.wDoc = Nothing

        ''    lblTitle.Text = fileName

        ''    objWinWordControl.LoadDocument(FileFullPath, FileId, TableName, False)

        ''    'Sarandy
        ''    'If IO.Path.GetExtension(FileFullPath) = ".dot" Or IO.Path.GetExtension(FileFullPath) = ".dotx" Then
        ''    '    _IsTemplate = True
        ''    '    Protect(True)
        ''    'End If

        ''    Protect(False)

        ''Catch ex As Exception
        ''    Me.lblMessage.Text = "خطا در بارگذاری"
        ''    ErrorManager.WriteMessage("New()", ex.ToString, Me.Text)
        ''End Try


    End Sub

    Public Sub New(ByVal FileFullPath As String, ByVal filecaseId As String, ByVal FileId As String, ByVal TableName As String, ByVal fileName As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ''Try

        ''    WinWordControl.WinWordControl.wordWnd = 0
        ''    WinWordControl.WinWordControl.wAppC = Nothing
        ''    objWinWordControl.wDoc = Nothing

        ''    lblTitle.Text = fileName

        ''    objWinWordControl.LoadDocument(FileFullPath, FileId, TableName, False)

        ''    'Sarandy
        ''    'If IO.Path.GetExtension(FileFullPath) = ".dot" Or IO.Path.GetExtension(FileFullPath) = ".dotx" Then
        ''    '    _IsTemplate = True
        ''    '    Protect(True)
        ''    'End If

        ''    objWinWordControl.BindDetails(filecaseId)

        ''    Protect(False)

        ''Catch ex As Exception
        ''    Me.lblMessage.Text = "خطا در بارگذاری"
        ''    ErrorManager.WriteMessage("New()", ex.ToString, Me.Text)
        ''End Try

    End Sub

    Public Sub New(ByVal FileFullPath As String, ByVal fileName As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


        ''Try

        ''    WinWordControl.WinWordControl.wordWnd = 0

        ''    WinWordControl.WinWordControl.wAppC = Nothing

        ''    objWinWordControl.wDoc = Nothing

        ''    lblTitle.Text = fileName

        ''    objWinWordControl.LoadDocument(FileFullPath, False)

        ''    Protect(False)

        ''Catch ex As Exception
        ''    Me.lblMessage.Text = "خطا در بارگذاری"
        ''    ErrorManager.WriteMessage("New()", ex.ToString, Me.Text)
        ''End Try

    End Sub

#End Region

#Region " Load "

    'Friend WithEvents bt As System.Windows.Forms.Button
    Private Sub OpenDoc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.bt = New System.Windows.Forms.Button
        'Me.bt.BackColor = Color.Blue
        'Me.splitContainer1.Panel1.Controls.Add(bt)

        Me.lblMessage.Text = String.Empty

        Me.ToolTip1.SetToolTip(Me.btnOpen, "بازکردن")
        Me.ToolTip1.SetToolTip(Me.btnSave, "ذخیره کردن")
        Me.ToolTip1.SetToolTip(Me.btnSaveAndClose, "ذخیره و بستن")
        Me.ToolTip1.SetToolTip(Me.btnSaveAs, "ذخیره با نام")
        Me.ToolTip1.SetToolTip(Me.btnPdf, "تبدیل به Pdf")
        Me.ToolTip1.SetToolTip(Me.btnPrint, "چاپ")
        Me.ToolTip1.SetToolTip(Me.btnPrintDataOnly, "چاپ اطلاعات وارد شده")
        Me.ToolTip1.SetToolTip(Me.btnEmail, "ایمیل")
        Me.ToolTip1.SetToolTip(Me.btnFax, "فاکس")
        Me.ToolTip1.SetToolTip(Me.pbCenter, "تنظیم حاشیه ها")

        ' check exe file --
        Dim softLock As New SoftLock(C_LicenceID)
        softLock.CheckLock(False, True)

    End Sub

#End Region

#Region " Command "

    '' ''Public Sub OpenDoc(ByVal filepath As String, ByVal fileName As String)

    '' ''    Try

    '' ''        WinWordControl.WinWordControl.wordWnd = 0
    '' ''        WinWordControl.WinWordControl.wAppC = Nothing
    '' ''        'objWinWordControl.wDoc = Nothing

    '' ''        objWinWordControl.LoadDocument(filepath, False)

    '' ''    Catch ex As Exception
    '' ''        Me.lblMessage.Text = "خطا در بارگذاری فایل"
    '' ''        ErrorManager.WriteMessage("OpenDoc()", ex.ToString, Me.Text)
    '' ''    End Try

    '' ''End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click

        Try
            Me.lblMessage.Text = String.Empty

            OpenFileDialog1.Filter = "MS-Word Files(*.doc,*.dot,*.docx,*.dotx,*.txt) | *.doc;*.dot;*.docx;*.dotx;*.txt"
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Multiselect = False

            Dim filNm As String

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                filNm = OpenFileDialog1.FileName
            Else
                Return
            End If


            WinWordControl.WinWordControl.wordWnd = 0
            WinWordControl.WinWordControl.wAppC = Nothing
            'objWinWordControl.wDoc = Nothing

            lblTitle.Text = IO.Path.GetFileNameWithoutExtension(filNm)


            objWinWordControl.LoadDocument(filNm, False)

            Protect(False)
            Me.lblMessage.Text = String.Empty

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در بارگذاری فایل"
            ErrorManager.WriteMessage("btnOpen_Click()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub btnSaveAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndClose.Click

        SaveDoc(True)

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ''''**************************Forchnage Doc
        ''objWinWordControl.Writekey()
        '''*******************************************
        SaveDoc(False)

    End Sub

    Sub SaveDoc(ByVal closeDoc As Boolean)

        Try
            Me.lblMessage.Text = String.Empty
            ' '' '' check exe file --
            '' ''Dim softLock As New SoftLock(C_LicenceID)
            '' ''softLock.CheckLock(False, True)

            If objWinWordControl.wDoc IsNot Nothing Then
                objWinWordControl.saveDoc(objWinWordControl.wDoc, True, closeDoc)
            End If

            lblMessage.Text = "فایل ذخیره شد."

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ذخیره فایل"
            ErrorManager.WriteMessage("SaveDoc()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub btnSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAs.Click

        Try
            Me.lblMessage.Text = String.Empty

            ' check exe file --
            Dim random As New Random()
            Dim softlock As New SoftLock(C_LicenceID)
            Dim day As Integer = random.Next(0, 6)
            If Date.Now.DayOfWeek = day Then
                softlock.CheckLock(False, True)
            End If

            If objWinWordControl.wDoc IsNot Nothing Then


                SaveFileDialog1.Filter = "MS-Word Files(*.doc,*.dot,*.docx,*.txt) | *.doc;*.dot;*.docx;*.txt"

                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

                    objWinWordControl.documentSaveAs(SaveFileDialog1.FileName)

                    Dim ap As New Word.ApplicationClass()
                    While ap.BackgroundPrintingStatus > 0
                        System.Threading.Thread.Sleep(250)
                    End While


                End If

            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ذخیره فایل با نام"
            ErrorManager.WriteMessage("btnSaveAs_Click()", ex.ToString, Me.Text)
        End Try


    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click

        Try

            Me.lblMessage.Text = String.Empty
            If objWinWordControl.wDoc IsNot Nothing Then



                SaveFileDialog1.Filter = "(*.pdf)|*.pdf"

                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

                    Dim FilName As Object = SaveFileDialog1.FileName
                    Dim FormatPDF As Object = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF
                    Dim Missing As Object = Type.Missing

                    objWinWordControl.wDoc.SaveAs(FilName, FormatPDF, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing, Missing)


                    Dim ap As New Word.ApplicationClass()
                    While ap.BackgroundPrintingStatus > 0
                        System.Threading.Thread.Sleep(250)
                    End While

                End If

            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ذخیره pdf"
            ErrorManager.WriteMessage("btnPdf_Click()", ex.ToString, Me.Text)
        End Try


    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.lblMessage.Text = String.Empty

            If objWinWordControl.wDoc IsNot Nothing Then


                Dim Missing As Object = Type.Missing
                Dim _True As Object = True
                Dim _False As Object = False

                'objWinWordControl.wDoc.PrintOutOld(_True, _False, missingValue, missingValue, missingValue, missingValue, missingValue, _
                '            missingValue, missingValue, missingValue, _False, _
                '                 missingValue, missingValue, missingValue)

                'objWinWordControl.document.PrintFormsData=True
                'objWinWordControl.wAppC.ActiveDocument.PrintOut()
                'objWinWordControl.wAppC.Options.PrintProperties = True

                'WordObj.PrintOut Background:=False


                WinWordControl.WinWordControl.wAppC.Options.PrintBackground = True
                objWinWordControl.wDoc.PrintOut(_True)
                Me.lblMessage.Text = "فایل به چاپگر پیش فرض ارسال شد"

                Dim ap As New Word.ApplicationClass()
                While ap.BackgroundPrintingStatus > 0
                    System.Threading.Thread.Sleep(250)
                End While

            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در چاپ"
            ErrorManager.WriteMessage("btnPrint_Click()", ex.ToString, Me.Text)
        End Try



    End Sub

    Private Sub btnPrintDataOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDataOnly.Click

        Try

            Me.lblMessage.Text = String.Empty

            ' check exe file --
            Dim softLock As New SoftLock(C_LicenceID)
            softLock.CheckLock(False, True)

            If objWinWordControl.wDoc IsNot Nothing Then


                'objWinWordControl.wDoc.PrintFormsData = True


                'objWinWordControl.wDoc.ScreenUpdating = False
                Protect(False)

                Dim Undo_NO As Integer = 0


                For Each Shp As Word.Shape In objWinWordControl.wDoc.Shapes
                    If Shp.Type = Office.MsoShapeType.msoPicture Then

                        Shp.Visible = Office.MsoTriState.msoFalse
                        Undo_NO += 1

                        'Shp.Type = Office.MsoShapeType.msoTextBox
                        'Shp.AutoShapeType = Office.MsoAutoShapeType.msoShapeRectangle

                        'Shp.Type = Office.MsoShapeType.msoPicture
                        'Shp.AutoShapeType = Office.MsoAutoShapeType.msoShapeMixed
                    End If
                Next



                For Each Tbl As Word.Table In objWinWordControl.wDoc.Tables

                    'Tbl.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle
                    'Tbl.Borders.InsideLineWidth = WdLineWidth.wdLineWidth050pt
                    Tbl.Borders.InsideColor = Word.WdColor.wdColorWhite
                    Tbl.Borders.OutsideColor = WdColor.wdColorWhite
                    Undo_NO += 2

                Next


                objWinWordControl.wDoc.PrintOut()
                Me.lblMessage.Text = "فایل به چاپگر پیش فرض ارسال شد"

                'Dim ap As New Word.ApplicationClass()
                'While ap.BackgroundPrintingStatus > 0
                '  System.Threading.Thread.Sleep(250)
                'End While


                For i As Integer = 1 To Undo_NO
                    objWinWordControl.wDoc.Undo()
                Next


                Protect(True)
                'objWinWordControl.wDoc.ScreenUpdating = True
                objWinWordControl.wDoc.PrintFormsData = False

            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در چاپ اطلاعات وارد شده"
            ErrorManager.WriteMessage("btnPrintDataOnly_Click()", ex.ToString, Me.Text)
        End Try



    End Sub

    Dim frmEmail As New frmEmail

    Private Sub btnEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmail.Click

        Try
            Me.lblMessage.Text = String.Empty

            If objWinWordControl.wDoc IsNot Nothing Then


                objWinWordControl.saveDoc(objWinWordControl.wDoc, False, True)

                'From_Email and DisplayName set inside frmEmail
                'frmEmail.ESubjec = 
                'frmEmail.EBody = 
                frmEmail.EAttachment = objWinWordControl.wDoc.FullName
                frmEmail.ShowDialog()


            End If

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در اطلاعات ایمیل"
            ErrorManager.WriteMessage("btnEmail_Click()", ex.ToString, Me.Text)
        End Try


    End Sub

    Dim frmFox As New frmFox

    Private Sub btnFax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFax.Click

        Try
            Me.lblMessage.Text = String.Empty

            If objWinWordControl.wDoc IsNot Nothing Then

                objWinWordControl.saveDoc(objWinWordControl.wDoc, False, True)

                'frmFox.FText2File = objWinWordControl.wDoc.Content.ToString
                frmFox.frmFileName = objWinWordControl.wDoc.FullName
                frmFox.ShowDialog()

            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در اطلاعات فاکس"
            ErrorManager.WriteMessage("btnFax_Click()", ex.ToString, Me.Text)
        End Try


    End Sub

    Private Sub btn_Left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Left.Click

        Try
            Me.lblMessage.Text = String.Empty

            Protect(False)

            If objWinWordControl.wDoc IsNot Nothing AndAlso objWinWordControl.wDoc.PageSetup.LeftMargin - 6 > 0 Then
                ' objWinWordControl.wDoc.PageSetup.BottomMargin = objWinWordControl.wAppC.MillimetersToPoints(1)
                objWinWordControl.wDoc.PageSetup.LeftMargin -= 6
                objWinWordControl.wDoc.PageSetup.RightMargin += 6
            End If

            Protect(True)


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در حرکت به چپ"
            ErrorManager.WriteMessage("btn_Left_Click()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub btn_top_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_top.Click

        Try
            Me.lblMessage.Text = String.Empty

            Protect(False)

            If objWinWordControl.wDoc IsNot Nothing AndAlso objWinWordControl.wDoc.PageSetup.TopMargin - 6 > 0 Then
                objWinWordControl.wDoc.PageSetup.TopMargin -= 6
                objWinWordControl.wDoc.PageSetup.BottomMargin += 6
            End If

            Protect(True)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در حرکت به بالا"
            ErrorManager.WriteMessage("btn_top_Click()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub btn_Down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Down.Click


        Try
            Me.lblMessage.Text = String.Empty

            Protect(False)

            If objWinWordControl.wDoc IsNot Nothing AndAlso objWinWordControl.wDoc.PageSetup.BottomMargin - 6 > 0 Then
                objWinWordControl.wDoc.PageSetup.BottomMargin -= 6
                objWinWordControl.wDoc.PageSetup.TopMargin += 6
            End If

            Protect(True)

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در حرکت به پایین"
            ErrorManager.WriteMessage("btn_Down_Click()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub btn_Right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Right.Click

        Try
            Me.lblMessage.Text = String.Empty

            Protect(False)

            If objWinWordControl.wDoc IsNot Nothing AndAlso objWinWordControl.wDoc.PageSetup.RightMargin - 6 > 0 Then
                objWinWordControl.wDoc.PageSetup.RightMargin -= 6
                objWinWordControl.wDoc.PageSetup.LeftMargin += 6
            End If

            Protect(True)

        Catch ex As Exception
            Me.lblMessage.Text = "خطادر حرکت به راست"
            ErrorManager.WriteMessage("btn_Right_Click()", ex.ToString, Me.Text)
        End Try


    End Sub

    Sub Protect(ByVal Active As Boolean)

        Try

            Dim Pass As String = "1"
            Dim oPass As Object = CType(Pass, Object)
            Dim oTrue As Object = CType(True, Object)

            If Not objWinWordControl.wDoc Is Nothing Then


                If Active Then

                    'If objWinWordControl.wDoc.ProtectionType = WdProtectionType.wdNoProtection AndAlso _IsTemplate Then
                    '    objWinWordControl.wDoc.Protect(Word.WdProtectionType.wdAllowOnlyFormFields, oTrue, oPass)
                    'End If

                Else
                    If Not objWinWordControl.wDoc.ProtectionType = WdProtectionType.wdNoProtection Then ' IF IS PROTECT OPEN IT
                        objWinWordControl.wDoc.Unprotect(oPass)
                    End If
                End If


            End If


        Catch ex As Exception
            Me.lblMessage.Text = "خطا در محافظت از فایل"
            ErrorManager.WriteMessage("Protect()", ex.ToString, Me.Text)
        End Try

    End Sub


#End Region

#Region " Form Event "

    Private Sub OpenDoc_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        Me.lblMessage.Text = String.Empty
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub OpenDoc_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop

        Try
            Me.lblMessage.Text = String.Empty

            'اضافه کردن فایل Drop

            Dim extension As String
            Dim name As String

            Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

            For Each fil As String In files

                extension = System.IO.Path.GetExtension(fil)
                name = System.IO.Path.GetFileName(fil)

                If extension <> String.Empty AndAlso extension = ".txt" OrElse extension = ".dot" OrElse extension = ".docx" OrElse extension = ".doc" Then

                    WinWordControl.WinWordControl.wAppC = Nothing
                    WinWordControl.WinWordControl.wordWnd = 0

                    objWinWordControl.LoadDocument(fil, False)

                    Exit Sub

                End If

            Next

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در باز کردن فایل درگ شده"
            ErrorManager.WriteMessage("OpenDoc_DragDrop()", ex.ToString, Me.Text)
        End Try

    End Sub

    Private Sub OpenDoc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ''Try
        ''    Me.lblMessage.Text = String.Empty

        ''    'sarandy : Close the Document.
        ''    If objWinWordControl.wDoc IsNot Nothing Then

        ''        objWinWordControl.wDoc.Close(False)
        ''        objWinWordControl.wDoc = Nothing



        ''    End If

        ''    'Sarandy: Quit wAppC and release the ApplicationClass.
        ''    If WinWordControl.WinWordControl.wAppC IsNot Nothing Then

        ''        WinWordControl.WinWordControl.wAppC.Quit()
        ''        WinWordControl.WinWordControl.wAppC = Nothing

        ''    End If

        ''    GC.Collect()
        ''    GC.WaitForPendingFinalizers()
        ''    GC.Collect()
        ''    GC.WaitForPendingFinalizers()


        ''Catch ex As Exception
        ''    Me.lblMessage.Text = "خطا در بستن فرم"
        ''    ErrorManager.WriteMessage("OpenDoc_FormClosing()", ex.ToString, Me.Text)
        ''End Try


    End Sub


#End Region

#Region " UnUsed "

    Private Sub picPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' objWinWordControl.wDoc.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView

    End Sub

    Private Sub Email1_UC_EmailSended(ByVal sender As Object, ByVal e As String)

        ' MsgBox("ایمیل ارسال شد")

    End Sub

    'Private Sub btnMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax.Click

    '    '    If Me.WindowState = FormWindowState.Maximized Then
    '    '        Me.Size = New Size(899, 592)
    '    '    Else
    '    '        Me.WindowState = FormWindowState.Maximized
    '    '    End If

    'End Sub

#End Region

    Private Sub objWinWordControl_ShowAddTempDetail() Handles objWinWordControl.ShowAddTempDetail

        Me.lblMessage.Text = String.Empty
        Dim f As New frmTempDocsDetail()
        f.ShowDialog()

    End Sub


End Class