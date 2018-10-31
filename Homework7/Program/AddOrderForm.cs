using System;
using System.Windows.Forms;

namespace Program
{
    public delegate void TransfDelegate(Order.Order value);
    public partial class AddOrderForm : Form
    {
        public bool isPressed = false;

        public AddOrderForm()
        {
            InitializeComponent();
        }

        public event TransfDelegate TransfEvent;
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckNullAllTextBox() == true)
            {
                CheckNum(textBox1);
                CheckNum(textBox3);
                Order.Order order = new Order.Order(textBox1.Text, textBox2.Text, uint.Parse(textBox3.Text));
                uint t = uint.Parse(textBox3.Text);
                for (int i = 0; i < t; i++)
                {
                    if (i == 0)
                    {
                        CheckNum(textBox5);
                        CheckNum(textBox10);
                        Order.OrderDetails od = new Order.OrderDetails(textBox4.Text, int.Parse(textBox5.Text), int.Parse(textBox10.Text));
                        order.AddOrderDetails(od);
                        order.TotalPrice += int.Parse(textBox5.Text) * int.Parse(textBox10.Text);
                    }
                    else if (i == 1)
                    {
                        CheckNum(textBox6);
                        CheckNum(textBox11);
                        Order.OrderDetails od = new Order.OrderDetails(textBox7.Text, int.Parse(textBox6.Text), int.Parse(textBox11.Text));
                        order.AddOrderDetails(od);
                        order.TotalPrice += int.Parse(textBox6.Text) * int.Parse(textBox11.Text);
                    }
                    else
                    {
                        CheckNum(textBox8);
                        CheckNum(textBox12);
                        Order.OrderDetails od = new Order.OrderDetails(textBox9.Text, int.Parse(textBox8.Text), int.Parse(textBox12.Text));
                        order.AddOrderDetails(od);
                        order.TotalPrice += int.Parse(textBox8.Text) * int.Parse(textBox12.Text);
                    }
                }
                TransfEvent(order);
                this.Close();
            }
            else
            {
                MessageBox.Show("您所输入的值有空项，请检查后再提交。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckNum(TextBox textBox)
        {
            try
            {
                int t = int.Parse(textBox.Text);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, textBox.Tag + "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox.Text = null;
            }
        }

        private bool CheckNull(TextBox textBox)
        {
            if (textBox.Visible == false || (textBox.Visible == true && textBox.Text != null))
                return true;
            return false;
        }

        private bool CheckNullAllTextBox()
        {
            bool result = true;
            foreach(Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    result = result && CheckNull((TextBox)c);
                }
            }
            return result;
        }

        private void CheckInputCategory()
        {
            if(textBox3.Text != null)
            {
                try
                {
                    int t = int.Parse(this.textBox3.Text);
                    if (!(1 <= t && t <= 3))
                    {
                        MessageBox.Show("仅支持输入三种产品。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox3.Text = null;
                    }
                    else
                    {
                        if (t == 2)
                        {
                            label6.Visible = true;
                            textBox6.Visible = true;
                            label7.Visible = true;
                            textBox7.Visible = true;
                            textBox11.Visible = true;
                            label11.Visible = true;
                            label8.Visible = false;
                            textBox8.Visible = false;
                            label9.Visible = false;
                            textBox9.Visible = false;
                            textBox12.Visible = false;
                            label12.Visible = false;
                        }
                        else if (t == 3)
                        {
                            label6.Visible = true;
                            textBox6.Visible = true;
                            label7.Visible = true;
                            textBox7.Visible = true;
                            textBox11.Visible = true;
                            label11.Visible = true;
                            label8.Visible = true;
                            textBox8.Visible = true;
                            label9.Visible = true;
                            textBox9.Visible = true;
                            textBox12.Visible = true;
                            label12.Visible = true;
                        }
                        else
                        {
                            label6.Visible = false;
                            textBox6.Visible = false;
                            label7.Visible = false;
                            textBox7.Visible = false;
                            label8.Visible = false;
                            textBox11.Visible = false;
                            label11.Visible = false;
                            textBox8.Visible = false;
                            label9.Visible = false;
                            textBox9.Visible = false;
                            textBox12.Visible = false;
                            label12.Visible = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Text = null;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
                isPressed = true;
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (isPressed == true)
            {
                CheckInputCategory();
                isPressed = false;
            }
        }
    }
}
