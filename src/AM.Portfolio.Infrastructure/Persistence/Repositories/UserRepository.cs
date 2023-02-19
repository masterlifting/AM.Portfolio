using AM.Portfolio.Core.Abstractions.Persistence.Repositories;
using AM.Portfolio.Core.Persistence.Entities.Sql;
using Microsoft.Extensions.Logging;

using Net.Shared.Persistence.Abstractions.Contexts;

using Shared.Persistence.Repositories;

namespace AM.Portfolio.Infrastructure.Persistence.Repositories
{
    public sealed class UserRepository : PostgreRepository<User>, IUserRepository
    {
        public UserRepository(ILogger<User> logger, IPersistencePostgreContext context) : base(logger, context)
        {
        }
    }
}
