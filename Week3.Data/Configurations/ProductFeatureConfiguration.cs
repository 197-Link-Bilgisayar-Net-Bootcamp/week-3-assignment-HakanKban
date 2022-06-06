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
    public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            //Relational
            builder.HasOne<Product>(x => x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x => x.Id);
            // Veri Ekleme
            builder.HasData(new ProductFeature { Id = 1, Height = 800, Width = 1200 },
                            new ProductFeature { Id = 2, Height = 500, Width = 1500 },
                            new ProductFeature { Id = 3, Height = 750, Width = 1750 }
                );
        }
    }
}
