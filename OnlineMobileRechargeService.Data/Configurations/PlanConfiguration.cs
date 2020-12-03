using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
   public  class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable("Plans");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Validate).IsRequired();


            //Lien ket khoa ngoai 1-n
            builder.HasOne(x => x.Provider).WithMany(x => x.Plans).HasForeignKey(x => x.ProviderId);
            builder.HasOne(x => x.VAS).WithMany(x => x.Plans).HasForeignKey(x => x.VASId);

        }
    }
}
