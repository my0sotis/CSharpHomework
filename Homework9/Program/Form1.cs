using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Order;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using MySql.Data.MySqlClient;

namespace Program
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
        }

        private void MenuTool1_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm(os.ListOfOrder);
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
            if (textBox1.Text != "")
            {
                string s = textBox1.Text;
                if (comboBox1.Text == "查询订单")
                {
                    if (comboBox2.Text == "订单号")
                    {
                        list = os.SearchByOrderId(long.Parse(textBox1.Text));
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                    else if (comboBox2.Text == "用户名")
                    {
                        list = os.SearchByClientName(textBox1.Text);
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                    else if(comboBox2.Text == "总价高于所输入值的")
                    {
                        list = os.SearchByWhichTotalPriceOver(long.Parse(textBox1.Text));
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                    else
                    {
                        list = os.SearchByProductName(textBox1.Text);
                        if (CheckListNull(list) == true)
                            OrderbindingSource.DataSource = list;
                    }
                }
                else
                {
                    if (comboBox2.Text == "订单号")
                    {
                        list = os.SearchByOrderId(long.Parse(textBox1.Text));
                        if (CheckListNull(list) == true)
                        {
                            foreach(Order.Order o in list)
                                os.ListOfOrder.Remove(o);
                            OrderbindingSource.DataSource = b;
                        }
                    }
                    else if (comboBox2.Text == "用户名")
                    {
                        list = os.SearchByClientName(textBox1.Text);
                        if (CheckListNull(list) == true)
                        {
                            foreach (Order.Order o in list)
                                os.ListOfOrder.Remove(o);
                            OrderbindingSource.DataSource = b;
                        }
                    }
                    else if (comboBox2.Text == "总价高于所输入值的")
                    {
                        list = os.SearchByWhichTotalPriceOver(long.Parse(textBox1.Text));
                        if (CheckListNull(list) == true)
                        {
                            foreach (Order.Order o in list)
                                os.ListOfOrder.Remove(o);
                            OrderbindingSource.DataSource = b;
                        }
                    }
                    else
                    {
                        list = os.SearchByProductName(textBox1.Text);
                        if (CheckListNull(list) == true)
                        {
                            foreach (Order.Order o in list)
                                os.ListOfOrder.Remove(o);
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

        private void OrderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前点击的订单号
            string value = OrderGridView.Rows[OrderGridView.CurrentRow.Index].Cells[0].Value.ToString();
            Order.Order order = os.SearchByOrderId(long.Parse(value))[0];
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
            Order.Order order = os.SearchByOrderId(int.Parse(value))[0];
            Order.Order o = os.SearchByOrderId(int.Parse(value))[0];
            ChangeOrderForm changeOrderForm = new ChangeOrderForm(o);
            changeOrderForm.ShowDialog();
            os.ListOfOrder.Add(o);
            os.ListOfOrder.Remove(order);
            b.DataSource = new BindingList<Order.Order>(os.ListOfOrder);
            OrderbindingSource.DataSource = b;
        }

        private void ImportOrder_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Order.Order>));
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
                    os.ListOfOrder = (List<Order.Order>)xml.Deserialize(fs);
                    fs.Close();
                    b.DataSource = new BindingList<Order.Order>(os.ListOfOrder);
                    OrderbindingSource.DataSource = b;
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
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order.Order>));
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
                    xmlser.Serialize(fs, os.ListOfOrder);
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
            }catch(Exception)
            {
                MessageBox.Show("您所输入的订单有误！", "输入错误！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void createMySQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMySqlDatabase();
        }

        private void CreateMySqlDatabase()
        {
            try
            {
                // UserId为MySQL用户名，PWD为密码
                string createOrderListStatement = "CREATE TABLE OrderList (" +
                    "OrderId VARCHAR(11), ClientName VARCHAR(20), " +
                    "ClientPhoneNumber VARCHAR(11), ProductCategory SMALLINT UNSIGNED, TotalPrice INT UNSIGNED);";
                string createOrderDetailsStatement = "CREATE TABLE DetailsList(" +
                    "ProductName VARCHAR(20), PriceOfProduct INT UNSIGNED, NumOfProduct INT UNSIGNED);";
                using (MySqlConnection connection = new MySqlConnection("Data Source = localhost;Persist Security Info = yes;" +
                    "UserId = root;PWD=159357258"))
                {
                    connection.Open();

                    // ListOfOrder为数据库名称，创建一个数据库并使用这个数据库
                    using (MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS ListOfOrder; USE ListOfOrder;", connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    connection.ChangeDatabase("ListOfOrder");
                    // 创建订单列表
                    using (MySqlCommand cmd = new MySqlCommand(createOrderListStatement, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    // 创建订单详情列表
                    using (MySqlCommand cmd = new MySqlCommand(createOrderDetailsStatement, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("生成订单数据库成功！", "生成成功！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "生成错误!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("删除订单数据库成功！", "删除成功！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "删除失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteMySQLDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMySqlDatabase();
        }
    }
}
