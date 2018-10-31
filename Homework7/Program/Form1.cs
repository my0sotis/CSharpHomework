using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Order;

namespace Program
{
    public partial class Form1 : Form
    {
        OrderService os = new OrderService();
        public string control { set; get; }
        public string flag { set; get; }
        public string content { set; get; }

        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(Form1_Load);

            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("查询订单");
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf("订单号");

            OrderbindingSource.DataSource = os.ListOfOrder;

            comboBox1.DataBindings.Add("Text", this, control);
            comboBox2.DataBindings.Add("Text", this, flag);
            textBox1.DataBindings.Add("Text", this, content);
        }

        private void MenuTool1_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm();
            addOrderForm.TransfEvent += AddOrderForm_Add;
            addOrderForm.ShowDialog();
            OrderbindingSource.DataSource = os.SearchByClientName("qw");
        }

        private void AddOrderForm_Add(Order.Order value)
        {
            os.ListOfOrder.Add(value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OrderGridView.AutoResizeColumns();
            OrderDetailGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == comboBox1.Items.IndexOf("查询订单"))
                button1.Text = "查询";
            else
                button1.Text = "删除";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Order.Order> list = new List<Order.Order>();
            if (textBox1.Text != null)
            {
                if (control == "查询订单")
                {
                    if (flag == "订单号")
                    {
                        CheckNum(textBox1);
                        list = os.SearchByOrderNum(int.Parse(content));
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                    else if (flag == "用户名")
                    {
                        list = os.SearchByClientName(content);
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                    else if(flag == "总价高于所输入值的")
                    {
                        CheckNum(textBox1);
                        list = os.SearchByWhichTotalPriceOver(int.Parse(textBox1.Text));
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                    else
                    {
                        CheckNum(textBox1);
                        list = os.SearchByProductName(textBox1.Text);
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                }
                else
                {
                    if (flag == "订单号")
                    {
                        CheckNum(textBox1);
                        list = os.SearchByOrderNum(int.Parse(content));
                        if (CheckListNull(list) == true)
                        {
                            foreach(Order.Order o in list)
                            {
                                os.ListOfOrder.Remove(o);
                            }
                            OrderbindingSource.DataSource = os.SearchByClientName();
                        }
                    }
                    else if (flag == "用户名")
                    {
                        list = os.SearchByClientName(content);
                        if (CheckListNull(list) == true)
                        {
                            foreach (Order.Order o in list)
                            {
                                os.ListOfOrder.Remove(o);
                            }
                            OrderbindingSource.DataSource = os.SearchByClientName();
                        }
                    }
                    else if (flag == "总价高于所输入值的")
                    {
                        CheckNum(textBox1);
                        list = os.SearchByWhichTotalPriceOver(int.Parse(textBox1.Text));
                        if (CheckListNull(list) == true)
                        {
                            foreach (Order.Order o in list)
                            {
                                os.ListOfOrder.Remove(o);
                            }
                            OrderbindingSource.DataSource = os.SearchByClientName();
                        }
                    }
                    else
                    {
                        CheckNum(textBox1);
                        list = os.SearchByProductName(textBox1.Text);
                        if (CheckListNull(list) == true)
                        {
                            foreach (Order.Order o in list)
                            {
                                os.ListOfOrder.Remove(o);
                            }
                            OrderbindingSource.DataSource = os.SearchByClientName();
                        }
                    }
                }

            }
        }

        private bool CheckListNull(List<Order.Order> list)
        {
            if(list == null)
            {
                MessageBox.Show("未找到相关订单。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OrderbindingSource.DataSource = os.SearchByClientName(null);
                return false;
            }
            return true;
        }

        private void CheckNum(TextBox textBox)
        {
            try
            {
                int t = int.Parse(textBox.Text);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox.Text = null;
            }
        }
    }
}
