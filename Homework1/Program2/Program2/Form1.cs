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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1 != null&&textBox2 != null)
            {
                string s1 = textBox1.Text;
                int a = int.Parse(s1);
                string s2 = textBox2.Text;
                int b = int.Parse(s2);
                label3.Text = "相乘后的结果为" + a * b;
            }
        }
    }
}
