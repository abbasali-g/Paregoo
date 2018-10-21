Namespace FileCaseArea
    Public Class AreaReview

        Private _fileCaseAreaName As String
        Private _fileCaseAreaID As String


        Public Property fileCaseAreaName() As String
            Get
                Return _fileCaseAreaName
            End Get
            Set(ByVal value As String)
                _fileCaseAreaName = value
            End Set
        End Property

        Public Property fileCaseAreaID() As String
            Get
                Return _fileCaseAreaID
            End Get
            Set(ByVal value As String)
                _fileCaseAreaID = value
            End Set
        End Property

    End Class
End Namespace

