using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesHandler : IRequestHandler<GetRealtiesRequest, PaginatedList<GetRealtiesResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRealtiesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetRealtiesResponse>> Handle(GetRealtiesRequest request, CancellationToken cancellationToken)
        {
            var realtiesQueryable = _context.Realties.AsQueryable();

            var realtiesPaginated = await realtiesQueryable
                  .ProjectTo<GetRealtiesResponse>(_mapper.ConfigurationProvider)
                  .PaginatedListAsync(request.PageNumber, request.PageSize);

            return realtiesPaginated;
        }
    }
}
