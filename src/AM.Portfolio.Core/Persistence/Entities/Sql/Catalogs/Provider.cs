using Net.Shared.Persistence.Abstractions.Entities;

namespace AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;

public sealed class Provider : Shared.Models.Persistence.Entities.Catalogs.PersistentCatalog, IPersistentSql, IPersistentCatalog
{
    public IEnumerable<Deal>? Deals { get; set; }
    public IEnumerable<Event>? Events { get; set; }
    public IEnumerable<Account>? Accounts { get; set; }
}
