using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
//using System.Linq;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace WFControls.CS
{
    public partial class TooltipGridC : UserControl
    {
        public TooltipGridC()
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

        private GraphicsPath graphicsPath;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(-1, -1);
            using (Pen p = new Pen(SystemColors.WindowFrame, 2))
            {
                e.Graphics.DrawPath(p, graphicsPath);
            }
            e.Graphics.ResetTransform();

           
        }

//-----------------------------------------------------------
        //protected override CreateParams CreateParams
        //{

        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x00000020;//WS_EX_TRANSPARENT 
        //        return cp;
        //    }

        //}



        //private int opacity;
        //public int Opacity
        //{
        //    get { return opacity; }

        //    set
        //    {
        //        opacity = value;
        //        //this.InvalidateEx();
        //    }
        //}


        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    Color bk = Color.FromArgb(Opacity, this.BackColor);
        //    e.Graphics.FillRectangle(new SolidBrush(bk), e.ClipRectangle);
        //}


        //protected void InvalidateEx()
        //{
        //    //if (Parent == null)
        //    //    return;
        //    //Rectangle rc = new Rectangle(this.Location, this.Size);
        //    //Parent.Invalidate(rc, true);
        //}




    //---------------------------------------
    }
}
