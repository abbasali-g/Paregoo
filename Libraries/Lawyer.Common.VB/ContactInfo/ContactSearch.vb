Namespace ContactInfo
    Public Class ContactSearch

        Private _custFullName As String
        Private _custID As String
        Private _custType As Int16
        Private _imageExtension As String
        Private _imageUpdateDate As String
        Private _cell As String
        Private _phone1 As String
        Private _phone2 As String


        Public Property custFullName() As String
            Get
                Return _custFullName
            End Get
            Set(ByVal value As String)
                _custFullName = value
            End Set
        End Property

        Public Property custCellphone() As String
            Get
                Return _cell
            End Get
            Set(ByVal value As String)
                _cell = value
            End Set
        End Property

        Public Property custphone1() As String
            Get
                Return _phone1
            End Get
            Set(ByVal value As String)
                _phone1 = value
            End Set
        End Property

        Public Property custphone2() As String
            Get
                Return _phone2
            End Get
            Set(ByVal value As String)
                _phone2 = value
            End Set
        End Property


        Public Property custID() As String
            Get
                Return _custID
            End Get
            Set(ByVal value As String)
                _custID = value
            End Set
        End Property


        Public Property custType() As Int16
            Get
                Return _custType
            End Get
            Set(ByVal value As Int16)
                _custType = value
            End Set
        End Property


        Public Property imageExtension() As String
            Get
                Return _imageExtension
            End Get
            Set(ByVal value As String)
                _imageExtension = value
            End Set
        End Property


        Public Property imageUpdateDate() As String
            Get
                Return _imageUpdateDate
            End Get
            Set(ByVal value As String)
                _imageUpdateDate = value
            End Set
        End Property

    End Class
End Namespace

