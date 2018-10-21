Imports System.Windows.Forms
Imports System.Reflection

Namespace HS.Thread

    Public Class Invoke

        'http://www.shabdar.org/c-sharp/102-cross-thread-operation-not-valid.html

        'Dim a As New HS.Thread
        'a.SetControlPropertyValue(Me.Label1, "text", "eeeeeeeeeeeeee")

        Private Delegate Sub Del_SetControlPropertyValue(ByVal oControl As Control, ByVal propName As String, ByVal propValue As Object)
        Public Sub SetControlPropertyValue(ByVal oControl As Control, ByVal propName As String, ByVal propValue As Object)

            If oControl.InvokeRequired Then

                Dim Del As New Del_SetControlPropertyValue(AddressOf SetControlPropertyValue)
                oControl.Invoke(Del, New Object() {oControl, propName, propValue})

            Else

                Dim t As Type = oControl.[GetType]()
                Dim props As PropertyInfo() = t.GetProperties()

                For Each p As PropertyInfo In props

                    If p.Name.ToUpper() = propName.ToUpper() Then
                        p.SetValue(oControl, propValue, Nothing)
                    End If


                Next
            End If

        End Sub


        Private Delegate Sub Del_AddItemToListBox(ByVal oControl As Control, ByVal Item As Object)
        Public Sub AddItemToListBox(ByVal oControl As Control, ByVal Item As Object)

            If TypeOf (oControl) Is ListBox Then

                If oControl.InvokeRequired Then

                    Dim Del As New Del_AddItemToListBox(AddressOf AddItemToListBox)
                    oControl.Invoke(Del, New Object() {oControl, Item})
                Else
                    CType(oControl, ListBox).Items.Add(Item)
                End If

            End If

        End Sub

    End Class

End Namespace
