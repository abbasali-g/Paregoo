Public Class ImageViewer

#Region " Property "

    Private _ImagePath As String
    Public Property ImagePath() As String
        Get
            Return _ImagePath
        End Get
        Set(ByVal value As String)
            _ImagePath = value + "\"
        End Set
    End Property

    Private _ImageList As New List(Of String)
    Public Property ImageList() As List(Of String)
        Get
            Return _ImageList
        End Get
        Set(ByVal value As List(Of String))

            If value IsNot Nothing AndAlso value.Count > 0 Then

                _ImageList = value
                FillImage()
                Me.Visible = True
            Else

                Me.Visible = False

            End If
        End Set


    End Property


    Dim TotalImage As Integer
    Dim CurImage As Integer

    Sub FillImage()

        Try

            ' _ImageList.Add("D:\1.jpg")

            TotalImage = _ImageList.Count
            CurImage = 0

            Me.lblNo.Text = CStr(CurImage + 1) + "/" + CStr(TotalImage)
            Me.pbImage.Image = Image.FromFile(_ImagePath + _ImageList(0))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Load "

    Private Sub ImageViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.pbImage.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

#End Region

#Region " Command "

    Private Sub pbNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbNext.Click

        Me.pbImage.Image = NextImage()

    End Sub

    Function NextImage() As Image

        Try

            If CurImage + 1 < TotalImage Then
                CurImage = CurImage + 1
            End If

            Me.lblNo.Text = CStr(CurImage + 1) + "/" + CStr(TotalImage)
            Dim _Image As Image = Image.FromFile(_ImagePath + _ImageList(CurImage))
            Return _Image

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Sub pbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBack.Click

        Me.pbImage.Image = BackImage()

    End Sub

    Function BackImage() As Image

        Try

            If CurImage - 1 > -1 Then
                CurImage = CurImage - 1
            End If

            Me.lblNo.Text = CStr(CurImage + 1) + "/" + CStr(TotalImage)
            Dim _Image As Image = Image.FromFile(_ImagePath + _ImageList(CurImage))
            Return _Image

        Catch ex As Exception
            Return Nothing
        End Try


    End Function

    Private Sub pbImage_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbImage.DoubleClick

        System.Diagnostics.Process.Start(_ImagePath + _ImageList(CurImage))

    End Sub

#End Region

#Region " Mouse Event "

    Private Sub pbNext_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbNext.MouseHover

        Me.pbNext.Image = Global.WFControls.VB.My.Resources.Resources.Next_Blue

    End Sub

    Private Sub pbNext_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbNext.MouseLeave
        Me.pbNext.Image = Global.WFControls.VB.My.Resources.Resources.Naxt_Gray
    End Sub

    Private Sub pbBack_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbBack.MouseHover

        Me.pbBack.Image = Global.WFControls.VB.My.Resources.Resources.Back_Blue

    End Sub

    Private Sub pbBack_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbBack.MouseLeave

        Me.pbBack.Image = Global.WFControls.VB.My.Resources.Resources.Back_Gray

    End Sub

#End Region


End Class
