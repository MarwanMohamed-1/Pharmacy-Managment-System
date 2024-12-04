using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }

        [ForeignKey("Purchase")]
        public int Purchase_ID { get; set; }
        public virtual Purchase Purchase { get; set; }

        [ForeignKey("Product")]
        public int Product_ID { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal Purchase_Price { get; set; }

        [NotMapped]
        public decimal Total => Quantity * Purchase_Price;
    }
}
