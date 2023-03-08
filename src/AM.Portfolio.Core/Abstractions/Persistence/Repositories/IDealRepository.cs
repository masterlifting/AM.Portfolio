using AM.Portfolio.Core.Persistence.Entities.Sql;
using Net.Shared.Persistence.Abstractions.Core.Repositories;

namespace AM.Portfolio.Core.Abstractions.Persistence.Repositories
{
    public interface IDealRepository : IPersistenceSqlRepository<Deal>
    {
    }
}
