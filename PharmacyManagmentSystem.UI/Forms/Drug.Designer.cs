namespace PharmacyManagmentSystem.UI.Forms
{
    partial class Drug
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
            groupBox1 = new GroupBox();
            search = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            label20 = new Label();
            label19 = new Label();
            textBox16 = new TextBox();
            textBox15 = new TextBox();
            dataGridView1 = new DataGridView();
            Barcode = new DataGridViewTextBoxColumn();
            PName = new DataGridViewTextBoxColumn();
            genericName = new DataGridViewTextBoxColumn();
            PForm = new DataGridViewTextBoxColumn();
            Units = new DataGridViewTextBoxColumn();
            Company = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            addItem = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(search);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(textBox16);
            groupBox1.Controls.Add(textBox15);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(868, 78);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search By";
            // 
            // search
            // 
            search.Location = new Point(726, 27);
            search.Name = "search";
            search.Size = new Size(110, 32);
            search.TabIndex = 15;
            search.Text = "Search";
            search.UseVisualStyleBackColor = true;
            search.Click += search_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(426, 32);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 8;
            label1.Text = "Generic Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(538, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(161, 23);
            textBox1.TabIndex = 9;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(188, 32);
            label20.Name = "label20";
            label20.Size = new Size(51, 20);
            label20.TabIndex = 4;
            label20.Text = "Name";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label19.Location = new Point(8, 32);
            label19.Name = "label19";
            label19.Size = new Size(66, 20);
            label19.TabIndex = 5;
            label19.Text = "Barcode";
            // 
            // textBox16
            // 
            textBox16.Location = new Point(245, 31);
            textBox16.Name = "textBox16";
            textBox16.Size = new Size(161, 23);
            textBox16.TabIndex = 6;
            // 
            // textBox15
            // 
            textBox15.Location = new Point(75, 31);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(97, 23);
            textBox15.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Barcode, PName, genericName, PForm, Units, Company, Price });
            dataGridView1.Location = new Point(10, 118);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(874, 358);
            dataGridView1.TabIndex = 14;
            // 
            // Barcode
            // 
            Barcode.HeaderText = "Barcode";
            Barcode.Name = "Barcode";
            // 
            // PName
            // 
            PName.HeaderText = "Name";
            PName.Name = "PName";
            PName.Width = 220;
            // 
            // genericName
            // 
            genericName.HeaderText = "Generic Name";
            genericName.Name = "genericName";
            genericName.Width = 135;
            // 
            // PForm
            // 
            PForm.HeaderText = "Form";
            PForm.Name = "PForm";
            // 
            // Units
            // 
            Units.HeaderText = "Units";
            Units.Name = "Units";
            Units.Width = 80;
            // 
            // Company
            // 
            Company.HeaderText = "Company";
            Company.Name = "Company";
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.Name = "Price";
            // 
            // addItem
            // 
            addItem.Location = new Point(360, 482);
            addItem.Name = "addItem";
            addItem.Size = new Size(122, 44);
            addItem.TabIndex = 15;
            addItem.Text = "Add Item";
            addItem.UseVisualStyleBackColor = true;
            // 
            // Drug
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 538);
            Controls.Add(addItem);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            MaximumSize = new Size(908, 577);
            MinimumSize = new Size(908, 577);
            Name = "Drug";
            Text = "Drug";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBox1;
        private Label label20;
        private Label label19;
        private TextBox textBox16;
        private TextBox textBox15;
        private Button search;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Barcode;
        private DataGridViewTextBoxColumn PName;
        private DataGridViewTextBoxColumn genericName;
        private DataGridViewTextBoxColumn PForm;
        private DataGridViewTextBoxColumn Units;
        private DataGridViewTextBoxColumn Company;
        private DataGridViewTextBoxColumn Price;
        private Button addItem;
    }
}