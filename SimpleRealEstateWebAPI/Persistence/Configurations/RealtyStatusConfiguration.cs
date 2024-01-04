using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RealtyStatusConfiguration : IEntityTypeConfiguration<RealtyStatus>
    {
        public void Configure(EntityTypeBuilder<RealtyStatus> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasData(
                new RealtyStatus() { Id = RealtyStatusEnum.Unknown, Name = "Unknown" },
                new RealtyStatus() { Id = RealtyStatusEnum.New, Name = "New" },
                new RealtyStatus() { Id = RealtyStatusEnum.NonVerified, Name = "NonVerified" },
                new RealtyStatus() { Id = RealtyStatusEnum.Verified, Name = "Verified" }
                );
        }
    }
}
