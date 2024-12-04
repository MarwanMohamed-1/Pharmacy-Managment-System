using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository productRepository { get; }
        ICategoryRepository categoryRepository { get; }
        ICustomerRepository customerRepository { get; }
        ISaleRepository saleRepository { get; }
        IPurchaseRepository purchaseRepository { get; }
        IUserRepository userRepository { get; }
        ISupplierRepository supplierRepository { get; }
        IPurchaseItemRepository PurchaseItemRepository { get; }
        ISaleItemRepository saleItemRepository { get; }
        void Save();
    }
}
