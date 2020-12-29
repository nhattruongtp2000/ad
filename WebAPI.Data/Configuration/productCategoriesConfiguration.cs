using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class productCategoriesConfiguration : IEntityTypeConfiguration<productCategories>
    {
        public void Configure(EntityTypeBuilder<productCategories> builder)
        {
            builder.ToTable("productCategory");

            builder.HasKey(x=>x.idCategory);
            builder.Property(x => x.idCategory).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.categoryName).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
        }
    }
}
