Imports System.Web.UI.WebControls

Namespace HS.JavaScript


    Public Class General

        Public Shared Sub HoverImage(ByVal imb As ImageButton)

            imb.Attributes("class") = "iexbutton" 'for gray image set border 
            imb.Attributes("onmouseover") = "this.className='iexbuttonover'"
            imb.Attributes("onmouseout") = "this.className='iexbutton'"

        End Sub



    End Class

End Namespace