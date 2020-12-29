using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebAPI.Data.EF;

namespace eShopSolution.Data.EF
{
    public class WebApiDbContextFactory : IDesignTimeDbContextFactory<WebApiDbContext>
    {
        public WebApiDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("WebAPI");

            var optionsBuilder = new DbContextOptionsBuilder<WebApiDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new WebApiDbContext(optionsBuilder.Options);
        }
    }
}
