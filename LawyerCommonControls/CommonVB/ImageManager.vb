Namespace CommonVB

    Public Class ImageManager


        Public Shared ReadOnly Property DefaultDocFiledetailIcon() As String

            Get

                Return "Detail"

            End Get

        End Property


        Public Shared ReadOnly Property DefaultDocFileAlarmIcon() As String

            Get

                Return "Alarm"

            End Get

        End Property


        Public Shared ReadOnly Property DefaultFileIcon() As String

            Get

                Return "File"

            End Get

        End Property


        Public Shared Function IsCorrectImage(ByVal extenstion As String) As Boolean

            extenstion = extenstion.ToLower()

            If extenstion = ".jpg" OrElse extenstion = ".png" OrElse extenstion = ".gif" OrElse extenstion = ".bitmap" Then

                Return True

            End If

            Return False

        End Function

    End Class

End Namespace

