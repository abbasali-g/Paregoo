Imports System.IO
Imports System.Security.Cryptography
Imports System.Text


Public Class HsPublic

    Shared Function ReadTextFile(ByVal LineNo As Integer, ByVal TextFilePath As String) As String

        Dim sr As StreamReader
        Dim _File As String = TextFilePath ' 

        If File.Exists(_File) Then
            sr = New StreamReader(_File)

            Dim str As String
            Dim No As Integer = 0
            Do While sr.Peek() >= 0

                str = sr.ReadLine()
                No += 1
                If No = LineNo Then

                    sr.Close()
                    Return str

                End If

                'Select Case No
                '    Case 2
                '        '-------------------------------------------- select cbb item
                '        'For i = 0 To Me.cbbType.Items.Count - 1

                '        '    Dim LawType As LawType = Me.cbbType.Items(i)
                '        '    If LawType.lawTypeID = CShort(str) Then
                '        '        Me.cbbType.SelectedIndex = i

                '        '    End If
                '        'Next
                '        '--------------------------------------------

                '    Case 3
                '        '-------------------------------------------- select cbb item
                '        'For i = 0 To Me.cbbCat.Items.Count - 1

                '        '    Dim LawCat As LawCat = Me.cbbCat.Items(i)
                '        '    If LawCat.lawCatID = CShort(str) Then
                '        '        Me.cbbCat.SelectedIndex = i

                '        '    End If
                '        'Next
                '        '--------------------------------------------

                '    Case 4


                '        'Dim intCol() As String = str.Split(",")

                '        'For i = 0 To Me.lvOrg.Items.Count - 1
                '        '    For ii = 0 To intCol.Count - 1

                '        '        If Me.lvOrg.Items(i).SubItems(1).Text = intCol(ii) Then
                '        '            Me.lvOrg.Items(i).Checked = True
                '        '        End If

                '        '    Next
                '        'Next




                '    Case Else

                'End Select


            Loop

            sr.Close()

        End If

        Return String.Empty

    End Function

    Shared Function ReadTextFile(ByVal TextFilePath As String) As StringBuilder

        Dim sr As StreamReader
        Dim _File As String = TextFilePath
        Dim str As New StringBuilder
        If File.Exists(_File) Then
            sr = New StreamReader(_File)


            Dim No As Integer = 0
            Do While sr.Peek() >= 0

                str.AppendLine(sr.ReadLine())
            Loop

            sr.Close()

        End If

        Return str

    End Function

#Region "Encrypt"

    Public Shared Function EncryptText(ByVal strText As String) As String
        Return Encrypt(strText, "HassanAmin")
    End Function

    Public Shared Function DecryptText(ByVal strText As String) As String
        Return Decrypt(strText, "HassanAmin")
    End Function

    Private Shared Function Encrypt(ByVal _Text As String, ByVal _Key As String) As String

        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

        Try

            Dim KeyByte() As Byte = Encoding.UTF8.GetBytes(Left(_Key, 8))
            Dim TextByte() As Byte = Encoding.UTF8.GetBytes(_Text)

            Dim _Stream As New MemoryStream()

            Dim _Crypt As New DESCryptoServiceProvider()
            Dim _CryptoStream As New CryptoStream(_Stream, _Crypt.CreateEncryptor(KeyByte, IV), CryptoStreamMode.Write)
            _CryptoStream.Write(TextByte, 0, TextByte.Length)
            _CryptoStream.FlushFinalBlock()

            Return Convert.ToBase64String(_Stream.ToArray())

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    'The function used to decrypt the text
    Private Shared Function Decrypt(ByVal _Text As String, ByVal _Key As String) As String

        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim TextByte(_Text.Length) As Byte


        Dim KeyByte() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(_Key, 8))
        TextByte = Convert.FromBase64String(_Text)

        Dim _Stream As New MemoryStream()

        Dim _Crypt As New DESCryptoServiceProvider()
        Dim _CryptoStream As New CryptoStream(_Stream, _Crypt.CreateDecryptor(KeyByte, IV), CryptoStreamMode.Write)
        _CryptoStream.Write(TextByte, 0, TextByte.Length)
        _CryptoStream.FlushFinalBlock()

        Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
        Return encoding.GetString(_Stream.ToArray())

    End Function

#End Region

End Class
