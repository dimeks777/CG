using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7KG
{
    public partial class Form1 : Form
    {
        private int center_x, center_y;
        private bool endReached = false;
        private double x, y, radius = 100;

        Brush aBrush = (Brush)Brushes.Green;
        Graphics gr;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            center_x = 20;
            center_y = 420;
            gr = pictureBox1.CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double newY = 0;
            x = center_x;
            while (!endReached)
            {
                x++;
                y = center_y - 0.2 * x + 45;
                DrawDot(x, y);
                Refresh();
                if (x == pictureBox1.Size.Width - radius)
                {
                    endReached = true;
                    newY = y;
                    break;
                }
            }
            while (endReached)
            {
                x--;
                y = newY + 0.2 * x - 45;
                DrawDot(x, y);
                Refresh();
                if (x == radius)
                {
                    endReached = false;
                    break;
                }
            }

        }

        private void DrawDot(double x, double y)
        {
            gr.FillEllipse(aBrush, Convert.ToSingle(x), Convert.ToSingle(y), (float)radius, (float)radius);
        }
    }
}
