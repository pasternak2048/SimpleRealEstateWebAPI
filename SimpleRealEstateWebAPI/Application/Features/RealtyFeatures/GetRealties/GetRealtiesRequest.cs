using Application.Common.Models;
using MediatR;

namespace Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesRequest : IRequest<PaginatedList<GetRealtiesResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
