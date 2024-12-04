using PharmacyManagementSystem.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Repository.IRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository productRepository { get; private set; }

        public ICategoryRepository categoryRepository { get; private set; }

        public ICustomerRepository customerRepository { get; private set; }

        public ISaleRepository saleRepository { get; private set; }

        public IPurchaseRepository purchaseRepository { get; private set; }

        public IUserRepository userRepository { get; private set; }

        public ISupplierRepository supplierRepository { get; private set; }

        public IPurchaseItemRepository PurchaseItemRepository { get; private set; }

        public ISaleItemRepository saleItemRepository { get; private set; }

        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            productRepository = new ProductRepository(_db);
            categoryRepository = new CategoryRepository(_db);
            customerRepository = new CustomerRepository(_db);
            saleRepository = new SaleRepository(_db);
            purchaseRepository = new PurchaseRepository(_db);
            userRepository = new UserRepository(_db);
            supplierRepository = new SupplierRepository(_db);
            PurchaseItemRepository = new PurchaseItemRepository(_db);
            saleItemRepository = new SaleItemRepository(_db);

        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
