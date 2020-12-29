using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class productTypesConfiguration : IEntityTypeConfiguration<productTypes>
    {
        public void Configure(EntityTypeBuilder<productTypes> builder)
        {
            builder.ToTable("productTypes");

            builder.HasKey(x => x.idType);
            builder.Property(x => x.idType).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.typeName).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
        }
    }
}
