using PharmacyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Repository.IRepository
{
    public interface IPurchaseItemRepository : IRepository<PurchaseItem>
    {
        void Update(PurchaseItem purchaseItem);
    }
}
