using WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Configuration
{
    public class usersConfiguration : IEntityTypeConfiguration<users>
    {
        public void Configure(EntityTypeBuilder<users> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.idUser);
            builder.Property(x => x.idUser).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            //builder.Property(x => x.email).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            //builder.HasIndex(x => x.email).IsUnique();
            //builder.Property(x => x.password).IsRequired().HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.firstName).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(x => x.lastName).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            //builder.Property(x => x.phoneNumber).HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(x => x.birthday).IsRequired();
            builder.Property(x => x.avatar).HasColumnType("VARCHAR").HasMaxLength(200);

            builder.Property(x => x.address).HasColumnType("nvarchar").HasMaxLength(400);
            builder.Property(x => x.note).IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
            builder.Property(x => x.province).HasColumnType("nvarchar").HasMaxLength(200);

            builder.Property(x => x.interestedIn).IsRequired().HasColumnType("nvarchar").HasMaxLength(1000);
            builder.Property(x => x.note).HasColumnType("nvarchar").HasMaxLength(1000);


        }
    }
}
