using Domain.Entities;

namespace Application.Repositories
{
    public interface IRealtyRepository
    {
        void Create(Realty entity);
        void Update(Realty entity);
        void Delete(Realty entity);
    }
}
