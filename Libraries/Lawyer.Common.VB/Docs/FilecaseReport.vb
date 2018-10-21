Namespace Docs
    Public Class FilecaseReport

        Private _fileCaseID As String
        Private _custID As String
        Private _custFullName As String
        Private _davi As String
        Private _fileCaseNumberInSystem As String
        Private _fileCaseOpenDate As Int32
        Private _fileCaseSubject As String
        Private _status As String
        Private _fileCaseCloseDate As Int32
        Private _FileCaseNumber As String
        Private _fileCaseStep As Int16
        Private _fileRelationId As String


        Public Property fileCaseID() As String
            Get
                Return _fileCaseID
            End Get
            Set(ByVal value As String)
                _fileCaseID = value
            End Set
        End Property


        Public Property custID() As String
            Get
                Return _custID
            End Get
            Set(ByVal value As String)
                _custID = value
            End Set
        End Property


        Public Property custFullName() As String
            Get
                Return _custFullName
            End Get
            Set(ByVal value As String)
                _custFullName = value
            End Set
        End Property


        Public Property davi() As String
            Get
                Return _davi
            End Get
            Set(ByVal value As String)
                _davi = value
            End Set
        End Property


        Public Property fileCaseNumberInSystem() As String
            Get
                Return _fileCaseNumberInSystem
            End Get
            Set(ByVal value As String)
                _fileCaseNumberInSystem = value
            End Set
        End Property


        Public Property fileCaseOpenDate() As Int32
            Get
                Return _fileCaseOpenDate
            End Get
            Set(ByVal value As Int32)
                _fileCaseOpenDate = value
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


        Public Property status() As String
            Get
                Return _status
            End Get
            Set(ByVal value As String)
                _status = value
            End Set
        End Property


        Public Property fileCaseCloseDate() As Int32
            Get
                Return _fileCaseCloseDate
            End Get
            Set(ByVal value As Int32)
                _fileCaseCloseDate = value
            End Set
        End Property


        Public Property FileCaseNumber() As String
            Get
                Return _FileCaseNumber
            End Get
            Set(ByVal value As String)
                _FileCaseNumber = value
            End Set
        End Property


        Public Property fileCaseStep1() As Int16
            Get
                Return _fileCaseStep
            End Get
            Set(ByVal value As Int16)
                _fileCaseStep = value
            End Set
        End Property

        Public ReadOnly Property fileCaseStep() As String
            Get
                Select Case _fileCaseStep
                    Case 0
                        Return "بدوی"
                    Case 1
                        Return "تجدید نظر"
                    Case 2
                        Return "دعوی مقابل"
                    Case 3
                        Return "دعوی جلب ثالث"
                    Case 4
                        Return "درخواست اعاده"
                    Case 5
                        Return "دعوی ورود ثالث"
                    Case 6
                        Return "دعوی اعتراض ثالث"
                    Case 7
                        Return "فرجام"
                    Case 8
                        Return "اجرای احکام"
                    Case 9
                        Return "مرحله دادسرا"

                End Select

                Return String.Empty

            End Get

        
        End Property

        Public Property fileRelationId() As String
            Get
                If _fileRelationId = "0" Then
                    Return "غیر مرتبط"

                Else

                    Return "مرتبط"
                End If
                Return _fileRelationId
            End Get
            Set(ByVal value As String)
                _fileRelationId = value
            End Set
        End Property


    End Class
End Namespace

