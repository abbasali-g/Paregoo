using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WFControls.CS.Shaxes
{
    public partial class ucShaxes : UserControl
    {
        public ucShaxes()
        {
            InitializeComponent();
        }

        private void ucShaxes_Load(object sender, EventArgs e)
        {
            //FillComboBoxs();
        }

        private void btnDiehUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDiehValue.Text == string.Empty || txtDiehYear.Text == string.Empty) return;
                bool rz=Lawyer.Common.VB.Shaxes.ShaxesManager.SetDiehOfYear(int.Parse(txtDiehYear.Text), double.Parse(txtDiehValue.Text));
                if(rz==true)
                    MessageBox.Show("بروز رسانی انجام شد");
                else
                    MessageBox.Show("بروز رسانی انجام نشد");
            }
            catch (Exception ex)
            { 
            }

        }

        public void  FillComboBoxs()
        {
            string curYear=Lawyer.Common.VB.Common.DateManager.GetCurrentYear();
            List<string> lstYear=new List<string>();
            lstYear =Lawyer.Common.VB.Credits.CreditManager.GetYears();
            cmbYear.DataSource=lstYear;
            cmbYear.SelectedIndex =cmbYear.Items.Count-1;
            ind = Lawyer.Common.VB.Credits.CreditManager.GetIndices(int.Parse(cmbYear.Text));
        }

        Lawyer.Common.VB.Credits.Index ind = null;
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ind = Lawyer.Common.VB.Credits.CreditManager.GetIndices(int.Parse(cmbYear.Text));
            if (ind == null)
            {
                  txtYearMean.Text = "0";
                  txtMonthValue.Text = "0";
                  return;
            }
            txtYearMean.Text = ind.mean.ToString();
            txtMonthValue.Text = getMonthShaxes(cmbMonth.SelectedIndex);

        }
      
      

        private string getMonthShaxes(int index)
        {
            string value = "0";
            switch (index)
            {
                case 1:
                    value = ind.m1.ToString();
                    break;
                case 2:
                    value = ind.m2.ToString();
                    break;
                case 3:
                    value = ind.m3.ToString();
                    break;
                case 4:
                    value = ind.m4.ToString();
                    break;
                case 5:
                    value = ind.m5.ToString();
                    break;
                case 6:
                    value = ind.m6.ToString();
                    break;
                case 7:
                    value = ind.m7.ToString();
                    break;
                case 8:
                    value = ind.m8.ToString();
                    break;
                case 9:
                    value = ind.m9.ToString();
                    break;
                case 10:
                    value = ind.m10.ToString();
                    break;
                case 11:
                    value = ind.m11.ToString();
                    break;
                case 12:
                    value = ind.m12.ToString();
                    break;

                
                default:
                    value ="0";
                    break;

                 
            }
            return value;
        }

        private void btnShaxesUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMonthValue.Text == string.Empty || txtMonthValue.Text == "0") return;
                bool rz = Lawyer.Common.VB.Shaxes.ShaxesManager.SetMonthShaxes(int.Parse(cmbYear.Text),cmbMonth.SelectedIndex, double.Parse(txtMonthValue.Text),double.Parse(txtYearMean.Text));
                if (rz == true)
                    MessageBox.Show("بروز رسانی انجام شد");
                else
                    MessageBox.Show("بروز رسانی انجام نشد");
            }
            catch (Exception ex)
            {
            }
        }
       


    }
}
