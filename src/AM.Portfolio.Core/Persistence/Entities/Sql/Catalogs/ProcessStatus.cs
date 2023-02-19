using AM.Shared.Models.Persistence.Entities.Catalogs;

using Net.Shared.Persistence.Abstractions.Entities;

namespace AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;

public sealed class ProcessStatus : PersistentProcessStatus, IPersistentSql, IPersistentCatalog
{
    public IEnumerable<Asset>? Assets { get; set; }
    public IEnumerable<Derivative>? Derivatives { get; set; }
    public IEnumerable<Deal>? Deals { get; set; }
    public IEnumerable<Event>? Events { get; set; }
}
