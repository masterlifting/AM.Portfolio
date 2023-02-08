using AM.Shared.Abstractions.Persistence.Entities.Catalogs;

using Net.Shared.Persistence.Abstractions.Entities;

namespace AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

public sealed class ProcessStatus : ProcessStatusBase, IPersistentSql
{
    public IEnumerable<Asset>? Assets { get; set; }
    public IEnumerable<Derivative>? Derivatives { get; set; }
    public IEnumerable<Deal>? Deals { get; set; }
    public IEnumerable<Event>? Events { get; set; }
}