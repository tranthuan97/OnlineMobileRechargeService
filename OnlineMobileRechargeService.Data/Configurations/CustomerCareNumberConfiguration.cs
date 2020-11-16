using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class CustomerCareNumberConfiguration : IEntityTypeConfiguration<CustomerCareNumber>
    {
        public void Configure(EntityTypeBuilder<CustomerCareNumber> builder)
        {
            builder.ToTable("CustomerCareNumbers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.PhoneNumber).IsRequired();

        }
    }
}