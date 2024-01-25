using Domain.Enums;
using MediatR;

namespace Application.Features.RealtyHeatingTypeFeatures.DeleteRealtyHeatingType
{
    public class DeleteRealtyHeatingTypeRequest : IRequest
    {
        public HeatingTypeEnum HeatingTypeId { get; set; }
        public Guid RealtyId { get; set; }
    }
}
