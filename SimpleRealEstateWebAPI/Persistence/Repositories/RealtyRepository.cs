using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class RealtyRepository : BaseRepository<Realty>, IRealtyRepository
    {
        public RealtyRepository(DataContext context) : base(context)
        {
        }
    }
}
