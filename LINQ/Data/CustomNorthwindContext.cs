using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LINQ.Program;

namespace LINQ.Data
{
    public class CustomNorthwindContext:NorthwindContext
    {

        public DbSet<ProductModel> ProductModels { get; set; }

        public CustomNorthwindContext()
        {
        }
        public CustomNorthwindContext(DbContextOptions<NorthwindContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {     
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductModel>(a => a.HasNoKey());
        }

    }
}
