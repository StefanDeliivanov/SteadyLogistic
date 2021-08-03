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

        public DbSet<Fleet> Fleets { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<SLogisticsUser> SLogisticsUsers { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Freight> Freights { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Trailer> Trailers { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<LoadUnloadInfo> LoadUnloadInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new LoadUnloadInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ManagerConfiguration());
            modelBuilder.ApplyConfiguration(new SLogisticsUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
