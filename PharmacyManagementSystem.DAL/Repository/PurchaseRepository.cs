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
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        private ApplicationDbContext _dbContext;
        public PurchaseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Purchase purchase)
        {
           _dbContext.Purchases.Update(purchase);
        }
    }
}
