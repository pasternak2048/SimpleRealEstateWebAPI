using Domain.Enums;
using MediatR;

namespace Application.Features.RealtyWallTypeFeatures.CreateRealtyWallType
{
    public class CreateRealtyWallTypeRequest : IRequest
    {
        public WallTypeEnum WallTypeId { get; set; }
        public Guid RealtyId { get; set; }
    }
}
