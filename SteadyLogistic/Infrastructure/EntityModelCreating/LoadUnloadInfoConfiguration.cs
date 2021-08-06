namespace SteadyLogistic.Infrastructure.EntityModelCreating
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SteadyLogistic.Data.Models;

    public class LoadUnloadInfoConfiguration : IEntityTypeConfiguration<LoadUnloadInfo>
    {
        public void Configure(EntityTypeBuilder<LoadUnloadInfo> builder)
        {
            builder
                .HasOne(a => a.City)
                .WithMany(b => b.LoadUnloadings)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Country)
                .WithMany(b => b.LoadUnloadings)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}