using Application.Common.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesMapper : Profile
    {
        public GetRealtiesMapper()
        {
            CreateMap<GetRealtiesRequest, Realty>().ReverseMap();
            CreateMap<GetRealtiesResponse, Realty>().ReverseMap();
            CreateMap<RealtyPlanningType, RealtyPlanningTypeDto>();
            CreateMap<PlanningType, PlanningTypeDto>();
        }
    }
}
