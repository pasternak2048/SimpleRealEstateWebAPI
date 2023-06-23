using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class WallTypeConfiguration : IEntityTypeConfiguration<WallType>
    {
        public void Configure(EntityTypeBuilder<WallType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");
        }
    }
}
