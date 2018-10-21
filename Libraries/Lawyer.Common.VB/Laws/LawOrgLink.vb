Namespace Laws

    Public Class LawOrgLink

        Private _lawOrgID As Int32
        Private _lawID As Int32
        Private _lawOrgNameID As Int32


        Public Property lawOrgID() As Int32
            Get
                Return _lawOrgID
            End Get
            Set(ByVal value As Int32)
                _lawOrgID = value
            End Set
        End Property


        Public Property lawID() As Int32
            Get
                Return _lawID
            End Get
            Set(ByVal value As Int32)
                _lawID = value
            End Set
        End Property


        Public Property lawOrgNameID() As Int32
            Get
                Return _lawOrgNameID
            End Get
            Set(ByVal value As Int32)
                _lawOrgNameID = value
            End Set
        End Property




    End Class

End Namespace
