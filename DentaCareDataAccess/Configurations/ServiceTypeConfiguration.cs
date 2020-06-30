using DentaCare.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCareDataAccess.Configurations
{
    public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.HasIndex(x => x.ServiceName).IsUnique();
            builder.Property(x => x.ServiceName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.ServicePrice).IsRequired();

           builder.HasMany(a => a.Appointments)
                  .WithOne(s => s.ServiceTypes)
                  .HasForeignKey(x => x.ServiceTypeId)
                  .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.EKarton)
                .WithOne(s => s.ServiceTypes)
                .HasForeignKey(x => x.ServiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
