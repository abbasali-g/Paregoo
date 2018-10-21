Imports System.Drawing
Namespace TimeParties
    Public Class Kartabl
        Private _tpID As String
        Private _timeTitle As String
        Private _custFullName As String
        Private _timeDate As Int32
        Private _timeID As String
        Private _image As Image
        Private _fileCaseNumber As String

        Public Property timeTitle() As String
            Get
                Return _timeTitle
            End Get
            Set(ByVal value As String)
                _timeTitle = value
            End Set
        End Property


        Public Property fileCaseNumber() As String
            Get
                Return _fileCaseNumber
            End Get
            Set(ByVal value As String)
                _fileCaseNumber = value
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

        Public ReadOnly Property timeDateStringFormat() As String
            Get
                Dim d As String = _timeDate.ToString
                Return d.Substring(0, 4) & "/" & d.Substring(4, 2) & "/" & d.Substring(6, 2)
            End Get

        End Property

        Public Property timeDate() As Int32
            Get
                Return _timeDate
            End Get
            Set(ByVal value As Int32)
                _timeDate = value
            End Set
        End Property


        Public Property tpID() As String
            Get
                Return _tpID
            End Get
            Set(ByVal value As String)
                _tpID = value
            End Set
        End Property

        Public Property timeID() As String
            Get
                Return _timeID
            End Get
            Set(ByVal value As String)
                _timeID = value
            End Set
        End Property

        Public Property AttachmentImage() As Image
            Get
                Return _image
            End Get
            Set(ByVal value As Image)
                _image = value
            End Set
        End Property

    End Class
End Namespace

