Namespace Timing

    Public Class TimingReview
        Private _timeID As Int32
        Private _description As String


        Public Property timeID() As Int32
            Get
                Return _timeID
            End Get
            Set(ByVal value As Int32)
                _timeID = value
            End Set
        End Property


        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                _description = value
            End Set
        End Property

    End Class

End Namespace

