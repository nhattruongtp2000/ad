using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Configuration;
using WebAPI.Data.Entities;
using WebAPI.Data.Extensions;

namespace WebAPI.Data.EF
{
    public class WebApiDbContext:IdentityDbContext<users,role,string>
    {
        public WebApiDbContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config

            
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasNoKey();

            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();

            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");

            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new adminConfiguration());

            modelBuilder.ApplyConfiguration(new odersDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new odersListConfiguration());
            modelBuilder.ApplyConfiguration(new productBrandConfiguration());
            modelBuilder.ApplyConfiguration(new productCategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new productColorConfiguration());

            modelBuilder.ApplyConfiguration(new productPhotosConfiguraiton());
            modelBuilder.ApplyConfiguration(new productsConfiguration());
            modelBuilder.ApplyConfiguration(new productSizeConfiguration());
            modelBuilder.ApplyConfiguration(new productTypesConfiguration());
            modelBuilder.ApplyConfiguration(new ratingConfiguration());
            modelBuilder.ApplyConfiguration(new usersConfiguration());
            modelBuilder.ApplyConfiguration(new vouchersConfiguration());


            //Data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);


        }

        public DbSet<products> products { get; set; }
        public DbSet<productCategories> productCategories { get; set; }

        public DbSet<admin> admin { get; set; }


        public DbSet<odersDetails> odersDetails { get; set; }

        public DbSet<odersList> odersList { get; set; }
        public DbSet<productBrand> productBrand { get; set; }

        public DbSet<productColor> productColor { get; set; }

        public DbSet<productPhotos> productPhotos { get; set; }

        public DbSet<productSize> productSize { get; set; }

        public DbSet<productTypes> productTypes { get; set; }
        public DbSet<role> role { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<vouchers> vouchers { get; set; }


    }
}
