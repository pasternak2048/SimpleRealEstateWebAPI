using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PlanningTypeConfiguration : IEntityTypeConfiguration<PlanningType>
    {
        public void Configure(EntityTypeBuilder<PlanningType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");
        }
    }
}
