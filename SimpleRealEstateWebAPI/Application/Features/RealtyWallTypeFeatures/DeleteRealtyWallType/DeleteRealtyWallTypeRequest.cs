using Domain.Enums;
using MediatR;

namespace Application.Features.RealtyWallTypeFeatures.DeleteRealtyWallType
{
    public class DeleteRealtyWallTypeRequest : IRequest
    {
        public WallTypeEnum WallTypeId { get; set; }
        public Guid RealtyId { get; set; }
    }
}
