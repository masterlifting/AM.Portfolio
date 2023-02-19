using Net.Shared.Persistence.Abstractions.Entities;

namespace AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;

public sealed class Exchange : Shared.Models.Persistence.Entities.Catalogs.Exchange, IPersistentSql, IPersistentCatalog
{
    public IEnumerable<Deal>? Deals { get; set; }
    public IEnumerable<Event>? Events { get; set; }
}
