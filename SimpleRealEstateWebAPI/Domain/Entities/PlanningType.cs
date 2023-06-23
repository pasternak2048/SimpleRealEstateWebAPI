using Domain.Enums;

namespace Domain.Entities
{
    public class PlanningType
    {
        public PlanningType()
        {
            RealtyPlanningTypes = new HashSet<RealtyPlanningType>();
        }

        public PlanningTypeEnum Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RealtyPlanningType> RealtyPlanningTypes { get; set; }
    }
}
