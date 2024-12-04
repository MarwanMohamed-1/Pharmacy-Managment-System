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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        private ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Customer customer)
        {
            _dbContext.Customers.Update(customer);
        }
    }
}
