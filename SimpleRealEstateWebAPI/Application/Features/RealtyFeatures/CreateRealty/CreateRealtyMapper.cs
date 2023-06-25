using AutoMapper;
using Domain.Entities;

namespace Application.Features.RealtyFeatures.CreateRealty
{
    public sealed class CreateRealtyMapper : Profile
    {
        public CreateRealtyMapper()
        {
            CreateMap<CreateRealtyRequest, Realty>();
            CreateMap<Realty, CreateRealtyResponse>();
        }
    }
}
