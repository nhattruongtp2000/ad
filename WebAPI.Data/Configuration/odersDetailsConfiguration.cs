
using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class odersDetailsConfiguration : IEntityTypeConfiguration<odersDetails>
    {
        public void Configure(EntityTypeBuilder<odersDetails> builder)
        {
            builder.ToTable("odersDetails");

            builder.HasKey(x => x.idOder);
            builder.Property(x => x.idOder).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.date).IsRequired();
            builder.Property(x=>x.idVoucher).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.status).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.totalPrice).IsRequired();
            
        }
    }
}
