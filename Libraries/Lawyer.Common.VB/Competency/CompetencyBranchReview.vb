Namespace Competencys

    Public Class CompetencyBranchReview

        Private _tsbType As Int16
        Private _tsbName As String

        Public Property tsbType() As SByte
            Get
                Return _tsbType
            End Get
            Set(ByVal value As SByte)
                _tsbType = value
            End Set
        End Property


        Public Property tsbName() As String
            Get
                Return _tsbName
            End Get
            Set(ByVal value As String)
                _tsbName = value
            End Set
        End Property

    End Class

End Namespace

