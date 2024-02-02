using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RealtyWallTypeConfiguration : IEntityTypeConfiguration<RealtyWallType>
    {
        public void Configure(EntityTypeBuilder<RealtyWallType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyWallTypes)
                .HasForeignKey(e => e.RealtyId);

            builder.HasOne(e => e.WallType)
                .WithMany(p => p.RealtyWallTypes)
                .HasForeignKey(e => e.WallTypeId);
        }
    }
}
