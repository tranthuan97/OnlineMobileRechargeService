using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineMobileRechargeService.Data.EF
{
    class OMRSDbContextFactory : IDesignTimeDbContextFactory<OMRSDbContext>
    {
        public OMRSDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var connectionString = configuration.GetConnectionString("OMRSDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<OMRSDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new OMRSDbContext(optionsBuilder.Options);
        }
    }
}
