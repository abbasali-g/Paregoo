Namespace Login
    Public Class CurrentLogin

        Private Shared _user As Login

        Public Shared Property CurrentUser() As Login

            Get
               
                Return _user


            End Get

            Set(ByVal value As Login)

                _user = value

            End Set

        End Property

    End Class


End Namespace
