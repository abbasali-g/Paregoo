namespace WFControls.CS.Sms
{
    partial class ucSms
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSetting = new System.Windows.Forms.Label();
            this.cmbSmsTemplate = new System.Windows.Forms.ComboBox();
            this.ctxDelTempSms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMenuDelSmsTempText = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectTempSms = new System.Windows.Forms.Button();
            this.btnAddToSmsTemp = new System.Windows.Forms.Button();
            this.lblSmsTextCount = new System.Windows.Forms.Label();
            this.txtSmsText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSendSms = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.btnSaveOrgName = new System.Windows.Forms.Button();
            this.txtOrgName = new System.Windows.Forms.TextBox();
            this.cmbReceiver = new System.Windows.Forms.ComboBox();
            this.ctxListToSend = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMenuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.btnShowOrgName = new System.Windows.Forms.Button();
            this.ctxDelTempSms.SuspendLayout();
            this.pnlSetting.SuspendLayout();
            this.ctxListToSend.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSetting
            // 
            this.lblSetting.AutoSize = true;
            this.lblSetting.Location = new System.Drawing.Point(238, 9);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(143, 13);
            this.lblSetting.TabIndex = 0;
            this.lblSetting.Text = "ثبت نام دفتر حقوقی/موسسه";
            this.lblSetting.Click += new System.EventHandler(this.lblSetting_Click);
            // 
            // cmbSmsTemplate
            // 
            this.cmbSmsTemplate.ContextMenuStrip = this.ctxDelTempSms;
            this.cmbSmsTemplate.FormattingEnabled = true;
            this.cmbSmsTemplate.Location = new System.Drawing.Point(63, 69);
            this.cmbSmsTemplate.Name = "cmbSmsTemplate";
            this.cmbSmsTemplate.Size = new System.Drawing.Size(317, 21);
            this.cmbSmsTemplate.TabIndex = 3;
            // 
            // ctxDelTempSms
            // 
            this.ctxDelTempSms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuDelSmsTempText});
            this.ctxDelTempSms.Name = "ctxDelTempSms";
            this.ctxDelTempSms.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctxDelTempSms.Size = new System.Drawing.Size(100, 26);
            // 
            // ctxMenuDelSmsTempText
            // 
            this.ctxMenuDelSmsTempText.Image = global::WFControls.CS.Properties.Resources.ok16_2;
            this.ctxMenuDelSmsTempText.Name = "ctxMenuDelSmsTempText";
            this.ctxMenuDelSmsTempText.Size = new System.Drawing.Size(99, 22);
            this.ctxMenuDelSmsTempText.Text = "حذف";
            this.ctxMenuDelSmsTempText.Click += new System.EventHandler(this.ctxMenuDelSmsTempText_Click);
            // 
            // btnSelectTempSms
            // 
            this.btnSelectTempSms.Location = new System.Drawing.Point(9, 67);
            this.btnSelectTempSms.Name = "btnSelectTempSms";
            this.btnSelectTempSms.Size = new System.Drawing.Size(50, 23);
            this.btnSelectTempSms.TabIndex = 2;
            this.btnSelectTempSms.Text = "انتخاب";
            this.btnSelectTempSms.UseVisualStyleBackColor = true;
            this.btnSelectTempSms.Click += new System.EventHandler(this.btnSelectTempSms_Click);
            // 
            // btnAddToSmsTemp
            // 
            this.btnAddToSmsTemp.Location = new System.Drawing.Point(9, 94);
            this.btnAddToSmsTemp.Name = "btnAddToSmsTemp";
            this.btnAddToSmsTemp.Size = new System.Drawing.Size(49, 23);
            this.btnAddToSmsTemp.TabIndex = 2;
            this.btnAddToSmsTemp.Text = "اضافه";
            this.btnAddToSmsTemp.UseVisualStyleBackColor = true;
            this.btnAddToSmsTemp.Click += new System.EventHandler(this.btnAddToSmsTemp_Click);
            // 
            // lblSmsTextCount
            // 
            this.lblSmsTextCount.AutoSize = true;
            this.lblSmsTextCount.Location = new System.Drawing.Point(63, 148);
            this.lblSmsTextCount.Name = "lblSmsTextCount";
            this.lblSmsTextCount.Size = new System.Drawing.Size(13, 13);
            this.lblSmsTextCount.TabIndex = 0;
            this.lblSmsTextCount.Text = "0";
            // 
            // txtSmsText
            // 
            this.txtSmsText.Location = new System.Drawing.Point(63, 164);
            this.txtSmsText.Multiline = true;
            this.txtSmsText.Name = "txtSmsText";
            this.txtSmsText.Size = new System.Drawing.Size(320, 63);
            this.txtSmsText.TabIndex = 1;
            this.txtSmsText.TextChanged += new System.EventHandler(this.txtSmsText_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "متن پیامک";
            // 
            // btnSendSms
            // 
            this.btnSendSms.Location = new System.Drawing.Point(3, 188);
            this.btnSendSms.Name = "btnSendSms";
            this.btnSendSms.Size = new System.Drawing.Size(53, 23);
            this.btnSendSms.TabIndex = 2;
            this.btnSendSms.Text = "ارسال";
            this.btnSendSms.UseVisualStyleBackColor = true;
            this.btnSendSms.Click += new System.EventHandler(this.btnSendSms_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "متون نمونه";
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.btnSaveOrgName);
            this.pnlSetting.Controls.Add(this.txtOrgName);
            this.pnlSetting.Location = new System.Drawing.Point(13, 25);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(328, 29);
            this.pnlSetting.TabIndex = 5;
            this.pnlSetting.Visible = false;
            // 
            // btnSaveOrgName
            // 
            this.btnSaveOrgName.Location = new System.Drawing.Point(9, 2);
            this.btnSaveOrgName.Name = "btnSaveOrgName";
            this.btnSaveOrgName.Size = new System.Drawing.Size(48, 23);
            this.btnSaveOrgName.TabIndex = 3;
            this.btnSaveOrgName.Text = "ثبت";
            this.btnSaveOrgName.UseVisualStyleBackColor = true;
            this.btnSaveOrgName.Click += new System.EventHandler(this.btnSaveOrgName_Click);
            // 
            // txtOrgName
            // 
            this.txtOrgName.Location = new System.Drawing.Point(61, 4);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Size = new System.Drawing.Size(267, 21);
            this.txtOrgName.TabIndex = 2;
            // 
            // cmbReceiver
            // 
            this.cmbReceiver.ContextMenuStrip = this.ctxListToSend;
            this.cmbReceiver.FormattingEnabled = true;
            this.cmbReceiver.Location = new System.Drawing.Point(64, 115);
            this.cmbReceiver.Name = "cmbReceiver";
            this.cmbReceiver.Size = new System.Drawing.Size(314, 21);
            this.cmbReceiver.TabIndex = 6;
            // 
            // ctxListToSend
            // 
            this.ctxListToSend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuDel});
            this.ctxListToSend.Name = "ctxListToSend";
            this.ctxListToSend.Size = new System.Drawing.Size(100, 26);
            // 
            // ctxMenuDel
            // 
            this.ctxMenuDel.Image = global::WFControls.CS.Properties.Resources.ok16_2;
            this.ctxMenuDel.Name = "ctxMenuDel";
            this.ctxMenuDel.Size = new System.Drawing.Size(99, 22);
            this.ctxMenuDel.Text = "حذف";
            this.ctxMenuDel.Click += new System.EventHandler(this.ctxMenuDel_Click);
            // 
            // lblReceiver
            // 
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Location = new System.Drawing.Point(329, 99);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(45, 13);
            this.lblReceiver.TabIndex = 7;
            this.lblReceiver.Text = "گیرندگان";
            // 
            // btnShowOrgName
            // 
            this.btnShowOrgName.Location = new System.Drawing.Point(347, 26);
            this.btnShowOrgName.Name = "btnShowOrgName";
            this.btnShowOrgName.Size = new System.Drawing.Size(40, 23);
            this.btnShowOrgName.TabIndex = 9;
            this.btnShowOrgName.Text = ">>";
            this.btnShowOrgName.UseVisualStyleBackColor = true;
            this.btnShowOrgName.Click += new System.EventHandler(this.btnShowOrgName_Click);
            // 
            // ucSms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(222)))));
            this.Controls.Add(this.btnShowOrgName);
            this.Controls.Add(this.lblReceiver);
            this.Controls.Add(this.cmbReceiver);
            this.Controls.Add(this.pnlSetting);
            this.Controls.Add(this.cmbSmsTemplate);
            this.Controls.Add(this.btnSendSms);
            this.Controls.Add(this.btnAddToSmsTemp);
            this.Controls.Add(this.btnSelectTempSms);
            this.Controls.Add(this.txtSmsText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSmsTextCount);
            this.Controls.Add(this.lblSetting);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Name = "ucSms";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(390, 240);
            this.ctxDelTempSms.ResumeLayout(false);
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.ctxListToSend.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSetting;
        private System.Windows.Forms.ComboBox cmbSmsTemplate;
        private System.Windows.Forms.Button btnSelectTempSms;
        private System.Windows.Forms.Button btnAddToSmsTemp;
        private System.Windows.Forms.Label lblSmsTextCount;
        private System.Windows.Forms.TextBox txtSmsText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSendSms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.Button btnSaveOrgName;
        private System.Windows.Forms.TextBox txtOrgName;
        private System.Windows.Forms.ComboBox cmbReceiver;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.ContextMenuStrip ctxListToSend;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuDel;
        private System.Windows.Forms.ContextMenuStrip ctxDelTempSms;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuDelSmsTempText;
        private System.Windows.Forms.Button btnShowOrgName;
    }
}
