using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Models;

namespace Week3.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).IsRequired();
            builder.ToTable("Products");
            //Relational
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            //Veri eklenmesi
            builder.HasData(new Product { Id = 1, Name = "Laptop", CategoryId = 1, Price = 50 },
                             new Product { Id = 2, Name = "Telefom", CategoryId = 1, Price = 35, },
                             new Product { Id = 3, Name = "Steteskop", CategoryId = 2, Price = 50, }
            );
        }
    }
}
