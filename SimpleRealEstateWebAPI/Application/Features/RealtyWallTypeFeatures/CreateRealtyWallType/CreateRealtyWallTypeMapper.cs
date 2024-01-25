using AutoMapper;
using Domain.Entities;

namespace Application.Features.RealtyWallTypeFeatures.CreateRealtyWallType
{
    public class CreateRealtyWallTypeMapper : Profile
    {
        public CreateRealtyWallTypeMapper()
        {
            CreateMap<CreateRealtyWallTypeRequest, RealtyWallType>();
        }
    }
}
