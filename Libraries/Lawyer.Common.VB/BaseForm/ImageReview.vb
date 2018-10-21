Namespace BaseForm
    Public Class ImageReview


        Private _imageExtension As String
        Private _imageUpdateDate As String
        Private _imageLogo As Byte()



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

        Public Property imageLogo() As Byte()
            Get
                Return _imageLogo
            End Get
            Set(ByVal value As Byte())
                _imageLogo = value
            End Set
        End Property

    End Class
End Namespace

