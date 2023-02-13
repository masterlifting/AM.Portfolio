using AM.Portfolio.Core.Abstractions.Persistence.Repositories;
using AM.Portfolio.Core.Domain.Persistence.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Net.Shared.Persistence.Abstractions.Contexts;

using Shared.Persistence.Repositories;

using static AM.Shared.Abstractions.Constants.Enums;

namespace AM.Portfolio.Infrastructure.Persistence.Repositories
{
    public sealed class DerivativeRepository : PostgreRepository<Derivative>, IDerivativeRepository
    {
        private readonly IPersistencePostgreContext _context;

        public DerivativeRepository(ILogger<Derivative> logger, IPersistencePostgreContext context) : base(logger, context)
        {
            _context = context;
        }

        public Task<Derivative[]> GetDerivativesAsync(AssetTypes type) =>
            _context.Set<Derivative>()
                .Include(x => x.Asset)
                .Where(x => x.Asset.TypeId == (int)type)
                .ToArrayAsync();

        public Task<Derivative[]> GetDerivativesAsync() => _context.FindManyAsync<Derivative>(x => true);
    }
}
