using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.DataContext;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {

        private ApplicationDbContext _dbContext;
        public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Supplier supplier)
        {
            _dbContext.Suppliers.Update(supplier);
        }
    }
}
