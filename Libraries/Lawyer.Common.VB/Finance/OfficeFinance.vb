Public Class OfficeFinance

    Private _financeId As String
    Private _finaceTypeID As String
    Private _financeDesc As String
    Private _financePaymentDate As Int32
    Private _financeAmount As Double
    Private _custId As String


    Public Property financeId() As String
        Get
            Return _financeId
        End Get
        Set(ByVal value As String)
            _financeId = value
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


    Public Property financeDesc() As String
        Get
            Return _financeDesc
        End Get
        Set(ByVal value As String)
            _financeDesc = value
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


    Public Property financeAmount() As Double
        Get
            Return _financeAmount
        End Get
        Set(ByVal value As Double)
            _financeAmount = value
        End Set
    End Property


    Public Property custId() As String
        Get
            Return _custId
        End Get
        Set(ByVal value As String)
            _custId = value
        End Set
    End Property

End Class
