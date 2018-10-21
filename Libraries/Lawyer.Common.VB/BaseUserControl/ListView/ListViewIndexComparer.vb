Imports System.Windows.Forms

Namespace BaseUserControl.ListView

    Public Class ListViewIndexComparer
        Implements System.Collections.IComparer


        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
            Implements System.Collections.IComparer.Compare

            Return CType(x, ListViewItem).Index - CType(y, ListViewItem).Index

        End Function


    End Class

End Namespace

