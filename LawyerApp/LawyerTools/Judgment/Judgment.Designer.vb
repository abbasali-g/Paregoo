<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Judgment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Judgment))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdbFixValue = New System.Windows.Forms.RadioButton()
        Me.rdbCalcValue = New System.Windows.Forms.RadioButton()
        Me.ckbCalendar = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbJudgmentLevel = New System.Windows.Forms.ComboBox()
        Me.txtTdoText = New System.Windows.Forms.TextBox()
        Me.pbColor = New System.Windows.Forms.PictureBox()
        Me.pbGray = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblWanted = New System.Windows.Forms.Label()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.acAmount = New WFControls.VB.AmountControl()
        Me.acWanted = New WFControls.VB.AmountControl()
        Me.pnlMsg = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pbColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbGray, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitle.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.PapayaWhip
        Me.Panel2.Controls.Add(Me.rdbFixValue)
        Me.Panel2.Controls.Add(Me.rdbCalcValue)
        Me.Panel2.Controls.Add(Me.ckbCalendar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(312, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(63, 138)
        Me.Panel2.TabIndex = 19
        '
        'rdbFixValue
        '
        Me.rdbFixValue.Image = Global.LawyerApp.My.Resources.Resources.Money
        Me.rdbFixValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbFixValue.Location = New System.Drawing.Point(5, 81)
        Me.rdbFixValue.Name = "rdbFixValue"
        Me.rdbFixValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbFixValue.Size = New System.Drawing.Size(55, 35)
        Me.rdbFixValue.TabIndex = 15
        Me.rdbFixValue.UseVisualStyleBackColor = True
        Me.rdbFixValue.Visible = False
        '
        'rdbCalcValue
        '
        Me.rdbCalcValue.Checked = True
        Me.rdbCalcValue.Image = Global.LawyerApp.My.Resources.Resources.Money_Calc
        Me.rdbCalcValue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbCalcValue.Location = New System.Drawing.Point(6, 40)
        Me.rdbCalcValue.Name = "rdbCalcValue"
        Me.rdbCalcValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rdbCalcValue.Size = New System.Drawing.Size(55, 35)
        Me.rdbCalcValue.TabIndex = 17
        Me.rdbCalcValue.TabStop = True
        Me.rdbCalcValue.UseVisualStyleBackColor = True
        '
        'ckbCalendar
        '
        Me.ckbCalendar.Image = Global.LawyerApp.My.Resources.Resources.No_calendar
        Me.ckbCalendar.Location = New System.Drawing.Point(7, 43)
        Me.ckbCalendar.Name = "ckbCalendar"
        Me.ckbCalendar.Size = New System.Drawing.Size(55, 33)
        Me.ckbCalendar.TabIndex = 18
        Me.ckbCalendar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.cbbJudgmentLevel)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(311, 32)
        Me.Panel3.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "مرحله دادرسی :"
        '
        'cbbJudgmentLevel
        '
        Me.cbbJudgmentLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbJudgmentLevel.FormattingEnabled = True
        Me.cbbJudgmentLevel.Location = New System.Drawing.Point(6, 7)
        Me.cbbJudgmentLevel.Name = "cbbJudgmentLevel"
        Me.cbbJudgmentLevel.Size = New System.Drawing.Size(208, 21)
        Me.cbbJudgmentLevel.TabIndex = 9
        '
        'txtTdoText
        '
        Me.txtTdoText.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.txtTdoText.Location = New System.Drawing.Point(-1, 32)
        Me.txtTdoText.Multiline = True
        Me.txtTdoText.Name = "txtTdoText"
        Me.txtTdoText.ReadOnly = True
        Me.txtTdoText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTdoText.Size = New System.Drawing.Size(373, 124)
        Me.txtTdoText.TabIndex = 154
        Me.txtTdoText.Visible = False
        Me.txtTdoText.WordWrap = False
        '
        'pbColor
        '
        Me.pbColor.Image = Global.LawyerApp.My.Resources.Resources.money_Ok
        Me.pbColor.Location = New System.Drawing.Point(10, 93)
        Me.pbColor.Name = "pbColor"
        Me.pbColor.Size = New System.Drawing.Size(48, 48)
        Me.pbColor.TabIndex = 26
        Me.pbColor.TabStop = False
        '
        'pbGray
        '
        Me.pbGray.Image = Global.LawyerApp.My.Resources.Resources.Money_Black
        Me.pbGray.Location = New System.Drawing.Point(10, 39)
        Me.pbGray.Name = "pbGray"
        Me.pbGray.Size = New System.Drawing.Size(48, 48)
        Me.pbGray.TabIndex = 18
        Me.pbGray.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(146, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "مبلغ قابل پرداخت"
        '
        'lblWanted
        '
        Me.lblWanted.AutoSize = True
        Me.lblWanted.Location = New System.Drawing.Point(166, 54)
        Me.lblWanted.Name = "lblWanted"
        Me.lblWanted.Size = New System.Drawing.Size(85, 13)
        Me.lblWanted.TabIndex = 29
        Me.lblWanted.Text = "میزان محکوم به :"
        '
        'pnlTitle
        '
        Me.pnlTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlTitle.Controls.Add(Me.Label3)
        Me.pnlTitle.Location = New System.Drawing.Point(10, 2)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(375, 23)
        Me.pnlTitle.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(179, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "هزینه های دادرسی در دعاوی مالی"
        '
        'pnlContent
        '
        Me.pnlContent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.acAmount)
        Me.pnlContent.Controls.Add(Me.acWanted)
        Me.pnlContent.Controls.Add(Me.Panel3)
        Me.pnlContent.Controls.Add(Me.pbGray)
        Me.pnlContent.Controls.Add(Me.Panel2)
        Me.pnlContent.Controls.Add(Me.pbColor)
        Me.pnlContent.Controls.Add(Me.lblWanted)
        Me.pnlContent.Controls.Add(Me.txtTdoText)
        Me.pnlContent.Location = New System.Drawing.Point(10, 25)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(375, 138)
        Me.pnlContent.TabIndex = 33
        '
        'acAmount
        '
        Me.acAmount.Amount = 0.0R
        Me.acAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.acAmount.Location = New System.Drawing.Point(60, 106)
        Me.acAmount.Name = "acAmount"
        Me.acAmount.Size = New System.Drawing.Size(100, 21)
        Me.acAmount.TabIndex = 156
        '
        'acWanted
        '
        Me.acWanted.Amount = 0.0R
        Me.acWanted.Location = New System.Drawing.Point(60, 52)
        Me.acWanted.Name = "acWanted"
        Me.acWanted.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.acWanted.Size = New System.Drawing.Size(100, 21)
        Me.acWanted.TabIndex = 155
        '
        'pnlMsg
        '
        Me.pnlMsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.pnlMsg.Controls.Add(Me.lblMessage)
        Me.pnlMsg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.pnlMsg.Location = New System.Drawing.Point(10, 187)
        Me.pnlMsg.Name = "pnlMsg"
        Me.pnlMsg.Size = New System.Drawing.Size(375, 26)
        Me.pnlMsg.TabIndex = 75
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.ReadOnly = True
        Me.lblMessage.Size = New System.Drawing.Size(375, 13)
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
        'Judgment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MintCream
        Me.ClientSize = New System.Drawing.Size(396, 216)
        Me.Controls.Add(Me.pnlMsg)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.pnlContent)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Judgment"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pbColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbGray, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.pnlMsg.ResumeLayout(False)
        Me.pnlMsg.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdbCalcValue As System.Windows.Forms.RadioButton
    Friend WithEvents pbGray As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdbFixValue As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cbbJudgmentLevel As System.Windows.Forms.ComboBox
    Friend WithEvents pbColor As System.Windows.Forms.PictureBox
    Friend WithEvents ckbCalendar As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblWanted As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTdoText As System.Windows.Forms.TextBox
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlMsg As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Friend WithEvents acWanted As WFControls.VB.AmountControl
    Friend WithEvents acAmount As WFControls.VB.AmountControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
