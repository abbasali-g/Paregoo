Namespace Setting
    Public Class SettingComplete

        Private _settingID As String
        Private _settingName As String
        Private _settingGroupID As String
        Private _settingValue As String


        Public Property settingID() As String
            Get
                Return _settingID
            End Get
            Set(ByVal value As String)
                _settingID = value
            End Set
        End Property


        Public Property settingName() As String
            Get
                Return _settingName
            End Get
            Set(ByVal value As String)
                _settingName = value
            End Set
        End Property


        Public Property settingGroupID() As String
            Get
                Return _settingGroupID
            End Get
            Set(ByVal value As String)
                _settingGroupID = value
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


    End Class

End Namespace

