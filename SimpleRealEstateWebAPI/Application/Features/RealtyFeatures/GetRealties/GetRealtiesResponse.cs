namespace Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        //public List<RealtyPlanningType> RealtyPlanningTypes { get; set; }

    }

    public class RealtyPlanningType
    {
        public Guid PlanningTypeId { get; set; }
        public Guid RealtyId { get; set; }

    }
}
