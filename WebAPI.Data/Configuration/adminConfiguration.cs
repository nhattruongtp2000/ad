using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class adminConfiguration : IEntityTypeConfiguration<admin>
    {
        public void Configure(EntityTypeBuilder<admin> builder)
        {
            builder.ToTable("admin ");
            builder.HasKey(x => x.idAdmin);
            builder.Property(x=>x.idAdmin).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.email).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.password).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
        }
    }
}
