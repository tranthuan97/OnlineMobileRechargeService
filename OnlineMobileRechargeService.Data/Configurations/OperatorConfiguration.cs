using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class OperatorConfiguration : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.ToTable("Operators");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();



        }
    }
}
