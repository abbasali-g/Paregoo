Namespace TimeParties

    Public Class KartablDetail
        Private _timeText As String
        Private _timeTitle As String
        Private _timeDate As Int32
        Private _timeTime As String
        Private _sender As String
        Private _timeID As String
        Private _timeSourceCustID As String
        Private _tpTargetCustID As String

               Public Property timeText() As String
            Get
                Return _timeText
            End Get
            Set(ByVal value As String)
                _timeText = value
            End Set
        End Property

        Public Property timeSourceCustID() As String
            Get
                Return _timeSourceCustID
            End Get
            Set(ByVal value As String)
                _timeSourceCustID = value
            End Set
        End Property


        Public Property tpTargetCustID() As String
            Get
                Return _tpTargetCustID
            End Get
            Set(ByVal value As String)
                _tpTargetCustID = value
            End Set
        End Property

        Public Property timeID() As String
            Get
                Return _timeID
            End Get
            Set(ByVal value As String)
                _timeID = value
            End Set
        End Property

        Public Property timeTitle() As String
            Get
                Return _timeTitle
            End Get
            Set(ByVal value As String)
                _timeTitle = value
            End Set
        End Property


        Public Property timeDate() As Int32
            Get
                Return _timeDate
            End Get
            Set(ByVal value As Int32)
                _timeDate = value
            End Set
        End Property


        Public Property timeTime() As String
            Get
                Return _timeTime
            End Get
            Set(ByVal value As String)
                _timeTime = value
            End Set
        End Property


        Public Property sender() As String
            Get
                Return _sender
            End Get
            Set(ByVal value As String)
                _sender = value
            End Set
        End Property
    End Class

End Namespace

