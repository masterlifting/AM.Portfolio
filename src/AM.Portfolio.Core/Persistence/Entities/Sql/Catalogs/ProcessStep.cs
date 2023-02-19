using AM.Shared.Models.Persistence.Entities.Catalogs;

using Net.Shared.Persistence.Abstractions.Entities;

namespace AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;

public sealed class ProcessStep : PersistentProcessStep, IPersistentSql, IPersistentCatalog
{
}
