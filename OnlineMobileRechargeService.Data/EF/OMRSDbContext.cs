using Microsoft.EntityFrameworkCore;
using OnlineMobileRechargeService.Data.Configurations;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.EF
{
    //Extend Dbcontext to create database
    class OMRSDbContext : DbContext
    {
        public OMRSDbContext(DbContextOptions options) : base(options)
        {
        }

        //Override method OnModelCreating
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new DNDCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DNDModeConfiguration());
            modelBuilder.ApplyConfiguration(new ModeInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OperatorConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<DNDCategory> DNDCategories { get; set; }
        public DbSet<DNDMode> DNDModes { get; set; }
        public DbSet<ModeInCategory> ModeInCategories { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
