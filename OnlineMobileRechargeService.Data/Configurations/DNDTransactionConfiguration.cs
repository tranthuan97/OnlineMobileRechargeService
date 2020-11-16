using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    class DNDTransactionConfiguration : IEntityTypeConfiguration<DNDTransaction>
    {
        public void Configure(EntityTypeBuilder<DNDTransaction> builder)
        {
            builder.ToTable("DNDTransactions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasOne(x => x.DNDCategory).WithMany(x => x.DNDTransactions).HasForeignKey(x => x.DNDCategoryId);
            builder.HasOne(x => x.DNDMode).WithMany(x => x.DNDTransactions).HasForeignKey(x => x.DNDModeId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.DNDTransactions).HasForeignKey(x => x.UserId);
        }
    }
}
