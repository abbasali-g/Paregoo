Imports System.Text.RegularExpressions


Namespace HS.FileManager.XmlFile

    Public Class General


        Public Shared Function XmlReplace(ByVal Str As String) As String

            Return Str.Replace(Chr(31), Chr(32)).Replace(Chr(12), "").Replace(Chr(26), "").Replace(Chr(2), "").Replace(Chr(1), "").Replace("'", "''").ToString

            ' Cur_LawContent = Cur_LawContent.Replace(Chr(31), Chr(32)) ' space insted nim fasele "ميشود" "مي شود"
            ' Cur_LawContent = Cur_LawContent.Replace("", "") 'chr(26)*
            ' Cur_LawContent = Cur_LawContent.Replace("", "") 'chr(12)*
            ' Cur_LawContent = Cur_LawContent.Replace("", "") 'chr(2)*
            ' Cur_LawContent = Cur_LawContent.Replace("", "")  'chr(1)*

        End Function



    End Class


End Namespace
