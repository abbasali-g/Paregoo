Imports System.Windows.Forms
Imports System.IO
Imports Lawyer.Common.VB.Common

Namespace Laws

    Public Class Fax


#Region "Property"



        Private _FaxNumber As String
        Private _RecipientName As String
        Private _DisplayName As String
        Private _Text As String
        Private _FileName As String

        Public Property DisplayName() As String
            Get
                Return _DisplayName
            End Get
            Set(ByVal value As String)
                _DisplayName = value
            End Set
        End Property

        Public Property FaxNumber() As String
            Get
                Return _FaxNumber
            End Get
            Set(ByVal value As String)
                _FaxNumber = value
            End Set
        End Property

        Public Property Text() As String
            Get
                Return _Text
            End Get
            Set(ByVal value As String)
                _Text = value
                '_FileName = String.Empty
            End Set
        End Property

        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal value As String)
                _FileName = value
                ' _Text = String.Empty
            End Set
        End Property

        Public Property RecipientName() As String
            Get
                Return _RecipientName
            End Get
            Set(ByVal value As String)
                _RecipientName = value
            End Set
        End Property

        Private _HasError As Boolean = False
        Public Property HasError() As Boolean
            Get
                Return _HasError
            End Get
            Set(ByVal value As Boolean)
                _HasError = value
            End Set
        End Property


        Private _Exception As Exception = Nothing
        Public ReadOnly Property Exception() As Exception
            Get
                Return _Exception
            End Get

        End Property


        Sub Clear()
            _HasError = False
            _Exception = Nothing
        End Sub


        Private _Message As String
        Public Property Message() As String
            Get
                Return _Message
            End Get
            Set(ByVal value As String)
                _Message = value
            End Set

        End Property




#End Region

#Region "Manager"

        'Public Sub SendFax(ByVal Fax As Fax)

        '    Clear()

        '    Try

        '        If Not String.IsNullOrEmpty(Fax.FaxNumber) Then


        '            Dim FaxServer As New FAXCOMLib.FaxServer
        '            FaxServer.Connect(Environment.MachineName)



        '            Dim BaseFile As String

        '            If Not String.IsNullOrEmpty(Fax.FileName) Then ' Can be pdf-bmp-jpg-tif

        '                BaseFile = Fax.FileName

        '            ElseIf Not String.IsNullOrEmpty(Fax.Text) Then '------------------------- Text File


        '                Dim _TextFile As String = FileManager.GetFaxFilePath ' Application.StartupPath + "\Fax.txt"

        '                ' Create a Text File
        '                Dim fs As FileStream = Nothing
        '                If (Not File.Exists(_TextFile)) Then
        '                    fs = File.Create(_TextFile)
        '                    Using fs
        '                    End Using
        '                End If

        '                ' Write to a Text File
        '                If File.Exists(_TextFile) Then
        '                    Using sw As StreamWriter = New StreamWriter(_TextFile)
        '                        sw.Write(Fax.Text)
        '                    End Using
        '                End If

        '                BaseFile = _TextFile

        '            Else

        '                Exit Sub

        '            End If


        '            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        '            Dim FaxDoc As FAXCOMLib.FaxDoc = CType(FaxServer.CreateDocument(BaseFile), FAXCOMLib.FaxDoc)






        '            If Not String.IsNullOrEmpty(Fax.FileName) AndAlso Not String.IsNullOrEmpty(Fax.Text) Then 'Text as Cover

        '                ' FaxDoc.CoverpageName = Fax.Text
        '                'FaxDoc.SendCoverpage = True

        '            End If

        '            FaxDoc.DisplayName = Fax.DisplayName
        '            FaxDoc.FaxNumber = Fax.FaxNumber

        '            'FaxDoc.RecipientName = Fax.RecipientName


        '            'FaxDoc.EmailAddress = "amit.patel@mokshadigital.com"
        '            ' FaxDoc.FileName = "c:\photoshop-button.pdf"
        '            'FaxDoc.SenderFax = "123123123123"
        '            'FaxDoc.DiscountSend = 0

        '            '  FaxDoc.CoverpageName = "c:\1.txt"
        '            'FaxDoc.CoverpageNote = ""
        '            ' FaxDoc.SendCoverpage = True
        '            'FaxDoc.CoverpageNot()

        '            '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


        '            Dim response As Integer = FaxDoc.Send



        '            FaxServer.Disconnect()

        '            ' lblMessage.Text = response.ToString()

        '            FaxDoc = Nothing
        '            FaxServer = Nothing

        '            '-----------------------
        '            'Sarandy Kill AcroRd32
        '            'Dim myProcesses() As Process
        '            'Dim myProcess As Process
        '            'myProcesses = Process.GetProcessesByName("AcroRd32")
        '            'For Each myProcess In myProcesses
        '            '    Try
        '            '        If Date.Now.Ticks - myProcess.StartTime.Ticks > TimeSpan.FromSeconds(30).Ticks Then
        '            '            myProcess.Kill()
        '            '        End If
        '            '    Catch ex As Exception
        '            '        ' Probably access denied
        '            '    End Try
        '            'Next

        '            '---------------------------
        '        Else
        '            _HasError = True
        '            _Exception = New Exception("شماره فاکس وارد نشده است")
        '        End If


        '    Catch ex As Exception
        '        _HasError = True

        '        While ex.InnerException IsNot Nothing
        '            ex = ex.InnerException
        '        End While
        '        _Exception = ex

        '    End Try


        'End Sub

#End Region



    End Class

End Namespace
