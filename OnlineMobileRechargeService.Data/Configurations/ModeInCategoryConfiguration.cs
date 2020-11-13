using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class ModeInCategoryConfiguration : IEntityTypeConfiguration<ModeInCategory>
    {
        public void Configure(EntityTypeBuilder<ModeInCategory> builder)
        {
            builder.ToTable("ModeInCategories");
            builder.HasKey(x => new { x.CategoryId, x.ModeId});

            builder.HasOne(x => x.DNDCategory).WithMany(x => x.ModeInCategories).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.DNDMode).WithMany(x => x.ModeInCategories).HasForeignKey(x => x.ModeId);
        }
    }
}
