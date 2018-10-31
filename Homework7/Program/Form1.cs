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
        BindingSource b = new BindingSource();


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
            b.DataSource =new BindingList<Order.Order>(os.ListOfOrder);
            OrderbindingSource.DataSource = b;
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
            b.DataSource = new BindingList<Order.Order>(os.ListOfOrder);
            if (textBox1.Text != null)
            {
                string s = textBox1.Text;
                if (control == "查询订单")
                {
                    if (flag == "订单号")
                    {
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
                        list = os.SearchByWhichTotalPriceOver(int.Parse(textBox1.Text));
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                    else
                    {
                        list = os.SearchByProductName(textBox1.Text);
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                    label1.Text = "你所搜到的订单数目为" + list.Capacity;
                }
                else
                {
                    if (flag == "订单号")
                    {
                        list = os.SearchByOrderNum(int.Parse(content));
                        if (CheckListNull(list) == true)
                        {
                            foreach(Order.Order o in list)
                            {
                                os.ListOfOrder.Remove(o);
                            }
                            OrderbindingSource.DataSource = b;
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
                            OrderbindingSource.DataSource = b;
                        }
                    }
                    else if (flag == "总价高于所输入值的")
                    {
                        list = os.SearchByWhichTotalPriceOver(int.Parse(textBox1.Text));
                        if (CheckListNull(list) == true)
                        {
                            foreach (Order.Order o in list)
                            {
                                os.ListOfOrder.Remove(o);
                            }
                            OrderbindingSource.DataSource = b;
                        }
                    }
                    else
                    {
                        list = os.SearchByProductName(textBox1.Text);
                        if (CheckListNull(list) == true)
                        {
                            foreach (Order.Order o in list)
                            {
                                os.ListOfOrder.Remove(o);
                            }
                            OrderbindingSource.DataSource = b;
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

        //检测错误时，总是出现虽然输入是数字，但提示格式错误
        private bool CheckNum(TextBox textBox)
        {
            int t = 0;
            if (int.TryParse(textBox.Text,out t))
            {
                return true;
            }
            else
            {
                MessageBox.Show("输入错误的值。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox.Text = null;
                return false;
            }
            
        }

        private void OrderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前点击的订单号
            string value = OrderGridView.Rows[OrderGridView.CurrentRow.Index].Cells[0].Value.ToString();
            Order.Order order = os.SearchByOrderNum(int.Parse(value))[0];
            OrderDetailGridView.DataSource = order.ListOfDetails;           //显示该订单
        }

        private void MenuTool3_Click(object sender, EventArgs e)
        {
            //显示所有订单
            b.DataSource = new BindingList<Order.Order>(os.ListOfOrder);
            OrderGridView.DataSource = b;
        }

        private void 修改订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = OrderGridView.Rows[OrderGridView.CurrentRow.Index].Cells[0].Value.ToString();
            Order.Order order = os.SearchByOrderNum(int.Parse(value))[0];
            Order.Order o = os.SearchByOrderNum(int.Parse(value))[0];
            ChangeOrderForm changeOrderForm = new ChangeOrderForm(o);
            changeOrderForm.ShowDialog();
            os.ListOfOrder.Add(o);
            os.ListOfOrder.Remove(order);
            b.DataSource = new BindingList<Order.Order>(os.ListOfOrder);
            OrderbindingSource.DataSource = b;
        }
    }
}
