using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Models
{
    public class SaleItem
    {
        public int Id { get; set; }

        [ForeignKey("Sale")]
        public int Sale_ID { get; set; }
        public virtual Sale Sale { get; set; }

        [ForeignKey("Product")]
        public int Product_ID { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal Sale_Price { get; set; }

        [NotMapped]
        public decimal Total => Quantity * Sale_Price;
    }
}
