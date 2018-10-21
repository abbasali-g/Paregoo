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
    public partial class ucSmsConfig : UserControl
    {
        public ucSmsConfig()
        {
            InitializeComponent();
        }

        private void chkSmsConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (Lawyer.Common.VB.Login.CurrentLogin.CurrentUser.IsAdmin)
                chkSmsConfig.Enabled = true;
            else
            {
                chkSmsConfig.Enabled = false;
                MessageBox.Show("عدم دسترسی برای کاربران غیر مدیر");
                return;
            }


            if (chkSmsConfig.Checked)
                Lawyer.Common.VB.SmsManager.setSmsConfig("0");
            if (!chkSmsConfig.Checked)
                Lawyer.Common.VB.SmsManager.setSmsConfig("1");

        }

        private void ucSmsConfig_Load(object sender, EventArgs e)
        {
            
            if (Lawyer.Common.VB.SmsManager.getSmsConfig() == true)
                chkSmsConfig.Checked = true;

            if (Lawyer.Common.VB.SmsManager.getSmsConfig() == true)
                chkSmsConfig.Checked = false;
        }
    }
}
