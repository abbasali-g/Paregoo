Namespace Common

    Public Class Picture

        Private _imageExtention As String
        Private _image As Byte()
        Private _imageUpdateDate As String


        Public Property pictureExtention() As String
            Get
                Return _imageExtention
            End Get
            Set(ByVal value As String)
                _imageExtention = value
            End Set
        End Property

        Public Property picUpdatedate() As String
            Get
                Return _imageUpdateDate
            End Get
            Set(ByVal value As String)
                _imageUpdateDate = value
            End Set
        End Property


        Public Property BinaryPicture() As Byte()
            Get
                Return _image
            End Get
            Set(ByVal value As Byte())
                _image = value
            End Set
        End Property


    End Class
End Namespace

