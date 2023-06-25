using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class RealtyRepository : IRealtyRepository
    {
        protected readonly DataContext Context;

        public RealtyRepository(DataContext context)
        {
            Context = context;
        }

        public void Create(Realty entity)
        {
            Context.Add(entity);
        }

        public void Update(Realty entity)
        {
            Context.Update(entity);
        }

        public void Delete(Realty entity)
        {
            entity.IsDeleted = true;
            Context.Update(entity);
        }
    }
}
