using Net.Shared.Persistence.Abstractions.Entities;
using Net.Shared.Persistence.Abstractions.Entities.Catalogs;

namespace AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

public sealed class OperationType : PersistentCatalog, IPersistentSql
{
    public IEnumerable<EventType>? EventTypes { get; set; }
}