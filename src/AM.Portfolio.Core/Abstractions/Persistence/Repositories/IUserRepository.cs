using AM.Portfolio.Core.Domain.Persistence.Entities;

using Net.Shared.Persistence.Abstractions.Repositories;

namespace AM.Portfolio.Core.Abstractions.Persistence.Repositories
{
    public interface IUserRepository : IPersistenceSqlRepository<User>
    {
    }
}
