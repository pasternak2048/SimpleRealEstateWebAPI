using AutoMapper;
using Domain.Entities;

namespace Application.Features.RealtyHeatingTypeFeatures.CreateRealtyHeatingType
{
    public class CreateRealtyHeatingTypeMapper : Profile
    {
        public CreateRealtyHeatingTypeMapper()
        {
            CreateMap<CreateRealtyHeatingTypeRequest, RealtyHeatingType>();
        }
    }
}
