using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class VASInProviderConfiguration : IEntityTypeConfiguration<VASInProvider>
    {
        public void Configure(EntityTypeBuilder<VASInProvider> builder)
        {
            builder.ToTable("VASInProviders");
            builder.HasKey(x => new { x.VASId, x.ProviderId });

            builder.HasOne(x => x.VAS).WithMany(x => x.VASInProviders).HasForeignKey(x => x.VASId);
            builder.HasOne(x => x.Provider).WithMany(x => x.VASInProviders).HasForeignKey(x => x.ProviderId);
        }
    }
}
