Imports MySql.Data.MySqlClient


Namespace CommonSetting
    Public Class CommonSettingManager

        Private Shared _ConnectionString As String
       
        Private Shared _DestConnString As String


        Public Shared Function ConnectionString() As String

            Try

                'abbas i have added
                '' _ConnectionString = String.Format("server={0};Port={1};uid={2}; pwd={3};database=nwdicdad2;", "127.0.0.1", "9918", "root", "@@%!mysqlnahani")

                Return _ConnectionString


            Catch ex As Exception


                Return Nothing

            End Try

        End Function

        Public Shared Sub SetConnectionString(ByVal Ip As String, ByVal port As String, ByVal UserName As String, ByVal passWord As String)
            _ConnectionString = String.Format("server={0};Port={1};uid={2}; pwd={3};database=nwdicdad2;", Ip, port, UserName, passWord)
        End Sub

        Public Property DestComputer() As String
            Get
                Return _DestConnString
            End Get
            Set(ByVal value As String)
                _DestConnString = value
            End Set
        End Property

        Public Shared Function DestinationConStr() As String
            Try
                If String.IsNullOrEmpty(_DestConnString) Then

                    
                    _DestConnString = String.Format("server={0};uid=root; pwd=1;database=nwdicdad2;", _DestConnString)

                End If

                Return _ConnectionString

            Catch ex As Exception

                Return Nothing

            End Try

        End Function

        Public Shared Function MaxFileImageID() As String

            Dim params(0) As MySqlParameter

            Dim defaulImage As String = String.Empty

            params(0) = New MySqlParameter("_settingName", "File.MaxImageID")

            Dim db As DbAccessLayer.MySqlDbAccess = New DbAccessLayer.MySqlDbAccess(CommonSettingManager.ConnectionString(), DbAccessLayer.ConnectionStringSourceType.MySetting)

            Dim value As String = CStr(db.GetScalarFromProcedure("stpDad_settingsSelValue", params))

            If db.HasError Then Return Nothing

            Return value

        End Function

#Region "Temp"

        Private Shared GhavaninForm As System.Windows.Forms.Form
        Private Shared CurAlarms As System.Windows.Forms.Form
        Private Shared CurFinanceSearchFun As System.Windows.Forms.Form
        Private Shared CurTimingSearchFun As System.Windows.Forms.Form
        Private Shared frmDoUpdate As System.Windows.Forms.Form

        Public Shared Property SetGhavaninForm() As System.Windows.Forms.Form
            Get
                Return GhavaninForm
            End Get
            Set(ByVal value As System.Windows.Forms.Form)
                GhavaninForm = value
            End Set
        End Property

        Private Shared ContactSearch As System.Windows.Forms.Form

        Public Shared Property SetCurAlarm() As System.Windows.Forms.Form
            Get
                Return CurAlarms
            End Get
            Set(ByVal value As System.Windows.Forms.Form)
                CurAlarms = value
            End Set
        End Property

        Public Shared Property SetFinanceSearchFun() As System.Windows.Forms.Form
            Get
                Return CurFinanceSearchFun
            End Get
            Set(ByVal value As System.Windows.Forms.Form)
                CurFinanceSearchFun = value
            End Set
        End Property

        Public Shared Property SetTimingSearchFun() As System.Windows.Forms.Form
            Get
                Return CurTimingSearchFun
            End Get
            Set(ByVal value As System.Windows.Forms.Form)
                CurTimingSearchFun = value
            End Set
        End Property

        Public Shared Property SetContactSearch() As System.Windows.Forms.Form
            Get
                Return GhavaninForm
            End Get
            Set(ByVal value As System.Windows.Forms.Form)
                GhavaninForm = value
            End Set
        End Property

        Public Shared Property SetDoUpdate() As System.Windows.Forms.Form
            Get
                Return frmDoUpdate
            End Get
            Set(ByVal value As System.Windows.Forms.Form)
                frmDoUpdate = value
            End Set
        End Property

        'Shared
        Private Shared _frmMaileSetting As Windows.Forms.Form
        Public Shared Property frmMaileSetting() As Windows.Forms.Form
            Get
                Return _frmMaileSetting
            End Get
            Set(ByVal value As Windows.Forms.Form)
                _frmMaileSetting = value
            End Set
        End Property


#End Region

    End Class




End Namespace

