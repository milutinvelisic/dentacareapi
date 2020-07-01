using DentaCare.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCareDataAccess.Configurations
{
    public class EKartonConfiguration : IEntityTypeConfiguration<EKarton>
    {
        public void Configure(EntityTypeBuilder<EKarton> builder)
        {
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            
        }
    }
}
