Namespace LawOrgs



    Public Class LawOrg

        Private _lawOrgNameID As Int32
        Private _lawOrgName As String


        Public Property lawOrgNameID() As Int32
            Get
                Return _lawOrgNameID
            End Get
            Set(ByVal value As Int32)
                _lawOrgNameID = value
            End Set
        End Property


        Public Property lawOrgName() As String
            Get
                Return _lawOrgName
            End Get
            Set(ByVal value As String)
                _lawOrgName = value
            End Set
        End Property


    End Class

End Namespace

