using AM.Portfolio.Core.Domain.Persistence.Collections;

using Net.Shared.Persistence.Abstractions.Repositories;

namespace AM.Portfolio.Core.Abstractions.Persistence.Repositories
{
    public interface IIncomingDataRepository : IPersistenceNoSqlRepository<IncomingData>
    {
    }
}
