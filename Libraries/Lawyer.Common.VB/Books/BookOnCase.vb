Namespace Books

    Public Class BookOnCase

        Private _shelfID As Guid
        Private _shelfNumber As Int16
        Private _shelfRow As Int16
        Private _shelfColumn As Int16
        Private _libID As Guid


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


        Public Property shelfRow() As Int16
            Get
                Return _shelfRow
            End Get
            Set(ByVal value As Int16)
                _shelfRow = value
            End Set
        End Property


        Public Property shelfColumn() As Int16
            Get
                Return _shelfColumn
            End Get
            Set(ByVal value As Int16)
                _shelfColumn = value
            End Set
        End Property


        Public Property libID() As Guid
            Get
                Return _libID
            End Get
            Set(ByVal value As Guid)
                _libID = value
            End Set
        End Property

    End Class





End Namespace
