namespace SteadyLogistic.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Infrastructure.EntityModelCreating;

    public class SteadyLogisticDbContext : IdentityDbContext<User>
    {

        public SteadyLogisticDbContext(DbContextOptions<SteadyLogisticDbContext> options)
            : base(options)
        {
        }

        public DbSet<CargoSize> CargoSizes { get; set; }

        public DbSet<City> Cities { get; set; }   

        public DbSet<Company> Companies { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Dimension> Dimensions { get; set; }

        public DbSet<Fleet> Fleets { get; set; }

        public DbSet<Freight> Freights { get; set; }

        public DbSet<LoadUnloadInfo> LoadUnloadInfos { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<PremiumUser> PremiumUsers { get; set; }

        public DbSet<Trailer> Trailers { get; set; }

        public DbSet<TrailerType> TrailerTypes { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new FreightConfiguration());
            modelBuilder.ApplyConfiguration(new LoadUnloadInfoConfiguration());
            modelBuilder.ApplyConfiguration(new PremiumUserConfiguration());
            modelBuilder.ApplyConfiguration(new TrailerConfiguration());
            modelBuilder.ApplyConfiguration(new TruckConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}