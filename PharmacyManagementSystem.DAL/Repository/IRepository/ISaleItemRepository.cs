using PharmacyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Repository.IRepository
{
    public interface ISaleItemRepository : IRepository<SaleItem>
    {
        void Update(SaleItem entity);

    }
}
