Namespace Docs
    Public Class FileCaseResult

        Private _fileCaseID As String
        Private _fileCaseResult As Int16?
        Private _filecaseResultDetail As Int16?
        Private _fileCaseGhararType As String
        Private _fileCaseCost As Double?

        Public Property fileCaseID() As String
            Get
                Return _fileCaseID
            End Get
            Set(ByVal value As String)
                _fileCaseID = value
            End Set
        End Property


        Public Property fileCaseCost() As Double?
            Get
                Return _fileCaseCost
            End Get
            Set(ByVal value As Double?)
                _fileCaseCost = value
            End Set
        End Property

        Public Property fileCaseGhararType() As String
            Get
                Return _fileCaseGhararType
            End Get
            Set(ByVal value As String)
                _fileCaseGhararType = value
            End Set
        End Property


        Public Property fileCaseResult() As Int16?
            Get
                Return _fileCaseResult
            End Get
            Set(ByVal value As Int16?)
                _fileCaseResult = value
            End Set
        End Property


        Public Property filecaseResultDetail() As Int16?
            Get
                Return _filecaseResultDetail
            End Get
            Set(ByVal value As Int16?)
                _filecaseResultDetail = value
            End Set
        End Property
    End Class
End Namespace

