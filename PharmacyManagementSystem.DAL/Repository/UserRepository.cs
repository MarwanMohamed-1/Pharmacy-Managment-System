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
    public class UserRepository : Repository<Users>, IUserRepository
    {
        private ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Users user)
        {
            _dbContext.Users.Update(user);
        }
    }
}
