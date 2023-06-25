using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RealtyTypeConfiguration : IEntityTypeConfiguration<RealtyType>
    {
        public void Configure(EntityTypeBuilder<RealtyType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasData(
                new RealtyType() { Id = RealtyTypeEnum.None, Name = "None" },
                new RealtyType() { Id = RealtyTypeEnum.Flat, Name = "Flat" },
                new RealtyType() { Id = RealtyTypeEnum.House, Name = "House" },
                new RealtyType() { Id = RealtyTypeEnum.Commercial, Name = "Commercial" },
                new RealtyType() { Id = RealtyTypeEnum.Planning, Name = "Planning" },
                new RealtyType() { Id = RealtyTypeEnum.PlaceOnly, Name = "PlaceOnly" }
                );
        }
    }
}
