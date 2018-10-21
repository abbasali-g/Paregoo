Imports Lawyer.Common.VB.Common
Imports Lawyer.Common.VB.LawyerError
Imports System.Windows.Forms


Public Class MailSetting

    '' ''#Region "Events"

    '' ''    Private Sub MailSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '' ''        ToolTip1.SetToolTip(btnRefresh, "Refresh")
    '' ''        lblMessage.Text = String.Empty

    '' ''        If Not IO.File.Exists(FileManager.GetMailCofigPath) Then

    '' ''            WriteDefault()

    '' ''        End If

    '' ''        Read_XML()

    '' ''    End Sub

    '' ''    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

    '' ''        If e.Value <> Nothing And e.ColumnIndex = 4 Then

    '' ''            With DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)

    '' ''                .Value = New String("*", TryCast(.Tag, String).Length)

    '' ''            End With

    '' ''        End If

    '' ''    End Sub

    '' ''    Private Sub DataGridView1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated

    '' ''        If e.ColumnIndex = 4 Then

    '' ''            Dim PasswordBox As TextBox = CType(DataGridView1.EditingControl, TextBox)

    '' ''            If PasswordBox IsNot Nothing Then

    '' ''                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = PasswordBox.Text()

    '' ''                PasswordBox.PasswordChar = Nothing

    '' ''            End If

    '' ''        End If

    '' ''    End Sub

    '' ''    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing

    '' ''        If CType(sender, DataGridView).CurrentCell.ColumnIndex = 4 Then

    '' ''            CType(DataGridView1.EditingControl, TextBox).PasswordChar = "*"

    '' ''        End If

    '' ''    End Sub


    '' ''    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '' ''        lblMessage.Text = String.Empty
    '' ''        Try

    '' ''            Dim XMLobj As Xml.XmlTextWriter
    '' ''            Dim enc As New System.[Text].UnicodeEncoding()

    '' ''            Try
    '' ''                Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(FileManager.GetMailCofigPath)
    '' ''                If fileInfo.IsReadOnly Then fileInfo.IsReadOnly = False
    '' ''            Catch ex As Exception

    '' ''            End Try

    '' ''            XMLobj = New Xml.XmlTextWriter(FileManager.GetMailCofigPath, enc)
    '' ''            XMLobj.Formatting = Xml.Formatting.Indented
    '' ''            XMLobj.Indentation = 5
    '' ''            XMLobj.WriteStartDocument()
    '' ''            XMLobj.WriteStartElement("MailSetting")


    '' ''            Dim count As Integer = 1


    '' ''            For Each Item As DataGridViewRow In DataGridView1.Rows

    '' ''                If Item.Index <> DataGridView1.Rows.Count - 1 Then

    '' ''                    Try

    '' ''                        If Not (Item.Cells("clmAddress").Value = String.Empty AndAlso Item.Cells("clmPort").Value = String.Empty AndAlso Item.Cells("cmlPass").Tag = String.Empty AndAlso Item.Cells("clmServer").Value = String.Empty) Then
    '' ''                            XMLobj.WriteStartElement("Mail" & count)
    '' ''                            XMLobj.WriteAttributeString("Address", Item.Cells("clmAddress").Value)
    '' ''                            XMLobj.WriteAttributeString("Port", Item.Cells("clmPort").Value)
    '' ''                            XMLobj.WriteAttributeString("Pass", Lawyer.Coding.HsPublic.EncryptText(Item.Cells("cmlPass").Tag))
    '' ''                            XMLobj.WriteAttributeString("Server", Item.Cells("clmServer").Value)
    '' ''                            Dim str As String = Item.Cells("clmActive").Value

    '' ''                            If str = Nothing Then
    '' ''                                XMLobj.WriteAttributeString("Active", "False")

    '' ''                            Else
    '' ''                                XMLobj.WriteAttributeString("Active", str)

    '' ''                            End If
    '' ''                            XMLobj.WriteEndElement()
    '' ''                            count += 1

    '' ''                        End If

    '' ''                    Catch ex As Exception
    '' ''                        count += 1
    '' ''                    End Try


    '' ''                End If

    '' ''            Next

    '' ''            XMLobj.WriteEndElement()
    '' ''            XMLobj.Close()

    '' ''            lblMessage.Text = "فایل ذخیره شد."

    '' ''        Catch ex As Exception

    '' ''            lblMessage.Text = "خطا در ذخیره فایل"

    '' ''            If IO.File.Exists(FileManager.GetMailCofigPath) Then

    '' ''                IO.File.Delete(FileManager.GetMailCofigPath)

    '' ''            End If

    '' ''            ErrorManager.WriteMessage("btnSave_Click", ex.ToString(), Me.Text)

    '' ''        End Try

    '' ''        Try
    '' ''            If Not IO.File.Exists(FileManager.GetMailCofigPath) Then

    '' ''                WriteDefault()

    '' ''            End If

    '' ''            Read_XML()

    '' ''        Catch ex As Exception

    '' ''            ErrorManager.WriteMessage("btnSave_Click", ex.ToString(), Me.Text)
    '' ''        End Try

    '' ''    End Sub

    '' ''    Private Sub tooltipDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooltipDel.Click
    '' ''        lblMessage.Text = String.Empty
    '' ''        Try

    '' ''            If rowIndex <> -1 Then

    '' ''                DataGridView1.Rows.RemoveAt(rowIndex)

    '' ''            End If

    '' ''        Catch ex As Exception

    '' ''        End Try

    '' ''    End Sub

    '' ''    Private Sub DataGridView1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseUp
    '' ''        lblMessage.Text = String.Empty
    '' ''        Try

    '' ''            If e.Button = Windows.Forms.MouseButtons.Right Then

    '' ''                Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)

    '' ''                If hti.Type = DataGridViewHitTestType.Cell Then

    '' ''                    rowIndex = hti.RowIndex

    '' ''                End If

    '' ''            End If

    '' ''        Catch ex As Exception

    '' ''            rowIndex = -1

    '' ''        End Try

    '' ''    End Sub

    '' ''    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
    '' ''        lblMessage.Text = String.Empty
    '' ''        If e.ColumnIndex = 0 Then

    '' ''            If DataGridView1.Rows(e.RowIndex).Cells("clmActive").Value = "True" Then

    '' ''                IsActiveIndex = -1

    '' ''            Else

    '' ''                If IsActiveIndex <> -1 Then
    '' ''                    DataGridView1.Rows(IsActiveIndex).Cells("clmActive").Value = "False"
    '' ''                End If
    '' ''                IsActiveIndex = e.RowIndex
    '' ''                DataGridView1.Rows(IsActiveIndex).Cells("clmActive").Value = "True"

    '' ''            End If
    '' ''        End If
    '' ''    End Sub

    '' ''    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

    '' ''        lblMessage.Text = String.Empty

    '' ''        If Not IO.File.Exists(FileManager.GetMailCofigPath) Then

    '' ''            WriteDefault()

    '' ''        End If

    '' ''        Read_XML()

    '' ''    End Sub

    '' ''#End Region

    '' ''#Region "Utility"

    '' ''    Private rowIndex As Integer = -1

    '' ''    Private IsActiveIndex As Integer = -1

    '' ''    Private Sub WriteDefault()

    '' ''        lblMessage.Text = String.Empty

    '' ''        Try

    '' ''            Dim XMLobj As Xml.XmlTextWriter
    '' ''            Dim enc As New System.[Text].UnicodeEncoding()

    '' ''            Try
    '' ''                Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(FileManager.GetMailCofigPath)
    '' ''                If fileInfo.IsReadOnly Then fileInfo.IsReadOnly = False
    '' ''            Catch ex As Exception

    '' ''            End Try


    '' ''            XMLobj = New Xml.XmlTextWriter(FileManager.GetMailCofigPath, enc)
    '' ''            XMLobj.Formatting = Xml.Formatting.Indented
    '' ''            XMLobj.Indentation = 5
    '' ''            XMLobj.WriteStartDocument()
    '' ''            XMLobj.WriteStartElement("MailSetting")

    '' ''            XMLobj.WriteStartElement("Mail1")
    '' ''            XMLobj.WriteAttributeString("Server", "smtp.gmail.com")
    '' ''            XMLobj.WriteAttributeString("Port", "587")
    '' ''            XMLobj.WriteAttributeString("Pass", "/6Psau1GIQE=") 'String.Empty
    '' ''            XMLobj.WriteAttributeString("Address", "")
    '' ''            XMLobj.WriteAttributeString("Active", "False")
    '' ''            XMLobj.WriteEndElement()
    '' ''            XMLobj.WriteEndElement()
    '' ''            XMLobj.Close()
    '' ''        Catch ex As Exception
    '' ''            ErrorManager.WriteMessage("WriteDefault", ex.ToString(), Me.Text)
    '' ''        End Try

    '' ''    End Sub

    '' ''    Private Sub Read_XML()

    '' ''        DataGridView1.Rows.Clear()

    '' ''        IsActiveIndex = -1
    '' ''        Dim XMLReader As Xml.XmlReader = Nothing

    '' ''        Try



    '' ''            XMLReader = New Xml.XmlTextReader(FileManager.GetMailCofigPath)

    '' ''            While XMLReader.Read

    '' ''                Select Case XMLReader.NodeType

    '' ''                    Case Xml.XmlNodeType.Element

    '' ''                        If XMLReader.AttributeCount = 5 Then

    '' ''                            Dim dr As Integer = DataGridView1.Rows.Add()

    '' ''                            While XMLReader.MoveToNextAttribute

    '' ''                                Select Case XMLReader.Name

    '' ''                                    Case "Address"

    '' ''                                        DataGridView1.Rows(dr).Cells("clmAddress").Value = XMLReader.Value

    '' ''                                    Case "Port"

    '' ''                                        DataGridView1.Rows(dr).Cells("clmPort").Value = XMLReader.Value

    '' ''                                    Case "Pass"

    '' ''                                        Try
    '' ''                                            DataGridView1.Rows(dr).Cells("cmlPass").Value = Lawyer.Coding.HsPublic.DecryptText(XMLReader.Value)
    '' ''                                            DataGridView1.Rows(dr).Cells("cmlPass").Tag = Lawyer.Coding.HsPublic.DecryptText(XMLReader.Value)

    '' ''                                        Catch ex As Exception

    '' ''                                            DataGridView1.Rows(dr).Cells("cmlPass").Value = String.Empty

    '' ''                                        End Try

    '' ''                                    Case "Server"

    '' ''                                        DataGridView1.Rows(dr).Cells("clmServer").Value = XMLReader.Value

    '' ''                                    Case "Active"

    '' ''                                        If IsActiveIndex <> -1 Then

    '' ''                                            DataGridView1.Rows(dr).Cells("clmActive").Value = CBool("False")

    '' ''                                        Else

    '' ''                                            If CBool(XMLReader.Value) Then

    '' ''                                                IsActiveIndex = dr

    '' ''                                            End If

    '' ''                                            DataGridView1.Rows(dr).Cells("clmActive").Value = CBool(XMLReader.Value)

    '' ''                                        End If


    '' ''                                End Select


    '' ''                            End While

    '' ''                        End If

    '' ''                End Select

    '' ''            End While

    '' ''            XMLReader.Close()

    '' ''        Catch ex As Exception

    '' ''            If XMLReader IsNot Nothing Then
    '' ''                XMLReader.Close()
    '' ''            End If
    '' ''            ErrorManager.WriteMessage("Read_XML", ex.ToString(), Me.Text)
    '' ''            lblMessage.Text = "خطا در بارگذاری فایل"

    '' ''        End Try

    '' ''    End Sub

    '' ''#End Region


End Class