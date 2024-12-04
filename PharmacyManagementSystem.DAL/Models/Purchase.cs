using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Models

{
    public class Purchase
    {
        public int Id { get; set; }

        [ForeignKey("Supplier")]
        public int Supplier_ID { get; set; }
        public virtual Supplier Supplier { get; set; }

        public DateTime Purchase_Date { get; set; }

        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();


    }
}
