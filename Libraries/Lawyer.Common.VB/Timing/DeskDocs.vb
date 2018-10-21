Namespace Timing

    Public Class deskDocs
        Private _deskDocID As String
        Private _deskDocName As String
        Private _deskDocBinary As Byte()
        Private _deskTimeID As String
        Private _deskImageID As String
        Private _deskDocExtension As String
        Private _fileFullPath As String


        Public Property deskDocID() As String
            Get
                Return _deskDocID
            End Get
            Set(ByVal value As String)
                _deskDocID = value
            End Set
        End Property


        Public Property FileFullPath() As String
            Get
                Return _fileFullPath
            End Get
            Set(ByVal value As String)
                _fileFullPath = value
            End Set
        End Property


        Public Property deskDocName() As String
            Get
                Return _deskDocName
            End Get
            Set(ByVal value As String)
                _deskDocName = value
            End Set
        End Property


        Public Property deskDocBinary() As Byte()
            Get
                Return _deskDocBinary
            End Get
            Set(ByVal value As Byte())
                _deskDocBinary = value
            End Set
        End Property


        Public Property deskTimeID() As String
            Get
                Return _deskTimeID
            End Get
            Set(ByVal value As String)
                _deskTimeID = value
            End Set
        End Property


        Public Property deskImageID() As String
            Get
                Return _deskImageID
            End Get
            Set(ByVal value As String)
                _deskImageID = value
            End Set
        End Property


        Public Property deskDocExtension() As String
            Get
                Return _deskDocExtension
            End Get
            Set(ByVal value As String)
                _deskDocExtension = value
            End Set
        End Property

    End Class

End Namespace

