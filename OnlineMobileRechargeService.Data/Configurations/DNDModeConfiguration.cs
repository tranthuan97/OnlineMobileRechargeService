using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class DNDModeConfiguration : IEntityTypeConfiguration<DNDMode>
    {
        public void Configure(EntityTypeBuilder<DNDMode> builder)
        {
            builder.ToTable("DNDModes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Status).IsRequired().HasDefaultValue("Active");

        }
    }
}
