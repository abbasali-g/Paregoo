Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.TimeParties

Public Class frmPostPone

#Region "Events"


    Private tp As New TimeParties

    Sub New(ByVal tpID As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        tp.tpID = tpID

    End Sub

    Private Sub dadMessageBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' HideMinimize = True

        btnOk.Focus()

        Me.ActiveControl = btnOk

        lblMessage.Text = String.Empty

    End Sub

    Private Sub bindElements()

        Try

            tp = TimePartiesManager.GetTimePartiesInfoByID(tp.tpID)

            If tp.timeReminderType.HasValue Then

                cmbReminderType.SelectedIndex = tp.timeReminderType

            Else
                cmbReminderType.SelectedIndex = 0

            End If

            txtReminder.Text = tp.timeReminderBefore()


        Catch ex As Exception

            lblMessage.Text = "خطا در بارگذاری"

        End Try
       
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        'Dim d As Date

        'Dim g As New GeneralUtilities.DateConvertor(CommonSettingManager.ConnectionString())

        'Dim miladiD As Date = g.GetMiladiDate(TimingDate.GetShamsiDate)

        'Dim AlarmDate As New Date(miladiD.Year, miladiD.Month, miladiD.Day, TimingTime.Value.Hour, TimingTime.Value.Minute, TimingTime.Value.Second)


        'Select Case cmbReminderType.SelectedIndex


        '    Case 0
        '        'دقیقه
        '        d = DateAdd(DateInterval.Minute, -CDbl(txtReminder.Text), AlarmDate)

        '    Case 1
        '        'ساعت
        '        d = DateAdd(DateInterval.Hour, -CDbl(txtReminder.Text), AlarmDate)

        '    Case 2
        '        'روز
        '        d = DateAdd(DateInterval.DayOfYear, -CDbl(txtReminder.Text), AlarmDate)

        'End Select

        'timeParties.timeActualTime = d.Hour.ToString().PadLeft(2, "0"c) & ":" & d.Minute.ToString().PadLeft(2, "0"c) & ":" & d.Second.ToString().PadLeft(2, "0"c)

        'Me.DialogResult = Windows.Forms.DialogResult.Yes

    End Sub

    Private Sub btnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancle.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub


#End Region

#Region "Methods"

    Public Function ShowMessage() As System.Windows.Forms.DialogResult

        Return Me.ShowDialog()

    End Function

#End Region


End Class