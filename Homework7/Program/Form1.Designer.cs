using System.Windows.Forms;

namespace Program
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.OrderGridView = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrderDetailGridView = new System.Windows.Forms.DataGridView();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numOfProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceOfProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDetail = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGridView)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetail)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.MenuTool3});
            this.MenuTool.Name = "MenuTool";
            this.MenuTool.Size = new System.Drawing.Size(51, 24);
            this.MenuTool.Text = "菜单";
            // 
            // MenuTool1
            // 
            this.MenuTool1.Name = "MenuTool1";
            this.MenuTool1.Size = new System.Drawing.Size(181, 26);
            this.MenuTool1.Text = "添加订单";
            this.MenuTool1.Click += new System.EventHandler(this.MenuTool1_Click);
            // 
            // MenuTool3
            // 
            this.MenuTool3.Name = "MenuTool3";
            this.MenuTool3.Size = new System.Drawing.Size(181, 26);
            this.MenuTool3.Text = "显示所有订单";
            this.MenuTool3.Click += new System.EventHandler(this.MenuTool3_Click);
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
            this.clientNameDataGridViewTextBoxColumn,
            this.productCategoryDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn});
            this.OrderGridView.ContextMenuStrip = this.contextMenuStrip2;
            this.OrderGridView.DataSource = this.OrderbindingSource;
            this.OrderGridView.Location = new System.Drawing.Point(0, 11);
            this.OrderGridView.Name = "OrderGridView";
            this.OrderGridView.RowTemplate.Height = 27;
            this.OrderGridView.Size = new System.Drawing.Size(1006, 224);
            this.OrderGridView.TabIndex = 2;
            this.OrderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderGridView_CellClick);
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.Name = "OrderId";
            // 
            // clientNameDataGridViewTextBoxColumn
            // 
            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.HeaderText = "ClientName";
            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";
            // 
            // productCategoryDataGridViewTextBoxColumn
            // 
            this.productCategoryDataGridViewTextBoxColumn.DataPropertyName = "ProductCategory";
            this.productCategoryDataGridViewTextBoxColumn.HeaderText = "ProductCategory";
            this.productCategoryDataGridViewTextBoxColumn.Name = "productCategoryDataGridViewTextBoxColumn";
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
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
            this.修改订单ToolStripMenuItem.Click += new System.EventHandler(this.修改订单ToolStripMenuItem_Click);
            // 
            // OrderbindingSource
            // 
            this.OrderbindingSource.AllowNew = false;
            this.OrderbindingSource.DataSource = typeof(Order.Order);
            // 
            // OrderDetailGridView
            // 
            this.OrderDetailGridView.AutoGenerateColumns = false;
            this.OrderDetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderDetailGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn,
            this.numOfProductDataGridViewTextBoxColumn,
            this.priceOfProductDataGridViewTextBoxColumn});
            this.OrderDetailGridView.DataSource = this.OrderDetail;
            this.OrderDetailGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderDetailGridView.Location = new System.Drawing.Point(0, 0);
            this.OrderDetailGridView.Name = "OrderDetailGridView";
            this.OrderDetailGridView.RowTemplate.Height = 27;
            this.OrderDetailGridView.Size = new System.Drawing.Size(1006, 168);
            this.OrderDetailGridView.TabIndex = 0;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            // 
            // numOfProductDataGridViewTextBoxColumn
            // 
            this.numOfProductDataGridViewTextBoxColumn.DataPropertyName = "NumOfProduct";
            this.numOfProductDataGridViewTextBoxColumn.HeaderText = "NumOfProduct";
            this.numOfProductDataGridViewTextBoxColumn.Name = "numOfProductDataGridViewTextBoxColumn";
            // 
            // priceOfProductDataGridViewTextBoxColumn
            // 
            this.priceOfProductDataGridViewTextBoxColumn.DataPropertyName = "PriceOfProduct";
            this.priceOfProductDataGridViewTextBoxColumn.HeaderText = "PriceOfProduct";
            this.priceOfProductDataGridViewTextBoxColumn.Name = "priceOfProductDataGridViewTextBoxColumn";
            // 
            // OrderDetail
            // 
            this.OrderDetail.DataSource = typeof(Order.OrderDetails);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 65);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(674, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "查询";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
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
            ((System.ComponentModel.ISupportInitialize)(this.OrderbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private DataGridViewTextBoxColumn OrderId;
        private DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productCategoryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private ToolStripMenuItem MenuTool3;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem 修改订单ToolStripMenuItem;
    }
}

