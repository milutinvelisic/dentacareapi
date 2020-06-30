using DentaCare.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCareDataAccess.Configurations
{
    public class TeethConfiguration : IEntityTypeConfiguration<Teeth>
    {
        public void Configure(EntityTypeBuilder<Teeth> builder)
        {
            builder.HasIndex(x => x.ToothNumber).IsUnique();
            builder.Property(x => x.ToothNumber).IsRequired();

            builder.HasMany(j => j.JawJawSideTeeth)
                   .WithOne(x => x.Tooth)
                   .HasForeignKey(x => x.ToothId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
