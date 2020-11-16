using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class PBPTransactionConfiguration : IEntityTypeConfiguration<PBPTransaction>
    {
        public void Configure(EntityTypeBuilder<PBPTransaction> builder)
        {
            builder.ToTable("PBPTransactions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Price).IsRequired();


        }
    }
}