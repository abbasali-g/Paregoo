Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web

Public Class DateConvertor

    Private _ConnectionString As String
    Private _LocationToGetDate As String
    Private Const c_ConStr = "ConStr"

#Region "Declarations..."

    Enum DateType

        Day

        Month

        Year

    End Enum

    Enum GetDateLocationTypes

        SqlServer

        System

    End Enum

    Structure SDateParts

        Private _day As String
        Private _month As String
        Private _year As String

        Public Property Day() As String
            Get
                Return _day
            End Get
            Set(ByVal value As String)
                _day = value
            End Set
        End Property

        Public Property Month() As String
            Get
                Return _month
            End Get
            Set(ByVal value As String)
                _month = value
            End Set
        End Property

        Public Property Year() As String
            Get
                Return _year
            End Get
            Set(ByVal value As String)
                _year = value
            End Set
        End Property

    End Structure

#End Region

#Region "Properties"

    Public Property ConnectionString() As String

        Get

            Return _ConnectionString

        End Get

        Set(ByVal value As String)

            _ConnectionString = value

        End Set

    End Property

    Public Property LocationToGetDate() As GetDateLocationTypes

        Get

            Return _LocationToGetDate

        End Get

        Set(ByVal value As GetDateLocationTypes)

            _LocationToGetDate = value

        End Set

    End Property

    Public Shared ReadOnly Property Current() As DateConvertor

        Get

            Dim _current As DateConvertor = Nothing

            Try

                _current = New DateConvertor()

            Catch ex As Exception

            End Try

            Return _current

        End Get

    End Property

#End Region

