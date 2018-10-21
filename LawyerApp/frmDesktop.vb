Imports Lawyer.Common.VB.News
Imports Lawyer.Common.VB.TimeParties
Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.Timing
Imports Lawyer.Common.VB.Docs
Imports Lawyer.Common.VB
Imports Lawyer.Common.VB.Login
Imports Lawyer.Common.CS.Update
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports Shetab.LicenseControl.Helper
Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.CommonSetting
Imports System.Net

Public Class frmDesktop

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.
        frmShowReminder = New NewShowCurTask()
        frmShowReminder.Show()
        frmShowReminder.Hide()

        'abbas important
        Try

            '  Dim setToday As Threading.Thread
            ''setToday = New Threading.Thread(New Threading.ThreadStart(AddressOf UcShamsiDate1.setToday))
            'setToday.Start()

        Catch ex As Exception

        End Try

        'frmShowUpdate = New InfoDadMessageBox(False, "نسخه جدید نرم افزار قابل دسترس است ، لطفا حهت بروز رسانی نرم افزار اقدام نمایید.", "بروز رسانی")
        'frmShowUpdate.Show()
        'frmShowUpdate.Hide()

    End Sub

#Region "Variable"


    Private IsCollapse As Boolean
    Dim userId As String = String.Empty
    Dim cmbEventRun As Boolean = False
    Dim t As New Timer()
    Dim t1 As New Timer()
    Dim fadeIn As Boolean = True
    Dim fadeOut As Boolean = False
    Private Const C_LicenceID As UInteger = LawyerSetting.LicenceId
    Public frmShowReminder As NewShowCurTask
    Public frmShowUpdate As InfoDadMessageBox
    ' Public frmDoUpdate As frmUpdate

    WithEvents _Timer As New Timer

#End Region

