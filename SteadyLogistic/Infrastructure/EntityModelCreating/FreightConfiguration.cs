namespace SteadyLogistic.Infrastructure.EntityModelCreating
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SteadyLogistic.Data.Models;

    public class FreightConfiguration : IEntityTypeConfiguration<Freight>
    {
        public void Configure(EntityTypeBuilder<Freight> builder)
        {
            builder
                .HasOne(a => a.CargoSize)
                .WithMany(b => b.Freights)
                .HasForeignKey(c => c.CargoSizeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Dimension)
                .WithMany(b => b.Freights)
                .HasForeignKey(c => c.DimensionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.User)
                .WithMany(b => b.Freights)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Loading)
                .WithMany(b => b.Loadings)
                .HasForeignKey(c => c.LoadingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Unloading)
                .WithMany(b => b.Unloadings)
                .HasForeignKey(c => c.UnloadingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(a => a.TrailerTypes)
                .WithMany(b => b.Freights);
        }
    }
}