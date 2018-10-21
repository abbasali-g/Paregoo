Imports System.IO


Namespace HS.Lawyer

    Public Class ConvertLawToDetails

#Region "Event"

        Public Event LawDetails_Finded(ByVal sender As Object, ByVal e As LawDetails)

#Region "- Event Class -"

        Public Class LawDetailsCollection : Inherits List(Of LawDetails)

        End Class

        Public Class LawDetails : Inherits EventArgs

            Public Sub New(ByVal lawID As Integer, ByVal lawDetTitle As String, ByVal lawDetContent As String)
                _lawID = lawID
                _lawDetTitle = lawDetTitle
                _lawDetContent = lawDetContent
            End Sub



#Region "- Event Class Property -"


            Private _lawID As Int32
            Private _lawDetTitle As String
            Private _lawDetContent As String


            Public Property lawID() As Int32
                Get
                    Return _lawID
                End Get
                Set(ByVal value As Int32)
                    _lawID = value
                End Set
            End Property


            Public Property lawDetTitle() As String
                Get
                    Return _lawDetTitle
                End Get
                Set(ByVal value As String)
                    _lawDetTitle = value
                End Set
            End Property


            Public Property lawDetContent() As String
                Get
                    Return _lawDetContent
                End Get
                Set(ByVal value As String)
                    _lawDetContent = value
                End Set
            End Property

#End Region

        End Class

#End Region

#End Region

#Region "- Definition -"

        Dim _Enter As String = Chr(13) + Chr(10)
        Dim _EnterRich As String = Chr(10) 'in richtextbox enter is 10

        Dim lawDetTitle As String
        Dim IsFirstOne, IsAcceptable, IsDoubtable As Boolean
        Dim CuttedLast9chars As String = String.Empty
        Dim CurNo As Integer = 0

