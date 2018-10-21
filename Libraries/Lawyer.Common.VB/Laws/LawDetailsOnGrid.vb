Namespace Laws

    Public Class LawDetailsOnGrid

        Private _lawID As Int32
        Private _lawDetID As Int32
        Private _lawTitle As String
        Private _lawDetTitle As String


        Public Property lawID() As Int32
            Get
                Return _lawID
            End Get
            Set(ByVal value As Int32)
                _lawID = value
            End Set
        End Property


        Public Property lawDetID() As Int32
            Get
                Return _lawDetID
            End Get
            Set(ByVal value As Int32)
                _lawDetID = value
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


        Public Property lawDetTitle() As String
            Get
                Return _lawDetTitle
            End Get
            Set(ByVal value As String)
                _lawDetTitle = value
            End Set
        End Property


    End Class

End Namespace
