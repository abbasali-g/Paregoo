<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewFinanceAdd
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
        Me.components = New System.ComponentModel.Container
        Dim FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdbDaryafti = New System.Windows.Forms.RadioButton
        Me.rdbHazine = New System.Windows.Forms.RadioButton
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.pnlHazine = New System.Windows.Forms.Panel
        Me.txtAmountHazine = New WFControls.VB.AmountControl
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbFinanceType = New System.Windows.Forms.ComboBox
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolstripDelComboItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlPaymentType = New System.Windows.Forms.Panel
        Me.txtAmountDaryafti = New WFControls.VB.AmountControl
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbPaymentType = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.financePaymentDate = New WFControls.VB.RmanShamsiDate
        Me.Label11 = New System.Windows.Forms.Label
        Me.pnlCheq = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtCheckDate = New WFControls.VB.RmanShamsiDate
        Me.txtCheckSerial = New System.Windows.Forms.TextBox
        Me.cmbBank = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.pnlMsg = New System.Windows.Forms.Panel
        Me.lblMessage = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlHazine.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.pnlPaymentType.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlCheq.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        FlowLayoutPanel1.AutoSize = True
        FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        FlowLayoutPanel1.Controls.Add(Me.Panel1)
        FlowLayoutPanel1.Controls.Add(Me.pnlHazine)
        FlowLayoutPanel1.Controls.Add(Me.pnlPaymentType)
        FlowLayoutPanel1.Controls.Add(Me.Panel2)
        FlowLayoutPanel1.Controls.Add(Me.pnlCheq)
        FlowLayoutPanel1.Controls.Add(Me.Panel4)
        FlowLayoutPanel1.Controls.Add(Me.pnlMsg)
        FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New System.Drawing.Size(422, 390)
        FlowLayoutPanel1.TabIndex = 76
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdbDaryafti)
        Me.Panel1.Controls.Add(Me.rdbHazine)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(8, 1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(413, 34)
        Me.Panel1.TabIndex = 0
        '
        'rdbDaryafti
        '
        Me.rdbDaryafti.AutoSize = True
        Me.rdbDaryafti.Location = New System.Drawing.Point(99, 9)
        Me.rdbDaryafti.Name = "rdbDaryafti"
        Me.rdbDaryafti.Size = New System.Drawing.Size(104, 18)
        Me.rdbDaryafti.TabIndex = 3
        Me.rdbDaryafti.Text = "دریافتی از موکل"
        Me.rdbDaryafti.UseVisualStyleBackColor = True
        '
        'rdbHazine
        '
        Me.rdbHazine.AutoSize = True
        Me.rdbHazine.Checked = True
        Me.rdbHazine.Location = New System.Drawing.Point(224, 10)
        Me.rdbHazine.Name = "rdbHazine"
        Me.rdbHazine.Size = New System.Drawing.Size(132, 18)
        Me.rdbHazine.TabIndex = 2
        Me.rdbHazine.TabStop = True
        Me.rdbHazine.Text = "ثبت بدهی برای موکل"
        Me.rdbHazine.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(413, 34)
        Me.ShapeContainer1.TabIndex = 26
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 5
        Me.RectangleShape2.Location = New System.Drawing.Point(23, 6)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(359, 24)
        '
        'pnlHazine
        '
        Me.pnlHazine.Controls.Add(Me.txtAmountHazine)
        Me.pnlHazine.Controls.Add(Me.Label9)
        Me.pnlHazine.Controls.Add(Me.Label10)
        Me.pnlHazine.Controls.Add(Me.cmbFinanceType)
        Me.pnlHazine.Location = New System.Drawing.Point(14, 37)
        Me.pnlHazine.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlHazine.Name = "pnlHazine"
        Me.pnlHazine.Size = New System.Drawing.Size(407, 28)
        Me.pnlHazine.TabIndex = 77
        '
        'txtAmountHazine
        '
        Me.txtAmountHazine.Amount = 0
        Me.txtAmountHazine.Location = New System.Drawing.Point(6, 5)
        Me.txtAmountHazine.Name = "txtAmountHazine"
        Me.txtAmountHazine.Size = New System.Drawing.Size(116, 22)
        Me.txtAmountHazine.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(331, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 14)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "نوع  :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(123, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 14)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "مبلغ :"
        '
        'cmbFinanceType
        '
        Me.cmbFinanceType.ContextMenuStrip = Me.ContextMenuStrip2
        Me.cmbFinanceType.DisplayMember = "settingName"
        Me.cmbFinanceType.FormattingEnabled = True
        Me.cmbFinanceType.Location = New System.Drawing.Point(202, 5)
        Me.cmbFinanceType.MaxLength = 150
        Me.cmbFinanceType.Name = "cmbFinanceType"
        Me.cmbFinanceType.Size = New System.Drawing.Size(122, 22)
        Me.cmbFinanceType.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.cmbFinanceType, "آیتم های این لیست قابل حذف/اضافه است")
        Me.cmbFinanceType.ValueMember = "settingValue"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolstripDelComboItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(96, 26)
        '
        'ToolstripDelComboItem
        '
        Me.ToolstripDelComboItem.Image = Global.WFControls.VB.My.Resources.Resources.DeleteCat
        Me.ToolstripDelComboItem.Name = "ToolstripDelComboItem"
        Me.ToolstripDelComboItem.Size = New System.Drawing.Size(95, 22)
        Me.ToolstripDelComboItem.Text = "حذف"
        '
        'pnlPaymentType
        '
        Me.pnlPaymentType.Controls.Add(Me.txtAmountDaryafti)
        Me.pnlPaymentType.Controls.Add(Me.Label3)
        Me.pnlPaymentType.Controls.Add(Me.Label2)
        Me.pnlPaymentType.Controls.Add(Me.cmbPaymentType)
        Me.pnlPaymentType.Location = New System.Drawing.Point(14, 67)
        Me.pnlPaymentType.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlPaymentType.Name = "pnlPaymentType"
        Me.pnlPaymentType.Size = New System.Drawing.Size(407, 30)
        Me.pnlPaymentType.TabIndex = 25
        '
        'txtAmountDaryafti
        '
        Me.txtAmountDaryafti.Amount = 0
        Me.txtAmountDaryafti.Location = New System.Drawing.Point(3, 5)
        Me.txtAmountDaryafti.Name = "txtAmountDaryafti"
        Me.txtAmountDaryafti.Size = New System.Drawing.Size(119, 22)
        Me.txtAmountDaryafti.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(125, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "مبلغ :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(329, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "نوع پرداخت :"
        '
        'cmbPaymentType
        '
        Me.cmbPaymentType.DisplayMember = "settingName"
        Me.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentType.FormattingEnabled = True
        Me.cmbPaymentType.Location = New System.Drawing.Point(202, 5)
        Me.cmbPaymentType.MaxLength = 150
        Me.cmbPaymentType.Name = "cmbPaymentType"
        Me.cmbPaymentType.Size = New System.Drawing.Size(122, 22)
        Me.cmbPaymentType.TabIndex = 2
        Me.cmbPaymentType.ValueMember = "settingValue"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.financePaymentDate)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Location = New System.Drawing.Point(14, 99)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(407, 30)
        Me.Panel2.TabIndex = 78
        '
        'financePaymentDate
        '
        Me.financePaymentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.financePaymentDate.Location = New System.Drawing.Point(204, 2)
        Me.financePaymentDate.Name = "financePaymentDate"
        Me.financePaymentDate.Size = New System.Drawing.Size(121, 27)
        Me.financePaymentDate.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(325, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 14)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "تاریخ پرداخت : "
        '
        'pnlCheq
        '
        Me.pnlCheq.Controls.Add(Me.GroupBox1)
        Me.pnlCheq.Location = New System.Drawing.Point(1, 131)
        Me.pnlCheq.Margin = New System.Windows.Forms.Padding(1)
        Me.pnlCheq.Name = "pnlCheq"
        Me.pnlCheq.Size = New System.Drawing.Size(420, 83)
        Me.pnlCheq.TabIndex = 26
        Me.pnlCheq.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCheckDate)
        Me.GroupBox1.Controls.Add(Me.txtCheckSerial)
        Me.GroupBox1.Controls.Add(Me.cmbBank)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbBranch)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(402, 78)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مشخصات چک"
        '
        'txtCheckDate
        '
        Me.txtCheckDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtCheckDate.Location = New System.Drawing.Point(7, 44)
        Me.txtCheckDate.Name = "txtCheckDate"
        Me.txtCheckDate.Size = New System.Drawing.Size(121, 27)
        Me.txtCheckDate.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.txtCheckDate, "آیتم های این لیست قابل حذف/اضافه است")
        '
        'txtCheckSerial
        '
        Me.txtCheckSerial.Location = New System.Drawing.Point(8, 20)
        Me.txtCheckSerial.MaxLength = 45
        Me.txtCheckSerial.Name = "txtCheckSerial"
        Me.txtCheckSerial.Size = New System.Drawing.Size(119, 22)
        Me.txtCheckSerial.TabIndex = 6
        '
        'cmbBank
        '
        Me.cmbBank.ContextMenuStrip = Me.ContextMenuStrip2
        Me.cmbBank.DisplayMember = "settingName"
        Me.cmbBank.FormattingEnabled = True
        Me.cmbBank.Location = New System.Drawing.Point(214, 20)
        Me.cmbBank.MaxLength = 150
        Me.cmbBank.Name = "cmbBank"
        Me.cmbBank.Size = New System.Drawing.Size(122, 22)
        Me.cmbBank.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cmbBank, "آیتم های این لیست قابل حذف/اضافه است")
        Me.cmbBank.ValueMember = "settingValue"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(339, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "شعبه :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(129, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "تاریخ چک :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(130, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 14)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "شماره چک :"
        '
        'cmbBranch
        '
        Me.cmbBranch.ContextMenuStrip = Me.ContextMenuStrip2
        Me.cmbBranch.DisplayMember = "settingName"
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(214, 49)
        Me.cmbBranch.MaxLength = 150
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(122, 22)
        Me.cmbBranch.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.cmbBranch, "آیتم های این لیست قابل حذف/اضافه است")
        Me.cmbBranch.ValueMember = "settingValue"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(340, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "بانک :"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.txtDescription)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Location = New System.Drawing.Point(10, 216)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(411, 147)
        Me.Panel4.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(323, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "سایر توضیحات"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(10, 27)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(391, 73)
        Me.txtDescription.TabIndex = 9
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.WFControls.VB.My.Resources.Resources.pill_shaped_002
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(150, 107)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 29)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "ذخیره"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(0, 364)
        Me.pnlMsg.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(422, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(8, 5)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(396, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "lblMessage"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'NewFinanceAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Controls.Add(FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Name = "NewFinanceAdd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(422, 390)
        FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlHazine.ResumeLayout(False)
        Me.pnlHazine.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.pnlPaymentType.ResumeLayout(False)
        Me.pnlPaymentType.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlCheq.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCheckSerial As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdbDaryafti As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHazine As System.Windows.Forms.RadioButton
    Friend WithEvents cmbBank As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbFinanceType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlPaymentType As System.Windows.Forms.Panel
    Friend WithEvents pnlCheq As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtAmountHazine As WFControls.VB.AmountControl
    Friend WithEvents txtCheckDate As WFControls.VB.RmanShamsiDate
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolstripDelComboItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlHazine As System.Windows.Forms.Panel
    Friend WithEvents txtAmountDaryafti As WFControls.VB.AmountControl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents financePaymentDate As WFControls.VB.RmanShamsiDate
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
