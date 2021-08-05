namespace SteadyLogistic.Infrastructure.EntityModelCreating
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SteadyLogistic.Data.Models;

    public class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder
                .HasOne(a => a.Fleet)
                .WithMany(b => b.Trucks)
                .HasForeignKey(c => c.FleetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}