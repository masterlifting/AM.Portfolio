using Net.Shared.Persistence.Abstractions.Entities;
using Net.Shared.Persistence.Models.Entities.Catalogs;

namespace AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;

public sealed class Exchange : PersistentCatalog, IPersistentSql, IPersistentCatalog
{
    public IEnumerable<Deal>? Deals { get; set; }
    public IEnumerable<Event>? Events { get; set; }
}
