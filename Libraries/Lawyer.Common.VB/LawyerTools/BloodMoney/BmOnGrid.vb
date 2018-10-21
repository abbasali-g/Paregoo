Namespace BloodMoneys

    Public Class BmOnGrid


        Private _bmName As String
        Private _QP As String
        Private _CalculateValue As Long

        Public Property bmName() As String
            Get
                Return _bmName
            End Get
            Set(ByVal value As String)
                _bmName = value
            End Set
        End Property


        Public Property QP() As String
            Get
                Return _QP
            End Get
            Set(ByVal value As String)
                _QP = value
            End Set
        End Property


        Public Property CalculateValue() As Long
            Get
                Return _CalculateValue
            End Get
            Set(ByVal value As Long)
                _CalculateValue = value
            End Set
        End Property


    End Class

End Namespace
