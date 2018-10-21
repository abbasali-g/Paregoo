Imports Lawyer.Common.VB.Timing

Namespace TimeParties

    Public Class TimePartiesReview
        Private _timeDate As String
        Private _timeActualTime As String
        Private _timeDone As Boolean
        Private _tpID As String
        Private _timeTitle As String
        Private _timeType As Int16
        Private _timeTime As String


        Private _timeTypeName As String
        Public Property timeTypeName() As String
            Get
                Return _timeTypeName
            End Get
            Set(ByVal value As String)
                _timeTypeName = value
            End Set
        End Property



        'Public ReadOnly Property timeTypeName() As String
        '    Get

        '        Return TimingManager.GetTypeName(_timeType)

        '    End Get

        'End Property

        Public ReadOnly Property timeFullDate() As String
            Get

                Return CStr(_timeDate) & "-" & timeTime

            End Get

        End Property

        Public Property timeDate() As String
            Get
                Return _timeDate.Substring(0, 4) & "/" & _timeDate.Substring(4, 2) & "/" & _timeDate.Substring(6, 2)
            End Get
            Set(ByVal value As String)
                _timeDate = value
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

        Public Property timeTime() As String
            Get
                Return _timeTime
            End Get
            Set(ByVal value As String)
                _timeTime = value
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


        Public Property timeType() As Int16
            Get
                Return _timeType
            End Get
            Set(ByVal value As Int16)
                _timeType = value
            End Set
        End Property

    End Class
End Namespace

