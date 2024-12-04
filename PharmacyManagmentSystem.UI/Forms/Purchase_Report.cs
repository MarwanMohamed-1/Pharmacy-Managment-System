using PharmacyManagementSystem.BLL.Services;
using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository.IRepository;
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
    public partial class Purchase_Report : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        public Purchase_Report(IUnitOfWork unitOfWork)
        {
             InitializeComponent();
            _unitOfWork = unitOfWork;
        }
        public Purchase_Report()
        {
            InitializeComponent();

        }
        private void Submit_Click(object sender, EventArgs e)
        {
            var purchasesReport = (from purchase in _unitOfWork.purchaseRepository.GetAll()
                                   join supplier in _unitOfWork.supplierRepository.GetAll() on purchase.Supplier_ID equals supplier.Id
                                   join purchaseItem in _unitOfWork.PurchaseItemRepository.GetAll() on purchase.Id equals purchaseItem.Purchase_ID
                                   join product in _unitOfWork.productRepository.GetAll() on purchaseItem.Product_ID equals product.Id
                                   where (purchase.Purchase_Date > dateTimePicker1.Value && purchase.Purchase_Date < dateTimePicker1.Value)
                                         || purchase.Purchase_Date == dateTimePicker2.Value
                                   select new
                                   {
                                       SupplierId = supplier.Id,
                                       SupplierName = supplier.Name,
                                       SupplierAddress = supplier.Address,
                                       SupplierPhone = supplier.Phone_Num,
                                       SupplierEmail = supplier.Email,
                                       PurchaseId = purchase.Id,
                                       PurchaseDate = purchase.Purchase_Date,
                                       ProductId = product.Id,
                                       ProductName = product.Name,
                                       GenericName = product.Generic_Name,
                                       ProductType = product.Type,
                                       Quantity = purchaseItem.Quantity,
                                       Price = product.price,
                                       TotalPrice = purchaseItem.Quantity * product.price
                                   }).ToList();

            dataGridView2.DataSource = purchasesReport;
        }

        private void purchaseBindingSource3_CurrentChanged(object sender, EventArgs e)
        {

        }
    }    
    
    
 }

    

