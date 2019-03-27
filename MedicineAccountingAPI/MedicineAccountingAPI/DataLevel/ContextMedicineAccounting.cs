using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicineAccountingAPI.DataLevel
{
    public class ContextMedicineAccounting:DbContext
    {
        public ContextMedicineAccounting(DbContextOptions<ContextMedicineAccounting> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        
    }
}
