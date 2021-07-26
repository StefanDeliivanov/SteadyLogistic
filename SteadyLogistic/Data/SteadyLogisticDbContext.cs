namespace SteadyLogistic.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Data.Models.Interfaces;

    public class SteadyLogisticDbContext : IdentityDbContext<SLogisticsUser>
    {
        private object deleteBehavior;

        public SteadyLogisticDbContext(DbContextOptions<SteadyLogisticDbContext> options)
            : base(options)
        {
        }
        public DbSet<City> Cities { get; init; }

        public DbSet<Company> Companies { get; init; }

        public DbSet<Country> Countries { get; init; }

        public DbSet<Freight> Freights { get; init; }

        public DbSet<Truck> Trucks { get; init; }

        public DbSet<Trailer> Trailers { get; init; }

        public DbSet<LoadUnloadInfo> LoadUnloadInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Company>()
                .HasOne(m => m.Manager)
                .WithOne(c => c.Company)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<IVehicle>()
                .HasOne(v => v.Company)
                .WithMany(f => f.Fleet)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
