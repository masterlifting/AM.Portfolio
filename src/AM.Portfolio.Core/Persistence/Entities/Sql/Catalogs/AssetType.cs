using Net.Shared.Persistence.Abstractions.Entities;

namespace AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;

public sealed class AssetType : Shared.Models.Persistence.Entities.Catalogs.AssetType, IPersistentSql, IPersistentCatalog
{
    public IEnumerable<Asset>? Assets { get; set; }
}
