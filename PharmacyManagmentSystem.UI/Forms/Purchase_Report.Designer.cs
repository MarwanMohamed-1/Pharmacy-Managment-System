namespace PharmacyManagmentSystem.UI.Forms
{
    partial class Purchase_Report
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
            this.Submit = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.purchaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.purchaseBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseItemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchaseBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.purchaseBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Submit);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Location = new System.Drawing.Point(2, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 94);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(386, 35);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker2.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(122, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(341, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "To";
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(644, 35);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(110, 32);
            this.Submit.TabIndex = 15;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(6, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 20);
            this.label19.TabIndex = 5;
            this.label19.Text = "Purchase Form";
            // 
            // purchaseBindingSource
            // 
            this.purchaseBindingSource.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Purchase);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.purchaseItemsDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.purchaseBindingSource3;
            this.dataGridView2.Location = new System.Drawing.Point(8, 248);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(781, 190);
            this.dataGridView2.TabIndex = 6;
            // 
            // purchaseBindingSource1
            // 
            this.purchaseBindingSource1.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Purchase);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // purchaseItemsDataGridViewTextBoxColumn
            // 
            this.purchaseItemsDataGridViewTextBoxColumn.DataPropertyName = "PurchaseItems";
            this.purchaseItemsDataGridViewTextBoxColumn.HeaderText = "PurchaseItems";
            this.purchaseItemsDataGridViewTextBoxColumn.Name = "purchaseItemsDataGridViewTextBoxColumn";
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Product);
            // 
            // purchaseBindingSource2
            // 
            this.purchaseBindingSource2.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Purchase);
            // 
            // purchaseBindingSource3
            // 
            this.purchaseBindingSource3.DataSource = typeof(PharmacyManagementSystem.DAL.Models.Purchase);
            this.purchaseBindingSource3.CurrentChanged += new System.EventHandler(this.purchaseBindingSource3_CurrentChanged);
            // 
            // Purchase_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Purchase_Report";
            this.Text = "Purchase_Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseBindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn invoiceNo;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn customer;
        private DataGridViewTextBoxColumn items;
        private DataGridViewTextBoxColumn discount;
        private DataGridViewTextBoxColumn totalPrice;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Button Submit;
        private Label label19;
        private BindingSource purchaseBindingSource;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn purchaseItemsDataGridViewTextBoxColumn;
        private BindingSource purchaseBindingSource2;
        private BindingSource purchaseBindingSource1;
        private BindingSource productBindingSource;
        private BindingSource purchaseBindingSource3;
    }
}