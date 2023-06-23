using Domain.Enums;

namespace Domain.Entities
{
    public class RealtyPlanningType
    {
        public Guid RealtyId { get; set; }
        public PlanningTypeEnum PlanningTypeId { get; set; }

        public virtual Realty Realty { get; set; }
        public virtual PlanningType PlanningType { get; set; }
    }
}
