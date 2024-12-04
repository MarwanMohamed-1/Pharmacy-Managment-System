using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        IEnumerable<T> GetAll(Func<T, bool> predicate); 
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        // void Update(T entity);
        void Remove(T entity);
        void UpdateAll(IEnumerable<T> entities);
        void Add(T entity);
        

    }
}
