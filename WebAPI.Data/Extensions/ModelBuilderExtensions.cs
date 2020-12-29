using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Entities;
using WebAPI.Data.Enums;

namespace WebAPI.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<productSize>().HasData(
                new productSize() { idSize = "L", sizeName = "L-(Chest 101-106cm)" },
                new productSize() { idSize = "M", sizeName = "M-(Chest 96-101cm)" },
                new productSize() { idSize = "S", sizeName = "S-(Chest 91-96cm)" },
                new productSize() { idSize = "XL", sizeName = "XL-(Chest 106-111cm)" }
                );
            modelBuilder.Entity<productTypes>().HasData(
                new productTypes() { idType = "BagsNPurses", typeName = "Bags & Purses" },
                new productTypes() { idType = "MEN", typeName = "Men Products" },
                new productTypes() { idType = "WOMEN", typeName = "Women Products" }
                );


            var roleId = new string("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new string("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            

            var hasher = new PasswordHasher<users>();
            modelBuilder.Entity<users>().HasData(new users
            {
                idUser="2",
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nhattruongtp2000@gmail.com",
                NormalizedEmail = "nhattruongtp2000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                birthday = new DateTime(2020, 10, 12),
                firstName = "Nguyen",
                lastName = "Truong",
                lastLogin = new DateTime(2020, 11, 13),
                interestedIn="asd",
                address="asd",
                avatar="asd",
                note="asd",
                province="asd"
            });


            
        }



        // any guid






    }
}
