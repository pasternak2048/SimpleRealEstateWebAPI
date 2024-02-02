using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RealtyPlanningTypeConfiguration : IEntityTypeConfiguration<RealtyPlanningType>
    {
        public void Configure(EntityTypeBuilder<RealtyPlanningType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyPlanningTypes)
                .HasForeignKey(e => e.RealtyId);

            builder.HasOne(e => e.PlanningType)
                .WithMany(p => p.RealtyPlanningTypes)
                .HasForeignKey(e => e.PlanningTypeId);
        }
    }
}
