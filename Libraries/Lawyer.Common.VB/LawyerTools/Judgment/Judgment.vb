Namespace Judgments

    Public Class Judgment


        Private _tdID As Int32
        Private _tdLevelName As String
        Private _tdLevelFixedValue As Single


        Public Property tdID() As Int32
            Get
                Return _tdID
            End Get
            Set(ByVal value As Int32)
                _tdID = value
            End Set
        End Property


        Public Property tdLevelName() As String
            Get
                Return _tdLevelName
            End Get
            Set(ByVal value As String)
                _tdLevelName = value
            End Set
        End Property


        Public Property tdLevelFixedValue() As Single
            Get
                Return _tdLevelFixedValue
            End Get
            Set(ByVal value As Single)
                _tdLevelFixedValue = value
            End Set
        End Property


    End Class

End Namespace
