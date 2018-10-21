using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFControls.CS.Sms
{
    public partial class ucSms : UserControl
    {

        string fileCaseID = null;
        string timeID = null;
        DataTable contactDT = null;
        DataTable dtToSend = null;

        public ucSms()
        {
            InitializeComponent();           
        }

        //public ucSms(string fileCaseID, string timeID, DataTable dt, string smsText)
        //{
        //    InitializeComponent();
        //    this.fileCaseID = fileCaseID;
        //    this.timeID = timeID;
        //    this.contactDT = dt;
        //}


        public void ucSmsInit(string fileCaseID, string timeID, DataTable dt, string smsText)
        {
            this.fileCaseID = fileCaseID;
            this.timeID = timeID;
            this.contactDT = dt;
            fillTemplateList();
            getListOfReceivers();
            txtSmsText.Text = smsText;
        }
        
        private void getListOfReceivers()
        {
            if (fileCaseID != null)
            {
                dtToSend = Lawyer.Common.VB.SmsManager.getReceiverListOfParvade(fileCaseID);
                if(dtToSend!=null && dtToSend.Rows.Count>0)
                   fillReceiverList(); 
            }

            if (timeID != null)
            {
                dtToSend = Lawyer.Common.VB.SmsManager.getReceiverListOfTiming(timeID);
                if(dtToSend!=null && dtToSend.Rows.Count>0)
                   fillReceiverList(); 
            }

            if (contactDT != null && contactDT.Rows.Count > 0)
            {
                dtToSend=contactDT;
                fillReceiverList();
            }
        }

        private void fillReceiverList()
        {
            for (int i = 0; i < dtToSend.Rows.Count; i++)
            {
                cmbReceiver.DisplayMember = "receiverName";
                cmbReceiver.ValueMember = "receiverNumber";
                cmbReceiver.DataSource = dtToSend;

            }
        }

      

        private void fillTemplateList()
        {
            DataTable dt = Lawyer.Common.VB.SmsManager.getSmsTemplateText();
            if (dt != null || dt.Rows.Count > 0)
            {
                cmbSmsTemplate.DisplayMember = "smsText";
                cmbSmsTemplate.ValueMember = "smsTempID";
                cmbSmsTemplate.DataSource = dt;
            }
        }
        
        private void lblSetting_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSaveOrgName_Click(object sender, EventArgs e)
        {
            try
            {
                //d1e165f8-d437-11e3-8f61-b56f0be9717a
                Lawyer.Common.VB.Setting.SettingComplete sc = new Lawyer.Common.VB.Setting.SettingComplete();
                sc.settingGroupID = "d1e165f8-d437-11e3-8f61-b56f0be9717a";
                sc.settingID = "d1r165f8-d437-11e3-8f61-b56f0be9717a";
                sc.settingName = "smsorgname";
                sc.settingValue = txtOrgName.Text.Trim();
                try
                {
                    Lawyer.Common.VB.Setting.SettingManager.DelSettingByID("d1r165f8-d437-11e3-8f61-b56f0be9717a");
                }
                catch (Exception ex) { }

                bool rz=Lawyer.Common.VB.Setting.SettingManager.AddSetting(sc);
                if (rz == true)
                    MessageBox.Show("ثبت انجام شد");
                else
                    MessageBox.Show("خطا در ثبت");

            }
            catch (Exception ex)
            { MessageBox.Show("خطا در ثبت:" + ex.Message); }

        }

        private void btnSelectTempSms_Click(object sender, EventArgs e)
        {
            txtSmsText.Text = cmbSmsTemplate.Text;
        }

        private void btnAddToSmsTemp_Click(object sender, EventArgs e)
        {
            int rz = Lawyer.Common.VB.SmsManager.addSmsTemplate(cmbSmsTemplate.Text);
            if (rz == 1)
            {
                MessageBox.Show("ثبت انجام شد");
                fillTemplateList();
            }
            else
                MessageBox.Show("خطا در ثبت");
        }

        private void ctxMenuDelSmsTempText_Click(object sender, EventArgs e)
        {
            int rz = Lawyer.Common.VB.SmsManager.deleteSmsTemplate(int.Parse(cmbSmsTemplate.SelectedValue.ToString()));
            if (rz == 1)
            {
                MessageBox.Show("حذف انجام شد");
                fillTemplateList();
            }
            else
                MessageBox.Show("خطا در حذف");
        }

        private void btnSendSms_Click(object sender, EventArgs e)
        {
      
            try
            {
                for (int i = 0; i < dtToSend.Rows.Count; i++)
                   // if (!checkContactExistingInList(dtToSend.Rows[i]["receiverNumber"].ToString()))
                     Lawyer.Common.VB.SmsManager.sendSms(dtToSend.Rows[i]["receiverID"].ToString(), dtToSend.Rows[i]["receiverName"].ToString(), dtToSend.Rows[i]["receiverNumber"].ToString(), dtToSend.Rows[i]["fileCaseID"].ToString(), dtToSend.Rows[i]["timeID"].ToString(), dtToSend.Rows[i]["smsSubject"].ToString(), txtSmsText.Text.Replace("'", ""));

                MessageBox.Show("پیام در بانک اطلاعاتی ذخیره شد");
            }
            catch (Exception ex)
            { MessageBox.Show("خطا در ارسال"); }
            

        }


        private bool checkContactExistingInList(string receiverNumber)
        {
            for(int i=0;i<cmbReceiver.Items.Count;i++)
            {
                DataRow cmbValue = ((DataRowView)cmbReceiver.Items[i]).Row;
                if (receiverNumber == cmbValue["receiverNumber"])
                    return true;
            }
            return false;
                
        }
    
        private void txtSmsText_TextChanged(object sender, EventArgs e)
        {
            lblSmsTextCount.Text = "تعداد:" + txtSmsText.Text.Length;
        }

        private void ctxMenuDel_Click(object sender, EventArgs e)
        {
            //cmbReceiver.Items.RemoveAt(cmbReceiver.SelectedIndex);
           
                int index = cmbReceiver.SelectedIndex;
                cmbReceiver.DataSource = null;

                dtToSend.Rows.RemoveAt(index);

                fillReceiverList();
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnShowOrgName_Click(object sender, EventArgs e)
        {
            if (pnlSetting.Visible)
                pnlSetting.Visible = false;
            else
            {
                pnlSetting.Visible = true;
                if (Lawyer.Common.VB.Setting.SettingManager.GetSettingsByName("smsorgname").Count > 0)
                    txtOrgName.Text = Lawyer.Common.VB.Setting.SettingManager.GetSettingsByName("smsorgname")[0].settingValue;
                else
                    txtOrgName.Text = "";
            }
        }

       


     
    }
}
