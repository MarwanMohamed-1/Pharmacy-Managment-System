using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Models
{
    public class Customer:Person
    {
        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
