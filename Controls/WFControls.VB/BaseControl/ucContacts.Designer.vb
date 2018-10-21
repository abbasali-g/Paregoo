<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucContacts
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtContacts = New System.Windows.Forms.TextBox()
        Me.btnShowDetail = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.btnRefresh.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.refresh2
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(16, 2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(14, 14)
        Me.btnRefresh.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.btnRefresh, "تازه گردانی")
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.btnClose.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.ok16_12
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(2, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(11, 11)
        Me.btnClose.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnClose, "بستن")
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'txtContacts
        '
        Me.txtContacts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtContacts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtContacts.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.txtContacts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtContacts.Location = New System.Drawing.Point(51, 3)
        Me.txtContacts.Name = "txtContacts"
        Me.txtContacts.Size = New System.Drawing.Size(146, 13)
        Me.txtContacts.TabIndex = 0
        '
        'btnShowDetail
        '
        Me.btnShowDetail.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.btnShowDetail.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.AddCat16
        Me.btnShowDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnShowDetail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowDetail.FlatAppearance.BorderSize = 0
        Me.btnShowDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowDetail.Location = New System.Drawing.Point(33, 3)
        Me.btnShowDetail.Name = "btnShowDetail"
        Me.btnShowDetail.Size = New System.Drawing.Size(14, 14)
        Me.btnShowDetail.TabIndex = 14
        Me.btnShowDetail.Text = "اضافه"
        Me.ToolTip1.SetToolTip(Me.btnShowDetail, "اضافه کردن")
        Me.btnShowDetail.UseVisualStyleBackColor = False
        '
        'ucContacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.btnShowDetail)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.txtContacts)
        Me.Name = "ucContacts"
        Me.Size = New System.Drawing.Size(200, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtContacts As System.Windows.Forms.TextBox
    Friend WithEvents btnShowDetail As System.Windows.Forms.Button

End Class
