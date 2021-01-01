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

            builder.Property(x => x.idVoucher).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idUser).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.date).IsRequired();

            builder.HasOne(x => x.users).WithMany(x => x.odersLists).HasForeignKey(x => x.idUser);
        }
    }
}
