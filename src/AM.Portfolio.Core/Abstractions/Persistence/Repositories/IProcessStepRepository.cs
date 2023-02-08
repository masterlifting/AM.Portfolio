using AM.Portfolio.Core.Domain.Persistence.Entities.Catalogs;

using Net.Shared.Persistence.Abstractions.Repositories;

namespace AM.Portfolio.Core.Abstractions.Persistence.Repositories
{
    public interface IProcessStepRepository : IPersistenceSqlRepository<ProcessStep>
    {
    }
}
