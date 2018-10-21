Namespace Laws

    Public Class Law

        Private _lawID As Int32
        Private _lawTitle As String
        Private _lawContent As String
        Private _lawTypeID As Int16
        Private _lawPassedDate As Int32
        Private _lawPublishedDate As Int32
        Private _lawPublicationNumber As String
        Private _lawNote As String
        Private _lawMansoukh As Int16
        Private _lawOwner As String
        Private _lawLRType As Int16
        Private _lawLRText As String
        Private _lawCatID As Int16
        Private _lawMansoukhDescription As String


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


        Public Property lawContent() As String
            Get
                Return _lawContent
            End Get
            Set(ByVal value As String)
                _lawContent = value
            End Set
        End Property


        Public Property lawTypeID() As Int16
            Get
                Return _lawTypeID
            End Get
            Set(ByVal value As Int16)
                _lawTypeID = value
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


        Public Property lawPublishedDate() As Int32
            Get
                Return _lawPublishedDate
            End Get
            Set(ByVal value As Int32)
                _lawPublishedDate = value
            End Set
        End Property


        Public Property lawPublicationNumber() As String
            Get
                Return _lawPublicationNumber
            End Get
            Set(ByVal value As String)
                _lawPublicationNumber = value
            End Set
        End Property


        Public Property lawNote() As String
            Get
                Return _lawNote
            End Get
            Set(ByVal value As String)
                _lawNote = value
            End Set
        End Property


        Public Property lawMansoukh() As Int16
            Get
                Return _lawMansoukh
            End Get
            Set(ByVal value As Int16)
                _lawMansoukh = value
            End Set
        End Property


        Public Property lawOwner() As String
            Get
                Return _lawOwner
            End Get
            Set(ByVal value As String)
                _lawOwner = value
            End Set
        End Property


        Public Property lawLRType() As Int16
            Get
                Return _lawLRType
            End Get
            Set(ByVal value As Int16)
                _lawLRType = value
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


        Public Property lawCatID() As Int16
            Get
                Return _lawCatID
            End Get
            Set(ByVal value As Int16)
                _lawCatID = value
            End Set
        End Property


        Public Property lawMansoukhDescription() As String
            Get
                Return _lawMansoukhDescription
            End Get
            Set(ByVal value As String)
                _lawMansoukhDescription = value
            End Set
        End Property

    End Class


End Namespace