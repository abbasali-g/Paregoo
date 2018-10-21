Namespace Timing

    Public Class TimingSearch

        Private _timeID As String
        Private _tpID As String
        Private _timeTitle As String
        Private _custFullName As String
        Private _timeDate As Int32
        Private _timeTime As String
        Private _timeDone As Boolean
        Private _fileCaseNumber As String
        Private _timeSms As Int16
        Private _timeNet As Int16

        Public Property fileCaseNumber() As String
            Get
                Return _fileCaseNumber
            End Get
            Set(ByVal value As String)
                _fileCaseNumber = value
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

        Public ReadOnly Property timeDateStringFormat() As String
            Get
                Dim d As String = _timeDate.ToString
                Return d.Substring(0, 4) & "/" & d.Substring(4, 2) & "/" & d.Substring(6, 2)
            End Get
          
        End Property

        Public Property tpID() As String
            Get
                Return _tpID
            End Get
            Set(ByVal value As String)
                _tpID = value
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

        Public Property custFullName() As String
            Get
                Return _custFullName
            End Get
            Set(ByVal value As String)
                _custFullName = value
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

        Public Property timeDone() As Boolean
            Get
                Return _timeDone
            End Get
            Set(ByVal value As Boolean)
                _timeDone = value
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

        Public ReadOnly Property timeFullDate() As String
            Get
                Dim d As String = _timeDate.ToString
                d = d.Substring(0, 4) & "/" & d.Substring(4, 2) & "/" & d.Substring(6, 2)

                Return CStr(d) & "-" & timeTime

            End Get

        End Property
        Public Property timeSms() As Int16
            Get
                Return _timeSms
            End Get
            Set(ByVal value As Int16)
                _timeSms = value
            End Set
        End Property

        Public Property timeNet() As Int16
            Get
                Return _timeNet
            End Get
            Set(ByVal value As Int16)
                _timeNet = value
            End Set
        End Property


    End Class

End Namespace

