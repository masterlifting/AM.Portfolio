using AM.Portfolio.Core.Abstractions.Persistence.Repositories;
using AM.Portfolio.Core.Persistence.Entities.Sql.Catalogs;
using Microsoft.Extensions.Logging;

using Net.Shared.Persistence.Abstractions.Contexts;

using Shared.Persistence.Repositories;

namespace AM.Portfolio.Infrastructure.Persistence.Repositories
{
    public sealed class ProcessStepRepository : PostgreRepository<ProcessStep>, IProcessStepRepository
    {
        public ProcessStepRepository(ILogger<ProcessStep> logger, IPersistencePostgreContext context) : base(logger, context)
        {
        }
    }
}
