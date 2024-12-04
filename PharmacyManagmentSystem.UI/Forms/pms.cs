using PharmacyManagementSystem.BLL.Services;
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
using PharmacyManagementSystem.DAL.DataContext;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CrystalDecisions.ReportAppServer.Prompting;
using iTextSharp.text;

namespace PharmacyManagmentSystem.UI.Forms
{
    public partial class PMSWindow : Form
    {
        private string _userRole;

        private CustomerService _customerService;
        private SupplierService _supplierService;
        private UsersService _usersService;
        private SaleItemService saleItemService;
        private PurchaseItemService purchaseItemService;
        private PurchaseService purchaseService;
        private CategoryService categoryService;
        private ProductService productService;
        int _supplierId = 0;
        bool _showpass = true;

        Sales_Report Sales_Report;
        Purchase_Report purchase_Report;

        public PMSWindow(CustomerService customerService, SupplierService supplierService
            , UsersService usersService, SaleItemService saleItemService, PurchaseItemService purchaseItemService
            , PurchaseService purchaseService, CategoryService categoryService, ProductService productService)
        {
            InitializeComponent();
            _customerService = customerService;
            _supplierService = supplierService;
            _usersService = usersService;
            this.saleItemService = saleItemService;
            this.purchaseItemService = purchaseItemService;
            this.purchaseService = purchaseService;
            this.categoryService = categoryService;
            this.productService = productService;

            comboBox1.DataSource = null;
            comboBox1.DataSource = this.categoryService.GetAllCategories().ToList();
            //comboBox1.SelectedIndex = 0;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

        }

        //public PMSWindow()
        //{
        //    InitializeComponent();
        //    _customerService = customerService;
        //    _supplierService = supplierService;
        //    _usersService = usersService;
        //}

