using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Order
{
    public delegate void TransfDelegate(OrderList value);
    public partial class AddOrderForm : Form
    {
        public bool isPressed = false;
        public List<OrderList> order;

        public AddOrderForm(List<OrderList> list)
        {
            InitializeComponent();
            this.order = list;
        }

        public event TransfDelegate TransfEvent;
        private void button1_Click(object sender, EventArgs e)
        {
            int totalPrice = 0;
            // 检查所有文本框是否有空项
            if (CheckNullAllTextBox() == true)
            {
                // 检查订单号、客户手机号、产品种类是否为数字，并检查订单号是否符合规范及是否有重复项
                if(!(CheckNum(textBox3) && CheckPhoneNumber(textBox13) && CheckOrderIdValid(textBox1) && CheckOrderIdRepeat(textBox1)))
                    return;
                uint t = uint.Parse(textBox3.Text);
                List<OrderDetails> details = new List<OrderDetails>();
                for (int i = 0; i < t; i++)
                {
                    if (i == 0)
                    {
                        if (!(CheckNum(textBox5) && CheckNum(textBox10)))
                            return;
                        OrderDetails od = new OrderDetails(textBox1.Text, textBox4.Text, int.Parse(textBox5.Text), int.Parse(textBox10.Text));
                        details.Add(od);
                        totalPrice += int.Parse(textBox5.Text) * int.Parse(textBox10.Text);
                    }
                    else if (i == 1)
                    {
                        if (!(CheckNum(textBox6) && CheckNum(textBox11)))
                            return;
                        OrderDetails od = new OrderDetails(textBox1.Text, textBox7.Text, int.Parse(textBox6.Text), int.Parse(textBox11.Text));
                        details.Add(od);
                        totalPrice += int.Parse(textBox6.Text) * int.Parse(textBox11.Text);
                    }
                    else
                    {
                        if (!(CheckNum(textBox8) && CheckNum(textBox12)))
                            return;
                        OrderDetails od = new OrderDetails(textBox1.Text, textBox9.Text, int.Parse(textBox8.Text), int.Parse(textBox12.Text));
                        details.Add(od);
                        totalPrice += int.Parse(textBox8.Text) * int.Parse(textBox12.Text);
                    }
                }
                OrderList order = new OrderList(textBox1.Text, textBox2.Text, textBox13.Text, int.Parse(textBox3.Text), details, totalPrice);
                TransfEvent(order);
                Close();
            }
            else
                MessageBox.Show("您所输入的值有空项，请检查后再提交。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool CheckOrderIdValid(TextBox textBox)
        {
            string pattern = "^(?:(?!0000)[0-9]{4}(?:(?:0[1-9]|1[0-2])(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)0229)[0-9]{3}$";
            if (Regex.IsMatch(textBox.Text, pattern) == true)
                return true;
            else
            {
                MessageBox.Show("你所输入的订单号不符合规范，应为“年月日+三位流水号”的形式。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Text = null;
                return false;
            }
        }

        private bool CheckOrderIdRepeat(TextBox textBox)
        {
            foreach (OrderList o in order)
                if (o.OrderId == textBox.Text)
                {
                    MessageBox.Show("你所输入的订单号有重复！", "输入错误!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = null;
                    return false;
                }
            return true;
        }

        private bool CheckNum(TextBox textBox)
        {
            try
            {
                int t = int.Parse(textBox.Text);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, textBox.Tag + "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Text = null;
                return false;
            }
            return true;
        }

        private bool CheckPhoneNumber(TextBox textBox)
        {
            string pattern = "^[0-9]{11}$";
            if (Regex.IsMatch(textBox.Text, pattern) == true)
                return true;
            else
            {
                MessageBox.Show("你所输入的客户手机号码格式有误。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Text = null;
                return false;
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
                if(c is TextBox)
                    result = result && CheckNull((TextBox)c);
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
                        MessageBox.Show("仅支持输入三种产品。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show(e.Message, "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
