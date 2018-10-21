Namespace LawTypes



    Public Class LawType
        Private _lawTypeID As Int16
        Private _lawTypeName As String
        Private _lawTypeLR As Int16


        Public Property lawTypeID() As Int16
            Get
                Return _lawTypeID
            End Get
            Set(ByVal value As Int16)
                _lawTypeID = value
            End Set
        End Property


        Public Property lawTypeName() As String
            Get
                Return _lawTypeName
            End Get
            Set(ByVal value As String)
                _lawTypeName = value
            End Set
        End Property


        Public Property lawTypeLR() As Int16
            Get
                Return _lawTypeLR
            End Get
            Set(ByVal value As Int16)
                _lawTypeLR = value
            End Set
        End Property

    End Class

End Namespace