        //public PMSWindow(UsersService _usersService)
        //{
        //    InitializeComponent();
        //    this._usersService = _usersService;
        //}
        private void SetTabPageAccess(string tabName)
        {
            // Check if the tab exists in the TabPages collection
            if (gtcPharmacy.TabPages.ContainsKey(tabName))
            {
                gtcPharmacy.TabPages[tabName].Enabled = RoleBasedAccess.CanAccess(_userRole, tabName);
            }
            else
            {
                //MessageBox.Show($"Tab '{tabName}' does not exist in the tab control.", "Tab Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigureTabs()
        {
            // Ensure gtcPharmacy is not null
            if (gtcPharmacy == null)
            {
                MessageBox.Show("TabControl is not initialized.");
                return;
            }

            //Loop through all tab pages and configure access

            foreach (TabPage tab in gtcPharmacy.TabPages)
            {
                // Disable all tabs by default
                tab.Enabled = true;



                // Enable only the tabs that the user has access to
                if (!RoleBasedAccess.CanAccess(_userRole, tab.Name))
                {
                    //tab.Enabled = true;

                    gtcPharmacy.TabPages.Remove(tab);

                }
            }



            // Check if _userRole is set
            if (string.IsNullOrEmpty(_userRole))
            {
                MessageBox.Show("User role is not assigned.");
                return;
            }

            // Configure each tab, ensuring the tab exists
            SetTabPageAccess("salesTab");
            SetTabPageAccess("purchaseTab");
            SetTabPageAccess("customersTab");
            SetTabPageAccess("reportsTab");
            SetTabPageAccess("Stock");
            SetTabPageAccess("addNewProduct");
            SetTabPageAccess("accountTab");
            SetTabPageAccess("supplierTap");

        }

        public void Login(string username, string password)
        {
            var user = _usersService.AuthenticateUser(username, password);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials or inactive user.");
                return;
            }



            // Assign the authenticated user's role
            _userRole = user.Role;

            // Ensure _userRole is not null or empty before configuring tabs
            if (string.IsNullOrEmpty(_userRole))
            {
                MessageBox.Show("User role is not set properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Configure tab access based on the user role
            ConfigureTabs();
            this.Show();
        }



        private void gtcPharmacy_Selected(object sender, TabControlEventArgs e)
        {

            //dgvCustomer.DataSource = null;
            //dgvCustomer.DataSource = _customerService.GetAllCustomers();

            //dgvSupplier.DataSource = null;
            //dgvSupplier.DataSource = _supplierService.GetAllSuppliers();

            //dgvAccounts.DataSource = null;
            //dgvAccounts.DataSource = _usersService.GetAllUsers();

            var data = productService.GetAllProducts().ToList();
            dataGridView2.DataSource = data;

            try
            {
                // Update Customer Data Grid View
                dgvCustomer.DataSource = null;
                var customers = _customerService.GetAllCustomers();
                if (customers != null)
                {
                    dgvCustomer.DataSource = customers;
                }
                else
                {
                    MessageBox.Show("No customer data available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Update Supplier Data Grid View
                dgvSupplier.DataSource = null;
                var suppliers = _supplierService.GetAllSuppliers();
                if (suppliers != null)
                {
                    dgvSupplier.DataSource = suppliers;
                }
                else
                {
                    MessageBox.Show("No supplier data available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Update Accounts Data Grid View
                dgvAccounts.DataSource = null;
                var users = _usersService.GetAllUsers();
                if (users != null)
                {
                    dgvAccounts.DataSource = users;
                }
                else
                {
                    MessageBox.Show("No user data available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Customer
        private void btnCAdd_Click(object sender, EventArgs e)
        {
            string name = this.txtCName.Text.Trim();
            string address = this.txtCAddress.Text.Trim();
            string phoneNum = this.txtCPhone.Text.Trim();
            string email = "";
            var validationMessage = ValidateInput(name, address, phoneNum, email);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var check = _customerService.AddCustomer(this.txtCName.Text, this.txtCAddress.Text, this.txtCPhone.Text, "");
            if (check)
            {
                MessageBox.Show("Data Successfully Added");
                this.txtCAddress.Text = "";
                this.txtCName.Text = "";
                this.txtCPhone.Text = "";
                dgvCustomer.DataSource = null;
                dgvCustomer.DataSource = _customerService.GetAllCustomers();
            }
            else
            {
                MessageBox.Show("Duplicate Customer");

            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCustomer.Rows.Count)
            {
                var selectedRow = dgvCustomer.Rows[e.RowIndex].DataBoundItem as Customer;

                if (selectedRow != null)
                {
                    this.txtECID.Text = selectedRow.Id.ToString();
                    this.txtECName.Text = selectedRow.Name.ToString();
                    this.txtECAddress.Text = selectedRow.Address.ToString();
                    this.txtECPhone.Text = selectedRow.Phone_Num.ToString();
                    this.txtECName.ReadOnly = false;
                    this.txtECAddress.ReadOnly = false;
                    this.txtECPhone.ReadOnly = false;
                }
            }
        }

        private void btnCEdit_Click_1(object sender, EventArgs e)
        {
            string name = this.txtECName.Text.Trim();
            string address = this.txtECAddress.Text.Trim();
            string phoneNum = this.txtECPhone.Text.Trim();
            string email = "";

            var validationMessage = ValidateInput(name, address, phoneNum, email);

            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show("Invalid Data", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = _customerService.GetCustomerById(int.Parse(this.txtECID.Text));
            customer.Name = name;
            customer.Address = address;
            customer.Phone_Num = phoneNum;

            var check = _customerService.UpdateCustomer(customer);
            if (check)
            {
                MessageBox.Show("Customer Successfully Updated");
                this.txtECID.Text = "";
                this.txtECAddress.Text = "";
                this.txtECName.Text = "";
                this.txtECPhone.Text = "";
                this.txtECName.ReadOnly = true;
                this.txtECAddress.ReadOnly = true;
                this.txtECPhone.ReadOnly = true;
                dgvCustomer.DataSource = null;
                dgvCustomer.DataSource = _customerService.GetAllCustomers();
            }
            else
            {
                MessageBox.Show("Duplicate Customer");

            }


        }




        private void btnCRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtECID.Text))
            {
                MessageBox.Show("Invalid Data", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var check = _customerService.DeleteCustomer(int.Parse(this.txtECID.Text));
            if (check)
            {
                MessageBox.Show("Customer Successfully Deleted");
                this.txtECID.Text = "";
                this.txtECAddress.Text = "";
                this.txtECName.Text = "";
                this.txtECPhone.Text = "";
                this.txtECName.ReadOnly = true;
                this.txtECAddress.ReadOnly = true;
                this.txtECPhone.ReadOnly = true;
                dgvCustomer.DataSource = null;
                dgvCustomer.DataSource = _customerService.GetAllCustomers();
            }
            else
            {
                MessageBox.Show("Duplicate Customer");

            }
        }

        private void btnCSearch_Click(object sender, EventArgs e)
        {
            this.txtECID.Text = "";
            this.txtECAddress.Text = "";
            this.txtECName.Text = "";
            this.txtECPhone.Text = "";
            this.txtECName.ReadOnly = true;
            this.txtECAddress.ReadOnly = true;
            this.txtECPhone.ReadOnly = true;
            string searchTerm = this.txtCSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvCustomer.DataSource = null;
                dgvCustomer.DataSource = _customerService.GetAllCustomers();
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var searchResults = _customerService.SearchCustomers(searchTerm);

            dgvCustomer.DataSource = null;
            dgvCustomer.DataSource = searchResults;

            if (!searchResults.Any())
            {
                MessageBox.Show("No customers found matching the search criteria.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCSearch_TextChanged(object sender, EventArgs e)
        {
            this.txtECID.Text = "";
            this.txtECAddress.Text = "";
            this.txtECName.Text = "";
            this.txtECPhone.Text = "";
            this.txtECName.ReadOnly = true;
            this.txtECAddress.ReadOnly = true;
            this.txtECPhone.ReadOnly = true;

            string searchTerm = this.txtCSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvCustomer.DataSource = null;
                dgvCustomer.DataSource = _customerService.GetAllCustomers();
                return;
            }

            var searchResults = _customerService.SearchCustomers(searchTerm);

            dgvCustomer.DataSource = null;
            dgvCustomer.DataSource = searchResults;

            if (!searchResults.Any())
            {
            }
        }


        //Supplier
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string name = this.txtSuName.Text.Trim();
            string address = this.txtSuAddress.Text.Trim();
            string phoneNum = this.txtSuPhone.Text.Trim();
            string email = this.txtSuEmail.Text.Trim();

            var validationMessage = ValidateInput(name, address, phoneNum, email);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                MessageBox.Show(validationMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var check = _supplierService.AddSupplier(name, address, phoneNum, email);
            if (check)
            {
                MessageBox.Show("Data Successfully Added");
                this.txtCAddress.Text = "";
                this.txtCName.Text = "";
                this.txtCPhone.Text = "";
                dgvSupplier.DataSource = null;
                dgvSupplier.DataSource = _supplierService.GetAllSuppliers();
            }
            else
            {
                MessageBox.Show("Duplicate Supplier");

            }
        }

        private void btnSuEdit_Click(object sender, EventArgs e)
        {
            string name = this.txtESuName.Text.Trim();
            string address = this.txtESuAddress.Text.Trim();
            string phoneNum = this.txtESuPhone.Text.Trim();
            string email = this.txtESuEmail.Text.Trim();

            var validationMessage = ValidateInput(name, address, phoneNum, email);

            if (_supplierId == 0)
            {
                MessageBox.Show("Invalid Data", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var suppler = _supplierService.GetSupplierById(_supplierId);
            suppler.Name = name;
            suppler.Address = address;
            suppler.Phone_Num = phoneNum;
            suppler.Email = email;


            var check = _supplierService.UpdateSupplier(suppler);
            if (check)
            {
                MessageBox.Show("Suppler Successfully Updated");
                this.txtSuAddress.Text = "";
                this.txtSuEmail.Text = "";
                this.txtSuName.Text = "";
                this.txtSuPhone.Text = "";
                this.txtESuName.ReadOnly = true;
                this.txtESuAddress.ReadOnly = true;
                this.txtESuPhone.ReadOnly = true;
                this.txtESuEmail.ReadOnly = true;
                _supplierId = 0;
                dgvSupplier.DataSource = null;
                dgvSupplier.DataSource = _supplierService.GetAllSuppliers();
            }
        }
        private void salesReport_Click(object sender, EventArgs e)
        {
            Sales_Report = new Sales_Report();
            Sales_Report.ShowDialog();
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSupplier.Rows.Count)
            {
                var selectedRow = dgvSupplier.Rows[e.RowIndex].DataBoundItem as Supplier;

                if (selectedRow != null)
                {
                    _supplierId = selectedRow.Id;
                    this.txtESuEmail.Text = selectedRow.Email.ToString();
                    this.txtESuName.Text = selectedRow.Name.ToString();
                    this.txtESuAddress.Text = selectedRow.Address.ToString();
                    this.txtESuPhone.Text = selectedRow.Phone_Num.ToString();

                    this.txtESuName.ReadOnly = false;
                    this.txtESuAddress.ReadOnly = false;
                    this.txtESuPhone.ReadOnly = false;
                    this.txtESuEmail.ReadOnly = false;
                }
            }
        }

        private void btnSuRemove_Click(object sender, EventArgs e)
        {
            if (_supplierId == 0)
            {
                MessageBox.Show("Invalid Data", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var check = _supplierService.DeleteSupplier(_supplierId);
            if (check)
            {
                MessageBox.Show("Suppler Successfully Deleted");
                this.txtESuEmail.Text = "";
                this.txtESuName.Text = "";
                this.txtESuPhone.Text = "";
                this.txtESuAddress.Text = "";
                this.txtESuName.ReadOnly = true;
                this.txtESuAddress.ReadOnly = true;
                this.txtESuPhone.ReadOnly = true;
                this.txtESuEmail.ReadOnly = true;
                _supplierId = 0;
                dgvSupplier.DataSource = null;
                dgvSupplier.DataSource = _supplierService.GetAllSuppliers();
            }
        }

        private void btnSuSearch_Click(object sender, EventArgs e)
        {
            _supplierId = 0;
            this.txtESuAddress.Text = "";
            this.txtESuName.Text = "";
            this.txtESuPhone.Text = "";
            this.txtESuEmail.Text = "";
            this.txtESuName.ReadOnly = true;
            this.txtESuAddress.ReadOnly = true;
            this.txtESuPhone.ReadOnly = true;
            this.txtESuEmail.ReadOnly = true;
            string searchTerm = this.txtSuSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvSupplier.DataSource = null;
                dgvSupplier.DataSource = _supplierService.GetAllSuppliers();
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var searchResults = _supplierService.SearchSupplier(searchTerm);

            dgvSupplier.DataSource = null;
            dgvSupplier.DataSource = searchResults;

            if (!searchResults.Any())
            {
                MessageBox.Show("No suppler found matching the search criteria.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSuSearch_TextChanged(object sender, EventArgs e)
        {
            _supplierId = 0;
            this.txtESuAddress.Text = "";
            this.txtESuName.Text = "";
            this.txtESuPhone.Text = "";
            this.txtESuEmail.Text = "";
            this.txtESuName.ReadOnly = true;
            this.txtESuAddress.ReadOnly = true;
            this.txtESuPhone.ReadOnly = true;
            this.txtESuEmail.ReadOnly = true;
            string searchTerm = this.txtSuSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvSupplier.DataSource = null;
                dgvSupplier.DataSource = _supplierService.GetAllSuppliers();
                return;
            }

            var searchResults = _supplierService.SearchSupplier(searchTerm);

            dgvSupplier.DataSource = null;
            dgvSupplier.DataSource = searchResults;

            if (!searchResults.Any())
            {
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtAcUserName.Text.Trim();
                string password = txtAcPassword.Text.Trim();
                string selectedRole = itemAcRole.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string passwordPattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$";
                if (!Regex.IsMatch(password, passwordPattern))
                {
                    MessageBox.Show("Password must be at least 6 characters long, including one uppercase letter, one number, and one special character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(selectedRole))
                {
                    MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var check = _usersService.AddUser(username, password, selectedRole, true);
                if (check)
                {
                    MessageBox.Show("User successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAcUserName.Text = "";
                    txtAcPassword.Text = "";
                    itemAcRole.SelectedIndex = -1;
                    dgvAccounts.DataSource = null;
                    dgvAccounts.DataSource = _usersService.GetAllUsers();
                }
                else
                {
                    MessageBox.Show("Failed to add user. Possibly a duplicate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidateInput(string name, string address, string phoneNum, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Supplier name is required.";
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                return "Supplier address is required.";
            }
            if (string.IsNullOrWhiteSpace(phoneNum))
            {
                return "Supplier phone number is required.";
            }
            if (!long.TryParse(phoneNum, out _) || phoneNum.Length != 11)
            {
                return "Phone number must be numeric and exactly 11 digits.";
            }
            if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
            {
                return "Invalid email format.";
            }
            return string.Empty;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {
            if (_showpass)
            {
                this.txtAcPassword.UseSystemPasswordChar = false;
                this.label27.Text = "Hide";
                _showpass = false;
            }
            else
            {
                this.txtAcPassword.UseSystemPasswordChar = true;
                this.label27.Text = "Show";
                _showpass = true;
            }
        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            Landing LD = new(_usersService, _customerService, _supplierService, saleItemService
                , purchaseItemService, purchaseService, categoryService, productService);

            LD.Show();
            this.Hide();


        }

        private void purchaseReport_Click(object sender, EventArgs e)
        {
            purchase_Report = new Purchase_Report();
            purchase_Report.ShowDialog();
        }

        private void addNewProduct_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var newProduct = productService.AddProduct(textBox1.Text, textBox2.Text, " ", int.Parse(textBox4.Text), dateTimePicker1.Value, textBox3.Text, textBox5.Text, int.Parse(textBox6.Text), comboBox1.SelectedIndex);

            if (newProduct == true)
            {
                MessageBox.Show("Product Added Successfully");

                //var product = from products
                //              in _productService.GetAllProducts().ToList()
                //              select products;


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = productService.GetAllProducts();
            }
            else
            {
                MessageBox.Show("Failed to Add Product");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool res = categoryService.AddCategory(txtCategory.Text);


            if (res)
            {
                MessageBox.Show("Category added");
            }

            else
            {

            }
        }

        private void salesSearch_Click(object sender, EventArgs e)
        {
            var data = from Product in productService.GetAllProducts()
                       where Product.Name == textBox12.Text || Product.Generic_Name == textBox11.Text || Product.Company == textBox10.Text
                       select Product;


            // dataGridView3.DataSource = data.ToList();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void salesCustomerCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void salesCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var customer = _customerService.GetCustomerById(int.Parse(this.salesCustomerCode.Text));
                if (customer != null)
                {
                    comboCustomerName.Text = customer.Name;
                    customerPhone.Text = customer.Phone_Num;
                    customerAddress.Text = customer.Address;
                    salesCustomerCode.Text = customer.Id.ToString();
                }

            }
        }

        private void salesProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                var PId = productService.GetProductById(Convert.ToInt32(this.salesProductCode.Text));
                if (PId != null)
                {

                    comboPName.Text = PId.Name;
                    salesPPrice.Text = PId.price.ToString();
                    comboPForm.Text = PId.Type;
                    textsalesExpire.Text = PId.Expire_Date.ToString();
                    textsalesBalance.Text = PId.Quantity.ToString();
                }
            }
        }

        private void PQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var product = productService.GetProductById(Convert.ToInt32(salesProductCode.Text));
                if (product != null)
                {
                    DataGridViewRow row = (DataGridViewRow)DGVSales.Rows[0].Clone();
                    row.Cells[0].Value = salesProductCode.Text;
                    row.Cells[1].Value = comboPName.Text;
                    row.Cells[2].Value = salesPPrice.Text;
                    row.Cells[3].Value = PQty.Text;
                    DGVSales.Rows.Add(row);
                }


                salesProductCode.Text = "";
                comboPName.Text = "";
                salesPPrice.Text = "";
                PQty.Text = "";
                textsalesExpire.Text = "";
                textsalesBalance.Text = "";
                saveInvoice.Enabled = true;



                // bill.Sale_ID = Convert.ToInt32(sale.Id);
                //  bill.Id = Convert.ToInt32(SalesBillNo.Text);
                //saleItemService.AddSaleItem(saleID, sale);

                //if (salesTotalPrice.Text != "")
                //{
                //    int total = (int)Convert.ToDecimal(salesTotalPrice.Text);
                //    salesTotalAmount.Text = (Convert.ToInt32(salesPPrice.Text) * Convert.ToInt32(PQty.Text) + total).ToString();
                //}
                //else
                //{
                //    salesTotalAmount.Text = (Convert.ToInt32(salesPPrice.Text) * Convert.ToInt32(PQty.Text)).ToString();

                //}


                //stock
                //var prod = _AppDbContext.products.Where(x => x.Id == Convert.ToInt32(salesProductCode.Text)).FirstOrDefault();
                //prod.Quantity = prod.Quantity - Convert.ToInt32(PQty.Text);
                //_AppDbContext.products.Append(prod);
                //_AppDbContext.SaveChanges();
            }
        }

        private void PQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void purchSCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var supplier = _supplierService.GetSupplierById(int.Parse(this.purchSCode.Text));
                if (supplier != null)
                {
                    purchSCode.Text = supplier.Id.ToString();
                    purchSName.Text = supplier.Name;
                    purchSAddress.Text = supplier.Address.ToString();
                    PurchSPhone.Text = supplier.Phone_Num.ToString();
                }

            }
        }

        private void purchaseSearch_Click(object sender, EventArgs e)
        {
            var product = productService.GetProductById(Convert.ToInt32(purchPCode.Text));
            DataGridViewRow row = (DataGridViewRow)DGVpurch.Rows[0].Clone();
            row.Cells[0].Value = purchPCode.Text;
            row.Cells[1].Value = purchPName.Text;
            row.Cells[2].Value = purchPQty.Text;
            row.Cells[3].Value = purchPExpire.Text;
            DGVpurch.Rows.Add(row);
            if (product != null)
            {

            }



            //var prod 
            //    //_AppDbContext.products.Where(x => x.Name == purchPName.Text).FirstOrDefault();
            //if (prod != null)
            //{
            //    //int prodQty = Convert.ToInt32(prod.Quantity);
            //    //prod.Quantity = Convert.ToInt32(purchPQty.Text) + prodQty;
            //    //prod.Generic_Name = purchPGeneric.Text;
            //    //prod.Company = purchPCompany.Text;
            //    //prod.Type = purchPForm.Text;
            //    //prod.Expire_Date = purchPExpire.Value;
            //    //prod.Pack_Size = purchPSize.Text;


            //    MessageBox.Show("Succeccfuly added!");

            //    if (purchTotal.Text != "")
            //    {
            //        int total = Convert.ToInt32(purchTotal.Text);
            //        purchTotal.Text = (Convert.ToInt32(purchPQty.Text) + total).ToString();
            //    }
            //    else
            //    {
            //        purchTotal.Text = (Convert.ToInt32(purchPQty.Text)).ToString();
            //    }


            //}
            //else
            //{

            //    Product newProduct = new Product();
            //    newProduct.Name = purchPName.Text;
            //    newProduct.Company = purchPCompany.Text;
            //    newProduct.Type = purchPForm.Text;
            //    newProduct.Generic_Name = purchPGeneric.Text;
            //    newProduct.Quantity = Convert.ToInt32(purchPQty.Text);
            //    newProduct.Pack_Size = purchPSize.Text;

            //    //productService.AddProduct(newProduct.Name,newProduct.Generic_Name,newProduct.Type,newProduct.Expire_Date,newProduct.Company,newProduct.Pack_Size,newProduct.price,newProduct.Category)
            //   // _AppDbContext.products.Append(newProduct);

            //    if (purchTotal.Text != "")
            //    {
            //        int total = Convert.ToInt32(purchTotal.Text);
            //        purchTotal.Text = (Convert.ToInt32(purchPQty.Text) + total).ToString();
            //    }
            //    else
            //    {
            //        purchTotal.Text = (Convert.ToInt32(purchPQty.Text)).ToString();
            //    }

            //    var purchDate = DateTime.Now;
            //    purchaseService.AddPurchase(Convert.ToInt32(purchSCode.Text), purchDate);

            //    DataGridViewRow row = (DataGridViewRow)DGVpurch.Rows[0].Clone();
            //    row.Cells[0].Value = purchBillNo.Text;
            //    row.Cells[1].Value = purchPName.Text;
            //    row.Cells[2].Value = purchPQty.Text;
            //    row.Cells[3].Value = purchPExpire.Value;
            //    DGVpurch.Rows.Add(row);

            //    purchPName.Text = "";

            //    purchPCompany.Text = "";
            //    purchPForm.Text = "";
            //    purchPGeneric.Text = "";
            //    purchPQty.Text = "";
            //    purchPSize.Text = "";

        }

        private void comboCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



