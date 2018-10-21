<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Credit
    Inherits GlobalForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Credit))
        Me.cbbOldYear = New System.Windows.Forms.ComboBox()
        Me.cbbOldMonth = New System.Windows.Forms.ComboBox()
        Me.cbbNewYear = New System.Windows.Forms.ComboBox()
        Me.cbbNewMonth = New System.Windows.Forms.ComboBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdbCheque = New System.Windows.Forms.RadioButton()
        Me.rdbMony = New System.Windows.Forms.RadioButton()
        Me.ckbDead = New System.Windows.Forms.CheckBox()
        Me.rdbWoman = New System.Windows.Forms.RadioButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblGrayDate = New System.Windows.Forms.Label()
        Me.lblGrayAmount = New System.Windows.Forms.Label()
        Me.lblColorDate = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.acCreditNew = New WFControls.VB.AmountControl()
        Me.acCreditOld = New WFControls.VB.AmountControl()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitle.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbbOldYear
        '
        Me.cbbOldYear.FormattingEnabled = True
        Me.cbbOldYear.Items.AddRange(New Object() {"1385", "1386", "1387", "1388", "1389", "1390"})
        Me.cbbOldYear.Location = New System.Drawing.Point(255, 71)
        Me.cbbOldYear.Name = "cbbOldYear"
        Me.cbbOldYear.Size = New System.Drawing.Size(50, 21)
        Me.cbbOldYear.TabIndex = 5
        '
        'cbbOldMonth
        '
        Me.cbbOldMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbOldMonth.FormattingEnabled = True
        Me.cbbOldMonth.Location = New System.Drawing.Point(307, 71)
        Me.cbbOldMonth.Name = "cbbOldMonth"
        Me.cbbOldMonth.Size = New System.Drawing.Size(70, 21)
        Me.cbbOldMonth.TabIndex = 6
        '
        'cbbNewYear
        '
        Me.cbbNewYear.FormattingEnabled = True
        Me.cbbNewYear.Location = New System.Drawing.Point(8, 71)
        Me.cbbNewYear.Name = "cbbNewYear"
        Me.cbbNewYear.Size = New System.Drawing.Size(50, 21)
        Me.cbbNewYear.TabIndex = 7
        '
        'cbbNewMonth
        '
        Me.cbbNewMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbNewMonth.FormattingEnabled = True
        Me.cbbNewMonth.Location = New System.Drawing.Point(66, 71)
        Me.cbbNewMonth.Name = "cbbNewMonth"
        Me.cbbNewMonth.Size = New System.Drawing.Size(70, 21)
        Me.cbbNewMonth.TabIndex = 8
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.LawyerApp.My.Resources.Resources.money_Ok
        Me.PictureBox4.Location = New System.Drawing.Point(8, 98)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.PapayaWhip
        Me.Panel2.Controls.Add(Me.rdbCheque)
        Me.Panel2.Controls.Add(Me.rdbMony)
        Me.Panel2.Controls.Add(Me.ckbDead)
        Me.Panel2.Controls.Add(Me.rdbWoman)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(488, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(68, 171)
        Me.Panel2.TabIndex = 18
        '
        'rdbCheque
        '
        Me.rdbCheque.Checked = True
        Me.rdbCheque.Image = Global.LawyerApp.My.Resources.Resources.cheque
        Me.rdbCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbCheque.Location = New System.Drawing.Point(3, 7)
        Me.rdbCheque.Name = "rdbCheque"
        Me.rdbCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbCheque.Size = New System.Drawing.Size(55, 35)
        Me.rdbCheque.TabIndex = 18
        Me.rdbCheque.TabStop = True
        Me.rdbCheque.UseVisualStyleBackColor = True
        '
        'rdbMony
        '
        Me.rdbMony.Image = Global.LawyerApp.My.Resources.Resources.Money
        Me.rdbMony.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbMony.Location = New System.Drawing.Point(3, 45)
        Me.rdbMony.Name = "rdbMony"
        Me.rdbMony.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbMony.Size = New System.Drawing.Size(55, 35)
        Me.rdbMony.TabIndex = 15
        Me.rdbMony.UseVisualStyleBackColor = True
        '
        'ckbDead
        '
        Me.ckbDead.Image = Global.LawyerApp.My.Resources.Resources.dead
        Me.ckbDead.Location = New System.Drawing.Point(8, 115)
        Me.ckbDead.Name = "ckbDead"
        Me.ckbDead.Size = New System.Drawing.Size(50, 28)
        Me.ckbDead.TabIndex = 17
        Me.ckbDead.UseVisualStyleBackColor = True
        '
        'rdbWoman
        '
        Me.rdbWoman.Image = Global.LawyerApp.My.Resources.Resources.Woman
        Me.rdbWoman.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbWoman.Location = New System.Drawing.Point(3, 83)
        Me.rdbWoman.Name = "rdbWoman"
        Me.rdbWoman.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbWoman.Size = New System.Drawing.Size(55, 35)
        Me.rdbWoman.TabIndex = 16
        Me.rdbWoman.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.LawyerApp.My.Resources.Resources.calendar
        Me.PictureBox2.Location = New System.Drawing.Point(26, 17)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(96, 75)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.LawyerApp.My.Resources.Resources.Money_Black
        Me.PictureBox3.Location = New System.Drawing.Point(247, 98)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LawyerApp.My.Resources.Resources.calendar_Gray
        Me.PictureBox1.Location = New System.Drawing.Point(275, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(96, 75)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblGrayDate
        '
        Me.lblGrayDate.AutoSize = True
        Me.lblGrayDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.lblGrayDate.Location = New System.Drawing.Point(381, 74)
        Me.lblGrayDate.Name = "lblGrayDate"
        Me.lblGrayDate.Size = New System.Drawing.Size(79, 13)
        Me.lblGrayDate.TabIndex = 31
        Me.lblGrayDate.Text = "تاریخ سررسید :"
        '
        'lblGrayAmount
        '
        Me.lblGrayAmount.AutoSize = True
        Me.lblGrayAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.lblGrayAmount.Location = New System.Drawing.Point(381, 123)
        Me.lblGrayAmount.Name = "lblGrayAmount"
        Me.lblGrayAmount.Size = New System.Drawing.Size(101, 13)
        Me.lblGrayAmount.TabIndex = 32
        Me.lblGrayAmount.Text = "مبلغ قراردادی طلب :"
        '
        'lblColorDate
        '
        Me.lblColorDate.AutoSize = True
        Me.lblColorDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.lblColorDate.Location = New System.Drawing.Point(142, 74)
        Me.lblColorDate.Name = "lblColorDate"
        Me.lblColorDate.Size = New System.Drawing.Size(58, 13)
        Me.lblColorDate.TabIndex = 33
        Me.lblColorDate.Text = "تاریخ تادیه :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(142, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "مبلغ قابل پرداخت :"
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Label2)
        Me.pnlTitle.Location = New System.Drawing.Point(5, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(556, 23)
        Me.pnlTitle.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(359, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(191, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "محاسبه خسارت تاخیر تادیه و مهریه"
        '
        'pnlContent
        '
        Me.pnlContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.acCreditNew)
        Me.pnlContent.Controls.Add(Me.acCreditOld)
        Me.pnlContent.Controls.Add(Me.Panel2)
        Me.pnlContent.Controls.Add(Me.Label4)
        Me.pnlContent.Controls.Add(Me.lblColorDate)
        Me.pnlContent.Controls.Add(Me.lblGrayAmount)
        Me.pnlContent.Controls.Add(Me.cbbOldYear)
        Me.pnlContent.Controls.Add(Me.lblGrayDate)
        Me.pnlContent.Controls.Add(Me.cbbOldMonth)
        Me.pnlContent.Controls.Add(Me.cbbNewYear)
        Me.pnlContent.Controls.Add(Me.PictureBox4)
        Me.pnlContent.Controls.Add(Me.cbbNewMonth)
        Me.pnlContent.Controls.Add(Me.PictureBox1)
        Me.pnlContent.Controls.Add(Me.PictureBox2)
        Me.pnlContent.Controls.Add(Me.PictureBox3)
        Me.pnlContent.Location = New System.Drawing.Point(5, 24)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(556, 171)
        Me.pnlContent.TabIndex = 36
        '
        'acCreditNew
        '
        Me.acCreditNew.Amount = 0.0R
        Me.acCreditNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.acCreditNew.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.acCreditNew.Location = New System.Drawing.Point(35, 124)
        Me.acCreditNew.Name = "acCreditNew"
        Me.acCreditNew.Size = New System.Drawing.Size(100, 14)
        Me.acCreditNew.TabIndex = 36
        '
        'acCreditOld
        '
        Me.acCreditOld.Amount = 0.0R
        Me.acCreditOld.Location = New System.Drawing.Point(275, 121)
        Me.acCreditOld.Name = "acCreditOld"
        Me.acCreditOld.Size = New System.Drawing.Size(100, 21)
        Me.acCreditOld.TabIndex = 35
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(5, 201)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(556, 25)
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
        Me.lblMessage.Size = New System.Drawing.Size(541, 13)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "lblMessage"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ShowAlways = True
        '
        'Credit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MintCream
        Me.ClientSize = New System.Drawing.Size(566, 225)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.pnlContent)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Credit"
        Me.ToolTip1.SetToolTip(Me, "محاسبه خسارت تاخیر تادیه")
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents cbbOldYear As System.Windows.Forms.ComboBox
    Friend WithEvents cbbOldMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cbbNewYear As System.Windows.Forms.ComboBox
    Friend WithEvents cbbNewMonth As System.Windows.Forms.ComboBox
    Friend WithEvents rdbMony As System.Windows.Forms.RadioButton
    Friend WithEvents rdbWoman As System.Windows.Forms.RadioButton
    Friend WithEvents ckbDead As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblGrayDate As System.Windows.Forms.Label
    Friend WithEvents lblGrayAmount As System.Windows.Forms.Label
    Friend WithEvents lblColorDate As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents acCreditOld As WFControls.VB.AmountControl
    Friend WithEvents acCreditNew As WFControls.VB.AmountControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents rdbCheque As System.Windows.Forms.RadioButton
End Class
