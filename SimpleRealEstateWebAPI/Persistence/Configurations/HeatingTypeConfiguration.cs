using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class HeatingTypeConfiguration : IEntityTypeConfiguration<HeatingType>
    {
        public void Configure(EntityTypeBuilder<HeatingType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");
        }
    }
}
