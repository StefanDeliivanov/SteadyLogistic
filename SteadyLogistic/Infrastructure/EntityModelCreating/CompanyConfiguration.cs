namespace SteadyLogistic.Infrastructure.EntityModelCreating
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SteadyLogistic.Data.Models;

    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder
               .HasOne(a => a.Manager)
               .WithOne(b => b.Company)
               .HasForeignKey<Company>(c => c.ManagerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Country)
                .WithMany(b => b.Companies)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(a => a.City)
                .WithMany(b => b.Companies)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Fleet)
                .WithOne(b => b.Company)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(a => a.VatNumber)
                .IsUnique();

            builder
                .HasIndex(a => a.Name)
                .IsUnique();

            builder
                .HasIndex(a => a.Email)
                .IsUnique();

            builder
                .HasIndex(a => a.PhoneNumber)
                .IsUnique();
        }
    }
}