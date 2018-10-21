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
    public partial class NewsTooltip : UserControl
    {

        #region Path

        private GraphicsPath graphicsPath;

        public NewsTooltip()
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

            webBrowser1.DocumentText = "<html><body style='background-color:#DDE6B7'; dir='rtl' >" + desc + "</body></html>";
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
       

    }
}
