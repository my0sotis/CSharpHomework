using System.Windows.Forms;
using Order;

namespace Order
{
    partial class 订单管理
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTool1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTool3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.OrderGridView = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderDetailGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientPhoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDetail = new System.Windows.Forms.BindingSource(this.components);
            this.createMySQLDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMySQLDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGridView)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 498);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1006, 55);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTool});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(20, 5, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1006, 31);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuTool
            // 
            this.MenuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTool1,
            this.MenuTool3,
            this.ExportOrder,
            this.ImportOrder,
            this.createMySQLDatabaseToolStripMenuItem,
            this.deleteMySQLDatabaseToolStripMenuItem});
            this.MenuTool.Name = "MenuTool";
            this.MenuTool.Size = new System.Drawing.Size(51, 24);
            this.MenuTool.Text = "菜单";
            // 
            // MenuTool1
            // 
            this.MenuTool1.Name = "MenuTool1";
            this.MenuTool1.Size = new System.Drawing.Size(259, 26);
            this.MenuTool1.Text = "Add Order";
            this.MenuTool1.Click += new System.EventHandler(this.MenuTool1_Click);
            // 
            // MenuTool3
            // 
            this.MenuTool3.Name = "MenuTool3";
            this.MenuTool3.Size = new System.Drawing.Size(259, 26);
            this.MenuTool3.Text = "Display All Orders";
            this.MenuTool3.Click += new System.EventHandler(this.MenuTool3_Click);
            // 
            // ExportOrder
            // 
            this.ExportOrder.Name = "ExportOrder";
            this.ExportOrder.Size = new System.Drawing.Size(259, 26);
            this.ExportOrder.Text = "Import Orders";
            this.ExportOrder.Click += new System.EventHandler(this.ImportOrder_Click);
            // 
            // ImportOrder
            // 
            this.ImportOrder.Name = "ImportOrder";
            this.ImportOrder.Size = new System.Drawing.Size(259, 26);
            this.ImportOrder.Text = "Export Orders";
            this.ImportOrder.Click += new System.EventHandler(this.ExportOrder_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 91);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.OrderGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OrderDetailGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1006, 407);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 4;
            // 
            // OrderGridView
            // 
            this.OrderGridView.AutoGenerateColumns = false;
            this.OrderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.ClientPhoneNumber,
            this.orderIdDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.clientPhoneNumberDataGridViewTextBoxColumn});
            this.OrderGridView.ContextMenuStrip = this.contextMenuStrip2;
            this.OrderGridView.DataSource = this.OrderbindingSource;
            this.OrderGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderGridView.Location = new System.Drawing.Point(0, 0);
            this.OrderGridView.Name = "OrderGridView";
            this.OrderGridView.RowTemplate.Height = 27;
            this.OrderGridView.Size = new System.Drawing.Size(1006, 235);
            this.OrderGridView.TabIndex = 2;
            this.OrderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderGridView_CellClick);
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.Name = "OrderId";
            // 
            // ClientPhoneNumber
            // 
            this.ClientPhoneNumber.DataPropertyName = "ClientPhoneNumber";
            this.ClientPhoneNumber.HeaderText = "ClientPhoneNumber";
            this.ClientPhoneNumber.Name = "ClientPhoneNumber";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改订单ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(139, 28);
            // 
            // 修改订单ToolStripMenuItem
            // 
            this.修改订单ToolStripMenuItem.Name = "修改订单ToolStripMenuItem";
            this.修改订单ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.修改订单ToolStripMenuItem.Text = "修改订单";
            // 
            // OrderDetailGridView
            // 
            this.OrderDetailGridView.AutoGenerateColumns = false;
            this.OrderDetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderDetailGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.OrderDetailGridView.DataSource = this.OrderDetail;
            this.OrderDetailGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderDetailGridView.Location = new System.Drawing.Point(0, 0);
            this.OrderDetailGridView.Name = "OrderDetailGridView";
            this.OrderDetailGridView.RowTemplate.Height = 27;
            this.OrderDetailGridView.Size = new System.Drawing.Size(1006, 168);
            this.OrderDetailGridView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 54);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(674, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(349, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(287, 25);
            this.textBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "订单号",
            "用户名",
            "产品名",
            "总价高于所输入值的"});
            this.comboBox2.Location = new System.Drawing.Point(184, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(146, 23);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "查询订单",
            "删除订单"});
            this.comboBox1.Location = new System.Drawing.Point(75, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ClientName";
            this.dataGridViewTextBoxColumn1.HeaderText = "ClientName";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProductCategory";
            this.dataGridViewTextBoxColumn2.HeaderText = "ProductCategory";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TotalPrice";
            this.dataGridViewTextBoxColumn3.HeaderText = "TotalPrice";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // clientPhoneNumberDataGridViewTextBoxColumn
            // 
            this.clientPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "ClientPhoneNumber";
            this.clientPhoneNumberDataGridViewTextBoxColumn.HeaderText = "ClientPhoneNumber";
            this.clientPhoneNumberDataGridViewTextBoxColumn.Name = "clientPhoneNumberDataGridViewTextBoxColumn";
            // 
            // OrderbindingSource
            // 
            this.OrderbindingSource.AllowNew = false;
            this.OrderbindingSource.DataSource = typeof(OrderList);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ProductName";
            this.dataGridViewTextBoxColumn4.HeaderText = "ProductName";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NumOfProduct";
            this.dataGridViewTextBoxColumn5.HeaderText = "NumOfProduct";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PriceOfProduct";
            this.dataGridViewTextBoxColumn6.HeaderText = "PriceOfProduct";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // OrderDetail
            // 
            this.OrderDetail.DataSource = typeof(OrderDetails);
            // 
            // createMySQLDatabaseToolStripMenuItem
            // 
            this.createMySQLDatabaseToolStripMenuItem.Name = "createMySQLDatabaseToolStripMenuItem";
            this.createMySQLDatabaseToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.createMySQLDatabaseToolStripMenuItem.Text = "Create MySQL Database";
            this.createMySQLDatabaseToolStripMenuItem.Click += new System.EventHandler(this.createMySQLDatabaseToolStripMenuItem_Click);
            // 
            // deleteMySQLDatabaseToolStripMenuItem
            // 
            this.deleteMySQLDatabaseToolStripMenuItem.Name = "deleteMySQLDatabaseToolStripMenuItem";
            this.deleteMySQLDatabaseToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.deleteMySQLDatabaseToolStripMenuItem.Text = "Delete MySQL Database";
            this.deleteMySQLDatabaseToolStripMenuItem.Click += new System.EventHandler(this.deleteMySQLDatabaseToolStripMenuItem_Click);
            // 
            // 订单管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "订单管理";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrderGridView)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuTool;
        private System.Windows.Forms.ToolStripMenuItem MenuTool1;
        private System.Windows.Forms.BindingSource OrderbindingSource;
        private System.Windows.Forms.Label label1;
        private SplitContainer splitContainer1;
        private DataGridView OrderGridView;
        private DataGridView OrderDetailGridView;
        private BindingSource OrderDetail;
        private DataGridViewTextBoxColumn orderNumDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numOfProductDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceOfProductDataGridViewTextBoxColumn;
        private Panel panel1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private Button button1;
        private ToolStripMenuItem MenuTool3;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem 修改订单ToolStripMenuItem;
        private ToolStripMenuItem ExportOrder;
        private ToolStripMenuItem ImportOrder;
        private DataGridViewTextBoxColumn OrderId;
        private DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ClientPhoneNumber;
        private DataGridViewTextBoxColumn productCategoryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn clientPhoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private ToolStripMenuItem createMySQLDatabaseToolStripMenuItem;
        private ToolStripMenuItem deleteMySQLDatabaseToolStripMenuItem;
    }
}

