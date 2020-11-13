using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class DNDCategoryConfiguration : IEntityTypeConfiguration<DNDCategory>
    {
        public void Configure(EntityTypeBuilder<DNDCategory> builder)
        {
            builder.ToTable("DNDCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Status).IsRequired().HasDefaultValue("Active");

        }
    }
}
