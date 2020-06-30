using DentaCare.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCareDataAccess.Configurations
{
    public class JawJawSideToothConfiguration : IEntityTypeConfiguration<JawJawSideTooth>
    {
        public void Configure(EntityTypeBuilder<JawJawSideTooth> builder)
        {
            builder.HasMany(x => x.EKarton)
                   .WithOne(x => x.JawJawSideTooth)
                   .HasForeignKey(x => x.JawJawSideToothId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
