using Application.Common.Models;
using Application.Repositories;
using MediatR;

namespace Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesHandler : IRequestHandler<GetRealtiesRequest, PaginatedList<GetRealtiesResponse>>
    {
        private readonly IRealtyRepository _realtyRepository;

        public GetRealtiesHandler(IRealtyRepository realtyRepository)
        {
            _realtyRepository = realtyRepository;
        }

        public async Task<PaginatedList<GetRealtiesResponse>> Handle(GetRealtiesRequest request, CancellationToken cancellationToken)
        {
            var realties = await _realtyRepository.GetRealties(request.PageNumber, request.PageSize, cancellationToken);

            return realties;
        }
    }
}
