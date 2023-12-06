using Domain.Enums;
using MediatR;

namespace Application.Features.RealtyPlanningTypeFeatures.CreateRealtyPlanningType
{
    public class CreateRealtyPlanningTypeRequest : IRequest
    {
        public PlanningTypeEnum PlanningTypeId { get; set; }
        public Guid RealtyId { get; set; }
    }
}
