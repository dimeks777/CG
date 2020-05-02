using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapePainter
{
    
    public partial class Form1 : Form
    {
        private readonly PointF[] triangle = { new PointF(287, 72), new PointF(307, 72), new PointF(297, 25), new PointF(287, 72) };

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
                DrawFlag(g);
                DrawDiagonals(g);
                DrawArcs(g);
                DrawCube(g);
        }

        protected void DrawFlag(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color.Blue))
            {
                g.FillEllipse(brush, 475, 100, 250, 250);
            }

            using (Brush brush = new SolidBrush(Color.Gold))
            {
                g.FillPolygon(brush, triangle);
            }
            using Pen selPen = new Pen(Color.Black);
            g.DrawRectangle(selPen, 300, 75, 600, 300);
            DrawTriangle(selPen, g);
            selPen.Color = Color.Brown;
            selPen.Width = 8;
            g.DrawLine(selPen, new Point(297, 75), new Point(297, 700));

        }

        protected void DrawTriangle(Pen pen, Graphics g)
        {
            pen.Color = Color.Gold;
            pen.Width = 5;
            g.DrawPolygon(pen, triangle);
        }

        protected void DrawDiagonals(Graphics g)
        {
            using Pen selPen = new Pen(Color.CadetBlue)
            {
                Width = 3,
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };
            g.DrawLine(selPen, new Point(0, ClientSize.Height), new Point(ClientSize.Width, 0));
            selPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            g.DrawLine(selPen, new Point(0, 0), new Point(ClientSize.Width, ClientSize.Height));
        }

        protected void DrawArcs(Graphics g)
        {
            using Pen selPen = new Pen(Color.DeepSkyBlue)
            {
                Width = 5,
                DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
            };
            g.DrawArc(selPen, 1080, 520, 200, 200, 90, 180);
            g.DrawArc(selPen, 1110, 520, 150, 200, 90, 180);
            g.DrawArc(selPen, 1140, 520, 100, 200, 90, 180);
            g.DrawArc(selPen, 1170, 520, 50, 200, 90, 180);

            g.DrawArc(selPen, 1080, 520, 200, 200, 90, 360);
            g.DrawArc(selPen, 1110, 520, 150, 200, 90, 360);
            g.DrawArc(selPen, 1140, 520, 100, 200, 90, 360);
            g.DrawArc(selPen, 1170, 520, 50, 200, 90, 360);

        }

        protected void DrawCube(Graphics g)
        {
            using Pen pen = new Pen(Color.Fuchsia, 2.5f);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            int w = 200, h = 200;
            Point pt1 = new Point(w / 2, h), pt2 = new Point(pt1.X, h / 2);
            g.DrawLine(pen, pt1, pt2);
            pt2 = new Point(0, 3 * h / 4);
            g.DrawLine(pen, pt1, pt2);
            pt1 = pt2;
            pt2.Offset(0, -h / 2);
            g.DrawLine(pen, pt1, pt2);
            pt1 = new Point(w / 2, h / 2);
            g.DrawLine(pen, pt1, pt2);
            pt2.Offset(w, 0);
            g.DrawLine(pen, pt1, pt2);
            pt1 = pt2;
            pt1.Offset(0, h / 2);
            g.DrawLine(pen, pt1, pt2);
            pt2 = new Point(w / 2, h);
            g.DrawLine(pen, pt1, pt2);
            pt1 = new Point(0, h / 4);
            pt2 = new Point(w / 2, 0);
            g.DrawLine(pen, pt1, pt2);
            pt1.Offset(w, 0);
            g.DrawLine(pen, pt1, pt2);
        }
    }
}
