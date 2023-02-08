using AM.Portfolio.Core.Domain.Persistence.Entities;
using AM.Shared.Abstractions.Persistence.Entities.Catalogs;

using Net.Shared.Persistence.Abstractions.Entities;

namespace AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

public sealed class Exchange : ExchangeBase, IPersistentSql
{
    public IEnumerable<Deal>? Deals { get; set; }
    public IEnumerable<Event>? Events { get; set; }
}
