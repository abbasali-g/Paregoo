Namespace Docs
    Public Class FileCaseNumber

        Private _fileCaseNumberInSystem As String
        Private _fileCaseNumberInCourt As String
        Private _fileCaseNumberInBranch As String
        ' '' ''Private _fileCaseNumberYear As String


        Public Property fileCaseNumberInSystem() As String
            Get
                Return _fileCaseNumberInSystem
            End Get
            Set(ByVal value As String)
                _fileCaseNumberInSystem = value
            End Set
        End Property


        Public Property fileCaseNumberInCourt() As String
            Get
                Return _fileCaseNumberInCourt
            End Get
            Set(ByVal value As String)
                _fileCaseNumberInCourt = value
            End Set
        End Property


        Public Property fileCaseNumberInBranch() As String
            Get
                Return _fileCaseNumberInBranch
            End Get
            Set(ByVal value As String)
                _fileCaseNumberInBranch = value
            End Set
        End Property


        ' '' ''Public Property fileCaseNumberYear() As String
        ' '' ''    Get
        ' '' ''        Return _fileCaseNumberYear
        ' '' ''    End Get
        ' '' ''    Set(ByVal value As String)
        ' '' ''        _fileCaseNumberYear = value
        ' '' ''    End Set
        ' '' ''End Property

    End Class

End Namespace

