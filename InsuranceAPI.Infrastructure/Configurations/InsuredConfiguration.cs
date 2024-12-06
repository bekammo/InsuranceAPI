using InsuranceAPI.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAPI.Infrastructure.Configurations
{
    public class InsuredConfiguration : IEntityTypeConfiguration<Insured>
    {
        public void Configure(EntityTypeBuilder<Insured> builder)
        {
            builder.ToTable("Insured");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.PersonalNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(i => i.Email)
                .HasMaxLength(100);

            builder.HasMany(i => i.InsuranceProducts)
                .WithOne(p => p.Insured)
                .HasForeignKey(p => p.InsuredId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
