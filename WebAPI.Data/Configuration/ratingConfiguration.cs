using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class ratingConfiguration : IEntityTypeConfiguration<rating>
    {
        public void Configure(EntityTypeBuilder<rating> builder)
        {
            builder.ToTable("rating");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.idUser).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idUser).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.idProduct).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.comment).IsRequired().HasColumnType("nvarchar").HasMaxLength(2000);
            builder.Property(x => x.rate).IsRequired();
            builder.Property(x => x.rateDate).IsRequired();

            builder.HasOne(x => x.users).WithMany(x => x.ratings).HasForeignKey(x => x.idUser);

            builder.HasOne(x => x.products).WithMany(x => x.ratings).HasForeignKey(x => x.idProduct);
        }
    }
}
