Imports System.Drawing
Namespace Timing

    Public Class TimingFullSearch

        Private _tpID As String
        Private _timeTitle As String
        Private _custFullName As String
        Private _targetcustName As String
        Private _timeDate As Int32
        Private _timeID As String
        Private _image As Image
        Private _fileCaseNumber As String
        Private _timeTime As String
        Private _timeType As Int16
        Private _timeTypeName As String
        Private _timeText As String
        Private _timeDone As Boolean
        Private _fileCaseNumberInCourt As String
        Private _fileCaseNumberInBranch As String
        Private _fileCaseNumberYear As String
        Private _fileCaseNumberInSystem As String
        Private _filecaseid As String
        Private _timeSms As Int16
        Private _timeNet As Int16

        Public Property filecaseid() As String
            Get
                Return _filecaseid
            End Get
            Set(ByVal value As String)
                _filecaseid = value
            End Set
        End Property


        Public Property tpID() As String
            Get
                Return _tpID
            End Get
            Set(ByVal value As String)
                _tpID = value
            End Set
        End Property

        Public Property timeTitle() As String
            Get
                Return _timeTitle
            End Get
            Set(ByVal value As String)
                _timeTitle = value
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
        Public Property targetcustName() As String
            Get
                Return _targetcustName
            End Get
            Set(ByVal value As String)
                _targetcustName = value
            End Set
        End Property

        Public Property timeDate() As Int32
            Get
                Return _timeDate
            End Get
            Set(ByVal value As Int32)
                _timeDate = value
            End Set
        End Property

        Public ReadOnly Property StrtimeDate() As String

            Get
                Dim s As String = _timeDate.ToString()

                Return s.Substring(0, 4) & "/" & s.Substring(4, 2) & "/" & s.Substring(6, 2)

            End Get

        End Property

        Public ReadOnly Property timeDateStringFormat() As String
            Get
                Dim d As String = _timeDate.ToString
                Return d.Substring(0, 4) & "/" & d.Substring(4, 2) & "/" & d.Substring(6, 2)
            End Get

        End Property

        Public Property timeID() As String
            Get
                Return _timeID
            End Get
            Set(ByVal value As String)
                _timeID = value
            End Set
        End Property

        Public Property AttachmentImage() As Image
            Get
                Return _image
            End Get
            Set(ByVal value As Image)
                _image = value
            End Set
        End Property

        Public ReadOnly Property fileCaseNumber() As String

            Get
                If _fileCaseNumberInCourt = String.Empty AndAlso _fileCaseNumberInBranch = String.Empty AndAlso _fileCaseNumberInSystem = String.Empty Then

                    Return String.Empty

                End If

                Return _fileCaseNumberInCourt + "/" + _fileCaseNumberInBranch + " (" + _fileCaseNumberInSystem + ")"

            End Get

        End Property

        Public Property timeTime() As String
            Get
                Return _timeTime
            End Get
            Set(ByVal value As String)
                _timeTime = value
            End Set
        End Property

        Public Property timeType() As Int16
            Get
                Return _timeType
            End Get
            Set(ByVal value As Int16)
                _timeType = value
            End Set
        End Property

        Public Property timeTypeName() As String
            Get
                Return _timeTypeName
                '' ''    Select Case timeType

                '' ''        Case 0

                '' ''            Return "وقت نظارت پرونده"
                '' ''        Case 1
                '' ''            Return "وقت پیگیری پرونده"
                '' ''        Case 2
                '' ''            Return "وقت رسیدگی"
                '' ''        Case 3
                '' ''            Return "جلسه"
                '' ''        Case 4
                '' ''            Return "مشاوره"
                '' ''        Case 5
                '' ''            Return "کار"
                '' ''        Case 6
                '' ''            Return "مکاتبات"
                '' ''        Case 7
                '' ''            Return "اخطاریه"

                '' ''        Case 10

                '' ''            Return "تماس"

                '' ''    End Select

                '' ''    Return String.Empty

            End Get
            Set(ByVal value As String)
                _timeTypeName = value
            End Set
        End Property

        Public Property timeText() As String
            Get
                Return _timeText
            End Get
            Set(ByVal value As String)
                _timeText = value
            End Set
        End Property

        Public Property timeDone() As String
            Get
                Return _timeDone
            End Get
            Set(ByVal value As String)
                _timeDone = value
            End Set
        End Property

        Public Property fileCaseNumberInCourt() As String
            Get
                Return _fileCaseNumberInCourt
            End Get
            Set(ByVal value As String)
                _fileCaseNumberInCourt = value
            End Set
        End Property

        Public Property fileCaseNumberInBranch() As String
            Get
                Return _fileCaseNumberInBranch
            End Get
            Set(ByVal value As String)
                _fileCaseNumberInBranch = value
            End Set
        End Property
        Public Property fileCaseNumberYear() As String
            Get
                Return _fileCaseNumberYear
            End Get
            Set(ByVal value As String)
                _fileCaseNumberYear = value
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

        Public ReadOnly Property timeFullDate() As String
            Get
                Dim d As String = _timeDate.ToString
                d = d.Substring(0, 4) & "/" & d.Substring(4, 2) & "/" & d.Substring(6, 2)

                If timeTime <> String.Empty Then
                    Return CStr(d) & "-" & timeTime
                End If

                Return CStr(d)

            End Get

        End Property

        Public Property timeSms() As Int16
            Get
                Return _timeSms
            End Get
            Set(ByVal value As Int16)
                _timeSms = value
            End Set
        End Property

        Public Property timeNet() As Int16
            Get
                Return _timeNet
            End Get
            Set(ByVal value As Int16)
                _timeNet = value
            End Set
        End Property

    End Class

End Namespace

