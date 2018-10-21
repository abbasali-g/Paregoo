using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;

namespace ServerLawApp.UC
{
    public partial class MsgBox : UserControl
    {

        private buttonClick status;
        public enum buttonClick
        {
            تایید , انصراف
        }
        public MsgBox()
        {
            InitializeComponent();
        }
        public buttonClick Show()
        {
            return buttonClick.انصراف;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            status = buttonClick.تایید;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            status = buttonClick.انصراف ;
        }
        
    }
}
