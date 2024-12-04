using Guna.UI2.WinForms.Suite;
using PharmacyManagementSystem.BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagmentSystem.UI.Forms
{
    public partial class Sales_Report : Form
    {

        private readonly SaleService _saleService;
        public Sales_Report()
        {
            InitializeComponent();
            _saleService = new SaleService();

        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get date range from the user interface (e.g., DateTimePickers)
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                // Define the file path for the generated PDF
                string filePath = "SalesReport.pdf";
                // Generate the PDF report
                _saleService.GenerateSalesReportPdf(startDate, endDate, filePath);

                // Optional: Print the generated PDF
                _saleService.PrintPdf(filePath);

                MessageBox.Show("Sales report generated and sent to the printer.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Sales_Report_Load(object sender, EventArgs e)
        {
           // dataGridView1.DataSource = _saleService.GetAllSales().ToList();
        }
    }
}
