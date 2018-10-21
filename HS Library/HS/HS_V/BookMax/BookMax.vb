Imports System.Collections.ArrayList
Imports System.IO

Namespace HS

    Public Class BookMax

        Private _AL_FarsiFieldTitle As New ArrayList
        Private _AL_FarsiEtcTitle As New ArrayList
        Private _AL_EnglishFieldTitle As New ArrayList
        Private _AL_EnglishEtcTitle As New ArrayList


        Private _Language As String
        Public WriteOnly Property Language() As String

            Set(ByVal value As String)
                _Language = value
            End Set
        End Property


        Private _Message As String
        Public ReadOnly Property Message() As String
            Get
                Return _Message
            End Get

        End Property

        Private Sub Fill_FarsiFieldTitle()

            _AL_FarsiFieldTitle.Add("سرشناسه:")
            _AL_FarsiFieldTitle.Add("عنوان:")
            _AL_FarsiFieldTitle.Add("نام پدیدآور:")
            _AL_FarsiFieldTitle.Add("مشخصات نشر:")
            _AL_FarsiFieldTitle.Add("مشخصات ظاهری:")
            _AL_FarsiFieldTitle.Add("فروست:")
            _AL_FarsiFieldTitle.Add("شابک:")
            _AL_FarsiFieldTitle.Add("موضوع:")
            _AL_FarsiFieldTitle.Add("رده بندی کنگره:")
            _AL_FarsiFieldTitle.Add("رده بندی دیویی:")
            _AL_FarsiFieldTitle.Add("شماره کتابشناسی ملی:")
            _AL_FarsiFieldTitle.Add("عنوان و نام پديدآور:")


        End Sub

        Private Sub Fill_FarsiEtcTitle()

            Try

                _AL_FarsiEtcTitle.Add("وضعیت فهرست نویسی:")
                _AL_FarsiEtcTitle.Add("يادداشت:")
                _AL_FarsiEtcTitle.Add("عنوان دیگر:")
                _AL_FarsiEtcTitle.Add("شناسه افزوده:")
                _AL_FarsiEtcTitle.Add("عنوان روی جلد:")
                _AL_FarsiEtcTitle.Add("عنوان عطف:")
                _AL_FarsiEtcTitle.Add("مندرجات:")
                _AL_FarsiEtcTitle.Add("موضوع:")
                _AL_FarsiEtcTitle.Add("وضعيت ويراست")

            Catch ex As Exception

            End Try

        End Sub

        Private Sub Fill_EnglishFieldTitle()

            Try

                _AL_EnglishFieldTitle.Add("Personal Name:")
                _AL_EnglishFieldTitle.Add("Main Title:")
                _AL_EnglishFieldTitle.Add("Published/Created:")
                _AL_EnglishFieldTitle.Add("Description:")

                _AL_EnglishFieldTitle.Add("ISBN:")
                _AL_EnglishFieldTitle.Add("Subjects:")
                _AL_EnglishFieldTitle.Add("LC Classification:")
                _AL_EnglishFieldTitle.Add("Dewey Class No.:")

                _AL_EnglishFieldTitle.Add("LC Control No.:")

            Catch ex As Exception
            End Try
        End Sub

        Private Sub Fill_EnglishEtcTitle()

            Try

                'for del from end of find

                _AL_EnglishEtcTitle.Add("LCCN Permalink:")
                _AL_EnglishEtcTitle.Add("Type of Material:")
                _AL_EnglishEtcTitle.Add("Related Names:")
                _AL_EnglishEtcTitle.Add("Notes:")
                _AL_EnglishEtcTitle.Add("Form/Genre:")
                _AL_EnglishEtcTitle.Add("LC Copy:")
                _AL_EnglishEtcTitle.Add("Serial Key Title:")
                _AL_EnglishEtcTitle.Add("Current Frequency:")
                _AL_EnglishEtcTitle.Add("Cancelled/Invalid LCCN:")
                _AL_EnglishEtcTitle.Add("Additional Formats:")
                _AL_EnglishEtcTitle.Add("Other System No.:")
                _AL_EnglishEtcTitle.Add("Reproduction No./Source:")
                _AL_EnglishEtcTitle.Add("Geographic Area Code:")
                _AL_EnglishEtcTitle.Add("Quality Code:")
                _AL_EnglishEtcTitle.Add("Edition Information:")
                _AL_EnglishEtcTitle.Add("ISSN:")
                _AL_EnglishEtcTitle.Add("Electronic File Information:")
                _AL_EnglishEtcTitle.Add("Links:")
                _AL_EnglishEtcTitle.Add("communication :")
                _AL_EnglishEtcTitle.Add("Projected Publication Date:")
                _AL_EnglishEtcTitle.Add("Corporate Name:")
                _AL_EnglishEtcTitle.Add("Cover Title:")
                _AL_EnglishEtcTitle.Add("Spine Title:")
                _AL_EnglishEtcTitle.Add("Acquisition Source:")
                _AL_EnglishEtcTitle.Add("Uniform Title:")
                _AL_EnglishEtcTitle.Add("Portion of Title:")
                _AL_EnglishEtcTitle.Add("Abbreviated Title:")
                _AL_EnglishEtcTitle.Add("National Bibliography No.:")

                _AL_EnglishEtcTitle.Add("_____")
                _AL_EnglishEtcTitle.Add("CALL NUMBER:")
                _AL_EnglishEtcTitle.Add("-- Request in:")
                _AL_EnglishEtcTitle.Add("-- Status:")
                _AL_EnglishEtcTitle.Add("-- Older Receipts:")
                _AL_EnglishEtcTitle.Add("=====")

            Catch ex As Exception

            End Try

        End Sub

        Private Function GetFileNames(ByVal path As String) As ArrayList

            Dim FileNames As New System.Collections.ArrayList()
            Dim TotalFiles As Integer = 0 : Dim FileName As String

            Try

                For Each FileName In Directory.GetFiles(Path)

                    If FileName.Substring(FileName.Length - 4) = ".txt" Then
                        FileNames.Insert(TotalFiles, FileName)
                        TotalFiles += 1
                    End If

                Next

            Catch ex As Exception
            End Try

            Return FileNames


        End Function


        Public Function ReadBookTextFile(ByVal FileName As String) As Hashtable


            Dim RecordValues As ArrayList
            Dim Ht_Record As New Hashtable


            RecordValues = MakeRecord(FileName)


            If RecordValues.Count = 0 Then
                _Message = " فایل بدون اطلاعات"
            Else


                If RecordValues(14) = "-" Or RecordValues(14) = "--" Or RecordValues(12) = "Error" Then 'error in lc3 or lc1
                    _Message = "فرمت کنگره نادرست است"
                End If

                Ht_Record.Add("Sarshenase", RecordValues(0))
                Ht_Record.Add("Onvan", RecordValues(1))
                Ht_Record.Add("NamePadidAvar", RecordValues(2))
                Ht_Record.Add("MoshakhasatNashr", RecordValues(3))
                Ht_Record.Add("MoshakhasatZaheri", RecordValues(4))
                Ht_Record.Add("Farvast", RecordValues(5))
                Ht_Record.Add("Shabak", RecordValues(6))
                Ht_Record.Add("Mozu", RecordValues(7))
                Ht_Record.Add("Kongere", RecordValues(8))
                Ht_Record.Add("Deioie", RecordValues(9))
                Ht_Record.Add("ShKetabshenasiMeli", RecordValues(10))
                Ht_Record.Add("FileName", RecordValues(11))
                Ht_Record.Add("LC1", RecordValues(12))
                Ht_Record.Add("LC2", RecordValues(13))
                Ht_Record.Add("LC3", RecordValues(14))
                Ht_Record.Add("LC4", RecordValues(15))


            End If


            Return Ht_Record

        End Function


        Private Function MakeRecord(ByVal FileName As String) As ArrayList

            Dim RecordValues As New ArrayList

            ' DetermineLanguage(FileName)

            Fill_FarsiFieldTitle() : Fill_FarsiEtcTitle()
            Fill_EnglishFieldTitle() : Fill_EnglishEtcTitle()

            If _Language = "Farsi" Then
                RecordValues = GetFarsiRecordValues(FileName)
            ElseIf _Language = "English" Then
                RecordValues = GetEnglishRecordValues(FileName)
            Else
                _Message = "محتویات فایل متنی صحیح نمی باشد"
            End If


            Return RecordValues

        End Function

        '~~~~~~~~~~~~~~~~~relate 1~~~~~~~~~~~~~~~~~~~~~~~~~~

        Private Function GetFarsiRecordValues(ByVal FileName As String) As ArrayList

            Dim RecordValues As New System.Collections.ArrayList
            Try

                Dim Sarshenase As String = GetFieldValue(FileName, _AL_FarsiFieldTitle(_AL_FarsiFieldTitle.IndexOf("سرشناسه:")))
                RecordValues.Add(RemoveInvalidChar(Sarshenase))

                Dim onvan As String = ""
                Dim PadidAvarande As String = ""
                Dim OnvanVaName As String = GetFieldValue(FileName, "عنوان و نام پديدآور:")

                If OnvanVaName <> String.Empty Then

                    If OnvanVaName.Contains("/") Then

                        Dim s() As String : s = OnvanVaName.Split("/")
                        onvan = s.GetValue(0)
                        PadidAvarande = s.GetValue(1)

                    Else

                        onvan = OnvanVaName
                        PadidAvarande = String.Empty

                    End If


                    'Else
                    ' onvan = SearchWord(FileName, FarsiField(FarsiField.IndexOf("عنوان:")))
                    ' PadidAvarande = SearchWord(FileName, FarsiField(FarsiField.IndexOf("نام پدیدآور:")))
                End If

                RecordValues.Add(RemoveInvalidChar(onvan))
                RecordValues.Add(RemoveInvalidChar(PadidAvarande))

                Dim MoshakhasatNashr As String = GetFieldValue(FileName, _AL_FarsiFieldTitle(_AL_FarsiFieldTitle.IndexOf("مشخصات نشر:")))
                RecordValues.Add(RemoveInvalidChar(MoshakhasatNashr))

                Dim moshakhasatZAheri As String = GetFieldValue(FileName, _AL_FarsiFieldTitle(_AL_FarsiFieldTitle.IndexOf("مشخصات ظاهری:")))
                RecordValues.Add(RemoveInvalidChar(moshakhasatZAheri))

                Dim Farvast As String = GetFieldValue(FileName, _AL_FarsiFieldTitle(_AL_FarsiFieldTitle.IndexOf("فروست:")))
                RecordValues.Add(RemoveInvalidChar(Farvast))

                Dim Shabak As String = GetFieldValue(FileName, _AL_FarsiFieldTitle(_AL_FarsiFieldTitle.IndexOf("شابک:")))
                RecordValues.Add(RemoveInvalidChar(Shabak))

                Dim MOZU As String = GetFieldValue(FileName, _AL_FarsiFieldTitle(_AL_FarsiFieldTitle.IndexOf("موضوع:")))
                RecordValues.Add(RemoveInvalidChar(MOZU))


                Dim Kongre As String = GetFieldValue(FileName, _AL_FarsiFieldTitle(_AL_FarsiFieldTitle.IndexOf("رده بندی کنگره:")))
                RecordValues.Add(RemoveInvalidChar(Kongre))
                '----------------------------------------------
                Dim Lc1 As String = String.Empty
                Dim Lc2 As String = String.Empty
                Dim Lc3 As String = String.Empty
                Dim Lc4 As String = String.Empty
                Dim Lc_Error As String = String.Empty
                Dim lc_farsi As Boolean = False

                If Kongre <> String.Empty Then

                    Kongre = Trim(RemoveInvalidCharFromLc(Kongre))


                    Dim seperators() As Char = {"/", "."}
                    Dim i As Integer
                    If Kongre.Contains("/") Then
                        i = 0 : lc_farsi = True
                    ElseIf Kongre.Contains(".") Then
                        i = 1
                    End If


                    Dim Lc() As String : Lc = Kongre.Split(seperators(i))
                    Dim LLc() As String
                    Dim al As New ArrayList

                    '====================================================================  create 2 section 

                    If Lc.Length = 3 Then
                        al.Add(Lc(0)) : al.Add(Lc(1)) : LLc = Lc(2).Split(" ")
                    ElseIf Lc.Length = 2 Then
                        al.Add(Lc(0)) : LLc = Lc(1).Split(" ")
                    Else
                        Lc_Error = "Error"
                    End If

                    If Lc_Error <> "Error" Then
                        '==================================================================== main section  1
                        Dim LC21 As ArrayList
                        LC21 = Lc1_LC2(al, "/") : Lc1 = LC21(0) : Lc2 = LC21(1)

                        '==================================================================== main section  2
                        If LLc.Length = 1 Then
                            Lc3 = LLc(0) : Lc4 = ""
                        ElseIf LLc.Length = 2 Then
                            Lc3 = LLc(0) : Lc4 = LLc(1)
                        ElseIf LLc.Length = 3 Then ' in english format
                            Lc3 = LLc(0).ToString + " " + LLc(1).ToString : Lc4 = LLc(2)
                        Else
                            Lc3 = "-" : Lc4 = "-"
                        End If
                    Else
                        Lc1 = "Error" : Lc2 = "Error" : Lc3 = "--" : Lc4 = "--"
                    End If



                End If
                '----------------------------------------------



                Dim Deioie As String = GetFieldValue(FileName, _AL_FarsiFieldTitle(_AL_FarsiFieldTitle.IndexOf("رده بندی دیویی:")))
                RecordValues.Add(RemoveInvalidChar(Deioie))

                Dim SHketabshenasi As String = GetFieldValue(FileName, _AL_FarsiFieldTitle(_AL_FarsiFieldTitle.IndexOf("شماره کتابشناسی ملی:")))
                RecordValues.Add(RemoveInvalidChar(SHketabshenasi))

                RecordValues.Add(FileName)

                '-----------------------------------
                'Lc1, Lc2, Lc3, Lc4
                '-----------reverse in farsi ------- ر۹م۹۳   
                '---------------------------------- ‭ر۹م۹۳
                If lc_farsi = True And Lc3 <> "--" And Lc3 <> "-" Then
                    Lc3 = GetReversLc3(Lc3)
                    ' Lc3 = direction(Lc3)
                End If
                '------------------------------------
                RecordValues.Add(Lc1)
                RecordValues.Add(Lc2)
                RecordValues.Add(Lc3)
                RecordValues.Add(Lc4)


                If onvan = String.Empty Then 'Or PadidAvarande = String.Empty Then
                    RecordValues.Clear()
                End If



            Catch ex As Exception

            End Try

            Return RecordValues


        End Function

        Private Function GetEnglishRecordValues(ByVal FileName As String) As ArrayList

            Dim RecordValues As New ArrayList
            Try
                '===========================================================

                Dim Sarshenase As String = GetFieldValue(FileName, "Personal Name:")
                RecordValues.Add(Sarshenase)

                Dim onvan As String = ""
                Dim PadidAvarande As String = ""
                Dim OnvanVaName As String = GetFieldValue(FileName, "Main Title:")

                If OnvanVaName <> String.Empty Then

                    If OnvanVaName.Contains("/") Then

                        Dim s() As String : s = OnvanVaName.Split("/")
                        onvan = s.GetValue(0)
                        PadidAvarande = s.GetValue(1)

                    ElseIf OnvanVaName.Contains("by") Then

                        Dim s() As String : s = OnvanVaName.Split("b")
                        onvan = s.GetValue(0)
                        PadidAvarande = s(1).Replace("y", "")

                    Else

                        onvan = OnvanVaName
                        PadidAvarande = String.Empty

                    End If


                    ' Else
                    ' onvan = SearchWord(FileName, EnglishField(EnglishField.IndexOf("عنوان:")))
                    ' PadidAvarande = SearchWord(FileName, EnglishField(EnglishField.IndexOf("نام پدیدآور:")))
                End If

                RecordValues.Add(onvan)
                RecordValues.Add(PadidAvarande)

                Dim MoshakhasatNashr As String = GetFieldValue(FileName, "Published/Created:")
                RecordValues.Add(MoshakhasatNashr)

                Dim moshakhasatZAheri As String = GetFieldValue(FileName, "Description:")
                RecordValues.Add(moshakhasatZAheri)

                Dim Farvast As String = String.Empty 'SearchWord(FileName, EnglishField(EnglishField.IndexOf("فروست:")))
                RecordValues.Add(Farvast)

                Dim Shabak As String = GetFieldValue(FileName, "ISBN:")
                RecordValues.Add(Shabak)

                Dim MOZU As String = GetFieldValue(FileName, "Subjects:")
                RecordValues.Add(MOZU)


                Dim Kongre As String = GetFieldValue(FileName, "LC Classification:")

                If Kongre = String.Empty Then
                    Kongre = GetFieldValue(FileName, "CALL NUMBER:")
                End If

                RecordValues.Add(Kongre)


                '----------------------------------------------
                Dim Lc1 As String = String.Empty
                Dim Lc2 As String = String.Empty
                Dim Lc3 As String = String.Empty
                Dim Lc4 As String = String.Empty
                Dim Lc_Error As String = String.Empty

                If Kongre <> String.Empty Then

                    Kongre = Trim(RemoveInvalidCharFromLc(Kongre))


                    Dim Lc() As String : Lc = Kongre.Split(".")
                    Dim LLc() As String
                    Dim al As New ArrayList

                    '====================================================================  create 2 section 
                    If Lc.Length = 3 Then
                        al.Add(Lc(0)) : al.Add(Lc(1)) : LLc = Lc(2).Split(" ")
                    ElseIf Lc.Length = 2 Then
                        al.Add(Lc(0)) : LLc = Lc(1).Split(" ")
                    Else
                        Lc_Error = "Error"
                    End If

                    If Lc_Error <> "Error" Then
                        '==================================================================== main section  1
                        Dim LC21 As ArrayList
                        LC21 = Lc1_LC2(al, ".") : Lc1 = LC21(0) : Lc2 = LC21(1)

                        '==================================================================== main section  2
                        If LLc.Length = 1 Then
                            Lc3 = LLc(0) : Lc4 = ""
                        ElseIf LLc.Length = 2 Then
                            Lc3 = LLc(0) : Lc4 = LLc(1)
                        ElseIf LLc.Length = 3 Then
                            Lc3 = LLc(0).ToString + " " + LLc(1).ToString : Lc4 = LLc(2)
                        Else
                            Lc3 = "-" : Lc4 = "-"
                        End If
                    Else
                        Lc1 = "Error" : Lc2 = "Error" : Lc3 = "--" : Lc4 = "--"
                    End If

                End If
                '----------------------------------------------



                Dim Deioie As String = GetFieldValue(FileName, "Dewey Class No.:")
                RecordValues.Add(Deioie)

                Dim SHketabshenasi As String = GetFieldValue(FileName, "LC Control No.:")
                RecordValues.Add(SHketabshenasi)

                RecordValues.Add(FileName)

                '-----------------------------------
                'Lc1, Lc2, Lc3, Lc4 
                RecordValues.Add(Lc1)
                RecordValues.Add(Lc2)
                RecordValues.Add(Lc3)
                RecordValues.Add(Lc4)




                If onvan = String.Empty Then
                    RecordValues.Clear()
                End If






                '=============================================================

            Catch ex As Exception
            End Try
            Return RecordValues

        End Function


        Private Function GetFieldValue(ByVal FileName As String, ByVal FieldTitle As String) As String

            Dim ReadFileLine As String = String.Empty
            Dim Find As String = String.Empty

            Dim MainField, UnusedFields As New ArrayList

            If _Language = "Farsi" Then
                MainField = _AL_FarsiFieldTitle : UnusedFields = _AL_FarsiEtcTitle
            ElseIf _Language = "English" Then
                MainField = _AL_EnglishFieldTitle : UnusedFields = _AL_EnglishEtcTitle
            End If


            Try

                Dim re As StreamReader = File.OpenText(FileName)

                While re.EndOfStream <> True 'Make string  from find field until next field.(read from first) 

                    ReadFileLine = re.ReadLine

                    ReadFileLine = ReadFileLine.Replace(" 	: 	", ":").Trim ' for fire fox browser

                    If ReadFileLine.IndexOf(FieldTitle, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 Then


                        ReadFileLine = ReadFileLine.Replace(FieldTitle, "").Trim
                        If Find <> String.Empty And Not (ReadFileLine.Contains("CALL NUMBER:")) Then 'repeated CALL NUMBER: not needed.
                            Find = Find
                        ElseIf Find <> String.Empty Then '========================== for repeated field
                            Find += " - " + ReadFileLine
                        Else
                            Find += ReadFileLine
                        End If


                    Else

                        If Find <> String.Empty Then

                            If ReadFileLine.Contains(":") Then 'combine until new main field

                                Dim s() As String : s = ReadFileLine.Split(":")
                                Dim a As String = s(0).Trim : a = a + ":"
                                MainField.Sort(Nothing) : Dim i As Integer = MainField.BinarySearch(a)

                                If i < 0 Then
                                    Find += " " + ReadFileLine.Trim
                                Else
                                    Exit While
                                End If

                            ElseIf Not (ReadFileLine.Contains("Copy")) Then ' in CALL NUMBER: no need next row like Copy 3
                                Find += " " + ReadFileLine.Trim
                            End If

                        End If


                    End If 'input.IndexOf(word,

                End While



                If Find <> String.Empty Then 'del secondary fields from end of find

                    For i As Integer = 0 To UnusedFields.Count - 1
                        If Find.Contains(UnusedFields(i)) Then
                            Dim Etc As String = Find.Substring(Find.IndexOf(UnusedFields(i)))
                            Find = Find.Replace(Etc, "").Trim
                        End If
                    Next

                End If




                re.Close()


            Catch ex As Exception
            End Try


            Return Find.Trim

        End Function

        '~~~~~~~~~~~~~~~~~relate 2~~~~~~~~~~~~~~~~~~~~~~~~~~

        Private Function GetReversLc3(ByVal str As String) As String

            Dim s As String = String.Empty
            Dim previous As String = "STR"

            Dim SeparatLc3 As New ArrayList

            For i As Integer = 0 To str.Length - 1

                If Char.IsLetter(str(i)) And previous = "STR" Then

                    s += str(i)

                ElseIf Char.IsDigit(str(i)) And previous = "STR" Then

                    SeparatLc3.Add(s) : s = String.Empty
                    s += str(i) : previous = "NUM"

                ElseIf Char.IsDigit(str(i)) And previous = "NUM" Then

                    s += str(i)

                ElseIf Char.IsLetter(str(i)) And previous = "NUM" Then

                    SeparatLc3.Add(s) : s = String.Empty
                    s += str(i) : previous = "STR"

                End If



            Next

            SeparatLc3.Add(s)
            s = String.Empty
            For i As Integer = SeparatLc3.Count - 1 To 0 Step -1
                s += SeparatLc3(i).ToString

            Next

            Return s





        End Function

        Private Function RemoveInvalidCharFromLc(ByVal str As String) As String

            'Const validChars As String = "/ ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیيكآءأإؤةabcdefghijklmnopqrstuvwxyz"
            Const validChars As String = "0/0‭" 'zero base - control caracter retun 0 like empty --> then for differ, zero location must be unuse character

            Dim s As String = String.Empty
            If str <> String.Empty Then

                For i As Integer = 0 To str.Length - 1
                    If Char.IsLetterOrDigit(str(i)) Or validChars.IndexOf(str(i).ToString()) <> 0 Then
                        s += str(i)
                    End If
                Next i

                s = Trim(s)
            End If
            Return s

        End Function

        Private Function RemoveInvalidChar(ByVal str As String) As String

            'Dim str As String = "‏رده بندی کنگره:‏‫‬‭TA۴۱۸/۷۴‏‫۱۳۸۶ ‏‫‭/آ۹م۴‬"

            'Dim Str2Char() As Char = str.ToCharArray
            'Dim str2(str.ToCharArray.Length - 1) As String
            'For ii As Integer = 0 To str.ToCharArray.Length - 1
            '    str2(ii) = AscW(Str2Char(ii))
            'Next

            '----------------------------------------
            Dim GoodStr As String = String.Empty
            Dim i As Integer = 1
            Dim ch As Char

            Try

          
                While i <= Len(str)

                    ch = Mid(str, i, 1)


                    If AscW(ch) <= 8000 Or AscW(ch) = 8204 Then '--- remove higher than 8000


                        If AscW(ch) = 8204 Then
                            If i + 1 <= Len(str) Then
                                If AscW(Mid(str, i + 1, 1)) <> 32 Then
                                    ch = " "
                                Else
                                    i = i + 1
                                    Continue While
                                End If
                            Else '---- remove 8204
                                i = i + 1
                                Continue While
                            End If

                        End If


                        If AscW(ch) >= 1776 And AscW(ch) <= 1785 Then  '------ convert farsi num to english num
                            ch = Chr(AscW(ch) - 1728) '-- 48 to 57
                        End If



                        GoodStr = GoodStr + ch



                    End If

                    i = i + 1

                End While

                Return GoodStr


            Catch ex As Exception
                Throw New Exception("Error!!!", ex)
            End Try


        End Function

        Private Function Lc1_LC2(ByVal ar As ArrayList, ByVal Joiner As String) As ArrayList


            Dim Lc1, Lc2 As String

            If ar.Count = 1 Then
                ar.Add("")
            ElseIf ar.Count = 2 Then
                ar(0) = ar(0) + Joiner + ar(1)
            End If

            For i As Integer = 0 To ar(0).ToString.Length - 1
                Dim b As Boolean = Char.IsLetter(ar(0).ToString, i)
                If b = False Then

                    Lc1 = ar(0).Substring(0, ar(0).Length - ar(0).Substring(i).Length)
                    Lc2 = ar(0).Substring(i)
                    Exit For

                End If
            Next

            ar(0) = Lc1 : ar(1) = Lc2

            Return ar
        End Function

        '~~~~~~~~~~~~~~~~~~~~unused~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        Private Sub DetermineLanguage(ByVal FileName As String)


            Fill_FarsiFieldTitle() : Fill_FarsiEtcTitle()

            Fill_EnglishFieldTitle() : Fill_EnglishEtcTitle()


            Dim OnvanVaName As String = GetFieldValue(FileName, "عنوان و نام پديدآور:")
            If OnvanVaName <> String.Empty Then
                _Language = "Farsi"
            Else
                OnvanVaName = GetFieldValue(FileName, "Main Title:")
                If OnvanVaName <> String.Empty Then
                    _Language = "English"
                Else
                    _Language = Nothing
                End If

            End If


        End Sub

        Function direction(ByVal str As String) As String

            'Dim chStr() As Char = str.ToCharArray
            'Dim str2(str.ToCharArray.Length - 1) As String
            'For ii As Integer = 0 To str.ToCharArray.Length - 1
            '    str2(ii) = AscW(chStr(ii))
            'Next


            '*strnum*str*num

            Dim s As String = ChrW(8237)
            Dim previous As String = "STR"
            Dim FirstNum As Boolean = True


            For i As Integer = 0 To str.Length - 1

                If Char.IsDigit(str(i)) And previous = "STR" And FirstNum = True Then

                    s += str(i)
                    FirstNum = False
                    previous = "NUM"

                ElseIf Char.IsDigit(str(i)) And previous = "STR" And FirstNum = False Then

                    s += ChrW(8236) + str(i)
                    previous = "NUM"

                ElseIf Char.IsLetter(str(i)) And previous = "NUM" Then

                    s += ChrW(8238) + str(i)
                    previous = "STR"

                Else

                    s += str(i)

                End If

            Next

            Return s

        End Function


    End Class



End Namespace