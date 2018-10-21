Namespace BloodMoneys

    Public Class BloodMoney


        Private _bmID As Int32
        Private _bmName As String
        Private _bmSex As String
        Private _bmValue As Double ' Single
        Private _bmValuLable As String
        Private _bmParentID As Int32
        Private _bmCalcType As String
        Private _bmDefaultValue As Single
        Private _bmValueToBeAdded As Double ' Single
        Private _bmLawText As String

        Private _Childs As Int32

        Private _bmLinkedParentID As Int32
        Private _bmImages As String
        Private _bmDescription As String



        Public Property bmLinkedParentID() As Int32
            Get
                Return _bmLinkedParentID
            End Get
            Set(ByVal value As Int32)
                _bmLinkedParentID = value
            End Set
        End Property


        Public Property bmImages() As String
            Get
                Return _bmImages
            End Get
            Set(ByVal value As String)
                _bmImages = value
            End Set
        End Property



        Public Property bmDescription() As String
            Get
                Return _bmDescription
            End Get
            Set(ByVal value As String)
                _bmDescription = value
            End Set
        End Property



        Public Property Childs() As Int32
            Get
                Return _Childs
            End Get
            Set(ByVal value As Int32)
                _Childs = value
            End Set
        End Property






        Public Property bmID() As Int32
            Get
                Return _bmID
            End Get
            Set(ByVal value As Int32)
                _bmID = value
            End Set
        End Property


        Public Property bmName() As String
            Get
                Return _bmName
            End Get
            Set(ByVal value As String)
                _bmName = value
            End Set
        End Property


        Public Property bmSex() As String
            Get
                Return _bmSex
            End Get
            Set(ByVal value As String)
                _bmSex = value
            End Set
        End Property


        Public Property bmValue() As Double
            Get
                Return _bmValue
            End Get
            Set(ByVal value As Double)
                _bmValue = value
            End Set
        End Property


        Public Property bmValuLable() As String
            Get
                Return _bmValuLable
            End Get
            Set(ByVal value As String)
                _bmValuLable = value
            End Set
        End Property


        Public Property bmParentID() As Int32
            Get
                Return _bmParentID
            End Get
            Set(ByVal value As Int32)
                _bmParentID = value
            End Set
        End Property


        Public Property bmCalcType() As String
            Get
                Return _bmCalcType
            End Get
            Set(ByVal value As String)
                _bmCalcType = value
            End Set
        End Property


        Public Property bmDefaultValue() As Single
            Get
                Return _bmDefaultValue
            End Get
            Set(ByVal value As Single)
                _bmDefaultValue = value
            End Set
        End Property


        Public Property bmValueToBeAdded() As Double
            Get
                Return _bmValueToBeAdded
            End Get
            Set(ByVal value As Double)
                _bmValueToBeAdded = value
            End Set
        End Property


        Public Property bmLawText() As String
            Get
                Return _bmLawText
            End Get
            Set(ByVal value As String)
                _bmLawText = value
            End Set
        End Property







    End Class

End Namespace
