using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public Task<User> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return Context.OldUsers.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}