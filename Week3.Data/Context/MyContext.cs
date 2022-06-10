using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Models;

namespace Week3.Data.Context
{
    public class MyContext : DbContext
    {


        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public MyContext()
        {
        }

        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<ProductFeature> ProductFeatures { get; set; }

        public DbSet<FullProduct> fullProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration ayarlarını yaptığımız assembly'i işaret ettik.Böylece newlemeden tanımladık.
            // Aynı assembly içinde olduğumuz için GetExecuting metodunu kullandık.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<FullProduct>().HasNoKey();
        }
    }
}
