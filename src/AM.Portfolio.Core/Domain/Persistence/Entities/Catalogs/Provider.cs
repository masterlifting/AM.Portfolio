using Net.Shared.Persistence.Abstractions.Entities;
using Net.Shared.Persistence.Abstractions.Entities.Catalogs;

namespace AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

public sealed class Provider : PersistentCatalog, IPersistentSql
{
    public IEnumerable<Deal>? Deals { get; set; }
    public IEnumerable<Event>? Events { get; set; }
    public IEnumerable<Account>? Accounts { get; set; }
}