using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class HeatingTypeConfiguration : IEntityTypeConfiguration<HeatingType>
    {
        public void Configure(EntityTypeBuilder<HeatingType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasData(
                new HeatingType() { Id = HeatingTypeEnum.None, Name = "None" },
                new HeatingType() { Id = HeatingTypeEnum.Electric, Name = "Electric" },
                new HeatingType() { Id = HeatingTypeEnum.Gas, Name = "Gas" },
                new HeatingType() { Id = HeatingTypeEnum.SolidFuel, Name = "SolidFuel" },
                new HeatingType() { Id = HeatingTypeEnum.Solar, Name = "Solar" },
                new HeatingType() { Id = HeatingTypeEnum.Geothermal, Name = "Geothermal" }
                );
        }
    }
}
