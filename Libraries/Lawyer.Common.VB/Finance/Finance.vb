Namespace Shaxes
    Public Class Finance
        Private _fileID As String
        Private _fileCaseID As String
        Private _financeBankID As String
        Private _financeBranchID As String
        Private _financeID As String
        Private _finaceTypeID As String
        Private _timeID As String
        Private _financePaymentDate As Int32
        Private _financePaymentType As String
        Private _financeAmount As Double
        Private _financePaymentTime As String
        Private _financeChequeSerial As String
        Private _financeChequeDate As String
        Private _financeCustID As String
        Private _financeDesc As String


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


        Public Property financeDesc() As String
            Get
                Return _financeDesc
            End Get
            Set(ByVal value As String)
                _financeDesc = value
            End Set
        End Property

        Public Property financeBankID() As String
            Get
                Return _financeBankID
            End Get
            Set(ByVal value As String)
                _financeBankID = value
            End Set
        End Property


        Public Property financeBranchID() As String
            Get
                Return _financeBranchID
            End Get
            Set(ByVal value As String)
                _financeBranchID = value
            End Set
        End Property


        Public Property financeID() As String
            Get
                Return _financeID
            End Get
            Set(ByVal value As String)
                _financeID = value
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


        Public Property financePaymentDate() As Int32
            Get
                Return _financePaymentDate
            End Get
            Set(ByVal value As Int32)
                _financePaymentDate = value
            End Set
        End Property


        Public Property financePaymentType() As String
            Get
                Return _financePaymentType
            End Get
            Set(ByVal value As String)
                _financePaymentType = value
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


        Public Property financePaymentTime() As String
            Get
                Return _financePaymentTime
            End Get
            Set(ByVal value As String)
                _financePaymentTime = value
            End Set
        End Property


        Public Property financeChequeSerial() As String
            Get
                Return _financeChequeSerial
            End Get
            Set(ByVal value As String)
                _financeChequeSerial = value
            End Set
        End Property


        Public Property financeChequeDate() As String
            Get
                Return _financeChequeDate
            End Get
            Set(ByVal value As String)
                _financeChequeDate = value
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

