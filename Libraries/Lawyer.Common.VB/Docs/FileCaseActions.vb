Namespace Docs
    Public Class FileCaseActions
        Private _Date As String
        Private _text As String



        Public Property ActionDate() As String
            Get
                Return _Date
            End Get
            Set(ByVal value As String)
                _Date = value
            End Set
        End Property


        Public Property ActionText() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property

    End Class
End Namespace

