using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Data;
using Order;
using System.Data.Entity;

namespace Order
{
    public partial class 订单管理 : Form
    {
        public OrderService os = new OrderService();
        BindingSource b = new BindingSource();

        public 订单管理()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(Form1_Load);

            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("查询订单");
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf("订单号");
            OrderGridView.ReadOnly = true;


            //CreateMySqlDatabase();
        }

        private void MenuTool1_Click(object sender, EventArgs e)
        {
            using (var db = new OrderDB())
            {
                IQueryable<OrderList> order = from t in db.Order select t;
                var list = order.ToList();
                AddOrderForm addOrderForm = new AddOrderForm(list);
                addOrderForm.TransfEvent += AddOrderForm_Add;
                addOrderForm.ShowDialog();
                order = from t in db.Order select t;
                list = order.ToList();
                b.DataSource = new BindingList<OrderList>(list);
                OrderbindingSource.DataSource = b;
            }
        }

        private void AddOrderForm_Add(OrderList value)
        {
            os.Add(value);
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
            using (var db = new OrderDB())
            {
                List<OrderList> list = new List<OrderList>();
                OrderService os = new OrderService();
                IQueryable<OrderList> orders = from t in db.Order select t;
                list = orders.ToList();
                b.DataSource = new BindingList<OrderList>(list);
                if (textBox1.Text != "")
                {
                    string s = textBox1.Text;
                    if (comboBox2.Text == "订单号")
                        list = os.QueryByOrderId(textBox1.Text);
                    else if (comboBox2.Text == "用户名")
                        list = os.QueryByClientName(textBox1.Text);
                    else if (comboBox2.Text == "总价高于所输入值的")
                        list = os.QueryByTotalPriceOver(long.Parse(textBox1.Text));
                    else
                        list = os.QueryByProductName(textBox1.Text);

                    if (comboBox1.Text == "查询订单")
                    {
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                    else
                    {
                        if (CheckListNull(list) == true)
                        {
                            foreach (OrderList o in list)
                                os.Delete(o.OrderId);
                            orders = from t in db.Order select t;
                            list = orders.ToList();
                            OrderbindingSource.DataSource = b;
                        }
                    }
                }
            }
        }

        private bool CheckListNull(List<OrderList> list)
        {
            if(list == null)
            {
                using (var db = new OrderDB())
                {
                    MessageBox.Show("未找到相关订单。", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Text = null;
                    OrderbindingSource.DataSource = db.Order;
                    return false;
                }
            }
            return true;
        }

        private void OrderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前点击的订单号
            string value = OrderGridView.Rows[OrderGridView.CurrentRow.Index].Cells[0].Value.ToString();
            OrderList order = os.QueryByOrderId(value)[0];
            OrderDetailGridView.DataSource = order.ListOfDetails;           //显示该订单
        }

        private void MenuTool3_Click(object sender, EventArgs e)
        {
            //显示所有订单
            using (var db = new OrderDB())
            {
                IQueryable<OrderList> orders = from t in db.Order select t;
                var list = orders.ToList();
                b.DataSource = new BindingList<OrderList>(list);
                OrderGridView.DataSource = b;
            }
        }

        private void 修改订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new OrderDB())
            {
                string value = OrderGridView.Rows[OrderGridView.CurrentRow.Index].Cells[0].Value.ToString();
                OrderList order = os.QueryByOrderId(value)[0];
                OrderList o = os.QueryByOrderId(value)[0];
                ChangeOrderForm changeOrderForm = new ChangeOrderForm(o);
                changeOrderForm.ShowDialog();
                os.Update(o);
                IQueryable<OrderList> orders = from t in db.Order select t;
                var list = orders.ToList();
                b.DataSource = new BindingList<OrderList>(list);
                OrderbindingSource.DataSource = b;
            }
        }

        private void ImportOrder_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new OrderDB())
                {
                    OrderService os = new OrderService();
                    XmlSerializer xml = new XmlSerializer(typeof(List<OrderList>));
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Title = "Open the file";
                    openFileDialog.Filter = "txt files(*.txt)|*.txt|All files(*.*)|*.*";
                    openFileDialog.AddExtension = true;
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.CheckPathExists = true;
                    openFileDialog.DefaultExt = "*.txt|*.txt";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                        //os.ListOfOrder = (List<Order>)xml.Deserialize(fs);
                        foreach (OrderList order in (List<OrderList>)xml.Deserialize(fs))
                            os.Add(order);
                        fs.Close();
                        IQueryable<OrderList> orders = from t in db.Order select t;
                        var list = orders.ToList();
                        b.DataSource = new BindingList<OrderList>(list);
                        OrderbindingSource.DataSource = b;
                    }
                }
            }catch(Exception)
            {
                return;
            }
        }

        private void ExportOrder_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new OrderDB())
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(List<OrderList>));
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Save the File";
                    saveFileDialog.Filter = "txt file(*.txt)|*.txt|html file(*.html)|*.html";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.CheckPathExists = true;
                    saveFileDialog.OverwritePrompt = true;
                    saveFileDialog.DefaultExt = "*.txt|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //不论结果需要txt还是html，事先生成一个xml文件(txt)
                        string filepath = saveFileDialog.FileName;
                        filepath = Path.GetDirectoryName(filepath);
                        string filename = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);

                        FileStream fs = new FileStream(filepath + filename + ".txt", FileMode.OpenOrCreate);
                        xmlser.Serialize(fs, db.Order);
                        fs.Close();
                        if (saveFileDialog.FilterIndex == 2)
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load(filepath + filename + ".txt");

                            XPathNavigator navigator = xmlDocument.CreateNavigator();
                            navigator.MoveToRoot();

                            XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
                            xslCompiledTransform.Load(@"..\..\OrderList.xslt");

                            FileStream fileStream = File.OpenWrite(saveFileDialog.FileName);
                            XmlWriterSettings settings = new XmlWriterSettings();
                            XmlWriter xmlWriter = XmlWriter.Create(fileStream, settings);

                            xslCompiledTransform.Transform(navigator, null, xmlWriter);
                            File.Delete(filepath + filename + ".txt");
                            fileStream.Close();
                        }
                    }
                }
            }catch(Exception)
            {
                MessageBox.Show("您所输入的订单有误！", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void DeleteMySqlDatabase()
        {
            try
            {
                string deleteDatabaseStatement = "DROP DATABASE ListOfOrder;";
                using (MySqlConnection connection = new MySqlConnection("Data Source = localhost;Persist Security Info = yes;" +
                    "UserId = root;PWD=159357258;Database = ListOfOrder"))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(deleteDatabaseStatement, connection))
                        cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "删除失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteMySQLDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMySqlDatabase();
        }
    }
}
