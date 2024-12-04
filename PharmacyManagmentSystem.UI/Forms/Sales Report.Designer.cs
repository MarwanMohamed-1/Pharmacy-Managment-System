namespace PharmacyManagmentSystem.UI.Forms
{
    partial class Sales_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.saleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saleBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.purchaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saleBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.saleBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.search);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(361, 32);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker2.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(97, 31);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(328, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "To";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(644, 28);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(110, 32);
            this.search.TabIndex = 15;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(8, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 20);
            this.label19.TabIndex = 5;
            this.label19.Text = "Sales from";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.Customer_ID,
            this.Sale_Date,
            this.SaleItems});
            this.dataGridView1.DataSource = this.saleBindingSource3;
            this.dataGridView1.Location = new System.Drawing.Point(9, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(779, 208);
            this.dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Print Report";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // saleBindingSource
            // 
            this.saleBindingSource.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Sale);
            // 
            // saleBindingSource1
            // 
            this.saleBindingSource1.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Sale);
            // 
            // purchaseBindingSource
            // 
            this.purchaseBindingSource.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Purchase);
            // 
            // saleBindingSource2
            // 
            this.saleBindingSource2.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Sale);
            // 
            // saleBindingSource3
            // 
            this.saleBindingSource3.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Sale);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // Customer_ID
            // 
            this.Customer_ID.DataPropertyName = "Customer_ID";
            this.Customer_ID.HeaderText = "Customer_ID";
            this.Customer_ID.Name = "Customer_ID";
            // 
            // Sale_Date
            // 
            this.Sale_Date.DataPropertyName = "Sale_Date";
            this.Sale_Date.HeaderText = "Sale_Date";
            this.Sale_Date.Name = "Sale_Date";
            // 
            // SaleItems
            // 
            this.SaleItems.DataPropertyName = "SaleItems";
            this.SaleItems.HeaderText = "SaleItems";
            this.SaleItems.Name = "SaleItems";
            // 
            // Sales_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(816, 553);
            this.MinimumSize = new System.Drawing.Size(816, 553);
            this.Name = "Sales_Report";
            this.Text = "Sales_Report";
            this.Load += new System.EventHandler(this.Sales_Report_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Button search;
        private Label label19;
        private DataGridView dataGridView1;
        private Button button1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Customer_ID;
        private DataGridViewTextBoxColumn Sale_Date;
        private DataGridViewTextBoxColumn SaleItems;
        private BindingSource saleBindingSource3;
        private BindingSource saleBindingSource;
        private BindingSource saleBindingSource1;
        private BindingSource purchaseBindingSource;
        private BindingSource saleBindingSource2;
    }
}