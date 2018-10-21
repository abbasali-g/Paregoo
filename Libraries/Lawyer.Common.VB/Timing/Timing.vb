Namespace Timing
    Public Class Timing
        Private _timeID As String
        Private _fileID As String
        Private _fileCaseID As String
        Private _timeType As Int16
        Private _timeText As String
        Private _timeSourceCustID As String
        Private _timeTitle As String
        Private _timingNo As String
        Private _timeSms As Int16
        Private _timeNet As Int16


        Public Property timingNo() As String
            Get
                Return _timingNo
            End Get
            Set(ByVal value As String)
                _timingNo = value
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

        Public Property fileID() As String
            Get
                Return _fileID
            End Get
            Set(ByVal value As String)
                _fileID = value
            End Set
        End Property

        Public Property fileCaseID() As String
            Get
                Return _fileCaseID
            End Get
            Set(ByVal value As String)
                _fileCaseID = value
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

        Public Property timeTitle() As String
            Get
                Return _timeTitle
            End Get
            Set(ByVal value As String)
                _timeTitle = value
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

