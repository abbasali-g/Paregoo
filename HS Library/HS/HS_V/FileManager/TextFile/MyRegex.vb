Imports System.Text.RegularExpressions
Imports System.IO

Namespace HS.FileManager.TextFile

    Public Class MyRegex



        Public Shared Function RemoveMESC_Header(ByVal Str As String) As String

            Try

                ' Dim _Regex As New Regex("^1\s*M E S C   B O O K.*\s*.*\s*.*\s*.*\s*.*DESCRPTION.*\s*.*----\s{2}", RegexOptions.Multiline)
                Dim _Regex As New Regex("^1\r\n.*\n.*\n.*\n.*\n.*\n.*\n.*\n.*----\s{2}", RegexOptions.Multiline)

                Dim m As Match = _Regex.Match(Str)
                While m.Success
                    Str = _Regex.Replace(Str, "")
                    m = m.NextMatch()
                End While

                Return Str

            Catch ex As Exception
                Throw ex
            End Try


        End Function




        Public Shared Function SearchStringInTextFile(ByVal FileName As String, ByVal SearchString As String) As String

            Dim SReader As New StreamReader(FileName)
            Dim allRead As String = SReader.ReadToEnd()
            SReader.Close()

            '  string regMatch = " "; It is case sensitive.
            If Regex.IsMatch(allRead, SearchString) Then 'If the match is found in allRead
                Return "found"
            Else
                Return "not found"
            End If

        End Function


        Public Shared Function GetWordsInDoubleQuote(ByVal s As String) As List(Of String)

            Dim _Regex As New Regex("""(?<InQuote>[^""]*)""")
            Dim m As Match = _Regex.Match(s)

            Dim l As New List(Of String)
            While m.Success
                l.Add(m.Groups("InQuote").Value)
                m = m.NextMatch()
            End While

            Return l
        End Function

        Public Shared Function RemoveWordsInDoubleQuote(ByVal s As String) As String

            Dim _Regex As New Regex("""(?<InQuote>[^""]*)""")

            Dim strQuoteLess As String

            strQuoteLess = _Regex.Replace(s, "")

            'Dim m As Match = _Regex.Match(s)

            'Dim l As New List(Of String)
            'While m.Success
            '    l.Add(m.Groups("InQuote").Value)
            '    m = m.NextMatch()
            'End While


            Return strQuoteLess
        End Function



        Shared Function ClearHTMLTags(ByVal strHTML As String, ByVal intWorkFlow As Integer) As String

            Dim regEx As System.Text.RegularExpressions.Regex
            Dim strTagLess As String
            '---------------------------------------
            strTagLess = strHTML


            'regEx initialization
            '---------------------------------------
            regEx = New System.Text.RegularExpressions.Regex("<[^>]*>", RegexOptions.IgnoreCase) ' 'this pattern mathces any html tag
            'Creates a regexp object		
            ' regEx.IgnoreCase = True
            'Don't give frat about case sensitivity
            ' regEx.Global = True
            'Global applicability
            '---------------------------------------

            'Phase I
            If intWorkFlow <> 1 Then
                strTagLess = regEx.Replace(strTagLess, "") 'all html tags are stripped
            End If

            'Phase II
            '	"bye bye rouge leftovers"
            '	"or, I want to render the source"
            '	"as html."

            '---------------------------------------
            'We *might* still have rouge < and > 
            'let's be positive that those that remain
            'are changed into html characters
            '---------------------------------------	

            If intWorkFlow > 0 And intWorkFlow < 3 Then

                regEx = New System.Text.RegularExpressions.Regex("[<]", RegexOptions.IgnoreCase) ' 'matches a single <
                strTagLess = regEx.Replace(strTagLess, "<")

                regEx = New System.Text.RegularExpressions.Regex("[>]", RegexOptions.IgnoreCase) '  'matches a single >
                strTagLess = regEx.Replace(strTagLess, ">")

            End If


            regEx = Nothing

            Return strTagLess

        End Function

        Shared Function HasHTMLTags(ByVal strHTML As String, ByVal intWorkFlow As Integer) As Boolean

            Dim regEx As System.Text.RegularExpressions.Regex
            Dim strTagLess As String
            Dim ISHtmlTag As Boolean = False
            '---------------------------------------
            strTagLess = strHTML


            'regEx initialization
            '---------------------------------------
            regEx = New System.Text.RegularExpressions.Regex("<[^>]*>", RegexOptions.IgnoreCase) ' 'this pattern mathces any html tag
            'Creates a regexp object		
            ' regEx.IgnoreCase = True
            'Don't give frat about case sensitivity
            ' regEx.Global = True
            'Global applicability
            '---------------------------------------

            'Phase I
            If intWorkFlow <> 1 Then
                ISHtmlTag = regEx.IsMatch(strTagLess) 'all html tags are stripped
            End If

            'Phase II
            '	"bye bye rouge leftovers"
            '	"or, I want to render the source"
            '	"as html."

            '---------------------------------------
            'We *might* still have rouge < and > 
            'let's be positive that those that remain
            'are changed into html characters
            '---------------------------------------	

            If intWorkFlow > 0 And intWorkFlow < 3 Then

                regEx = New System.Text.RegularExpressions.Regex("[<]", RegexOptions.IgnoreCase) ' 'matches a single <
                strTagLess = regEx.Replace(strTagLess, "<")

                regEx = New System.Text.RegularExpressions.Regex("[>]", RegexOptions.IgnoreCase) '  'matches a single >
                strTagLess = regEx.Replace(strTagLess, ">")

            End If


            regEx = Nothing

            Return ISHtmlTag

        End Function


        Function IsEmail(ByVal email As String) As Boolean

            Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
            Return emailExpression.IsMatch(email)

        End Function


    End Class


End Namespace