using Application.Common.Models;
using Application.Features.RealtyFeatures.GetRealties;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IRealtyRepository
    {
        void Create(Realty entity);
        void Update(Realty entity);
        void Delete(Realty entity);

        Task<PaginatedList<GetRealtiesResponse>> GetRealties(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
