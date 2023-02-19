using Net.Shared.Persistence.Abstractions.Entities;

namespace AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;

public sealed class Country : Shared.Models.Persistence.Entities.Catalogs.Country, IPersistentSql, IPersistentCatalog
{
    public IEnumerable<Asset>? Assets { get; set; }
}
