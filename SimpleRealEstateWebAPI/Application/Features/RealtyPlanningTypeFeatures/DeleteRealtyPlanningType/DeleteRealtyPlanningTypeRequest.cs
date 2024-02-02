using MediatR;

namespace Application.Features.RealtyPlanningTypeFeatures.DeleteRealtyPlanningType
{
    public class DeleteRealtyPlanningTypeRequest : IRequest
    {
        public Guid RealtyPlanningTypeId { get; set; }
    }
}
