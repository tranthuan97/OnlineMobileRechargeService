using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class GuestTransactionConfiguration : IEntityTypeConfiguration<GuestTransaction>
    {
        public void Configure(EntityTypeBuilder<GuestTransaction> builder)
        {
            builder.ToTable("GuestTransactions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.Plan).WithMany(x => x.GuestTransactions).HasForeignKey(x => x.PlanId);
        }
    }
}