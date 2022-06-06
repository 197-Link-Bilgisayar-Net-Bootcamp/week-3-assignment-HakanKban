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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Id).UseIdentityColumn();
            //Veri eklenmesi
            builder.HasData( new Category { Id = 1, CategoryName = "Elektronik" },
                             new Category { Id = 2, CategoryName = "Medikal" }
                             );
        }
    }
}
