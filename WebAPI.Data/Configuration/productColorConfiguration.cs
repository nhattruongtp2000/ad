using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class productColorConfiguration : IEntityTypeConfiguration<productColor>
    {
        public void Configure(EntityTypeBuilder<productColor> builder)
        {
            builder.ToTable("productColor");

            builder.HasKey(x => x.idColor);
            builder.Property(x => x.idColor).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.colorName).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
        }
    }
}
