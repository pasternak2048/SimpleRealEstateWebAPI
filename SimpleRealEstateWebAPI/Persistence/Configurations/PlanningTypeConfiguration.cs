using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PlanningTypeConfiguration : IEntityTypeConfiguration<PlanningType>
    {
        public void Configure(EntityTypeBuilder<PlanningType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasData(
                new PlanningType() { Id = PlanningTypeEnum.None, Name = "None" },
                new PlanningType() { Id = PlanningTypeEnum.Jacuzzi, Name = "Jacuzzi" },
                new PlanningType() { Id = PlanningTypeEnum.MultiLevel, Name = "MultiLevel" },
                new PlanningType() { Id = PlanningTypeEnum.Terrace, Name = "Terrace" },
                new PlanningType() { Id = PlanningTypeEnum.Penthouse, Name = "Penthouse" },
                new PlanningType() { Id = PlanningTypeEnum.WithoutFurniture, Name = "WithoutFurniture" }
                );
        }
    }
}
