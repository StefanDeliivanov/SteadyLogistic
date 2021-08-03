namespace SteadyLogistic.Infrastructure.EntityModelCreating
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SteadyLogistic.Data.Models;

    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasIndex(a => a.Name)
                .IsUnique();

            builder
                .HasIndex(a => a.Code)
                .IsUnique();
        }
    }
}


