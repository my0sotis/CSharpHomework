using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order
{
    public partial class ChangeOrderForm : Form
    {
        public OrderList order;
        public ChangeOrderForm(OrderList order)
        {
            InitializeComponent();
            this.order = order;
            if(order.ProductCategory == 1)
            {
                comboBox1.Items.Remove("订单2名称");
                comboBox1.Items.Remove("订单2价格");
                comboBox1.Items.Remove("订单2数目");
                comboBox1.Items.Remove("订单3名称");
                comboBox1.Items.Remove("订单3价格");
                comboBox1.Items.Remove("订单3数目");
            }
            else if(order.ProductCategory == 2)
            {
                comboBox1.Items.Remove("订单3名称");
                comboBox1.Items.Remove("订单3价格");
                comboBox1.Items.Remove("订单3数目");
            }
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("订单号");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null)
            {
                string s = textBox1.Text;
                if (comboBox1.Text == "订单号")
                {
                    //if (CheckNum(textBox1) == false)
                    //    return;
                    order.OrderId = s;
                }
                else if (comboBox1.Text == "用户名")
                    order.ClientName = s;
                else if (comboBox1.Text == "订单1名称")
                    order.ListOfDetails[0].ProductName = s;
                else if (comboBox1.Text == "订单1数目")
                {
                    //if (CheckNum(textBox1) == false)
                    //    return;
                    order.ListOfDetails[0].NumOfProduct = int.Parse(s);
                }
                else if(comboBox1.Text == "订单1价格")
                {
                    //if (CheckNum(textBox1) == false)
                    //    return;
                    order.ListOfDetails[0].PriceOfProduct = int.Parse(s);
                }
                else if (comboBox1.Text == "订单2名称")
                    order.ListOfDetails[1].ProductName = s;
                else if (comboBox1.Text == "订单2数目")
                {
                    //if (CheckNum(textBox1) == false)
                    //    return;
                    order.ListOfDetails[1].NumOfProduct = int.Parse(s);
                }
                else if (comboBox1.Text == "订单2价格")
                {
                    //if (CheckNum(textBox1) == false)
                    //    return;
                    order.ListOfDetails[1].PriceOfProduct = int.Parse(s);
                }
                else if (comboBox1.Text == "订单3名称")
                    order.ListOfDetails[2].ProductName = s;
                else if (comboBox1.Text == "订单3数目")
                {
                    //if (CheckNum(textBox1) == false)
                    //    return;
                    order.ListOfDetails[2].NumOfProduct = int.Parse(s);
                }
                else if (comboBox1.Text == "订单3价格")
                {
                    //if (CheckNum(textBox1) == false)
                    //    return;
                    order.ListOfDetails[2].PriceOfProduct = int.Parse(s);
                }
                this.Close();
            }
            else
                MessageBox.Show("输入为空。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private bool CheckNum(TextBox textBox)
        {
            try
            {
                int t = int.Parse(textBox.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Text = null;
                return false;
            }
            return true;
        }
    }
}
