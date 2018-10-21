Namespace Laws

    Public Class LawCat


        Private _lawCatID As Int32
        Private _lawCatName As String
        Private _lawCatLR As Int16


        Public Property lawCatID() As Int32
            Get
                Return _lawCatID
            End Get
            Set(ByVal value As Int32)
                _lawCatID = value
            End Set
        End Property


        Public Property lawCatName() As String
            Get
                Return _lawCatName
            End Get
            Set(ByVal value As String)
                _lawCatName = value
            End Set
        End Property


        Public Property lawCatLR() As Int16
            Get
                Return _lawCatLR
            End Get
            Set(ByVal value As Int16)
                _lawCatLR = value
            End Set
        End Property

    End Class


End Namespace
