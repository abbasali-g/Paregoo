
Namespace HS.FileManager.Pdf

    Public Class FileType

        Private _Path As String
        Private _Kind As String
        Private _Name As String
        Private _PageNo As Integer
        Private _ThumbImage As String



        Public Property Path() As String
            Get
                Return _Path
            End Get
            Set(ByVal value As String)
                _Path = value
            End Set
        End Property


        Public Property Kind() As String
            Get
                Return _Kind
            End Get
            Set(ByVal value As String)
                _Kind = value
            End Set
        End Property


        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property


        Public Property PageNo() As Integer
            Get
                Return _PageNo
            End Get
            Set(ByVal value As Int32)
                _PageNo = value
            End Set
        End Property


        Public Property ThumbImage() As String
            Get
                Return _ThumbImage
            End Get
            Set(ByVal value As String)
                _ThumbImage = value
            End Set
        End Property


    End Class


End Namespace