#Region "Constructor..."

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="connectionString">set this parameter when LocationToGetDate parameter has set to SqlServer,otherwise set it string.empty</param>
    ''' <param name="LocationToGetDate"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ConnectionString As String, ByVal LocationToGetDate As GetDateLocationTypes)

        If LocationToGetDate = GetDateLocationTypes.System Then

            ConnectionString = String.Empty

        End If

        Me.ConnectionString = ConnectionString

        Me.LocationToGetDate = LocationToGetDate

    End Sub

    ''' <summary>
    ''' when connection string was set and GetDateLocation was not Set The default location For Get Date is Sql Server
    ''' </summary>
    ''' <param name="connectionString"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ConnectionString As String)

        Me.ConnectionString = ConnectionString

        Me.LocationToGetDate = GetDateLocationTypes.SqlServer

    End Sub

    ''' <summary>
    ''' The Default Location For Get Date is Sql Server when It was not set
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        Try

            Me.ConnectionString = HttpContext.Current.Application(c_ConStr).ToString()

        Catch ex As Exception

            Me.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings(c_ConStr).ConnectionString

        End Try

        Me.LocationToGetDate = GetDateLocationTypes.SqlServer

    End Sub

#End Region

#Region "Base Methods"

    Private Function BaseGetShamsiDate(ByVal MiladiDate As Date, ByVal ReturnDateType As DateType) As String

        Dim sdate As SDateParts = BaseGetShamsiDate(MiladiDate)

        Dim rval As String = "0"

        Select Case ReturnDateType

            Case DateType.Day

                rval = sdate.Day

            Case DateType.Month

                rval = sdate.Month

            Case DateType.Year

                rval = sdate.Year

        End Select

        Return rval

    End Function

    Private Function BaseGetShamsiDate(ByVal MiladiDate As Date) As SDateParts

        Try

            Dim pc As New System.Globalization.PersianCalendar()

            Dim y, m, d As String

            Dim InputMiladiDate As Date

            If MiladiDate = Nothing Then

                InputMiladiDate = Me.GetMiladiDate

            Else

                InputMiladiDate = MiladiDate

            End If

            y = pc.GetYear(InputMiladiDate).ToString()
            m = pc.GetMonth(InputMiladiDate).ToString.PadLeft(2, "0")
            d = pc.GetDayOfMonth(InputMiladiDate).ToString.PadLeft(2, "0")

            '' ''OuPutDate = String.Join("/", New String() {y, m, d})

            Dim sdate As New SDateParts

            sdate.Day = d

            sdate.Month = m

            sdate.Year = y

            Return sdate

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

    Private Function BaseGetMiladiDate(ByVal ShamsiDate As String) As Date

        Try

            Dim miladiDate As Date

            If ShamsiDate = Nothing Then

                If Me.LocationToGetDate = GetDateLocationTypes.SqlServer Then

                    Using cmd As New SqlCommand("SELECT GETDATE() AS [MiladiDate]")

                        Using cnn As New SqlConnection(Me.ConnectionString)

                            cmd.Connection = cnn

                            If Not cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Open()

                            miladiDate = cmd.ExecuteScalar()

                            cmd.Connection.Close()

                        End Using

                    End Using

                Else

                    miladiDate = System.DateTime.Now

                End If

            Else

                Dim pc As New System.Globalization.PersianCalendar()

                If Not IsShamsiDate(ShamsiDate) Then

                    Dim _reverseShamsiDate As String = ReverseShamsiDate(ShamsiDate)

                    If IsShamsiDate(_reverseShamsiDate) Then

                        ShamsiDate = _reverseShamsiDate

                    Else

                        Return String.Empty

                    End If

                End If

                Dim ShamsiDateItems As String() = ShamsiDate.Split("/")

                miladiDate = pc.ToDateTime(CInt(ShamsiDateItems(0)), CInt(ShamsiDateItems(1)), CInt(ShamsiDateItems(2)), 0, 0, 0, 0)

            End If

            Return miladiDate

        Catch ex As Exception

            Return String.Empty

        End Try

    End Function

#End Region

#Region "Public Functions..."

    Public Overloads Function GetShamsiDate(ByVal MiladiDate As Date, ByVal ReturnDateType As DateType) As String

        Return Me.BaseGetShamsiDate(MiladiDate, ReturnDateType)

    End Function

    Public Overloads Function GetShamsiDate(ByVal MiladiDate As Date) As String

        Dim sdate As SDateParts = Me.BaseGetShamsiDate(MiladiDate)

        Return String.Format("{0}/{1}/{2}", sdate.Year, sdate.Month, sdate.Day)

    End Function

    ''' <summary>
    ''' Get Today Shamsi Date
    ''' </summary>
    ''' <param name="ReturnDateType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetShamsiDate(ByVal ReturnDateType As DateType) As String

        Return Me.BaseGetShamsiDate(String.Empty, ReturnDateType)

    End Function

    ''' <summary>
    ''' Get Today Shamsi Date
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetShamsiDate() As String

        Dim sdate As SDateParts = Me.BaseGetShamsiDate(Nothing)

        Return String.Format("{0}/{1}/{2}", sdate.Year, sdate.Month, sdate.Day)

    End Function


    ''' <summary>
    ''' example : {0}/{1}/{2}  or {0},{1},{2} or {0}{1}{2}
    ''' 
    ''' </summary>
    ''' <param name="ReturnFormat">
    ''' {0} : Year 
    ''' {1} : Month 
    ''' {2} : Day
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetShamsiDate(ByVal MiladiDate As Date, ByVal ReturnFormat As String) As String

        Dim sdate As SDateParts = Me.BaseGetShamsiDate(MiladiDate)

        Return String.Format(ReturnFormat, sdate.Year, sdate.Month, sdate.Day)

    End Function

    ''' <summary>
    ''' Get Today Shamsidate with custom Format
    ''' example : {0}/{1}/{2}  or {0},{1},{2} or {0}{1}{2}
    ''' 
    ''' </summary>
    ''' <param name="ReturnFormat">
    ''' {0} : Year 
    ''' {1} : Month 
    ''' {2} : Day
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetShamsiDate(ByVal ReturnFormat As String) As String

        Dim sdate As SDateParts = Me.BaseGetShamsiDate(Nothing)

        Return String.Format(ReturnFormat, sdate.Year, sdate.Month, sdate.Day)

    End Function



    Public Overloads Function GetShamsiDateParts(ByVal MiladiDate As Date) As SDateParts

        Return Me.BaseGetShamsiDate(MiladiDate)

    End Function

    Public Overloads Function GetShamsiDateParts() As SDateParts

        Return Me.BaseGetShamsiDate(Nothing)

    End Function


    ''' <summary>
    ''' get shamsidate without any seprator, with 8 digit
    ''' example : 13880129
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetShamsiDateInNumericFormat(ByVal Miladidate As Date) As Integer

        Return Convert.ToInt32(GetShamsiDate(Miladidate, "{0}{1}{2}"))

    End Function

    ''' <summary>
    ''' get Today shamsidate without any seprator, with 8 digit
    ''' example : 13880129
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    '' ''Public Overloads Function GetShamsiDateInNumericFormat() As String

    '' ''    Return GetShamsiDate("{0}{1}{2}")

    '' ''End Function

    Public Overloads Function GetShamsiDateInNumericFormat() As Integer

        Return Convert.ToInt32(GetShamsiDate("{0}{1}{2}"))

    End Function

    Public Overloads Function GetMiladiDate(ByVal ShamsiDate As String) As Date

        Return Me.BaseGetMiladiDate(ShamsiDate)

    End Function

    Public Overloads Function GetMiladiDate() As Date

        Return Me.BaseGetMiladiDate(Nothing)

    End Function

    Public Function GetFasriWeekDay(ByVal InputDate As DateTime) As Integer

        Dim FarsiDayOfWeek As Integer

        Select Case InputDate.DayOfWeek

            Case DayOfWeek.Saturday
                FarsiDayOfWeek = 0
            Case DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
                FarsiDayOfWeek = InputDate.DayOfWeek + 1

        End Select

        Return FarsiDayOfWeek

    End Function

    Public Function GetFasriWeekDayName(ByVal InputDate As DateTime) As String

        Select Case InputDate.DayOfWeek

            Case DayOfWeek.Saturday
                Return "شنبه"
            Case DayOfWeek.Sunday
                Return "یکشنبه"
            Case DayOfWeek.Monday
                Return "دوشنبه"
            Case DayOfWeek.Tuesday
                Return "سه شنبه"
            Case DayOfWeek.Wednesday
                Return "چهار شنبه"
            Case DayOfWeek.Thursday
                Return "پنجشنبه"
            Case DayOfWeek.Friday
                Return "جمعه"
        End Select

        Return ""

    End Function

    Public Function GetTime() As String

        Try

            Dim miladiDate As Date

            If Me.LocationToGetDate = GetDateLocationTypes.SqlServer Then

                Using cmd As New SqlCommand("SELECT GETDATE() AS [MiladiDate]")

                    Using cnn As New SqlConnection(Me.ConnectionString)

                        cmd.Connection = cnn

                        If Not cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Open()

                        miladiDate = cmd.ExecuteScalar()

                        cmd.Connection.Close()

                    End Using

                End Using

            Else

                miladiDate = System.DateTime.Now

            End If

            Return String.Format("{0:00}:{1:00}:{2:00}", miladiDate.Hour, miladiDate.Minute, miladiDate.Second)

        Catch ex As Exception

            Return String.Empty

        End Try

    End Function

