Imports Lawyer.Common.VB.LawyerError
Imports Lawyer.Common.VB.Timing
Imports Lawyer.Common.VB.CommonSetting
Imports Lawyer.Common.VB.TimeParties

Public Class NewShowCurTask



    'Private Sub ShowCurTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    '    Try
    '        Dim str As String = String.Empty

    '        Dim a As ArrayList = TimingManager.TimingSearch()

    '        If a IsNot Nothing Then


    '            For index As Integer = 0 To a.Count - 1

    '                str &= vbCrLf & index + 1 & "- " & a.Item(0)
    '            Next

    '        End If


    '        txtContent.Text = str




    '    Catch ex As Exception

    '        ErrorManager.WriteMessage("ShowCurTask_Load", ex.ToString(), Me.Text)

    '    End Try

    'End Sub


    Private Sub BindTiming()
        Try

        
            DataGridView1.Columns.Clear()
            DataGridView1.DataSource = Nothing

            'Dim gvClmTitle As New System.Windows.Forms.DataGridViewLinkColumn
            Dim gvClmType As New System.Windows.Forms.DataGridViewLinkColumn
            Dim gvClmDate As New System.Windows.Forms.DataGridViewTextBoxColumn
            Dim gvClmID As New System.Windows.Forms.DataGridViewTextBoxColumn
            Dim gvclmDone As New System.Windows.Forms.DataGridViewCheckBoxColumn
            Dim gvClmTime As New System.Windows.Forms.DataGridViewTextBoxColumn
            Dim gvClmT As New System.Windows.Forms.DataGridViewTextBoxColumn
            'gvClmT

            'gvClmTitle.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            'gvClmTitle.DataPropertyName = "timeTitle"
            'gvClmTitle.HeaderText = ""
            'gvClmTitle.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            'gvClmTitle.Name = "timeTitle"
            'gvClmTitle.ReadOnly = True
            'gvClmTitle.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            'gvClmTitle.Width = 70
            'gvClmTitle.LinkBehavior = LinkBehavior.NeverUnderline

            'gvClmType
            '
            gvClmType.DataPropertyName = "timeTypeName"
            gvClmType.HeaderText = ""
            gvClmType.Name = "timeTypeName"
            gvClmType.ReadOnly = True
            gvClmType.Width = 80
            gvClmType.ReadOnly = True
            gvClmType.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            gvClmType.LinkBehavior = LinkBehavior.NeverUnderline
            '
            'gvClmDate
            '
            gvClmTime.DataPropertyName = "timeTime"
            gvClmTime.HeaderText = ""
            gvClmTime.Name = "timeTime"
            gvClmTime.ReadOnly = True
            gvClmTime.Width = 60

            gvClmDate.DataPropertyName = "timeDate"
            gvClmDate.HeaderText = ""
            gvClmDate.Name = "timeDate"
            gvClmDate.ReadOnly = True
            gvClmDate.Width = 70
            '
            'gvClmID
            '
            gvClmT.DataPropertyName = "timeType"
            gvClmT.HeaderText = ""
            gvClmT.Name = "timeType"
            gvClmT.ReadOnly = True
            gvClmT.Visible = False

            gvClmID.DataPropertyName = "tpID"
            gvClmID.HeaderText = ""
            gvClmID.Name = "tpID"
            gvClmID.ReadOnly = True
            gvClmID.Visible = False

            'gvClmcheck
            '
            gvclmDone.DataPropertyName = "timeDone"
            gvclmDone.HeaderText = ""
            gvclmDone.Name = "timeDone"
            gvclmDone.ReadOnly = True
            gvclmDone.Width = 20
            gvclmDone.FlatStyle = FlatStyle.Flat

            Dim dgvBC As New DataGridViewButtonColumn
            With dgvBC
                .Name = "Select"
                .HeaderText = ""
                .Text = "به تعویق انداختن"
                .Width = 100
                .UseColumnTextForButtonValue = True
            End With


            Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {gvClmID, gvclmDone, gvClmType, gvClmDate, gvClmTime, dgvBC, gvClmT})

            Dim b As New BindingSource

            DataGridView1.AutoGenerateColumns = False

            Dim list As TimePartiesReviewCollection = TimePartiesManager.GetCurrentTiming()


            For Each Item As TimePartiesReview In list

                Dim dr As Integer = DataGridView1.Rows.Add()

                DataGridView1.Rows(dr).Cells("timeTypeName").Value = Item.timeTypeName

                DataGridView1.Rows(dr).Cells("timeTime").Value = Item.timeTime

                DataGridView1.Rows(dr).Cells("tpID").Value = Item.tpID

                DataGridView1.Rows(dr).Cells("timeDone").Value = Item.timeDone

                DataGridView1.Rows(dr).Cells("timeDate").Value = Item.timeDate

                DataGridView1.Rows(dr).Cells("timeType").Value = Item.timeType

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try

            If e.ColumnIndex = 1 Then

                Dim IsCheck As Boolean = DataGridView1.Rows(e.RowIndex).Cells("timeDone").Value

                Dim result As Boolean = TimePartiesManager.EditTimingDoneField(DataGridView1.Rows(e.RowIndex).Cells("tpID").Value, Not IsCheck)

                If result Then

                    If IsCheck Then

                        DataGridView1.Rows(e.RowIndex).Cells("timeDone").Value = 0

                    Else
                        DataGridView1.Rows(e.RowIndex).Cells("timeDone").Value = 1


                    End If

                End If

                'ElseIf e.ColumnIndex = 2 Then

                '    If DataGridView1.Rows(e.RowIndex).Cells("timeType").Value = "4" Then

                '        Dim f As New MoshavereView(DataGridView1.Rows(e.RowIndex).Cells("tpID").Value, "")

                '        f.Show()

                '    Else


                '        Dim f As New TimingView(DataGridView1.Rows(e.RowIndex).Cells("tpID").Value)

                '        f.Show()

                '    End If

                '    BindTiming()

            ElseIf e.ColumnIndex = 5 Then

                If DataGridView1.Rows(e.RowIndex).Cells("timeType").Value = "4" Then

                    Dim f As New MoshavereView(DataGridView1.Rows(e.RowIndex).Cells("tpID").Value, "")

                    f.ShowDialog()

                Else


                    Dim f As New TimingView(DataGridView1.Rows(e.RowIndex).Cells("tpID").Value)

                    f.ShowDialog()

                End If

                BindTiming()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Function IsHasContent()

        Try

            BindTiming()

            If DataGridView1.RowCount > 0 Then

                Return True

            Else

                Return False

            End If

        Catch ex As Exception

            ErrorManager.WriteMessage("IsHasContent", ex.ToString(), Me.Text)

            Return False

        End Try

    End Function


    'Public Overrides Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Me.Hide()

    'End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Me.Hide()

    End Sub

  
    Private Sub NewShowCurTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BindTiming()

    End Sub

End Class