using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RealtyWallTypeConfiguration : IEntityTypeConfiguration<RealtyWallType>
    {
        public void Configure(EntityTypeBuilder<RealtyWallType> builder)
        {
            builder.HasKey(e => new { e.RealtyId, e.WallTypeId });

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyWallTypes)
                .HasForeignKey(e => e.RealtyId);

            builder.HasOne(e => e.WallType)
                .WithMany(p => p.RealtyWallTypes)
                .HasForeignKey(e => e.WallTypeId);
        }
    }
}
