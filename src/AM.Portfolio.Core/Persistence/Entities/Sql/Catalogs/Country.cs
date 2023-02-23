﻿using Net.Shared.Persistence.Abstractions.Entities;
using Net.Shared.Persistence.Models.Entities.Catalogs;

namespace AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;

public sealed class Country : PersistentCatalog, IPersistentSql, IPersistentCatalog
{
    public IEnumerable<Asset>? Assets { get; set; }
}
