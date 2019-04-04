using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicineAccountingAPI.DataLevel
{
    public class ContextMedicineAccounting: DbContext
    {
        public ContextMedicineAccounting(DbContextOptions<ContextMedicineAccounting> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product { Id=1, Name="Citramon", Amount = 20, Price =10},
                    new Product { Id=2, Name="Nimessil", Amount = 50, Price =11.50},
                    new Product { Id=3, Name="Nurofen", Amount = 20, Price = 50}
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
