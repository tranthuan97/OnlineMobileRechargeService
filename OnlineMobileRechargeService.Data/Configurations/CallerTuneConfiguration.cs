using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMobileRechargeService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMobileRechargeService.Data.Configurations
{
    public class CallerTuneConfiguration : IEntityTypeConfiguration<CallerTune>
    {
        public void Configure(EntityTypeBuilder<CallerTune> builder)
        {
            builder.ToTable("CallerTunes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Singer).IsRequired();
            builder.Property(x => x.Image).IsRequired();

        }
    }
}