#End Region


        Public Function GetDetail(ByVal lawID As Integer, ByVal LawContent As String, ByVal DoubtableLawFilePath As String) As LawDetailsCollection

            Dim LawDetailsCollection As New LawDetailsCollection
            Dim Cur_LawContent As String = LawContent

            If Trim(Cur_LawContent) = String.Empty Then
                Return Nothing
            End If

            Cur_LawContent = Cur_LawContent.Replace(_Enter + Chr(32), _Enter)
            Cur_LawContent = Cur_LawContent.Replace("<br>", _Enter)
            Cur_LawContent = Cur_LawContent.Replace("ـ", "-") '220 --> 45

            '
            Cur_LawContent = Cur_LawContent.Replace("&raquo;", "»")
            Cur_LawContent = Cur_LawContent.Replace("&laquo;", "«")
            Cur_LawContent = Cur_LawContent.Replace("", "") 'chr(7)


            'for xml error  
            Cur_LawContent = HS.FileManager.XmlFile.General.XmlReplace(Cur_LawContent)
            Cur_LawContent = HS.FileManager.TextFile.MyRegex.ClearHTMLTags(Cur_LawContent, 0)


            Cur_LawContent = Cur_LawContent.Replace("'", "''") ' for insert sql


            Cur_LawContent = Cur_LawContent.Replace("‎", "")
            Cur_LawContent = Cur_LawContent.Replace("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", " ")
            Cur_LawContent = Cur_LawContent.Replace("&nbsp;&nbsp;&nbsp;&nbsp;", " ")
            Cur_LawContent = Cur_LawContent.Replace("&nbsp;&nbsp;&nbsp;", " ")
            Cur_LawContent = Cur_LawContent.Replace("&nbsp;&nbsp;", " ")
            Cur_LawContent = Cur_LawContent.Replace("&nbsp;", " ") '&nbsp;
            Cur_LawContent = Cur_LawContent.Replace("&zwnj;", " ")
            Cur_LawContent = Cur_LawContent.Replace("&raquo;", " ")
            Cur_LawContent = IIf(Cur_LawContent.Substring(0, 1) = _EnterRich, Cur_LawContent.Substring(1), Cur_LawContent)
            Cur_LawContent = Trim(Cur_LawContent)








            Dim lr As New List(Of String())


            Dim Flg1, Flg2 As Integer
            Dim _End As Boolean = False
            IsFirstOne = True


            While Not _End

                'If CurNo = 1 Then
                '    Dim a As Integer = 1
                'End If

                Flg1 = GetFindPos(Cur_LawContent, True)
                IsFirstOne = False

                '================================== 12--> 1
                'After Cut Current find , Search remain
                If Flg1 + 1 >= 9 Then
                    CuttedLast9chars = Cur_LawContent.Substring(Flg1 + 1 - 9, 9)
                Else
                    CuttedLast9chars = Cur_LawContent.Substring(0, Flg1 + 1)
                End If
                '-------------------------------
                Flg2 = GetFindPos(Cur_LawContent.Substring(Flg1 + 1), False)

                '===================================================================== inner search

                Dim StartOfInnerContent As Integer = 1

                While Not IsAcceptable

                    If Flg2 = -1 Then
                        Exit While
                    Else

                        Dim CutLenForNextSearch As Integer = 10
                        StartOfInnerContent += Flg2 + CutLenForNextSearch
                        If StartOfInnerContent < Cur_LawContent.Length Then

                            'After Cut Current find , Search again
                            If StartOfInnerContent >= 9 Then
                                CuttedLast9chars = Cur_LawContent.Substring(StartOfInnerContent - 9, 9) '  اده.....بقیه
                            Else
                                CuttedLast9chars = Cur_LawContent.Substring(0, StartOfInnerContent)
                            End If

                            Flg2 = GetFindPos(Cur_LawContent.Substring(StartOfInnerContent), False)

                        Else
                            Flg2 = -1
                        End If

                    End If
                End While
                '=====================================================================

                If Flg2 > -1 Then
                    Flg2 += StartOfInnerContent
                End If

                '------------------------------- len madde str

                If Flg1 > -1 Then

                    Dim start_LawDetContent As Integer = Flg1
                    Dim Len_LawDetContent As Integer


                    If Flg2 > -1 Then
                        Len_LawDetContent = Flg2 - Flg1
                    Else
                        Len_LawDetContent = Cur_LawContent.Length - Flg1
                        _End = True
                    End If


                    Dim lawDetContent As String = Cur_LawContent.Substring(start_LawDetContent, Len_LawDetContent)
                    If lawDetContent.Substring(0, 2) = _Enter Then
                        lawDetContent = lawDetContent.Substring(2)
                    End If
                    lawDetContent = lawDetContent.Replace(_EnterRich, _Enter) ' EnterRich when store in mysql disappear.


                    '------------------------------
                    If Flg1 > 0 Then 'exception - add remain text in top to previous madde
                        ' lr(lr.Count - 1)(1) += Cur_LawContent.Substring(0, Flg1 - 1)
                    End If
                    '-------------------------------

                    ' lr.Add(New String() {lawDetTitle, lawDetContent})

                    If IsDoubtable = True Then
                        Dim fm As New HS.FileManager.TextFile.General
                        fm.AppendTextToFile(lawID, DoubtableLawFilePath)
                    End If

                    '================asli
                    ' Dim LawDetails As New LawDetails(lawID, lawDetTitle, lawDetContent)
                    ' LawDetailsCollection.Add(LawDetails)

                    RaiseEvent LawDetails_Finded(Me, New LawDetails(lawID, lawDetTitle, lawDetContent))

                    ' Dim LawDetails As New LawDetails
                    ' LawDetails.lawID = lawID
                    ' LawDetails.lawDetTitle = lawDetTitle
                    ' LawDetails.lawDetContent = lawDetContent
                    ' LawDetailsManager.testInsertdet(LawDetails)
                    '===================

                    If start_LawDetContent + Len_LawDetContent >= 9 Then
                        CuttedLast9chars = Cur_LawContent.Substring(start_LawDetContent + Len_LawDetContent - 9, 9)
                    Else
                        CuttedLast9chars = Cur_LawContent.Substring(start_LawDetContent, Len_LawDetContent) '(0,start)
                    End If

                    Cur_LawContent = Cur_LawContent.Substring(start_LawDetContent + Len_LawDetContent)

                    CurNo += 1

                End If '----------- len madde str

            End While

            Return LawDetailsCollection

        End Function

        Function GetFindPos(ByVal Content As String, ByVal GetLawDetTitle As Boolean) As Integer

            Dim Pos As Integer
            Dim NextStr, PrevStr As String

            IsAcceptable = False


            If IsFirstOne Then

                Pos = 0
                IsAcceptable = True

            Else


                If Content.Contains("ماده") Then

                    Pos = Content.IndexOf("ماده")


                    'Make NextStr, PrevStr
                    If Content.Length - (Pos + 4) >= 25 Then
                        NextStr = Content.Substring(Pos + 4, 25)
                    Else
                        NextStr = Content.Substring(Pos + 4, Content.Length - (Pos + 4))
                    End If

                    If Pos >= 9 Then
                        PrevStr = Content.Substring(Pos - 9, 9)
                    Else
                        PrevStr = Content.Substring(0, Pos)
                    End If



                    Select Case True


                        Case NextStr.Contains("-") Or NextStr.Contains("_") Or NextStr.Contains("ـ") Or NextStr.Contains(":") Or NextStr.Contains("اول") Or NextStr.Contains("دوم") Or NextStr.Contains("سوم") Or NextStr.Contains("چهارم") Or NextStr.Contains("پنجم") Or NextStr.Contains("ششم") Or NextStr.Contains("هفتم") Or NextStr.Contains("هشتم") Or NextStr.Contains("نهم") Or NextStr.Contains("دهم") Or NextStr.Contains("یازدهم") Or NextStr.Contains("دورازدهم") Or NextStr.Contains("سیزدهم") Or NextStr.Contains("چهاردهم") Or NextStr.Contains("پانزدهم") Or NextStr.Contains("شانزدهم") Or NextStr.Contains("هفدهم") Or NextStr.Contains("هجدهم") Or NextStr.Contains("نوزدهم") Or NextStr.Contains("بیست") Or NextStr.Contains("سي") Or NextStr.Contains("چهل") Or NextStr.Contains("پنجاه") Or NextStr.Contains("شصت") Or NextStr.Contains("هفتاد") Or NextStr.Contains("هشتاد") Or NextStr.Contains("نود") Or NextStr.Contains("صد") Or NextStr.Contains("دويست")

                            Dim BaseString As String = IIf(Len(PrevStr) = 9, PrevStr, CuttedLast9chars)

                            If BaseString.Contains(_Enter) Or BaseString.Contains(_EnterRich) Then
                                If CuttedLast9chars.Contains("اده" + _Enter) Then 'شاید فقط اینتر در آخر 9 کاراکتر مجاز باشد
                                    IsAcceptable = False ' اگر در جستجوی غیر قابل قبول قبلی کلمه ماده در آخر سطر باشد ، 9 کاراکتر شامل اینتر غیر مجاز است 
                                Else
                                    IsAcceptable = True
                                End If

                            End If

                            If Not IsAcceptable Then

                                Select Case True
                                    Case CuttedLast9chars.Length = 9 AndAlso CuttedLast9chars.Contains("      ") AndAlso CuttedLast9chars.Substring(0, 3).Contains(".")
                                        IsAcceptable = True
                                    Case PrevStr.Length = 9 AndAlso PrevStr.Contains("      ") AndAlso PrevStr.Substring(0, 3).Contains(".")
                                        IsAcceptable = True
                                    Case PrevStr.Contains("      ") Or CuttedLast9chars.Contains("      ")
                                        IsDoubtable = True
                                        IsAcceptable = True
                                End Select

                            End If

                        Case Else

                            IsAcceptable = False

                    End Select

                Else

                    Pos = -1

                End If

            End If




            ' Get LawDetTitle

            If IsAcceptable Then

                If GetLawDetTitle Then

                    Dim TitleAreaLen As Integer
                    TitleAreaLen = IIf(Pos + 30 <= Content.Length, 30, Content.Length - Pos)
                    Select Case True
                        Case IsFirstOne AndAlso Content.Substring(Pos, TitleAreaLen).Contains("ماده") AndAlso Content.Substring(Pos, TitleAreaLen).Contains("-")
                            lawDetTitle = Content.Substring(Pos, Content.Substring(Pos, TitleAreaLen).IndexOf("-") - Pos)
                        Case IsFirstOne AndAlso Content.Substring(Pos, TitleAreaLen).Contains("ماده") AndAlso Content.Substring(Pos, TitleAreaLen).Contains("_")
                            lawDetTitle = Content.Substring(Pos, Content.Substring(Pos, TitleAreaLen).IndexOf("_") - Pos)
                        Case IsFirstOne
                            lawDetTitle = "عنوان"
                        Case Content.Substring(Pos, TitleAreaLen).Contains("ماده") AndAlso Content.Substring(Pos, TitleAreaLen).IndexOf(_Enter, 5) > -1
                            lawDetTitle = Content.Substring(Pos, Content.Substring(Pos, TitleAreaLen).IndexOf(_Enter, 5) - Pos)
                        Case Content.Substring(Pos, TitleAreaLen).Contains("ماده") AndAlso Content.Substring(Pos, TitleAreaLen).IndexOf(_EnterRich, 5) > -1
                            lawDetTitle = Content.Substring(Pos, Content.Substring(Pos, TitleAreaLen).IndexOf(_EnterRich, 5) - Pos)
                        Case Content.Substring(Pos, TitleAreaLen).Contains("-")
                            lawDetTitle = Content.Substring(Pos, Content.Substring(Pos, TitleAreaLen).IndexOf("-") - Pos)
                        Case Content.Substring(Pos, TitleAreaLen).Contains("_")
                            lawDetTitle = Content.Substring(Pos, Content.Substring(Pos, TitleAreaLen).IndexOf("_") - Pos)
                        Case Content.Substring(Pos, TitleAreaLen).Contains(":")
                            lawDetTitle = Content.Substring(Pos, Content.Substring(Pos, TitleAreaLen).IndexOf(":") - Pos)
                        Case Content.Substring(Pos, TitleAreaLen).Contains("ماده") AndAlso Content.Substring(Pos, TitleAreaLen).IndexOf(" ", 5) > -1
                            lawDetTitle = Content.Substring(Pos, Content.Substring(Pos, TitleAreaLen).IndexOf(" ", 5) - Pos)
                        Case Else
                            lawDetTitle = Content.Substring(Pos, TitleAreaLen)
                    End Select


                End If
            End If

            Return Pos



        End Function

    End Class

End Namespace
