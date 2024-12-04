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
    public class PurchaseItemRepository : Repository<PurchaseItem>, IPurchaseItemRepository
    {
        private ApplicationDbContext _dbContext;

        public PurchaseItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(PurchaseItem purchaseItem)
        {
            //_dbContext.PurchaseItems.Update(purchaseItem);
        }
    }
}
