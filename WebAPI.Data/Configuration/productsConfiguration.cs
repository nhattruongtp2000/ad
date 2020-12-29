using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    class productsConfiguration : IEntityTypeConfiguration<products>
    {
        public void Configure(EntityTypeBuilder<products> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.idProduct);
            builder.Property(x => x.idProduct).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idBrand).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idCategory).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idColor).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idSize).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idType).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idProduct).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.salePrice).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.photoReview).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.detail).IsRequired().HasColumnType("nvarchar").HasMaxLength(2000);
            builder.Property(x => x.isSaling).IsRequired();
            builder.Property(x => x.dateAdded).IsRequired();

            builder.HasOne(x => x.productSize).WithMany(x => x.products).HasForeignKey(x => x.idSize);
            builder.HasOne(x => x.productTypes).WithMany(x => x.products).HasForeignKey(x => x.idType);
            builder.HasOne(x => x.productColor).WithMany(x => x.products).HasForeignKey(x => x.idColor);
            builder.HasOne(x => x.productBrand).WithMany(x => x.products).HasForeignKey(x => x.idBrand);
            builder.HasOne(x => x.productCategories).WithMany(x => x.products).HasForeignKey(x => x.idCategory);
        }
    }
}
