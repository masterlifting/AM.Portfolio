using AM.Portfolio.Core.Persistence.Entities.Sql;
using Net.Shared.Persistence.Abstractions.Repositories;

namespace AM.Portfolio.Core.Abstractions.Persistence.Repositories
{
    public interface IEventRepository : IPersistenceSqlRepository<Event>
    {
    }
}
