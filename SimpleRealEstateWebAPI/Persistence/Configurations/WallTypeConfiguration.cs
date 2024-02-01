using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class WallTypeConfiguration : IEntityTypeConfiguration<WallType>
    {
        public void Configure(EntityTypeBuilder<WallType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasData(
               new WallType() { Id = WallTypeEnum.None, Name = "None" },
               new WallType() { Id = WallTypeEnum.Brick, Name = "Brick" },
               new WallType() { Id = WallTypeEnum.Concrete, Name = "Concrete" },
               new WallType() { Id = WallTypeEnum.Wood, Name = "Wood" }
               );
        }
    }
}
