using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class UserInPlanConfiguration : IEntityTypeConfiguration<UserInPlan>
    {
        public void Configure(EntityTypeBuilder<UserInPlan> builder)
        {
            builder.ToTable("UserInPlans");
            builder.HasKey(x => new { x.UserId, x.PlanId });

            builder.HasOne(x => x.AppUser).WithMany(x => x.UserInPlans).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Plan).WithMany(x => x.UserInPlans).HasForeignKey(x => x.PlanId);


        }
    }
}