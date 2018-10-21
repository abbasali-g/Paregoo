Imports System.IO

Namespace Laws

    Public Class ConvertLawToDetails


        Dim _Title As String
        Dim IsFirstOn, IsAcceptable, IsDoubtable As Boolean
        Dim _Enter As String = Chr(13) + Chr(10)
        '------------------------------------------
        'in richtextbox enter is 10
        Dim _EnterRich As String = Chr(10)
        '-------------------------------------------
        Dim CuttedLast9chars As String = String.Empty
        Dim CurNo As Integer = 0



        Public Sub InsertLawAsDetail(ByVal _lawID As Integer)


            Dim Law As New Law
            Law = LawManager.GetLawByIDForEmail(_lawID)
            ' Law.lawTitle
            ' Law.lawContent 

            Dim str As String = Law.lawContent
            str = str.Replace(_Enter + Chr(32), _Enter)
            str = str.Replace("ـ", "-") '220 --> 45 

            Dim lr As New List(Of String())


            Dim Flg1, Flg2 As Integer
            Dim _End As Boolean = False


            IsFirstOn = True
            While Not _End

                'If CurNo = 1 Then
                '    Dim a As Integer = 1
                'End If

                Flg1 = _Find(str, True)
                IsFirstOn = False

                '================================== 12--> 1
                If Flg1 + 1 >= 9 Then
                    CuttedLast9chars = str.Substring(Flg1 + 1 - 9, 9)
                Else
                    CuttedLast9chars = str.Substring(0, Flg1 + 1)
                End If
                '-------------------------------
                Flg2 = _Find(str.Substring(Flg1 + 1), False)
                Dim PosPointer As Integer = 1
                '==================================





                '===================================================================== inner search

                While Not IsAcceptable

                    If Flg2 = -1 Then
                        Exit While
                    Else

                        PosPointer += Flg2 + 12
                        If PosPointer < str.Length Then
                            '--------------------
                            If PosPointer >= 9 Then
                                CuttedLast9chars = str.Substring(PosPointer - 9, 9)
                            Else
                                CuttedLast9chars = str.Substring(0, PosPointer)
                            End If
                            '----------------------
                            Flg2 = _Find(str.Substring(PosPointer), False)
                        Else
                            Flg2 = -1
                        End If

                    End If
                End While
                '=====================================================================

                If Flg2 > -1 Then
                    Flg2 += PosPointer
                End If

                '------------------------------- len madde str
                Dim Len As Integer

                If Flg1 > -1 Then

                    If Flg2 > -1 Then
                        Len = Flg2 - Flg1
                    Else
                        Len = str.Length - Flg1 'str.Length - 1 - f1
                        _End = True
                    End If


                    Dim start As Integer = Flg1
                    Dim Madde As String = str.Substring(start, Len)
                    If Madde.Substring(0, 2) = _Enter Then
                        Madde = Madde.Substring(2)
                    End If


                    '------------------------------
                    If Flg1 > 0 Then 'exception - add remain text in top to previous madde
                        lr(lr.Count - 1)(1) += str.Substring(0, Flg1 - 1)
                        '================
                        'Dim LawDetails0 As New LawDetails
                        'LawDetails0.lawID = _lawID
                        'LawDetails0.lawDetContent = str.Substring(0, f1 - 1)
                        'LawDetailsManager.testUpdatedet(LawDetails0)
                        '===================
                    End If
                    '-------------------------------


                    lr.Add(New String() {_Title, Madde})
                    If IsDoubtable = True Then
                        _write(_lawID)
                    End If

                    '================asli
                    Dim LawDetails As New LawDetails
                    LawDetails.lawID = _lawID
                    LawDetails.lawDetTitle = _Title
                    LawDetails.lawDetContent = Madde
                    LawDetailsManager.testInsertdet(LawDetails)
                    '===================

                    If start + Len >= 9 Then
                        CuttedLast9chars = str.Substring(start + Len - 9, 9)
                    Else
                        CuttedLast9chars = str.Substring(start, Len) '(0,start)
                    End If


                    str = str.Substring(start + Len)
                    CurNo += 1

                End If '----------- len madde str

            End While

            'lr(lr.Count - 1)(1) += _Enter + str ' join remain str to last madde

            '================
            'Dim LawDetails2 As New LawDetails
            'LawDetails2.lawID = _lawID
            'LawDetails2.lawDetContent = Enter + str
            'LawDetailsManager.testUpdatedet(LawDetails2)
            '===================



        End Sub


        Function _Find(ByVal str As String, ByVal setTitle As Boolean) As Integer

            Dim F1 As Integer
            Dim NextStr, PrevStr As String


            IsAcceptable = False

            If IsFirstOn Then

                F1 = 0
                IsAcceptable = True

            Else


                If str.Contains("ماده") Then

                    F1 = str.IndexOf("ماده")

                    If str.Length - (F1 + 4) >= 15 Then
                        NextStr = str.Substring(F1 + 4, 15)
                    Else
                        NextStr = str.Substring(F1 + 4, str.Length - (F1 + 4))
                    End If

                    If F1 >= 9 Then
                        PrevStr = str.Substring(F1 - 9, 15)
                    Else
                        PrevStr = str.Substring(0, F1)
                    End If



                    Select Case True


                        Case NextStr.Contains("-") Or NextStr.Contains("_") Or NextStr.Contains("ـ") Or NextStr.Contains(":") Or NextStr.Contains("اول") Or NextStr.Contains("دوم") Or NextStr.Contains("سوم") Or NextStr.Contains("چهارم") Or NextStr.Contains("پنجم") Or NextStr.Contains("ششم") Or NextStr.Contains("هفتم") Or NextStr.Contains("هشتم") Or NextStr.Contains("نهم") Or NextStr.Contains("دهم") Or NextStr.Contains("یازدهم") Or NextStr.Contains("دورازدهم") Or NextStr.Contains("سیزدهم") Or NextStr.Contains("چهاردهم") Or NextStr.Contains("پانزدهم") Or NextStr.Contains("شانزدهم") Or NextStr.Contains("هفدهم") Or NextStr.Contains("هجدهم") Or NextStr.Contains("نوزدهم") Or NextStr.Contains("بیستم")

                            If PrevStr.Contains(_Enter) Or CuttedLast9chars.Contains(_Enter) Or PrevStr.Contains(_EnterRich) Or CuttedLast9chars.Contains(_EnterRich) Then
                                IsAcceptable = True
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

                    F1 = -1

                End If ' str.Contains("ماده")

            End If

            '------------------

            If IsAcceptable Then
                If setTitle Then

                    Select Case True
                        Case IsFirstOn AndAlso str.Substring(F1, 15).Contains("ماده") AndAlso str.Substring(F1, 15).Contains("-")
                            _Title = str.Substring(F1, str.Substring(F1, 15).IndexOf("-") - F1)
                        Case IsFirstOn AndAlso str.Substring(F1, 15).Contains("ماده") AndAlso str.Substring(F1, 15).Contains("_")
                            _Title = str.Substring(F1, str.Substring(F1, 15).IndexOf("_") - F1)
                        Case IsFirstOn
                            _Title = "عنوان"
                        Case str.Substring(F1, 15).Contains("-")
                            _Title = str.Substring(F1, str.Substring(F1, 15).IndexOf("-") - F1)
                        Case str.Substring(F1, 15).Contains("_")
                            _Title = str.Substring(F1, str.Substring(F1, 15).IndexOf("_") - F1)
                        Case str.Substring(F1, 15).Contains(":")
                            _Title = str.Substring(F1, str.Substring(F1, 15).IndexOf(":") - F1)
                        Case Else
                            _Title = str.Substring(F1, 15)
                    End Select



                End If
            End If

            Return F1



        End Function

        Sub _write(ByVal _lawID As Integer)

            Dim sw As StreamWriter
            Dim _File As String = "c:" + "\DoubtableLaw.txt" 'Application.StartupPath

            ' Create a Text File
            'Dim fs As FileStream = Nothing
            If (Not File.Exists(_File)) Then
                sw = File.CreateText(_File)
                ' fs = File.Create(_File)
                Using sw
                End Using
            End If

            ' Write to a Text File (append)
            If File.Exists(_File) Then

                sw = File.AppendText(_File)
                Using sw ' = New StreamWriter(_File)

                    sw.WriteLine(_lawID.ToString)
                    sw.Flush()
                    sw.Close()

                End Using
            End If


        End Sub



    End Class

End Namespace
