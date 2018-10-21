Namespace Laws


    Public Class LawDetails


        Private _lawDetID As Int32
        Private _lawID As Int32
        Private _lawDetTitle As String
        Private _lawDetContent As String
        Private _lawDetType As String
        Private _lawDetOwner As String
        Private _lawDetParent As Int16
        Private _lawDetSubParent As Int16


        Public Property lawDetID() As Int32
            Get
                Return _lawDetID
            End Get
            Set(ByVal value As Int32)
                _lawDetID = value
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


        Public Property lawDetTitle() As String
            Get
                Return _lawDetTitle
            End Get
            Set(ByVal value As String)
                _lawDetTitle = value
            End Set
        End Property


        Public Property lawDetContent() As String
            Get
                Return _lawDetContent
            End Get
            Set(ByVal value As String)
                _lawDetContent = value
            End Set
        End Property


        Public Property lawDetType() As String
            Get
                Return _lawDetType
            End Get
            Set(ByVal value As String)
                _lawDetType = value
            End Set
        End Property


        Public Property lawDetOwner() As String
            Get
                Return _lawDetOwner
            End Get
            Set(ByVal value As String)
                _lawDetOwner = value
            End Set
        End Property


        Public Property lawDetParent() As Int16
            Get
                Return _lawDetParent
            End Get
            Set(ByVal value As Int16)
                _lawDetParent = value
            End Set
        End Property


        Public Property lawDetSubParent() As Int16
            Get
                Return _lawDetSubParent
            End Get
            Set(ByVal value As Int16)
                _lawDetSubParent = value
            End Set
        End Property




    End Class

End Namespace
