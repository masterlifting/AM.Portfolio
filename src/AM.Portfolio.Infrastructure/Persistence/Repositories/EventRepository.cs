using AM.Portfolio.Core.Abstractions.Persistence.Repositories;
using AM.Portfolio.Core.Domain.Persistence.Entities;

using Microsoft.Extensions.Logging;

using Net.Shared.Persistence.Abstractions.Contexts;

using Shared.Persistence.Repositories;

namespace AM.Portfolio.Infrastructure.Persistence.Repositories
{
    public sealed class EventRepository : PostgreRepository<Event>, IEventRepository
    {
        public EventRepository(ILogger<Event> logger, IPersistencePostgreContext context) : base(logger, context)
        {
        }
    }
}
