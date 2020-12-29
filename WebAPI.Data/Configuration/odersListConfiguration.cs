using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class odersListConfiguration : IEntityTypeConfiguration<odersList>
    {
        public void Configure(EntityTypeBuilder<odersList> builder)
        {
            builder.ToTable("odersList");

            builder.HasKey(x => x.idOrderList);
            builder.Property(x => x.idOrder).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idUser).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200); 
            builder.Property(x => x.idProduct).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);

            builder.HasOne(x => x.users).WithMany(x => x.odersLists).HasForeignKey(x => x.idUser);
            builder.HasOne(x => x.Products).WithMany(x => x.odersLists).HasForeignKey(x => x.idProduct);
            builder.HasOne(x => x.odersDetails).WithMany(x => x.odersLists).HasForeignKey(x => x.idOrder);
        }
    }
}
