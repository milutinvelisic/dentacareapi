using DentaCare.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCareDataAccess.Configurations
{
    public class JawConfiguration : IEntityTypeConfiguration<Jaw>
    {
        public void Configure(EntityTypeBuilder<Jaw> builder)
        {
            builder.HasIndex(x => x.JawName).IsUnique();
            builder.Property(x => x.JawName).IsRequired().HasMaxLength(10);

            builder.HasMany(j => j.JawJawSideTeeth)
                   .WithOne(x => x.Jaw)
                   .HasForeignKey(x => x.JawId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
