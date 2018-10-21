using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
// 
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace WFControls.CS
{
    public partial class PropertyMsg : UserControl
    {


        #region Path

        private GraphicsPath graphicsPath;

        public PropertyMsg()
        {
            InitializeComponent();
            Region = new Region(graphicsPath = CreateRoundRectangle(Width - 1, Height - 1, 6));
        }

        private static GraphicsPath CreateRoundRectangle(int w, int h, int r)
        {
            int d = r << 1;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, d, d), 180, 90);
            path.AddLine(r, 0, w - r, 0);
            path.AddArc(new Rectangle(w - d, 0, d, d), 270, 90);
            path.AddLine(w + 1, r, w + 1, h - r);
            path.AddArc(new Rectangle(w - d, h - d, d, d), 0, 90);
            path.AddLine(w - r, h + 1, r, h + 1);
            path.AddArc(new Rectangle(0, h - d, d, d), 90, 90);
            path.AddLine(0, h - r, 0, r);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, 0);
            using (Pen p = new Pen( System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185))))) , 2))
            {
                e.Graphics.DrawPath(p, graphicsPath);
            }
            e.Graphics.ResetTransform();


        }


        #endregion

        public void SetText(string title,string desc)
        {
            textBox1.Text = title;

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FillBox()
        {
             //Dim lstItem As New ListViewItem

             //   lstItem.Font = New System.Drawing.Font("tahoma", 8.25, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)

             //   lstItem.Text = Item.custFullName

             //   lstItem.SubItems.Add(Item.contactInfoID.ToString())

             //   lstItem.SubItems.Add(0) 'قبلا انتخاب شده است

             //   lstTargetSource.Items.Add(lstItem.Clone())
            ListViewItem lstItem=new ListViewItem ();
            lstItem.Text="مشخصات پرونده";
            lstTargetSource.Items.Add(lstItem);
            ListViewItem lstItem1 = new ListViewItem();
            lstItem1.Text = "اوراق";
            lstTargetSource.Items.Add(lstItem1);
            ListViewItem lstItem2 = new ListViewItem();
            lstItem2.Text = "مستندات";
            lstTargetSource.Items.Add(lstItem2);


        }

        private void PropertyMsg_Load(object sender, EventArgs e)
        {
            FillBox();
        }
       

    }
}
