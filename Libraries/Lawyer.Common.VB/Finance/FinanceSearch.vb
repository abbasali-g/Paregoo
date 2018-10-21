Namespace Shaxes

    Public Class FinanceSearch
        Private _financeAmount As Double
        Private _financeID As String
        Private _financeType As String
        Private _financeDesc As String
        Private _FileCaseNumber As String
        Private _fileCaseID As String
        Private _custFullName As String
        Private _financeChequeSerial As String
        Private _BranchName As String
        Private _financePaymentDate As String
        Private _financePaymentTime As String
        Private _financePaymentType As Int16?
        Private _bankName As String
        Private _finaceTypeID As String

        Public Property finaceTypeID() As String
            Get
                Return _finaceTypeID
            End Get
            Set(ByVal value As String)
                _finaceTypeID = value
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



        Public Property financePaymentType() As Int16?
            Get
                Return _financePaymentType
            End Get
            Set(ByVal value As Int16?)
                _financePaymentType = value
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


        Public Property financeType() As String
            Get
                If _financePaymentType.HasValue Then

                    If _financePaymentType = 0 Then

                        Return "نقدی"

                    Else
                        Return "چک"

                    End If

                Else

                    Return _financeType

                End If
            End Get
            Set(ByVal value As String)
                _financeType = value
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


        Public Property FileCaseNumber() As String
            Get
                Return _FileCaseNumber
            End Get
            Set(ByVal value As String)
                _FileCaseNumber = value
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


        Public Property custFullName() As String
            Get
                Return _custFullName
            End Get
            Set(ByVal value As String)
                _custFullName = value
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


        Public Property BranchName() As String
            Get
                Return _BranchName
            End Get
            Set(ByVal value As String)
                _BranchName = value
            End Set
        End Property



        Public Property bankName() As String
            Get
                Return _bankName
            End Get
            Set(ByVal value As String)
                _bankName = value
            End Set
        End Property

        Public ReadOnly Property AmountHazine() As String
            Get
                If _financeAmount < 0 Then

                    Return -_financeAmount

                Else

                    Return 0

                End If

            End Get

        End Property


        Public ReadOnly Property Shobe() As String

            Get

                Dim str As String = String.Empty

                If _BranchName <> String.Empty Then

                    Return _bankName & "-" & _BranchName

                Else

                    Return _bankName

                End If

            End Get

        End Property

        Public ReadOnly Property AmountDaryafti() As String
            Get
                If _financeAmount >= 0 Then

                    Return _financeAmount

                Else

                    Return 0

                End If

            End Get

        End Property

        Public Property financePaymentDate() As String
            Get
                Return _financePaymentDate.Substring(0, 4) + "/" + _financePaymentDate.Substring(4, 2) + "/" + _financePaymentDate.Substring(6, 2)
            End Get
            Set(ByVal value As String)
                _financePaymentDate = value
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
    End Class

End Namespace

