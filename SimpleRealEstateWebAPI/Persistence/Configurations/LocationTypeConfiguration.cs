using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LocationTypeConfiguration : IEntityTypeConfiguration<LocationType>
    {
        public void Configure(EntityTypeBuilder<LocationType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasData(
                new LocationType() { Id = LocationTypeEnum.None, Name = "None" },
                new LocationType() { Id = LocationTypeEnum.Street, Name = "Street" },
                new LocationType() { Id = LocationTypeEnum.CityArea, Name = "CityArea" },
                new LocationType() { Id = LocationTypeEnum.City, Name = "City" },
                new LocationType() { Id = LocationTypeEnum.District, Name = "District" },
                new LocationType() { Id = LocationTypeEnum.Region, Name = "Region" }
                );
        }
    }
}
