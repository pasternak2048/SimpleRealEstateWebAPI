using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.RealtyFeatures.CreateRealty
{
    public sealed class CreateRealtyMapper : Profile
    {
        public CreateRealtyMapper()
        {
            CreateMap<CreateRealtyRequest, Realty>();

            CreateMap<Realty, CreateRealtyResponse>();

            CreateMap<int, RealtyPlanningType>()
                .ForMember(dest => dest.PlanningTypeId, opts => opts.MapFrom(y => y));

            CreateMap<int, RealtyHeatingType>()
                .ForMember(dest => dest.HeatingTypeId, opts => opts.MapFrom(y => y));

            CreateMap<int, RealtyWallType>()
                .ForMember(dest => dest.WallTypeId, opts => opts.MapFrom(y => y));
        }
    }
}
