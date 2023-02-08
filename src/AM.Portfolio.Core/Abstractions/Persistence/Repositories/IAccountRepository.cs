using AM.Portfolio.Core.Domain.Persistence.Entities;

using Net.Shared.Persistence.Abstractions.Repositories;

namespace AM.Portfolio.Core.Abstractions.Persistence.Repositories
{
    public interface IAccountRepository : IPersistenceSqlRepository<Account>
    {
        Task<Account> GetAccountAsync(string agreement, Guid userId, int providerId);
    }
}
