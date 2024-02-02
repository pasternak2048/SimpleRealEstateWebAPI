using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class RealtyPlanningType : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid RealtyId { get; set; }
        public PlanningTypeEnum PlanningTypeId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Realty Realty { get; set; }
        public virtual PlanningType PlanningType { get; set; }
    }
}
