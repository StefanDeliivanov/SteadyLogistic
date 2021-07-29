namespace SteadyLogistic.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SteadyLogistic.Data.Models;

    public class SteadyLogisticDbContext : IdentityDbContext<SLogisticsUser>
    {

        public SteadyLogisticDbContext(DbContextOptions<SteadyLogisticDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Freight> Freights { get; set; }

        public DbSet<Truck> Trucks { get; set; }

        public DbSet<Trailer> Trailers { get; set; }

        public DbSet<LoadUnloadInfo> LoadUnloadInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<City>()
                .HasOne(a => a.Country)
                .WithMany(b => b.Cities)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder
            //    .Entity<Company>()
            //    .HasOne(a => a.Manager)
            //    .WithOne(b => b.Company)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Company>()
               .HasOne(a => a.Country)
               .WithMany(b => b.Companies)
               .HasForeignKey(c => c.CountryId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
               .Entity<Company>()
               .HasOne(a => a.City)
               .WithMany(b => b.Companies)
               .HasForeignKey(c => c.CityId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Freight>()
               .HasOne(a => a.User)
               .WithMany(b => b.Freights)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
             .Entity<LoadUnloadInfo>()
             .HasOne(a => a.City)
             .WithMany(b => b.LoadUnloadings)
             .HasForeignKey(c => c.CityId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
            .Entity<LoadUnloadInfo>()
            .HasOne(a => a.Country)
            .WithMany(b => b.LoadUnloadings)
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
            .Entity<SLogisticsUser>()
            .HasOne(a => a.Company)
            .WithMany(b => b.Employees)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
            .Entity<Truck>()
            .HasOne(a => a.Company)
            .WithMany(b => b.TruckFleet)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
            .Entity<Trailer>()
            .HasOne(a => a.Company)
            .WithMany(b => b.TrailerFleet)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