#Region "Base"


    Private Sub frmDesktop_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            ''''''''''''''''''''''''''''''vertical panels''''''''''''''''''
            pnlNews.Visible = False
            pnlOghat.Visible = False




            Me.StartPosition = FormStartPosition.CenterScreen

            'Application.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo("fa-IR"))

            ''********************************curUser**************************
            userId = CurrentLogin.CurrentUser.UserID
            lblCurUser.Text = CurrentLogin.CurrentUser.Name

            'Bind calendar'''''''''''''''''''''''''''''''''''''''
            'faMonthView.ShowToday(DateTime.Now)


            ' load Timing ************************************
            Dim fNowDate As String = Convert.ToInt32(DateManager.GetCurrentShamsiDateInNumericFormat())
            Dim lastDayOfthisMonth As String = Convert.ToInt32(DateManager.GetCurrentShamsiDateInNumericFormat().Substring(0, 6) + "31")
            BindTiming(fNowDate, lastDayOfthisMonth, userId)

            '''''=================News===============

            'LoadNewsCollection()


            'abbas imp
            ' ''If C_LicenceID = 473 Then

            ' ''    thread = New Threading.Thread(New Threading.ThreadStart(AddressOf StartUpdate))

            ' ''    thread.Start()



            ' ''End If


            ' '' ''**********************************blackList*************************
            'abbas imp
            '' ''thBlack = New Threading.Thread(New Threading.ThreadStart(AddressOf CheckBlackList))

            '' ''thBlack.Start()


            ' '' '' '' ''**********************************Tasks*************************

            thTasks = New Threading.Thread(New Threading.ThreadStart(AddressOf showNowTasks))

            thTasks.Start()
            cmbEventRun = True


            '''''''''''''''''''''software version'''''''''''''''''''''''''''''''''''
            SetDBLastVersions()
            SetLastVersions()

            dgrdAction.Location = New Point(0, 170)


            setMainPageContent()



        Catch ex As Exception


        End Try



    End Sub



#End Region

    Private Sub setMainPageContent()
        'check for internet connection ...
        ''http://www.dadco.ir
        pnlNews.Visible = True
        pnlOghat.Visible = False
        Dim appPath As String
        appPath = Application.StartupPath
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")

                    WebBrowser1.Navigate("http://www.dadco.ir")

                    WebBrowser1.Document.BackColor = Color.BlueViolet
                    

                End Using
            End Using
        Catch
           
            WebBrowser1.Navigate(appPath & "/paregoo.html")

        End Try



    End Sub

#Region "Timing"

    Dim listChangeDate As DataTable = Nothing
    Private Sub BindTiming(ByVal fromDate As Int32, ByVal toDate As Int32, ByVal userId As String)

        Dim b As New BindingSource
        dgrdAction.AutoGenerateColumns = False
        listChangeDate = TimePartiesManager.GetDesktopReminders(fromDate, toDate, userId)
        dgrdAction.DataSource = listChangeDate
        fillCalendarDays(listChangeDate)
    End Sub

    Private Sub faMonthView_MonthChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If flag = True Then Return


        'faMonthView.SelectedDateRange.Clear()

        'Dim fNowDate As String = Convert.ToInt32(faMonthView.Year.ToString() + faMonthView.Month.ToString().PadLeft(2, "0"c) + "01")
        'If fNowDate.StartsWith("20") Then Return
        'Dim lastDayOfthisMonth As String = Convert.ToInt32(faMonthView.Year.ToString() + faMonthView.Month.ToString().PadLeft(2, "0"c) + "31")
        'BindTiming(fNowDate, lastDayOfthisMonth, userId)

    End Sub

    Dim flag As Boolean = False
    Private Sub fillCalendarDays(ByVal dt As DataTable)
        If dt Is Nothing Or dt.Rows.Count = 0 Then Return

        'Dim items(dt.Rows.Count - 1) As Date
        'flag = True
        'For i As Integer = 0 To dt.Rows.Count - 1
        '    Dim intFarsiDate As Integer = dt.Rows(i)("actualDate")
        '    Dim persianToEnglishDate As New FarsiLibrary.Utils.PersianDate(String.Format("{0:000/00/00}", intFarsiDate))
        '    Dim englishDate As Date = Convert.ToDateTime(persianToEnglishDate)

        '    items(i) = englishDate.Date

        'Next
        'faMonthView.SelectedDateRange.AddRange(items)

        ''faMonthView.SelectedDateRange.AddRange(New DateTime() {"2/13/2014", "2/14/2014", "2/15/2014"})

        'flag = False


    End Sub

#End Region

#Region "News"

    Private newsList As New NewsCollection

    Private Delegate Sub loadRSS(ByVal text As String)

    Dim thNews As Threading.Thread

    Private Sub LoadNewsCollection()

        Try
            If newsList.Count = 0 Then

                thNews = New Threading.Thread(New Threading.ThreadStart(AddressOf LoadNews))
                thNews.Start()


            End If
        Catch ex As Exception

        End Try


    End Sub


    Private Sub LoadNews()

        Try

            Dim RSSXml As New Xml.XmlDocument()
            RSSXml.Load("http://www.dadco.ir/nwdicrss.aspx")
            System.Threading.Thread.Sleep(4000)
            Dim RSSNodeList As Xml.XmlNodeList = RSSXml.SelectNodes("rss/channel/item")


            Dim sb As New StringBuilder
            Dim title As String = String.Empty
            Dim link As String = String.Empty
            Dim desc As String = String.Empty
            Dim pupdate As String = String.Empty

            'newsList.Clear()
            Dim htmlBody As String = " <html> <head><script language='javascript' type='text/javascript'> function showDetail(newsid) { if (document.getElementById(newsid).style.display == 'none') document.getElementById(newsid).style.display = 'block'; else document.getElementById(newsid).style.display = 'none';  } </script> </head> <body bgcolor='#180053'>   "
            Dim divId As Int32 = 0
            For Each RSSNode As Xml.XmlNode In RSSNodeList

                title = String.Empty
                link = String.Empty
                desc = String.Empty
                pupdate = String.Empty


                Dim RSSSubNode As Xml.XmlNode
                RSSSubNode = RSSNode.SelectSingleNode("title")

                If RSSSubNode IsNot Nothing Then title = RSSSubNode.InnerText

                RSSSubNode = RSSNode.SelectSingleNode("link")

                If RSSSubNode IsNot Nothing Then link = RSSSubNode.InnerText

                RSSSubNode = RSSNode.SelectSingleNode("description")

                If RSSSubNode IsNot Nothing Then desc = RSSSubNode.InnerText

                RSSSubNode = RSSNode.SelectSingleNode("pubDate")

                If RSSSubNode IsNot Nothing Then pupdate = RSSSubNode.InnerText

                htmlBody += "<div dir='rtl'   > <table> <tr>     <td style='vertical-align: middle;'> "
                htmlBody += " <a href='#' onclick='showDetail(" + divId.ToString() + ");'> "
                htmlBody += " <div id='newsTitle_" + divId.ToString() + "' style=' font-family: Tahoma; font-size: x-small;color: #FFFFFF; direction:rtl; text-decoration:none'> "
                htmlBody += title + "</div>       </a> </td>"
                htmlBody += " <td style='direction:ltr; vertical-align: middle; color:#99CC00; font-family: Tahoma; font-size: x-small; '> "
                htmlBody += " (" + pupdate + ")  </td>  </tr> </table> </div>"
                htmlBody += " <div  id='" + divId.ToString() + "' style='display:none; direction:rtl;float:auto;color: #FFCC00; font-family: Tahoma; font-size: x-small;'> "
                htmlBody += desc + "      </div> </br>"

                'newsList.Add(New news(title, desc, pupdate, link))
                divId += 1

            Next

            htmlBody += "  </body> </html>"

            WebBrowser1.DocumentText = htmlBody


        Catch ex As Exception



        End Try


    End Sub


    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WebBrowser1.Document.Body.Style &= ";scrollbar-base-color: orange"

    End Sub

#End Region

#Region "softversion"
    Private Sub SetLastVersions()

        Try

            Dim lastVersion As String = String.Empty

            Try

                txtCVersion.Text = "نسخه نرم افزار : " & Lawyer.Common.Default.DefaultValue.DefaultSoftV

            Catch ex As Exception

                txtCVersion.Text = "نسخه نرم افزار  : " + "------"

            End Try

            SetDBLastVersions()
        Catch ex As Exception
            ErrorManager.WriteMessage("SetLastVersions", ex.ToString(), Me.Text)

        End Try


    End Sub

    Private Sub SetDBLastVersions()
        Dim dbVersion As String = String.Empty
        Try

            Lawyer.Common.CS.Update.UpdateManager.SetConnection(CommonSettingManager.ConnectionString)

            dbVersion = InitialDownload.GetDBLastVersion()

            If dbVersion = String.Empty Then

                txtdbVersion.Text = "نسخه پایگاه داده : " + Lawyer.Common.Default.DefaultValue.DefaultDatabaseV

                dbVersion = Lawyer.Common.Default.DefaultValue.DefaultDatabaseV

            Else
                txtdbVersion.Text = "نسخه پایگاه داده : " + dbVersion

            End If

        Catch ex As Exception

            txtdbVersion.Text = "نسخه پایگاه داده  : " + "------"

            dbVersion = String.Empty

            ErrorManager.WriteMessage("SetDBLastVersions", ex.ToString(), Me.Text)

        End Try

    End Sub
#End Region

#Region "BlackList"

    'Dim thBlack As Threading.Thread


    'Private Sub CheckBlackList()

    '    Try

    '        Dim sI As New NetClass.SrvDadco.SerialInfo()

    '        Dim shetab As New Shetab.LicenseControl.Helper.SoftLock(C_LicenceID)

    '        Try
    '            Dim objIPHE As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry("www.google.com")

    '            If readSystemCode() = True Then
    '                writeSystemCode()
    '            End If
    '        Catch ex As Exception
    '            ''if has unregistration code in windows
    '            If readSystemCode() = True Then
    '                writeSystemCode()
    '            End If
    '            Threading.Thread.Sleep(1600000)

    '            CheckBlackList()

    '            Exit Sub

    '        End Try

    '        If sI.checkSerialInBlackListNew(shetab.GetRegistrationInfo.SerialNumber, shetab.GetRegistrationInfo.ComputerId, shetab.GetRegistrationInfo.ActivationCode & "@" & shetab.GetRegistrationInfo.FullName) Then

    '            ' shetab.UnRegister()
    '            writeSystemCode()

    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub writeSystemCode()

    '    Dim softLock As New SoftLock(C_LicenceID)
    '    Try
    '        softLock.UnRegister()
    '    Catch ex As Exception

    '    End Try
    '    Try

    '        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
    '        Dim objWriter As New System.IO.StreamWriter(path + "\dtczz.dll", False)
    '        Dim rs As String = StrReverse(softLock.SerialNumber)
    '        objWriter.WriteLine(rs)
    '        objWriter.Close()
    '    Catch ex As Exception

    '    End Try

    'End Sub
    'Private Function readSystemCode() As Boolean
    '    Try
    '        Dim softLock As New SoftLock(C_LicenceID)
    '        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
    '        Dim file As New FileInfo(path + "\dtczz.dll")
    '        If Not file.Exists Then Return False

    '        Dim objReader As New System.IO.StreamReader(path + "\dtczz.dll")
    '        Dim rs As String = objReader.ReadLine().Trim()
    '        Dim sr As String = StrReverse(rs)
    '        If softLock.SerialNumber = sr Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '        objReader.Close()
    '    Catch ex As Exception
    '        Return False
    '    End Try

    'End Function

#End Region

#Region "Task"

    Dim thTasks As Threading.Thread

    Private Sub showNowTasks()
        Try
            While True

                If frmShowReminder.IsHasContent() Then

                    'frmShowReminder.WindowState = FormWindowState.Normal
                    frmShowReminder.Show()
                    frmShowReminder.Activate()
                    'frmShowReminder.BringToFront()

                End If

                Threading.Thread.Sleep(120000)


            End While
        Catch ex As Exception

        End Try


    End Sub

#End Region
    'abbas new
#Region "Menu"

    Private Sub frmDesktop_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim msg As MsgBoxResult = MsgBox("آیا می خواهید خارج شوید", MsgBoxStyle.YesNo)
        If msg = MsgBoxResult.No Then
            e.Cancel = True

        End If
    End Sub

    Private Sub doBackup()
        If Not CurrentLogin.CurrentUser.IsAdmin Then
            Dim i As New InfoDadMessageBox(True, "فقط کاربر مدیر مجوز دسترسی دارد", "پشتیبانگیری")
            i.ShowDialog()
            Exit Sub
        End If

        Dim currentConfig As Lawyer.Common.CS.ConfigFile.Config

        Try
            currentConfig = Lawyer.Common.CS.ConfigFile.Config.Load(FileManager.GetLoginConfigPath())

            If currentConfig Is Nothing Then

                currentConfig = Lawyer.Common.CS.ConfigFile.Config.CreateDefultXml(FileManager.GetLoginConfigPath())

            End If

        Catch ex As Exception

            currentConfig = Nothing

        End Try


        Dim f As New frmRestoreBackup(currentConfig, False, False)

        f.ShowDialog()

    End Sub

    Private Sub tsMenuClick(ByVal tsName As String)


        Dim f As Form

        Select Case tsName

            Case "picLibrary"
                f = New BookSearch()
            Case "picContact"
                f = New ContactSearch()
            Case "picDocs"
                f = New BraowsDocs()
            Case "picFiles"
                f = New BrowseFiles()

            Case "picMail"
                f = New frmEmail()
            Case "picDiye"
                f = New BloodMoney()
            Case "picKhesarat"
                f = New Credit()
            Case "picMohasebe"
                f = New Tarefe()

            Case "picHagV"
                f = New LawyerSFees()
            Case "picJorm"
                f = New GuiltSearch()
            Case "picCourt"
                f = New Address()
            Case "picClericalSpending"
                f = New frmOfficeFinanceAdd()
            Case "picConsulting"
                f = New frmMoshavere()
            Case "picAction"
                f = New frmNewTimingSearch()
            Case "picFinance"
                f = New frmNewFinanceSearch()
            Case "tsShaxes"
                f = New frmShexes()
            Case "picTemplateLetter"
                f = New frmTempDocsDetail()
            Case "picSmsConfig"
                f = New frmSmsConfig()

            Case "picAbout"
                f = New SupportForm()


        End Select

        f.Show()


    End Sub

    Private Sub tsContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsContact.Click
        tsMenuClick("picContact")
    End Sub

    Private Sub tsConsulting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsConsulting.Click
        tsMenuClick("picConsulting")
    End Sub

    Private Sub tsTemplateDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTemplateDoc.Click
        tsMenuClick("picDocs")
    End Sub

    Private Sub tsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFile.Click
        tsMenuClick("picFiles")
    End Sub

    Private Sub tsAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAction.Click
        tsMenuClick("picAction")
    End Sub

    Private Sub tsLaw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        tsMenuClick("picLaw")
    End Sub

    Private Sub tsFinance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFinance.Click
        tsMenuClick("picFinance")
    End Sub

    Private Sub tsBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsBackup.Click
        doBackup()
    End Sub

    Private Sub tsOfficeFinance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsOfficeFinance.Click
        tsMenuClick("picClericalSpending")
    End Sub

    Private Sub tsLibrary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLibrary.Click
        tsMenuClick("picLibrary")
    End Sub

    Private Sub tsMojremaneh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMojremaneh.Click
        tsMenuClick("picJorm")
    End Sub

    Private Sub tsHaghvekaleh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsHaghvekaleh.Click
        tsMenuClick("picHagV")
    End Sub

    Private Sub tsDadrasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDadrasi.Click
        'tsMenuClick("picMohasebe")
        System.Diagnostics.Process.Start("tarefe.pdf")
    End Sub

    Private Sub tsDieh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDieh.Click
        tsMenuClick("picDiye")
    End Sub

    Private Sub tsTadieh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTadieh.Click
        tsMenuClick("picKhesarat")
    End Sub

    Private Sub tsMehrieh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMehrieh.Click
        tsMenuClick("picKhesarat")
    End Sub

    Private Sub tsMarakez_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMarakez.Click
        tsMenuClick("picCourt")
    End Sub

    Private Sub tsShaxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsShaxes.Click
        tsMenuClick("tsShaxes")
    End Sub

    Private Sub tsEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEmail.Click
        tsMenuClick("picMail")
    End Sub

    Private Sub tsAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAbout.Click
        tsMenuClick("picAbout")
    End Sub

    Private Sub tsTemplateLetter_Click(sender As Object, e As EventArgs) Handles tsTemplateLetter.Click
        tsMenuClick("picTemplateLetter")
    End Sub

    Private Sub tsMenuSmsConfig_Click(sender As Object, e As EventArgs) Handles tsMenuSmsConfig.Click
        tsMenuClick("picSmsConfig")
    End Sub
#End Region

#Region "vertical_Menu"


    Private Sub ToolStripBtnNews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBtnNews.Click
        If pnlNews.Visible Then
            pnlNews.Visible = False
        Else
            pnlNews.Visible = True
            pnlOghat.Visible = False
            If WebBrowser1.Document.Body.InnerText = Nothing Then
                'LoadNewsCollection()
            End If
        End If
    End Sub

    Private Sub ToolStripBtnOghat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBtnOghat.Click
        If pnlOghat.Visible Then
            pnlOghat.Visible = False
        Else
            pnlNews.Visible = False
            pnlOghat.Visible = True
        End If


    End Sub
#End Region


    Private Sub tsFilmAshkhas_Click(sender As Object, e As EventArgs) Handles tsFilmAshkhas.Click
        Try
            System.Diagnostics.Process.Start("Help\Ashkhas.wmv")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tsFilmAsnadTip_Click(sender As Object, e As EventArgs) Handles tsFilmAsnadTip.Click
        Try
            System.Diagnostics.Process.Start("Help\AsnadTip.wmv")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsFilmEghdamat_Click(sender As Object, e As EventArgs) Handles tsFilmEghdamat.Click
        Try
            System.Diagnostics.Process.Start("Help\Egdamat.wmv")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsFilmHazine_Click(sender As Object, e As EventArgs) Handles tsFilmHazine.Click
        Try
            System.Diagnostics.Process.Start("Help\Hazine.wmv")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsFilmParvandeh_Click(sender As Object, e As EventArgs) Handles tsFilmParvandeh.Click
        Try
            System.Diagnostics.Process.Start("Help\Parvandeh.wmv")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsFilmPoshtivangiri_Click(sender As Object, e As EventArgs) Handles tsFilmPoshtivangiri.Click
        Try
            System.Diagnostics.Process.Start("Help\Poshtibangiri.wmv")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsAboutParegoo_Click(sender As Object, e As EventArgs) Handles tsAboutParegoo.Click
        Dim frm As New SupportForm
        frm.ShowDialog()
    End Sub

    Private Sub faMonthView_Load(sender As Object, e As EventArgs) Handles faMonthView.Load
        faMonthView.SetTodayDate(DateTime.Now)

    End Sub


    Private Sub faMonthView_SelectedDateChanged(selectedDateTime As Date, selectedPersianDateTime As BehComponents.PersianDateTime) Handles faMonthView.SelectedDateChanged
        If flag = True Then Return


        Dim fNowDate As String = Convert.ToInt32(faMonthView.GetSelectedDateInDateTime.Year.ToString() + faMonthView.GetSelectedDateInDateTime.Month.ToString().PadLeft(2, "0"c) + "01")
        If fNowDate.StartsWith("20") Then Return
        Dim lastDayOfthisMonth As String = Convert.ToInt32(faMonthView.GetSelectedDateInDateTime.Year.ToString() + faMonthView.GetSelectedDateInDateTime.Month.ToString().PadLeft(2, "0"c) + "31")
        BindTiming(fNowDate, lastDayOfthisMonth, userId)
    End Sub
End Class
