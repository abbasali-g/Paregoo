using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
namespace WFControls.CS.BaseUc
{
    public partial class frmPropertyMsg : Form
    {
        Dictionary<string, string> result;
        public frmPropertyMsg()
        {
            InitializeComponent();
            ////////Region = new Region(graphicsPath = CreateRoundRectangle(Width - 1, Height - 1, 6));

        }
        bool _isCheckedAtLest = false;

        public frmPropertyMsg(ArrayList s , string title , string formName)
        {
            InitializeComponent();
            ////////Region = new Region(graphicsPath = CreateRoundRectangle(Width - 1, Height - 1, 6));
            foreach (string[] value in s)
	        {
	          
                ListViewItem lstItem = new ListViewItem();
                lstItem.Text =value[1];
                lstItem.SubItems.Add(value[0]);
                lstItem.Checked = true;
                lstTargetSource.Items.Add(lstItem);
	        }

            txtTitle.Text = title;

            this.Text = formName;
        }

        public frmPropertyMsg( Dictionary<string, string[]> s, string title, string formName)
        {
            InitializeComponent();
            ////////Region = new Region(graphicsPath = CreateRoundRectangle(Width - 1, Height - 1, 6));
            foreach (string value in s.Keys)
            {
              
                ListViewItem lstItem = new ListViewItem();
                lstItem.Text = s[value][0];
                lstItem.SubItems.Add(value);
                if (s[value][1] == "True" || s[value][1]=="1") lstItem.Checked = true;
                lstTargetSource.Items.Add(lstItem);
            }

            txtTitle.Text = title;

            this.Text = formName;
        }

            #region Path

        //////private GraphicsPath graphicsPath;

        ////////    private static GraphicsPath CreateRoundRectangle(int w, int h, int r)
        ////////{
        ////////    int d = r << 1;
        ////////    GraphicsPath path = new GraphicsPath();
        ////////    path.StartFigure();
        ////////    path.AddArc(new Rectangle(0, 0, d, d), 180, 90);
        ////////    path.AddLine(r, 0, w - r, 0);
        ////////    path.AddArc(new Rectangle(w - d, 0, d, d), 270, 90);
        ////////    path.AddLine(w + 1, r, w + 1, h - r);
        ////////    path.AddArc(new Rectangle(w - d, h - d, d, d), 0, 90);
        ////////    path.AddLine(w - r, h + 1, r, h + 1);
        ////////    path.AddArc(new Rectangle(0, h - d, d, d), 90, 90);
        ////////    path.AddLine(0, h - r, 0, r);
        ////////    path.CloseFigure();
        ////////    return path;
        ////////}

        ////////protected override void OnPaint(PaintEventArgs e)
        ////////{
        ////////    e.Graphics.TranslateTransform(0, 0);
        ////////    using (Pen p = new Pen( System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185))))) , 2))
        ////////    {
        ////////        e.Graphics.DrawPath(p, graphicsPath);
        ////////    }
        ////////    e.Graphics.ResetTransform();


        ////////}
        #endregion

        //private void FillBox()
        //{
        //    //Dim lstItem As New ListViewItem

        //    //   lstItem.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

        //    //   lstItem.Text = Item.custFullName

        //    //   lstItem.SubItems.Add(Item.contactInfoID.ToString())

        //    //   lstItem.SubItems.Add(0) 'قبلا انتخاب شده است

        //    //   lstTargetSource.Items.Add(lstItem.Clone())
        //    ListViewItem lstItem = new ListViewItem();
        //    lstItem.Text = "مشخصات پرونده";
        //    lstTargetSource.Items.Add(lstItem);
        //    ListViewItem lstItem1 = new ListViewItem();
        //    lstItem1.Text = "اوراق";
        //    lstTargetSource.Items.Add(lstItem1);
        //    ListViewItem lstItem2 = new ListViewItem();
        //    lstItem2.Text = "مستندات";
        //    lstTargetSource.Items.Add(lstItem2);


        //}
               
        private void picClose_Click(object sender, EventArgs e)
        {
            result = new Dictionary<string, string>();
            foreach (ListViewItem value in lstTargetSource.Items)
            {
                if (value.Checked) _isCheckedAtLest = true;
                result.Add(value.SubItems[1].Text, value.Checked.ToString());
            }
          
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            result = null;
            this.Close();
        }

        public Dictionary<string,string > GetResult()
        {
            return result;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            result = new Dictionary<string, string>();
             foreach (ListViewItem value in lstTargetSource.Items)
            {
                if (value.Checked) _isCheckedAtLest = true;
                result.Add(value.SubItems[1].Text, value.Checked.ToString());
            }
            this.Close();
        }
        public bool IsCheckedAtLeast()
        {
            return _isCheckedAtLest;
        }


    }
}
