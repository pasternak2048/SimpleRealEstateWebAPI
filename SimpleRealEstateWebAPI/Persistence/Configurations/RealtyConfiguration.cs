using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RealtyConfiguration : IEntityTypeConfiguration<Realty>
    {
        public void Configure(EntityTypeBuilder<Realty> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(e => e.RealtyStatus)
                .WithMany(p => p.Realties)
                .HasForeignKey(e => e.RealtyStatusId);

            builder.HasOne(e => e.RealtyType)
               .WithMany(p => p.Realties)
               .HasForeignKey(e => e.RealtyTypeId);

            builder.HasOne(e => e.Location)
                .WithMany(p=>p.Realties)
                .HasForeignKey(e => e.LocationId);
        }
    }
}
