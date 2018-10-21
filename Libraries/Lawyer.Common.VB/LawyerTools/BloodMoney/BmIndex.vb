Namespace BloodMoneys

    Public Class BmIndex


        Private _bmiID As Int32
        Private _bmiName As String
        Private _bmiValue As Single
        Private _bmiQuantity As Single
        Private _bmiYear As Int16
        Private _bmiType As Int16


        Public Property bmiID() As Int32
            Get
                Return _bmiID
            End Get
            Set(ByVal value As Int32)
                _bmiID = value
            End Set
        End Property


        Public Property bmiName() As String
            Get
                Return _bmiName
            End Get
            Set(ByVal value As String)
                _bmiName = value
            End Set
        End Property


        Public Property bmiValue() As Single
            Get
                Return _bmiValue
            End Get
            Set(ByVal value As Single)
                _bmiValue = value
            End Set
        End Property


        Public Property bmiQuantity() As Single
            Get
                Return _bmiQuantity
            End Get
            Set(ByVal value As Single)
                _bmiQuantity = value
            End Set
        End Property


        Public Property bmiYear() As Int16
            Get
                Return _bmiYear
            End Get
            Set(ByVal value As Int16)
                _bmiYear = value
            End Set
        End Property


        Public Property bmiType() As Int16
            Get
                Return _bmiType
            End Get
            Set(ByVal value As Int16)
                _bmiType = value
            End Set
        End Property

    End Class




End Namespace
