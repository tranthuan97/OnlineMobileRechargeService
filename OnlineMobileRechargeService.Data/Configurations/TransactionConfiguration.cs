using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Price).IsRequired().HasDefaultValue("0");
            builder.Property(x => x.PaymentCard).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.AppUser).WithMany(x => x.Transactions).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Provider).WithMany(x => x.Transactions).HasForeignKey(x => x.ProviderId);
            builder.HasOne(x => x.VAS).WithMany(x => x.Transactions).HasForeignKey(x => x.VASId);
        }
    }
}