Namespace Timing

    Public Class DeskDocsReview

        Private _deskDocID As String
        Private _deskDocName As String
        Private _deskImageID As String


        Public Property deskDocID() As String
            Get
                Return _deskDocID
            End Get
            Set(ByVal value As String)
                _deskDocID = value
            End Set
        End Property


        Public Property deskDocName() As String
            Get
                Return _deskDocName
            End Get
            Set(ByVal value As String)
                _deskDocName = value
            End Set
        End Property


        Public Property deskImageID() As String
            Get
                Return _deskImageID
            End Get
            Set(ByVal value As String)
                _deskImageID = value
            End Set
        End Property


    End Class


End Namespace

