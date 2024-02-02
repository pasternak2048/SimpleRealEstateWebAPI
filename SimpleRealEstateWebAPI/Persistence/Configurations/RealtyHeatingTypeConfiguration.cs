using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Persistence.Configurations
{
    public class RealtyHeatingTypeConfiguration : IEntityTypeConfiguration<RealtyHeatingType>
    {
        public void Configure(EntityTypeBuilder<RealtyHeatingType> builder)
        {
            builder.HasKey(e => new { e.RealtyId, e.HeatingTypeId });

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.RealtyId);

            builder.HasOne(e => e.HeatingType)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.HeatingTypeId);
        }
    }
}
