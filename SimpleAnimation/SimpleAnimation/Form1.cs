using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleAnimation
{
    public partial class Form1 : Form
    {
        Timer timer;
        Graphics graphics;
        const int iNumRevs = 4;
        float fAngle, fScale;
        int iNumPoints;
        PointF[] aptf;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 500;
            iNumPoints = iNumRevs * 2 * (panel1.Width + panel1.Height);
            aptf = new PointF[iNumPoints];
        }

        void timer_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < iNumPoints; i++)
            {
                fAngle = (float)(i * 2 * Math.PI / (iNumPoints / iNumRevs));
                fScale = 1 - (float)i / iNumPoints;

                aptf[i].X = (float)(panel1.Width / 2 * (1 + fScale * Math.Cos(fAngle)));
                aptf[i].Y = (float)(panel1.Height / 2 * (1 + fScale * Math.Sin(fAngle)));
            }


            //for (int i = 0; i < iNumPoints; i++)
            //{
            //    fAngle = (float)(i * 2 * Math.PI / (iNumPoints / iNumRevs));
            //    fScale = 1 - (float)i / iNumPoints;

            //    aptf[i].X = (float)(panel1.Width / 2 * (1 + fScale * Math.Cos(fAngle)/fAngle));
            //    aptf[i].Y = (float)(panel1.Height / 2 * (1 + fScale * Math.Sin(fAngle)/fAngle));
            //}

            //float a = 0.05F, b = 0.1F;
            //for (int i = 0; i < iNumPoints; i++)
            //{
            //    fAngle = (float)(i * 2 * Math.PI / (iNumPoints / iNumRevs));
            //    fScale = 1 - (float)i / iNumPoints;

            //    aptf[i].X = (float)(panel1.Width / 2 * (1 + a * Math.Pow(Math.E, b * fAngle) * Math.Cos(fAngle)));
            //    aptf[i].Y = (float)(panel1.Height / 2 * (1 + a * Math.Pow(Math.E, b * fAngle) * Math.Sin(fAngle)));

            //}


            panel1.Invalidate();
        }

        private void PolarToCartesian(float r, float theta,out float x, out float y)
        {
            x = (float)(r * Math.Cos(theta));
            y = (float)(r * Math.Sin(theta));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = Graphics.FromHwnd(panel1.Handle);


            for (int i = 0; i < iNumPoints; i++)
            {
                fAngle = (float)(i * 2 * Math.PI / (iNumPoints / iNumRevs));
                fScale = 1 - (float)i / iNumPoints;

                aptf[i].X = (panel1.Width / 2);
                aptf[i].Y = (panel1.Height / 2);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            checked
            {
                for (int i = iNumPoints - 1; i > 0; i--)
                {
                    try
                    {
                       graphics.DrawLine(Pens.Green, aptf[i], aptf[i - 1]);                 
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Exception: {0} > {1}.", aptf[i], float.MaxValue);
                    }
                }
            }

        }
    }
} 

            

