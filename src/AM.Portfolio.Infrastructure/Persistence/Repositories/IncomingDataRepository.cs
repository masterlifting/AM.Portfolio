using AM.Portfolio.Core.Abstractions.Persistence.Repositories;
using AM.Portfolio.Core.Persistence.Entities.NoSql;
using Microsoft.Extensions.Logging;

using Net.Shared.Persistence.Abstractions.Contexts;

using Shared.Persistence.Repositories;

namespace AM.Portfolio.Infrastructure.Persistence.Repositories
{
    public sealed class IncomingDataRepository : MongoRepository<IncomingData>, IIncomingDataRepository
    {
        public IncomingDataRepository(ILogger<IncomingData> logger, IPersistenceMongoContext context) : base(logger, context)
        {
        }
    }
}
