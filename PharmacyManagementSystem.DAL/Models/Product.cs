using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  PharmacyManagementSystem.DAL.Models

{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string Generic_Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime Expire_Date { get; set; }

        public string Company { get; set; }
        public string Pack_Size { get; set; }

        public decimal price { get; set; }

        [ForeignKey("Category")]
        public int Category_ID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    }
}
