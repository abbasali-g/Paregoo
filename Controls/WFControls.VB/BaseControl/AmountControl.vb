Public Class AmountControl : Inherits TextBox

    Public Property Amount() As Double

        Get

            If Me.Text = String.Empty Then

                Return 0

            Else

                Return CDbl(Me.Text.Replace(",", ""))

            End If

        End Get

        Set(ByVal value As Double)

            If Me.Text = String.Empty AndAlso Me.ReadOnly Then

                showZeroAmount()

            Else

                Me.Text = value

            End If


        End Set

    End Property

    Private Sub showZeroAmount()

        RemoveHandler Me.TextChanged, New EventHandler(AddressOf tb_TextChanged)

        Me.Text = "0"

        AddHandler Me.TextChanged, New EventHandler(AddressOf tb_TextChanged)

    End Sub

    Public Sub Reset()

        Me.Text = String.Empty

    End Sub

    Public Sub New()

        AddHandler Me.TextChanged, New EventHandler(AddressOf tb_TextChanged)
        AddHandler Me.KeyPress, New KeyPressEventHandler(AddressOf Me_KeyPress)

    End Sub

    Private Sub Me_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Try

            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then

                e.Handled = True

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub tb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim value As String = Me.Text.Replace(",", "")

        Dim ul As ULong

        If ULong.TryParse(value, ul) Then

            RemoveHandler Me.TextChanged, New EventHandler(AddressOf tb_TextChanged)

            Me.Text = String.Format("{0:#,#}", ul)

            Me.SelectionStart = Me.Text.Length

            AddHandler Me.TextChanged, New EventHandler(AddressOf tb_TextChanged)

        End If

    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'AmountControl
        '
        Me.MaxLength = 20
        Me.ResumeLayout(False)

    End Sub
End Class
