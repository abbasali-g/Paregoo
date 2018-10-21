Namespace Laws

    Public Class LawOnSet


        Private _ldID As Int32
        Private _ldName As String
        Private _ldParent As Int32

        Private _ltid As Int32
        Private _lawid As Int32
        Private _lsid As Int32
        Private _lawdetid As Int32

        Private _lawTitle As String
        Private _lawDetTitle As String
        Private _lawDetContent As String


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


        Public Property ltid() As Int32
            Get
                Return _ltid
            End Get
            Set(ByVal value As Int32)
                _ltid = value
            End Set
        End Property


        Public Property lawid() As Int32
            Get
                Return _lawid
            End Get
            Set(ByVal value As Int32)
                _lawid = value
            End Set
        End Property


        Public Property lsid() As Int32
            Get
                Return _lsid
            End Get
            Set(ByVal value As Int32)
                _lsid = value
            End Set
        End Property


        Public Property lawdetid() As Int32
            Get
                Return _lawdetid
            End Get
            Set(ByVal value As Int32)
                _lawdetid = value
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


        Public Property lawDetContent() As String
            Get
                Return _lawDetContent
            End Get
            Set(ByVal value As String)
                _lawDetContent = value
            End Set
        End Property






    End Class

End Namespace
