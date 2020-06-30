using DentaCare.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCareDataAccess.Configurations
{
    public class JawSideConfiguration : IEntityTypeConfiguration<JawSide>
    {
        public void Configure(EntityTypeBuilder<JawSide> builder)
        {
            builder.HasIndex(x => x.JawSideName).IsUnique();
            builder.Property(x => x.JawSideName).IsRequired().HasMaxLength(10);

            builder.HasMany(j => j.JawJawSideTeeth)
                   .WithOne(x => x.JawSide)
                   .HasForeignKey(x => x.JawSideId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
