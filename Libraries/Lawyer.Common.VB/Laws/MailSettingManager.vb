Imports Lawyer.Common.VB.Common

Namespace Laws
    Public Class MailSettingManager

        Public Shared Function GetActiveMail() As String

            Dim XMLReader As Xml.XmlReader = Nothing
            Try
                Dim strMailSetting As String = String.Empty
                Dim server As String = String.Empty
                Dim port As String = String.Empty
                Dim pass As String = String.Empty
                Dim mail As String = String.Empty
                Dim active As Boolean = False


                Try
                    Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(FileManager.GetMailCofigPath)
                    If fileInfo.IsReadOnly Then fileInfo.IsReadOnly = False
                Catch ex As Exception

                End Try

                XMLReader = New Xml.XmlTextReader(FileManager.GetMailCofigPath)

                While XMLReader.Read

                    Select Case XMLReader.NodeType

                        Case Xml.XmlNodeType.Element

                            If XMLReader.AttributeCount = 5 Then

                                While XMLReader.MoveToNextAttribute

                                    Select Case XMLReader.Name

                                        Case "Active"

                                            If XMLReader.Value.ToLower <> "true" Then

                                                active = False

                                                Exit While

                                            End If

                                            active = True

                                        Case "Server"

                                            server = XMLReader.Value


                                        Case "Address"

                                            mail = XMLReader.Value

                                        Case "Port"

                                            port = XMLReader.Value

                                        Case "Pass"
                                            pass = XMLReader.Value

                                    End Select


                                End While


                                If active Then
                                    XMLReader.Close()
                                    Return String.Format("{0}:{1}:{2}:{3}", server, port, pass, mail)

                                End If

                            End If

                    End Select

                End While

                XMLReader.Close()
            Catch ex As Exception

                If XMLReader IsNot Nothing Then

                    XMLReader.Close()

                End If

            End Try
            

            Return String.Empty

        End Function

        Public Shared Function GetEmailSetting() As Setting.SettingCollection

            Return Setting.SettingManager.GetSettingsByName("EmailSetting")

        End Function


    End Class


End Namespace

