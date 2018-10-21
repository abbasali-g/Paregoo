<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCContactSearch
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
        Me.lvContacts = New System.Windows.Forms.ListView()
        Me.custFullName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.custCellPhone = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.custOfficeTel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ctxContactMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxMenuNewAddNewUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMenuDeleteSelectedUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMenuPrintList = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.cmbContactType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstviewDisplayItems = New System.Windows.Forms.ComboBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.ctxMenuSmsSendToList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMenuSmsSendToSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxContactMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvContacts
        '
        Me.lvContacts.AllowColumnReorder = True
        Me.lvContacts.AllowDrop = True
        Me.lvContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvContacts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.custFullName, Me.custCellPhone, Me.custOfficeTel})
        Me.lvContacts.ContextMenuStrip = Me.ctxContactMenu
        Me.lvContacts.FullRowSelect = True
        Me.lvContacts.GridLines = True
        Me.lvContacts.Location = New System.Drawing.Point(6, 63)
        Me.lvContacts.Name = "lvContacts"
        Me.lvContacts.RightToLeftLayout = True
        Me.lvContacts.ShowItemToolTips = True
        Me.lvContacts.Size = New System.Drawing.Size(503, 439)
        Me.lvContacts.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvContacts.TabIndex = 0
        Me.lvContacts.UseCompatibleStateImageBehavior = False
        '
        'custFullName
        '
        Me.custFullName.Tag = "custFullName"
        Me.custFullName.Text = "مشخصات"
        Me.custFullName.Width = 200
        '
        'custCellPhone
        '
        Me.custCellPhone.Tag = "custCellPhone"
        Me.custCellPhone.Text = "شماره همراه"
        Me.custCellPhone.Width = 120
        '
        'custOfficeTel
        '
        Me.custOfficeTel.Tag = "custOfficeTel"
        Me.custOfficeTel.Text = "شماره تلفن"
        Me.custOfficeTel.Width = 120
        '
        'ctxContactMenu
        '
        Me.ctxContactMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxMenuNewAddNewUser, Me.ctxMenuDeleteSelectedUsers, Me.ctxMenuPrintList, Me.ctxMenuSmsSendToList, Me.ctxMenuSmsSendToSelected})
        Me.ctxContactMenu.Name = "ctxContactMenu"
        Me.ctxContactMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ctxContactMenu.Size = New System.Drawing.Size(222, 114)
        '
        'ctxMenuNewAddNewUser
        '
        Me.ctxMenuNewAddNewUser.Image = Global.WFControls.VB.My.Resources.Resources.AddCat16
        Me.ctxMenuNewAddNewUser.Name = "ctxMenuNewAddNewUser"
        Me.ctxMenuNewAddNewUser.Size = New System.Drawing.Size(221, 22)
        Me.ctxMenuNewAddNewUser.Text = "ایجاد فرد جدید"
        '
        'ctxMenuDeleteSelectedUsers
        '
        Me.ctxMenuDeleteSelectedUsers.Image = Global.WFControls.VB.My.Resources.Resources.DeleteCat
        Me.ctxMenuDeleteSelectedUsers.Name = "ctxMenuDeleteSelectedUsers"
        Me.ctxMenuDeleteSelectedUsers.Size = New System.Drawing.Size(221, 22)
        Me.ctxMenuDeleteSelectedUsers.Text = "حذف کاربر انتخاب شده"
        '
        'ctxMenuPrintList
        '
        Me.ctxMenuPrintList.Image = Global.WFControls.VB.My.Resources.Resources.printerWeb
        Me.ctxMenuPrintList.Name = "ctxMenuPrintList"
        Me.ctxMenuPrintList.Size = New System.Drawing.Size(221, 22)
        Me.ctxMenuPrintList.Text = "چاپ لیست"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(413, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "نام خانوادگی/تلفن:"
        '
        'txtFullName
        '
        Me.txtFullName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFullName.Location = New System.Drawing.Point(304, 34)
        Me.txtFullName.MaxLength = 100
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(108, 22)
        Me.txtFullName.TabIndex = 2
        '
        'cmbContactType
        '
        Me.cmbContactType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbContactType.FormattingEnabled = True
        Me.cmbContactType.Location = New System.Drawing.Point(176, 34)
        Me.cmbContactType.Name = "cmbContactType"
        Me.cmbContactType.Size = New System.Drawing.Size(91, 22)
        Me.cmbContactType.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(269, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "نوع :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 14)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "نمایش"
        Me.Label3.Visible = False
        '
        'lstviewDisplayItems
        '
        Me.lstviewDisplayItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstviewDisplayItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstviewDisplayItems.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lstviewDisplayItems.FormattingEnabled = True
        Me.lstviewDisplayItems.Items.AddRange(New Object() {"LargeIcon", "Details", "SmallIcon", "List", "Title"})
        Me.lstviewDisplayItems.Location = New System.Drawing.Point(37, 34)
        Me.lstviewDisplayItems.Name = "lstviewDisplayItems"
        Me.lstviewDisplayItems.Size = New System.Drawing.Size(87, 21)
        Me.lstviewDisplayItems.TabIndex = 16
        Me.lstviewDisplayItems.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Image = Global.WFControls.VB.My.Resources.Resources.printerWeb
        Me.btnPrint.Location = New System.Drawing.Point(145, 34)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(25, 22)
        Me.btnPrint.TabIndex = 18
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'ctxMenuSmsSendToList
        '
        Me.ctxMenuSmsSendToList.Image = Global.WFControls.VB.My.Resources.Resources.AddPic
        Me.ctxMenuSmsSendToList.Name = "ctxMenuSmsSendToList"
        Me.ctxMenuSmsSendToList.Size = New System.Drawing.Size(221, 22)
        Me.ctxMenuSmsSendToList.Text = "ارسال پیامک به لیست"
        '
        'ctxMenuSmsSendToSelected
        '
        Me.ctxMenuSmsSendToSelected.Image = Global.WFControls.VB.My.Resources.Resources.row_gray
        Me.ctxMenuSmsSendToSelected.Name = "ctxMenuSmsSendToSelected"
        Me.ctxMenuSmsSendToSelected.Size = New System.Drawing.Size(221, 22)
        Me.ctxMenuSmsSendToSelected.Text = "ارسال پیامک به انتخاب شده ها"
        '
        'UCContactSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lstviewDisplayItems)
        Me.Controls.Add(Me.cmbContactType)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvContacts)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "UCContactSearch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(522, 503)
        Me.ctxContactMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvContacts As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents cmbContactType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstviewDisplayItems As System.Windows.Forms.ComboBox
    Friend WithEvents custFullName As System.Windows.Forms.ColumnHeader
    Friend WithEvents custCellPhone As System.Windows.Forms.ColumnHeader
    Friend WithEvents custOfficeTel As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents ctxContactMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxMenuNewAddNewUser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenuDeleteSelectedUsers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenuPrintList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenuSmsSendToList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenuSmsSendToSelected As System.Windows.Forms.ToolStripMenuItem

End Class
