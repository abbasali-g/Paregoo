Namespace Books


    Public Class Book


        Private _libID As Guid
        Private _libName As String
        Private _libSubject As String
        Private _libSummary As String
        Private _libFile As Byte()


        Private _libFileName As String

        Public Property libFileName() As String
            Get
                Return _libFileName
            End Get
            Set(ByVal value As String)
                _libFileName = value
            End Set
        End Property


        Private _HasFile As Boolean

        Public Property HasFile() As Boolean
            Get
                Return _HasFile
            End Get
            Set(ByVal value As Boolean)
                _HasFile = value
            End Set
        End Property






        Public Property libID() As Guid
            Get
                Return _libID
            End Get
            Set(ByVal value As Guid)
                _libID = value
            End Set
        End Property


        Public Property libName() As String
            Get
                Return _libName
            End Get
            Set(ByVal value As String)
                _libName = value
            End Set
        End Property


        Public Property libSubject() As String
            Get
                Return _libSubject
            End Get
            Set(ByVal value As String)
                _libSubject = value
            End Set
        End Property


        Public Property libSummary() As String
            Get
                Return _libSummary
            End Get
            Set(ByVal value As String)
                _libSummary = value
            End Set
        End Property


        Public Property libFile() As Byte()
            Get
                Return _libFile
            End Get
            Set(ByVal value As Byte())
                _libFile = value
            End Set
        End Property



    End Class


End Namespace