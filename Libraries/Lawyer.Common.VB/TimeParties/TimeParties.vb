Namespace TimeParties
    Public Class TimeParties
        Private _tpID As String
        Private _timeID As String
        Private _tpTargetCustID As String
        Private _timeDate As Int32
        Private _timeTime As String
        Private _timeReminderBefore As String
        Private _timeStatus As String
        Private _timeActualTime As String
        Private _timeDone As Boolean
        Private _timeDuration As String
        Private _timeEnd As String
        Private _timeReminderType As Int16?
        Private _timeActualDate As String


        Public Property timeActualDate() As String
            Get
                Return _timeActualDate
            End Get
            Set(ByVal value As String)
                _timeActualDate = value
            End Set
        End Property

        Public Property tpID() As String
            Get
                Return _tpID
            End Get
            Set(ByVal value As String)
                _tpID = value
            End Set
        End Property

        Public Property timeReminderType() As Int16?
            Get
                Return _timeReminderType
            End Get
            Set(ByVal value As Int16?)
                _timeReminderType = value
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


        Public Property timeEnd() As String
            Get
                Return _timeEnd
            End Get
            Set(ByVal value As String)
                _timeEnd = value
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


        Public Property timeReminderBefore() As String
            Get
                Return _timeReminderBefore
            End Get
            Set(ByVal value As String)
                _timeReminderBefore = value
            End Set
        End Property


        Public Property timeStatus() As String
            Get
                Return _timeStatus
            End Get
            Set(ByVal value As String)
                _timeStatus = value
            End Set
        End Property


        Public Property timeActualTime() As String
            Get
                Return _timeActualTime
            End Get
            Set(ByVal value As String)
                _timeActualTime = value
            End Set
        End Property


        Public Property timeDone() As Boolean
            Get
                Return _timeDone
            End Get
            Set(ByVal value As Boolean)
                _timeDone = value
            End Set
        End Property


        Public Property timeDuration() As String
            Get
                Return _timeDuration
            End Get
            Set(ByVal value As String)
                _timeDuration = value
            End Set
        End Property

    End Class

End Namespace