#End Region

#Region "Shared Functions..."

    Public Shared Function IsShamsiDate(ByVal str As String) As Boolean

        If String.IsNullOrEmpty(str) Then Return False

        If str.Length <> 10 Then Return False

        If str.Split("/").Length <> 3 Then Return False

        If IsNumeric(str.Replace("/", "")) = False Then Return False

        Dim Year As String() = str.Split("/")

        If Year(0).Length = 4 Then '1387/11/19

            If Val(Year(1)) > 12 Or Val(Year(1)) < 0 Then Return False

            If Val(Year(2)) > 31 Or Val(Year(2)) < 0 Then Return False

        ElseIf Year(0).Length = 2 Then '31/12/1387

            If Val(Year(1)) > 12 Or Val(Year(1)) < 0 Then Return False

            If Val(Year(0)) > 31 Or Val(Year(0)) < 0 Then Return False

        End If

        Return True

    End Function

    Public Shared Function ReverseShamsiDate(ByVal ShamsiDate As String) As String

        Try

            Dim RshamsiDate() As String = ShamsiDate.Split("/")

            Return RshamsiDate(2) & "/" & RshamsiDate(1) & "/" & RshamsiDate(0)

        Catch ex As Exception

            Return String.Empty

        End Try

    End Function

    Public Shared Function AdjustShamsiDate(ByVal ShamsiDate As String, ByVal minYear As Integer)

        Dim StrShamsiDate() As String = ShamsiDate.Split("/")

        Dim mYear As UShort

        Dim Year As UShort

        Dim Month As UShort

        Dim Day As UShort

        Try

            mYear = minYear

        Catch ex As Exception

            Return String.Empty

        End Try

        If StrShamsiDate.Length <> 3 Then

            Return String.Empty

        End If

        Try

            Year = StrShamsiDate(0)

            Month = StrShamsiDate(1)

            Day = StrShamsiDate(2)

        Catch ex As Exception

            Return String.Empty

        End Try

        If Year < mYear Then

            Year += mYear

        End If

        If Month < 1 Or Month > 12 Then

            Return String.Empty

        End If

        If Day < 1 Or Day > 31 Then

            Return String.Empty

        End If

        StrShamsiDate(0) = Year.ToString()

        StrShamsiDate(1) = IIf(Month < 10, "0" & Month.ToString(), Month.ToString())

        StrShamsiDate(2) = IIf(Day < 10, "0" & Day.ToString(), Day.ToString())

        Return String.Join("/", StrShamsiDate)

    End Function

#End Region


End Class

