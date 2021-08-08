namespace SteadyLogistic.Infrastructure.EntityModelCreating
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SteadyLogistic.Data.Models;

    public class PremiumUserConfiguration : IEntityTypeConfiguration<PremiumUser>
    {
        public void Configure(EntityTypeBuilder<PremiumUser> builder)
        {
            builder
                .HasOne(a => a.Company)
                .WithMany(b => b.Employees)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<PremiumUser>(b => b.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(a => a.Email)
                .IsUnique();

            builder
                .HasIndex(a => a.PhoneNumber)
                .IsUnique();
        }
    }
}