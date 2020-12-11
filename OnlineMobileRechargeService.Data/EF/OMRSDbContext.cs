using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineMobileRechargeService.Data.Configurations;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMobileRechargeService.Data.EF
{
    //Extend Dbcontext to create database
    public class OMRSDbContext : DbContext
    {
        public OMRSDbContext(DbContextOptions options) : base(options)
        {
        }

        public OMRSDbContext()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("OMRSDatabase"));
            }
        }

        //Override method OnModelCreating
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            

            modelBuilder.ApplyConfiguration(new CallerTuneConfiguration());
            modelBuilder.ApplyConfiguration(new ContactUsConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerCareNumberConfiguration());
            modelBuilder.ApplyConfiguration(new DNDCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DNDModeConfiguration());
            modelBuilder.ApplyConfiguration(new DNDTransactionConfiguration());

            modelBuilder.ApplyConfiguration(new FeedBackConfiguration());
            modelBuilder.ApplyConfiguration(new ModeInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new PBPTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new PlanConfiguration());

            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new GuestTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new UserInPlanConfiguration());
            modelBuilder.ApplyConfiguration(new VASConfiguration());
            modelBuilder.ApplyConfiguration(new VASInProviderConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<CallerTune> CallerTunes { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<CustomerCareNumber> CustomerCareNumbers { get; set; }
        public DbSet<DNDCategory> DNDCategories { get; set; }
        public DbSet<DNDMode> DNDModes { get; set; }
        public DbSet<DNDTransaction> DNDTransactions { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<ModeInCategory> ModeInCategories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PBPTransaction> PBPTransactions { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<GuestTransaction> GuestTransactions { get; set; }
        public DbSet<UserInPlan> UserInPlans { get; set; }
        public DbSet<VAS> VAS { get; set; }
        public DbSet<VASInProvider> VASInProviders { get; set; }

    }
}
