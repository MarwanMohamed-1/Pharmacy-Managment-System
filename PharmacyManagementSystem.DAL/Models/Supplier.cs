using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Models
{
    public class Supplier:Person
    {
        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    }
}
