
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
            builder.Property(x => x.idProduct).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.totalPrice).IsRequired();

            builder.HasOne(x => x.odersLists).WithMany(x => x.odersDetails).HasForeignKey(x => x.idOrderList);
            builder.HasOne(x => x.Products).WithMany(x => x.odersDetails).HasForeignKey(x => x.idProduct);

        }
    }
}
