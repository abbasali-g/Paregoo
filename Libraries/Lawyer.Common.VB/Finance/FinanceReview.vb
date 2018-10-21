Namespace Shaxes
    Public Class FinanceReview
        Private _financeID As String
        Private _fileID As String
        Private _fileCaseID As String
        Private _finaceTypeID As String
        Private _timeID As String
        Private _financeCustID As String


        Public Property financeID() As String
            Get
                Return _financeID
            End Get
            Set(ByVal value As String)
                _financeID = value
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


        Public Property finaceTypeID() As String
            Get
                Return _finaceTypeID
            End Get
            Set(ByVal value As String)
                _finaceTypeID = value
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


        Public Property financeCustID() As String
            Get
                Return _financeCustID
            End Get
            Set(ByVal value As String)
                _financeCustID = value
            End Set
        End Property

    End Class
End Namespace

