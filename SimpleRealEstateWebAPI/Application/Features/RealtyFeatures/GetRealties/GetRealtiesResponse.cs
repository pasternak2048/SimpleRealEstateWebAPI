using Application.Common.DTOs;

namespace Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<RealtyPlanningTypeDto> RealtyPlanningTypes { get; set; }

    }
}
