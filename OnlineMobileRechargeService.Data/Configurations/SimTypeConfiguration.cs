using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class SimTypeConfiguration : IEntityTypeConfiguration<SimType>
    {
        public void Configure(EntityTypeBuilder<SimType> builder)
        {
            builder.ToTable("SimTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();

        }
    }
}
