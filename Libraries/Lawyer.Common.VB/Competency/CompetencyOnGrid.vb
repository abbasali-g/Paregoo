Namespace Competencys

    Public Class CompetencyOnGrid


        Private _tsid As Guid
        Private _tsState As String
        Private _tsProvince As String
        Private _tsName As String
        Private _tsMapField As String
        Private _tsDescription As String

        Private _tsbID As Guid
        Private _tsbName As String


        Public Property tsid() As Guid
            Get
                Return _tsid
            End Get
            Set(ByVal value As Guid)
                _tsid = value
            End Set
        End Property

        Public Property tsState() As String
            Get
                Return _tsState
            End Get
            Set(ByVal value As String)
                _tsState = value
            End Set
        End Property

        Public Property tsProvince() As String
            Get
                Return _tsProvince
            End Get
            Set(ByVal value As String)
                _tsProvince = value
            End Set
        End Property

        Public Property tsName() As String
            Get
                Return _tsName
            End Get
            Set(ByVal value As String)
                _tsName = value
            End Set
        End Property

        Public Property tsMapField() As String
            Get
                Return _tsMapField
            End Get
            Set(ByVal value As String)
                _tsMapField = value
            End Set
        End Property

        Public Property tsDescription() As String
            Get
                Return _tsDescription
            End Get
            Set(ByVal value As String)
                _tsDescription = value
            End Set
        End Property

        Public Property tsbID() As Guid
            Get
                Return _tsbID
            End Get
            Set(ByVal value As Guid)
                _tsbID = value
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
