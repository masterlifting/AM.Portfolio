using AM.Portfolio.Core.Persistence.Entities.NoSql;
using Net.Shared.Persistence.Abstractions.Repositories;

namespace AM.Portfolio.Core.Abstractions.Persistence.Repositories
{
    public interface IIncomingDataRepository : IPersistenceNoSqlRepository<IncomingData>
    {
    }
}
