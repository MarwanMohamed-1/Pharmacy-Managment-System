using PharmacyManagementSystem.DAL.DataContext;
using PharmacyManagementSystem.DAL.Models;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Repository
{
    public class SaleItemRepository : Repository<SaleItem>, ISaleItemRepository
    {
        private ApplicationDbContext _dbContext;
        public SaleItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(SaleItem entity)
        {
            _dbContext.saleItems.Update(entity);
        }
    }
}
