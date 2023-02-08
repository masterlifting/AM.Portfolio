using AM.Portfolio.Core.Abstractions.Persistence.Repositories;
using AM.Portfolio.Core.Domain.Persistence.Entities;

using Microsoft.Extensions.Logging;

using Net.Shared.Persistence.Abstractions.Contexts;

using Shared.Persistence.Repositories;

namespace AM.Portfolio.Infrastructure.Persistence.Repositories
{
    public sealed class DealRepository : PostgreRepository<Deal>, IDealRepository
    {
        public DealRepository(ILogger<Deal> logger, IPostgrePersistenceContext context) : base(logger, context)
        {
        }
    }
}
