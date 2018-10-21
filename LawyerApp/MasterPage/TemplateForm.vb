Public Class TemplateForm

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim tSize As Size = TextRenderer.MeasureText(Me.Text, Me.Font)
        Dim borderRect As Rectangle = e.ClipRectangle
        borderRect.Y = (borderRect.Y _
                    + (tSize.Height / 2))
        borderRect.Height = (borderRect.Height _
                    - (tSize.Height / 2))
        ControlPaint.DrawBorder(e.Graphics, borderRect, Color.Azure, ButtonBorderStyle.Solid)
        Dim textRect As Rectangle = e.ClipRectangle
        textRect.X = (textRect.X + 6)
        textRect.Width = tSize.Width
        textRect.Height = tSize.Height
        e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), textRect)
        e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), textRect)
    End Sub


   
    Private Sub TemplateForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As String = IO.Path.GetDirectoryName("E:\Lawyer\Solution\LawyerClient\bin\Debug\lawyer\e.exe")

    End Sub
End Class