using AM.Shared.Models.Persistence.Entities.Catalogs;

using Net.Shared.Persistence.Abstractions.Entities;
using Net.Shared.Persistence.Abstractions.Entities.Catalogs;
using Net.Shared.Persistence.Models.Entities.Catalogs;

namespace AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;

public sealed class EventType : PersistentCatalog, IPersistentSql, IPersistentCatalog
{
    public OperationType OperationType { get; set; } = null!;
    public int OperationTypeId { get; set; }

    public IEnumerable<Event>? Events { get; set; }
}
