using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.DAL.DataContext;
using PharmacyManagementSystem.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PharmacyManagementSystem.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _dbContext;
        internal DbSet<T> dbset;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbset = _dbContext.Set<T>();


        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> Query = dbset;
            if(!(string.IsNullOrEmpty(includeProperties)))
            {
                foreach (var includeprop in includeProperties.Split(new char[] { ',' }
              , StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeprop);
                }

            }
            return Query.ToList();
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            if (!(string.IsNullOrEmpty(includeProperties)))
            {
                foreach (var includeprop in includeProperties.Split(new char[] { ',' }
                , StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }

            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void UpdateAll(IEnumerable<T> entities)
        {
            dbset.UpdateRange(entities);
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return dbset.Where(predicate).ToList();
        }
    }
}
