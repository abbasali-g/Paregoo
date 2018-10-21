Imports Lawyer.Common.VB.Books
Imports Lawyer.Common.VB.LawyerError

Public Class CaseAdd


#Region " Load "

    Private Sub CaseAdd_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ActiveControl = Me.txtName
    End Sub

    Private Sub CaseAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblMessage.Text = String.Empty

    End Sub

#End Region

#Region " Command "

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            Dim BookCase As New BookCase
            BookCase.shelfID = Guid.NewGuid
            BookCase.shelfName = txtName.Text

            BookCaseManager.InsertCase(BookCase)


            Dim BookView As New BookView
            BookView = Me.Owner ' Access to Parent
            BookView.FillLv = True

            Me.Close()

        Catch ex As Exception
            Me.lblMessage.Text = "خطا در ایجاد قفسه"
            ErrorManager.WriteMessage("btnSave_Click()", ex.ToString, Me.Text)
        End Try


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

#End Region



End Class