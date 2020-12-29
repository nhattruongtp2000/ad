using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class productSizeConfiguration : IEntityTypeConfiguration<productSize>
    {
        public void Configure(EntityTypeBuilder<productSize> builder)
        {
            builder.ToTable("productSize");

            builder.HasKey(x => x.idSize);
            builder.Property(x => x.idSize).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.sizeName).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
        }
    }
}
