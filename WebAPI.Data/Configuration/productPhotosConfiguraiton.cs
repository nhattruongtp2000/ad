using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class productPhotosConfiguraiton : IEntityTypeConfiguration<productPhotos>
    {
        public void Configure(EntityTypeBuilder<productPhotos> builder)
        {
            builder.ToTable("productPhotos");
            builder.HasKey(x => x.IdPhoto);
            builder.Property(x=>x.idProduct).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x=>x.link).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.uploadedTime).IsRequired();

            builder.HasOne(x => x.products).WithMany(x => x.productPhotos).HasForeignKey(x => x.idProduct);
        }
    }
}
