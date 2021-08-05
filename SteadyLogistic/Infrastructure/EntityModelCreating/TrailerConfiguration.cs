namespace SteadyLogistic.Infrastructure.EntityModelCreating
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SteadyLogistic.Data.Models;

    public class TrailerConfiguration : IEntityTypeConfiguration<Trailer>
    {
        public void Configure(EntityTypeBuilder<Trailer> builder)
        {
            builder
                .HasOne(a => a.Fleet)
                .WithMany(b => b.Trailers)
                .HasForeignKey(c => c.FleetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Type)
                .WithMany(b => b.Trailers)
                .HasForeignKey(c => c.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Dimension)
                .WithMany(b => b.Trailers)
                .HasForeignKey(c => c.DimensionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}