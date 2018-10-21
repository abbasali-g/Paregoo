Imports System.Net.Mail
Imports System.Net.Mime

Namespace Laws

    Public Class Email


#Region " Property "


        Private _SmtpClient As String
        Private _Port As String
        Private _NetworkCredential_Mail As String
        Private _NetworkCredential_Pass As String
        Private _EnableSsl As Boolean = False

        Private _From_Email As String 'for replay to mail
        Private _DisplayName As String

        Private _To_Email As String
        Private _Subject As String
        Private _Body As String

        Private _AttachmentFilePath As String


        Public Property SmtpClient() As String
            Get
                Return _SmtpClient
            End Get
            Set(ByVal value As String)
                _SmtpClient = value
            End Set
        End Property

        Public Property Port() As Integer
            Get
                Return _Port
            End Get
            Set(ByVal value As Integer)
                _Port = value
            End Set
        End Property


        Public Property NetworkCredential_Mail() As String
            Get
                Return _NetworkCredential_Mail
            End Get
            Set(ByVal value As String)
                _NetworkCredential_Mail = value
            End Set
        End Property

        Public Property NetworkCredential_Pass() As String
            Get
                Return _NetworkCredential_Pass
            End Get
            Set(ByVal value As String)
                _NetworkCredential_Pass = value
            End Set
        End Property

        Public Property EnableSsl() As Boolean
            Get
                Return _EnableSsl
            End Get
            Set(ByVal value As Boolean)
                _EnableSsl = value
            End Set
        End Property

        Public Property From_Email() As String
            Get
                Return _From_Email
            End Get
            Set(ByVal value As String)
                _From_Email = value
            End Set
        End Property

        Public Property DisplayName() As String
            Get
                Return _DisplayName
            End Get
            Set(ByVal value As String)
                _DisplayName = value
            End Set
        End Property

        Public Property To_Email() As String
            Get
                Return _To_Email
            End Get
            Set(ByVal value As String)
                _To_Email = value
            End Set
        End Property

        Public Property Subject() As String
            Get
                Return _Subject
            End Get
            Set(ByVal value As String)
                _Subject = value
            End Set
        End Property

        Public Property Body() As String
            Get
                Return _Body
            End Get
            Set(ByVal value As String)
                _Body = value
            End Set
        End Property


        Public Property AttachmentFilePath() As String
            Get
                Return _AttachmentFilePath
            End Get
            Set(ByVal value As String)
                _AttachmentFilePath = value
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



#End Region

#Region "Event"

        Public Event EmailSended(ByVal sender As Object, ByVal e As String)

#End Region



#Region "Manager"


        Public Sub SendEmail(ByVal Email As Email)

            Clear()

            Try

                Dim client As New SmtpClient(Email.SmtpClient)
                If Not String.IsNullOrEmpty(_Port) Then
                    client.Port = _Port
                End If

                client.UseDefaultCredentials = False
                client.Credentials = New System.Net.NetworkCredential(Email.NetworkCredential_Mail, Email.NetworkCredential_Pass)

                client.EnableSsl = Email.EnableSsl ' true in gmail and yahoo
                'client.Timeout = 20000 'defullt is 100000(100 second)

                '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                Dim msg As New MailMessage


                msg.From = New MailAddress(Email.From_Email, Email.DisplayName)
                msg.ReplyTo = New MailAddress(Email.From_Email, Email.DisplayName)

                msg.To.Clear()
                msg.To.Add(Email.To_Email) ' separat with camma .msg.To.Add(New MailAddress(Email.To_Email))
                msg.Subject = Email.Subject
                msg.SubjectEncoding = System.Text.Encoding.UTF8
                msg.Body = Email.Body
                msg.BodyEncoding = System.Text.Encoding.UTF8

                msg.Priority = MailPriority.High

                'msg.IsBodyHtml = True
                'msg.Body = "<div style=\"font-family:Arial\">This is an INLINE attachment

                ' >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


                '-----------------------  Attachment
                If Not String.IsNullOrEmpty(_AttachmentFilePath) Then

                    Dim Af As New Attachment(_AttachmentFilePath)
                    ' Dim Att As New Attachment(_AttachmentFilePath, MediaTypeNames.Application.Octet)

                    Dim _FileDate As ContentDisposition = Af.ContentDisposition

                    _FileDate.CreationDate = System.IO.File.GetCreationTime(_AttachmentFilePath)
                    _FileDate.ModificationDate = System.IO.File.GetLastWriteTime(_AttachmentFilePath)
                    _FileDate.ReadDate = System.IO.File.GetLastAccessTime(_AttachmentFilePath)

                    msg.Attachments.Add(Af)


                End If
                '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>



                client.Send(msg)
                RaiseEvent EmailSended(Me, "ok")

            Catch ex As Exception
                _HasError = True

                While ex.InnerException IsNot Nothing
                    ex = ex.InnerException
                End While
                _Exception = ex

            End Try


        End Sub



#End Region


    End Class


End Namespace