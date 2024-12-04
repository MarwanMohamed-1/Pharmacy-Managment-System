namespace PharmacyManagmentSystem.UI.Forms
{
    partial class ShortageReport
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
            dataGridView4 = new DataGridView();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            expire = new DataGridViewTextBoxColumn();
            button1 = new Button();
            groupBox1 = new GroupBox();
            search = new Button();
            label20 = new Label();
            label19 = new Label();
            textBox16 = new TextBox();
            textBox15 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, expire });
            dataGridView4.Location = new Point(11, 95);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new Size(688, 363);
            dataGridView4.TabIndex = 5;
            dataGridView4.CellContentClick += dataGridView4_CellContentClick;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Name";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Width = 400;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Quantity";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Width = 80;
            // 
            // expire
            // 
            expire.HeaderText = "Expire";
            expire.Name = "expire";
            expire.Width = 165;
            // 
            // button1
            // 
            button1.Location = new Point(311, 464);
            button1.Name = "button1";
            button1.Size = new Size(92, 34);
            button1.TabIndex = 6;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(search);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(textBox16);
            groupBox1.Controls.Add(textBox15);
            groupBox1.Location = new Point(11, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(688, 78);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search By";
            // 
            // search
            // 
            search.Location = new Point(571, 27);
            search.Name = "search";
            search.Size = new Size(110, 32);
            search.TabIndex = 15;
            search.Text = "Search";
            search.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label20.Location = new Point(188, 32);
            label20.Name = "label20";
            label20.Size = new Size(51, 20);
            label20.TabIndex = 4;
            label20.Text = "Name";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
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
            // ShortageReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 505);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView4);
            MaximumSize = new Size(721, 544);
            MinimumSize = new Size(721, 544);
            Name = "ShortageReport";
            Text = "ShortageReport";
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn expire;
        private Button button1;
        private GroupBox groupBox1;
        private Button search;
        private Label label20;
        private Label label19;
        private TextBox textBox16;
        private TextBox textBox15;
    }
}