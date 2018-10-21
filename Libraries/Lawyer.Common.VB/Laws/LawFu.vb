Namespace Laws

    Public Class LawFu


        Private _lawFUID As Int32
        Private _lawID As Int32
        Private _userID As String
        Private _lawFULRTYe As Int16


        Public Property lawFUID() As Int32
            Get
                Return _lawFUID
            End Get
            Set(ByVal value As Int32)
                _lawFUID = value
            End Set
        End Property


        Public Property lawID() As Int32
            Get
                Return _lawID
            End Get
            Set(ByVal value As Int32)
                _lawID = value
            End Set
        End Property


        Public Property userID() As String
            Get
                Return _userID
            End Get
            Set(ByVal value As String)
                _userID = value
            End Set
        End Property


        Public Property lawFULRTYe() As Int16
            Get
                Return _lawFULRTYe
            End Get
            Set(ByVal value As Int16)
                _lawFULRTYe = value
            End Set
        End Property







    End Class


End Namespace
