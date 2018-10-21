Namespace Competencys

    Public Class CompetencyBranch


        Private _tsbID As Guid
        Private _tsid As Guid
        Private _tsbType As Int16
        Private _tsbName As String


        Public Property tsbID() As Guid
            Get
                Return _tsbID
            End Get
            Set(ByVal value As Guid)
                _tsbID = value
            End Set
        End Property


        Public Property tsid() As Guid
            Get
                Return _tsid
            End Get
            Set(ByVal value As Guid)
                _tsid = value
            End Set
        End Property


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
