Namespace LawKeyWords


    Public Class LawKeyWord


        Private _lawKeywordID As Int32
        Private _lawKeywordName As String
        Private _lawID As Int32
        Private _lawKeywordOwner As String
        Private _lawKeywordLR As Int16


        Public Property lawKeywordID() As Int32
            Get
                Return _lawKeywordID
            End Get
            Set(ByVal value As Int32)
                _lawKeywordID = value
            End Set
        End Property


        Public Property lawKeywordName() As String
            Get
                Return _lawKeywordName
            End Get
            Set(ByVal value As String)
                _lawKeywordName = value
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


        Public Property lawKeywordOwner() As String
            Get
                Return _lawKeywordOwner
            End Get
            Set(ByVal value As String)
                _lawKeywordOwner = value
            End Set
        End Property


        Public Property lawKeywordLR() As Int16
            Get
                Return _lawKeywordLR
            End Get
            Set(ByVal value As Int16)
                _lawKeywordLR = value
            End Set
        End Property




    End Class


End Namespace
