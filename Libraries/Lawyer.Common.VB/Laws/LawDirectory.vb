Namespace Laws

    Public Class LawDirectory


        Private _ldID As Int32
        Private _ldName As String
        Private _ldParent As Int32


        Private _Childs As Int32

        Public Property Childs() As Int32
            Get
                Return _Childs
            End Get
            Set(ByVal value As Int32)
                _Childs = value
            End Set
        End Property


        Public Property ldID() As Int32
            Get
                Return _ldID
            End Get
            Set(ByVal value As Int32)
                _ldID = value
            End Set
        End Property


        Public Property ldName() As String
            Get
                Return _ldName
            End Get
            Set(ByVal value As String)
                _ldName = value
            End Set
        End Property


        Public Property ldParent() As Int32
            Get
                Return _ldParent
            End Get
            Set(ByVal value As Int32)
                _ldParent = value
            End Set
        End Property


    End Class

End Namespace
