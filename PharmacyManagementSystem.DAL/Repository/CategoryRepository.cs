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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }
    }
}
