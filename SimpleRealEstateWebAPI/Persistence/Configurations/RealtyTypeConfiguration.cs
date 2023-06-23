using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RealtyTypeConfiguration : IEntityTypeConfiguration<RealtyType>
    {
        public void Configure(EntityTypeBuilder<RealtyType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");
        }
    }
}
