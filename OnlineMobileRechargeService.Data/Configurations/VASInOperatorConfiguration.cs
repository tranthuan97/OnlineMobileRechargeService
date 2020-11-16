using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class VASInOperatorConfiguration : IEntityTypeConfiguration<VASInOperator>
    {
        public void Configure(EntityTypeBuilder<VASInOperator> builder)
        {
            builder.ToTable("VASInOperators");
            builder.HasKey(x => new { x.VASId, x.OperatorId });

            builder.HasOne(x => x.VAS).WithMany(x => x.VASInOperators).HasForeignKey(x => x.VASId);
            builder.HasOne(x => x.Operator).WithMany(x => x.VASInOperators).HasForeignKey(x => x.VASId);
        }
    }
}
