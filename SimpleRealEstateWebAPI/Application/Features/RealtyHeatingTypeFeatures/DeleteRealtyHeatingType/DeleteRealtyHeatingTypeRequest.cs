using MediatR;

namespace Application.Features.RealtyHeatingTypeFeatures.DeleteRealtyHeatingType
{
    public class DeleteRealtyHeatingTypeRequest : IRequest
    {
        public Guid RealtyHeatingTypeId { get; set; }
    }
}
