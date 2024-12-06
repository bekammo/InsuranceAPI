using InsuranceAPI.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Infrastructure.Configurations
{
    public class InsuranceProductConfiguration : IEntityTypeConfiguration<InsuranceProduct>
    {
        public void Configure(EntityTypeBuilder<InsuranceProduct> builder)
        {
            builder.ToTable("InsuranceProduct");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Premium)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CoverageAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            builder.HasOne(p => p.Insured)
                .WithMany(i => i.InsuranceProducts)
                .HasForeignKey(p => p.InsuredId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
