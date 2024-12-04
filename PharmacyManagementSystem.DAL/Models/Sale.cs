using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  PharmacyManagementSystem.DAL.Models

{
    public class Sale
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int Customer_ID { get; set; }
        public virtual Customer Customer { get; set; }

        public DateTime Sale_Date { get; set; }

        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
