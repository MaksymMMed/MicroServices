using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistense.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Issues)
                .WithOne(x => x.Unit);
        }
    }
}
