using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures.GetAllUser
{
    public sealed class GetAllUserMapper : Profile
    {
        public GetAllUserMapper()
        {
            CreateMap<User, GetAllUserResponse>();
        }
    }
}