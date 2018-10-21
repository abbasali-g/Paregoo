Namespace FileCaseArea
    Public Class Area

        Private _fileCaseAreaID As String
        Private _fileCaseAreaName As String
        Private _fileCaseAreaChilds As String
        Private _fileCaseAreaTel As String
        Private _fileCaseAreaAddress As String


        Public Property fileCaseAreaID() As String
            Get
                Return _fileCaseAreaID
            End Get
            Set(ByVal value As String)
                _fileCaseAreaID = value
            End Set
        End Property


        Public Property fileCaseAreaName() As String
            Get
                Return _fileCaseAreaName
            End Get
            Set(ByVal value As String)
                _fileCaseAreaName = value
            End Set
        End Property


        Public Property fileCaseAreaChilds() As String
            Get
                Return _fileCaseAreaChilds
            End Get
            Set(ByVal value As String)
                _fileCaseAreaChilds = value
            End Set
        End Property


        Public Property fileCaseAreaTel() As String
            Get
                Return _fileCaseAreaTel
            End Get
            Set(ByVal value As String)
                _fileCaseAreaTel = value
            End Set
        End Property


        Public Property fileCaseAreaAddress() As String
            Get
                Return _fileCaseAreaAddress
            End Get
            Set(ByVal value As String)
                _fileCaseAreaAddress = value
            End Set
        End Property


    End Class
End Namespace

