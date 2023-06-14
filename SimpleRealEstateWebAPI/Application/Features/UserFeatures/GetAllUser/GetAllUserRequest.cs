using MediatR;

namespace Application.Features.UserFeatures.GetAllUser
{
    public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;
}