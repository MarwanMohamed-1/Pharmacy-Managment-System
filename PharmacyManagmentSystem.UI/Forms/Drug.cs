using PharmacyManagementSystem.BLL.Services;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using PharmacyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PharmacyManagmentSystem.UI.Forms
{
    public partial class Drug : Form
    {

        private readonly ProductService _productService;

        public Drug(ProductService productService )
        {
            InitializeComponent();
            _productService = productService;
        }

        private void search_Click(object sender, EventArgs e)
        {
            string barcode = textBox15.Text.Trim();
            string name = textBox16.Text.Trim();
            string genericName = textBox1.Text.Trim();

            var products = _productService.GetAllProducts(); 

            if (!string.IsNullOrEmpty(barcode))
            {
                products = products.Where(p => p.Id.ToString().Contains(barcode)).ToList();
            }

            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name.Contains(name)).ToList();
            }

            if (!string.IsNullOrEmpty(genericName))
            {
                products = products.Where(p => p.Generic_Name.Contains(genericName)).ToList();
            }

            dataGridView1.DataSource = products;
        }
    
    }
}
