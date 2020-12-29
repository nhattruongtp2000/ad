
using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    class productBrandConfiguration : IEntityTypeConfiguration<productBrand>
    {
        public void Configure(EntityTypeBuilder<productBrand> builder)
        {
            builder.ToTable("productBrand");

            builder.HasKey(x => x.idBrand);
            builder.Property(x => x.idBrand).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.brandName).IsRequired();
            builder.Property(x => x.brandDetail).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
        }
    }
}
