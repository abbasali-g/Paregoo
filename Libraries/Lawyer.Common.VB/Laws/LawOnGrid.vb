Namespace Laws

    Public Class LawOnGrid


        Private _lawID As Int32
        Private _lawTitle As String
        Private _lawLRText As String
        Private _lawPassedDate As Int32


        Public Property lawID() As Int32
            Get
                Return _lawID
            End Get
            Set(ByVal value As Int32)
                _lawID = value
            End Set
        End Property


        Public Property lawTitle() As String
            Get
                Return _lawTitle
            End Get
            Set(ByVal value As String)
                _lawTitle = value
            End Set
        End Property


        Public Property lawLRText() As String
            Get
                Return _lawLRText
            End Get
            Set(ByVal value As String)
                _lawLRText = value
            End Set
        End Property

        Public Property lawPassedDate() As Int32
            Get
                Return _lawPassedDate
            End Get
            Set(ByVal value As Int32)
                _lawPassedDate = value
            End Set
        End Property

    End Class

End Namespace

