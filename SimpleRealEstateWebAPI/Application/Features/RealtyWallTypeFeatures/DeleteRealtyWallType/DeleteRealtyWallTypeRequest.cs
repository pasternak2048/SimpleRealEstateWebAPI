using MediatR;

namespace Application.Features.RealtyWallTypeFeatures.DeleteRealtyWallType
{
    public class DeleteRealtyWallTypeRequest : IRequest
    {
        public Guid RealtyWallTypeId { get; set; }
    }
}
