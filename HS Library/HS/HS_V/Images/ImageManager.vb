
Namespace HS.Images


    Public Class ImageManager


#Region "- Property -"

        Private _HasError As Boolean
        Public ReadOnly Property HasError() As Boolean
            Get
                Return _HasError
            End Get

        End Property

        Private _Exception As Exception = Nothing
        Public ReadOnly Property Exception() As Exception
            Get
                Return _Exception
            End Get

        End Property

        Private _Message As String
        Public Property Message() As String
            Get
                Return _Message
            End Get
            Set(ByVal value As String)
                _Message = value
            End Set

        End Property


        Private _HasFile As Boolean
        Public ReadOnly Property HasFile() As Boolean
            Get
                Return _HasFile
            End Get

        End Property

        Public Sub Clear()

            _Message = Nothing
            _HasError = Nothing
            _HasFile = Nothing

        End Sub


        Private Sub SetMessage(ByVal Message As String)

            Dim _Bool As Boolean = True
            Select Case _Bool

                Case Message.Contains("is not a recognized imageformat")
                    _Message = "فایل غیر تصویری می باشد"
                Case Else
                    _Message = Message

            End Select


        End Sub


#End Region


        Public Sub ResizingImageSave(ByVal Image_path As String, ByVal Thumb_path As String, ByVal Thumb_Width As Integer, ByVal DelSource As Boolean) 'thumb_Width=200 or 350 or 100

            Try


                Dim Original As Drawing.Image = Drawing.Image.FromFile(Image_path)
                Dim Thumb As Drawing.Image = Original.GetThumbnailImage(Thumb_Width, Original.Height / Original.Width * Thumb_Width, Nothing, New IntPtr())

                '-----------------  White Canvas

                Dim Canvas As Drawing.Graphics = Drawing.Graphics.FromImage(Thumb)
                Canvas.Clear(Drawing.Color.White)

                Canvas.SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
                Canvas.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

                Canvas.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                Canvas.PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.HighQuality


                Dim h As Integer = Original.Height / Original.Width * Thumb_Width
                Canvas.DrawImage(Original, 0, 0, Thumb_Width, h)

                '---------------
                Thumb.Save(Thumb_path, Drawing.Imaging.ImageFormat.Jpeg)

                Original.Dispose()

                If DelSource AndAlso System.IO.File.Exists(Image_path) Then
                    System.IO.File.Delete(Image_path)
                End If

            Catch ex As Exception
                _HasError = True
                _Message = " خطا در ذخیره فایل تصویر " + ex.Message
            End Try

        End Sub


    End Class


End Namespace
