using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.RealtyFeatures.EditRealty
{
    public class EditRealtyRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public RealtyTypeEnum RealtyTypeId { get; set; }
        public Guid LocationId { get; set; }
        public int? Floor { get; set; }
        public bool? IsFirstFloor { get; set; }
        public bool? IsLastFloor { get; set; }
        public int? FloorCount { get; set; }
        public double? Area { get; set; }
        public int? RoomCount { get; set; }
        public int? BathCount { get; set; }
        public DateTimeOffset? BuildDate { get; set; }
    }
}
