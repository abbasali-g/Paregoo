Namespace ContactInfo
    Public Class Contact
        Private _custID As String
        Private _custFullName As String
        Private _custCompanyName As String
        Private _custJobTitle As String
        Private _custRegisterationNumber As String
        Private _custIDNumber As String
        Private _custFatherName As String
        Private _custBthDay As String
        Private _custEmailOne As String
        Private _custHomeTel As String
        Private _custOfficeTel As String
        Private _custCellPhone As String
        Private _custFax As String
        Private _custAddress As String
        Private _custType As Int16
        Private _custDescription As String
        Private _custUserName As String
        Private _custPassword As String
        Private _custIsSysUser As Boolean
        Private _custIsAdminUser As Boolean
        Private _imageUpdateDate As String
        Private _imageExtension As String
        Private _custSaltkey As String
        Private _custNetUser As String
        Private _custNetPassword As String


        Public Property custID() As String
            Get
                Return _custID
            End Get
            Set(ByVal value As String)
                _custID = value
            End Set
        End Property


        Public Property custFullName() As String
            Get
                Return _custFullName
            End Get
            Set(ByVal value As String)
                _custFullName = value
            End Set
        End Property


        Public Property custSaltkey() As String
            Get
                Return _custSaltkey
            End Get
            Set(ByVal value As String)
                _custSaltkey = value
            End Set
        End Property

        Public Property custCompanyName() As String
            Get
                Return _custCompanyName
            End Get
            Set(ByVal value As String)
                _custCompanyName = value
            End Set
        End Property


        Public Property custJobTitle() As String
            Get
                Return _custJobTitle
            End Get
            Set(ByVal value As String)
                _custJobTitle = value
            End Set
        End Property


        Public Property custRegisterationNumber() As String
            Get
                Return _custRegisterationNumber
            End Get
            Set(ByVal value As String)
                _custRegisterationNumber = value
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


        Public Property imageExtension() As String
            Get
                Return _imageExtension
            End Get
            Set(ByVal value As String)
                _imageExtension = value
            End Set
        End Property
        Public Property custIDNumber() As String
            Get
                Return _custIDNumber
            End Get
            Set(ByVal value As String)
                _custIDNumber = value
            End Set
        End Property


        Public Property custFatherName() As String
            Get
                Return _custFatherName
            End Get
            Set(ByVal value As String)
                _custFatherName = value
            End Set
        End Property


        Public Property custBthDay() As String
            Get
                Return _custBthDay
            End Get
            Set(ByVal value As String)
                _custBthDay = value
            End Set
        End Property


        Public Property custEmailOne() As String
            Get
                Return _custEmailOne
            End Get
            Set(ByVal value As String)
                _custEmailOne = value
            End Set
        End Property

        Public Property custHomeTel() As String
            Get
                Return _custHomeTel
            End Get
            Set(ByVal value As String)
                _custHomeTel = value
            End Set
        End Property


        Public Property custOfficeTel() As String
            Get
                Return _custOfficeTel
            End Get
            Set(ByVal value As String)
                _custOfficeTel = value
            End Set
        End Property


        Public Property custCellPhone() As String
            Get
                Return _custCellPhone
            End Get
            Set(ByVal value As String)
                _custCellPhone = value
            End Set
        End Property


        Public Property custFax() As String
            Get
                Return _custFax
            End Get
            Set(ByVal value As String)
                _custFax = value
            End Set
        End Property


        Public Property custAddress() As String
            Get
                Return _custAddress
            End Get
            Set(ByVal value As String)
                _custAddress = value
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


        Public Property custDescription() As String
            Get
                Return _custDescription
            End Get
            Set(ByVal value As String)
                _custDescription = value
            End Set
        End Property


        Public Property custUserName() As String
            Get
                Return _custUserName
            End Get
            Set(ByVal value As String)
                _custUserName = value
            End Set
        End Property


        Public Property custPassword() As String
            Get
                Return _custPassword
            End Get
            Set(ByVal value As String)
                _custPassword = value
            End Set
        End Property


        Public Property custIsSysUser() As Boolean
            Get
                Return _custIsSysUser
            End Get
            Set(ByVal value As Boolean)
                _custIsSysUser = value
            End Set
        End Property


        Public Property custIsAdminUser() As Boolean
            Get
                Return _custIsAdminUser
            End Get
            Set(ByVal value As Boolean)
                _custIsAdminUser = value
            End Set
        End Property


        Public Property custNetUser() As String
            Get
                Return _custNetUser
            End Get
            Set(ByVal value As String)
                _custNetUser = value
            End Set
        End Property


        Public Property custNetPassword() As String
            Get
                Return _custNetPassword
            End Get
            Set(ByVal value As String)
                _custNetPassword = value
            End Set
        End Property

    End Class
End Namespace

