using AM.Shared.Abstractions.Persistence.Entities.Catalogs;

using Net.Shared.Persistence.Abstractions.Entities;

namespace AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

public sealed class AssetType : AssetTypeBase, IPersistentSql
{
    public IEnumerable<Asset>? Assets { get; set; }
}
