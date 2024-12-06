using InsuranceAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InsuranceAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Insured> Insureds { get; set; } = default!;
        public DbSet<InsuranceProduct> InsuranceProducts { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public IDbConnection GetDbConnection() => Database.GetDbConnection();
    }
}
