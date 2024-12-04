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
    public partial class Landing : Form
    {
        private readonly UsersService _userService;
        private readonly CustomerService _customerService;
        private readonly SupplierService _supplierService;
        private readonly SaleItemService saleItemService;
        private readonly PurchaseItemService purchaseItemService;
        private readonly PurchaseService purchaseService;
        private readonly CategoryService categoryService;
        private readonly ProductService productService;


        public Landing()
        {

        }
        public Landing(UsersService userservice , CustomerService customerService , SupplierService supplierservice //, SaleItemService saleItemService, PurchaseItemService purchaseItemService
, SaleItemService saleItemService, PurchaseItemService purchaseItemService, PurchaseService purchaseService, CategoryService categoryService, ProductService productService)
        {
            InitializeComponent();
            this._userService = userservice;
            this._customerService= customerService;
            this._supplierService = supplierservice;
            this.saleItemService = saleItemService;
            this.purchaseItemService = purchaseItemService;
            this.purchaseService = purchaseService;
            this.categoryService = categoryService;
            this.productService = productService;
        }

       

        private void login_Click_1(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            var mainForm = new PMSWindow(_customerService, _supplierService, _userService , saleItemService , purchaseItemService , purchaseService
                  ,categoryService , productService);

            mainForm.Login(username, password);

            if (mainForm.Visible)
            {
                this.Hide();
            }
        }
    }
}
