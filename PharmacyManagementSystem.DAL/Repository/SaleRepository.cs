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
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private ApplicationDbContext _dbContext;
        public SaleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Sale> GetSalesBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Sales.Where(s => s.Sale_Date >= startDate && s.Sale_Date <= endDate).ToList();
        }

        public void Update(Sale entity)
        {
           _dbContext.Sales.Update(entity);
        }
    }
}
