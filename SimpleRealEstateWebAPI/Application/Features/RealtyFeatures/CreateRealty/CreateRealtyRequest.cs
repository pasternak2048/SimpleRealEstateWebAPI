using MediatR;

namespace Application.Features.RealtyFeatures.CreateRealty
{
    public sealed record CreateRealtyRequest(string Description) : IRequest<CreateRealtyResponse>;
}
