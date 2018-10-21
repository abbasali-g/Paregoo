Namespace Docs
    Public Class CurrentFileCase
        Private _fileCaseID As String
        Private _fileID As String
        Private _fileCaseSubject As String


        Public Property fileCaseID() As String
            Get
                Return _fileCaseID
            End Get
            Set(ByVal value As String)
                _fileCaseID = value
            End Set
        End Property


        Public Property fileID() As String
            Get
                Return _fileID
            End Get
            Set(ByVal value As String)
                _fileID = value
            End Set
        End Property


        Public Property fileCaseSubject() As String
            Get
                Return _fileCaseSubject
            End Get
            Set(ByVal value As String)
                _fileCaseSubject = value
            End Set
        End Property
    End Class

End Namespace

