Namespace BaseForm
    Public Class Image
        Private _imageID As String
        Private _imageExtension As String
        Private _imageUpdateDate As String
        Private _imageLogo As Byte()
        Private _imageName As String
        Private _imagePath As String


        Public Property imageID() As String
            Get
                Return _imageID
            End Get
            Set(ByVal value As String)
                _imageID = value
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


        Public Property imagePath() As String
            Get
                Return _imagePath
            End Get
            Set(ByVal value As String)
                _imagePath = value
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

        Public Property imageLogo() As Byte()
            Get
                Return _imageLogo
            End Get
            Set(ByVal value As Byte())
                _imageLogo = value
            End Set
        End Property


        Public Property imageName() As String
            Get
                Return _imageName
            End Get
            Set(ByVal value As String)
                _imageName = value
            End Set
        End Property

    End Class

End Namespace
