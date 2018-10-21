Namespace Timing

    Public Class MoshavereSearch

        Private _timeSourceCustID As String
        Private _tpTargetCustID As String
        Private _timeID As String
        Private _timeTitle As String
        Private _timeText As String
        Private _timeType As Int16
        Private _tpid As String
        Private _timeTime As String
        Private _timeDate As String
        Private _financeAmount As Double
        Private _financeCustID As String
        Private _reciever As String
        Private _sender As String
        Private _movakel As String
        Private _timeDone As Boolean
        Private _timeSms As Int16
        Private _timeNet As Int16

        Public Property timeDone() As Boolean
            Get
                Return _timeDone
            End Get
            Set(ByVal value As Boolean)
                _timeDone = value
            End Set
        End Property

        Public ReadOnly Property timeFullDate() As String
            Get
                Return timeDate & "-" & timeTime
            End Get
           
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


        Public Property timeText() As String
            Get
                Return _timeText
            End Get
            Set(ByVal value As String)
                _timeText = value
            End Set
        End Property


        Public Property timeType() As Int16
            Get
                Return _timeType
            End Get
            Set(ByVal value As Int16)
                _timeType = value
            End Set
        End Property


        Public Property tpid() As String
            Get
                Return _tpid
            End Get
            Set(ByVal value As String)
                _tpid = value
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


        Public Property timeDate() As String
            Get
                Return _timeDate.Substring(0, 4) & "/" & _timeDate.Substring(4, 2) & "/" & _timeDate.Substring(6, 2)

            End Get
            Set(ByVal value As String)
                _timeDate = value
            End Set
        End Property


        Public Property financeAmount() As Double
            Get
                Return _financeAmount
            End Get
            Set(ByVal value As Double)
                _financeAmount = value
            End Set
        End Property


        Public Property financeCustID() As String
            Get
                Return _financeCustID
            End Get
            Set(ByVal value As String)
                _financeCustID = value
            End Set
        End Property


        Public Property reciever() As String
            Get
                Return _reciever
            End Get
            Set(ByVal value As String)
                _reciever = value
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


        Public Property movakel() As String
            Get
                Return _movakel
            End Get
            Set(ByVal value As String)
                _movakel = value
            End Set
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

