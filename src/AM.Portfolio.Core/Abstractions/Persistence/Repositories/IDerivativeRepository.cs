using AM.Portfolio.Core.Persistence.Entities.Sql;
using Net.Shared.Persistence.Abstractions.Repositories;

using static AM.Shared.Abstractions.Constants.Enums;

namespace AM.Portfolio.Core.Abstractions.Persistence.Repositories
{
    public interface IDerivativeRepository : IPersistenceSqlRepository<Derivative>
    {
        Task<Derivative[]> GetDerivativesAsync(AssetTypes type);
        Task<Derivative[]> GetDerivativesAsync();
    }
}
