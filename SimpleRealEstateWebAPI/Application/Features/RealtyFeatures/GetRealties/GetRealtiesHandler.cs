using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesHandler : IRequestHandler<GetRealtiesRequest, PaginatedList<GetRealtiesResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISqlConnectionService _connectionService;

        public GetRealtiesHandler(IApplicationDbContext context, IMapper mapper, ISqlConnectionService connectionService)
        {
            _context = context;
            _mapper = mapper;
            _connectionService = connectionService;
        }
       // List<GetRealtiesResponse>
        public async Task<PaginatedList<GetRealtiesResponse>> Handle(GetRealtiesRequest request, CancellationToken cancellationToken)
        {
            //var realtiesQueryable = _context.Realties.AsQueryable();

            //var realtiesPaginated = await realtiesQueryable
            //      .ProjectTo<GetRealtiesResponse>(_mapper.ConfigurationProvider)
            //      .PaginatedListAsync(request.PageNumber, request.PageSize);

            await using SqlConnection sqlConnection = _connectionService.CreateConnection();

            var sql = $@"SELECT * FROM Realties AS rt
                      INNER JOIN RealtyPlanningTypes AS RealtyPlanningTypes
                      ON rt.ID = RealtyPlanningTypes.RealtyId
                      ORDER BY (SELECT NULL)
                      OFFSET {(request.PageNumber - 1) * request.PageSize}
                      ROWS FETCH NEXT {request.PageSize} ROWS ONLY";

            var realties = await sqlConnection.QueryAsync<GetRealtiesResponse>(sql);

            return PaginatedList<GetRealtiesResponse>.Create(realties.ToList(), request.PageNumber, request.PageSize);

            //return realtiesPaginated;
        }
    }
}
