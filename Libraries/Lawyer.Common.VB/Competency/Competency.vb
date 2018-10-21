Namespace Competencys

    Public Class Competency


        Private _tsid As Guid
        Private _tsState As String
        Private _tsProvince As String
        Private _tsName As String
        Private _tsType As Int16

        Private _tsTypeEnums As String ' for enums

        Private _tsHokmType As String
        Private _tsMapField As String
        Private _tsDescription As String


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


        Public Property tsType() As SByte
            Get
                Return _tsType
            End Get
            Set(ByVal value As SByte)
                _tsType = value
            End Set
        End Property


        Public Property tsTypeEnums() As String
            Get
                Return _tsTypeEnums
            End Get
            Set(ByVal value As String)
                _tsTypeEnums = value
            End Set
        End Property

        Public Property tsHokmType() As String
            Get
                Return _tsHokmType
            End Get
            Set(ByVal value As String)
                _tsHokmType = value
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




    End Class

End Namespace
