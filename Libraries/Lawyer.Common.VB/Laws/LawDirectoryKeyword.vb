Namespace Laws

    Public Class LawDirectoryKeyword


        Private _lkid As Int32
        Private _lkText As String
        Private _lsid As Int32


        Public Property lkid() As Int32
            Get
                Return _lkid
            End Get
            Set(ByVal value As Int32)
                _lkid = value
            End Set
        End Property


        Public Property lkText() As String
            Get
                Return _lkText
            End Get
            Set(ByVal value As String)
                _lkText = value
            End Set
        End Property


        Public Property lsid() As Int32
            Get
                Return _lsid
            End Get
            Set(ByVal value As Int32)
                _lsid = value
            End Set
        End Property


    End Class

End Namespace