
Namespace Setting
    Public Class Setting

        Private _settingName As String
        Private _settingValue As String



        Public Property settingName() As String
            Get
                Return _settingName
            End Get
            Set(ByVal value As String)
                _settingName = value
            End Set
        End Property


        Public Property settingValue() As String
            Get
                Return _settingValue
            End Get
            Set(ByVal value As String)
                _settingValue = value
            End Set
        End Property

        Public Sub New(ByVal settingName As String, ByVal settingValue As String)

            _settingName = settingName
            _settingValue = settingValue

        End Sub

        Public Sub New()

        End Sub

    End Class
End Namespace

