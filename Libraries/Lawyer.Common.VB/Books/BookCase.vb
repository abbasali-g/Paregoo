Namespace Books


    Public Class BookCase


        Private _shelfID As Guid
        Private _shelfNumber As Int16
        Private _shelfName As String


        Public Property shelfID() As Guid
            Get
                Return _shelfID
            End Get
            Set(ByVal value As Guid)
                _shelfID = value
            End Set
        End Property


        Public Property shelfNumber() As Int16
            Get
                Return _shelfNumber
            End Get
            Set(ByVal value As Int16)
                _shelfNumber = value
            End Set
        End Property


        Public Property shelfName() As String
            Get
                Return _shelfName
            End Get
            Set(ByVal value As String)
                _shelfName = value
            End Set
        End Property



    End Class


End Namespace



