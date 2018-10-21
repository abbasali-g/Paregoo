Imports LawyerCommonControls.CommonVB
Imports System.Windows.Forms

Public Class RmanShamsiDate

#Region "Event"

    Private Sub ShamsiDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter

        txtYear.Focus()

    End Sub

    Private Sub txtMonth_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonth.Leave

        UpdateMonth()

        UpdateDay()

    End Sub

    Private Sub txtMonth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonth.KeyPress, txtDay.KeyPress, txtYear.KeyPress

        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

            e.Handled = True

        End If

    End Sub

    Private Sub txtDay_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDay.Leave

        UpdateDay()

    End Sub

    Private Sub txtYear_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYear.Leave

        If txtYear.Text <> String.Empty AndAlso txtYear.Text.Substring(0, 1) = "0" Then

            If txtYear.Text.Length > 1 Then

                txtYear.Text = "1" & txtYear.Text.Substring(1, txtYear.Text.Length - 1)
            Else

                txtYear.Text = "1"

            End If

        End If

        UpdateDay()

    End Sub

    Private Sub txtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYear.TextChanged

        If txtYear.Text.Length = 4 Then

            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)

        End If

    End Sub

    Private Sub txtMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonth.TextChanged

        If txtMonth.Text.Length = 2 Then

            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)

        End If

    End Sub

    Private Sub txtYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYear.KeyDown, txtMonth.KeyDown

        If e.KeyCode = Keys.Enter Then

            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)

        End If

    End Sub

#End Region

#Region "Utility"

    Private Sub UpdateMonth()

        If txtMonth.Text <> String.Empty Then

            If CInt(txtMonth.Text) > 13 OrElse CInt(txtMonth.Text) = 0 Then

                txtMonth.Text = 1

            End If

            txtMonth.Text = txtMonth.Text.PadLeft(2, "0"c)

        End If

    End Sub

    Private Sub UpdateDay()

        Try

            If txtMonth.Text <> String.Empty Then

                If CInt(txtMonth.Text) < 7 AndAlso CInt(txtDay.Text) > 31 Then

                    txtDay.Text = "31"

                ElseIf CInt(txtMonth.Text) >= 7 AndAlso CInt(txtMonth.Text) < 12 AndAlso CInt(txtDay.Text) > 30 Then

                    txtDay.Text = "30"

                ElseIf CInt(txtMonth.Text) = 12 Then

                    Dim pCalender As New System.Globalization.PersianCalendar

                    If txtYear.Text <> String.Empty AndAlso txtYear.Text.Length = 4 Then

                        If Not pCalender.IsLeapYear(CInt(txtYear.Text)) AndAlso CInt(txtDay.Text) > 29 Then

                            txtDay.Text = "29"

                        ElseIf CInt(txtDay.Text) > 30 Then

                            txtDay.Text = "30"

                        End If

                    ElseIf CInt(txtDay.Text) > 30 Then

                        txtDay.Text = "30"

                    End If


                End If

                txtDay.Text = txtDay.Text.PadLeft(2, "0"c)

            End If

        Catch ex As Exception

            txtDay.Text = "01"

        End Try


    End Sub

    Private Function ValueInNumericFormat() As Integer?

        Dim i As Integer?

        If txtYear.Text.Length < 4 OrElse txtMonth.Text.Length < 2 OrElse txtDay.Text.Length < 2 Then

            Return i

        End If

        Return CInt(txtYear.Text & txtMonth.Text & txtDay.Text)

    End Function

    Private Function Value() As String

        If txtYear.Text.Length < 4 OrElse txtMonth.Text.Length < 2 OrElse txtDay.Text.Length < 2 Then

            Return String.Empty

        End If

        Return (txtYear.Text & "/" & txtMonth.Text & "/" & txtDay.Text)

    End Function

    Private Sub ResetElements()

        txtYear.Text = String.Empty

        txtMonth.Text = String.Empty

        txtDay.Text = String.Empty

    End Sub



#End Region

#Region "Methods"

    Public ReadOnly Property GetShamsiDateInNumericFormat() As Integer?

        Get

            Return ValueInNumericFormat()

        End Get

    End Property

    Public ReadOnly Property GetShamsiDate() As String

        Get

            Return Value()

        End Get

    End Property

    Public WriteOnly Property SetToday() As Boolean

        Set(ByVal value As Boolean)

            If value Then

                SetShamsiDate(DateManager.GetCurrentShamsiDate())

            End If

        End Set

    End Property

    Public Sub SetShamsiDate(ByVal shamsiDate As String)

        If Not String.IsNullOrEmpty(shamsiDate) AndAlso shamsiDate.Length = 10 Then

            txtYear.Text = shamsiDate.Substring(0, 4)

            txtMonth.Text = shamsiDate.Substring(5, 2)

            txtDay.Text = shamsiDate.Substring(8, 2)

        Else

            ResetElements()

        End If

    End Sub

    Public Sub SetShamsiDateInNumericFormat(ByVal shamsiDate As String)

        If Not String.IsNullOrEmpty(shamsiDate) AndAlso shamsiDate.Length = 8 Then

            txtYear.Text = shamsiDate.Substring(0, 4)

            txtMonth.Text = shamsiDate.Substring(4, 2)

            txtDay.Text = shamsiDate.Substring(6, 2)

        Else

            ResetElements()

        End If

    End Sub

    Public Sub SetShamsiDate(ByVal shamsiDate As Integer?)

        Dim value As String = shamsiDate.ToString()

        If shamsiDate.HasValue AndAlso value.Length = 8 Then

            txtYear.Text = value.Substring(0, 4)

            txtMonth.Text = value.Substring(4, 2)

            txtDay.Text = value.Substring(6, 2)

        Else

            ResetElements()

        End If

    End Sub

    Public Sub ResetDate()

        txtYear.Text = String.Empty

        txtMonth.Text = String.Empty

        txtDay.Text = String.Empty

    End Sub

    Public WriteOnly Property ReadOnlyDate() As Boolean

        Set(ByVal value As Boolean)

            txtYear.ReadOnly = value

            txtMonth.ReadOnly = value

            txtDay.ReadOnly = value

        End Set

    End Property


#End Region

    Private Sub RmanShamsiDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtYear.Focus()
    End Sub

End Class
