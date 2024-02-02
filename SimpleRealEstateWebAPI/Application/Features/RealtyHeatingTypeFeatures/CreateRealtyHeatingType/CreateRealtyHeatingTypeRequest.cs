using Domain.Enums;
using MediatR;

namespace Application.Features.RealtyHeatingTypeFeatures.CreateRealtyHeatingType
{
    public class CreateRealtyHeatingTypeRequest : IRequest
    {
        public HeatingTypeEnum HeatingTypeId { get; set; }
        public Guid RealtyId { get; set; }
    }
}
