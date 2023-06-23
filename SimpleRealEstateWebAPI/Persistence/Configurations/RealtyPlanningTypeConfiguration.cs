using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RealtyPlanningTypeConfiguration : IEntityTypeConfiguration<RealtyPlanningType>
    {
        public void Configure(EntityTypeBuilder<RealtyPlanningType> builder)
        {
            builder.HasKey(e => new { e.RealtyId, e.PlanningTypeId });

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyPlanningTypes)
                .HasForeignKey(e => e.RealtyId);

            builder.HasOne(e => e.PlanningType)
                .WithMany(p => p.RealtyPlanningTypes)
                .HasForeignKey(e => e.PlanningTypeId);
        }
    }
}
