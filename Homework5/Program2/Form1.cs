using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.CreateGraphics();
            else
            {
                graphics.Clear(Color.White);
                graphics = this.CreateGraphics();
            }
            string s = textBox3.Text;
            int len = int.Parse(s);
            s = textBox4.Text;
            double angle = int.Parse(s) * Math.PI / 180;
            s = textBox8.Text;
            n = int.Parse(s);
            drawCayleyTree(n, 250, 400, len, -angle);
        }
        private Graphics graphics;
        int n = 10;
        double k = 1;
        double per1 = 0.6;
        double per2 = 0.7;
        float width = 1;
        int r = 0;
        int g = 0;
        int b = 0;
        
        void drawCayleyTree(int n,
            double x0,double y0,double len,double th)
        {
            string s = textBox1.Text;
            double th1 = double.Parse(s) * Math.PI / 180;
            s = textBox2.Text;
            double th2 = double.Parse(s) * Math.PI / 180;
            if (n == 0) return;
            s = textBox5.Text;
            r = int.Parse(s);
            s = textBox6.Text;
            g = int.Parse(s);
            s = textBox7.Text;
            b = int.Parse(s);

            double x1 = x0 + len * Math.Cos(th) + (len / 20.0) * Math.Cos(th + th1);
            double y1 = y0 + len * Math.Sin(th) + (len / 20.0) * Math.Sin(th + th1);
            double x2 = x0 + len * Math.Cos(th) * k;
            double y2 = y0 + len * Math.Sin(th) * k;

            double x3 = x0 + len * Math.Cos(th);
            double y3 = y0 + len * Math.Sin(th);
            drawLine(x0, y0, x3, y3);
            drawCayleyTree(n - 1, x1, y1, per1 * len, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * len, th - th2);
        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            Pen p = new Pen(Color.FromArgb(r,g,b), width);
            graphics.DrawLine(p,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = (trackBar1.Value / (10.0)).ToString();
            k = trackBar1.Value / (10.0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label8.Text = (trackBar2.Value / (10.0)).ToString();
            per1 = trackBar2.Value / (10.0);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label9.Text = (trackBar3.Value / (10.0)).ToString();
            per2 = trackBar3.Value / (10.0);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label11.Text = (trackBar4.Value / (10.0)).ToString();
            width = (float)(trackBar4.Value / (10.0));
        }
    }
}
