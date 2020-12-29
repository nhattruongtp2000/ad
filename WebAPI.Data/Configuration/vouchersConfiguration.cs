using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebAPI.Data.Configuration
{
    public class vouchersConfiguration : IEntityTypeConfiguration<vouchers>
    {
        public void Configure(EntityTypeBuilder<vouchers> builder)
        {

            builder.ToTable("vouchers");

            builder.HasKey(x => x.idVoucher);
            builder.Property(x => x.idVoucher).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.price).IsRequired();
            builder.Property(x => x.expiredDate).IsRequired();
            builder.Property(x => x.isUse).HasDefaultValue(0);
        }
    }
}
