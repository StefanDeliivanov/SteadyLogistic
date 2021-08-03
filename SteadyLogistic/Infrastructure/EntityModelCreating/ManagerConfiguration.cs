namespace SteadyLogistic.Infrastructure.EntityModelCreating
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SteadyLogistic.Data.Models;

    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder
                .HasKey(a => new { a.CompanyId, a.UserId });
        }
    }
}
