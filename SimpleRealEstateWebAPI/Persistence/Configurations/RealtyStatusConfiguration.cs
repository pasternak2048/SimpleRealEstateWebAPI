using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RealtyStatusConfiguration : IEntityTypeConfiguration<RealtyStatus>
    {
        public void Configure(EntityTypeBuilder<RealtyStatus> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");
        }
    }
}
