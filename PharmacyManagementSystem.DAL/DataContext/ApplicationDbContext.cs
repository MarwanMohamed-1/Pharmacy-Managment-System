using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.DataContext
{
    public class ApplicationDbContext:DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=PharmacyManagementDb;Integrated Security=True ;TrustServerCertificate=True");
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<PurchaseItem> purchaseItems { get; set; }
        public DbSet<SaleItem> saleItems { get; set; }


    }
}
